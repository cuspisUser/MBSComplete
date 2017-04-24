namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class RadnikZaObracunDataAdapter : IDataAdapter, IRadnikZaObracunDataAdapter
    {
        private static string[] attributeNames = new string[] { 
            "TM1.[IDRADNIK]", "TM1.[AKTIVAN]", "TM1.[PREZIME]", "TM1.[IME]", "TM1.[JMBG]", "TM1.[DATUMRODJENJA]", "TM1.[ulica]", "TM1.[mjesto]", "TM1.[kucnibroj]", "TM1.[OPCINARADAIDOPCINE]", "T15.[NAZIVOPCINE]", "TM1.[OPCINASTANOVANJAIDOPCINE]", "T14.[NAZIVOPCINE]", "T14.[PRIREZ]", "T14.[VBDIOPCINA]", "T14.[ZRNOPCINA]", 
            "TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]", "T13.[NAZIVSKUPPOREZAIDOPRINOSA]", "TM1.[IDBANKE]", "T12.[NAZIVBANKE1]", "T12.[NAZIVBANKE2]", "T12.[NAZIVBANKE3]", "T12.[VBDIBANKE]", "T12.[ZRNBANKE]", "TM1.[TEKUCI]", "TM1.[ZBIRNINETO]", "TM1.[SIFRAOPISAPLACANJANETO]", "TM1.[OPISPLACANJANETO]", "TM1.[TJEDNIFONDSATI]", "TM1.[KOEFICIJENT]", "TM1.[POSTOTAKOSLOBODJENJAODPOREZA]", "TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA]", 
            "TM1.[TJEDNIFONDSATISTAZ]", "TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI]", "TM1.[GODINESTAZA]", "TM1.[MJESECISTAZA]", "TM1.[DANISTAZA]", "TM1.[IDBENEFICIRANI]", "T11.[NAZIVBENEFICIRANI]", "TM1.[DATUMPRESTANKARADNOGODNOSA]", "TM1.[BROJMIROVINSKOG]", "TM1.[BROJZDRAVSTVENOG]", "TM1.[MBO]", "TM1.[IDTITULA]", "T10.[NAZIVTITULA]", "TM1.[IDRADNOMJESTO]", "T9.[NAZIVRADNOMJESTO]", "TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]", 
            "T8.[NAZIVSTRUCNASPREMA]", "TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]", "T7.[NAZIVSTRUCNASPREMA]", "TM1.[IDSTRUKA]", "T6.[NAZIVSTRUKA]", "TM1.[IDBRACNOSTANJE]", "T5.[NAZIVBRACNOSTANJE]", "TM1.[IDORGDIO]", "T4.[ORGANIZACIJSKIDIO]", "TM1.[OIB]", "TM1.[IDSPOL]", "T3.[NAZIVSPOL]", "TM1.[IDIPIDENT]", "T2.[NAZIVIPIDENT]"
         };
        private ReadWriteCommand cmRADNIKBrutoSelect1;
        private ReadWriteCommand cmRADNIKIzuzeceOdOvrheSelect1;
        private ReadWriteCommand cmRADNIKKreditiSelect1;
        private ReadWriteCommand cmRADNIKNetoSelect1;
        private ReadWriteCommand cmRADNIKObustavaSelect1;
        private ReadWriteCommand cmRADNIKOdbitakSelect1;
        private ReadWriteCommand cmRADNIKOlaksicaSelect1;
        private ReadWriteCommand cmRADNIKSelect1;
        private ReadWriteCommand cmRADNIKSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private string filterCondition;
        private string filterString;
        private string filterStringCond;
        private bool m__AKTIVANIsNull;
        private bool m__BANKAZASTICENOIDBANKEIsNull;
        private bool m__BROJMIROVINSKOGIsNull;
        private bool m__BROJZDRAVSTVENOGIsNull;
        private bool m__BRUTOELEMENTIDELEMENTIsNull;
        private bool m__BRUTOELEMENTNAZIVELEMENTIsNull;
        private bool m__BRUTOIZNOSIsNull;
        private bool m__BRUTOPOSTOTAKIsNull;
        private bool m__BRUTOSATIIsNull;
        private bool m__BRUTOSATNICAIsNull;
        private bool m__DANISTAZAIsNull;
        private bool m__DATUMPRESTANKARADNOGODNOSAIsNull;
        private bool m__DATUMRODJENJAIsNull;
        private bool m__DATUMUGOVORAIsNull;
        private bool m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIIsNull;
        private bool m__FAKTOROSOBNOGODBITKAIsNull;
        private bool m__GODINESTAZAIsNull;
        private bool m__IDBANKEIsNull;
        private bool m__IDBENEFICIRANIIsNull;
        private bool m__IDBRACNOSTANJEIsNull;
        private bool m__IDIPIDENTIsNull;
        private bool m__IDORGDIOIsNull;
        private bool m__IDRADNIKIsNull;
        private bool m__IDRADNOMJESTOIsNull;
        private bool m__IDSPOLIsNull;
        private bool m__IDSTRUKAIsNull;
        private bool m__IDTITULAIsNull;
        private bool m__IMEIsNull;
        private bool m__JMBGIsNull;
        private bool m__KOEFICIJENTIsNull;
        private bool m__KREDITAKTIVANIsNull;
        private bool m__kucnibrojIsNull;
        private bool m__MBOIsNull;
        private bool m__MJESECISTAZAIsNull;
        private bool m__mjestoIsNull;
        private bool m__MOKREDITORIsNull;
        private bool m__MZKREDITORIsNull;
        private bool m__NAZIVBANKE1IsNull;
        private bool m__NAZIVBANKE2IsNull;
        private bool m__NAZIVBANKE3IsNull;
        private bool m__NAZIVBENEFICIRANIIsNull;
        private bool m__NAZIVBRACNOSTANJEIsNull;
        private bool m__NAZIVIPIDENTIsNull;
        private bool m__NAZIVOSOBNIODBITAKIsNull;
        private bool m__NAZIVRADNOMJESTOIsNull;
        private bool m__NAZIVSPOLIsNull;
        private bool m__NAZIVSTRUKAIsNull;
        private bool m__NAZIVTITULAIsNull;
        private bool m__NETOELEMENTIDELEMENTIsNull;
        private bool m__NETOELEMENTNAZIVELEMENTIsNull;
        private bool m__NETOIZNOSIsNull;
        private bool m__NETOPOSTOTAKIsNull;
        private bool m__NETOSATIIsNull;
        private bool m__NETOSATNICAIsNull;
        private bool m__OBUSTAVAAKTIVNAIsNull;
        private bool m__OIBIsNull;
        private bool m__OPCINARADAIDOPCINEIsNull;
        private bool m__OPCINARADANAZIVOPCINEIsNull;
        private bool m__OPCINASTANOVANJAIDOPCINEIsNull;
        private bool m__OPCINASTANOVANJANAZIVOPCINEIsNull;
        private bool m__OPCINASTANOVANJAPRIREZIsNull;
        private bool m__OPCINASTANOVANJAVBDIOPCINAIsNull;
        private bool m__OPCINASTANOVANJAZRNOPCINAIsNull;
        private bool m__OPISPLACANJAKREDITORIsNull;
        private bool m__OPISPLACANJANETOIsNull;
        private bool m__ORGANIZACIJSKIDIOIsNull;
        private bool m__OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKIsNull;
        private bool m__POKREDITORIsNull;
        private bool m__POSTOTAKOSLOBODJENJAODPOREZAIsNull;
        private bool m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAIsNull;
        private bool m__POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull;
        private bool m__PREZIMEIsNull;
        private bool m__PZKREDITORIsNull;
        private bool m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAIsNull;
        private bool m__RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAIsNull;
        private bool m__SIFRAOPISAPLACANJAKREDITORIsNull;
        private bool m__SIFRAOPISAPLACANJANETOIsNull;
        private bool m__TEKUCIIsNull;
        private bool m__TJEDNIFONDSATIIsNull;
        private bool m__TJEDNIFONDSATISTAZIsNull;
        private bool m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAIsNull;
        private bool m__TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull;
        private bool m__ulicaIsNull;
        private bool m__UZIMAUOBZIROSNOVICEDOPRINOSAIsNull;
        private bool m__VBDIBANKEIsNull;
        private bool m__ZADBROJRATAOBUSTAVEIsNull;
        private bool m__ZADISPLACENOKASAIsNull;
        private bool m__ZADIZNOSIZUZECAIsNull;
        private bool m__ZADIZNOSOBUSTAVEIsNull;
        private bool m__ZADIZNOSOLAKSICEIsNull;
        private bool m__ZADIZNOSRATEKREDITAIsNull;
        private bool m__ZADKREDITIIDKREDITORIsNull;
        private bool m__ZADKREDITINAZIVKREDITORIsNull;
        private bool m__ZADKREDITIPRIMATELJKREDITOR1IsNull;
        private bool m__ZADKREDITIPRIMATELJKREDITOR2IsNull;
        private bool m__ZADKREDITIPRIMATELJKREDITOR3IsNull;
        private bool m__ZADMOIZUZECEIsNull;
        private bool m__ZADMOOLAKSICEIsNull;
        private bool m__ZADMZIZUZECEIsNull;
        private bool m__ZADMZOLAKSICEIsNull;
        private bool m__ZADOBUSTAVAIDOBUSTAVAIsNull;
        private bool m__ZADOBUSTAVANAZIVOBUSTAVAIsNull;
        private bool m__ZADOBUSTAVANAZIVVRSTAOBUSTAVEIsNull;
        private bool m__ZADOBUSTAVAVRSTAOBUSTAVEIsNull;
        private bool m__ZADOLAKSICEIDGRUPEOLAKSICAIsNull;
        private bool m__ZADOLAKSICEIDOLAKSICEIsNull;
        private bool m__ZADOLAKSICEIDTIPOLAKSICEIsNull;
        private bool m__ZADOLAKSICEMAXIMALNIIZNOSGRUPEIsNull;
        private bool m__ZADOLAKSICENAZIVGRUPEOLAKSICAIsNull;
        private bool m__ZADOLAKSICENAZIVOLAKSICEIsNull;
        private bool m__ZADOLAKSICENAZIVTIPOLAKSICEIsNull;
        private bool m__ZADOLAKSICEPRIMATELJOLAKSICA1IsNull;
        private bool m__ZADOLAKSICEPRIMATELJOLAKSICA2IsNull;
        private bool m__ZADOLAKSICEPRIMATELJOLAKSICA3IsNull;
        private bool m__ZADOLAKSICEVBDIOLAKSICAIsNull;
        private bool m__ZADOLAKSICEZRNOLAKSICAIsNull;
        private bool m__ZADOPISPLACANJAIZUZECEIsNull;
        private bool m__ZADOPISPLACANJAOLAKSICEIsNull;
        private bool m__ZADPOIZUZECEIsNull;
        private bool m__ZADPOOLAKSICEIsNull;
        private bool m__ZADPOSTOTAKOBUSTAVEIsNull;
        private bool m__ZADPOSTOTNAODBRUTAIsNull;
        private bool m__ZADPZIZUZECEIsNull;
        private bool m__ZADPZOLAKSICEIsNull;
        private bool m__ZADSALDOKASAIsNull;
        private bool m__ZADSIFRAOPISAPLACANJAIZUZECEIsNull;
        private bool m__ZADSIFRAOPISAPLACANJAOLAKSICEIsNull;
        private bool m__ZADTEKUCIIZUZECEIsNull;
        private bool m__ZADUKUPNIZNOSKREDITAIsNull;
        private bool m__ZADVECOTPLACENOBROJRATAIsNull;
        private bool m__ZADVECOTPLACENOUKUPNIIZNOSIsNull;
        private bool m__ZBIRNINETOIsNull;
        private bool m__ZRNBANKEIsNull;
        private bool m_AKTIVAN;
        private int m_BANKAZASTICENOIDBANKE;
        private string m_BROJMIROVINSKOG;
        private string m_BROJZDRAVSTVENOG;
        private int m_BRUTOELEMENTIDELEMENT;
        private string m_BRUTOELEMENTNAZIVELEMENT;
        private decimal m_BRUTOIZNOS;
        private decimal m_BRUTOPOSTOTAK;
        private decimal m_BRUTOSATI;
        private decimal m_BRUTOSATNICA;
        private short m_DANISTAZA;
        private DateTime m_DATUMPRESTANKARADNOGODNOSA;
        private DateTime m_DATUMRODJENJA;
        private DateTime m_DATUMUGOVORA;
        private DateTime m_DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
        private decimal m_FAKTOROSOBNOGODBITKA;
        private short m_GODINESTAZA;
        private int m_IDBANKE;
        private string m_IDBENEFICIRANI;
        private int m_IDBRACNOSTANJE;
        private int m_IDIPIDENT;
        private int m_IDORGDIO;
        private int m_IDRADNIK;
        private int m_IDRADNOMJESTO;
        private int m_IDSPOL;
        private int m_IDSTRUKA;
        private int m_IDTITULA;
        private string m_IME;
        private string m_JMBG;
        private decimal m_KOEFICIJENT;
        private bool m_KREDITAKTIVAN;
        private string m_kucnibroj;
        private string m_MBO;
        private short m_MJESECISTAZA;
        private string m_mjesto;
        private string m_MOKREDITOR;
        private string m_MZKREDITOR;
        private string m_NAZIVBANKE1;
        private string m_NAZIVBANKE2;
        private string m_NAZIVBANKE3;
        private string m_NAZIVBENEFICIRANI;
        private string m_NAZIVBRACNOSTANJE;
        private string m_NAZIVIPIDENT;
        private string m_NAZIVOSOBNIODBITAK;
        private string m_NAZIVRADNOMJESTO;
        private string m_NAZIVSPOL;
        private string m_NAZIVSTRUKA;
        private string m_NAZIVTITULA;
        private int m_NETOELEMENTIDELEMENT;
        private string m_NETOELEMENTNAZIVELEMENT;
        private decimal m_NETOIZNOS;
        private decimal m_NETOPOSTOTAK;
        private decimal m_NETOSATI;
        private decimal m_NETOSATNICA;
        private bool m_OBUSTAVAAKTIVNA;
        private string m_OIB;
        private string m_OPCINARADAIDOPCINE;
        private string m_OPCINARADANAZIVOPCINE;
        private string m_OPCINASTANOVANJAIDOPCINE;
        private string m_OPCINASTANOVANJANAZIVOPCINE;
        private decimal m_OPCINASTANOVANJAPRIREZ;
        private string m_OPCINASTANOVANJAVBDIOPCINA;
        private string m_OPCINASTANOVANJAZRNOPCINA;
        private string m_OPISPLACANJAKREDITOR;
        private string m_OPISPLACANJANETO;
        private string m_ORGANIZACIJSKIDIO;
        private int m_OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;
        private string m_POKREDITOR;
        private decimal m_POSTOTAKOSLOBODJENJAODPOREZA;
        private int m_POTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
        private string m_POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA;
        private string m_PREZIME;
        private string m_PZKREDITOR;
        private int m_RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
        private string m_RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA;
        private int m_RecordCount;
        private string m_SIFRAOPISAPLACANJAKREDITOR;
        private string m_SIFRAOPISAPLACANJANETO;
        private string m_SubSelTopString22;
        private string m_SubSelTopString23;
        private string m_SubSelTopString290;
        private string m_SubSelTopString54;
        private string m_SubSelTopString56;
        private string m_SubSelTopString59;
        private string m_SubSelTopString75;
        private string m_TEKUCI;
        private decimal m_TJEDNIFONDSATI;
        private decimal m_TJEDNIFONDSATISTAZ;
        private int m_TopRowCount;
        private int m_TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
        private string m_TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA;
        private string m_ulica;
        private bool m_UZIMAUOBZIROSNOVICEDOPRINOSA;
        private string m_VBDIBANKE;
        private string m_WhereString;
        private string m_WhereString3;
        private string m_WhereString4;
        private string m_WhereString5;
        private string m_WhereString6;
        private string m_WhereString7;
        private string m_WhereString8;
        private string m_WhereString9;
        private decimal m_ZADBROJRATAOBUSTAVE;
        private decimal m_ZADISPLACENOKASA;
        private decimal m_ZADIZNOSIZUZECA;
        private decimal m_ZADIZNOSOBUSTAVE;
        private decimal m_ZADIZNOSOLAKSICE;
        private decimal m_ZADIZNOSRATEKREDITA;
        private int m_ZADKREDITIIDKREDITOR;
        private string m_ZADKREDITINAZIVKREDITOR;
        private string m_ZADKREDITIPRIMATELJKREDITOR1;
        private string m_ZADKREDITIPRIMATELJKREDITOR2;
        private string m_ZADKREDITIPRIMATELJKREDITOR3;
        private string m_ZADMOIZUZECE;
        private string m_ZADMOOLAKSICE;
        private string m_ZADMZIZUZECE;
        private string m_ZADMZOLAKSICE;
        private int m_ZADOBUSTAVAIDOBUSTAVA;
        private string m_ZADOBUSTAVANAZIVOBUSTAVA;
        private string m_ZADOBUSTAVANAZIVVRSTAOBUSTAVE;
        private short m_ZADOBUSTAVAVRSTAOBUSTAVE;
        private int m_ZADOLAKSICEIDGRUPEOLAKSICA;
        private int m_ZADOLAKSICEIDOLAKSICE;
        private int m_ZADOLAKSICEIDTIPOLAKSICE;
        private decimal m_ZADOLAKSICEMAXIMALNIIZNOSGRUPE;
        private string m_ZADOLAKSICENAZIVGRUPEOLAKSICA;
        private string m_ZADOLAKSICENAZIVOLAKSICE;
        private string m_ZADOLAKSICENAZIVTIPOLAKSICE;
        private string m_ZADOLAKSICEPRIMATELJOLAKSICA1;
        private string m_ZADOLAKSICEPRIMATELJOLAKSICA2;
        private string m_ZADOLAKSICEPRIMATELJOLAKSICA3;
        private string m_ZADOLAKSICEVBDIOLAKSICA;
        private string m_ZADOLAKSICEZRNOLAKSICA;
        private string m_ZADOPISPLACANJAIZUZECE;
        private string m_ZADOPISPLACANJAOLAKSICE;
        private string m_ZADPOIZUZECE;
        private string m_ZADPOOLAKSICE;
        private decimal m_ZADPOSTOTAKOBUSTAVE;
        private bool m_ZADPOSTOTNAODBRUTA;
        private string m_ZADPZIZUZECE;
        private string m_ZADPZOLAKSICE;
        private decimal m_ZADSALDOKASA;
        private string m_ZADSIFRAOPISAPLACANJAIZUZECE;
        private string m_ZADSIFRAOPISAPLACANJAOLAKSICE;
        private string m_ZADTEKUCIIZUZECE;
        private decimal m_ZADUKUPNIZNOSKREDITA;
        private decimal m_ZADVECOTPLACENOBROJRATA;
        private decimal m_ZADVECOTPLACENOUKUPNIIZNOS;
        private bool m_ZBIRNINETO;
        private string m_ZRNBANKE;
        private ArrayList orderArray;
        private string orderString;
        private IDataReader RADNIKBrutoSelect1;
        private IDataReader RADNIKIzuzeceOdOvrheSelect1;
        private IDataReader RADNIKKreditiSelect1;
        private IDataReader RADNIKNetoSelect1;
        private IDataReader RADNIKObustavaSelect1;
        private IDataReader RADNIKOdbitakSelect1;
        private IDataReader RADNIKOlaksicaSelect1;
        private IDataReader RADNIKSelect1;
        private IDataReader RADNIKSelect2;
        private RADNIKDataSet RadnikZaObracunSet;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private string reverseOrderString;
        private RADNIKDataSet.RADNIKRow rowRADNIK;
        private RADNIKDataSet.RADNIKBrutoRow rowRADNIKBruto;
        private RADNIKDataSet.RADNIKIzuzeceOdOvrheRow rowRADNIKIzuzeceOdOvrhe;
        private RADNIKDataSet.RADNIKKreditiRow rowRADNIKKrediti;
        private RADNIKDataSet.RADNIKNetoRow rowRADNIKNeto;
        private RADNIKDataSet.RADNIKObustavaRow rowRADNIKObustava;
        private RADNIKDataSet.RADNIKOdbitakRow rowRADNIKOdbitak;
        private RADNIKDataSet.RADNIKOlaksicaRow rowRADNIKOlaksica;
        private string scmdbuf;
        private string sWhereSep;

        public RadnikZaObracunDataAdapter()
        {
            this.Init_order_Radnik();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
        }

        private void AddRowRadnik()
        {
            this.RadnikZaObracunSet.RADNIK.AddRADNIKRow(this.rowRADNIK);
            this.rowRADNIK.AcceptChanges();
        }

        private void AddRowRadnikbruto()
        {
            this.RadnikZaObracunSet.RADNIKBruto.AddRADNIKBrutoRow(this.rowRADNIKBruto);
            this.rowRADNIKBruto.AcceptChanges();
        }

        private void AddRowRadnikizuzeceodovrhe()
        {
            this.RadnikZaObracunSet.RADNIKIzuzeceOdOvrhe.AddRADNIKIzuzeceOdOvrheRow(this.rowRADNIKIzuzeceOdOvrhe);
            this.rowRADNIKIzuzeceOdOvrhe.AcceptChanges();
        }

        private void AddRowRadnikkrediti()
        {
            this.RadnikZaObracunSet.RADNIKKrediti.AddRADNIKKreditiRow(this.rowRADNIKKrediti);
            this.rowRADNIKKrediti.AcceptChanges();
        }

        private void AddRowRadnikneto()
        {
            this.RadnikZaObracunSet.RADNIKNeto.AddRADNIKNetoRow(this.rowRADNIKNeto);
            this.rowRADNIKNeto.AcceptChanges();
        }

        private void AddRowRadnikobustava()
        {
            this.RadnikZaObracunSet.RADNIKObustava.AddRADNIKObustavaRow(this.rowRADNIKObustava);
            this.rowRADNIKObustava.AcceptChanges();
        }

        private void AddRowRadnikodbitak()
        {
            this.RadnikZaObracunSet.RADNIKOdbitak.AddRADNIKOdbitakRow(this.rowRADNIKOdbitak);
            this.rowRADNIKOdbitak.AcceptChanges();
        }

        private void AddRowRadnikolaksica()
        {
            this.RadnikZaObracunSet.RADNIKOlaksica.AddRADNIKOlaksicaRow(this.rowRADNIKOlaksica);
            this.rowRADNIKOlaksica.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            string[] strArray;
            int num10 = 0;
            this.m_WhereString = "" + this.filterString + "  ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString();
                    this.scmdbuf = this.scmdbuf + "  TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[PREZIME], TM1.[IME], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T15.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, T13.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, TM1.[IDBANKE], T12.[NAZIVBANKE1], T12.[NAZIVBANKE2], T12.[NAZIVBANKE3], T12.[VBDIBANKE], T12.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], TM1.[IDBENEFICIRANI], T11.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], TM1.[IDTITULA], T10.[NAZIVTITULA], TM1.[IDRADNOMJESTO], T9.[NAZIVRADNOMJESTO], TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, T8.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, T7.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, TM1.[IDSTRUKA], T6.[NAZIVSTRUKA], TM1.[IDBRACNOSTANJE], T5.[NAZIVBRACNOSTANJE], TM1.[IDORGDIO], T4.[ORGANIZACIJSKIDIO], TM1.[OIB], TM1.[IDSPOL], T3.[NAZIVSPOL], TM1.[IDIPIDENT], T2.[NAZIVIPIDENT]";
                    this.scmdbuf = this.scmdbuf + " FROM (((((((((((((([RADNIK] TM1 INNER JOIN [IPIDENT] T2 ON T2.[IDIPIDENT] = TM1.[IDIPIDENT]) INNER JOIN [SPOL] T3 ON T3.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [ORGDIO] T4 ON T4.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [BRACNOSTANJE] T5 ON T5.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [STRUKA] T6 ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [STRUCNASPREMA] T7 ON T7.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T8 ON T8.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [RADNOMJESTO] T9 ON T9.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [TITULA] T10 ON T10.[IDTITULA] = TM1.[IDTITULA]) INNER JOIN [BENEFICIRANI] T11 ON T11.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) INNER JOIN [BANKE] T12 ON T12.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T13 ON T13.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [OPCINA] T14 ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [OPCINA] T15 ON T15.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE])";
                    this.scmdbuf = this.scmdbuf + this.m_WhereString + "" + this.orderString + "";
                }
                else
                {
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    else
                    {
                        this.sWhereSep = " AND ";
                    }
                    int internalRecordCount = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(internalRecordCount >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(internalRecordCount >= startRow, internalRecordCount - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    this.scmdbuf = "";
                    this.scmdbuf = this.scmdbuf + "SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[PREZIME], TM1.[IME], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T15.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, T13.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, TM1.[IDBANKE], T12.[NAZIVBANKE1], T12.[NAZIVBANKE2], T12.[NAZIVBANKE3], T12.[VBDIBANKE], T12.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], TM1.[IDBENEFICIRANI], T11.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], TM1.[IDTITULA], T10.[NAZIVTITULA], TM1.[IDRADNOMJESTO], T9.[NAZIVRADNOMJESTO], TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, T8.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, T7.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, TM1.[IDSTRUKA], T6.[NAZIVSTRUKA], TM1.[IDBRACNOSTANJE], T5.[NAZIVBRACNOSTANJE], TM1.[IDORGDIO], T4.[ORGANIZACIJSKIDIO], TM1.[OIB], TM1.[IDSPOL], T3.[NAZIVSPOL], TM1.[IDIPIDENT], T2.[NAZIVIPIDENT]";
                    this.scmdbuf = this.scmdbuf + " FROM (((((((((((((([RADNIK] TM1 INNER JOIN [IPIDENT] T2 ON T2.[IDIPIDENT] = TM1.[IDIPIDENT]) INNER JOIN [SPOL] T3 ON T3.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [ORGDIO] T4 ON T4.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [BRACNOSTANJE] T5 ON T5.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [STRUKA] T6 ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [STRUCNASPREMA] T7 ON T7.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T8 ON T8.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [RADNOMJESTO] T9 ON T9.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [TITULA] T10 ON T10.[IDTITULA] = TM1.[IDTITULA]) INNER JOIN [BENEFICIRANI] T11 ON T11.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) INNER JOIN [BANKE] T12 ON T12.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T13 ON T13.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [OPCINA] T14 ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [OPCINA] T15 ON T15.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) WHERE TM1.[IDRADNIK] IN ( SELECT TOP ";
                    this.scmdbuf = this.scmdbuf + maxRows.ToString() + " TM1.[IDRADNIK]  FROM (((((((((((((([RADNIK] TM1 INNER JOIN [IPIDENT] T2 ON T2.[IDIPIDENT] = TM1.[IDIPIDENT]) INNER JOIN [SPOL] T3 ON T3.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [ORGDIO] T4 ON T4.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [BRACNOSTANJE] T5 ON T5.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [STRUKA] T6 ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [STRUCNASPREMA] T7 ON T7.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T8 ON T8.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [RADNOMJESTO] T9 ON T9.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [TITULA] T10 ON T10.[IDTITULA] = TM1.[IDTITULA]) INNER JOIN [BENEFICIRANI] T11 ON T11.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) INNER JOIN [BANKE] T12 ON T12.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T13 ON T13.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [OPCINA] T14 ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [OPCINA] T15 ON T15.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE])" + this.m_WhereString + "" + this.sWhereSep + "TM1.[IDRADNIK] NOT IN ( SELECT TOP " + startRow.ToString();
                    this.scmdbuf = this.scmdbuf + " TM1.[IDRADNIK]  FROM (((((((((((((([RADNIK] TM1 INNER JOIN [IPIDENT] T2 ON T2.[IDIPIDENT] = TM1.[IDIPIDENT]) INNER JOIN [SPOL] T3 ON T3.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [ORGDIO] T4 ON T4.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [BRACNOSTANJE] T5 ON T5.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [STRUKA] T6 ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [STRUCNASPREMA] T7 ON T7.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T8 ON T8.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [RADNOMJESTO] T9 ON T9.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [TITULA] T10 ON T10.[IDTITULA] = TM1.[IDTITULA]) INNER JOIN [BENEFICIRANI] T11 ON T11.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) INNER JOIN [BANKE] T12 ON T12.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T13 ON T13.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [OPCINA] T14 ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [OPCINA] T15 ON T15.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE])" + this.m_WhereString + "" + this.orderString + ")" + this.orderString + ")" + this.orderString + "";
                }
            }
            else
            {
                this.scmdbuf = "";
                this.scmdbuf = this.scmdbuf + "SELECT TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[PREZIME], TM1.[IME], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, T15.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, T14.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T14.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T14.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T14.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, T13.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, TM1.[IDBANKE], T12.[NAZIVBANKE1], T12.[NAZIVBANKE2], T12.[NAZIVBANKE3], T12.[VBDIBANKE], T12.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], TM1.[IDBENEFICIRANI], T11.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], TM1.[IDTITULA], T10.[NAZIVTITULA], TM1.[IDRADNOMJESTO], T9.[NAZIVRADNOMJESTO], TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, T8.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, T7.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, TM1.[IDSTRUKA], T6.[NAZIVSTRUKA], TM1.[IDBRACNOSTANJE], T5.[NAZIVBRACNOSTANJE], TM1.[IDORGDIO], T4.[ORGANIZACIJSKIDIO], TM1.[OIB], TM1.[IDSPOL], T3.[NAZIVSPOL], TM1.[IDIPIDENT], T2.[NAZIVIPIDENT]";
                this.scmdbuf = this.scmdbuf + " FROM (((((((((((((([RADNIK] TM1 INNER JOIN [IPIDENT] T2 ON T2.[IDIPIDENT] = TM1.[IDIPIDENT]) INNER JOIN [SPOL] T3 ON T3.[IDSPOL] = TM1.[IDSPOL]) LEFT JOIN [ORGDIO] T4 ON T4.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [BRACNOSTANJE] T5 ON T5.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [STRUKA] T6 ON T6.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [STRUCNASPREMA] T7 ON T7.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T8 ON T8.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [RADNOMJESTO] T9 ON T9.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [TITULA] T10 ON T10.[IDTITULA] = TM1.[IDTITULA]) INNER JOIN [BENEFICIRANI] T11 ON T11.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) INNER JOIN [BANKE] T12 ON T12.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T13 ON T13.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [OPCINA] T14 ON T14.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [OPCINA] T15 ON T15.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE])";
                this.scmdbuf = this.scmdbuf + this.m_WhereString + "" + this.orderString + " ";
            }
            this.cmRADNIKSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKSelect2.ErrorMask |= ErrorMask.Lock;
            this.RADNIKSelect2 = this.cmRADNIKSelect2.FetchData();
            int num = 0;
            while (this.cmRADNIKSelect2.HasMoreRows && (num != maxRows))
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0, ref this.m__IDRADNIKIsNull);
                this.m_AKTIVAN = this.dsDefault.Db.GetBoolean(this.RADNIKSelect2, 1, ref this.m__AKTIVANIsNull);
                this.m_PREZIME = this.dsDefault.Db.GetString(this.RADNIKSelect2, 2, ref this.m__PREZIMEIsNull);
                this.m_IME = this.dsDefault.Db.GetString(this.RADNIKSelect2, 3, ref this.m__IMEIsNull);
                this.m_JMBG = this.dsDefault.Db.GetString(this.RADNIKSelect2, 4, ref this.m__JMBGIsNull);
                this.m_DATUMRODJENJA = this.dsDefault.Db.GetDateTime(this.RADNIKSelect2, 5, ref this.m__DATUMRODJENJAIsNull);
                this.m_ulica = this.dsDefault.Db.GetString(this.RADNIKSelect2, 6, ref this.m__ulicaIsNull);
                this.m_mjesto = this.dsDefault.Db.GetString(this.RADNIKSelect2, 7, ref this.m__mjestoIsNull);
                this.m_kucnibroj = this.dsDefault.Db.GetString(this.RADNIKSelect2, 8, ref this.m__kucnibrojIsNull);
                this.m_OPCINARADAIDOPCINE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 9, ref this.m__OPCINARADAIDOPCINEIsNull);
                this.m_OPCINARADANAZIVOPCINE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 10, ref this.m__OPCINARADANAZIVOPCINEIsNull);
                this.m_OPCINASTANOVANJAIDOPCINE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 11, ref this.m__OPCINASTANOVANJAIDOPCINEIsNull);
                this.m_OPCINASTANOVANJANAZIVOPCINE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 12, ref this.m__OPCINASTANOVANJANAZIVOPCINEIsNull);
                this.m_OPCINASTANOVANJAPRIREZ = this.dsDefault.Db.GetDecimal(this.RADNIKSelect2, 13, ref this.m__OPCINASTANOVANJAPRIREZIsNull);
                this.m_OPCINASTANOVANJAVBDIOPCINA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 14, ref this.m__OPCINASTANOVANJAVBDIOPCINAIsNull);
                this.m_OPCINASTANOVANJAZRNOPCINA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 15, ref this.m__OPCINASTANOVANJAZRNOPCINAIsNull);
                this.m_RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x10, ref this.m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAIsNull);
                this.m_RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x11, ref this.m__RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAIsNull);
                this.m_IDBANKE = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x12, ref this.m__IDBANKEIsNull);
                this.m_NAZIVBANKE1 = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x13, ref this.m__NAZIVBANKE1IsNull);
                this.m_NAZIVBANKE2 = this.dsDefault.Db.GetString(this.RADNIKSelect2, 20, ref this.m__NAZIVBANKE2IsNull);
                this.m_NAZIVBANKE3 = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x15, ref this.m__NAZIVBANKE3IsNull);
                this.m_VBDIBANKE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x16, ref this.m__VBDIBANKEIsNull);
                this.m_ZRNBANKE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x17, ref this.m__ZRNBANKEIsNull);
                this.m_TEKUCI = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x18, ref this.m__TEKUCIIsNull);
                this.m_ZBIRNINETO = this.dsDefault.Db.GetBoolean(this.RADNIKSelect2, 0x19, ref this.m__ZBIRNINETOIsNull);
                this.m_SIFRAOPISAPLACANJANETO = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x1a, ref this.m__SIFRAOPISAPLACANJANETOIsNull);
                this.m_OPISPLACANJANETO = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x1b, ref this.m__OPISPLACANJANETOIsNull);
                this.m_TJEDNIFONDSATI = this.dsDefault.Db.GetDecimal(this.RADNIKSelect2, 0x1c, ref this.m__TJEDNIFONDSATIIsNull);
                this.m_KOEFICIJENT = this.dsDefault.Db.GetDecimal(this.RADNIKSelect2, 0x1d, ref this.m__KOEFICIJENTIsNull);
                this.m_POSTOTAKOSLOBODJENJAODPOREZA = this.dsDefault.Db.GetDecimal(this.RADNIKSelect2, 30, ref this.m__POSTOTAKOSLOBODJENJAODPOREZAIsNull);
                this.m_UZIMAUOBZIROSNOVICEDOPRINOSA = this.dsDefault.Db.GetBoolean(this.RADNIKSelect2, 0x1f, ref this.m__UZIMAUOBZIROSNOVICEDOPRINOSAIsNull);
                this.m_TJEDNIFONDSATISTAZ = this.dsDefault.Db.GetDecimal(this.RADNIKSelect2, 0x20, ref this.m__TJEDNIFONDSATISTAZIsNull);
                this.m_DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = this.dsDefault.Db.GetDateTime(this.RADNIKSelect2, 0x21, ref this.m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIIsNull);
                this.m_GODINESTAZA = this.dsDefault.Db.GetInt16(this.RADNIKSelect2, 0x22, ref this.m__GODINESTAZAIsNull);
                this.m_MJESECISTAZA = this.dsDefault.Db.GetInt16(this.RADNIKSelect2, 0x23, ref this.m__MJESECISTAZAIsNull);
                this.m_DANISTAZA = this.dsDefault.Db.GetInt16(this.RADNIKSelect2, 0x24, ref this.m__DANISTAZAIsNull);
                this.m_IDBENEFICIRANI = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x25, ref this.m__IDBENEFICIRANIIsNull);
                this.m_NAZIVBENEFICIRANI = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x26, ref this.m__NAZIVBENEFICIRANIIsNull);
                this.m_DATUMPRESTANKARADNOGODNOSA = this.dsDefault.Db.GetDateTime(this.RADNIKSelect2, 0x27, ref this.m__DATUMPRESTANKARADNOGODNOSAIsNull);
                this.m_BROJMIROVINSKOG = this.dsDefault.Db.GetString(this.RADNIKSelect2, 40, ref this.m__BROJMIROVINSKOGIsNull);
                this.m_BROJZDRAVSTVENOG = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x29, ref this.m__BROJZDRAVSTVENOGIsNull);
                this.m_MBO = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x2a, ref this.m__MBOIsNull);
                this.m_IDTITULA = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x2b, ref this.m__IDTITULAIsNull);
                this.m_NAZIVTITULA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x2c, ref this.m__NAZIVTITULAIsNull);
                this.m_IDRADNOMJESTO = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x2d, ref this.m__IDRADNOMJESTOIsNull);
                this.m_NAZIVRADNOMJESTO = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x2e, ref this.m__NAZIVRADNOMJESTOIsNull);
                this.m_TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x2f, ref this.m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAIsNull);
                this.m_TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x30, ref this.m__TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull);
                this.m_POTREBNASTRUCNASPREMAIDSTRUCNASPREMA = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x31, ref this.m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAIsNull);
                this.m_POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 50, ref this.m__POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull);
                this.m_IDSTRUKA = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x33, ref this.m__IDSTRUKAIsNull);
                this.m_NAZIVSTRUKA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x34, ref this.m__NAZIVSTRUKAIsNull);
                this.m_IDBRACNOSTANJE = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x35, ref this.m__IDBRACNOSTANJEIsNull);
                this.m_NAZIVBRACNOSTANJE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x36, ref this.m__NAZIVBRACNOSTANJEIsNull);
                this.m_IDORGDIO = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x37, ref this.m__IDORGDIOIsNull);
                this.m_ORGANIZACIJSKIDIO = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x38, ref this.m__ORGANIZACIJSKIDIOIsNull);
                this.m_OIB = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x39, ref this.m__OIBIsNull);
                this.m_IDSPOL = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 0x3a, ref this.m__IDSPOLIsNull);
                this.m_NAZIVSPOL = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x3b, ref this.m__NAZIVSPOLIsNull);
                this.m_IDIPIDENT = this.dsDefault.Db.GetInt32(this.RADNIKSelect2, 60, ref this.m__IDIPIDENTIsNull);
                this.m_NAZIVIPIDENT = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x3d, ref this.m__NAZIVIPIDENTIsNull);
                this.m_NAZIVIPIDENT = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x3d, ref this.m__NAZIVIPIDENTIsNull);
                this.m_NAZIVSPOL = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x3b, ref this.m__NAZIVSPOLIsNull);
                this.m_ORGANIZACIJSKIDIO = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x38, ref this.m__ORGANIZACIJSKIDIOIsNull);
                this.m_NAZIVBRACNOSTANJE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x36, ref this.m__NAZIVBRACNOSTANJEIsNull);
                this.m_NAZIVSTRUKA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x34, ref this.m__NAZIVSTRUKAIsNull);
                this.m_POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 50, ref this.m__POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull);
                this.m_TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x30, ref this.m__TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull);
                this.m_NAZIVRADNOMJESTO = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x2e, ref this.m__NAZIVRADNOMJESTOIsNull);
                this.m_NAZIVTITULA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x2c, ref this.m__NAZIVTITULAIsNull);
                this.m_NAZIVBENEFICIRANI = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x26, ref this.m__NAZIVBENEFICIRANIIsNull);
                this.m_NAZIVBANKE1 = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x13, ref this.m__NAZIVBANKE1IsNull);
                this.m_NAZIVBANKE2 = this.dsDefault.Db.GetString(this.RADNIKSelect2, 20, ref this.m__NAZIVBANKE2IsNull);
                this.m_NAZIVBANKE3 = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x15, ref this.m__NAZIVBANKE3IsNull);
                this.m_VBDIBANKE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x16, ref this.m__VBDIBANKEIsNull);
                this.m_ZRNBANKE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x17, ref this.m__ZRNBANKEIsNull);
                this.m_RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 0x11, ref this.m__RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAIsNull);
                this.m_OPCINASTANOVANJANAZIVOPCINE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 12, ref this.m__OPCINASTANOVANJANAZIVOPCINEIsNull);
                this.m_OPCINASTANOVANJAPRIREZ = this.dsDefault.Db.GetDecimal(this.RADNIKSelect2, 13, ref this.m__OPCINASTANOVANJAPRIREZIsNull);
                this.m_OPCINASTANOVANJAVBDIOPCINA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 14, ref this.m__OPCINASTANOVANJAVBDIOPCINAIsNull);
                this.m_OPCINASTANOVANJAZRNOPCINA = this.dsDefault.Db.GetString(this.RADNIKSelect2, 15, ref this.m__OPCINASTANOVANJAZRNOPCINAIsNull);
                this.m_OPCINARADANAZIVOPCINE = this.dsDefault.Db.GetString(this.RADNIKSelect2, 10, ref this.m__OPCINARADANAZIVOPCINEIsNull);
                this.rowRADNIK = this.RadnikZaObracunSet.RADNIK.NewRADNIKRow();
                this.rowRADNIK["IDRADNIK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDRADNIKIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDRADNIK));
                this.rowRADNIK["AKTIVAN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__AKTIVANIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_AKTIVAN));
                this.rowRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PREZIMEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PREZIME));
                this.rowRADNIK["IME"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IMEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IME));
                this.rowRADNIK["JMBG"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__JMBGIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_JMBG));
                this.rowRADNIK["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DATUMRODJENJAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DATUMRODJENJA));
                this.rowRADNIK["ulica"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ulicaIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ulica));
                this.rowRADNIK["mjesto"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__mjestoIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_mjesto));
                this.rowRADNIK["kucnibroj"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__kucnibrojIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_kucnibroj));
                this.rowRADNIK["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINARADAIDOPCINEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINARADAIDOPCINE));
                this.rowRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINARADANAZIVOPCINEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINARADANAZIVOPCINE));
                this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINASTANOVANJAIDOPCINEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINASTANOVANJAIDOPCINE));
                this.rowRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINASTANOVANJANAZIVOPCINEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINASTANOVANJANAZIVOPCINE));
                this.rowRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINASTANOVANJAPRIREZIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINASTANOVANJAPRIREZ));
                this.rowRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINASTANOVANJAVBDIOPCINAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINASTANOVANJAVBDIOPCINA));
                this.rowRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPCINASTANOVANJAZRNOPCINAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPCINASTANOVANJAZRNOPCINA));
                this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA));
                this.rowRADNIK["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA));
                this.rowRADNIK["IDBANKE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDBANKEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDBANKE));
                this.rowRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVBANKE1IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVBANKE1));
                this.rowRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVBANKE2IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVBANKE2));
                this.rowRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVBANKE3IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVBANKE3));
                this.rowRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__VBDIBANKEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_VBDIBANKE));
                this.rowRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZRNBANKEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZRNBANKE));
                this.rowRADNIK["TEKUCI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__TEKUCIIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_TEKUCI));
                this.rowRADNIK["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZBIRNINETOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZBIRNINETO));
                this.rowRADNIK["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__SIFRAOPISAPLACANJANETOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_SIFRAOPISAPLACANJANETO));
                this.rowRADNIK["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPISPLACANJANETOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPISPLACANJANETO));
                this.rowRADNIK["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__TJEDNIFONDSATIIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_TJEDNIFONDSATI));
                this.rowRADNIK["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__KOEFICIJENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_KOEFICIJENT));
                this.rowRADNIK["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__POSTOTAKOSLOBODJENJAODPOREZAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_POSTOTAKOSLOBODJENJAODPOREZA));
                this.rowRADNIK["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__UZIMAUOBZIROSNOVICEDOPRINOSAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_UZIMAUOBZIROSNOVICEDOPRINOSA));
                this.rowRADNIK["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__TJEDNIFONDSATISTAZIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_TJEDNIFONDSATISTAZ));
                this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI));
                this.rowRADNIK["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__GODINESTAZAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_GODINESTAZA));
                this.rowRADNIK["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MJESECISTAZAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MJESECISTAZA));
                this.rowRADNIK["DANISTAZA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DANISTAZAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DANISTAZA));
                this.rowRADNIK["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDBENEFICIRANIIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDBENEFICIRANI));
                this.rowRADNIK["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVBENEFICIRANIIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVBENEFICIRANI));
                this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DATUMPRESTANKARADNOGODNOSAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DATUMPRESTANKARADNOGODNOSA));
                this.rowRADNIK["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BROJMIROVINSKOGIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BROJMIROVINSKOG));
                this.rowRADNIK["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BROJZDRAVSTVENOGIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BROJZDRAVSTVENOG));
                this.rowRADNIK["MBO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MBOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MBO));
                this.rowRADNIK["IDTITULA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDTITULAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDTITULA));
                this.rowRADNIK["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVTITULAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVTITULA));
                this.rowRADNIK["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDRADNOMJESTOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDRADNOMJESTO));
                this.rowRADNIK["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVRADNOMJESTOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVRADNOMJESTO));
                this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA));
                this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA));
                this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_POTREBNASTRUCNASPREMAIDSTRUCNASPREMA));
                this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA));
                this.rowRADNIK["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDSTRUKAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDSTRUKA));
                this.rowRADNIK["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVSTRUKAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVSTRUKA));
                this.rowRADNIK["IDBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDBRACNOSTANJEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDBRACNOSTANJE));
                this.rowRADNIK["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVBRACNOSTANJEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVBRACNOSTANJE));
                this.rowRADNIK["IDORGDIO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDORGDIOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDORGDIO));
                this.rowRADNIK["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ORGANIZACIJSKIDIOIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ORGANIZACIJSKIDIO));
                this.rowRADNIK["OIB"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OIBIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OIB));
                this.rowRADNIK["IDSPOL"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDSPOLIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDSPOL));
                this.rowRADNIK["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVSPOLIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVSPOL));
                this.rowRADNIK["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__IDIPIDENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_IDIPIDENT));
                this.rowRADNIK["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVIPIDENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVIPIDENT));
                this.AddRowRadnik();
                num++;
                this.cmRADNIKSelect2.HasMoreRows = this.RADNIKSelect2.Read();
            }
            this.RADNIKSelect2.Close();
            this.m_WhereString9 = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_SubSelTopString290 = "( SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK] FROM [RADNIK] TM1" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ASC )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BANKAZASTICENOIDBANKE], T1.[ZADSIFRAOPISAPLACANJAIZUZECE], T1.[ZADOPISPLACANJAIZUZECE], T1.[ZADTEKUCIIZUZECE], T1.[ZADMOIZUZECE], T1.[ZADPOIZUZECE], T1.[ZADMZIZUZECE], T1.[ZADPZIZUZECE], T1.[ZADIZNOSIZUZECA] FROM ([RADNIKIzuzeceOdOvrhe] T1 INNER JOIN  " + this.m_SubSelTopString290 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString9 + " ORDER BY T1.[IDRADNIK]";
                }
                else
                {
                    int num3 = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(num3 >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(num3 >= startRow, num3 - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    strArray = new string[7];
                    strArray[0] = "( SELECT TOP ";
                    strArray[1] = this.m_TopRowCount.ToString();
                    strArray[2] = " * FROM ( SELECT TOP ";
                    num10 = startRow + maxRows;
                    strArray[3] = num10.ToString();
                    strArray[4] = " TM1.[IDRADNIK] FROM [RADNIK] TM1";
                    strArray[5] = this.m_WhereString;
                    strArray[6] = " ORDER BY TM1.[IDRADNIK] ASC ) DK_A1  ORDER BY [IDRADNIK] DESC )";
                    this.m_SubSelTopString290 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BANKAZASTICENOIDBANKE], T1.[ZADSIFRAOPISAPLACANJAIZUZECE], T1.[ZADOPISPLACANJAIZUZECE], T1.[ZADTEKUCIIZUZECE], T1.[ZADMOIZUZECE], T1.[ZADPOIZUZECE], T1.[ZADMZIZUZECE], T1.[ZADPZIZUZECE], T1.[ZADIZNOSIZUZECA] FROM ([RADNIKIzuzeceOdOvrhe] T1 INNER JOIN  " + this.m_SubSelTopString290 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString9 + " ORDER BY T1.[IDRADNIK]";
                }
            }
            else
            {
                if (string.Compare(this.m_WhereString9.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                {
                    this.sWhereSep = "";
                }
                else
                {
                    this.sWhereSep = "";
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)
                    {
                        this.sWhereSep = " AND ";
                    }
                    else
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    this.m_WhereString9 = this.m_WhereString9.Substring(7);
                }
                this.m_SubSelTopString290 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BANKAZASTICENOIDBANKE], T1.[ZADSIFRAOPISAPLACANJAIZUZECE], T1.[ZADOPISPLACANJAIZUZECE], T1.[ZADTEKUCIIZUZECE], T1.[ZADMOIZUZECE], T1.[ZADPOIZUZECE], T1.[ZADMZIZUZECE], T1.[ZADPZIZUZECE], T1.[ZADIZNOSIZUZECA] FROM ([RADNIKIzuzeceOdOvrhe] T1 INNER JOIN  " + this.m_SubSelTopString290 + "  TM1 ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " " + this.sWhereSep + " " + this.m_WhereString9 + " ORDER BY T1.[IDRADNIK] ";
            }
            this.cmRADNIKIzuzeceOdOvrheSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKIzuzeceOdOvrheSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKIzuzeceOdOvrheSelect1 = this.cmRADNIKIzuzeceOdOvrheSelect1.FetchData();
            while (this.cmRADNIKIzuzeceOdOvrheSelect1.HasMoreRows)
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKIzuzeceOdOvrheSelect1, 0, ref this.m__IDRADNIKIsNull);
                this.m_BANKAZASTICENOIDBANKE = this.dsDefault.Db.GetInt32(this.RADNIKIzuzeceOdOvrheSelect1, 1, ref this.m__BANKAZASTICENOIDBANKEIsNull);
                this.m_ZADSIFRAOPISAPLACANJAIZUZECE = this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect1, 2, ref this.m__ZADSIFRAOPISAPLACANJAIZUZECEIsNull);
                this.m_ZADOPISPLACANJAIZUZECE = this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect1, 3, ref this.m__ZADOPISPLACANJAIZUZECEIsNull);
                this.m_ZADTEKUCIIZUZECE = this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect1, 4, ref this.m__ZADTEKUCIIZUZECEIsNull);
                this.m_ZADMOIZUZECE = this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect1, 5, ref this.m__ZADMOIZUZECEIsNull);
                this.m_ZADPOIZUZECE = this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect1, 6, ref this.m__ZADPOIZUZECEIsNull);
                this.m_ZADMZIZUZECE = this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect1, 7, ref this.m__ZADMZIZUZECEIsNull);
                this.m_ZADPZIZUZECE = this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect1, 8, ref this.m__ZADPZIZUZECEIsNull);
                this.m_ZADIZNOSIZUZECA = this.dsDefault.Db.GetDecimal(this.RADNIKIzuzeceOdOvrheSelect1, 9, ref this.m__ZADIZNOSIZUZECAIsNull);
                this.rowRADNIKIzuzeceOdOvrhe = this.RadnikZaObracunSet.RADNIKIzuzeceOdOvrhe.NewRADNIKIzuzeceOdOvrheRow();
                this.rowRADNIKIzuzeceOdOvrhe["BANKAZASTICENOIDBANKE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BANKAZASTICENOIDBANKEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BANKAZASTICENOIDBANKE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADSIFRAOPISAPLACANJAIZUZECE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADSIFRAOPISAPLACANJAIZUZECEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADSIFRAOPISAPLACANJAIZUZECE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADOPISPLACANJAIZUZECE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOPISPLACANJAIZUZECEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOPISPLACANJAIZUZECE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADTEKUCIIZUZECE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADTEKUCIIZUZECEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADTEKUCIIZUZECE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADMOIZUZECE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADMOIZUZECEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADMOIZUZECE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADPOIZUZECE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADPOIZUZECEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADPOIZUZECE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADMZIZUZECE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADMZIZUZECEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADMZIZUZECE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADPZIZUZECE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADPZIZUZECEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADPZIZUZECE));
                this.rowRADNIKIzuzeceOdOvrhe["ZADIZNOSIZUZECA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADIZNOSIZUZECAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADIZNOSIZUZECA));
                this.rowRADNIKIzuzeceOdOvrhe.IDRADNIK = this.m_IDRADNIK;
                this.AddRowRadnikizuzeceodovrhe();
                this.cmRADNIKIzuzeceOdOvrheSelect1.HasMoreRows = this.RADNIKIzuzeceOdOvrheSelect1.Read();
            }
            this.RADNIKIzuzeceOdOvrheSelect1.Close();
            this.m_WhereString8 = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_SubSelTopString56 = "( SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK] FROM [RADNIK] TM1" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ASC )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT, T2.[NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT, T1.[NETOSATNICA], T1.[NETOSATI], T1.[NETOPOSTOTAK], T1.[NETOIZNOS] FROM (([RADNIKNeto] T1 INNER JOIN [ELEMENT] T2 ON T2.[IDELEMENT] = T1.[NETOELEMENTIDELEMENT]) INNER JOIN  " + this.m_SubSelTopString56 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString8 + " ORDER BY T1.[IDRADNIK]";
                }
                else
                {
                    int num4 = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(num4 >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(num4 >= startRow, num4 - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    strArray = new string[7];
                    strArray[0] = "( SELECT TOP ";
                    strArray[1] = this.m_TopRowCount.ToString();
                    strArray[2] = " * FROM ( SELECT TOP ";
                    num10 = startRow + maxRows;
                    strArray[3] = num10.ToString();
                    strArray[4] = " TM1.[IDRADNIK] FROM [RADNIK] TM1";
                    strArray[5] = this.m_WhereString;
                    strArray[6] = " ORDER BY TM1.[IDRADNIK] ASC ) DK_A1  ORDER BY [IDRADNIK] DESC )";
                    this.m_SubSelTopString56 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT, T2.[NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT, T1.[NETOSATNICA], T1.[NETOSATI], T1.[NETOPOSTOTAK], T1.[NETOIZNOS] FROM (([RADNIKNeto] T1 INNER JOIN [ELEMENT] T2 ON T2.[IDELEMENT] = T1.[NETOELEMENTIDELEMENT]) INNER JOIN  " + this.m_SubSelTopString56 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString8 + " ORDER BY T1.[IDRADNIK]";
                }
            }
            else
            {
                if (string.Compare(this.m_WhereString8.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                {
                    this.sWhereSep = "";
                }
                else
                {
                    this.sWhereSep = "";
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)
                    {
                        this.sWhereSep = " AND ";
                    }
                    else
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    this.m_WhereString8 = this.m_WhereString8.Substring(7);
                }
                this.m_SubSelTopString56 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT, T2.[NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT, T1.[NETOSATNICA], T1.[NETOSATI], T1.[NETOPOSTOTAK], T1.[NETOIZNOS] FROM (([RADNIKNeto] T1 INNER JOIN [ELEMENT] T2 ON T2.[IDELEMENT] = T1.[NETOELEMENTIDELEMENT]) INNER JOIN  " + this.m_SubSelTopString56 + "  TM1 ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " " + this.sWhereSep + " " + this.m_WhereString8 + " ORDER BY T1.[IDRADNIK] ";
            }
            this.cmRADNIKNetoSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKNetoSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKNetoSelect1 = this.cmRADNIKNetoSelect1.FetchData();
            while (this.cmRADNIKNetoSelect1.HasMoreRows)
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKNetoSelect1, 0, ref this.m__IDRADNIKIsNull);
                this.m_NETOELEMENTIDELEMENT = this.dsDefault.Db.GetInt32(this.RADNIKNetoSelect1, 1, ref this.m__NETOELEMENTIDELEMENTIsNull);
                this.m_NETOELEMENTNAZIVELEMENT = this.dsDefault.Db.GetString(this.RADNIKNetoSelect1, 2, ref this.m__NETOELEMENTNAZIVELEMENTIsNull);
                this.m_NETOSATNICA = this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect1, 3, ref this.m__NETOSATNICAIsNull);
                this.m_NETOSATI = this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect1, 4, ref this.m__NETOSATIIsNull);
                this.m_NETOPOSTOTAK = this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect1, 5, ref this.m__NETOPOSTOTAKIsNull);
                this.m_NETOIZNOS = this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect1, 6, ref this.m__NETOIZNOSIsNull);
                this.m_NETOELEMENTNAZIVELEMENT = this.dsDefault.Db.GetString(this.RADNIKNetoSelect1, 2, ref this.m__NETOELEMENTNAZIVELEMENTIsNull);
                this.rowRADNIKNeto = this.RadnikZaObracunSet.RADNIKNeto.NewRADNIKNetoRow();
                this.rowRADNIKNeto["NETOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NETOELEMENTIDELEMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NETOELEMENTIDELEMENT));
                this.rowRADNIKNeto["NETOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NETOELEMENTNAZIVELEMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NETOELEMENTNAZIVELEMENT));
                this.rowRADNIKNeto["NETOSATNICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NETOSATNICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NETOSATNICA));
                this.rowRADNIKNeto["NETOSATI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NETOSATIIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NETOSATI));
                this.rowRADNIKNeto["NETOPOSTOTAK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NETOPOSTOTAKIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NETOPOSTOTAK));
                this.rowRADNIKNeto["NETOIZNOS"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NETOIZNOSIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NETOIZNOS));
                this.rowRADNIKNeto.IDRADNIK = this.m_IDRADNIK;
                this.AddRowRadnikneto();
                this.cmRADNIKNetoSelect1.HasMoreRows = this.RADNIKNetoSelect1.Read();
            }
            this.RADNIKNetoSelect1.Close();
            this.m_WhereString7 = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_SubSelTopString54 = "( SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK] FROM [RADNIK] TM1" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ASC )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT, T2.[NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, T1.[BRUTOSATNICA], T1.[BRUTOSATI], T1.[BRUTOPOSTOTAK], T1.[BRUTOIZNOS] FROM (([RADNIKBruto] T1 INNER JOIN [ELEMENT] T2 ON T2.[IDELEMENT] = T1.[BRUTOELEMENTIDELEMENT]) INNER JOIN  " + this.m_SubSelTopString54 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString7 + " ORDER BY T1.[IDRADNIK]";
                }
                else
                {
                    int num5 = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(num5 >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(num5 >= startRow, num5 - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    strArray = new string[7];
                    strArray[0] = "( SELECT TOP ";
                    strArray[1] = this.m_TopRowCount.ToString();
                    strArray[2] = " * FROM ( SELECT TOP ";
                    num10 = startRow + maxRows;
                    strArray[3] = num10.ToString();
                    strArray[4] = " TM1.[IDRADNIK] FROM [RADNIK] TM1";
                    strArray[5] = this.m_WhereString;
                    strArray[6] = " ORDER BY TM1.[IDRADNIK] ASC ) DK_A1  ORDER BY [IDRADNIK] DESC )";
                    this.m_SubSelTopString54 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT, T2.[NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, T1.[BRUTOSATNICA], T1.[BRUTOSATI], T1.[BRUTOPOSTOTAK], T1.[BRUTOIZNOS] FROM (([RADNIKBruto] T1 INNER JOIN [ELEMENT] T2 ON T2.[IDELEMENT] = T1.[BRUTOELEMENTIDELEMENT]) INNER JOIN  " + this.m_SubSelTopString54 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString7 + " ORDER BY T1.[IDRADNIK]";
                }
            }
            else
            {
                if (string.Compare(this.m_WhereString7.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                {
                    this.sWhereSep = "";
                }
                else
                {
                    this.sWhereSep = "";
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)
                    {
                        this.sWhereSep = " AND ";
                    }
                    else
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    this.m_WhereString7 = this.m_WhereString7.Substring(7);
                }
                this.m_SubSelTopString54 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT, T2.[NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, T1.[BRUTOSATNICA], T1.[BRUTOSATI], T1.[BRUTOPOSTOTAK], T1.[BRUTOIZNOS] FROM (([RADNIKBruto] T1 INNER JOIN [ELEMENT] T2 ON T2.[IDELEMENT] = T1.[BRUTOELEMENTIDELEMENT]) INNER JOIN  " + this.m_SubSelTopString54 + "  TM1 ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " " + this.sWhereSep + " " + this.m_WhereString7 + " ORDER BY T1.[IDRADNIK] ";
            }
            this.cmRADNIKBrutoSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKBrutoSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKBrutoSelect1 = this.cmRADNIKBrutoSelect1.FetchData();
            while (this.cmRADNIKBrutoSelect1.HasMoreRows)
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKBrutoSelect1, 0, ref this.m__IDRADNIKIsNull);
                this.m_BRUTOELEMENTIDELEMENT = this.dsDefault.Db.GetInt32(this.RADNIKBrutoSelect1, 1, ref this.m__BRUTOELEMENTIDELEMENTIsNull);
                this.m_BRUTOELEMENTNAZIVELEMENT = this.dsDefault.Db.GetString(this.RADNIKBrutoSelect1, 2, ref this.m__BRUTOELEMENTNAZIVELEMENTIsNull);
                this.m_BRUTOSATNICA = this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect1, 3, ref this.m__BRUTOSATNICAIsNull);
                this.m_BRUTOSATI = this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect1, 4, ref this.m__BRUTOSATIIsNull);
                this.m_BRUTOPOSTOTAK = this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect1, 5, ref this.m__BRUTOPOSTOTAKIsNull);
                this.m_BRUTOIZNOS = this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect1, 6, ref this.m__BRUTOIZNOSIsNull);
                this.m_BRUTOELEMENTNAZIVELEMENT = this.dsDefault.Db.GetString(this.RADNIKBrutoSelect1, 2, ref this.m__BRUTOELEMENTNAZIVELEMENTIsNull);
                this.rowRADNIKBruto = this.RadnikZaObracunSet.RADNIKBruto.NewRADNIKBrutoRow();
                this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BRUTOELEMENTIDELEMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BRUTOELEMENTIDELEMENT));
                this.rowRADNIKBruto["BRUTOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BRUTOELEMENTNAZIVELEMENTIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BRUTOELEMENTNAZIVELEMENT));
                this.rowRADNIKBruto["BRUTOSATNICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BRUTOSATNICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BRUTOSATNICA));
                this.rowRADNIKBruto["BRUTOSATI"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BRUTOSATIIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BRUTOSATI));
                this.rowRADNIKBruto["BRUTOPOSTOTAK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BRUTOPOSTOTAKIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BRUTOPOSTOTAK));
                this.rowRADNIKBruto["BRUTOIZNOS"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__BRUTOIZNOSIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_BRUTOIZNOS));
                this.rowRADNIKBruto.IDRADNIK = this.m_IDRADNIK;
                this.AddRowRadnikbruto();
                this.cmRADNIKBrutoSelect1.HasMoreRows = this.RADNIKBrutoSelect1.Read();
            }
            this.RADNIKBrutoSelect1.Close();
            this.m_WhereString6 = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_SubSelTopString59 = "( SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK] FROM [RADNIK] TM1" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ASC )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA, T1.[OBUSTAVAAKTIVNA], T2.[NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, T2.[VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE, T3.[NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE, T1.[ZADIZNOSOBUSTAVE], T1.[ZADPOSTOTAKOBUSTAVE], T1.[ZADISPLACENOKASA], T1.[ZADSALDOKASA], T1.[ZADPOSTOTNAODBRUTA] FROM ((([RADNIKObustava] T1 INNER JOIN [OBUSTAVA] T2 ON T2.[IDOBUSTAVA] = T1.[ZADOBUSTAVAIDOBUSTAVA]) LEFT JOIN [VRSTEOBUSTAVA] T3 ON T3.[VRSTAOBUSTAVE] = T2.[VRSTAOBUSTAVE]) INNER JOIN  " + this.m_SubSelTopString59 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString6 + " ORDER BY T1.[IDRADNIK]";
                }
                else
                {
                    int num6 = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(num6 >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(num6 >= startRow, num6 - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    strArray = new string[7];
                    strArray[0] = "( SELECT TOP ";
                    strArray[1] = this.m_TopRowCount.ToString();
                    strArray[2] = " * FROM ( SELECT TOP ";
                    num10 = startRow + maxRows;
                    strArray[3] = num10.ToString();
                    strArray[4] = " TM1.[IDRADNIK] FROM [RADNIK] TM1";
                    strArray[5] = this.m_WhereString;
                    strArray[6] = " ORDER BY TM1.[IDRADNIK] ASC ) DK_A1  ORDER BY [IDRADNIK] DESC )";
                    this.m_SubSelTopString59 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA, T1.[OBUSTAVAAKTIVNA], T2.[NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, T2.[VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE, T3.[NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE, T1.[ZADIZNOSOBUSTAVE], T1.[ZADPOSTOTAKOBUSTAVE], T1.[ZADISPLACENOKASA], T1.[ZADSALDOKASA], T1.[ZADPOSTOTNAODBRUTA] FROM ((([RADNIKObustava] T1 INNER JOIN [OBUSTAVA] T2 ON T2.[IDOBUSTAVA] = T1.[ZADOBUSTAVAIDOBUSTAVA]) LEFT JOIN [VRSTEOBUSTAVA] T3 ON T3.[VRSTAOBUSTAVE] = T2.[VRSTAOBUSTAVE]) INNER JOIN  " + this.m_SubSelTopString59 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString6 + " ORDER BY T1.[IDRADNIK]";
                }
            }
            else
            {
                if (string.Compare(this.m_WhereString6.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                {
                    this.sWhereSep = "";
                }
                else
                {
                    this.sWhereSep = "";
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)
                    {
                        this.sWhereSep = " AND ";
                    }
                    else
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    this.m_WhereString6 = this.m_WhereString6.Substring(7);
                }
                this.m_SubSelTopString59 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA, T1.[OBUSTAVAAKTIVNA], T2.[NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, T2.[VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE, T3.[NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE, T1.[ZADIZNOSOBUSTAVE], T1.[ZADPOSTOTAKOBUSTAVE], T1.[ZADISPLACENOKASA], T1.[ZADSALDOKASA], T1.[ZADPOSTOTNAODBRUTA] FROM ((([RADNIKObustava] T1 INNER JOIN [OBUSTAVA] T2 ON T2.[IDOBUSTAVA] = T1.[ZADOBUSTAVAIDOBUSTAVA]) LEFT JOIN [VRSTEOBUSTAVA] T3 ON T3.[VRSTAOBUSTAVE] = T2.[VRSTAOBUSTAVE]) INNER JOIN  " + this.m_SubSelTopString59 + "  TM1 ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " " + this.sWhereSep + " " + this.m_WhereString6 + " ORDER BY T1.[IDRADNIK] ";
            }
            this.cmRADNIKObustavaSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKObustavaSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKObustavaSelect1 = this.cmRADNIKObustavaSelect1.FetchData();
            while (this.cmRADNIKObustavaSelect1.HasMoreRows)
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKObustavaSelect1, 0, ref this.m__IDRADNIKIsNull);
                this.m_ZADOBUSTAVAIDOBUSTAVA = this.dsDefault.Db.GetInt32(this.RADNIKObustavaSelect1, 1, ref this.m__ZADOBUSTAVAIDOBUSTAVAIsNull);
                this.m_OBUSTAVAAKTIVNA = this.dsDefault.Db.GetBoolean(this.RADNIKObustavaSelect1, 2, ref this.m__OBUSTAVAAKTIVNAIsNull);
                this.m_ZADOBUSTAVANAZIVOBUSTAVA = this.dsDefault.Db.GetString(this.RADNIKObustavaSelect1, 3, ref this.m__ZADOBUSTAVANAZIVOBUSTAVAIsNull);
                this.m_ZADOBUSTAVAVRSTAOBUSTAVE = this.dsDefault.Db.GetInt16(this.RADNIKObustavaSelect1, 4, ref this.m__ZADOBUSTAVAVRSTAOBUSTAVEIsNull);
                this.m_ZADOBUSTAVANAZIVVRSTAOBUSTAVE = this.dsDefault.Db.GetString(this.RADNIKObustavaSelect1, 5, ref this.m__ZADOBUSTAVANAZIVVRSTAOBUSTAVEIsNull);
                this.m_ZADIZNOSOBUSTAVE = this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect1, 6, ref this.m__ZADIZNOSOBUSTAVEIsNull);
                this.m_ZADPOSTOTAKOBUSTAVE = this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect1, 7, ref this.m__ZADPOSTOTAKOBUSTAVEIsNull);
                this.m_ZADISPLACENOKASA = this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect1, 8, ref this.m__ZADISPLACENOKASAIsNull);
                this.m_ZADSALDOKASA = this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect1, 9, ref this.m__ZADSALDOKASAIsNull);
                this.m_ZADPOSTOTNAODBRUTA = this.dsDefault.Db.GetBoolean(this.RADNIKObustavaSelect1, 10, ref this.m__ZADPOSTOTNAODBRUTAIsNull);
                this.m_ZADOBUSTAVANAZIVOBUSTAVA = this.dsDefault.Db.GetString(this.RADNIKObustavaSelect1, 3, ref this.m__ZADOBUSTAVANAZIVOBUSTAVAIsNull);
                this.m_ZADOBUSTAVAVRSTAOBUSTAVE = this.dsDefault.Db.GetInt16(this.RADNIKObustavaSelect1, 4, ref this.m__ZADOBUSTAVAVRSTAOBUSTAVEIsNull);
                this.m_ZADOBUSTAVANAZIVVRSTAOBUSTAVE = this.dsDefault.Db.GetString(this.RADNIKObustavaSelect1, 5, ref this.m__ZADOBUSTAVANAZIVVRSTAOBUSTAVEIsNull);
                this.rowRADNIKObustava = this.RadnikZaObracunSet.RADNIKObustava.NewRADNIKObustavaRow();
                this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOBUSTAVAIDOBUSTAVAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOBUSTAVAIDOBUSTAVA));
                this.rowRADNIKObustava["OBUSTAVAAKTIVNA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OBUSTAVAAKTIVNAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OBUSTAVAAKTIVNA));
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOBUSTAVANAZIVOBUSTAVAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOBUSTAVANAZIVOBUSTAVA));
                this.rowRADNIKObustava["ZADOBUSTAVAVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOBUSTAVAVRSTAOBUSTAVEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOBUSTAVAVRSTAOBUSTAVE));
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOBUSTAVANAZIVVRSTAOBUSTAVEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOBUSTAVANAZIVVRSTAOBUSTAVE));
                this.rowRADNIKObustava["ZADIZNOSOBUSTAVE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADIZNOSOBUSTAVEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADIZNOSOBUSTAVE));
                this.rowRADNIKObustava["ZADPOSTOTAKOBUSTAVE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADPOSTOTAKOBUSTAVEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADPOSTOTAKOBUSTAVE));
                this.rowRADNIKObustava["ZADISPLACENOKASA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADISPLACENOKASAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADISPLACENOKASA));
                this.rowRADNIKObustava["ZADSALDOKASA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADSALDOKASAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADSALDOKASA));
                this.rowRADNIKObustava["ZADPOSTOTNAODBRUTA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADPOSTOTNAODBRUTAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADPOSTOTNAODBRUTA));
                this.rowRADNIKObustava.IDRADNIK = this.m_IDRADNIK;
                this.AddRowRadnikobustava();
                this.cmRADNIKObustavaSelect1.HasMoreRows = this.RADNIKObustavaSelect1.Read();
            }
            this.RADNIKObustavaSelect1.Close();
            this.m_WhereString5 = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_SubSelTopString75 = "( SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK] FROM [RADNIK] TM1" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ASC )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR, T1.[DATUMUGOVORA], T1.[KREDITAKTIVAN], T2.[NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, T2.[PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, T2.[PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, T2.[PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, T1.[SIFRAOPISAPLACANJAKREDITOR], T1.[OPISPLACANJAKREDITOR], T1.[MOKREDITOR], T1.[POKREDITOR], T1.[MZKREDITOR], T1.[PZKREDITOR], T1.[ZADIZNOSRATEKREDITA], T1.[ZADBROJRATAOBUSTAVE], T1.[ZADUKUPNIZNOSKREDITA], T1.[ZADVECOTPLACENOBROJRATA], T1.[ZADVECOTPLACENOUKUPNIIZNOS] FROM (([RADNIKKrediti] T1 INNER JOIN [KREDITOR] T2 ON T2.[IDKREDITOR] = T1.[ZADKREDITIIDKREDITOR]) INNER JOIN  " + this.m_SubSelTopString75 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString5 + " ORDER BY T1.[IDRADNIK]";
                }
                else
                {
                    int num7 = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(num7 >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(num7 >= startRow, num7 - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    strArray = new string[7];
                    strArray[0] = "( SELECT TOP ";
                    strArray[1] = this.m_TopRowCount.ToString();
                    strArray[2] = " * FROM ( SELECT TOP ";
                    num10 = startRow + maxRows;
                    strArray[3] = num10.ToString();
                    strArray[4] = " TM1.[IDRADNIK] FROM [RADNIK] TM1";
                    strArray[5] = this.m_WhereString;
                    strArray[6] = " ORDER BY TM1.[IDRADNIK] ASC ) DK_A1  ORDER BY [IDRADNIK] DESC )";
                    this.m_SubSelTopString75 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR, T1.[DATUMUGOVORA], T1.[KREDITAKTIVAN], T2.[NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, T2.[PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, T2.[PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, T2.[PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, T1.[SIFRAOPISAPLACANJAKREDITOR], T1.[OPISPLACANJAKREDITOR], T1.[MOKREDITOR], T1.[POKREDITOR], T1.[MZKREDITOR], T1.[PZKREDITOR], T1.[ZADIZNOSRATEKREDITA], T1.[ZADBROJRATAOBUSTAVE], T1.[ZADUKUPNIZNOSKREDITA], T1.[ZADVECOTPLACENOBROJRATA], T1.[ZADVECOTPLACENOUKUPNIIZNOS] FROM (([RADNIKKrediti] T1 INNER JOIN [KREDITOR] T2 ON T2.[IDKREDITOR] = T1.[ZADKREDITIIDKREDITOR]) INNER JOIN  " + this.m_SubSelTopString75 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString5 + " ORDER BY T1.[IDRADNIK]";
                }
            }
            else
            {
                if (string.Compare(this.m_WhereString5.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                {
                    this.sWhereSep = "";
                }
                else
                {
                    this.sWhereSep = "";
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)
                    {
                        this.sWhereSep = " AND ";
                    }
                    else
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    this.m_WhereString5 = this.m_WhereString5.Substring(7);
                }
                this.m_SubSelTopString75 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR, T1.[DATUMUGOVORA], T1.[KREDITAKTIVAN], T2.[NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, T2.[PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, T2.[PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, T2.[PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, T1.[SIFRAOPISAPLACANJAKREDITOR], T1.[OPISPLACANJAKREDITOR], T1.[MOKREDITOR], T1.[POKREDITOR], T1.[MZKREDITOR], T1.[PZKREDITOR], T1.[ZADIZNOSRATEKREDITA], T1.[ZADBROJRATAOBUSTAVE], T1.[ZADUKUPNIZNOSKREDITA], T1.[ZADVECOTPLACENOBROJRATA], T1.[ZADVECOTPLACENOUKUPNIIZNOS] FROM (([RADNIKKrediti] T1 INNER JOIN [KREDITOR] T2 ON T2.[IDKREDITOR] = T1.[ZADKREDITIIDKREDITOR]) INNER JOIN  " + this.m_SubSelTopString75 + "  TM1 ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " " + this.sWhereSep + " " + this.m_WhereString5 + " ORDER BY T1.[IDRADNIK] ";
            }
            this.cmRADNIKKreditiSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKKreditiSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKKreditiSelect1 = this.cmRADNIKKreditiSelect1.FetchData();
            while (this.cmRADNIKKreditiSelect1.HasMoreRows)
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKKreditiSelect1, 0, ref this.m__IDRADNIKIsNull);
                this.m_ZADKREDITIIDKREDITOR = this.dsDefault.Db.GetInt32(this.RADNIKKreditiSelect1, 1, ref this.m__ZADKREDITIIDKREDITORIsNull);
                this.m_DATUMUGOVORA = this.dsDefault.Db.GetDateTime(this.RADNIKKreditiSelect1, 2, ref this.m__DATUMUGOVORAIsNull);
                this.m_KREDITAKTIVAN = this.dsDefault.Db.GetBoolean(this.RADNIKKreditiSelect1, 3, ref this.m__KREDITAKTIVANIsNull);
                this.m_ZADKREDITINAZIVKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 4, ref this.m__ZADKREDITINAZIVKREDITORIsNull);
                this.m_ZADKREDITIPRIMATELJKREDITOR1 = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 5, ref this.m__ZADKREDITIPRIMATELJKREDITOR1IsNull);
                this.m_ZADKREDITIPRIMATELJKREDITOR2 = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 6, ref this.m__ZADKREDITIPRIMATELJKREDITOR2IsNull);
                this.m_ZADKREDITIPRIMATELJKREDITOR3 = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 7, ref this.m__ZADKREDITIPRIMATELJKREDITOR3IsNull);
                this.m_SIFRAOPISAPLACANJAKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 8, ref this.m__SIFRAOPISAPLACANJAKREDITORIsNull);
                this.m_OPISPLACANJAKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 9, ref this.m__OPISPLACANJAKREDITORIsNull);
                this.m_MOKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 10, ref this.m__MOKREDITORIsNull);
                this.m_POKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 11, ref this.m__POKREDITORIsNull);
                this.m_MZKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 12, ref this.m__MZKREDITORIsNull);
                this.m_PZKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 13, ref this.m__PZKREDITORIsNull);
                this.m_ZADIZNOSRATEKREDITA = this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect1, 14, ref this.m__ZADIZNOSRATEKREDITAIsNull);
                this.m_ZADBROJRATAOBUSTAVE = this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect1, 15, ref this.m__ZADBROJRATAOBUSTAVEIsNull);
                this.m_ZADUKUPNIZNOSKREDITA = this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect1, 0x10, ref this.m__ZADUKUPNIZNOSKREDITAIsNull);
                this.m_ZADVECOTPLACENOBROJRATA = this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect1, 0x11, ref this.m__ZADVECOTPLACENOBROJRATAIsNull);
                this.m_ZADVECOTPLACENOUKUPNIIZNOS = this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect1, 0x12, ref this.m__ZADVECOTPLACENOUKUPNIIZNOSIsNull);
                this.m_ZADKREDITINAZIVKREDITOR = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 4, ref this.m__ZADKREDITINAZIVKREDITORIsNull);
                this.m_ZADKREDITIPRIMATELJKREDITOR1 = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 5, ref this.m__ZADKREDITIPRIMATELJKREDITOR1IsNull);
                this.m_ZADKREDITIPRIMATELJKREDITOR2 = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 6, ref this.m__ZADKREDITIPRIMATELJKREDITOR2IsNull);
                this.m_ZADKREDITIPRIMATELJKREDITOR3 = this.dsDefault.Db.GetString(this.RADNIKKreditiSelect1, 7, ref this.m__ZADKREDITIPRIMATELJKREDITOR3IsNull);
                this.rowRADNIKKrediti = this.RadnikZaObracunSet.RADNIKKrediti.NewRADNIKKreditiRow();
                this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADKREDITIIDKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADKREDITIIDKREDITOR));
                this.rowRADNIKKrediti["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__DATUMUGOVORAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_DATUMUGOVORA));
                this.rowRADNIKKrediti["KREDITAKTIVAN"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__KREDITAKTIVANIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_KREDITAKTIVAN));
                this.rowRADNIKKrediti["ZADKREDITINAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADKREDITINAZIVKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADKREDITINAZIVKREDITOR));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADKREDITIPRIMATELJKREDITOR1IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADKREDITIPRIMATELJKREDITOR1));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADKREDITIPRIMATELJKREDITOR2IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADKREDITIPRIMATELJKREDITOR2));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADKREDITIPRIMATELJKREDITOR3IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADKREDITIPRIMATELJKREDITOR3));
                this.rowRADNIKKrediti["SIFRAOPISAPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__SIFRAOPISAPLACANJAKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_SIFRAOPISAPLACANJAKREDITOR));
                this.rowRADNIKKrediti["OPISPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OPISPLACANJAKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OPISPLACANJAKREDITOR));
                this.rowRADNIKKrediti["MOKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MOKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MOKREDITOR));
                this.rowRADNIKKrediti["POKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__POKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_POKREDITOR));
                this.rowRADNIKKrediti["MZKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__MZKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_MZKREDITOR));
                this.rowRADNIKKrediti["PZKREDITOR"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__PZKREDITORIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_PZKREDITOR));
                this.rowRADNIKKrediti["ZADIZNOSRATEKREDITA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADIZNOSRATEKREDITAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADIZNOSRATEKREDITA));
                this.rowRADNIKKrediti["ZADBROJRATAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADBROJRATAOBUSTAVEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADBROJRATAOBUSTAVE));
                this.rowRADNIKKrediti["ZADUKUPNIZNOSKREDITA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADUKUPNIZNOSKREDITAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADUKUPNIZNOSKREDITA));
                this.rowRADNIKKrediti["ZADVECOTPLACENOBROJRATA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADVECOTPLACENOBROJRATAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADVECOTPLACENOBROJRATA));
                this.rowRADNIKKrediti["ZADVECOTPLACENOUKUPNIIZNOS"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADVECOTPLACENOUKUPNIIZNOSIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADVECOTPLACENOUKUPNIIZNOS));
                this.rowRADNIKKrediti.IDRADNIK = this.m_IDRADNIK;
                this.AddRowRadnikkrediti();
                this.cmRADNIKKreditiSelect1.HasMoreRows = this.RADNIKKreditiSelect1.Read();
            }
            this.RADNIKKreditiSelect1.Close();
            this.m_WhereString4 = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_SubSelTopString23 = "( SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK] FROM [RADNIK] TM1" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ASC )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE, T2.[IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, T4.[MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, T4.[NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA, T2.[NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, T2.[IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE, T3.[NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE, T2.[VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, T2.[ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, T2.[PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, T2.[PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, T2.[PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, T1.[ZADMZOLAKSICE], T1.[ZADPZOLAKSICE], T1.[ZADMOOLAKSICE], T1.[ZADPOOLAKSICE], T1.[ZADSIFRAOPISAPLACANJAOLAKSICE], T1.[ZADOPISPLACANJAOLAKSICE], T1.[ZADIZNOSOLAKSICE] FROM (((([RADNIKOlaksica] T1 INNER JOIN [OLAKSICE] T2 ON T2.[IDOLAKSICE] = T1.[ZADOLAKSICEIDOLAKSICE]) LEFT JOIN [TIPOLAKSICE] T3 ON T3.[IDTIPOLAKSICE] = T2.[IDTIPOLAKSICE]) LEFT JOIN [GRUPEOLAKSICA] T4 ON T4.[IDGRUPEOLAKSICA] = T2.[IDGRUPEOLAKSICA]) INNER JOIN  " + this.m_SubSelTopString23 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString4 + " ORDER BY T1.[IDRADNIK]";
                }
                else
                {
                    int num8 = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(num8 >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(num8 >= startRow, num8 - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    strArray = new string[7];
                    strArray[0] = "( SELECT TOP ";
                    strArray[1] = this.m_TopRowCount.ToString();
                    strArray[2] = " * FROM ( SELECT TOP ";
                    num10 = startRow + maxRows;
                    strArray[3] = num10.ToString();
                    strArray[4] = " TM1.[IDRADNIK] FROM [RADNIK] TM1";
                    strArray[5] = this.m_WhereString;
                    strArray[6] = " ORDER BY TM1.[IDRADNIK] ASC ) DK_A1  ORDER BY [IDRADNIK] DESC )";
                    this.m_SubSelTopString23 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE, T2.[IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, T4.[MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, T4.[NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA, T2.[NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, T2.[IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE, T3.[NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE, T2.[VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, T2.[ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, T2.[PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, T2.[PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, T2.[PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, T1.[ZADMZOLAKSICE], T1.[ZADPZOLAKSICE], T1.[ZADMOOLAKSICE], T1.[ZADPOOLAKSICE], T1.[ZADSIFRAOPISAPLACANJAOLAKSICE], T1.[ZADOPISPLACANJAOLAKSICE], T1.[ZADIZNOSOLAKSICE] FROM (((([RADNIKOlaksica] T1 INNER JOIN [OLAKSICE] T2 ON T2.[IDOLAKSICE] = T1.[ZADOLAKSICEIDOLAKSICE]) LEFT JOIN [TIPOLAKSICE] T3 ON T3.[IDTIPOLAKSICE] = T2.[IDTIPOLAKSICE]) LEFT JOIN [GRUPEOLAKSICA] T4 ON T4.[IDGRUPEOLAKSICA] = T2.[IDGRUPEOLAKSICA]) INNER JOIN  " + this.m_SubSelTopString23 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString4 + " ORDER BY T1.[IDRADNIK]";
                }
            }
            else
            {
                if (string.Compare(this.m_WhereString4.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                {
                    this.sWhereSep = "";
                }
                else
                {
                    this.sWhereSep = "";
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)
                    {
                        this.sWhereSep = " AND ";
                    }
                    else
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    this.m_WhereString4 = this.m_WhereString4.Substring(7);
                }
                this.m_SubSelTopString23 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE, T2.[IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, T4.[MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, T4.[NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA, T2.[NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, T2.[IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE, T3.[NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE, T2.[VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, T2.[ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, T2.[PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, T2.[PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, T2.[PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, T1.[ZADMZOLAKSICE], T1.[ZADPZOLAKSICE], T1.[ZADMOOLAKSICE], T1.[ZADPOOLAKSICE], T1.[ZADSIFRAOPISAPLACANJAOLAKSICE], T1.[ZADOPISPLACANJAOLAKSICE], T1.[ZADIZNOSOLAKSICE] FROM (((([RADNIKOlaksica] T1 INNER JOIN [OLAKSICE] T2 ON T2.[IDOLAKSICE] = T1.[ZADOLAKSICEIDOLAKSICE]) LEFT JOIN [TIPOLAKSICE] T3 ON T3.[IDTIPOLAKSICE] = T2.[IDTIPOLAKSICE]) LEFT JOIN [GRUPEOLAKSICA] T4 ON T4.[IDGRUPEOLAKSICA] = T2.[IDGRUPEOLAKSICA]) INNER JOIN  " + this.m_SubSelTopString23 + "  TM1 ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " " + this.sWhereSep + " " + this.m_WhereString4 + " ORDER BY T1.[IDRADNIK] ";
            }
            this.cmRADNIKOlaksicaSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKOlaksicaSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKOlaksicaSelect1 = this.cmRADNIKOlaksicaSelect1.FetchData();
            while (this.cmRADNIKOlaksicaSelect1.HasMoreRows)
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect1, 0, ref this.m__IDRADNIKIsNull);
                this.m_ZADOLAKSICEIDOLAKSICE = this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect1, 1, ref this.m__ZADOLAKSICEIDOLAKSICEIsNull);
                this.m_ZADOLAKSICEIDGRUPEOLAKSICA = this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect1, 2, ref this.m__ZADOLAKSICEIDGRUPEOLAKSICAIsNull);
                this.m_ZADOLAKSICEMAXIMALNIIZNOSGRUPE = this.dsDefault.Db.GetDecimal(this.RADNIKOlaksicaSelect1, 3, ref this.m__ZADOLAKSICEMAXIMALNIIZNOSGRUPEIsNull);
                this.m_ZADOLAKSICENAZIVGRUPEOLAKSICA = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 4, ref this.m__ZADOLAKSICENAZIVGRUPEOLAKSICAIsNull);
                this.m_ZADOLAKSICENAZIVOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 5, ref this.m__ZADOLAKSICENAZIVOLAKSICEIsNull);
                this.m_ZADOLAKSICEIDTIPOLAKSICE = this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect1, 6, ref this.m__ZADOLAKSICEIDTIPOLAKSICEIsNull);
                this.m_ZADOLAKSICENAZIVTIPOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 7, ref this.m__ZADOLAKSICENAZIVTIPOLAKSICEIsNull);
                this.m_ZADOLAKSICEVBDIOLAKSICA = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 8, ref this.m__ZADOLAKSICEVBDIOLAKSICAIsNull);
                this.m_ZADOLAKSICEZRNOLAKSICA = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 9, ref this.m__ZADOLAKSICEZRNOLAKSICAIsNull);
                this.m_ZADOLAKSICEPRIMATELJOLAKSICA1 = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 10, ref this.m__ZADOLAKSICEPRIMATELJOLAKSICA1IsNull);
                this.m_ZADOLAKSICEPRIMATELJOLAKSICA2 = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 11, ref this.m__ZADOLAKSICEPRIMATELJOLAKSICA2IsNull);
                this.m_ZADOLAKSICEPRIMATELJOLAKSICA3 = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 12, ref this.m__ZADOLAKSICEPRIMATELJOLAKSICA3IsNull);
                this.m_ZADMZOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 13, ref this.m__ZADMZOLAKSICEIsNull);
                this.m_ZADPZOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 14, ref this.m__ZADPZOLAKSICEIsNull);
                this.m_ZADMOOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 15, ref this.m__ZADMOOLAKSICEIsNull);
                this.m_ZADPOOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 0x10, ref this.m__ZADPOOLAKSICEIsNull);
                this.m_ZADSIFRAOPISAPLACANJAOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 0x11, ref this.m__ZADSIFRAOPISAPLACANJAOLAKSICEIsNull);
                this.m_ZADOPISPLACANJAOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 0x12, ref this.m__ZADOPISPLACANJAOLAKSICEIsNull);
                this.m_ZADIZNOSOLAKSICE = this.dsDefault.Db.GetDecimal(this.RADNIKOlaksicaSelect1, 0x13, ref this.m__ZADIZNOSOLAKSICEIsNull);
                this.m_ZADOLAKSICEIDGRUPEOLAKSICA = this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect1, 2, ref this.m__ZADOLAKSICEIDGRUPEOLAKSICAIsNull);
                this.m_ZADOLAKSICENAZIVOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 5, ref this.m__ZADOLAKSICENAZIVOLAKSICEIsNull);
                this.m_ZADOLAKSICEIDTIPOLAKSICE = this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect1, 6, ref this.m__ZADOLAKSICEIDTIPOLAKSICEIsNull);
                this.m_ZADOLAKSICEVBDIOLAKSICA = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 8, ref this.m__ZADOLAKSICEVBDIOLAKSICAIsNull);
                this.m_ZADOLAKSICEZRNOLAKSICA = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 9, ref this.m__ZADOLAKSICEZRNOLAKSICAIsNull);
                this.m_ZADOLAKSICEPRIMATELJOLAKSICA1 = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 10, ref this.m__ZADOLAKSICEPRIMATELJOLAKSICA1IsNull);
                this.m_ZADOLAKSICEPRIMATELJOLAKSICA2 = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 11, ref this.m__ZADOLAKSICEPRIMATELJOLAKSICA2IsNull);
                this.m_ZADOLAKSICEPRIMATELJOLAKSICA3 = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 12, ref this.m__ZADOLAKSICEPRIMATELJOLAKSICA3IsNull);
                this.m_ZADOLAKSICENAZIVTIPOLAKSICE = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 7, ref this.m__ZADOLAKSICENAZIVTIPOLAKSICEIsNull);
                this.m_ZADOLAKSICEMAXIMALNIIZNOSGRUPE = this.dsDefault.Db.GetDecimal(this.RADNIKOlaksicaSelect1, 3, ref this.m__ZADOLAKSICEMAXIMALNIIZNOSGRUPEIsNull);
                this.m_ZADOLAKSICENAZIVGRUPEOLAKSICA = this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect1, 4, ref this.m__ZADOLAKSICENAZIVGRUPEOLAKSICAIsNull);
                this.rowRADNIKOlaksica = this.RadnikZaObracunSet.RADNIKOlaksica.NewRADNIKOlaksicaRow();
                this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEIDOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEIDOLAKSICE));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEIDGRUPEOLAKSICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEIDGRUPEOLAKSICA));
                this.rowRADNIKOlaksica["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEMAXIMALNIIZNOSGRUPEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEMAXIMALNIIZNOSGRUPE));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICENAZIVGRUPEOLAKSICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICENAZIVGRUPEOLAKSICA));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICENAZIVOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICENAZIVOLAKSICE));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEIDTIPOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEIDTIPOLAKSICE));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICENAZIVTIPOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICENAZIVTIPOLAKSICE));
                this.rowRADNIKOlaksica["ZADOLAKSICEVBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEVBDIOLAKSICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEVBDIOLAKSICA));
                this.rowRADNIKOlaksica["ZADOLAKSICEZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEZRNOLAKSICAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEZRNOLAKSICA));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEPRIMATELJOLAKSICA1IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEPRIMATELJOLAKSICA1));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEPRIMATELJOLAKSICA2IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEPRIMATELJOLAKSICA2));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOLAKSICEPRIMATELJOLAKSICA3IsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOLAKSICEPRIMATELJOLAKSICA3));
                this.rowRADNIKOlaksica["ZADMZOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADMZOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADMZOLAKSICE));
                this.rowRADNIKOlaksica["ZADPZOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADPZOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADPZOLAKSICE));
                this.rowRADNIKOlaksica["ZADMOOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADMOOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADMOOLAKSICE));
                this.rowRADNIKOlaksica["ZADPOOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADPOOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADPOOLAKSICE));
                this.rowRADNIKOlaksica["ZADSIFRAOPISAPLACANJAOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADSIFRAOPISAPLACANJAOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADSIFRAOPISAPLACANJAOLAKSICE));
                this.rowRADNIKOlaksica["ZADOPISPLACANJAOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADOPISPLACANJAOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADOPISPLACANJAOLAKSICE));
                this.rowRADNIKOlaksica["ZADIZNOSOLAKSICE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__ZADIZNOSOLAKSICEIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_ZADIZNOSOLAKSICE));
                this.rowRADNIKOlaksica.IDRADNIK = this.m_IDRADNIK;
                this.AddRowRadnikolaksica();
                this.cmRADNIKOlaksicaSelect1.HasMoreRows = this.RADNIKOlaksicaSelect1.Read();
            }
            this.RADNIKOlaksicaSelect1.Close();
            this.m_WhereString3 = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_SubSelTopString22 = "( SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK] FROM [RADNIK] TM1" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ASC )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, T2.[NAZIVOSOBNIODBITAK], T2.[FAKTOROSOBNOGODBITKA] FROM (([RADNIKOdbitak] T1 INNER JOIN [OSOBNIODBITAK] T2 ON T2.[IDOSOBNIODBITAK] = T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]) INNER JOIN  " + this.m_SubSelTopString22 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString3 + " ORDER BY T1.[IDRADNIK]";
                }
                else
                {
                    int num9 = this.GetInternalRecordCount();
                    this.m_TopRowCount = Conversions.ToInteger(Interaction.IIf(num9 >= (startRow + maxRows), maxRows, RuntimeHelpers.GetObjectValue(Interaction.IIf(num9 >= startRow, num9 - startRow, 0))));
                    if (this.m_TopRowCount == 0)
                    {
                        return;
                    }
                    strArray = new string[] { "( SELECT TOP ", this.m_TopRowCount.ToString(), " * FROM ( SELECT TOP ", (startRow + maxRows).ToString(), " TM1.[IDRADNIK] FROM [RADNIK] TM1", this.m_WhereString, " ORDER BY TM1.[IDRADNIK] ASC ) DK_A1  ORDER BY [IDRADNIK] DESC )" };
                    this.m_SubSelTopString22 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, T2.[NAZIVOSOBNIODBITAK], T2.[FAKTOROSOBNOGODBITKA] FROM (([RADNIKOdbitak] T1 INNER JOIN [OSOBNIODBITAK] T2 ON T2.[IDOSOBNIODBITAK] = T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]) INNER JOIN  " + this.m_SubSelTopString22 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString3 + " ORDER BY T1.[IDRADNIK]";
                }
            }
            else
            {
                if (string.Compare(this.m_WhereString3.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0)
                {
                    this.sWhereSep = "";
                }
                else
                {
                    this.sWhereSep = "";
                    if (string.Compare(this.m_WhereString.TrimEnd(new char[] { ' ' }), "".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)
                    {
                        this.sWhereSep = " AND ";
                    }
                    else
                    {
                        this.sWhereSep = " WHERE ";
                    }
                    this.m_WhereString3 = this.m_WhereString3.Substring(7);
                }
                this.m_SubSelTopString22 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, T2.[NAZIVOSOBNIODBITAK], T2.[FAKTOROSOBNOGODBITKA] FROM (([RADNIKOdbitak] T1 INNER JOIN [OSOBNIODBITAK] T2 ON T2.[IDOSOBNIODBITAK] = T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]) INNER JOIN  " + this.m_SubSelTopString22 + "  TM1 ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " " + this.sWhereSep + " " + this.m_WhereString3 + " ORDER BY T1.[IDRADNIK] ";
            }
            this.cmRADNIKOdbitakSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKOdbitakSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKOdbitakSelect1 = this.cmRADNIKOdbitakSelect1.FetchData();
            while (this.cmRADNIKOdbitakSelect1.HasMoreRows)
            {
                this.m_IDRADNIK = this.dsDefault.Db.GetInt32(this.RADNIKOdbitakSelect1, 0, ref this.m__IDRADNIKIsNull);
                this.m_OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = this.dsDefault.Db.GetInt32(this.RADNIKOdbitakSelect1, 1, ref this.m__OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKIsNull);
                this.m_NAZIVOSOBNIODBITAK = this.dsDefault.Db.GetStringNE(this.RADNIKOdbitakSelect1, 2, ref this.m__NAZIVOSOBNIODBITAKIsNull);
                this.m_FAKTOROSOBNOGODBITKA = this.dsDefault.Db.GetDecimal(this.RADNIKOdbitakSelect1, 3, ref this.m__FAKTOROSOBNOGODBITKAIsNull);
                this.m_NAZIVOSOBNIODBITAK = this.dsDefault.Db.GetStringNE(this.RADNIKOdbitakSelect1, 2, ref this.m__NAZIVOSOBNIODBITAKIsNull);
                this.m_FAKTOROSOBNOGODBITKA = this.dsDefault.Db.GetDecimal(this.RADNIKOdbitakSelect1, 3, ref this.m__FAKTOROSOBNOGODBITKAIsNull);
                this.rowRADNIKOdbitak = this.RadnikZaObracunSet.RADNIKOdbitak.NewRADNIKOdbitakRow();
                this.rowRADNIKOdbitak["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK));
                this.rowRADNIKOdbitak["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__NAZIVOSOBNIODBITAKIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_NAZIVOSOBNIODBITAK));
                this.rowRADNIKOdbitak["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(this.m__FAKTOROSOBNOGODBITKAIsNull, RuntimeHelpers.GetObjectValue(Convert.DBNull), this.m_FAKTOROSOBNOGODBITKA));
                this.rowRADNIKOdbitak.IDRADNIK = this.m_IDRADNIK;
                this.AddRowRadnikodbitak();
                this.cmRADNIKOdbitakSelect1.HasMoreRows = this.RADNIKOdbitakSelect1.Read();
            }
            this.RADNIKOdbitakSelect1.Close();
            this.Cleanup();
        }

        public virtual int Fill(RADNIKDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RadnikZaObracunSet = dataSet;
            this.rowRADNIK = this.RadnikZaObracunSet.RADNIK.NewRADNIKRow();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
            try
            {
                this.executePrivate(0, -1);
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.RadnikZaObracunSet = (RADNIKDataSet) dataSet;
            if (this.RadnikZaObracunSet != null)
            {
                return this.Fill(this.RadnikZaObracunSet);
            }
            this.RadnikZaObracunSet = new RADNIKDataSet();
            this.Fill(this.RadnikZaObracunSet);
            dataSet.Merge(this.RadnikZaObracunSet);
            return 0;
        }

        public virtual int FillPage(RADNIKDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RadnikZaObracunSet = dataSet;
            this.rowRADNIK = this.RadnikZaObracunSet.RADNIK.NewRADNIKRow();
            this.orderString = GetOrderString(this.Order, true);
            this.reverseOrderString = GetOrderString(this.Order, false);
            try
            {
                this.executePrivate(startRow, maxRows);
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.RadnikZaObracunSet = (RADNIKDataSet) dataSet;
            if (this.RadnikZaObracunSet != null)
            {
                return this.FillPage(this.RadnikZaObracunSet, startRow, maxRows);
            }
            this.RadnikZaObracunSet = new RADNIKDataSet();
            this.FillPage(this.RadnikZaObracunSet, startRow, maxRows);
            dataSet.Merge(this.RadnikZaObracunSet);
            return 0;
        }

        public virtual DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            DataTable[] array = new DataTable[dataSet.Tables.Count + 1];
            dataSet.Tables.CopyTo(array, dataSet.Tables.Count);
            return array;
        }

        public static string GetAttributeName(Attribute attribute)
        {
            return attributeNames[(int) attribute];
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                this.fillDataParameters = new DbParameter[0];
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            string str = "";
            this.scmdbuf = "SELECT COUNT(*) FROM (((((((((((((([RADNIK] T1 INNER JOIN [IPIDENT] T2 ON T2.[IDIPIDENT] = T1.[IDIPIDENT]) INNER JOIN [SPOL] T3 ON T3.[IDSPOL] = T1.[IDSPOL]) LEFT JOIN [ORGDIO] T4 ON T4.[IDORGDIO] = T1.[IDORGDIO]) LEFT JOIN [BRACNOSTANJE] T5 ON T5.[IDBRACNOSTANJE] = T1.[IDBRACNOSTANJE]) LEFT JOIN [STRUKA] T6 ON T6.[IDSTRUKA] = T1.[IDSTRUKA]) LEFT JOIN [STRUCNASPREMA] T7 ON T7.[IDSTRUCNASPREMA] = T1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T8 ON T8.[IDSTRUCNASPREMA] = T1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [RADNOMJESTO] T9 ON T9.[IDRADNOMJESTO] = T1.[IDRADNOMJESTO]) LEFT JOIN [TITULA] T10 ON T10.[IDTITULA] = T1.[IDTITULA]) INNER JOIN [BENEFICIRANI] T11 ON T11.[IDBENEFICIRANI] = T1.[IDBENEFICIRANI]) INNER JOIN [BANKE] T12 ON T12.[IDBANKE] = T1.[IDBANKE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T13 ON T13.[IDSKUPPOREZAIDOPRINOSA] = T1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [OPCINA] T14 ON T14.[IDOPCINE] = T1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [OPCINA] T15 ON T15.[IDOPCINE] = T1.[OPCINARADAIDOPCINE])" + str + "  ";
            this.cmRADNIKSelect1 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.cmRADNIKSelect1.ErrorMask |= ErrorMask.Lock;
            this.RADNIKSelect1 = this.cmRADNIKSelect1.FetchData();
            if (this.RADNIKSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.RADNIKSelect1.GetInt32(0);
            }
            this.RADNIKSelect1.Close();
            return this.m_RecordCount;
        }

        public static string GetOrderString(ArrayList ListOrder, bool AscendingOrder)
        {
            IEnumerator enumerator = null;
            string str2 = "";
            string str3 = "";
            if (ListOrder.Count > 0)
            {
                str3 = " ORDER BY ";
            }
            try
            {
                enumerator = ListOrder.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    OrderAttribute current = (OrderAttribute) enumerator.Current;
                    if (current.OrderAttributeAscending == AscendingOrder)
                    {
                        str2 = str2 + str3 + " " + current.OrderAttributeString;
                    }
                    else
                    {
                        str2 = str2 + str3 + " " + current.OrderAttributeString + " DESC";
                    }
                    str3 = ", ";
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            return str2;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        private void Init_order_Radnik()
        {
            this.Order = new ArrayList();
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.scmdbuf = "";
            this.m_WhereString = "";
            this.m_RecordCount = 0;
            this.sWhereSep = "";
            this.m_TopRowCount = 0;
            this.m__IDRADNIKIsNull = false;
            this.m_IDRADNIK = 0;
            this.m__AKTIVANIsNull = false;
            this.m_AKTIVAN = false;
            this.m__PREZIMEIsNull = false;
            this.m_PREZIME = "";
            this.m__IMEIsNull = false;
            this.m_IME = "";
            this.m__JMBGIsNull = false;
            this.m_JMBG = "";
            this.m__DATUMRODJENJAIsNull = false;
            this.m_DATUMRODJENJA = DateTime.MinValue;
            this.m__ulicaIsNull = false;
            this.m_ulica = "";
            this.m__mjestoIsNull = false;
            this.m_mjesto = "";
            this.m__kucnibrojIsNull = false;
            this.m_kucnibroj = "";
            this.m__OPCINARADAIDOPCINEIsNull = false;
            this.m_OPCINARADAIDOPCINE = "";
            this.m__OPCINARADANAZIVOPCINEIsNull = false;
            this.m_OPCINARADANAZIVOPCINE = "";
            this.m__OPCINASTANOVANJAIDOPCINEIsNull = false;
            this.m_OPCINASTANOVANJAIDOPCINE = "";
            this.m__OPCINASTANOVANJANAZIVOPCINEIsNull = false;
            this.m_OPCINASTANOVANJANAZIVOPCINE = "";
            this.m__OPCINASTANOVANJAPRIREZIsNull = false;
            this.m_OPCINASTANOVANJAPRIREZ = new decimal();
            this.m__OPCINASTANOVANJAVBDIOPCINAIsNull = false;
            this.m_OPCINASTANOVANJAVBDIOPCINA = "";
            this.m__OPCINASTANOVANJAZRNOPCINAIsNull = false;
            this.m_OPCINASTANOVANJAZRNOPCINA = "";
            this.m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAIsNull = false;
            this.m_RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = 0;
            this.m__RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAIsNull = false;
            this.m_RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA = "";
            this.m__IDBANKEIsNull = false;
            this.m_IDBANKE = 0;
            this.m__NAZIVBANKE1IsNull = false;
            this.m_NAZIVBANKE1 = "";
            this.m__NAZIVBANKE2IsNull = false;
            this.m_NAZIVBANKE2 = "";
            this.m__NAZIVBANKE3IsNull = false;
            this.m_NAZIVBANKE3 = "";
            this.m__VBDIBANKEIsNull = false;
            this.m_VBDIBANKE = "";
            this.m__ZRNBANKEIsNull = false;
            this.m_ZRNBANKE = "";
            this.m__TEKUCIIsNull = false;
            this.m_TEKUCI = "";
            this.m__ZBIRNINETOIsNull = false;
            this.m_ZBIRNINETO = false;
            this.m__SIFRAOPISAPLACANJANETOIsNull = false;
            this.m_SIFRAOPISAPLACANJANETO = "";
            this.m__OPISPLACANJANETOIsNull = false;
            this.m_OPISPLACANJANETO = "";
            this.m__TJEDNIFONDSATIIsNull = false;
            this.m_TJEDNIFONDSATI = new decimal();
            this.m__KOEFICIJENTIsNull = false;
            this.m_KOEFICIJENT = new decimal();
            this.m__POSTOTAKOSLOBODJENJAODPOREZAIsNull = false;
            this.m_POSTOTAKOSLOBODJENJAODPOREZA = new decimal();
            this.m__UZIMAUOBZIROSNOVICEDOPRINOSAIsNull = false;
            this.m_UZIMAUOBZIROSNOVICEDOPRINOSA = false;
            this.m__TJEDNIFONDSATISTAZIsNull = false;
            this.m_TJEDNIFONDSATISTAZ = new decimal();
            this.m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIIsNull = false;
            this.m_DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = DateTime.MinValue;
            this.m__GODINESTAZAIsNull = false;
            this.m_GODINESTAZA = 0;
            this.m__MJESECISTAZAIsNull = false;
            this.m_MJESECISTAZA = 0;
            this.m__DANISTAZAIsNull = false;
            this.m_DANISTAZA = 0;
            this.m__IDBENEFICIRANIIsNull = false;
            this.m_IDBENEFICIRANI = "";
            this.m__NAZIVBENEFICIRANIIsNull = false;
            this.m_NAZIVBENEFICIRANI = "";
            this.m__DATUMPRESTANKARADNOGODNOSAIsNull = false;
            this.m_DATUMPRESTANKARADNOGODNOSA = DateTime.MinValue;
            this.m__BROJMIROVINSKOGIsNull = false;
            this.m_BROJMIROVINSKOG = "";
            this.m__BROJZDRAVSTVENOGIsNull = false;
            this.m_BROJZDRAVSTVENOG = "";
            this.m__MBOIsNull = false;
            this.m_MBO = "";
            this.m__IDTITULAIsNull = false;
            this.m_IDTITULA = 0;
            this.m__NAZIVTITULAIsNull = false;
            this.m_NAZIVTITULA = "";
            this.m__IDRADNOMJESTOIsNull = false;
            this.m_IDRADNOMJESTO = 0;
            this.m__NAZIVRADNOMJESTOIsNull = false;
            this.m_NAZIVRADNOMJESTO = "";
            this.m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAIsNull = false;
            this.m_TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = 0;
            this.m__TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull = false;
            this.m_TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA = "";
            this.m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAIsNull = false;
            this.m_POTREBNASTRUCNASPREMAIDSTRUCNASPREMA = 0;
            this.m__POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAIsNull = false;
            this.m_POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA = "";
            this.m__IDSTRUKAIsNull = false;
            this.m_IDSTRUKA = 0;
            this.m__NAZIVSTRUKAIsNull = false;
            this.m_NAZIVSTRUKA = "";
            this.m__IDBRACNOSTANJEIsNull = false;
            this.m_IDBRACNOSTANJE = 0;
            this.m__NAZIVBRACNOSTANJEIsNull = false;
            this.m_NAZIVBRACNOSTANJE = "";
            this.m__IDORGDIOIsNull = false;
            this.m_IDORGDIO = 0;
            this.m__ORGANIZACIJSKIDIOIsNull = false;
            this.m_ORGANIZACIJSKIDIO = "";
            this.m__OIBIsNull = false;
            this.m_OIB = "";
            this.m__IDSPOLIsNull = false;
            this.m_IDSPOL = 0;
            this.m__NAZIVSPOLIsNull = false;
            this.m_NAZIVSPOL = "";
            this.m__IDIPIDENTIsNull = false;
            this.m_IDIPIDENT = 0;
            this.m__NAZIVIPIDENTIsNull = false;
            this.m_NAZIVIPIDENT = "";
            this.m_SubSelTopString290 = "";
            this.m_WhereString9 = "";
            this.m__BANKAZASTICENOIDBANKEIsNull = false;
            this.m_BANKAZASTICENOIDBANKE = 0;
            this.m__ZADSIFRAOPISAPLACANJAIZUZECEIsNull = false;
            this.m_ZADSIFRAOPISAPLACANJAIZUZECE = "";
            this.m__ZADOPISPLACANJAIZUZECEIsNull = false;
            this.m_ZADOPISPLACANJAIZUZECE = "";
            this.m__ZADTEKUCIIZUZECEIsNull = false;
            this.m_ZADTEKUCIIZUZECE = "";
            this.m__ZADMOIZUZECEIsNull = false;
            this.m_ZADMOIZUZECE = "";
            this.m__ZADPOIZUZECEIsNull = false;
            this.m_ZADPOIZUZECE = "";
            this.m__ZADMZIZUZECEIsNull = false;
            this.m_ZADMZIZUZECE = "";
            this.m__ZADPZIZUZECEIsNull = false;
            this.m_ZADPZIZUZECE = "";
            this.m__ZADIZNOSIZUZECAIsNull = false;
            this.m_ZADIZNOSIZUZECA = new decimal();
            this.m_SubSelTopString56 = "";
            this.m_WhereString8 = "";
            this.m__NETOELEMENTIDELEMENTIsNull = false;
            this.m_NETOELEMENTIDELEMENT = 0;
            this.m__NETOELEMENTNAZIVELEMENTIsNull = false;
            this.m_NETOELEMENTNAZIVELEMENT = "";
            this.m__NETOSATNICAIsNull = false;
            this.m_NETOSATNICA = new decimal();
            this.m__NETOSATIIsNull = false;
            this.m_NETOSATI = new decimal();
            this.m__NETOPOSTOTAKIsNull = false;
            this.m_NETOPOSTOTAK = new decimal();
            this.m__NETOIZNOSIsNull = false;
            this.m_NETOIZNOS = new decimal();
            this.m_SubSelTopString54 = "";
            this.m_WhereString7 = "";
            this.m__BRUTOELEMENTIDELEMENTIsNull = false;
            this.m_BRUTOELEMENTIDELEMENT = 0;
            this.m__BRUTOELEMENTNAZIVELEMENTIsNull = false;
            this.m_BRUTOELEMENTNAZIVELEMENT = "";
            this.m__BRUTOSATNICAIsNull = false;
            this.m_BRUTOSATNICA = new decimal();
            this.m__BRUTOSATIIsNull = false;
            this.m_BRUTOSATI = new decimal();
            this.m__BRUTOPOSTOTAKIsNull = false;
            this.m_BRUTOPOSTOTAK = new decimal();
            this.m__BRUTOIZNOSIsNull = false;
            this.m_BRUTOIZNOS = new decimal();
            this.m_SubSelTopString59 = "";
            this.m_WhereString6 = "";
            this.m__ZADOBUSTAVAIDOBUSTAVAIsNull = false;
            this.m_ZADOBUSTAVAIDOBUSTAVA = 0;
            this.m__OBUSTAVAAKTIVNAIsNull = false;
            this.m_OBUSTAVAAKTIVNA = false;
            this.m__ZADOBUSTAVANAZIVOBUSTAVAIsNull = false;
            this.m_ZADOBUSTAVANAZIVOBUSTAVA = "";
            this.m__ZADOBUSTAVAVRSTAOBUSTAVEIsNull = false;
            this.m_ZADOBUSTAVAVRSTAOBUSTAVE = 0;
            this.m__ZADOBUSTAVANAZIVVRSTAOBUSTAVEIsNull = false;
            this.m_ZADOBUSTAVANAZIVVRSTAOBUSTAVE = "";
            this.m__ZADIZNOSOBUSTAVEIsNull = false;
            this.m_ZADIZNOSOBUSTAVE = new decimal();
            this.m__ZADPOSTOTAKOBUSTAVEIsNull = false;
            this.m_ZADPOSTOTAKOBUSTAVE = new decimal();
            this.m__ZADISPLACENOKASAIsNull = false;
            this.m_ZADISPLACENOKASA = new decimal();
            this.m__ZADSALDOKASAIsNull = false;
            this.m_ZADSALDOKASA = new decimal();
            this.m__ZADPOSTOTNAODBRUTAIsNull = false;
            this.m_ZADPOSTOTNAODBRUTA = false;
            this.m_SubSelTopString75 = "";
            this.m_WhereString5 = "";
            this.m__ZADKREDITIIDKREDITORIsNull = false;
            this.m_ZADKREDITIIDKREDITOR = 0;
            this.m__DATUMUGOVORAIsNull = false;
            this.m_DATUMUGOVORA = DateTime.MinValue;
            this.m__KREDITAKTIVANIsNull = false;
            this.m_KREDITAKTIVAN = false;
            this.m__ZADKREDITINAZIVKREDITORIsNull = false;
            this.m_ZADKREDITINAZIVKREDITOR = "";
            this.m__ZADKREDITIPRIMATELJKREDITOR1IsNull = false;
            this.m_ZADKREDITIPRIMATELJKREDITOR1 = "";
            this.m__ZADKREDITIPRIMATELJKREDITOR2IsNull = false;
            this.m_ZADKREDITIPRIMATELJKREDITOR2 = "";
            this.m__ZADKREDITIPRIMATELJKREDITOR3IsNull = false;
            this.m_ZADKREDITIPRIMATELJKREDITOR3 = "";
            this.m__SIFRAOPISAPLACANJAKREDITORIsNull = false;
            this.m_SIFRAOPISAPLACANJAKREDITOR = "";
            this.m__OPISPLACANJAKREDITORIsNull = false;
            this.m_OPISPLACANJAKREDITOR = "";
            this.m__MOKREDITORIsNull = false;
            this.m_MOKREDITOR = "";
            this.m__POKREDITORIsNull = false;
            this.m_POKREDITOR = "";
            this.m__MZKREDITORIsNull = false;
            this.m_MZKREDITOR = "";
            this.m__PZKREDITORIsNull = false;
            this.m_PZKREDITOR = "";
            this.m__ZADIZNOSRATEKREDITAIsNull = false;
            this.m_ZADIZNOSRATEKREDITA = new decimal();
            this.m__ZADBROJRATAOBUSTAVEIsNull = false;
            this.m_ZADBROJRATAOBUSTAVE = new decimal();
            this.m__ZADUKUPNIZNOSKREDITAIsNull = false;
            this.m_ZADUKUPNIZNOSKREDITA = new decimal();
            this.m__ZADVECOTPLACENOBROJRATAIsNull = false;
            this.m_ZADVECOTPLACENOBROJRATA = new decimal();
            this.m__ZADVECOTPLACENOUKUPNIIZNOSIsNull = false;
            this.m_ZADVECOTPLACENOUKUPNIIZNOS = new decimal();
            this.m_SubSelTopString23 = "";
            this.m_WhereString4 = "";
            this.m__ZADOLAKSICEIDOLAKSICEIsNull = false;
            this.m_ZADOLAKSICEIDOLAKSICE = 0;
            this.m__ZADOLAKSICEIDGRUPEOLAKSICAIsNull = false;
            this.m_ZADOLAKSICEIDGRUPEOLAKSICA = 0;
            this.m__ZADOLAKSICEMAXIMALNIIZNOSGRUPEIsNull = false;
            this.m_ZADOLAKSICEMAXIMALNIIZNOSGRUPE = new decimal();
            this.m__ZADOLAKSICENAZIVGRUPEOLAKSICAIsNull = false;
            this.m_ZADOLAKSICENAZIVGRUPEOLAKSICA = "";
            this.m__ZADOLAKSICENAZIVOLAKSICEIsNull = false;
            this.m_ZADOLAKSICENAZIVOLAKSICE = "";
            this.m__ZADOLAKSICEIDTIPOLAKSICEIsNull = false;
            this.m_ZADOLAKSICEIDTIPOLAKSICE = 0;
            this.m__ZADOLAKSICENAZIVTIPOLAKSICEIsNull = false;
            this.m_ZADOLAKSICENAZIVTIPOLAKSICE = "";
            this.m__ZADOLAKSICEVBDIOLAKSICAIsNull = false;
            this.m_ZADOLAKSICEVBDIOLAKSICA = "";
            this.m__ZADOLAKSICEZRNOLAKSICAIsNull = false;
            this.m_ZADOLAKSICEZRNOLAKSICA = "";
            this.m__ZADOLAKSICEPRIMATELJOLAKSICA1IsNull = false;
            this.m_ZADOLAKSICEPRIMATELJOLAKSICA1 = "";
            this.m__ZADOLAKSICEPRIMATELJOLAKSICA2IsNull = false;
            this.m_ZADOLAKSICEPRIMATELJOLAKSICA2 = "";
            this.m__ZADOLAKSICEPRIMATELJOLAKSICA3IsNull = false;
            this.m_ZADOLAKSICEPRIMATELJOLAKSICA3 = "";
            this.m__ZADMZOLAKSICEIsNull = false;
            this.m_ZADMZOLAKSICE = "";
            this.m__ZADPZOLAKSICEIsNull = false;
            this.m_ZADPZOLAKSICE = "";
            this.m__ZADMOOLAKSICEIsNull = false;
            this.m_ZADMOOLAKSICE = "";
            this.m__ZADPOOLAKSICEIsNull = false;
            this.m_ZADPOOLAKSICE = "";
            this.m__ZADSIFRAOPISAPLACANJAOLAKSICEIsNull = false;
            this.m_ZADSIFRAOPISAPLACANJAOLAKSICE = "";
            this.m__ZADOPISPLACANJAOLAKSICEIsNull = false;
            this.m_ZADOPISPLACANJAOLAKSICE = "";
            this.m__ZADIZNOSOLAKSICEIsNull = false;
            this.m_ZADIZNOSOLAKSICE = new decimal();
            this.m_SubSelTopString22 = "";
            this.m_WhereString3 = "";
            this.m__OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKIsNull = false;
            this.m_OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = 0;
            this.m__NAZIVOSOBNIODBITAKIsNull = false;
            this.m_NAZIVOSOBNIODBITAK = "";
            this.m__FAKTOROSOBNOGODBITKAIsNull = false;
            this.m_FAKTOROSOBNOGODBITKA = new decimal();
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public virtual int Update(DataSet dataSet)
        {
            throw new InvalidOperationException();
        }

        public string Filter
        {
            get
            {
                return this.filterCondition;
            }
            set
            {
                this.filterCondition = value;
                this.filterString = QueryHelper.GetFilterString(this.filterCondition);
                this.filterStringCond = QueryHelper.AddFilterString(this.filterCondition);
            }
        }

        public System.Data.MissingMappingAction MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        public ArrayList Order
        {
            get
            {
                return this.orderArray;
            }
            set
            {
                this.orderArray = value;
            }
        }

        string Placa.IRadnikZaObracunDataAdapter.Filter
        {
            get
            {
                return this.filterCondition;
            }
            set
            {
                this.filterCondition = value;
                this.filterString = QueryHelper.GetFilterString(this.filterCondition);
                this.filterStringCond = QueryHelper.AddFilterString(this.filterCondition);
            }
        }

        System.Data.MissingMappingAction System.Data.IDataAdapter.MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction System.Data.IDataAdapter.MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        ITableMappingCollection System.Data.IDataAdapter.TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        ITableMappingCollection TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
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

        public enum Attribute
        {
            IDRADNIK,
            AKTIVAN,
            PREZIME,
            IME,
            JMBG,
            DATUMRODJENJA,
            ulica,
            mjesto,
            kucnibroj,
            OPCINARADAIDOPCINE,
            OPCINARADANAZIVOPCINE,
            OPCINASTANOVANJAIDOPCINE,
            OPCINASTANOVANJANAZIVOPCINE,
            OPCINASTANOVANJAPRIREZ,
            OPCINASTANOVANJAVBDIOPCINA,
            OPCINASTANOVANJAZRNOPCINA,
            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA,
            RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA,
            IDBANKE,
            NAZIVBANKE1,
            NAZIVBANKE2,
            NAZIVBANKE3,
            VBDIBANKE,
            ZRNBANKE,
            TEKUCI,
            ZBIRNINETO,
            SIFRAOPISAPLACANJANETO,
            OPISPLACANJANETO,
            TJEDNIFONDSATI,
            KOEFICIJENT,
            POSTOTAKOSLOBODJENJAODPOREZA,
            UZIMAUOBZIROSNOVICEDOPRINOSA,
            TJEDNIFONDSATISTAZ,
            DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI,
            GODINESTAZA,
            MJESECISTAZA,
            DANISTAZA,
            IDBENEFICIRANI,
            NAZIVBENEFICIRANI,
            DATUMPRESTANKARADNOGODNOSA,
            BROJMIROVINSKOG,
            BROJZDRAVSTVENOG,
            MBO,
            IDTITULA,
            NAZIVTITULA,
            IDRADNOMJESTO,
            NAZIVRADNOMJESTO,
            TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA,
            TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA,
            POTREBNASTRUCNASPREMAIDSTRUCNASPREMA,
            POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA,
            IDSTRUKA,
            NAZIVSTRUKA,
            IDBRACNOSTANJE,
            NAZIVBRACNOSTANJE,
            IDORGDIO,
            ORGANIZACIJSKIDIO,
            OIB,
            IDSPOL,
            NAZIVSPOL,
            IDIPIDENT,
            NAZIVIPIDENT
        }

        public class OrderAttribute
        {
            public bool OrderAttributeAscending;
            public RadnikZaObracunDataAdapter.Attribute OrderAttributeName;
            public string OrderAttributeString;

            public OrderAttribute(RadnikZaObracunDataAdapter.Attribute orderAttributeName)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = true;
                this.OrderAttributeString = RadnikZaObracunDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }

            public OrderAttribute(RadnikZaObracunDataAdapter.Attribute orderAttributeName, bool orderAttributeAscending)
            {
                this.OrderAttributeName = orderAttributeName;
                this.OrderAttributeAscending = orderAttributeAscending;
                this.OrderAttributeString = RadnikZaObracunDataAdapter.attributeNames[(int) this.OrderAttributeName];
            }
        }
    }
}

