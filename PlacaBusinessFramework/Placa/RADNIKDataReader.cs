namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RADNIKDataReader : IDisposable
    {
        private ReadWriteCommand cmRADNIKDelete10;
        private ReadWriteCommand cmRADNIKDelete11;
        private ReadWriteCommand cmRADNIKDelete12;
        private ReadWriteCommand cmRADNIKDelete13;
        private ReadWriteCommand cmRADNIKDelete14;
        private ReadWriteCommand cmRADNIKDelete15;
        private ReadWriteCommand cmRADNIKDelete16;
        private ReadWriteCommand cmRADNIKDelete17;
        private ReadWriteCommand cmRADNIKDelete18;
        private ReadWriteCommand cmRADNIKDelete19;
        private ReadWriteCommand cmRADNIKDelete2;
        private ReadWriteCommand cmRADNIKDelete3;
        private ReadWriteCommand cmRADNIKDelete4;
        private ReadWriteCommand cmRADNIKDelete5;
        private ReadWriteCommand cmRADNIKDelete6;
        private ReadWriteCommand cmRADNIKDelete7;
        private ReadWriteCommand cmRADNIKDelete8;
        private ReadWriteCommand cmRADNIKDelete9;
        private ReadWriteCommand cmRADNIKSelect24;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RADNIKSelect24;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDBANKE(int iDBANKE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete13 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDBANKE] = @IDBANKE", false);
            if (this.cmRADNIKDelete13.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmRADNIKDelete13.SetParameter(0, iDBANKE);
            return this.cmRADNIKDelete13.ExecuteStmt();
        }

        public int DeleteByIDBENEFICIRANI(string iDBENEFICIRANI)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete12 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI", false);
            if (this.cmRADNIKDelete12.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            this.cmRADNIKDelete12.SetParameter(0, iDBENEFICIRANI);
            return this.cmRADNIKDelete12.ExecuteStmt();
        }

        public int DeleteByIDBRACNOSTANJE(int iDBRACNOSTANJE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete7 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE", false);
            if (this.cmRADNIKDelete7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            this.cmRADNIKDelete7.SetParameter(0, iDBRACNOSTANJE);
            return this.cmRADNIKDelete7.ExecuteStmt();
        }

        public int DeleteByIDDRZAVLJANSTVO(int iDDRZAVLJANSTVO)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete18 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO", false);
            if (this.cmRADNIKDelete18.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete18.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            this.cmRADNIKDelete18.SetParameter(0, iDDRZAVLJANSTVO);
            return this.cmRADNIKDelete18.ExecuteStmt();
        }

        public int DeleteByIDIPIDENT(int iDIPIDENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete15 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDIPIDENT] = @IDIPIDENT", false);
            if (this.cmRADNIKDelete15.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete15.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            this.cmRADNIKDelete15.SetParameter(0, iDIPIDENT);
            return this.cmRADNIKDelete15.ExecuteStmt();
        }

        public int DeleteByIDORGDIO(int iDORGDIO)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete6 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDORGDIO] = @IDORGDIO", false);
            if (this.cmRADNIKDelete6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            this.cmRADNIKDelete6.SetParameter(0, iDORGDIO);
            return this.cmRADNIKDelete6.ExecuteStmt();
        }

        public int DeleteByIDRADNOMJESTO(int iDRADNOMJESTO)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete10 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO", false);
            if (this.cmRADNIKDelete10.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            this.cmRADNIKDelete10.SetParameter(0, iDRADNOMJESTO);
            return this.cmRADNIKDelete10.ExecuteStmt();
        }

        public int DeleteByIDRADNOVRIJEME(int iDRADNOVRIJEME)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete19 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME", false);
            if (this.cmRADNIKDelete19.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete19.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            this.cmRADNIKDelete19.SetParameter(0, iDRADNOVRIJEME);
            return this.cmRADNIKDelete19.ExecuteStmt();
        }

        public int DeleteByIDSPOL(int iDSPOL)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete14 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDSPOL] = @IDSPOL", false);
            if (this.cmRADNIKDelete14.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRADNIKDelete14.SetParameter(0, iDSPOL);
            return this.cmRADNIKDelete14.ExecuteStmt();
        }

        public int DeleteByIDSTRUKA(int iDSTRUKA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete8 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDSTRUKA] = @IDSTRUKA", false);
            if (this.cmRADNIKDelete8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            this.cmRADNIKDelete8.SetParameter(0, iDSTRUKA);
            return this.cmRADNIKDelete8.ExecuteStmt();
        }

        public int DeleteByIDTITULA(int iDTITULA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete11 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDTITULA] = @IDTITULA", false);
            if (this.cmRADNIKDelete11.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            this.cmRADNIKDelete11.SetParameter(0, iDTITULA);
            return this.cmRADNIKDelete11.ExecuteStmt();
        }

        public int DeleteByIDUGOVORORADU(int iDUGOVORORADU)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete17 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDUGOVORORADU] = @IDUGOVORORADU", false);
            if (this.cmRADNIKDelete17.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete17.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            this.cmRADNIKDelete17.SetParameter(0, iDUGOVORORADU);
            return this.cmRADNIKDelete17.ExecuteStmt();
        }

        public int DeleteByJMBG(string jMBG)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete2 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [JMBG] = @JMBG", false);
            if (this.cmRADNIKDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
            }
            this.cmRADNIKDelete2.SetParameter(0, jMBG);
            return this.cmRADNIKDelete2.ExecuteStmt();
        }

        public int DeleteByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete4 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE", false);
            if (this.cmRADNIKDelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKDelete4.SetParameter(0, oPCINARADAIDOPCINE);
            return this.cmRADNIKDelete4.ExecuteStmt();
        }

        public int DeleteByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete5 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE", false);
            if (this.cmRADNIKDelete5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKDelete5.SetParameter(0, oPCINASTANOVANJAIDOPCINE);
            return this.cmRADNIKDelete5.ExecuteStmt();
        }

        public int DeleteByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete9 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", false);
            if (this.cmRADNIKDelete9.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKDelete9.SetParameter(0, pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
            return this.cmRADNIKDelete9.ExecuteStmt();
        }

        public int DeleteByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete3 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", false);
            if (this.cmRADNIKDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            this.cmRADNIKDelete3.SetParameter(0, rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
            return this.cmRADNIKDelete3.ExecuteStmt();
        }

        public int DeleteByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKDelete16 = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", false);
            if (this.cmRADNIKDelete16.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKDelete16.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKDelete16.SetParameter(0, tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
            return this.cmRADNIKDelete16.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RADNIKSelect24 != null))
                    {
                        this.m_Closed = true;
                        this.RADNIKSelect24.Close();
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
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDBANKE(int iDBANKE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDBANKE] = @IDBANKE ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDBANKE);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDBENEFICIRANI(string iDBENEFICIRANI)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDBENEFICIRANI] = @IDBENEFICIRANI ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDBENEFICIRANI);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDBRACNOSTANJE(int iDBRACNOSTANJE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDBRACNOSTANJE] = @IDBRACNOSTANJE ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDBRACNOSTANJE);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDDRZAVLJANSTVO(int iDDRZAVLJANSTVO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDDRZAVLJANSTVO);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDIPIDENT(int iDIPIDENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDIPIDENT] = @IDIPIDENT ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDIPIDENT);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDORGDIO(int iDORGDIO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDORGDIO] = @IDORGDIO ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDORGDIO);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDRADNIK(int iDRADNIK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDRADNIK] = @IDRADNIK ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDRADNIK);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDRADNOMJESTO(int iDRADNOMJESTO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDRADNOMJESTO] = @IDRADNOMJESTO ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDRADNOMJESTO);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDRADNOVRIJEME(int iDRADNOVRIJEME)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDRADNOVRIJEME] = @IDRADNOVRIJEME ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDRADNOVRIJEME);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDSPOL(int iDSPOL)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDSPOL] = @IDSPOL ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDSPOL);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDSTRUKA(int iDSTRUKA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDSTRUKA] = @IDSTRUKA ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDSTRUKA);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDTITULA(int iDTITULA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDTITULA] = @IDTITULA ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDTITULA);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByIDUGOVORORADU(int iDUGOVORORADU)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[IDUGOVORORADU] = @IDUGOVORORADU ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, iDUGOVORORADU);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByJMBG(string jMBG)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[JMBG] = @JMBG ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
            }
            this.cmRADNIKSelect24.SetParameter(0, jMBG);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKSelect24.SetParameter(0, oPCINARADAIDOPCINE);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKSelect24.SetParameter(0, oPCINASTANOVANJAIDOPCINE);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
        }

        public IDataReader OpenByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string statement = " SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T13.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T15.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T3.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T4.[NAZIVTITULA], T5.[NAZIVRADNOMJESTO], T17.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T16.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T6.[NAZIVSTRUKA], T7.[NAZIVBRACNOSTANJE], T8.[ORGANIZACIJSKIDIO], T3.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T11.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T12.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T9.[NAZIVSPOL], T10.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI],  TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [BENEFICIRANI] T3 WITH (NOLOCK) ON T3.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T4 WITH (NOLOCK) ON T4.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T5 WITH (NOLOCK) ON T5.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUKA] T6 WITH (NOLOCK) ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T7 WITH (NOLOCK) ON T7.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T8 WITH (NOLOCK) ON T8.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [SPOL] T9 WITH (NOLOCK) ON T9.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [IPIDENT] T10 WITH (NOLOCK) ON T10.[IDIPIDENT] = TM1.[IDIPIDENT]) LEFT JOIN [DRZAVLJANSTVO] T11 WITH (NOLOCK) ON T11.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T12 WITH (NOLOCK) ON T12.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) LEFT JOIN [OPCINA] T13 WITH (NOLOCK) ON T13.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T14 WITH (NOLOCK) ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) LEFT JOIN [SKUPPOREZAIDOPRINOSA] T15 WITH (NOLOCK) ON T15.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) LEFT JOIN [STRUCNASPREMA] T16 WITH (NOLOCK) ON T16.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T17 WITH (NOLOCK) ON T17.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) WHERE TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA ORDER BY TM1.[IDRADNIK] ";
            this.cmRADNIKSelect24 = this.connDefault.GetCommand(statement, false);
            if (this.cmRADNIKSelect24.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect24.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKSelect24.SetParameter(0, tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.RADNIKSelect24 = this.cmRADNIKSelect24.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RADNIKSelect24;
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

