namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Threading;

    public class PREGLEDZADUZENJADataReader : IDisposable
    {
        private static string[] attributeNames = new string[] { "T1.[IDPARTNER]", "T4.[NAZIVPARTNER]", "T4.[PARTNEROIB]", "T2.[NAZIVPROIZVOD]", "T1.[IDPROIZVOD]", "T1.[IDZADUZENJE]", "T1.[KOLICINAZADUZENJA]", "T1.[CIJENAZADUZENJA]", "T3.[FINPOREZSTOPA]", "T1.[RABATZADUZENJA]", "T1.[UGOVORBROJ]", "T1.[DATUMUGOVORA]", "T1.[AKTIVNO]" };
        private ReadWriteCommand cmPARTNERZADUZENJESelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private string filterCondition;
        private string filterString;
        private bool m_Disposed;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private IDataReader PARTNERZADUZENJESelect3;
        private string reverseOrderString;
        private string scmdbuf;

        public PREGLEDZADUZENJADataReader()
        {
            this.Init_order_Partnerzaduzenje();
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
                    this.PARTNERZADUZENJESelect3.Close();
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

        private void Init_order_Partnerzaduzenje()
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
            this.m_WhereString = " WHERE " + this.filterString + "  T1.[AKTIVNO] = 1";
            this.scmdbuf = "SELECT T1.[IDPARTNER], T4.[NAZIVPARTNER], T4.[PARTNEROIB], T2.[NAZIVPROIZVOD], T1.[IDPROIZVOD], T1.[IDZADUZENJE], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T3.[FINPOREZSTOPA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T2.[FINPOREZIDPOREZ] FROM ((([PARTNERZADUZENJE] T1 INNER JOIN [PROIZVOD] T2 ON T2.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T3 ON T3.[FINPOREZIDPOREZ] = T2.[FINPOREZIDPOREZ]) INNER JOIN [PARTNER] T4 ON T4.[IDPARTNER] = T1.[IDPARTNER])" + this.m_WhereString + " " + this.orderString + "  ";
            this.cmPARTNERZADUZENJESelect3 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmPARTNERZADUZENJESelect3.ErrorMask |= ErrorMask.Lock;
            this.PARTNERZADUZENJESelect3 = this.cmPARTNERZADUZENJESelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PARTNERZADUZENJESelect3;
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
            IDPARTNER,
            NAZIVPARTNER,
            PARTNEROIB,
            NAZIVPROIZVOD,
            IDPROIZVOD,
            IDZADUZENJE,
            KOLICINAZADUZENJA,
            CIJENAZADUZENJA,
            FINPOREZSTOPA,
            RABATZADUZENJA,
            UGOVORBROJ,
            DATUMUGOVORA,
            AKTIVNO
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PREGLEDZADUZENJADataReader.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PREGLEDZADUZENJADataReader.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PREGLEDZADUZENJADataReader.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PREGLEDZADUZENJADataReader.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PREGLEDZADUZENJADataReader.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}

