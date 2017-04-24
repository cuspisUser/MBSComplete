namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class GKSTAVKADataReader : IDisposable
    {
        private ReadWriteCommand cmGKSTAVKADelete10;
        private ReadWriteCommand cmGKSTAVKADelete2;
        private ReadWriteCommand cmGKSTAVKADelete3;
        private ReadWriteCommand cmGKSTAVKADelete4;
        private ReadWriteCommand cmGKSTAVKADelete5;
        private ReadWriteCommand cmGKSTAVKADelete6;
        private ReadWriteCommand cmGKSTAVKADelete7;
        private ReadWriteCommand cmGKSTAVKADelete8;
        private ReadWriteCommand cmGKSTAVKADelete9;
        private ReadWriteCommand cmGKSTAVKASelect14;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader GKSTAVKASelect14;
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

        public int DeleteByBROJSTAVKE(int bROJSTAVKE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete5 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [BROJSTAVKE] = @BROJSTAVKE", false);
            if (this.cmGKSTAVKADelete5.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
            }
            this.cmGKSTAVKADelete5.SetParameter(0, bROJSTAVKE);
            return this.cmGKSTAVKADelete5.ExecuteStmt();
        }

        public int DeleteByGKGODIDGODINE(short gKGODIDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete9 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [GKGODIDGODINE] = @GKGODIDGODINE", false);
            if (this.cmGKSTAVKADelete9.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKADelete9.SetParameter(0, gKGODIDGODINE);
            return this.cmGKSTAVKADelete9.ExecuteStmt();
        }

        public int DeleteByIDDOKUMENT(int iDDOKUMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete8 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [IDDOKUMENT] = @IDDOKUMENT", false);
            if (this.cmGKSTAVKADelete8.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKADelete8.SetParameter(0, iDDOKUMENT);
            return this.cmGKSTAVKADelete8.ExecuteStmt();
        }

        public int DeleteByIDDOKUMENTBROJDOKUMENTA(int iDDOKUMENT, int bROJDOKUMENTA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete7 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [BROJDOKUMENTA] = @BROJDOKUMENTA and [IDDOKUMENT] = @IDDOKUMENT", false);
            if (this.cmGKSTAVKADelete7.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKADelete7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKADelete7.SetParameter(0, bROJDOKUMENTA);
            this.cmGKSTAVKADelete7.SetParameter(1, iDDOKUMENT);
            return this.cmGKSTAVKADelete7.ExecuteStmt();
        }

        public int DeleteByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete6 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [BROJDOKUMENTA] = @BROJDOKUMENTA and [IDDOKUMENT] = @IDDOKUMENT and [GKGODIDGODINE] = @GKGODIDGODINE", false);
            if (this.cmGKSTAVKADelete6.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKADelete6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                this.cmGKSTAVKADelete6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKADelete6.SetParameter(0, bROJDOKUMENTA);
            this.cmGKSTAVKADelete6.SetParameter(1, iDDOKUMENT);
            this.cmGKSTAVKADelete6.SetParameter(2, gKGODIDGODINE);
            return this.cmGKSTAVKADelete6.ExecuteStmt();
        }

        public int DeleteByIDKONTO(string iDKONTO)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete10 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [IDKONTO] = @IDKONTO", false);
            if (this.cmGKSTAVKADelete10.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            this.cmGKSTAVKADelete10.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(iDKONTO)));
            return this.cmGKSTAVKADelete10.ExecuteStmt();
        }

        public int DeleteByIDMJESTOTROSKA(int iDMJESTOTROSKA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete4 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA", false);
            if (this.cmGKSTAVKADelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            this.cmGKSTAVKADelete4.SetParameter(0, iDMJESTOTROSKA);
            return this.cmGKSTAVKADelete4.ExecuteStmt();
        }

        public int DeleteByIDORGJED(int iDORGJED)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete3 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [IDORGJED] = @IDORGJED", false);
            if (this.cmGKSTAVKADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            this.cmGKSTAVKADelete3.SetParameter(0, iDORGJED);
            return this.cmGKSTAVKADelete3.ExecuteStmt();
        }

        public int DeleteByIDPARTNER(int iDPARTNER)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKADelete2 = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [IDPARTNER] = @IDPARTNER", false);
            if (this.cmGKSTAVKADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmGKSTAVKADelete2.SetParameter(0, iDPARTNER);
            return this.cmGKSTAVKADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.GKSTAVKASelect14 != null))
                    {
                        this.m_Closed = true;
                        this.GKSTAVKASelect14.Close();
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
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ORDER BY TM1.[IDGKSTAVKA] ", false);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByBROJSTAVKE(int bROJSTAVKE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[BROJSTAVKE] = @BROJSTAVKE ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, bROJSTAVKE);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByGKGODIDGODINE(short gKGODIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[GKGODIDGODINE] = @GKGODIDGODINE ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, gKGODIDGODINE);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDDOKUMENT(int iDDOKUMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDDOKUMENT] = @IDDOKUMENT ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, iDDOKUMENT);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDDOKUMENTBROJDOKUMENTA(int iDDOKUMENT, int bROJDOKUMENTA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[BROJDOKUMENTA] = @BROJDOKUMENTA and TM1.[IDDOKUMENT] = @IDDOKUMENT ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, bROJDOKUMENTA);
            this.cmGKSTAVKASelect14.SetParameter(1, iDDOKUMENT);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[BROJDOKUMENTA] = @BROJDOKUMENTA and TM1.[IDDOKUMENT] = @IDDOKUMENT and TM1.[GKGODIDGODINE] = @GKGODIDGODINE ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, bROJDOKUMENTA);
            this.cmGKSTAVKASelect14.SetParameter(1, iDDOKUMENT);
            this.cmGKSTAVKASelect14.SetParameter(2, gKGODIDGODINE);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDGKSTAVKA(int iDGKSTAVKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDGKSTAVKA] = @IDGKSTAVKA ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, iDGKSTAVKA);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDKONTO(string iDKONTO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDKONTO] = @IDKONTO ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(iDKONTO)));
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDMJESTOTROSKA(int iDMJESTOTROSKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDMJESTOTROSKA] = @IDMJESTOTROSKA ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, iDMJESTOTROSKA);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDORGJED(int iDORGJED)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDORGJED] = @IDORGJED ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, iDORGJED);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
        }

        public IDataReader OpenByIDPARTNER(int iDPARTNER)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect14 = this.connDefault.GetCommand("SELECT TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) LEFT JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) LEFT JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) LEFT JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) LEFT JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) LEFT JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) WHERE TM1.[IDPARTNER] = @IDPARTNER ORDER BY TM1.[IDGKSTAVKA] ", false);
            if (this.cmGKSTAVKASelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmGKSTAVKASelect14.SetParameter(0, iDPARTNER);
            this.GKSTAVKASelect14 = this.cmGKSTAVKASelect14.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GKSTAVKASelect14;
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

