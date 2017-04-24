namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class SHEMAIRADataReader : IDisposable
    {
        private ReadWriteCommand cmSHEMAIRADelete2;
        private ReadWriteCommand cmSHEMAIRASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader SHEMAIRASelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteBySHEMAIRADOKIDDOKUMENT(int sHEMAIRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAIRADelete2 = this.connDefault.GetCommand("DELETE FROM [SHEMAIRA]  WHERE [SHEMAIRADOKIDDOKUMENT] = @SHEMAIRADOKIDDOKUMENT", false);
            if (this.cmSHEMAIRADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAIRADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmSHEMAIRADelete2.SetParameter(0, sHEMAIRADOKIDDOKUMENT);
            return this.cmSHEMAIRADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.SHEMAIRASelect6 != null))
                    {
                        this.m_Closed = true;
                        this.SHEMAIRASelect6.Close();
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
            this.cmSHEMAIRASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAIRA], TM1.[NAZIVSHEMAIRA], TM1.[SHEMAIRADOKIDDOKUMENT] AS SHEMAIRADOKIDDOKUMENT FROM [SHEMAIRA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDSHEMAIRA] ", false);
            this.SHEMAIRASelect6 = this.cmSHEMAIRASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAIRASelect6;
        }

        public IDataReader OpenByIDSHEMAIRA(int iDSHEMAIRA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAIRASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAIRA], TM1.[NAZIVSHEMAIRA], TM1.[SHEMAIRADOKIDDOKUMENT] AS SHEMAIRADOKIDDOKUMENT FROM [SHEMAIRA] TM1 WITH (NOLOCK) WHERE TM1.[IDSHEMAIRA] = @IDSHEMAIRA ORDER BY TM1.[IDSHEMAIRA] ", false);
            if (this.cmSHEMAIRASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAIRASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
            }
            this.cmSHEMAIRASelect6.SetParameter(0, iDSHEMAIRA);
            this.SHEMAIRASelect6 = this.cmSHEMAIRASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAIRASelect6;
        }

        public IDataReader OpenBySHEMAIRADOKIDDOKUMENT(int sHEMAIRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAIRASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAIRA], TM1.[NAZIVSHEMAIRA], TM1.[SHEMAIRADOKIDDOKUMENT] AS SHEMAIRADOKIDDOKUMENT FROM [SHEMAIRA] TM1 WITH (NOLOCK) WHERE TM1.[SHEMAIRADOKIDDOKUMENT] = @SHEMAIRADOKIDDOKUMENT ORDER BY TM1.[IDSHEMAIRA] ", false);
            if (this.cmSHEMAIRASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAIRASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmSHEMAIRASelect6.SetParameter(0, sHEMAIRADOKIDDOKUMENT);
            this.SHEMAIRASelect6 = this.cmSHEMAIRASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAIRASelect6;
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

