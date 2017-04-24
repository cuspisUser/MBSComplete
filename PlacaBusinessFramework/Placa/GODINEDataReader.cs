namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class GODINEDataReader : IDisposable
    {
        private ReadWriteCommand cmGODINESelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader GODINESelect5;
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
                    if (!this.m_Closed && (this.GODINESelect5 != null))
                    {
                        this.m_Closed = true;
                        this.GODINESelect5.Close();
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
            this.cmGODINESelect5 = this.connDefault.GetCommand("SELECT TM1.[IDGODINE], TM1.[GODINEAKTIVNA] FROM [GODINE] TM1 WITH (NOLOCK) ORDER BY TM1.[IDGODINE] ", false);
            this.GODINESelect5 = this.cmGODINESelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GODINESelect5;
        }

        public IDataReader OpenByIDGODINE(short iDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGODINESelect5 = this.connDefault.GetCommand("SELECT TM1.[IDGODINE], TM1.[GODINEAKTIVNA] FROM [GODINE] TM1 WITH (NOLOCK) WHERE TM1.[IDGODINE] = @IDGODINE ORDER BY TM1.[IDGODINE] ", false);
            if (this.cmGODINESelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmGODINESelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmGODINESelect5.SetParameter(0, iDGODINE);
            this.GODINESelect5 = this.cmGODINESelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GODINESelect5;
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

