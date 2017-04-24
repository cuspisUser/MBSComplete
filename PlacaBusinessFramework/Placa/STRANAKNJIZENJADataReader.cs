namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class STRANAKNJIZENJADataReader : IDisposable
    {
        private ReadWriteCommand cmSTRANAKNJIZENJASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader STRANAKNJIZENJASelect5;

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
                    if (!this.m_Closed && (this.STRANAKNJIZENJASelect5 != null))
                    {
                        this.m_Closed = true;
                        this.STRANAKNJIZENJASelect5.Close();
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
            this.cmSTRANAKNJIZENJASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDSTRANA], TM1.[NAZIVSTRANE] FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDSTRANA] ", false);
            this.STRANAKNJIZENJASelect5 = this.cmSTRANAKNJIZENJASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.STRANAKNJIZENJASelect5;
        }

        public IDataReader OpenByIDSTRANA(int iDSTRANA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSTRANAKNJIZENJASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDSTRANA], TM1.[NAZIVSTRANE] FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK) WHERE TM1.[IDSTRANA] = @IDSTRANA ORDER BY TM1.[IDSTRANA] ", false);
            if (this.cmSTRANAKNJIZENJASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSTRANAKNJIZENJASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
            }
            this.cmSTRANAKNJIZENJASelect5.SetParameter(0, iDSTRANA);
            this.STRANAKNJIZENJASelect5 = this.cmSTRANAKNJIZENJASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.STRANAKNJIZENJASelect5;
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

