namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class s_od_pripremaDataReader : IDisposable
    {
        private ReadWriteCommand cms_od_pripremaSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader s_od_pripremaSelect3;

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
                    this.s_od_pripremaSelect3.Close();
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

        public IDataReader Open(int godina, int id, int mjesec, string vrsta)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cms_od_pripremaSelect3 = this.connDefault.GetCommand("S_PLACA_PRIPREMA", true);
            this.cms_od_pripremaSelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cms_od_pripremaSelect3.IDbCommand.Parameters.Clear();
            this.cms_od_pripremaSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cms_od_pripremaSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@id", id));
            this.cms_od_pripremaSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesec", mjesec));
            this.cms_od_pripremaSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vrsta", vrsta));
            this.cms_od_pripremaSelect3.ErrorMask |= ErrorMask.Lock;
            this.s_od_pripremaSelect3 = this.cms_od_pripremaSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.s_od_pripremaSelect3;
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

