namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class IRADataReader : IDisposable
    {
        private ReadWriteCommand cmIRADelete2;
        private ReadWriteCommand cmIRADelete3;
        private ReadWriteCommand cmIRADelete4;
        private ReadWriteCommand cmIRADelete5;
        private ReadWriteCommand cmIRADelete6;
        private ReadWriteCommand cmIRASelect10;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader IRASelect10;
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

        public int DeleteByIDTIPIRA(int iDTIPIRA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRADelete4 = this.connDefault.GetCommand("DELETE FROM [IRA]  WHERE [IDTIPIRA] = @IDTIPIRA", false);
            if (this.cmIRADelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRADelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            this.cmIRADelete4.SetParameter(0, iDTIPIRA);
            return this.cmIRADelete4.ExecuteStmt();
        }

        public int DeleteByIRADOKIDDOKUMENT(int iRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRADelete6 = this.connDefault.GetCommand("DELETE FROM [IRA]  WHERE [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT", false);
            if (this.cmIRADelete6.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRADelete6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRADelete6.SetParameter(0, iRADOKIDDOKUMENT);
            return this.cmIRADelete6.ExecuteStmt();
        }

        public int DeleteByIRAGODIDGODINE(short iRAGODIDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRADelete3 = this.connDefault.GetCommand("DELETE FROM [IRA]  WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE", false);
            if (this.cmIRADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
            }
            this.cmIRADelete3.SetParameter(0, iRAGODIDGODINE);
            return this.cmIRADelete3.ExecuteStmt();
        }

        public int DeleteByIRAGODIDGODINEIRADOKIDDOKUMENT(short iRAGODIDGODINE, int iRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRADelete2 = this.connDefault.GetCommand("DELETE FROM [IRA]  WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE and [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT", false);
            if (this.cmIRADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                this.cmIRADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRADelete2.SetParameter(0, iRAGODIDGODINE);
            this.cmIRADelete2.SetParameter(1, iRADOKIDDOKUMENT);
            return this.cmIRADelete2.ExecuteStmt();
        }

        public int DeleteByIRAPARTNERIDPARTNER(int iRAPARTNERIDPARTNER)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRADelete5 = this.connDefault.GetCommand("DELETE FROM [IRA]  WHERE [IRAPARTNERIDPARTNER] = @IRAPARTNERIDPARTNER", false);
            if (this.cmIRADelete5.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRADelete5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAPARTNERIDPARTNER", DbType.Int32));
            }
            this.cmIRADelete5.SetParameter(0, iRAPARTNERIDPARTNER);
            return this.cmIRADelete5.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.IRASelect10 != null))
                    {
                        this.m_Closed = true;
                        this.IRASelect10.Close();
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
            this.cmIRASelect10 = this.connDefault.GetCommand("SELECT TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] TM1 WITH (NOLOCK) ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ", false);
            this.IRASelect10 = this.cmIRASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.IRASelect10;
        }

        public IDataReader OpenByIDTIPIRA(int iDTIPIRA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect10 = this.connDefault.GetCommand("SELECT TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] TM1 WITH (NOLOCK) WHERE TM1.[IDTIPIRA] = @IDTIPIRA ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ", false);
            if (this.cmIRASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            this.cmIRASelect10.SetParameter(0, iDTIPIRA);
            this.IRASelect10 = this.cmIRASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.IRASelect10;
        }

        public IDataReader OpenByIRADOKIDDOKUMENT(int iRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect10 = this.connDefault.GetCommand("SELECT TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] TM1 WITH (NOLOCK) WHERE TM1.[IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ", false);
            if (this.cmIRASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRASelect10.SetParameter(0, iRADOKIDDOKUMENT);
            this.IRASelect10 = this.cmIRASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.IRASelect10;
        }

        public IDataReader OpenByIRAGODIDGODINE(short iRAGODIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect10 = this.connDefault.GetCommand("SELECT TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] TM1 WITH (NOLOCK) WHERE TM1.[IRAGODIDGODINE] = @IRAGODIDGODINE ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ", false);
            if (this.cmIRASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
            }
            this.cmIRASelect10.SetParameter(0, iRAGODIDGODINE);
            this.IRASelect10 = this.cmIRASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.IRASelect10;
        }

        public IDataReader OpenByIRAGODIDGODINEIRADOKIDDOKUMENT(short iRAGODIDGODINE, int iRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect10 = this.connDefault.GetCommand("SELECT TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] TM1 WITH (NOLOCK) WHERE TM1.[IRAGODIDGODINE] = @IRAGODIDGODINE and TM1.[IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ", false);
            if (this.cmIRASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRASelect10.SetParameter(0, iRAGODIDGODINE);
            this.cmIRASelect10.SetParameter(1, iRADOKIDDOKUMENT);
            this.IRASelect10 = this.cmIRASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.IRASelect10;
        }

        public IDataReader OpenByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int iRABROJ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect10 = this.connDefault.GetCommand("SELECT TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] TM1 WITH (NOLOCK) WHERE TM1.[IRAGODIDGODINE] = @IRAGODIDGODINE and TM1.[IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT and TM1.[IRABROJ] = @IRABROJ ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ", false);
            if (this.cmIRASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRABROJ", DbType.Int32));
            }
            this.cmIRASelect10.SetParameter(0, iRAGODIDGODINE);
            this.cmIRASelect10.SetParameter(1, iRADOKIDDOKUMENT);
            this.cmIRASelect10.SetParameter(2, iRABROJ);
            this.IRASelect10 = this.cmIRASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.IRASelect10;
        }

        public IDataReader OpenByIRAPARTNERIDPARTNER(int iRAPARTNERIDPARTNER)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect10 = this.connDefault.GetCommand("SELECT TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] TM1 WITH (NOLOCK) WHERE TM1.[IRAPARTNERIDPARTNER] = @IRAPARTNERIDPARTNER ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ", false);
            if (this.cmIRASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAPARTNERIDPARTNER", DbType.Int32));
            }
            this.cmIRASelect10.SetParameter(0, iRAPARTNERIDPARTNER);
            this.IRASelect10 = this.cmIRASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.IRASelect10;
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

