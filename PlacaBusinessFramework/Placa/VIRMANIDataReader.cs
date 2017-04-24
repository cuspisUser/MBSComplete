namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class VIRMANIDataReader : IDisposable
    {
        private ReadWriteCommand cmVIRMANIDelete2;
        private ReadWriteCommand cmVIRMANISelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader VIRMANISelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteBySIFRAOBRACUNAVIRMAN(string sIFRAOBRACUNAVIRMAN)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVIRMANIDelete2 = this.connDefault.GetCommand("DELETE FROM [VIRMANI]  WHERE [SIFRAOBRACUNAVIRMAN] = @SIFRAOBRACUNAVIRMAN", false);
            if (this.cmVIRMANIDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmVIRMANIDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOBRACUNAVIRMAN", DbType.String, 11));
            }
            this.cmVIRMANIDelete2.SetParameter(0, sIFRAOBRACUNAVIRMAN);
            return this.cmVIRMANIDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.VIRMANISelect6 != null))
                    {
                        this.m_Closed = true;
                        this.VIRMANISelect6.Close();
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
            this.cmVIRMANISelect6 = this.connDefault.GetCommand("SELECT TM1.[IDVIRMAN], TM1.[SIFRAOBRACUNAVIRMAN], TM1.[PLA1], TM1.[PLA2], TM1.[PLA3], TM1.[BROJRACUNAPLA], TM1.[MODELZADUZENJA], TM1.[POZIVZADUZENJA], TM1.[PRI1], TM1.[PRI2], TM1.[PRI3], TM1.[BROJRACUNAPRI], TM1.[MODELODOBRENJA], TM1.[POZIVODOBRENJA], TM1.[SIFRAOPISAPLACANJAVIRMAN], TM1.[OPISPLACANJAVIRMAN], TM1.[DATUMVALUTE], TM1.[DATUMPODNOSENJA], TM1.[IZVORDOKUMENTA], TM1.[OZNACEN], TM1.[IZNOS], TM1.[NAMJENA] FROM [VIRMANI] TM1 WITH (NOLOCK) ORDER BY TM1.[IDVIRMAN] ", false);
            this.VIRMANISelect6 = this.cmVIRMANISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.VIRMANISelect6;
        }

        public IDataReader OpenByIDVIRMAN(int iDVIRMAN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVIRMANISelect6 = this.connDefault.GetCommand("SELECT TM1.[IDVIRMAN], TM1.[SIFRAOBRACUNAVIRMAN], TM1.[PLA1], TM1.[PLA2], TM1.[PLA3], TM1.[BROJRACUNAPLA], TM1.[MODELZADUZENJA], TM1.[POZIVZADUZENJA], TM1.[PRI1], TM1.[PRI2], TM1.[PRI3], TM1.[BROJRACUNAPRI], TM1.[MODELODOBRENJA], TM1.[POZIVODOBRENJA], TM1.[SIFRAOPISAPLACANJAVIRMAN], TM1.[OPISPLACANJAVIRMAN], TM1.[DATUMVALUTE], TM1.[DATUMPODNOSENJA], TM1.[IZVORDOKUMENTA], TM1.[OZNACEN], TM1.[IZNOS], TM1.[NAMJENA] FROM [VIRMANI] TM1 WITH (NOLOCK) WHERE TM1.[IDVIRMAN] = @IDVIRMAN ORDER BY TM1.[IDVIRMAN] ", false);
            if (this.cmVIRMANISelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmVIRMANISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVIRMAN", DbType.Int32));
            }
            this.cmVIRMANISelect6.SetParameter(0, iDVIRMAN);
            this.VIRMANISelect6 = this.cmVIRMANISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.VIRMANISelect6;
        }

        public IDataReader OpenBySIFRAOBRACUNAVIRMAN(string sIFRAOBRACUNAVIRMAN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVIRMANISelect6 = this.connDefault.GetCommand("SELECT TM1.[IDVIRMAN], TM1.[SIFRAOBRACUNAVIRMAN], TM1.[PLA1], TM1.[PLA2], TM1.[PLA3], TM1.[BROJRACUNAPLA], TM1.[MODELZADUZENJA], TM1.[POZIVZADUZENJA], TM1.[PRI1], TM1.[PRI2], TM1.[PRI3], TM1.[BROJRACUNAPRI], TM1.[MODELODOBRENJA], TM1.[POZIVODOBRENJA], TM1.[SIFRAOPISAPLACANJAVIRMAN], TM1.[OPISPLACANJAVIRMAN], TM1.[DATUMVALUTE], TM1.[DATUMPODNOSENJA], TM1.[IZVORDOKUMENTA], TM1.[OZNACEN], TM1.[IZNOS], TM1.[NAMJENA] FROM [VIRMANI] TM1 WITH (NOLOCK) WHERE TM1.[SIFRAOBRACUNAVIRMAN] = @SIFRAOBRACUNAVIRMAN ORDER BY TM1.[IDVIRMAN] ", false);
            if (this.cmVIRMANISelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmVIRMANISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOBRACUNAVIRMAN", DbType.String, 11));
            }
            this.cmVIRMANISelect6.SetParameter(0, sIFRAOBRACUNAVIRMAN);
            this.VIRMANISelect6 = this.cmVIRMANISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.VIRMANISelect6;
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

