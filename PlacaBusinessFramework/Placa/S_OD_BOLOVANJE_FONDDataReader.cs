namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class S_OD_BOLOVANJE_FONDDataReader : IDisposable
    {
        private ReadWriteCommand cmS_OD_BOLOVANJE_FONDSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader S_OD_BOLOVANJE_FONDSelect3;

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
                    this.S_OD_BOLOVANJE_FONDSelect3.Close();
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

        public IDataReader Open(string oDD, string dOOO, int idradnik)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_BOLOVANJE_FONDSelect3 = this.connDefault.GetCommand("S_PLACA_BOLOVANJE_FOND", true);
            this.cmS_OD_BOLOVANJE_FONDSelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_BOLOVANJE_FONDSelect3.IDbCommand.Parameters.Clear();
            this.cmS_OD_BOLOVANJE_FONDSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODD", oDD));
            this.cmS_OD_BOLOVANJE_FONDSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOOO", dOOO));
            this.cmS_OD_BOLOVANJE_FONDSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik", idradnik));
            this.cmS_OD_BOLOVANJE_FONDSelect3.ErrorMask |= ErrorMask.Lock;
            this.S_OD_BOLOVANJE_FONDSelect3 = this.cmS_OD_BOLOVANJE_FONDSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.S_OD_BOLOVANJE_FONDSelect3;
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

