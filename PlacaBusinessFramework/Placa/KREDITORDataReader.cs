namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class KREDITORDataReader : IDisposable
    {
        private ReadWriteCommand cmKREDITORSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader KREDITORSelect5;
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
                    if (!this.m_Closed && (this.KREDITORSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.KREDITORSelect5.Close();
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
            this.cmKREDITORSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDKREDITOR], TM1.[NAZIVKREDITOR], TM1.[VBDIKREDITOR], TM1.[ZRNKREDITOR], TM1.[PRIMATELJKREDITOR1], TM1.[PRIMATELJKREDITOR2], TM1.[PRIMATELJKREDITOR3] FROM [KREDITOR] TM1 WITH (NOLOCK) ORDER BY TM1.[IDKREDITOR] ", false);
            this.KREDITORSelect5 = this.cmKREDITORSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KREDITORSelect5;
        }

        public IDataReader OpenByIDKREDITOR(int iDKREDITOR)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKREDITORSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDKREDITOR], TM1.[NAZIVKREDITOR], TM1.[VBDIKREDITOR], TM1.[ZRNKREDITOR], TM1.[PRIMATELJKREDITOR1], TM1.[PRIMATELJKREDITOR2], TM1.[PRIMATELJKREDITOR3] FROM [KREDITOR] TM1 WITH (NOLOCK) WHERE TM1.[IDKREDITOR] = @IDKREDITOR ORDER BY TM1.[IDKREDITOR] ", false);
            if (this.cmKREDITORSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmKREDITORSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            this.cmKREDITORSelect5.SetParameter(0, iDKREDITOR);
            this.KREDITORSelect5 = this.cmKREDITORSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KREDITORSelect5;
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

