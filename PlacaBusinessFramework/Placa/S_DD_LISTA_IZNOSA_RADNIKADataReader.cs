namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class S_DD_LISTA_IZNOSA_RADNIKADataReader : IDisposable
    {
        private ReadWriteCommand cmS_DD_LISTA_IZNOSA_RADNIKASelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader S_DD_LISTA_IZNOSA_RADNIKASelect3;

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
                    this.S_DD_LISTA_IZNOSA_RADNIKASelect3.Close();
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

        public IDataReader Open(string iDOBRACUN, int sORT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect3 = this.connDefault.GetCommand("S_DD_LISTA_IZNOSA_RADNIKA", true);
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Clear();
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", sORT));
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect3.ErrorMask |= ErrorMask.Lock;
            this.S_DD_LISTA_IZNOSA_RADNIKASelect3 = this.cmS_DD_LISTA_IZNOSA_RADNIKASelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.S_DD_LISTA_IZNOSA_RADNIKASelect3;
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

