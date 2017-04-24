namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OLAKSICEDataReader : IDisposable
    {
        private ReadWriteCommand cmOLAKSICEDelete2;
        private ReadWriteCommand cmOLAKSICEDelete3;
        private ReadWriteCommand cmOLAKSICESelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OLAKSICESelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDGRUPEOLAKSICA(int iDGRUPEOLAKSICA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICEDelete3 = this.connDefault.GetCommand("DELETE FROM [OLAKSICE]  WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA", false);
            if (this.cmOLAKSICEDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICEDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            this.cmOLAKSICEDelete3.SetParameter(0, iDGRUPEOLAKSICA);
            return this.cmOLAKSICEDelete3.ExecuteStmt();
        }

        public int DeleteByIDTIPOLAKSICE(int iDTIPOLAKSICE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICEDelete2 = this.connDefault.GetCommand("DELETE FROM [OLAKSICE]  WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE", false);
            if (this.cmOLAKSICEDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICEDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            this.cmOLAKSICEDelete2.SetParameter(0, iDTIPOLAKSICE);
            return this.cmOLAKSICEDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.OLAKSICESelect7 != null))
                    {
                        this.m_Closed = true;
                        this.OLAKSICESelect7.Close();
                    }
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

        private void init_reader()
        {
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
            this.m_Disposed = false;
            this.m_Closed = true;
        }

        private void Initialize()
        {
            this.m_Disposed = false;
            this.m_Closed = false;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public IDataReader Open()
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICESelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOLAKSICE], TM1.[NAZIVOLAKSICE], T2.[NAZIVGRUPEOLAKSICA], T2.[MAXIMALNIIZNOSGRUPE], T3.[NAZIVTIPOLAKSICE], TM1.[VBDIOLAKSICA], TM1.[ZRNOLAKSICA], TM1.[PRIMATELJOLAKSICA1], TM1.[PRIMATELJOLAKSICA2], TM1.[PRIMATELJOLAKSICA3], TM1.[IDGRUPEOLAKSICA], TM1.[IDTIPOLAKSICE] FROM (([OLAKSICE] TM1 WITH (NOLOCK) LEFT JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) ORDER BY TM1.[IDOLAKSICE] ", false);
            this.OLAKSICESelect7 = this.cmOLAKSICESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OLAKSICESelect7;
        }

        public IDataReader OpenByIDGRUPEOLAKSICA(int iDGRUPEOLAKSICA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICESelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOLAKSICE], TM1.[NAZIVOLAKSICE], T2.[NAZIVGRUPEOLAKSICA], T2.[MAXIMALNIIZNOSGRUPE], T3.[NAZIVTIPOLAKSICE], TM1.[VBDIOLAKSICA], TM1.[ZRNOLAKSICA], TM1.[PRIMATELJOLAKSICA1], TM1.[PRIMATELJOLAKSICA2], TM1.[PRIMATELJOLAKSICA3], TM1.[IDGRUPEOLAKSICA], TM1.[IDTIPOLAKSICE] FROM (([OLAKSICE] TM1 WITH (NOLOCK) LEFT JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) WHERE TM1.[IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ORDER BY TM1.[IDOLAKSICE] ", false);
            if (this.cmOLAKSICESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            this.cmOLAKSICESelect7.SetParameter(0, iDGRUPEOLAKSICA);
            this.OLAKSICESelect7 = this.cmOLAKSICESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OLAKSICESelect7;
        }

        public IDataReader OpenByIDOLAKSICE(int iDOLAKSICE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICESelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOLAKSICE], TM1.[NAZIVOLAKSICE], T2.[NAZIVGRUPEOLAKSICA], T2.[MAXIMALNIIZNOSGRUPE], T3.[NAZIVTIPOLAKSICE], TM1.[VBDIOLAKSICA], TM1.[ZRNOLAKSICA], TM1.[PRIMATELJOLAKSICA1], TM1.[PRIMATELJOLAKSICA2], TM1.[PRIMATELJOLAKSICA3], TM1.[IDGRUPEOLAKSICA], TM1.[IDTIPOLAKSICE] FROM (([OLAKSICE] TM1 WITH (NOLOCK) LEFT JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) WHERE TM1.[IDOLAKSICE] = @IDOLAKSICE ORDER BY TM1.[IDOLAKSICE] ", false);
            if (this.cmOLAKSICESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            this.cmOLAKSICESelect7.SetParameter(0, iDOLAKSICE);
            this.OLAKSICESelect7 = this.cmOLAKSICESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OLAKSICESelect7;
        }

        public IDataReader OpenByIDTIPOLAKSICE(int iDTIPOLAKSICE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICESelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOLAKSICE], TM1.[NAZIVOLAKSICE], T2.[NAZIVGRUPEOLAKSICA], T2.[MAXIMALNIIZNOSGRUPE], T3.[NAZIVTIPOLAKSICE], TM1.[VBDIOLAKSICA], TM1.[ZRNOLAKSICA], TM1.[PRIMATELJOLAKSICA1], TM1.[PRIMATELJOLAKSICA2], TM1.[PRIMATELJOLAKSICA3], TM1.[IDGRUPEOLAKSICA], TM1.[IDTIPOLAKSICE] FROM (([OLAKSICE] TM1 WITH (NOLOCK) LEFT JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) WHERE TM1.[IDTIPOLAKSICE] = @IDTIPOLAKSICE ORDER BY TM1.[IDOLAKSICE] ", false);
            if (this.cmOLAKSICESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            this.cmOLAKSICESelect7.SetParameter(0, iDTIPOLAKSICE);
            this.OLAKSICESelect7 = this.cmOLAKSICESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OLAKSICESelect7;
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
    }
}

