namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class KORISNIKDataReader : IDisposable
    {
        private ReadWriteCommand cmKORISNIKSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader KORISNIKSelect5;
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
                    if (!this.m_Closed && (this.KORISNIKSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.KORISNIKSelect5.Close();
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
            this.cmKORISNIKSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDKORISNIK], TM1.[KORISNIK1NAZIV], TM1.[KORISNIK1ADRESA], TM1.[KORISNIK1MJESTO], TM1.[KORISNIKOIB], TM1.[MBKORISNIK], TM1.[MBKORISNIKJEDINICA], TM1.[JMBGKORISNIK], TM1.[KONTAKTOSOBA], TM1.[KONTAKTTELEFON], TM1.[KONTAKTFAX], TM1.[EMAIL], TM1.[NADLEZNAPU], TM1.[BROJCANAOZNAKAPU], TM1.[STAZUKOEFICIJENTU], TM1.[RKP], TM1.[PREZIMEIMEOVLASTENEOSOBE], TM1.[ADRESAOVLASTENEOSOBE], TM1.[OIBOVLASTENEOSOBE], TM1.[ANALITIKA], TM1.[KORISNIK1HZZO], TM1.[KORISNIK1NAZIVZANALJEPNICE], TM1.[EMAILPOSILJAOCA], TM1.[NAZIVPOSILJAOCA], TM1.[SMTPSERVER] FROM [KORISNIK] TM1 WITH (NOLOCK) ORDER BY TM1.[IDKORISNIK] ", false);
            this.KORISNIKSelect5 = this.cmKORISNIKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KORISNIKSelect5;
        }

        public IDataReader OpenByIDKORISNIK(int iDKORISNIK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKORISNIKSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDKORISNIK], TM1.[KORISNIK1NAZIV], TM1.[KORISNIK1ADRESA], TM1.[KORISNIK1MJESTO], TM1.[KORISNIKOIB], TM1.[MBKORISNIK], TM1.[MBKORISNIKJEDINICA], TM1.[JMBGKORISNIK], TM1.[KONTAKTOSOBA], TM1.[KONTAKTTELEFON], TM1.[KONTAKTFAX], TM1.[EMAIL], TM1.[NADLEZNAPU], TM1.[BROJCANAOZNAKAPU], TM1.[STAZUKOEFICIJENTU], TM1.[RKP], TM1.[PREZIMEIMEOVLASTENEOSOBE], TM1.[ADRESAOVLASTENEOSOBE], TM1.[OIBOVLASTENEOSOBE], TM1.[ANALITIKA], TM1.[KORISNIK1HZZO], TM1.[KORISNIK1NAZIVZANALJEPNICE], TM1.[EMAILPOSILJAOCA], TM1.[NAZIVPOSILJAOCA], TM1.[SMTPSERVER] FROM [KORISNIK] TM1 WITH (NOLOCK) WHERE TM1.[IDKORISNIK] = @IDKORISNIK ORDER BY TM1.[IDKORISNIK] ", false);
            if (this.cmKORISNIKSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmKORISNIKSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
            }
            this.cmKORISNIKSelect5.SetParameter(0, iDKORISNIK);
            this.KORISNIKSelect5 = this.cmKORISNIKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KORISNIKSelect5;
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

