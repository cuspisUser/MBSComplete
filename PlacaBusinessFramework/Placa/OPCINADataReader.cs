namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OPCINADataReader : IDisposable
    {
        private ReadWriteCommand cmOPCINASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OPCINASelect5;

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
                    if (!this.m_Closed && (this.OPCINASelect5 != null))
                    {
                        this.m_Closed = true;
                        this.OPCINASelect5.Close();
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
            this.cmOPCINASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDOPCINE], TM1.[NAZIVOPCINE], TM1.[PRIREZ], TM1.[VBDIOPCINA], TM1.[ZRNOPCINA] FROM [OPCINA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDOPCINE] ", false);
            this.OPCINASelect5 = this.cmOPCINASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OPCINASelect5;
        }

        public IDataReader OpenByIDOPCINE(string iDOPCINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOPCINASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDOPCINE], TM1.[NAZIVOPCINE], TM1.[PRIREZ], TM1.[VBDIOPCINA], TM1.[ZRNOPCINA] FROM [OPCINA] TM1 WITH (NOLOCK) WHERE TM1.[IDOPCINE] = @IDOPCINE ORDER BY TM1.[IDOPCINE] ", false);
            if (this.cmOPCINASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmOPCINASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOPCINE", DbType.String, 4));
            }
            this.cmOPCINASelect5.SetParameter(0, iDOPCINE);
            this.OPCINASelect5 = this.cmOPCINASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OPCINASelect5;
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

