namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class TIPURADataReader : IDisposable
    {
        private ReadWriteCommand cmTIPURASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader TIPURASelect5;

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
                    if (!this.m_Closed && (this.TIPURASelect5 != null))
                    {
                        this.m_Closed = true;
                        this.TIPURASelect5.Close();
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
            this.cmTIPURASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDTIPURA], TM1.[NAZIVTIPURA] FROM [TIPURA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDTIPURA] ", false);
            this.TIPURASelect5 = this.cmTIPURASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.TIPURASelect5;
        }

        public IDataReader OpenByIDTIPURA(int iDTIPURA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPURASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDTIPURA], TM1.[NAZIVTIPURA] FROM [TIPURA] TM1 WITH (NOLOCK) WHERE TM1.[IDTIPURA] = @IDTIPURA ORDER BY TM1.[IDTIPURA] ", false);
            if (this.cmTIPURASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPURASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            this.cmTIPURASelect5.SetParameter(0, iDTIPURA);
            this.TIPURASelect5 = this.cmTIPURASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.TIPURASelect5;
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

