namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class SP_FIN_URAPLACANJEDataReader : IDisposable
    {
        private ReadWriteCommand cmSP_FIN_URAPLACANJESelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader SP_FIN_URAPLACANJESelect3;

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
                    this.SP_FIN_URAPLACANJESelect3.Close();
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

        public IDataReader Open(int iDDOKUMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSP_FIN_URAPLACANJESelect3 = this.connDefault.GetCommand("S_FIN_URA_PLACANJE", true);
            this.cmSP_FIN_URAPLACANJESelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmSP_FIN_URAPLACANJESelect3.IDbCommand.Parameters.Clear();
            this.cmSP_FIN_URAPLACANJESelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", iDDOKUMENT));
            this.cmSP_FIN_URAPLACANJESelect3.ErrorMask |= ErrorMask.Lock;
            this.SP_FIN_URAPLACANJESelect3 = this.cmSP_FIN_URAPLACANJESelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SP_FIN_URAPLACANJESelect3;
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

