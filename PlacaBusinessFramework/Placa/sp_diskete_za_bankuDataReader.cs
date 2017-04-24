namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class sp_diskete_za_bankuDataReader : IDisposable
    {
        private ReadWriteCommand cmsp_diskete_za_bankuSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader sp_diskete_za_bankuSelect3;

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
                    this.sp_diskete_za_bankuSelect3.Close();
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

        public IDataReader Open(string idobracun, string vbdibanke)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_diskete_za_bankuSelect3 = this.connDefault.GetCommand("S_PLACA_ISPLATE_ZA_BANKU", true);
            this.cmsp_diskete_za_bankuSelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_diskete_za_bankuSelect3.IDbCommand.Parameters.Clear();
            this.cmsp_diskete_za_bankuSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cmsp_diskete_za_bankuSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vbdibanke", vbdibanke));
            this.cmsp_diskete_za_bankuSelect3.ErrorMask |= ErrorMask.Lock;
            this.sp_diskete_za_bankuSelect3 = this.cmsp_diskete_za_bankuSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.sp_diskete_za_bankuSelect3;
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

