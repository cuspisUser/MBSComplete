namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class VRSTADOPRINOSDataReader : IDisposable
    {
        private ReadWriteCommand cmVRSTADOPRINOSSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader VRSTADOPRINOSSelect5;

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
                    if (!this.m_Closed && (this.VRSTADOPRINOSSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.VRSTADOPRINOSSelect5.Close();
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
            this.cmVRSTADOPRINOSSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDVRSTADOPRINOS], TM1.[NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK) ORDER BY TM1.[IDVRSTADOPRINOS] ", false);
            this.VRSTADOPRINOSSelect5 = this.cmVRSTADOPRINOSSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.VRSTADOPRINOSSelect5;
        }

        public IDataReader OpenByIDVRSTADOPRINOS(int iDVRSTADOPRINOS)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVRSTADOPRINOSSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDVRSTADOPRINOS], TM1.[NAZIVVRSTADOPRINOS] FROM [VRSTADOPRINOS] TM1 WITH (NOLOCK) WHERE TM1.[IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ORDER BY TM1.[IDVRSTADOPRINOS] ", false);
            if (this.cmVRSTADOPRINOSSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmVRSTADOPRINOSSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            this.cmVRSTADOPRINOSSelect5.SetParameter(0, iDVRSTADOPRINOS);
            this.VRSTADOPRINOSSelect5 = this.cmVRSTADOPRINOSSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.VRSTADOPRINOSSelect5;
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

