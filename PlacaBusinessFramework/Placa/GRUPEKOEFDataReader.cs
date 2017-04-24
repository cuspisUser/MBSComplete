namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class GRUPEKOEFDataReader : IDisposable
    {
        private ReadWriteCommand cmGRUPEKOEFSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader GRUPEKOEFSelect5;
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
                    if (!this.m_Closed && (this.GRUPEKOEFSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.GRUPEKOEFSelect5.Close();
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
            this.cmGRUPEKOEFSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDGRUPEKOEF], TM1.[NAZIVGRUPEKOEF] FROM [GRUPEKOEF] TM1 WITH (NOLOCK) ORDER BY TM1.[IDGRUPEKOEF] ", false);
            this.GRUPEKOEFSelect5 = this.cmGRUPEKOEFSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GRUPEKOEFSelect5;
        }

        public IDataReader OpenByIDGRUPEKOEF(int iDGRUPEKOEF)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGRUPEKOEFSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDGRUPEKOEF], TM1.[NAZIVGRUPEKOEF] FROM [GRUPEKOEF] TM1 WITH (NOLOCK) WHERE TM1.[IDGRUPEKOEF] = @IDGRUPEKOEF ORDER BY TM1.[IDGRUPEKOEF] ", false);
            if (this.cmGRUPEKOEFSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmGRUPEKOEFSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            this.cmGRUPEKOEFSelect5.SetParameter(0, iDGRUPEKOEF);
            this.GRUPEKOEFSelect5 = this.cmGRUPEKOEFSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GRUPEKOEFSelect5;
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

