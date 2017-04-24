namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OSNOVAOSIGURANJADataReader : IDisposable
    {
        private ReadWriteCommand cmOSNOVAOSIGURANJADelete2;
        private ReadWriteCommand cmOSNOVAOSIGURANJASelect10;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OSNOVAOSIGURANJASelect10;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByZAMOOIDOSNOVAOSIGURANJA(string zAMOOIDOSNOVAOSIGURANJA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSNOVAOSIGURANJADelete2 = this.connDefault.GetCommand("DELETE FROM [OSNOVAOSIGURANJA]  WHERE [ZAMOOIDOSNOVAOSIGURANJA] = @ZAMOOIDOSNOVAOSIGURANJA", false);
            if (this.cmOSNOVAOSIGURANJADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSNOVAOSIGURANJADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmOSNOVAOSIGURANJADelete2.SetParameter(0, zAMOOIDOSNOVAOSIGURANJA);
            return this.cmOSNOVAOSIGURANJADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.OSNOVAOSIGURANJASelect10 != null))
                    {
                        this.m_Closed = true;
                        this.OSNOVAOSIGURANJASelect10.Close();
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
            this.cmOSNOVAOSIGURANJASelect10 = this.connDefault.GetCommand("SELECT TM1.[IDOSNOVAOSIGURANJA], TM1.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[NAZIVOSNOVAOSIGURANJA], T2.[NAZIVOSNOVAOSIGURANJA] AS ZAMOONAZIVOSNOVAOSIGURANJA, TM1.[ZAMOOIDOSNOVAOSIGURANJA] AS ZAMOOIDOSNOVAOSIGURANJA FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA]) ORDER BY TM1.[IDOSNOVAOSIGURANJA] ", false);
            this.OSNOVAOSIGURANJASelect10 = this.cmOSNOVAOSIGURANJASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSNOVAOSIGURANJASelect10;
        }

        public IDataReader OpenByIDOSNOVAOSIGURANJA(string iDOSNOVAOSIGURANJA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSNOVAOSIGURANJASelect10 = this.connDefault.GetCommand("SELECT TM1.[IDOSNOVAOSIGURANJA], TM1.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[NAZIVOSNOVAOSIGURANJA], T2.[NAZIVOSNOVAOSIGURANJA] AS ZAMOONAZIVOSNOVAOSIGURANJA, TM1.[ZAMOOIDOSNOVAOSIGURANJA] AS ZAMOOIDOSNOVAOSIGURANJA FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA]) WHERE TM1.[IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ORDER BY TM1.[IDOSNOVAOSIGURANJA] ", false);
            if (this.cmOSNOVAOSIGURANJASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSNOVAOSIGURANJASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmOSNOVAOSIGURANJASelect10.SetParameterString(0, iDOSNOVAOSIGURANJA);
            this.OSNOVAOSIGURANJASelect10 = this.cmOSNOVAOSIGURANJASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSNOVAOSIGURANJASelect10;
        }

        public IDataReader OpenByZAMOOIDOSNOVAOSIGURANJA(string zAMOOIDOSNOVAOSIGURANJA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSNOVAOSIGURANJASelect10 = this.connDefault.GetCommand("SELECT TM1.[IDOSNOVAOSIGURANJA], TM1.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[NAZIVOSNOVAOSIGURANJA], T2.[NAZIVOSNOVAOSIGURANJA] AS ZAMOONAZIVOSNOVAOSIGURANJA, TM1.[ZAMOOIDOSNOVAOSIGURANJA] AS ZAMOOIDOSNOVAOSIGURANJA FROM ([OSNOVAOSIGURANJA] TM1 WITH (NOLOCK) LEFT JOIN [OSNOVAOSIGURANJA] T2 WITH (NOLOCK) ON T2.[IDOSNOVAOSIGURANJA] = TM1.[ZAMOOIDOSNOVAOSIGURANJA]) WHERE TM1.[ZAMOOIDOSNOVAOSIGURANJA] = @ZAMOOIDOSNOVAOSIGURANJA ORDER BY TM1.[IDOSNOVAOSIGURANJA] ", false);
            if (this.cmOSNOVAOSIGURANJASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSNOVAOSIGURANJASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAMOOIDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmOSNOVAOSIGURANJASelect10.SetParameter(0, zAMOOIDOSNOVAOSIGURANJA);
            this.OSNOVAOSIGURANJASelect10 = this.cmOSNOVAOSIGURANJASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSNOVAOSIGURANJASelect10;
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

