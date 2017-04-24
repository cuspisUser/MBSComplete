namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Threading;

    public class PROVIDER_NETODataReader : IDisposable
    {
        private static string[] attributeNames = new string[] { "TM1.[IDELEMENT]", "TM1.[NAZIVELEMENT]", "TM1.[IDVRSTAELEMENTA]" };
        private ReadWriteCommand cmELEMENTSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader ELEMENTSelect3;
        private string filterCondition;
        private string filterString;
        private bool m_Disposed;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private string reverseOrderString;
        private string scmdbuf;

        public PROVIDER_NETODataReader()
        {
            this.Init_order_Element();
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
                    this.ELEMENTSelect3.Close();
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

        private void Init_order_Element()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.IDVRSTAELEMENTA, true));
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
            this.m_WhereString = " WHERE " + this.filterString + "  TM1.[IDVRSTAELEMENTA] = 1";
            this.scmdbuf = "SELECT TM1.[IDELEMENT], TM1.[NAZIVELEMENT], TM1.[IDVRSTAELEMENTA], T2.[NAZIVVRSTAELEMENT] FROM ([ELEMENT] TM1 INNER JOIN [VRSTAELEMENT] T2 ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA])" + this.m_WhereString + " " + this.orderString + "  ";
            this.cmELEMENTSelect3 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmELEMENTSelect3.ErrorMask |= ErrorMask.Lock;
            this.ELEMENTSelect3 = this.cmELEMENTSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ELEMENTSelect3;
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
                this.filterString = QueryHelper.AddFilterString(this.filterCondition);
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
            IDELEMENT,
            NAZIVELEMENT,
            IDVRSTAELEMENTA
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PROVIDER_NETODataReader.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PROVIDER_NETODataReader.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PROVIDER_NETODataReader.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PROVIDER_NETODataReader.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PROVIDER_NETODataReader.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}

