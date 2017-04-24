namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class SHEMAURADataReader : IDisposable
    {
        private ReadWriteCommand cmSHEMAURADelete2;
        private ReadWriteCommand cmSHEMAURASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader SHEMAURASelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByPARTNERSHEMAURAIDPARTNER(int pARTNERSHEMAURAIDPARTNER)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAURADelete2 = this.connDefault.GetCommand("DELETE FROM [SHEMAURA]  WHERE [PARTNERSHEMAURAIDPARTNER] = @PARTNERSHEMAURAIDPARTNER", false);
            if (this.cmSHEMAURADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAURADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
            }
            this.cmSHEMAURADelete2.SetParameter(0, pARTNERSHEMAURAIDPARTNER);
            return this.cmSHEMAURADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.SHEMAURASelect6 != null))
                    {
                        this.m_Closed = true;
                        this.SHEMAURASelect6.Close();
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
            this.cmSHEMAURASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAURA], TM1.[NAZIVSHEMAURA], TM1.[PARTNERSHEMAURAIDPARTNER] AS PARTNERSHEMAURAIDPARTNER FROM [SHEMAURA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDSHEMAURA] ", false);
            this.SHEMAURASelect6 = this.cmSHEMAURASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAURASelect6;
        }

        public IDataReader OpenByIDSHEMAURA(int iDSHEMAURA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAURASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAURA], TM1.[NAZIVSHEMAURA], TM1.[PARTNERSHEMAURAIDPARTNER] AS PARTNERSHEMAURAIDPARTNER FROM [SHEMAURA] TM1 WITH (NOLOCK) WHERE TM1.[IDSHEMAURA] = @IDSHEMAURA ORDER BY TM1.[IDSHEMAURA] ", false);
            if (this.cmSHEMAURASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAURASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
            }
            this.cmSHEMAURASelect6.SetParameter(0, iDSHEMAURA);
            this.SHEMAURASelect6 = this.cmSHEMAURASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAURASelect6;
        }

        public IDataReader OpenByPARTNERSHEMAURAIDPARTNER(int pARTNERSHEMAURAIDPARTNER)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAURASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAURA], TM1.[NAZIVSHEMAURA], TM1.[PARTNERSHEMAURAIDPARTNER] AS PARTNERSHEMAURAIDPARTNER FROM [SHEMAURA] TM1 WITH (NOLOCK) WHERE TM1.[PARTNERSHEMAURAIDPARTNER] = @PARTNERSHEMAURAIDPARTNER ORDER BY TM1.[IDSHEMAURA] ", false);
            if (this.cmSHEMAURASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAURASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
            }
            this.cmSHEMAURASelect6.SetParameter(0, pARTNERSHEMAURAIDPARTNER);
            this.SHEMAURASelect6 = this.cmSHEMAURASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAURASelect6;
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

