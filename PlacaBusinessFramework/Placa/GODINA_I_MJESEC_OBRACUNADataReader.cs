namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class GODINA_I_MJESEC_OBRACUNADataReader : IDisposable
    {
        private ReadWriteCommand cmGODINA_I_MJESEC_OBRACUNASelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader GODINA_I_MJESEC_OBRACUNASelect3;
        private bool m_Disposed;

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
                    this.GODINA_I_MJESEC_OBRACUNASelect3.Close();
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

        public IDataReader Open()
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGODINA_I_MJESEC_OBRACUNASelect3 = this.connDefault.GetCommand("S_PLACA_GOD_MJE_OBR", true);
            this.cmGODINA_I_MJESEC_OBRACUNASelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmGODINA_I_MJESEC_OBRACUNASelect3.IDbCommand.Parameters.Clear();
            this.cmGODINA_I_MJESEC_OBRACUNASelect3.ErrorMask |= ErrorMask.Lock;
            this.GODINA_I_MJESEC_OBRACUNASelect3 = this.cmGODINA_I_MJESEC_OBRACUNASelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GODINA_I_MJESEC_OBRACUNASelect3;
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

