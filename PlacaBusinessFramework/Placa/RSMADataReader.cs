namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RSMADataReader : IDisposable
    {
        private ReadWriteCommand cmRSMADelete2;
        private ReadWriteCommand cmRSMADelete3;
        private ReadWriteCommand cmRSMADelete4;
        private ReadWriteCommand cmRSMASelect8;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RSMASelect8;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDOBRACUN(string iDOBRACUN)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMADelete4 = this.connDefault.GetCommand("DELETE FROM [RSMA]  WHERE [IDOBRACUN] = @IDOBRACUN", false);
            if (this.cmRSMADelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMADelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            this.cmRSMADelete4.SetParameter(0, iDOBRACUN);
            return this.cmRSMADelete4.ExecuteStmt();
        }

        public int DeleteByIDRSVRSTEOBRACUNA(string iDRSVRSTEOBRACUNA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMADelete2 = this.connDefault.GetCommand("DELETE FROM [RSMA]  WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA", false);
            if (this.cmRSMADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            this.cmRSMADelete2.SetParameter(0, iDRSVRSTEOBRACUNA);
            return this.cmRSMADelete2.ExecuteStmt();
        }

        public int DeleteByIDRSVRSTEOBVEZNIKA(string iDRSVRSTEOBVEZNIKA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMADelete3 = this.connDefault.GetCommand("DELETE FROM [RSMA]  WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA", false);
            if (this.cmRSMADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            this.cmRSMADelete3.SetParameter(0, iDRSVRSTEOBVEZNIKA);
            return this.cmRSMADelete3.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RSMASelect8 != null))
                    {
                        this.m_Closed = true;
                        this.RSMASelect8.Close();
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
            this.cmRSMASelect8 = this.connDefault.GetCommand("SELECT TM1.[IDENTIFIKATOROBRASCA], TM1.[MBOBVEZNIKA], TM1.[MBGOBVEZNIKA], TM1.[NAZIVOBVEZNIKA], TM1.[ADRESA], T2.[NAZIVRSVRSTEOBVEZNIKA], T3.[NAZIVRSVRSTEOBRACUNA], TM1.[mjesecoBRACUNArsm], TM1.[godinaobracunarsm], TM1.[BROJOSIGURANIKA], TM1.[mjesecisplatersm], TM1.[godinaisplatersm], TM1.[IDRSVRSTEOBVEZNIKA], TM1.[IDRSVRSTEOBRACUNA], TM1.[IDOBRACUN] FROM (([RSMA] TM1 WITH (NOLOCK) LEFT JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) LEFT JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) ORDER BY TM1.[IDENTIFIKATOROBRASCA] ", false);
            this.RSMASelect8 = this.cmRSMASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RSMASelect8;
        }

        public IDataReader OpenByIDENTIFIKATOROBRASCA(string iDENTIFIKATOROBRASCA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect8 = this.connDefault.GetCommand("SELECT TM1.[IDENTIFIKATOROBRASCA], TM1.[MBOBVEZNIKA], TM1.[MBGOBVEZNIKA], TM1.[NAZIVOBVEZNIKA], TM1.[ADRESA], T2.[NAZIVRSVRSTEOBVEZNIKA], T3.[NAZIVRSVRSTEOBRACUNA], TM1.[mjesecoBRACUNArsm], TM1.[godinaobracunarsm], TM1.[BROJOSIGURANIKA], TM1.[mjesecisplatersm], TM1.[godinaisplatersm], TM1.[IDRSVRSTEOBVEZNIKA], TM1.[IDRSVRSTEOBRACUNA], TM1.[IDOBRACUN] FROM (([RSMA] TM1 WITH (NOLOCK) LEFT JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) LEFT JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) WHERE TM1.[IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA ORDER BY TM1.[IDENTIFIKATOROBRASCA] ", false);
            if (this.cmRSMASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            this.cmRSMASelect8.SetParameter(0, iDENTIFIKATOROBRASCA);
            this.RSMASelect8 = this.cmRSMASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RSMASelect8;
        }

        public IDataReader OpenByIDOBRACUN(string iDOBRACUN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect8 = this.connDefault.GetCommand("SELECT TM1.[IDENTIFIKATOROBRASCA], TM1.[MBOBVEZNIKA], TM1.[MBGOBVEZNIKA], TM1.[NAZIVOBVEZNIKA], TM1.[ADRESA], T2.[NAZIVRSVRSTEOBVEZNIKA], T3.[NAZIVRSVRSTEOBRACUNA], TM1.[mjesecoBRACUNArsm], TM1.[godinaobracunarsm], TM1.[BROJOSIGURANIKA], TM1.[mjesecisplatersm], TM1.[godinaisplatersm], TM1.[IDRSVRSTEOBVEZNIKA], TM1.[IDRSVRSTEOBRACUNA], TM1.[IDOBRACUN] FROM (([RSMA] TM1 WITH (NOLOCK) LEFT JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) LEFT JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) WHERE TM1.[IDOBRACUN] = @IDOBRACUN ORDER BY TM1.[IDENTIFIKATOROBRASCA] ", false);
            if (this.cmRSMASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            this.cmRSMASelect8.SetParameter(0, iDOBRACUN);
            this.RSMASelect8 = this.cmRSMASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RSMASelect8;
        }

        public IDataReader OpenByIDRSVRSTEOBRACUNA(string iDRSVRSTEOBRACUNA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect8 = this.connDefault.GetCommand("SELECT TM1.[IDENTIFIKATOROBRASCA], TM1.[MBOBVEZNIKA], TM1.[MBGOBVEZNIKA], TM1.[NAZIVOBVEZNIKA], TM1.[ADRESA], T2.[NAZIVRSVRSTEOBVEZNIKA], T3.[NAZIVRSVRSTEOBRACUNA], TM1.[mjesecoBRACUNArsm], TM1.[godinaobracunarsm], TM1.[BROJOSIGURANIKA], TM1.[mjesecisplatersm], TM1.[godinaisplatersm], TM1.[IDRSVRSTEOBVEZNIKA], TM1.[IDRSVRSTEOBRACUNA], TM1.[IDOBRACUN] FROM (([RSMA] TM1 WITH (NOLOCK) LEFT JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) LEFT JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) WHERE TM1.[IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ORDER BY TM1.[IDENTIFIKATOROBRASCA] ", false);
            if (this.cmRSMASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            this.cmRSMASelect8.SetParameter(0, iDRSVRSTEOBRACUNA);
            this.RSMASelect8 = this.cmRSMASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RSMASelect8;
        }

        public IDataReader OpenByIDRSVRSTEOBVEZNIKA(string iDRSVRSTEOBVEZNIKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect8 = this.connDefault.GetCommand("SELECT TM1.[IDENTIFIKATOROBRASCA], TM1.[MBOBVEZNIKA], TM1.[MBGOBVEZNIKA], TM1.[NAZIVOBVEZNIKA], TM1.[ADRESA], T2.[NAZIVRSVRSTEOBVEZNIKA], T3.[NAZIVRSVRSTEOBRACUNA], TM1.[mjesecoBRACUNArsm], TM1.[godinaobracunarsm], TM1.[BROJOSIGURANIKA], TM1.[mjesecisplatersm], TM1.[godinaisplatersm], TM1.[IDRSVRSTEOBVEZNIKA], TM1.[IDRSVRSTEOBRACUNA], TM1.[IDOBRACUN] FROM (([RSMA] TM1 WITH (NOLOCK) LEFT JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) LEFT JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) WHERE TM1.[IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ORDER BY TM1.[IDENTIFIKATOROBRASCA] ", false);
            if (this.cmRSMASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            this.cmRSMASelect8.SetParameter(0, iDRSVRSTEOBVEZNIKA);
            this.RSMASelect8 = this.cmRSMASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RSMASelect8;
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

