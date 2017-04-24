namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RADNOMJESTODataReader : IDisposable
    {
        private ReadWriteCommand cmRADNOMJESTOSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RADNOMJESTOSelect5;

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
                    if (!this.m_Closed && (this.RADNOMJESTOSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.RADNOMJESTOSelect5.Close();
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
            this.cmRADNOMJESTOSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDRADNOMJESTO], TM1.[NAZIVRADNOMJESTO] FROM [RADNOMJESTO] TM1 WITH (NOLOCK) ORDER BY TM1.[IDRADNOMJESTO] ", false);
            this.RADNOMJESTOSelect5 = this.cmRADNOMJESTOSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNOMJESTOSelect5;
        }

        public IDataReader OpenByIDRADNOMJESTO(int iDRADNOMJESTO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNOMJESTOSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDRADNOMJESTO], TM1.[NAZIVRADNOMJESTO] FROM [RADNOMJESTO] TM1 WITH (NOLOCK) WHERE TM1.[IDRADNOMJESTO] = @IDRADNOMJESTO ORDER BY TM1.[IDRADNOMJESTO] ", false);
            if (this.cmRADNOMJESTOSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNOMJESTOSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            this.cmRADNOMJESTOSelect5.SetParameter(0, iDRADNOMJESTO);
            this.RADNOMJESTOSelect5 = this.cmRADNOMJESTOSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNOMJESTOSelect5;
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

