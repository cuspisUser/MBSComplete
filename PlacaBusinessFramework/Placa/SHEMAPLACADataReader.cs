namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class SHEMAPLACADataReader : IDisposable
    {
        private ReadWriteCommand cmSHEMAPLACADelete2;
        private ReadWriteCommand cmSHEMAPLACASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader SHEMAPLACASelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteBySHEMAPLOJIDORGJED(int sHEMAPLOJIDORGJED)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAPLACADelete2 = this.connDefault.GetCommand("DELETE FROM [SHEMAPLACA]  WHERE [SHEMAPLOJIDORGJED] = @SHEMAPLOJIDORGJED", false);
            if (this.cmSHEMAPLACADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMAPLACADelete2.SetParameter(0, sHEMAPLOJIDORGJED);
            return this.cmSHEMAPLACADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.SHEMAPLACASelect6 != null))
                    {
                        this.m_Closed = true;
                        this.SHEMAPLACASelect6.Close();
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
            this.cmSHEMAPLACASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAPLACA], TM1.[NAZIVSHEMAPLACA], TM1.[SHEMAPLOJIDORGJED] AS SHEMAPLOJIDORGJED FROM [SHEMAPLACA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDSHEMAPLACA] ", false);
            this.SHEMAPLACASelect6 = this.cmSHEMAPLACASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAPLACASelect6;
        }

        public IDataReader OpenByIDSHEMAPLACA(int iDSHEMAPLACA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAPLACASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAPLACA], TM1.[NAZIVSHEMAPLACA], TM1.[SHEMAPLOJIDORGJED] AS SHEMAPLOJIDORGJED FROM [SHEMAPLACA] TM1 WITH (NOLOCK) WHERE TM1.[IDSHEMAPLACA] = @IDSHEMAPLACA ORDER BY TM1.[IDSHEMAPLACA] ", false);
            if (this.cmSHEMAPLACASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAPLACA", DbType.Int32));
            }
            this.cmSHEMAPLACASelect6.SetParameter(0, iDSHEMAPLACA);
            this.SHEMAPLACASelect6 = this.cmSHEMAPLACASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAPLACASelect6;
        }

        public IDataReader OpenBySHEMAPLOJIDORGJED(int sHEMAPLOJIDORGJED)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAPLACASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMAPLACA], TM1.[NAZIVSHEMAPLACA], TM1.[SHEMAPLOJIDORGJED] AS SHEMAPLOJIDORGJED FROM [SHEMAPLACA] TM1 WITH (NOLOCK) WHERE TM1.[SHEMAPLOJIDORGJED] = @SHEMAPLOJIDORGJED ORDER BY TM1.[IDSHEMAPLACA] ", false);
            if (this.cmSHEMAPLACASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAPLACASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAPLOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMAPLACASelect6.SetParameter(0, sHEMAPLOJIDORGJED);
            this.SHEMAPLACASelect6 = this.cmSHEMAPLACASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMAPLACASelect6;
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

