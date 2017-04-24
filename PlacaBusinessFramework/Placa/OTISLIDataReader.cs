namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OTISLIDataReader : IDisposable
    {
        private ReadWriteCommand cmOTISLIDelete2;
        private ReadWriteCommand cmOTISLISelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OTISLISelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDRADNIK(int iDRADNIK)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOTISLIDelete2 = this.connDefault.GetCommand("DELETE FROM [OTISLI]  WHERE [IDRADNIK] = @IDRADNIK", false);
            if (this.cmOTISLIDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOTISLIDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOTISLIDelete2.SetParameter(0, iDRADNIK);
            return this.cmOTISLIDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.OTISLISelect6 != null))
                    {
                        this.m_Closed = true;
                        this.OTISLISelect6.Close();
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
            this.cmOTISLISelect6 = this.connDefault.GetCommand("SELECT TM1.[DATUMODLASKA], TM1.[IDRADNIK] FROM [OTISLI] TM1 WITH (NOLOCK) ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ", false);
            this.OTISLISelect6 = this.cmOTISLISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OTISLISelect6;
        }

        public IDataReader OpenByIDRADNIK(int iDRADNIK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOTISLISelect6 = this.connDefault.GetCommand("SELECT TM1.[DATUMODLASKA], TM1.[IDRADNIK] FROM [OTISLI] TM1 WITH (NOLOCK) WHERE TM1.[IDRADNIK] = @IDRADNIK ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ", false);
            if (this.cmOTISLISelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOTISLISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmOTISLISelect6.SetParameter(0, iDRADNIK);
            this.OTISLISelect6 = this.cmOTISLISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OTISLISelect6;
        }

        public IDataReader OpenByIDRADNIKDATUMODLASKA(int iDRADNIK, DateTime dATUMODLASKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOTISLISelect6 = this.connDefault.GetCommand("SELECT TM1.[DATUMODLASKA], TM1.[IDRADNIK] FROM [OTISLI] TM1 WITH (NOLOCK) WHERE TM1.[IDRADNIK] = @IDRADNIK and TM1.[DATUMODLASKA] = @DATUMODLASKA ORDER BY TM1.[IDRADNIK], TM1.[DATUMODLASKA] ", false);
            if (this.cmOTISLISelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOTISLISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                this.cmOTISLISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMODLASKA", DbType.Date));
            }
            this.cmOTISLISelect6.SetParameter(0, iDRADNIK);
            this.cmOTISLISelect6.SetParameterDateObject(1, dATUMODLASKA);
            this.OTISLISelect6 = this.cmOTISLISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OTISLISelect6;
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

