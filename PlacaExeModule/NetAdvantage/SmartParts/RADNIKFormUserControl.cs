namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Resources;
    using Deklarit.Win;
    using Deklarit.WinHelper;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinTabControl;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class RADNIKFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkAKTIVAN")]
        private UltraCheckEditor _checkAKTIVAN;
        [AccessedThroughProperty("checkUZIMAUOBZIROSNOVICEDOPRINOSA")]
        private UltraCheckEditor _checkUZIMAUOBZIROSNOVICEDOPRINOSA;
        [AccessedThroughProperty("checkZBIRNINETO")]
        private UltraCheckEditor _checkZBIRNINETO;
        [AccessedThroughProperty("comboIDBENEFICIRANI")]
        private BENEFICIRANIComboBox _comboIDBENEFICIRANI;
        [AccessedThroughProperty("comboIDBRACNOSTANJE")]
        private BRACNOSTANJEComboBox _comboIDBRACNOSTANJE;
        [AccessedThroughProperty("comboIDDRZAVLJANSTVO")]
        private DRZAVLJANSTVOComboBox _comboIDDRZAVLJANSTVO;
        [AccessedThroughProperty("comboIDIPIDENT")]
        private IPIDENTComboBox _comboIDIPIDENT;
        [AccessedThroughProperty("comboIDORGDIO")]
        private ORGDIOComboBox _comboIDORGDIO;
        [AccessedThroughProperty("comboIDRADNOMJESTO")]
        private RADNOMJESTOComboBox _comboIDRADNOMJESTO;
        [AccessedThroughProperty("comboIDSPOL")]
        private SPOLComboBox _comboIDSPOL;
        [AccessedThroughProperty("comboIDSTRUKA")]
        private STRUKAComboBox _comboIDSTRUKA;
        [AccessedThroughProperty("comboIDTITULA")]
        private TITULAComboBox _comboIDTITULA;
        [AccessedThroughProperty("comboIDUGOVORORADU")]
        private UGOVORORADUComboBox _comboIDUGOVORORADU;
        [AccessedThroughProperty("comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA")]
        private STRUCNASPREMAComboBox _comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
        [AccessedThroughProperty("comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA")]
        private SKUPPOREZAIDOPRINOSAComboBox _comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
        [AccessedThroughProperty("comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA")]
        private STRUCNASPREMAComboBox _comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMPRESTANKARADNOGODNOSA")]
        private UltraDateTimeEditor _datePickerDATUMPRESTANKARADNOGODNOSA;
        [AccessedThroughProperty("datePickerDATUMRODJENJA")]
        private UltraDateTimeEditor _datePickerDATUMRODJENJA;
        [AccessedThroughProperty("datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI")]
        private UltraDateTimeEditor _datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
        [AccessedThroughProperty("datePickerPOCETAKRADA")]
        private UltraDateTimeEditor _datePickerPOCETAKRADA;
        [AccessedThroughProperty("datePickerUGOVOROD")]
        private UltraDateTimeEditor _datePickerUGOVOROD;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelRADNIKBruto")]
        private UltraGrid _grdLevelRADNIKBruto;
        [AccessedThroughProperty("grdLevelRADNIKIzuzeceOdOvrhe")]
        private UltraGrid _grdLevelRADNIKIzuzeceOdOvrhe;
        [AccessedThroughProperty("grdLevelRADNIKKrediti")]
        private UltraGrid _grdLevelRADNIKKrediti;
        [AccessedThroughProperty("grdLevelRADNIKLevel7")]
        private UltraGrid _grdLevelRADNIKLevel7;
        [AccessedThroughProperty("grdLevelRADNIKNeto")]
        private UltraGrid _grdLevelRADNIKNeto;
        [AccessedThroughProperty("grdLevelRADNIKObustava")]
        private UltraGrid _grdLevelRADNIKObustava;
        [AccessedThroughProperty("grdLevelRADNIKOdbitak")]
        private UltraGrid _grdLevelRADNIKOdbitak;
        [AccessedThroughProperty("grdLevelRADNIKOlaksica")]
        private UltraGrid _grdLevelRADNIKOlaksica;
        [AccessedThroughProperty("Group2")]
        private UltraGroupBox _Group2;
        [AccessedThroughProperty("Group3")]
        private UltraGroupBox _Group3;
        [AccessedThroughProperty("Group4")]
        private UltraGroupBox _Group4;
        [AccessedThroughProperty("Group5")]
        private UltraGroupBox _Group5;
        [AccessedThroughProperty("Group6")]
        private UltraGroupBox _Group6;
        [AccessedThroughProperty("KreditiPage")]
        private UltraTabPageControl _KreditiPage;
        [AccessedThroughProperty("label1AKTIVAN")]
        private UltraLabel _label1AKTIVAN;
        [AccessedThroughProperty("label1BROJMIROVINSKOG")]
        private UltraLabel _label1BROJMIROVINSKOG;
        [AccessedThroughProperty("label1BROJZDRAVSTVENOG")]
        private UltraLabel _label1BROJZDRAVSTVENOG;
        [AccessedThroughProperty("label1DANISTAZA")]
        private UltraLabel _label1DANISTAZA;
        [AccessedThroughProperty("label1DANISTAZAPRO")]
        private UltraLabel _label1DANISTAZAPRO;
        [AccessedThroughProperty("label1DATUMPRESTANKARADNOGODNOSA")]
        private UltraLabel _label1DATUMPRESTANKARADNOGODNOSA;
        [AccessedThroughProperty("label1DATUMRODJENJA")]
        private UltraLabel _label1DATUMRODJENJA;
        [AccessedThroughProperty("label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI")]
        private UltraLabel _label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
        [AccessedThroughProperty("label1GODINESTAZA")]
        private UltraLabel _label1GODINESTAZA;
        [AccessedThroughProperty("label1GODINESTAZAPRO")]
        private UltraLabel _label1GODINESTAZAPRO;
        [AccessedThroughProperty("label1IDBANKE")]
        private UltraLabel _label1IDBANKE;
        [AccessedThroughProperty("label1IDBENEFICIRANI")]
        private UltraLabel _label1IDBENEFICIRANI;
        [AccessedThroughProperty("label1IDBRACNOSTANJE")]
        private UltraLabel _label1IDBRACNOSTANJE;
        [AccessedThroughProperty("label1IDDRZAVLJANSTVO")]
        private UltraLabel _label1IDDRZAVLJANSTVO;
        [AccessedThroughProperty("label1IDIPIDENT")]
        private UltraLabel _label1IDIPIDENT;
        [AccessedThroughProperty("label1IDORGDIO")]
        private UltraLabel _label1IDORGDIO;
        [AccessedThroughProperty("label1IDRADNIK")]
        private UltraLabel _label1IDRADNIK;
        [AccessedThroughProperty("label1IDRADNOMJESTO")]
        private UltraLabel _label1IDRADNOMJESTO;
        [AccessedThroughProperty("label1IDRADNOVRIJEME")]
        private UltraLabel _label1IDRADNOVRIJEME;
        [AccessedThroughProperty("label1IDSPOL")]
        private UltraLabel _label1IDSPOL;
        [AccessedThroughProperty("label1IDSTRUKA")]
        private UltraLabel _label1IDSTRUKA;
        [AccessedThroughProperty("label1IDTITULA")]
        private UltraLabel _label1IDTITULA;
        [AccessedThroughProperty("label1IDUGOVORORADU")]
        private UltraLabel _label1IDUGOVORORADU;
        [AccessedThroughProperty("label1IME")]
        private UltraLabel _label1IME;
        [AccessedThroughProperty("label1JMBG")]
        private UltraLabel _label1JMBG;
        [AccessedThroughProperty("label1KOEFICIJENT")]
        private UltraLabel _label1KOEFICIJENT;
        [AccessedThroughProperty("label1kucnibroj")]
        private UltraLabel _label1kucnibroj;
        [AccessedThroughProperty("label1MBO")]
        private UltraLabel _label1MBO;
        [AccessedThroughProperty("label1MJESECISTAZA")]
        private UltraLabel _label1MJESECISTAZA;
        [AccessedThroughProperty("label1MJESECISTAZAPRO")]
        private UltraLabel _label1MJESECISTAZAPRO;
        [AccessedThroughProperty("label1mjesto")]
        private UltraLabel _label1mjesto;
        [AccessedThroughProperty("label1MO")]
        private UltraLabel _label1MO;
        [AccessedThroughProperty("label1NAZIVBANKE1")]
        private UltraLabel _label1NAZIVBANKE1;
        [AccessedThroughProperty("label1NAZIVPOSLA")]
        private UltraLabel _label1NAZIVPOSLA;
        [AccessedThroughProperty("label1OIB")]
        private UltraLabel _label1OIB;
        [AccessedThroughProperty("label1OPCINARADAIDOPCINE")]
        private UltraLabel _label1OPCINARADAIDOPCINE;
        [AccessedThroughProperty("label1OPCINARADANAZIVOPCINE")]
        private UltraLabel _label1OPCINARADANAZIVOPCINE;
        [AccessedThroughProperty("label1OPCINASTANOVANJAIDOPCINE")]
        private UltraLabel _label1OPCINASTANOVANJAIDOPCINE;
        [AccessedThroughProperty("label1OPCINASTANOVANJANAZIVOPCINE")]
        private UltraLabel _label1OPCINASTANOVANJANAZIVOPCINE;
        [AccessedThroughProperty("label1OPCINASTANOVANJAPRIREZ")]
        private UltraLabel _label1OPCINASTANOVANJAPRIREZ;
        [AccessedThroughProperty("label1OPISPLACANJANETO")]
        private UltraLabel _label1OPISPLACANJANETO;
        [AccessedThroughProperty("label1PBO")]
        private UltraLabel _label1PBO;
        [AccessedThroughProperty("label1POCETAKRADA")]
        private UltraLabel _label1POCETAKRADA;
        [AccessedThroughProperty("label1POSTOTAKOSLOBODJENJAODPOREZA")]
        private UltraLabel _label1POSTOTAKOSLOBODJENJAODPOREZA;
        [AccessedThroughProperty("label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA")]
        private UltraLabel _label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
        [AccessedThroughProperty("label1PREZIME")]
        private UltraLabel _label1PREZIME;
        [AccessedThroughProperty("label1PRODUZENOMIROVINSKO")]
        private UltraLabel _label1PRODUZENOMIROVINSKO;
        [AccessedThroughProperty("label1RADNADOZVOLA")]
        private UltraLabel _label1RADNADOZVOLA;
        [AccessedThroughProperty("label1RADNASPOSOBNOST")]
        private UltraLabel _label1RADNASPOSOBNOST;
        [AccessedThroughProperty("label1RADNIKNAPOMENA")]
        private UltraLabel _label1RADNIKNAPOMENA;
        [AccessedThroughProperty("label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA")]
        private UltraLabel _label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
        [AccessedThroughProperty("label1RADUINOZEMSTVU")]
        private UltraLabel _label1RADUINOZEMSTVU;
        [AccessedThroughProperty("label1RAZLOGPRESTANKA")]
        private UltraLabel _label1RAZLOGPRESTANKA;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJANETO")]
        private UltraLabel _label1SIFRAOPISAPLACANJANETO;
        [AccessedThroughProperty("label1TEKUCI")]
        private UltraLabel _label1TEKUCI;
        [AccessedThroughProperty("label1TJEDNIFONDSATI")]
        private UltraLabel _label1TJEDNIFONDSATI;
        [AccessedThroughProperty("label1TJEDNIFONDSATISTAZ")]
        private UltraLabel _label1TJEDNIFONDSATISTAZ;
        [AccessedThroughProperty("label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA")]
        private UltraLabel _label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
        [AccessedThroughProperty("label1UGOVOROD")]
        private UltraLabel _label1UGOVOROD;
        [AccessedThroughProperty("label1UKUPNODANASTAZA")]
        private UltraLabel _label1UKUPNODANASTAZA;
        [AccessedThroughProperty("label1UKUPNOGODINESTAZA")]
        private UltraLabel _label1UKUPNOGODINESTAZA;
        [AccessedThroughProperty("label1UKUPNOMJESECISTAZA")]
        private UltraLabel _label1UKUPNOMJESECISTAZA;
        [AccessedThroughProperty("label1ulica")]
        private UltraLabel _label1ulica;
        [AccessedThroughProperty("label1UZIMAUOBZIROSNOVICEDOPRINOSA")]
        private UltraLabel _label1UZIMAUOBZIROSNOVICEDOPRINOSA;
        [AccessedThroughProperty("label1VRIJEMEMIROVANJARADNOGODNOSA")]
        private UltraLabel _label1VRIJEMEMIROVANJARADNOGODNOSA;
        [AccessedThroughProperty("label1VRIJEMEPRIPRAVNICKOG")]
        private UltraLabel _label1VRIJEMEPRIPRAVNICKOG;
        [AccessedThroughProperty("label1VRIJEMEPROBNOGRADA")]
        private UltraLabel _label1VRIJEMEPROBNOGRADA;
        [AccessedThroughProperty("label1VRIJEMESTRUCNI")]
        private UltraLabel _label1VRIJEMESTRUCNI;
        [AccessedThroughProperty("label1ZABRANANATJECANJA")]
        private UltraLabel _label1ZABRANANATJECANJA;
        [AccessedThroughProperty("label1ZAVRSENASKOLA")]
        private UltraLabel _label1ZAVRSENASKOLA;
        [AccessedThroughProperty("label1ZBIRNINETO")]
        private UltraLabel _label1ZBIRNINETO;
        [AccessedThroughProperty("labelNAZIVBANKE1")]
        private UltraLabel _labelNAZIVBANKE1;
        [AccessedThroughProperty("labelOPCINARADANAZIVOPCINE")]
        private UltraLabel _labelOPCINARADANAZIVOPCINE;
        [AccessedThroughProperty("labelOPCINASTANOVANJANAZIVOPCINE")]
        private UltraLabel _labelOPCINASTANOVANJANAZIVOPCINE;
        [AccessedThroughProperty("labelOPCINASTANOVANJAPRIREZ")]
        private UltraLabel _labelOPCINASTANOVANJAPRIREZ;
        [AccessedThroughProperty("labelUKUPNODANASTAZA")]
        private UltraLabel _labelUKUPNODANASTAZA;
        [AccessedThroughProperty("labelUKUPNOGODINESTAZA")]
        private UltraLabel _labelUKUPNOGODINESTAZA;
        [AccessedThroughProperty("labelUKUPNOMJESECISTAZA")]
        private UltraLabel _labelUKUPNOMJESECISTAZA;
        [AccessedThroughProperty("Level4Page")]
        private UltraTabPageControl _Level4Page;
        [AccessedThroughProperty("linkLabelRADNIKBruto")]
        private UltraLabel _linkLabelRADNIKBruto;
        [AccessedThroughProperty("linkLabelRADNIKBrutoAdd")]
        private UltraLabel _linkLabelRADNIKBrutoAdd;
        [AccessedThroughProperty("linkLabelRADNIKBrutoDelete")]
        private UltraLabel _linkLabelRADNIKBrutoDelete;
        [AccessedThroughProperty("linkLabelRADNIKBrutoUpdate")]
        private UltraLabel _linkLabelRADNIKBrutoUpdate;
        [AccessedThroughProperty("linkLabelRADNIKIzuzeceOdOvrhe")]
        private UltraLabel _linkLabelRADNIKIzuzeceOdOvrhe;
        [AccessedThroughProperty("linkLabelRADNIKIzuzeceOdOvrheAdd")]
        private UltraLabel _linkLabelRADNIKIzuzeceOdOvrheAdd;
        [AccessedThroughProperty("linkLabelRADNIKIzuzeceOdOvrheDelete")]
        private UltraLabel _linkLabelRADNIKIzuzeceOdOvrheDelete;
        [AccessedThroughProperty("linkLabelRADNIKIzuzeceOdOvrheUpdate")]
        private UltraLabel _linkLabelRADNIKIzuzeceOdOvrheUpdate;
        [AccessedThroughProperty("linkLabelRADNIKKrediti")]
        private UltraLabel _linkLabelRADNIKKrediti;
        [AccessedThroughProperty("linkLabelRADNIKKreditiAdd")]
        private UltraLabel _linkLabelRADNIKKreditiAdd;
        [AccessedThroughProperty("linkLabelRADNIKKreditiDelete")]
        private UltraLabel _linkLabelRADNIKKreditiDelete;
        [AccessedThroughProperty("linkLabelRADNIKKreditiUpdate")]
        private UltraLabel _linkLabelRADNIKKreditiUpdate;
        [AccessedThroughProperty("linkLabelRADNIKLevel7")]
        private UltraLabel _linkLabelRADNIKLevel7;
        [AccessedThroughProperty("linkLabelRADNIKLevel7Add")]
        private UltraLabel _linkLabelRADNIKLevel7Add;
        [AccessedThroughProperty("linkLabelRADNIKLevel7Delete")]
        private UltraLabel _linkLabelRADNIKLevel7Delete;
        [AccessedThroughProperty("linkLabelRADNIKLevel7Update")]
        private UltraLabel _linkLabelRADNIKLevel7Update;
        [AccessedThroughProperty("linkLabelRADNIKNeto")]
        private UltraLabel _linkLabelRADNIKNeto;
        [AccessedThroughProperty("linkLabelRADNIKNetoAdd")]
        private UltraLabel _linkLabelRADNIKNetoAdd;
        [AccessedThroughProperty("linkLabelRADNIKNetoDelete")]
        private UltraLabel _linkLabelRADNIKNetoDelete;
        [AccessedThroughProperty("linkLabelRADNIKNetoUpdate")]
        private UltraLabel _linkLabelRADNIKNetoUpdate;
        [AccessedThroughProperty("linkLabelRADNIKObustava")]
        private UltraLabel _linkLabelRADNIKObustava;
        [AccessedThroughProperty("linkLabelRADNIKObustavaAdd")]
        private UltraLabel _linkLabelRADNIKObustavaAdd;
        [AccessedThroughProperty("linkLabelRADNIKObustavaDelete")]
        private UltraLabel _linkLabelRADNIKObustavaDelete;
        [AccessedThroughProperty("linkLabelRADNIKObustavaUpdate")]
        private UltraLabel _linkLabelRADNIKObustavaUpdate;
        [AccessedThroughProperty("linkLabelRADNIKOdbitak")]
        private UltraLabel _linkLabelRADNIKOdbitak;
        [AccessedThroughProperty("linkLabelRADNIKOdbitakAdd")]
        private UltraLabel _linkLabelRADNIKOdbitakAdd;
        [AccessedThroughProperty("linkLabelRADNIKOdbitakDelete")]
        private UltraLabel _linkLabelRADNIKOdbitakDelete;
        [AccessedThroughProperty("linkLabelRADNIKOdbitakUpdate")]
        private UltraLabel _linkLabelRADNIKOdbitakUpdate;
        [AccessedThroughProperty("linkLabelRADNIKOlaksica")]
        private UltraLabel _linkLabelRADNIKOlaksica;
        [AccessedThroughProperty("linkLabelRADNIKOlaksicaAdd")]
        private UltraLabel _linkLabelRADNIKOlaksicaAdd;
        [AccessedThroughProperty("linkLabelRADNIKOlaksicaDelete")]
        private UltraLabel _linkLabelRADNIKOlaksicaDelete;
        [AccessedThroughProperty("linkLabelRADNIKOlaksicaUpdate")]
        private UltraLabel _linkLabelRADNIKOlaksicaUpdate;
        [AccessedThroughProperty("OsobniOdbitakPage")]
        private UltraTabPageControl _OsobniOdbitakPage;
        [AccessedThroughProperty("panelactionsRADNIKBruto")]
        private Panel _panelactionsRADNIKBruto;
        [AccessedThroughProperty("panelactionsRADNIKIzuzeceOdOvrhe")]
        private Panel _panelactionsRADNIKIzuzeceOdOvrhe;
        [AccessedThroughProperty("panelactionsRADNIKKrediti")]
        private Panel _panelactionsRADNIKKrediti;
        [AccessedThroughProperty("panelactionsRADNIKLevel7")]
        private Panel _panelactionsRADNIKLevel7;
        [AccessedThroughProperty("panelactionsRADNIKNeto")]
        private Panel _panelactionsRADNIKNeto;
        [AccessedThroughProperty("panelactionsRADNIKObustava")]
        private Panel _panelactionsRADNIKObustava;
        [AccessedThroughProperty("panelactionsRADNIKOdbitak")]
        private Panel _panelactionsRADNIKOdbitak;
        [AccessedThroughProperty("panelactionsRADNIKOlaksica")]
        private Panel _panelactionsRADNIKOlaksica;
        [AccessedThroughProperty("RADNIKLevel4Page")]
        private UltraTabPageControl _RADNIKLevel4Page;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("Tab1")]
        private UltraTabControl _Tab1;
        [AccessedThroughProperty("Tab2")]
        private UltraTabControl _Tab2;
        [AccessedThroughProperty("TabPage1")]
        private UltraTabPageControl _TabPage1;
        [AccessedThroughProperty("TabPage10")]
        private UltraTabPageControl _TabPage10;
        [AccessedThroughProperty("TabPage2")]
        private UltraTabPageControl _TabPage2;
        [AccessedThroughProperty("TabPage3")]
        private UltraTabPageControl _TabPage3;
        [AccessedThroughProperty("TabPage4")]
        private UltraTabPageControl _TabPage4;
        [AccessedThroughProperty("TabPage5")]
        private UltraTabPageControl _TabPage5;
        [AccessedThroughProperty("TabPage6")]
        private UltraTabPageControl _TabPage6;
        [AccessedThroughProperty("TabPage7")]
        private UltraTabPageControl _TabPage7;
        [AccessedThroughProperty("TabPage8")]
        private UltraTabPageControl _TabPage8;
        [AccessedThroughProperty("TabPage9")]
        private UltraTabPageControl _TabPage9;
        [AccessedThroughProperty("textBROJMIROVINSKOG")]
        private UltraTextEditor _textBROJMIROVINSKOG;
        [AccessedThroughProperty("textBROJZDRAVSTVENOG")]
        private UltraTextEditor _textBROJZDRAVSTVENOG;
        [AccessedThroughProperty("textDANISTAZA")]
        private UltraNumericEditor _textDANISTAZA;
        [AccessedThroughProperty("textDANISTAZAPRO")]
        private UltraNumericEditor _textDANISTAZAPRO;
        [AccessedThroughProperty("textGODINESTAZA")]
        private UltraNumericEditor _textGODINESTAZA;
        [AccessedThroughProperty("textGODINESTAZAPRO")]
        private UltraNumericEditor _textGODINESTAZAPRO;
        [AccessedThroughProperty("textIDBANKE")]
        private UltraNumericEditor _textIDBANKE;
        [AccessedThroughProperty("textIDRADNIK")]
        private UltraNumericEditor _textIDRADNIK;
        [AccessedThroughProperty("textIDRADNOVRIJEME")]
        private UltraNumericEditor _textIDRADNOVRIJEME;
        [AccessedThroughProperty("textIME")]
        private UltraTextEditor _textIME;
        [AccessedThroughProperty("textJMBG")]
        private UltraTextEditor _textJMBG;
        [AccessedThroughProperty("textKOEFICIJENT")]
        private UltraNumericEditor _textKOEFICIJENT;
        [AccessedThroughProperty("textkucnibroj")]
        private UltraTextEditor _textkucnibroj;
        [AccessedThroughProperty("textMBO")]
        private UltraTextEditor _textMBO;
        [AccessedThroughProperty("textMJESECISTAZA")]
        private UltraNumericEditor _textMJESECISTAZA;
        [AccessedThroughProperty("textMJESECISTAZAPRO")]
        private UltraNumericEditor _textMJESECISTAZAPRO;
        [AccessedThroughProperty("textmjesto")]
        private UltraTextEditor _textmjesto;
        [AccessedThroughProperty("textMO")]
        private UltraTextEditor _textMO;
        [AccessedThroughProperty("textNAZIVPOSLA")]
        private UltraTextEditor _textNAZIVPOSLA;
        [AccessedThroughProperty("textOIB")]
        private UltraTextEditor _textOIB;
        [AccessedThroughProperty("textOPCINARADAIDOPCINE")]
        private UltraTextEditor _textOPCINARADAIDOPCINE;
        [AccessedThroughProperty("textOPCINASTANOVANJAIDOPCINE")]
        private UltraTextEditor _textOPCINASTANOVANJAIDOPCINE;
        [AccessedThroughProperty("textOPISPLACANJANETO")]
        private UltraTextEditor _textOPISPLACANJANETO;
        [AccessedThroughProperty("textPBO")]
        private UltraTextEditor _textPBO;
        [AccessedThroughProperty("textPOSTOTAKOSLOBODJENJAODPOREZA")]
        private UltraNumericEditor _textPOSTOTAKOSLOBODJENJAODPOREZA;
        [AccessedThroughProperty("textPREZIME")]
        private UltraTextEditor _textPREZIME;
        [AccessedThroughProperty("textPRODUZENOMIROVINSKO")]
        private UltraTextEditor _textPRODUZENOMIROVINSKO;
        [AccessedThroughProperty("textRADNADOZVOLA")]
        private UltraTextEditor _textRADNADOZVOLA;
        [AccessedThroughProperty("textRADNASPOSOBNOST")]
        private UltraTextEditor _textRADNASPOSOBNOST;
        [AccessedThroughProperty("textRADNIKNAPOMENA")]
        private UltraTextEditor _textRADNIKNAPOMENA;
        [AccessedThroughProperty("textRADUINOZEMSTVU")]
        private UltraTextEditor _textRADUINOZEMSTVU;
        [AccessedThroughProperty("textRAZLOGPRESTANKA")]
        private UltraTextEditor _textRAZLOGPRESTANKA;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJANETO")]
        private UltraTextEditor _textSIFRAOPISAPLACANJANETO;
        [AccessedThroughProperty("textTEKUCI")]
        private UltraTextEditor _textTEKUCI;
        [AccessedThroughProperty("textTJEDNIFONDSATI")]
        private UltraNumericEditor _textTJEDNIFONDSATI;
        [AccessedThroughProperty("textTJEDNIFONDSATISTAZ")]
        private UltraNumericEditor _textTJEDNIFONDSATISTAZ;
        [AccessedThroughProperty("textulica")]
        private UltraTextEditor _textulica;
        [AccessedThroughProperty("textVRIJEMEMIROVANJARADNOGODNOSA")]
        private UltraTextEditor _textVRIJEMEMIROVANJARADNOGODNOSA;
        [AccessedThroughProperty("textVRIJEMEPRIPRAVNICKOG")]
        private UltraTextEditor _textVRIJEMEPRIPRAVNICKOG;
        [AccessedThroughProperty("textVRIJEMEPROBNOGRADA")]
        private UltraTextEditor _textVRIJEMEPROBNOGRADA;
        [AccessedThroughProperty("textVRIJEMESTRUCNI")]
        private UltraTextEditor _textVRIJEMESTRUCNI;
        [AccessedThroughProperty("textZABRANANATJECANJA")]
        private UltraTextEditor _textZABRANANATJECANJA;
        [AccessedThroughProperty("textZAVRSENASKOLA")]
        private UltraTextEditor _textZAVRSENASKOLA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIK;
        private BindingSource bindingSourceRADNIKBruto;
        private BindingSource bindingSourceRADNIKIzuzeceOdOvrhe;
        private BindingSource bindingSourceRADNIKKrediti;
        private BindingSource bindingSourceRADNIKLevel7;
        private BindingSource bindingSourceRADNIKNeto;
        private BindingSource bindingSourceRADNIKObustava;
        private BindingSource bindingSourceRADNIKOdbitak;
        private BindingSource bindingSourceRADNIKOlaksica;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIK;
        protected TableLayoutPanel layoutManagerGroup2;
        protected TableLayoutPanel layoutManagerGroup3;
        protected TableLayoutPanel layoutManagerGroup4;
        protected TableLayoutPanel layoutManagerGroup5;
        protected TableLayoutPanel layoutManagerGroup6;
        protected TableLayoutPanel layoutManagerKreditiPage;
        protected TableLayoutPanel layoutManagerLevel4Page;
        protected TableLayoutPanel layoutManagerOsobniOdbitakPage;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKBruto;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKKrediti;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKLevel7;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKNeto;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKObustava;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKOdbitak;
        protected TableLayoutPanel layoutManagerpanelactionsRADNIKOlaksica;
        protected TableLayoutPanel layoutManagerRADNIKLevel4Page;
        protected TableLayoutPanel layoutManagerTabPage1;
        protected TableLayoutPanel layoutManagerTabPage10;
        protected TableLayoutPanel layoutManagerTabPage2;
        protected TableLayoutPanel layoutManagerTabPage3;
        protected TableLayoutPanel layoutManagerTabPage4;
        protected TableLayoutPanel layoutManagerTabPage5;
        protected TableLayoutPanel layoutManagerTabPage6;
        protected TableLayoutPanel layoutManagerTabPage7;
        protected TableLayoutPanel layoutManagerTabPage8;
        protected TableLayoutPanel layoutManagerTabPage9;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIK";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RADNIKFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptBANKEIDBANKE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectBANKEIDBANKE(fillMethod, fillByRow);
            this.UpdateValuesBANKEIDBANKE(result);
        }

        private void CallPromptInLinesBANKEBANKAZASTICENOIDBANKE(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.RADNIKController.SelectBANKEBANKAZASTICENOIDBANKE("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["BANKAZASTICENOIDBANKE"] = RuntimeHelpers.GetObjectValue(row2["IDBANKE"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesKREDITORZADKREDITIIDKREDITOR(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.RADNIKController.SelectKREDITORZADKREDITIIDKREDITOR("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["ZADKREDITIIDKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["IDKREDITOR"]);
                    row3["ZADKREDITINAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["NAZIVKREDITOR"]);
                    row3["ZADKREDITIPRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKREDITOR1"]);
                    row3["ZADKREDITIPRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKREDITOR2"]);
                    row3["ZADKREDITIPRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJKREDITOR3"]);
                    row3["ZADKREDITIVBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["VBDIKREDITOR"]);
                    row3["ZADKREDITIZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(row2["ZRNKREDITOR"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesOBUSTAVAZADOBUSTAVAIDOBUSTAVA(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.RADNIKController.SelectOBUSTAVAZADOBUSTAVAIDOBUSTAVA("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["ZADOBUSTAVAIDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["IDOBUSTAVA"]);
                    row3["ZADOBUSTAVANAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["NAZIVOBUSTAVA"]);
                    row3["ZADOBUSTAVAZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["ZRNOBUSTAVA"]);
                    row3["ZADOBUSTAVAVBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(row2["VBDIOBUSTAVA"]);
                    row3["ZADOBUSTAVAVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(row2["VRSTAOBUSTAVE"]);
                    row3["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(row2["NAZIVVRSTAOBUSTAVE"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesOLAKSICEZADOLAKSICEIDOLAKSICE(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.RADNIKController.SelectOLAKSICEZADOLAKSICEIDOLAKSICE("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["ZADOLAKSICEIDOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["IDOLAKSICE"]);
                    row3["ZADOLAKSICENAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["NAZIVOLAKSICE"]);
                    row3["ZADOLAKSICEVBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["VBDIOLAKSICA"]);
                    row3["ZADOLAKSICEZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["ZRNOLAKSICA"]);
                    row3["ZADOLAKSICEPRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOLAKSICA1"]);
                    row3["ZADOLAKSICEPRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOLAKSICA2"]);
                    row3["ZADOLAKSICEPRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJOLAKSICA3"]);
                    row3["ZADOLAKSICEIDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["IDGRUPEOLAKSICA"]);
                    row3["ZADOLAKSICEIDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["IDTIPOLAKSICE"]);
                    row3["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(row2["MAXIMALNIIZNOSGRUPE"]);
                    row3["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(row2["NAZIVGRUPEOLAKSICA"]);
                    row3["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(row2["NAZIVTIPOLAKSICE"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.RADNIKController.SelectOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(row2["IDOSOBNIODBITAK"]);
                    row3["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(row2["NAZIVOSOBNIODBITAK"]);
                    row3["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(row2["FAKTOROSOBNOGODBITKA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptOPCINAOPCINARADAIDOPCINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectOPCINAOPCINARADAIDOPCINE(fillMethod, fillByRow);
            this.UpdateValuesOPCINAOPCINARADAIDOPCINE(result);
        }

        private void CallPromptOPCINAOPCINASTANOVANJAIDOPCINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectOPCINAOPCINASTANOVANJAIDOPCINE(fillMethod, fillByRow);
            this.UpdateValuesOPCINAOPCINASTANOVANJAIDOPCINE(result);
        }

        private void CallPromptRADNOVRIJEMEIDRADNOVRIJEME(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectRADNOVRIJEMEIDRADNOVRIJEME(fillMethod, fillByRow);
            this.UpdateValuesRADNOVRIJEMEIDRADNOVRIJEME(result);
        }

        private void CallViewBANKEIDBANKE(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowBANKEIDBANKE(this.m_CurrentRow);
            this.UpdateValuesBANKEIDBANKE(result);
        }

        private void CallViewOPCINAOPCINARADAIDOPCINE(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowOPCINAOPCINARADAIDOPCINE(this.m_CurrentRow);
            this.UpdateValuesOPCINAOPCINARADAIDOPCINE(result);
        }

        private void CallViewOPCINAOPCINASTANOVANJAIDOPCINE(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowOPCINAOPCINASTANOVANJAIDOPCINE(this.m_CurrentRow);
            this.UpdateValuesOPCINAOPCINASTANOVANJAIDOPCINE(result);
        }

        private void CallViewRADNOVRIJEMEIDRADNOVRIJEME(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowRADNOVRIJEMEIDRADNOVRIJEME(this.m_CurrentRow);
            this.UpdateValuesRADNOVRIJEMEIDRADNOVRIJEME(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIK.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/BENEFICIRANI", Thread=ThreadOption.UserInterface)]
        public void comboIDBENEFICIRANI_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDBENEFICIRANI.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/BRACNOSTANJE", Thread=ThreadOption.UserInterface)]
        public void comboIDBRACNOSTANJE_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDBRACNOSTANJE.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/DRZAVLJANSTVO", Thread=ThreadOption.UserInterface)]
        public void comboIDDRZAVLJANSTVO_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDDRZAVLJANSTVO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/IPIDENT", Thread=ThreadOption.UserInterface)]
        public void comboIDIPIDENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDIPIDENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGDIO", Thread=ThreadOption.UserInterface)]
        public void comboIDORGDIO_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDORGDIO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNOMJESTO", Thread=ThreadOption.UserInterface)]
        public void comboIDRADNOMJESTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDRADNOMJESTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/SPOL", Thread=ThreadOption.UserInterface)]
        public void comboIDSPOL_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDSPOL.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRUKA", Thread=ThreadOption.UserInterface)]
        public void comboIDSTRUKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDSTRUKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/TITULA", Thread=ThreadOption.UserInterface)]
        public void comboIDTITULA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDTITULA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/UGOVORORADU", Thread=ThreadOption.UserInterface)]
        public void comboIDUGOVORORADU_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDUGOVORORADU.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRUCNASPREMA", Thread=ThreadOption.UserInterface)]
        public void comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA_Add(object sender, ComponentEventArgs e)
        {
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/SKUPPOREZAIDOPRINOSA", Thread=ThreadOption.UserInterface)]
        public void comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA_Add(object sender, ComponentEventArgs e)
        {
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRUCNASPREMA", Thread=ThreadOption.UserInterface)]
        public void comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA_Add(object sender, ComponentEventArgs e)
        {
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Fill();
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, DataView enumList, string Id, string Name, bool overrideList)
        {
            ValueList myValueList = null;
            if (overrideList && dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists[valueListName];
                myValueList.ValueListItems.Clear();
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (myValueList != null)
            {
                LoadValueList(myValueList, enumList, Id, Name);
            }
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsRADNIKDataSet1.RADNIK.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ((DataRow) enumerator.Current).Delete();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (this.RADNIKController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if (column.CellActivation == Activation.AllowEdit)
            {
                switch (Conversions.ToString(column.Tag))
                {
                    case "ELEMENTBRUTOELEMENTIDELEMENTAddNew":
                        this.PictureBoxClickedInLinesBRUTOELEMENTIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "ELEMENTNETOELEMENTIDELEMENTAddNew":
                        this.PictureBoxClickedInLinesNETOELEMENTIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "OBUSTAVAZADOBUSTAVAIDOBUSTAVA":
                        this.CallPromptInLinesOBUSTAVAZADOBUSTAVAIDOBUSTAVA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KREDITORZADKREDITIIDKREDITOR":
                        this.CallPromptInLinesKREDITORZADKREDITIIDKREDITOR(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "OSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK":
                        this.CallPromptInLinesOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "OLAKSICEZADOLAKSICEIDOLAKSICE":
                        this.CallPromptInLinesOLAKSICEZADOLAKSICEIDOLAKSICE(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "GRUPEKOEFIDGRUPEKOEFAddNew":
                        this.PictureBoxClickedInLinesIDGRUPEKOEF(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "BANKEBANKAZASTICENOIDBANKE":
                        this.CallPromptInLinesBANKEBANKAZASTICENOIDBANKE(RuntimeHelpers.GetObjectValue(sender), e);
                        break;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EndEditCurrentRow()
        {
            if (this.grdLevelRADNIKBruto.ActiveRow != null)
            {
                this.grdLevelRADNIKBruto.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelRADNIKNeto.ActiveRow != null)
            {
                this.grdLevelRADNIKNeto.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelRADNIKObustava.ActiveRow != null)
            {
                this.grdLevelRADNIKObustava.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelRADNIKKrediti.ActiveRow != null)
            {
                this.grdLevelRADNIKKrediti.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelRADNIKOdbitak.ActiveRow != null)
            {
                this.grdLevelRADNIKOdbitak.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelRADNIKOlaksica.ActiveRow != null)
            {
                this.grdLevelRADNIKOlaksica.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelRADNIKLevel7.ActiveRow != null)
            {
                this.grdLevelRADNIKLevel7.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelRADNIKIzuzeceOdOvrhe.ActiveRow != null)
            {
                this.grdLevelRADNIKIzuzeceOdOvrhe.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grd_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
        }

        private void grd_CellListSelect(object sender, CellEventArgs e)
        {
            if (e.Cell.ValueListResolved != null)
            {
                DataView tag = (DataView) ((ValueList) e.Cell.ValueListResolved).Tag;
                int selectedItemIndex = e.Cell.ValueListResolved.SelectedItemIndex;
                DataRow result = null;
                if ((tag.Count > selectedItemIndex) && (selectedItemIndex >= 0))
                {
                    result = tag[selectedItemIndex].Row;
                }
                if (e.Cell.Column.Key == "BRUTOELEMENTIDELEMENT")
                {
                    this.UpdateValuesBRUTOELEMENTIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "NETOELEMENTIDELEMENT")
                {
                    this.UpdateValuesNETOELEMENTIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "IDGRUPEKOEF")
                {
                    this.UpdateValuesIDGRUPEKOEF(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelRADNIKBruto_AfterRowActivate(object sender, EventArgs e)
        {
            string rADNIKRADNIKBrutoLevelDescription = StringResources.RADNIKRADNIKBrutoLevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKBruto.ActiveRow;
            this.linkLabelRADNIKBrutoAdd.Text = Deklarit.Resources.Resources.Add + " " + rADNIKRADNIKBrutoLevelDescription;
            this.linkLabelRADNIKBrutoUpdate.Text = Deklarit.Resources.Resources.Update + " " + rADNIKRADNIKBrutoLevelDescription;
            this.linkLabelRADNIKBrutoDelete.Text = Deklarit.Resources.Resources.Delete + " " + rADNIKRADNIKBrutoLevelDescription;
        }

        private void grdLevelRADNIKBruto_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKBruto_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKBrutoUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKBruto_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        private void grdLevelRADNIKIzuzeceOdOvrhe_AfterRowActivate(object sender, EventArgs e)
        {
            string rADNIKRADNIKIzuzeceOdOvrheLevelDescription = StringResources.RADNIKRADNIKIzuzeceOdOvrheLevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKIzuzeceOdOvrhe.ActiveRow;
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Text = Deklarit.Resources.Resources.Add + " " + rADNIKRADNIKIzuzeceOdOvrheLevelDescription;
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Text = Deklarit.Resources.Resources.Update + " " + rADNIKRADNIKIzuzeceOdOvrheLevelDescription;
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Text = Deklarit.Resources.Resources.Delete + " " + rADNIKRADNIKIzuzeceOdOvrheLevelDescription;
        }

        private void grdLevelRADNIKIzuzeceOdOvrhe_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKIzuzeceOdOvrhe_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKIzuzeceOdOvrheUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKIzuzeceOdOvrhe_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        private void grdLevelRADNIKKrediti_AfterRowActivate(object sender, EventArgs e)
        {
            string rADNIKRADNIKKreditiLevelDescription = StringResources.RADNIKRADNIKKreditiLevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKKrediti.ActiveRow;
            this.linkLabelRADNIKKreditiAdd.Text = Deklarit.Resources.Resources.Add + " " + rADNIKRADNIKKreditiLevelDescription;
            this.linkLabelRADNIKKreditiUpdate.Text = Deklarit.Resources.Resources.Update + " " + rADNIKRADNIKKreditiLevelDescription;
            this.linkLabelRADNIKKreditiDelete.Text = Deklarit.Resources.Resources.Delete + " " + rADNIKRADNIKKreditiLevelDescription;
        }

        private void grdLevelRADNIKKrediti_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKKrediti_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKKreditiUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKKrediti_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        private void grdLevelRADNIKLevel7_AfterRowActivate(object sender, EventArgs e)
        {
            string str = StringResources.RADNIKRADNIKLevel7LevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKLevel7.ActiveRow;
            this.linkLabelRADNIKLevel7Add.Text = Deklarit.Resources.Resources.Add + " " + str;
            this.linkLabelRADNIKLevel7Update.Text = Deklarit.Resources.Resources.Update + " " + str;
            this.linkLabelRADNIKLevel7Delete.Text = Deklarit.Resources.Resources.Delete + " " + str;
        }

        private void grdLevelRADNIKLevel7_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKLevel7_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKLevel7Update_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKLevel7_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        private void grdLevelRADNIKNeto_AfterRowActivate(object sender, EventArgs e)
        {
            string rADNIKRADNIKNetoLevelDescription = StringResources.RADNIKRADNIKNetoLevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKNeto.ActiveRow;
            this.linkLabelRADNIKNetoAdd.Text = Deklarit.Resources.Resources.Add + " " + rADNIKRADNIKNetoLevelDescription;
            this.linkLabelRADNIKNetoUpdate.Text = Deklarit.Resources.Resources.Update + " " + rADNIKRADNIKNetoLevelDescription;
            this.linkLabelRADNIKNetoDelete.Text = Deklarit.Resources.Resources.Delete + " " + rADNIKRADNIKNetoLevelDescription;
        }

        private void grdLevelRADNIKNeto_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKNeto_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKNetoUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKNeto_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        private void grdLevelRADNIKObustava_AfterRowActivate(object sender, EventArgs e)
        {
            string rADNIKRADNIKObustavaLevelDescription = StringResources.RADNIKRADNIKObustavaLevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKObustava.ActiveRow;
            this.linkLabelRADNIKObustavaAdd.Text = Deklarit.Resources.Resources.Add + " " + rADNIKRADNIKObustavaLevelDescription;
            this.linkLabelRADNIKObustavaUpdate.Text = Deklarit.Resources.Resources.Update + " " + rADNIKRADNIKObustavaLevelDescription;
            this.linkLabelRADNIKObustavaDelete.Text = Deklarit.Resources.Resources.Delete + " " + rADNIKRADNIKObustavaLevelDescription;
        }

        private void grdLevelRADNIKObustava_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKObustava_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKObustavaUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKObustava_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        private void grdLevelRADNIKOdbitak_AfterRowActivate(object sender, EventArgs e)
        {
            string rADNIKRADNIKOdbitakLevelDescription = StringResources.RADNIKRADNIKOdbitakLevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKOdbitak.ActiveRow;
            this.linkLabelRADNIKOdbitakAdd.Text = Deklarit.Resources.Resources.Add + " " + rADNIKRADNIKOdbitakLevelDescription;
            this.linkLabelRADNIKOdbitakUpdate.Text = Deklarit.Resources.Resources.Update + " " + rADNIKRADNIKOdbitakLevelDescription;
            this.linkLabelRADNIKOdbitakDelete.Text = Deklarit.Resources.Resources.Delete + " " + rADNIKRADNIKOdbitakLevelDescription;
        }

        private void grdLevelRADNIKOdbitak_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKOdbitak_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKOdbitakUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKOdbitak_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        private void grdLevelRADNIKOlaksica_AfterRowActivate(object sender, EventArgs e)
        {
            string rADNIKRADNIKOlaksicaLevelDescription = StringResources.RADNIKRADNIKOlaksicaLevelDescription;
            UltraGridRow activeRow = this.grdLevelRADNIKOlaksica.ActiveRow;
            this.linkLabelRADNIKOlaksicaAdd.Text = Deklarit.Resources.Resources.Add + " " + rADNIKRADNIKOlaksicaLevelDescription;
            this.linkLabelRADNIKOlaksicaUpdate.Text = Deklarit.Resources.Resources.Update + " " + rADNIKRADNIKOlaksicaLevelDescription;
            this.linkLabelRADNIKOlaksicaDelete.Text = Deklarit.Resources.Resources.Delete + " " + rADNIKRADNIKOlaksicaLevelDescription;
        }

        private void grdLevelRADNIKOlaksica_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRADNIK.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRADNIK.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRADNIKOlaksica_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RADNIKOlaksicaUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRADNIKOlaksica_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceRADNIK, "AKTIVAN", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkAKTIVAN.DataBindings["CheckState"] != null)
            {
                this.checkAKTIVAN.DataBindings.Remove(this.checkAKTIVAN.DataBindings["CheckState"]);
            }
            this.checkAKTIVAN.DataBindings.Add(binding);
            Binding binding3 = new Binding("Text", this.bindingSourceRADNIK, "DATUMRODJENJA", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMRODJENJA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMRODJENJA.DataBindings.Remove(this.datePickerDATUMRODJENJA.DataBindings["Text"]);
            }
            this.datePickerDATUMRODJENJA.DataBindings.Add(binding3);
            Binding binding5 = new Binding("Text", this.bindingSourceRADNIK, "OPCINASTANOVANJAPRIREZ", true);
            binding5.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelOPCINASTANOVANJAPRIREZ.DataBindings["Text"] != null)
            {
                this.labelOPCINASTANOVANJAPRIREZ.DataBindings.Remove(this.labelOPCINASTANOVANJAPRIREZ.DataBindings["Text"]);
            }
            this.labelOPCINASTANOVANJAPRIREZ.DataBindings.Add(binding5);
            Binding binding9 = new Binding("CheckState", this.bindingSourceRADNIK, "ZBIRNINETO", true);
            binding9.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding9.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkZBIRNINETO.DataBindings["CheckState"] != null)
            {
                this.checkZBIRNINETO.DataBindings.Remove(this.checkZBIRNINETO.DataBindings["CheckState"]);
            }
            this.checkZBIRNINETO.DataBindings.Add(binding9);
            Binding binding8 = new Binding("CheckState", this.bindingSourceRADNIK, "UZIMAUOBZIROSNOVICEDOPRINOSA", true);
            binding8.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding8.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.DataBindings["CheckState"] != null)
            {
                this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.DataBindings.Remove(this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.DataBindings["CheckState"]);
            }
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.DataBindings.Add(binding8);
            Binding binding4 = new Binding("Text", this.bindingSourceRADNIK, "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding4.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.DataBindings["Text"] != null)
            {
                this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.DataBindings.Remove(this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.DataBindings["Text"]);
            }
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.DataBindings.Add(binding4);
            Binding binding2 = new Binding("Text", this.bindingSourceRADNIK, "DATUMPRESTANKARADNOGODNOSA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerDATUMPRESTANKARADNOGODNOSA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMPRESTANKARADNOGODNOSA.DataBindings.Remove(this.datePickerDATUMPRESTANKARADNOGODNOSA.DataBindings["Text"]);
            }
            this.datePickerDATUMPRESTANKARADNOGODNOSA.DataBindings.Add(binding2);
            Binding binding7 = new Binding("Text", this.bindingSourceRADNIK, "UGOVOROD", true);
            binding7.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding7.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerUGOVOROD.DataBindings["Text"] != null)
            {
                this.datePickerUGOVOROD.DataBindings.Remove(this.datePickerUGOVOROD.DataBindings["Text"]);
            }
            this.datePickerUGOVOROD.DataBindings.Add(binding7);
            Binding binding6 = new Binding("Text", this.bindingSourceRADNIK, "POCETAKRADA", true);
            binding6.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding6.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerPOCETAKRADA.DataBindings["Text"] != null)
            {
                this.datePickerPOCETAKRADA.DataBindings.Remove(this.datePickerPOCETAKRADA.DataBindings["Text"]);
            }
            this.datePickerPOCETAKRADA.DataBindings.Add(binding6);
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKBruto))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKBruto);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKNeto))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKNeto);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKObustava))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKObustava);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKKrediti))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKKrediti);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKOdbitak))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKOdbitak);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKOlaksica))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKOlaksica);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKLevel7))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKLevel7);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelRADNIKIzuzeceOdOvrhe))
            {
                this.m_DataGrids.Add(this.grdLevelRADNIKIzuzeceOdOvrhe);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRADNIKDataSet1.RADNIK[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKRow) ((DataRowView) this.bindingSourceRADNIK.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIK).BeginInit();
            this.bindingSourceRADNIKOdbitak = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKOdbitak).BeginInit();
            this.bindingSourceRADNIKOlaksica = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKOlaksica).BeginInit();
            this.bindingSourceRADNIKKrediti = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKKrediti).BeginInit();
            this.bindingSourceRADNIKBruto = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKBruto).BeginInit();
            this.bindingSourceRADNIKNeto = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKNeto).BeginInit();
            this.bindingSourceRADNIKObustava = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKObustava).BeginInit();
            this.bindingSourceRADNIKLevel7 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKLevel7).BeginInit();
            this.bindingSourceRADNIKIzuzeceOdOvrhe = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKIzuzeceOdOvrhe).BeginInit();
            this.layoutManagerformRADNIK = new TableLayoutPanel();
            this.layoutManagerformRADNIK.SuspendLayout();
            this.layoutManagerformRADNIK.AutoSize = true;
            this.layoutManagerformRADNIK.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIK.Size = size;
            this.layoutManagerformRADNIK.ColumnCount = 1;
            this.layoutManagerformRADNIK.RowCount = 2;
            this.layoutManagerformRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIK.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIK.RowStyles.Add(new RowStyle());
            this.Tab2 = new UltraTabControl();
            UltraTab tab8 = new UltraTab();
            this.TabPage3 = new UltraTabPageControl();
            this.layoutManagerTabPage3 = new TableLayoutPanel();
            this.layoutManagerTabPage3.AutoSize = true;
            this.layoutManagerTabPage3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage3.ColumnCount = 2;
            this.layoutManagerTabPage3.RowCount = 10;
            this.layoutManagerTabPage3.Dock = DockStyle.Fill;
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            Padding padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage3.Margin = padding;
            this.Group6 = new UltraGroupBox();
            this.layoutManagerGroup6 = new TableLayoutPanel();
            this.layoutManagerGroup6.AutoSize = true;
            this.layoutManagerGroup6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerGroup6.ColumnCount = 4;
            this.layoutManagerGroup6.RowCount = 3;
            this.layoutManagerGroup6.Dock = DockStyle.Fill;
            this.layoutManagerGroup6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup6.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup6.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup6.RowStyles.Add(new RowStyle());
            this.label1IDRADNIK = new UltraLabel();
            this.textIDRADNIK = new UltraNumericEditor();
            this.label1IDIPIDENT = new UltraLabel();
            this.comboIDIPIDENT = new IPIDENTComboBox();
            this.label1IDSPOL = new UltraLabel();
            this.comboIDSPOL = new SPOLComboBox();
            this.label1AKTIVAN = new UltraLabel();
            this.checkAKTIVAN = new UltraCheckEditor();
            this.label1PREZIME = new UltraLabel();
            this.textPREZIME = new UltraTextEditor();
            this.label1IME = new UltraLabel();
            this.textIME = new UltraTextEditor();
            this.label1OIB = new UltraLabel();
            this.textOIB = new UltraTextEditor();
            this.label1JMBG = new UltraLabel();
            this.textJMBG = new UltraTextEditor();
            this.label1DATUMRODJENJA = new UltraLabel();
            this.datePickerDATUMRODJENJA = new UltraDateTimeEditor();
            this.label1ulica = new UltraLabel();
            this.textulica = new UltraTextEditor();
            this.label1kucnibroj = new UltraLabel();
            this.textkucnibroj = new UltraTextEditor();
            this.label1mjesto = new UltraLabel();
            this.textmjesto = new UltraTextEditor();
            UltraTab tab9 = new UltraTab();
            this.TabPage4 = new UltraTabPageControl();
            this.layoutManagerTabPage4 = new TableLayoutPanel();
            this.layoutManagerTabPage4.AutoSize = true;
            this.layoutManagerTabPage4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage4.ColumnCount = 1;
            this.layoutManagerTabPage4.RowCount = 2;
            this.layoutManagerTabPage4.Dock = DockStyle.Fill;
            this.layoutManagerTabPage4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage4.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage4.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage4.Margin = padding;
            this.Group3 = new UltraGroupBox();
            this.layoutManagerGroup3 = new TableLayoutPanel();
            this.layoutManagerGroup3.AutoSize = true;
            this.layoutManagerGroup3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerGroup3.ColumnCount = 4;
            this.layoutManagerGroup3.RowCount = 5;
            this.layoutManagerGroup3.Dock = DockStyle.Fill;
            this.layoutManagerGroup3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup3.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup3.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup3.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup3.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup3.RowStyles.Add(new RowStyle());
            this.label1OPCINASTANOVANJAIDOPCINE = new UltraLabel();
            this.textOPCINASTANOVANJAIDOPCINE = new UltraTextEditor();
            this.label1OPCINASTANOVANJANAZIVOPCINE = new UltraLabel();
            this.labelOPCINASTANOVANJANAZIVOPCINE = new UltraLabel();
            this.label1OPCINARADAIDOPCINE = new UltraLabel();
            this.textOPCINARADAIDOPCINE = new UltraTextEditor();
            this.label1OPCINARADANAZIVOPCINE = new UltraLabel();
            this.labelOPCINARADANAZIVOPCINE = new UltraLabel();
            this.label1OPCINASTANOVANJAPRIREZ = new UltraLabel();
            this.labelOPCINASTANOVANJAPRIREZ = new UltraLabel();
            this.Group4 = new UltraGroupBox();
            this.layoutManagerGroup4 = new TableLayoutPanel();
            this.layoutManagerGroup4.AutoSize = true;
            this.layoutManagerGroup4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerGroup4.ColumnCount = 2;
            this.layoutManagerGroup4.RowCount = 2;
            this.layoutManagerGroup4.Dock = DockStyle.Fill;
            this.layoutManagerGroup4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup4.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup4.RowStyles.Add(new RowStyle());
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = new UltraLabel();
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = new SKUPPOREZAIDOPRINOSAComboBox();
            this.Group2 = new UltraGroupBox();
            this.layoutManagerGroup2 = new TableLayoutPanel();
            this.layoutManagerGroup2.AutoSize = true;
            this.layoutManagerGroup2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerGroup2.ColumnCount = 4;
            this.layoutManagerGroup2.RowCount = 5;
            this.layoutManagerGroup2.Dock = DockStyle.Fill;
            this.layoutManagerGroup2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup2.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup2.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup2.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup2.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup2.RowStyles.Add(new RowStyle());
            this.label1IDBANKE = new UltraLabel();
            this.textIDBANKE = new UltraNumericEditor();
            this.label1TEKUCI = new UltraLabel();
            this.textTEKUCI = new UltraTextEditor();
            this.label1MO = new UltraLabel();
            this.textMO = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJANETO = new UltraLabel();
            this.textSIFRAOPISAPLACANJANETO = new UltraTextEditor();
            this.label1NAZIVBANKE1 = new UltraLabel();
            this.labelNAZIVBANKE1 = new UltraLabel();
            this.label1ZBIRNINETO = new UltraLabel();
            this.checkZBIRNINETO = new UltraCheckEditor();
            this.label1PBO = new UltraLabel();
            this.textPBO = new UltraTextEditor();
            this.label1OPISPLACANJANETO = new UltraLabel();
            this.textOPISPLACANJANETO = new UltraTextEditor();
            UltraTab tab10 = new UltraTab();
            this.TabPage5 = new UltraTabPageControl();
            this.layoutManagerTabPage5 = new TableLayoutPanel();
            this.layoutManagerTabPage5.AutoSize = true;
            this.layoutManagerTabPage5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage5.ColumnCount = 2;
            this.layoutManagerTabPage5.RowCount = 8;
            this.layoutManagerTabPage5.Dock = DockStyle.Fill;
            this.layoutManagerTabPage5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage5.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage5.Margin = padding;
            this.label1KOEFICIJENT = new UltraLabel();
            this.textKOEFICIJENT = new UltraNumericEditor();
            this.label1POSTOTAKOSLOBODJENJAODPOREZA = new UltraLabel();
            this.textPOSTOTAKOSLOBODJENJAODPOREZA = new UltraNumericEditor();
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA = new UltraLabel();
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA = new UltraCheckEditor();
            this.label1TJEDNIFONDSATI = new UltraLabel();
            this.textTJEDNIFONDSATI = new UltraNumericEditor();
            this.label1TJEDNIFONDSATISTAZ = new UltraLabel();
            this.textTJEDNIFONDSATISTAZ = new UltraNumericEditor();
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = new UltraLabel();
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = new UltraDateTimeEditor();
            this.label1IDBENEFICIRANI = new UltraLabel();
            this.comboIDBENEFICIRANI = new BENEFICIRANIComboBox();
            this.Group5 = new UltraGroupBox();
            this.layoutManagerGroup5 = new TableLayoutPanel();
            this.layoutManagerGroup5.AutoSize = true;
            this.layoutManagerGroup5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerGroup5.ColumnCount = 6;
            this.layoutManagerGroup5.RowCount = 4;
            this.layoutManagerGroup5.Dock = DockStyle.Fill;
            this.layoutManagerGroup5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerGroup5.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup5.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup5.RowStyles.Add(new RowStyle());
            this.layoutManagerGroup5.RowStyles.Add(new RowStyle());
            this.label1GODINESTAZA = new UltraLabel();
            this.textGODINESTAZA = new UltraNumericEditor();
            this.label1GODINESTAZAPRO = new UltraLabel();
            this.textGODINESTAZAPRO = new UltraNumericEditor();
            this.label1UKUPNOGODINESTAZA = new UltraLabel();
            this.labelUKUPNOGODINESTAZA = new UltraLabel();
            this.label1MJESECISTAZA = new UltraLabel();
            this.textMJESECISTAZA = new UltraNumericEditor();
            this.label1MJESECISTAZAPRO = new UltraLabel();
            this.textMJESECISTAZAPRO = new UltraNumericEditor();
            this.label1UKUPNOMJESECISTAZA = new UltraLabel();
            this.labelUKUPNOMJESECISTAZA = new UltraLabel();
            this.label1DANISTAZA = new UltraLabel();
            this.textDANISTAZA = new UltraNumericEditor();
            this.label1DANISTAZAPRO = new UltraLabel();
            this.textDANISTAZAPRO = new UltraNumericEditor();
            this.label1UKUPNODANASTAZA = new UltraLabel();
            this.labelUKUPNODANASTAZA = new UltraLabel();
            UltraTab tab11 = new UltraTab();
            this.TabPage6 = new UltraTabPageControl();
            this.layoutManagerTabPage6 = new TableLayoutPanel();
            this.layoutManagerTabPage6.AutoSize = true;
            this.layoutManagerTabPage6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage6.ColumnCount = 2;
            this.layoutManagerTabPage6.RowCount = 12;
            this.layoutManagerTabPage6.Dock = DockStyle.Fill;
            this.layoutManagerTabPage6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage6.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage6.Margin = padding;
            this.label1BROJMIROVINSKOG = new UltraLabel();
            this.textBROJMIROVINSKOG = new UltraTextEditor();
            this.label1BROJZDRAVSTVENOG = new UltraLabel();
            this.textBROJZDRAVSTVENOG = new UltraTextEditor();
            this.label1MBO = new UltraLabel();
            this.textMBO = new UltraTextEditor();
            this.label1IDTITULA = new UltraLabel();
            this.comboIDTITULA = new TITULAComboBox();
            this.label1IDRADNOMJESTO = new UltraLabel();
            this.comboIDRADNOMJESTO = new RADNOMJESTOComboBox();
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = new UltraLabel();
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = new STRUCNASPREMAComboBox();
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA = new UltraLabel();
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = new STRUCNASPREMAComboBox();
            this.label1IDSTRUKA = new UltraLabel();
            this.comboIDSTRUKA = new STRUKAComboBox();
            this.label1IDBRACNOSTANJE = new UltraLabel();
            this.comboIDBRACNOSTANJE = new BRACNOSTANJEComboBox();
            this.label1IDORGDIO = new UltraLabel();
            this.comboIDORGDIO = new ORGDIOComboBox();
            this.label1DATUMPRESTANKARADNOGODNOSA = new UltraLabel();
            this.datePickerDATUMPRESTANKARADNOGODNOSA = new UltraDateTimeEditor();
            UltraTab tab13 = new UltraTab();
            this.TabPage8 = new UltraTabPageControl();
            this.layoutManagerTabPage8 = new TableLayoutPanel();
            this.layoutManagerTabPage8.AutoSize = true;
            this.layoutManagerTabPage8.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage8.ColumnCount = 2;
            this.layoutManagerTabPage8.RowCount = 12;
            this.layoutManagerTabPage8.Dock = DockStyle.Fill;
            this.layoutManagerTabPage8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage8.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage8.Margin = padding;
            this.label1IDDRZAVLJANSTVO = new UltraLabel();
            this.comboIDDRZAVLJANSTVO = new DRZAVLJANSTVOComboBox();
            this.label1RADNADOZVOLA = new UltraLabel();
            this.textRADNADOZVOLA = new UltraTextEditor();
            this.label1ZAVRSENASKOLA = new UltraLabel();
            this.textZAVRSENASKOLA = new UltraTextEditor();
            this.label1UGOVOROD = new UltraLabel();
            this.datePickerUGOVOROD = new UltraDateTimeEditor();
            this.label1POCETAKRADA = new UltraLabel();
            this.datePickerPOCETAKRADA = new UltraDateTimeEditor();
            this.label1NAZIVPOSLA = new UltraLabel();
            this.textNAZIVPOSLA = new UltraTextEditor();
            this.label1IDUGOVORORADU = new UltraLabel();
            this.comboIDUGOVORORADU = new UGOVORORADUComboBox();
            this.label1VRIJEMEPROBNOGRADA = new UltraLabel();
            this.textVRIJEMEPROBNOGRADA = new UltraTextEditor();
            this.label1VRIJEMEPRIPRAVNICKOG = new UltraLabel();
            this.textVRIJEMEPRIPRAVNICKOG = new UltraTextEditor();
            this.label1VRIJEMESTRUCNI = new UltraLabel();
            this.textVRIJEMESTRUCNI = new UltraTextEditor();
            this.label1IDRADNOVRIJEME = new UltraLabel();
            this.textIDRADNOVRIJEME = new UltraNumericEditor();
            UltraTab tab14 = new UltraTab();
            this.TabPage9 = new UltraTabPageControl();
            this.layoutManagerTabPage9 = new TableLayoutPanel();
            this.layoutManagerTabPage9.AutoSize = true;
            this.layoutManagerTabPage9.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage9.ColumnCount = 2;
            this.layoutManagerTabPage9.RowCount = 7;
            this.layoutManagerTabPage9.Dock = DockStyle.Fill;
            this.layoutManagerTabPage9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage9.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage9.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage9.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage9.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage9.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage9.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage9.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage9.Margin = padding;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA = new UltraLabel();
            this.textVRIJEMEMIROVANJARADNOGODNOSA = new UltraTextEditor();
            this.label1RAZLOGPRESTANKA = new UltraLabel();
            this.textRAZLOGPRESTANKA = new UltraTextEditor();
            this.label1ZABRANANATJECANJA = new UltraLabel();
            this.textZABRANANATJECANJA = new UltraTextEditor();
            this.label1PRODUZENOMIROVINSKO = new UltraLabel();
            this.textPRODUZENOMIROVINSKO = new UltraTextEditor();
            this.label1RADUINOZEMSTVU = new UltraLabel();
            this.textRADUINOZEMSTVU = new UltraTextEditor();
            this.label1RADNASPOSOBNOST = new UltraLabel();
            this.textRADNASPOSOBNOST = new UltraTextEditor();
            this.label1RADNIKNAPOMENA = new UltraLabel();
            this.textRADNIKNAPOMENA = new UltraTextEditor();
            this.Tab1 = new UltraTabControl();
            UltraTab tab2 = new UltraTab();
            this.Level4Page = new UltraTabPageControl();
            this.layoutManagerLevel4Page = new TableLayoutPanel();
            this.layoutManagerLevel4Page.AutoSize = true;
            this.layoutManagerLevel4Page.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerLevel4Page.ColumnCount = 1;
            this.layoutManagerLevel4Page.RowCount = 2;
            this.layoutManagerLevel4Page.Dock = DockStyle.Fill;
            this.layoutManagerLevel4Page.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerLevel4Page.RowStyles.Add(new RowStyle());
            this.layoutManagerLevel4Page.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerLevel4Page.Margin = padding;
            this.grdLevelRADNIKBruto = new UltraGrid();
            this.panelactionsRADNIKBruto = new Panel();
            this.layoutManagerpanelactionsRADNIKBruto = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKBruto.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKBruto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKBruto.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKBruto.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKBruto.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKBruto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKBruto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKBruto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKBruto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKBruto.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKBrutoAdd = new UltraLabel();
            this.linkLabelRADNIKBrutoUpdate = new UltraLabel();
            this.linkLabelRADNIKBrutoDelete = new UltraLabel();
            this.linkLabelRADNIKBruto = new UltraLabel();
            UltraTab tab5 = new UltraTab();
            this.TabPage1 = new UltraTabPageControl();
            this.layoutManagerTabPage1 = new TableLayoutPanel();
            this.layoutManagerTabPage1.AutoSize = true;
            this.layoutManagerTabPage1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage1.ColumnCount = 1;
            this.layoutManagerTabPage1.RowCount = 2;
            this.layoutManagerTabPage1.Dock = DockStyle.Fill;
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage1.Margin = padding;
            this.grdLevelRADNIKNeto = new UltraGrid();
            this.panelactionsRADNIKNeto = new Panel();
            this.layoutManagerpanelactionsRADNIKNeto = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKNeto.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKNeto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKNeto.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKNeto.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKNeto.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKNeto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKNeto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKNeto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKNeto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKNeto.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKNetoAdd = new UltraLabel();
            this.linkLabelRADNIKNetoUpdate = new UltraLabel();
            this.linkLabelRADNIKNetoDelete = new UltraLabel();
            this.linkLabelRADNIKNeto = new UltraLabel();
            UltraTab tab7 = new UltraTab();
            this.TabPage2 = new UltraTabPageControl();
            this.layoutManagerTabPage2 = new TableLayoutPanel();
            this.layoutManagerTabPage2.AutoSize = true;
            this.layoutManagerTabPage2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage2.ColumnCount = 1;
            this.layoutManagerTabPage2.RowCount = 2;
            this.layoutManagerTabPage2.Dock = DockStyle.Fill;
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage2.Margin = padding;
            this.grdLevelRADNIKObustava = new UltraGrid();
            this.panelactionsRADNIKObustava = new Panel();
            this.layoutManagerpanelactionsRADNIKObustava = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKObustava.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKObustava.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKObustava.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKObustava.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKObustava.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKObustava.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKObustava.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKObustava.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKObustava.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKObustava.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKObustavaAdd = new UltraLabel();
            this.linkLabelRADNIKObustavaUpdate = new UltraLabel();
            this.linkLabelRADNIKObustavaDelete = new UltraLabel();
            this.linkLabelRADNIKObustava = new UltraLabel();
            UltraTab tab = new UltraTab();
            this.KreditiPage = new UltraTabPageControl();
            this.layoutManagerKreditiPage = new TableLayoutPanel();
            this.layoutManagerKreditiPage.AutoSize = true;
            this.layoutManagerKreditiPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerKreditiPage.ColumnCount = 1;
            this.layoutManagerKreditiPage.RowCount = 2;
            this.layoutManagerKreditiPage.Dock = DockStyle.Fill;
            this.layoutManagerKreditiPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerKreditiPage.RowStyles.Add(new RowStyle());
            this.layoutManagerKreditiPage.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerKreditiPage.Margin = padding;
            this.grdLevelRADNIKKrediti = new UltraGrid();
            this.panelactionsRADNIKKrediti = new Panel();
            this.layoutManagerpanelactionsRADNIKKrediti = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKKrediti.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKKrediti.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKKrediti.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKKrediti.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKKrediti.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKKreditiAdd = new UltraLabel();
            this.linkLabelRADNIKKreditiUpdate = new UltraLabel();
            this.linkLabelRADNIKKreditiDelete = new UltraLabel();
            this.linkLabelRADNIKKrediti = new UltraLabel();
            UltraTab tab3 = new UltraTab();
            this.OsobniOdbitakPage = new UltraTabPageControl();
            this.layoutManagerOsobniOdbitakPage = new TableLayoutPanel();
            this.layoutManagerOsobniOdbitakPage.AutoSize = true;
            this.layoutManagerOsobniOdbitakPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerOsobniOdbitakPage.ColumnCount = 1;
            this.layoutManagerOsobniOdbitakPage.RowCount = 2;
            this.layoutManagerOsobniOdbitakPage.Dock = DockStyle.Fill;
            this.layoutManagerOsobniOdbitakPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerOsobniOdbitakPage.RowStyles.Add(new RowStyle());
            this.layoutManagerOsobniOdbitakPage.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerOsobniOdbitakPage.Margin = padding;
            this.grdLevelRADNIKOdbitak = new UltraGrid();
            this.panelactionsRADNIKOdbitak = new Panel();
            this.layoutManagerpanelactionsRADNIKOdbitak = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKOdbitak.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOdbitak.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKOdbitak.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKOdbitak.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKOdbitak.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKOdbitak.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOdbitak.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOdbitak.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOdbitak.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOdbitak.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKOdbitakAdd = new UltraLabel();
            this.linkLabelRADNIKOdbitakUpdate = new UltraLabel();
            this.linkLabelRADNIKOdbitakDelete = new UltraLabel();
            this.linkLabelRADNIKOdbitak = new UltraLabel();
            UltraTab tab4 = new UltraTab();
            this.RADNIKLevel4Page = new UltraTabPageControl();
            this.layoutManagerRADNIKLevel4Page = new TableLayoutPanel();
            this.layoutManagerRADNIKLevel4Page.AutoSize = true;
            this.layoutManagerRADNIKLevel4Page.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerRADNIKLevel4Page.ColumnCount = 1;
            this.layoutManagerRADNIKLevel4Page.RowCount = 2;
            this.layoutManagerRADNIKLevel4Page.Dock = DockStyle.Fill;
            this.layoutManagerRADNIKLevel4Page.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerRADNIKLevel4Page.RowStyles.Add(new RowStyle());
            this.layoutManagerRADNIKLevel4Page.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerRADNIKLevel4Page.Margin = padding;
            this.grdLevelRADNIKOlaksica = new UltraGrid();
            this.panelactionsRADNIKOlaksica = new Panel();
            this.layoutManagerpanelactionsRADNIKOlaksica = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKOlaksica.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOlaksica.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKOlaksica.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKOlaksica.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKOlaksica.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKOlaksica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOlaksica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOlaksica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOlaksica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKOlaksicaAdd = new UltraLabel();
            this.linkLabelRADNIKOlaksicaUpdate = new UltraLabel();
            this.linkLabelRADNIKOlaksicaDelete = new UltraLabel();
            this.linkLabelRADNIKOlaksica = new UltraLabel();
            UltraTab tab12 = new UltraTab();
            this.TabPage7 = new UltraTabPageControl();
            this.layoutManagerTabPage7 = new TableLayoutPanel();
            this.layoutManagerTabPage7.AutoSize = true;
            this.layoutManagerTabPage7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage7.ColumnCount = 1;
            this.layoutManagerTabPage7.RowCount = 2;
            this.layoutManagerTabPage7.Dock = DockStyle.Fill;
            this.layoutManagerTabPage7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage7.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage7.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage7.Margin = padding;
            this.grdLevelRADNIKLevel7 = new UltraGrid();
            this.panelactionsRADNIKLevel7 = new Panel();
            this.layoutManagerpanelactionsRADNIKLevel7 = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKLevel7.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKLevel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKLevel7.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKLevel7.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKLevel7.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKLevel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKLevel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKLevel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKLevel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKLevel7.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKLevel7Add = new UltraLabel();
            this.linkLabelRADNIKLevel7Update = new UltraLabel();
            this.linkLabelRADNIKLevel7Delete = new UltraLabel();
            this.linkLabelRADNIKLevel7 = new UltraLabel();
            UltraTab tab6 = new UltraTab();
            this.TabPage10 = new UltraTabPageControl();
            this.layoutManagerTabPage10 = new TableLayoutPanel();
            this.layoutManagerTabPage10.AutoSize = true;
            this.layoutManagerTabPage10.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage10.ColumnCount = 1;
            this.layoutManagerTabPage10.RowCount = 2;
            this.layoutManagerTabPage10.Dock = DockStyle.Fill;
            this.layoutManagerTabPage10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage10.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage10.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage10.Margin = padding;
            this.grdLevelRADNIKIzuzeceOdOvrhe = new UltraGrid();
            this.panelactionsRADNIKIzuzeceOdOvrhe = new Panel();
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe = new TableLayoutPanel();
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.ColumnCount = 4;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.RowCount = 1;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.RowStyles.Add(new RowStyle());
            this.linkLabelRADNIKIzuzeceOdOvrheAdd = new UltraLabel();
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate = new UltraLabel();
            this.linkLabelRADNIKIzuzeceOdOvrheDelete = new UltraLabel();
            this.linkLabelRADNIKIzuzeceOdOvrhe = new UltraLabel();
            this.Tab2.SuspendLayout();
            ((ISupportInitialize) this.Tab2).BeginInit();
            this.layoutManagerTabPage3.SuspendLayout();
            this.Group6.SuspendLayout();
            ((ISupportInitialize) this.Group6).BeginInit();
            this.layoutManagerGroup6.SuspendLayout();
            ((ISupportInitialize) this.textIDRADNIK).BeginInit();
            ((ISupportInitialize) this.textPREZIME).BeginInit();
            ((ISupportInitialize) this.textIME).BeginInit();
            ((ISupportInitialize) this.textOIB).BeginInit();
            ((ISupportInitialize) this.textJMBG).BeginInit();
            ((ISupportInitialize) this.textulica).BeginInit();
            ((ISupportInitialize) this.textkucnibroj).BeginInit();
            ((ISupportInitialize) this.textmjesto).BeginInit();
            this.layoutManagerTabPage4.SuspendLayout();
            this.Group3.SuspendLayout();
            ((ISupportInitialize) this.Group3).BeginInit();
            this.layoutManagerGroup3.SuspendLayout();
            ((ISupportInitialize) this.textOPCINASTANOVANJAIDOPCINE).BeginInit();
            ((ISupportInitialize) this.textOPCINARADAIDOPCINE).BeginInit();
            this.Group4.SuspendLayout();
            ((ISupportInitialize) this.Group4).BeginInit();
            this.layoutManagerGroup4.SuspendLayout();
            this.Group2.SuspendLayout();
            ((ISupportInitialize) this.Group2).BeginInit();
            this.layoutManagerGroup2.SuspendLayout();
            ((ISupportInitialize) this.textIDBANKE).BeginInit();
            ((ISupportInitialize) this.textTEKUCI).BeginInit();
            ((ISupportInitialize) this.textMO).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJANETO).BeginInit();
            ((ISupportInitialize) this.textPBO).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJANETO).BeginInit();
            this.layoutManagerTabPage5.SuspendLayout();
            ((ISupportInitialize) this.textKOEFICIJENT).BeginInit();
            ((ISupportInitialize) this.textPOSTOTAKOSLOBODJENJAODPOREZA).BeginInit();
            ((ISupportInitialize) this.textTJEDNIFONDSATI).BeginInit();
            ((ISupportInitialize) this.textTJEDNIFONDSATISTAZ).BeginInit();
            this.Group5.SuspendLayout();
            ((ISupportInitialize) this.Group5).BeginInit();
            this.layoutManagerGroup5.SuspendLayout();
            ((ISupportInitialize) this.textGODINESTAZA).BeginInit();
            ((ISupportInitialize) this.textGODINESTAZAPRO).BeginInit();
            ((ISupportInitialize) this.textMJESECISTAZA).BeginInit();
            ((ISupportInitialize) this.textMJESECISTAZAPRO).BeginInit();
            ((ISupportInitialize) this.textDANISTAZA).BeginInit();
            ((ISupportInitialize) this.textDANISTAZAPRO).BeginInit();
            this.layoutManagerTabPage6.SuspendLayout();
            ((ISupportInitialize) this.textBROJMIROVINSKOG).BeginInit();
            ((ISupportInitialize) this.textBROJZDRAVSTVENOG).BeginInit();
            ((ISupportInitialize) this.textMBO).BeginInit();
            this.layoutManagerTabPage8.SuspendLayout();
            ((ISupportInitialize) this.textRADNADOZVOLA).BeginInit();
            ((ISupportInitialize) this.textZAVRSENASKOLA).BeginInit();
            ((ISupportInitialize) this.textNAZIVPOSLA).BeginInit();
            ((ISupportInitialize) this.textVRIJEMEPROBNOGRADA).BeginInit();
            ((ISupportInitialize) this.textVRIJEMEPRIPRAVNICKOG).BeginInit();
            ((ISupportInitialize) this.textVRIJEMESTRUCNI).BeginInit();
            ((ISupportInitialize) this.textIDRADNOVRIJEME).BeginInit();
            this.layoutManagerTabPage9.SuspendLayout();
            ((ISupportInitialize) this.textVRIJEMEMIROVANJARADNOGODNOSA).BeginInit();
            ((ISupportInitialize) this.textRAZLOGPRESTANKA).BeginInit();
            ((ISupportInitialize) this.textZABRANANATJECANJA).BeginInit();
            ((ISupportInitialize) this.textPRODUZENOMIROVINSKO).BeginInit();
            ((ISupportInitialize) this.textRADUINOZEMSTVU).BeginInit();
            ((ISupportInitialize) this.textRADNASPOSOBNOST).BeginInit();
            ((ISupportInitialize) this.textRADNIKNAPOMENA).BeginInit();
            this.Tab1.SuspendLayout();
            ((ISupportInitialize) this.Tab1).BeginInit();
            this.layoutManagerLevel4Page.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKBruto).BeginInit();
            this.panelactionsRADNIKBruto.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKBruto.SuspendLayout();
            this.layoutManagerTabPage1.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKNeto).BeginInit();
            this.panelactionsRADNIKNeto.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKNeto.SuspendLayout();
            this.layoutManagerTabPage2.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKObustava).BeginInit();
            this.panelactionsRADNIKObustava.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKObustava.SuspendLayout();
            this.layoutManagerKreditiPage.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKKrediti).BeginInit();
            this.panelactionsRADNIKKrediti.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKKrediti.SuspendLayout();
            this.layoutManagerOsobniOdbitakPage.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKOdbitak).BeginInit();
            this.panelactionsRADNIKOdbitak.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKOdbitak.SuspendLayout();
            this.layoutManagerRADNIKLevel4Page.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKOlaksica).BeginInit();
            this.panelactionsRADNIKOlaksica.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKOlaksica.SuspendLayout();
            this.layoutManagerTabPage7.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKLevel7).BeginInit();
            this.panelactionsRADNIKLevel7.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKLevel7.SuspendLayout();
            this.layoutManagerTabPage10.SuspendLayout();
            ((ISupportInitialize) this.grdLevelRADNIKIzuzeceOdOvrhe).BeginInit();
            this.panelactionsRADNIKIzuzeceOdOvrhe.SuspendLayout();
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SuspendLayout();
            UltraGridBand band7 = new UltraGridBand("RADNIKOdbitak", -1);
            UltraGridColumn column73 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column75 = new UltraGridColumn("OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK");
            UltraGridColumn column74 = new UltraGridColumn("NAZIVOSOBNIODBITAK");
            UltraGridColumn column72 = new UltraGridColumn("FAKTOROSOBNOGODBITKA");
            UltraGridBand band8 = new UltraGridBand("RADNIKOlaksica", -1);
            UltraGridColumn column76 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column81 = new UltraGridColumn("ZADOLAKSICEIDOLAKSICE");
            UltraGridColumn column80 = new UltraGridColumn("ZADOLAKSICEIDGRUPEOLAKSICA");
            UltraGridColumn column83 = new UltraGridColumn("ZADOLAKSICEMAXIMALNIIZNOSGRUPE");
            UltraGridColumn column84 = new UltraGridColumn("ZADOLAKSICENAZIVGRUPEOLAKSICA");
            UltraGridColumn column85 = new UltraGridColumn("ZADOLAKSICENAZIVOLAKSICE");
            UltraGridColumn column82 = new UltraGridColumn("ZADOLAKSICEIDTIPOLAKSICE");
            UltraGridColumn column86 = new UltraGridColumn("ZADOLAKSICENAZIVTIPOLAKSICE");
            UltraGridColumn column90 = new UltraGridColumn("ZADOLAKSICEVBDIOLAKSICA");
            UltraGridColumn column91 = new UltraGridColumn("ZADOLAKSICEZRNOLAKSICA");
            UltraGridColumn column87 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA1");
            UltraGridColumn column88 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA2");
            UltraGridColumn column89 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA3");
            UltraGridColumn column79 = new UltraGridColumn("ZADMZOLAKSICE");
            UltraGridColumn column95 = new UltraGridColumn("ZADPZOLAKSICE");
            UltraGridColumn column78 = new UltraGridColumn("ZADMOOLAKSICE");
            UltraGridColumn column94 = new UltraGridColumn("ZADPOOLAKSICE");
            UltraGridColumn column96 = new UltraGridColumn("ZADSIFRAOPISAPLACANJAOLAKSICE");
            UltraGridColumn column92 = new UltraGridColumn("ZADOPISPLACANJAOLAKSICE");
            UltraGridColumn column77 = new UltraGridColumn("ZADIZNOSOLAKSICE");
            UltraGridColumn column93 = new UltraGridColumn("ZADPOJEDINACNIPOZIV");
            UltraGridBand band3 = new UltraGridBand("RADNIKKrediti", -1);
            UltraGridColumn column21 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column34 = new UltraGridColumn("ZADKREDITIIDKREDITOR");
            UltraGridColumn column20 = new UltraGridColumn("DATUMUGOVORA");
            UltraGridColumn column22 = new UltraGridColumn("KREDITAKTIVAN");
            UltraGridColumn column35 = new UltraGridColumn("ZADKREDITINAZIVKREDITOR");
            UltraGridColumn column36 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR1");
            UltraGridColumn column37 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR2");
            UltraGridColumn column38 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR3");
            UltraGridColumn column31 = new UltraGridColumn("SIFRAOPISAPLACANJAKREDITOR");
            UltraGridColumn column27 = new UltraGridColumn("OPISPLACANJAKREDITOR");
            UltraGridColumn column25 = new UltraGridColumn("MOKREDITOR");
            UltraGridColumn column29 = new UltraGridColumn("POKREDITOR");
            UltraGridColumn column26 = new UltraGridColumn("MZKREDITOR");
            UltraGridColumn column30 = new UltraGridColumn("PZKREDITOR");
            UltraGridColumn column33 = new UltraGridColumn("ZADIZNOSRATEKREDITA");
            UltraGridColumn column32 = new UltraGridColumn("ZADBROJRATAOBUSTAVE");
            UltraGridColumn column41 = new UltraGridColumn("ZADUKUPNIZNOSKREDITA");
            UltraGridColumn column42 = new UltraGridColumn("ZADVECOTPLACENOBROJRATA");
            UltraGridColumn column43 = new UltraGridColumn("ZADVECOTPLACENOUKUPNIIZNOS");
            UltraGridColumn column23 = new UltraGridColumn("KREDITOTPLACENIIZNOS");
            UltraGridColumn column24 = new UltraGridColumn("KREDITOTPLACENORATA");
            UltraGridColumn column39 = new UltraGridColumn("ZADKREDITIVBDIKREDITOR");
            UltraGridColumn column40 = new UltraGridColumn("ZADKREDITIZRNKREDITOR");
            UltraGridColumn column28 = new UltraGridColumn("PARTIJAKREDITASPECIFIKACIJA");
            UltraGridBand band = new UltraGridBand("RADNIKBruto", -1);
            UltraGridColumn column9 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column = new UltraGridColumn("BRUTOELEMENTIDELEMENT");
            UltraGridColumn column2 = new UltraGridColumn("columnBRUTOELEMENTIDELEMENTAddNew", 0);
            UltraGridColumn column3 = new UltraGridColumn("BRUTOELEMENTNAZIVELEMENT");
            UltraGridColumn column8 = new UltraGridColumn("BRUTOSATNICA");
            UltraGridColumn column7 = new UltraGridColumn("BRUTOSATI");
            UltraGridColumn column6 = new UltraGridColumn("BRUTOPOSTOTAK");
            UltraGridColumn column5 = new UltraGridColumn("BRUTOIZNOS");
            UltraGridColumn column4 = new UltraGridColumn("BRUTOELEMENTPOSTOTAK");
            UltraGridBand band5 = new UltraGridBand("RADNIKNeto", -1);
            UltraGridColumn column49 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column50 = new UltraGridColumn("NETOELEMENTIDELEMENT");
            UltraGridColumn column51 = new UltraGridColumn("columnNETOELEMENTIDELEMENTAddNew", 0);
            UltraGridColumn column52 = new UltraGridColumn("NETOELEMENTNAZIVELEMENT");
            UltraGridColumn column56 = new UltraGridColumn("NETOSATNICA");
            UltraGridColumn column55 = new UltraGridColumn("NETOSATI");
            UltraGridColumn column54 = new UltraGridColumn("NETOPOSTOTAK");
            UltraGridColumn column53 = new UltraGridColumn("NETOIZNOS");
            UltraGridBand band6 = new UltraGridBand("RADNIKObustava", -1);
            UltraGridColumn column57 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column63 = new UltraGridColumn("ZADOBUSTAVAIDOBUSTAVA");
            UltraGridColumn column58 = new UltraGridColumn("OBUSTAVAAKTIVNA");
            UltraGridColumn column64 = new UltraGridColumn("ZADOBUSTAVANAZIVOBUSTAVA");
            UltraGridColumn column67 = new UltraGridColumn("ZADOBUSTAVAVRSTAOBUSTAVE");
            UltraGridColumn column65 = new UltraGridColumn("ZADOBUSTAVANAZIVVRSTAOBUSTAVE");
            UltraGridColumn column62 = new UltraGridColumn("ZADIZNOSOBUSTAVE");
            UltraGridColumn column69 = new UltraGridColumn("ZADPOSTOTAKOBUSTAVE");
            UltraGridColumn column70 = new UltraGridColumn("ZADPOSTOTNAODBRUTA");
            UltraGridColumn column61 = new UltraGridColumn("ZADISPLACENOKASA");
            UltraGridColumn column71 = new UltraGridColumn("ZADSALDOKASA");
            UltraGridColumn column60 = new UltraGridColumn("OTPLACENIIZNOS");
            UltraGridColumn column59 = new UltraGridColumn("OTPLACENIBROJRATA");
            UltraGridColumn column68 = new UltraGridColumn("ZADOBUSTAVAZRNOBUSTAVA");
            UltraGridColumn column66 = new UltraGridColumn("ZADOBUSTAVAVBDIOBUSTAVA");
            UltraGridBand band4 = new UltraGridBand("RADNIKLevel7", -1);
            UltraGridColumn column47 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column45 = new UltraGridColumn("IDGRUPEKOEF");
            UltraGridColumn column46 = new UltraGridColumn("columnIDGRUPEKOEFAddNew", 0);
            UltraGridColumn column48 = new UltraGridColumn("NAZIVGRUPEKOEF");
            UltraGridColumn column44 = new UltraGridColumn("DODATNIKOEFICIJENT");
            UltraGridBand band2 = new UltraGridBand("RADNIKIzuzeceOdOvrhe", -1);
            UltraGridColumn column11 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column10 = new UltraGridColumn("BANKAZASTICENOIDBANKE");
            UltraGridColumn column18 = new UltraGridColumn("ZADSIFRAOPISAPLACANJAIZUZECE");
            UltraGridColumn column15 = new UltraGridColumn("ZADOPISPLACANJAIZUZECE");
            UltraGridColumn column19 = new UltraGridColumn("ZADTEKUCIIZUZECE");
            UltraGridColumn column13 = new UltraGridColumn("ZADMOIZUZECE");
            UltraGridColumn column16 = new UltraGridColumn("ZADPOIZUZECE");
            UltraGridColumn column14 = new UltraGridColumn("ZADMZIZUZECE");
            UltraGridColumn column17 = new UltraGridColumn("ZADPZIZUZECE");
            UltraGridColumn column12 = new UltraGridColumn("ZADIZNOSIZUZECA");
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.Tab2.Tabs.Add(tab8);
            this.Tab2.Controls.Add(this.TabPage3);
            this.Tab2.Tabs.Add(tab9);
            this.Tab2.Controls.Add(this.TabPage4);
            this.Tab2.Tabs.Add(tab10);
            this.Tab2.Controls.Add(this.TabPage5);
            this.Tab2.Tabs.Add(tab11);
            this.Tab2.Controls.Add(this.TabPage6);
            this.Tab2.Tabs.Add(tab13);
            this.Tab2.Controls.Add(this.TabPage8);
            this.Tab2.Tabs.Add(tab14);
            this.Tab2.Controls.Add(this.TabPage9);
            this.Tab1.Tabs.Add(tab2);
            this.Tab1.Controls.Add(this.Level4Page);
            this.Tab1.Tabs.Add(tab5);
            this.Tab1.Controls.Add(this.TabPage1);
            this.Tab1.Tabs.Add(tab7);
            this.Tab1.Controls.Add(this.TabPage2);
            this.Tab1.Tabs.Add(tab);
            this.Tab1.Controls.Add(this.KreditiPage);
            this.Tab1.Tabs.Add(tab3);
            this.Tab1.Controls.Add(this.OsobniOdbitakPage);
            this.Tab1.Tabs.Add(tab4);
            this.Tab1.Controls.Add(this.RADNIKLevel4Page);
            this.Tab1.Tabs.Add(tab12);
            this.Tab1.Controls.Add(this.TabPage7);
            this.Tab1.Tabs.Add(tab6);
            this.Tab1.Controls.Add(this.TabPage10);
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIK.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIK.DataMember = "RADNIK";
            ((ISupportInitialize) this.bindingSourceRADNIK).BeginInit();
            this.bindingSourceRADNIKOdbitak.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKOdbitak.DataMember = "RADNIK_RADNIKOdbitak";
            this.bindingSourceRADNIKOlaksica.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKOlaksica.DataMember = "RADNIK_RADNIKOlaksica";
            this.bindingSourceRADNIKKrediti.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKKrediti.DataMember = "RADNIK_RADNIKKrediti";
            this.bindingSourceRADNIKBruto.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKBruto.DataMember = "RADNIK_RADNIKBruto";
            this.bindingSourceRADNIKNeto.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKNeto.DataMember = "RADNIK_RADNIKNeto";
            this.bindingSourceRADNIKObustava.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKObustava.DataMember = "RADNIK_RADNIKObustava";
            this.bindingSourceRADNIKLevel7.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKLevel7.DataMember = "RADNIK_RADNIKLevel7";
            this.bindingSourceRADNIKIzuzeceOdOvrhe.DataSource = this.bindingSourceRADNIK;
            this.bindingSourceRADNIKIzuzeceOdOvrhe.DataMember = "RADNIK_RADNIKIzuzeceOdOvrhe";
            point = new System.Drawing.Point(0, 0);
            this.Tab2.Location = point;
            this.Tab2.Name = "Tab2";
            this.layoutManagerformRADNIK.Controls.Add(this.Tab2, 0, 0);
            this.layoutManagerformRADNIK.SetColumnSpan(this.Tab2, 1);
            this.layoutManagerformRADNIK.SetRowSpan(this.Tab2, 1);
            padding = new Padding(5, 11, 5, 5);
            this.Tab2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Tab2.MinimumSize = size;
            this.Tab2.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage3.Location = point;
            this.TabPage3.Name = "TabPage3";
            tab8.TabPage = this.TabPage3;
            tab8.Text = "Osnovni podaci o radniku";
            this.TabPage3.Controls.Add(this.layoutManagerTabPage3);
            point = new System.Drawing.Point(0, 0);
            this.Group6.Location = point;
            this.Group6.Name = "Group6";
            this.Group6.Text = "...";
            this.Group6.Dock = DockStyle.Fill;
            this.Group6.AutoSize = true;
            this.Group6.BackColor = Color.Transparent;
            this.Group6.Controls.Add(this.layoutManagerGroup6);
            this.layoutManagerTabPage3.Controls.Add(this.Group6, 0, 0);
            this.layoutManagerTabPage3.SetColumnSpan(this.Group6, 2);
            this.layoutManagerTabPage3.SetRowSpan(this.Group6, 1);
            padding = new Padding(2, 2, 2, 2);
            this.Group6.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Group6.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNIK.Location = point;
            this.label1IDRADNIK.Name = "label1IDRADNIK";
            this.label1IDRADNIK.TabIndex = 1;
            this.label1IDRADNIK.Tag = "labelIDRADNIK";
            this.label1IDRADNIK.Text = "Šifra radnika:";
            this.label1IDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNIK.AutoSize = true;
            this.label1IDRADNIK.Anchor = AnchorStyles.Left;
            this.label1IDRADNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNIK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRADNIK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRADNIK.ImageSize = size;
            this.label1IDRADNIK.Appearance.ForeColor = Color.Black;
            this.label1IDRADNIK.BackColor = Color.Transparent;
            this.layoutManagerGroup6.Controls.Add(this.label1IDRADNIK, 0, 0);
            this.layoutManagerGroup6.SetColumnSpan(this.label1IDRADNIK, 1);
            this.layoutManagerGroup6.SetRowSpan(this.label1IDRADNIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1IDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRADNIK.Location = point;
            this.textIDRADNIK.Name = "textIDRADNIK";
            this.textIDRADNIK.Tag = "IDRADNIK";
            this.textIDRADNIK.TabIndex = 0;
            this.textIDRADNIK.Anchor = AnchorStyles.Left;
            this.textIDRADNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRADNIK.ReadOnly = false;
            this.textIDRADNIK.PromptChar = ' ';
            this.textIDRADNIK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDRADNIK.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDRADNIK"));
            this.textIDRADNIK.NumericType = NumericType.Integer;
            this.textIDRADNIK.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerGroup6.Controls.Add(this.textIDRADNIK, 1, 0);
            this.layoutManagerGroup6.SetColumnSpan(this.textIDRADNIK, 1);
            this.layoutManagerGroup6.SetRowSpan(this.textIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDIPIDENT.Location = point;
            this.label1IDIPIDENT.Name = "label1IDIPIDENT";
            this.label1IDIPIDENT.TabIndex = 1;
            this.label1IDIPIDENT.Tag = "labelIDIPIDENT";
            this.label1IDIPIDENT.Text = "Šifra IP-a:";
            this.label1IDIPIDENT.StyleSetName = "FieldUltraLabel";
            this.label1IDIPIDENT.AutoSize = true;
            this.label1IDIPIDENT.Anchor = AnchorStyles.Left;
            this.label1IDIPIDENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDIPIDENT.Appearance.ForeColor = Color.Black;
            this.label1IDIPIDENT.BackColor = Color.Transparent;
            this.layoutManagerGroup6.Controls.Add(this.label1IDIPIDENT, 0, 1);
            this.layoutManagerGroup6.SetColumnSpan(this.label1IDIPIDENT, 1);
            this.layoutManagerGroup6.SetRowSpan(this.label1IDIPIDENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDIPIDENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x4e, 0x17);
            this.label1IDIPIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDIPIDENT.Location = point;
            this.comboIDIPIDENT.Name = "comboIDIPIDENT";
            this.comboIDIPIDENT.Tag = "IDIPIDENT";
            this.comboIDIPIDENT.TabIndex = 0;
            this.comboIDIPIDENT.Anchor = AnchorStyles.Left;
            this.comboIDIPIDENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDIPIDENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDIPIDENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDIPIDENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDIPIDENT.Enabled = true;
            this.comboIDIPIDENT.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDIPIDENT"));
            //comboIDIPIDENT.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDIPIDENT.ShowPictureBox = true;
            this.comboIDIPIDENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDIPIDENT);
            this.comboIDIPIDENT.ValueMember = "IDIPIDENT";
            this.comboIDIPIDENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDIPIDENT);
            this.layoutManagerGroup6.Controls.Add(this.comboIDIPIDENT, 1, 1);
            this.layoutManagerGroup6.SetColumnSpan(this.comboIDIPIDENT, 1);
            this.layoutManagerGroup6.SetRowSpan(this.comboIDIPIDENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDIPIDENT.Margin = padding;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.comboIDIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);//(91, 23);
            this.comboIDIPIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDSPOL.Location = point;
            this.label1IDSPOL.Name = "label1IDSPOL";
            this.label1IDSPOL.TabIndex = 1;
            this.label1IDSPOL.Tag = "labelIDSPOL";
            this.label1IDSPOL.Text = "Šifra spola:";
            this.label1IDSPOL.StyleSetName = "FieldUltraLabel";
            this.label1IDSPOL.AutoSize = true;
            this.label1IDSPOL.Anchor = AnchorStyles.Left;
            this.label1IDSPOL.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSPOL.Appearance.ForeColor = Color.Black;
            this.label1IDSPOL.BackColor = Color.Transparent;
            this.layoutManagerGroup6.Controls.Add(this.label1IDSPOL, 2, 0);
            this.layoutManagerGroup6.SetColumnSpan(this.label1IDSPOL, 1);
            this.layoutManagerGroup6.SetRowSpan(this.label1IDSPOL, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDSPOL.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0x55, 0x17);
            this.label1IDSPOL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDSPOL.Location = point;
            this.comboIDSPOL.Name = "comboIDSPOL";
            this.comboIDSPOL.Tag = "IDSPOL";
            this.comboIDSPOL.TabIndex = 0;
            this.comboIDSPOL.Anchor = AnchorStyles.Left;
            this.comboIDSPOL.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDSPOL.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSPOL.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSPOL.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDSPOL.Enabled = true;
            this.comboIDSPOL.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDSPOL"));
            //comboIDSPOL.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDSPOL.ShowPictureBox = true;
            this.comboIDSPOL.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDSPOL);
            this.comboIDSPOL.ValueMember = "IDSPOL";
            this.comboIDSPOL.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDSPOL);
            this.layoutManagerGroup6.Controls.Add(this.comboIDSPOL, 3, 0);
            this.layoutManagerGroup6.SetColumnSpan(this.comboIDSPOL, 1);
            this.layoutManagerGroup6.SetRowSpan(this.comboIDSPOL, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDSPOL.Margin = padding;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboIDSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboIDSPOL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1AKTIVAN.Location = point;
            this.label1AKTIVAN.Name = "label1AKTIVAN";
            this.label1AKTIVAN.TabIndex = 1;
            this.label1AKTIVAN.Tag = "labelAKTIVAN";
            this.label1AKTIVAN.Text = "aktivan:";
            this.label1AKTIVAN.StyleSetName = "FieldUltraLabel";
            this.label1AKTIVAN.AutoSize = true;
            this.label1AKTIVAN.Anchor = AnchorStyles.Left;
            this.label1AKTIVAN.Appearance.TextVAlign = VAlign.Middle;
            this.label1AKTIVAN.Appearance.ForeColor = Color.Black;
            this.label1AKTIVAN.BackColor = Color.Transparent;
            this.layoutManagerGroup6.Controls.Add(this.label1AKTIVAN, 2, 1);
            this.layoutManagerGroup6.SetColumnSpan(this.label1AKTIVAN, 1);
            this.layoutManagerGroup6.SetRowSpan(this.label1AKTIVAN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1AKTIVAN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1AKTIVAN.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1AKTIVAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkAKTIVAN.Location = point;
            this.checkAKTIVAN.Name = "checkAKTIVAN";
            this.checkAKTIVAN.Tag = "AKTIVAN";
            this.checkAKTIVAN.TabIndex = 0;
            this.checkAKTIVAN.Anchor = AnchorStyles.Left;
            this.checkAKTIVAN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkAKTIVAN.Enabled = true;
            this.layoutManagerGroup6.Controls.Add(this.checkAKTIVAN, 3, 1);
            this.layoutManagerGroup6.SetColumnSpan(this.checkAKTIVAN, 1);
            this.layoutManagerGroup6.SetRowSpan(this.checkAKTIVAN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkAKTIVAN.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkAKTIVAN.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkAKTIVAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PREZIME.Location = point;
            this.label1PREZIME.Name = "label1PREZIME";
            this.label1PREZIME.TabIndex = 1;
            this.label1PREZIME.Tag = "labelPREZIME";
            this.label1PREZIME.Text = "Prezime:";
            this.label1PREZIME.StyleSetName = "FieldUltraLabel";
            this.label1PREZIME.AutoSize = true;
            this.label1PREZIME.Anchor = AnchorStyles.Left;
            this.label1PREZIME.Appearance.TextVAlign = VAlign.Middle;
            this.label1PREZIME.Appearance.ForeColor = Color.Black;
            this.label1PREZIME.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1PREZIME, 0, 1);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1PREZIME, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1PREZIME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PREZIME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x45, 0x17);
            this.label1PREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPREZIME.Location = point;
            this.textPREZIME.Name = "textPREZIME";
            this.textPREZIME.Tag = "PREZIME";
            this.textPREZIME.TabIndex = 0;
            this.textPREZIME.Anchor = AnchorStyles.Left;
            this.textPREZIME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPREZIME.ReadOnly = false;
            this.textPREZIME.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "PREZIME"));
            this.textPREZIME.MaxLength = 50;
            this.layoutManagerTabPage3.Controls.Add(this.textPREZIME, 1, 1);
            this.layoutManagerTabPage3.SetColumnSpan(this.textPREZIME, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textPREZIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPREZIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IME.Location = point;
            this.label1IME.Name = "label1IME";
            this.label1IME.TabIndex = 1;
            this.label1IME.Tag = "labelIME";
            this.label1IME.Text = "Ime:";
            this.label1IME.StyleSetName = "FieldUltraLabel";
            this.label1IME.AutoSize = true;
            this.label1IME.Anchor = AnchorStyles.Left;
            this.label1IME.Appearance.TextVAlign = VAlign.Middle;
            this.label1IME.Appearance.ForeColor = Color.Black;
            this.label1IME.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1IME, 0, 2);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1IME, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1IME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IME.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x17);
            this.label1IME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIME.Location = point;
            this.textIME.Name = "textIME";
            this.textIME.Tag = "IME";
            this.textIME.TabIndex = 0;
            this.textIME.Anchor = AnchorStyles.Left;
            this.textIME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIME.ReadOnly = false;
            this.textIME.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "IME"));
            this.textIME.MaxLength = 50;
            this.layoutManagerTabPage3.Controls.Add(this.textIME, 1, 2);
            this.layoutManagerTabPage3.SetColumnSpan(this.textIME, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OIB.Location = point;
            this.label1OIB.Name = "label1OIB";
            this.label1OIB.TabIndex = 1;
            this.label1OIB.Tag = "labelOIB";
            this.label1OIB.Text = "Osobni identifikacijski broj:";
            this.label1OIB.StyleSetName = "FieldUltraLabel";
            this.label1OIB.AutoSize = true;
            this.label1OIB.Anchor = AnchorStyles.Left;
            this.label1OIB.Appearance.TextVAlign = VAlign.Middle;
            this.label1OIB.Appearance.ForeColor = Color.Black;
            this.label1OIB.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1OIB, 0, 3);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1OIB, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1OIB, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OIB.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OIB.MinimumSize = size;
            size = new System.Drawing.Size(0xba, 0x17);
            this.label1OIB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOIB.Location = point;
            this.textOIB.Name = "textOIB";
            this.textOIB.Tag = "OIB";
            this.textOIB.TabIndex = 0;
            this.textOIB.Anchor = AnchorStyles.Left;
            this.textOIB.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOIB.ContextMenu = this.contextMenu1;
            this.textOIB.ReadOnly = false;
            this.textOIB.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "OIB"));
            this.textOIB.Nullable = true;
            this.textOIB.MaxLength = 11;
            this.layoutManagerTabPage3.Controls.Add(this.textOIB, 1, 3);
            this.layoutManagerTabPage3.SetColumnSpan(this.textOIB, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textOIB, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOIB.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textOIB.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textOIB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1JMBG.Location = point;
            this.label1JMBG.Name = "label1JMBG";
            this.label1JMBG.TabIndex = 1;
            this.label1JMBG.Tag = "labelJMBG";
            this.label1JMBG.Text = "JMBG:";
            this.label1JMBG.StyleSetName = "FieldUltraLabel";
            this.label1JMBG.AutoSize = true;
            this.label1JMBG.Anchor = AnchorStyles.Left;
            this.label1JMBG.Appearance.TextVAlign = VAlign.Middle;
            this.label1JMBG.Appearance.ForeColor = Color.Black;
            this.label1JMBG.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1JMBG, 0, 4);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1JMBG, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1JMBG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1JMBG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1JMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1JMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textJMBG.Location = point;
            this.textJMBG.Name = "textJMBG";
            this.textJMBG.Tag = "JMBG";
            this.textJMBG.TabIndex = 0;
            this.textJMBG.Anchor = AnchorStyles.Left;
            this.textJMBG.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textJMBG.ReadOnly = false;
            this.textJMBG.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "JMBG"));
            this.textJMBG.MaxLength = 13;
            this.layoutManagerTabPage3.Controls.Add(this.textJMBG, 1, 4);
            this.layoutManagerTabPage3.SetColumnSpan(this.textJMBG, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textJMBG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textJMBG.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textJMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textJMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMRODJENJA.Location = point;
            this.label1DATUMRODJENJA.Name = "label1DATUMRODJENJA";
            this.label1DATUMRODJENJA.TabIndex = 1;
            this.label1DATUMRODJENJA.Tag = "labelDATUMRODJENJA";
            this.label1DATUMRODJENJA.Text = "Datum rođenja:";
            this.label1DATUMRODJENJA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMRODJENJA.AutoSize = true;
            this.label1DATUMRODJENJA.Anchor = AnchorStyles.Left;
            this.label1DATUMRODJENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMRODJENJA.Appearance.ForeColor = Color.Black;
            this.label1DATUMRODJENJA.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DATUMRODJENJA, 0, 5);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DATUMRODJENJA, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DATUMRODJENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMRODJENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMRODJENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1DATUMRODJENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMRODJENJA.Location = point;
            this.datePickerDATUMRODJENJA.Name = "datePickerDATUMRODJENJA";
            this.datePickerDATUMRODJENJA.Tag = "DATUMRODJENJA";
            this.datePickerDATUMRODJENJA.TabIndex = 0;
            this.datePickerDATUMRODJENJA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMRODJENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMRODJENJA.Enabled = true;
            this.layoutManagerTabPage3.Controls.Add(this.datePickerDATUMRODJENJA, 1, 5);
            this.layoutManagerTabPage3.SetColumnSpan(this.datePickerDATUMRODJENJA, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.datePickerDATUMRODJENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMRODJENJA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMRODJENJA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMRODJENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ulica.Location = point;
            this.label1ulica.Name = "label1ulica";
            this.label1ulica.TabIndex = 1;
            this.label1ulica.Tag = "labelulica";
            this.label1ulica.Text = "Ulica:";
            this.label1ulica.StyleSetName = "FieldUltraLabel";
            this.label1ulica.AutoSize = true;
            this.label1ulica.Anchor = AnchorStyles.Left;
            this.label1ulica.Appearance.TextVAlign = VAlign.Middle;
            this.label1ulica.Appearance.ForeColor = Color.Black;
            this.label1ulica.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1ulica, 0, 6);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1ulica, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1ulica, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ulica.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ulica.MinimumSize = size;
            size = new System.Drawing.Size(0x31, 0x17);
            this.label1ulica.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textulica.Location = point;
            this.textulica.Name = "textulica";
            this.textulica.Tag = "ulica";
            this.textulica.TabIndex = 0;
            this.textulica.Anchor = AnchorStyles.Left;
            this.textulica.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textulica.ReadOnly = false;
            this.textulica.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "ulica"));
            this.textulica.MaxLength = 50;
            this.layoutManagerTabPage3.Controls.Add(this.textulica, 1, 6);
            this.layoutManagerTabPage3.SetColumnSpan(this.textulica, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textulica, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textulica.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textulica.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textulica.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1kucnibroj.Location = point;
            this.label1kucnibroj.Name = "label1kucnibroj";
            this.label1kucnibroj.TabIndex = 1;
            this.label1kucnibroj.Tag = "labelkucnibroj";
            this.label1kucnibroj.Text = "Kućni broj:";
            this.label1kucnibroj.StyleSetName = "FieldUltraLabel";
            this.label1kucnibroj.AutoSize = true;
            this.label1kucnibroj.Anchor = AnchorStyles.Left;
            this.label1kucnibroj.Appearance.TextVAlign = VAlign.Middle;
            this.label1kucnibroj.Appearance.ForeColor = Color.Black;
            this.label1kucnibroj.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1kucnibroj, 0, 7);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1kucnibroj, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1kucnibroj, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1kucnibroj.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1kucnibroj.MinimumSize = size;
            size = new System.Drawing.Size(0x53, 0x17);
            this.label1kucnibroj.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textkucnibroj.Location = point;
            this.textkucnibroj.Name = "textkucnibroj";
            this.textkucnibroj.Tag = "kucnibroj";
            this.textkucnibroj.TabIndex = 0;
            this.textkucnibroj.Anchor = AnchorStyles.Left;
            this.textkucnibroj.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textkucnibroj.ReadOnly = false;
            this.textkucnibroj.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "kucnibroj"));
            this.textkucnibroj.MaxLength = 10;
            this.layoutManagerTabPage3.Controls.Add(this.textkucnibroj, 1, 7);
            this.layoutManagerTabPage3.SetColumnSpan(this.textkucnibroj, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textkucnibroj, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textkucnibroj.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textkucnibroj.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textkucnibroj.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1mjesto.Location = point;
            this.label1mjesto.Name = "label1mjesto";
            this.label1mjesto.TabIndex = 1;
            this.label1mjesto.Tag = "labelmjesto";
            this.label1mjesto.Text = "Mjesto:";
            this.label1mjesto.StyleSetName = "FieldUltraLabel";
            this.label1mjesto.AutoSize = true;
            this.label1mjesto.Anchor = AnchorStyles.Left;
            this.label1mjesto.Appearance.TextVAlign = VAlign.Middle;
            this.label1mjesto.Appearance.ForeColor = Color.Black;
            this.label1mjesto.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1mjesto, 0, 8);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1mjesto, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1mjesto, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1mjesto.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mjesto.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1mjesto.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textmjesto.Location = point;
            this.textmjesto.Name = "textmjesto";
            this.textmjesto.Tag = "mjesto";
            this.textmjesto.TabIndex = 0;
            this.textmjesto.Anchor = AnchorStyles.Left;
            this.textmjesto.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textmjesto.ReadOnly = false;
            this.textmjesto.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "mjesto"));
            this.textmjesto.MaxLength = 50;
            this.layoutManagerTabPage3.Controls.Add(this.textmjesto, 1, 8);
            this.layoutManagerTabPage3.SetColumnSpan(this.textmjesto, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textmjesto, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textmjesto.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textmjesto.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textmjesto.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.TabPage4.Location = point;
            this.TabPage4.Name = "TabPage4";
            tab9.TabPage = this.TabPage4;
            tab9.Text = "Općine i banke";
            this.TabPage4.Controls.Add(this.layoutManagerTabPage4);
            point = new System.Drawing.Point(0, 0);
            this.Group3.Location = point;
            this.Group3.Name = "Group3";
            this.Group3.Text = "Group3";
            this.Group3.Dock = DockStyle.Fill;
            this.Group3.AutoSize = true;
            this.Group3.BackColor = Color.Transparent;
            this.Group3.Controls.Add(this.layoutManagerGroup3);
            this.layoutManagerTabPage4.Controls.Add(this.Group3, 0, 0);
            this.layoutManagerTabPage4.SetColumnSpan(this.Group3, 1);
            this.layoutManagerTabPage4.SetRowSpan(this.Group3, 1);
            padding = new Padding(2, 2, 2, 2);
            this.Group3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Group3.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINASTANOVANJAIDOPCINE.Location = point;
            this.label1OPCINASTANOVANJAIDOPCINE.Name = "label1OPCINASTANOVANJAIDOPCINE";
            this.label1OPCINASTANOVANJAIDOPCINE.TabIndex = 1;
            this.label1OPCINASTANOVANJAIDOPCINE.Tag = "labelOPCINASTANOVANJAIDOPCINE";
            this.label1OPCINASTANOVANJAIDOPCINE.Text = "Šifra općine stanovanja:";
            this.label1OPCINASTANOVANJAIDOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINASTANOVANJAIDOPCINE.AutoSize = true;
            this.label1OPCINASTANOVANJAIDOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINASTANOVANJAIDOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINASTANOVANJAIDOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINASTANOVANJAIDOPCINE.BackColor = Color.Transparent;
            this.layoutManagerGroup3.Controls.Add(this.label1OPCINASTANOVANJAIDOPCINE, 0, 0);
            this.layoutManagerGroup3.SetColumnSpan(this.label1OPCINASTANOVANJAIDOPCINE, 1);
            this.layoutManagerGroup3.SetRowSpan(this.label1OPCINASTANOVANJAIDOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINASTANOVANJAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINASTANOVANJAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0xa5, 0x17);
            this.label1OPCINASTANOVANJAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPCINASTANOVANJAIDOPCINE.Location = point;
            this.textOPCINASTANOVANJAIDOPCINE.Name = "textOPCINASTANOVANJAIDOPCINE";
            this.textOPCINASTANOVANJAIDOPCINE.Tag = "OPCINASTANOVANJAIDOPCINE";
            this.textOPCINASTANOVANJAIDOPCINE.TabIndex = 0;
            this.textOPCINASTANOVANJAIDOPCINE.Anchor = AnchorStyles.Left;
            this.textOPCINASTANOVANJAIDOPCINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPCINASTANOVANJAIDOPCINE.ReadOnly = false;
            this.textOPCINASTANOVANJAIDOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "OPCINASTANOVANJAIDOPCINE"));
            this.textOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
            EditorButton button3 = new EditorButton {
                Key = "editorButtonOPCINAOPCINASTANOVANJAIDOPCINE",
                Tag = "editorButtonOPCINAOPCINASTANOVANJAIDOPCINE",
                Text = "..."
            };
            this.textOPCINASTANOVANJAIDOPCINE.ButtonsRight.Add(button3);
            this.textOPCINASTANOVANJAIDOPCINE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOPCINAOPCINASTANOVANJAIDOPCINE);
            this.layoutManagerGroup3.Controls.Add(this.textOPCINASTANOVANJAIDOPCINE, 1, 0);
            this.layoutManagerGroup3.SetColumnSpan(this.textOPCINASTANOVANJAIDOPCINE, 1);
            this.layoutManagerGroup3.SetRowSpan(this.textOPCINASTANOVANJAIDOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPCINASTANOVANJAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINASTANOVANJAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINASTANOVANJAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINASTANOVANJANAZIVOPCINE.Location = point;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Name = "label1OPCINASTANOVANJANAZIVOPCINE";
            this.label1OPCINASTANOVANJANAZIVOPCINE.TabIndex = 1;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Tag = "labelOPCINASTANOVANJANAZIVOPCINE";
            this.label1OPCINASTANOVANJANAZIVOPCINE.Text = "Naziv općine stanovanja:";
            this.label1OPCINASTANOVANJANAZIVOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINASTANOVANJANAZIVOPCINE.AutoSize = true;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINASTANOVANJANAZIVOPCINE.BackColor = Color.Transparent;
            this.layoutManagerGroup3.Controls.Add(this.label1OPCINASTANOVANJANAZIVOPCINE, 0, 1);
            this.layoutManagerGroup3.SetColumnSpan(this.label1OPCINASTANOVANJANAZIVOPCINE, 1);
            this.layoutManagerGroup3.SetRowSpan(this.label1OPCINASTANOVANJANAZIVOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINASTANOVANJANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINASTANOVANJANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x17);
            this.label1OPCINASTANOVANJANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPCINASTANOVANJANAZIVOPCINE.Location = point;
            this.labelOPCINASTANOVANJANAZIVOPCINE.Name = "labelOPCINASTANOVANJANAZIVOPCINE";
            this.labelOPCINASTANOVANJANAZIVOPCINE.Tag = "OPCINASTANOVANJANAZIVOPCINE";
            this.labelOPCINASTANOVANJANAZIVOPCINE.TabIndex = 0;
            this.labelOPCINASTANOVANJANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.labelOPCINASTANOVANJANAZIVOPCINE.BackColor = Color.Transparent;
            this.labelOPCINASTANOVANJANAZIVOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "OPCINASTANOVANJANAZIVOPCINE"));
            this.labelOPCINASTANOVANJANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerGroup3.Controls.Add(this.labelOPCINASTANOVANJANAZIVOPCINE, 1, 1);
            this.layoutManagerGroup3.SetColumnSpan(this.labelOPCINASTANOVANJANAZIVOPCINE, 3);
            this.layoutManagerGroup3.SetRowSpan(this.labelOPCINASTANOVANJANAZIVOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPCINASTANOVANJANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINASTANOVANJANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINASTANOVANJANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINARADAIDOPCINE.Location = point;
            this.label1OPCINARADAIDOPCINE.Name = "label1OPCINARADAIDOPCINE";
            this.label1OPCINARADAIDOPCINE.TabIndex = 1;
            this.label1OPCINARADAIDOPCINE.Tag = "labelOPCINARADAIDOPCINE";
            this.label1OPCINARADAIDOPCINE.Text = "Šifra općine rada:";
            this.label1OPCINARADAIDOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINARADAIDOPCINE.AutoSize = true;
            this.label1OPCINARADAIDOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINARADAIDOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINARADAIDOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINARADAIDOPCINE.BackColor = Color.Transparent;
            this.layoutManagerGroup3.Controls.Add(this.label1OPCINARADAIDOPCINE, 0, 2);
            this.layoutManagerGroup3.SetColumnSpan(this.label1OPCINARADAIDOPCINE, 1);
            this.layoutManagerGroup3.SetRowSpan(this.label1OPCINARADAIDOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINARADAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINARADAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x7c, 0x17);
            this.label1OPCINARADAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPCINARADAIDOPCINE.Location = point;
            this.textOPCINARADAIDOPCINE.Name = "textOPCINARADAIDOPCINE";
            this.textOPCINARADAIDOPCINE.Tag = "OPCINARADAIDOPCINE";
            this.textOPCINARADAIDOPCINE.TabIndex = 0;
            this.textOPCINARADAIDOPCINE.Anchor = AnchorStyles.Left;
            this.textOPCINARADAIDOPCINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPCINARADAIDOPCINE.ReadOnly = false;
            this.textOPCINARADAIDOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "OPCINARADAIDOPCINE"));
            this.textOPCINARADAIDOPCINE.MaxLength = 4;
            EditorButton button2 = new EditorButton {
                Key = "editorButtonOPCINAOPCINARADAIDOPCINE",
                Tag = "editorButtonOPCINAOPCINARADAIDOPCINE",
                Text = "..."
            };
            this.textOPCINARADAIDOPCINE.ButtonsRight.Add(button2);
            this.textOPCINARADAIDOPCINE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOPCINAOPCINARADAIDOPCINE);
            this.layoutManagerGroup3.Controls.Add(this.textOPCINARADAIDOPCINE, 1, 2);
            this.layoutManagerGroup3.SetColumnSpan(this.textOPCINARADAIDOPCINE, 1);
            this.layoutManagerGroup3.SetRowSpan(this.textOPCINARADAIDOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPCINARADAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINARADAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINARADAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINARADANAZIVOPCINE.Location = point;
            this.label1OPCINARADANAZIVOPCINE.Name = "label1OPCINARADANAZIVOPCINE";
            this.label1OPCINARADANAZIVOPCINE.TabIndex = 1;
            this.label1OPCINARADANAZIVOPCINE.Tag = "labelOPCINARADANAZIVOPCINE";
            this.label1OPCINARADANAZIVOPCINE.Text = "Naziv općine rada:";
            this.label1OPCINARADANAZIVOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINARADANAZIVOPCINE.AutoSize = true;
            this.label1OPCINARADANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINARADANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINARADANAZIVOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINARADANAZIVOPCINE.BackColor = Color.Transparent;
            this.layoutManagerGroup3.Controls.Add(this.label1OPCINARADANAZIVOPCINE, 0, 3);
            this.layoutManagerGroup3.SetColumnSpan(this.label1OPCINARADANAZIVOPCINE, 1);
            this.layoutManagerGroup3.SetRowSpan(this.label1OPCINARADANAZIVOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINARADANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINARADANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x81, 0x17);
            this.label1OPCINARADANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPCINARADANAZIVOPCINE.Location = point;
            this.labelOPCINARADANAZIVOPCINE.Name = "labelOPCINARADANAZIVOPCINE";
            this.labelOPCINARADANAZIVOPCINE.Tag = "OPCINARADANAZIVOPCINE";
            this.labelOPCINARADANAZIVOPCINE.TabIndex = 0;
            this.labelOPCINARADANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.labelOPCINARADANAZIVOPCINE.BackColor = Color.Transparent;
            this.labelOPCINARADANAZIVOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "OPCINARADANAZIVOPCINE"));
            this.labelOPCINARADANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerGroup3.Controls.Add(this.labelOPCINARADANAZIVOPCINE, 1, 3);
            this.layoutManagerGroup3.SetColumnSpan(this.labelOPCINARADANAZIVOPCINE, 3);
            this.layoutManagerGroup3.SetRowSpan(this.labelOPCINARADANAZIVOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPCINARADANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINARADANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINARADANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINASTANOVANJAPRIREZ.Location = point;
            this.label1OPCINASTANOVANJAPRIREZ.Name = "label1OPCINASTANOVANJAPRIREZ";
            this.label1OPCINASTANOVANJAPRIREZ.TabIndex = 1;
            this.label1OPCINASTANOVANJAPRIREZ.Tag = "labelOPCINASTANOVANJAPRIREZ";
            this.label1OPCINASTANOVANJAPRIREZ.Text = "Prirez općine stanovanja:";
            this.label1OPCINASTANOVANJAPRIREZ.StyleSetName = "FieldUltraLabel";
            this.label1OPCINASTANOVANJAPRIREZ.AutoSize = true;
            this.label1OPCINASTANOVANJAPRIREZ.Anchor = AnchorStyles.Left;
            this.label1OPCINASTANOVANJAPRIREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINASTANOVANJAPRIREZ.Appearance.ForeColor = Color.Black;
            this.label1OPCINASTANOVANJAPRIREZ.BackColor = Color.Transparent;
            this.layoutManagerGroup3.Controls.Add(this.label1OPCINASTANOVANJAPRIREZ, 2, 0);
            this.layoutManagerGroup3.SetColumnSpan(this.label1OPCINASTANOVANJAPRIREZ, 1);
            this.layoutManagerGroup3.SetRowSpan(this.label1OPCINASTANOVANJAPRIREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINASTANOVANJAPRIREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINASTANOVANJAPRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xac, 0x17);
            this.label1OPCINASTANOVANJAPRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPCINASTANOVANJAPRIREZ.Location = point;
            this.labelOPCINASTANOVANJAPRIREZ.Name = "labelOPCINASTANOVANJAPRIREZ";
            this.labelOPCINASTANOVANJAPRIREZ.Tag = "OPCINASTANOVANJAPRIREZ";
            this.labelOPCINASTANOVANJAPRIREZ.TabIndex = 0;
            this.labelOPCINASTANOVANJAPRIREZ.Anchor = AnchorStyles.Left;
            this.labelOPCINASTANOVANJAPRIREZ.BackColor = Color.Transparent;
            this.labelOPCINASTANOVANJAPRIREZ.Appearance.TextHAlign = HAlign.Left;
            this.labelOPCINASTANOVANJAPRIREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerGroup3.Controls.Add(this.labelOPCINASTANOVANJAPRIREZ, 3, 0);
            this.layoutManagerGroup3.SetColumnSpan(this.labelOPCINASTANOVANJAPRIREZ, 1);
            this.layoutManagerGroup3.SetRowSpan(this.labelOPCINASTANOVANJAPRIREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPCINASTANOVANJAPRIREZ.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOPCINASTANOVANJAPRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOPCINASTANOVANJAPRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.Group4.Location = point;
            this.Group4.Name = "Group4";
            this.Group4.Text = "Skupine poreza i doprinosa";
            this.Group4.Dock = DockStyle.Fill;
            this.Group4.AutoSize = true;
            this.Group4.BackColor = Color.Transparent;
            this.Group4.Controls.Add(this.layoutManagerGroup4);
            this.layoutManagerTabPage4.Controls.Add(this.Group4, 0, 1);
            this.layoutManagerTabPage4.SetColumnSpan(this.Group4, 1);
            this.layoutManagerTabPage4.SetRowSpan(this.Group4, 1);
            padding = new Padding(2, 2, 2, 2);
            this.Group4.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Group4.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Location = point;
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Name = "label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA";
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.TabIndex = 1;
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Tag = "labelRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA";
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Text = "Šifra skupine poreza i doprinosa:";
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.StyleSetName = "FieldUltraLabel";
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.AutoSize = true;
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Anchor = AnchorStyles.Left;
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Appearance.ForeColor = Color.Black;
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.BackColor = Color.Transparent;
            this.layoutManagerGroup4.Controls.Add(this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, 0, 0);
            this.layoutManagerGroup4.SetColumnSpan(this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, 1);
            this.layoutManagerGroup4.SetRowSpan(this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(0xda, 0x17);
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Location = point;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Name = "comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA";
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Tag = "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA";
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.TabIndex = 0;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Anchor = AnchorStyles.Left;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.DropDownStyle = DropDownStyle.DropDown;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Enabled = true;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"));
            //comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ShowPictureBox = true;
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ValueMember = "IDSKUPPOREZAIDOPRINOSA";
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.SelectionChanged += new EventHandler(this.SelectedIndexChangedRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
            this.layoutManagerGroup4.Controls.Add(this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, 1, 0);
            this.layoutManagerGroup4.SetColumnSpan(this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, 2);
            this.layoutManagerGroup4.SetRowSpan(this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.Group2.Location = point;
            this.Group2.Name = "Group2";
            this.Group2.Text = "Banke";
            this.Group2.Dock = DockStyle.Fill;
            this.Group2.AutoSize = true;
            this.Group2.BackColor = Color.Transparent;
            this.Group2.Controls.Add(this.layoutManagerGroup2);
            this.layoutManagerGroup4.Controls.Add(this.Group2, 0, 1);
            this.layoutManagerGroup4.SetColumnSpan(this.Group2, 2);
            this.layoutManagerGroup4.SetRowSpan(this.Group2, 1);
            padding = new Padding(2, 2, 2, 2);
            this.Group2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Group2.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDBANKE.Location = point;
            this.label1IDBANKE.Name = "label1IDBANKE";
            this.label1IDBANKE.TabIndex = 1;
            this.label1IDBANKE.Tag = "labelIDBANKE";
            this.label1IDBANKE.Text = "Šifra banke:";
            this.label1IDBANKE.StyleSetName = "FieldUltraLabel";
            this.label1IDBANKE.AutoSize = true;
            this.label1IDBANKE.Anchor = AnchorStyles.Left;
            this.label1IDBANKE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDBANKE.Appearance.ForeColor = Color.Black;
            this.label1IDBANKE.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1IDBANKE, 0, 0);
            this.layoutManagerGroup2.SetColumnSpan(this.label1IDBANKE, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1IDBANKE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDBANKE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDBANKE.MinimumSize = size;
            size = new System.Drawing.Size(90, 0x17);
            this.label1IDBANKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDBANKE.Location = point;
            this.textIDBANKE.Name = "textIDBANKE";
            this.textIDBANKE.Tag = "IDBANKE";
            this.textIDBANKE.TabIndex = 0;
            this.textIDBANKE.Anchor = AnchorStyles.Left;
            this.textIDBANKE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDBANKE.ReadOnly = false;
            this.textIDBANKE.PromptChar = ' ';
            this.textIDBANKE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDBANKE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDBANKE"));
            this.textIDBANKE.NumericType = NumericType.Integer;
            this.textIDBANKE.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonBANKEIDBANKE",
                Tag = "editorButtonBANKEIDBANKE",
                Text = "..."
            };
            this.textIDBANKE.ButtonsRight.Add(button);
            this.textIDBANKE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptBANKEIDBANKE);
            this.layoutManagerGroup2.Controls.Add(this.textIDBANKE, 1, 0);
            this.layoutManagerGroup2.SetColumnSpan(this.textIDBANKE, 1);
            this.layoutManagerGroup2.SetRowSpan(this.textIDBANKE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDBANKE.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDBANKE.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDBANKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1TEKUCI.Location = point;
            this.label1TEKUCI.Name = "label1TEKUCI";
            this.label1TEKUCI.TabIndex = 1;
            this.label1TEKUCI.Tag = "labelTEKUCI";
            this.label1TEKUCI.Text = "Tekući račun:";
            this.label1TEKUCI.StyleSetName = "FieldUltraLabel";
            this.label1TEKUCI.AutoSize = true;
            this.label1TEKUCI.Anchor = AnchorStyles.Left;
            this.label1TEKUCI.Appearance.TextVAlign = VAlign.Middle;
            this.label1TEKUCI.Appearance.ForeColor = Color.Black;
            this.label1TEKUCI.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1TEKUCI, 0, 1);
            this.layoutManagerGroup2.SetColumnSpan(this.label1TEKUCI, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1TEKUCI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1TEKUCI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1TEKUCI.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 0x17);
            this.label1TEKUCI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textTEKUCI.Location = point;
            this.textTEKUCI.Name = "textTEKUCI";
            this.textTEKUCI.Tag = "TEKUCI";
            this.textTEKUCI.TabIndex = 0;
            this.textTEKUCI.Anchor = AnchorStyles.Left;
            this.textTEKUCI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textTEKUCI.ReadOnly = false;
            this.textTEKUCI.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "TEKUCI"));
            this.textTEKUCI.MaxLength = 10;
            this.layoutManagerGroup2.Controls.Add(this.textTEKUCI, 1, 1);
            this.layoutManagerGroup2.SetColumnSpan(this.textTEKUCI, 1);
            this.layoutManagerGroup2.SetRowSpan(this.textTEKUCI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textTEKUCI.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textTEKUCI.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textTEKUCI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MO.Location = point;
            this.label1MO.Name = "label1MO";
            this.label1MO.TabIndex = 1;
            this.label1MO.Tag = "labelMO";
            this.label1MO.Text = "Model odobrenja kod pojedinačne uplate na tekući:";
            this.label1MO.StyleSetName = "FieldUltraLabel";
            this.label1MO.AutoSize = true;
            this.label1MO.Anchor = AnchorStyles.Left;
            this.label1MO.Appearance.TextVAlign = VAlign.Middle;
            this.label1MO.Appearance.ForeColor = Color.Black;
            this.label1MO.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1MO, 0, 2);
            this.layoutManagerGroup2.SetColumnSpan(this.label1MO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1MO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MO.MinimumSize = size;
            size = new System.Drawing.Size(0x14d, 0x17);
            this.label1MO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMO.Location = point;
            this.textMO.Name = "textMO";
            this.textMO.Tag = "MO";
            this.textMO.TabIndex = 0;
            this.textMO.Anchor = AnchorStyles.Left;
            this.textMO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMO.ContextMenu = this.contextMenu1;
            this.textMO.ReadOnly = false;
            this.textMO.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "MO"));
            this.textMO.Nullable = true;
            this.textMO.MaxLength = 2;
            this.layoutManagerGroup2.Controls.Add(this.textMO, 1, 2);
            this.layoutManagerGroup2.SetColumnSpan(this.textMO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.textMO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMO.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMO.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJANETO.Location = point;
            this.label1SIFRAOPISAPLACANJANETO.Name = "label1SIFRAOPISAPLACANJANETO";
            this.label1SIFRAOPISAPLACANJANETO.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJANETO.Tag = "labelSIFRAOPISAPLACANJANETO";
            this.label1SIFRAOPISAPLACANJANETO.Text = "Šifra opisa plaćanja (iznos za isplatu):";
            this.label1SIFRAOPISAPLACANJANETO.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJANETO.AutoSize = true;
            this.label1SIFRAOPISAPLACANJANETO.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJANETO.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJANETO.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJANETO.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1SIFRAOPISAPLACANJANETO, 0, 3);
            this.layoutManagerGroup2.SetColumnSpan(this.label1SIFRAOPISAPLACANJANETO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1SIFRAOPISAPLACANJANETO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(0xfb, 0x17);
            this.label1SIFRAOPISAPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJANETO.Location = point;
            this.textSIFRAOPISAPLACANJANETO.Name = "textSIFRAOPISAPLACANJANETO";
            this.textSIFRAOPISAPLACANJANETO.Tag = "SIFRAOPISAPLACANJANETO";
            this.textSIFRAOPISAPLACANJANETO.TabIndex = 0;
            this.textSIFRAOPISAPLACANJANETO.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJANETO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJANETO.ReadOnly = false;
            this.textSIFRAOPISAPLACANJANETO.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "SIFRAOPISAPLACANJANETO"));
            this.textSIFRAOPISAPLACANJANETO.MaxLength = 2;
            this.layoutManagerGroup2.Controls.Add(this.textSIFRAOPISAPLACANJANETO, 1, 3);
            this.layoutManagerGroup2.SetColumnSpan(this.textSIFRAOPISAPLACANJANETO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.textSIFRAOPISAPLACANJANETO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVBANKE1.Location = point;
            this.label1NAZIVBANKE1.Name = "label1NAZIVBANKE1";
            this.label1NAZIVBANKE1.TabIndex = 1;
            this.label1NAZIVBANKE1.Tag = "labelNAZIVBANKE1";
            this.label1NAZIVBANKE1.Text = "Naziv banke:";
            this.label1NAZIVBANKE1.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBANKE1.AutoSize = true;
            this.label1NAZIVBANKE1.Anchor = AnchorStyles.Left;
            this.label1NAZIVBANKE1.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVBANKE1.Appearance.ForeColor = Color.Black;
            this.label1NAZIVBANKE1.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1NAZIVBANKE1, 2, 0);
            this.layoutManagerGroup2.SetColumnSpan(this.label1NAZIVBANKE1, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1NAZIVBANKE1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVBANKE1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVBANKE1.MinimumSize = size;
            size = new System.Drawing.Size(0x5f, 0x17);
            this.label1NAZIVBANKE1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVBANKE1.Location = point;
            this.labelNAZIVBANKE1.Name = "labelNAZIVBANKE1";
            this.labelNAZIVBANKE1.Tag = "NAZIVBANKE1";
            this.labelNAZIVBANKE1.TabIndex = 0;
            this.labelNAZIVBANKE1.Anchor = AnchorStyles.Left;
            this.labelNAZIVBANKE1.BackColor = Color.Transparent;
            this.labelNAZIVBANKE1.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "NAZIVBANKE1"));
            this.labelNAZIVBANKE1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerGroup2.Controls.Add(this.labelNAZIVBANKE1, 3, 0);
            this.layoutManagerGroup2.SetColumnSpan(this.labelNAZIVBANKE1, 1);
            this.layoutManagerGroup2.SetRowSpan(this.labelNAZIVBANKE1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVBANKE1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVBANKE1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVBANKE1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZBIRNINETO.Location = point;
            this.label1ZBIRNINETO.Name = "label1ZBIRNINETO";
            this.label1ZBIRNINETO.TabIndex = 1;
            this.label1ZBIRNINETO.Tag = "labelZBIRNINETO";
            this.label1ZBIRNINETO.Text = "Uključen u zbirni neto:";
            this.label1ZBIRNINETO.StyleSetName = "FieldUltraLabel";
            this.label1ZBIRNINETO.AutoSize = true;
            this.label1ZBIRNINETO.Anchor = AnchorStyles.Left;
            this.label1ZBIRNINETO.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZBIRNINETO.Appearance.ForeColor = Color.Black;
            this.label1ZBIRNINETO.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1ZBIRNINETO, 2, 1);
            this.layoutManagerGroup2.SetColumnSpan(this.label1ZBIRNINETO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1ZBIRNINETO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZBIRNINETO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZBIRNINETO.MinimumSize = size;
            size = new System.Drawing.Size(0x9b, 0x17);
            this.label1ZBIRNINETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkZBIRNINETO.Location = point;
            this.checkZBIRNINETO.Name = "checkZBIRNINETO";
            this.checkZBIRNINETO.Tag = "ZBIRNINETO";
            this.checkZBIRNINETO.TabIndex = 0;
            this.checkZBIRNINETO.Anchor = AnchorStyles.Left;
            this.checkZBIRNINETO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkZBIRNINETO.Enabled = true;
            this.layoutManagerGroup2.Controls.Add(this.checkZBIRNINETO, 3, 1);
            this.layoutManagerGroup2.SetColumnSpan(this.checkZBIRNINETO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.checkZBIRNINETO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkZBIRNINETO.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkZBIRNINETO.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkZBIRNINETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PBO.Location = point;
            this.label1PBO.Name = "label1PBO";
            this.label1PBO.TabIndex = 1;
            this.label1PBO.Tag = "labelPBO";
            this.label1PBO.Text = "Poziv na broj odobrenja kod pojedinačne uplate na tekući:";
            this.label1PBO.StyleSetName = "FieldUltraLabel";
            this.label1PBO.AutoSize = true;
            this.label1PBO.Anchor = AnchorStyles.Left;
            this.label1PBO.Appearance.TextVAlign = VAlign.Middle;
            this.label1PBO.Appearance.ForeColor = Color.Black;
            this.label1PBO.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1PBO, 2, 2);
            this.layoutManagerGroup2.SetColumnSpan(this.label1PBO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1PBO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PBO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PBO.MinimumSize = size;
            size = new System.Drawing.Size(0x178, 0x17);
            this.label1PBO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPBO.Location = point;
            this.textPBO.Name = "textPBO";
            this.textPBO.Tag = "PBO";
            this.textPBO.TabIndex = 0;
            this.textPBO.Anchor = AnchorStyles.Left;
            this.textPBO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPBO.ContextMenu = this.contextMenu1;
            this.textPBO.ReadOnly = false;
            this.textPBO.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "PBO"));
            this.textPBO.Nullable = true;
            this.textPBO.MaxLength = 0x16;
            this.layoutManagerGroup2.Controls.Add(this.textPBO, 3, 2);
            this.layoutManagerGroup2.SetColumnSpan(this.textPBO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.textPBO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPBO.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPBO.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPBO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJANETO.Location = point;
            this.label1OPISPLACANJANETO.Name = "label1OPISPLACANJANETO";
            this.label1OPISPLACANJANETO.TabIndex = 1;
            this.label1OPISPLACANJANETO.Tag = "labelOPISPLACANJANETO";
            this.label1OPISPLACANJANETO.Text = "Opis plaćanja (iznos za isplatu):";
            this.label1OPISPLACANJANETO.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJANETO.AutoSize = true;
            this.label1OPISPLACANJANETO.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJANETO.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJANETO.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJANETO.BackColor = Color.Transparent;
            this.layoutManagerGroup2.Controls.Add(this.label1OPISPLACANJANETO, 2, 3);
            this.layoutManagerGroup2.SetColumnSpan(this.label1OPISPLACANJANETO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.label1OPISPLACANJANETO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(0xd5, 0x17);
            this.label1OPISPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJANETO.Location = point;
            this.textOPISPLACANJANETO.Name = "textOPISPLACANJANETO";
            this.textOPISPLACANJANETO.Tag = "OPISPLACANJANETO";
            this.textOPISPLACANJANETO.TabIndex = 0;
            this.textOPISPLACANJANETO.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJANETO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJANETO.ReadOnly = false;
            this.textOPISPLACANJANETO.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "OPISPLACANJANETO"));
            this.textOPISPLACANJANETO.MaxLength = 0x24;
            this.layoutManagerGroup2.Controls.Add(this.textOPISPLACANJANETO, 3, 3);
            this.layoutManagerGroup2.SetColumnSpan(this.textOPISPLACANJANETO, 1);
            this.layoutManagerGroup2.SetRowSpan(this.textOPISPLACANJANETO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.TabPage5.Location = point;
            this.TabPage5.Name = "TabPage5";
            tab10.TabPage = this.TabPage5;
            tab10.Text = "Koeficijent i staž";
            this.TabPage5.Controls.Add(this.layoutManagerTabPage5);
            point = new System.Drawing.Point(0, 0);
            this.label1KOEFICIJENT.Location = point;
            this.label1KOEFICIJENT.Name = "label1KOEFICIJENT";
            this.label1KOEFICIJENT.TabIndex = 1;
            this.label1KOEFICIJENT.Tag = "labelKOEFICIJENT";
            this.label1KOEFICIJENT.Text = "Koeficijent:";
            this.label1KOEFICIJENT.StyleSetName = "FieldUltraLabel";
            this.label1KOEFICIJENT.AutoSize = true;
            this.label1KOEFICIJENT.Anchor = AnchorStyles.Left;
            this.label1KOEFICIJENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1KOEFICIJENT.Appearance.ForeColor = Color.Black;
            this.label1KOEFICIJENT.BackColor = Color.Transparent;
            this.layoutManagerTabPage5.Controls.Add(this.label1KOEFICIJENT, 0, 0);
            this.layoutManagerTabPage5.SetColumnSpan(this.label1KOEFICIJENT, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.label1KOEFICIJENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x17);
            this.label1KOEFICIJENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKOEFICIJENT.Location = point;
            this.textKOEFICIJENT.Name = "textKOEFICIJENT";
            this.textKOEFICIJENT.Tag = "KOEFICIJENT";
            this.textKOEFICIJENT.TabIndex = 0;
            this.textKOEFICIJENT.Anchor = AnchorStyles.Left;
            this.textKOEFICIJENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKOEFICIJENT.ReadOnly = false;
            this.textKOEFICIJENT.PromptChar = ' ';
            this.textKOEFICIJENT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKOEFICIJENT.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "KOEFICIJENT"));
            this.textKOEFICIJENT.NumericType = NumericType.Double;
            this.textKOEFICIJENT.MaxValue = 79228162514264337593543950335M;
            this.textKOEFICIJENT.MinValue = -79228162514264337593543950335M;
            this.textKOEFICIJENT.MaskInput = "{LOC}-nnnnnnn.nnnnnnnnnn";
            this.layoutManagerTabPage5.Controls.Add(this.textKOEFICIJENT, 1, 0);
            this.layoutManagerTabPage5.SetColumnSpan(this.textKOEFICIJENT, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.textKOEFICIJENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKOEFICIJENT.Margin = padding;
            size = new System.Drawing.Size(0x88, 0x16);
            this.textKOEFICIJENT.MinimumSize = size;
            size = new System.Drawing.Size(0x88, 0x16);
            this.textKOEFICIJENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Location = point;
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Name = "label1POSTOTAKOSLOBODJENJAODPOREZA";
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.TabIndex = 1;
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Tag = "labelPOSTOTAKOSLOBODJENJAODPOREZA";
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Text = "Postotak oslobođenja od poreza (HRVI, ...):";
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.StyleSetName = "FieldUltraLabel";
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.AutoSize = true;
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Anchor = AnchorStyles.Left;
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Appearance.ForeColor = Color.Black;
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.BackColor = Color.Transparent;
            this.layoutManagerTabPage5.Controls.Add(this.label1POSTOTAKOSLOBODJENJAODPOREZA, 0, 1);
            this.layoutManagerTabPage5.SetColumnSpan(this.label1POSTOTAKOSLOBODJENJAODPOREZA, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.label1POSTOTAKOSLOBODJENJAODPOREZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.MinimumSize = size;
            size = new System.Drawing.Size(0x11c, 0x17);
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.Location = point;
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.Name = "textPOSTOTAKOSLOBODJENJAODPOREZA";
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.Tag = "POSTOTAKOSLOBODJENJAODPOREZA";
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.TabIndex = 0;
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.Anchor = AnchorStyles.Left;
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.ReadOnly = false;
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.PromptChar = ' ';
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "POSTOTAKOSLOBODJENJAODPOREZA"));
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.NumericType = NumericType.Double;
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.MaxValue = 79228162514264337593543950335M;
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.MinValue = -79228162514264337593543950335M;
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerTabPage5.Controls.Add(this.textPOSTOTAKOSLOBODJENJAODPOREZA, 1, 1);
            this.layoutManagerTabPage5.SetColumnSpan(this.textPOSTOTAKOSLOBODJENJAODPOREZA, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.textPOSTOTAKOSLOBODJENJAODPOREZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPOSTOTAKOSLOBODJENJAODPOREZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Location = point;
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Name = "label1UZIMAUOBZIROSNOVICEDOPRINOSA";
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.TabIndex = 1;
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Tag = "labelUZIMAUOBZIROSNOVICEDOPRINOSA";
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Text = "Korištenje min. i maks. osnovice za obračun doprinosa:";
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.StyleSetName = "FieldUltraLabel";
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.AutoSize = true;
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Anchor = AnchorStyles.Left;
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Appearance.ForeColor = Color.Black;
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.BackColor = Color.Transparent;
            this.layoutManagerTabPage5.Controls.Add(this.label1UZIMAUOBZIROSNOVICEDOPRINOSA, 0, 2);
            this.layoutManagerTabPage5.SetColumnSpan(this.label1UZIMAUOBZIROSNOVICEDOPRINOSA, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.label1UZIMAUOBZIROSNOVICEDOPRINOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x164, 0x17);
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.Location = point;
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.Name = "checkUZIMAUOBZIROSNOVICEDOPRINOSA";
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.Tag = "UZIMAUOBZIROSNOVICEDOPRINOSA";
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.TabIndex = 0;
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.Anchor = AnchorStyles.Left;
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.Enabled = true;
            this.layoutManagerTabPage5.Controls.Add(this.checkUZIMAUOBZIROSNOVICEDOPRINOSA, 1, 2);
            this.layoutManagerTabPage5.SetColumnSpan(this.checkUZIMAUOBZIROSNOVICEDOPRINOSA, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.checkUZIMAUOBZIROSNOVICEDOPRINOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkUZIMAUOBZIROSNOVICEDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1TJEDNIFONDSATI.Location = point;
            this.label1TJEDNIFONDSATI.Name = "label1TJEDNIFONDSATI";
            this.label1TJEDNIFONDSATI.TabIndex = 1;
            this.label1TJEDNIFONDSATI.Tag = "labelTJEDNIFONDSATI";
            this.label1TJEDNIFONDSATI.Text = "Tjedni fond sati (za obračun):";
            this.label1TJEDNIFONDSATI.StyleSetName = "FieldUltraLabel";
            this.label1TJEDNIFONDSATI.AutoSize = true;
            this.label1TJEDNIFONDSATI.Anchor = AnchorStyles.Left;
            this.label1TJEDNIFONDSATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1TJEDNIFONDSATI.Appearance.ForeColor = Color.Black;
            this.label1TJEDNIFONDSATI.BackColor = Color.Transparent;
            this.layoutManagerTabPage5.Controls.Add(this.label1TJEDNIFONDSATI, 0, 3);
            this.layoutManagerTabPage5.SetColumnSpan(this.label1TJEDNIFONDSATI, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.label1TJEDNIFONDSATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1TJEDNIFONDSATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1TJEDNIFONDSATI.MinimumSize = size;
            size = new System.Drawing.Size(0xc7, 0x17);
            this.label1TJEDNIFONDSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textTJEDNIFONDSATI.Location = point;
            this.textTJEDNIFONDSATI.Name = "textTJEDNIFONDSATI";
            this.textTJEDNIFONDSATI.Tag = "TJEDNIFONDSATI";
            this.textTJEDNIFONDSATI.TabIndex = 0;
            this.textTJEDNIFONDSATI.Anchor = AnchorStyles.Left;
            this.textTJEDNIFONDSATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textTJEDNIFONDSATI.ReadOnly = false;
            this.textTJEDNIFONDSATI.PromptChar = ' ';
            this.textTJEDNIFONDSATI.Enter += new EventHandler(this.numericEditor_Enter);
            this.textTJEDNIFONDSATI.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "TJEDNIFONDSATI"));
            this.textTJEDNIFONDSATI.NumericType = NumericType.Double;
            this.textTJEDNIFONDSATI.MaxValue = 79228162514264337593543950335M;
            this.textTJEDNIFONDSATI.MinValue = -79228162514264337593543950335M;
            this.textTJEDNIFONDSATI.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerTabPage5.Controls.Add(this.textTJEDNIFONDSATI, 1, 3);
            this.layoutManagerTabPage5.SetColumnSpan(this.textTJEDNIFONDSATI, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.textTJEDNIFONDSATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textTJEDNIFONDSATI.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textTJEDNIFONDSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textTJEDNIFONDSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1TJEDNIFONDSATISTAZ.Location = point;
            this.label1TJEDNIFONDSATISTAZ.Name = "label1TJEDNIFONDSATISTAZ";
            this.label1TJEDNIFONDSATISTAZ.TabIndex = 1;
            this.label1TJEDNIFONDSATISTAZ.Tag = "labelTJEDNIFONDSATISTAZ";
            this.label1TJEDNIFONDSATISTAZ.Text = "Tjedni fond sati (za izračun staža):";
            this.label1TJEDNIFONDSATISTAZ.StyleSetName = "FieldUltraLabel";
            this.label1TJEDNIFONDSATISTAZ.AutoSize = true;
            this.label1TJEDNIFONDSATISTAZ.Anchor = AnchorStyles.Left;
            this.label1TJEDNIFONDSATISTAZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1TJEDNIFONDSATISTAZ.Appearance.ForeColor = Color.Black;
            this.label1TJEDNIFONDSATISTAZ.BackColor = Color.Transparent;
            this.layoutManagerTabPage5.Controls.Add(this.label1TJEDNIFONDSATISTAZ, 0, 4);
            this.layoutManagerTabPage5.SetColumnSpan(this.label1TJEDNIFONDSATISTAZ, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.label1TJEDNIFONDSATISTAZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1TJEDNIFONDSATISTAZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1TJEDNIFONDSATISTAZ.MinimumSize = size;
            size = new System.Drawing.Size(230, 0x17);
            this.label1TJEDNIFONDSATISTAZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textTJEDNIFONDSATISTAZ.Location = point;
            this.textTJEDNIFONDSATISTAZ.Name = "textTJEDNIFONDSATISTAZ";
            this.textTJEDNIFONDSATISTAZ.Tag = "TJEDNIFONDSATISTAZ";
            this.textTJEDNIFONDSATISTAZ.TabIndex = 0;
            this.textTJEDNIFONDSATISTAZ.Anchor = AnchorStyles.Left;
            this.textTJEDNIFONDSATISTAZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textTJEDNIFONDSATISTAZ.ReadOnly = false;
            this.textTJEDNIFONDSATISTAZ.PromptChar = ' ';
            this.textTJEDNIFONDSATISTAZ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textTJEDNIFONDSATISTAZ.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "TJEDNIFONDSATISTAZ"));
            this.textTJEDNIFONDSATISTAZ.NumericType = NumericType.Double;
            this.textTJEDNIFONDSATISTAZ.MaxValue = 79228162514264337593543950335M;
            this.textTJEDNIFONDSATISTAZ.MinValue = -79228162514264337593543950335M;
            this.textTJEDNIFONDSATISTAZ.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerTabPage5.Controls.Add(this.textTJEDNIFONDSATISTAZ, 1, 4);
            this.layoutManagerTabPage5.SetColumnSpan(this.textTJEDNIFONDSATISTAZ, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.textTJEDNIFONDSATISTAZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textTJEDNIFONDSATISTAZ.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textTJEDNIFONDSATISTAZ.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textTJEDNIFONDSATISTAZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Location = point;
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Name = "label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI";
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.TabIndex = 1;
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Tag = "labelDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI";
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Text = "Datum zadnjeg zaposlenja ili promjene fonda sati:";
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.StyleSetName = "FieldUltraLabel";
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.AutoSize = true;
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Anchor = AnchorStyles.Left;
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Appearance.ForeColor = Color.Black;
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.BackColor = Color.Transparent;
            this.layoutManagerTabPage5.Controls.Add(this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, 0, 5);
            this.layoutManagerTabPage5.SetColumnSpan(this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.MinimumSize = size;
            size = new System.Drawing.Size(0x147, 0x17);
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Location = point;
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Name = "datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI";
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Tag = "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI";
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.TabIndex = 0;
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Anchor = AnchorStyles.Left;
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Enabled = true;
            this.layoutManagerTabPage5.Controls.Add(this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, 1, 5);
            this.layoutManagerTabPage5.SetColumnSpan(this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDBENEFICIRANI.Location = point;
            this.label1IDBENEFICIRANI.Name = "label1IDBENEFICIRANI";
            this.label1IDBENEFICIRANI.TabIndex = 1;
            this.label1IDBENEFICIRANI.Tag = "labelIDBENEFICIRANI";
            this.label1IDBENEFICIRANI.Text = "Šifra beneficiranog radnog staža:";
            this.label1IDBENEFICIRANI.StyleSetName = "FieldUltraLabel";
            this.label1IDBENEFICIRANI.AutoSize = true;
            this.label1IDBENEFICIRANI.Anchor = AnchorStyles.Left;
            this.label1IDBENEFICIRANI.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDBENEFICIRANI.Appearance.ForeColor = Color.Black;
            this.label1IDBENEFICIRANI.BackColor = Color.Transparent;
            this.layoutManagerTabPage5.Controls.Add(this.label1IDBENEFICIRANI, 0, 6);
            this.layoutManagerTabPage5.SetColumnSpan(this.label1IDBENEFICIRANI, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.label1IDBENEFICIRANI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDBENEFICIRANI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDBENEFICIRANI.MinimumSize = size;
            size = new System.Drawing.Size(0xdd, 0x17);
            this.label1IDBENEFICIRANI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDBENEFICIRANI.Location = point;
            this.comboIDBENEFICIRANI.Name = "comboIDBENEFICIRANI";
            this.comboIDBENEFICIRANI.Tag = "IDBENEFICIRANI";
            this.comboIDBENEFICIRANI.TabIndex = 0;
            this.comboIDBENEFICIRANI.Anchor = AnchorStyles.Left;
            this.comboIDBENEFICIRANI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDBENEFICIRANI.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDBENEFICIRANI.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDBENEFICIRANI.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDBENEFICIRANI.Enabled = true;
            this.comboIDBENEFICIRANI.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDBENEFICIRANI"));
            //comboIDBENEFICIRANI.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDBENEFICIRANI.ShowPictureBox = true;
            this.comboIDBENEFICIRANI.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDBENEFICIRANI);
            this.comboIDBENEFICIRANI.ValueMember = "IDBENEFICIRANI";
            this.comboIDBENEFICIRANI.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDBENEFICIRANI);
            this.layoutManagerTabPage5.Controls.Add(this.comboIDBENEFICIRANI, 1, 6);
            this.layoutManagerTabPage5.SetColumnSpan(this.comboIDBENEFICIRANI, 1);
            this.layoutManagerTabPage5.SetRowSpan(this.comboIDBENEFICIRANI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDBENEFICIRANI.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDBENEFICIRANI.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDBENEFICIRANI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.Group5.Location = point;
            this.Group5.Name = "Group5";
            this.Group5.Text = "...";
            this.Group5.Dock = DockStyle.Fill;
            this.Group5.AutoSize = true;
            this.Group5.BackColor = Color.Transparent;
            this.Group5.Controls.Add(this.layoutManagerGroup5);
            this.layoutManagerTabPage5.Controls.Add(this.Group5, 0, 7);
            this.layoutManagerTabPage5.SetColumnSpan(this.Group5, 2);
            this.layoutManagerTabPage5.SetRowSpan(this.Group5, 1);
            padding = new Padding(2, 2, 2, 2);
            this.Group5.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Group5.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GODINESTAZA.Location = point;
            this.label1GODINESTAZA.Name = "label1GODINESTAZA";
            this.label1GODINESTAZA.TabIndex = 1;
            this.label1GODINESTAZA.Tag = "labelGODINESTAZA";
            this.label1GODINESTAZA.Text = "Godine staža (do datuma):";
            this.label1GODINESTAZA.StyleSetName = "FieldUltraLabel";
            this.label1GODINESTAZA.AutoSize = true;
            this.label1GODINESTAZA.Anchor = AnchorStyles.Left;
            this.label1GODINESTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINESTAZA.Appearance.ForeColor = Color.Black;
            this.label1GODINESTAZA.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1GODINESTAZA, 0, 0);
            this.layoutManagerGroup5.SetColumnSpan(this.label1GODINESTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1GODINESTAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GODINESTAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINESTAZA.MinimumSize = size;
            size = new System.Drawing.Size(180, 0x17);
            this.label1GODINESTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINESTAZA.Location = point;
            this.textGODINESTAZA.Name = "textGODINESTAZA";
            this.textGODINESTAZA.Tag = "GODINESTAZA";
            this.textGODINESTAZA.TabIndex = 0;
            this.textGODINESTAZA.Anchor = AnchorStyles.Left;
            this.textGODINESTAZA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textGODINESTAZA.ReadOnly = false;
            this.textGODINESTAZA.PromptChar = ' ';
            this.textGODINESTAZA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textGODINESTAZA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "GODINESTAZA"));
            this.textGODINESTAZA.NumericType = NumericType.Integer;
            this.textGODINESTAZA.MaskInput = "{LOC}-nn";
            this.layoutManagerGroup5.Controls.Add(this.textGODINESTAZA, 1, 0);
            this.layoutManagerGroup5.SetColumnSpan(this.textGODINESTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.textGODINESTAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINESTAZA.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textGODINESTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textGODINESTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GODINESTAZAPRO.Location = point;
            this.label1GODINESTAZAPRO.Name = "label1GODINESTAZAPRO";
            this.label1GODINESTAZAPRO.TabIndex = 1;
            this.label1GODINESTAZAPRO.Tag = "labelGODINESTAZAPRO";
            this.label1GODINESTAZAPRO.Text = "Godine staža (do datuma)  - jubilarne:";
            this.label1GODINESTAZAPRO.StyleSetName = "FieldUltraLabel";
            this.label1GODINESTAZAPRO.AutoSize = true;
            this.label1GODINESTAZAPRO.Anchor = AnchorStyles.Left;
            this.label1GODINESTAZAPRO.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINESTAZAPRO.Appearance.ForeColor = Color.Black;
            this.label1GODINESTAZAPRO.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1GODINESTAZAPRO, 0, 1);
            this.layoutManagerGroup5.SetColumnSpan(this.label1GODINESTAZAPRO, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1GODINESTAZAPRO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GODINESTAZAPRO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINESTAZAPRO.MinimumSize = size;
            size = new System.Drawing.Size(0xfc, 0x17);
            this.label1GODINESTAZAPRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINESTAZAPRO.Location = point;
            this.textGODINESTAZAPRO.Name = "textGODINESTAZAPRO";
            this.textGODINESTAZAPRO.Tag = "GODINESTAZAPRO";
            this.textGODINESTAZAPRO.TabIndex = 0;
            this.textGODINESTAZAPRO.Anchor = AnchorStyles.Left;
            this.textGODINESTAZAPRO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textGODINESTAZAPRO.ReadOnly = false;
            this.textGODINESTAZAPRO.PromptChar = ' ';
            this.textGODINESTAZAPRO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textGODINESTAZAPRO.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "GODINESTAZAPRO"));
            this.textGODINESTAZAPRO.NumericType = NumericType.Integer;
            this.textGODINESTAZAPRO.MaskInput = "{LOC}-nn";
            this.layoutManagerGroup5.Controls.Add(this.textGODINESTAZAPRO, 1, 1);
            this.layoutManagerGroup5.SetColumnSpan(this.textGODINESTAZAPRO, 1);
            this.layoutManagerGroup5.SetRowSpan(this.textGODINESTAZAPRO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINESTAZAPRO.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textGODINESTAZAPRO.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textGODINESTAZAPRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UKUPNOGODINESTAZA.Location = point;
            this.label1UKUPNOGODINESTAZA.Name = "label1UKUPNOGODINESTAZA";
            this.label1UKUPNOGODINESTAZA.TabIndex = 1;
            this.label1UKUPNOGODINESTAZA.Tag = "labelUKUPNOGODINESTAZA";
            this.label1UKUPNOGODINESTAZA.Text = "Ukupno godina staža:";
            this.label1UKUPNOGODINESTAZA.StyleSetName = "FieldUltraLabel";
            this.label1UKUPNOGODINESTAZA.AutoSize = true;
            this.label1UKUPNOGODINESTAZA.Anchor = AnchorStyles.Left;
            this.label1UKUPNOGODINESTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1UKUPNOGODINESTAZA.Appearance.ForeColor = Color.Black;
            this.label1UKUPNOGODINESTAZA.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1UKUPNOGODINESTAZA, 0, 2);
            this.layoutManagerGroup5.SetColumnSpan(this.label1UKUPNOGODINESTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1UKUPNOGODINESTAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UKUPNOGODINESTAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UKUPNOGODINESTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x95, 0x17);
            this.label1UKUPNOGODINESTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelUKUPNOGODINESTAZA.Location = point;
            this.labelUKUPNOGODINESTAZA.Name = "labelUKUPNOGODINESTAZA";
            this.labelUKUPNOGODINESTAZA.Tag = "UKUPNOGODINESTAZA";
            this.labelUKUPNOGODINESTAZA.TabIndex = 0;
            this.labelUKUPNOGODINESTAZA.Anchor = AnchorStyles.Left;
            this.labelUKUPNOGODINESTAZA.BackColor = Color.Transparent;
            this.labelUKUPNOGODINESTAZA.Appearance.TextHAlign = HAlign.Left;
            this.labelUKUPNOGODINESTAZA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "UKUPNOGODINESTAZA"));
            this.labelUKUPNOGODINESTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerGroup5.Controls.Add(this.labelUKUPNOGODINESTAZA, 1, 2);
            this.layoutManagerGroup5.SetColumnSpan(this.labelUKUPNOGODINESTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.labelUKUPNOGODINESTAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelUKUPNOGODINESTAZA.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelUKUPNOGODINESTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelUKUPNOGODINESTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MJESECISTAZA.Location = point;
            this.label1MJESECISTAZA.Name = "label1MJESECISTAZA";
            this.label1MJESECISTAZA.TabIndex = 1;
            this.label1MJESECISTAZA.Tag = "labelMJESECISTAZA";
            this.label1MJESECISTAZA.Text = "Mjeseci staža (do datuma):";
            this.label1MJESECISTAZA.StyleSetName = "FieldUltraLabel";
            this.label1MJESECISTAZA.AutoSize = true;
            this.label1MJESECISTAZA.Anchor = AnchorStyles.Left;
            this.label1MJESECISTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECISTAZA.Appearance.ForeColor = Color.Black;
            this.label1MJESECISTAZA.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1MJESECISTAZA, 2, 0);
            this.layoutManagerGroup5.SetColumnSpan(this.label1MJESECISTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1MJESECISTAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESECISTAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESECISTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1MJESECISTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESECISTAZA.Location = point;
            this.textMJESECISTAZA.Name = "textMJESECISTAZA";
            this.textMJESECISTAZA.Tag = "MJESECISTAZA";
            this.textMJESECISTAZA.TabIndex = 0;
            this.textMJESECISTAZA.Anchor = AnchorStyles.Left;
            this.textMJESECISTAZA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMJESECISTAZA.ReadOnly = false;
            this.textMJESECISTAZA.PromptChar = ' ';
            this.textMJESECISTAZA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMJESECISTAZA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "MJESECISTAZA"));
            this.textMJESECISTAZA.NumericType = NumericType.Integer;
            this.textMJESECISTAZA.MaskInput = "{LOC}-nn";
            this.layoutManagerGroup5.Controls.Add(this.textMJESECISTAZA, 3, 0);
            this.layoutManagerGroup5.SetColumnSpan(this.textMJESECISTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.textMJESECISTAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECISTAZA.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textMJESECISTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textMJESECISTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MJESECISTAZAPRO.Location = point;
            this.label1MJESECISTAZAPRO.Name = "label1MJESECISTAZAPRO";
            this.label1MJESECISTAZAPRO.TabIndex = 1;
            this.label1MJESECISTAZAPRO.Tag = "labelMJESECISTAZAPRO";
            this.label1MJESECISTAZAPRO.Text = "Mjeseci staža (do datuma) - jubilarne:";
            this.label1MJESECISTAZAPRO.StyleSetName = "FieldUltraLabel";
            this.label1MJESECISTAZAPRO.AutoSize = true;
            this.label1MJESECISTAZAPRO.Anchor = AnchorStyles.Left;
            this.label1MJESECISTAZAPRO.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECISTAZAPRO.Appearance.ForeColor = Color.Black;
            this.label1MJESECISTAZAPRO.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1MJESECISTAZAPRO, 2, 1);
            this.layoutManagerGroup5.SetColumnSpan(this.label1MJESECISTAZAPRO, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1MJESECISTAZAPRO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESECISTAZAPRO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESECISTAZAPRO.MinimumSize = size;
            size = new System.Drawing.Size(0xfc, 0x17);
            this.label1MJESECISTAZAPRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESECISTAZAPRO.Location = point;
            this.textMJESECISTAZAPRO.Name = "textMJESECISTAZAPRO";
            this.textMJESECISTAZAPRO.Tag = "MJESECISTAZAPRO";
            this.textMJESECISTAZAPRO.TabIndex = 0;
            this.textMJESECISTAZAPRO.Anchor = AnchorStyles.Left;
            this.textMJESECISTAZAPRO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMJESECISTAZAPRO.ReadOnly = false;
            this.textMJESECISTAZAPRO.PromptChar = ' ';
            this.textMJESECISTAZAPRO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMJESECISTAZAPRO.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "MJESECISTAZAPRO"));
            this.textMJESECISTAZAPRO.NumericType = NumericType.Integer;
            this.textMJESECISTAZAPRO.MaskInput = "{LOC}-nn";
            this.layoutManagerGroup5.Controls.Add(this.textMJESECISTAZAPRO, 3, 1);
            this.layoutManagerGroup5.SetColumnSpan(this.textMJESECISTAZAPRO, 1);
            this.layoutManagerGroup5.SetRowSpan(this.textMJESECISTAZAPRO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECISTAZAPRO.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textMJESECISTAZAPRO.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textMJESECISTAZAPRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UKUPNOMJESECISTAZA.Location = point;
            this.label1UKUPNOMJESECISTAZA.Name = "label1UKUPNOMJESECISTAZA";
            this.label1UKUPNOMJESECISTAZA.TabIndex = 1;
            this.label1UKUPNOMJESECISTAZA.Tag = "labelUKUPNOMJESECISTAZA";
            this.label1UKUPNOMJESECISTAZA.Text = "Ukupno mjeseci staža:";
            this.label1UKUPNOMJESECISTAZA.StyleSetName = "FieldUltraLabel";
            this.label1UKUPNOMJESECISTAZA.AutoSize = true;
            this.label1UKUPNOMJESECISTAZA.Anchor = AnchorStyles.Left;
            this.label1UKUPNOMJESECISTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1UKUPNOMJESECISTAZA.Appearance.ForeColor = Color.Black;
            this.label1UKUPNOMJESECISTAZA.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1UKUPNOMJESECISTAZA, 2, 2);
            this.layoutManagerGroup5.SetColumnSpan(this.label1UKUPNOMJESECISTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1UKUPNOMJESECISTAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UKUPNOMJESECISTAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UKUPNOMJESECISTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x9a, 0x17);
            this.label1UKUPNOMJESECISTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelUKUPNOMJESECISTAZA.Location = point;
            this.labelUKUPNOMJESECISTAZA.Name = "labelUKUPNOMJESECISTAZA";
            this.labelUKUPNOMJESECISTAZA.Tag = "UKUPNOMJESECISTAZA";
            this.labelUKUPNOMJESECISTAZA.TabIndex = 0;
            this.labelUKUPNOMJESECISTAZA.Anchor = AnchorStyles.Left;
            this.labelUKUPNOMJESECISTAZA.BackColor = Color.Transparent;
            this.labelUKUPNOMJESECISTAZA.Appearance.TextHAlign = HAlign.Left;
            this.labelUKUPNOMJESECISTAZA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "UKUPNOMJESECISTAZA"));
            this.labelUKUPNOMJESECISTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerGroup5.Controls.Add(this.labelUKUPNOMJESECISTAZA, 3, 2);
            this.layoutManagerGroup5.SetColumnSpan(this.labelUKUPNOMJESECISTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.labelUKUPNOMJESECISTAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelUKUPNOMJESECISTAZA.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelUKUPNOMJESECISTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelUKUPNOMJESECISTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DANISTAZA.Location = point;
            this.label1DANISTAZA.Name = "label1DANISTAZA";
            this.label1DANISTAZA.TabIndex = 1;
            this.label1DANISTAZA.Tag = "labelDANISTAZA";
            this.label1DANISTAZA.Text = "Dani staža (do datuma):";
            this.label1DANISTAZA.StyleSetName = "FieldUltraLabel";
            this.label1DANISTAZA.AutoSize = true;
            this.label1DANISTAZA.Anchor = AnchorStyles.Left;
            this.label1DANISTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DANISTAZA.Appearance.ForeColor = Color.Black;
            this.label1DANISTAZA.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1DANISTAZA, 4, 0);
            this.layoutManagerGroup5.SetColumnSpan(this.label1DANISTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1DANISTAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DANISTAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DANISTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0xa5, 0x17);
            this.label1DANISTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDANISTAZA.Location = point;
            this.textDANISTAZA.Name = "textDANISTAZA";
            this.textDANISTAZA.Tag = "DANISTAZA";
            this.textDANISTAZA.TabIndex = 0;
            this.textDANISTAZA.Anchor = AnchorStyles.Left;
            this.textDANISTAZA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDANISTAZA.ReadOnly = false;
            this.textDANISTAZA.PromptChar = ' ';
            this.textDANISTAZA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDANISTAZA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "DANISTAZA"));
            this.textDANISTAZA.NumericType = NumericType.Integer;
            this.textDANISTAZA.MaskInput = "{LOC}-nnn";
            this.layoutManagerGroup5.Controls.Add(this.textDANISTAZA, 5, 0);
            this.layoutManagerGroup5.SetColumnSpan(this.textDANISTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.textDANISTAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDANISTAZA.Margin = padding;
            size = new System.Drawing.Size(0x26, 0x16);
            this.textDANISTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x26, 0x16);
            this.textDANISTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DANISTAZAPRO.Location = point;
            this.label1DANISTAZAPRO.Name = "label1DANISTAZAPRO";
            this.label1DANISTAZAPRO.TabIndex = 1;
            this.label1DANISTAZAPRO.Tag = "labelDANISTAZAPRO";
            this.label1DANISTAZAPRO.Text = "Dani staža (do datuma) - jubilarne:";
            this.label1DANISTAZAPRO.StyleSetName = "FieldUltraLabel";
            this.label1DANISTAZAPRO.AutoSize = true;
            this.label1DANISTAZAPRO.Anchor = AnchorStyles.Left;
            this.label1DANISTAZAPRO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DANISTAZAPRO.Appearance.ForeColor = Color.Black;
            this.label1DANISTAZAPRO.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1DANISTAZAPRO, 4, 1);
            this.layoutManagerGroup5.SetColumnSpan(this.label1DANISTAZAPRO, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1DANISTAZAPRO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DANISTAZAPRO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DANISTAZAPRO.MinimumSize = size;
            size = new System.Drawing.Size(0xe9, 0x17);
            this.label1DANISTAZAPRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDANISTAZAPRO.Location = point;
            this.textDANISTAZAPRO.Name = "textDANISTAZAPRO";
            this.textDANISTAZAPRO.Tag = "DANISTAZAPRO";
            this.textDANISTAZAPRO.TabIndex = 0;
            this.textDANISTAZAPRO.Anchor = AnchorStyles.Left;
            this.textDANISTAZAPRO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDANISTAZAPRO.ReadOnly = false;
            this.textDANISTAZAPRO.PromptChar = ' ';
            this.textDANISTAZAPRO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDANISTAZAPRO.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "DANISTAZAPRO"));
            this.textDANISTAZAPRO.NumericType = NumericType.Integer;
            this.textDANISTAZAPRO.MaskInput = "{LOC}-nnn";
            this.layoutManagerGroup5.Controls.Add(this.textDANISTAZAPRO, 5, 1);
            this.layoutManagerGroup5.SetColumnSpan(this.textDANISTAZAPRO, 1);
            this.layoutManagerGroup5.SetRowSpan(this.textDANISTAZAPRO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDANISTAZAPRO.Margin = padding;
            size = new System.Drawing.Size(0x26, 0x16);
            this.textDANISTAZAPRO.MinimumSize = size;
            size = new System.Drawing.Size(0x26, 0x16);
            this.textDANISTAZAPRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UKUPNODANASTAZA.Location = point;
            this.label1UKUPNODANASTAZA.Name = "label1UKUPNODANASTAZA";
            this.label1UKUPNODANASTAZA.TabIndex = 1;
            this.label1UKUPNODANASTAZA.Tag = "labelUKUPNODANASTAZA";
            this.label1UKUPNODANASTAZA.Text = "Ukupno dana staža:";
            this.label1UKUPNODANASTAZA.StyleSetName = "FieldUltraLabel";
            this.label1UKUPNODANASTAZA.AutoSize = true;
            this.label1UKUPNODANASTAZA.Anchor = AnchorStyles.Left;
            this.label1UKUPNODANASTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1UKUPNODANASTAZA.Appearance.ForeColor = Color.Black;
            this.label1UKUPNODANASTAZA.BackColor = Color.Transparent;
            this.layoutManagerGroup5.Controls.Add(this.label1UKUPNODANASTAZA, 4, 2);
            this.layoutManagerGroup5.SetColumnSpan(this.label1UKUPNODANASTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.label1UKUPNODANASTAZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UKUPNODANASTAZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UKUPNODANASTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x89, 0x17);
            this.label1UKUPNODANASTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelUKUPNODANASTAZA.Location = point;
            this.labelUKUPNODANASTAZA.Name = "labelUKUPNODANASTAZA";
            this.labelUKUPNODANASTAZA.Tag = "UKUPNODANASTAZA";
            this.labelUKUPNODANASTAZA.TabIndex = 0;
            this.labelUKUPNODANASTAZA.Anchor = AnchorStyles.Left;
            this.labelUKUPNODANASTAZA.BackColor = Color.Transparent;
            this.labelUKUPNODANASTAZA.Appearance.TextHAlign = HAlign.Left;
            this.labelUKUPNODANASTAZA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "UKUPNODANASTAZA"));
            this.labelUKUPNODANASTAZA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerGroup5.Controls.Add(this.labelUKUPNODANASTAZA, 5, 2);
            this.layoutManagerGroup5.SetColumnSpan(this.labelUKUPNODANASTAZA, 1);
            this.layoutManagerGroup5.SetRowSpan(this.labelUKUPNODANASTAZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelUKUPNODANASTAZA.Margin = padding;
            size = new System.Drawing.Size(0x26, 0x16);
            this.labelUKUPNODANASTAZA.MinimumSize = size;
            size = new System.Drawing.Size(0x26, 0x16);
            this.labelUKUPNODANASTAZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.TabPage6.Location = point;
            this.TabPage6.Name = "TabPage6";
            tab11.TabPage = this.TabPage6;
            tab11.Text = "Kadrovski podaci";
            this.TabPage6.Controls.Add(this.layoutManagerTabPage6);
            point = new System.Drawing.Point(0, 0);
            this.label1BROJMIROVINSKOG.Location = point;
            this.label1BROJMIROVINSKOG.Name = "label1BROJMIROVINSKOG";
            this.label1BROJMIROVINSKOG.TabIndex = 1;
            this.label1BROJMIROVINSKOG.Tag = "labelBROJMIROVINSKOG";
            this.label1BROJMIROVINSKOG.Text = "Broj mirovinskog osiguranja:";
            this.label1BROJMIROVINSKOG.StyleSetName = "FieldUltraLabel";
            this.label1BROJMIROVINSKOG.AutoSize = true;
            this.label1BROJMIROVINSKOG.Anchor = AnchorStyles.Left;
            this.label1BROJMIROVINSKOG.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJMIROVINSKOG.Appearance.ForeColor = Color.Black;
            this.label1BROJMIROVINSKOG.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1BROJMIROVINSKOG, 0, 0);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1BROJMIROVINSKOG, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1BROJMIROVINSKOG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJMIROVINSKOG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJMIROVINSKOG.MinimumSize = size;
            size = new System.Drawing.Size(0xc3, 0x17);
            this.label1BROJMIROVINSKOG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJMIROVINSKOG.Location = point;
            this.textBROJMIROVINSKOG.Name = "textBROJMIROVINSKOG";
            this.textBROJMIROVINSKOG.Tag = "BROJMIROVINSKOG";
            this.textBROJMIROVINSKOG.TabIndex = 0;
            this.textBROJMIROVINSKOG.Anchor = AnchorStyles.Left;
            this.textBROJMIROVINSKOG.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJMIROVINSKOG.ContextMenu = this.contextMenu1;
            this.textBROJMIROVINSKOG.ReadOnly = false;
            this.textBROJMIROVINSKOG.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "BROJMIROVINSKOG"));
            this.textBROJMIROVINSKOG.Nullable = true;
            this.textBROJMIROVINSKOG.MaxLength = 50;
            this.layoutManagerTabPage6.Controls.Add(this.textBROJMIROVINSKOG, 1, 0);
            this.layoutManagerTabPage6.SetColumnSpan(this.textBROJMIROVINSKOG, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.textBROJMIROVINSKOG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJMIROVINSKOG.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textBROJMIROVINSKOG.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textBROJMIROVINSKOG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BROJZDRAVSTVENOG.Location = point;
            this.label1BROJZDRAVSTVENOG.Name = "label1BROJZDRAVSTVENOG";
            this.label1BROJZDRAVSTVENOG.TabIndex = 1;
            this.label1BROJZDRAVSTVENOG.Tag = "labelBROJZDRAVSTVENOG";
            this.label1BROJZDRAVSTVENOG.Text = "Broj zdravstvenog osiguranja:";
            this.label1BROJZDRAVSTVENOG.StyleSetName = "FieldUltraLabel";
            this.label1BROJZDRAVSTVENOG.AutoSize = true;
            this.label1BROJZDRAVSTVENOG.Anchor = AnchorStyles.Left;
            this.label1BROJZDRAVSTVENOG.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJZDRAVSTVENOG.Appearance.ForeColor = Color.Black;
            this.label1BROJZDRAVSTVENOG.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1BROJZDRAVSTVENOG, 0, 1);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1BROJZDRAVSTVENOG, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1BROJZDRAVSTVENOG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJZDRAVSTVENOG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJZDRAVSTVENOG.MinimumSize = size;
            size = new System.Drawing.Size(0xca, 0x17);
            this.label1BROJZDRAVSTVENOG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJZDRAVSTVENOG.Location = point;
            this.textBROJZDRAVSTVENOG.Name = "textBROJZDRAVSTVENOG";
            this.textBROJZDRAVSTVENOG.Tag = "BROJZDRAVSTVENOG";
            this.textBROJZDRAVSTVENOG.TabIndex = 0;
            this.textBROJZDRAVSTVENOG.Anchor = AnchorStyles.Left;
            this.textBROJZDRAVSTVENOG.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJZDRAVSTVENOG.ContextMenu = this.contextMenu1;
            this.textBROJZDRAVSTVENOG.ReadOnly = false;
            this.textBROJZDRAVSTVENOG.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "BROJZDRAVSTVENOG"));
            this.textBROJZDRAVSTVENOG.Nullable = true;
            this.textBROJZDRAVSTVENOG.MaxLength = 50;
            this.layoutManagerTabPage6.Controls.Add(this.textBROJZDRAVSTVENOG, 1, 1);
            this.layoutManagerTabPage6.SetColumnSpan(this.textBROJZDRAVSTVENOG, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.textBROJZDRAVSTVENOG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJZDRAVSTVENOG.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textBROJZDRAVSTVENOG.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textBROJZDRAVSTVENOG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MBO.Location = point;
            this.label1MBO.Name = "label1MBO";
            this.label1MBO.TabIndex = 1;
            this.label1MBO.Tag = "labelMBO";
            this.label1MBO.Text = "Matični broj osiguranika:";
            this.label1MBO.StyleSetName = "FieldUltraLabel";
            this.label1MBO.AutoSize = true;
            this.label1MBO.Anchor = AnchorStyles.Left;
            this.label1MBO.Appearance.TextVAlign = VAlign.Middle;
            this.label1MBO.Appearance.ForeColor = Color.Black;
            this.label1MBO.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1MBO, 0, 2);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1MBO, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1MBO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MBO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MBO.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x17);
            this.label1MBO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMBO.Location = point;
            this.textMBO.Name = "textMBO";
            this.textMBO.Tag = "MBO";
            this.textMBO.TabIndex = 0;
            this.textMBO.Anchor = AnchorStyles.Left;
            this.textMBO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMBO.ContextMenu = this.contextMenu1;
            this.textMBO.ReadOnly = false;
            this.textMBO.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "MBO"));
            this.textMBO.Nullable = true;
            this.textMBO.MaxLength = 50;
            this.layoutManagerTabPage6.Controls.Add(this.textMBO, 1, 2);
            this.layoutManagerTabPage6.SetColumnSpan(this.textMBO, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.textMBO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMBO.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textMBO.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textMBO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDTITULA.Location = point;
            this.label1IDTITULA.Name = "label1IDTITULA";
            this.label1IDTITULA.TabIndex = 1;
            this.label1IDTITULA.Tag = "labelIDTITULA";
            this.label1IDTITULA.Text = "Šifra titule:";
            this.label1IDTITULA.StyleSetName = "FieldUltraLabel";
            this.label1IDTITULA.AutoSize = true;
            this.label1IDTITULA.Anchor = AnchorStyles.Left;
            this.label1IDTITULA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTITULA.Appearance.ForeColor = Color.Black;
            this.label1IDTITULA.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1IDTITULA, 0, 3);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1IDTITULA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1IDTITULA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDTITULA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTITULA.MinimumSize = size;
            size = new System.Drawing.Size(0x55, 0x17);
            this.label1IDTITULA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDTITULA.Location = point;
            this.comboIDTITULA.Name = "comboIDTITULA";
            this.comboIDTITULA.Tag = "IDTITULA";
            this.comboIDTITULA.TabIndex = 0;
            this.comboIDTITULA.Anchor = AnchorStyles.Left;
            this.comboIDTITULA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDTITULA.ContextMenu = this.contextMenu1;
            this.comboIDTITULA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDTITULA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDTITULA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDTITULA.Enabled = true;
            this.comboIDTITULA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDTITULA"));
            //comboIDTITULA.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDTITULA.ShowPictureBox = true;
            this.comboIDTITULA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDTITULA);
            this.comboIDTITULA.ValueMember = "IDTITULA";
            this.comboIDTITULA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDTITULA);
            this.layoutManagerTabPage6.Controls.Add(this.comboIDTITULA, 1, 3);
            this.layoutManagerTabPage6.SetColumnSpan(this.comboIDTITULA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.comboIDTITULA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDTITULA.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDTITULA.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDTITULA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNOMJESTO.Location = point;
            this.label1IDRADNOMJESTO.Name = "label1IDRADNOMJESTO";
            this.label1IDRADNOMJESTO.TabIndex = 1;
            this.label1IDRADNOMJESTO.Tag = "labelIDRADNOMJESTO";
            this.label1IDRADNOMJESTO.Text = "Šifra radnog mjesta:";
            this.label1IDRADNOMJESTO.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNOMJESTO.AutoSize = true;
            this.label1IDRADNOMJESTO.Anchor = AnchorStyles.Left;
            this.label1IDRADNOMJESTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNOMJESTO.Appearance.ForeColor = Color.Black;
            this.label1IDRADNOMJESTO.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1IDRADNOMJESTO, 0, 4);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1IDRADNOMJESTO, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1IDRADNOMJESTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNOMJESTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNOMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
            this.label1IDRADNOMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDRADNOMJESTO.Location = point;
            this.comboIDRADNOMJESTO.Name = "comboIDRADNOMJESTO";
            this.comboIDRADNOMJESTO.Tag = "IDRADNOMJESTO";
            this.comboIDRADNOMJESTO.TabIndex = 0;
            this.comboIDRADNOMJESTO.Anchor = AnchorStyles.Left;
            this.comboIDRADNOMJESTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDRADNOMJESTO.ContextMenu = this.contextMenu1;
            this.comboIDRADNOMJESTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNOMJESTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDRADNOMJESTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDRADNOMJESTO.Enabled = true;
            this.comboIDRADNOMJESTO.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDRADNOMJESTO"));
            //comboIDRADNOMJESTO.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDRADNOMJESTO.ShowPictureBox = true;
            this.comboIDRADNOMJESTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDRADNOMJESTO);
            this.comboIDRADNOMJESTO.ValueMember = "IDRADNOMJESTO";
            this.comboIDRADNOMJESTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDRADNOMJESTO);
            this.layoutManagerTabPage6.Controls.Add(this.comboIDRADNOMJESTO, 1, 4);
            this.layoutManagerTabPage6.SetColumnSpan(this.comboIDRADNOMJESTO, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.comboIDRADNOMJESTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDRADNOMJESTO.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDRADNOMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDRADNOMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Location = point;
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Name = "label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.TabIndex = 1;
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Tag = "labelTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Text = "Šifra stručne spreme:";
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.StyleSetName = "FieldUltraLabel";
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.AutoSize = true;
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Appearance.TextVAlign = VAlign.Middle;
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Appearance.ForeColor = Color.Black;
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, 0, 5);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x94, 0x17);
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Location = point;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Name = "comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Tag = "TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.TabIndex = 0;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ContextMenu = this.contextMenu1;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.DropDownStyle = DropDownStyle.DropDown;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Enabled = true;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"));
            //comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ShowPictureBox = true;
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ValueMember = "IDSTRUCNASPREMA";
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.SelectionChanged += new EventHandler(this.SelectedIndexChangedTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.layoutManagerTabPage6.Controls.Add(this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, 1, 5);
            this.layoutManagerTabPage6.SetColumnSpan(this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Location = point;
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Name = "label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.TabIndex = 1;
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Tag = "labelPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Text = "Šifra potrebne stručne spreme:";
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.StyleSetName = "FieldUltraLabel";
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.AutoSize = true;
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Appearance.ForeColor = Color.Black;
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, 0, 6);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0xd0, 0x17);
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Location = point;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Name = "comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Tag = "POTREBNASTRUCNASPREMAIDSTRUCNASPREMA";
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.TabIndex = 0;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ContextMenu = this.contextMenu1;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.DropDownStyle = DropDownStyle.DropDown;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Enabled = true;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"));
            //comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ShowPictureBox = true;
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ValueMember = "IDSTRUCNASPREMA";
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.SelectionChanged += new EventHandler(this.SelectedIndexChangedPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
            this.layoutManagerTabPage6.Controls.Add(this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA, 1, 6);
            this.layoutManagerTabPage6.SetColumnSpan(this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDSTRUKA.Location = point;
            this.label1IDSTRUKA.Name = "label1IDSTRUKA";
            this.label1IDSTRUKA.TabIndex = 1;
            this.label1IDSTRUKA.Tag = "labelIDSTRUKA";
            this.label1IDSTRUKA.Text = "Šifra struke:";
            this.label1IDSTRUKA.StyleSetName = "FieldUltraLabel";
            this.label1IDSTRUKA.AutoSize = true;
            this.label1IDSTRUKA.Anchor = AnchorStyles.Left;
            this.label1IDSTRUKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSTRUKA.Appearance.ForeColor = Color.Black;
            this.label1IDSTRUKA.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1IDSTRUKA, 0, 7);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1IDSTRUKA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1IDSTRUKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDSTRUKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSTRUKA.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1IDSTRUKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDSTRUKA.Location = point;
            this.comboIDSTRUKA.Name = "comboIDSTRUKA";
            this.comboIDSTRUKA.Tag = "IDSTRUKA";
            this.comboIDSTRUKA.TabIndex = 0;
            this.comboIDSTRUKA.Anchor = AnchorStyles.Left;
            this.comboIDSTRUKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDSTRUKA.ContextMenu = this.contextMenu1;
            this.comboIDSTRUKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSTRUKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDSTRUKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDSTRUKA.Enabled = true;
            this.comboIDSTRUKA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDSTRUKA"));
            //comboIDSTRUKA.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDSTRUKA.ShowPictureBox = true;
            this.comboIDSTRUKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDSTRUKA);
            this.comboIDSTRUKA.ValueMember = "IDSTRUKA";
            this.comboIDSTRUKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDSTRUKA);
            this.layoutManagerTabPage6.Controls.Add(this.comboIDSTRUKA, 1, 7);
            this.layoutManagerTabPage6.SetColumnSpan(this.comboIDSTRUKA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.comboIDSTRUKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDSTRUKA.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDSTRUKA.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDSTRUKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDBRACNOSTANJE.Location = point;
            this.label1IDBRACNOSTANJE.Name = "label1IDBRACNOSTANJE";
            this.label1IDBRACNOSTANJE.TabIndex = 1;
            this.label1IDBRACNOSTANJE.Tag = "labelIDBRACNOSTANJE";
            this.label1IDBRACNOSTANJE.Text = "Šifra bračnog stanja:";
            this.label1IDBRACNOSTANJE.StyleSetName = "FieldUltraLabel";
            this.label1IDBRACNOSTANJE.AutoSize = true;
            this.label1IDBRACNOSTANJE.Anchor = AnchorStyles.Left;
            this.label1IDBRACNOSTANJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDBRACNOSTANJE.Appearance.ForeColor = Color.Black;
            this.label1IDBRACNOSTANJE.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1IDBRACNOSTANJE, 0, 8);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1IDBRACNOSTANJE, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1IDBRACNOSTANJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDBRACNOSTANJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDBRACNOSTANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 0x17);
            this.label1IDBRACNOSTANJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDBRACNOSTANJE.Location = point;
            this.comboIDBRACNOSTANJE.Name = "comboIDBRACNOSTANJE";
            this.comboIDBRACNOSTANJE.Tag = "IDBRACNOSTANJE";
            this.comboIDBRACNOSTANJE.TabIndex = 0;
            this.comboIDBRACNOSTANJE.Anchor = AnchorStyles.Left;
            this.comboIDBRACNOSTANJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDBRACNOSTANJE.ContextMenu = this.contextMenu1;
            this.comboIDBRACNOSTANJE.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDBRACNOSTANJE.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDBRACNOSTANJE.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDBRACNOSTANJE.Enabled = true;
            this.comboIDBRACNOSTANJE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDBRACNOSTANJE"));
            //comboIDBRACNOSTANJE.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDBRACNOSTANJE.ShowPictureBox = true;
            this.comboIDBRACNOSTANJE.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDBRACNOSTANJE);
            this.comboIDBRACNOSTANJE.ValueMember = "IDBRACNOSTANJE";
            this.comboIDBRACNOSTANJE.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDBRACNOSTANJE);
            this.layoutManagerTabPage6.Controls.Add(this.comboIDBRACNOSTANJE, 1, 8);
            this.layoutManagerTabPage6.SetColumnSpan(this.comboIDBRACNOSTANJE, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.comboIDBRACNOSTANJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDBRACNOSTANJE.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDBRACNOSTANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDBRACNOSTANJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDORGDIO.Location = point;
            this.label1IDORGDIO.Name = "label1IDORGDIO";
            this.label1IDORGDIO.TabIndex = 1;
            this.label1IDORGDIO.Tag = "labelIDORGDIO";
            this.label1IDORGDIO.Text = "Šifra organizacijske jedinice:";
            this.label1IDORGDIO.StyleSetName = "FieldUltraLabel";
            this.label1IDORGDIO.AutoSize = true;
            this.label1IDORGDIO.Anchor = AnchorStyles.Left;
            this.label1IDORGDIO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDORGDIO.Appearance.ForeColor = Color.Black;
            this.label1IDORGDIO.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1IDORGDIO, 0, 9);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1IDORGDIO, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1IDORGDIO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDORGDIO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDORGDIO.MinimumSize = size;
            size = new System.Drawing.Size(0xc2, 0x17);
            this.label1IDORGDIO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDORGDIO.Location = point;
            this.comboIDORGDIO.Name = "comboIDORGDIO";
            this.comboIDORGDIO.Tag = "IDORGDIO";
            this.comboIDORGDIO.TabIndex = 0;
            this.comboIDORGDIO.Anchor = AnchorStyles.Left;
            this.comboIDORGDIO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDORGDIO.ContextMenu = this.contextMenu1;
            this.comboIDORGDIO.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDORGDIO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDORGDIO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDORGDIO.Enabled = true;
            this.comboIDORGDIO.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDORGDIO"));
            //comboIDORGDIO.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDORGDIO.ShowPictureBox = true;
            this.comboIDORGDIO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDORGDIO);
            this.comboIDORGDIO.ValueMember = "IDORGDIO";
            this.comboIDORGDIO.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDORGDIO);
            this.layoutManagerTabPage6.Controls.Add(this.comboIDORGDIO, 1, 9);
            this.layoutManagerTabPage6.SetColumnSpan(this.comboIDORGDIO, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.comboIDORGDIO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDORGDIO.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDORGDIO.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDORGDIO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMPRESTANKARADNOGODNOSA.Location = point;
            this.label1DATUMPRESTANKARADNOGODNOSA.Name = "label1DATUMPRESTANKARADNOGODNOSA";
            this.label1DATUMPRESTANKARADNOGODNOSA.TabIndex = 1;
            this.label1DATUMPRESTANKARADNOGODNOSA.Tag = "labelDATUMPRESTANKARADNOGODNOSA";
            this.label1DATUMPRESTANKARADNOGODNOSA.Text = "Datum prestanka radnog odnosa:";
            this.label1DATUMPRESTANKARADNOGODNOSA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMPRESTANKARADNOGODNOSA.AutoSize = true;
            this.label1DATUMPRESTANKARADNOGODNOSA.Anchor = AnchorStyles.Left;
            this.label1DATUMPRESTANKARADNOGODNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMPRESTANKARADNOGODNOSA.Appearance.ForeColor = Color.Black;
            this.label1DATUMPRESTANKARADNOGODNOSA.BackColor = Color.Transparent;
            this.layoutManagerTabPage6.Controls.Add(this.label1DATUMPRESTANKARADNOGODNOSA, 0, 10);
            this.layoutManagerTabPage6.SetColumnSpan(this.label1DATUMPRESTANKARADNOGODNOSA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.label1DATUMPRESTANKARADNOGODNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMPRESTANKARADNOGODNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMPRESTANKARADNOGODNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0xde, 0x17);
            this.label1DATUMPRESTANKARADNOGODNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMPRESTANKARADNOGODNOSA.Location = point;
            this.datePickerDATUMPRESTANKARADNOGODNOSA.Name = "datePickerDATUMPRESTANKARADNOGODNOSA";
            this.datePickerDATUMPRESTANKARADNOGODNOSA.Tag = "DATUMPRESTANKARADNOGODNOSA";
            this.datePickerDATUMPRESTANKARADNOGODNOSA.TabIndex = 0;
            this.datePickerDATUMPRESTANKARADNOGODNOSA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMPRESTANKARADNOGODNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMPRESTANKARADNOGODNOSA.ContextMenu = this.contextMenu1;
            this.datePickerDATUMPRESTANKARADNOGODNOSA.Enabled = true;
            this.layoutManagerTabPage6.Controls.Add(this.datePickerDATUMPRESTANKARADNOGODNOSA, 1, 10);
            this.layoutManagerTabPage6.SetColumnSpan(this.datePickerDATUMPRESTANKARADNOGODNOSA, 1);
            this.layoutManagerTabPage6.SetRowSpan(this.datePickerDATUMPRESTANKARADNOGODNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMPRESTANKARADNOGODNOSA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMPRESTANKARADNOGODNOSA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMPRESTANKARADNOGODNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.TabPage8.Location = point;
            this.TabPage8.Name = "TabPage8";
            tab13.TabPage = this.TabPage8;
            tab13.Text = "Kadrovski podaci 2";
            this.TabPage8.Controls.Add(this.layoutManagerTabPage8);
            point = new System.Drawing.Point(0, 0);
            this.label1IDDRZAVLJANSTVO.Location = point;
            this.label1IDDRZAVLJANSTVO.Name = "label1IDDRZAVLJANSTVO";
            this.label1IDDRZAVLJANSTVO.TabIndex = 1;
            this.label1IDDRZAVLJANSTVO.Tag = "labelIDDRZAVLJANSTVO";
            this.label1IDDRZAVLJANSTVO.Text = "Državljanstvo:";
            this.label1IDDRZAVLJANSTVO.StyleSetName = "FieldUltraLabel";
            this.label1IDDRZAVLJANSTVO.AutoSize = true;
            this.label1IDDRZAVLJANSTVO.Anchor = AnchorStyles.Left;
            this.label1IDDRZAVLJANSTVO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDRZAVLJANSTVO.Appearance.ForeColor = Color.Black;
            this.label1IDDRZAVLJANSTVO.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1IDDRZAVLJANSTVO, 0, 0);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1IDDRZAVLJANSTVO, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1IDDRZAVLJANSTVO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDDRZAVLJANSTVO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDRZAVLJANSTVO.MinimumSize = size;
            size = new System.Drawing.Size(0x69, 0x17);
            this.label1IDDRZAVLJANSTVO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDDRZAVLJANSTVO.Location = point;
            this.comboIDDRZAVLJANSTVO.Name = "comboIDDRZAVLJANSTVO";
            this.comboIDDRZAVLJANSTVO.Tag = "IDDRZAVLJANSTVO";
            this.comboIDDRZAVLJANSTVO.TabIndex = 0;
            this.comboIDDRZAVLJANSTVO.Anchor = AnchorStyles.Left;
            this.comboIDDRZAVLJANSTVO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDDRZAVLJANSTVO.ContextMenu = this.contextMenu1;
            this.comboIDDRZAVLJANSTVO.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDDRZAVLJANSTVO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDDRZAVLJANSTVO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDDRZAVLJANSTVO.Enabled = true;
            this.comboIDDRZAVLJANSTVO.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDDRZAVLJANSTVO"));
            //comboIDDRZAVLJANSTVO.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDDRZAVLJANSTVO.ShowPictureBox = true;
            this.comboIDDRZAVLJANSTVO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDDRZAVLJANSTVO);
            this.comboIDDRZAVLJANSTVO.ValueMember = "IDDRZAVLJANSTVO";
            this.comboIDDRZAVLJANSTVO.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDDRZAVLJANSTVO);
            this.layoutManagerTabPage8.Controls.Add(this.comboIDDRZAVLJANSTVO, 1, 0);
            this.layoutManagerTabPage8.SetColumnSpan(this.comboIDDRZAVLJANSTVO, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.comboIDDRZAVLJANSTVO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDDRZAVLJANSTVO.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDDRZAVLJANSTVO.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDDRZAVLJANSTVO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RADNADOZVOLA.Location = point;
            this.label1RADNADOZVOLA.Name = "label1RADNADOZVOLA";
            this.label1RADNADOZVOLA.TabIndex = 1;
            this.label1RADNADOZVOLA.Tag = "labelRADNADOZVOLA";
            this.label1RADNADOZVOLA.Text = "Podaci o radnoj dozboli:";
            this.label1RADNADOZVOLA.StyleSetName = "FieldUltraLabel";
            this.label1RADNADOZVOLA.AutoSize = true;
            this.label1RADNADOZVOLA.Anchor = AnchorStyles.Left;
            this.label1RADNADOZVOLA.Appearance.TextVAlign = VAlign.Middle;
            this.label1RADNADOZVOLA.Appearance.ForeColor = Color.Black;
            this.label1RADNADOZVOLA.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1RADNADOZVOLA, 0, 1);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1RADNADOZVOLA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1RADNADOZVOLA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RADNADOZVOLA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RADNADOZVOLA.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 0x17);
            this.label1RADNADOZVOLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRADNADOZVOLA.Location = point;
            this.textRADNADOZVOLA.Name = "textRADNADOZVOLA";
            this.textRADNADOZVOLA.Tag = "RADNADOZVOLA";
            this.textRADNADOZVOLA.TabIndex = 0;
            this.textRADNADOZVOLA.Anchor = AnchorStyles.Left;
            this.textRADNADOZVOLA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRADNADOZVOLA.ContextMenu = this.contextMenu1;
            this.textRADNADOZVOLA.ReadOnly = false;
            this.textRADNADOZVOLA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "RADNADOZVOLA"));
            this.textRADNADOZVOLA.Nullable = true;
            this.textRADNADOZVOLA.MaxLength = 50;
            this.layoutManagerTabPage8.Controls.Add(this.textRADNADOZVOLA, 1, 1);
            this.layoutManagerTabPage8.SetColumnSpan(this.textRADNADOZVOLA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.textRADNADOZVOLA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRADNADOZVOLA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRADNADOZVOLA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRADNADOZVOLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZAVRSENASKOLA.Location = point;
            this.label1ZAVRSENASKOLA.Name = "label1ZAVRSENASKOLA";
            this.label1ZAVRSENASKOLA.TabIndex = 1;
            this.label1ZAVRSENASKOLA.Tag = "labelZAVRSENASKOLA";
            this.label1ZAVRSENASKOLA.Text = "Završena škola:";
            this.label1ZAVRSENASKOLA.StyleSetName = "FieldUltraLabel";
            this.label1ZAVRSENASKOLA.AutoSize = true;
            this.label1ZAVRSENASKOLA.Anchor = AnchorStyles.Left;
            this.label1ZAVRSENASKOLA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZAVRSENASKOLA.Appearance.ForeColor = Color.Black;
            this.label1ZAVRSENASKOLA.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1ZAVRSENASKOLA, 0, 2);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1ZAVRSENASKOLA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1ZAVRSENASKOLA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZAVRSENASKOLA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZAVRSENASKOLA.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1ZAVRSENASKOLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZAVRSENASKOLA.Location = point;
            this.textZAVRSENASKOLA.Name = "textZAVRSENASKOLA";
            this.textZAVRSENASKOLA.Tag = "ZAVRSENASKOLA";
            this.textZAVRSENASKOLA.TabIndex = 0;
            this.textZAVRSENASKOLA.Anchor = AnchorStyles.Left;
            this.textZAVRSENASKOLA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZAVRSENASKOLA.ContextMenu = this.contextMenu1;
            this.textZAVRSENASKOLA.ReadOnly = false;
            this.textZAVRSENASKOLA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "ZAVRSENASKOLA"));
            this.textZAVRSENASKOLA.Nullable = true;
            this.textZAVRSENASKOLA.MaxLength = 50;
            this.layoutManagerTabPage8.Controls.Add(this.textZAVRSENASKOLA, 1, 2);
            this.layoutManagerTabPage8.SetColumnSpan(this.textZAVRSENASKOLA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.textZAVRSENASKOLA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZAVRSENASKOLA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textZAVRSENASKOLA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textZAVRSENASKOLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UGOVOROD.Location = point;
            this.label1UGOVOROD.Name = "label1UGOVOROD";
            this.label1UGOVOROD.TabIndex = 1;
            this.label1UGOVOROD.Tag = "labelUGOVOROD";
            this.label1UGOVOROD.Text = "Datum sklapanja ugovora o radu:";
            this.label1UGOVOROD.StyleSetName = "FieldUltraLabel";
            this.label1UGOVOROD.AutoSize = true;
            this.label1UGOVOROD.Anchor = AnchorStyles.Left;
            this.label1UGOVOROD.Appearance.TextVAlign = VAlign.Middle;
            this.label1UGOVOROD.Appearance.ForeColor = Color.Black;
            this.label1UGOVOROD.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1UGOVOROD, 0, 3);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1UGOVOROD, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1UGOVOROD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UGOVOROD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UGOVOROD.MinimumSize = size;
            size = new System.Drawing.Size(0xde, 0x17);
            this.label1UGOVOROD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerUGOVOROD.Location = point;
            this.datePickerUGOVOROD.Name = "datePickerUGOVOROD";
            this.datePickerUGOVOROD.Tag = "UGOVOROD";
            this.datePickerUGOVOROD.TabIndex = 0;
            this.datePickerUGOVOROD.Anchor = AnchorStyles.Left;
            this.datePickerUGOVOROD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerUGOVOROD.ContextMenu = this.contextMenu1;
            this.datePickerUGOVOROD.Enabled = true;
            this.layoutManagerTabPage8.Controls.Add(this.datePickerUGOVOROD, 1, 3);
            this.layoutManagerTabPage8.SetColumnSpan(this.datePickerUGOVOROD, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.datePickerUGOVOROD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerUGOVOROD.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerUGOVOROD.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerUGOVOROD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POCETAKRADA.Location = point;
            this.label1POCETAKRADA.Name = "label1POCETAKRADA";
            this.label1POCETAKRADA.TabIndex = 1;
            this.label1POCETAKRADA.Tag = "labelPOCETAKRADA";
            this.label1POCETAKRADA.Text = "Datum početka rada:";
            this.label1POCETAKRADA.StyleSetName = "FieldUltraLabel";
            this.label1POCETAKRADA.AutoSize = true;
            this.label1POCETAKRADA.Anchor = AnchorStyles.Left;
            this.label1POCETAKRADA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POCETAKRADA.Appearance.ForeColor = Color.Black;
            this.label1POCETAKRADA.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1POCETAKRADA, 0, 4);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1POCETAKRADA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1POCETAKRADA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POCETAKRADA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POCETAKRADA.MinimumSize = size;
            size = new System.Drawing.Size(0x91, 0x17);
            this.label1POCETAKRADA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerPOCETAKRADA.Location = point;
            this.datePickerPOCETAKRADA.Name = "datePickerPOCETAKRADA";
            this.datePickerPOCETAKRADA.Tag = "POCETAKRADA";
            this.datePickerPOCETAKRADA.TabIndex = 0;
            this.datePickerPOCETAKRADA.Anchor = AnchorStyles.Left;
            this.datePickerPOCETAKRADA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerPOCETAKRADA.ContextMenu = this.contextMenu1;
            this.datePickerPOCETAKRADA.Enabled = true;
            this.layoutManagerTabPage8.Controls.Add(this.datePickerPOCETAKRADA, 1, 4);
            this.layoutManagerTabPage8.SetColumnSpan(this.datePickerPOCETAKRADA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.datePickerPOCETAKRADA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerPOCETAKRADA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerPOCETAKRADA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerPOCETAKRADA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPOSLA.Location = point;
            this.label1NAZIVPOSLA.Name = "label1NAZIVPOSLA";
            this.label1NAZIVPOSLA.TabIndex = 1;
            this.label1NAZIVPOSLA.Tag = "labelNAZIVPOSLA";
            this.label1NAZIVPOSLA.Text = "Naziv posla / narav i vrsta:";
            this.label1NAZIVPOSLA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPOSLA.AutoSize = true;
            this.label1NAZIVPOSLA.Anchor = AnchorStyles.Left;
            this.label1NAZIVPOSLA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPOSLA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPOSLA.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1NAZIVPOSLA, 0, 5);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1NAZIVPOSLA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1NAZIVPOSLA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPOSLA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPOSLA.MinimumSize = size;
            size = new System.Drawing.Size(0xb6, 0x17);
            this.label1NAZIVPOSLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPOSLA.Location = point;
            this.textNAZIVPOSLA.Name = "textNAZIVPOSLA";
            this.textNAZIVPOSLA.Tag = "NAZIVPOSLA";
            this.textNAZIVPOSLA.TabIndex = 0;
            this.textNAZIVPOSLA.Anchor = AnchorStyles.Left;
            this.textNAZIVPOSLA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVPOSLA.ContextMenu = this.contextMenu1;
            this.textNAZIVPOSLA.ReadOnly = false;
            this.textNAZIVPOSLA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "NAZIVPOSLA"));
            this.textNAZIVPOSLA.Nullable = true;
            this.textNAZIVPOSLA.MaxLength = 50;
            this.layoutManagerTabPage8.Controls.Add(this.textNAZIVPOSLA, 1, 5);
            this.layoutManagerTabPage8.SetColumnSpan(this.textNAZIVPOSLA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.textNAZIVPOSLA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPOSLA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPOSLA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPOSLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDUGOVORORADU.Location = point;
            this.label1IDUGOVORORADU.Name = "label1IDUGOVORORADU";
            this.label1IDUGOVORORADU.TabIndex = 1;
            this.label1IDUGOVORORADU.Tag = "labelIDUGOVORORADU";
            this.label1IDUGOVORORADU.Text = "Ugovor sklopljen na:";
            this.label1IDUGOVORORADU.StyleSetName = "FieldUltraLabel";
            this.label1IDUGOVORORADU.AutoSize = true;
            this.label1IDUGOVORORADU.Anchor = AnchorStyles.Left;
            this.label1IDUGOVORORADU.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDUGOVORORADU.Appearance.ForeColor = Color.Black;
            this.label1IDUGOVORORADU.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1IDUGOVORORADU, 0, 6);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1IDUGOVORORADU, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1IDUGOVORORADU, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDUGOVORORADU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDUGOVORORADU.MinimumSize = size;
            size = new System.Drawing.Size(0x8f, 0x17);
            this.label1IDUGOVORORADU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDUGOVORORADU.Location = point;
            this.comboIDUGOVORORADU.Name = "comboIDUGOVORORADU";
            this.comboIDUGOVORORADU.Tag = "IDUGOVORORADU";
            this.comboIDUGOVORORADU.TabIndex = 0;
            this.comboIDUGOVORORADU.Anchor = AnchorStyles.Left;
            this.comboIDUGOVORORADU.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDUGOVORORADU.ContextMenu = this.contextMenu1;
            this.comboIDUGOVORORADU.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDUGOVORORADU.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDUGOVORORADU.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDUGOVORORADU.Enabled = true;
            this.comboIDUGOVORORADU.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDUGOVORORADU"));
            //comboIDUGOVORORADU.PictureBox.Image = ImageResourcesNew.page_white_edit;
            this.comboIDUGOVORORADU.ShowPictureBox = true;
            this.comboIDUGOVORORADU.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDUGOVORORADU);
            this.comboIDUGOVORORADU.ValueMember = "IDUGOVORORADU";
            this.comboIDUGOVORORADU.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDUGOVORORADU);
            this.layoutManagerTabPage8.Controls.Add(this.comboIDUGOVORORADU, 1, 6);
            this.layoutManagerTabPage8.SetColumnSpan(this.comboIDUGOVORORADU, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.comboIDUGOVORORADU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDUGOVORORADU.Margin = padding;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboIDUGOVORORADU.MinimumSize = size;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.comboIDUGOVORORADU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VRIJEMEPROBNOGRADA.Location = point;
            this.label1VRIJEMEPROBNOGRADA.Name = "label1VRIJEMEPROBNOGRADA";
            this.label1VRIJEMEPROBNOGRADA.TabIndex = 1;
            this.label1VRIJEMEPROBNOGRADA.Tag = "labelVRIJEMEPROBNOGRADA";
            this.label1VRIJEMEPROBNOGRADA.Text = "Vrijeme trajanja probnog rada:";
            this.label1VRIJEMEPROBNOGRADA.StyleSetName = "FieldUltraLabel";
            this.label1VRIJEMEPROBNOGRADA.AutoSize = true;
            this.label1VRIJEMEPROBNOGRADA.Anchor = AnchorStyles.Left;
            this.label1VRIJEMEPROBNOGRADA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRIJEMEPROBNOGRADA.Appearance.ForeColor = Color.Black;
            this.label1VRIJEMEPROBNOGRADA.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1VRIJEMEPROBNOGRADA, 0, 7);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1VRIJEMEPROBNOGRADA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1VRIJEMEPROBNOGRADA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRIJEMEPROBNOGRADA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRIJEMEPROBNOGRADA.MinimumSize = size;
            size = new System.Drawing.Size(0xd0, 0x17);
            this.label1VRIJEMEPROBNOGRADA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRIJEMEPROBNOGRADA.Location = point;
            this.textVRIJEMEPROBNOGRADA.Name = "textVRIJEMEPROBNOGRADA";
            this.textVRIJEMEPROBNOGRADA.Tag = "VRIJEMEPROBNOGRADA";
            this.textVRIJEMEPROBNOGRADA.TabIndex = 0;
            this.textVRIJEMEPROBNOGRADA.Anchor = AnchorStyles.Left;
            this.textVRIJEMEPROBNOGRADA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVRIJEMEPROBNOGRADA.ContextMenu = this.contextMenu1;
            this.textVRIJEMEPROBNOGRADA.ReadOnly = false;
            this.textVRIJEMEPROBNOGRADA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "VRIJEMEPROBNOGRADA"));
            this.textVRIJEMEPROBNOGRADA.Nullable = true;
            this.textVRIJEMEPROBNOGRADA.MaxLength = 30;
            this.layoutManagerTabPage8.Controls.Add(this.textVRIJEMEPROBNOGRADA, 1, 7);
            this.layoutManagerTabPage8.SetColumnSpan(this.textVRIJEMEPROBNOGRADA, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.textVRIJEMEPROBNOGRADA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRIJEMEPROBNOGRADA.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textVRIJEMEPROBNOGRADA.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textVRIJEMEPROBNOGRADA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VRIJEMEPRIPRAVNICKOG.Location = point;
            this.label1VRIJEMEPRIPRAVNICKOG.Name = "label1VRIJEMEPRIPRAVNICKOG";
            this.label1VRIJEMEPRIPRAVNICKOG.TabIndex = 1;
            this.label1VRIJEMEPRIPRAVNICKOG.Tag = "labelVRIJEMEPRIPRAVNICKOG";
            this.label1VRIJEMEPRIPRAVNICKOG.Text = "Vrijeme trajanja pripravničkog:";
            this.label1VRIJEMEPRIPRAVNICKOG.StyleSetName = "FieldUltraLabel";
            this.label1VRIJEMEPRIPRAVNICKOG.AutoSize = true;
            this.label1VRIJEMEPRIPRAVNICKOG.Anchor = AnchorStyles.Left;
            this.label1VRIJEMEPRIPRAVNICKOG.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRIJEMEPRIPRAVNICKOG.Appearance.ForeColor = Color.Black;
            this.label1VRIJEMEPRIPRAVNICKOG.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1VRIJEMEPRIPRAVNICKOG, 0, 8);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1VRIJEMEPRIPRAVNICKOG, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1VRIJEMEPRIPRAVNICKOG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRIJEMEPRIPRAVNICKOG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRIJEMEPRIPRAVNICKOG.MinimumSize = size;
            size = new System.Drawing.Size(210, 0x17);
            this.label1VRIJEMEPRIPRAVNICKOG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRIJEMEPRIPRAVNICKOG.Location = point;
            this.textVRIJEMEPRIPRAVNICKOG.Name = "textVRIJEMEPRIPRAVNICKOG";
            this.textVRIJEMEPRIPRAVNICKOG.Tag = "VRIJEMEPRIPRAVNICKOG";
            this.textVRIJEMEPRIPRAVNICKOG.TabIndex = 0;
            this.textVRIJEMEPRIPRAVNICKOG.Anchor = AnchorStyles.Left;
            this.textVRIJEMEPRIPRAVNICKOG.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVRIJEMEPRIPRAVNICKOG.ContextMenu = this.contextMenu1;
            this.textVRIJEMEPRIPRAVNICKOG.ReadOnly = false;
            this.textVRIJEMEPRIPRAVNICKOG.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "VRIJEMEPRIPRAVNICKOG"));
            this.textVRIJEMEPRIPRAVNICKOG.Nullable = true;
            this.textVRIJEMEPRIPRAVNICKOG.MaxLength = 30;
            this.layoutManagerTabPage8.Controls.Add(this.textVRIJEMEPRIPRAVNICKOG, 1, 8);
            this.layoutManagerTabPage8.SetColumnSpan(this.textVRIJEMEPRIPRAVNICKOG, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.textVRIJEMEPRIPRAVNICKOG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRIJEMEPRIPRAVNICKOG.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textVRIJEMEPRIPRAVNICKOG.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textVRIJEMEPRIPRAVNICKOG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VRIJEMESTRUCNI.Location = point;
            this.label1VRIJEMESTRUCNI.Name = "label1VRIJEMESTRUCNI";
            this.label1VRIJEMESTRUCNI.TabIndex = 1;
            this.label1VRIJEMESTRUCNI.Tag = "labelVRIJEMESTRUCNI";
            this.label1VRIJEMESTRUCNI.Text = "Vrijeme i rezultat polaganja stručnog:";
            this.label1VRIJEMESTRUCNI.StyleSetName = "FieldUltraLabel";
            this.label1VRIJEMESTRUCNI.AutoSize = true;
            this.label1VRIJEMESTRUCNI.Anchor = AnchorStyles.Left;
            this.label1VRIJEMESTRUCNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRIJEMESTRUCNI.Appearance.ForeColor = Color.Black;
            this.label1VRIJEMESTRUCNI.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1VRIJEMESTRUCNI, 0, 9);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1VRIJEMESTRUCNI, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1VRIJEMESTRUCNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRIJEMESTRUCNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRIJEMESTRUCNI.MinimumSize = size;
            size = new System.Drawing.Size(250, 0x17);
            this.label1VRIJEMESTRUCNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRIJEMESTRUCNI.Location = point;
            this.textVRIJEMESTRUCNI.Name = "textVRIJEMESTRUCNI";
            this.textVRIJEMESTRUCNI.Tag = "VRIJEMESTRUCNI";
            this.textVRIJEMESTRUCNI.TabIndex = 0;
            this.textVRIJEMESTRUCNI.Anchor = AnchorStyles.Left;
            this.textVRIJEMESTRUCNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVRIJEMESTRUCNI.ContextMenu = this.contextMenu1;
            this.textVRIJEMESTRUCNI.ReadOnly = false;
            this.textVRIJEMESTRUCNI.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "VRIJEMESTRUCNI"));
            this.textVRIJEMESTRUCNI.Nullable = true;
            this.textVRIJEMESTRUCNI.MaxLength = 50;
            this.layoutManagerTabPage8.Controls.Add(this.textVRIJEMESTRUCNI, 1, 9);
            this.layoutManagerTabPage8.SetColumnSpan(this.textVRIJEMESTRUCNI, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.textVRIJEMESTRUCNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRIJEMESTRUCNI.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textVRIJEMESTRUCNI.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textVRIJEMESTRUCNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNOVRIJEME.Location = point;
            this.label1IDRADNOVRIJEME.Name = "label1IDRADNOVRIJEME";
            this.label1IDRADNOVRIJEME.TabIndex = 1;
            this.label1IDRADNOVRIJEME.Tag = "labelIDRADNOVRIJEME";
            this.label1IDRADNOVRIJEME.Text = "IDRADNOVRIJEME:";
            this.label1IDRADNOVRIJEME.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNOVRIJEME.AutoSize = true;
            this.label1IDRADNOVRIJEME.Anchor = AnchorStyles.Left;
            this.label1IDRADNOVRIJEME.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNOVRIJEME.Appearance.ForeColor = Color.Black;
            this.label1IDRADNOVRIJEME.BackColor = Color.Transparent;
            this.layoutManagerTabPage8.Controls.Add(this.label1IDRADNOVRIJEME, 0, 10);
            this.layoutManagerTabPage8.SetColumnSpan(this.label1IDRADNOVRIJEME, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.label1IDRADNOVRIJEME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNOVRIJEME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNOVRIJEME.MinimumSize = size;
            size = new System.Drawing.Size(0x88, 0x17);
            this.label1IDRADNOVRIJEME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRADNOVRIJEME.Location = point;
            this.textIDRADNOVRIJEME.Name = "textIDRADNOVRIJEME";
            this.textIDRADNOVRIJEME.Tag = "IDRADNOVRIJEME";
            this.textIDRADNOVRIJEME.TabIndex = 0;
            this.textIDRADNOVRIJEME.Anchor = AnchorStyles.Left;
            this.textIDRADNOVRIJEME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRADNOVRIJEME.ContextMenu = this.contextMenu1;
            this.textIDRADNOVRIJEME.ReadOnly = false;
            this.textIDRADNOVRIJEME.PromptChar = ' ';
            this.textIDRADNOVRIJEME.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDRADNOVRIJEME.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIK, "IDRADNOVRIJEME"));
            this.textIDRADNOVRIJEME.NumericType = NumericType.Integer;
            this.textIDRADNOVRIJEME.MaskInput = "{LOC}-nnnnn";
            this.textIDRADNOVRIJEME.Nullable = true;
            EditorButton button4 = new EditorButton {
                Key = "editorButtonRADNOVRIJEMEIDRADNOVRIJEME",
                Tag = "editorButtonRADNOVRIJEMEIDRADNOVRIJEME",
                Text = "..."
            };
            this.textIDRADNOVRIJEME.ButtonsRight.Add(button4);
            this.textIDRADNOVRIJEME.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptRADNOVRIJEMEIDRADNOVRIJEME);
            this.layoutManagerTabPage8.Controls.Add(this.textIDRADNOVRIJEME, 1, 10);
            this.layoutManagerTabPage8.SetColumnSpan(this.textIDRADNOVRIJEME, 1);
            this.layoutManagerTabPage8.SetRowSpan(this.textIDRADNOVRIJEME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRADNOVRIJEME.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDRADNOVRIJEME.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDRADNOVRIJEME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.TabPage9.Location = point;
            this.TabPage9.Name = "TabPage9";
            tab14.TabPage = this.TabPage9;
            tab14.Text = "Kadrovski podaci 3";
            this.TabPage9.Controls.Add(this.layoutManagerTabPage9);
            point = new System.Drawing.Point(0, 0);
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Location = point;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Name = "label1VRIJEMEMIROVANJARADNOGODNOSA";
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.TabIndex = 1;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Tag = "labelVRIJEMEMIROVANJARADNOGODNOSA";
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Text = "Vrijeme mirovanja radnog odnosa:";
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.StyleSetName = "FieldUltraLabel";
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.AutoSize = true;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Anchor = AnchorStyles.Left;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Appearance.ForeColor = Color.Black;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.BackColor = Color.Transparent;
            this.layoutManagerTabPage9.Controls.Add(this.label1VRIJEMEMIROVANJARADNOGODNOSA, 0, 0);
            this.layoutManagerTabPage9.SetColumnSpan(this.label1VRIJEMEMIROVANJARADNOGODNOSA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.label1VRIJEMEMIROVANJARADNOGODNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.MinimumSize = size;
            size = new System.Drawing.Size(230, 0x17);
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRIJEMEMIROVANJARADNOGODNOSA.Location = point;
            this.textVRIJEMEMIROVANJARADNOGODNOSA.Name = "textVRIJEMEMIROVANJARADNOGODNOSA";
            this.textVRIJEMEMIROVANJARADNOGODNOSA.Tag = "VRIJEMEMIROVANJARADNOGODNOSA";
            this.textVRIJEMEMIROVANJARADNOGODNOSA.TabIndex = 0;
            this.textVRIJEMEMIROVANJARADNOGODNOSA.Anchor = AnchorStyles.Left;
            this.textVRIJEMEMIROVANJARADNOGODNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVRIJEMEMIROVANJARADNOGODNOSA.ContextMenu = this.contextMenu1;
            this.textVRIJEMEMIROVANJARADNOGODNOSA.ReadOnly = false;
            this.textVRIJEMEMIROVANJARADNOGODNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "VRIJEMEMIROVANJARADNOGODNOSA"));
            this.textVRIJEMEMIROVANJARADNOGODNOSA.Nullable = true;
            this.textVRIJEMEMIROVANJARADNOGODNOSA.MaxLength = 30;
            this.layoutManagerTabPage9.Controls.Add(this.textVRIJEMEMIROVANJARADNOGODNOSA, 1, 0);
            this.layoutManagerTabPage9.SetColumnSpan(this.textVRIJEMEMIROVANJARADNOGODNOSA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.textVRIJEMEMIROVANJARADNOGODNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRIJEMEMIROVANJARADNOGODNOSA.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textVRIJEMEMIROVANJARADNOGODNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textVRIJEMEMIROVANJARADNOGODNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAZLOGPRESTANKA.Location = point;
            this.label1RAZLOGPRESTANKA.Name = "label1RAZLOGPRESTANKA";
            this.label1RAZLOGPRESTANKA.TabIndex = 1;
            this.label1RAZLOGPRESTANKA.Tag = "labelRAZLOGPRESTANKA";
            this.label1RAZLOGPRESTANKA.Text = "Razlog prestanka radnog odnosa:";
            this.label1RAZLOGPRESTANKA.StyleSetName = "FieldUltraLabel";
            this.label1RAZLOGPRESTANKA.AutoSize = true;
            this.label1RAZLOGPRESTANKA.Anchor = AnchorStyles.Left;
            this.label1RAZLOGPRESTANKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZLOGPRESTANKA.Appearance.ForeColor = Color.Black;
            this.label1RAZLOGPRESTANKA.BackColor = Color.Transparent;
            this.layoutManagerTabPage9.Controls.Add(this.label1RAZLOGPRESTANKA, 0, 1);
            this.layoutManagerTabPage9.SetColumnSpan(this.label1RAZLOGPRESTANKA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.label1RAZLOGPRESTANKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZLOGPRESTANKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZLOGPRESTANKA.MinimumSize = size;
            size = new System.Drawing.Size(0xdf, 0x17);
            this.label1RAZLOGPRESTANKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAZLOGPRESTANKA.Location = point;
            this.textRAZLOGPRESTANKA.Name = "textRAZLOGPRESTANKA";
            this.textRAZLOGPRESTANKA.Tag = "RAZLOGPRESTANKA";
            this.textRAZLOGPRESTANKA.TabIndex = 0;
            this.textRAZLOGPRESTANKA.Anchor = AnchorStyles.Left;
            this.textRAZLOGPRESTANKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAZLOGPRESTANKA.ContextMenu = this.contextMenu1;
            this.textRAZLOGPRESTANKA.ReadOnly = false;
            this.textRAZLOGPRESTANKA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "RAZLOGPRESTANKA"));
            this.textRAZLOGPRESTANKA.Nullable = true;
            this.textRAZLOGPRESTANKA.MaxLength = 30;
            this.layoutManagerTabPage9.Controls.Add(this.textRAZLOGPRESTANKA, 1, 1);
            this.layoutManagerTabPage9.SetColumnSpan(this.textRAZLOGPRESTANKA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.textRAZLOGPRESTANKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAZLOGPRESTANKA.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textRAZLOGPRESTANKA.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textRAZLOGPRESTANKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZABRANANATJECANJA.Location = point;
            this.label1ZABRANANATJECANJA.Name = "label1ZABRANANATJECANJA";
            this.label1ZABRANANATJECANJA.TabIndex = 1;
            this.label1ZABRANANATJECANJA.Tag = "labelZABRANANATJECANJA";
            this.label1ZABRANANATJECANJA.Text = "Ugovorena zabrana natjecanja i trajanje:";
            this.label1ZABRANANATJECANJA.StyleSetName = "FieldUltraLabel";
            this.label1ZABRANANATJECANJA.AutoSize = true;
            this.label1ZABRANANATJECANJA.Anchor = AnchorStyles.Left;
            this.label1ZABRANANATJECANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZABRANANATJECANJA.Appearance.ForeColor = Color.Black;
            this.label1ZABRANANATJECANJA.BackColor = Color.Transparent;
            this.layoutManagerTabPage9.Controls.Add(this.label1ZABRANANATJECANJA, 0, 2);
            this.layoutManagerTabPage9.SetColumnSpan(this.label1ZABRANANATJECANJA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.label1ZABRANANATJECANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZABRANANATJECANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZABRANANATJECANJA.MinimumSize = size;
            size = new System.Drawing.Size(270, 0x17);
            this.label1ZABRANANATJECANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZABRANANATJECANJA.Location = point;
            this.textZABRANANATJECANJA.Name = "textZABRANANATJECANJA";
            this.textZABRANANATJECANJA.Tag = "ZABRANANATJECANJA";
            this.textZABRANANATJECANJA.TabIndex = 0;
            this.textZABRANANATJECANJA.Anchor = AnchorStyles.Left;
            this.textZABRANANATJECANJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZABRANANATJECANJA.ContextMenu = this.contextMenu1;
            this.textZABRANANATJECANJA.ReadOnly = false;
            this.textZABRANANATJECANJA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "ZABRANANATJECANJA"));
            this.textZABRANANATJECANJA.Nullable = true;
            this.textZABRANANATJECANJA.MaxLength = 50;
            this.layoutManagerTabPage9.Controls.Add(this.textZABRANANATJECANJA, 1, 2);
            this.layoutManagerTabPage9.SetColumnSpan(this.textZABRANANATJECANJA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.textZABRANANATJECANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZABRANANATJECANJA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textZABRANANATJECANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textZABRANANATJECANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRODUZENOMIROVINSKO.Location = point;
            this.label1PRODUZENOMIROVINSKO.Name = "label1PRODUZENOMIROVINSKO";
            this.label1PRODUZENOMIROVINSKO.TabIndex = 1;
            this.label1PRODUZENOMIROVINSKO.Tag = "labelPRODUZENOMIROVINSKO";
            this.label1PRODUZENOMIROVINSKO.Text = "Uvjeti i vrijeme za koje se uplaćuju dop.za mir.:";
            this.label1PRODUZENOMIROVINSKO.StyleSetName = "FieldUltraLabel";
            this.label1PRODUZENOMIROVINSKO.AutoSize = true;
            this.label1PRODUZENOMIROVINSKO.Anchor = AnchorStyles.Left;
            this.label1PRODUZENOMIROVINSKO.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRODUZENOMIROVINSKO.Appearance.ForeColor = Color.Black;
            this.label1PRODUZENOMIROVINSKO.BackColor = Color.Transparent;
            this.layoutManagerTabPage9.Controls.Add(this.label1PRODUZENOMIROVINSKO, 0, 3);
            this.layoutManagerTabPage9.SetColumnSpan(this.label1PRODUZENOMIROVINSKO, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.label1PRODUZENOMIROVINSKO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRODUZENOMIROVINSKO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRODUZENOMIROVINSKO.MinimumSize = size;
            size = new System.Drawing.Size(310, 0x17);
            this.label1PRODUZENOMIROVINSKO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRODUZENOMIROVINSKO.Location = point;
            this.textPRODUZENOMIROVINSKO.Name = "textPRODUZENOMIROVINSKO";
            this.textPRODUZENOMIROVINSKO.Tag = "PRODUZENOMIROVINSKO";
            this.textPRODUZENOMIROVINSKO.TabIndex = 0;
            this.textPRODUZENOMIROVINSKO.Anchor = AnchorStyles.Left;
            this.textPRODUZENOMIROVINSKO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRODUZENOMIROVINSKO.ContextMenu = this.contextMenu1;
            this.textPRODUZENOMIROVINSKO.ReadOnly = false;
            this.textPRODUZENOMIROVINSKO.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "PRODUZENOMIROVINSKO"));
            this.textPRODUZENOMIROVINSKO.Nullable = true;
            this.textPRODUZENOMIROVINSKO.MaxLength = 50;
            this.layoutManagerTabPage9.Controls.Add(this.textPRODUZENOMIROVINSKO, 1, 3);
            this.layoutManagerTabPage9.SetColumnSpan(this.textPRODUZENOMIROVINSKO, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.textPRODUZENOMIROVINSKO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRODUZENOMIROVINSKO.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPRODUZENOMIROVINSKO.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPRODUZENOMIROVINSKO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RADUINOZEMSTVU.Location = point;
            this.label1RADUINOZEMSTVU.Name = "label1RADUINOZEMSTVU";
            this.label1RADUINOZEMSTVU.TabIndex = 1;
            this.label1RADUINOZEMSTVU.Tag = "labelRADUINOZEMSTVU";
            this.label1RADUINOZEMSTVU.Text = "Rad u inozemstvu:";
            this.label1RADUINOZEMSTVU.StyleSetName = "FieldUltraLabel";
            this.label1RADUINOZEMSTVU.AutoSize = true;
            this.label1RADUINOZEMSTVU.Anchor = AnchorStyles.Left;
            this.label1RADUINOZEMSTVU.Appearance.TextVAlign = VAlign.Middle;
            this.label1RADUINOZEMSTVU.Appearance.ForeColor = Color.Black;
            this.label1RADUINOZEMSTVU.BackColor = Color.Transparent;
            this.layoutManagerTabPage9.Controls.Add(this.label1RADUINOZEMSTVU, 0, 4);
            this.layoutManagerTabPage9.SetColumnSpan(this.label1RADUINOZEMSTVU, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.label1RADUINOZEMSTVU, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RADUINOZEMSTVU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RADUINOZEMSTVU.MinimumSize = size;
            size = new System.Drawing.Size(130, 0x17);
            this.label1RADUINOZEMSTVU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRADUINOZEMSTVU.Location = point;
            this.textRADUINOZEMSTVU.Name = "textRADUINOZEMSTVU";
            this.textRADUINOZEMSTVU.Tag = "RADUINOZEMSTVU";
            this.textRADUINOZEMSTVU.TabIndex = 0;
            this.textRADUINOZEMSTVU.Anchor = AnchorStyles.Left;
            this.textRADUINOZEMSTVU.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRADUINOZEMSTVU.ContextMenu = this.contextMenu1;
            this.textRADUINOZEMSTVU.ReadOnly = false;
            this.textRADUINOZEMSTVU.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "RADUINOZEMSTVU"));
            this.textRADUINOZEMSTVU.Nullable = true;
            this.textRADUINOZEMSTVU.MaxLength = 50;
            this.layoutManagerTabPage9.Controls.Add(this.textRADUINOZEMSTVU, 1, 4);
            this.layoutManagerTabPage9.SetColumnSpan(this.textRADUINOZEMSTVU, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.textRADUINOZEMSTVU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRADUINOZEMSTVU.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRADUINOZEMSTVU.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRADUINOZEMSTVU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RADNASPOSOBNOST.Location = point;
            this.label1RADNASPOSOBNOST.Name = "label1RADNASPOSOBNOST";
            this.label1RADNASPOSOBNOST.TabIndex = 1;
            this.label1RADNASPOSOBNOST.Tag = "labelRADNASPOSOBNOST";
            this.label1RADNASPOSOBNOST.Text = "Potrebno prethodno/redovito utvrđivanje radne sposobnosti:";
            this.label1RADNASPOSOBNOST.StyleSetName = "FieldUltraLabel";
            this.label1RADNASPOSOBNOST.AutoSize = true;
            this.label1RADNASPOSOBNOST.Anchor = AnchorStyles.Left;
            this.label1RADNASPOSOBNOST.Appearance.TextVAlign = VAlign.Middle;
            this.label1RADNASPOSOBNOST.Appearance.ForeColor = Color.Black;
            this.label1RADNASPOSOBNOST.BackColor = Color.Transparent;
            this.layoutManagerTabPage9.Controls.Add(this.label1RADNASPOSOBNOST, 0, 5);
            this.layoutManagerTabPage9.SetColumnSpan(this.label1RADNASPOSOBNOST, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.label1RADNASPOSOBNOST, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RADNASPOSOBNOST.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RADNASPOSOBNOST.MinimumSize = size;
            size = new System.Drawing.Size(0x18b, 0x17);
            this.label1RADNASPOSOBNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRADNASPOSOBNOST.Location = point;
            this.textRADNASPOSOBNOST.Name = "textRADNASPOSOBNOST";
            this.textRADNASPOSOBNOST.Tag = "RADNASPOSOBNOST";
            this.textRADNASPOSOBNOST.TabIndex = 0;
            this.textRADNASPOSOBNOST.Anchor = AnchorStyles.Left;
            this.textRADNASPOSOBNOST.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRADNASPOSOBNOST.ContextMenu = this.contextMenu1;
            this.textRADNASPOSOBNOST.ReadOnly = false;
            this.textRADNASPOSOBNOST.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "RADNASPOSOBNOST"));
            this.textRADNASPOSOBNOST.Nullable = true;
            this.textRADNASPOSOBNOST.MaxLength = 30;
            this.layoutManagerTabPage9.Controls.Add(this.textRADNASPOSOBNOST, 1, 5);
            this.layoutManagerTabPage9.SetColumnSpan(this.textRADNASPOSOBNOST, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.textRADNASPOSOBNOST, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRADNASPOSOBNOST.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textRADNASPOSOBNOST.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textRADNASPOSOBNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RADNIKNAPOMENA.Location = point;
            this.label1RADNIKNAPOMENA.Name = "label1RADNIKNAPOMENA";
            this.label1RADNIKNAPOMENA.TabIndex = 1;
            this.label1RADNIKNAPOMENA.Tag = "labelRADNIKNAPOMENA";
            this.label1RADNIKNAPOMENA.Text = "Napomena:";
            this.label1RADNIKNAPOMENA.StyleSetName = "FieldUltraLabel";
            this.label1RADNIKNAPOMENA.AutoSize = true;
            this.label1RADNIKNAPOMENA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1RADNIKNAPOMENA.Appearance.TextVAlign = VAlign.Middle;
            this.label1RADNIKNAPOMENA.Appearance.ForeColor = Color.Black;
            this.label1RADNIKNAPOMENA.BackColor = Color.Transparent;
            this.layoutManagerTabPage9.Controls.Add(this.label1RADNIKNAPOMENA, 0, 6);
            this.layoutManagerTabPage9.SetColumnSpan(this.label1RADNIKNAPOMENA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.label1RADNIKNAPOMENA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RADNIKNAPOMENA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RADNIKNAPOMENA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x17);
            this.label1RADNIKNAPOMENA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRADNIKNAPOMENA.Location = point;
            this.textRADNIKNAPOMENA.Name = "textRADNIKNAPOMENA";
            this.textRADNIKNAPOMENA.Tag = "RADNIKNAPOMENA";
            this.textRADNIKNAPOMENA.TabIndex = 0;
            this.textRADNIKNAPOMENA.Anchor = AnchorStyles.Left;
            this.textRADNIKNAPOMENA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRADNIKNAPOMENA.ContextMenu = this.contextMenu1;
            this.textRADNIKNAPOMENA.ReadOnly = false;
            this.textRADNIKNAPOMENA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIK, "RADNIKNAPOMENA"));
            this.textRADNIKNAPOMENA.Nullable = true;
            this.textRADNIKNAPOMENA.Multiline = true;
            this.layoutManagerTabPage9.Controls.Add(this.textRADNIKNAPOMENA, 1, 6);
            this.layoutManagerTabPage9.SetColumnSpan(this.textRADNIKNAPOMENA, 1);
            this.layoutManagerTabPage9.SetRowSpan(this.textRADNIKNAPOMENA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRADNIKNAPOMENA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x58);
            this.textRADNIKNAPOMENA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x58);
            this.textRADNIKNAPOMENA.Size = size;
            this.textRADNIKNAPOMENA.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.Tab1.Location = point;
            this.Tab1.Name = "Tab1";
            this.layoutManagerformRADNIK.Controls.Add(this.Tab1, 0, 1);
            this.layoutManagerformRADNIK.SetColumnSpan(this.Tab1, 1);
            this.layoutManagerformRADNIK.SetRowSpan(this.Tab1, 1);
            padding = new Padding(5, 11, 5, 5);
            this.Tab1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Tab1.MinimumSize = size;
            this.Tab1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.Level4Page.Location = point;
            this.Level4Page.Name = "Level4Page";
            tab2.TabPage = this.Level4Page;
            tab2.Text = "Bruto elementi";
            this.Level4Page.Controls.Add(this.layoutManagerLevel4Page);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKBruto.Location = point;
            this.grdLevelRADNIKBruto.Name = "grdLevelRADNIKBruto";
            this.layoutManagerLevel4Page.Controls.Add(this.grdLevelRADNIKBruto, 0, 0);
            this.layoutManagerLevel4Page.SetColumnSpan(this.grdLevelRADNIKBruto, 1);
            this.layoutManagerLevel4Page.SetRowSpan(this.grdLevelRADNIKBruto, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKBruto.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKBruto.MinimumSize = size;
            size = new System.Drawing.Size(0x1c3, 200);
            this.grdLevelRADNIKBruto.Size = size;
            this.grdLevelRADNIKBruto.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKBruto.Location = point;
            this.panelactionsRADNIKBruto.Name = "panelactionsRADNIKBruto";
            this.panelactionsRADNIKBruto.BackColor = Color.Transparent;
            this.panelactionsRADNIKBruto.Controls.Add(this.layoutManagerpanelactionsRADNIKBruto);
            this.layoutManagerLevel4Page.Controls.Add(this.panelactionsRADNIKBruto, 0, 1);
            this.layoutManagerLevel4Page.SetColumnSpan(this.panelactionsRADNIKBruto, 1);
            this.layoutManagerLevel4Page.SetRowSpan(this.panelactionsRADNIKBruto, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKBruto.Margin = padding;
            size = new System.Drawing.Size(0x19b, 0x19);
            this.panelactionsRADNIKBruto.MinimumSize = size;
            size = new System.Drawing.Size(0x19b, 0x19);
            this.panelactionsRADNIKBruto.Size = size;
            this.panelactionsRADNIKBruto.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKBrutoAdd.Location = point;
            this.linkLabelRADNIKBrutoAdd.Name = "linkLabelRADNIKBrutoAdd";
            size = new System.Drawing.Size(0x71, 15);
            this.linkLabelRADNIKBrutoAdd.Size = size;
            this.linkLabelRADNIKBrutoAdd.Text = " Add Bruto elementi  ";
            this.linkLabelRADNIKBrutoAdd.Click += new EventHandler(this.RADNIKBrutoAdd_Click);
            this.linkLabelRADNIKBrutoAdd.BackColor = Color.Transparent;
            this.linkLabelRADNIKBrutoAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKBrutoAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKBrutoAdd.Cursor = Cursors.Hand;
            this.linkLabelRADNIKBrutoAdd.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKBruto.Controls.Add(this.linkLabelRADNIKBrutoAdd, 0, 0);
            this.layoutManagerpanelactionsRADNIKBruto.SetColumnSpan(this.linkLabelRADNIKBrutoAdd, 1);
            this.layoutManagerpanelactionsRADNIKBruto.SetRowSpan(this.linkLabelRADNIKBrutoAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKBrutoAdd.Margin = padding;
            size = new System.Drawing.Size(0x71, 15);
            this.linkLabelRADNIKBrutoAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 15);
            this.linkLabelRADNIKBrutoAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKBrutoUpdate.Location = point;
            this.linkLabelRADNIKBrutoUpdate.Name = "linkLabelRADNIKBrutoUpdate";
            size = new System.Drawing.Size(0x83, 15);
            this.linkLabelRADNIKBrutoUpdate.Size = size;
            this.linkLabelRADNIKBrutoUpdate.Text = " Update Bruto elementi  ";
            this.linkLabelRADNIKBrutoUpdate.Click += new EventHandler(this.RADNIKBrutoUpdate_Click);
            this.linkLabelRADNIKBrutoUpdate.BackColor = Color.Transparent;
            this.linkLabelRADNIKBrutoUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKBrutoUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKBrutoUpdate.Cursor = Cursors.Hand;
            this.linkLabelRADNIKBrutoUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKBruto.Controls.Add(this.linkLabelRADNIKBrutoUpdate, 1, 0);
            this.layoutManagerpanelactionsRADNIKBruto.SetColumnSpan(this.linkLabelRADNIKBrutoUpdate, 1);
            this.layoutManagerpanelactionsRADNIKBruto.SetRowSpan(this.linkLabelRADNIKBrutoUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKBrutoUpdate.Margin = padding;
            size = new System.Drawing.Size(0x83, 15);
            this.linkLabelRADNIKBrutoUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x83, 15);
            this.linkLabelRADNIKBrutoUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKBrutoDelete.Location = point;
            this.linkLabelRADNIKBrutoDelete.Name = "linkLabelRADNIKBrutoDelete";
            size = new System.Drawing.Size(0x7f, 15);
            this.linkLabelRADNIKBrutoDelete.Size = size;
            this.linkLabelRADNIKBrutoDelete.Text = " Delete Bruto elementi  ";
            this.linkLabelRADNIKBrutoDelete.Click += new EventHandler(this.RADNIKBrutoDelete_Click);
            this.linkLabelRADNIKBrutoDelete.BackColor = Color.Transparent;
            this.linkLabelRADNIKBrutoDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKBrutoDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKBrutoDelete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKBrutoDelete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKBruto.Controls.Add(this.linkLabelRADNIKBrutoDelete, 2, 0);
            this.layoutManagerpanelactionsRADNIKBruto.SetColumnSpan(this.linkLabelRADNIKBrutoDelete, 1);
            this.layoutManagerpanelactionsRADNIKBruto.SetRowSpan(this.linkLabelRADNIKBrutoDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKBrutoDelete.Margin = padding;
            size = new System.Drawing.Size(0x7f, 15);
            this.linkLabelRADNIKBrutoDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x7f, 15);
            this.linkLabelRADNIKBrutoDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKBruto.Location = point;
            this.linkLabelRADNIKBruto.Name = "linkLabelRADNIKBruto";
            this.layoutManagerpanelactionsRADNIKBruto.Controls.Add(this.linkLabelRADNIKBruto, 3, 0);
            this.layoutManagerpanelactionsRADNIKBruto.SetColumnSpan(this.linkLabelRADNIKBruto, 1);
            this.layoutManagerpanelactionsRADNIKBruto.SetRowSpan(this.linkLabelRADNIKBruto, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKBruto.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKBruto.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKBruto.Size = size;
            this.linkLabelRADNIKBruto.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage1.Location = point;
            this.TabPage1.Name = "TabPage1";
            tab5.TabPage = this.TabPage1;
            tab5.Text = "Neto elementi";
            this.TabPage1.Controls.Add(this.layoutManagerTabPage1);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKNeto.Location = point;
            this.grdLevelRADNIKNeto.Name = "grdLevelRADNIKNeto";
            this.layoutManagerTabPage1.Controls.Add(this.grdLevelRADNIKNeto, 0, 0);
            this.layoutManagerTabPage1.SetColumnSpan(this.grdLevelRADNIKNeto, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.grdLevelRADNIKNeto, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKNeto.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKNeto.MinimumSize = size;
            size = new System.Drawing.Size(0x1c3, 200);
            this.grdLevelRADNIKNeto.Size = size;
            this.grdLevelRADNIKNeto.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKNeto.Location = point;
            this.panelactionsRADNIKNeto.Name = "panelactionsRADNIKNeto";
            this.panelactionsRADNIKNeto.BackColor = Color.Transparent;
            this.panelactionsRADNIKNeto.Controls.Add(this.layoutManagerpanelactionsRADNIKNeto);
            this.layoutManagerTabPage1.Controls.Add(this.panelactionsRADNIKNeto, 0, 1);
            this.layoutManagerTabPage1.SetColumnSpan(this.panelactionsRADNIKNeto, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.panelactionsRADNIKNeto, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKNeto.Margin = padding;
            size = new System.Drawing.Size(0x18f, 0x19);
            this.panelactionsRADNIKNeto.MinimumSize = size;
            size = new System.Drawing.Size(0x18f, 0x19);
            this.panelactionsRADNIKNeto.Size = size;
            this.panelactionsRADNIKNeto.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKNetoAdd.Location = point;
            this.linkLabelRADNIKNetoAdd.Name = "linkLabelRADNIKNetoAdd";
            size = new System.Drawing.Size(0x6d, 15);
            this.linkLabelRADNIKNetoAdd.Size = size;
            this.linkLabelRADNIKNetoAdd.Text = " Add Neto elementi  ";
            this.linkLabelRADNIKNetoAdd.Click += new EventHandler(this.RADNIKNetoAdd_Click);
            this.linkLabelRADNIKNetoAdd.BackColor = Color.Transparent;
            this.linkLabelRADNIKNetoAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKNetoAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKNetoAdd.Cursor = Cursors.Hand;
            this.linkLabelRADNIKNetoAdd.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKNeto.Controls.Add(this.linkLabelRADNIKNetoAdd, 0, 0);
            this.layoutManagerpanelactionsRADNIKNeto.SetColumnSpan(this.linkLabelRADNIKNetoAdd, 1);
            this.layoutManagerpanelactionsRADNIKNeto.SetRowSpan(this.linkLabelRADNIKNetoAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKNetoAdd.Margin = padding;
            size = new System.Drawing.Size(0x6d, 15);
            this.linkLabelRADNIKNetoAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x6d, 15);
            this.linkLabelRADNIKNetoAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKNetoUpdate.Location = point;
            this.linkLabelRADNIKNetoUpdate.Name = "linkLabelRADNIKNetoUpdate";
            size = new System.Drawing.Size(0x7f, 15);
            this.linkLabelRADNIKNetoUpdate.Size = size;
            this.linkLabelRADNIKNetoUpdate.Text = " Update Neto elementi  ";
            this.linkLabelRADNIKNetoUpdate.Click += new EventHandler(this.RADNIKNetoUpdate_Click);
            this.linkLabelRADNIKNetoUpdate.BackColor = Color.Transparent;
            this.linkLabelRADNIKNetoUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKNetoUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKNetoUpdate.Cursor = Cursors.Hand;
            this.linkLabelRADNIKNetoUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKNeto.Controls.Add(this.linkLabelRADNIKNetoUpdate, 1, 0);
            this.layoutManagerpanelactionsRADNIKNeto.SetColumnSpan(this.linkLabelRADNIKNetoUpdate, 1);
            this.layoutManagerpanelactionsRADNIKNeto.SetRowSpan(this.linkLabelRADNIKNetoUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKNetoUpdate.Margin = padding;
            size = new System.Drawing.Size(0x7f, 15);
            this.linkLabelRADNIKNetoUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x7f, 15);
            this.linkLabelRADNIKNetoUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKNetoDelete.Location = point;
            this.linkLabelRADNIKNetoDelete.Name = "linkLabelRADNIKNetoDelete";
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelRADNIKNetoDelete.Size = size;
            this.linkLabelRADNIKNetoDelete.Text = " Delete Neto elementi  ";
            this.linkLabelRADNIKNetoDelete.Click += new EventHandler(this.RADNIKNetoDelete_Click);
            this.linkLabelRADNIKNetoDelete.BackColor = Color.Transparent;
            this.linkLabelRADNIKNetoDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKNetoDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKNetoDelete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKNetoDelete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKNeto.Controls.Add(this.linkLabelRADNIKNetoDelete, 2, 0);
            this.layoutManagerpanelactionsRADNIKNeto.SetColumnSpan(this.linkLabelRADNIKNetoDelete, 1);
            this.layoutManagerpanelactionsRADNIKNeto.SetRowSpan(this.linkLabelRADNIKNetoDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKNetoDelete.Margin = padding;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelRADNIKNetoDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelRADNIKNetoDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKNeto.Location = point;
            this.linkLabelRADNIKNeto.Name = "linkLabelRADNIKNeto";
            this.layoutManagerpanelactionsRADNIKNeto.Controls.Add(this.linkLabelRADNIKNeto, 3, 0);
            this.layoutManagerpanelactionsRADNIKNeto.SetColumnSpan(this.linkLabelRADNIKNeto, 1);
            this.layoutManagerpanelactionsRADNIKNeto.SetRowSpan(this.linkLabelRADNIKNeto, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKNeto.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKNeto.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKNeto.Size = size;
            this.linkLabelRADNIKNeto.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage2.Location = point;
            this.TabPage2.Name = "TabPage2";
            tab7.TabPage = this.TabPage2;
            tab7.Text = "Obustave";
            this.TabPage2.Controls.Add(this.layoutManagerTabPage2);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKObustava.Location = point;
            this.grdLevelRADNIKObustava.Name = "grdLevelRADNIKObustava";
            this.layoutManagerTabPage2.Controls.Add(this.grdLevelRADNIKObustava, 0, 0);
            this.layoutManagerTabPage2.SetColumnSpan(this.grdLevelRADNIKObustava, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.grdLevelRADNIKObustava, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKObustava.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKObustava.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelRADNIKObustava.Size = size;
            this.grdLevelRADNIKObustava.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKObustava.Location = point;
            this.panelactionsRADNIKObustava.Name = "panelactionsRADNIKObustava";
            this.panelactionsRADNIKObustava.BackColor = Color.Transparent;
            this.panelactionsRADNIKObustava.Controls.Add(this.layoutManagerpanelactionsRADNIKObustava);
            this.layoutManagerTabPage2.Controls.Add(this.panelactionsRADNIKObustava, 0, 1);
            this.layoutManagerTabPage2.SetColumnSpan(this.panelactionsRADNIKObustava, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.panelactionsRADNIKObustava, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKObustava.Margin = padding;
            size = new System.Drawing.Size(0x145, 0x19);
            this.panelactionsRADNIKObustava.MinimumSize = size;
            size = new System.Drawing.Size(0x145, 0x19);
            this.panelactionsRADNIKObustava.Size = size;
            this.panelactionsRADNIKObustava.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKObustavaAdd.Location = point;
            this.linkLabelRADNIKObustavaAdd.Name = "linkLabelRADNIKObustavaAdd";
            size = new System.Drawing.Size(0x55, 15);
            this.linkLabelRADNIKObustavaAdd.Size = size;
            this.linkLabelRADNIKObustavaAdd.Text = " Add Obustave  ";
            this.linkLabelRADNIKObustavaAdd.Click += new EventHandler(this.RADNIKObustavaAdd_Click);
            this.linkLabelRADNIKObustavaAdd.BackColor = Color.Transparent;
            this.linkLabelRADNIKObustavaAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKObustavaAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKObustavaAdd.Cursor = Cursors.Hand;
            this.linkLabelRADNIKObustavaAdd.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKObustava.Controls.Add(this.linkLabelRADNIKObustavaAdd, 0, 0);
            this.layoutManagerpanelactionsRADNIKObustava.SetColumnSpan(this.linkLabelRADNIKObustavaAdd, 1);
            this.layoutManagerpanelactionsRADNIKObustava.SetRowSpan(this.linkLabelRADNIKObustavaAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKObustavaAdd.Margin = padding;
            size = new System.Drawing.Size(0x55, 15);
            this.linkLabelRADNIKObustavaAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x55, 15);
            this.linkLabelRADNIKObustavaAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKObustavaUpdate.Location = point;
            this.linkLabelRADNIKObustavaUpdate.Name = "linkLabelRADNIKObustavaUpdate";
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelRADNIKObustavaUpdate.Size = size;
            this.linkLabelRADNIKObustavaUpdate.Text = " Update Obustave  ";
            this.linkLabelRADNIKObustavaUpdate.Click += new EventHandler(this.RADNIKObustavaUpdate_Click);
            this.linkLabelRADNIKObustavaUpdate.BackColor = Color.Transparent;
            this.linkLabelRADNIKObustavaUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKObustavaUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKObustavaUpdate.Cursor = Cursors.Hand;
            this.linkLabelRADNIKObustavaUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKObustava.Controls.Add(this.linkLabelRADNIKObustavaUpdate, 1, 0);
            this.layoutManagerpanelactionsRADNIKObustava.SetColumnSpan(this.linkLabelRADNIKObustavaUpdate, 1);
            this.layoutManagerpanelactionsRADNIKObustava.SetRowSpan(this.linkLabelRADNIKObustavaUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKObustavaUpdate.Margin = padding;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelRADNIKObustavaUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelRADNIKObustavaUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKObustavaDelete.Location = point;
            this.linkLabelRADNIKObustavaDelete.Name = "linkLabelRADNIKObustavaDelete";
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelRADNIKObustavaDelete.Size = size;
            this.linkLabelRADNIKObustavaDelete.Text = " Delete Obustave  ";
            this.linkLabelRADNIKObustavaDelete.Click += new EventHandler(this.RADNIKObustavaDelete_Click);
            this.linkLabelRADNIKObustavaDelete.BackColor = Color.Transparent;
            this.linkLabelRADNIKObustavaDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKObustavaDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKObustavaDelete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKObustavaDelete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKObustava.Controls.Add(this.linkLabelRADNIKObustavaDelete, 2, 0);
            this.layoutManagerpanelactionsRADNIKObustava.SetColumnSpan(this.linkLabelRADNIKObustavaDelete, 1);
            this.layoutManagerpanelactionsRADNIKObustava.SetRowSpan(this.linkLabelRADNIKObustavaDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKObustavaDelete.Margin = padding;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelRADNIKObustavaDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelRADNIKObustavaDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKObustava.Location = point;
            this.linkLabelRADNIKObustava.Name = "linkLabelRADNIKObustava";
            this.layoutManagerpanelactionsRADNIKObustava.Controls.Add(this.linkLabelRADNIKObustava, 3, 0);
            this.layoutManagerpanelactionsRADNIKObustava.SetColumnSpan(this.linkLabelRADNIKObustava, 1);
            this.layoutManagerpanelactionsRADNIKObustava.SetRowSpan(this.linkLabelRADNIKObustava, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKObustava.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKObustava.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKObustava.Size = size;
            this.linkLabelRADNIKObustava.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.KreditiPage.Location = point;
            this.KreditiPage.Name = "KreditiPage";
            tab.TabPage = this.KreditiPage;
            tab.Text = "Krediti";
            this.KreditiPage.Controls.Add(this.layoutManagerKreditiPage);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKKrediti.Location = point;
            this.grdLevelRADNIKKrediti.Name = "grdLevelRADNIKKrediti";
            this.layoutManagerKreditiPage.Controls.Add(this.grdLevelRADNIKKrediti, 0, 0);
            this.layoutManagerKreditiPage.SetColumnSpan(this.grdLevelRADNIKKrediti, 1);
            this.layoutManagerKreditiPage.SetRowSpan(this.grdLevelRADNIKKrediti, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKKrediti.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKKrediti.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelRADNIKKrediti.Size = size;
            this.grdLevelRADNIKKrediti.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKKrediti.Location = point;
            this.panelactionsRADNIKKrediti.Name = "panelactionsRADNIKKrediti";
            this.panelactionsRADNIKKrediti.BackColor = Color.Transparent;
            this.panelactionsRADNIKKrediti.Controls.Add(this.layoutManagerpanelactionsRADNIKKrediti);
            this.layoutManagerKreditiPage.Controls.Add(this.panelactionsRADNIKKrediti, 0, 1);
            this.layoutManagerKreditiPage.SetColumnSpan(this.panelactionsRADNIKKrediti, 1);
            this.layoutManagerKreditiPage.SetRowSpan(this.panelactionsRADNIKKrediti, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKKrediti.Margin = padding;
            size = new System.Drawing.Size(0x198, 0x19);
            this.panelactionsRADNIKKrediti.MinimumSize = size;
            size = new System.Drawing.Size(0x198, 0x19);
            this.panelactionsRADNIKKrediti.Size = size;
            this.panelactionsRADNIKKrediti.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKKreditiAdd.Location = point;
            this.linkLabelRADNIKKreditiAdd.Name = "linkLabelRADNIKKreditiAdd";
            size = new System.Drawing.Size(0x70, 15);
            this.linkLabelRADNIKKreditiAdd.Size = size;
            this.linkLabelRADNIKKreditiAdd.Text = " Add Krediti radnika  ";
            this.linkLabelRADNIKKreditiAdd.Click += new EventHandler(this.RADNIKKreditiAdd_Click);
            this.linkLabelRADNIKKreditiAdd.BackColor = Color.Transparent;
            this.linkLabelRADNIKKreditiAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKKreditiAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKKreditiAdd.Cursor = Cursors.Hand;
            this.linkLabelRADNIKKreditiAdd.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKKrediti.Controls.Add(this.linkLabelRADNIKKreditiAdd, 0, 0);
            this.layoutManagerpanelactionsRADNIKKrediti.SetColumnSpan(this.linkLabelRADNIKKreditiAdd, 1);
            this.layoutManagerpanelactionsRADNIKKrediti.SetRowSpan(this.linkLabelRADNIKKreditiAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKKreditiAdd.Margin = padding;
            size = new System.Drawing.Size(0x70, 15);
            this.linkLabelRADNIKKreditiAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 15);
            this.linkLabelRADNIKKreditiAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKKreditiUpdate.Location = point;
            this.linkLabelRADNIKKreditiUpdate.Name = "linkLabelRADNIKKreditiUpdate";
            size = new System.Drawing.Size(130, 15);
            this.linkLabelRADNIKKreditiUpdate.Size = size;
            this.linkLabelRADNIKKreditiUpdate.Text = " Update Krediti radnika  ";
            this.linkLabelRADNIKKreditiUpdate.Click += new EventHandler(this.RADNIKKreditiUpdate_Click);
            this.linkLabelRADNIKKreditiUpdate.BackColor = Color.Transparent;
            this.linkLabelRADNIKKreditiUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKKreditiUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKKreditiUpdate.Cursor = Cursors.Hand;
            this.linkLabelRADNIKKreditiUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKKrediti.Controls.Add(this.linkLabelRADNIKKreditiUpdate, 1, 0);
            this.layoutManagerpanelactionsRADNIKKrediti.SetColumnSpan(this.linkLabelRADNIKKreditiUpdate, 1);
            this.layoutManagerpanelactionsRADNIKKrediti.SetRowSpan(this.linkLabelRADNIKKreditiUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKKreditiUpdate.Margin = padding;
            size = new System.Drawing.Size(130, 15);
            this.linkLabelRADNIKKreditiUpdate.MinimumSize = size;
            size = new System.Drawing.Size(130, 15);
            this.linkLabelRADNIKKreditiUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKKreditiDelete.Location = point;
            this.linkLabelRADNIKKreditiDelete.Name = "linkLabelRADNIKKreditiDelete";
            size = new System.Drawing.Size(0x7e, 15);
            this.linkLabelRADNIKKreditiDelete.Size = size;
            this.linkLabelRADNIKKreditiDelete.Text = " Delete Krediti radnika  ";
            this.linkLabelRADNIKKreditiDelete.Click += new EventHandler(this.RADNIKKreditiDelete_Click);
            this.linkLabelRADNIKKreditiDelete.BackColor = Color.Transparent;
            this.linkLabelRADNIKKreditiDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKKreditiDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKKreditiDelete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKKreditiDelete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKKrediti.Controls.Add(this.linkLabelRADNIKKreditiDelete, 2, 0);
            this.layoutManagerpanelactionsRADNIKKrediti.SetColumnSpan(this.linkLabelRADNIKKreditiDelete, 1);
            this.layoutManagerpanelactionsRADNIKKrediti.SetRowSpan(this.linkLabelRADNIKKreditiDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKKreditiDelete.Margin = padding;
            size = new System.Drawing.Size(0x7e, 15);
            this.linkLabelRADNIKKreditiDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 15);
            this.linkLabelRADNIKKreditiDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKKrediti.Location = point;
            this.linkLabelRADNIKKrediti.Name = "linkLabelRADNIKKrediti";
            this.layoutManagerpanelactionsRADNIKKrediti.Controls.Add(this.linkLabelRADNIKKrediti, 3, 0);
            this.layoutManagerpanelactionsRADNIKKrediti.SetColumnSpan(this.linkLabelRADNIKKrediti, 1);
            this.layoutManagerpanelactionsRADNIKKrediti.SetRowSpan(this.linkLabelRADNIKKrediti, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKKrediti.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKKrediti.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKKrediti.Size = size;
            this.linkLabelRADNIKKrediti.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.OsobniOdbitakPage.Location = point;
            this.OsobniOdbitakPage.Name = "OsobniOdbitakPage";
            tab3.TabPage = this.OsobniOdbitakPage;
            tab3.Text = "Osobni odbici radnika";
            this.OsobniOdbitakPage.Controls.Add(this.layoutManagerOsobniOdbitakPage);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKOdbitak.Location = point;
            this.grdLevelRADNIKOdbitak.Name = "grdLevelRADNIKOdbitak";
            this.layoutManagerOsobniOdbitakPage.Controls.Add(this.grdLevelRADNIKOdbitak, 0, 0);
            this.layoutManagerOsobniOdbitakPage.SetColumnSpan(this.grdLevelRADNIKOdbitak, 1);
            this.layoutManagerOsobniOdbitakPage.SetRowSpan(this.grdLevelRADNIKOdbitak, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKOdbitak.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKOdbitak.MinimumSize = size;
            size = new System.Drawing.Size(0x1c6, 200);
            this.grdLevelRADNIKOdbitak.Size = size;
            this.grdLevelRADNIKOdbitak.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKOdbitak.Location = point;
            this.panelactionsRADNIKOdbitak.Name = "panelactionsRADNIKOdbitak";
            this.panelactionsRADNIKOdbitak.BackColor = Color.Transparent;
            this.panelactionsRADNIKOdbitak.Controls.Add(this.layoutManagerpanelactionsRADNIKOdbitak);
            this.layoutManagerOsobniOdbitakPage.Controls.Add(this.panelactionsRADNIKOdbitak, 0, 1);
            this.layoutManagerOsobniOdbitakPage.SetColumnSpan(this.panelactionsRADNIKOdbitak, 1);
            this.layoutManagerOsobniOdbitakPage.SetRowSpan(this.panelactionsRADNIKOdbitak, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKOdbitak.Margin = padding;
            size = new System.Drawing.Size(0x20a, 0x19);
            this.panelactionsRADNIKOdbitak.MinimumSize = size;
            size = new System.Drawing.Size(0x20a, 0x19);
            this.panelactionsRADNIKOdbitak.Size = size;
            this.panelactionsRADNIKOdbitak.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOdbitakAdd.Location = point;
            this.linkLabelRADNIKOdbitakAdd.Name = "linkLabelRADNIKOdbitakAdd";
            size = new System.Drawing.Size(150, 15);
            this.linkLabelRADNIKOdbitakAdd.Size = size;
            this.linkLabelRADNIKOdbitakAdd.Text = " Add Osobni odbici radnika  ";
            this.linkLabelRADNIKOdbitakAdd.Click += new EventHandler(this.RADNIKOdbitakAdd_Click);
            this.linkLabelRADNIKOdbitakAdd.BackColor = Color.Transparent;
            this.linkLabelRADNIKOdbitakAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKOdbitakAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKOdbitakAdd.Cursor = Cursors.Hand;
            this.linkLabelRADNIKOdbitakAdd.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOdbitak.Controls.Add(this.linkLabelRADNIKOdbitakAdd, 0, 0);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetColumnSpan(this.linkLabelRADNIKOdbitakAdd, 1);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetRowSpan(this.linkLabelRADNIKOdbitakAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOdbitakAdd.Margin = padding;
            size = new System.Drawing.Size(150, 15);
            this.linkLabelRADNIKOdbitakAdd.MinimumSize = size;
            size = new System.Drawing.Size(150, 15);
            this.linkLabelRADNIKOdbitakAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOdbitakUpdate.Location = point;
            this.linkLabelRADNIKOdbitakUpdate.Name = "linkLabelRADNIKOdbitakUpdate";
            size = new System.Drawing.Size(0xa8, 15);
            this.linkLabelRADNIKOdbitakUpdate.Size = size;
            this.linkLabelRADNIKOdbitakUpdate.Text = " Update Osobni odbici radnika  ";
            this.linkLabelRADNIKOdbitakUpdate.Click += new EventHandler(this.RADNIKOdbitakUpdate_Click);
            this.linkLabelRADNIKOdbitakUpdate.BackColor = Color.Transparent;
            this.linkLabelRADNIKOdbitakUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKOdbitakUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKOdbitakUpdate.Cursor = Cursors.Hand;
            this.linkLabelRADNIKOdbitakUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOdbitak.Controls.Add(this.linkLabelRADNIKOdbitakUpdate, 1, 0);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetColumnSpan(this.linkLabelRADNIKOdbitakUpdate, 1);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetRowSpan(this.linkLabelRADNIKOdbitakUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOdbitakUpdate.Margin = padding;
            size = new System.Drawing.Size(0xa8, 15);
            this.linkLabelRADNIKOdbitakUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0xa8, 15);
            this.linkLabelRADNIKOdbitakUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOdbitakDelete.Location = point;
            this.linkLabelRADNIKOdbitakDelete.Name = "linkLabelRADNIKOdbitakDelete";
            size = new System.Drawing.Size(0xa4, 15);
            this.linkLabelRADNIKOdbitakDelete.Size = size;
            this.linkLabelRADNIKOdbitakDelete.Text = " Delete Osobni odbici radnika  ";
            this.linkLabelRADNIKOdbitakDelete.Click += new EventHandler(this.RADNIKOdbitakDelete_Click);
            this.linkLabelRADNIKOdbitakDelete.BackColor = Color.Transparent;
            this.linkLabelRADNIKOdbitakDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKOdbitakDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKOdbitakDelete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKOdbitakDelete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOdbitak.Controls.Add(this.linkLabelRADNIKOdbitakDelete, 2, 0);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetColumnSpan(this.linkLabelRADNIKOdbitakDelete, 1);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetRowSpan(this.linkLabelRADNIKOdbitakDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOdbitakDelete.Margin = padding;
            size = new System.Drawing.Size(0xa4, 15);
            this.linkLabelRADNIKOdbitakDelete.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 15);
            this.linkLabelRADNIKOdbitakDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOdbitak.Location = point;
            this.linkLabelRADNIKOdbitak.Name = "linkLabelRADNIKOdbitak";
            this.layoutManagerpanelactionsRADNIKOdbitak.Controls.Add(this.linkLabelRADNIKOdbitak, 3, 0);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetColumnSpan(this.linkLabelRADNIKOdbitak, 1);
            this.layoutManagerpanelactionsRADNIKOdbitak.SetRowSpan(this.linkLabelRADNIKOdbitak, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOdbitak.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKOdbitak.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKOdbitak.Size = size;
            this.linkLabelRADNIKOdbitak.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.RADNIKLevel4Page.Location = point;
            this.RADNIKLevel4Page.Name = "RADNIKLevel4Page";
            tab4.TabPage = this.RADNIKLevel4Page;
            tab4.Text = "Olakšice radnika";
            this.RADNIKLevel4Page.Controls.Add(this.layoutManagerRADNIKLevel4Page);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKOlaksica.Location = point;
            this.grdLevelRADNIKOlaksica.Name = "grdLevelRADNIKOlaksica";
            this.layoutManagerRADNIKLevel4Page.Controls.Add(this.grdLevelRADNIKOlaksica, 0, 0);
            this.layoutManagerRADNIKLevel4Page.SetColumnSpan(this.grdLevelRADNIKOlaksica, 1);
            this.layoutManagerRADNIKLevel4Page.SetRowSpan(this.grdLevelRADNIKOlaksica, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKOlaksica.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKOlaksica.MinimumSize = size;
            size = new System.Drawing.Size(0x211, 200);
            this.grdLevelRADNIKOlaksica.Size = size;
            this.grdLevelRADNIKOlaksica.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKOlaksica.Location = point;
            this.panelactionsRADNIKOlaksica.Name = "panelactionsRADNIKOlaksica";
            this.panelactionsRADNIKOlaksica.BackColor = Color.Transparent;
            this.panelactionsRADNIKOlaksica.Controls.Add(this.layoutManagerpanelactionsRADNIKOlaksica);
            this.layoutManagerRADNIKLevel4Page.Controls.Add(this.panelactionsRADNIKOlaksica, 0, 1);
            this.layoutManagerRADNIKLevel4Page.SetColumnSpan(this.panelactionsRADNIKOlaksica, 1);
            this.layoutManagerRADNIKLevel4Page.SetRowSpan(this.panelactionsRADNIKOlaksica, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKOlaksica.Margin = padding;
            size = new System.Drawing.Size(0x132, 0x19);
            this.panelactionsRADNIKOlaksica.MinimumSize = size;
            size = new System.Drawing.Size(0x132, 0x19);
            this.panelactionsRADNIKOlaksica.Size = size;
            this.panelactionsRADNIKOlaksica.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOlaksicaAdd.Location = point;
            this.linkLabelRADNIKOlaksicaAdd.Name = "linkLabelRADNIKOlaksicaAdd";
            size = new System.Drawing.Size(0x4e, 15);
            this.linkLabelRADNIKOlaksicaAdd.Size = size;
            this.linkLabelRADNIKOlaksicaAdd.Text = " Add Olakšice  ";
            this.linkLabelRADNIKOlaksicaAdd.Click += new EventHandler(this.RADNIKOlaksicaAdd_Click);
            this.linkLabelRADNIKOlaksicaAdd.BackColor = Color.Transparent;
            this.linkLabelRADNIKOlaksicaAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKOlaksicaAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKOlaksicaAdd.Cursor = Cursors.Hand;
            this.linkLabelRADNIKOlaksicaAdd.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOlaksica.Controls.Add(this.linkLabelRADNIKOlaksicaAdd, 0, 0);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetColumnSpan(this.linkLabelRADNIKOlaksicaAdd, 1);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetRowSpan(this.linkLabelRADNIKOlaksicaAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOlaksicaAdd.Margin = padding;
            size = new System.Drawing.Size(0x4e, 15);
            this.linkLabelRADNIKOlaksicaAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x4e, 15);
            this.linkLabelRADNIKOlaksicaAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOlaksicaUpdate.Location = point;
            this.linkLabelRADNIKOlaksicaUpdate.Name = "linkLabelRADNIKOlaksicaUpdate";
            size = new System.Drawing.Size(0x60, 15);
            this.linkLabelRADNIKOlaksicaUpdate.Size = size;
            this.linkLabelRADNIKOlaksicaUpdate.Text = " Update Olakšice  ";
            this.linkLabelRADNIKOlaksicaUpdate.Click += new EventHandler(this.RADNIKOlaksicaUpdate_Click);
            this.linkLabelRADNIKOlaksicaUpdate.BackColor = Color.Transparent;
            this.linkLabelRADNIKOlaksicaUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKOlaksicaUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKOlaksicaUpdate.Cursor = Cursors.Hand;
            this.linkLabelRADNIKOlaksicaUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOlaksica.Controls.Add(this.linkLabelRADNIKOlaksicaUpdate, 1, 0);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetColumnSpan(this.linkLabelRADNIKOlaksicaUpdate, 1);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetRowSpan(this.linkLabelRADNIKOlaksicaUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOlaksicaUpdate.Margin = padding;
            size = new System.Drawing.Size(0x60, 15);
            this.linkLabelRADNIKOlaksicaUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 15);
            this.linkLabelRADNIKOlaksicaUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOlaksicaDelete.Location = point;
            this.linkLabelRADNIKOlaksicaDelete.Name = "linkLabelRADNIKOlaksicaDelete";
            size = new System.Drawing.Size(0x5c, 15);
            this.linkLabelRADNIKOlaksicaDelete.Size = size;
            this.linkLabelRADNIKOlaksicaDelete.Text = " Delete Olakšice  ";
            this.linkLabelRADNIKOlaksicaDelete.Click += new EventHandler(this.RADNIKOlaksicaDelete_Click);
            this.linkLabelRADNIKOlaksicaDelete.BackColor = Color.Transparent;
            this.linkLabelRADNIKOlaksicaDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKOlaksicaDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKOlaksicaDelete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKOlaksicaDelete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKOlaksica.Controls.Add(this.linkLabelRADNIKOlaksicaDelete, 2, 0);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetColumnSpan(this.linkLabelRADNIKOlaksicaDelete, 1);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetRowSpan(this.linkLabelRADNIKOlaksicaDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOlaksicaDelete.Margin = padding;
            size = new System.Drawing.Size(0x5c, 15);
            this.linkLabelRADNIKOlaksicaDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 15);
            this.linkLabelRADNIKOlaksicaDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKOlaksica.Location = point;
            this.linkLabelRADNIKOlaksica.Name = "linkLabelRADNIKOlaksica";
            this.layoutManagerpanelactionsRADNIKOlaksica.Controls.Add(this.linkLabelRADNIKOlaksica, 3, 0);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetColumnSpan(this.linkLabelRADNIKOlaksica, 1);
            this.layoutManagerpanelactionsRADNIKOlaksica.SetRowSpan(this.linkLabelRADNIKOlaksica, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKOlaksica.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKOlaksica.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKOlaksica.Size = size;
            this.linkLabelRADNIKOlaksica.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage7.Location = point;
            this.TabPage7.Name = "TabPage7";
            tab12.TabPage = this.TabPage7;
            tab12.Text = "Dodatni koeficijenti";
            this.TabPage7.Controls.Add(this.layoutManagerTabPage7);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKLevel7.Location = point;
            this.grdLevelRADNIKLevel7.Name = "grdLevelRADNIKLevel7";
            this.layoutManagerTabPage7.Controls.Add(this.grdLevelRADNIKLevel7, 0, 0);
            this.layoutManagerTabPage7.SetColumnSpan(this.grdLevelRADNIKLevel7, 1);
            this.layoutManagerTabPage7.SetRowSpan(this.grdLevelRADNIKLevel7, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKLevel7.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKLevel7.MinimumSize = size;
            size = new System.Drawing.Size(0x1ee, 200);
            this.grdLevelRADNIKLevel7.Size = size;
            this.grdLevelRADNIKLevel7.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKLevel7.Location = point;
            this.panelactionsRADNIKLevel7.Name = "panelactionsRADNIKLevel7";
            this.panelactionsRADNIKLevel7.BackColor = Color.Transparent;
            this.panelactionsRADNIKLevel7.Controls.Add(this.layoutManagerpanelactionsRADNIKLevel7);
            this.layoutManagerTabPage7.Controls.Add(this.panelactionsRADNIKLevel7, 0, 1);
            this.layoutManagerTabPage7.SetColumnSpan(this.panelactionsRADNIKLevel7, 1);
            this.layoutManagerTabPage7.SetRowSpan(this.panelactionsRADNIKLevel7, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKLevel7.Margin = padding;
            size = new System.Drawing.Size(0x15f, 0x19);
            this.panelactionsRADNIKLevel7.MinimumSize = size;
            size = new System.Drawing.Size(0x15f, 0x19);
            this.panelactionsRADNIKLevel7.Size = size;
            this.panelactionsRADNIKLevel7.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKLevel7Add.Location = point;
            this.linkLabelRADNIKLevel7Add.Name = "linkLabelRADNIKLevel7Add";
            size = new System.Drawing.Size(0x5d, 15);
            this.linkLabelRADNIKLevel7Add.Size = size;
            this.linkLabelRADNIKLevel7Add.Text = " Add Koeficijenti  ";
            this.linkLabelRADNIKLevel7Add.Click += new EventHandler(this.RADNIKLevel7Add_Click);
            this.linkLabelRADNIKLevel7Add.BackColor = Color.Transparent;
            this.linkLabelRADNIKLevel7Add.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKLevel7Add.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKLevel7Add.Cursor = Cursors.Hand;
            this.linkLabelRADNIKLevel7Add.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKLevel7.Controls.Add(this.linkLabelRADNIKLevel7Add, 0, 0);
            this.layoutManagerpanelactionsRADNIKLevel7.SetColumnSpan(this.linkLabelRADNIKLevel7Add, 1);
            this.layoutManagerpanelactionsRADNIKLevel7.SetRowSpan(this.linkLabelRADNIKLevel7Add, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKLevel7Add.Margin = padding;
            size = new System.Drawing.Size(0x5d, 15);
            this.linkLabelRADNIKLevel7Add.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 15);
            this.linkLabelRADNIKLevel7Add.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKLevel7Update.Location = point;
            this.linkLabelRADNIKLevel7Update.Name = "linkLabelRADNIKLevel7Update";
            size = new System.Drawing.Size(0x6f, 15);
            this.linkLabelRADNIKLevel7Update.Size = size;
            this.linkLabelRADNIKLevel7Update.Text = " Update Koeficijenti  ";
            this.linkLabelRADNIKLevel7Update.Click += new EventHandler(this.RADNIKLevel7Update_Click);
            this.linkLabelRADNIKLevel7Update.BackColor = Color.Transparent;
            this.linkLabelRADNIKLevel7Update.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKLevel7Update.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKLevel7Update.Cursor = Cursors.Hand;
            this.linkLabelRADNIKLevel7Update.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKLevel7.Controls.Add(this.linkLabelRADNIKLevel7Update, 1, 0);
            this.layoutManagerpanelactionsRADNIKLevel7.SetColumnSpan(this.linkLabelRADNIKLevel7Update, 1);
            this.layoutManagerpanelactionsRADNIKLevel7.SetRowSpan(this.linkLabelRADNIKLevel7Update, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKLevel7Update.Margin = padding;
            size = new System.Drawing.Size(0x6f, 15);
            this.linkLabelRADNIKLevel7Update.MinimumSize = size;
            size = new System.Drawing.Size(0x6f, 15);
            this.linkLabelRADNIKLevel7Update.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKLevel7Delete.Location = point;
            this.linkLabelRADNIKLevel7Delete.Name = "linkLabelRADNIKLevel7Delete";
            size = new System.Drawing.Size(0x6b, 15);
            this.linkLabelRADNIKLevel7Delete.Size = size;
            this.linkLabelRADNIKLevel7Delete.Text = " Delete Koeficijenti  ";
            this.linkLabelRADNIKLevel7Delete.Click += new EventHandler(this.RADNIKLevel7Delete_Click);
            this.linkLabelRADNIKLevel7Delete.BackColor = Color.Transparent;
            this.linkLabelRADNIKLevel7Delete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKLevel7Delete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKLevel7Delete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKLevel7Delete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKLevel7.Controls.Add(this.linkLabelRADNIKLevel7Delete, 2, 0);
            this.layoutManagerpanelactionsRADNIKLevel7.SetColumnSpan(this.linkLabelRADNIKLevel7Delete, 1);
            this.layoutManagerpanelactionsRADNIKLevel7.SetRowSpan(this.linkLabelRADNIKLevel7Delete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKLevel7Delete.Margin = padding;
            size = new System.Drawing.Size(0x6b, 15);
            this.linkLabelRADNIKLevel7Delete.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 15);
            this.linkLabelRADNIKLevel7Delete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKLevel7.Location = point;
            this.linkLabelRADNIKLevel7.Name = "linkLabelRADNIKLevel7";
            this.layoutManagerpanelactionsRADNIKLevel7.Controls.Add(this.linkLabelRADNIKLevel7, 3, 0);
            this.layoutManagerpanelactionsRADNIKLevel7.SetColumnSpan(this.linkLabelRADNIKLevel7, 1);
            this.layoutManagerpanelactionsRADNIKLevel7.SetRowSpan(this.linkLabelRADNIKLevel7, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKLevel7.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKLevel7.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKLevel7.Size = size;
            this.linkLabelRADNIKLevel7.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage10.Location = point;
            this.TabPage10.Name = "TabPage10";
            tab6.TabPage = this.TabPage10;
            tab6.Text = "Izuzeto iz ovrhe";
            this.TabPage10.Controls.Add(this.layoutManagerTabPage10);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRADNIKIzuzeceOdOvrhe.Location = point;
            this.grdLevelRADNIKIzuzeceOdOvrhe.Name = "grdLevelRADNIKIzuzeceOdOvrhe";
            this.layoutManagerTabPage10.Controls.Add(this.grdLevelRADNIKIzuzeceOdOvrhe, 0, 0);
            this.layoutManagerTabPage10.SetColumnSpan(this.grdLevelRADNIKIzuzeceOdOvrhe, 1);
            this.layoutManagerTabPage10.SetRowSpan(this.grdLevelRADNIKIzuzeceOdOvrhe, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRADNIKIzuzeceOdOvrhe.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRADNIKIzuzeceOdOvrhe.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelRADNIKIzuzeceOdOvrhe.Size = size;
            this.grdLevelRADNIKIzuzeceOdOvrhe.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRADNIKIzuzeceOdOvrhe.Location = point;
            this.panelactionsRADNIKIzuzeceOdOvrhe.Name = "panelactionsRADNIKIzuzeceOdOvrhe";
            this.panelactionsRADNIKIzuzeceOdOvrhe.BackColor = Color.Transparent;
            this.panelactionsRADNIKIzuzeceOdOvrhe.Controls.Add(this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe);
            this.layoutManagerTabPage10.Controls.Add(this.panelactionsRADNIKIzuzeceOdOvrhe, 0, 1);
            this.layoutManagerTabPage10.SetColumnSpan(this.panelactionsRADNIKIzuzeceOdOvrhe, 1);
            this.layoutManagerTabPage10.SetRowSpan(this.panelactionsRADNIKIzuzeceOdOvrhe, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRADNIKIzuzeceOdOvrhe.Margin = padding;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsRADNIKIzuzeceOdOvrhe.MinimumSize = size;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsRADNIKIzuzeceOdOvrhe.Size = size;
            this.panelactionsRADNIKIzuzeceOdOvrhe.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Location = point;
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Name = "linkLabelRADNIKIzuzeceOdOvrheAdd";
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Size = size;
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Text = " Add IzuzeceOdOvrhe  ";
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Click += new EventHandler(this.RADNIKIzuzeceOdOvrheAdd_Click);
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.BackColor = Color.Transparent;
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Cursor = Cursors.Hand;
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.Controls.Add(this.linkLabelRADNIKIzuzeceOdOvrheAdd, 0, 0);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.linkLabelRADNIKIzuzeceOdOvrheAdd, 1);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetRowSpan(this.linkLabelRADNIKIzuzeceOdOvrheAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Margin = padding;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Location = point;
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Name = "linkLabelRADNIKIzuzeceOdOvrheUpdate";
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Size = size;
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Text = " Update IzuzeceOdOvrhe  ";
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Click += new EventHandler(this.RADNIKIzuzeceOdOvrheUpdate_Click);
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.BackColor = Color.Transparent;
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Cursor = Cursors.Hand;
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.Controls.Add(this.linkLabelRADNIKIzuzeceOdOvrheUpdate, 1, 0);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.linkLabelRADNIKIzuzeceOdOvrheUpdate, 1);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetRowSpan(this.linkLabelRADNIKIzuzeceOdOvrheUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Margin = padding;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Location = point;
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Name = "linkLabelRADNIKIzuzeceOdOvrheDelete";
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Size = size;
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Text = " Delete IzuzeceOdOvrhe  ";
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Click += new EventHandler(this.RADNIKIzuzeceOdOvrheDelete_Click);
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.BackColor = Color.Transparent;
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Cursor = Cursors.Hand;
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.AutoSize = true;
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.Controls.Add(this.linkLabelRADNIKIzuzeceOdOvrheDelete, 2, 0);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.linkLabelRADNIKIzuzeceOdOvrheDelete, 1);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetRowSpan(this.linkLabelRADNIKIzuzeceOdOvrheDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Margin = padding;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRADNIKIzuzeceOdOvrhe.Location = point;
            this.linkLabelRADNIKIzuzeceOdOvrhe.Name = "linkLabelRADNIKIzuzeceOdOvrhe";
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.Controls.Add(this.linkLabelRADNIKIzuzeceOdOvrhe, 3, 0);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetColumnSpan(this.linkLabelRADNIKIzuzeceOdOvrhe, 1);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.SetRowSpan(this.linkLabelRADNIKIzuzeceOdOvrhe, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRADNIKIzuzeceOdOvrhe.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKIzuzeceOdOvrhe.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRADNIKIzuzeceOdOvrhe.Size = size;
            this.linkLabelRADNIKIzuzeceOdOvrhe.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformRADNIK);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIK;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column9.Width = 0x69;
            appearance8.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance8;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RADNIKBRUTOELEMENTIDELEMENTDescription;
            column.Width = 0x48;
            column.Format = "";
            column.CellAppearance = appearance;
            column2.AllowGroupBy = DefaultableBoolean.False;
            column2.AutoSizeEdit = DefaultableBoolean.False;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column2.CellAppearance.BorderAlpha = Alpha.Transparent;
            column2.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column2.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column2.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column2.Header.Enabled = false;
            column2.Header.Fixed = true;
            column2.Header.Caption = "";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column2.Width = 20;
            column2.MinWidth = 20;
            column2.MaxWidth = 20;
            column2.Tag = "ELEMENTBRUTOELEMENTIDELEMENTAddNew";
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.RADNIKBRUTOELEMENTNAZIVELEMENTDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance2;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.RADNIKBRUTOSATNICADescription;
            column8.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column8.PromptChar = ' ';
            column8.Format = "F8";
            column8.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.RADNIKBRUTOSATIDescription;
            column7.Width = 0x37;
            appearance6.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.RADNIKBRUTOPOSTOTAKDescription;
            column6.Width = 0x4b;
            appearance5.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.RADNIKBRUTOIZNOSDescription;
            column5.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.RADNIKBRUTOELEMENTPOSTOTAKDescription;
            column4.Width = 0x37;
            appearance3.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance3;
            column4.Hidden = true;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 1;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 5;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 6;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 7;
            this.grdLevelRADNIKBruto.Visible = true;
            this.grdLevelRADNIKBruto.Name = "grdLevelRADNIKBruto";
            this.grdLevelRADNIKBruto.Tag = "RADNIKBruto";
            this.grdLevelRADNIKBruto.TabIndex = 0xd3;
            this.grdLevelRADNIKBruto.Dock = DockStyle.Fill;
            this.grdLevelRADNIKBruto.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKBruto.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKBruto.DataSource = this.bindingSourceRADNIKBruto;
            this.grdLevelRADNIKBruto.Enter += new EventHandler(this.grdLevelRADNIKBruto_Enter);
            this.grdLevelRADNIKBruto.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKBruto_AfterRowInsert);
            this.grdLevelRADNIKBruto.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKBruto.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKBruto.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKBruto.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKBruto_DoubleClick);
            this.grdLevelRADNIKBruto.AfterRowActivate += new EventHandler(this.grdLevelRADNIKBruto_AfterRowActivate);
            this.grdLevelRADNIKBruto.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKBruto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKBruto.DisplayLayout.BandsSerializer.Add(band);
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            column49.CellActivation = Activation.Disabled;
            column49.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column49.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column49.Width = 0x69;
            appearance47.TextHAlign = HAlign.Right;
            column49.MaskInput = "{LOC}-nnnnnnnn";
            column49.PromptChar = ' ';
            column49.Format = "";
            column49.CellAppearance = appearance47;
            column49.Hidden = true;
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            column50.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column50.Header.Caption = StringResources.RADNIKNETOELEMENTIDELEMENTDescription;
            column50.Width = 0x48;
            column50.Format = "";
            column50.CellAppearance = appearance48;
            column51.AllowGroupBy = DefaultableBoolean.False;
            column51.AutoSizeEdit = DefaultableBoolean.False;
            column51.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column51.CellAppearance.BorderAlpha = Alpha.Transparent;
            column51.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column51.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column51.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column51.Header.Enabled = false;
            column51.Header.Fixed = true;
            column51.Header.Caption = "";
            column51.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column51.Width = 20;
            column51.MinWidth = 20;
            column51.MaxWidth = 20;
            column51.Tag = "ELEMENTNETOELEMENTIDELEMENTAddNew";
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            column52.CellActivation = Activation.Disabled;
            column52.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column52.Header.Caption = StringResources.RADNIKNETOELEMENTNAZIVELEMENTDescription;
            column52.Width = 0x128;
            column52.Format = "";
            column52.CellAppearance = appearance49;
            column52.Hidden = true;
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            column56.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column56.Header.Caption = StringResources.RADNIKNETOSATNICADescription;
            column56.Width = 0x66;
            appearance53.TextHAlign = HAlign.Right;
            column56.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column56.PromptChar = ' ';
            column56.Format = "F8";
            column56.CellAppearance = appearance53;
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            column55.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column55.Header.Caption = StringResources.RADNIKNETOSATIDescription;
            column55.Width = 0x37;
            appearance52.TextHAlign = HAlign.Right;
            column55.MaskInput = "{LOC}-nnn.nn";
            column55.PromptChar = ' ';
            column55.Format = "F2";
            column55.CellAppearance = appearance52;
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            column54.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column54.Header.Caption = StringResources.RADNIKNETOPOSTOTAKDescription;
            column54.Width = 0x4b;
            appearance51.TextHAlign = HAlign.Right;
            column54.MaskInput = "{LOC}-nnn.nn";
            column54.PromptChar = ' ';
            column54.Format = "F2";
            column54.CellAppearance = appearance51;
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            column53.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column53.Header.Caption = StringResources.RADNIKNETOIZNOSDescription;
            column53.Width = 0x66;
            appearance50.TextHAlign = HAlign.Right;
            column53.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column53.PromptChar = ' ';
            column53.Format = "F2";
            column53.CellAppearance = appearance50;
            band5.Columns.Add(column50);
            column50.Header.VisiblePosition = 0;
            band5.Columns.Add(column56);
            column56.Header.VisiblePosition = 1;
            band5.Columns.Add(column55);
            column55.Header.VisiblePosition = 2;
            band5.Columns.Add(column54);
            column54.Header.VisiblePosition = 3;
            band5.Columns.Add(column53);
            column53.Header.VisiblePosition = 4;
            band5.Columns.Add(column49);
            column49.Header.VisiblePosition = 5;
            band5.Columns.Add(column52);
            column52.Header.VisiblePosition = 6;
            this.grdLevelRADNIKNeto.Visible = true;
            this.grdLevelRADNIKNeto.Name = "grdLevelRADNIKNeto";
            this.grdLevelRADNIKNeto.Tag = "RADNIKNeto";
            this.grdLevelRADNIKNeto.TabIndex = 0xd3;
            this.grdLevelRADNIKNeto.Dock = DockStyle.Fill;
            this.grdLevelRADNIKNeto.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKNeto.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKNeto.DataSource = this.bindingSourceRADNIKNeto;
            this.grdLevelRADNIKNeto.Enter += new EventHandler(this.grdLevelRADNIKNeto_Enter);
            this.grdLevelRADNIKNeto.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKNeto_AfterRowInsert);
            this.grdLevelRADNIKNeto.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKNeto.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKNeto.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKNeto.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKNeto_DoubleClick);
            this.grdLevelRADNIKNeto.AfterRowActivate += new EventHandler(this.grdLevelRADNIKNeto_AfterRowActivate);
            this.grdLevelRADNIKNeto.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKNeto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKNeto.DisplayLayout.BandsSerializer.Add(band5);
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            column57.CellActivation = Activation.Disabled;
            column57.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column57.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column57.Width = 0x69;
            appearance54.TextHAlign = HAlign.Right;
            column57.MaskInput = "{LOC}-nnnnnnnn";
            column57.PromptChar = ' ';
            column57.Format = "";
            column57.CellAppearance = appearance54;
            column57.Hidden = true;
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            column63.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column63.Header.Caption = StringResources.RADNIKZADOBUSTAVAIDOBUSTAVADescription;
            column63.Width = 0x48;
            appearance60.TextHAlign = HAlign.Right;
            column63.MaskInput = "{LOC}-nnnnnnnn";
            column63.PromptChar = ' ';
            column63.Format = "";
            column63.CellAppearance = appearance60;
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            column58.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column58.Header.Caption = StringResources.RADNIKOBUSTAVAAKTIVNADescription;
            column58.Width = 0x9c;
            column58.Format = "";
            column58.CellAppearance = appearance55;
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            column64.CellActivation = Activation.Disabled;
            column64.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column64.Header.Caption = StringResources.RADNIKZADOBUSTAVANAZIVOBUSTAVADescription;
            column64.Width = 0x128;
            column64.Format = "";
            column64.CellAppearance = appearance61;
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            column67.CellActivation = Activation.Disabled;
            column67.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column67.Header.Caption = StringResources.RADNIKZADOBUSTAVAVRSTAOBUSTAVEDescription;
            column67.Width = 0x33;
            appearance64.TextHAlign = HAlign.Right;
            column67.MaskInput = "{LOC}-nn";
            column67.PromptChar = ' ';
            column67.Format = "";
            column67.CellAppearance = appearance64;
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            column65.CellActivation = Activation.Disabled;
            column65.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column65.Header.Caption = StringResources.RADNIKZADOBUSTAVANAZIVVRSTAOBUSTAVEDescription;
            column65.Width = 0x128;
            column65.Format = "";
            column65.CellAppearance = appearance62;
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            column62.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column62.Header.Caption = StringResources.RADNIKZADIZNOSOBUSTAVEDescription;
            column62.Width = 0x74;
            appearance59.TextHAlign = HAlign.Right;
            column62.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column62.PromptChar = ' ';
            column62.Format = "F2";
            column62.CellAppearance = appearance59;
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            column69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column69.Header.Caption = StringResources.RADNIKZADPOSTOTAKOBUSTAVEDescription;
            column69.Width = 0x88;
            appearance66.TextHAlign = HAlign.Right;
            column69.MaskInput = "{LOC}-nnn.nn";
            column69.PromptChar = ' ';
            column69.Format = "F2";
            column69.CellAppearance = appearance66;
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            column70.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column70.Header.Caption = StringResources.RADNIKZADPOSTOTNAODBRUTADescription;
            column70.Width = 0xd4;
            column70.Format = "";
            column70.CellAppearance = appearance67;
            column70.Hidden = true;
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            column61.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column61.Header.Caption = StringResources.RADNIKZADISPLACENOKASADescription;
            column61.Width = 0x88;
            appearance58.TextHAlign = HAlign.Right;
            column61.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column61.PromptChar = ' ';
            column61.Format = "F2";
            column61.CellAppearance = appearance58;
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            column71.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column71.Header.Caption = StringResources.RADNIKZADSALDOKASADescription;
            column71.Width = 0xd9;
            appearance68.TextHAlign = HAlign.Right;
            column71.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column71.PromptChar = ' ';
            column71.Format = "F2";
            column71.CellAppearance = appearance68;
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            column60.CellActivation = Activation.Disabled;
            column60.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column60.Header.Caption = StringResources.RADNIKOTPLACENIIZNOSDescription;
            column60.Width = 0xb7;
            appearance57.TextHAlign = HAlign.Right;
            column60.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column60.PromptChar = ' ';
            column60.Format = "F2";
            column60.CellAppearance = appearance57;
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            column59.CellActivation = Activation.Disabled;
            column59.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column59.Header.Caption = StringResources.RADNIKOTPLACENIBROJRATADescription;
            column59.Width = 0xb1;
            appearance56.TextHAlign = HAlign.Right;
            column59.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column59.PromptChar = ' ';
            column59.Format = "F2";
            column59.CellAppearance = appearance56;
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            column68.CellActivation = Activation.Disabled;
            column68.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column68.Header.Caption = StringResources.RADNIKZADOBUSTAVAZRNOBUSTAVADescription;
            column68.Width = 0xbf;
            column68.Format = "";
            column68.CellAppearance = appearance65;
            column68.Hidden = true;
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            column66.CellActivation = Activation.Disabled;
            column66.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column66.Header.Caption = StringResources.RADNIKZADOBUSTAVAVBDIOBUSTAVADescription;
            column66.Width = 0xbf;
            column66.Format = "";
            column66.CellAppearance = appearance63;
            column66.Hidden = true;
            band6.Columns.Add(column63);
            column63.Header.VisiblePosition = 0;
            band6.Columns.Add(column64);
            column64.Header.VisiblePosition = 1;
            band6.Columns.Add(column60);
            column60.Header.VisiblePosition = 2;
            band6.Columns.Add(column59);
            column59.Header.VisiblePosition = 3;
            band6.Columns.Add(column67);
            column67.Header.VisiblePosition = 4;
            band6.Columns.Add(column65);
            column65.Header.VisiblePosition = 5;
            band6.Columns.Add(column62);
            column62.Header.VisiblePosition = 6;
            band6.Columns.Add(column69);
            column69.Header.VisiblePosition = 7;
            band6.Columns.Add(column61);
            column61.Header.VisiblePosition = 8;
            band6.Columns.Add(column71);
            column71.Header.VisiblePosition = 9;
            band6.Columns.Add(column58);
            column58.Header.VisiblePosition = 10;
            band6.Columns.Add(column57);
            column57.Header.VisiblePosition = 11;
            band6.Columns.Add(column70);
            column70.Header.VisiblePosition = 12;
            band6.Columns.Add(column68);
            column68.Header.VisiblePosition = 13;
            band6.Columns.Add(column66);
            column66.Header.VisiblePosition = 14;
            this.grdLevelRADNIKObustava.Visible = true;
            this.grdLevelRADNIKObustava.Name = "grdLevelRADNIKObustava";
            this.grdLevelRADNIKObustava.Tag = "RADNIKObustava";
            this.grdLevelRADNIKObustava.TabIndex = 0xd3;
            this.grdLevelRADNIKObustava.Dock = DockStyle.Fill;
            this.grdLevelRADNIKObustava.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKObustava.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKObustava.DataSource = this.bindingSourceRADNIKObustava;
            this.grdLevelRADNIKObustava.Enter += new EventHandler(this.grdLevelRADNIKObustava_Enter);
            this.grdLevelRADNIKObustava.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKObustava_AfterRowInsert);
            this.grdLevelRADNIKObustava.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKObustava.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKObustava.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKObustava.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKObustava_DoubleClick);
            this.grdLevelRADNIKObustava.AfterRowActivate += new EventHandler(this.grdLevelRADNIKObustava_AfterRowActivate);
            this.grdLevelRADNIKObustava.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKObustava.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKObustava.DisplayLayout.BandsSerializer.Add(band6);
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.Disabled;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column21.Width = 0x69;
            appearance20.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnn";
            column21.PromptChar = ' ';
            column21.Format = "";
            column21.CellAppearance = appearance20;
            column21.Hidden = true;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.RADNIKZADKREDITIIDKREDITORDescription;
            column34.Width = 0x48;
            appearance33.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnnnnnn";
            column34.PromptChar = ' ';
            column34.Format = "";
            column34.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.RADNIKDATUMUGOVORADescription;
            column20.Width = 100;
            column20.MinValue = DateTime.MinValue;
            column20.MaxValue = DateTime.MaxValue;
            column20.Format = "d";
            column20.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.RADNIKKREDITAKTIVANDescription;
            column22.Width = 0x8e;
            column22.Format = "";
            column22.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.Disabled;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.RADNIKZADKREDITINAZIVKREDITORDescription;
            column35.Width = 0x9c;
            column35.Format = "";
            column35.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.Disabled;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR1Description;
            column36.Width = 0xa3;
            column36.Format = "";
            column36.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column37.CellActivation = Activation.Disabled;
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR2Description;
            column37.Width = 0xa3;
            column37.Format = "";
            column37.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column38.CellActivation = Activation.Disabled;
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR3Description;
            column38.Width = 0xa3;
            column38.Format = "";
            column38.CellAppearance = appearance37;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.RADNIKSIFRAOPISAPLACANJAKREDITORDescription;
            column31.Width = 0x9c;
            column31.Format = "";
            column31.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.RADNIKOPISPLACANJAKREDITORDescription;
            column27.Width = 0x10c;
            column27.Format = "";
            column27.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.RADNIKMOKREDITORDescription;
            column25.Width = 0x79;
            column25.Format = "";
            column25.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.RADNIKPOKREDITORDescription;
            column29.Width = 0xb1;
            column29.Format = "";
            column29.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.RADNIKMZKREDITORDescription;
            column26.Width = 0x79;
            column26.Format = "";
            column26.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.RADNIKPZKREDITORDescription;
            column30.Width = 0xb1;
            column30.Format = "";
            column30.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.RADNIKZADIZNOSRATEKREDITADescription;
            column33.Width = 0x8f;
            appearance32.TextHAlign = HAlign.Right;
            column33.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column33.PromptChar = ' ';
            column33.Format = "F2";
            column33.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.RADNIKZADBROJRATAOBUSTAVEDescription;
            column32.Width = 0x88;
            appearance31.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.RADNIKZADUKUPNIZNOSKREDITADescription;
            column41.Width = 0x9c;
            appearance40.TextHAlign = HAlign.Right;
            column41.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column41.PromptChar = ' ';
            column41.Format = "F2";
            column41.CellAppearance = appearance40;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.RADNIKZADVECOTPLACENOBROJRATADescription;
            column42.Width = 0x123;
            appearance41.TextHAlign = HAlign.Right;
            column42.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column42.PromptChar = ' ';
            column42.Format = "F2";
            column42.CellAppearance = appearance41;
            column42.Hidden = true;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.Header.Caption = StringResources.RADNIKZADVECOTPLACENOUKUPNIIZNOSDescription;
            column43.Width = 0x123;
            appearance42.TextHAlign = HAlign.Right;
            column43.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column43.PromptChar = ' ';
            column43.Format = "F2";
            column43.CellAppearance = appearance42;
            column43.Hidden = true;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.Disabled;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.RADNIKKREDITOTPLACENIIZNOSDescription;
            column23.Width = 0xb7;
            appearance22.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.Disabled;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.RADNIKKREDITOTPLACENORATADescription;
            column24.Width = 210;
            appearance23.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column39.CellActivation = Activation.Disabled;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.RADNIKZADKREDITIVBDIKREDITORDescription;
            column39.Width = 100;
            column39.Format = "";
            column39.CellAppearance = appearance38;
            column39.Hidden = true;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column40.CellActivation = Activation.Disabled;
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.RADNIKZADKREDITIZRNKREDITORDescription;
            column40.Width = 0x5d;
            column40.Format = "";
            column40.CellAppearance = appearance39;
            column40.Hidden = true;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.RADNIKPARTIJAKREDITASPECIFIKACIJADescription;
            column28.Width = 240;
            column28.Format = "";
            column28.CellAppearance = appearance27;
            column28.Hidden = true;
            band3.Columns.Add(column34);
            column34.Header.VisiblePosition = 0;
            band3.Columns.Add(column35);
            column35.Header.VisiblePosition = 1;
            band3.Columns.Add(column41);
            column41.Header.VisiblePosition = 2;
            band3.Columns.Add(column22);
            column22.Header.VisiblePosition = 3;
            band3.Columns.Add(column23);
            column23.Header.VisiblePosition = 4;
            band3.Columns.Add(column24);
            column24.Header.VisiblePosition = 5;
            band3.Columns.Add(column31);
            column31.Header.VisiblePosition = 6;
            band3.Columns.Add(column27);
            column27.Header.VisiblePosition = 7;
            band3.Columns.Add(column33);
            column33.Header.VisiblePosition = 8;
            band3.Columns.Add(column32);
            column32.Header.VisiblePosition = 9;
            band3.Columns.Add(column36);
            column36.Header.VisiblePosition = 10;
            band3.Columns.Add(column37);
            column37.Header.VisiblePosition = 11;
            band3.Columns.Add(column38);
            column38.Header.VisiblePosition = 12;
            band3.Columns.Add(column25);
            column25.Header.VisiblePosition = 13;
            band3.Columns.Add(column29);
            column29.Header.VisiblePosition = 14;
            band3.Columns.Add(column26);
            column26.Header.VisiblePosition = 15;
            band3.Columns.Add(column30);
            column30.Header.VisiblePosition = 0x10;
            band3.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x11;
            band3.Columns.Add(column21);
            column21.Header.VisiblePosition = 0x12;
            band3.Columns.Add(column42);
            column42.Header.VisiblePosition = 0x13;
            band3.Columns.Add(column43);
            column43.Header.VisiblePosition = 20;
            band3.Columns.Add(column39);
            column39.Header.VisiblePosition = 0x15;
            band3.Columns.Add(column40);
            column40.Header.VisiblePosition = 0x16;
            band3.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x17;
            this.grdLevelRADNIKKrediti.Visible = true;
            this.grdLevelRADNIKKrediti.Name = "grdLevelRADNIKKrediti";
            this.grdLevelRADNIKKrediti.Tag = "RADNIKKrediti";
            this.grdLevelRADNIKKrediti.TabIndex = 0xd3;
            this.grdLevelRADNIKKrediti.Dock = DockStyle.Fill;
            this.grdLevelRADNIKKrediti.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKKrediti.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKKrediti.DataSource = this.bindingSourceRADNIKKrediti;
            this.grdLevelRADNIKKrediti.Enter += new EventHandler(this.grdLevelRADNIKKrediti_Enter);
            this.grdLevelRADNIKKrediti.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKKrediti_AfterRowInsert);
            this.grdLevelRADNIKKrediti.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKKrediti.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKKrediti.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKKrediti.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKKrediti_DoubleClick);
            this.grdLevelRADNIKKrediti.AfterRowActivate += new EventHandler(this.grdLevelRADNIKKrediti_AfterRowActivate);
            this.grdLevelRADNIKKrediti.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKKrediti.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKKrediti.DisplayLayout.BandsSerializer.Add(band3);
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            column73.CellActivation = Activation.Disabled;
            column73.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column73.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column73.Width = 0x69;
            appearance70.TextHAlign = HAlign.Right;
            column73.MaskInput = "{LOC}-nnnnnnnn";
            column73.PromptChar = ' ';
            column73.Format = "";
            column73.CellAppearance = appearance70;
            column73.Hidden = true;
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            column75.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column75.Header.Caption = StringResources.RADNIKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKDescription;
            column75.Width = 0x33;
            appearance72.TextHAlign = HAlign.Right;
            column75.MaskInput = "{LOC}-nnnnn";
            column75.PromptChar = ' ';
            column75.Format = "";
            column75.CellAppearance = appearance72;
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            column74.CellActivation = Activation.Disabled;
            column74.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column74.Header.Caption = StringResources.RADNIKNAZIVOSOBNIODBITAKDescription;
            column74.Width = 0x128;
            column74.Format = "";
            column74.CellAppearance = appearance71;
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            column72.CellActivation = Activation.Disabled;
            column72.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column72.Header.Caption = StringResources.RADNIKFAKTOROSOBNOGODBITKADescription;
            column72.Width = 0x3e;
            appearance69.TextHAlign = HAlign.Right;
            column72.MaskInput = "{LOC}-nnn.nn";
            column72.PromptChar = ' ';
            column72.Format = "F2";
            column72.CellAppearance = appearance69;
            band7.Columns.Add(column75);
            column75.Header.VisiblePosition = 0;
            band7.Columns.Add(column74);
            column74.Header.VisiblePosition = 1;
            band7.Columns.Add(column72);
            column72.Header.VisiblePosition = 2;
            band7.Columns.Add(column73);
            column73.Header.VisiblePosition = 3;
            this.grdLevelRADNIKOdbitak.Visible = true;
            this.grdLevelRADNIKOdbitak.Name = "grdLevelRADNIKOdbitak";
            this.grdLevelRADNIKOdbitak.Tag = "RADNIKOdbitak";
            this.grdLevelRADNIKOdbitak.TabIndex = 0xd3;
            this.grdLevelRADNIKOdbitak.Dock = DockStyle.Fill;
            this.grdLevelRADNIKOdbitak.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKOdbitak.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKOdbitak.DataSource = this.bindingSourceRADNIKOdbitak;
            this.grdLevelRADNIKOdbitak.Enter += new EventHandler(this.grdLevelRADNIKOdbitak_Enter);
            this.grdLevelRADNIKOdbitak.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKOdbitak_AfterRowInsert);
            this.grdLevelRADNIKOdbitak.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKOdbitak.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKOdbitak.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKOdbitak.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKOdbitak_DoubleClick);
            this.grdLevelRADNIKOdbitak.AfterRowActivate += new EventHandler(this.grdLevelRADNIKOdbitak_AfterRowActivate);
            this.grdLevelRADNIKOdbitak.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKOdbitak.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKOdbitak.DisplayLayout.BandsSerializer.Add(band7);
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            column76.CellActivation = Activation.Disabled;
            column76.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column76.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column76.Width = 0x69;
            appearance73.TextHAlign = HAlign.Right;
            column76.MaskInput = "{LOC}-nnnnnnnn";
            column76.PromptChar = ' ';
            column76.Format = "";
            column76.CellAppearance = appearance73;
            column76.Hidden = true;
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            column81.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column81.Header.Caption = StringResources.RADNIKZADOLAKSICEIDOLAKSICEDescription;
            column81.Width = 0x48;
            appearance78.TextHAlign = HAlign.Right;
            column81.MaskInput = "{LOC}-nnnnnnnn";
            column81.PromptChar = ' ';
            column81.Format = "";
            column81.CellAppearance = appearance78;
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            column80.CellActivation = Activation.Disabled;
            column80.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column80.Header.Caption = StringResources.RADNIKZADOLAKSICEIDGRUPEOLAKSICADescription;
            column80.Width = 0x70;
            appearance77.TextHAlign = HAlign.Right;
            column80.MaskInput = "{LOC}-nnnnn";
            column80.PromptChar = ' ';
            column80.Format = "";
            column80.CellAppearance = appearance77;
            column80.Hidden = true;
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            column83.CellActivation = Activation.Disabled;
            column83.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column83.Header.Caption = StringResources.RADNIKZADOLAKSICEMAXIMALNIIZNOSGRUPEDescription;
            column83.Width = 150;
            appearance80.TextHAlign = HAlign.Right;
            column83.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column83.PromptChar = ' ';
            column83.Format = "F2";
            column83.CellAppearance = appearance80;
            column83.Hidden = true;
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            column84.CellActivation = Activation.Disabled;
            column84.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column84.Header.Caption = StringResources.RADNIKZADOLAKSICENAZIVGRUPEOLAKSICADescription;
            column84.Width = 0x128;
            column84.Format = "";
            column84.CellAppearance = appearance81;
            column84.Hidden = true;
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            column85.CellActivation = Activation.Disabled;
            column85.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column85.Header.Caption = StringResources.RADNIKZADOLAKSICENAZIVOLAKSICEDescription;
            column85.Width = 0x128;
            column85.Format = "";
            column85.CellAppearance = appearance82;
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            column82.CellActivation = Activation.Disabled;
            column82.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column82.Header.Caption = StringResources.RADNIKZADOLAKSICEIDTIPOLAKSICEDescription;
            column82.Width = 0x33;
            appearance79.TextHAlign = HAlign.Right;
            column82.MaskInput = "{LOC}-nnnnn";
            column82.PromptChar = ' ';
            column82.Format = "";
            column82.CellAppearance = appearance79;
            column82.Hidden = true;
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            column86.CellActivation = Activation.Disabled;
            column86.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column86.Header.Caption = StringResources.RADNIKZADOLAKSICENAZIVTIPOLAKSICEDescription;
            column86.Width = 0x128;
            column86.Format = "";
            column86.CellAppearance = appearance83;
            column86.Hidden = true;
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            column90.CellActivation = Activation.Disabled;
            column90.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column90.Header.Caption = StringResources.RADNIKZADOLAKSICEVBDIOLAKSICADescription;
            column90.Width = 0xbf;
            column90.Format = "";
            column90.CellAppearance = appearance87;
            column90.Hidden = true;
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            column91.CellActivation = Activation.Disabled;
            column91.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column91.Header.Caption = StringResources.RADNIKZADOLAKSICEZRNOLAKSICADescription;
            column91.Width = 0xbf;
            column91.Format = "";
            column91.CellAppearance = appearance88;
            column91.Hidden = true;
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            column87.CellActivation = Activation.Disabled;
            column87.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column87.Header.Caption = StringResources.RADNIKZADOLAKSICEPRIMATELJOLAKSICA1Description;
            column87.Width = 170;
            column87.Format = "";
            column87.CellAppearance = appearance84;
            column87.Hidden = true;
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            column88.CellActivation = Activation.Disabled;
            column88.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column88.Header.Caption = StringResources.RADNIKZADOLAKSICEPRIMATELJOLAKSICA2Description;
            column88.Width = 170;
            column88.Format = "";
            column88.CellAppearance = appearance85;
            column88.Hidden = true;
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            column89.CellActivation = Activation.Disabled;
            column89.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column89.Header.Caption = StringResources.RADNIKZADOLAKSICEPRIMATELJOLAKSICA3Description;
            column89.Width = 170;
            column89.Format = "";
            column89.CellAppearance = appearance86;
            column89.Hidden = true;
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            column79.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column79.Header.Caption = StringResources.RADNIKZADMZOLAKSICEDescription;
            column79.Width = 0x79;
            column79.Format = "";
            column79.CellAppearance = appearance76;
            column79.Hidden = true;
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            column95.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column95.Header.Caption = StringResources.RADNIKZADPZOLAKSICEDescription;
            column95.Width = 0xb1;
            column95.Format = "";
            column95.CellAppearance = appearance92;
            column95.Hidden = true;
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            column78.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column78.Header.Caption = StringResources.RADNIKZADMOOLAKSICEDescription;
            column78.Width = 0x79;
            column78.Format = "";
            column78.CellAppearance = appearance75;
            column78.Hidden = true;
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            column94.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column94.Header.Caption = StringResources.RADNIKZADPOOLAKSICEDescription;
            column94.Width = 0xb1;
            column94.Format = "";
            column94.CellAppearance = appearance91;
            column94.Hidden = true;
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            column96.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column96.Header.Caption = StringResources.RADNIKZADSIFRAOPISAPLACANJAOLAKSICEDescription;
            column96.Width = 0x9c;
            column96.Format = "";
            column96.CellAppearance = appearance93;
            column96.Hidden = true;
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            column92.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column92.Header.Caption = StringResources.RADNIKZADOPISPLACANJAOLAKSICEDescription;
            column92.Width = 0x10c;
            column92.Format = "";
            column92.CellAppearance = appearance89;
            column92.Hidden = true;
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            column77.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column77.Header.Caption = StringResources.RADNIKZADIZNOSOLAKSICEDescription;
            column77.Width = 0x74;
            appearance74.TextHAlign = HAlign.Right;
            column77.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column77.PromptChar = ' ';
            column77.Format = "F2";
            column77.CellAppearance = appearance74;
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            column93.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column93.Header.Caption = StringResources.RADNIKZADPOJEDINACNIPOZIVDescription;
            column93.Width = 0xd4;
            column93.Format = "";
            column93.CellAppearance = appearance90;
            column93.Hidden = true;
            band8.Columns.Add(column81);
            column81.Header.VisiblePosition = 0;
            band8.Columns.Add(column85);
            column85.Header.VisiblePosition = 1;
            band8.Columns.Add(column77);
            column77.Header.VisiblePosition = 2;
            band8.Columns.Add(column76);
            column76.Header.VisiblePosition = 3;
            band8.Columns.Add(column80);
            column80.Header.VisiblePosition = 4;
            band8.Columns.Add(column83);
            column83.Header.VisiblePosition = 5;
            band8.Columns.Add(column84);
            column84.Header.VisiblePosition = 6;
            band8.Columns.Add(column82);
            column82.Header.VisiblePosition = 7;
            band8.Columns.Add(column86);
            column86.Header.VisiblePosition = 8;
            band8.Columns.Add(column90);
            column90.Header.VisiblePosition = 9;
            band8.Columns.Add(column91);
            column91.Header.VisiblePosition = 10;
            band8.Columns.Add(column87);
            column87.Header.VisiblePosition = 11;
            band8.Columns.Add(column88);
            column88.Header.VisiblePosition = 12;
            band8.Columns.Add(column89);
            column89.Header.VisiblePosition = 13;
            band8.Columns.Add(column79);
            column79.Header.VisiblePosition = 14;
            band8.Columns.Add(column95);
            column95.Header.VisiblePosition = 15;
            band8.Columns.Add(column78);
            column78.Header.VisiblePosition = 0x10;
            band8.Columns.Add(column94);
            column94.Header.VisiblePosition = 0x11;
            band8.Columns.Add(column96);
            column96.Header.VisiblePosition = 0x12;
            band8.Columns.Add(column92);
            column92.Header.VisiblePosition = 0x13;
            band8.Columns.Add(column93);
            column93.Header.VisiblePosition = 20;
            this.grdLevelRADNIKOlaksica.Visible = true;
            this.grdLevelRADNIKOlaksica.Name = "grdLevelRADNIKOlaksica";
            this.grdLevelRADNIKOlaksica.Tag = "RADNIKOlaksica";
            this.grdLevelRADNIKOlaksica.TabIndex = 0xd3;
            this.grdLevelRADNIKOlaksica.Dock = DockStyle.Fill;
            this.grdLevelRADNIKOlaksica.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKOlaksica.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKOlaksica.DataSource = this.bindingSourceRADNIKOlaksica;
            this.grdLevelRADNIKOlaksica.Enter += new EventHandler(this.grdLevelRADNIKOlaksica_Enter);
            this.grdLevelRADNIKOlaksica.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKOlaksica_AfterRowInsert);
            this.grdLevelRADNIKOlaksica.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKOlaksica.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKOlaksica.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKOlaksica.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKOlaksica_DoubleClick);
            this.grdLevelRADNIKOlaksica.AfterRowActivate += new EventHandler(this.grdLevelRADNIKOlaksica_AfterRowActivate);
            this.grdLevelRADNIKOlaksica.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKOlaksica.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKOlaksica.DisplayLayout.BandsSerializer.Add(band8);
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            column47.CellActivation = Activation.Disabled;
            column47.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column47.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column47.Width = 0x69;
            appearance45.TextHAlign = HAlign.Right;
            column47.MaskInput = "{LOC}-nnnnnnnn";
            column47.PromptChar = ' ';
            column47.Format = "";
            column47.CellAppearance = appearance45;
            column47.Hidden = true;
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            column45.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column45.Header.Caption = StringResources.RADNIKIDGRUPEKOEFDescription;
            column45.Width = 0x33;
            column45.Format = "";
            column45.CellAppearance = appearance44;
            column46.AllowGroupBy = DefaultableBoolean.False;
            column46.AutoSizeEdit = DefaultableBoolean.False;
            column46.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column46.CellAppearance.BorderAlpha = Alpha.Transparent;
            column46.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column46.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column46.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column46.Header.Enabled = false;
            column46.Header.Fixed = true;
            column46.Header.Caption = "";
            column46.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column46.Width = 20;
            column46.MinWidth = 20;
            column46.MaxWidth = 20;
            column46.Tag = "GRUPEKOEFIDGRUPEKOEFAddNew";
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            column48.CellActivation = Activation.Disabled;
            column48.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column48.Header.Caption = StringResources.RADNIKNAZIVGRUPEKOEFDescription;
            column48.Width = 0x128;
            column48.Format = "";
            column48.CellAppearance = appearance46;
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.Header.Caption = StringResources.RADNIKDODATNIKOEFICIJENTDescription;
            column44.Width = 0x66;
            appearance43.TextHAlign = HAlign.Right;
            column44.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column44.PromptChar = ' ';
            column44.Format = "F8";
            column44.CellAppearance = appearance43;
            band4.Columns.Add(column45);
            column45.Header.VisiblePosition = 0;
            band4.Columns.Add(column48);
            column48.Header.VisiblePosition = 1;
            band4.Columns.Add(column44);
            column44.Header.VisiblePosition = 2;
            band4.Columns.Add(column47);
            column47.Header.VisiblePosition = 3;
            this.grdLevelRADNIKLevel7.Visible = true;
            this.grdLevelRADNIKLevel7.Name = "grdLevelRADNIKLevel7";
            this.grdLevelRADNIKLevel7.Tag = "RADNIKLevel7";
            this.grdLevelRADNIKLevel7.TabIndex = 0xd3;
            this.grdLevelRADNIKLevel7.Dock = DockStyle.Fill;
            this.grdLevelRADNIKLevel7.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKLevel7.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKLevel7.DataSource = this.bindingSourceRADNIKLevel7;
            this.grdLevelRADNIKLevel7.Enter += new EventHandler(this.grdLevelRADNIKLevel7_Enter);
            this.grdLevelRADNIKLevel7.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKLevel7_AfterRowInsert);
            this.grdLevelRADNIKLevel7.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKLevel7.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKLevel7.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKLevel7.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKLevel7_DoubleClick);
            this.grdLevelRADNIKLevel7.AfterRowActivate += new EventHandler(this.grdLevelRADNIKLevel7_AfterRowActivate);
            this.grdLevelRADNIKLevel7.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKLevel7.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKLevel7.DisplayLayout.BandsSerializer.Add(band4);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column11.Width = 0x69;
            appearance10.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnn";
            column11.PromptChar = ' ';
            column11.Format = "";
            column11.CellAppearance = appearance10;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.RADNIKBANKAZASTICENOIDBANKEDescription;
            column10.Width = 0x112;
            appearance9.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.RADNIKZADSIFRAOPISAPLACANJAIZUZECEDescription;
            column18.Width = 0x9c;
            column18.Format = "";
            column18.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.RADNIKZADOPISPLACANJAIZUZECEDescription;
            column15.Width = 0x10c;
            column15.Format = "";
            column15.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.RADNIKZADTEKUCIIZUZECEDescription;
            column19.Width = 170;
            column19.Format = "";
            column19.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.RADNIKZADMOIZUZECEDescription;
            column13.Width = 0x79;
            column13.Format = "";
            column13.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.RADNIKZADPOIZUZECEDescription;
            column16.Width = 0xb1;
            column16.Format = "";
            column16.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.RADNIKZADMZIZUZECEDescription;
            column14.Width = 0x79;
            column14.Format = "";
            column14.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.RADNIKZADPZIZUZECEDescription;
            column17.Width = 0xb1;
            column17.Format = "";
            column17.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.RADNIKZADIZNOSIZUZECADescription;
            column12.Width = 0xa3;
            appearance11.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance11;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 0;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 1;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 2;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 3;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 4;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 5;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 6;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 7;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 8;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 9;
            this.grdLevelRADNIKIzuzeceOdOvrhe.Visible = true;
            this.grdLevelRADNIKIzuzeceOdOvrhe.Name = "grdLevelRADNIKIzuzeceOdOvrhe";
            this.grdLevelRADNIKIzuzeceOdOvrhe.Tag = "RADNIKIzuzeceOdOvrhe";
            this.grdLevelRADNIKIzuzeceOdOvrhe.TabIndex = 0xd3;
            this.grdLevelRADNIKIzuzeceOdOvrhe.Dock = DockStyle.Fill;
            this.grdLevelRADNIKIzuzeceOdOvrhe.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRADNIKIzuzeceOdOvrhe.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRADNIKIzuzeceOdOvrhe.DataSource = this.bindingSourceRADNIKIzuzeceOdOvrhe;
            this.grdLevelRADNIKIzuzeceOdOvrhe.Enter += new EventHandler(this.grdLevelRADNIKIzuzeceOdOvrhe_Enter);
            this.grdLevelRADNIKIzuzeceOdOvrhe.AfterRowInsert += new RowEventHandler(this.grdLevelRADNIKIzuzeceOdOvrhe_AfterRowInsert);
            this.grdLevelRADNIKIzuzeceOdOvrhe.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRADNIKIzuzeceOdOvrhe.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRADNIKIzuzeceOdOvrhe.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRADNIKIzuzeceOdOvrhe.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRADNIKIzuzeceOdOvrhe_DoubleClick);
            this.grdLevelRADNIKIzuzeceOdOvrhe.AfterRowActivate += new EventHandler(this.grdLevelRADNIKIzuzeceOdOvrhe_AfterRowActivate);
            this.grdLevelRADNIKIzuzeceOdOvrhe.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRADNIKIzuzeceOdOvrhe.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRADNIKIzuzeceOdOvrhe.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "RADNIKFormUserControl";
            this.Text = "Zaposlenici";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIK.ResumeLayout(false);
            this.layoutManagerformRADNIK.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIK).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKOdbitak).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKOlaksica).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKKrediti).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKBruto).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKNeto).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKObustava).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKLevel7).EndInit();
            ((ISupportInitialize) this.bindingSourceRADNIKIzuzeceOdOvrhe).EndInit();
            ((ISupportInitialize) this.textIDRADNIK).EndInit();
            this.Group6.ResumeLayout(true);
            this.Group6.PerformLayout();
            ((ISupportInitialize) this.Group6).EndInit();
            this.layoutManagerGroup6.ResumeLayout(false);
            this.layoutManagerGroup6.PerformLayout();
            ((ISupportInitialize) this.textPREZIME).EndInit();
            ((ISupportInitialize) this.textIME).EndInit();
            ((ISupportInitialize) this.textOIB).EndInit();
            ((ISupportInitialize) this.textJMBG).EndInit();
            ((ISupportInitialize) this.textulica).EndInit();
            ((ISupportInitialize) this.textkucnibroj).EndInit();
            ((ISupportInitialize) this.textmjesto).EndInit();
            this.layoutManagerTabPage3.ResumeLayout(false);
            this.layoutManagerTabPage3.PerformLayout();
            ((ISupportInitialize) this.textOPCINASTANOVANJAIDOPCINE).EndInit();
            ((ISupportInitialize) this.textOPCINARADAIDOPCINE).EndInit();
            this.Group3.ResumeLayout(true);
            this.Group3.PerformLayout();
            ((ISupportInitialize) this.Group3).EndInit();
            this.layoutManagerGroup3.ResumeLayout(false);
            this.layoutManagerGroup3.PerformLayout();
            ((ISupportInitialize) this.textIDBANKE).EndInit();
            ((ISupportInitialize) this.textTEKUCI).EndInit();
            ((ISupportInitialize) this.textMO).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJANETO).EndInit();
            ((ISupportInitialize) this.textPBO).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJANETO).EndInit();
            this.Group2.ResumeLayout(true);
            this.Group2.PerformLayout();
            ((ISupportInitialize) this.Group2).EndInit();
            this.layoutManagerGroup2.ResumeLayout(false);
            this.layoutManagerGroup2.PerformLayout();
            this.Group4.ResumeLayout(true);
            this.Group4.PerformLayout();
            ((ISupportInitialize) this.Group4).EndInit();
            this.layoutManagerGroup4.ResumeLayout(false);
            this.layoutManagerGroup4.PerformLayout();
            this.layoutManagerTabPage4.ResumeLayout(false);
            this.layoutManagerTabPage4.PerformLayout();
            ((ISupportInitialize) this.textKOEFICIJENT).EndInit();
            ((ISupportInitialize) this.textPOSTOTAKOSLOBODJENJAODPOREZA).EndInit();
            ((ISupportInitialize) this.textTJEDNIFONDSATI).EndInit();
            ((ISupportInitialize) this.textTJEDNIFONDSATISTAZ).EndInit();
            ((ISupportInitialize) this.textGODINESTAZA).EndInit();
            ((ISupportInitialize) this.textGODINESTAZAPRO).EndInit();
            ((ISupportInitialize) this.textMJESECISTAZA).EndInit();
            ((ISupportInitialize) this.textMJESECISTAZAPRO).EndInit();
            ((ISupportInitialize) this.textDANISTAZA).EndInit();
            ((ISupportInitialize) this.textDANISTAZAPRO).EndInit();
            this.Group5.ResumeLayout(true);
            this.Group5.PerformLayout();
            ((ISupportInitialize) this.Group5).EndInit();
            this.layoutManagerGroup5.ResumeLayout(false);
            this.layoutManagerGroup5.PerformLayout();
            this.layoutManagerTabPage5.ResumeLayout(false);
            this.layoutManagerTabPage5.PerformLayout();
            ((ISupportInitialize) this.textBROJMIROVINSKOG).EndInit();
            ((ISupportInitialize) this.textBROJZDRAVSTVENOG).EndInit();
            ((ISupportInitialize) this.textMBO).EndInit();
            this.layoutManagerTabPage6.ResumeLayout(false);
            this.layoutManagerTabPage6.PerformLayout();
            ((ISupportInitialize) this.textRADNADOZVOLA).EndInit();
            ((ISupportInitialize) this.textZAVRSENASKOLA).EndInit();
            ((ISupportInitialize) this.textNAZIVPOSLA).EndInit();
            ((ISupportInitialize) this.textVRIJEMEPROBNOGRADA).EndInit();
            ((ISupportInitialize) this.textVRIJEMEPRIPRAVNICKOG).EndInit();
            ((ISupportInitialize) this.textVRIJEMESTRUCNI).EndInit();
            ((ISupportInitialize) this.textIDRADNOVRIJEME).EndInit();
            this.layoutManagerTabPage8.ResumeLayout(false);
            this.layoutManagerTabPage8.PerformLayout();
            ((ISupportInitialize) this.textVRIJEMEMIROVANJARADNOGODNOSA).EndInit();
            ((ISupportInitialize) this.textRAZLOGPRESTANKA).EndInit();
            ((ISupportInitialize) this.textZABRANANATJECANJA).EndInit();
            ((ISupportInitialize) this.textPRODUZENOMIROVINSKO).EndInit();
            ((ISupportInitialize) this.textRADUINOZEMSTVU).EndInit();
            ((ISupportInitialize) this.textRADNASPOSOBNOST).EndInit();
            ((ISupportInitialize) this.textRADNIKNAPOMENA).EndInit();
            this.layoutManagerTabPage9.ResumeLayout(false);
            this.layoutManagerTabPage9.PerformLayout();
            this.Tab2.ResumeLayout(true);
            this.Tab2.PerformLayout();
            ((ISupportInitialize) this.Tab2).EndInit();
            ((ISupportInitialize) this.grdLevelRADNIKBruto).EndInit();
            this.panelactionsRADNIKBruto.ResumeLayout(true);
            this.panelactionsRADNIKBruto.PerformLayout();
            this.layoutManagerpanelactionsRADNIKBruto.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKBruto.PerformLayout();
            this.layoutManagerLevel4Page.ResumeLayout(false);
            this.layoutManagerLevel4Page.PerformLayout();
            ((ISupportInitialize) this.grdLevelRADNIKNeto).EndInit();
            this.panelactionsRADNIKNeto.ResumeLayout(true);
            this.panelactionsRADNIKNeto.PerformLayout();
            this.layoutManagerpanelactionsRADNIKNeto.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKNeto.PerformLayout();
            this.layoutManagerTabPage1.ResumeLayout(false);
            this.layoutManagerTabPage1.PerformLayout();
            ((ISupportInitialize) this.grdLevelRADNIKObustava).EndInit();
            this.panelactionsRADNIKObustava.ResumeLayout(true);
            this.panelactionsRADNIKObustava.PerformLayout();
            this.layoutManagerpanelactionsRADNIKObustava.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKObustava.PerformLayout();
            this.layoutManagerTabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.PerformLayout();
            ((ISupportInitialize) this.grdLevelRADNIKKrediti).EndInit();
            this.panelactionsRADNIKKrediti.ResumeLayout(true);
            this.panelactionsRADNIKKrediti.PerformLayout();
            this.layoutManagerpanelactionsRADNIKKrediti.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKKrediti.PerformLayout();
            this.layoutManagerKreditiPage.ResumeLayout(false);
            this.layoutManagerKreditiPage.PerformLayout();
            ((ISupportInitialize) this.grdLevelRADNIKOdbitak).EndInit();
            this.panelactionsRADNIKOdbitak.ResumeLayout(true);
            this.panelactionsRADNIKOdbitak.PerformLayout();
            this.layoutManagerpanelactionsRADNIKOdbitak.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKOdbitak.PerformLayout();
            this.layoutManagerOsobniOdbitakPage.ResumeLayout(false);
            this.layoutManagerOsobniOdbitakPage.PerformLayout();
            ((ISupportInitialize) this.grdLevelRADNIKOlaksica).EndInit();
            this.panelactionsRADNIKOlaksica.ResumeLayout(true);
            this.panelactionsRADNIKOlaksica.PerformLayout();
            this.layoutManagerpanelactionsRADNIKOlaksica.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKOlaksica.PerformLayout();
            this.layoutManagerRADNIKLevel4Page.ResumeLayout(false);
            this.layoutManagerRADNIKLevel4Page.PerformLayout();
            ((ISupportInitialize) this.grdLevelRADNIKLevel7).EndInit();
            this.panelactionsRADNIKLevel7.ResumeLayout(true);
            this.panelactionsRADNIKLevel7.PerformLayout();
            this.layoutManagerpanelactionsRADNIKLevel7.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKLevel7.PerformLayout();
            this.layoutManagerTabPage7.ResumeLayout(false);
            this.layoutManagerTabPage7.PerformLayout();
            ((ISupportInitialize) this.grdLevelRADNIKIzuzeceOdOvrhe).EndInit();
            this.panelactionsRADNIKIzuzeceOdOvrhe.ResumeLayout(true);
            this.panelactionsRADNIKIzuzeceOdOvrhe.PerformLayout();
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.ResumeLayout(false);
            this.layoutManagerpanelactionsRADNIKIzuzeceOdOvrhe.PerformLayout();
            this.layoutManagerTabPage10.ResumeLayout(false);
            this.layoutManagerTabPage10.PerformLayout();
            this.Tab1.ResumeLayout(true);
            this.Tab1.PerformLayout();
            ((ISupportInitialize) this.Tab1).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                return false;
            }
            this.EndEditCurrentRow();
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private static void LoadValueList(ValueList myValueList, DataView enumList, string Id, string Name)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = enumList.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRowView current = (DataRowView) enumerator.Current;
                    DataRow row = current.Row;
                    ValueListItem item = new ValueListItem {
                        DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                        DisplayText = row[Name].ToString()
                    };
                    myValueList.ValueListItems.Add(item);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            myValueList.Tag = enumList;
        }

        private void Localize()
        {
            this.label1IDRADNIK.Text = StringResources.RADNIKIDRADNIKDescription;
            this.label1IDIPIDENT.Text = StringResources.RADNIKIDIPIDENTDescription;
            this.label1IDSPOL.Text = StringResources.RADNIKIDSPOLDescription;
            this.label1AKTIVAN.Text = StringResources.RADNIKAKTIVANDescription;
            this.label1PREZIME.Text = StringResources.RADNIKPREZIMEDescription;
            this.label1IME.Text = StringResources.RADNIKIMEDescription;
            this.label1OIB.Text = StringResources.RADNIKOIBDescription;
            this.label1JMBG.Text = StringResources.RADNIKJMBGDescription;
            this.label1DATUMRODJENJA.Text = StringResources.RADNIKDATUMRODJENJADescription;
            this.label1ulica.Text = StringResources.RADNIKulicaDescription;
            this.label1kucnibroj.Text = StringResources.RADNIKkucnibrojDescription;
            this.label1mjesto.Text = StringResources.RADNIKmjestoDescription;
            this.label1OPCINASTANOVANJAIDOPCINE.Text = StringResources.RADNIKOPCINASTANOVANJAIDOPCINEDescription;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Text = StringResources.RADNIKOPCINASTANOVANJANAZIVOPCINEDescription;
            this.label1OPCINARADAIDOPCINE.Text = StringResources.RADNIKOPCINARADAIDOPCINEDescription;
            this.label1OPCINARADANAZIVOPCINE.Text = StringResources.RADNIKOPCINARADANAZIVOPCINEDescription;
            this.label1OPCINASTANOVANJAPRIREZ.Text = StringResources.RADNIKOPCINASTANOVANJAPRIREZDescription;
            this.label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Text = StringResources.RADNIKRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSADescription;
            this.label1IDBANKE.Text = StringResources.RADNIKIDBANKEDescription;
            this.label1TEKUCI.Text = StringResources.RADNIKTEKUCIDescription;
            this.label1MO.Text = StringResources.RADNIKMODescription;
            this.label1SIFRAOPISAPLACANJANETO.Text = StringResources.RADNIKSIFRAOPISAPLACANJANETODescription;
            this.label1NAZIVBANKE1.Text = StringResources.RADNIKNAZIVBANKE1Description;
            this.label1ZBIRNINETO.Text = StringResources.RADNIKZBIRNINETODescription;
            this.label1PBO.Text = StringResources.RADNIKPBODescription;
            this.label1OPISPLACANJANETO.Text = StringResources.RADNIKOPISPLACANJANETODescription;
            this.label1KOEFICIJENT.Text = StringResources.RADNIKKOEFICIJENTDescription;
            this.label1POSTOTAKOSLOBODJENJAODPOREZA.Text = StringResources.RADNIKPOSTOTAKOSLOBODJENJAODPOREZADescription;
            this.label1UZIMAUOBZIROSNOVICEDOPRINOSA.Text = StringResources.RADNIKUZIMAUOBZIROSNOVICEDOPRINOSADescription;
            this.label1TJEDNIFONDSATI.Text = StringResources.RADNIKTJEDNIFONDSATIDescription;
            this.label1TJEDNIFONDSATISTAZ.Text = StringResources.RADNIKTJEDNIFONDSATISTAZDescription;
            this.label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Text = StringResources.RADNIKDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIDescription;
            this.label1IDBENEFICIRANI.Text = StringResources.RADNIKIDBENEFICIRANIDescription;
            this.label1GODINESTAZA.Text = StringResources.RADNIKGODINESTAZADescription;
            this.label1GODINESTAZAPRO.Text = StringResources.RADNIKGODINESTAZAPRODescription;
            this.label1UKUPNOGODINESTAZA.Text = StringResources.RADNIKUKUPNOGODINESTAZADescription;
            this.label1MJESECISTAZA.Text = StringResources.RADNIKMJESECISTAZADescription;
            this.label1MJESECISTAZAPRO.Text = StringResources.RADNIKMJESECISTAZAPRODescription;
            this.label1UKUPNOMJESECISTAZA.Text = StringResources.RADNIKUKUPNOMJESECISTAZADescription;
            this.label1DANISTAZA.Text = StringResources.RADNIKDANISTAZADescription;
            this.label1DANISTAZAPRO.Text = StringResources.RADNIKDANISTAZAPRODescription;
            this.label1UKUPNODANASTAZA.Text = StringResources.RADNIKUKUPNODANASTAZADescription;
            this.label1BROJMIROVINSKOG.Text = StringResources.RADNIKBROJMIROVINSKOGDescription;
            this.label1BROJZDRAVSTVENOG.Text = StringResources.RADNIKBROJZDRAVSTVENOGDescription;
            this.label1MBO.Text = StringResources.RADNIKMBODescription;
            this.label1IDTITULA.Text = StringResources.RADNIKIDTITULADescription;
            this.label1IDRADNOMJESTO.Text = StringResources.RADNIKIDRADNOMJESTODescription;
            this.label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Text = StringResources.RADNIKTRENUTNASTRUCNASPREMAIDSTRUCNASPREMADescription;
            this.label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Text = StringResources.RADNIKPOTREBNASTRUCNASPREMAIDSTRUCNASPREMADescription;
            this.label1IDSTRUKA.Text = StringResources.RADNIKIDSTRUKADescription;
            this.label1IDBRACNOSTANJE.Text = StringResources.RADNIKIDBRACNOSTANJEDescription;
            this.label1IDORGDIO.Text = StringResources.RADNIKIDORGDIODescription;
            this.label1DATUMPRESTANKARADNOGODNOSA.Text = StringResources.RADNIKDATUMPRESTANKARADNOGODNOSADescription;
            this.label1IDDRZAVLJANSTVO.Text = StringResources.RADNIKIDDRZAVLJANSTVODescription;
            this.label1RADNADOZVOLA.Text = StringResources.RADNIKRADNADOZVOLADescription;
            this.label1ZAVRSENASKOLA.Text = StringResources.RADNIKZAVRSENASKOLADescription;
            this.label1UGOVOROD.Text = StringResources.RADNIKUGOVORODDescription;
            this.label1POCETAKRADA.Text = StringResources.RADNIKPOCETAKRADADescription;
            this.label1NAZIVPOSLA.Text = StringResources.RADNIKNAZIVPOSLADescription;
            this.label1IDUGOVORORADU.Text = StringResources.RADNIKIDUGOVORORADUDescription;
            this.label1VRIJEMEPROBNOGRADA.Text = StringResources.RADNIKVRIJEMEPROBNOGRADADescription;
            this.label1VRIJEMEPRIPRAVNICKOG.Text = StringResources.RADNIKVRIJEMEPRIPRAVNICKOGDescription;
            this.label1VRIJEMESTRUCNI.Text = StringResources.RADNIKVRIJEMESTRUCNIDescription;
            this.label1IDRADNOVRIJEME.Text = StringResources.RADNIKIDRADNOVRIJEMEDescription;
            this.label1VRIJEMEMIROVANJARADNOGODNOSA.Text = StringResources.RADNIKVRIJEMEMIROVANJARADNOGODNOSADescription;
            this.label1RAZLOGPRESTANKA.Text = StringResources.RADNIKRAZLOGPRESTANKADescription;
            this.label1ZABRANANATJECANJA.Text = StringResources.RADNIKZABRANANATJECANJADescription;
            this.label1PRODUZENOMIROVINSKO.Text = StringResources.RADNIKPRODUZENOMIROVINSKODescription;
            this.label1RADUINOZEMSTVU.Text = StringResources.RADNIKRADUINOZEMSTVUDescription;
            this.label1RADNASPOSOBNOST.Text = StringResources.RADNIKRADNASPOSOBNOSTDescription;
            this.label1RADNIKNAPOMENA.Text = StringResources.RADNIKRADNIKNAPOMENADescription;
            this.TabPage3.Tab.Text = StringResources.RADNIKRADNIKTabPage3TabDescription;
            this.TabPage4.Tab.Text = StringResources.RADNIKRADNIKTabPage4TabDescription;
            this.TabPage5.Tab.Text = StringResources.RADNIKRADNIKTabPage5TabDescription;
            this.TabPage6.Tab.Text = StringResources.RADNIKRADNIKTabPage6TabDescription;
            this.TabPage8.Tab.Text = StringResources.RADNIKRADNIKTabPage8TabDescription;
            this.TabPage9.Tab.Text = StringResources.RADNIKRADNIKTabPage9TabDescription;
            this.Level4Page.Tab.Text = StringResources.RADNIKRADNIKLevel4PageTabDescription;
            this.TabPage1.Tab.Text = StringResources.RADNIKRADNIKTabPage1TabDescription;
            this.TabPage2.Tab.Text = StringResources.RADNIKRADNIKTabPage2TabDescription;
            this.KreditiPage.Tab.Text = StringResources.RADNIKRADNIKKreditiPageTabDescription;
            this.OsobniOdbitakPage.Tab.Text = StringResources.RADNIKRADNIKOsobniOdbitakPageTabDescription;
            this.RADNIKLevel4Page.Tab.Text = StringResources.RADNIKRADNIKRADNIKLevel4PageTabDescription;
            this.TabPage7.Tab.Text = StringResources.RADNIKRADNIKTabPage7TabDescription;
            this.TabPage10.Tab.Text = StringResources.RADNIKRADNIKTabPage10TabDescription;
            this.Group6.Text = StringResources.RADNIKRADNIKGroup6GroupDescription;
            this.Group3.Text = StringResources.RADNIKRADNIKGroup3GroupDescription;
            this.Group4.Text = StringResources.RADNIKRADNIKGroup4GroupDescription;
            this.Group2.Text = StringResources.RADNIKRADNIKGroup2GroupDescription;
            this.Group5.Text = StringResources.RADNIKRADNIKGroup5GroupDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGOOBRACUN")]
        public void NewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewOTISLI")]
        public void NewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewZAPOSLENI")]
        public void NewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewZAPOSLENI(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDBENEFICIRANI(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("BENEFICIRANI", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDBRACNOSTANJE(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("BRACNOSTANJE", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDDRZAVLJANSTVO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("DRZAVLJANSTVO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDIPIDENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("IPIDENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDORGDIO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGDIO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDRADNOMJESTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNOMJESTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDSPOL(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("SPOL", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDSTRUKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRUKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDTITULA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("TITULA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDUGOVORORADU(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("UGOVORORADU", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesBRUTOELEMENTIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesIDGRUPEKOEF(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("GRUPEKOEF", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesNETOELEMENTIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRUCNASPREMA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("SKUPPOREZAIDOPRINOSA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRUCNASPREMA", null, DeklaritMode.Insert));
            }
        }

        private void RADNIKBrutoAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKBruto.ActiveRow;
            this.RADNIKBrutoInsert();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void RADNIKBrutoBRUTOELEMENTIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            PROVIDER_BRUTOComboBox box = new PROVIDER_BRUTOComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["ELEMENT"].DefaultView;
            if ((this.grdLevelRADNIKBruto.ActiveRow != null) && (this.grdLevelRADNIKBruto.ActiveRow.Cells["BRUTOELEMENTIDELEMENT"] != null))
            {
                ValueList myValueList = new ValueList();
                LoadValueList(myValueList, defaultView, "IDELEMENT", "EL");
                this.grdLevelRADNIKBruto.ActiveRow.Cells["BRUTOELEMENTIDELEMENT"].ValueList = myValueList;
            }
            else
            {
                CreateValueList(this.grdLevelRADNIKBruto, "ELEMENTBRUTOELEMENTIDELEMENT", defaultView, "IDELEMENT", "EL", true);
            }
        }

        private void RADNIKBrutoDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKBruto);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKBruto.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKBruto.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKBruto).Selected = true;
                this.grdLevelRADNIKBruto.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKBrutoInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKBruto(this.m_CurrentRow);
            }
        }

        private void RADNIKBrutoUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKBruto) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKBruto);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKBruto(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKBrutoUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKBruto.ActiveRow != null)
            {
                this.RADNIKBrutoUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelRADNIKBrutoAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKBrutoLevelDescription;
            this.linkLabelRADNIKBrutoUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKBrutoLevelDescription;
            this.linkLabelRADNIKBrutoDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKBrutoLevelDescription;
            this.linkLabelRADNIKNetoAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKNetoLevelDescription;
            this.linkLabelRADNIKNetoUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKNetoLevelDescription;
            this.linkLabelRADNIKNetoDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKNetoLevelDescription;
            this.linkLabelRADNIKObustavaAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKObustavaLevelDescription;
            this.linkLabelRADNIKObustavaUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKObustavaLevelDescription;
            this.linkLabelRADNIKObustavaDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKObustavaLevelDescription;
            this.linkLabelRADNIKKreditiAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKKreditiLevelDescription;
            this.linkLabelRADNIKKreditiUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKKreditiLevelDescription;
            this.linkLabelRADNIKKreditiDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKKreditiLevelDescription;
            this.linkLabelRADNIKOdbitakAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKOdbitakLevelDescription;
            this.linkLabelRADNIKOdbitakUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKOdbitakLevelDescription;
            this.linkLabelRADNIKOdbitakDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKOdbitakLevelDescription;
            this.linkLabelRADNIKOlaksicaAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKOlaksicaLevelDescription;
            this.linkLabelRADNIKOlaksicaUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKOlaksicaLevelDescription;
            this.linkLabelRADNIKOlaksicaDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKOlaksicaLevelDescription;
            this.linkLabelRADNIKLevel7Add.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKLevel7LevelDescription;
            this.linkLabelRADNIKLevel7Update.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKLevel7LevelDescription;
            this.linkLabelRADNIKLevel7Delete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKLevel7LevelDescription;
            this.linkLabelRADNIKIzuzeceOdOvrheAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RADNIKRADNIKIzuzeceOdOvrheLevelDescription;
            this.linkLabelRADNIKIzuzeceOdOvrheUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RADNIKRADNIKIzuzeceOdOvrheLevelDescription;
            this.linkLabelRADNIKIzuzeceOdOvrheDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RADNIKRADNIKIzuzeceOdOvrheLevelDescription;
        }

        private void RADNIKIzuzeceOdOvrheAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKIzuzeceOdOvrhe.ActiveRow;
            this.RADNIKIzuzeceOdOvrheInsert();
        }

        private void RADNIKIzuzeceOdOvrheDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKIzuzeceOdOvrhe);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKIzuzeceOdOvrhe.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKIzuzeceOdOvrhe.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKIzuzeceOdOvrhe).Selected = true;
                this.grdLevelRADNIKIzuzeceOdOvrhe.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKIzuzeceOdOvrheInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKIzuzeceOdOvrhe(this.m_CurrentRow);
            }
        }

        private void RADNIKIzuzeceOdOvrheUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKIzuzeceOdOvrhe) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKIzuzeceOdOvrhe);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKIzuzeceOdOvrhe(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKIzuzeceOdOvrheUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKIzuzeceOdOvrhe.ActiveRow != null)
            {
                this.RADNIKIzuzeceOdOvrheUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKKreditiAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKKrediti.ActiveRow;
            this.RADNIKKreditiInsert();
        }

        private void RADNIKKreditiDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKKrediti);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKKrediti.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKKrediti.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKKrediti).Selected = true;
                this.grdLevelRADNIKKrediti.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKKreditiInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKKrediti(this.m_CurrentRow);
            }
        }

        private void RADNIKKreditiUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKKrediti) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKKrediti);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKKrediti(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKKreditiUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKKrediti.ActiveRow != null)
            {
                this.RADNIKKreditiUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKLevel7Add_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKLevel7.ActiveRow;
            this.RADNIKLevel7Insert();
        }

        private void RADNIKLevel7Delete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKLevel7);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKLevel7.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKLevel7.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKLevel7).Selected = true;
                this.grdLevelRADNIKLevel7.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/GRUPEKOEF", Thread=ThreadOption.UserInterface)]
        public void RADNIKLevel7IDGRUPEKOEF_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new GRUPEKOEFDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetGRUPEKOEFDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["GRUPEKOEF"]) {
                Sort = "IDGRUPEKOEF"
            };
            CreateValueList(this.grdLevelRADNIKLevel7, "GRUPEKOEFIDGRUPEKOEF", enumList, "IDGRUPEKOEF", "IDGRUPEKOEF", true);
        }

        private void RADNIKLevel7Insert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKLevel7(this.m_CurrentRow);
            }
        }

        private void RADNIKLevel7Update()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKLevel7) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKLevel7);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKLevel7(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKLevel7Update_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKLevel7.ActiveRow != null)
            {
                this.RADNIKLevel7Update();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKNetoAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKNeto.ActiveRow;
            this.RADNIKNetoInsert();
        }

        private void RADNIKNetoDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKNeto);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKNeto.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKNeto.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKNeto).Selected = true;
                this.grdLevelRADNIKNeto.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKNetoInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKNeto(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void RADNIKNetoNETOELEMENTIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            PROVIDER_NETOComboBox box = new PROVIDER_NETOComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["ELEMENT"].DefaultView;
            if ((this.grdLevelRADNIKNeto.ActiveRow != null) && (this.grdLevelRADNIKNeto.ActiveRow.Cells["NETOELEMENTIDELEMENT"] != null))
            {
                ValueList myValueList = new ValueList();
                LoadValueList(myValueList, defaultView, "IDELEMENT", "EL");
                this.grdLevelRADNIKNeto.ActiveRow.Cells["NETOELEMENTIDELEMENT"].ValueList = myValueList;
            }
            else
            {
                CreateValueList(this.grdLevelRADNIKNeto, "ELEMENTNETOELEMENTIDELEMENT", defaultView, "IDELEMENT", "EL", true);
            }
        }

        private void RADNIKNetoUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKNeto) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKNeto);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKNeto(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKNetoUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKNeto.ActiveRow != null)
            {
                this.RADNIKNetoUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKObustavaAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKObustava.ActiveRow;
            this.RADNIKObustavaInsert();
        }

        private void RADNIKObustavaDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKObustava);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKObustava.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKObustava.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKObustava).Selected = true;
                this.grdLevelRADNIKObustava.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKObustavaInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKObustava(this.m_CurrentRow);
            }
        }

        private void RADNIKObustavaUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKObustava) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKObustava);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKObustava(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKObustavaUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKObustava.ActiveRow != null)
            {
                this.RADNIKObustavaUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKOdbitakAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKOdbitak.ActiveRow;
            this.RADNIKOdbitakInsert();
        }

        private void RADNIKOdbitakDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKOdbitak);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKOdbitak.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKOdbitak.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKOdbitak).Selected = true;
                this.grdLevelRADNIKOdbitak.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKOdbitakInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKOdbitak(this.m_CurrentRow);
            }
        }

        private void RADNIKOdbitakUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKOdbitak) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKOdbitak);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKOdbitak(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKOdbitakUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKOdbitak.ActiveRow != null)
            {
                this.RADNIKOdbitakUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKOlaksicaAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRADNIKOlaksica.ActiveRow;
            this.RADNIKOlaksicaInsert();
        }

        private void RADNIKOlaksicaDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKOlaksica);
            if ((currentRowListIndex != -1) && (this.grdLevelRADNIKOlaksica.Selected.Rows.Count > 0))
            {
                this.grdLevelRADNIKOlaksica.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRADNIKOlaksica).Selected = true;
                this.grdLevelRADNIKOlaksica.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKOlaksicaInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIK, this.RADNIKController.WorkItem, this))
            {
                this.RADNIKController.AddRADNIKOlaksica(this.m_CurrentRow);
            }
        }

        private void RADNIKOlaksicaUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRADNIKOlaksica) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRADNIKOlaksica);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RADNIKController.UpdateRADNIKOlaksica(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RADNIKOlaksicaUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRADNIKOlaksica.ActiveRow != null)
            {
                this.RADNIKOlaksicaUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIK"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIK, "RADNIK|RADNIK");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKOdbitak"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKOdbitak, "RADNIK|RADNIKOdbitak");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKOlaksica"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKOlaksica, "RADNIK|RADNIKOlaksica");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKKrediti"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKKrediti, "RADNIK|RADNIKKrediti");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKBruto"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKBruto, "RADNIK|RADNIKBruto");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKNeto"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKNeto, "RADNIK|RADNIKNeto");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKObustava"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKObustava, "RADNIK|RADNIKObustava");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKLevel7"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKLevel7, "RADNIK|RADNIKLevel7");
            }
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIK|RADNIKIzuzeceOdOvrhe"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKIzuzeceOdOvrhe, "RADNIK|RADNIKIzuzeceOdOvrhe");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRADNIKDataSet1.RADNIK.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RADNIKController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RADNIKController.Update(this))
            {
                this.RADNIKController.DataSet = new RADNIKDataSet();
                DataSetUtil.AddEmptyRow(this.RADNIKController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RADNIKController.DataSet.RADNIK[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDBENEFICIRANI(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDBENEFICIRANI.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDBENEFICIRANI.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(row["IDBENEFICIRANI"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(row["NAZIVBENEFICIRANI"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(row["BROJPRIZNATIHMJESECI"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDBRACNOSTANJE(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDBRACNOSTANJE.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDBRACNOSTANJE.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(row["IDBRACNOSTANJE"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(row["NAZIVBRACNOSTANJE"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDDRZAVLJANSTVO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDDRZAVLJANSTVO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDDRZAVLJANSTVO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(row["IDDRZAVLJANSTVO"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(row["NAZIVDRZAVLJANSTVO"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDIPIDENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDIPIDENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDIPIDENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(row["IDIPIDENT"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVIPIDENT"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDORGDIO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDORGDIO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDORGDIO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDORGDIO"] = RuntimeHelpers.GetObjectValue(row["IDORGDIO"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(row["ORGANIZACIJSKIDIO"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDRADNOMJESTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDRADNOMJESTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDRADNOMJESTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(row["IDRADNOMJESTO"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(row["NAZIVRADNOMJESTO"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDSPOL(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDSPOL.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDSPOL.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDSPOL"] = RuntimeHelpers.GetObjectValue(row["IDSPOL"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(row["NAZIVSPOL"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDSTRUKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDSTRUKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDSTRUKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(row["IDSTRUKA"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(row["NAZIVSTRUKA"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDTITULA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDTITULA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDTITULA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDTITULA"] = RuntimeHelpers.GetObjectValue(row["IDTITULA"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(row["NAZIVTITULA"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDUGOVORORADU(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDUGOVORORADU.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDUGOVORORADU.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDUGOVORORADU"] = RuntimeHelpers.GetObjectValue(row["IDUGOVORORADU"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(row["NAZIVUGOVORORADU"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["IDSTRUCNASPREMA"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["NAZIVSTRUCNASPREMA"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(row["IDSKUPPOREZAIDOPRINOSA"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"] = RuntimeHelpers.GetObjectValue(row["NAZIVSKUPPOREZAIDOPRINOSA"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["IDSTRUCNASPREMA"]);
                    ((DataRowView) this.bindingSourceRADNIK.Current).Row["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(row["NAZIVSTRUCNASPREMA"]);
                    this.bindingSourceRADNIK.ResetCurrentItem();
                }
            }
        }

        private void SetComboBoxColumnProperties()
        {
            PROVIDER_BRUTOComboBox box = new PROVIDER_BRUTOComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["ELEMENT"].DefaultView;
            CreateValueList(this.grdLevelRADNIKBruto, "ELEMENTBRUTOELEMENTIDELEMENT", defaultView, "IDELEMENT", "EL", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelRADNIKBruto, "BRUTOELEMENTIDELEMENT");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelRADNIKBruto.DisplayLayout.ValueLists["ELEMENTBRUTOELEMENTIDELEMENT"];
            gridColumn.Width = 370;
            this.grdLevelRADNIKBruto.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKBruto.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            PROVIDER_NETOComboBox box2 = new PROVIDER_NETOComboBox();
            box2.Fill();
            DataView enumList = box2.DataSet.Tables["ELEMENT"].DefaultView;
            CreateValueList(this.grdLevelRADNIKNeto, "ELEMENTNETOELEMENTIDELEMENT", enumList, "IDELEMENT", "EL", false);
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelRADNIKNeto, "NETOELEMENTIDELEMENT");
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.grdLevelRADNIKNeto.DisplayLayout.ValueLists["ELEMENTNETOELEMENTIDELEMENT"];
            column5.Width = 370;
            this.grdLevelRADNIKNeto.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKNeto.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column6 = FormHelperClass.GetGridColumn(this.grdLevelRADNIKObustava, "ZADOBUSTAVAIDOBUSTAVA");
            column6.Tag = "OBUSTAVAZADOBUSTAVAIDOBUSTAVA";
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelRADNIKObustava.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKObustava.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelRADNIKKrediti, "ZADKREDITIIDKREDITOR");
            column3.Tag = "KREDITORZADKREDITIIDKREDITOR";
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelRADNIKKrediti.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKKrediti.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column7 = FormHelperClass.GetGridColumn(this.grdLevelRADNIKOdbitak, "OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK");
            column7.Tag = "OSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK";
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelRADNIKOdbitak.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKOdbitak.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column8 = FormHelperClass.GetGridColumn(this.grdLevelRADNIKOlaksica, "ZADOLAKSICEIDOLAKSICE");
            column8.Tag = "OLAKSICEZADOLAKSICEIDOLAKSICE";
            column8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelRADNIKOlaksica.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKOlaksica.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            DataSet dataSet = new GRUPEKOEFDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetGRUPEKOEFDataAdapter().Fill(dataSet);
            }
            DataView view2 = new DataView(dataSet.Tables["GRUPEKOEF"]) {
                Sort = "IDGRUPEKOEF"
            };
            CreateValueList(this.grdLevelRADNIKLevel7, "GRUPEKOEFIDGRUPEKOEF", view2, "IDGRUPEKOEF", "IDGRUPEKOEF", false);
            UltraGridColumn column4 = FormHelperClass.GetGridColumn(this.grdLevelRADNIKLevel7, "IDGRUPEKOEF");
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.grdLevelRADNIKLevel7.DisplayLayout.ValueLists["GRUPEKOEFIDGRUPEKOEF"];
            column4.Width = 0x37;
            this.grdLevelRADNIKLevel7.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKLevel7.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelRADNIKIzuzeceOdOvrhe, "BANKAZASTICENOIDBANKE");
            column2.Tag = "BANKEBANKAZASTICENOIDBANKE";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelRADNIKIzuzeceOdOvrhe.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelRADNIKIzuzeceOdOvrhe.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDRADNIK.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
            Size controlSize = WinHelperUtil.GetControlSize(this.Group6);
            this.Group6.Width = (controlSize.Width + this.Group6.Parent.Margin.Horizontal) + this.Group6.Margin.Horizontal;
            this.Group6.Height = ((controlSize.Height + this.Group6.Parent.Margin.Vertical) + this.Group6.Margin.Vertical) + this.Group6.Parent.Bounds.Y;
            Size size2 = WinHelperUtil.GetControlSize(this.Group3);
            this.Group3.Width = (size2.Width + this.Group3.Parent.Margin.Horizontal) + this.Group3.Margin.Horizontal;
            this.Group3.Height = ((size2.Height + this.Group3.Parent.Margin.Vertical) + this.Group3.Margin.Vertical) + this.Group3.Parent.Bounds.Y;
            Size size = WinHelperUtil.GetControlSize(this.Group2);
            this.Group2.Width = (size.Width + this.Group2.Parent.Margin.Horizontal) + this.Group2.Margin.Horizontal;
            this.Group2.Height = ((size.Height + this.Group2.Parent.Margin.Vertical) + this.Group2.Margin.Vertical) + this.Group2.Parent.Bounds.Y;
            Size size3 = WinHelperUtil.GetControlSize(this.Group4);
            this.Group4.Width = (size3.Width + this.Group4.Parent.Margin.Horizontal) + this.Group4.Margin.Horizontal;
            this.Group4.Height = ((size3.Height + this.Group4.Parent.Margin.Vertical) + this.Group4.Margin.Vertical) + this.Group4.Parent.Bounds.Y;
            Size size4 = WinHelperUtil.GetControlSize(this.Group5);
            this.Group5.Width = (size4.Width + this.Group5.Parent.Margin.Horizontal) + this.Group5.Margin.Horizontal;
            this.Group5.Height = ((size4.Height + this.Group5.Parent.Margin.Vertical) + this.Group5.Margin.Vertical) + this.Group5.Parent.Bounds.Y;
            Size size7 = WinHelperUtil.GetControlSize(this.Tab2);
            this.Tab2.TabPageSize = size7;
            size7.Width = (size7.Width + this.Tab2.Parent.Margin.Horizontal) + this.Tab2.Margin.Horizontal;
            size7.Height += this.Tab2.Margin.Vertical;
            this.Tab2.Size = size7;
            Size size6 = WinHelperUtil.GetControlSize(this.Tab1);
            this.Tab1.TabPageSize = size6;
            size6.Width = (size6.Width + this.Tab1.Parent.Margin.Horizontal) + this.Tab1.Margin.Horizontal;
            size6.Height += this.Tab1.Margin.Vertical;
            this.Tab1.Size = size6;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesBANKEIDBANKE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDBANKE"] = RuntimeHelpers.GetObjectValue(result["IDBANKE"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE1"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE2"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE3"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(result["VBDIBANKE"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(result["ZRNBANKE"]);
                this.bindingSourceRADNIK.ResetCurrentItem();
            }
        }

        private void UpdateValuesBRUTOELEMENTIDELEMENT(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["BRUTOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(result["IDELEMENT"]);
                    row["BRUTOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(result["NAZIVELEMENT"]);
                    row["BRUTOELEMENTPOSTOTAK"] = RuntimeHelpers.GetObjectValue(result["POSTOTAK"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesIDGRUPEKOEF(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(result["IDGRUPEKOEF"]);
                    row["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(result["NAZIVGRUPEKOEF"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesNETOELEMENTIDELEMENT(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["NETOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(result["IDELEMENT"]);
                    row["NETOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(result["NAZIVELEMENT"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesOPCINAOPCINARADAIDOPCINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(result["IDOPCINE"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(result["NAZIVOPCINE"]);
                this.bindingSourceRADNIK.ResetCurrentItem();
            }
        }

        private void UpdateValuesOPCINAOPCINASTANOVANJAIDOPCINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(result["IDOPCINE"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(result["NAZIVOPCINE"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(result["PRIREZ"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(result["VBDIOPCINA"]);
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(result["ZRNOPCINA"]);
                this.bindingSourceRADNIK.ResetCurrentItem();
            }
        }

        private void UpdateValuesRADNOVRIJEMEIDRADNOVRIJEME(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIK.Current).Row["IDRADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(result["IDRADNOVRIJEME"]);
                this.bindingSourceRADNIK.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewGOOBRACUN")]
        public void ViewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewOTISLI")]
        public void ViewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewZAPOSLENI")]
        public void ViewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewZAPOSLENI(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkAKTIVAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkAKTIVAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkAKTIVAN = value;
            }
        }

        protected virtual UltraCheckEditor checkUZIMAUOBZIROSNOVICEDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkUZIMAUOBZIROSNOVICEDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkUZIMAUOBZIROSNOVICEDOPRINOSA = value;
            }
        }

        protected virtual UltraCheckEditor checkZBIRNINETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkZBIRNINETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkZBIRNINETO = value;
            }
        }

        protected virtual BENEFICIRANIComboBox comboIDBENEFICIRANI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDBENEFICIRANI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDBENEFICIRANI = value;
            }
        }

        protected virtual BRACNOSTANJEComboBox comboIDBRACNOSTANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDBRACNOSTANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDBRACNOSTANJE = value;
            }
        }

        protected virtual DRZAVLJANSTVOComboBox comboIDDRZAVLJANSTVO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDDRZAVLJANSTVO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDDRZAVLJANSTVO = value;
            }
        }

        protected virtual IPIDENTComboBox comboIDIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDIPIDENT = value;
            }
        }

        protected virtual ORGDIOComboBox comboIDORGDIO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDORGDIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDORGDIO = value;
            }
        }

        protected virtual RADNOMJESTOComboBox comboIDRADNOMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDRADNOMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDRADNOMJESTO = value;
            }
        }

        protected virtual SPOLComboBox comboIDSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDSPOL = value;
            }
        }

        protected virtual STRUKAComboBox comboIDSTRUKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDSTRUKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDSTRUKA = value;
            }
        }

        protected virtual TITULAComboBox comboIDTITULA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDTITULA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDTITULA = value;
            }
        }

        protected virtual UGOVORORADUComboBox comboIDUGOVORORADU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDUGOVORORADU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDUGOVORORADU = value;
            }
        }

        protected virtual STRUCNASPREMAComboBox comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        protected virtual SKUPPOREZAIDOPRINOSAComboBox comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = value;
            }
        }

        protected virtual STRUCNASPREMAComboBox comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        private ContextMenu contextMenu1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._contextMenu1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._contextMenu1 = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMPRESTANKARADNOGODNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMPRESTANKARADNOGODNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMPRESTANKARADNOGODNOSA = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMRODJENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMRODJENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMRODJENJA = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerPOCETAKRADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerPOCETAKRADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerPOCETAKRADA = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerUGOVOROD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerUGOVOROD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerUGOVOROD = value;
            }
        }

        private ErrorProvider errorProvider1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProvider1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProvider1 = value;
            }
        }

        private ErrorProviderValidator errorProviderValidator1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProviderValidator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProviderValidator1 = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKBruto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKBruto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKBruto = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKIzuzeceOdOvrhe
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKIzuzeceOdOvrhe;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKIzuzeceOdOvrhe = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKKrediti = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKLevel7
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKLevel7;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKLevel7 = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKNeto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKNeto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKNeto = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKObustava
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKObustava;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKObustava = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKOdbitak
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKOdbitak;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKOdbitak = value;
            }
        }

        protected virtual UltraGrid grdLevelRADNIKOlaksica
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRADNIKOlaksica;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRADNIKOlaksica = value;
            }
        }

        protected virtual UltraGroupBox Group2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Group2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Group2 = value;
            }
        }

        protected virtual UltraGroupBox Group3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Group3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Group3 = value;
            }
        }

        protected virtual UltraGroupBox Group4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Group4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Group4 = value;
            }
        }

        protected virtual UltraGroupBox Group5
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Group5;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Group5 = value;
            }
        }

        protected virtual UltraGroupBox Group6
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Group6;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Group6 = value;
            }
        }

        protected virtual UltraTabPageControl KreditiPage
        {
            [DebuggerNonUserCode]
            get
            {
                return this._KreditiPage;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._KreditiPage = value;
            }
        }

        protected virtual UltraLabel label1AKTIVAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1AKTIVAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1AKTIVAN = value;
            }
        }

        protected virtual UltraLabel label1BROJMIROVINSKOG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJMIROVINSKOG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJMIROVINSKOG = value;
            }
        }

        protected virtual UltraLabel label1BROJZDRAVSTVENOG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJZDRAVSTVENOG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJZDRAVSTVENOG = value;
            }
        }

        protected virtual UltraLabel label1DANISTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DANISTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DANISTAZA = value;
            }
        }

        protected virtual UltraLabel label1DANISTAZAPRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DANISTAZAPRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DANISTAZAPRO = value;
            }
        }

        protected virtual UltraLabel label1DATUMPRESTANKARADNOGODNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMPRESTANKARADNOGODNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMPRESTANKARADNOGODNOSA = value;
            }
        }

        protected virtual UltraLabel label1DATUMRODJENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMRODJENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMRODJENJA = value;
            }
        }

        protected virtual UltraLabel label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = value;
            }
        }

        protected virtual UltraLabel label1GODINESTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINESTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINESTAZA = value;
            }
        }

        protected virtual UltraLabel label1GODINESTAZAPRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINESTAZAPRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINESTAZAPRO = value;
            }
        }

        protected virtual UltraLabel label1IDBANKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDBANKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDBANKE = value;
            }
        }

        protected virtual UltraLabel label1IDBENEFICIRANI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDBENEFICIRANI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDBENEFICIRANI = value;
            }
        }

        protected virtual UltraLabel label1IDBRACNOSTANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDBRACNOSTANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDBRACNOSTANJE = value;
            }
        }

        protected virtual UltraLabel label1IDDRZAVLJANSTVO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDRZAVLJANSTVO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDRZAVLJANSTVO = value;
            }
        }

        protected virtual UltraLabel label1IDIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDIPIDENT = value;
            }
        }

        protected virtual UltraLabel label1IDORGDIO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDORGDIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDORGDIO = value;
            }
        }

        protected virtual UltraLabel label1IDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNIK = value;
            }
        }

        protected virtual UltraLabel label1IDRADNOMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNOMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNOMJESTO = value;
            }
        }

        protected virtual UltraLabel label1IDRADNOVRIJEME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNOVRIJEME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNOVRIJEME = value;
            }
        }

        protected virtual UltraLabel label1IDSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSPOL = value;
            }
        }

        protected virtual UltraLabel label1IDSTRUKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSTRUKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSTRUKA = value;
            }
        }

        protected virtual UltraLabel label1IDTITULA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTITULA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTITULA = value;
            }
        }

        protected virtual UltraLabel label1IDUGOVORORADU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDUGOVORORADU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDUGOVORORADU = value;
            }
        }

        protected virtual UltraLabel label1IME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IME = value;
            }
        }

        protected virtual UltraLabel label1JMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1JMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1JMBG = value;
            }
        }

        protected virtual UltraLabel label1KOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KOEFICIJENT = value;
            }
        }

        protected virtual UltraLabel label1kucnibroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1kucnibroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1kucnibroj = value;
            }
        }

        protected virtual UltraLabel label1MBO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MBO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MBO = value;
            }
        }

        protected virtual UltraLabel label1MJESECISTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESECISTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESECISTAZA = value;
            }
        }

        protected virtual UltraLabel label1MJESECISTAZAPRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESECISTAZAPRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESECISTAZAPRO = value;
            }
        }

        protected virtual UltraLabel label1mjesto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mjesto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mjesto = value;
            }
        }

        protected virtual UltraLabel label1MO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MO = value;
            }
        }

        protected virtual UltraLabel label1NAZIVBANKE1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVBANKE1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVBANKE1 = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPOSLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPOSLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPOSLA = value;
            }
        }

        protected virtual UltraLabel label1OIB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OIB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OIB = value;
            }
        }

        protected virtual UltraLabel label1OPCINARADAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINARADAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINARADAIDOPCINE = value;
            }
        }

        protected virtual UltraLabel label1OPCINARADANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINARADANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINARADANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel label1OPCINASTANOVANJAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINASTANOVANJAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINASTANOVANJAIDOPCINE = value;
            }
        }

        protected virtual UltraLabel label1OPCINASTANOVANJANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINASTANOVANJANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINASTANOVANJANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel label1OPCINASTANOVANJAPRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINASTANOVANJAPRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINASTANOVANJAPRIREZ = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJANETO = value;
            }
        }

        protected virtual UltraLabel label1PBO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PBO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PBO = value;
            }
        }

        protected virtual UltraLabel label1POCETAKRADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POCETAKRADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POCETAKRADA = value;
            }
        }

        protected virtual UltraLabel label1POSTOTAKOSLOBODJENJAODPOREZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POSTOTAKOSLOBODJENJAODPOREZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POSTOTAKOSLOBODJENJAODPOREZA = value;
            }
        }

        protected virtual UltraLabel label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POTREBNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        protected virtual UltraLabel label1PREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PREZIME = value;
            }
        }

        protected virtual UltraLabel label1PRODUZENOMIROVINSKO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRODUZENOMIROVINSKO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRODUZENOMIROVINSKO = value;
            }
        }

        protected virtual UltraLabel label1RADNADOZVOLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RADNADOZVOLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RADNADOZVOLA = value;
            }
        }

        protected virtual UltraLabel label1RADNASPOSOBNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RADNASPOSOBNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RADNASPOSOBNOST = value;
            }
        }

        protected virtual UltraLabel label1RADNIKNAPOMENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RADNIKNAPOMENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RADNIKNAPOMENA = value;
            }
        }

        protected virtual UltraLabel label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = value;
            }
        }

        protected virtual UltraLabel label1RADUINOZEMSTVU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RADUINOZEMSTVU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RADUINOZEMSTVU = value;
            }
        }

        protected virtual UltraLabel label1RAZLOGPRESTANKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZLOGPRESTANKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZLOGPRESTANKA = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJANETO = value;
            }
        }

        protected virtual UltraLabel label1TEKUCI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1TEKUCI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1TEKUCI = value;
            }
        }

        protected virtual UltraLabel label1TJEDNIFONDSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1TJEDNIFONDSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1TJEDNIFONDSATI = value;
            }
        }

        protected virtual UltraLabel label1TJEDNIFONDSATISTAZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1TJEDNIFONDSATISTAZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1TJEDNIFONDSATISTAZ = value;
            }
        }

        protected virtual UltraLabel label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        protected virtual UltraLabel label1UGOVOROD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UGOVOROD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UGOVOROD = value;
            }
        }

        protected virtual UltraLabel label1UKUPNODANASTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UKUPNODANASTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UKUPNODANASTAZA = value;
            }
        }

        protected virtual UltraLabel label1UKUPNOGODINESTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UKUPNOGODINESTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UKUPNOGODINESTAZA = value;
            }
        }

        protected virtual UltraLabel label1UKUPNOMJESECISTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UKUPNOMJESECISTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UKUPNOMJESECISTAZA = value;
            }
        }

        protected virtual UltraLabel label1ulica
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ulica;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ulica = value;
            }
        }

        protected virtual UltraLabel label1UZIMAUOBZIROSNOVICEDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UZIMAUOBZIROSNOVICEDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UZIMAUOBZIROSNOVICEDOPRINOSA = value;
            }
        }

        protected virtual UltraLabel label1VRIJEMEMIROVANJARADNOGODNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRIJEMEMIROVANJARADNOGODNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRIJEMEMIROVANJARADNOGODNOSA = value;
            }
        }

        protected virtual UltraLabel label1VRIJEMEPRIPRAVNICKOG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRIJEMEPRIPRAVNICKOG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRIJEMEPRIPRAVNICKOG = value;
            }
        }

        protected virtual UltraLabel label1VRIJEMEPROBNOGRADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRIJEMEPROBNOGRADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRIJEMEPROBNOGRADA = value;
            }
        }

        protected virtual UltraLabel label1VRIJEMESTRUCNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRIJEMESTRUCNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRIJEMESTRUCNI = value;
            }
        }

        protected virtual UltraLabel label1ZABRANANATJECANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZABRANANATJECANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZABRANANATJECANJA = value;
            }
        }

        protected virtual UltraLabel label1ZAVRSENASKOLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZAVRSENASKOLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZAVRSENASKOLA = value;
            }
        }

        protected virtual UltraLabel label1ZBIRNINETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZBIRNINETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZBIRNINETO = value;
            }
        }

        protected virtual UltraLabel labelNAZIVBANKE1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVBANKE1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVBANKE1 = value;
            }
        }

        protected virtual UltraLabel labelOPCINARADANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPCINARADANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPCINARADANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel labelOPCINASTANOVANJANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPCINASTANOVANJANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPCINASTANOVANJANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel labelOPCINASTANOVANJAPRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPCINASTANOVANJAPRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPCINASTANOVANJAPRIREZ = value;
            }
        }

        protected virtual UltraLabel labelUKUPNODANASTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelUKUPNODANASTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelUKUPNODANASTAZA = value;
            }
        }

        protected virtual UltraLabel labelUKUPNOGODINESTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelUKUPNOGODINESTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelUKUPNOGODINESTAZA = value;
            }
        }

        protected virtual UltraLabel labelUKUPNOMJESECISTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelUKUPNOMJESECISTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelUKUPNOMJESECISTAZA = value;
            }
        }

        protected virtual UltraTabPageControl Level4Page
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Level4Page;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Level4Page = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKBruto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKBruto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKBruto = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKBrutoAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKBrutoAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKBrutoAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKBrutoDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKBrutoDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKBrutoDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKBrutoUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKBrutoUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKBrutoUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKIzuzeceOdOvrhe
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKIzuzeceOdOvrhe;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKIzuzeceOdOvrhe = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKIzuzeceOdOvrheAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKIzuzeceOdOvrheAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKIzuzeceOdOvrheAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKIzuzeceOdOvrheDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKIzuzeceOdOvrheDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKIzuzeceOdOvrheDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKIzuzeceOdOvrheUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKIzuzeceOdOvrheUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKIzuzeceOdOvrheUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKKrediti = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKKreditiAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKKreditiAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKKreditiAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKKreditiDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKKreditiDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKKreditiDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKKreditiUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKKreditiUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKKreditiUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKLevel7
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKLevel7;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKLevel7 = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKLevel7Add
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKLevel7Add;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKLevel7Add = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKLevel7Delete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKLevel7Delete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKLevel7Delete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKLevel7Update
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKLevel7Update;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKLevel7Update = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKNeto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKNeto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKNeto = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKNetoAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKNetoAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKNetoAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKNetoDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKNetoDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKNetoDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKNetoUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKNetoUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKNetoUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKObustava
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKObustava;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKObustava = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKObustavaAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKObustavaAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKObustavaAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKObustavaDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKObustavaDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKObustavaDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKObustavaUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKObustavaUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKObustavaUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOdbitak
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOdbitak;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOdbitak = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOdbitakAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOdbitakAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOdbitakAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOdbitakDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOdbitakDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOdbitakDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOdbitakUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOdbitakUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOdbitakUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOlaksica
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOlaksica;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOlaksica = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOlaksicaAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOlaksicaAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOlaksicaAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOlaksicaDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOlaksicaDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOlaksicaDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRADNIKOlaksicaUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRADNIKOlaksicaUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRADNIKOlaksicaUpdate = value;
            }
        }

        public DeklaritMode Mode
        {
            get
            {
                return this.m_Mode;
            }
            set
            {
                this.m_Mode = value;
            }
        }

        protected virtual UltraTabPageControl OsobniOdbitakPage
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OsobniOdbitakPage;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._OsobniOdbitakPage = value;
            }
        }

        protected virtual Panel panelactionsRADNIKBruto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKBruto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKBruto = value;
            }
        }

        protected virtual Panel panelactionsRADNIKIzuzeceOdOvrhe
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKIzuzeceOdOvrhe;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKIzuzeceOdOvrhe = value;
            }
        }

        protected virtual Panel panelactionsRADNIKKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKKrediti = value;
            }
        }

        protected virtual Panel panelactionsRADNIKLevel7
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKLevel7;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKLevel7 = value;
            }
        }

        protected virtual Panel panelactionsRADNIKNeto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKNeto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKNeto = value;
            }
        }

        protected virtual Panel panelactionsRADNIKObustava
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKObustava;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKObustava = value;
            }
        }

        protected virtual Panel panelactionsRADNIKOdbitak
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKOdbitak;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKOdbitak = value;
            }
        }

        protected virtual Panel panelactionsRADNIKOlaksica
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRADNIKOlaksica;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRADNIKOlaksica = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.RADNIKController RADNIKController { get; set; }

        protected virtual UltraTabPageControl RADNIKLevel4Page
        {
            [DebuggerNonUserCode]
            get
            {
                return this._RADNIKLevel4Page;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._RADNIKLevel4Page = value;
            }
        }

        private MenuItem SetNullItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SetNullItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SetNullItem = value;
            }
        }

        protected virtual UltraTabControl Tab1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Tab1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Tab1 = value;
            }
        }

        protected virtual UltraTabControl Tab2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Tab2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Tab2 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage1 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage10
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage10;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage10 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage2 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage3 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage4 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage5
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage5;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage5 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage6
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage6;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage6 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage7
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage7;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage7 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage8
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage8;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage8 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage9
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage9;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage9 = value;
            }
        }

        protected virtual UltraTextEditor textBROJMIROVINSKOG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJMIROVINSKOG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJMIROVINSKOG = value;
            }
        }

        protected virtual UltraTextEditor textBROJZDRAVSTVENOG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJZDRAVSTVENOG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJZDRAVSTVENOG = value;
            }
        }

        protected virtual UltraNumericEditor textDANISTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDANISTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDANISTAZA = value;
            }
        }

        protected virtual UltraNumericEditor textDANISTAZAPRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDANISTAZAPRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDANISTAZAPRO = value;
            }
        }

        protected virtual UltraNumericEditor textGODINESTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINESTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINESTAZA = value;
            }
        }

        protected virtual UltraNumericEditor textGODINESTAZAPRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINESTAZAPRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINESTAZAPRO = value;
            }
        }

        protected virtual UltraNumericEditor textIDBANKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDBANKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDBANKE = value;
            }
        }

        protected virtual UltraNumericEditor textIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRADNIK = value;
            }
        }

        protected virtual UltraNumericEditor textIDRADNOVRIJEME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRADNOVRIJEME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRADNOVRIJEME = value;
            }
        }

        protected virtual UltraTextEditor textIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIME = value;
            }
        }

        protected virtual UltraTextEditor textJMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textJMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textJMBG = value;
            }
        }

        protected virtual UltraNumericEditor textKOEFICIJENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKOEFICIJENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKOEFICIJENT = value;
            }
        }

        protected virtual UltraTextEditor textkucnibroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textkucnibroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textkucnibroj = value;
            }
        }

        protected virtual UltraTextEditor textMBO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMBO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMBO = value;
            }
        }

        protected virtual UltraNumericEditor textMJESECISTAZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESECISTAZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESECISTAZA = value;
            }
        }

        protected virtual UltraNumericEditor textMJESECISTAZAPRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESECISTAZAPRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESECISTAZAPRO = value;
            }
        }

        protected virtual UltraTextEditor textmjesto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textmjesto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textmjesto = value;
            }
        }

        protected virtual UltraTextEditor textMO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMO = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVPOSLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPOSLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVPOSLA = value;
            }
        }

        protected virtual UltraTextEditor textOIB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOIB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOIB = value;
            }
        }

        protected virtual UltraTextEditor textOPCINARADAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPCINARADAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPCINARADAIDOPCINE = value;
            }
        }

        protected virtual UltraTextEditor textOPCINASTANOVANJAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPCINASTANOVANJAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPCINASTANOVANJAIDOPCINE = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJANETO = value;
            }
        }

        protected virtual UltraTextEditor textPBO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPBO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPBO = value;
            }
        }

        protected virtual UltraNumericEditor textPOSTOTAKOSLOBODJENJAODPOREZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOSTOTAKOSLOBODJENJAODPOREZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOSTOTAKOSLOBODJENJAODPOREZA = value;
            }
        }

        protected virtual UltraTextEditor textPREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPREZIME = value;
            }
        }

        protected virtual UltraTextEditor textPRODUZENOMIROVINSKO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRODUZENOMIROVINSKO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRODUZENOMIROVINSKO = value;
            }
        }

        protected virtual UltraTextEditor textRADNADOZVOLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRADNADOZVOLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRADNADOZVOLA = value;
            }
        }

        protected virtual UltraTextEditor textRADNASPOSOBNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRADNASPOSOBNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRADNASPOSOBNOST = value;
            }
        }

        protected virtual UltraTextEditor textRADNIKNAPOMENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRADNIKNAPOMENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRADNIKNAPOMENA = value;
            }
        }

        protected virtual UltraTextEditor textRADUINOZEMSTVU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRADUINOZEMSTVU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRADUINOZEMSTVU = value;
            }
        }

        protected virtual UltraTextEditor textRAZLOGPRESTANKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAZLOGPRESTANKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAZLOGPRESTANKA = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJANETO = value;
            }
        }

        protected virtual UltraTextEditor textTEKUCI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textTEKUCI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textTEKUCI = value;
            }
        }

        protected virtual UltraNumericEditor textTJEDNIFONDSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textTJEDNIFONDSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textTJEDNIFONDSATI = value;
            }
        }

        protected virtual UltraNumericEditor textTJEDNIFONDSATISTAZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textTJEDNIFONDSATISTAZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textTJEDNIFONDSATISTAZ = value;
            }
        }

        protected virtual UltraTextEditor textulica
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textulica;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textulica = value;
            }
        }

        protected virtual UltraTextEditor textVRIJEMEMIROVANJARADNOGODNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRIJEMEMIROVANJARADNOGODNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRIJEMEMIROVANJARADNOGODNOSA = value;
            }
        }

        protected virtual UltraTextEditor textVRIJEMEPRIPRAVNICKOG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRIJEMEPRIPRAVNICKOG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRIJEMEPRIPRAVNICKOG = value;
            }
        }

        protected virtual UltraTextEditor textVRIJEMEPROBNOGRADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRIJEMEPROBNOGRADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRIJEMEPROBNOGRADA = value;
            }
        }

        protected virtual UltraTextEditor textVRIJEMESTRUCNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRIJEMESTRUCNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRIJEMESTRUCNI = value;
            }
        }

        protected virtual UltraTextEditor textZABRANANATJECANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZABRANANATJECANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZABRANANATJECANJA = value;
            }
        }

        protected virtual UltraTextEditor textZAVRSENASKOLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZAVRSENASKOLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZAVRSENASKOLA = value;
            }
        }

        private System.Windows.Forms.ToolTip toolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._toolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._toolTip1 = value;
            }
        }
    }
}

