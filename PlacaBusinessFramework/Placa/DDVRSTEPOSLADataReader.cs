namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DDVRSTEPOSLADataReader : IDisposable
    {
        private ReadWriteCommand cmDDVRSTEPOSLASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDVRSTEPOSLASelect5;
        private DataStore dsDefault;
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
                    if (!this.m_Closed && (this.DDVRSTEPOSLASelect5 != null))
                    {
                        this.m_Closed = true;
                        this.DDVRSTEPOSLASelect5.Close();
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
            this.cmDDVRSTEPOSLASelect5 = this.connDefault.GetCommand("SELECT TM1.[DDIDVRSTAPOSLA], TM1.[DDNAZIVVRSTAPOSLA] FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK) ORDER BY TM1.[DDIDVRSTAPOSLA] ", false);
            this.DDVRSTEPOSLASelect5 = this.cmDDVRSTEPOSLASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDVRSTEPOSLASelect5;
        }

        public IDataReader OpenByDDIDVRSTAPOSLA(int dDIDVRSTAPOSLA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDVRSTEPOSLASelect5 = this.connDefault.GetCommand("SELECT TM1.[DDIDVRSTAPOSLA], TM1.[DDNAZIVVRSTAPOSLA] FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK) WHERE TM1.[DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ORDER BY TM1.[DDIDVRSTAPOSLA] ", false);
            if (this.cmDDVRSTEPOSLASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDVRSTEPOSLASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            this.cmDDVRSTEPOSLASelect5.SetParameter(0, dDIDVRSTAPOSLA);
            this.DDVRSTEPOSLASelect5 = this.cmDDVRSTEPOSLASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDVRSTEPOSLASelect5;
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

