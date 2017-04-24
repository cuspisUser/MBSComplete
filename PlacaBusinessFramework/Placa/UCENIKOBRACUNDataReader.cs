namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class UCENIKOBRACUNDataReader : IDisposable
    {
        private ReadWriteCommand cmUCENIKOBRACUNDelete2;
        private ReadWriteCommand cmUCENIKOBRACUNSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader UCENIKOBRACUNSelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByUCOBRMJESEC(int uCOBRMJESEC)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKOBRACUNDelete2 = this.connDefault.GetCommand("DELETE FROM [UCENIKOBRACUN]  WHERE [UCOBRMJESEC] = @UCOBRMJESEC", false);
            if (this.cmUCENIKOBRACUNDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKOBRACUNDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
            }
            this.cmUCENIKOBRACUNDelete2.SetParameter(0, uCOBRMJESEC);
            return this.cmUCENIKOBRACUNDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.UCENIKOBRACUNSelect6 != null))
                    {
                        this.m_Closed = true;
                        this.UCENIKOBRACUNSelect6.Close();
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
            this.cmUCENIKOBRACUNSelect6 = this.connDefault.GetCommand("SELECT TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA], TM1.[AKTIVANZARSM], TM1.[UCOBROPIS], TM1.[OSNOVICAPODANU] FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK) ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ", false);
            this.UCENIKOBRACUNSelect6 = this.cmUCENIKOBRACUNSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.UCENIKOBRACUNSelect6;
        }

        public IDataReader OpenByUCOBRMJESEC(int uCOBRMJESEC)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKOBRACUNSelect6 = this.connDefault.GetCommand("SELECT TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA], TM1.[AKTIVANZARSM], TM1.[UCOBROPIS], TM1.[OSNOVICAPODANU] FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK) WHERE TM1.[UCOBRMJESEC] = @UCOBRMJESEC ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ", false);
            if (this.cmUCENIKOBRACUNSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKOBRACUNSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
            }
            this.cmUCENIKOBRACUNSelect6.SetParameter(0, uCOBRMJESEC);
            this.UCENIKOBRACUNSelect6 = this.cmUCENIKOBRACUNSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.UCENIKOBRACUNSelect6;
        }

        public IDataReader OpenByUCOBRMJESECUCOBRGODINA(int uCOBRMJESEC, int uCOBRGODINA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKOBRACUNSelect6 = this.connDefault.GetCommand("SELECT TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA], TM1.[AKTIVANZARSM], TM1.[UCOBROPIS], TM1.[OSNOVICAPODANU] FROM [UCENIKOBRACUN] TM1 WITH (NOLOCK) WHERE TM1.[UCOBRMJESEC] = @UCOBRMJESEC and TM1.[UCOBRGODINA] = @UCOBRGODINA ORDER BY TM1.[UCOBRMJESEC], TM1.[UCOBRGODINA] ", false);
            if (this.cmUCENIKOBRACUNSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKOBRACUNSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRMJESEC", DbType.Int32));
                this.cmUCENIKOBRACUNSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCOBRGODINA", DbType.Int32));
            }
            this.cmUCENIKOBRACUNSelect6.SetParameter(0, uCOBRMJESEC);
            this.cmUCENIKOBRACUNSelect6.SetParameter(1, uCOBRGODINA);
            this.UCENIKOBRACUNSelect6 = this.cmUCENIKOBRACUNSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.UCENIKOBRACUNSelect6;
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

