namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class SP_LISTA_IZNOSA_RADNIKADataReader : IDisposable
    {
        private ReadWriteCommand cmSP_LISTA_IZNOSA_RADNIKASelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader SP_LISTA_IZNOSA_RADNIKASelect3;

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
                    this.SP_LISTA_IZNOSA_RADNIKASelect3.Close();
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

        public IDataReader Open(string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3 = this.connDefault.GetCommand("S_PLACA_IZNOSI_PO_ZAPOSLENIKU", true);
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Clear();
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECOBRACUNA", mJESECOBRACUNA));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", gODINAOBRACUNA));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", sORT));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect3.ErrorMask |= ErrorMask.Lock;
            this.SP_LISTA_IZNOSA_RADNIKASelect3 = this.cmSP_LISTA_IZNOSA_RADNIKASelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.SP_LISTA_IZNOSA_RADNIKASelect3;
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

