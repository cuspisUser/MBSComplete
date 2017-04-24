namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class KRIZNIPOREZDataReader : IDisposable
    {
        private ReadWriteCommand cmKRIZNIPOREZSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader KRIZNIPOREZSelect5;
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
                    if (!this.m_Closed && (this.KRIZNIPOREZSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.KRIZNIPOREZSelect5.Close();
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
            this.cmKRIZNIPOREZSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDKRIZNIPOREZ], TM1.[NAZIVKRIZNIPOREZ], TM1.[KRIZNISTOPA], TM1.[KRIZNIOD], TM1.[KRIZNIDO], TM1.[MOKRIZNI], TM1.[POKRIZNI], TM1.[MZKRIZNI], TM1.[PZKRIZNI], TM1.[PRIMATELJKRIZNI1], TM1.[PRIMATELJKRIZNI2], TM1.[PRIMATELJKRIZNI3], TM1.[SIFRAOPISAPLACANJAKRIZNI], TM1.[OPISPLACANJAKRIZNI], TM1.[VBDIKRIZNI], TM1.[ZRNKRIZNI] FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK) ORDER BY TM1.[IDKRIZNIPOREZ] ", false);
            this.KRIZNIPOREZSelect5 = this.cmKRIZNIPOREZSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KRIZNIPOREZSelect5;
        }

        public IDataReader OpenByIDKRIZNIPOREZ(int iDKRIZNIPOREZ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKRIZNIPOREZSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDKRIZNIPOREZ], TM1.[NAZIVKRIZNIPOREZ], TM1.[KRIZNISTOPA], TM1.[KRIZNIOD], TM1.[KRIZNIDO], TM1.[MOKRIZNI], TM1.[POKRIZNI], TM1.[MZKRIZNI], TM1.[PZKRIZNI], TM1.[PRIMATELJKRIZNI1], TM1.[PRIMATELJKRIZNI2], TM1.[PRIMATELJKRIZNI3], TM1.[SIFRAOPISAPLACANJAKRIZNI], TM1.[OPISPLACANJAKRIZNI], TM1.[VBDIKRIZNI], TM1.[ZRNKRIZNI] FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK) WHERE TM1.[IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ORDER BY TM1.[IDKRIZNIPOREZ] ", false);
            if (this.cmKRIZNIPOREZSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmKRIZNIPOREZSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            this.cmKRIZNIPOREZSelect5.SetParameter(0, iDKRIZNIPOREZ);
            this.KRIZNIPOREZSelect5 = this.cmKRIZNIPOREZSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KRIZNIPOREZSelect5;
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

