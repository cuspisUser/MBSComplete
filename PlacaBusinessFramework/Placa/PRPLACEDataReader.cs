namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class PRPLACEDataReader : IDisposable
    {
        private ReadWriteCommand cmPRPLACEDelete2;
        private ReadWriteCommand cmPRPLACEDelete3;
        private ReadWriteCommand cmPRPLACESelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader PRPLACESelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByPRPLACEID(int pRPLACEID)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACEDelete3 = this.connDefault.GetCommand("DELETE FROM [PRPLACE]  WHERE [PRPLACEID] = @PRPLACEID", false);
            if (this.cmPRPLACEDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACEDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
            }
            this.cmPRPLACEDelete3.SetParameter(0, pRPLACEID);
            return this.cmPRPLACEDelete3.ExecuteStmt();
        }

        public int DeleteByPRPLACEIDPRPLACEZAMJESEC(int pRPLACEID, short pRPLACEZAMJESEC)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACEDelete2 = this.connDefault.GetCommand("DELETE FROM [PRPLACE]  WHERE [PRPLACEID] = @PRPLACEID and [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC", false);
            if (this.cmPRPLACEDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACEDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACEDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
            }
            this.cmPRPLACEDelete2.SetParameter(0, pRPLACEID);
            this.cmPRPLACEDelete2.SetParameter(1, pRPLACEZAMJESEC);
            return this.cmPRPLACEDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.PRPLACESelect7 != null))
                    {
                        this.m_Closed = true;
                        this.PRPLACESelect7.Close();
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
            this.cmPRPLACESelect7 = this.connDefault.GetCommand("SELECT TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU], TM1.[PRPLACEOPIS], TM1.[PRPLACEOSNOVICA], TM1.[PRPLACEPROSJECNISATI] FROM [PRPLACE] TM1 WITH (NOLOCK) ORDER BY TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU] ", false);
            this.PRPLACESelect7 = this.cmPRPLACESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PRPLACESelect7;
        }

        public IDataReader OpenByPRPLACEID(int pRPLACEID)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACESelect7 = this.connDefault.GetCommand("SELECT TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU], TM1.[PRPLACEOPIS], TM1.[PRPLACEOSNOVICA], TM1.[PRPLACEPROSJECNISATI] FROM [PRPLACE] TM1 WITH (NOLOCK) WHERE TM1.[PRPLACEID] = @PRPLACEID ORDER BY TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU] ", false);
            if (this.cmPRPLACESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
            }
            this.cmPRPLACESelect7.SetParameter(0, pRPLACEID);
            this.PRPLACESelect7 = this.cmPRPLACESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PRPLACESelect7;
        }

        public IDataReader OpenByPRPLACEIDPRPLACEZAMJESEC(int pRPLACEID, short pRPLACEZAMJESEC)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACESelect7 = this.connDefault.GetCommand("SELECT TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU], TM1.[PRPLACEOPIS], TM1.[PRPLACEOSNOVICA], TM1.[PRPLACEPROSJECNISATI] FROM [PRPLACE] TM1 WITH (NOLOCK) WHERE TM1.[PRPLACEID] = @PRPLACEID and TM1.[PRPLACEZAMJESEC] = @PRPLACEZAMJESEC ORDER BY TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU] ", false);
            if (this.cmPRPLACESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
            }
            this.cmPRPLACESelect7.SetParameter(0, pRPLACEID);
            this.cmPRPLACESelect7.SetParameter(1, pRPLACEZAMJESEC);
            this.PRPLACESelect7 = this.cmPRPLACESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PRPLACESelect7;
        }

        public IDataReader OpenByPRPLACEIDPRPLACEZAMJESECPRPLACEZAGODINU(int pRPLACEID, short pRPLACEZAMJESEC, short pRPLACEZAGODINU)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACESelect7 = this.connDefault.GetCommand("SELECT TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU], TM1.[PRPLACEOPIS], TM1.[PRPLACEOSNOVICA], TM1.[PRPLACEPROSJECNISATI] FROM [PRPLACE] TM1 WITH (NOLOCK) WHERE TM1.[PRPLACEID] = @PRPLACEID and TM1.[PRPLACEZAMJESEC] = @PRPLACEZAMJESEC and TM1.[PRPLACEZAGODINU] = @PRPLACEZAGODINU ORDER BY TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU] ", false);
            if (this.cmPRPLACESelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                this.cmPRPLACESelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
            }
            this.cmPRPLACESelect7.SetParameter(0, pRPLACEID);
            this.cmPRPLACESelect7.SetParameter(1, pRPLACEZAMJESEC);
            this.cmPRPLACESelect7.SetParameter(2, pRPLACEZAGODINU);
            this.PRPLACESelect7 = this.cmPRPLACESelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PRPLACESelect7;
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

