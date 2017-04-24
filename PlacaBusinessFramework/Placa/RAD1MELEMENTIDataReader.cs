namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1MELEMENTIDataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1MELEMENTISelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1MELEMENTISelect5;

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
                    if (!this.m_Closed && (this.RAD1MELEMENTISelect5 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1MELEMENTISelect5.Close();
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
            this.cmRAD1MELEMENTISelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1ELEMENTIID], TM1.[RAD1ELEMENTINAZIV] FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1ELEMENTIID] ", false);
            this.RAD1MELEMENTISelect5 = this.cmRAD1MELEMENTISelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1MELEMENTISelect5;
        }

        public IDataReader OpenByRAD1ELEMENTIID(int rAD1ELEMENTIID)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTISelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1ELEMENTIID], TM1.[RAD1ELEMENTINAZIV] FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK) WHERE TM1.[RAD1ELEMENTIID] = @RAD1ELEMENTIID ORDER BY TM1.[RAD1ELEMENTIID] ", false);
            if (this.cmRAD1MELEMENTISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            this.cmRAD1MELEMENTISelect5.SetParameter(0, rAD1ELEMENTIID);
            this.RAD1MELEMENTISelect5 = this.cmRAD1MELEMENTISelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1MELEMENTISelect5;
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

