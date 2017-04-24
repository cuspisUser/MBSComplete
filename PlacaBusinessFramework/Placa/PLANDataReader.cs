namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class PLANDataReader : IDisposable
    {
        private ReadWriteCommand cmPLANDelete2;
        private ReadWriteCommand cmPLANDelete3;
        private ReadWriteCommand cmPLANSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader PLANSelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDPLAN(int iDPLAN)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANDelete2 = this.connDefault.GetCommand("DELETE FROM [PLAN]  WHERE [IDPLAN] = @IDPLAN", false);
            if (this.cmPLANDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
            }
            this.cmPLANDelete2.SetParameter(0, iDPLAN);
            return this.cmPLANDelete2.ExecuteStmt();
        }

        public int DeleteByPLANGODINAIDGODINE(short pLANGODINAIDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANDelete3 = this.connDefault.GetCommand("DELETE FROM [PLAN]  WHERE [PLANGODINAIDGODINE] = @PLANGODINAIDGODINE", false);
            if (this.cmPLANDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            this.cmPLANDelete3.SetParameter(0, pLANGODINAIDGODINE);
            return this.cmPLANDelete3.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.PLANSelect7 != null))
                    {
                        this.m_Closed = true;
                        this.PLANSelect7.Close();
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
            this.cmPLANSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPLAN], TM1.[RADNINAZIVPLANA], TM1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE FROM [PLAN] TM1 WITH (NOLOCK) ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ", false);
            this.PLANSelect7 = this.cmPLANSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PLANSelect7;
        }

        public IDataReader OpenByIDPLAN(int iDPLAN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPLAN], TM1.[RADNINAZIVPLANA], TM1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE FROM [PLAN] TM1 WITH (NOLOCK) WHERE TM1.[IDPLAN] = @IDPLAN ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ", false);
            if (this.cmPLANSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
            }
            this.cmPLANSelect7.SetParameter(0, iDPLAN);
            this.PLANSelect7 = this.cmPLANSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PLANSelect7;
        }

        public IDataReader OpenByIDPLANPLANGODINAIDGODINE(int iDPLAN, short pLANGODINAIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPLAN], TM1.[RADNINAZIVPLANA], TM1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE FROM [PLAN] TM1 WITH (NOLOCK) WHERE TM1.[IDPLAN] = @IDPLAN and TM1.[PLANGODINAIDGODINE] = @PLANGODINAIDGODINE ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ", false);
            if (this.cmPLANSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLAN", DbType.Int32));
                this.cmPLANSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            this.cmPLANSelect7.SetParameter(0, iDPLAN);
            this.cmPLANSelect7.SetParameter(1, pLANGODINAIDGODINE);
            this.PLANSelect7 = this.cmPLANSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PLANSelect7;
        }

        public IDataReader OpenByPLANGODINAIDGODINE(short pLANGODINAIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLANSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPLAN], TM1.[RADNINAZIVPLANA], TM1.[PLANGODINAIDGODINE] AS PLANGODINAIDGODINE FROM [PLAN] TM1 WITH (NOLOCK) WHERE TM1.[PLANGODINAIDGODINE] = @PLANGODINAIDGODINE ORDER BY TM1.[IDPLAN], TM1.[PLANGODINAIDGODINE] ", false);
            if (this.cmPLANSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLANSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLANGODINAIDGODINE", DbType.Int16));
            }
            this.cmPLANSelect7.SetParameter(0, pLANGODINAIDGODINE);
            this.PLANSelect7 = this.cmPLANSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PLANSelect7;
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

