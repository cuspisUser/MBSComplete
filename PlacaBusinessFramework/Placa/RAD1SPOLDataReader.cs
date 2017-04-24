namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1SPOLDataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1SPOLSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1SPOLSelect5;

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
                    if (!this.m_Closed && (this.RAD1SPOLSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1SPOLSelect5.Close();
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
            this.cmRAD1SPOLSelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1SPOLID], TM1.[RAD1SPOLNAZIV] FROM [RAD1SPOL] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1SPOLID] ", false);
            this.RAD1SPOLSelect5 = this.cmRAD1SPOLSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPOLSelect5;
        }

        public IDataReader OpenByRAD1SPOLID(int rAD1SPOLID)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPOLSelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1SPOLID], TM1.[RAD1SPOLNAZIV] FROM [RAD1SPOL] TM1 WITH (NOLOCK) WHERE TM1.[RAD1SPOLID] = @RAD1SPOLID ORDER BY TM1.[RAD1SPOLID] ", false);
            if (this.cmRAD1SPOLSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPOLSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            this.cmRAD1SPOLSelect5.SetParameter(0, rAD1SPOLID);
            this.RAD1SPOLSelect5 = this.cmRAD1SPOLSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1SPOLSelect5;
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

