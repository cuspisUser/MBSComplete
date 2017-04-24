namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Threading;

    public class PregledObracunaDataReader : IDisposable
    {
        private static string[] attributeNames = new string[] { 
            "[IDOBRACUN]", "[VRSTAOBRACUNA]", "[MJESECOBRACUNA]", "[GODINAOBRACUNA]", "[MJESECISPLATE]", "[GODINAISPLATE]", "[DATUMISPLATE]", "[tjednifondsatiobracun]", "[MJESECNIFONDSATIOBRACUN]", "[OSNOVNIOO]", "[OBRACUNSKAOSNOVICA]", "[DATUMOBRACUNASTAZA]", "[OBRPOSTOTNIH]", "[OBRFIKSNIH]", "[OBRKREDITNIH]", "[ZAKLJ]", 
            "[SVRHAOBRACUNA]", "[IDENTIFIKATOROBRASCA]"
         };
        private ReadWriteCommand cmPregledObracunaSelect3;
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
        private IDataReader PregledObracunaSelect3;
        private string reverseOrderString;
        private string scmdbuf;

        public PregledObracunaDataReader()
        {
            this.Init_order_Pregledobracuna();
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
                    this.PregledObracunaSelect3.Close();
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

        private void Init_order_Pregledobracuna()
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
            this.scmdbuf = "SELECT [IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], [tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], [OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA], [IDENTIFIKATOROBRASCA] FROM [vwPregledObracuna]" + this.m_WhereString + " " + this.orderString + "  ";
            this.cmPregledObracunaSelect3 = this.connDefault.GetCommand(this.scmdbuf, true);
            this.cmPregledObracunaSelect3.ErrorMask |= ErrorMask.Lock;
            this.PregledObracunaSelect3 = this.cmPregledObracunaSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PregledObracunaSelect3;
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
            IDOBRACUN,
            VRSTAOBRACUNA,
            MJESECOBRACUNA,
            GODINAOBRACUNA,
            MJESECISPLATE,
            GODINAISPLATE,
            DATUMISPLATE,
            tjednifondsatiobracun,
            MJESECNIFONDSATIOBRACUN,
            OSNOVNIOO,
            OBRACUNSKAOSNOVICA,
            DATUMOBRACUNASTAZA,
            OBRPOSTOTNIH,
            OBRFIKSNIH,
            OBRKREDITNIH,
            ZAKLJ,
            SVRHAOBRACUNA,
            IDENTIFIKATOROBRASCA
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public PregledObracunaDataReader.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(PregledObracunaDataReader.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = PregledObracunaDataReader.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(PregledObracunaDataReader.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = PregledObracunaDataReader.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}

