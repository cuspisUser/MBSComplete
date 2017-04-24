namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class TIPIRADataReader : IDisposable
    {
        private ReadWriteCommand cmTIPIRASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader TIPIRASelect5;

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
                    if (!this.m_Closed && (this.TIPIRASelect5 != null))
                    {
                        this.m_Closed = true;
                        this.TIPIRASelect5.Close();
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
            this.cmTIPIRASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDTIPIRA], TM1.[NAZIVTIPIRA] FROM [TIPIRA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDTIPIRA] ", false);
            this.TIPIRASelect5 = this.cmTIPIRASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.TIPIRASelect5;
        }

        public IDataReader OpenByIDTIPIRA(int iDTIPIRA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPIRASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDTIPIRA], TM1.[NAZIVTIPIRA] FROM [TIPIRA] TM1 WITH (NOLOCK) WHERE TM1.[IDTIPIRA] = @IDTIPIRA ORDER BY TM1.[IDTIPIRA] ", false);
            if (this.cmTIPIRASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPIRASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            this.cmTIPIRASelect5.SetParameter(0, iDTIPIRA);
            this.TIPIRASelect5 = this.cmTIPIRASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.TIPIRASelect5;
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

