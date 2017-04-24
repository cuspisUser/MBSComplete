namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1SPREMEVEZADataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1SPREMEVEZADelete2;
        private ReadWriteCommand cmRAD1SPREMEVEZADelete3;
        private ReadWriteCommand cmRAD1SPREMEVEZASelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1SPREMEVEZASelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDSTRUCNASPREMA(int iDSTRUCNASPREMA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZADelete3 = this.connDefault.GetCommand("DELETE FROM [RAD1SPREMEVEZA]  WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA", false);
            if (this.cmRAD1SPREMEVEZADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZADelete3.SetParameter(0, iDSTRUCNASPREMA);
            return this.cmRAD1SPREMEVEZADelete3.ExecuteStmt();
        }

        public int DeleteByRAD1IDSPREME(int rAD1IDSPREME)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZADelete2 = this.connDefault.GetCommand("DELETE FROM [RAD1SPREMEVEZA]  WHERE [RAD1IDSPREME] = @RAD1IDSPREME", false);
            if (this.cmRAD1SPREMEVEZADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZADelete2.SetParameter(0, rAD1IDSPREME);
            return this.cmRAD1SPREMEVEZADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RAD1SPREMEVEZASelect7 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1SPREMEVEZASelect7.Close();
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
            this.cmRAD1SPREMEVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ", false);
            this.RAD1SPREMEVEZASelect7 = this.cmRAD1SPREMEVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPREMEVEZASelect7;
        }

        public IDataReader OpenByIDSTRUCNASPREMA(int iDSTRUCNASPREMA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) WHERE TM1.[IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ", false);
            if (this.cmRAD1SPREMEVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect7.SetParameter(0, iDSTRUCNASPREMA);
            this.RAD1SPREMEVEZASelect7 = this.cmRAD1SPREMEVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPREMEVEZASelect7;
        }

        public IDataReader OpenByRAD1IDSPREME(int rAD1IDSPREME)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) WHERE TM1.[RAD1IDSPREME] = @RAD1IDSPREME ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ", false);
            if (this.cmRAD1SPREMEVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect7.SetParameter(0, rAD1IDSPREME);
            this.RAD1SPREMEVEZASelect7 = this.cmRAD1SPREMEVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPREMEVEZASelect7;
        }

        public IDataReader OpenByRAD1IDSPREMEIDSTRUCNASPREMA(int rAD1IDSPREME, int iDSTRUCNASPREMA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) WHERE TM1.[RAD1IDSPREME] = @RAD1IDSPREME and TM1.[IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ", false);
            if (this.cmRAD1SPREMEVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                this.cmRAD1SPREMEVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect7.SetParameter(0, rAD1IDSPREME);
            this.cmRAD1SPREMEVEZASelect7.SetParameter(1, iDSTRUCNASPREMA);
            this.RAD1SPREMEVEZASelect7 = this.cmRAD1SPREMEVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPREMEVEZASelect7;
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

