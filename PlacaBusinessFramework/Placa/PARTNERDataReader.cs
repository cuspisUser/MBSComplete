namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class PARTNERDataReader : IDisposable
    {
        private ReadWriteCommand cmPARTNERSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader PARTNERSelect5;

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
                    if (!this.m_Closed && (this.PARTNERSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.PARTNERSelect5.Close();
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
            this.cmPARTNERSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[MB], TM1.[PARTNERMJESTO], TM1.[PARTNERULICA], TM1.[PARTNEREMAIL], TM1.[PARTNEROIB], TM1.[PARTNERFAX], TM1.[PARTNERTELEFON], TM1.[PARTNERZIRO1], TM1.[PARTNERZIRO2] FROM [PARTNER] TM1 WITH (NOLOCK) ORDER BY TM1.[IDPARTNER] ", false);
            this.PARTNERSelect5 = this.cmPARTNERSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PARTNERSelect5;
        }

        public IDataReader OpenByIDPARTNER(int iDPARTNER)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPARTNERSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[MB], TM1.[PARTNERMJESTO], TM1.[PARTNERULICA], TM1.[PARTNEREMAIL], TM1.[PARTNEROIB], TM1.[PARTNERFAX], TM1.[PARTNERTELEFON], TM1.[PARTNERZIRO1], TM1.[PARTNERZIRO2] FROM [PARTNER] TM1 WITH (NOLOCK) WHERE TM1.[IDPARTNER] = @IDPARTNER ORDER BY TM1.[IDPARTNER] ", false);
            if (this.cmPARTNERSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmPARTNERSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmPARTNERSelect5.SetParameter(0, iDPARTNER);
            this.PARTNERSelect5 = this.cmPARTNERSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PARTNERSelect5;
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

