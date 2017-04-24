namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Threading;

    public class PregledRadnikaSvihDataReader : IDisposable
    {
        private static string[] attributeNames = new string[] { "TM1.[IDRADNIK]", "TM1.[JMBG]", "TM1.[PREZIME]", "TM1.[IME]", "TM1.[AKTIVAN]", "TM1.[OPCINASTANOVANJAIDOPCINE]", "TM1.[IDORGDIO]", "TM1.[OIB]" };
        private ReadWriteCommand cmRADNIKSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m_Disposed;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private IDataReader RADNIKSelect3;
        private string reverseOrderString;
        private string scmdbuf;

        public PregledRadnikaSvihDataReader()
        {
            this.Init_order_Radnik();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    this.RADNIKSelect3.Close();
                }
                finally
                {
                    try
                    {
                        this.connDefault.Close();
                    }
                    finally
                    {
                        this.Cleanup();
                    }
                }
            }
        }

        public static string GetAttributeName(Attribute attribute)
        {
            return attributeNames[(int) attribute];
        }

        public static string GetOrderString(ArrayList ListOrder, bool AscendingOrder)
        {
            IEnumerator enumerator = null;
            string str2 = "";
            string str3 = "";
            if (ListOrder.Count > 0)
            {
                str3 = " ORDER BY ";
            }
            try
            {
                enumerator = ListOrder.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    OrderAttribute current = (OrderAttribute) enumerator.Current;
                    if (current.OrderAttributeAscending == AscendingOrder)
                    {
                        str2 = str2 + str3 + " " + current.OrderAttributeString;
                    }
                    else
                    {
                        str2 = str2 + str3 + " " + current.OrderAttributeString + " DESC";
                    }
                    str3 = ", ";
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            return str2;
        }

        private void Init_order_Radnik()
        {
            this.Order = new ArrayList();
        }

        private void init_reader()
        {
            this.Initialize();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
            this.m_Disposed = false;
        }

        private void Initialize()
        {
            this.m_Disposed = false;
            this.scmdbuf = "";
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public IDataReader Open()
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.m_WhereString = "" + this.filterString + "  ";
            this.scmdbuf = "SELECT TM1.[IDRADNIK], TM1.[JMBG], TM1.[PREZIME], TM1.[IME], TM1.[AKTIVAN], TM1.[OPCINASTANOVANJAIDOPCINE], TM1.[IDORGDIO], TM1.[OIB] FROM [RADNIK] TM1" + this.m_WhereString + " " + this.orderString + "  ";
            this.cmRADNIKSelect3 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKSelect3.ErrorMask |= ErrorMask.Lock;
            this.RADNIKSelect3 = this.cmRADNIKSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect3;
        }

        public string Filter
        {
            get
            {
                return this.filterCondition;
            }
            set
            {
                this.filterCondition = value;
                this.filterString = QueryHelper.GetFilterString(this.filterCondition);
                this.filterStringCond = QueryHelper.AddFilterString(this.filterCondition);
            }
        }

        public ArrayList Order
        {
            get
            {
                return this.orderArray;
            }
            set
            {
                this.orderArray = value;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.daCurrentTransaction;
            }
            set
            {
                this.daCurrentTransaction = value;
            }
        }

        public enum Attribute
        {
            IDRADNIK,
            JMBG,
            PREZIME,
            IME,
            AKTIVAN,
            OPCINASTANOVANJAIDOPCINE,
            IDORGDIO,
            OIB
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PregledRadnikaSvihDataReader.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PregledRadnikaSvihDataReader.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PregledRadnikaSvihDataReader.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PregledRadnikaSvihDataReader.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PregledRadnikaSvihDataReader.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}

