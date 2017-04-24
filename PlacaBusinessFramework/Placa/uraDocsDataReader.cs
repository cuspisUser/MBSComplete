namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Threading;

    public class uraDocsDataReader : IDisposable
    {
        private static string[] attributeNames = new string[] { "TM1.[IDDOKUMENT]", "TM1.[NAZIVDOKUMENT]", "TM1.[IDTIPDOKUMENTA]", "T2.[NAZIVTIPDOKUMENTA]", "TM1.[PS]" };
        private ReadWriteCommand cmDOKUMENTSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOKUMENTSelect3;
        private DataStore dsDefault;
        private string filterCondition;
        private string filterString;
        private bool m_Disposed;
        private string m_WhereString;
        private ArrayList orderArray;
        private string orderString;
        private string reverseOrderString;
        private string scmdbuf;

        public uraDocsDataReader()
        {
            this.Init_order_Dokument();
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
                    this.DOKUMENTSelect3.Close();
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

        private void Init_order_Dokument()
        {
            this.Order = new ArrayList();
            this.Order.Add(new OrderAttribute(Attribute.IDTIPDOKUMENTA, true));
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
            this.m_WhereString = " WHERE " + this.filterString + "  TM1.[IDTIPDOKUMENTA] = 2";
            this.scmdbuf = "SELECT TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], TM1.[IDTIPDOKUMENTA], T2.[NAZIVTIPDOKUMENTA], TM1.[PS] FROM ([DOKUMENT] TM1 INNER JOIN [TIPDOKUMENTA] T2 ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + " " + this.orderString + "  ";
            this.cmDOKUMENTSelect3 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmDOKUMENTSelect3.ErrorMask |= ErrorMask.Lock;
            this.DOKUMENTSelect3 = this.cmDOKUMENTSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOKUMENTSelect3;
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
            IDDOKUMENT,
            NAZIVDOKUMENT,
            IDTIPDOKUMENTA,
            NAZIVTIPDOKUMENTA,
            PS
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public uraDocsDataReader.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(uraDocsDataReader.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = uraDocsDataReader.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(uraDocsDataReader.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = uraDocsDataReader.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}

