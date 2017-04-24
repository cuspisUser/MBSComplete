namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class S_OD_STANJE_OBUSTAVADataReader : IDisposable
    {
        private ReadWriteCommand cmS_OD_STANJE_OBUSTAVASelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader S_OD_STANJE_OBUSTAVASelect3;

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
                    this.S_OD_STANJE_OBUSTAVASelect3.Close();
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
        }

        private void Initialize()
        {
            this.m_Disposed = false;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public IDataReader Open(string idobracun)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_STANJE_OBUSTAVASelect3 = this.connDefault.GetCommand("S_PLACA_STANJE_OBUSTAVA", true);
            this.cmS_OD_STANJE_OBUSTAVASelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_STANJE_OBUSTAVASelect3.IDbCommand.Parameters.Clear();
            this.cmS_OD_STANJE_OBUSTAVASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cmS_OD_STANJE_OBUSTAVASelect3.ErrorMask |= ErrorMask.Lock;
            this.S_OD_STANJE_OBUSTAVASelect3 = this.cmS_OD_STANJE_OBUSTAVASelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.S_OD_STANJE_OBUSTAVASelect3;
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

