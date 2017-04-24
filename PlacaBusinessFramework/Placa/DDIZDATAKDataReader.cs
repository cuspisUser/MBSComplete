namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DDIZDATAKDataReader : IDisposable
    {
        private ReadWriteCommand cmDDIZDATAKSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDIZDATAKSelect5;
        private DataStore dsDefault;
        private bool m_Closed;
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
                    if (!this.m_Closed && (this.DDIZDATAKSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.DDIZDATAKSelect5.Close();
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
            this.cmDDIZDATAKSelect5 = this.connDefault.GetCommand("SELECT TM1.[DDIDIZDATAK], TM1.[DDNAZIVIZDATKA], TM1.[DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] TM1 WITH (NOLOCK) ORDER BY TM1.[DDIDIZDATAK] ", false);
            this.DDIZDATAKSelect5 = this.cmDDIZDATAKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDIZDATAKSelect5;
        }

        public IDataReader OpenByDDIDIZDATAK(int dDIDIZDATAK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDIZDATAKSelect5 = this.connDefault.GetCommand("SELECT TM1.[DDIDIZDATAK], TM1.[DDNAZIVIZDATKA], TM1.[DDPOSTOTAKIZDATKA] FROM [DDIZDATAK] TM1 WITH (NOLOCK) WHERE TM1.[DDIDIZDATAK] = @DDIDIZDATAK ORDER BY TM1.[DDIDIZDATAK] ", false);
            if (this.cmDDIZDATAKSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDIZDATAKSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDIZDATAK", DbType.Int32));
            }
            this.cmDDIZDATAKSelect5.SetParameter(0, dDIDIZDATAK);
            this.DDIZDATAKSelect5 = this.cmDDIZDATAKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDIZDATAKSelect5;
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

