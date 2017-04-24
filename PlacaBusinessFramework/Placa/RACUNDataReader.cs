namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RACUNDataReader : IDisposable
    {
        private ReadWriteCommand cmRACUNDelete2;
        private ReadWriteCommand cmRACUNDelete3;
        private ReadWriteCommand cmRACUNDelete4;
        private ReadWriteCommand cmRACUNSelect8;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RACUNSelect8;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDPARTNER(int iDPARTNER)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNDelete4 = this.connDefault.GetCommand("DELETE FROM [RACUN]  WHERE [IDPARTNER] = @IDPARTNER", false);
            if (this.cmRACUNDelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNDelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmRACUNDelete4.SetParameter(0, iDPARTNER);
            return this.cmRACUNDelete4.ExecuteStmt();
        }

        public int DeleteByIDRACUN(int iDRACUN)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNDelete2 = this.connDefault.GetCommand("DELETE FROM [RACUN]  WHERE [IDRACUN] = @IDRACUN", false);
            if (this.cmRACUNDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
            }
            this.cmRACUNDelete2.SetParameter(0, iDRACUN);
            return this.cmRACUNDelete2.ExecuteStmt();
        }

        public int DeleteByRACUNGODINAIDGODINE(short rACUNGODINAIDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNDelete3 = this.connDefault.GetCommand("DELETE FROM [RACUN]  WHERE [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE", false);
            if (this.cmRACUNDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            this.cmRACUNDelete3.SetParameter(0, rACUNGODINAIDGODINE);
            return this.cmRACUNDelete3.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RACUNSelect8 != null))
                    {
                        this.m_Closed = true;
                        this.RACUNSelect8.Close();
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
            this.cmRACUNSelect8 = this.connDefault.GetCommand("SELECT TM1.[IDRACUN], TM1.[ZAPREDUJAM], T2.[NAZIVPARTNER], T2.[MB], T2.[PARTNERMJESTO], T2.[PARTNERULICA], T2.[PARTNEREMAIL], TM1.[DATUM], TM1.[VALUTA], TM1.[RAZDOBLJEOD], TM1.[RAZDOBLJEDO], TM1.[MODEL], TM1.[POZIV], TM1.[NAPOMENA], T2.[PARTNEROIB], TM1.[IDPARTNER], TM1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE FROM ([RACUN] TM1 WITH (NOLOCK) LEFT JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ", false);
            this.RACUNSelect8 = this.cmRACUNSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RACUNSelect8;
        }

        public IDataReader OpenByIDPARTNER(int iDPARTNER)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect8 = this.connDefault.GetCommand("SELECT TM1.[IDRACUN], TM1.[ZAPREDUJAM], T2.[NAZIVPARTNER], T2.[MB], T2.[PARTNERMJESTO], T2.[PARTNERULICA], T2.[PARTNEREMAIL], TM1.[DATUM], TM1.[VALUTA], TM1.[RAZDOBLJEOD], TM1.[RAZDOBLJEDO], TM1.[MODEL], TM1.[POZIV], TM1.[NAPOMENA], T2.[PARTNEROIB], TM1.[IDPARTNER], TM1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE FROM ([RACUN] TM1 WITH (NOLOCK) LEFT JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDPARTNER] = @IDPARTNER ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ", false);
            if (this.cmRACUNSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmRACUNSelect8.SetParameter(0, iDPARTNER);
            this.RACUNSelect8 = this.cmRACUNSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RACUNSelect8;
        }

        public IDataReader OpenByIDRACUN(int iDRACUN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect8 = this.connDefault.GetCommand("SELECT TM1.[IDRACUN], TM1.[ZAPREDUJAM], T2.[NAZIVPARTNER], T2.[MB], T2.[PARTNERMJESTO], T2.[PARTNERULICA], T2.[PARTNEREMAIL], TM1.[DATUM], TM1.[VALUTA], TM1.[RAZDOBLJEOD], TM1.[RAZDOBLJEDO], TM1.[MODEL], TM1.[POZIV], TM1.[NAPOMENA], T2.[PARTNEROIB], TM1.[IDPARTNER], TM1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE FROM ([RACUN] TM1 WITH (NOLOCK) LEFT JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDRACUN] = @IDRACUN ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ", false);
            if (this.cmRACUNSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
            }
            this.cmRACUNSelect8.SetParameter(0, iDRACUN);
            this.RACUNSelect8 = this.cmRACUNSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RACUNSelect8;
        }

        public IDataReader OpenByIDRACUNRACUNGODINAIDGODINE(int iDRACUN, short rACUNGODINAIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect8 = this.connDefault.GetCommand("SELECT TM1.[IDRACUN], TM1.[ZAPREDUJAM], T2.[NAZIVPARTNER], T2.[MB], T2.[PARTNERMJESTO], T2.[PARTNERULICA], T2.[PARTNEREMAIL], TM1.[DATUM], TM1.[VALUTA], TM1.[RAZDOBLJEOD], TM1.[RAZDOBLJEDO], TM1.[MODEL], TM1.[POZIV], TM1.[NAPOMENA], T2.[PARTNEROIB], TM1.[IDPARTNER], TM1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE FROM ([RACUN] TM1 WITH (NOLOCK) LEFT JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDRACUN] = @IDRACUN and TM1.[RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ", false);
            if (this.cmRACUNSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                this.cmRACUNSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            this.cmRACUNSelect8.SetParameter(0, iDRACUN);
            this.cmRACUNSelect8.SetParameter(1, rACUNGODINAIDGODINE);
            this.RACUNSelect8 = this.cmRACUNSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RACUNSelect8;
        }

        public IDataReader OpenByRACUNGODINAIDGODINE(short rACUNGODINAIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect8 = this.connDefault.GetCommand("SELECT TM1.[IDRACUN], TM1.[ZAPREDUJAM], T2.[NAZIVPARTNER], T2.[MB], T2.[PARTNERMJESTO], T2.[PARTNERULICA], T2.[PARTNEREMAIL], TM1.[DATUM], TM1.[VALUTA], TM1.[RAZDOBLJEOD], TM1.[RAZDOBLJEDO], TM1.[MODEL], TM1.[POZIV], TM1.[NAPOMENA], T2.[PARTNEROIB], TM1.[IDPARTNER], TM1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE FROM ([RACUN] TM1 WITH (NOLOCK) LEFT JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ", false);
            if (this.cmRACUNSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            this.cmRACUNSelect8.SetParameter(0, rACUNGODINAIDGODINE);
            this.RACUNSelect8 = this.cmRACUNSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RACUNSelect8;
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

