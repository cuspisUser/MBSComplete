namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1VEZASPOLDataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1VEZASPOLDelete2;
        private ReadWriteCommand cmRAD1VEZASPOLDelete3;
        private ReadWriteCommand cmRAD1VEZASPOLSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1VEZASPOLSelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDSPOL(int iDSPOL)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLDelete3 = this.connDefault.GetCommand("DELETE FROM [RAD1VEZASPOL]  WHERE [IDSPOL] = @IDSPOL", false);
            if (this.cmRAD1VEZASPOLDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRAD1VEZASPOLDelete3.SetParameter(0, iDSPOL);
            return this.cmRAD1VEZASPOLDelete3.ExecuteStmt();
        }

        public int DeleteByRAD1SPOLID(int rAD1SPOLID)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLDelete2 = this.connDefault.GetCommand("DELETE FROM [RAD1VEZASPOL]  WHERE [RAD1SPOLID] = @RAD1SPOLID", false);
            if (this.cmRAD1VEZASPOLDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            this.cmRAD1VEZASPOLDelete2.SetParameter(0, rAD1SPOLID);
            return this.cmRAD1VEZASPOLDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RAD1VEZASPOLSelect7 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1VEZASPOLSelect7.Close();
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
            this.cmRAD1VEZASPOLSelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1SPOLID], TM1.[IDSPOL] FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ", false);
            this.RAD1VEZASPOLSelect7 = this.cmRAD1VEZASPOLSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1VEZASPOLSelect7;
        }

        public IDataReader OpenByIDSPOL(int iDSPOL)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLSelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1SPOLID], TM1.[IDSPOL] FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) WHERE TM1.[IDSPOL] = @IDSPOL ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ", false);
            if (this.cmRAD1VEZASPOLSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect7.SetParameter(0, iDSPOL);
            this.RAD1VEZASPOLSelect7 = this.cmRAD1VEZASPOLSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1VEZASPOLSelect7;
        }

        public IDataReader OpenByRAD1SPOLID(int rAD1SPOLID)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLSelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1SPOLID], TM1.[IDSPOL] FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) WHERE TM1.[RAD1SPOLID] = @RAD1SPOLID ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ", false);
            if (this.cmRAD1VEZASPOLSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect7.SetParameter(0, rAD1SPOLID);
            this.RAD1VEZASPOLSelect7 = this.cmRAD1VEZASPOLSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1VEZASPOLSelect7;
        }

        public IDataReader OpenByRAD1SPOLIDIDSPOL(int rAD1SPOLID, int iDSPOL)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1VEZASPOLSelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1SPOLID], TM1.[IDSPOL] FROM [RAD1VEZASPOL] TM1 WITH (NOLOCK) WHERE TM1.[RAD1SPOLID] = @RAD1SPOLID and TM1.[IDSPOL] = @IDSPOL ORDER BY TM1.[RAD1SPOLID], TM1.[IDSPOL] ", false);
            if (this.cmRAD1VEZASPOLSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1VEZASPOLSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                this.cmRAD1VEZASPOLSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRAD1VEZASPOLSelect7.SetParameter(0, rAD1SPOLID);
            this.cmRAD1VEZASPOLSelect7.SetParameter(1, iDSPOL);
            this.RAD1VEZASPOLSelect7 = this.cmRAD1VEZASPOLSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1VEZASPOLSelect7;
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

