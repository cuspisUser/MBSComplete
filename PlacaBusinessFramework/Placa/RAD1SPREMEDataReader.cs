namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1SPREMEDataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1SPREMESelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1SPREMESelect5;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RAD1SPREMESelect5 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1SPREMESelect5.Close();
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
            this.cmRAD1SPREMESelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1IDSPREME], TM1.[RAD1NAZIVSPREME] FROM [RAD1SPREME] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1IDSPREME] ", false);
            this.RAD1SPREMESelect5 = this.cmRAD1SPREMESelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPREMESelect5;
        }

        public IDataReader OpenByRAD1IDSPREME(int rAD1IDSPREME)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMESelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1IDSPREME], TM1.[RAD1NAZIVSPREME] FROM [RAD1SPREME] TM1 WITH (NOLOCK) WHERE TM1.[RAD1IDSPREME] = @RAD1IDSPREME ORDER BY TM1.[RAD1IDSPREME] ", false);
            if (this.cmRAD1SPREMESelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMESelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            this.cmRAD1SPREMESelect5.SetParameter(0, rAD1IDSPREME);
            this.RAD1SPREMESelect5 = this.cmRAD1SPREMESelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPREMESelect5;
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

