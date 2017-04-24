namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Hlp;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;

    public class RADNIKDataAdapter : IDataAdapter, IRADNIKDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove189;
        private bool _Gxremove193;
        private bool _Gxremove214;
        private bool _Gxremove238;
        private bool _Gxremove246;
        private bool _Gxremove261;
        private bool _Gxremove276;
        private bool _Gxremove280;
        private ReadWriteCommand cmRADNIKBrutoSelect2;
        private ReadWriteCommand cmRADNIKIzuzeceOdOvrheSelect2;
        private ReadWriteCommand cmRADNIKKreditiSelect2;
        private ReadWriteCommand cmRADNIKLevel7Select2;
        private ReadWriteCommand cmRADNIKNetoSelect2;
        private ReadWriteCommand cmRADNIKObustavaSelect2;
        private ReadWriteCommand cmRADNIKOdbitakSelect2;
        private ReadWriteCommand cmRADNIKOlaksicaSelect2;
        private ReadWriteCommand cmRADNIKSelect1;
        private ReadWriteCommand cmRADNIKSelect10;
        private ReadWriteCommand cmRADNIKSelect11;
        private ReadWriteCommand cmRADNIKSelect12;
        private ReadWriteCommand cmRADNIKSelect13;
        private ReadWriteCommand cmRADNIKSelect14;
        private ReadWriteCommand cmRADNIKSelect15;
        private ReadWriteCommand cmRADNIKSelect16;
        private ReadWriteCommand cmRADNIKSelect17;
        private ReadWriteCommand cmRADNIKSelect18;
        private ReadWriteCommand cmRADNIKSelect19;
        private ReadWriteCommand cmRADNIKSelect2;
        private ReadWriteCommand cmRADNIKSelect23;
        private ReadWriteCommand cmRADNIKSelect3;
        private ReadWriteCommand cmRADNIKSelect4;
        private ReadWriteCommand cmRADNIKSelect5;
        private ReadWriteCommand cmRADNIKSelect6;
        private ReadWriteCommand cmRADNIKSelect7;
        private ReadWriteCommand cmRADNIKSelect8;
        private ReadWriteCommand cmRADNIKSelect9;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__AKTIVANOriginal;
        private object m__BROJMIROVINSKOGOriginal;
        private object m__BROJZDRAVSTVENOGOriginal;
        private object m__BRUTOIZNOSOriginal;
        private object m__BRUTOPOSTOTAKOriginal;
        private object m__BRUTOSATIOriginal;
        private object m__BRUTOSATNICAOriginal;
        private object m__DANISTAZAOriginal;
        private object m__DANISTAZAPROOriginal;
        private object m__DATUMPRESTANKARADNOGODNOSAOriginal;
        private object m__DATUMRODJENJAOriginal;
        private object m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIOriginal;
        private object m__DODATNIKOEFICIJENTOriginal;
        private object m__GODINESTAZAOriginal;
        private object m__GODINESTAZAPROOriginal;
        private object m__IDBANKEOriginal;
        private object m__IDBENEFICIRANIOriginal;
        private object m__IDBRACNOSTANJEOriginal;
        private object m__IDDRZAVLJANSTVOOriginal;
        private object m__IDIPIDENTOriginal;
        private object m__IDORGDIOOriginal;
        private object m__IDRADNOMJESTOOriginal;
        private object m__IDRADNOVRIJEMEOriginal;
        private object m__IDSPOLOriginal;
        private object m__IDSTRUKAOriginal;
        private object m__IDTITULAOriginal;
        private object m__IDUGOVORORADUOriginal;
        private object m__IMEOriginal;
        private object m__JMBGOriginal;
        private object m__KOEFICIJENTOriginal;
        private object m__KREDITAKTIVANOriginal;
        private object m__kucnibrojOriginal;
        private object m__MBOOriginal;
        private object m__MJESECISTAZAOriginal;
        private object m__MJESECISTAZAPROOriginal;
        private object m__mjestoOriginal;
        private object m__MOKREDITOROriginal;
        private object m__MOOriginal;
        private object m__MZKREDITOROriginal;
        private object m__NAZIVPOSLAOriginal;
        private object m__NETOIZNOSOriginal;
        private object m__NETOPOSTOTAKOriginal;
        private object m__NETOSATIOriginal;
        private object m__NETOSATNICAOriginal;
        private object m__OBUSTAVAAKTIVNAOriginal;
        private object m__OIBOriginal;
        private object m__OPCINARADAIDOPCINEOriginal;
        private object m__OPCINASTANOVANJAIDOPCINEOriginal;
        private object m__OPISPLACANJAKREDITOROriginal;
        private object m__OPISPLACANJANETOOriginal;
        private object m__PARTIJAKREDITASPECIFIKACIJAOriginal;
        private object m__PBOOriginal;
        private object m__POCETAKRADAOriginal;
        private object m__POKREDITOROriginal;
        private object m__POSTOTAKOSLOBODJENJAODPOREZAOriginal;
        private object m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAOriginal;
        private object m__PREZIMEOriginal;
        private object m__PRODUZENOMIROVINSKOOriginal;
        private object m__PZKREDITOROriginal;
        private object m__RADNADOZVOLAOriginal;
        private object m__RADNASPOSOBNOSTOriginal;
        private object m__RADNIKNAPOMENAOriginal;
        private object m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAOriginal;
        private object m__RADUINOZEMSTVUOriginal;
        private object m__RAZLOGPRESTANKAOriginal;
        private object m__SIFRAOPISAPLACANJAKREDITOROriginal;
        private object m__SIFRAOPISAPLACANJANETOOriginal;
        private object m__TEKUCIOriginal;
        private object m__TJEDNIFONDSATIOriginal;
        private object m__TJEDNIFONDSATISTAZOriginal;
        private object m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAOriginal;
        private object m__UGOVORODOriginal;
        private object m__ulicaOriginal;
        private object m__UZIMAUOBZIROSNOVICEDOPRINOSAOriginal;
        private object m__VRIJEMEMIROVANJARADNOGODNOSAOriginal;
        private object m__VRIJEMEPRIPRAVNICKOGOriginal;
        private object m__VRIJEMEPROBNOGRADAOriginal;
        private object m__VRIJEMESTRUCNIOriginal;
        private object m__ZABRANANATJECANJAOriginal;
        private object m__ZADBROJRATAOBUSTAVEOriginal;
        private object m__ZADISPLACENOKASAOriginal;
        private object m__ZADIZNOSIZUZECAOriginal;
        private object m__ZADIZNOSOBUSTAVEOriginal;
        private object m__ZADIZNOSOLAKSICEOriginal;
        private object m__ZADIZNOSRATEKREDITAOriginal;
        private object m__ZADMOIZUZECEOriginal;
        private object m__ZADMOOLAKSICEOriginal;
        private object m__ZADMZIZUZECEOriginal;
        private object m__ZADMZOLAKSICEOriginal;
        private object m__ZADOPISPLACANJAIZUZECEOriginal;
        private object m__ZADOPISPLACANJAOLAKSICEOriginal;
        private object m__ZADPOIZUZECEOriginal;
        private object m__ZADPOJEDINACNIPOZIVOriginal;
        private object m__ZADPOOLAKSICEOriginal;
        private object m__ZADPOSTOTAKOBUSTAVEOriginal;
        private object m__ZADPOSTOTNAODBRUTAOriginal;
        private object m__ZADPZIZUZECEOriginal;
        private object m__ZADPZOLAKSICEOriginal;
        private object m__ZADSALDOKASAOriginal;
        private object m__ZADSIFRAOPISAPLACANJAIZUZECEOriginal;
        private object m__ZADSIFRAOPISAPLACANJAOLAKSICEOriginal;
        private object m__ZADTEKUCIIZUZECEOriginal;
        private object m__ZADUKUPNIZNOSKREDITAOriginal;
        private object m__ZADVECOTPLACENOBROJRATAOriginal;
        private object m__ZADVECOTPLACENOUKUPNIIZNOSOriginal;
        private object m__ZAVRSENASKOLAOriginal;
        private object m__ZBIRNINETOOriginal;
        private readonly string m_SelectString21 = "TM1.[IDRADNIK], TM1.[AKTIVAN], TM1.[GODINESTAZAPRO], TM1.[MJESECISTAZAPRO], TM1.[DANISTAZAPRO], TM1.[PREZIME], TM1.[IME], TM1.[OIB], TM1.[JMBG], TM1.[DATUMRODJENJA], TM1.[ulica], TM1.[mjesto], TM1.[kucnibroj], T2.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T3.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T3.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T3.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T3.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, T4.[NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA, T5.[NAZIVBANKE1], T5.[NAZIVBANKE2], T5.[NAZIVBANKE3], T5.[VBDIBANKE], T5.[ZRNBANKE], TM1.[TEKUCI], TM1.[ZBIRNINETO], TM1.[SIFRAOPISAPLACANJANETO], TM1.[OPISPLACANJANETO], TM1.[TJEDNIFONDSATI], TM1.[KOEFICIJENT], TM1.[POSTOTAKOSLOBODJENJAODPOREZA], TM1.[UZIMAUOBZIROSNOVICEDOPRINOSA], TM1.[TJEDNIFONDSATISTAZ], TM1.[DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], TM1.[GODINESTAZA], TM1.[MJESECISTAZA], TM1.[DANISTAZA], T6.[NAZIVBENEFICIRANI], TM1.[DATUMPRESTANKARADNOGODNOSA], TM1.[BROJMIROVINSKOG], TM1.[BROJZDRAVSTVENOG], TM1.[MBO], T7.[NAZIVTITULA], T8.[NAZIVRADNOMJESTO], T9.[NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA, T10.[NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA, T11.[NAZIVSTRUKA], T12.[NAZIVBRACNOSTANJE], T13.[ORGANIZACIJSKIDIO], T6.[BROJPRIZNATIHMJESECI], TM1.[MO], TM1.[PBO], T14.[NAZIVDRZAVLJANSTVO], TM1.[RADNADOZVOLA], TM1.[ZAVRSENASKOLA], TM1.[UGOVOROD], TM1.[POCETAKRADA], TM1.[NAZIVPOSLA], T15.[NAZIVUGOVORORADU], TM1.[VRIJEMEPROBNOGRADA], TM1.[VRIJEMEPRIPRAVNICKOG], TM1.[VRIJEMESTRUCNI], TM1.[RADUINOZEMSTVU], TM1.[RADNASPOSOBNOST], TM1.[VRIJEMEMIROVANJARADNOGODNOSA], TM1.[RAZLOGPRESTANKA], TM1.[ZABRANANATJECANJA], TM1.[PRODUZENOMIROVINSKO], TM1.[RADNIKNAPOMENA], T16.[NAZIVSPOL], T17.[NAZIVIPIDENT], TM1.[IDBANKE], TM1.[IDBENEFICIRANI], TM1.[IDTITULA], TM1.[IDRADNOMJESTO], TM1.[IDSTRUKA], TM1.[IDBRACNOSTANJE], TM1.[IDORGDIO], TM1.[IDSPOL], TM1.[IDIPIDENT], TM1.[IDDRZAVLJANSTVO], TM1.[IDUGOVORORADU], TM1.[IDRADNOVRIJEME], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
        private string m_SPOJENOPREZIME;
        private string m_SubSelTopString22;
        private string m_SubSelTopString23;
        private string m_SubSelTopString290;
        private string m_SubSelTopString54;
        private string m_SubSelTopString56;
        private string m_SubSelTopString59;
        private string m_SubSelTopString75;
        private string m_SubSelTopString97;
        private string m_WhereString;
        private IDataReader RADNIKBrutoSelect2;
        private IDataReader RADNIKIzuzeceOdOvrheSelect2;
        private IDataReader RADNIKKreditiSelect2;
        private IDataReader RADNIKLevel7Select2;
        private IDataReader RADNIKNetoSelect2;
        private IDataReader RADNIKObustavaSelect2;
        private IDataReader RADNIKOdbitakSelect2;
        private IDataReader RADNIKOlaksicaSelect2;
        private IDataReader RADNIKSelect1;
        private IDataReader RADNIKSelect10;
        private IDataReader RADNIKSelect11;
        private IDataReader RADNIKSelect12;
        private IDataReader RADNIKSelect13;
        private IDataReader RADNIKSelect14;
        private IDataReader RADNIKSelect15;
        private IDataReader RADNIKSelect16;
        private IDataReader RADNIKSelect17;
        private IDataReader RADNIKSelect18;
        private IDataReader RADNIKSelect19;
        private IDataReader RADNIKSelect2;
        private IDataReader RADNIKSelect23;
        private IDataReader RADNIKSelect3;
        private IDataReader RADNIKSelect4;
        private IDataReader RADNIKSelect5;
        private IDataReader RADNIKSelect6;
        private IDataReader RADNIKSelect7;
        private IDataReader RADNIKSelect8;
        private IDataReader RADNIKSelect9;
        private RADNIKDataSet RADNIKSet;
        private short RcdFound21;
        private short RcdFound22;
        private short RcdFound23;
        private short RcdFound290;
        private short RcdFound54;
        private short RcdFound56;
        private short RcdFound59;
        private short RcdFound75;
        private short RcdFound97;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RADNIKDataSet.RADNIKRow rowRADNIK;
        private RADNIKDataSet.RADNIKBrutoRow rowRADNIKBruto;
        private RADNIKDataSet.RADNIKIzuzeceOdOvrheRow rowRADNIKIzuzeceOdOvrhe;
        private RADNIKDataSet.RADNIKKreditiRow rowRADNIKKrediti;
        private RADNIKDataSet.RADNIKLevel7Row rowRADNIKLevel7;
        private RADNIKDataSet.RADNIKNetoRow rowRADNIKNeto;
        private RADNIKDataSet.RADNIKObustavaRow rowRADNIKObustava;
        private RADNIKDataSet.RADNIKOdbitakRow rowRADNIKOdbitak;
        private RADNIKDataSet.RADNIKOlaksicaRow rowRADNIKOlaksica;
        private string scmdbuf;
        private StatementType sMode21;
        private StatementType sMode22;
        private StatementType sMode23;
        private StatementType sMode290;
        private StatementType sMode54;
        private StatementType sMode56;
        private StatementType sMode59;
        private StatementType sMode75;
        private StatementType sMode97;

        public event RADNIKBrutoUpdateEventHandler RADNIKBrutoUpdated;

        public event RADNIKBrutoUpdateEventHandler RADNIKBrutoUpdating;

        public event RADNIKIzuzeceOdOvrheUpdateEventHandler RADNIKIzuzeceOdOvrheUpdated;

        public event RADNIKIzuzeceOdOvrheUpdateEventHandler RADNIKIzuzeceOdOvrheUpdating;

        public event RADNIKKreditiUpdateEventHandler RADNIKKreditiUpdated;

        public event RADNIKKreditiUpdateEventHandler RADNIKKreditiUpdating;

        public event RADNIKLevel7UpdateEventHandler RADNIKLevel7Updated;

        public event RADNIKLevel7UpdateEventHandler RADNIKLevel7Updating;

        public event RADNIKNetoUpdateEventHandler RADNIKNetoUpdated;

        public event RADNIKNetoUpdateEventHandler RADNIKNetoUpdating;

        public event RADNIKObustavaUpdateEventHandler RADNIKObustavaUpdated;

        public event RADNIKObustavaUpdateEventHandler RADNIKObustavaUpdating;

        public event RADNIKOdbitakUpdateEventHandler RADNIKOdbitakUpdated;

        public event RADNIKOdbitakUpdateEventHandler RADNIKOdbitakUpdating;

        public event RADNIKOlaksicaUpdateEventHandler RADNIKOlaksicaUpdated;

        public event RADNIKOlaksicaUpdateEventHandler RADNIKOlaksicaUpdating;

        public event RADNIKUpdateEventHandler RADNIKUpdated;

        public event RADNIKUpdateEventHandler RADNIKUpdating;

        private void AddRowRadnik()
        {
            this.RADNIKSet.RADNIK.AddRADNIKRow(this.rowRADNIK);
        }

        private void AddRowRadnikbruto()
        {
            this.RADNIKSet.RADNIKBruto.AddRADNIKBrutoRow(this.rowRADNIKBruto);
        }

        private void AddRowRadnikizuzeceodovrhe()
        {
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.AddRADNIKIzuzeceOdOvrheRow(this.rowRADNIKIzuzeceOdOvrhe);
        }

        private void AddRowRadnikkrediti()
        {
            this.RADNIKSet.RADNIKKrediti.AddRADNIKKreditiRow(this.rowRADNIKKrediti);
        }

        private void AddRowRadniklevel7()
        {
            this.RADNIKSet.RADNIKLevel7.AddRADNIKLevel7Row(this.rowRADNIKLevel7);
        }

        private void AddRowRadnikneto()
        {
            this.RADNIKSet.RADNIKNeto.AddRADNIKNetoRow(this.rowRADNIKNeto);
        }

        private void AddRowRadnikobustava()
        {
            this.RADNIKSet.RADNIKObustava.AddRADNIKObustavaRow(this.rowRADNIKObustava);
        }

        private void AddRowRadnikodbitak()
        {
            this.RADNIKSet.RADNIKOdbitak.AddRADNIKOdbitakRow(this.rowRADNIKOdbitak);
        }

        private void AddRowRadnikolaksica()
        {
            this.RADNIKSet.RADNIKOlaksica.AddRADNIKOlaksicaRow(this.rowRADNIKOlaksica);
        }

        private void AfterConfirmRadnik()
        {
            this.OnRADNIKUpdating(new RADNIKEventArgs(this.rowRADNIK, this.Gx_mode));
        }

        private void AfterConfirmRadnikbruto()
        {
            this.OnRADNIKBrutoUpdating(new RADNIKBrutoEventArgs(this.rowRADNIKBruto, this.Gx_mode));
        }

        private void AfterConfirmRadnikizuzeceodovrhe()
        {
            this.OnRADNIKIzuzeceOdOvrheUpdating(new RADNIKIzuzeceOdOvrheEventArgs(this.rowRADNIKIzuzeceOdOvrhe, this.Gx_mode));
        }

        private void AfterConfirmRadnikkrediti()
        {
            this.OnRADNIKKreditiUpdating(new RADNIKKreditiEventArgs(this.rowRADNIKKrediti, this.Gx_mode));
        }

        private void AfterConfirmRadniklevel7()
        {
            this.OnRADNIKLevel7Updating(new RADNIKLevel7EventArgs(this.rowRADNIKLevel7, this.Gx_mode));
        }

        private void AfterConfirmRadnikneto()
        {
            this.OnRADNIKNetoUpdating(new RADNIKNetoEventArgs(this.rowRADNIKNeto, this.Gx_mode));
        }

        private void AfterConfirmRadnikobustava()
        {
            this.OnRADNIKObustavaUpdating(new RADNIKObustavaEventArgs(this.rowRADNIKObustava, this.Gx_mode));
        }

        private void AfterConfirmRadnikodbitak()
        {
            this.OnRADNIKOdbitakUpdating(new RADNIKOdbitakEventArgs(this.rowRADNIKOdbitak, this.Gx_mode));
        }

        private void AfterConfirmRadnikolaksica()
        {
            this.OnRADNIKOlaksicaUpdating(new RADNIKOlaksicaEventArgs(this.rowRADNIKOlaksica, this.Gx_mode));
        }

        private void CheckDeleteErrorsRadnik()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDGOOBRACUN] FROM [GOOBRACUN] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new GOOBRACUNInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "GOOBRACUN" }));
            }
            reader2.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [DATUMODLASKA] FROM [OTISLI] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new OTISLIInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OTISLI" }));
            }
            reader4.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [DATUMZAPOSLENJA] FROM [ZAPOSLENI] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new ZAPOSLENIInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ZAPOSLENI" }));
            }
            reader6.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [MJESEC], [IDGODINE], [BROJEVIDENCIJE], [IDRADNIK] FROM [EVIDENCIJARADNICI] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new EVIDENCIJARADNICIInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNICI" }));
            }
            reader.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [IDELEMENT], [IDRADNIK] FROM [PRPLACEPRPLACEELEMENTIRADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new PRPLACEPRPLACEELEMENTIRADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader5.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK] FROM [ObracunRadnici] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new ObracunRadniciInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ObracunRadnici" }));
            }
            reader3.Close();
        }

        private void CheckExtendedTableRadnik()
        {
            this.rowRADNIK.UKUPNIFAKTOR = placa.UkupnoFaktorOO(this.rowRADNIK.IDRADNIK, Configuration.ConnectionString.ToString());
            this.m_SPOJENOPREZIME = this.rowRADNIK.PREZIME + " " + this.rowRADNIK.IME;
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]));
            IDataReader reader6 = command6.FetchData();
            if (!command6.HasMoreRows)
            {
                reader6.Close();
                throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
            }
            this.rowRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0));
            reader6.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            IDataReader reader7 = command7.FetchData();
            if (!command7.HasMoreRows)
            {
                reader7.Close();
                throw new OPCINAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OPCINA") }));
            }
            this.rowRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 0));
            this.rowRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader7, 1));
            this.rowRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 2));
            this.rowRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 3));
            reader7.Close();
            ReadWriteCommand command10 = this.connDefault.GetCommand("SELECT [NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA FROM [SKUPPOREZAIDOPRINOSA] WITH (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
            if (command10.IDbCommand.Parameters.Count == 0)
            {
                command10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            command10.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
            IDataReader reader10 = command10.FetchData();
            if (!command10.HasMoreRows)
            {
                reader10.Close();
                throw new SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SKUPPOREZAIDOPRINOSA") }));
            }
            this.rowRADNIK["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader10, 0));
            reader10.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new BANKEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
            }
            this.rowRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new BENEFICIRANIForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BENEFICIRANI") }));
            }
            this.rowRADNIK["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            this.rowRADNIK["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader2, 1));
            reader2.Close();
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNODANASTAZA = placa.DaniStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOMJESECISTAZA = placa.MjeseciStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOGODINESTAZA = placa.GodineStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsIDTITULANull())
            {
                ReadWriteCommand command15 = this.connDefault.GetCommand("SELECT [NAZIVTITULA] FROM [TITULA] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                if (command15.IDbCommand.Parameters.Count == 0)
                {
                    command15.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                }
                command15.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]));
                IDataReader reader15 = command15.FetchData();
                if (!command15.HasMoreRows && (0 != this.rowRADNIK.IDTITULA))
                {
                    reader15.Close();
                    throw new TITULAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TITULA") }));
                }
                this.rowRADNIK["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader15, 0));
                reader15.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVTITULA"] = "";
            }
            if (!this.rowRADNIK.IsIDRADNOMJESTONull())
            {
                ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                if (command9.IDbCommand.Parameters.Count == 0)
                {
                    command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                }
                command9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]));
                IDataReader reader9 = command9.FetchData();
                if (!command9.HasMoreRows && (0 != this.rowRADNIK.IDRADNOMJESTO))
                {
                    reader9.Close();
                    throw new RADNOMJESTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNOMJESTO") }));
                }
                this.rowRADNIK["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader9, 0));
                reader9.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVRADNOMJESTO"] = "";
            }
            if (!this.rowRADNIK.IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command12 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command12.IDbCommand.Parameters.Count == 0)
                {
                    command12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command12.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader12 = command12.FetchData();
                if (!command12.HasMoreRows && (0 != this.rowRADNIK.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA))
                {
                    reader12.Close();
                    throw new STRUCNASPREMAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
                }
                this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader12, 0));
                reader12.Close();
            }
            else
            {
                this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIK.IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command13 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command13.IDbCommand.Parameters.Count == 0)
                {
                    command13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader13 = command13.FetchData();
                if (!command13.HasMoreRows && (0 != this.rowRADNIK.POTREBNASTRUCNASPREMAIDSTRUCNASPREMA))
                {
                    reader13.Close();
                    throw new STRUCNASPREMAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
                }
                this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader13, 0));
                reader13.Close();
            }
            else
            {
                this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIK.IsIDSTRUKANull())
            {
                ReadWriteCommand command14 = this.connDefault.GetCommand("SELECT [NAZIVSTRUKA] FROM [STRUKA] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                if (command14.IDbCommand.Parameters.Count == 0)
                {
                    command14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                }
                command14.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]));
                IDataReader reader14 = command14.FetchData();
                if (!command14.HasMoreRows && (0 != this.rowRADNIK.IDSTRUKA))
                {
                    reader14.Close();
                    throw new STRUKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUKA") }));
                }
                this.rowRADNIK["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader14, 0));
                reader14.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVSTRUKA"] = "";
            }
            if (!this.rowRADNIK.IsIDBRACNOSTANJENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVBRACNOSTANJE] FROM [BRACNOSTANJE] WITH (NOLOCK) WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]));
                IDataReader reader3 = command3.FetchData();
                if (!command3.HasMoreRows && (0 != this.rowRADNIK.IDBRACNOSTANJE))
                {
                    reader3.Close();
                    throw new BRACNOSTANJEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BRACNOSTANJE") }));
                }
                this.rowRADNIK["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                reader3.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVBRACNOSTANJE"] = "";
            }
            if (!this.rowRADNIK.IsIDORGDIONull())
            {
                ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT [ORGANIZACIJSKIDIO] FROM [ORGDIO] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                if (command8.IDbCommand.Parameters.Count == 0)
                {
                    command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                }
                command8.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]));
                IDataReader reader8 = command8.FetchData();
                if (!command8.HasMoreRows && (0 != this.rowRADNIK.IDORGDIO))
                {
                    reader8.Close();
                    throw new ORGDIOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGDIO") }));
                }
                this.rowRADNIK["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader8, 0));
                reader8.Close();
            }
            else
            {
                this.rowRADNIK["ORGANIZACIJSKIDIO"] = "";
            }
            if (!this.rowRADNIK.IsIDDRZAVLJANSTVONull())
            {
                ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVDRZAVLJANSTVO] FROM [DRZAVLJANSTVO] WITH (NOLOCK) WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ", false);
                if (command4.IDbCommand.Parameters.Count == 0)
                {
                    command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
                }
                command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]));
                IDataReader reader4 = command4.FetchData();
                if (!command4.HasMoreRows && (0 != this.rowRADNIK.IDDRZAVLJANSTVO))
                {
                    reader4.Close();
                    throw new DRZAVLJANSTVOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DRZAVLJANSTVO") }));
                }
                this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0));
                reader4.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = "";
            }
            if (!this.rowRADNIK.IsIDUGOVORORADUNull())
            {
                ReadWriteCommand command16 = this.connDefault.GetCommand("SELECT [NAZIVUGOVORORADU] FROM [UGOVORORADU] WITH (NOLOCK) WHERE [IDUGOVORORADU] = @IDUGOVORORADU ", false);
                if (command16.IDbCommand.Parameters.Count == 0)
                {
                    command16.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
                }
                command16.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]));
                IDataReader reader16 = command16.FetchData();
                if (!command16.HasMoreRows && (0 != this.rowRADNIK.IDUGOVORORADU))
                {
                    reader16.Close();
                    throw new UGOVORORADUForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("UGOVORORADU") }));
                }
                this.rowRADNIK["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader16, 0));
                reader16.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVUGOVORORADU"] = "";
            }
            ReadWriteCommand command11 = this.connDefault.GetCommand("SELECT [NAZIVSPOL] FROM [SPOL] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (command11.IDbCommand.Parameters.Count == 0)
            {
                command11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command11.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]));
            IDataReader reader11 = command11.FetchData();
            if (!command11.HasMoreRows)
            {
                reader11.Close();
                throw new SPOLForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SPOL") }));
            }
            this.rowRADNIK["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader11, 0));
            reader11.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVIPIDENT] FROM [IPIDENT] WITH (NOLOCK) WHERE [IDIPIDENT] = @IDIPIDENT ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]));
            IDataReader reader5 = command5.FetchData();
            if (!command5.HasMoreRows)
            {
                reader5.Close();
                throw new IPIDENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("IPIDENT") }));
            }
            this.rowRADNIK["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0));
            reader5.Close();
        }

        private void CheckExtendedTableRadnikbruto()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, [POSTOTAK] AS BRUTOELEMENTPOSTOTAK FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @BRUTOELEMENTIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            this.rowRADNIKBruto["BRUTOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowRADNIKBruto["BRUTOELEMENTPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            reader.Close();
        }

        private void CheckExtendedTableRadnikkrediti()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, [PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, [PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, [PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, [VBDIKREDITOR] AS ZADKREDITIVBDIKREDITOR, [ZRNKREDITOR] AS ZADKREDITIZRNKREDITOR FROM [KREDITOR] WITH (NOLOCK) WHERE [IDKREDITOR] = @ZADKREDITIIDKREDITOR ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADKREDITIIDKREDITOR", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KREDITORForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KREDITOR") }));
            }
            this.rowRADNIKKrediti["ZADKREDITINAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowRADNIKKrediti["ZADKREDITIVBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowRADNIKKrediti["ZADKREDITIZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            reader.Close();
            this.rowRADNIKKrediti.KREDITOTPLACENIIZNOS = decimal.Add(placa.Krediti_iznos(this.rowRADNIKKrediti.IDRADNIK, this.rowRADNIKKrediti.ZADKREDITIIDKREDITOR, Configuration.ConnectionString.ToString(), this.rowRADNIKKrediti.DATUMUGOVORA), this.rowRADNIKKrediti.ZADVECOTPLACENOUKUPNIIZNOS);
            this.rowRADNIKKrediti.KREDITOTPLACENORATA = decimal.Add(new decimal(placa.Krediti_brojrata(this.rowRADNIKKrediti.IDRADNIK, this.rowRADNIKKrediti.ZADKREDITIIDKREDITOR, Configuration.ConnectionString.ToString(), this.rowRADNIKKrediti.DATUMUGOVORA)), this.rowRADNIKKrediti.ZADVECOTPLACENOBROJRATA);
        }

        private void CheckExtendedTableRadniklevel7()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEKOEF] FROM [GRUPEKOEF] WITH (NOLOCK) WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDGRUPEKOEF"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GRUPEKOEFForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GRUPEKOEF") }));
            }
            this.rowRADNIKLevel7["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckExtendedTableRadnikneto()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @NETOELEMENTIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOELEMENTIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            this.rowRADNIKNeto["NETOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckExtendedTableRadnikobustava()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, [ZRNOBUSTAVA] AS ZADOBUSTAVAZRNOBUSTAVA, [VBDIOBUSTAVA] AS ZADOBUSTAVAVBDIOBUSTAVA, [VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE FROM [OBUSTAVA] WITH (NOLOCK) WHERE [IDOBUSTAVA] = @ZADOBUSTAVAIDOBUSTAVA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAIDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new OBUSTAVAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OBUSTAVA") }));
            }
            this.rowRADNIKObustava["ZADOBUSTAVANAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowRADNIKObustava["ZADOBUSTAVAZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowRADNIKObustava["ZADOBUSTAVAVBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowRADNIKObustava["ZADOBUSTAVAVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 3));
            reader.Close();
            if (!this.rowRADNIKObustava.IsZADOBUSTAVAVRSTAOBUSTAVENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @ZADOBUSTAVAVRSTAOBUSTAVE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAVRSTAOBUSTAVE", DbType.Int16));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAVRSTAOBUSTAVE"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new VRSTEOBUSTAVAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTEOBUSTAVA") }));
                }
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                reader2.Close();
            }
            else
            {
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if ((this.rowRADNIKObustava.ZADOBUSTAVAVRSTAOBUSTAVE == 0) && (decimal.Compare(this.rowRADNIKObustava.ZADIZNOSOBUSTAVE, Convert.ToDecimal(0)) != 0))
            {
                throw new gRESKA("Unesite postotak obustave za postotne obustave!");
            }
            if ((this.rowRADNIKObustava.ZADOBUSTAVAVRSTAOBUSTAVE == 1) && (decimal.Compare(this.rowRADNIKObustava.ZADPOSTOTAKOBUSTAVE, Convert.ToDecimal(0)) != 0))
            {
                throw new gRESKA("Unesite iznos obustave za fiksne obustave!");
            }
            this.rowRADNIKObustava.OTPLACENIIZNOS = decimal.Add(placa.Obustave_Iznos(this.rowRADNIKObustava.IDRADNIK, this.rowRADNIKObustava.ZADOBUSTAVAIDOBUSTAVA, Configuration.ConnectionString.ToString()), this.rowRADNIKObustava.ZADSALDOKASA);
            this.rowRADNIKObustava.OTPLACENIBROJRATA = placa.Obustave_BROJRATA(this.rowRADNIKObustava.IDRADNIK, this.rowRADNIKObustava.ZADOBUSTAVAIDOBUSTAVA, Configuration.ConnectionString.ToString());
        }

        private void CheckExtendedTableRadnikodbitak()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSOBNIODBITAK], [FAKTOROSOBNOGODBITKA] FROM [OSOBNIODBITAK] WITH (NOLOCK) WHERE [IDOSOBNIODBITAK] = @OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new OSOBNIODBITAKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSOBNIODBITAK") }));
            }
            this.rowRADNIKOdbitak["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 0));
            this.rowRADNIKOdbitak["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            reader.Close();
        }

        private void CheckExtendedTableRadnikolaksica()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, [VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, [ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, [PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, [PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, [PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, [IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, [IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDOLAKSICE] = @ZADOLAKSICEIDOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new OLAKSICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OLAKSICE") }));
            }
            this.rowRADNIKOlaksica["ZADOLAKSICENAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            this.rowRADNIKOlaksica["ZADOLAKSICEVBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 1));
            this.rowRADNIKOlaksica["ZADOLAKSICEZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 2));
            this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 3));
            this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 4));
            this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 5));
            this.rowRADNIKOlaksica["ZADOLAKSICEIDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 6));
            this.rowRADNIKOlaksica["ZADOLAKSICEIDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 7));
            reader2.Close();
            if (!this.rowRADNIKOlaksica.IsZADOLAKSICEIDGRUPEOLAKSICANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, [NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @ZADOLAKSICEIDGRUPEOLAKSICA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDGRUPEOLAKSICA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDGRUPEOLAKSICA"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new GRUPEOLAKSICAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GRUPEOLAKSICA") }));
                }
                this.rowRADNIKOlaksica["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                reader.Close();
            }
            else
            {
                this.rowRADNIKOlaksica["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIKOlaksica.IsZADOLAKSICEIDTIPOLAKSICENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @ZADOLAKSICEIDTIPOLAKSICE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDTIPOLAKSICE", DbType.Int32));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDTIPOLAKSICE"]));
                IDataReader reader3 = command3.FetchData();
                if (!command3.HasMoreRows)
                {
                    reader3.Close();
                    throw new TIPOLAKSICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPOLAKSICE") }));
                }
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                reader3.Close();
            }
            else
            {
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
        }

        private void CheckIntegrityErrorsRadnik()
        {
            if (!this.rowRADNIK.IsIDRADNOVRIJEMENull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNOVRIJEME] FROM [RADNOVRIJEME] WITH (NOLOCK) WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOVRIJEME"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows && (0 != this.rowRADNIK.IDRADNOVRIJEME))
                {
                    reader.Close();
                    throw new RADNOVRIJEMEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNOVRIJEME") }));
                }
                reader.Close();
            }
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsRadnikizuzeceodovrhe()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBANKE] AS BANKAZASTICENOIDBANKE FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @BANKAZASTICENOIDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BANKAZASTICENOIDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["BANKAZASTICENOIDBANKE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new BANKEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyRadnik()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [AKTIVAN], [GODINESTAZAPRO], [MJESECISTAZAPRO], [DANISTAZAPRO], [PREZIME], [IME], [OIB], [JMBG], [DATUMRODJENJA], [ulica], [mjesto], [kucnibroj], [TEKUCI], [ZBIRNINETO], [SIFRAOPISAPLACANJANETO], [OPISPLACANJANETO], [TJEDNIFONDSATI], [KOEFICIJENT], [POSTOTAKOSLOBODJENJAODPOREZA], [UZIMAUOBZIROSNOVICEDOPRINOSA], [TJEDNIFONDSATISTAZ], [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], [GODINESTAZA], [MJESECISTAZA], [DANISTAZA], [DATUMPRESTANKARADNOGODNOSA], [BROJMIROVINSKOG], [BROJZDRAVSTVENOG], [MBO], [MO], [PBO], [RADNADOZVOLA], [ZAVRSENASKOLA], [UGOVOROD], [POCETAKRADA], [NAZIVPOSLA], [VRIJEMEPROBNOGRADA], [VRIJEMEPRIPRAVNICKOG], [VRIJEMESTRUCNI], [RADUINOZEMSTVU], [RADNASPOSOBNOST], [VRIJEMEMIROVANJARADNOGODNOSA], [RAZLOGPRESTANKA], [ZABRANANATJECANJA], [PRODUZENOMIROVINSKO], [RADNIKNAPOMENA], [IDBANKE], [IDBENEFICIRANI], [IDTITULA], [IDRADNOMJESTO], [IDSTRUKA], [IDBRACNOSTANJE], [IDORGDIO], [IDSPOL], [IDIPIDENT], [IDDRZAVLJANSTVO], [IDUGOVORORADU], [IDRADNOVRIJEME], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM [RADNIK] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PRPLACEPRPLACEELEMENTIRADNIK") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__AKTIVANOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1)))) || ((!this.m__GODINESTAZAPROOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 2))) || !this.m__MJESECISTAZAPROOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 3)))) || (!this.m__DANISTAZAPROOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PREZIMEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IMEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OIBOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__JMBGOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMRODJENJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ulicaOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__mjestoOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__kucnibrojOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__TEKUCIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13)))) || (!this.m__ZBIRNINETOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 14))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJANETOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJANETOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x10)))) || ((!this.m__TJEDNIFONDSATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x11))) || !this.m__KOEFICIJENTOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x12)))) || (!this.m__POSTOTAKOSLOBODJENJAODPOREZAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x13))) || !this.m__UZIMAUOBZIROSNOVICEDOPRINOSAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 20))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__TJEDNIFONDSATISTAZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x15)))) || ((!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x16))) || !this.m__GODINESTAZAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x17)))) || (!this.m__MJESECISTAZAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x18))) || !this.m__DANISTAZAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x19))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMPRESTANKARADNOGODNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x1a)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__BROJMIROVINSKOGOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1b))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__BROJZDRAVSTVENOGOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1c))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MBOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1d)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 30))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PBOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1f)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RADNADOZVOLAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x20))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZAVRSENASKOLAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x21))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__UGOVORODOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x22)))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__POCETAKRADAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x23))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPOSLAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x24)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VRIJEMEPROBNOGRADAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x25))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VRIJEMEPRIPRAVNICKOGOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x26))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VRIJEMESTRUCNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x27)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RADUINOZEMSTVUOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 40))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RADNASPOSOBNOSTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x29)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VRIJEMEMIROVANJARADNOGODNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2a))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RAZLOGPRESTANKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2b))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZABRANANATJECANJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2c)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRODUZENOMIROVINSKOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2d))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RADNIKNAPOMENAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2e)))) || ((!this.m__IDBANKEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x2f))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IDBENEFICIRANIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x30)))) || (!this.m__IDTITULAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x31))) || !this.m__IDRADNOMJESTOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 50))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__IDSTRUKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x33)))) || ((!this.m__IDBRACNOSTANJEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x34))) || !this.m__IDORGDIOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x35)))) || (!this.m__IDSPOLOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x36))) || !this.m__IDIPIDENTOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x37))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__IDDRZAVLJANSTVOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x38)))) || ((!this.m__IDUGOVORORADUOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x39))) || !this.m__IDRADNOVRIJEMEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3a)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPCINARADAIDOPCINEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x3b))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPCINASTANOVANJAIDOPCINEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 60))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3d)))) || (!this.m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3e))) || !this.m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3f)))))
                {
                    reader.Close();
                    throw new RADNIKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PRPLACEPRPLACEELEMENTIRADNIK") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadnikbruto()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [BRUTOSATI], [BRUTOPOSTOTAK], [BRUTOIZNOS], [BRUTOSATNICA], [BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT FROM [RADNIKBruto] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [BRUTOELEMENTIDELEMENT] = @BRUTOELEMENTIDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOELEMENTIDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKBrutoDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKBruto") }));
                }
                if ((!command.HasMoreRows || !this.m__BRUTOSATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1)))) || ((!this.m__BRUTOPOSTOTAKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__BRUTOIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || !this.m__BRUTOSATNICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))))
                {
                    reader.Close();
                    throw new RADNIKBrutoDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKBruto") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadnikizuzeceodovrhe()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [ZADSIFRAOPISAPLACANJAIZUZECE], [ZADOPISPLACANJAIZUZECE], [ZADTEKUCIIZUZECE], [ZADMOIZUZECE], [ZADPOIZUZECE], [ZADMZIZUZECE], [ZADPZIZUZECE], [ZADIZNOSIZUZECA], [BANKAZASTICENOIDBANKE] AS BANKAZASTICENOIDBANKE FROM [RADNIKIzuzeceOdOvrhe] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [BANKAZASTICENOIDBANKE] = @BANKAZASTICENOIDBANKE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BANKAZASTICENOIDBANKE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["BANKAZASTICENOIDBANKE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKIzuzeceOdOvrheDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKIzuzeceOdOvrhe") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADSIFRAOPISAPLACANJAIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADOPISPLACANJAIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADTEKUCIIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADMOIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADPOIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADMZIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADPZIZUZECEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || !this.m__ZADIZNOSIZUZECAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8)))))
                {
                    reader.Close();
                    throw new RADNIKIzuzeceOdOvrheDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKIzuzeceOdOvrhe") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadnikkrediti()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [DATUMUGOVORA], [ZADIZNOSRATEKREDITA], [ZADBROJRATAOBUSTAVE], [ZADUKUPNIZNOSKREDITA], [ZADVECOTPLACENOBROJRATA], [ZADVECOTPLACENOUKUPNIIZNOS], [KREDITAKTIVAN], [SIFRAOPISAPLACANJAKREDITOR], [OPISPLACANJAKREDITOR], [MOKREDITOR], [POKREDITOR], [MZKREDITOR], [PZKREDITOR], [PARTIJAKREDITASPECIFIKACIJA], [ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR FROM [RADNIKKrediti] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [ZADKREDITIIDKREDITOR] = @ZADKREDITIIDKREDITOR AND [DATUMUGOVORA] = @DATUMUGOVORA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADKREDITIIDKREDITOR", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"]));
                command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["DATUMUGOVORA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKKreditiDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKKrediti") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__ZADIZNOSRATEKREDITAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || ((!this.m__ZADBROJRATAOBUSTAVEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !this.m__ZADUKUPNIZNOSKREDITAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || (!this.m__ZADVECOTPLACENOBROJRATAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || !this.m__ZADVECOTPLACENOUKUPNIIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__KREDITAKTIVANOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 7)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJAKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJAKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTIJAKREDITASPECIFIKACIJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 14)))))
                {
                    reader.Close();
                    throw new RADNIKKreditiDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKKrediti") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadniklevel7()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [DODATNIKOEFICIJENT], [IDGRUPEKOEF] FROM [RADNIKLevel7] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [IDGRUPEKOEF] = @IDGRUPEKOEF ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDGRUPEKOEF"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKLevel7DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKLevel7") }));
                }
                if (!command.HasMoreRows || !this.m__DODATNIKOEFICIJENTOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1))))
                {
                    reader.Close();
                    throw new RADNIKLevel7DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKLevel7") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadnikneto()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [NETOSATI], [NETOSATNICA], [NETOPOSTOTAK], [NETOIZNOS], [NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT FROM [RADNIKNeto] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [NETOELEMENTIDELEMENT] = @NETOELEMENTIDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOELEMENTIDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOELEMENTIDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKNetoDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKNeto") }));
                }
                if ((!command.HasMoreRows || !this.m__NETOSATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1)))) || ((!this.m__NETOSATNICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__NETOPOSTOTAKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || !this.m__NETOIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))))
                {
                    reader.Close();
                    throw new RADNIKNetoDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKNeto") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadnikobustava()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [ZADIZNOSOBUSTAVE], [ZADPOSTOTAKOBUSTAVE], [ZADISPLACENOKASA], [ZADSALDOKASA], [OBUSTAVAAKTIVNA], [ZADPOSTOTNAODBRUTA], [ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA FROM [RADNIKObustava] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [ZADOBUSTAVAIDOBUSTAVA] = @ZADOBUSTAVAIDOBUSTAVA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAIDOBUSTAVA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKObustavaDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKObustava") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__ZADIZNOSOBUSTAVEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1)))) || ((!this.m__ZADPOSTOTAKOBUSTAVEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__ZADISPLACENOKASAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || (!this.m__ZADSALDOKASAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4))) || !this.m__OBUSTAVAAKTIVNAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 5))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !this.m__ZADPOSTOTNAODBRUTAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 6))))
                {
                    reader.Close();
                    throw new RADNIKObustavaDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKObustava") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadnikodbitak()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK FROM [RADNIKOdbitak] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = @OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKOdbitakDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKOdbitak") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new RADNIKOdbitakDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKOdbitak") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRadnikolaksica()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [ZADMZOLAKSICE], [ZADPZOLAKSICE], [ZADMOOLAKSICE], [ZADPOOLAKSICE], [ZADSIFRAOPISAPLACANJAOLAKSICE], [ZADOPISPLACANJAOLAKSICE], [ZADIZNOSOLAKSICE], [ZADPOJEDINACNIPOZIV], [ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE FROM [RADNIKOlaksica] WITH (UPDLOCK) WHERE [IDRADNIK] = @IDRADNIK AND [ZADOLAKSICEIDOLAKSICE] = @ZADOLAKSICEIDOLAKSICE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDOLAKSICE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["IDRADNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNIKOlaksicaDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNIKOlaksica") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADMZOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADPZOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADMOOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADPOOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADSIFRAOPISAPLACANJAOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADOPISPLACANJAOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!this.m__ZADIZNOSOLAKSICEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZADPOJEDINACNIPOZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8)))))
                {
                    reader.Close();
                    throw new RADNIKOlaksicaDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNIKOlaksica") }));
                }
                reader.Close();
            }
        }

        private void CheckUniqueIndexRadnik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [JMBG] FROM [RADNIK] WITH (NOLOCK) WHERE ( [JMBG] = @JMBG) and Not ( [IDRADNIK] = @IDRADNIK) ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["JMBG"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new IRADNIK15IndexAlreadyExistsException(string.Format(this.resourceManager.GetString("1004"), new object[] { "RADNIK", "JMBG" }));
            }
            reader.Close();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRadnik()
        {
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
        }

        private void CreateNewRowRadnikbruto()
        {
            this.rowRADNIKBruto = this.RADNIKSet.RADNIKBruto.NewRADNIKBrutoRow();
        }

        private void CreateNewRowRadnikizuzeceodovrhe()
        {
            this.rowRADNIKIzuzeceOdOvrhe = this.RADNIKSet.RADNIKIzuzeceOdOvrhe.NewRADNIKIzuzeceOdOvrheRow();
        }

        private void CreateNewRowRadnikkrediti()
        {
            this.rowRADNIKKrediti = this.RADNIKSet.RADNIKKrediti.NewRADNIKKreditiRow();
        }

        private void CreateNewRowRadniklevel7()
        {
            this.rowRADNIKLevel7 = this.RADNIKSet.RADNIKLevel7.NewRADNIKLevel7Row();
        }

        private void CreateNewRowRadnikneto()
        {
            this.rowRADNIKNeto = this.RADNIKSet.RADNIKNeto.NewRADNIKNetoRow();
        }

        private void CreateNewRowRadnikobustava()
        {
            this.rowRADNIKObustava = this.RADNIKSet.RADNIKObustava.NewRADNIKObustavaRow();
        }

        private void CreateNewRowRadnikodbitak()
        {
            this.rowRADNIKOdbitak = this.RADNIKSet.RADNIKOdbitak.NewRADNIKOdbitakRow();
        }

        private void CreateNewRowRadnikolaksica()
        {
            this.rowRADNIKOlaksica = this.RADNIKSet.RADNIKOlaksica.NewRADNIKOlaksicaRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnik();
            this.OnDeleteControlsRadnik();
            this.ProcessNestedLevelRadnikizuzeceodovrhe();
            this.ProcessNestedLevelRadniklevel7();
            this.ProcessNestedLevelRadnikkrediti();
            this.ProcessNestedLevelRadnikobustava();
            this.ProcessNestedLevelRadnikneto();
            this.ProcessNestedLevelRadnikbruto();
            this.ProcessNestedLevelRadnikolaksica();
            this.ProcessNestedLevelRadnikodbitak();
            this.AfterConfirmRadnik();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIK]  WHERE [IDRADNIK] = @IDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRadnik();
            }
            this.OnRADNIKUpdated(new RADNIKEventArgs(this.rowRADNIK, StatementType.Delete));
            this.rowRADNIK.Delete();
            this.sMode21 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode21;
        }

        private void DeleteRadnikbruto()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnikbruto();
            this.OnDeleteControlsRadnikbruto();
            this.AfterConfirmRadnikbruto();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKBruto]  WHERE [IDRADNIK] = @IDRADNIK AND [BRUTOELEMENTIDELEMENT] = @BRUTOELEMENTIDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOELEMENTIDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"]));
            command.ExecuteStmt();
            this.OnRADNIKBrutoUpdated(new RADNIKBrutoEventArgs(this.rowRADNIKBruto, StatementType.Delete));
            this.rowRADNIKBruto.Delete();
            this.sMode54 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode54;
        }

        private void DeleteRadnikizuzeceodovrhe()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnikizuzeceodovrhe();
            this.AfterConfirmRadnikizuzeceodovrhe();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKIzuzeceOdOvrhe]  WHERE [IDRADNIK] = @IDRADNIK AND [BANKAZASTICENOIDBANKE] = @BANKAZASTICENOIDBANKE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BANKAZASTICENOIDBANKE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["BANKAZASTICENOIDBANKE"]));
            command.ExecuteStmt();
            this.OnRADNIKIzuzeceOdOvrheUpdated(new RADNIKIzuzeceOdOvrheEventArgs(this.rowRADNIKIzuzeceOdOvrhe, StatementType.Delete));
            this.rowRADNIKIzuzeceOdOvrhe.Delete();
            this.sMode290 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode290;
        }

        private void DeleteRadnikkrediti()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnikkrediti();
            this.OnDeleteControlsRadnikkrediti();
            this.AfterConfirmRadnikkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKKrediti]  WHERE [IDRADNIK] = @IDRADNIK AND [ZADKREDITIIDKREDITOR] = @ZADKREDITIIDKREDITOR AND [DATUMUGOVORA] = @DATUMUGOVORA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADKREDITIIDKREDITOR", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["DATUMUGOVORA"]));
            command.ExecuteStmt();
            this.OnRADNIKKreditiUpdated(new RADNIKKreditiEventArgs(this.rowRADNIKKrediti, StatementType.Delete));
            this.rowRADNIKKrediti.Delete();
            this.sMode75 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode75;
        }

        private void DeleteRadniklevel7()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadniklevel7();
            this.OnDeleteControlsRadniklevel7();
            this.AfterConfirmRadniklevel7();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKLevel7]  WHERE [IDRADNIK] = @IDRADNIK AND [IDGRUPEKOEF] = @IDGRUPEKOEF", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDGRUPEKOEF"]));
            command.ExecuteStmt();
            this.OnRADNIKLevel7Updated(new RADNIKLevel7EventArgs(this.rowRADNIKLevel7, StatementType.Delete));
            this.rowRADNIKLevel7.Delete();
            this.sMode97 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode97;
        }

        private void DeleteRadnikneto()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnikneto();
            this.OnDeleteControlsRadnikneto();
            this.AfterConfirmRadnikneto();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKNeto]  WHERE [IDRADNIK] = @IDRADNIK AND [NETOELEMENTIDELEMENT] = @NETOELEMENTIDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOELEMENTIDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOELEMENTIDELEMENT"]));
            command.ExecuteStmt();
            this.OnRADNIKNetoUpdated(new RADNIKNetoEventArgs(this.rowRADNIKNeto, StatementType.Delete));
            this.rowRADNIKNeto.Delete();
            this.sMode56 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode56;
        }

        private void DeleteRadnikobustava()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnikobustava();
            this.OnDeleteControlsRadnikobustava();
            this.AfterConfirmRadnikobustava();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKObustava]  WHERE [IDRADNIK] = @IDRADNIK AND [ZADOBUSTAVAIDOBUSTAVA] = @ZADOBUSTAVAIDOBUSTAVA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAIDOBUSTAVA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"]));
            command.ExecuteStmt();
            this.OnRADNIKObustavaUpdated(new RADNIKObustavaEventArgs(this.rowRADNIKObustava, StatementType.Delete));
            this.rowRADNIKObustava.Delete();
            this.sMode59 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode59;
        }

        private void DeleteRadnikodbitak()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnikodbitak();
            this.OnDeleteControlsRadnikodbitak();
            this.AfterConfirmRadnikodbitak();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKOdbitak]  WHERE [IDRADNIK] = @IDRADNIK AND [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] = @OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"]));
            command.ExecuteStmt();
            this.OnRADNIKOdbitakUpdated(new RADNIKOdbitakEventArgs(this.rowRADNIKOdbitak, StatementType.Delete));
            this.rowRADNIKOdbitak.Delete();
            this.sMode22 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode22;
        }

        private void DeleteRadnikolaksica()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnikolaksica();
            this.OnDeleteControlsRadnikolaksica();
            this.AfterConfirmRadnikolaksica();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNIKOlaksica]  WHERE [IDRADNIK] = @IDRADNIK AND [ZADOLAKSICEIDOLAKSICE] = @ZADOLAKSICEIDOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDOLAKSICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"]));
            command.ExecuteStmt();
            this.OnRADNIKOlaksicaUpdated(new RADNIKOlaksicaEventArgs(this.rowRADNIKOlaksica, StatementType.Delete));
            this.rowRADNIKOlaksica.Delete();
            this.sMode23 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode23;
        }

        public virtual int Fill(RADNIKDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.RADNIKSet = dataSet;
                    this.LoadChildRadnik(0, -1);
                    dataSet.AcceptChanges();
                }
                finally
                {
                    this.Cleanup();
                }
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.RADNIKSet = (RADNIKDataSet) dataSet;
            if (this.RADNIKSet != null)
            {
                return this.Fill(this.RADNIKSet);
            }
            this.RADNIKSet = new RADNIKDataSet();
            this.Fill(this.RADNIKSet);
            dataSet.Merge(this.RADNIKSet);
            return 0;
        }

        public virtual int Fill(RADNIKDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNIK"]));
        }

        public virtual int Fill(RADNIKDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNIK"]));
        }

        public virtual int Fill(RADNIKDataSet dataSet, int iDRADNIK)
        {
            if (!this.FillByIDRADNIK(dataSet, iDRADNIK))
            {
                throw new RADNIKNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PRPLACEPRPLACEELEMENTIRADNIK") }));
            }
            return 0;
        }

        public virtual int FillByIDBANKE(RADNIKDataSet dataSet, int iDBANKE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDBANKE = iDBANKE;
            try
            {
                this.LoadByIDBANKE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDBENEFICIRANI(RADNIKDataSet dataSet, string iDBENEFICIRANI)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDBENEFICIRANI = iDBENEFICIRANI;
            try
            {
                this.LoadByIDBENEFICIRANI(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDBRACNOSTANJE(RADNIKDataSet dataSet, int iDBRACNOSTANJE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDBRACNOSTANJE = iDBRACNOSTANJE;
            try
            {
                this.LoadByIDBRACNOSTANJE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDDRZAVLJANSTVO(RADNIKDataSet dataSet, int iDDRZAVLJANSTVO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDDRZAVLJANSTVO = iDDRZAVLJANSTVO;
            try
            {
                this.LoadByIDDRZAVLJANSTVO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDIPIDENT(RADNIKDataSet dataSet, int iDIPIDENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDIPIDENT = iDIPIDENT;
            try
            {
                this.LoadByIDIPIDENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDORGDIO(RADNIKDataSet dataSet, int iDORGDIO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDORGDIO = iDORGDIO;
            try
            {
                this.LoadByIDORGDIO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDRADNIK(RADNIKDataSet dataSet, int iDRADNIK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDRADNIK = iDRADNIK;
            try
            {
                this.LoadByIDRADNIK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound21 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDRADNOMJESTO(RADNIKDataSet dataSet, int iDRADNOMJESTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDRADNOMJESTO = iDRADNOMJESTO;
            try
            {
                this.LoadByIDRADNOMJESTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDRADNOVRIJEME(RADNIKDataSet dataSet, int iDRADNOVRIJEME)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDRADNOVRIJEME = iDRADNOVRIJEME;
            try
            {
                this.LoadByIDRADNOVRIJEME(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDSPOL(RADNIKDataSet dataSet, int iDSPOL)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDSPOL = iDSPOL;
            try
            {
                this.LoadByIDSPOL(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDSTRUKA(RADNIKDataSet dataSet, int iDSTRUKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDSTRUKA = iDSTRUKA;
            try
            {
                this.LoadByIDSTRUKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDTITULA(RADNIKDataSet dataSet, int iDTITULA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDTITULA = iDTITULA;
            try
            {
                this.LoadByIDTITULA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDUGOVORORADU(RADNIKDataSet dataSet, int iDUGOVORORADU)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDUGOVORORADU = iDUGOVORORADU;
            try
            {
                this.LoadByIDUGOVORORADU(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByJMBG(RADNIKDataSet dataSet, string jMBG)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.JMBG = jMBG;
            try
            {
                this.LoadByJMBG(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByOPCINARADAIDOPCINE(RADNIKDataSet dataSet, string oPCINARADAIDOPCINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.OPCINARADAIDOPCINE = oPCINARADAIDOPCINE;
            try
            {
                this.LoadByOPCINARADAIDOPCINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByOPCINASTANOVANJAIDOPCINE(RADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.OPCINASTANOVANJAIDOPCINE = oPCINASTANOVANJAIDOPCINE;
            try
            {
                this.LoadByOPCINASTANOVANJAIDOPCINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.POTREBNASTRUCNASPREMAIDSTRUCNASPREMA = pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            try
            {
                this.LoadByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(RADNIKDataSet dataSet, int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            try
            {
                this.LoadByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            try
            {
                this.LoadByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(RADNIKDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            try
            {
                this.LoadChildRadnik(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDBANKE(RADNIKDataSet dataSet, int iDBANKE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDBANKE = iDBANKE;
            try
            {
                this.LoadByIDBANKE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDBENEFICIRANI(RADNIKDataSet dataSet, string iDBENEFICIRANI, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDBENEFICIRANI = iDBENEFICIRANI;
            try
            {
                this.LoadByIDBENEFICIRANI(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDBRACNOSTANJE(RADNIKDataSet dataSet, int iDBRACNOSTANJE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDBRACNOSTANJE = iDBRACNOSTANJE;
            try
            {
                this.LoadByIDBRACNOSTANJE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDDRZAVLJANSTVO(RADNIKDataSet dataSet, int iDDRZAVLJANSTVO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDDRZAVLJANSTVO = iDDRZAVLJANSTVO;
            try
            {
                this.LoadByIDDRZAVLJANSTVO(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDIPIDENT(RADNIKDataSet dataSet, int iDIPIDENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDIPIDENT = iDIPIDENT;
            try
            {
                this.LoadByIDIPIDENT(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDORGDIO(RADNIKDataSet dataSet, int iDORGDIO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDORGDIO = iDORGDIO;
            try
            {
                this.LoadByIDORGDIO(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRADNOMJESTO(RADNIKDataSet dataSet, int iDRADNOMJESTO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDRADNOMJESTO = iDRADNOMJESTO;
            try
            {
                this.LoadByIDRADNOMJESTO(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRADNOVRIJEME(RADNIKDataSet dataSet, int iDRADNOVRIJEME, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDRADNOVRIJEME = iDRADNOVRIJEME;
            try
            {
                this.LoadByIDRADNOVRIJEME(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDSPOL(RADNIKDataSet dataSet, int iDSPOL, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDSPOL = iDSPOL;
            try
            {
                this.LoadByIDSPOL(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDSTRUKA(RADNIKDataSet dataSet, int iDSTRUKA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDSTRUKA = iDSTRUKA;
            try
            {
                this.LoadByIDSTRUKA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDTITULA(RADNIKDataSet dataSet, int iDTITULA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDTITULA = iDTITULA;
            try
            {
                this.LoadByIDTITULA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDUGOVORORADU(RADNIKDataSet dataSet, int iDUGOVORORADU, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.IDUGOVORORADU = iDUGOVORORADU;
            try
            {
                this.LoadByIDUGOVORORADU(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByJMBG(RADNIKDataSet dataSet, string jMBG, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.JMBG = jMBG;
            try
            {
                this.LoadByJMBG(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByOPCINARADAIDOPCINE(RADNIKDataSet dataSet, string oPCINARADAIDOPCINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.OPCINARADAIDOPCINE = oPCINARADAIDOPCINE;
            try
            {
                this.LoadByOPCINARADAIDOPCINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByOPCINASTANOVANJAIDOPCINE(RADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.OPCINASTANOVANJAIDOPCINE = oPCINASTANOVANJAIDOPCINE;
            try
            {
                this.LoadByOPCINASTANOVANJAIDOPCINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.POTREBNASTRUCNASPREMAIDSTRUCNASPREMA = pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            try
            {
                this.LoadByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(RADNIKDataSet dataSet, int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            try
            {
                this.LoadByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNIKSet = dataSet;
            this.rowRADNIK = this.RADNIKSet.RADNIK.NewRADNIKRow();
            this.rowRADNIK.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            try
            {
                this.LoadByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            DataTable[] array = new DataTable[dataSet.Tables.Count + 1];
            dataSet.Tables.CopyTo(array, dataSet.Tables.Count);
            return array;
        }

        private void GetByPrimaryKey()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNIK], [AKTIVAN], [GODINESTAZAPRO], [MJESECISTAZAPRO], [DANISTAZAPRO], [PREZIME], [IME], [OIB], [JMBG], [DATUMRODJENJA], [ulica], [mjesto], [kucnibroj], [TEKUCI], [ZBIRNINETO], [SIFRAOPISAPLACANJANETO], [OPISPLACANJANETO], [TJEDNIFONDSATI], [KOEFICIJENT], [POSTOTAKOSLOBODJENJAODPOREZA], [UZIMAUOBZIROSNOVICEDOPRINOSA], [TJEDNIFONDSATISTAZ], [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], [GODINESTAZA], [MJESECISTAZA], [DANISTAZA], [DATUMPRESTANKARADNOGODNOSA], [BROJMIROVINSKOG], [BROJZDRAVSTVENOG], [MBO], [MO], [PBO], [RADNADOZVOLA], [ZAVRSENASKOLA], [UGOVOROD], [POCETAKRADA], [NAZIVPOSLA], [VRIJEMEPROBNOGRADA], [VRIJEMEPRIPRAVNICKOG], [VRIJEMESTRUCNI], [RADUINOZEMSTVU], [RADNASPOSOBNOST], [VRIJEMEMIROVANJARADNOGODNOSA], [RAZLOGPRESTANKA], [ZABRANANATJECANJA], [PRODUZENOMIROVINSKO], [RADNIKNAPOMENA], [IDBANKE], [IDBENEFICIRANI], [IDTITULA], [IDRADNOMJESTO], [IDSTRUKA], [IDBRACNOSTANJE], [IDORGDIO], [IDSPOL], [IDIPIDENT], [IDDRZAVLJANSTVO], [IDUGOVORORADU], [IDRADNOVRIJEME], [OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE, [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] AS POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound21 = 1;
                this.rowRADNIK["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRADNIK["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                this.rowRADNIK["GODINESTAZAPRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 2));
                this.rowRADNIK["MJESECISTAZAPRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 3));
                this.rowRADNIK["DANISTAZAPRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 4));
                this.rowRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowRADNIK["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowRADNIK["OIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowRADNIK["JMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowRADNIK["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 9));
                this.rowRADNIK["ulica"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowRADNIK["mjesto"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowRADNIK["kucnibroj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowRADNIK["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13));
                this.rowRADNIK["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 14));
                this.rowRADNIK["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15));
                this.rowRADNIK["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x10));
                this.rowRADNIK["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x11));
                this.rowRADNIK["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x12));
                this.rowRADNIK["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x13));
                this.rowRADNIK["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 20));
                this.rowRADNIK["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x15));
                this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x16));
                this.rowRADNIK["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x17));
                this.rowRADNIK["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x18));
                this.rowRADNIK["DANISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x19));
                this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x1a));
                this.rowRADNIK["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1b));
                this.rowRADNIK["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1c));
                this.rowRADNIK["MBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1d));
                this.rowRADNIK["MO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 30));
                this.rowRADNIK["PBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x1f));
                this.rowRADNIK["RADNADOZVOLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x20));
                this.rowRADNIK["ZAVRSENASKOLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x21));
                this.rowRADNIK["UGOVOROD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x22));
                this.rowRADNIK["POCETAKRADA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x23));
                this.rowRADNIK["NAZIVPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x24));
                this.rowRADNIK["VRIJEMEPROBNOGRADA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x25));
                this.rowRADNIK["VRIJEMEPRIPRAVNICKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x26));
                this.rowRADNIK["VRIJEMESTRUCNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x27));
                this.rowRADNIK["RADUINOZEMSTVU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 40));
                this.rowRADNIK["RADNASPOSOBNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x29));
                this.rowRADNIK["VRIJEMEMIROVANJARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2a));
                this.rowRADNIK["RAZLOGPRESTANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2b));
                this.rowRADNIK["ZABRANANATJECANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2c));
                this.rowRADNIK["PRODUZENOMIROVINSKO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2d));
                this.rowRADNIK["RADNIKNAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x2e));
                this.rowRADNIK["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x2f));
                this.rowRADNIK["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x30));
                this.rowRADNIK["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x31));
                this.rowRADNIK["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 50));
                this.rowRADNIK["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x33));
                this.rowRADNIK["IDBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x34));
                this.rowRADNIK["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x35));
                this.rowRADNIK["IDSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x36));
                this.rowRADNIK["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x37));
                this.rowRADNIK["IDDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x38));
                this.rowRADNIK["IDUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x39));
                this.rowRADNIK["IDRADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3a));
                this.rowRADNIK["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x3b));
                this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 60));
                this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3d));
                this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3e));
                this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x3f));
                this.sMode21 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadRadnik();
                this.Gx_mode = this.sMode21;
            }
            else
            {
                this.RcdFound21 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDRADNIK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect19 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) ", false);
            this.RADNIKSelect19 = this.cmRADNIKSelect19.FetchData();
            if (this.RADNIKSelect19.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect19.GetInt32(0);
            }
            this.RADNIKSelect19.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDBANKE(int iDBANKE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect12 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (this.cmRADNIKSelect12.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmRADNIKSelect12.SetParameter(0, iDBANKE);
            this.RADNIKSelect12 = this.cmRADNIKSelect12.FetchData();
            if (this.RADNIKSelect12.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect12.GetInt32(0);
            }
            this.RADNIKSelect12.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDBENEFICIRANI(string iDBENEFICIRANI)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect11 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
            if (this.cmRADNIKSelect11.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            this.cmRADNIKSelect11.SetParameter(0, iDBENEFICIRANI);
            this.RADNIKSelect11 = this.cmRADNIKSelect11.FetchData();
            if (this.RADNIKSelect11.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect11.GetInt32(0);
            }
            this.RADNIKSelect11.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDBRACNOSTANJE(int iDBRACNOSTANJE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect6 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE ", false);
            if (this.cmRADNIKSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            this.cmRADNIKSelect6.SetParameter(0, iDBRACNOSTANJE);
            this.RADNIKSelect6 = this.cmRADNIKSelect6.FetchData();
            if (this.RADNIKSelect6.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect6.GetInt32(0);
            }
            this.RADNIKSelect6.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDDRZAVLJANSTVO(int iDDRZAVLJANSTVO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect17 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ", false);
            if (this.cmRADNIKSelect17.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect17.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            this.cmRADNIKSelect17.SetParameter(0, iDDRZAVLJANSTVO);
            this.RADNIKSelect17 = this.cmRADNIKSelect17.FetchData();
            if (this.RADNIKSelect17.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect17.GetInt32(0);
            }
            this.RADNIKSelect17.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDIPIDENT(int iDIPIDENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect14 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDIPIDENT] = @IDIPIDENT ", false);
            if (this.cmRADNIKSelect14.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            this.cmRADNIKSelect14.SetParameter(0, iDIPIDENT);
            this.RADNIKSelect14 = this.cmRADNIKSelect14.FetchData();
            if (this.RADNIKSelect14.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect14.GetInt32(0);
            }
            this.RADNIKSelect14.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDORGDIO(int iDORGDIO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect5 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
            if (this.cmRADNIKSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            this.cmRADNIKSelect5.SetParameter(0, iDORGDIO);
            this.RADNIKSelect5 = this.cmRADNIKSelect5.FetchData();
            if (this.RADNIKSelect5.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect5.GetInt32(0);
            }
            this.RADNIKSelect5.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRADNOMJESTO(int iDRADNOMJESTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect9 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
            if (this.cmRADNIKSelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            this.cmRADNIKSelect9.SetParameter(0, iDRADNOMJESTO);
            this.RADNIKSelect9 = this.cmRADNIKSelect9.FetchData();
            if (this.RADNIKSelect9.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect9.GetInt32(0);
            }
            this.RADNIKSelect9.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRADNOVRIJEME(int iDRADNOVRIJEME)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect18 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME ", false);
            if (this.cmRADNIKSelect18.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect18.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            this.cmRADNIKSelect18.SetParameter(0, iDRADNOVRIJEME);
            this.RADNIKSelect18 = this.cmRADNIKSelect18.FetchData();
            if (this.RADNIKSelect18.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect18.GetInt32(0);
            }
            this.RADNIKSelect18.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDSPOL(int iDSPOL)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect13 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (this.cmRADNIKSelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRADNIKSelect13.SetParameter(0, iDSPOL);
            this.RADNIKSelect13 = this.cmRADNIKSelect13.FetchData();
            if (this.RADNIKSelect13.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect13.GetInt32(0);
            }
            this.RADNIKSelect13.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDSTRUKA(int iDSTRUKA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect7 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
            if (this.cmRADNIKSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            this.cmRADNIKSelect7.SetParameter(0, iDSTRUKA);
            this.RADNIKSelect7 = this.cmRADNIKSelect7.FetchData();
            if (this.RADNIKSelect7.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect7.GetInt32(0);
            }
            this.RADNIKSelect7.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDTITULA(int iDTITULA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect10 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
            if (this.cmRADNIKSelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            this.cmRADNIKSelect10.SetParameter(0, iDTITULA);
            this.RADNIKSelect10 = this.cmRADNIKSelect10.FetchData();
            if (this.RADNIKSelect10.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect10.GetInt32(0);
            }
            this.RADNIKSelect10.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDUGOVORORADU(int iDUGOVORORADU)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect16 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [IDUGOVORORADU] = @IDUGOVORORADU ", false);
            if (this.cmRADNIKSelect16.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect16.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            this.cmRADNIKSelect16.SetParameter(0, iDUGOVORORADU);
            this.RADNIKSelect16 = this.cmRADNIKSelect16.FetchData();
            if (this.RADNIKSelect16.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect16.GetInt32(0);
            }
            this.RADNIKSelect16.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByJMBG(string jMBG)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [JMBG] = @JMBG ", false);
            if (this.cmRADNIKSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
            }
            this.cmRADNIKSelect1.SetParameter(0, jMBG);
            this.RADNIKSelect1 = this.cmRADNIKSelect1.FetchData();
            if (this.RADNIKSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect1.GetInt32(0);
            }
            this.RADNIKSelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (this.cmRADNIKSelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKSelect3.SetParameter(0, oPCINARADAIDOPCINE);
            this.RADNIKSelect3 = this.cmRADNIKSelect3.FetchData();
            if (this.RADNIKSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect3.GetInt32(0);
            }
            this.RADNIKSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (this.cmRADNIKSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKSelect4.SetParameter(0, oPCINASTANOVANJAIDOPCINE);
            this.RADNIKSelect4 = this.cmRADNIKSelect4.FetchData();
            if (this.RADNIKSelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect4.GetInt32(0);
            }
            this.RADNIKSelect4.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect8 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
            if (this.cmRADNIKSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKSelect8.SetParameter(0, pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.RADNIKSelect8 = this.cmRADNIKSelect8.FetchData();
            if (this.RADNIKSelect8.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect8.GetInt32(0);
            }
            this.RADNIKSelect8.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
            if (this.cmRADNIKSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            this.cmRADNIKSelect2.SetParameter(0, rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
            this.RADNIKSelect2 = this.cmRADNIKSelect2.FetchData();
            if (this.RADNIKSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect2.GetInt32(0);
            }
            this.RADNIKSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNIKSelect15 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNIK] WITH (NOLOCK) WHERE [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
            if (this.cmRADNIKSelect15.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect15.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKSelect15.SetParameter(0, tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.RADNIKSelect15 = this.cmRADNIKSelect15.FetchData();
            if (this.RADNIKSelect15.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNIKSelect15.GetInt32(0);
            }
            this.RADNIKSelect15.Close();
            return this.recordCount;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                this.InitializeMembers();
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        public virtual int GetRecordCountByIDBANKE(int iDBANKE)
        {
            int internalRecordCountByIDBANKE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDBANKE = this.GetInternalRecordCountByIDBANKE(iDBANKE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDBANKE;
        }

        public virtual int GetRecordCountByIDBENEFICIRANI(string iDBENEFICIRANI)
        {
            int internalRecordCountByIDBENEFICIRANI;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDBENEFICIRANI = this.GetInternalRecordCountByIDBENEFICIRANI(iDBENEFICIRANI);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDBENEFICIRANI;
        }

        public virtual int GetRecordCountByIDBRACNOSTANJE(int iDBRACNOSTANJE)
        {
            int internalRecordCountByIDBRACNOSTANJE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDBRACNOSTANJE = this.GetInternalRecordCountByIDBRACNOSTANJE(iDBRACNOSTANJE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDBRACNOSTANJE;
        }

        public virtual int GetRecordCountByIDDRZAVLJANSTVO(int iDDRZAVLJANSTVO)
        {
            int internalRecordCountByIDDRZAVLJANSTVO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDDRZAVLJANSTVO = this.GetInternalRecordCountByIDDRZAVLJANSTVO(iDDRZAVLJANSTVO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDDRZAVLJANSTVO;
        }

        public virtual int GetRecordCountByIDIPIDENT(int iDIPIDENT)
        {
            int internalRecordCountByIDIPIDENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDIPIDENT = this.GetInternalRecordCountByIDIPIDENT(iDIPIDENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDIPIDENT;
        }

        public virtual int GetRecordCountByIDORGDIO(int iDORGDIO)
        {
            int internalRecordCountByIDORGDIO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDORGDIO = this.GetInternalRecordCountByIDORGDIO(iDORGDIO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDORGDIO;
        }

        public virtual int GetRecordCountByIDRADNOMJESTO(int iDRADNOMJESTO)
        {
            int internalRecordCountByIDRADNOMJESTO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDRADNOMJESTO = this.GetInternalRecordCountByIDRADNOMJESTO(iDRADNOMJESTO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDRADNOMJESTO;
        }

        public virtual int GetRecordCountByIDRADNOVRIJEME(int iDRADNOVRIJEME)
        {
            int internalRecordCountByIDRADNOVRIJEME;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDRADNOVRIJEME = this.GetInternalRecordCountByIDRADNOVRIJEME(iDRADNOVRIJEME);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDRADNOVRIJEME;
        }

        public virtual int GetRecordCountByIDSPOL(int iDSPOL)
        {
            int internalRecordCountByIDSPOL;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDSPOL = this.GetInternalRecordCountByIDSPOL(iDSPOL);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDSPOL;
        }

        public virtual int GetRecordCountByIDSTRUKA(int iDSTRUKA)
        {
            int internalRecordCountByIDSTRUKA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDSTRUKA = this.GetInternalRecordCountByIDSTRUKA(iDSTRUKA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDSTRUKA;
        }

        public virtual int GetRecordCountByIDTITULA(int iDTITULA)
        {
            int internalRecordCountByIDTITULA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDTITULA = this.GetInternalRecordCountByIDTITULA(iDTITULA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDTITULA;
        }

        public virtual int GetRecordCountByIDUGOVORORADU(int iDUGOVORORADU)
        {
            int internalRecordCountByIDUGOVORORADU;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDUGOVORORADU = this.GetInternalRecordCountByIDUGOVORORADU(iDUGOVORORADU);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDUGOVORORADU;
        }

        public virtual int GetRecordCountByJMBG(string jMBG)
        {
            int internalRecordCountByJMBG;
            try
            {
                this.InitializeMembers();
                internalRecordCountByJMBG = this.GetInternalRecordCountByJMBG(jMBG);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByJMBG;
        }

        public virtual int GetRecordCountByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            int internalRecordCountByOPCINARADAIDOPCINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByOPCINARADAIDOPCINE = this.GetInternalRecordCountByOPCINARADAIDOPCINE(oPCINARADAIDOPCINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByOPCINARADAIDOPCINE;
        }

        public virtual int GetRecordCountByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            int internalRecordCountByOPCINASTANOVANJAIDOPCINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByOPCINASTANOVANJAIDOPCINE = this.GetInternalRecordCountByOPCINASTANOVANJAIDOPCINE(oPCINASTANOVANJAIDOPCINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByOPCINASTANOVANJAIDOPCINE;
        }

        public virtual int GetRecordCountByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            int internalRecordCountByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = this.GetInternalRecordCountByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
        }

        public virtual int GetRecordCountByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA)
        {
            int internalRecordCountByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = this.GetInternalRecordCountByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
        }

        public virtual int GetRecordCountByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA)
        {
            int internalRecordCountByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = this.GetInternalRecordCountByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound21 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_SPOJENOPREZIME = "";
            this.m__ZADSIFRAOPISAPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADOPISPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADTEKUCIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADMOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADPOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADMZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADPZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADIZNOSIZUZECAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove280 = false;
            this._Condition = false;
            this.RcdFound290 = 0;
            this.m_SubSelTopString290 = "";
            this.m__DODATNIKOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove276 = false;
            this.RcdFound97 = 0;
            this.m_SubSelTopString97 = "";
            this.m__ZADIZNOSOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADPOSTOTAKOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADISPLACENOKASAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADSALDOKASAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBUSTAVAAKTIVNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADPOSTOTNAODBRUTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove261 = false;
            this.RcdFound59 = 0;
            this.m_SubSelTopString59 = "";
            this.m__NETOSATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NETOSATNICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NETOPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NETOIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove246 = false;
            this.RcdFound56 = 0;
            this.m_SubSelTopString56 = "";
            this.m__BRUTOSATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BRUTOPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BRUTOIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BRUTOSATNICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove238 = false;
            this.RcdFound54 = 0;
            this.m_SubSelTopString54 = "";
            this.m__ZADIZNOSRATEKREDITAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADBROJRATAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADUKUPNIZNOSKREDITAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADVECOTPLACENOBROJRATAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADVECOTPLACENOUKUPNIIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KREDITAKTIVANOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTIJAKREDITASPECIFIKACIJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove214 = false;
            this.RcdFound75 = 0;
            this.m_SubSelTopString75 = "";
            this.m__ZADMZOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADPZOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADMOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADPOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADSIFRAOPISAPLACANJAOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADOPISPLACANJAOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADIZNOSOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZADPOJEDINACNIPOZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove193 = false;
            this.RcdFound23 = 0;
            this.m_SubSelTopString23 = "";
            this._Gxremove189 = false;
            this.RcdFound22 = 0;
            this.m_SubSelTopString22 = "";
            this.m__AKTIVANOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__GODINESTAZAPROOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MJESECISTAZAPROOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DANISTAZAPROOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PREZIMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OIBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__JMBGOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMRODJENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ulicaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__mjestoOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__kucnibrojOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TEKUCIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZBIRNINETOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TJEDNIFONDSATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POSTOTAKOSLOBODJENJAODPOREZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__UZIMAUOBZIROSNOVICEDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TJEDNIFONDSATISTAZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__GODINESTAZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MJESECISTAZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DANISTAZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMPRESTANKARADNOGODNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJMIROVINSKOGOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJZDRAVSTVENOGOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MBOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PBOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RADNADOZVOLAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZAVRSENASKOLAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__UGOVORODOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POCETAKRADAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVPOSLAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VRIJEMEPROBNOGRADAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VRIJEMEPRIPRAVNICKOGOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VRIJEMESTRUCNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RADUINOZEMSTVUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RADNASPOSOBNOSTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VRIJEMEMIROVANJARADNOGODNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RAZLOGPRESTANKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZABRANANATJECANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRODUZENOMIROVINSKOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RADNIKNAPOMENAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDBANKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDBENEFICIRANIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDTITULAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDRADNOMJESTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDSTRUKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDBRACNOSTANJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDORGDIOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDSPOLOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDIPIDENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDDRZAVLJANSTVOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDUGOVORORADUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDRADNOVRIJEMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPCINARADAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPCINASTANOVANJAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RADNIKSet = new RADNIKDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRadnik()
        {
            this.CheckOptimisticConcurrencyRadnik();
            this.CheckExtendedTableRadnik();
            this.AfterConfirmRadnik();
            string statement = " INSERT INTO [RADNIK] ([IDRADNIK], [AKTIVAN], [GODINESTAZAPRO], [MJESECISTAZAPRO], [DANISTAZAPRO], [PREZIME], [IME], [OIB], [JMBG], [DATUMRODJENJA], [ulica], [mjesto], [kucnibroj], [TEKUCI], [ZBIRNINETO], [SIFRAOPISAPLACANJANETO], [OPISPLACANJANETO], [TJEDNIFONDSATI], [KOEFICIJENT], [POSTOTAKOSLOBODJENJAODPOREZA], [UZIMAUOBZIROSNOVICEDOPRINOSA], [TJEDNIFONDSATISTAZ], [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI], [GODINESTAZA], [MJESECISTAZA], [DANISTAZA], [DATUMPRESTANKARADNOGODNOSA], [BROJMIROVINSKOG], [BROJZDRAVSTVENOG], [MBO], [MO], [PBO], [RADNADOZVOLA], [ZAVRSENASKOLA], [UGOVOROD], [POCETAKRADA], [NAZIVPOSLA], [VRIJEMEPROBNOGRADA], [VRIJEMEPRIPRAVNICKOG], [VRIJEMESTRUCNI], [RADUINOZEMSTVU], [RADNASPOSOBNOST], [VRIJEMEMIROVANJARADNOGODNOSA], [RAZLOGPRESTANKA], [ZABRANANATJECANJA], [PRODUZENOMIROVINSKO], [RADNIKNAPOMENA], [IDBANKE], [IDBENEFICIRANI], [IDTITULA], [IDRADNOMJESTO], [IDSTRUKA], [IDBRACNOSTANJE], [IDORGDIO], [IDSPOL], [IDIPIDENT], [IDDRZAVLJANSTVO], [IDUGOVORORADU], [IDRADNOVRIJEME], [OPCINARADAIDOPCINE], [OPCINASTANOVANJAIDOPCINE], [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA], [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA], [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) VALUES (@IDRADNIK, @AKTIVAN, @GODINESTAZAPRO, @MJESECISTAZAPRO, @DANISTAZAPRO, @PREZIME, @IME, @OIB, @JMBG, @DATUMRODJENJA, @ulica, @mjesto, @kucnibroj, @TEKUCI, @ZBIRNINETO, @SIFRAOPISAPLACANJANETO, @OPISPLACANJANETO, @TJEDNIFONDSATI, @KOEFICIJENT, @POSTOTAKOSLOBODJENJAODPOREZA, @UZIMAUOBZIROSNOVICEDOPRINOSA, @TJEDNIFONDSATISTAZ, @DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, @GODINESTAZA, @MJESECISTAZA, @DANISTAZA, @DATUMPRESTANKARADNOGODNOSA, @BROJMIROVINSKOG, @BROJZDRAVSTVENOG, @MBO, @MO, @PBO, @RADNADOZVOLA, @ZAVRSENASKOLA, @UGOVOROD, @POCETAKRADA, @NAZIVPOSLA, @VRIJEMEPROBNOGRADA, @VRIJEMEPRIPRAVNICKOG, @VRIJEMESTRUCNI,  @RADUINOZEMSTVU, @RADNASPOSOBNOST, @VRIJEMEMIROVANJARADNOGODNOSA, @RAZLOGPRESTANKA, @ZABRANANATJECANJA, @PRODUZENOMIROVINSKO, @RADNIKNAPOMENA, @IDBANKE, @IDBENEFICIRANI, @IDTITULA, @IDRADNOMJESTO, @IDSTRUKA, @IDBRACNOSTANJE, @IDORGDIO, @IDSPOL, @IDIPIDENT, @IDDRZAVLJANSTVO, @IDUGOVORORADU, @IDRADNOVRIJEME, @OPCINARADAIDOPCINE, @OPCINASTANOVANJAIDOPCINE, @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA)";
            ReadWriteCommand command = this.connDefault.GetCommand(statement, false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVAN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINESTAZAPRO", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISTAZAPRO", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DANISTAZAPRO", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OIB", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMRODJENJA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ulica", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesto", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kucnibroj", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TEKUCI", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZBIRNINETO", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJANETO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJANETO", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TJEDNIFONDSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTOTAKOSLOBODJENJAODPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UZIMAUOBZIROSNOVICEDOPRINOSA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TJEDNIFONDSATISTAZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINESTAZA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISTAZA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DANISTAZA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMPRESTANKARADNOGODNOSA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJMIROVINSKOG", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJZDRAVSTVENOG", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PBO", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNADOZVOLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSENASKOLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UGOVOROD", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETAKRADA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOSLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMEPROBNOGRADA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMEPRIPRAVNICKOG", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMESTRUCNI", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADUINOZEMSTVU", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNASPOSOBNOST", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMEMIROVANJARADNOGODNOSA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZLOGPRESTANKA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZABRANANATJECANJA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRODUZENOMIROVINSKO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKNAPOMENA", DbType.String));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIK["AKTIVAN"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZAPRO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZAPRO"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZAPRO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIK["PREZIME"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IME"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OIB"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRADNIK["JMBG"]));
            command.SetParameterDateObject(9, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMRODJENJA"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ulica"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRADNIK["mjesto"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRADNIK["kucnibroj"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TEKUCI"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZBIRNINETO"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowRADNIK["SIFRAOPISAPLACANJANETO"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPISPLACANJANETO"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATI"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowRADNIK["KOEFICIJENT"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POSTOTAKOSLOBODJENJAODPOREZA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowRADNIK["UZIMAUOBZIROSNOVICEDOPRINOSA"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATISTAZ"]));
            command.SetParameterDateObject(0x16, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"]));
            command.SetParameter(0x17, RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZA"]));
            command.SetParameter(0x18, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZA"]));
            command.SetParameter(0x19, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZA"]));
            command.SetParameterDateObject(0x1a, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"]));
            command.SetParameter(0x1b, RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJMIROVINSKOG"]));
            command.SetParameter(0x1c, RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJZDRAVSTVENOG"]));
            command.SetParameter(0x1d, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MBO"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MO"]));
            command.SetParameter(0x1f, RuntimeHelpers.GetObjectValue(this.rowRADNIK["PBO"]));
            command.SetParameter(0x20, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNADOZVOLA"]));
            command.SetParameter(0x21, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZAVRSENASKOLA"]));
            command.SetParameterDateObject(0x22, RuntimeHelpers.GetObjectValue(this.rowRADNIK["UGOVOROD"]));
            command.SetParameterDateObject(0x23, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POCETAKRADA"]));
            command.SetParameter(0x24, RuntimeHelpers.GetObjectValue(this.rowRADNIK["NAZIVPOSLA"]));
            command.SetParameter(0x25, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPROBNOGRADA"]));
            command.SetParameter(0x26, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPRIPRAVNICKOG"]));
            command.SetParameter(0x27, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMESTRUCNI"]));
            command.SetParameter(40, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADUINOZEMSTVU"]));
            command.SetParameter(0x29, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNASPOSOBNOST"]));
            command.SetParameter(0x2a, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEMIROVANJARADNOGODNOSA"]));
            command.SetParameter(0x2b, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RAZLOGPRESTANKA"]));
            command.SetParameter(0x2c, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZABRANANATJECANJA"]));
            command.SetParameter(0x2d, RuntimeHelpers.GetObjectValue(this.rowRADNIK["PRODUZENOMIROVINSKO"]));
            command.SetParameter(0x2e, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKNAPOMENA"]));
            command.SetParameter(0x2f, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]));
            command.SetParameter(0x30, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]));
            command.SetParameter(0x31, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]));
            command.SetParameter(50, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]));
            command.SetParameter(0x33, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]));
            command.SetParameter(0x34, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]));
            command.SetParameter(0x35, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]));
            command.SetParameter(0x36, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]));
            command.SetParameter(0x37, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]));
            command.SetParameter(0x38, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]));
            command.SetParameter(0x39, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]));
            command.SetParameter(0x3a, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOVRIJEME"]));
            command.SetParameter(0x3b, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]));
            command.SetParameter(60, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            command.SetParameter(0x3d, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(0x3e, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
            command.SetParameter(0x3f, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                this.CheckUniqueIndexRadnik();
                throw new RADNIKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRadnik();
            }
            this.OnRADNIKUpdated(new RADNIKEventArgs(this.rowRADNIK, StatementType.Insert));
            this.ProcessLevelRadnik();
        }

        private void InsertRadnikbruto()
        {
            this.CheckOptimisticConcurrencyRadnikbruto();
            this.CheckExtendedTableRadnikbruto();
            this.AfterConfirmRadnikbruto();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKBruto] ([IDRADNIK], [BRUTOSATI], [BRUTOPOSTOTAK], [BRUTOIZNOS], [BRUTOSATNICA], [BRUTOELEMENTIDELEMENT]) VALUES (@IDRADNIK, @BRUTOSATI, @BRUTOPOSTOTAK, @BRUTOIZNOS, @BRUTOSATNICA, @BRUTOELEMENTIDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOELEMENTIDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOPOSTOTAK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOIZNOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATNICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKBrutoDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNIKBrutoUpdated(new RADNIKBrutoEventArgs(this.rowRADNIKBruto, StatementType.Insert));
        }

        private void InsertRadnikizuzeceodovrhe()
        {
            this.CheckOptimisticConcurrencyRadnikizuzeceodovrhe();
            this.AfterConfirmRadnikizuzeceodovrhe();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKIzuzeceOdOvrhe] ([IDRADNIK], [ZADSIFRAOPISAPLACANJAIZUZECE], [ZADOPISPLACANJAIZUZECE], [ZADTEKUCIIZUZECE], [ZADMOIZUZECE], [ZADPOIZUZECE], [ZADMZIZUZECE], [ZADPZIZUZECE], [ZADIZNOSIZUZECA], [BANKAZASTICENOIDBANKE]) VALUES (@IDRADNIK, @ZADSIFRAOPISAPLACANJAIZUZECE, @ZADOPISPLACANJAIZUZECE, @ZADTEKUCIIZUZECE, @ZADMOIZUZECE, @ZADPOIZUZECE, @ZADMZIZUZECE, @ZADPZIZUZECE, @ZADIZNOSIZUZECA, @BANKAZASTICENOIDBANKE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADSIFRAOPISAPLACANJAIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOPISPLACANJAIZUZECE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADTEKUCIIZUZECE", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMOIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMZIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPZIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSIZUZECA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BANKAZASTICENOIDBANKE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADSIFRAOPISAPLACANJAIZUZECE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADOPISPLACANJAIZUZECE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADTEKUCIIZUZECE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMOIZUZECE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPOIZUZECE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMZIZUZECE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPZIZUZECE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADIZNOSIZUZECA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["BANKAZASTICENOIDBANKE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKIzuzeceOdOvrheDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRadnikizuzeceodovrhe();
            }
            this.OnRADNIKIzuzeceOdOvrheUpdated(new RADNIKIzuzeceOdOvrheEventArgs(this.rowRADNIKIzuzeceOdOvrhe, StatementType.Insert));
        }

        private void InsertRadnikkrediti()
        {
            this.CheckOptimisticConcurrencyRadnikkrediti();
            this.CheckExtendedTableRadnikkrediti();
            this.AfterConfirmRadnikkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKKrediti] ([IDRADNIK], [DATUMUGOVORA], [ZADIZNOSRATEKREDITA], [ZADBROJRATAOBUSTAVE], [ZADUKUPNIZNOSKREDITA], [ZADVECOTPLACENOBROJRATA], [ZADVECOTPLACENOUKUPNIIZNOS], [KREDITAKTIVAN], [SIFRAOPISAPLACANJAKREDITOR], [OPISPLACANJAKREDITOR], [MOKREDITOR], [POKREDITOR], [MZKREDITOR], [PZKREDITOR], [PARTIJAKREDITASPECIFIKACIJA], [ZADKREDITIIDKREDITOR]) VALUES (@IDRADNIK, @DATUMUGOVORA, @ZADIZNOSRATEKREDITA, @ZADBROJRATAOBUSTAVE, @ZADUKUPNIZNOSKREDITA, @ZADVECOTPLACENOBROJRATA, @ZADVECOTPLACENOUKUPNIIZNOS, @KREDITAKTIVAN, @SIFRAOPISAPLACANJAKREDITOR, @OPISPLACANJAKREDITOR, @MOKREDITOR, @POKREDITOR, @MZKREDITOR, @PZKREDITOR, @PARTIJAKREDITASPECIFIKACIJA, @ZADKREDITIIDKREDITOR)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSRATEKREDITA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADBROJRATAOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADUKUPNIZNOSKREDITA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADVECOTPLACENOBROJRATA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADVECOTPLACENOUKUPNIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KREDITAKTIVAN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKREDITOR", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTIJAKREDITASPECIFIKACIJA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADKREDITIIDKREDITOR", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["IDRADNIK"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["DATUMUGOVORA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADIZNOSRATEKREDITA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADBROJRATAOBUSTAVE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADUKUPNIZNOSKREDITA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOBROJRATA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOUKUPNIIZNOS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["KREDITAKTIVAN"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["SIFRAOPISAPLACANJAKREDITOR"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["OPISPLACANJAKREDITOR"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MOKREDITOR"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["POKREDITOR"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MZKREDITOR"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PZKREDITOR"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PARTIJAKREDITASPECIFIKACIJA"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKKreditiDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNIKKreditiUpdated(new RADNIKKreditiEventArgs(this.rowRADNIKKrediti, StatementType.Insert));
        }

        private void InsertRadniklevel7()
        {
            this.CheckOptimisticConcurrencyRadniklevel7();
            this.CheckExtendedTableRadniklevel7();
            this.AfterConfirmRadniklevel7();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKLevel7] ([IDRADNIK], [DODATNIKOEFICIJENT], [IDGRUPEKOEF]) VALUES (@IDRADNIK, @DODATNIKOEFICIJENT, @IDGRUPEKOEF)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DODATNIKOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["DODATNIKOEFICIJENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDGRUPEKOEF"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKLevel7DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNIKLevel7Updated(new RADNIKLevel7EventArgs(this.rowRADNIKLevel7, StatementType.Insert));
        }

        private void InsertRadnikneto()
        {
            this.CheckOptimisticConcurrencyRadnikneto();
            this.CheckExtendedTableRadnikneto();
            this.AfterConfirmRadnikneto();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKNeto] ([IDRADNIK], [NETOSATI], [NETOSATNICA], [NETOPOSTOTAK], [NETOIZNOS], [NETOELEMENTIDELEMENT]) VALUES (@IDRADNIK, @NETOSATI, @NETOSATNICA, @NETOPOSTOTAK, @NETOIZNOS, @NETOELEMENTIDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOELEMENTIDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATNICA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOPOSTOTAK"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOIZNOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOELEMENTIDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKNetoDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNIKNetoUpdated(new RADNIKNetoEventArgs(this.rowRADNIKNeto, StatementType.Insert));
        }

        private void InsertRadnikobustava()
        {
            this.CheckOptimisticConcurrencyRadnikobustava();
            this.CheckExtendedTableRadnikobustava();
            this.AfterConfirmRadnikobustava();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKObustava] ([IDRADNIK], [ZADIZNOSOBUSTAVE], [ZADPOSTOTAKOBUSTAVE], [ZADISPLACENOKASA], [ZADSALDOKASA], [OBUSTAVAAKTIVNA], [ZADPOSTOTNAODBRUTA], [ZADOBUSTAVAIDOBUSTAVA]) VALUES (@IDRADNIK, @ZADIZNOSOBUSTAVE, @ZADPOSTOTAKOBUSTAVE, @ZADISPLACENOKASA, @ZADSALDOKASA, @OBUSTAVAAKTIVNA, @ZADPOSTOTNAODBRUTA, @ZADOBUSTAVAIDOBUSTAVA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOSTOTAKOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADISPLACENOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADSALDOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBUSTAVAAKTIVNA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOSTOTNAODBRUTA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAIDOBUSTAVA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADIZNOSOBUSTAVE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTAKOBUSTAVE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADISPLACENOKASA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADSALDOKASA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["OBUSTAVAAKTIVNA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTNAODBRUTA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKObustavaDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNIKObustavaUpdated(new RADNIKObustavaEventArgs(this.rowRADNIKObustava, StatementType.Insert));
        }

        private void InsertRadnikodbitak()
        {
            this.CheckOptimisticConcurrencyRadnikodbitak();
            this.CheckExtendedTableRadnikodbitak();
            this.AfterConfirmRadnikodbitak();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKOdbitak] ([IDRADNIK], [OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]) VALUES (@IDRADNIK, @OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKOdbitakDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNIKOdbitakUpdated(new RADNIKOdbitakEventArgs(this.rowRADNIKOdbitak, StatementType.Insert));
        }

        private void InsertRadnikolaksica()
        {
            this.CheckOptimisticConcurrencyRadnikolaksica();
            this.CheckExtendedTableRadnikolaksica();
            this.AfterConfirmRadnikolaksica();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNIKOlaksica] ([IDRADNIK], [ZADMZOLAKSICE], [ZADPZOLAKSICE], [ZADMOOLAKSICE], [ZADPOOLAKSICE], [ZADSIFRAOPISAPLACANJAOLAKSICE], [ZADOPISPLACANJAOLAKSICE], [ZADIZNOSOLAKSICE], [ZADPOJEDINACNIPOZIV], [ZADOLAKSICEIDOLAKSICE]) VALUES (@IDRADNIK, @ZADMZOLAKSICE, @ZADPZOLAKSICE, @ZADMOOLAKSICE, @ZADPOOLAKSICE, @ZADSIFRAOPISAPLACANJAOLAKSICE, @ZADOPISPLACANJAOLAKSICE, @ZADIZNOSOLAKSICE, @ZADPOJEDINACNIPOZIV, @ZADOLAKSICEIDOLAKSICE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMZOLAKSICE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPZOLAKSICE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMOOLAKSICE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOOLAKSICE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADSIFRAOPISAPLACANJAOLAKSICE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOPISPLACANJAOLAKSICE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSOLAKSICE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOJEDINACNIPOZIV", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDOLAKSICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["IDRADNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMZOLAKSICE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPZOLAKSICE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMOOLAKSICE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOOLAKSICE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADSIFRAOPISAPLACANJAOLAKSICE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOPISPLACANJAOLAKSICE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADIZNOSOLAKSICE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOJEDINACNIPOZIV"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNIKOlaksicaDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNIKOlaksicaUpdated(new RADNIKOlaksicaEventArgs(this.rowRADNIKOlaksica, StatementType.Insert));
        }

        private void LoadByIDBANKE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDBANKE(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDBENEFICIRANI(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDBENEFICIRANI(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDBRACNOSTANJE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDBRACNOSTANJE(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDDRZAVLJANSTVO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDDRZAVLJANSTVO(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDIPIDENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDIPIDENT(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDORGDIO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDORGDIO(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDRADNIK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDRADNIK(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDRADNOMJESTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDRADNOMJESTO(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDRADNOVRIJEME(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDRADNOVRIJEME(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDSPOL(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDSPOL(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDSTRUKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDSTRUKA(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDTITULA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDTITULA(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByIDUGOVORORADU(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByIDUGOVORORADU(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByJMBG(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByJMBG(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByOPCINARADAIDOPCINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByOPCINARADAIDOPCINE(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByOPCINASTANOVANJAIDOPCINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByOPCINASTANOVANJAIDOPCINE(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
            this.RADNIKSet.RADNIKLevel7.BeginLoadData();
            this.RADNIKSet.RADNIKObustava.BeginLoadData();
            this.RADNIKSet.RADNIKNeto.BeginLoadData();
            this.RADNIKSet.RADNIKBruto.BeginLoadData();
            this.RADNIKSet.RADNIKKrediti.BeginLoadData();
            this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
            this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
            this.RADNIKSet.RADNIK.BeginLoadData();
            this.ScanByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(startRow, maxRows);
            this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
            this.RADNIKSet.RADNIKLevel7.EndLoadData();
            this.RADNIKSet.RADNIKObustava.EndLoadData();
            this.RADNIKSet.RADNIKNeto.EndLoadData();
            this.RADNIKSet.RADNIKBruto.EndLoadData();
            this.RADNIKSet.RADNIKKrediti.EndLoadData();
            this.RADNIKSet.RADNIKOlaksica.EndLoadData();
            this.RADNIKSet.RADNIKOdbitak.EndLoadData();
            this.RADNIKSet.RADNIK.EndLoadData();
            this.RADNIKSet.EnforceConstraints = enforceConstraints;
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadChildRadnik(int startRow, int maxRows)
        {
            try//db - 28.01.2017 - bez ovog try-catch puca radi u RADNIKIzuzeceOdOvrhe jer neka od vrijednosti ne postiva constrainte. ps ovo NE puni mail
            {
                this.CreateNewRowRadnik();
                bool enforceConstraints = this.RADNIKSet.EnforceConstraints;
                this.RADNIKSet.RADNIKIzuzeceOdOvrhe.BeginLoadData();
                this.RADNIKSet.RADNIKLevel7.BeginLoadData();
                this.RADNIKSet.RADNIKObustava.BeginLoadData();
                this.RADNIKSet.RADNIKNeto.BeginLoadData();
                this.RADNIKSet.RADNIKBruto.BeginLoadData();
                this.RADNIKSet.RADNIKKrediti.BeginLoadData();
                this.RADNIKSet.RADNIKOlaksica.BeginLoadData();
                this.RADNIKSet.RADNIKOdbitak.BeginLoadData();
                this.RADNIKSet.RADNIK.BeginLoadData();
               
                this.ScanStartRadnik(startRow, maxRows);

                this.RADNIKSet.RADNIKIzuzeceOdOvrhe.EndLoadData();
                this.RADNIKSet.RADNIKLevel7.EndLoadData();
                this.RADNIKSet.RADNIKObustava.EndLoadData();
                this.RADNIKSet.RADNIKNeto.EndLoadData();
                this.RADNIKSet.RADNIKBruto.EndLoadData();
                this.RADNIKSet.RADNIKKrediti.EndLoadData();
                this.RADNIKSet.RADNIKOlaksica.EndLoadData();
                this.RADNIKSet.RADNIKOdbitak.EndLoadData();
                this.RADNIKSet.RADNIK.EndLoadData();
                this.RADNIKSet.EnforceConstraints = enforceConstraints;
            }
            catch { }
        }

        private void LoadChildRadnikbruto()
        {
            this.CreateNewRowRadnikbruto();
            this.ScanStartRadnikbruto();
        }

        private void LoadChildRadnikizuzeceodovrhe()
        {
            this.CreateNewRowRadnikizuzeceodovrhe();
            this.ScanStartRadnikizuzeceodovrhe();
        }

        private void LoadChildRadnikkrediti()
        {
            this.CreateNewRowRadnikkrediti();
            this.ScanStartRadnikkrediti();
        }

        private void LoadChildRadniklevel7()
        {
            this.CreateNewRowRadniklevel7();
            this.ScanStartRadniklevel7();
        }

        private void LoadChildRadnikneto()
        {
            this.CreateNewRowRadnikneto();
            this.ScanStartRadnikneto();
        }

        private void LoadChildRadnikobustava()
        {
            this.CreateNewRowRadnikobustava();
            this.ScanStartRadnikobustava();
        }

        private void LoadChildRadnikodbitak()
        {
            this.CreateNewRowRadnikodbitak();
            this.ScanStartRadnikodbitak();
        }

        private void LoadChildRadnikolaksica()
        {
            this.CreateNewRowRadnikolaksica();
            this.ScanStartRadnikolaksica();
        }

        private void LoadDataRadnik(int maxRows)
        {
            int num = 0;
            if (this.RcdFound21 != 0)
            {
                this.ScanLoadRadnik();
                while ((this.RcdFound21 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRadnik();
                    this.CreateNewRowRadnik();
                    this.ScanNextRadnik();
                }
            }
            if (num > 0)
            {
                this.RcdFound21 = 1;
            }
            this.ScanEndRadnik();
            if (this.RADNIKSet.RADNIK.Count > 0)
            {
                this.rowRADNIK = this.RADNIKSet.RADNIK[this.RADNIKSet.RADNIK.Count - 1];
            }
        }

        private void LoadDataRadnikbruto()
        {
            while (this.RcdFound54 != 0)
            {
                this.LoadRowRadnikbruto();
                this.CreateNewRowRadnikbruto();
                this.ScanNextRadnikbruto();
            }
            this.ScanEndRadnikbruto();
        }

        private void LoadDataRadnikizuzeceodovrhe()
        {
            while (this.RcdFound290 != 0)
            {
                this.LoadRowRadnikizuzeceodovrhe();
                this.CreateNewRowRadnikizuzeceodovrhe();
                this.ScanNextRadnikizuzeceodovrhe();
            }
            this.ScanEndRadnikizuzeceodovrhe();
        }

        private void LoadDataRadnikkrediti()
        {
            while (this.RcdFound75 != 0)
            {
                this.LoadRowRadnikkrediti();
                this.CreateNewRowRadnikkrediti();
                this.ScanNextRadnikkrediti();
            }
            this.ScanEndRadnikkrediti();
        }

        private void LoadDataRadniklevel7()
        {
            while (this.RcdFound97 != 0)
            {
                this.LoadRowRadniklevel7();
                this.CreateNewRowRadniklevel7();
                this.ScanNextRadniklevel7();
            }
            this.ScanEndRadniklevel7();
        }

        private void LoadDataRadnikneto()
        {
            while (this.RcdFound56 != 0)
            {
                this.LoadRowRadnikneto();
                this.CreateNewRowRadnikneto();
                this.ScanNextRadnikneto();
            }
            this.ScanEndRadnikneto();
        }

        private void LoadDataRadnikobustava()
        {
            while (this.RcdFound59 != 0)
            {
                this.LoadRowRadnikobustava();
                this.CreateNewRowRadnikobustava();
                this.ScanNextRadnikobustava();
            }
            this.ScanEndRadnikobustava();
        }

        private void LoadDataRadnikodbitak()
        {
            while (this.RcdFound22 != 0)
            {
                this.LoadRowRadnikodbitak();
                this.CreateNewRowRadnikodbitak();
                this.ScanNextRadnikodbitak();
            }
            this.ScanEndRadnikodbitak();
        }

        private void LoadDataRadnikolaksica()
        {
            while (this.RcdFound23 != 0)
            {
                this.LoadRowRadnikolaksica();
                this.CreateNewRowRadnikolaksica();
                this.ScanNextRadnikolaksica();
            }
            this.ScanEndRadnikolaksica();
        }

        private void LoadRadnik()
        {
            this.rowRADNIK.UKUPNIFAKTOR = placa.UkupnoFaktorOO(this.rowRADNIK.IDRADNIK, Configuration.ConnectionString.ToString());
            this.m_SPOJENOPREZIME = this.rowRADNIK.PREZIME + " " + this.rowRADNIK.IME;
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                this.rowRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0));
            }
            reader6.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                this.rowRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 0));
                this.rowRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader7, 1));
                this.rowRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 2));
                this.rowRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 3));
            }
            reader7.Close();
            ReadWriteCommand command10 = this.connDefault.GetCommand("SELECT [NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA FROM [SKUPPOREZAIDOPRINOSA] WITH (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
            if (command10.IDbCommand.Parameters.Count == 0)
            {
                command10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            command10.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
            IDataReader reader10 = command10.FetchData();
            if (command10.HasMoreRows)
            {
                this.rowRADNIK["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader10, 0));
            }
            reader10.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowRADNIK["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowRADNIK["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader2, 1));
            }
            reader2.Close();
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNODANASTAZA = placa.DaniStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOMJESECISTAZA = placa.MjeseciStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOGODINESTAZA = placa.GodineStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsIDTITULANull())
            {
                ReadWriteCommand command15 = this.connDefault.GetCommand("SELECT [NAZIVTITULA] FROM [TITULA] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                if (command15.IDbCommand.Parameters.Count == 0)
                {
                    command15.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                }
                command15.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]));
                IDataReader reader15 = command15.FetchData();
                if (command15.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader15, 0));
                }
                reader15.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVTITULA"] = "";
            }
            if (!this.rowRADNIK.IsIDRADNOMJESTONull())
            {
                ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                if (command9.IDbCommand.Parameters.Count == 0)
                {
                    command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                }
                command9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]));
                IDataReader reader9 = command9.FetchData();
                if (command9.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader9, 0));
                }
                reader9.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVRADNOMJESTO"] = "";
            }
            if (!this.rowRADNIK.IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command12 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command12.IDbCommand.Parameters.Count == 0)
                {
                    command12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command12.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader12 = command12.FetchData();
                if (command12.HasMoreRows)
                {
                    this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader12, 0));
                }
                reader12.Close();
            }
            else
            {
                this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIK.IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command13 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command13.IDbCommand.Parameters.Count == 0)
                {
                    command13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader13 = command13.FetchData();
                if (command13.HasMoreRows)
                {
                    this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader13, 0));
                }
                reader13.Close();
            }
            else
            {
                this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIK.IsIDSTRUKANull())
            {
                ReadWriteCommand command14 = this.connDefault.GetCommand("SELECT [NAZIVSTRUKA] FROM [STRUKA] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                if (command14.IDbCommand.Parameters.Count == 0)
                {
                    command14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                }
                command14.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]));
                IDataReader reader14 = command14.FetchData();
                if (command14.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader14, 0));
                }
                reader14.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVSTRUKA"] = "";
            }
            if (!this.rowRADNIK.IsIDBRACNOSTANJENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVBRACNOSTANJE] FROM [BRACNOSTANJE] WITH (NOLOCK) WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]));
                IDataReader reader3 = command3.FetchData();
                if (command3.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                }
                reader3.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVBRACNOSTANJE"] = "";
            }
            if (!this.rowRADNIK.IsIDORGDIONull())
            {
                ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT [ORGANIZACIJSKIDIO] FROM [ORGDIO] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                if (command8.IDbCommand.Parameters.Count == 0)
                {
                    command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                }
                command8.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]));
                IDataReader reader8 = command8.FetchData();
                if (command8.HasMoreRows)
                {
                    this.rowRADNIK["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader8, 0));
                }
                reader8.Close();
            }
            else
            {
                this.rowRADNIK["ORGANIZACIJSKIDIO"] = "";
            }
            if (!this.rowRADNIK.IsIDDRZAVLJANSTVONull())
            {
                ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVDRZAVLJANSTVO] FROM [DRZAVLJANSTVO] WITH (NOLOCK) WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ", false);
                if (command4.IDbCommand.Parameters.Count == 0)
                {
                    command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
                }
                command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]));
                IDataReader reader4 = command4.FetchData();
                if (command4.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0));
                }
                reader4.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = "";
            }
            if (!this.rowRADNIK.IsIDUGOVORORADUNull())
            {
                ReadWriteCommand command16 = this.connDefault.GetCommand("SELECT [NAZIVUGOVORORADU] FROM [UGOVORORADU] WITH (NOLOCK) WHERE [IDUGOVORORADU] = @IDUGOVORORADU ", false);
                if (command16.IDbCommand.Parameters.Count == 0)
                {
                    command16.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
                }
                command16.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]));
                IDataReader reader16 = command16.FetchData();
                if (command16.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader16, 0));
                }
                reader16.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVUGOVORORADU"] = "";
            }
            ReadWriteCommand command11 = this.connDefault.GetCommand("SELECT [NAZIVSPOL] FROM [SPOL] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (command11.IDbCommand.Parameters.Count == 0)
            {
                command11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command11.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]));
            IDataReader reader11 = command11.FetchData();
            if (command11.HasMoreRows)
            {
                this.rowRADNIK["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader11, 0));
            }
            reader11.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVIPIDENT] FROM [IPIDENT] WITH (NOLOCK) WHERE [IDIPIDENT] = @IDIPIDENT ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                this.rowRADNIK["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0));
            }
            reader5.Close();
        }

        private void LoadRowRadnik()
        {
            this.OnLoadActionsRadnik();
            this.AddRowRadnik();
        }

        private void LoadRowRadnikbruto()
        {
            this.AddRowRadnikbruto();
        }

        private void LoadRowRadnikizuzeceodovrhe()
        {
            this.AddRowRadnikizuzeceodovrhe();
        }

        private void LoadRowRadnikkrediti()
        {
            this.OnLoadActionsRadnikkrediti();
            this.AddRowRadnikkrediti();
        }

        private void LoadRowRadniklevel7()
        {
            this.AddRowRadniklevel7();
        }

        private void LoadRowRadnikneto()
        {
            this.AddRowRadnikneto();
        }

        private void LoadRowRadnikobustava()
        {
            this.OnLoadActionsRadnikobustava();
            this.AddRowRadnikobustava();
        }

        private void LoadRowRadnikodbitak()
        {
            this.AddRowRadnikodbitak();
        }

        private void LoadRowRadnikolaksica()
        {
            this.AddRowRadnikolaksica();
        }

        private void OnDeleteControlsRadnik()
        {
            this.rowRADNIK.UKUPNIFAKTOR = placa.UkupnoFaktorOO(this.rowRADNIK.IDRADNIK, Configuration.ConnectionString.ToString());
            this.m_SPOJENOPREZIME = this.rowRADNIK.PREZIME + " " + this.rowRADNIK.IME;
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINARADANAZIVOPCINE FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINARADAIDOPCINE ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                this.rowRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0));
            }
            reader6.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT [NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, [PRIREZ] AS OPCINASTANOVANJAPRIREZ, [VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, [ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA FROM [OPCINA] WITH (NOLOCK) WHERE [IDOPCINE] = @OPCINASTANOVANJAIDOPCINE ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                this.rowRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 0));
                this.rowRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader7, 1));
                this.rowRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 2));
                this.rowRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader7, 3));
            }
            reader7.Close();
            ReadWriteCommand command10 = this.connDefault.GetCommand("SELECT [NAZIVSKUPPOREZAIDOPRINOSA] AS RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA FROM [SKUPPOREZAIDOPRINOSA] WITH (NOLOCK) WHERE [IDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA ", false);
            if (command10.IDbCommand.Parameters.Count == 0)
            {
                command10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            command10.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
            IDataReader reader10 = command10.FetchData();
            if (command10.HasMoreRows)
            {
                this.rowRADNIK["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader10, 0));
            }
            reader10.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowRADNIK["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowRADNIK["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader2, 1));
            }
            reader2.Close();
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNODANASTAZA = placa.DaniStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOMJESECISTAZA = placa.MjeseciStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOGODINESTAZA = placa.GodineStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsIDTITULANull())
            {
                ReadWriteCommand command15 = this.connDefault.GetCommand("SELECT [NAZIVTITULA] FROM [TITULA] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                if (command15.IDbCommand.Parameters.Count == 0)
                {
                    command15.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                }
                command15.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]));
                IDataReader reader15 = command15.FetchData();
                if (command15.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader15, 0));
                }
                reader15.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVTITULA"] = "";
            }
            if (!this.rowRADNIK.IsIDRADNOMJESTONull())
            {
                ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                if (command9.IDbCommand.Parameters.Count == 0)
                {
                    command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                }
                command9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]));
                IDataReader reader9 = command9.FetchData();
                if (command9.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader9, 0));
                }
                reader9.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVRADNOMJESTO"] = "";
            }
            if (!this.rowRADNIK.IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command12 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command12.IDbCommand.Parameters.Count == 0)
                {
                    command12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command12.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader12 = command12.FetchData();
                if (command12.HasMoreRows)
                {
                    this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader12, 0));
                }
                reader12.Close();
            }
            else
            {
                this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIK.IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull())
            {
                ReadWriteCommand command13 = this.connDefault.GetCommand("SELECT [NAZIVSTRUCNASPREMA] AS POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA ", false);
                if (command13.IDbCommand.Parameters.Count == 0)
                {
                    command13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                }
                command13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
                IDataReader reader13 = command13.FetchData();
                if (command13.HasMoreRows)
                {
                    this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader13, 0));
                }
                reader13.Close();
            }
            else
            {
                this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIK.IsIDSTRUKANull())
            {
                ReadWriteCommand command14 = this.connDefault.GetCommand("SELECT [NAZIVSTRUKA] FROM [STRUKA] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                if (command14.IDbCommand.Parameters.Count == 0)
                {
                    command14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                }
                command14.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]));
                IDataReader reader14 = command14.FetchData();
                if (command14.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader14, 0));
                }
                reader14.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVSTRUKA"] = "";
            }
            if (!this.rowRADNIK.IsIDBRACNOSTANJENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVBRACNOSTANJE] FROM [BRACNOSTANJE] WITH (NOLOCK) WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]));
                IDataReader reader3 = command3.FetchData();
                if (command3.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                }
                reader3.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVBRACNOSTANJE"] = "";
            }
            if (!this.rowRADNIK.IsIDORGDIONull())
            {
                ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT [ORGANIZACIJSKIDIO] FROM [ORGDIO] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                if (command8.IDbCommand.Parameters.Count == 0)
                {
                    command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                }
                command8.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]));
                IDataReader reader8 = command8.FetchData();
                if (command8.HasMoreRows)
                {
                    this.rowRADNIK["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader8, 0));
                }
                reader8.Close();
            }
            else
            {
                this.rowRADNIK["ORGANIZACIJSKIDIO"] = "";
            }
            if (!this.rowRADNIK.IsIDDRZAVLJANSTVONull())
            {
                ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVDRZAVLJANSTVO] FROM [DRZAVLJANSTVO] WITH (NOLOCK) WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ", false);
                if (command4.IDbCommand.Parameters.Count == 0)
                {
                    command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
                }
                command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]));
                IDataReader reader4 = command4.FetchData();
                if (command4.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0));
                }
                reader4.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = "";
            }
            if (!this.rowRADNIK.IsIDUGOVORORADUNull())
            {
                ReadWriteCommand command16 = this.connDefault.GetCommand("SELECT [NAZIVUGOVORORADU] FROM [UGOVORORADU] WITH (NOLOCK) WHERE [IDUGOVORORADU] = @IDUGOVORORADU ", false);
                if (command16.IDbCommand.Parameters.Count == 0)
                {
                    command16.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
                }
                command16.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]));
                IDataReader reader16 = command16.FetchData();
                if (command16.HasMoreRows)
                {
                    this.rowRADNIK["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader16, 0));
                }
                reader16.Close();
            }
            else
            {
                this.rowRADNIK["NAZIVUGOVORORADU"] = "";
            }
            ReadWriteCommand command11 = this.connDefault.GetCommand("SELECT [NAZIVSPOL] FROM [SPOL] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (command11.IDbCommand.Parameters.Count == 0)
            {
                command11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command11.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]));
            IDataReader reader11 = command11.FetchData();
            if (command11.HasMoreRows)
            {
                this.rowRADNIK["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader11, 0));
            }
            reader11.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVIPIDENT] FROM [IPIDENT] WITH (NOLOCK) WHERE [IDIPIDENT] = @IDIPIDENT ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                this.rowRADNIK["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0));
            }
            reader5.Close();
        }

        private void OnDeleteControlsRadnikbruto()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, [POSTOTAK] AS BRUTOELEMENTPOSTOTAK FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @BRUTOELEMENTIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIKBruto["BRUTOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRADNIKBruto["BRUTOELEMENTPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
        }

        private void OnDeleteControlsRadnikkrediti()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, [PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, [PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, [PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, [VBDIKREDITOR] AS ZADKREDITIVBDIKREDITOR, [ZRNKREDITOR] AS ZADKREDITIZRNKREDITOR FROM [KREDITOR] WITH (NOLOCK) WHERE [IDKREDITOR] = @ZADKREDITIIDKREDITOR ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADKREDITIIDKREDITOR", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIKKrediti["ZADKREDITINAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowRADNIKKrediti["ZADKREDITIVBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowRADNIKKrediti["ZADKREDITIZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            }
            reader.Close();
            this.rowRADNIKKrediti.KREDITOTPLACENORATA = decimal.Add(new decimal(placa.Krediti_brojrata(this.rowRADNIKKrediti.IDRADNIK, this.rowRADNIKKrediti.ZADKREDITIIDKREDITOR, Configuration.ConnectionString.ToString(), this.rowRADNIKKrediti.DATUMUGOVORA)), this.rowRADNIKKrediti.ZADVECOTPLACENOBROJRATA);
            this.rowRADNIKKrediti.KREDITOTPLACENIIZNOS = decimal.Add(placa.Krediti_iznos(this.rowRADNIKKrediti.IDRADNIK, this.rowRADNIKKrediti.ZADKREDITIIDKREDITOR, Configuration.ConnectionString.ToString(), this.rowRADNIKKrediti.DATUMUGOVORA), this.rowRADNIKKrediti.ZADVECOTPLACENOUKUPNIIZNOS);
        }

        private void OnDeleteControlsRadniklevel7()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEKOEF] FROM [GRUPEKOEF] WITH (NOLOCK) WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDGRUPEKOEF"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIKLevel7["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsRadnikneto()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @NETOELEMENTIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOELEMENTIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIKNeto["NETOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsRadnikobustava()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, [ZRNOBUSTAVA] AS ZADOBUSTAVAZRNOBUSTAVA, [VBDIOBUSTAVA] AS ZADOBUSTAVAVBDIOBUSTAVA, [VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE FROM [OBUSTAVA] WITH (NOLOCK) WHERE [IDOBUSTAVA] = @ZADOBUSTAVAIDOBUSTAVA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAIDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRADNIKObustava["ZADOBUSTAVAZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowRADNIKObustava["ZADOBUSTAVAVBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowRADNIKObustava["ZADOBUSTAVAVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 3));
            }
            reader.Close();
            if (!this.rowRADNIKObustava.IsZADOBUSTAVAVRSTAOBUSTAVENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @ZADOBUSTAVAVRSTAOBUSTAVE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAVRSTAOBUSTAVE", DbType.Int16));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAVRSTAOBUSTAVE"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowRADNIKObustava["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                }
                reader2.Close();
            }
            else
            {
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            this.rowRADNIKObustava.OTPLACENIBROJRATA = placa.Obustave_BROJRATA(this.rowRADNIKObustava.IDRADNIK, this.rowRADNIKObustava.ZADOBUSTAVAIDOBUSTAVA, Configuration.ConnectionString.ToString());
            this.rowRADNIKObustava.OTPLACENIIZNOS = decimal.Add(placa.Obustave_Iznos(this.rowRADNIKObustava.IDRADNIK, this.rowRADNIKObustava.ZADOBUSTAVAIDOBUSTAVA, Configuration.ConnectionString.ToString()), this.rowRADNIKObustava.ZADSALDOKASA);
        }

        private void OnDeleteControlsRadnikodbitak()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSOBNIODBITAK], [FAKTOROSOBNOGODBITKA] FROM [OSOBNIODBITAK] WITH (NOLOCK) WHERE [IDOSOBNIODBITAK] = @OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRADNIKOdbitak["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 0));
                this.rowRADNIKOdbitak["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
        }

        private void OnDeleteControlsRadnikolaksica()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, [VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, [ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, [PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, [PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, [PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, [IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, [IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDOLAKSICE] = @ZADOLAKSICEIDOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                this.rowRADNIKOlaksica["ZADOLAKSICEVBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 1));
                this.rowRADNIKOlaksica["ZADOLAKSICEZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 2));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 3));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 4));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 5));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 6));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader2, 7));
            }
            reader2.Close();
            if (!this.rowRADNIKOlaksica.IsZADOLAKSICEIDGRUPEOLAKSICANull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, [NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @ZADOLAKSICEIDGRUPEOLAKSICA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDGRUPEOLAKSICA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDGRUPEOLAKSICA"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowRADNIKOlaksica["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
                    this.rowRADNIKOlaksica["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                }
                reader.Close();
            }
            else
            {
                this.rowRADNIKOlaksica["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (!this.rowRADNIKOlaksica.IsZADOLAKSICEIDTIPOLAKSICENull())
            {
                ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @ZADOLAKSICEIDTIPOLAKSICE ", false);
                if (command3.IDbCommand.Parameters.Count == 0)
                {
                    command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDTIPOLAKSICE", DbType.Int32));
                }
                command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDTIPOLAKSICE"]));
                IDataReader reader3 = command3.FetchData();
                if (command3.HasMoreRows)
                {
                    this.rowRADNIKOlaksica["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0));
                }
                reader3.Close();
            }
            else
            {
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
        }

        private void OnLoadActionsRadnik()
        {
            this.rowRADNIK.UKUPNIFAKTOR = placa.UkupnoFaktorOO(this.rowRADNIK.IDRADNIK, Configuration.ConnectionString.ToString());
            this.m_SPOJENOPREZIME = this.rowRADNIK.PREZIME + " " + this.rowRADNIK.IME;
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNODANASTAZA = placa.DaniStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOMJESECISTAZA = placa.MjeseciStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
            if (!this.rowRADNIK.IsBROJPRIZNATIHMJESECINull())
            {
                this.rowRADNIK.UKUPNOGODINESTAZA = placa.GodineStaza(new decimal(this.rowRADNIK.GODINESTAZA), new decimal(this.rowRADNIK.MJESECISTAZA), new decimal(this.rowRADNIK.DANISTAZA), this.rowRADNIK.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DateTime.Now, this.rowRADNIK.TJEDNIFONDSATISTAZ, 40M, new decimal(this.rowRADNIK.BROJPRIZNATIHMJESECI));
            }
        }

        private void OnLoadActionsRadnikkrediti()
        {
            this.rowRADNIKKrediti.KREDITOTPLACENIIZNOS = decimal.Add(placa.Krediti_iznos(this.rowRADNIKKrediti.IDRADNIK, this.rowRADNIKKrediti.ZADKREDITIIDKREDITOR, Configuration.ConnectionString.ToString(), this.rowRADNIKKrediti.DATUMUGOVORA), this.rowRADNIKKrediti.ZADVECOTPLACENOUKUPNIIZNOS);
            this.rowRADNIKKrediti.KREDITOTPLACENORATA = decimal.Add(new decimal(placa.Krediti_brojrata(this.rowRADNIKKrediti.IDRADNIK, this.rowRADNIKKrediti.ZADKREDITIIDKREDITOR, Configuration.ConnectionString.ToString(), this.rowRADNIKKrediti.DATUMUGOVORA)), this.rowRADNIKKrediti.ZADVECOTPLACENOBROJRATA);
        }

        private void OnLoadActionsRadnikobustava()
        {
            this.rowRADNIKObustava.OTPLACENIIZNOS = decimal.Add(placa.Obustave_Iznos(this.rowRADNIKObustava.IDRADNIK, this.rowRADNIKObustava.ZADOBUSTAVAIDOBUSTAVA, Configuration.ConnectionString.ToString()), this.rowRADNIKObustava.ZADSALDOKASA);
            this.rowRADNIKObustava.OTPLACENIBROJRATA = placa.Obustave_BROJRATA(this.rowRADNIKObustava.IDRADNIK, this.rowRADNIKObustava.ZADOBUSTAVAIDOBUSTAVA, Configuration.ConnectionString.ToString());
        }

        private void OnRADNIKBrutoUpdated(RADNIKBrutoEventArgs e)
        {
            if (this.RADNIKBrutoUpdated != null)
            {
                RADNIKBrutoUpdateEventHandler rADNIKBrutoUpdatedEvent = this.RADNIKBrutoUpdated;
                if (rADNIKBrutoUpdatedEvent != null)
                {
                    rADNIKBrutoUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKBrutoUpdating(RADNIKBrutoEventArgs e)
        {
            if (this.RADNIKBrutoUpdating != null)
            {
                RADNIKBrutoUpdateEventHandler rADNIKBrutoUpdatingEvent = this.RADNIKBrutoUpdating;
                if (rADNIKBrutoUpdatingEvent != null)
                {
                    rADNIKBrutoUpdatingEvent(this, e);
                }
            }
        }

        private void OnRADNIKIzuzeceOdOvrheUpdated(RADNIKIzuzeceOdOvrheEventArgs e)
        {
            if (this.RADNIKIzuzeceOdOvrheUpdated != null)
            {
                RADNIKIzuzeceOdOvrheUpdateEventHandler rADNIKIzuzeceOdOvrheUpdatedEvent = this.RADNIKIzuzeceOdOvrheUpdated;
                if (rADNIKIzuzeceOdOvrheUpdatedEvent != null)
                {
                    rADNIKIzuzeceOdOvrheUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKIzuzeceOdOvrheUpdating(RADNIKIzuzeceOdOvrheEventArgs e)
        {
            if (this.RADNIKIzuzeceOdOvrheUpdating != null)
            {
                RADNIKIzuzeceOdOvrheUpdateEventHandler rADNIKIzuzeceOdOvrheUpdatingEvent = this.RADNIKIzuzeceOdOvrheUpdating;
                if (rADNIKIzuzeceOdOvrheUpdatingEvent != null)
                {
                    rADNIKIzuzeceOdOvrheUpdatingEvent(this, e);
                }
            }
        }

        private void OnRADNIKKreditiUpdated(RADNIKKreditiEventArgs e)
        {
            if (this.RADNIKKreditiUpdated != null)
            {
                RADNIKKreditiUpdateEventHandler rADNIKKreditiUpdatedEvent = this.RADNIKKreditiUpdated;
                if (rADNIKKreditiUpdatedEvent != null)
                {
                    rADNIKKreditiUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKKreditiUpdating(RADNIKKreditiEventArgs e)
        {
            if (this.RADNIKKreditiUpdating != null)
            {
                RADNIKKreditiUpdateEventHandler rADNIKKreditiUpdatingEvent = this.RADNIKKreditiUpdating;
                if (rADNIKKreditiUpdatingEvent != null)
                {
                    rADNIKKreditiUpdatingEvent(this, e);
                }
            }
        }

        private void OnRADNIKLevel7Updated(RADNIKLevel7EventArgs e)
        {
            if (this.RADNIKLevel7Updated != null)
            {
                RADNIKLevel7UpdateEventHandler handler = this.RADNIKLevel7Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRADNIKLevel7Updating(RADNIKLevel7EventArgs e)
        {
            if (this.RADNIKLevel7Updating != null)
            {
                RADNIKLevel7UpdateEventHandler handler = this.RADNIKLevel7Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRADNIKNetoUpdated(RADNIKNetoEventArgs e)
        {
            if (this.RADNIKNetoUpdated != null)
            {
                RADNIKNetoUpdateEventHandler rADNIKNetoUpdatedEvent = this.RADNIKNetoUpdated;
                if (rADNIKNetoUpdatedEvent != null)
                {
                    rADNIKNetoUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKNetoUpdating(RADNIKNetoEventArgs e)
        {
            if (this.RADNIKNetoUpdating != null)
            {
                RADNIKNetoUpdateEventHandler rADNIKNetoUpdatingEvent = this.RADNIKNetoUpdating;
                if (rADNIKNetoUpdatingEvent != null)
                {
                    rADNIKNetoUpdatingEvent(this, e);
                }
            }
        }

        private void OnRADNIKObustavaUpdated(RADNIKObustavaEventArgs e)
        {
            if (this.RADNIKObustavaUpdated != null)
            {
                RADNIKObustavaUpdateEventHandler rADNIKObustavaUpdatedEvent = this.RADNIKObustavaUpdated;
                if (rADNIKObustavaUpdatedEvent != null)
                {
                    rADNIKObustavaUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKObustavaUpdating(RADNIKObustavaEventArgs e)
        {
            if (this.RADNIKObustavaUpdating != null)
            {
                RADNIKObustavaUpdateEventHandler rADNIKObustavaUpdatingEvent = this.RADNIKObustavaUpdating;
                if (rADNIKObustavaUpdatingEvent != null)
                {
                    rADNIKObustavaUpdatingEvent(this, e);
                }
            }
        }

        private void OnRADNIKOdbitakUpdated(RADNIKOdbitakEventArgs e)
        {
            if (this.RADNIKOdbitakUpdated != null)
            {
                RADNIKOdbitakUpdateEventHandler rADNIKOdbitakUpdatedEvent = this.RADNIKOdbitakUpdated;
                if (rADNIKOdbitakUpdatedEvent != null)
                {
                    rADNIKOdbitakUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKOdbitakUpdating(RADNIKOdbitakEventArgs e)
        {
            if (this.RADNIKOdbitakUpdating != null)
            {
                RADNIKOdbitakUpdateEventHandler rADNIKOdbitakUpdatingEvent = this.RADNIKOdbitakUpdating;
                if (rADNIKOdbitakUpdatingEvent != null)
                {
                    rADNIKOdbitakUpdatingEvent(this, e);
                }
            }
        }

        private void OnRADNIKOlaksicaUpdated(RADNIKOlaksicaEventArgs e)
        {
            if (this.RADNIKOlaksicaUpdated != null)
            {
                RADNIKOlaksicaUpdateEventHandler rADNIKOlaksicaUpdatedEvent = this.RADNIKOlaksicaUpdated;
                if (rADNIKOlaksicaUpdatedEvent != null)
                {
                    rADNIKOlaksicaUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKOlaksicaUpdating(RADNIKOlaksicaEventArgs e)
        {
            if (this.RADNIKOlaksicaUpdating != null)
            {
                RADNIKOlaksicaUpdateEventHandler rADNIKOlaksicaUpdatingEvent = this.RADNIKOlaksicaUpdating;
                if (rADNIKOlaksicaUpdatingEvent != null)
                {
                    rADNIKOlaksicaUpdatingEvent(this, e);
                }
            }
        }

        private void OnRADNIKUpdated(RADNIKEventArgs e)
        {
            if (this.RADNIKUpdated != null)
            {
                RADNIKUpdateEventHandler rADNIKUpdatedEvent = this.RADNIKUpdated;
                if (rADNIKUpdatedEvent != null)
                {
                    rADNIKUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNIKUpdating(RADNIKEventArgs e)
        {
            if (this.RADNIKUpdating != null)
            {
                RADNIKUpdateEventHandler rADNIKUpdatingEvent = this.RADNIKUpdating;
                if (rADNIKUpdatingEvent != null)
                {
                    rADNIKUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelRadnik()
        {
            this.sMode21 = this.Gx_mode;
            this.ProcessNestedLevelRadnikodbitak();
            this.ProcessNestedLevelRadnikolaksica();
            this.ProcessNestedLevelRadnikkrediti();
            this.ProcessNestedLevelRadnikbruto();
            this.ProcessNestedLevelRadnikneto();
            this.ProcessNestedLevelRadnikobustava();
            this.ProcessNestedLevelRadniklevel7();
            this.ProcessNestedLevelRadnikizuzeceodovrhe();
            this.Gx_mode = this.sMode21;
        }

        private void ProcessNestedLevelRadnikbruto()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKBruto.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKBruto = (RADNIKDataSet.RADNIKBrutoRow) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKBruto))
                    {
                        bool flag = false;
                        if (this.rowRADNIKBruto.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKBruto.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKBruto["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadnikbruto();
                            if (this.rowRADNIKBruto.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadnikbruto();
                            }
                            else
                            {
                                if (this._Gxremove238)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadnikbruto();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadnikbruto();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelRadnikizuzeceodovrhe()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKIzuzeceOdOvrhe.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKIzuzeceOdOvrhe = (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKIzuzeceOdOvrhe))
                    {
                        bool flag = false;
                        if (this.rowRADNIKIzuzeceOdOvrhe.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKIzuzeceOdOvrhe.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKIzuzeceOdOvrhe["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadnikizuzeceodovrhe();
                            if (this.rowRADNIKIzuzeceOdOvrhe.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadnikizuzeceodovrhe();
                            }
                            else
                            {
                                if (this._Gxremove280)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadnikizuzeceodovrhe();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadnikizuzeceodovrhe();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelRadnikkrediti()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKKrediti.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKKrediti = (RADNIKDataSet.RADNIKKreditiRow) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKKrediti))
                    {
                        bool flag = false;
                        if (this.rowRADNIKKrediti.RowState != DataRowState.Deleted)
                        {
                            this.rowRADNIKKrediti["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["DATUMUGOVORA"])));
                        }
                        if (this.rowRADNIKKrediti.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKKrediti.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKKrediti["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadnikkrediti();
                            if (this.rowRADNIKKrediti.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadnikkrediti();
                            }
                            else
                            {
                                if (this._Gxremove214)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadnikkrediti();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadnikkrediti();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelRadniklevel7()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKLevel7.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKLevel7 = (RADNIKDataSet.RADNIKLevel7Row) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKLevel7))
                    {
                        bool flag = false;
                        if (this.rowRADNIKLevel7.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKLevel7.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKLevel7["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadniklevel7();
                            if (this.rowRADNIKLevel7.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadniklevel7();
                            }
                            else
                            {
                                if (this._Gxremove276)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadniklevel7();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadniklevel7();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelRadnikneto()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKNeto.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKNeto = (RADNIKDataSet.RADNIKNetoRow) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKNeto))
                    {
                        bool flag = false;
                        if (this.rowRADNIKNeto.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKNeto.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKNeto["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadnikneto();
                            if (this.rowRADNIKNeto.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadnikneto();
                            }
                            else
                            {
                                if (this._Gxremove246)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadnikneto();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadnikneto();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelRadnikobustava()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKObustava.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKObustava = (RADNIKDataSet.RADNIKObustavaRow) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKObustava))
                    {
                        bool flag = false;
                        if (this.rowRADNIKObustava.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKObustava.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKObustava["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadnikobustava();
                            if (this.rowRADNIKObustava.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadnikobustava();
                            }
                            else
                            {
                                if (this._Gxremove261)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadnikobustava();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadnikobustava();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelRadnikodbitak()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKOdbitak.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKOdbitak = (RADNIKDataSet.RADNIKOdbitakRow) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKOdbitak))
                    {
                        bool flag = false;
                        if (this.rowRADNIKOdbitak.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKOdbitak.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKOdbitak["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadnikodbitak();
                            if (this.rowRADNIKOdbitak.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadnikodbitak();
                            }
                            else
                            {
                                if (this._Gxremove189)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadnikodbitak();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadnikodbitak();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ProcessNestedLevelRadnikolaksica()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RADNIKSet.RADNIKOlaksica.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRADNIKOlaksica = (RADNIKDataSet.RADNIKOlaksicaRow) current;
                    if (Helpers.IsRowChanged(this.rowRADNIKOlaksica))
                    {
                        bool flag = false;
                        if (this.rowRADNIKOlaksica.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowRADNIKOlaksica.IDRADNIK == this.rowRADNIK.IDRADNIK;
                        }
                        else
                        {
                            flag = this.rowRADNIKOlaksica["IDRADNIK", DataRowVersion.Original].Equals(this.rowRADNIK.IDRADNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowRadnikolaksica();
                            if (this.rowRADNIKOlaksica.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRadnikolaksica();
                            }
                            else
                            {
                                if (this._Gxremove193)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteRadnikolaksica();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRadnikolaksica();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ReadRowRadnik()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIK.RowState);
            if (this.rowRADNIK.RowState != DataRowState.Deleted)
            {
                this.rowRADNIK["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMRODJENJA"])));
                this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"])));
                this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"])));
                this.rowRADNIK["UGOVOROD"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRADNIK["UGOVOROD"])));
                this.rowRADNIK["POCETAKRADA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRADNIK["POCETAKRADA"])));
            }
            if (this.rowRADNIK.RowState != DataRowState.Added)
            {
                this.m__AKTIVANOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["AKTIVAN", DataRowVersion.Original]);
                this.m__GODINESTAZAPROOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZAPRO", DataRowVersion.Original]);
                this.m__MJESECISTAZAPROOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZAPRO", DataRowVersion.Original]);
                this.m__DANISTAZAPROOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZAPRO", DataRowVersion.Original]);
                this.m__PREZIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["PREZIME", DataRowVersion.Original]);
                this.m__IMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IME", DataRowVersion.Original]);
                this.m__OIBOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OIB", DataRowVersion.Original]);
                this.m__JMBGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["JMBG", DataRowVersion.Original]);
                this.m__DATUMRODJENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMRODJENJA", DataRowVersion.Original]);
                this.m__ulicaOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ulica", DataRowVersion.Original]);
                this.m__mjestoOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["mjesto", DataRowVersion.Original]);
                this.m__kucnibrojOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["kucnibroj", DataRowVersion.Original]);
                this.m__TEKUCIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TEKUCI", DataRowVersion.Original]);
                this.m__ZBIRNINETOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZBIRNINETO", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["SIFRAOPISAPLACANJANETO", DataRowVersion.Original]);
                this.m__OPISPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPISPLACANJANETO", DataRowVersion.Original]);
                this.m__TJEDNIFONDSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATI", DataRowVersion.Original]);
                this.m__KOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["KOEFICIJENT", DataRowVersion.Original]);
                this.m__POSTOTAKOSLOBODJENJAODPOREZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["POSTOTAKOSLOBODJENJAODPOREZA", DataRowVersion.Original]);
                this.m__UZIMAUOBZIROSNOVICEDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["UZIMAUOBZIROSNOVICEDOPRINOSA", DataRowVersion.Original]);
                this.m__TJEDNIFONDSATISTAZOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATISTAZ", DataRowVersion.Original]);
                this.m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", DataRowVersion.Original]);
                this.m__GODINESTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZA", DataRowVersion.Original]);
                this.m__MJESECISTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZA", DataRowVersion.Original]);
                this.m__DANISTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZA", DataRowVersion.Original]);
                this.m__DATUMPRESTANKARADNOGODNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA", DataRowVersion.Original]);
                this.m__BROJMIROVINSKOGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJMIROVINSKOG", DataRowVersion.Original]);
                this.m__BROJZDRAVSTVENOGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJZDRAVSTVENOG", DataRowVersion.Original]);
                this.m__MBOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MBO", DataRowVersion.Original]);
                this.m__MOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MO", DataRowVersion.Original]);
                this.m__PBOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["PBO", DataRowVersion.Original]);
                this.m__RADNADOZVOLAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNADOZVOLA", DataRowVersion.Original]);
                this.m__ZAVRSENASKOLAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZAVRSENASKOLA", DataRowVersion.Original]);
                this.m__UGOVORODOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["UGOVOROD", DataRowVersion.Original]);
                this.m__POCETAKRADAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["POCETAKRADA", DataRowVersion.Original]);
                this.m__NAZIVPOSLAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["NAZIVPOSLA", DataRowVersion.Original]);
                this.m__VRIJEMEPROBNOGRADAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPROBNOGRADA", DataRowVersion.Original]);
                this.m__VRIJEMEPRIPRAVNICKOGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPRIPRAVNICKOG", DataRowVersion.Original]);
                this.m__VRIJEMESTRUCNIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMESTRUCNI", DataRowVersion.Original]);
                this.m__RADUINOZEMSTVUOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADUINOZEMSTVU", DataRowVersion.Original]);
                this.m__RADNASPOSOBNOSTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNASPOSOBNOST", DataRowVersion.Original]);
                this.m__VRIJEMEMIROVANJARADNOGODNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEMIROVANJARADNOGODNOSA", DataRowVersion.Original]);
                this.m__RAZLOGPRESTANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RAZLOGPRESTANKA", DataRowVersion.Original]);
                this.m__ZABRANANATJECANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZABRANANATJECANJA", DataRowVersion.Original]);
                this.m__PRODUZENOMIROVINSKOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["PRODUZENOMIROVINSKO", DataRowVersion.Original]);
                this.m__RADNIKNAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKNAPOMENA", DataRowVersion.Original]);
                this.m__IDBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE", DataRowVersion.Original]);
                this.m__IDBENEFICIRANIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI", DataRowVersion.Original]);
                this.m__IDTITULAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA", DataRowVersion.Original]);
                this.m__IDRADNOMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO", DataRowVersion.Original]);
                this.m__IDSTRUKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA", DataRowVersion.Original]);
                this.m__IDBRACNOSTANJEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE", DataRowVersion.Original]);
                this.m__IDORGDIOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO", DataRowVersion.Original]);
                this.m__IDSPOLOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL", DataRowVersion.Original]);
                this.m__IDIPIDENTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT", DataRowVersion.Original]);
                this.m__IDDRZAVLJANSTVOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO", DataRowVersion.Original]);
                this.m__IDUGOVORORADUOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU", DataRowVersion.Original]);
                this.m__IDRADNOVRIJEMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOVRIJEME", DataRowVersion.Original]);
                this.m__OPCINARADAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE", DataRowVersion.Original]);
                this.m__OPCINASTANOVANJAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE", DataRowVersion.Original]);
                this.m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DataRowVersion.Original]);
                this.m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DataRowVersion.Original]);
                this.m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DataRowVersion.Original]);
            }
            else
            {
                this.m__AKTIVANOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["AKTIVAN"]);
                this.m__GODINESTAZAPROOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZAPRO"]);
                this.m__MJESECISTAZAPROOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZAPRO"]);
                this.m__DANISTAZAPROOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZAPRO"]);
                this.m__PREZIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["PREZIME"]);
                this.m__IMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IME"]);
                this.m__OIBOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OIB"]);
                this.m__JMBGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["JMBG"]);
                this.m__DATUMRODJENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMRODJENJA"]);
                this.m__ulicaOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ulica"]);
                this.m__mjestoOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["mjesto"]);
                this.m__kucnibrojOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["kucnibroj"]);
                this.m__TEKUCIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TEKUCI"]);
                this.m__ZBIRNINETOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZBIRNINETO"]);
                this.m__SIFRAOPISAPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["SIFRAOPISAPLACANJANETO"]);
                this.m__OPISPLACANJANETOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPISPLACANJANETO"]);
                this.m__TJEDNIFONDSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATI"]);
                this.m__KOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["KOEFICIJENT"]);
                this.m__POSTOTAKOSLOBODJENJAODPOREZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["POSTOTAKOSLOBODJENJAODPOREZA"]);
                this.m__UZIMAUOBZIROSNOVICEDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["UZIMAUOBZIROSNOVICEDOPRINOSA"]);
                this.m__TJEDNIFONDSATISTAZOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATISTAZ"]);
                this.m__DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"]);
                this.m__GODINESTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZA"]);
                this.m__MJESECISTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZA"]);
                this.m__DANISTAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZA"]);
                this.m__DATUMPRESTANKARADNOGODNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"]);
                this.m__BROJMIROVINSKOGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJMIROVINSKOG"]);
                this.m__BROJZDRAVSTVENOGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJZDRAVSTVENOG"]);
                this.m__MBOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MBO"]);
                this.m__MOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["MO"]);
                this.m__PBOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["PBO"]);
                this.m__RADNADOZVOLAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNADOZVOLA"]);
                this.m__ZAVRSENASKOLAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZAVRSENASKOLA"]);
                this.m__UGOVORODOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["UGOVOROD"]);
                this.m__POCETAKRADAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["POCETAKRADA"]);
                this.m__NAZIVPOSLAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["NAZIVPOSLA"]);
                this.m__VRIJEMEPROBNOGRADAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPROBNOGRADA"]);
                this.m__VRIJEMEPRIPRAVNICKOGOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPRIPRAVNICKOG"]);
                this.m__VRIJEMESTRUCNIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMESTRUCNI"]);
                this.m__RADUINOZEMSTVUOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADUINOZEMSTVU"]);
                this.m__RADNASPOSOBNOSTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNASPOSOBNOST"]);
                this.m__VRIJEMEMIROVANJARADNOGODNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEMIROVANJARADNOGODNOSA"]);
                this.m__RAZLOGPRESTANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RAZLOGPRESTANKA"]);
                this.m__ZABRANANATJECANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZABRANANATJECANJA"]);
                this.m__PRODUZENOMIROVINSKOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["PRODUZENOMIROVINSKO"]);
                this.m__RADNIKNAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKNAPOMENA"]);
                this.m__IDBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]);
                this.m__IDBENEFICIRANIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]);
                this.m__IDTITULAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]);
                this.m__IDRADNOMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]);
                this.m__IDSTRUKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]);
                this.m__IDBRACNOSTANJEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]);
                this.m__IDORGDIOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]);
                this.m__IDSPOLOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]);
                this.m__IDIPIDENTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]);
                this.m__IDDRZAVLJANSTVOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]);
                this.m__IDUGOVORORADUOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]);
                this.m__IDRADNOVRIJEMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOVRIJEME"]);
                this.m__OPCINARADAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]);
                this.m__OPCINASTANOVANJAIDOPCINEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]);
                this.m__RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]);
                this.m__POTREBNASTRUCNASPREMAIDSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]);
                this.m__TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]);
            }
            this._Gxremove = this.rowRADNIK.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRADNIK = (RADNIKDataSet.RADNIKRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIK);
            }
        }

        private void ReadRowRadnikbruto()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKBruto.RowState);
            if (this.rowRADNIKBruto.RowState != DataRowState.Added)
            {
                this.m__BRUTOSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATI", DataRowVersion.Original]);
                this.m__BRUTOPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOPOSTOTAK", DataRowVersion.Original]);
                this.m__BRUTOIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOIZNOS", DataRowVersion.Original]);
                this.m__BRUTOSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATNICA", DataRowVersion.Original]);
            }
            else
            {
                this.m__BRUTOSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATI"]);
                this.m__BRUTOPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOPOSTOTAK"]);
                this.m__BRUTOIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOIZNOS"]);
                this.m__BRUTOSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATNICA"]);
            }
            this._Gxremove238 = this.rowRADNIKBruto.RowState == DataRowState.Deleted;
            if (this._Gxremove238)
            {
                this.rowRADNIKBruto = (RADNIKDataSet.RADNIKBrutoRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKBruto);
            }
        }

        private void ReadRowRadnikizuzeceodovrhe()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKIzuzeceOdOvrhe.RowState);
            if (this.rowRADNIKIzuzeceOdOvrhe.RowState != DataRowState.Added)
            {
                this.m__ZADSIFRAOPISAPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADSIFRAOPISAPLACANJAIZUZECE", DataRowVersion.Original]);
                this.m__ZADOPISPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADOPISPLACANJAIZUZECE", DataRowVersion.Original]);
                this.m__ZADTEKUCIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADTEKUCIIZUZECE", DataRowVersion.Original]);
                this.m__ZADMOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMOIZUZECE", DataRowVersion.Original]);
                this.m__ZADPOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPOIZUZECE", DataRowVersion.Original]);
                this.m__ZADMZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMZIZUZECE", DataRowVersion.Original]);
                this.m__ZADPZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPZIZUZECE", DataRowVersion.Original]);
                this.m__ZADIZNOSIZUZECAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADIZNOSIZUZECA", DataRowVersion.Original]);
            }
            else
            {
                this.m__ZADSIFRAOPISAPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADSIFRAOPISAPLACANJAIZUZECE"]);
                this.m__ZADOPISPLACANJAIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADOPISPLACANJAIZUZECE"]);
                this.m__ZADTEKUCIIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADTEKUCIIZUZECE"]);
                this.m__ZADMOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMOIZUZECE"]);
                this.m__ZADPOIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPOIZUZECE"]);
                this.m__ZADMZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMZIZUZECE"]);
                this.m__ZADPZIZUZECEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPZIZUZECE"]);
                this.m__ZADIZNOSIZUZECAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADIZNOSIZUZECA"]);
            }
            this._Gxremove280 = this.rowRADNIKIzuzeceOdOvrhe.RowState == DataRowState.Deleted;
            if (this._Gxremove280)
            {
                this.rowRADNIKIzuzeceOdOvrhe = (RADNIKDataSet.RADNIKIzuzeceOdOvrheRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKIzuzeceOdOvrhe);
            }
        }

        private void ReadRowRadnikkrediti()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKKrediti.RowState);
            if (this.rowRADNIKKrediti.RowState != DataRowState.Added)
            {
                this.m__ZADIZNOSRATEKREDITAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADIZNOSRATEKREDITA", DataRowVersion.Original]);
                this.m__ZADBROJRATAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADBROJRATAOBUSTAVE", DataRowVersion.Original]);
                this.m__ZADUKUPNIZNOSKREDITAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADUKUPNIZNOSKREDITA", DataRowVersion.Original]);
                this.m__ZADVECOTPLACENOBROJRATAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOBROJRATA", DataRowVersion.Original]);
                this.m__ZADVECOTPLACENOUKUPNIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOUKUPNIIZNOS", DataRowVersion.Original]);
                this.m__KREDITAKTIVANOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["KREDITAKTIVAN", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["SIFRAOPISAPLACANJAKREDITOR", DataRowVersion.Original]);
                this.m__OPISPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["OPISPLACANJAKREDITOR", DataRowVersion.Original]);
                this.m__MOKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MOKREDITOR", DataRowVersion.Original]);
                this.m__POKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["POKREDITOR", DataRowVersion.Original]);
                this.m__MZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MZKREDITOR", DataRowVersion.Original]);
                this.m__PZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PZKREDITOR", DataRowVersion.Original]);
                this.m__PARTIJAKREDITASPECIFIKACIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PARTIJAKREDITASPECIFIKACIJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__ZADIZNOSRATEKREDITAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADIZNOSRATEKREDITA"]);
                this.m__ZADBROJRATAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADBROJRATAOBUSTAVE"]);
                this.m__ZADUKUPNIZNOSKREDITAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADUKUPNIZNOSKREDITA"]);
                this.m__ZADVECOTPLACENOBROJRATAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOBROJRATA"]);
                this.m__ZADVECOTPLACENOUKUPNIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOUKUPNIIZNOS"]);
                this.m__KREDITAKTIVANOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["KREDITAKTIVAN"]);
                this.m__SIFRAOPISAPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["SIFRAOPISAPLACANJAKREDITOR"]);
                this.m__OPISPLACANJAKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["OPISPLACANJAKREDITOR"]);
                this.m__MOKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MOKREDITOR"]);
                this.m__POKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["POKREDITOR"]);
                this.m__MZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MZKREDITOR"]);
                this.m__PZKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PZKREDITOR"]);
                this.m__PARTIJAKREDITASPECIFIKACIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PARTIJAKREDITASPECIFIKACIJA"]);
            }
            this._Gxremove214 = this.rowRADNIKKrediti.RowState == DataRowState.Deleted;
            if (this._Gxremove214)
            {
                this.rowRADNIKKrediti = (RADNIKDataSet.RADNIKKreditiRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKKrediti);
            }
        }

        private void ReadRowRadniklevel7()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKLevel7.RowState);
            if (this.rowRADNIKLevel7.RowState != DataRowState.Added)
            {
                this.m__DODATNIKOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["DODATNIKOEFICIJENT", DataRowVersion.Original]);
            }
            else
            {
                this.m__DODATNIKOEFICIJENTOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["DODATNIKOEFICIJENT"]);
            }
            this._Gxremove276 = this.rowRADNIKLevel7.RowState == DataRowState.Deleted;
            if (this._Gxremove276)
            {
                this.rowRADNIKLevel7 = (RADNIKDataSet.RADNIKLevel7Row) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKLevel7);
            }
        }

        private void ReadRowRadnikneto()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKNeto.RowState);
            if (this.rowRADNIKNeto.RowState != DataRowState.Added)
            {
                this.m__NETOSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATI", DataRowVersion.Original]);
                this.m__NETOSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATNICA", DataRowVersion.Original]);
                this.m__NETOPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOPOSTOTAK", DataRowVersion.Original]);
                this.m__NETOIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOIZNOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__NETOSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATI"]);
                this.m__NETOSATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATNICA"]);
                this.m__NETOPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOPOSTOTAK"]);
                this.m__NETOIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOIZNOS"]);
            }
            this._Gxremove246 = this.rowRADNIKNeto.RowState == DataRowState.Deleted;
            if (this._Gxremove246)
            {
                this.rowRADNIKNeto = (RADNIKDataSet.RADNIKNetoRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKNeto);
            }
        }

        private void ReadRowRadnikobustava()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKObustava.RowState);
            if (this.rowRADNIKObustava.RowState != DataRowState.Added)
            {
                this.m__ZADIZNOSOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADIZNOSOBUSTAVE", DataRowVersion.Original]);
                this.m__ZADPOSTOTAKOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTAKOBUSTAVE", DataRowVersion.Original]);
                this.m__ZADISPLACENOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADISPLACENOKASA", DataRowVersion.Original]);
                this.m__ZADSALDOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADSALDOKASA", DataRowVersion.Original]);
                this.m__OBUSTAVAAKTIVNAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["OBUSTAVAAKTIVNA", DataRowVersion.Original]);
                this.m__ZADPOSTOTNAODBRUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTNAODBRUTA", DataRowVersion.Original]);
            }
            else
            {
                this.m__ZADIZNOSOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADIZNOSOBUSTAVE"]);
                this.m__ZADPOSTOTAKOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTAKOBUSTAVE"]);
                this.m__ZADISPLACENOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADISPLACENOKASA"]);
                this.m__ZADSALDOKASAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADSALDOKASA"]);
                this.m__OBUSTAVAAKTIVNAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["OBUSTAVAAKTIVNA"]);
                this.m__ZADPOSTOTNAODBRUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTNAODBRUTA"]);
            }
            this._Gxremove261 = this.rowRADNIKObustava.RowState == DataRowState.Deleted;
            if (this._Gxremove261)
            {
                this.rowRADNIKObustava = (RADNIKDataSet.RADNIKObustavaRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKObustava);
            }
        }

        private void ReadRowRadnikodbitak()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKOdbitak.RowState);
            if (this.rowRADNIKOdbitak.RowState == DataRowState.Added)
            {
            }
            this._Gxremove189 = this.rowRADNIKOdbitak.RowState == DataRowState.Deleted;
            if (this._Gxremove189)
            {
                this.rowRADNIKOdbitak = (RADNIKDataSet.RADNIKOdbitakRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKOdbitak);
            }
        }

        private void ReadRowRadnikolaksica()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNIKOlaksica.RowState);
            if (this.rowRADNIKOlaksica.RowState != DataRowState.Added)
            {
                this.m__ZADMZOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMZOLAKSICE", DataRowVersion.Original]);
                this.m__ZADPZOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPZOLAKSICE", DataRowVersion.Original]);
                this.m__ZADMOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMOOLAKSICE", DataRowVersion.Original]);
                this.m__ZADPOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOOLAKSICE", DataRowVersion.Original]);
                this.m__ZADSIFRAOPISAPLACANJAOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADSIFRAOPISAPLACANJAOLAKSICE", DataRowVersion.Original]);
                this.m__ZADOPISPLACANJAOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOPISPLACANJAOLAKSICE", DataRowVersion.Original]);
                this.m__ZADIZNOSOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADIZNOSOLAKSICE", DataRowVersion.Original]);
                this.m__ZADPOJEDINACNIPOZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOJEDINACNIPOZIV", DataRowVersion.Original]);
            }
            else
            {
                this.m__ZADMZOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMZOLAKSICE"]);
                this.m__ZADPZOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPZOLAKSICE"]);
                this.m__ZADMOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMOOLAKSICE"]);
                this.m__ZADPOOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOOLAKSICE"]);
                this.m__ZADSIFRAOPISAPLACANJAOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADSIFRAOPISAPLACANJAOLAKSICE"]);
                this.m__ZADOPISPLACANJAOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOPISPLACANJAOLAKSICE"]);
                this.m__ZADIZNOSOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADIZNOSOLAKSICE"]);
                this.m__ZADPOJEDINACNIPOZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOJEDINACNIPOZIV"]);
            }
            this._Gxremove193 = this.rowRADNIKOlaksica.RowState == DataRowState.Deleted;
            if (this._Gxremove193)
            {
                this.rowRADNIKOlaksica = (RADNIKDataSet.RADNIKOlaksicaRow) DataSetUtil.CloneOriginalDataRow(this.rowRADNIKOlaksica);
            }
        }

        private void ScanByIDBANKE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBANKE] = @IDBANKE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBANKERadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDBENEFICIRANI(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBENEFICIRANI] = @IDBENEFICIRANI";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBENEFICIRANIRadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDBRACNOSTANJE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBRACNOSTANJE] = @IDBRACNOSTANJE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDBRACNOSTANJERadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDDRZAVLJANSTVO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDDRZAVLJANSTVORadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDIPIDENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDIPIDENT] = @IDIPIDENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDIPIDENTRadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDORGDIO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDORGDIO] = @IDORGDIO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDORGDIORadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDRADNIK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNIK] = @IDRADNIK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNIKRadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDRADNOMJESTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNOMJESTO] = @IDRADNOMJESTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOMJESTORadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDRADNOVRIJEME(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNOVRIJEME] = @IDRADNOVRIJEME";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOVRIJEME"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRADNOVRIJEMERadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDSPOL(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSPOL] = @IDSPOL";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSPOLRadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDSTRUKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSTRUKA] = @IDSTRUKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSTRUKARadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDTITULA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTITULA] = @IDTITULA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDTITULARadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByIDUGOVORORADU(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDUGOVORORADU] = @IDUGOVORORADU";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDUGOVORORADURadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByJMBG(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[JMBG] = @JMBG";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["JMBG"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersJMBGRadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByOPCINARADAIDOPCINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINARADAIDOPCINERadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByOPCINASTANOVANJAIDOPCINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersOPCINASTANOVANJAIDOPCINERadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] = @POTREBNASTRUCNASPREMAIDSTRUCNASPREMA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA] = @RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] = @TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNIKSelect23.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKSelect23.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRADNIKSelect23.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanEndRadnik()
        {
            this.RADNIKSelect23.Close();
        }

        private void ScanEndRadnikbruto()
        {
            this.RADNIKBrutoSelect2.Close();
        }

        private void ScanEndRadnikizuzeceodovrhe()
        {
            this.RADNIKIzuzeceOdOvrheSelect2.Close();
        }

        private void ScanEndRadnikkrediti()
        {
            this.RADNIKKreditiSelect2.Close();
        }

        private void ScanEndRadniklevel7()
        {
            this.RADNIKLevel7Select2.Close();
        }

        private void ScanEndRadnikneto()
        {
            this.RADNIKNetoSelect2.Close();
        }

        private void ScanEndRadnikobustava()
        {
            this.RADNIKObustavaSelect2.Close();
        }

        private void ScanEndRadnikodbitak()
        {
            this.RADNIKOdbitakSelect2.Close();
        }

        private void ScanEndRadnikolaksica()
        {
            this.RADNIKOlaksicaSelect2.Close();
        }

        private void ScanLoadRadnik()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKSelect23.HasMoreRows)
            {
                this.RcdFound21 = 1;
                this.rowRADNIK["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0));
                this.rowRADNIK["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.RADNIKSelect23, 1));
                this.rowRADNIK["GODINESTAZAPRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 2));
                this.rowRADNIK["MJESECISTAZAPRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 3));
                this.rowRADNIK["DANISTAZAPRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 4));
                this.rowRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 5));
                this.rowRADNIK["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 6));
                this.rowRADNIK["OIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 7));
                this.rowRADNIK["JMBG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 8));
                this.rowRADNIK["DATUMRODJENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RADNIKSelect23, 9));
                this.rowRADNIK["ulica"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 10));
                this.rowRADNIK["mjesto"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 11));
                this.rowRADNIK["kucnibroj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 12));
                this.rowRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 13));
                this.rowRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 14));
                this.rowRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKSelect23, 15));
                this.rowRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x10));
                this.rowRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x11));
                this.rowRADNIK["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x12));
                this.rowRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x13));
                this.rowRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 20));
                this.rowRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x15));
                this.rowRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x16));
                this.rowRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x17));
                this.rowRADNIK["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x18));
                this.rowRADNIK["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.RADNIKSelect23, 0x19));
                this.rowRADNIK["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x1a));
                this.rowRADNIK["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x1b));
                this.rowRADNIK["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKSelect23, 0x1c));
                this.rowRADNIK["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKSelect23, 0x1d));
                this.rowRADNIK["POSTOTAKOSLOBODJENJAODPOREZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKSelect23, 30));
                this.rowRADNIK["UZIMAUOBZIROSNOVICEDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.RADNIKSelect23, 0x1f));
                this.rowRADNIK["TJEDNIFONDSATISTAZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKSelect23, 0x20));
                this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RADNIKSelect23, 0x21));
                this.rowRADNIK["GODINESTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 0x22));
                this.rowRADNIK["MJESECISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 0x23));
                this.rowRADNIK["DANISTAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 0x24));
                this.rowRADNIK["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x25));
                this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RADNIKSelect23, 0x26));
                this.rowRADNIK["BROJMIROVINSKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x27));
                this.rowRADNIK["BROJZDRAVSTVENOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 40));
                this.rowRADNIK["MBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x29));
                this.rowRADNIK["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2a));
                this.rowRADNIK["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2b));
                this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2c));
                this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2d));
                this.rowRADNIK["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2e));
                this.rowRADNIK["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2f));
                this.rowRADNIK["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x30));
                this.rowRADNIK["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 0x31));
                this.rowRADNIK["MO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 50));
                this.rowRADNIK["PBO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x33));
                this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x34));
                this.rowRADNIK["RADNADOZVOLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x35));
                this.rowRADNIK["ZAVRSENASKOLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x36));
                this.rowRADNIK["UGOVOROD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RADNIKSelect23, 0x37));
                this.rowRADNIK["POCETAKRADA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RADNIKSelect23, 0x38));
                this.rowRADNIK["NAZIVPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x39));
                this.rowRADNIK["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x3a));
                this.rowRADNIK["VRIJEMEPROBNOGRADA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x3b));
                this.rowRADNIK["VRIJEMEPRIPRAVNICKOG"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 60));
                this.rowRADNIK["VRIJEMESTRUCNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x3d));
                this.rowRADNIK["RADUINOZEMSTVU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x3e));
                this.rowRADNIK["RADNASPOSOBNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x3f));
                this.rowRADNIK["VRIJEMEMIROVANJARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x40));
                this.rowRADNIK["RAZLOGPRESTANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x41));
                this.rowRADNIK["ZABRANANATJECANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x42));
                this.rowRADNIK["PRODUZENOMIROVINSKO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x43));
                this.rowRADNIK["RADNIKNAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x44));
                this.rowRADNIK["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x45));
                this.rowRADNIK["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 70));
                this.rowRADNIK["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x47));
                this.rowRADNIK["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x48));
                this.rowRADNIK["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x49));
                this.rowRADNIK["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x4a));
                this.rowRADNIK["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x4b));
                this.rowRADNIK["IDBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x4c));
                this.rowRADNIK["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x4d));
                this.rowRADNIK["IDSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x4e));
                this.rowRADNIK["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x4f));
                this.rowRADNIK["IDDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 80));
                this.rowRADNIK["IDUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x51));
                this.rowRADNIK["IDRADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x52));
                this.rowRADNIK["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x53));
                this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x54));
                this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x55));
                this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x56));
                this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKSelect23, 0x57));
                this.rowRADNIK["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 13));
                this.rowRADNIK["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 14));
                this.rowRADNIK["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKSelect23, 15));
                this.rowRADNIK["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x10));
                this.rowRADNIK["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x11));
                this.rowRADNIK["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x12));
                this.rowRADNIK["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x13));
                this.rowRADNIK["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 20));
                this.rowRADNIK["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x15));
                this.rowRADNIK["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x16));
                this.rowRADNIK["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x17));
                this.rowRADNIK["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x25));
                this.rowRADNIK["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKSelect23, 0x31));
                this.rowRADNIK["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2a));
                this.rowRADNIK["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2b));
                this.rowRADNIK["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2c));
                this.rowRADNIK["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2d));
                this.rowRADNIK["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2e));
                this.rowRADNIK["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x2f));
                this.rowRADNIK["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x30));
                this.rowRADNIK["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x34));
                this.rowRADNIK["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x3a));
                this.rowRADNIK["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 0x45));
                this.rowRADNIK["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKSelect23, 70));
            }
        }

        private void ScanLoadRadnikbruto()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKBrutoSelect2.HasMoreRows)
            {
                this.RcdFound54 = 1;
                this.rowRADNIKBruto["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKBrutoSelect2, 0));
                this.rowRADNIKBruto["BRUTOSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect2, 1));
                this.rowRADNIKBruto["BRUTOPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect2, 2));
                this.rowRADNIKBruto["BRUTOIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect2, 3));
                this.rowRADNIKBruto["BRUTOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKBrutoSelect2, 4));
                this.rowRADNIKBruto["BRUTOSATNICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect2, 5));
                this.rowRADNIKBruto["BRUTOELEMENTPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect2, 6));
                this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKBrutoSelect2, 7));
                this.rowRADNIKBruto["BRUTOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKBrutoSelect2, 4));
                this.rowRADNIKBruto["BRUTOELEMENTPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKBrutoSelect2, 6));
            }
        }

        private void ScanLoadRadnikizuzeceodovrhe()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKIzuzeceOdOvrheSelect2.HasMoreRows)
            {
                this.RcdFound290 = 1;
                this.rowRADNIKIzuzeceOdOvrhe["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKIzuzeceOdOvrheSelect2, 0));
                this.rowRADNIKIzuzeceOdOvrhe["ZADSIFRAOPISAPLACANJAIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect2, 1));
                this.rowRADNIKIzuzeceOdOvrhe["ZADOPISPLACANJAIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect2, 2));
                this.rowRADNIKIzuzeceOdOvrhe["ZADTEKUCIIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect2, 3));
                this.rowRADNIKIzuzeceOdOvrhe["ZADMOIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect2, 4));
                this.rowRADNIKIzuzeceOdOvrhe["ZADPOIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect2, 5));
                this.rowRADNIKIzuzeceOdOvrhe["ZADMZIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect2, 6));
                this.rowRADNIKIzuzeceOdOvrhe["ZADPZIZUZECE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKIzuzeceOdOvrheSelect2, 7));
                this.rowRADNIKIzuzeceOdOvrhe["ZADIZNOSIZUZECA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKIzuzeceOdOvrheSelect2, 8));
                this.rowRADNIKIzuzeceOdOvrhe["BANKAZASTICENOIDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKIzuzeceOdOvrheSelect2, 9));
            }
        }

        private void ScanLoadRadnikkrediti()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKKreditiSelect2.HasMoreRows)
            {
                this.RcdFound75 = 1;
                this.rowRADNIKKrediti["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKKreditiSelect2, 0));
                this.rowRADNIKKrediti["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RADNIKKreditiSelect2, 1));
                this.rowRADNIKKrediti["ZADIZNOSRATEKREDITA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect2, 2));
                this.rowRADNIKKrediti["ZADBROJRATAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect2, 3));
                this.rowRADNIKKrediti["ZADUKUPNIZNOSKREDITA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect2, 4));
                this.rowRADNIKKrediti["ZADVECOTPLACENOBROJRATA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect2, 5));
                this.rowRADNIKKrediti["ZADVECOTPLACENOUKUPNIIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKKreditiSelect2, 6));
                this.rowRADNIKKrediti["KREDITAKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.RADNIKKreditiSelect2, 7));
                this.rowRADNIKKrediti["ZADKREDITINAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 8));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 9));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 10));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 11));
                this.rowRADNIKKrediti["SIFRAOPISAPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 12));
                this.rowRADNIKKrediti["OPISPLACANJAKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 13));
                this.rowRADNIKKrediti["MOKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 14));
                this.rowRADNIKKrediti["POKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 15));
                this.rowRADNIKKrediti["MZKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 0x10));
                this.rowRADNIKKrediti["PZKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 0x11));
                this.rowRADNIKKrediti["ZADKREDITIVBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 0x12));
                this.rowRADNIKKrediti["ZADKREDITIZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 0x13));
                this.rowRADNIKKrediti["PARTIJAKREDITASPECIFIKACIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 20));
                this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKKreditiSelect2, 0x15));
                this.rowRADNIKKrediti["ZADKREDITINAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 8));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 9));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 10));
                this.rowRADNIKKrediti["ZADKREDITIPRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 11));
                this.rowRADNIKKrediti["ZADKREDITIVBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 0x12));
                this.rowRADNIKKrediti["ZADKREDITIZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKKreditiSelect2, 0x13));
            }
        }

        private void ScanLoadRadniklevel7()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKLevel7Select2.HasMoreRows)
            {
                this.RcdFound97 = 1;
                this.rowRADNIKLevel7["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKLevel7Select2, 0));
                this.rowRADNIKLevel7["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKLevel7Select2, 1));
                this.rowRADNIKLevel7["DODATNIKOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKLevel7Select2, 2));
                this.rowRADNIKLevel7["IDGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKLevel7Select2, 3));
                this.rowRADNIKLevel7["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKLevel7Select2, 1));
            }
        }

        private void ScanLoadRadnikneto()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKNetoSelect2.HasMoreRows)
            {
                this.RcdFound56 = 1;
                this.rowRADNIKNeto["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKNetoSelect2, 0));
                this.rowRADNIKNeto["NETOSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect2, 1));
                this.rowRADNIKNeto["NETOSATNICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect2, 2));
                this.rowRADNIKNeto["NETOPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect2, 3));
                this.rowRADNIKNeto["NETOIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKNetoSelect2, 4));
                this.rowRADNIKNeto["NETOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKNetoSelect2, 5));
                this.rowRADNIKNeto["NETOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKNetoSelect2, 6));
                this.rowRADNIKNeto["NETOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKNetoSelect2, 5));
            }
        }

        private void ScanLoadRadnikobustava()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKObustavaSelect2.HasMoreRows)
            {
                this.RcdFound59 = 1;
                this.rowRADNIKObustava["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKObustavaSelect2, 0));
                this.rowRADNIKObustava["ZADIZNOSOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect2, 1));
                this.rowRADNIKObustava["ZADPOSTOTAKOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect2, 2));
                this.rowRADNIKObustava["ZADISPLACENOKASA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect2, 3));
                this.rowRADNIKObustava["ZADSALDOKASA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKObustavaSelect2, 4));
                this.rowRADNIKObustava["OBUSTAVAAKTIVNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.RADNIKObustavaSelect2, 5));
                this.rowRADNIKObustava["ZADPOSTOTNAODBRUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.RADNIKObustavaSelect2, 6));
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 7));
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 8));
                this.rowRADNIKObustava["ZADOBUSTAVAZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 9));
                this.rowRADNIKObustava["ZADOBUSTAVAVBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 10));
                this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKObustavaSelect2, 11));
                this.rowRADNIKObustava["ZADOBUSTAVAVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKObustavaSelect2, 12));
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 7));
                this.rowRADNIKObustava["ZADOBUSTAVAZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 9));
                this.rowRADNIKObustava["ZADOBUSTAVAVBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 10));
                this.rowRADNIKObustava["ZADOBUSTAVAVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RADNIKObustavaSelect2, 12));
                this.rowRADNIKObustava["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKObustavaSelect2, 8));
            }
        }

        private void ScanLoadRadnikodbitak()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKOdbitakSelect2.HasMoreRows)
            {
                this.RcdFound22 = 1;
                this.rowRADNIKOdbitak["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOdbitakSelect2, 0));
                this.rowRADNIKOdbitak["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(this.RADNIKOdbitakSelect2, 1));
                this.rowRADNIKOdbitak["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKOdbitakSelect2, 2));
                this.rowRADNIKOdbitak["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOdbitakSelect2, 3));
                this.rowRADNIKOdbitak["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(this.RADNIKOdbitakSelect2, 1));
                this.rowRADNIKOdbitak["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKOdbitakSelect2, 2));
            }
        }

        private void ScanLoadRadnikolaksica()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNIKOlaksicaSelect2.HasMoreRows)
            {
                this.RcdFound23 = 1;
                this.rowRADNIKOlaksica["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect2, 0));
                this.rowRADNIKOlaksica["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKOlaksicaSelect2, 1));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 2));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 3));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 4));
                this.rowRADNIKOlaksica["ZADOLAKSICEVBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 5));
                this.rowRADNIKOlaksica["ZADOLAKSICEZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 6));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 7));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 8));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 9));
                this.rowRADNIKOlaksica["ZADMZOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 10));
                this.rowRADNIKOlaksica["ZADPZOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 11));
                this.rowRADNIKOlaksica["ZADMOOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 12));
                this.rowRADNIKOlaksica["ZADPOOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 13));
                this.rowRADNIKOlaksica["ZADSIFRAOPISAPLACANJAOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 14));
                this.rowRADNIKOlaksica["ZADOPISPLACANJAOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 15));
                this.rowRADNIKOlaksica["ZADIZNOSOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKOlaksicaSelect2, 0x10));
                this.rowRADNIKOlaksica["ZADPOJEDINACNIPOZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 0x11));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect2, 0x12));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect2, 0x13));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect2, 20));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 3));
                this.rowRADNIKOlaksica["ZADOLAKSICEVBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 5));
                this.rowRADNIKOlaksica["ZADOLAKSICEZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 6));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 7));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 8));
                this.rowRADNIKOlaksica["ZADOLAKSICEPRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 9));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect2, 0x13));
                this.rowRADNIKOlaksica["ZADOLAKSICEIDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNIKOlaksicaSelect2, 20));
                this.rowRADNIKOlaksica["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RADNIKOlaksicaSelect2, 1));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 2));
                this.rowRADNIKOlaksica["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNIKOlaksicaSelect2, 4));
            }
        }

        private void ScanNextRadnik()
        {
            this.cmRADNIKSelect23.HasMoreRows = this.RADNIKSelect23.Read();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
        }

        private void ScanNextRadnikbruto()
        {
            this.cmRADNIKBrutoSelect2.HasMoreRows = this.RADNIKBrutoSelect2.Read();
            this.RcdFound54 = 0;
            this.ScanLoadRadnikbruto();
        }

        private void ScanNextRadnikizuzeceodovrhe()
        {
            this.cmRADNIKIzuzeceOdOvrheSelect2.HasMoreRows = this.RADNIKIzuzeceOdOvrheSelect2.Read();
            this.RcdFound290 = 0;
            this.ScanLoadRadnikizuzeceodovrhe();
        }

        private void ScanNextRadnikkrediti()
        {
            this.cmRADNIKKreditiSelect2.HasMoreRows = this.RADNIKKreditiSelect2.Read();
            this.RcdFound75 = 0;
            this.ScanLoadRadnikkrediti();
        }

        private void ScanNextRadniklevel7()
        {
            this.cmRADNIKLevel7Select2.HasMoreRows = this.RADNIKLevel7Select2.Read();
            this.RcdFound97 = 0;
            this.ScanLoadRadniklevel7();
        }

        private void ScanNextRadnikneto()
        {
            this.cmRADNIKNetoSelect2.HasMoreRows = this.RADNIKNetoSelect2.Read();
            this.RcdFound56 = 0;
            this.ScanLoadRadnikneto();
        }

        private void ScanNextRadnikobustava()
        {
            this.cmRADNIKObustavaSelect2.HasMoreRows = this.RADNIKObustavaSelect2.Read();
            this.RcdFound59 = 0;
            this.ScanLoadRadnikobustava();
        }

        private void ScanNextRadnikodbitak()
        {
            this.cmRADNIKOdbitakSelect2.HasMoreRows = this.RADNIKOdbitakSelect2.Read();
            this.RcdFound22 = 0;
            this.ScanLoadRadnikodbitak();
        }

        private void ScanNextRadnikolaksica()
        {
            this.cmRADNIKOlaksicaSelect2.HasMoreRows = this.RADNIKOlaksicaSelect2.Read();
            this.RcdFound23 = 0;
            this.ScanLoadRadnikolaksica();
        }

        private void ScanStartRadnik(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString21 + "  FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString21, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK] ) AS DK_PAGENUM   FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString21 + " FROM (((((((((((((((([RADNIK] TM1 WITH (NOLOCK) INNER JOIN [OPCINA] T2 WITH (NOLOCK) ON T2.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) INNER JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) INNER JOIN [SKUPPOREZAIDOPRINOSA] T4 WITH (NOLOCK) ON T4.[IDSKUPPOREZAIDOPRINOSA] = TM1.[RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]) INNER JOIN [BANKE] T5 WITH (NOLOCK) ON T5.[IDBANKE] = TM1.[IDBANKE]) INNER JOIN [BENEFICIRANI] T6 WITH (NOLOCK) ON T6.[IDBENEFICIRANI] = TM1.[IDBENEFICIRANI]) LEFT JOIN [TITULA] T7 WITH (NOLOCK) ON T7.[IDTITULA] = TM1.[IDTITULA]) LEFT JOIN [RADNOMJESTO] T8 WITH (NOLOCK) ON T8.[IDRADNOMJESTO] = TM1.[IDRADNOMJESTO]) LEFT JOIN [STRUCNASPREMA] T9 WITH (NOLOCK) ON T9.[IDSTRUCNASPREMA] = TM1.[TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUCNASPREMA] T10 WITH (NOLOCK) ON T10.[IDSTRUCNASPREMA] = TM1.[POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]) LEFT JOIN [STRUKA] T11 WITH (NOLOCK) ON T11.[IDSTRUKA] = TM1.[IDSTRUKA]) LEFT JOIN [BRACNOSTANJE] T12 WITH (NOLOCK) ON T12.[IDBRACNOSTANJE] = TM1.[IDBRACNOSTANJE]) LEFT JOIN [ORGDIO] T13 WITH (NOLOCK) ON T13.[IDORGDIO] = TM1.[IDORGDIO]) LEFT JOIN [DRZAVLJANSTVO] T14 WITH (NOLOCK) ON T14.[IDDRZAVLJANSTVO] = TM1.[IDDRZAVLJANSTVO]) LEFT JOIN [UGOVORORADU] T15 WITH (NOLOCK) ON T15.[IDUGOVORORADU] = TM1.[IDUGOVORORADU]) INNER JOIN [SPOL] T16 WITH (NOLOCK) ON T16.[IDSPOL] = TM1.[IDSPOL]) INNER JOIN [IPIDENT] T17 WITH (NOLOCK) ON T17.[IDIPIDENT] = TM1.[IDIPIDENT])" + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] ";
            }
            this.cmRADNIKSelect23 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RADNIKSelect23 = this.cmRADNIKSelect23.FetchData();
            this.RcdFound21 = 0;
            this.ScanLoadRadnik();
            this.LoadDataRadnik(maxRows);
            if (this.RcdFound21 > 0)
            {
                this.SubLvlScanStartRadnikodbitak(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKOdbitakSelect2);
                this.SubLvlFetchRadnikodbitak();
                this.SubLoadDataRadnikodbitak();
                this.SubLvlScanStartRadnikolaksica(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKOlaksicaSelect2);
                this.SubLvlFetchRadnikolaksica();
                this.SubLoadDataRadnikolaksica();
                this.SubLvlScanStartRadnikkrediti(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKKreditiSelect2);
                this.SubLvlFetchRadnikkrediti();
                this.SubLoadDataRadnikkrediti();
                this.SubLvlScanStartRadnikbruto(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKBrutoSelect2);
                this.SubLvlFetchRadnikbruto();
                this.SubLoadDataRadnikbruto();
                this.SubLvlScanStartRadnikneto(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKNetoSelect2);
                this.SubLvlFetchRadnikneto();
                this.SubLoadDataRadnikneto();
                this.SubLvlScanStartRadnikobustava(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKObustavaSelect2);
                this.SubLvlFetchRadnikobustava();
                this.SubLoadDataRadnikobustava();
                this.SubLvlScanStartRadniklevel7(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKLevel7Select2);
                this.SubLvlFetchRadniklevel7();
                this.SubLoadDataRadniklevel7();
                this.SubLvlScanStartRadnikizuzeceodovrhe(this.m_WhereString, startRow, maxRows);
                this.SetParametersRadnikRadnik(this.cmRADNIKIzuzeceOdOvrheSelect2);
                this.SubLvlFetchRadnikizuzeceodovrhe();
                this.SubLoadDataRadnikizuzeceodovrhe();
            }
        }

        private void ScanStartRadnikbruto()
        {
            this.cmRADNIKBrutoSelect2 = this.connDefault.GetCommand("SELECT T1.[IDRADNIK], T1.[BRUTOSATI], T1.[BRUTOPOSTOTAK], T1.[BRUTOIZNOS], T2.[NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, T1.[BRUTOSATNICA], T2.[POSTOTAK] AS BRUTOELEMENTPOSTOTAK, T1.[BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT FROM ([RADNIKBruto] T1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = T1.[BRUTOELEMENTIDELEMENT]) WHERE T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDRADNIK], T1.[BRUTOELEMENTIDELEMENT] ", false);
            if (this.cmRADNIKBrutoSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKBrutoSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKBrutoSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["IDRADNIK"]));
            this.RADNIKBrutoSelect2 = this.cmRADNIKBrutoSelect2.FetchData();
            this.RcdFound54 = 0;
            this.ScanLoadRadnikbruto();
        }

        private void ScanStartRadnikizuzeceodovrhe()
        {
            this.cmRADNIKIzuzeceOdOvrheSelect2 = this.connDefault.GetCommand("SELECT [IDRADNIK], [ZADSIFRAOPISAPLACANJAIZUZECE], [ZADOPISPLACANJAIZUZECE], [ZADTEKUCIIZUZECE], [ZADMOIZUZECE], [ZADPOIZUZECE], [ZADMZIZUZECE], [ZADPZIZUZECE], [ZADIZNOSIZUZECA], [BANKAZASTICENOIDBANKE] AS BANKAZASTICENOIDBANKE FROM [RADNIKIzuzeceOdOvrhe] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ORDER BY [IDRADNIK], [BANKAZASTICENOIDBANKE] ", false);
            if (this.cmRADNIKIzuzeceOdOvrheSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKIzuzeceOdOvrheSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKIzuzeceOdOvrheSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["IDRADNIK"]));
            this.RADNIKIzuzeceOdOvrheSelect2 = this.cmRADNIKIzuzeceOdOvrheSelect2.FetchData();
            this.RcdFound290 = 0;
            this.ScanLoadRadnikizuzeceodovrhe();
        }

        private void ScanStartRadnikkrediti()
        {
            this.cmRADNIKKreditiSelect2 = this.connDefault.GetCommand("SELECT T1.[IDRADNIK], T1.[DATUMUGOVORA], T1.[ZADIZNOSRATEKREDITA], T1.[ZADBROJRATAOBUSTAVE], T1.[ZADUKUPNIZNOSKREDITA], T1.[ZADVECOTPLACENOBROJRATA], T1.[ZADVECOTPLACENOUKUPNIIZNOS], T1.[KREDITAKTIVAN], T2.[NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, T2.[PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, T2.[PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, T2.[PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, T1.[SIFRAOPISAPLACANJAKREDITOR], T1.[OPISPLACANJAKREDITOR], T1.[MOKREDITOR], T1.[POKREDITOR], T1.[MZKREDITOR], T1.[PZKREDITOR], T2.[VBDIKREDITOR] AS ZADKREDITIVBDIKREDITOR, T2.[ZRNKREDITOR] AS ZADKREDITIZRNKREDITOR, T1.[PARTIJAKREDITASPECIFIKACIJA], T1.[ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR FROM ([RADNIKKrediti] T1 WITH (NOLOCK) INNER JOIN [KREDITOR] T2 WITH (NOLOCK) ON T2.[IDKREDITOR] = T1.[ZADKREDITIIDKREDITOR]) WHERE T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDRADNIK], T1.[ZADKREDITIIDKREDITOR], T1.[DATUMUGOVORA] ", false);
            if (this.cmRADNIKKreditiSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKKreditiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKKreditiSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["IDRADNIK"]));
            this.RADNIKKreditiSelect2 = this.cmRADNIKKreditiSelect2.FetchData();
            this.RcdFound75 = 0;
            this.ScanLoadRadnikkrediti();
        }

        private void ScanStartRadniklevel7()
        {
            this.cmRADNIKLevel7Select2 = this.connDefault.GetCommand("SELECT T1.[IDRADNIK], T2.[NAZIVGRUPEKOEF], T1.[DODATNIKOEFICIJENT], T1.[IDGRUPEKOEF] FROM ([RADNIKLevel7] T1 WITH (NOLOCK) INNER JOIN [GRUPEKOEF] T2 WITH (NOLOCK) ON T2.[IDGRUPEKOEF] = T1.[IDGRUPEKOEF]) WHERE T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDRADNIK], T1.[IDGRUPEKOEF] ", false);
            if (this.cmRADNIKLevel7Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKLevel7Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKLevel7Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDRADNIK"]));
            this.RADNIKLevel7Select2 = this.cmRADNIKLevel7Select2.FetchData();
            this.RcdFound97 = 0;
            this.ScanLoadRadniklevel7();
        }

        private void ScanStartRadnikneto()
        {
            this.cmRADNIKNetoSelect2 = this.connDefault.GetCommand("SELECT T1.[IDRADNIK], T1.[NETOSATI], T1.[NETOSATNICA], T1.[NETOPOSTOTAK], T1.[NETOIZNOS], T2.[NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT, T1.[NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT FROM ([RADNIKNeto] T1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = T1.[NETOELEMENTIDELEMENT]) WHERE T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDRADNIK], T1.[NETOELEMENTIDELEMENT] ", false);
            if (this.cmRADNIKNetoSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKNetoSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKNetoSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["IDRADNIK"]));
            this.RADNIKNetoSelect2 = this.cmRADNIKNetoSelect2.FetchData();
            this.RcdFound56 = 0;
            this.ScanLoadRadnikneto();
        }

        private void ScanStartRadnikobustava()
        {
            this.cmRADNIKObustavaSelect2 = this.connDefault.GetCommand("SELECT T1.[IDRADNIK], T1.[ZADIZNOSOBUSTAVE], T1.[ZADPOSTOTAKOBUSTAVE], T1.[ZADISPLACENOKASA], T1.[ZADSALDOKASA], T1.[OBUSTAVAAKTIVNA], T1.[ZADPOSTOTNAODBRUTA], T2.[NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, T3.[NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE, T2.[ZRNOBUSTAVA] AS ZADOBUSTAVAZRNOBUSTAVA, T2.[VBDIOBUSTAVA] AS ZADOBUSTAVAVBDIOBUSTAVA, T1.[ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA, T2.[VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE FROM (([RADNIKObustava] T1 WITH (NOLOCK) INNER JOIN [OBUSTAVA] T2 WITH (NOLOCK) ON T2.[IDOBUSTAVA] = T1.[ZADOBUSTAVAIDOBUSTAVA]) LEFT JOIN [VRSTEOBUSTAVA] T3 WITH (NOLOCK) ON T3.[VRSTAOBUSTAVE] = T2.[VRSTAOBUSTAVE]) WHERE T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDRADNIK], T1.[ZADOBUSTAVAIDOBUSTAVA] ", false);
            if (this.cmRADNIKObustavaSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKObustavaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKObustavaSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["IDRADNIK"]));
            this.RADNIKObustavaSelect2 = this.cmRADNIKObustavaSelect2.FetchData();
            this.RcdFound59 = 0;
            this.ScanLoadRadnikobustava();
        }

        private void ScanStartRadnikodbitak()
        {
            this.cmRADNIKOdbitakSelect2 = this.connDefault.GetCommand("SELECT T1.[IDRADNIK], T2.[NAZIVOSOBNIODBITAK], T2.[FAKTOROSOBNOGODBITKA], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK FROM ([RADNIKOdbitak] T1 WITH (NOLOCK) INNER JOIN [OSOBNIODBITAK] T2 WITH (NOLOCK) ON T2.[IDOSOBNIODBITAK] = T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]) WHERE T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDRADNIK], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] ", false);
            if (this.cmRADNIKOdbitakSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKOdbitakSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKOdbitakSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOdbitak["IDRADNIK"]));
            this.RADNIKOdbitakSelect2 = this.cmRADNIKOdbitakSelect2.FetchData();
            this.RcdFound22 = 0;
            this.ScanLoadRadnikodbitak();
        }

        private void ScanStartRadnikolaksica()
        {
            this.cmRADNIKOlaksicaSelect2 = this.connDefault.GetCommand("SELECT T1.[IDRADNIK], T3.[MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, T3.[NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA, T2.[NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, T4.[NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE, T2.[VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, T2.[ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, T2.[PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, T2.[PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, T2.[PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, T1.[ZADMZOLAKSICE], T1.[ZADPZOLAKSICE], T1.[ZADMOOLAKSICE], T1.[ZADPOOLAKSICE], T1.[ZADSIFRAOPISAPLACANJAOLAKSICE], T1.[ZADOPISPLACANJAOLAKSICE], T1.[ZADIZNOSOLAKSICE], T1.[ZADPOJEDINACNIPOZIV], T1.[ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE, T2.[IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, T2.[IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE FROM ((([RADNIKOlaksica] T1 WITH (NOLOCK) INNER JOIN [OLAKSICE] T2 WITH (NOLOCK) ON T2.[IDOLAKSICE] = T1.[ZADOLAKSICEIDOLAKSICE]) LEFT JOIN [GRUPEOLAKSICA] T3 WITH (NOLOCK) ON T3.[IDGRUPEOLAKSICA] = T2.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T4 WITH (NOLOCK) ON T4.[IDTIPOLAKSICE] = T2.[IDTIPOLAKSICE]) WHERE T1.[IDRADNIK] = @IDRADNIK ORDER BY T1.[IDRADNIK], T1.[ZADOLAKSICEIDOLAKSICE] ", false);
            if (this.cmRADNIKOlaksicaSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNIKOlaksicaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmRADNIKOlaksicaSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["IDRADNIK"]));
            this.RADNIKOlaksicaSelect2 = this.cmRADNIKOlaksicaSelect2.FetchData();
            this.RcdFound23 = 0;
            this.ScanLoadRadnikolaksica();
        }

        private void SetParametersIDBANKERadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]));
        }

        private void SetParametersIDBENEFICIRANIRadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]));
        }

        private void SetParametersIDBRACNOSTANJERadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]));
        }

        private void SetParametersIDDRZAVLJANSTVORadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]));
        }

        private void SetParametersIDIPIDENTRadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]));
        }

        private void SetParametersIDORGDIORadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]));
        }

        private void SetParametersIDRADNIKRadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
        }

        private void SetParametersIDRADNOMJESTORadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]));
        }

        private void SetParametersIDRADNOVRIJEMERadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOVRIJEME"]));
        }

        private void SetParametersIDSPOLRadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]));
        }

        private void SetParametersIDSTRUKARadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]));
        }

        private void SetParametersIDTITULARadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]));
        }

        private void SetParametersIDUGOVORORADURadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]));
        }

        private void SetParametersJMBGRadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["JMBG"]));
        }

        private void SetParametersOPCINARADAIDOPCINERadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]));
        }

        private void SetParametersOPCINASTANOVANJAIDOPCINERadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]));
        }

        private void SetParametersPOTREBNASTRUCNASPREMAIDSTRUCNASPREMARadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
        }

        private void SetParametersRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
        }

        private void SetParametersRadnikRadnik(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersTRENUTNASTRUCNASPREMAIDSTRUCNASPREMARadnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
        }

        private void SkipNextRadnikbruto()
        {
            this.cmRADNIKBrutoSelect2.HasMoreRows = this.RADNIKBrutoSelect2.Read();
            this.RcdFound54 = 0;
            if (this.cmRADNIKBrutoSelect2.HasMoreRows)
            {
                this.RcdFound54 = 1;
            }
        }

        private void SkipNextRadnikizuzeceodovrhe()
        {
            this.cmRADNIKIzuzeceOdOvrheSelect2.HasMoreRows = this.RADNIKIzuzeceOdOvrheSelect2.Read();
            this.RcdFound290 = 0;
            if (this.cmRADNIKIzuzeceOdOvrheSelect2.HasMoreRows)
            {
                this.RcdFound290 = 1;
            }
        }

        private void SkipNextRadnikkrediti()
        {
            this.cmRADNIKKreditiSelect2.HasMoreRows = this.RADNIKKreditiSelect2.Read();
            this.RcdFound75 = 0;
            if (this.cmRADNIKKreditiSelect2.HasMoreRows)
            {
                this.RcdFound75 = 1;
            }
        }

        private void SkipNextRadniklevel7()
        {
            this.cmRADNIKLevel7Select2.HasMoreRows = this.RADNIKLevel7Select2.Read();
            this.RcdFound97 = 0;
            if (this.cmRADNIKLevel7Select2.HasMoreRows)
            {
                this.RcdFound97 = 1;
            }
        }

        private void SkipNextRadnikneto()
        {
            this.cmRADNIKNetoSelect2.HasMoreRows = this.RADNIKNetoSelect2.Read();
            this.RcdFound56 = 0;
            if (this.cmRADNIKNetoSelect2.HasMoreRows)
            {
                this.RcdFound56 = 1;
            }
        }

        private void SkipNextRadnikobustava()
        {
            this.cmRADNIKObustavaSelect2.HasMoreRows = this.RADNIKObustavaSelect2.Read();
            this.RcdFound59 = 0;
            if (this.cmRADNIKObustavaSelect2.HasMoreRows)
            {
                this.RcdFound59 = 1;
            }
        }

        private void SkipNextRadnikodbitak()
        {
            this.cmRADNIKOdbitakSelect2.HasMoreRows = this.RADNIKOdbitakSelect2.Read();
            this.RcdFound22 = 0;
            if (this.cmRADNIKOdbitakSelect2.HasMoreRows)
            {
                this.RcdFound22 = 1;
            }
        }

        private void SkipNextRadnikolaksica()
        {
            this.cmRADNIKOlaksicaSelect2.HasMoreRows = this.RADNIKOlaksicaSelect2.Read();
            this.RcdFound23 = 0;
            if (this.cmRADNIKOlaksicaSelect2.HasMoreRows)
            {
                this.RcdFound23 = 1;
            }
        }

        private void SubLoadDataRadnikbruto()
        {
            while (this.RcdFound54 != 0)
            {
                this.LoadRowRadnikbruto();
                this.CreateNewRowRadnikbruto();
                this.ScanNextRadnikbruto();
            }
            this.ScanEndRadnikbruto();
        }

        private void SubLoadDataRadnikizuzeceodovrhe()
        {
            while (this.RcdFound290 != 0)
            {
                this.LoadRowRadnikizuzeceodovrhe();
                this.CreateNewRowRadnikizuzeceodovrhe();
                this.ScanNextRadnikizuzeceodovrhe();
            }
            this.ScanEndRadnikizuzeceodovrhe();
        }

        private void SubLoadDataRadnikkrediti()
        {
            while (this.RcdFound75 != 0)
            {
                this.LoadRowRadnikkrediti();
                this.CreateNewRowRadnikkrediti();
                this.ScanNextRadnikkrediti();
            }
            this.ScanEndRadnikkrediti();
        }

        private void SubLoadDataRadniklevel7()
        {
            while (this.RcdFound97 != 0)
            {
                this.LoadRowRadniklevel7();
                this.CreateNewRowRadniklevel7();
                this.ScanNextRadniklevel7();
            }
            this.ScanEndRadniklevel7();
        }

        private void SubLoadDataRadnikneto()
        {
            while (this.RcdFound56 != 0)
            {
                this.LoadRowRadnikneto();
                this.CreateNewRowRadnikneto();
                this.ScanNextRadnikneto();
            }
            this.ScanEndRadnikneto();
        }

        private void SubLoadDataRadnikobustava()
        {
            while (this.RcdFound59 != 0)
            {
                this.LoadRowRadnikobustava();
                this.CreateNewRowRadnikobustava();
                this.ScanNextRadnikobustava();
            }
            this.ScanEndRadnikobustava();
        }

        private void SubLoadDataRadnikodbitak()
        {
            while (this.RcdFound22 != 0)
            {
                this.LoadRowRadnikodbitak();
                this.CreateNewRowRadnikodbitak();
                this.ScanNextRadnikodbitak();
            }
            this.ScanEndRadnikodbitak();
        }

        private void SubLoadDataRadnikolaksica()
        {
            while (this.RcdFound23 != 0)
            {
                this.LoadRowRadnikolaksica();
                this.CreateNewRowRadnikolaksica();
                this.ScanNextRadnikolaksica();
            }
            this.ScanEndRadnikolaksica();
        }

        private void SubLvlFetchRadnikbruto()
        {
            this.CreateNewRowRadnikbruto();
            this.RADNIKBrutoSelect2 = this.cmRADNIKBrutoSelect2.FetchData();
            this.RcdFound54 = 0;
            this.ScanLoadRadnikbruto();
        }

        private void SubLvlFetchRadnikizuzeceodovrhe()
        {
            this.CreateNewRowRadnikizuzeceodovrhe();
            this.RADNIKIzuzeceOdOvrheSelect2 = this.cmRADNIKIzuzeceOdOvrheSelect2.FetchData();
            this.RcdFound290 = 0;
            this.ScanLoadRadnikizuzeceodovrhe();
        }

        private void SubLvlFetchRadnikkrediti()
        {
            this.CreateNewRowRadnikkrediti();
            this.RADNIKKreditiSelect2 = this.cmRADNIKKreditiSelect2.FetchData();
            this.RcdFound75 = 0;
            this.ScanLoadRadnikkrediti();
        }

        private void SubLvlFetchRadniklevel7()
        {
            this.CreateNewRowRadniklevel7();
            this.RADNIKLevel7Select2 = this.cmRADNIKLevel7Select2.FetchData();
            this.RcdFound97 = 0;
            this.ScanLoadRadniklevel7();
        }

        private void SubLvlFetchRadnikneto()
        {
            this.CreateNewRowRadnikneto();
            this.RADNIKNetoSelect2 = this.cmRADNIKNetoSelect2.FetchData();
            this.RcdFound56 = 0;
            this.ScanLoadRadnikneto();
        }

        private void SubLvlFetchRadnikobustava()
        {
            this.CreateNewRowRadnikobustava();
            this.RADNIKObustavaSelect2 = this.cmRADNIKObustavaSelect2.FetchData();
            this.RcdFound59 = 0;
            this.ScanLoadRadnikobustava();
        }

        private void SubLvlFetchRadnikodbitak()
        {
            this.CreateNewRowRadnikodbitak();
            this.RADNIKOdbitakSelect2 = this.cmRADNIKOdbitakSelect2.FetchData();
            this.RcdFound22 = 0;
            this.ScanLoadRadnikodbitak();
        }

        private void SubLvlFetchRadnikolaksica()
        {
            this.CreateNewRowRadnikolaksica();
            this.RADNIKOlaksicaSelect2 = this.cmRADNIKOlaksicaSelect2.FetchData();
            this.RcdFound23 = 0;
            this.ScanLoadRadnikolaksica();
        }

        private void SubLvlScanStartRadnikbruto(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString54 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BRUTOSATI], T1.[BRUTOPOSTOTAK], T1.[BRUTOIZNOS], T3.[NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, T1.[BRUTOSATNICA], T3.[POSTOTAK] AS BRUTOELEMENTPOSTOTAK, T1.[BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT FROM (([RADNIKBruto] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString54 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[BRUTOELEMENTIDELEMENT]) ORDER BY T1.[IDRADNIK], T1.[BRUTOELEMENTIDELEMENT]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString54 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BRUTOSATI], T1.[BRUTOPOSTOTAK], T1.[BRUTOIZNOS], T3.[NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, T1.[BRUTOSATNICA], T3.[POSTOTAK] AS BRUTOELEMENTPOSTOTAK, T1.[BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT FROM (([RADNIKBruto] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString54 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[BRUTOELEMENTIDELEMENT]) ORDER BY T1.[IDRADNIK], T1.[BRUTOELEMENTIDELEMENT]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString54 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[BRUTOSATI], T1.[BRUTOPOSTOTAK], T1.[BRUTOIZNOS], T3.[NAZIVELEMENT] AS BRUTOELEMENTNAZIVELEMENT, T1.[BRUTOSATNICA], T3.[POSTOTAK] AS BRUTOELEMENTPOSTOTAK, T1.[BRUTOELEMENTIDELEMENT] AS BRUTOELEMENTIDELEMENT FROM (([RADNIKBruto] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString54 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[BRUTOELEMENTIDELEMENT])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[BRUTOELEMENTIDELEMENT] ";
            }
            this.cmRADNIKBrutoSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartRadnikizuzeceodovrhe(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString290 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADSIFRAOPISAPLACANJAIZUZECE], T1.[ZADOPISPLACANJAIZUZECE], T1.[ZADTEKUCIIZUZECE], T1.[ZADMOIZUZECE], T1.[ZADPOIZUZECE], T1.[ZADMZIZUZECE], T1.[ZADPZIZUZECE], T1.[ZADIZNOSIZUZECA], T1.[BANKAZASTICENOIDBANKE] AS BANKAZASTICENOIDBANKE FROM ([RADNIKIzuzeceOdOvrhe] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString290 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) ORDER BY T1.[IDRADNIK], T1.[BANKAZASTICENOIDBANKE]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString290 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADSIFRAOPISAPLACANJAIZUZECE], T1.[ZADOPISPLACANJAIZUZECE], T1.[ZADTEKUCIIZUZECE], T1.[ZADMOIZUZECE], T1.[ZADPOIZUZECE], T1.[ZADMZIZUZECE], T1.[ZADPZIZUZECE], T1.[ZADIZNOSIZUZECA], T1.[BANKAZASTICENOIDBANKE] AS BANKAZASTICENOIDBANKE FROM ([RADNIKIzuzeceOdOvrhe] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString290 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) ORDER BY T1.[IDRADNIK], T1.[BANKAZASTICENOIDBANKE]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString290 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADSIFRAOPISAPLACANJAIZUZECE], T1.[ZADOPISPLACANJAIZUZECE], T1.[ZADTEKUCIIZUZECE], T1.[ZADMOIZUZECE], T1.[ZADPOIZUZECE], T1.[ZADMZIZUZECE], T1.[ZADPZIZUZECE], T1.[ZADIZNOSIZUZECA], T1.[BANKAZASTICENOIDBANKE] AS BANKAZASTICENOIDBANKE FROM ([RADNIKIzuzeceOdOvrhe] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString290 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[BANKAZASTICENOIDBANKE] ";
            }
            this.cmRADNIKIzuzeceOdOvrheSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartRadnikkrediti(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString75 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[DATUMUGOVORA], T1.[ZADIZNOSRATEKREDITA], T1.[ZADBROJRATAOBUSTAVE], T1.[ZADUKUPNIZNOSKREDITA], T1.[ZADVECOTPLACENOBROJRATA], T1.[ZADVECOTPLACENOUKUPNIIZNOS], T1.[KREDITAKTIVAN], T3.[NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, T3.[PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, T3.[PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, T3.[PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, T1.[SIFRAOPISAPLACANJAKREDITOR], T1.[OPISPLACANJAKREDITOR], T1.[MOKREDITOR], T1.[POKREDITOR], T1.[MZKREDITOR], T1.[PZKREDITOR], T3.[VBDIKREDITOR] AS ZADKREDITIVBDIKREDITOR, T3.[ZRNKREDITOR] AS ZADKREDITIZRNKREDITOR, T1.[PARTIJAKREDITASPECIFIKACIJA], T1.[ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR FROM (([RADNIKKrediti] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString75 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [KREDITOR] T3 WITH (NOLOCK) ON T3.[IDKREDITOR] = T1.[ZADKREDITIIDKREDITOR]) ORDER BY T1.[IDRADNIK], T1.[ZADKREDITIIDKREDITOR], T1.[DATUMUGOVORA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString75 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[DATUMUGOVORA], T1.[ZADIZNOSRATEKREDITA], T1.[ZADBROJRATAOBUSTAVE], T1.[ZADUKUPNIZNOSKREDITA], T1.[ZADVECOTPLACENOBROJRATA], T1.[ZADVECOTPLACENOUKUPNIIZNOS], T1.[KREDITAKTIVAN], T3.[NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, T3.[PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, T3.[PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, T3.[PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, T1.[SIFRAOPISAPLACANJAKREDITOR], T1.[OPISPLACANJAKREDITOR], T1.[MOKREDITOR], T1.[POKREDITOR], T1.[MZKREDITOR], T1.[PZKREDITOR], T3.[VBDIKREDITOR] AS ZADKREDITIVBDIKREDITOR, T3.[ZRNKREDITOR] AS ZADKREDITIZRNKREDITOR, T1.[PARTIJAKREDITASPECIFIKACIJA], T1.[ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR FROM (([RADNIKKrediti] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString75 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [KREDITOR] T3 WITH (NOLOCK) ON T3.[IDKREDITOR] = T1.[ZADKREDITIIDKREDITOR]) ORDER BY T1.[IDRADNIK], T1.[ZADKREDITIIDKREDITOR], T1.[DATUMUGOVORA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString75 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[DATUMUGOVORA], T1.[ZADIZNOSRATEKREDITA], T1.[ZADBROJRATAOBUSTAVE], T1.[ZADUKUPNIZNOSKREDITA], T1.[ZADVECOTPLACENOBROJRATA], T1.[ZADVECOTPLACENOUKUPNIIZNOS], T1.[KREDITAKTIVAN], T3.[NAZIVKREDITOR] AS ZADKREDITINAZIVKREDITOR, T3.[PRIMATELJKREDITOR1] AS ZADKREDITIPRIMATELJKREDITOR1, T3.[PRIMATELJKREDITOR2] AS ZADKREDITIPRIMATELJKREDITOR2, T3.[PRIMATELJKREDITOR3] AS ZADKREDITIPRIMATELJKREDITOR3, T1.[SIFRAOPISAPLACANJAKREDITOR], T1.[OPISPLACANJAKREDITOR], T1.[MOKREDITOR], T1.[POKREDITOR], T1.[MZKREDITOR], T1.[PZKREDITOR], T3.[VBDIKREDITOR] AS ZADKREDITIVBDIKREDITOR, T3.[ZRNKREDITOR] AS ZADKREDITIZRNKREDITOR, T1.[PARTIJAKREDITASPECIFIKACIJA], T1.[ZADKREDITIIDKREDITOR] AS ZADKREDITIIDKREDITOR FROM (([RADNIKKrediti] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString75 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [KREDITOR] T3 WITH (NOLOCK) ON T3.[IDKREDITOR] = T1.[ZADKREDITIIDKREDITOR])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[ZADKREDITIIDKREDITOR], T1.[DATUMUGOVORA] ";
            }
            this.cmRADNIKKreditiSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartRadniklevel7(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString97 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T3.[NAZIVGRUPEKOEF], T1.[DODATNIKOEFICIJENT], T1.[IDGRUPEKOEF] FROM (([RADNIKLevel7] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString97 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [GRUPEKOEF] T3 WITH (NOLOCK) ON T3.[IDGRUPEKOEF] = T1.[IDGRUPEKOEF]) ORDER BY T1.[IDRADNIK], T1.[IDGRUPEKOEF]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString97 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T3.[NAZIVGRUPEKOEF], T1.[DODATNIKOEFICIJENT], T1.[IDGRUPEKOEF] FROM (([RADNIKLevel7] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString97 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [GRUPEKOEF] T3 WITH (NOLOCK) ON T3.[IDGRUPEKOEF] = T1.[IDGRUPEKOEF]) ORDER BY T1.[IDRADNIK], T1.[IDGRUPEKOEF]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString97 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T3.[NAZIVGRUPEKOEF], T1.[DODATNIKOEFICIJENT], T1.[IDGRUPEKOEF] FROM (([RADNIKLevel7] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString97 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [GRUPEKOEF] T3 WITH (NOLOCK) ON T3.[IDGRUPEKOEF] = T1.[IDGRUPEKOEF])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[IDGRUPEKOEF] ";
            }
            this.cmRADNIKLevel7Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartRadnikneto(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString56 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[NETOSATI], T1.[NETOSATNICA], T1.[NETOPOSTOTAK], T1.[NETOIZNOS], T3.[NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT, T1.[NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT FROM (([RADNIKNeto] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString56 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[NETOELEMENTIDELEMENT]) ORDER BY T1.[IDRADNIK], T1.[NETOELEMENTIDELEMENT]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString56 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[NETOSATI], T1.[NETOSATNICA], T1.[NETOPOSTOTAK], T1.[NETOIZNOS], T3.[NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT, T1.[NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT FROM (([RADNIKNeto] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString56 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[NETOELEMENTIDELEMENT]) ORDER BY T1.[IDRADNIK], T1.[NETOELEMENTIDELEMENT]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString56 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[NETOSATI], T1.[NETOSATNICA], T1.[NETOPOSTOTAK], T1.[NETOIZNOS], T3.[NAZIVELEMENT] AS NETOELEMENTNAZIVELEMENT, T1.[NETOELEMENTIDELEMENT] AS NETOELEMENTIDELEMENT FROM (([RADNIKNeto] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString56 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[NETOELEMENTIDELEMENT])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[NETOELEMENTIDELEMENT] ";
            }
            this.cmRADNIKNetoSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartRadnikobustava(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString59 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADIZNOSOBUSTAVE], T1.[ZADPOSTOTAKOBUSTAVE], T1.[ZADISPLACENOKASA], T1.[ZADSALDOKASA], T1.[OBUSTAVAAKTIVNA], T1.[ZADPOSTOTNAODBRUTA], T3.[NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, T4.[NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE, T3.[ZRNOBUSTAVA] AS ZADOBUSTAVAZRNOBUSTAVA, T3.[VBDIOBUSTAVA] AS ZADOBUSTAVAVBDIOBUSTAVA, T1.[ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA, T3.[VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE FROM ((([RADNIKObustava] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString59 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OBUSTAVA] T3 WITH (NOLOCK) ON T3.[IDOBUSTAVA] = T1.[ZADOBUSTAVAIDOBUSTAVA]) LEFT JOIN [VRSTEOBUSTAVA] T4 WITH (NOLOCK) ON T4.[VRSTAOBUSTAVE] = T3.[VRSTAOBUSTAVE]) ORDER BY T1.[IDRADNIK], T1.[ZADOBUSTAVAIDOBUSTAVA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString59 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADIZNOSOBUSTAVE], T1.[ZADPOSTOTAKOBUSTAVE], T1.[ZADISPLACENOKASA], T1.[ZADSALDOKASA], T1.[OBUSTAVAAKTIVNA], T1.[ZADPOSTOTNAODBRUTA], T3.[NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, T4.[NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE, T3.[ZRNOBUSTAVA] AS ZADOBUSTAVAZRNOBUSTAVA, T3.[VBDIOBUSTAVA] AS ZADOBUSTAVAVBDIOBUSTAVA, T1.[ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA, T3.[VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE FROM ((([RADNIKObustava] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString59 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OBUSTAVA] T3 WITH (NOLOCK) ON T3.[IDOBUSTAVA] = T1.[ZADOBUSTAVAIDOBUSTAVA]) LEFT JOIN [VRSTEOBUSTAVA] T4 WITH (NOLOCK) ON T4.[VRSTAOBUSTAVE] = T3.[VRSTAOBUSTAVE]) ORDER BY T1.[IDRADNIK], T1.[ZADOBUSTAVAIDOBUSTAVA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString59 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T1.[ZADIZNOSOBUSTAVE], T1.[ZADPOSTOTAKOBUSTAVE], T1.[ZADISPLACENOKASA], T1.[ZADSALDOKASA], T1.[OBUSTAVAAKTIVNA], T1.[ZADPOSTOTNAODBRUTA], T3.[NAZIVOBUSTAVA] AS ZADOBUSTAVANAZIVOBUSTAVA, T4.[NAZIVVRSTAOBUSTAVE] AS ZADOBUSTAVANAZIVVRSTAOBUSTAVE, T3.[ZRNOBUSTAVA] AS ZADOBUSTAVAZRNOBUSTAVA, T3.[VBDIOBUSTAVA] AS ZADOBUSTAVAVBDIOBUSTAVA, T1.[ZADOBUSTAVAIDOBUSTAVA] AS ZADOBUSTAVAIDOBUSTAVA, T3.[VRSTAOBUSTAVE] AS ZADOBUSTAVAVRSTAOBUSTAVE FROM ((([RADNIKObustava] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString59 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OBUSTAVA] T3 WITH (NOLOCK) ON T3.[IDOBUSTAVA] = T1.[ZADOBUSTAVAIDOBUSTAVA]) LEFT JOIN [VRSTEOBUSTAVA] T4 WITH (NOLOCK) ON T4.[VRSTAOBUSTAVE] = T3.[VRSTAOBUSTAVE])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[ZADOBUSTAVAIDOBUSTAVA] ";
            }
            this.cmRADNIKObustavaSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartRadnikodbitak(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString22 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T3.[NAZIVOSOBNIODBITAK], T3.[FAKTOROSOBNOGODBITKA], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK FROM (([RADNIKOdbitak] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString22 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OSOBNIODBITAK] T3 WITH (NOLOCK) ON T3.[IDOSOBNIODBITAK] = T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]) ORDER BY T1.[IDRADNIK], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString22 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T3.[NAZIVOSOBNIODBITAK], T3.[FAKTOROSOBNOGODBITKA], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK FROM (([RADNIKOdbitak] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString22 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OSOBNIODBITAK] T3 WITH (NOLOCK) ON T3.[IDOSOBNIODBITAK] = T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]) ORDER BY T1.[IDRADNIK], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString22 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T3.[NAZIVOSOBNIODBITAK], T3.[FAKTOROSOBNOGODBITKA], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] AS OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK FROM (([RADNIKOdbitak] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString22 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OSOBNIODBITAK] T3 WITH (NOLOCK) ON T3.[IDOSOBNIODBITAK] = T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK] ";
            }
            this.cmRADNIKOdbitakSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartRadnikolaksica(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString23 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRADNIK]  FROM [RADNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRADNIK] )";
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T4.[MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, T4.[NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA, T3.[NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, T5.[NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE, T3.[VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, T3.[ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, T3.[PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, T3.[PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, T3.[PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, T1.[ZADMZOLAKSICE], T1.[ZADPZOLAKSICE], T1.[ZADMOOLAKSICE], T1.[ZADPOOLAKSICE], T1.[ZADSIFRAOPISAPLACANJAOLAKSICE], T1.[ZADOPISPLACANJAOLAKSICE], T1.[ZADIZNOSOLAKSICE], T1.[ZADPOJEDINACNIPOZIV], T1.[ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE, T3.[IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, T3.[IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE FROM (((([RADNIKOlaksica] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString23 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OLAKSICE] T3 WITH (NOLOCK) ON T3.[IDOLAKSICE] = T1.[ZADOLAKSICEIDOLAKSICE]) LEFT JOIN [GRUPEOLAKSICA] T4 WITH (NOLOCK) ON T4.[IDGRUPEOLAKSICA] = T3.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T5 WITH (NOLOCK) ON T5.[IDTIPOLAKSICE] = T3.[IDTIPOLAKSICE]) ORDER BY T1.[IDRADNIK], T1.[ZADOLAKSICEIDOLAKSICE]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRADNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNIK]  ) AS DK_PAGENUM   FROM [RADNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString23 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDRADNIK], T4.[MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, T4.[NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA, T3.[NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, T5.[NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE, T3.[VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, T3.[ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, T3.[PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, T3.[PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, T3.[PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, T1.[ZADMZOLAKSICE], T1.[ZADPZOLAKSICE], T1.[ZADMOOLAKSICE], T1.[ZADPOOLAKSICE], T1.[ZADSIFRAOPISAPLACANJAOLAKSICE], T1.[ZADOPISPLACANJAOLAKSICE], T1.[ZADIZNOSOLAKSICE], T1.[ZADPOJEDINACNIPOZIV], T1.[ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE, T3.[IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, T3.[IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE FROM (((([RADNIKOlaksica] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString23 + "  TMX ON TMX.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OLAKSICE] T3 WITH (NOLOCK) ON T3.[IDOLAKSICE] = T1.[ZADOLAKSICEIDOLAKSICE]) LEFT JOIN [GRUPEOLAKSICA] T4 WITH (NOLOCK) ON T4.[IDGRUPEOLAKSICA] = T3.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T5 WITH (NOLOCK) ON T5.[IDTIPOLAKSICE] = T3.[IDTIPOLAKSICE]) ORDER BY T1.[IDRADNIK], T1.[ZADOLAKSICEIDOLAKSICE]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString23 = "[RADNIK]";
                this.scmdbuf = "SELECT T1.[IDRADNIK], T4.[MAXIMALNIIZNOSGRUPE] AS ZADOLAKSICEMAXIMALNIIZNOSGRUPE, T4.[NAZIVGRUPEOLAKSICA] AS ZADOLAKSICENAZIVGRUPEOLAKSICA, T3.[NAZIVOLAKSICE] AS ZADOLAKSICENAZIVOLAKSICE, T5.[NAZIVTIPOLAKSICE] AS ZADOLAKSICENAZIVTIPOLAKSICE, T3.[VBDIOLAKSICA] AS ZADOLAKSICEVBDIOLAKSICA, T3.[ZRNOLAKSICA] AS ZADOLAKSICEZRNOLAKSICA, T3.[PRIMATELJOLAKSICA1] AS ZADOLAKSICEPRIMATELJOLAKSICA1, T3.[PRIMATELJOLAKSICA2] AS ZADOLAKSICEPRIMATELJOLAKSICA2, T3.[PRIMATELJOLAKSICA3] AS ZADOLAKSICEPRIMATELJOLAKSICA3, T1.[ZADMZOLAKSICE], T1.[ZADPZOLAKSICE], T1.[ZADMOOLAKSICE], T1.[ZADPOOLAKSICE], T1.[ZADSIFRAOPISAPLACANJAOLAKSICE], T1.[ZADOPISPLACANJAOLAKSICE], T1.[ZADIZNOSOLAKSICE], T1.[ZADPOJEDINACNIPOZIV], T1.[ZADOLAKSICEIDOLAKSICE] AS ZADOLAKSICEIDOLAKSICE, T3.[IDGRUPEOLAKSICA] AS ZADOLAKSICEIDGRUPEOLAKSICA, T3.[IDTIPOLAKSICE] AS ZADOLAKSICEIDTIPOLAKSICE FROM (((([RADNIKOlaksica] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString23 + "  TM1 WITH (NOLOCK) ON TM1.[IDRADNIK] = T1.[IDRADNIK]) INNER JOIN [OLAKSICE] T3 WITH (NOLOCK) ON T3.[IDOLAKSICE] = T1.[ZADOLAKSICEIDOLAKSICE]) LEFT JOIN [GRUPEOLAKSICA] T4 WITH (NOLOCK) ON T4.[IDGRUPEOLAKSICA] = T3.[IDGRUPEOLAKSICA]) LEFT JOIN [TIPOLAKSICE] T5 WITH (NOLOCK) ON T5.[IDTIPOLAKSICE] = T3.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY T1.[IDRADNIK], T1.[ZADOLAKSICEIDOLAKSICE] ";
            }
            this.cmRADNIKOlaksicaSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RADNIKSet = (RADNIKDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RADNIKSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RADNIKSet.RADNIK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RADNIKDataSet.RADNIKRow current = (RADNIKDataSet.RADNIKRow) enumerator.Current;
                        this.rowRADNIK = current;
                        if (Helpers.IsRowChanged(this.rowRADNIK))
                        {
                            this.ReadRowRadnik();
                            if (this.rowRADNIK.RowState == DataRowState.Added)
                            {
                                this.InsertRadnik();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRadnik();
                            }
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                dataSet.AcceptChanges();
                this.connDefault.Commit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateRadnik()
        {
            this.CheckOptimisticConcurrencyRadnik();
            this.CheckExtendedTableRadnik();
            this.AfterConfirmRadnik();
            string statement = " UPDATE [RADNIK] SET [AKTIVAN]=@AKTIVAN, [GODINESTAZAPRO]=@GODINESTAZAPRO, [MJESECISTAZAPRO]=@MJESECISTAZAPRO, [DANISTAZAPRO]=@DANISTAZAPRO, [PREZIME]=@PREZIME, [IME]=@IME, [OIB]=@OIB, [JMBG]=@JMBG, [DATUMRODJENJA]=@DATUMRODJENJA, [ulica]=@ulica, [mjesto]=@mjesto, [kucnibroj]=@kucnibroj, [TEKUCI]=@TEKUCI, [ZBIRNINETO]=@ZBIRNINETO, [SIFRAOPISAPLACANJANETO]=@SIFRAOPISAPLACANJANETO, [OPISPLACANJANETO]=@OPISPLACANJANETO, [TJEDNIFONDSATI]=@TJEDNIFONDSATI, [KOEFICIJENT]=@KOEFICIJENT, [POSTOTAKOSLOBODJENJAODPOREZA]=@POSTOTAKOSLOBODJENJAODPOREZA, [UZIMAUOBZIROSNOVICEDOPRINOSA]=@UZIMAUOBZIROSNOVICEDOPRINOSA, [TJEDNIFONDSATISTAZ]=@TJEDNIFONDSATISTAZ, [DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI]=@DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, [GODINESTAZA]=@GODINESTAZA, [MJESECISTAZA]=@MJESECISTAZA, [DANISTAZA]=@DANISTAZA, [DATUMPRESTANKARADNOGODNOSA]=@DATUMPRESTANKARADNOGODNOSA, [BROJMIROVINSKOG]=@BROJMIROVINSKOG, [BROJZDRAVSTVENOG]=@BROJZDRAVSTVENOG, [MBO]=@MBO, [MO]=@MO, [PBO]=@PBO, [RADNADOZVOLA]=@RADNADOZVOLA, [ZAVRSENASKOLA]=@ZAVRSENASKOLA, [UGOVOROD]=@UGOVOROD, [POCETAKRADA]=@POCETAKRADA, [NAZIVPOSLA]=@NAZIVPOSLA, [VRIJEMEPROBNOGRADA]=@VRIJEMEPROBNOGRADA, [VRIJEMEPRIPRAVNICKOG]=@VRIJEMEPRIPRAVNICKOG, [VRIJEMESTRUCNI]=@VRIJEMESTRUCNI, [RADUINOZEMSTVU]=@RADUINOZEMSTVU, [RADNASPOSOBNOST]=@RADNASPOSOBNOST, [VRIJEMEMIROVANJARADNOGODNOSA]=@VRIJEMEMIROVANJARADNOGODNOSA, [RAZLOGPRESTANKA]=@RAZLOGPRESTANKA, [ZABRANANATJECANJA]=@ZABRANANATJECANJA, [PRODUZENOMIROVINSKO]=@PRODUZENOMIROVINSKO, [RADNIKNAPOMENA]=@RADNIKNAPOMENA, [IDBANKE]=@IDBANKE, [IDBENEFICIRANI]=@IDBENEFICIRANI, [IDTITULA]=@IDTITULA, [IDRADNOMJESTO]=@IDRADNOMJESTO, [IDSTRUKA]=@IDSTRUKA, [IDBRACNOSTANJE]=@IDBRACNOSTANJE, [IDORGDIO]=@IDORGDIO, [IDSPOL]=@IDSPOL, [IDIPIDENT]=@IDIPIDENT, [IDDRZAVLJANSTVO]=@IDDRZAVLJANSTVO, [IDUGOVORORADU]=@IDUGOVORORADU,  [IDRADNOVRIJEME]=@IDRADNOVRIJEME, [OPCINARADAIDOPCINE]=@OPCINARADAIDOPCINE, [OPCINASTANOVANJAIDOPCINE]=@OPCINASTANOVANJAIDOPCINE, [RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA]=@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA]=@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA]=@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA  WHERE [IDRADNIK] = @IDRADNIK";
            ReadWriteCommand command = this.connDefault.GetCommand(statement, false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVAN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINESTAZAPRO", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISTAZAPRO", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DANISTAZAPRO", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OIB", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBG", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMRODJENJA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ulica", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesto", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kucnibroj", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TEKUCI", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZBIRNINETO", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJANETO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJANETO", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TJEDNIFONDSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTOTAKOSLOBODJENJAODPOREZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UZIMAUOBZIROSNOVICEDOPRINOSA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TJEDNIFONDSATISTAZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINESTAZA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISTAZA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DANISTAZA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMPRESTANKARADNOGODNOSA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJMIROVINSKOG", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJZDRAVSTVENOG", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PBO", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNADOZVOLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSENASKOLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UGOVOROD", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETAKRADA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOSLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMEPROBNOGRADA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMEPRIPRAVNICKOG", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMESTRUCNI", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADUINOZEMSTVU", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNASPOSOBNOST", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRIJEMEMIROVANJARADNOGODNOSA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZLOGPRESTANKA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZABRANANATJECANJA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRODUZENOMIROVINSKO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKNAPOMENA", DbType.String));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIK["AKTIVAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZAPRO"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZAPRO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZAPRO"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIK["PREZIME"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IME"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OIB"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIK["JMBG"]));
            command.SetParameterDateObject(8, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMRODJENJA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ulica"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRADNIK["mjesto"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRADNIK["kucnibroj"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TEKUCI"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZBIRNINETO"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowRADNIK["SIFRAOPISAPLACANJANETO"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPISPLACANJANETO"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATI"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowRADNIK["KOEFICIJENT"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POSTOTAKOSLOBODJENJAODPOREZA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowRADNIK["UZIMAUOBZIROSNOVICEDOPRINOSA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TJEDNIFONDSATISTAZ"]));
            command.SetParameterDateObject(0x15, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"]));
            command.SetParameter(0x16, RuntimeHelpers.GetObjectValue(this.rowRADNIK["GODINESTAZA"]));
            command.SetParameter(0x17, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MJESECISTAZA"]));
            command.SetParameter(0x18, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DANISTAZA"]));
            command.SetParameterDateObject(0x19, RuntimeHelpers.GetObjectValue(this.rowRADNIK["DATUMPRESTANKARADNOGODNOSA"]));
            command.SetParameter(0x1a, RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJMIROVINSKOG"]));
            command.SetParameter(0x1b, RuntimeHelpers.GetObjectValue(this.rowRADNIK["BROJZDRAVSTVENOG"]));
            command.SetParameter(0x1c, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MBO"]));
            command.SetParameter(0x1d, RuntimeHelpers.GetObjectValue(this.rowRADNIK["MO"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowRADNIK["PBO"]));
            command.SetParameter(0x1f, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNADOZVOLA"]));
            command.SetParameter(0x20, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZAVRSENASKOLA"]));
            command.SetParameterDateObject(0x21, RuntimeHelpers.GetObjectValue(this.rowRADNIK["UGOVOROD"]));
            command.SetParameterDateObject(0x22, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POCETAKRADA"]));
            command.SetParameter(0x23, RuntimeHelpers.GetObjectValue(this.rowRADNIK["NAZIVPOSLA"]));
            command.SetParameter(0x24, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPROBNOGRADA"]));
            command.SetParameter(0x25, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEPRIPRAVNICKOG"]));
            command.SetParameter(0x26, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMESTRUCNI"]));
            command.SetParameter(0x27, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADUINOZEMSTVU"]));
            command.SetParameter(40, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNASPOSOBNOST"]));
            command.SetParameter(0x29, RuntimeHelpers.GetObjectValue(this.rowRADNIK["VRIJEMEMIROVANJARADNOGODNOSA"]));
            command.SetParameter(0x2a, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RAZLOGPRESTANKA"]));
            command.SetParameter(0x2b, RuntimeHelpers.GetObjectValue(this.rowRADNIK["ZABRANANATJECANJA"]));
            command.SetParameter(0x2c, RuntimeHelpers.GetObjectValue(this.rowRADNIK["PRODUZENOMIROVINSKO"]));
            command.SetParameter(0x2d, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKNAPOMENA"]));
            command.SetParameter(0x2e, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBANKE"]));
            command.SetParameter(0x2f, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBENEFICIRANI"]));
            command.SetParameter(0x30, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDTITULA"]));
            command.SetParameter(0x31, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOMJESTO"]));
            command.SetParameter(50, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSTRUKA"]));
            command.SetParameter(0x33, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDBRACNOSTANJE"]));
            command.SetParameter(0x34, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDORGDIO"]));
            command.SetParameter(0x35, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDSPOL"]));
            command.SetParameter(0x36, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDIPIDENT"]));
            command.SetParameter(0x37, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDDRZAVLJANSTVO"]));
            command.SetParameter(0x38, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDUGOVORORADU"]));
            command.SetParameter(0x39, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNOVRIJEME"]));
            command.SetParameter(0x3a, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINARADAIDOPCINE"]));
            command.SetParameter(0x3b, RuntimeHelpers.GetObjectValue(this.rowRADNIK["OPCINASTANOVANJAIDOPCINE"]));
            command.SetParameter(60, RuntimeHelpers.GetObjectValue(this.rowRADNIK["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]));
            command.SetParameter(0x3d, RuntimeHelpers.GetObjectValue(this.rowRADNIK["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"]));
            command.SetParameter(0x3e, RuntimeHelpers.GetObjectValue(this.rowRADNIK["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"]));
            command.SetParameter(0x3f, RuntimeHelpers.GetObjectValue(this.rowRADNIK["IDRADNIK"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRadnik();
            }
            if (command.DupKey)
            {
                this.CheckUniqueIndexRadnik();
            }
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIK.IDRADNIK);
            this.OnRADNIKUpdated(new RADNIKEventArgs(this.rowRADNIK, StatementType.Update));
            this.ProcessLevelRadnik();
        }

        private void UpdateRadnikbruto()
        {
            this.CheckOptimisticConcurrencyRadnikbruto();
            this.CheckExtendedTableRadnikbruto();
            this.AfterConfirmRadnikbruto();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNIKBruto] SET [BRUTOSATI]=@BRUTOSATI, [BRUTOPOSTOTAK]=@BRUTOPOSTOTAK, [BRUTOIZNOS]=@BRUTOIZNOS, [BRUTOSATNICA]=@BRUTOSATNICA  WHERE [IDRADNIK] = @IDRADNIK AND [BRUTOELEMENTIDELEMENT] = @BRUTOELEMENTIDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BRUTOELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATI"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOPOSTOTAK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOIZNOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOSATNICA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["IDRADNIK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKBruto["BRUTOELEMENTIDELEMENT"]));
            command.ExecuteStmt();
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIKBruto.IDRADNIK);
            this.OnRADNIKBrutoUpdated(new RADNIKBrutoEventArgs(this.rowRADNIKBruto, StatementType.Update));
        }

        private void UpdateRadnikizuzeceodovrhe()
        {
            this.CheckOptimisticConcurrencyRadnikizuzeceodovrhe();
            this.AfterConfirmRadnikizuzeceodovrhe();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNIKIzuzeceOdOvrhe] SET [ZADSIFRAOPISAPLACANJAIZUZECE]=@ZADSIFRAOPISAPLACANJAIZUZECE, [ZADOPISPLACANJAIZUZECE]=@ZADOPISPLACANJAIZUZECE, [ZADTEKUCIIZUZECE]=@ZADTEKUCIIZUZECE, [ZADMOIZUZECE]=@ZADMOIZUZECE, [ZADPOIZUZECE]=@ZADPOIZUZECE, [ZADMZIZUZECE]=@ZADMZIZUZECE, [ZADPZIZUZECE]=@ZADPZIZUZECE, [ZADIZNOSIZUZECA]=@ZADIZNOSIZUZECA  WHERE [IDRADNIK] = @IDRADNIK AND [BANKAZASTICENOIDBANKE] = @BANKAZASTICENOIDBANKE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADSIFRAOPISAPLACANJAIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOPISPLACANJAIZUZECE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADTEKUCIIZUZECE", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMOIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMZIZUZECE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPZIZUZECE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSIZUZECA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BANKAZASTICENOIDBANKE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADSIFRAOPISAPLACANJAIZUZECE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADOPISPLACANJAIZUZECE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADTEKUCIIZUZECE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMOIZUZECE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPOIZUZECE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADMZIZUZECE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADPZIZUZECE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["ZADIZNOSIZUZECA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["IDRADNIK"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRADNIKIzuzeceOdOvrhe["BANKAZASTICENOIDBANKE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRadnikizuzeceodovrhe();
            }
            this.OnRADNIKIzuzeceOdOvrheUpdated(new RADNIKIzuzeceOdOvrheEventArgs(this.rowRADNIKIzuzeceOdOvrhe, StatementType.Update));
        }

        private void UpdateRadnikkrediti()
        {
            this.CheckOptimisticConcurrencyRadnikkrediti();
            this.CheckExtendedTableRadnikkrediti();
            this.AfterConfirmRadnikkrediti();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNIKKrediti] SET [ZADIZNOSRATEKREDITA]=@ZADIZNOSRATEKREDITA, [ZADBROJRATAOBUSTAVE]=@ZADBROJRATAOBUSTAVE, [ZADUKUPNIZNOSKREDITA]=@ZADUKUPNIZNOSKREDITA, [ZADVECOTPLACENOBROJRATA]=@ZADVECOTPLACENOBROJRATA, [ZADVECOTPLACENOUKUPNIIZNOS]=@ZADVECOTPLACENOUKUPNIIZNOS, [KREDITAKTIVAN]=@KREDITAKTIVAN, [SIFRAOPISAPLACANJAKREDITOR]=@SIFRAOPISAPLACANJAKREDITOR, [OPISPLACANJAKREDITOR]=@OPISPLACANJAKREDITOR, [MOKREDITOR]=@MOKREDITOR, [POKREDITOR]=@POKREDITOR, [MZKREDITOR]=@MZKREDITOR, [PZKREDITOR]=@PZKREDITOR, [PARTIJAKREDITASPECIFIKACIJA]=@PARTIJAKREDITASPECIFIKACIJA  WHERE [IDRADNIK] = @IDRADNIK AND [ZADKREDITIIDKREDITOR] = @ZADKREDITIIDKREDITOR AND [DATUMUGOVORA] = @DATUMUGOVORA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSRATEKREDITA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADBROJRATAOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADUKUPNIZNOSKREDITA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADVECOTPLACENOBROJRATA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADVECOTPLACENOUKUPNIIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KREDITAKTIVAN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKREDITOR", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKREDITOR", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKREDITOR", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTIJAKREDITASPECIFIKACIJA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADKREDITIIDKREDITOR", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADIZNOSRATEKREDITA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADBROJRATAOBUSTAVE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADUKUPNIZNOSKREDITA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOBROJRATA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADVECOTPLACENOUKUPNIIZNOS"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["KREDITAKTIVAN"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["SIFRAOPISAPLACANJAKREDITOR"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["OPISPLACANJAKREDITOR"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MOKREDITOR"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["POKREDITOR"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["MZKREDITOR"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PZKREDITOR"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["PARTIJAKREDITASPECIFIKACIJA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["IDRADNIK"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["ZADKREDITIIDKREDITOR"]));
            command.SetParameterDateObject(15, RuntimeHelpers.GetObjectValue(this.rowRADNIKKrediti["DATUMUGOVORA"]));
            command.ExecuteStmt();
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIKKrediti.IDRADNIK);
            this.OnRADNIKKreditiUpdated(new RADNIKKreditiEventArgs(this.rowRADNIKKrediti, StatementType.Update));
        }

        private void UpdateRadniklevel7()
        {
            this.CheckOptimisticConcurrencyRadniklevel7();
            this.CheckExtendedTableRadniklevel7();
            this.AfterConfirmRadniklevel7();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNIKLevel7] SET [DODATNIKOEFICIJENT]=@DODATNIKOEFICIJENT  WHERE [IDRADNIK] = @IDRADNIK AND [IDGRUPEKOEF] = @IDGRUPEKOEF", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DODATNIKOEFICIJENT", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["DODATNIKOEFICIJENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDRADNIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKLevel7["IDGRUPEKOEF"]));
            command.ExecuteStmt();
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIKLevel7.IDRADNIK);
            this.OnRADNIKLevel7Updated(new RADNIKLevel7EventArgs(this.rowRADNIKLevel7, StatementType.Update));
        }

        private void UpdateRadnikneto()
        {
            this.CheckOptimisticConcurrencyRadnikneto();
            this.CheckExtendedTableRadnikneto();
            this.AfterConfirmRadnikneto();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNIKNeto] SET [NETOSATI]=@NETOSATI, [NETOSATNICA]=@NETOSATNICA, [NETOPOSTOTAK]=@NETOPOSTOTAK, [NETOIZNOS]=@NETOIZNOS  WHERE [IDRADNIK] = @IDRADNIK AND [NETOELEMENTIDELEMENT] = @NETOELEMENTIDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOSATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOSATNICA", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NETOELEMENTIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATI"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOSATNICA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOPOSTOTAK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOIZNOS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["IDRADNIK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKNeto["NETOELEMENTIDELEMENT"]));
            command.ExecuteStmt();
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIKNeto.IDRADNIK);
            this.OnRADNIKNetoUpdated(new RADNIKNetoEventArgs(this.rowRADNIKNeto, StatementType.Update));
        }

        private void UpdateRadnikobustava()
        {
            this.CheckOptimisticConcurrencyRadnikobustava();
            this.CheckExtendedTableRadnikobustava();
            this.AfterConfirmRadnikobustava();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNIKObustava] SET [ZADIZNOSOBUSTAVE]=@ZADIZNOSOBUSTAVE, [ZADPOSTOTAKOBUSTAVE]=@ZADPOSTOTAKOBUSTAVE, [ZADISPLACENOKASA]=@ZADISPLACENOKASA, [ZADSALDOKASA]=@ZADSALDOKASA, [OBUSTAVAAKTIVNA]=@OBUSTAVAAKTIVNA, [ZADPOSTOTNAODBRUTA]=@ZADPOSTOTNAODBRUTA  WHERE [IDRADNIK] = @IDRADNIK AND [ZADOBUSTAVAIDOBUSTAVA] = @ZADOBUSTAVAIDOBUSTAVA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOSTOTAKOBUSTAVE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADISPLACENOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADSALDOKASA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBUSTAVAAKTIVNA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOSTOTNAODBRUTA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOBUSTAVAIDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADIZNOSOBUSTAVE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTAKOBUSTAVE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADISPLACENOKASA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADSALDOKASA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["OBUSTAVAAKTIVNA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADPOSTOTNAODBRUTA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["IDRADNIK"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKObustava["ZADOBUSTAVAIDOBUSTAVA"]));
            command.ExecuteStmt();
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIKObustava.IDRADNIK);
            this.OnRADNIKObustavaUpdated(new RADNIKObustavaEventArgs(this.rowRADNIKObustava, StatementType.Update));
        }

        private void UpdateRadnikodbitak()
        {
            this.CheckOptimisticConcurrencyRadnikodbitak();
            this.CheckExtendedTableRadnikodbitak();
            this.AfterConfirmRadnikodbitak();
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIKOdbitak.IDRADNIK);
            this.OnRADNIKOdbitakUpdated(new RADNIKOdbitakEventArgs(this.rowRADNIKOdbitak, StatementType.Update));
        }

        private void UpdateRadnikolaksica()
        {
            this.CheckOptimisticConcurrencyRadnikolaksica();
            this.CheckExtendedTableRadnikolaksica();
            this.AfterConfirmRadnikolaksica();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNIKOlaksica] SET [ZADMZOLAKSICE]=@ZADMZOLAKSICE, [ZADPZOLAKSICE]=@ZADPZOLAKSICE, [ZADMOOLAKSICE]=@ZADMOOLAKSICE, [ZADPOOLAKSICE]=@ZADPOOLAKSICE, [ZADSIFRAOPISAPLACANJAOLAKSICE]=@ZADSIFRAOPISAPLACANJAOLAKSICE, [ZADOPISPLACANJAOLAKSICE]=@ZADOPISPLACANJAOLAKSICE, [ZADIZNOSOLAKSICE]=@ZADIZNOSOLAKSICE, [ZADPOJEDINACNIPOZIV]=@ZADPOJEDINACNIPOZIV  WHERE [IDRADNIK] = @IDRADNIK AND [ZADOLAKSICEIDOLAKSICE] = @ZADOLAKSICEIDOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMZOLAKSICE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPZOLAKSICE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADMOOLAKSICE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOOLAKSICE", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADSIFRAOPISAPLACANJAOLAKSICE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOPISPLACANJAOLAKSICE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADIZNOSOLAKSICE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADPOJEDINACNIPOZIV", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZADOLAKSICEIDOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMZOLAKSICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPZOLAKSICE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADMOOLAKSICE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOOLAKSICE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADSIFRAOPISAPLACANJAOLAKSICE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOPISPLACANJAOLAKSICE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADIZNOSOLAKSICE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADPOJEDINACNIPOZIV"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["IDRADNIK"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRADNIKOlaksica["ZADOLAKSICEIDOLAKSICE"]));
            command.ExecuteStmt();
            new radnikupdateredundancy(ref this.dsDefault).execute(this.rowRADNIKOlaksica.IDRADNIK);
            this.OnRADNIKOlaksicaUpdated(new RADNIKOlaksicaEventArgs(this.rowRADNIKOlaksica, StatementType.Update));
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

        [Serializable]
        public class BANKEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public BANKEForeignKeyNotFoundException()
            {
            }

            public BANKEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected BANKEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BANKEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BENEFICIRANIForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public BENEFICIRANIForeignKeyNotFoundException()
            {
            }

            public BENEFICIRANIForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected BENEFICIRANIForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BENEFICIRANIForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BRACNOSTANJEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public BRACNOSTANJEForeignKeyNotFoundException()
            {
            }

            public BRACNOSTANJEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected BRACNOSTANJEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BRACNOSTANJEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DRZAVLJANSTVOForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DRZAVLJANSTVOForeignKeyNotFoundException()
            {
            }

            public DRZAVLJANSTVOForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DRZAVLJANSTVOForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DRZAVLJANSTVOForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ELEMENTForeignKeyNotFoundException()
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJARADNICIInvalidDeleteException : InvalidDeleteException
        {
            public EVIDENCIJARADNICIInvalidDeleteException()
            {
            }

            public EVIDENCIJARADNICIInvalidDeleteException(string message) : base(message)
            {
            }

            protected EVIDENCIJARADNICIInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJARADNICIInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ForeignKeyNotFoundException()
            {
            }

            public ForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GOOBRACUNInvalidDeleteException : InvalidDeleteException
        {
            public GOOBRACUNInvalidDeleteException()
            {
            }

            public GOOBRACUNInvalidDeleteException(string message) : base(message)
            {
            }

            protected GOOBRACUNInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GOOBRACUNInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class gRESKA : UserException
        {
            public gRESKA()
            {
            }

            public gRESKA(string message) : base(message)
            {
            }

            protected gRESKA(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public gRESKA(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEKOEFForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public GRUPEKOEFForeignKeyNotFoundException()
            {
            }

            public GRUPEKOEFForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected GRUPEKOEFForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEOLAKSICAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public GRUPEOLAKSICAForeignKeyNotFoundException()
            {
            }

            public GRUPEOLAKSICAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected GRUPEOLAKSICAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEOLAKSICAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IPIDENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public IPIDENTForeignKeyNotFoundException()
            {
            }

            public IPIDENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected IPIDENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IPIDENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IRADNIK15IndexAlreadyExistsException : IndexAlreadyExistsException
        {
            public IRADNIK15IndexAlreadyExistsException()
            {
            }

            public IRADNIK15IndexAlreadyExistsException(string message) : base(message)
            {
            }

            protected IRADNIK15IndexAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRADNIK15IndexAlreadyExistsException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KREDITORForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public KREDITORForeignKeyNotFoundException()
            {
            }

            public KREDITORForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected KREDITORForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KREDITORForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunRadniciInvalidDeleteException : InvalidDeleteException
        {
            public ObracunRadniciInvalidDeleteException()
            {
            }

            public ObracunRadniciInvalidDeleteException(string message) : base(message)
            {
            }

            protected ObracunRadniciInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunRadniciInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBUSTAVAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OBUSTAVAForeignKeyNotFoundException()
            {
            }

            public OBUSTAVAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OBUSTAVAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBUSTAVAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OLAKSICEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OLAKSICEForeignKeyNotFoundException()
            {
            }

            public OLAKSICEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OLAKSICEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OLAKSICEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OPCINAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OPCINAForeignKeyNotFoundException()
            {
            }

            public OPCINAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OPCINAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OPCINAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGDIOForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ORGDIOForeignKeyNotFoundException()
            {
            }

            public ORGDIOForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ORGDIOForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGDIOForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSOBNIODBITAKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OSOBNIODBITAKForeignKeyNotFoundException()
            {
            }

            public OSOBNIODBITAKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OSOBNIODBITAKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSOBNIODBITAKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OTISLIInvalidDeleteException : InvalidDeleteException
        {
            public OTISLIInvalidDeleteException()
            {
            }

            public OTISLIInvalidDeleteException(string message) : base(message)
            {
            }

            protected OTISLIInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OTISLIInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIRADNIKInvalidDeleteException : InvalidDeleteException
        {
            public PRPLACEPRPLACEELEMENTIRADNIKInvalidDeleteException()
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIRADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKBrutoDataChangedException : DataChangedException
        {
            public RADNIKBrutoDataChangedException()
            {
            }

            public RADNIKBrutoDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKBrutoDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKBrutoDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKBrutoDataLockedException : DataLockedException
        {
            public RADNIKBrutoDataLockedException()
            {
            }

            public RADNIKBrutoDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKBrutoDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKBrutoDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKBrutoDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKBrutoDuplicateKeyException()
            {
            }

            public RADNIKBrutoDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKBrutoDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKBrutoDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKBrutoEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKBrutoRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKBrutoEventArgs(RADNIKDataSet.RADNIKBrutoRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKBrutoRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKBrutoUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKBrutoEventArgs e);

        [Serializable]
        public class RADNIKDataChangedException : DataChangedException
        {
            public RADNIKDataChangedException()
            {
            }

            public RADNIKDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKDataLockedException : DataLockedException
        {
            public RADNIKDataLockedException()
            {
            }

            public RADNIKDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKDuplicateKeyException()
            {
            }

            public RADNIKDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKEventArgs(RADNIKDataSet.RADNIKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        [Serializable]
        public class RADNIKIzuzeceOdOvrheDataChangedException : DataChangedException
        {
            public RADNIKIzuzeceOdOvrheDataChangedException()
            {
            }

            public RADNIKIzuzeceOdOvrheDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKIzuzeceOdOvrheDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKIzuzeceOdOvrheDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKIzuzeceOdOvrheDataLockedException : DataLockedException
        {
            public RADNIKIzuzeceOdOvrheDataLockedException()
            {
            }

            public RADNIKIzuzeceOdOvrheDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKIzuzeceOdOvrheDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKIzuzeceOdOvrheDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKIzuzeceOdOvrheDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKIzuzeceOdOvrheDuplicateKeyException()
            {
            }

            public RADNIKIzuzeceOdOvrheDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKIzuzeceOdOvrheDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKIzuzeceOdOvrheDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKIzuzeceOdOvrheEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKIzuzeceOdOvrheRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKIzuzeceOdOvrheEventArgs(RADNIKDataSet.RADNIKIzuzeceOdOvrheRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKIzuzeceOdOvrheRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKIzuzeceOdOvrheUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKIzuzeceOdOvrheEventArgs e);

        [Serializable]
        public class RADNIKKreditiDataChangedException : DataChangedException
        {
            public RADNIKKreditiDataChangedException()
            {
            }

            public RADNIKKreditiDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKKreditiDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKKreditiDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKKreditiDataLockedException : DataLockedException
        {
            public RADNIKKreditiDataLockedException()
            {
            }

            public RADNIKKreditiDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKKreditiDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKKreditiDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKKreditiDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKKreditiDuplicateKeyException()
            {
            }

            public RADNIKKreditiDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKKreditiDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKKreditiDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKKreditiEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKKreditiRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKKreditiEventArgs(RADNIKDataSet.RADNIKKreditiRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKKreditiRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKKreditiUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKKreditiEventArgs e);

        [Serializable]
        public class RADNIKLevel7DataChangedException : DataChangedException
        {
            public RADNIKLevel7DataChangedException()
            {
            }

            public RADNIKLevel7DataChangedException(string message) : base(message)
            {
            }

            protected RADNIKLevel7DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKLevel7DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKLevel7DataLockedException : DataLockedException
        {
            public RADNIKLevel7DataLockedException()
            {
            }

            public RADNIKLevel7DataLockedException(string message) : base(message)
            {
            }

            protected RADNIKLevel7DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKLevel7DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKLevel7DuplicateKeyException : DuplicateKeyException
        {
            public RADNIKLevel7DuplicateKeyException()
            {
            }

            public RADNIKLevel7DuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKLevel7DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKLevel7DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKLevel7EventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKLevel7Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKLevel7EventArgs(RADNIKDataSet.RADNIKLevel7Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKLevel7Row Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKLevel7UpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKLevel7EventArgs e);

        [Serializable]
        public class RADNIKNetoDataChangedException : DataChangedException
        {
            public RADNIKNetoDataChangedException()
            {
            }

            public RADNIKNetoDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKNetoDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKNetoDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKNetoDataLockedException : DataLockedException
        {
            public RADNIKNetoDataLockedException()
            {
            }

            public RADNIKNetoDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKNetoDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKNetoDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKNetoDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKNetoDuplicateKeyException()
            {
            }

            public RADNIKNetoDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKNetoDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKNetoDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKNetoEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKNetoRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKNetoEventArgs(RADNIKDataSet.RADNIKNetoRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKNetoRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKNetoUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKNetoEventArgs e);

        [Serializable]
        public class RADNIKNotFoundException : DataNotFoundException
        {
            public RADNIKNotFoundException()
            {
            }

            public RADNIKNotFoundException(string message) : base(message)
            {
            }

            protected RADNIKNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKObustavaDataChangedException : DataChangedException
        {
            public RADNIKObustavaDataChangedException()
            {
            }

            public RADNIKObustavaDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKObustavaDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKObustavaDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKObustavaDataLockedException : DataLockedException
        {
            public RADNIKObustavaDataLockedException()
            {
            }

            public RADNIKObustavaDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKObustavaDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKObustavaDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKObustavaDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKObustavaDuplicateKeyException()
            {
            }

            public RADNIKObustavaDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKObustavaDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKObustavaDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKObustavaEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKObustavaRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKObustavaEventArgs(RADNIKDataSet.RADNIKObustavaRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKObustavaRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKObustavaUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKObustavaEventArgs e);

        [Serializable]
        public class RADNIKOdbitakDataChangedException : DataChangedException
        {
            public RADNIKOdbitakDataChangedException()
            {
            }

            public RADNIKOdbitakDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKOdbitakDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOdbitakDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKOdbitakDataLockedException : DataLockedException
        {
            public RADNIKOdbitakDataLockedException()
            {
            }

            public RADNIKOdbitakDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKOdbitakDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOdbitakDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKOdbitakDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKOdbitakDuplicateKeyException()
            {
            }

            public RADNIKOdbitakDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKOdbitakDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOdbitakDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKOdbitakEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKOdbitakRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKOdbitakEventArgs(RADNIKDataSet.RADNIKOdbitakRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKOdbitakRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKOdbitakUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKOdbitakEventArgs e);

        [Serializable]
        public class RADNIKOlaksicaDataChangedException : DataChangedException
        {
            public RADNIKOlaksicaDataChangedException()
            {
            }

            public RADNIKOlaksicaDataChangedException(string message) : base(message)
            {
            }

            protected RADNIKOlaksicaDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOlaksicaDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKOlaksicaDataLockedException : DataLockedException
        {
            public RADNIKOlaksicaDataLockedException()
            {
            }

            public RADNIKOlaksicaDataLockedException(string message) : base(message)
            {
            }

            protected RADNIKOlaksicaDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOlaksicaDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKOlaksicaDuplicateKeyException : DuplicateKeyException
        {
            public RADNIKOlaksicaDuplicateKeyException()
            {
            }

            public RADNIKOlaksicaDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNIKOlaksicaDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOlaksicaDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNIKOlaksicaEventArgs : EventArgs
        {
            private RADNIKDataSet.RADNIKOlaksicaRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNIKOlaksicaEventArgs(RADNIKDataSet.RADNIKOlaksicaRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNIKDataSet.RADNIKOlaksicaRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RADNIKOlaksicaUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKOlaksicaEventArgs e);

        public delegate void RADNIKUpdateEventHandler(object sender, RADNIKDataAdapter.RADNIKEventArgs e);

        [Serializable]
        public class RADNOMJESTOForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNOMJESTOForeignKeyNotFoundException()
            {
            }

            public RADNOMJESTOForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNOMJESTOForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOMJESTOForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNOVRIJEMEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNOVRIJEMEForeignKeyNotFoundException()
            {
            }

            public RADNOVRIJEMEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNOVRIJEMEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOVRIJEMEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException()
            {
            }

            public SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SKUPPOREZAIDOPRINOSAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SPOLForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public SPOLForeignKeyNotFoundException()
            {
            }

            public SPOLForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected SPOLForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SPOLForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUCNASPREMAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public STRUCNASPREMAForeignKeyNotFoundException()
            {
            }

            public STRUCNASPREMAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected STRUCNASPREMAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUCNASPREMAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUKAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public STRUKAForeignKeyNotFoundException()
            {
            }

            public STRUKAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected STRUKAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUKAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPOLAKSICEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TIPOLAKSICEForeignKeyNotFoundException()
            {
            }

            public TIPOLAKSICEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TIPOLAKSICEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPOLAKSICEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TITULAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TITULAForeignKeyNotFoundException()
            {
            }

            public TITULAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TITULAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TITULAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UGOVORORADUForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public UGOVORORADUForeignKeyNotFoundException()
            {
            }

            public UGOVORORADUForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected UGOVORORADUForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UGOVORORADUForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTEOBUSTAVAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public VRSTEOBUSTAVAForeignKeyNotFoundException()
            {
            }

            public VRSTEOBUSTAVAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected VRSTEOBUSTAVAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTEOBUSTAVAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ZAPOSLENIInvalidDeleteException : InvalidDeleteException
        {
            public ZAPOSLENIInvalidDeleteException()
            {
            }

            public ZAPOSLENIInvalidDeleteException(string message) : base(message)
            {
            }

            protected ZAPOSLENIInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZAPOSLENIInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

