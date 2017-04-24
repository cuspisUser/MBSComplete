namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class BANKEDataReader : IDisposable
    {
        private IDataReader BANKESelect5;
        private ReadWriteCommand cmBANKESelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
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
                    if (!this.m_Closed && (this.BANKESelect5 != null))
                    {
                        this.m_Closed = true;
                        this.BANKESelect5.Close();
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
            this.cmBANKESelect5 = this.connDefault.GetCommand("SELECT TM1.[IDBANKE], TM1.[NAZIVBANKE1], TM1.[NAZIVBANKE2], TM1.[NAZIVBANKE3], TM1.[MOBANKA], TM1.[POBANKA], TM1.[MZBANKA], TM1.[PZBANKA], TM1.[SIFRAOPISPLACANJABANKE], TM1.[OPISPLACANJABANKE], TM1.[VBDIBANKE], TM1.[ZRNBANKE] FROM [BANKE] TM1 WITH (NOLOCK) ORDER BY TM1.[IDBANKE] ", false);
            this.BANKESelect5 = this.cmBANKESelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BANKESelect5;
        }

        public IDataReader OpenByIDBANKE(int iDBANKE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBANKESelect5 = this.connDefault.GetCommand("SELECT TM1.[IDBANKE], TM1.[NAZIVBANKE1], TM1.[NAZIVBANKE2], TM1.[NAZIVBANKE3], TM1.[MOBANKA], TM1.[POBANKA], TM1.[MZBANKA], TM1.[PZBANKA], TM1.[SIFRAOPISPLACANJABANKE], TM1.[OPISPLACANJABANKE], TM1.[VBDIBANKE], TM1.[ZRNBANKE] FROM [BANKE] TM1 WITH (NOLOCK) WHERE TM1.[IDBANKE] = @IDBANKE ORDER BY TM1.[IDBANKE] ", false);
            if (this.cmBANKESelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmBANKESelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmBANKESelect5.SetParameter(0, iDBANKE);
            this.BANKESelect5 = this.cmBANKESelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BANKESelect5;
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

