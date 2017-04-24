namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RSVRSTEOBRACUNADataReader : IDisposable
    {
        private ReadWriteCommand cmRSVRSTEOBRACUNASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RSVRSTEOBRACUNASelect5;

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
                    if (!this.m_Closed && (this.RSVRSTEOBRACUNASelect5 != null))
                    {
                        this.m_Closed = true;
                        this.RSVRSTEOBRACUNASelect5.Close();
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
            this.cmRSVRSTEOBRACUNASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDRSVRSTEOBRACUNA], TM1.[NAZIVRSVRSTEOBRACUNA] FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK) ORDER BY TM1.[IDRSVRSTEOBRACUNA] ", false);
            this.RSVRSTEOBRACUNASelect5 = this.cmRSVRSTEOBRACUNASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RSVRSTEOBRACUNASelect5;
        }

        public IDataReader OpenByIDRSVRSTEOBRACUNA(string iDRSVRSTEOBRACUNA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSVRSTEOBRACUNASelect5 = this.connDefault.GetCommand("SELECT TM1.[IDRSVRSTEOBRACUNA], TM1.[NAZIVRSVRSTEOBRACUNA] FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK) WHERE TM1.[IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ORDER BY TM1.[IDRSVRSTEOBRACUNA] ", false);
            if (this.cmRSVRSTEOBRACUNASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSVRSTEOBRACUNASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            this.cmRSVRSTEOBRACUNASelect5.SetParameter(0, iDRSVRSTEOBRACUNA);
            this.RSVRSTEOBRACUNASelect5 = this.cmRSVRSTEOBRACUNASelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RSVRSTEOBRACUNASelect5;
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

