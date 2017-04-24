namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class ZATVARANJADataReader : IDisposable
    {
        private ReadWriteCommand cmZATVARANJADelete2;
        private ReadWriteCommand cmZATVARANJADelete3;
        private ReadWriteCommand cmZATVARANJASelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader ZATVARANJASelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByGK1IDGKSTAVKA(int gK1IDGKSTAVKA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJADelete2 = this.connDefault.GetCommand("DELETE FROM [ZATVARANJA]  WHERE [GK1IDGKSTAVKA] = @GK1IDGKSTAVKA", false);
            if (this.cmZATVARANJADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJADelete2.SetParameter(0, gK1IDGKSTAVKA);
            return this.cmZATVARANJADelete2.ExecuteStmt();
        }

        public int DeleteByGK2IDGKSTAVKA(int gK2IDGKSTAVKA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJADelete3 = this.connDefault.GetCommand("DELETE FROM [ZATVARANJA]  WHERE [GK2IDGKSTAVKA] = @GK2IDGKSTAVKA", false);
            if (this.cmZATVARANJADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJADelete3.SetParameter(0, gK2IDGKSTAVKA);
            return this.cmZATVARANJADelete3.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.ZATVARANJASelect7 != null))
                    {
                        this.m_Closed = true;
                        this.ZATVARANJASelect7.Close();
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
            this.cmZATVARANJASelect7 = this.connDefault.GetCommand("SELECT TM1.[ZATVARANJAIZNOS], TM1.[GK1IDGKSTAVKA] AS GK1IDGKSTAVKA, TM1.[GK2IDGKSTAVKA] AS GK2IDGKSTAVKA FROM [ZATVARANJA] TM1 WITH (NOLOCK) ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ", false);
            this.ZATVARANJASelect7 = this.cmZATVARANJASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ZATVARANJASelect7;
        }

        public IDataReader OpenByGK1IDGKSTAVKA(int gK1IDGKSTAVKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJASelect7 = this.connDefault.GetCommand("SELECT TM1.[ZATVARANJAIZNOS], TM1.[GK1IDGKSTAVKA] AS GK1IDGKSTAVKA, TM1.[GK2IDGKSTAVKA] AS GK2IDGKSTAVKA FROM [ZATVARANJA] TM1 WITH (NOLOCK) WHERE TM1.[GK1IDGKSTAVKA] = @GK1IDGKSTAVKA ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ", false);
            if (this.cmZATVARANJASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect7.SetParameter(0, gK1IDGKSTAVKA);
            this.ZATVARANJASelect7 = this.cmZATVARANJASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ZATVARANJASelect7;
        }

        public IDataReader OpenByGK1IDGKSTAVKAGK2IDGKSTAVKA(int gK1IDGKSTAVKA, int gK2IDGKSTAVKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJASelect7 = this.connDefault.GetCommand("SELECT TM1.[ZATVARANJAIZNOS], TM1.[GK1IDGKSTAVKA] AS GK1IDGKSTAVKA, TM1.[GK2IDGKSTAVKA] AS GK2IDGKSTAVKA FROM [ZATVARANJA] TM1 WITH (NOLOCK) WHERE TM1.[GK1IDGKSTAVKA] = @GK1IDGKSTAVKA and TM1.[GK2IDGKSTAVKA] = @GK2IDGKSTAVKA ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ", false);
            if (this.cmZATVARANJASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
                this.cmZATVARANJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect7.SetParameter(0, gK1IDGKSTAVKA);
            this.cmZATVARANJASelect7.SetParameter(1, gK2IDGKSTAVKA);
            this.ZATVARANJASelect7 = this.cmZATVARANJASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ZATVARANJASelect7;
        }

        public IDataReader OpenByGK2IDGKSTAVKA(int gK2IDGKSTAVKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJASelect7 = this.connDefault.GetCommand("SELECT TM1.[ZATVARANJAIZNOS], TM1.[GK1IDGKSTAVKA] AS GK1IDGKSTAVKA, TM1.[GK2IDGKSTAVKA] AS GK2IDGKSTAVKA FROM [ZATVARANJA] TM1 WITH (NOLOCK) WHERE TM1.[GK2IDGKSTAVKA] = @GK2IDGKSTAVKA ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ", false);
            if (this.cmZATVARANJASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect7.SetParameter(0, gK2IDGKSTAVKA);
            this.ZATVARANJASelect7 = this.cmZATVARANJASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ZATVARANJASelect7;
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

