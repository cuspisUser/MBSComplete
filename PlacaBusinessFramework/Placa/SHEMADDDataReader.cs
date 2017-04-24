namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class SHEMADDDataReader : IDisposable
    {
        private ReadWriteCommand cmSHEMADDDelete2;
        private ReadWriteCommand cmSHEMADDSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader SHEMADDSelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteBySHEMADDOJIDORGJED(int sHEMADDOJIDORGJED)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMADDDelete2 = this.connDefault.GetCommand("DELETE FROM [SHEMADD]  WHERE [SHEMADDOJIDORGJED] = @SHEMADDOJIDORGJED", false);
            if (this.cmSHEMADDDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMADDDelete2.SetParameter(0, sHEMADDOJIDORGJED);
            return this.cmSHEMADDDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.SHEMADDSelect6 != null))
                    {
                        this.m_Closed = true;
                        this.SHEMADDSelect6.Close();
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
            this.cmSHEMADDSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMADD], TM1.[NAZIVSHEMADD], TM1.[SHEMADDOJIDORGJED] AS SHEMADDOJIDORGJED FROM [SHEMADD] TM1 WITH (NOLOCK) ORDER BY TM1.[IDSHEMADD] ", false);
            this.SHEMADDSelect6 = this.cmSHEMADDSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMADDSelect6;
        }

        public IDataReader OpenByIDSHEMADD(int iDSHEMADD)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMADDSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMADD], TM1.[NAZIVSHEMADD], TM1.[SHEMADDOJIDORGJED] AS SHEMADDOJIDORGJED FROM [SHEMADD] TM1 WITH (NOLOCK) WHERE TM1.[IDSHEMADD] = @IDSHEMADD ORDER BY TM1.[IDSHEMADD] ", false);
            if (this.cmSHEMADDSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMADD", DbType.Int32));
            }
            this.cmSHEMADDSelect6.SetParameter(0, iDSHEMADD);
            this.SHEMADDSelect6 = this.cmSHEMADDSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMADDSelect6;
        }

        public IDataReader OpenBySHEMADDOJIDORGJED(int sHEMADDOJIDORGJED)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMADDSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDSHEMADD], TM1.[NAZIVSHEMADD], TM1.[SHEMADDOJIDORGJED] AS SHEMADDOJIDORGJED FROM [SHEMADD] TM1 WITH (NOLOCK) WHERE TM1.[SHEMADDOJIDORGJED] = @SHEMADDOJIDORGJED ORDER BY TM1.[IDSHEMADD] ", false);
            if (this.cmSHEMADDSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMADDSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMADDOJIDORGJED", DbType.Int32));
            }
            this.cmSHEMADDSelect6.SetParameter(0, sHEMADDOJIDORGJED);
            this.SHEMADDSelect6 = this.cmSHEMADDSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SHEMADDSelect6;
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

