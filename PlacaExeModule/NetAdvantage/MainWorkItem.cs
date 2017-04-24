namespace NetAdvantage
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.Services;
    using Hlp;
    using Microsoft.Practices.CompositeUI;
    using My.Resources;
    using Placa;
    using System;
    using System.Runtime.CompilerServices;

    public class MainWorkItem : WorkItem
    {
        private IUICommandDefinitionAdapterService m_MenuAdapterService;
        private IUICommandDefinitionAdapterService m_UICommandDefinitionAdapterService;
        private Deklarit.Practices.CompositeUI.UICommandDefinitionContainer m_UICommandDefinitionContainer;

        public MainWorkItem()
        {
            this.m_UICommandDefinitionContainer = new Deklarit.Practices.CompositeUI.UICommandDefinitionContainer(this);
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("BusinessComponents", StringResources.MenuBusinessComponentsFolderMenu, this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Common", StringResources.MenuCommonFolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KORISNIKCommand", StringResources.KORISNIKDescription, this.Site + ".BusinessComponents.Common", 11, null, "KORISNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.POSTANSKIBROJEVICommand", StringResources.POSTANSKIBROJEVIDescription, this.Site + ".BusinessComponents.Common", 11, null, "POSTANSKIBROJEVI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.STRANAKNJIZENJACommand", StringResources.STRANAKNJIZENJADescription, this.Site + ".BusinessComponents.Common", 11, null, "STRANAKNJIZENJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.STRANEKNJIZENJACommand", StringResources.STRANEKNJIZENJADescription, this.Site + ".BusinessComponents.Common", 11, null, "STRANEKNJIZENJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.testCommand", StringResources.testDescription, this.Site + ".BusinessComponents.Common", 11, null, "test.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPPARTNERACommand", StringResources.TIPPARTNERADescription, this.Site + ".BusinessComponents.Common", 11, null, "TIPPARTNERA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VERZIJACommand", StringResources.VERZIJADescription, this.Site + ".BusinessComponents.Common", 11, null, "VERZIJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DD", StringResources.MenuDDFolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DDIZDATAKCommand", StringResources.DDIZDATAKDescription, this.Site + ".BusinessComponents.DD", 11, null, "DDIZDATAK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DDKATEGORIJACommand", StringResources.DDKATEGORIJADescription, this.Site + ".BusinessComponents.DD", 11, null, "DDKATEGORIJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DDKOLONAIDDCommand", StringResources.DDKOLONAIDDDescription, this.Site + ".BusinessComponents.DD", 11, null, "DDKOLONAIDD.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DDOBRACUNCommand", StringResources.DDOBRACUNDescription, this.Site + ".BusinessComponents.DD", 11, null, "DDOBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DDRADNIKCommand", StringResources.DDRADNIKDescription, this.Site + ".BusinessComponents.DD", 11, null, "DDRADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DDVRSTEPOSLACommand", StringResources.DDVRSTEPOSLADescription, this.Site + ".BusinessComponents.DD", 11, null, "DDVRSTEPOSLA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Evidencija", StringResources.MenuEvidencijaFolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.EVIDENCIJACommand", StringResources.EVIDENCIJADescription, this.Site + ".BusinessComponents.Evidencija", 11, null, "EVIDENCIJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SMJENECommand", StringResources.SMJENEDescription, this.Site + ".BusinessComponents.Evidencija", 11, null, "SMJENE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Finpos", StringResources.MenuFinposFolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.AKTIVNOSTCommand", StringResources.AKTIVNOSTDescription, this.Site + ".BusinessComponents.Finpos", 11, null, "AKTIVNOST.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BLAGAJNACommand", StringResources.BLAGAJNADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "BLAGAJNA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BLGVRSTEDOKCommand", StringResources.BLGVRSTEDOKDescription, this.Site + ".BusinessComponents.Finpos", 11, null, "BLGVRSTEDOK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DOKUMENTCommand", StringResources.DOKUMENTDescription, this.Site + ".BusinessComponents.Finpos", 11, null, "DOKUMENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GKSTAVKACommand", StringResources.GKSTAVKADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "GKSTAVKA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GODINECommand", StringResources.GODINEDescription, this.Site + ".BusinessComponents.Finpos", 11, null, "GODINE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.IRACommand", StringResources.IRADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "IRA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KONTOCommand", StringResources.KONTODescription, this.Site + ".BusinessComponents.Finpos", 11, null, "KONTO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.MJESTOTROSKACommand", StringResources.MJESTOTROSKADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "MJESTOTROSKA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ORGJEDCommand", StringResources.ORGJEDDescription, this.Site + ".BusinessComponents.Finpos", 11, null, "ORGJED.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PARTNERCommand", StringResources.PARTNERDescription, this.Site + ".BusinessComponents.Finpos", 11, null, "PARTNER.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PLANCommand", StringResources.PLANDescription, this.Site + ".BusinessComponents.Finpos", 11, null, "PLAN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SHEMAIRACommand", StringResources.SHEMAIRADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "SHEMAIRA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SHEMAURACommand", StringResources.SHEMAURADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "SHEMAURA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPDOKUMENTACommand", StringResources.TIPDOKUMENTADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "TIPDOKUMENTA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPIRACommand", StringResources.TIPIRADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "TIPIRA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPURACommand", StringResources.TIPURADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "TIPURA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.URACommand", StringResources.URADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "URA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ZATVARANJACommand", StringResources.ZATVARANJADescription, this.Site + ".BusinessComponents.Finpos", 11, null, "ZATVARANJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OSNOVNA", StringResources.MenuOSNOVNAFolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.AMSKUPINECommand", StringResources.AMSKUPINEDescription, this.Site + ".BusinessComponents.OSNOVNA", 11, null, "AMSKUPINE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.LOKACIJECommand", StringResources.LOKACIJEDescription, this.Site + ".BusinessComponents.OSNOVNA", 11, null, "LOKACIJE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSCommand", StringResources.OSDescription, this.Site + ".BusinessComponents.OSNOVNA", 11, null, "OS.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSDOKUMENTCommand", StringResources.OSDOKUMENTDescription, this.Site + ".BusinessComponents.OSNOVNA", 11, null, "OSDOKUMENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSRAZMJESTAJCommand", StringResources.OSRAZMJESTAJDescription, this.Site + ".BusinessComponents.OSNOVNA", 11, null, "OSRAZMJESTAJ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSVRSTACommand", StringResources.OSVRSTADescription, this.Site + ".BusinessComponents.OSNOVNA", 11, null, "OSVRSTA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJICommand", StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDescription, this.Site + ".BusinessComponents.OSNOVNA", 13, null, "S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OS_BROJ_I_DATUMCommand", StringResources.S_OS_BROJ_I_DATUMDescription, this.Site + ".BusinessComponents.OSNOVNA", 13, null, "S_OS_BROJ_I_DATUM.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OS_POSTOJECI_DOKUMENTICommand", StringResources.S_OS_POSTOJECI_DOKUMENTIDescription, this.Site + ".BusinessComponents.OSNOVNA", 13, null, "S_OS_POSTOJECI_DOKUMENTI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJACommand", StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADescription, this.Site + ".BusinessComponents.OSNOVNA", 13, null, "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OS_REKAP_TEMELJNICECommand", StringResources.S_OS_REKAP_TEMELJNICEDescription, this.Site + ".BusinessComponents.OSNOVNA", 13, null, "S_OS_REKAP_TEMELJNICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OS_STANJE_LOKACIJACommand", StringResources.S_OS_STANJE_LOKACIJADescription, this.Site + ".BusinessComponents.OSNOVNA", 13, null, "S_OS_STANJE_LOKACIJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICACommand", StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADescription, this.Site + ".BusinessComponents.OSNOVNA", 13, null, "S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa", StringResources.MenuPlacaFolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BANKECommand", StringResources.BANKEDescription, this.Site + ".BusinessComponents.Placa", ImageResources.BANKEImageSmall, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BENEFICIRANICommand", StringResources.BENEFICIRANIDescription, this.Site + ".BusinessComponents.Placa", 11, null, "BENEFICIRANI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BOLOVANJEFONDCommand", StringResources.BOLOVANJEFONDDescription, this.Site + ".BusinessComponents.Placa", 11, null, "BOLOVANJEFOND.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BRACNOSTANJECommand", StringResources.BRACNOSTANJEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "BRACNOSTANJE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DOPRINOSCommand", StringResources.DOPRINOSDescription, this.Site + ".BusinessComponents.Placa", 11, null, "DOPRINOS.Select"));
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DOSIPZAGLAVLJECommand", StringResources.DOSIPZAGLAVLJEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "DOSIPZAGLAVLJE.Select"));
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DRZAVLJANSTVOCommand", StringResources.DRZAVLJANSTVODescription, this.Site + ".BusinessComponents.Placa", 11, null, "DRZAVLJANSTVO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ELEMENTCommand", StringResources.ELEMENTDescription, this.Site + ".BusinessComponents.Placa", 11, null, "ELEMENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GOOBRACUNCommand", StringResources.GOOBRACUNDescription, this.Site + ".BusinessComponents.Placa", 11, null, "GOOBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GRUPEKOEFCommand", StringResources.GRUPEKOEFDescription, this.Site + ".BusinessComponents.Placa", 11, null, "GRUPEKOEF.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GRUPEOLAKSICACommand", StringResources.GRUPEOLAKSICADescription, this.Site + ".BusinessComponents.Placa", 11, null, "GRUPEOLAKSICA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.IPIDENTCommand", StringResources.IPIDENTDescription, this.Site + ".BusinessComponents.Placa", 11, null, "IPIDENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.IZVORDOKUMENTACommand", StringResources.IZVORDOKUMENTADescription, this.Site + ".BusinessComponents.Placa", 11, null, "IZVORDOKUMENTA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KREDITORCommand", StringResources.KREDITORDescription, this.Site + ".BusinessComponents.Placa", 11, null, "KREDITOR.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KRIZNIPOREZCommand", StringResources.KRIZNIPOREZDescription, this.Site + ".BusinessComponents.Placa", 11, null, "KRIZNIPOREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.MZOSTABLICECommand", StringResources.MZOSTABLICEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "MZOSTABLICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OBRACUNCommand", StringResources.OBRACUNDescription, this.Site + ".BusinessComponents.Placa", 11, null, "OBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OBUSTAVACommand", StringResources.OBUSTAVADescription, this.Site + ".BusinessComponents.Placa", 11, null, "OBUSTAVA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OLAKSICECommand", StringResources.OLAKSICEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "OLAKSICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OPCINACommand", StringResources.OPCINADescription, this.Site + ".BusinessComponents.Placa", 11, null, "OPCINA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ORGDIOCommand", StringResources.ORGDIODescription, this.Site + ".BusinessComponents.Placa", 11, null, "ORGDIO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSNOVAOSIGURANJACommand", StringResources.OSNOVAOSIGURANJADescription, this.Site + ".BusinessComponents.Placa", 11, null, "OSNOVAOSIGURANJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSOBNIODBITAKCommand", StringResources.OSOBNIODBITAKDescription, this.Site + ".BusinessComponents.Placa", 11, null, "OSOBNIODBITAK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OTISLICommand", StringResources.OTISLIDescription, this.Site + ".BusinessComponents.Placa", 11, null, "OTISLI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.POREZCommand", StringResources.POREZDescription, this.Site + ".BusinessComponents.Placa", 11, null, "POREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PRPLACECommand", StringResources.PRPLACEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "PRPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1GELEMENTICommand", StringResources.RAD1GELEMENTIDescription, this.Site + ".BusinessComponents.Placa", 11, null, "RAD1GELEMENTI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1MELEMENTICommand", StringResources.RAD1MELEMENTIDescription, this.Site + ".BusinessComponents.Placa", 11, null, "RAD1MELEMENTI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1SPOLCommand", StringResources.RAD1SPOLDescription, this.Site + ".BusinessComponents.Placa", 11, null, "RAD1SPOL.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1SPREMECommand", StringResources.RAD1SPREMEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "RAD1SPREME.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RADNIKCommand", StringResources.RADNIKDescription, this.Site + ".BusinessComponents.Placa", 11, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RADNOMJESTOCommand", StringResources.RADNOMJESTODescription, this.Site + ".BusinessComponents.Placa", 11, null, "RADNOMJESTO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RADNOVRIJEMECommand", StringResources.RADNOVRIJEMEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "RADNOVRIJEME.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RSMACommand", StringResources.RSMADescription, this.Site + ".BusinessComponents.Placa", 11, null, "RSMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RSVRSTEOBRACUNACommand", StringResources.RSVRSTEOBRACUNADescription, this.Site + ".BusinessComponents.Placa", 11, null, "RSVRSTEOBRACUNA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RSVRSTEOBVEZNIKACommand", StringResources.RSVRSTEOBVEZNIKADescription, this.Site + ".BusinessComponents.Placa", 11, null, "RSVRSTEOBVEZNIKA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SKUPPOREZAIDOPRINOSACommand", StringResources.SKUPPOREZAIDOPRINOSADescription, this.Site + ".BusinessComponents.Placa", 11, null, "SKUPPOREZAIDOPRINOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SPOLCommand", StringResources.SPOLDescription, this.Site + ".BusinessComponents.Placa", 11, null, "SPOL.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.STRUCNASPREMACommand", StringResources.STRUCNASPREMADescription, this.Site + ".BusinessComponents.Placa", 11, null, "STRUCNASPREMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.STRUKACommand", StringResources.STRUKADescription, this.Site + ".BusinessComponents.Placa", 11, null, "STRUKA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPIZNOSACommand", StringResources.TIPIZNOSADescription, this.Site + ".BusinessComponents.Placa", 11, null, "TIPIZNOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPOLAKSICECommand", StringResources.TIPOLAKSICEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "TIPOLAKSICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TITULACommand", StringResources.TITULADescription, this.Site + ".BusinessComponents.Placa", 11, null, "TITULA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.UGOVORORADUCommand", StringResources.UGOVORORADUDescription, this.Site + ".BusinessComponents.Placa", 11, null, "UGOVORORADU.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VALUTECommand", StringResources.VALUTEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "VALUTE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VIRMANICommand", StringResources.VIRMANIDescription, this.Site + ".BusinessComponents.Placa", 11, null, "VIRMANI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VRSTADOPRINOSCommand", StringResources.VRSTADOPRINOSDescription, this.Site + ".BusinessComponents.Placa", 11, null, "VRSTADOPRINOS.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VRSTAELEMENTCommand", StringResources.VRSTAELEMENTDescription, this.Site + ".BusinessComponents.Placa", 11, null, "VRSTAELEMENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VRSTAOBUSTAVECommand", StringResources.VRSTAOBUSTAVEDescription, this.Site + ".BusinessComponents.Placa", 11, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ZAPOSLENICommand", StringResources.ZAPOSLENIDescription, this.Site + ".BusinessComponents.Placa", 11, null, "ZAPOSLENI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("UcenickaPraksa", StringResources.MenuUcenickaPraksaFolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.UCENIKCommand", StringResources.UCENIKDescription, this.Site + ".BusinessComponents.UcenickaPraksa", 11, null, "UCENIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.UCENIKOBRACUNCommand", StringResources.UCENIKOBRACUNDescription, this.Site + ".BusinessComponents.UcenickaPraksa", 11, null, "UCENIKOBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.UCENIKRSMIDENTCommand", StringResources.UCENIKRSMIDENTDescription, this.Site + ".BusinessComponents.UcenickaPraksa", 11, null, "UCENIKRSMIDENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("VezeRAD1", StringResources.MenuVezeRAD1FolderMenu, this.Site + ".BusinessComponents", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1GELEMENTIVEZACommand", StringResources.RAD1GELEMENTIVEZADescription, this.Site + ".BusinessComponents.VezeRAD1", 11, null, "RAD1GELEMENTIVEZA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1MELEMENTIVEZACommand", StringResources.RAD1MELEMENTIVEZADescription, this.Site + ".BusinessComponents.VezeRAD1", 11, null, "RAD1MELEMENTIVEZA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1SPREMEVEZACommand", StringResources.RAD1SPREMEVEZADescription, this.Site + ".BusinessComponents.VezeRAD1", 11, null, "RAD1SPREMEVEZA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RAD1VEZASPOLCommand", StringResources.RAD1VEZASPOLDescription, this.Site + ".BusinessComponents.VezeRAD1", 11, null, "RAD1VEZASPOL.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DDVRSTEIZNOSACommand", StringResources.DDVRSTEIZNOSADescription, this.Site + ".BusinessComponents", 11, null, "DDVRSTEIZNOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.FINPOREZCommand", StringResources.FINPOREZDescription, this.Site + ".BusinessComponents", 11, null, "FINPOREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.IRAVRSTAIZNOSACommand", StringResources.IRAVRSTAIZNOSADescription, this.Site + ".BusinessComponents", 11, null, "IRAVRSTAIZNOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.JEDINICAMJERECommand", StringResources.JEDINICAMJEREDescription, this.Site + ".BusinessComponents", 11, null, "JEDINICAMJERE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PLVRSTEIZNOSACommand", StringResources.PLVRSTEIZNOSADescription, this.Site + ".BusinessComponents", 11, null, "PLVRSTEIZNOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PROIZVODCommand", StringResources.PROIZVODDescription, this.Site + ".BusinessComponents", 11, null, "PROIZVOD.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RACUNCommand", StringResources.RACUNDescription, this.Site + ".BusinessComponents", 11, null, "RACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SHEMADDCommand", StringResources.SHEMADDDescription, this.Site + ".BusinessComponents", 11, null, "SHEMADD.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SHEMAPLACACommand", StringResources.SHEMAPLACADescription, this.Site + ".BusinessComponents", 11, null, "SHEMAPLACA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.URAVRSTAIZNOSACommand", StringResources.URAVRSTAIZNOSADescription, this.Site + ".BusinessComponents", 11, null, "URAVRSTAIZNOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DataProviders", StringResources.MenuDataProvidersFolderMenu, this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DP_DD", StringResources.MenuDP_DDFolderMenu, this.Site + ".DataProviders", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_DD_IP1Command", StringResources.S_DD_IP1Description, this.Site + ".DataProviders.DP_DD", 13, null, "S_DD_IP1.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_DD_IPPCommand", StringResources.S_DD_IPPDescription, this.Site + ".DataProviders.DP_DD", 13, null, "S_DD_IPP.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_DD_KRIZNI_POREZCommand", StringResources.S_DD_KRIZNI_POREZDescription, this.Site + ".DataProviders.DP_DD", 13, null, "S_DD_KRIZNI_POREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_DD_LISTA_IZNOSA_RADNIKACommand", StringResources.S_DD_LISTA_IZNOSA_RADNIKADescription, this.Site + ".DataProviders.DP_DD", 13, null, "S_DD_LISTA_IZNOSA_RADNIKA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_DD_POTVRDACommand", StringResources.S_DD_POTVRDADescription, this.Site + ".DataProviders.DP_DD", 13, null, "S_DD_POTVRDA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_DD_REKAP_DOPRINOSCommand", StringResources.S_DD_REKAP_DOPRINOSDescription, this.Site + ".DataProviders.DP_DD", 13, null, "S_DD_REKAP_DOPRINOS.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.V_DD_GODINE_ISPLATECommand", StringResources.V_DD_GODINE_ISPLATEDescription, this.Site + ".DataProviders.DP_DD", 13, null, "V_DD_GODINE_ISPLATE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.V_DD_PREGLED_OBRACUNACommand", StringResources.V_DD_PREGLED_OBRACUNADescription, this.Site + ".DataProviders.DP_DD", 13, null, "V_DD_PREGLED_OBRACUNA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DP_FINPOS", StringResources.MenuDP_FINPOSFolderMenu, this.Site + ".DataProviders", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.partnerabecedaCommand", StringResources.partnerabecedaDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "partnerabeceda.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PREGLEDZADUZENJACommand", StringResources.PREGLEDZADUZENJADescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "PREGLEDZADUZENJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_BILANCACommand", StringResources.S_FIN_BILANCADescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_BILANCA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_BLAGAJNA_U_GKCommand", StringResources.S_FIN_BLAGAJNA_U_GKDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_BLAGAJNA_U_GK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_DNEVNIKCommand", StringResources.S_FIN_DNEVNIKDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_DNEVNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_DNEVNIKBLAGAJNECommand", StringResources.S_FIN_DNEVNIKBLAGAJNEDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_DNEVNIKBLAGAJNE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_DNEVNIKBLAGAJNEODDOCommand", StringResources.S_FIN_DNEVNIKBLAGAJNEODDODescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_DNEVNIKBLAGAJNEODDO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_FINANCIJSKO_UPRAVLJANJECommand", StringResources.S_FIN_FINANCIJSKO_UPRAVLJANJEDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_FINANCIJSKO_UPRAVLJANJE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_IRA_PLACANJECommand", StringResources.S_FIN_IRA_PLACANJEDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_IRA_PLACANJE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_IZVRSENJE_PLANACommand", StringResources.S_FIN_IZVRSENJE_PLANADescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_IZVRSENJE_PLANA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_KARTICEPARTNERACommand", StringResources.S_FIN_KARTICEPARTNERADescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_KARTICEPARTNERA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_KONTO_KARTICECommand", StringResources.S_FIN_KONTO_KARTICEDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_KONTO_KARTICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_OTVORENE_STAVKECommand", StringResources.S_FIN_OTVORENE_STAVKEDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_OTVORENE_STAVKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_PARTNERI_SA_OTVORENIMACommand", StringResources.S_FIN_PARTNERI_SA_OTVORENIMADescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_PARTNERI_SA_OTVORENIMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_PROMET_PO_KONTIMACommand", StringResources.S_FIN_PROMET_PO_KONTIMADescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_PROMET_PO_KONTIMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_FIN_PROMET_PO_PARTNERIMACommand", StringResources.S_FIN_PROMET_PO_PARTNERIMADescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "S_FIN_PROMET_PO_PARTNERIMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SP_FIN_URAPLACANJECommand", StringResources.SP_FIN_URAPLACANJEDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "SP_FIN_URAPLACANJE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.trazi_partneraCommand", StringResources.trazi_partneraDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "trazi_partnera.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.trazi_proizvodCommand", StringResources.trazi_proizvodDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "trazi_proizvod.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.uraDocsCommand", StringResources.uraDocsDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "uraDocs.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VW_ZADUZENI_PARTNERICommand", StringResources.VW_ZADUZENI_PARTNERIDescription, this.Site + ".DataProviders.DP_FINPOS", 13, null, "VW_ZADUZENI_PARTNERI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("DP_Placa", StringResources.MenuDP_PlacaFolderMenu, this.Site + ".DataProviders", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GODINA_I_MJESEC_OBRACUNACommand", StringResources.GODINA_I_MJESEC_OBRACUNADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "GODINA_I_MJESEC_OBRACUNA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PregledObracunaCommand", StringResources.PregledObracunaDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "PregledObracuna.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PregledRadnikaCommand", StringResources.PregledRadnikaDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "PregledRadnika.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PregledRadnikaSvihCommand", StringResources.PregledRadnikaSvihDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "PregledRadnikaSvih.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PROVIDER_BRUTOCommand", StringResources.PROVIDER_BRUTODescription, this.Site + ".DataProviders.DP_Placa", 13, null, "PROVIDER_BRUTO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PROVIDER_NETOCommand", StringResources.PROVIDER_NETODescription, this.Site + ".DataProviders.DP_Placa", 13, null, "PROVIDER_NETO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RadnikPripremaCommand", StringResources.RadnikPripremaDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "RadnikPriprema.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RadnikZaObracunCommand", StringResources.RadnikZaObracunDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "RadnikZaObracun.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_BOLOVANJE_FONDCommand", StringResources.S_OD_BOLOVANJE_FONDDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_BOLOVANJE_FOND.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_BOLOVANJE_POSLODAVACCommand", StringResources.S_OD_BOLOVANJE_POSLODAVACDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_BOLOVANJE_POSLODAVAC.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_IP_ZBIRNICommand", StringResources.S_OD_IP_ZBIRNIDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_IP_ZBIRNI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_IPPCommand", StringResources.S_OD_IPPDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_IPP.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_KONACNICommand", StringResources.S_OD_KONACNIDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_KONACNI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_KONACNI_POREZ_PO_OPCINAMACommand", StringResources.S_OD_KONACNI_POREZ_PO_OPCINAMADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_KONACNI_POREZ_PO_OPCINAMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_KREDIT_OBRACUNATCommand", StringResources.S_OD_KREDIT_OBRACUNATDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_KREDIT_OBRACUNAT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_KRIZNI_POREZCommand", StringResources.S_OD_KRIZNI_POREZDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_KRIZNI_POREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_OBUSTAVA_OBRACUNATACommand", StringResources.S_OD_OBUSTAVA_OBRACUNATADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_OBUSTAVA_OBRACUNATA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_OO_MJESECNOCommand", StringResources.S_OD_OO_MJESECNODescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_OO_MJESECNO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_POREZ_MJESECNOCommand", StringResources.S_OD_POREZ_MJESECNODescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_POREZ_MJESECNO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.s_od_pripremaCommand", StringResources.s_od_pripremaDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "s_od_priprema.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_PROSJEK_PLACECommand", StringResources.S_OD_PROSJEK_PLACEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_PROSJEK_PLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.s_od_rekap_brutoCommand", StringResources.s_od_rekap_brutoDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "s_od_rekap_bruto.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.s_od_rekap_doprinosCommand", StringResources.s_od_rekap_doprinosDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "s_od_rekap_doprinos.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_REKAP_FIKSNECommand", StringResources.S_OD_REKAP_FIKSNEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_REKAP_FIKSNE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_REKAP_ISPLATACommand", StringResources.S_OD_REKAP_ISPLATADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_REKAP_ISPLATA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_REKAP_KREDITNECommand", StringResources.S_OD_REKAP_KREDITNEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_REKAP_KREDITNE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_REKAP_NETOCommand", StringResources.S_OD_REKAP_NETODescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_REKAP_NETO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_REKAP_OLAKSICECommand", StringResources.S_OD_REKAP_OLAKSICEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_REKAP_OLAKSICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_REKAP_POREZCommand", StringResources.S_OD_REKAP_POREZDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_REKAP_POREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_REKAP_POSTOTNECommand", StringResources.S_OD_REKAP_POSTOTNEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_REKAP_POSTOTNE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_STANJE_KREDITACommand", StringResources.S_OD_STANJE_KREDITADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_STANJE_KREDITA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_STANJE_OBUSTAVACommand", StringResources.S_OD_STANJE_OBUSTAVADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_STANJE_OBUSTAVA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_STAT_KREDITCommand", StringResources.S_OD_STAT_KREDITDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_STAT_KREDIT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_OD_TABLICA01Command", StringResources.S_OD_TABLICA01Description, this.Site + ".DataProviders.DP_Placa", 13, null, "S_OD_TABLICA01.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMACommand", StringResources.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_KONACNI_REKAPOPCINECommand", StringResources.S_PLACA_KONACNI_REKAPOPCINEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_KONACNI_REKAPOPCINE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_KREDITI_KARTICECommand", StringResources.S_PLACA_KREDITI_KARTICEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_KREDITI_KARTICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_ODBICI_GODINACommand", StringResources.S_PLACA_ODBICI_GODINADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_ODBICI_GODINA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_RAD1GCommand", StringResources.S_PLACA_RAD1GDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_RAD1G.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_RAD1G_IIICommand", StringResources.S_PLACA_RAD1G_IIIDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_RAD1G_III.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_RAD1G_IVCommand", StringResources.S_PLACA_RAD1G_IVDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_RAD1G_IV.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_RAD1G_SATICommand", StringResources.S_PLACA_RAD1G_SATIDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_RAD1G_SATI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_RAD1M_DIO1Command", StringResources.S_PLACA_RAD1M_DIO1Description, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_RAD1M_DIO1.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_RAD1M_DIO2Command", StringResources.S_PLACA_RAD1M_DIO2Description, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_RAD1M_DIO2.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_RAD1M_DIO3Command", StringResources.S_PLACA_RAD1M_DIO3Description, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_RAD1M_DIO3.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.S_PLACA_SIFREOBRACUNACommand", StringResources.S_PLACA_SIFREOBRACUNADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "S_PLACA_SIFREOBRACUNA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_diskete_za_bankuCommand", StringResources.sp_diskete_za_bankuDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_diskete_za_banku.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_id_detaljiCommand", StringResources.sp_id_detaljiDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_id_detalji.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_id_zaglavljeCommand", StringResources.sp_id_zaglavljeDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_id_zaglavlje.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_ip_detaljiCommand", StringResources.sp_ip_detaljiDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_ip_detalji.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_ip_zaglavljeCommand", StringResources.sp_ip_zaglavljeDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_ip_zaglavlje.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SP_LISTA_IZNOSA_RADNIKACommand", StringResources.SP_LISTA_IZNOSA_RADNIKADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "SP_LISTA_IZNOSA_RADNIKA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_maticni_kartonCommand", StringResources.sp_maticni_kartonDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_maticni_karton.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_REKAP_ISPLATACommand", StringResources.sp_REKAP_ISPLATADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_REKAP_ISPLATA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_RSOBRAZACCommand", StringResources.sp_RSOBRAZACDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_RSOBRAZAC.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_VIRMANICommand", StringResources.sp_VIRMANIDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_VIRMANI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.sp_zap1Command", StringResources.sp_zap1Description, this.Site + ".DataProviders.DP_Placa", 13, null, "sp_zap1.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.vw_DD_MJESECI_GODINE_ISPLATECommand", StringResources.vw_DD_MJESECI_GODINE_ISPLATEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "vw_DD_MJESECI_GODINE_ISPLATE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VW_GODINE_ISPLATECommand", StringResources.VW_GODINE_ISPLATEDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "VW_GODINE_ISPLATE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VW_GODINE_OBRACUNACommand", StringResources.VW_GODINE_OBRACUNADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "VW_GODINE_OBRACUNA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.vw_mjeseci_godine_isplateCommand", StringResources.vw_mjeseci_godine_isplateDescription, this.Site + ".DataProviders.DP_Placa", 13, null, "vw_mjeseci_godine_isplate.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VW_MJESECI_GODINE_OBRACUNACommand", StringResources.VW_MJESECI_GODINE_OBRACUNADescription, this.Site + ".DataProviders.DP_Placa", 13, null, "VW_MJESECI_GODINE_OBRACUNA.Select"));
        }

        protected override void OnActivated()
        {
            base.OnActivated();
        }

        protected override void OnRunStarted()
        {
            this.MenuEntryAdapter.AddElements(this.RootWorkItem, this.m_UICommandDefinitionContainer, null);
            this.Items.AddNew<MainController>();
            base.OnRunStarted();
        }

        [OnBuiltUp]
        public void Prosiriizbornik()
        {
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OpciSifrarnici", "Opći šifrarnici", this.Site + "", 11, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KORISNIKCommand", "Korisnik aplikacije", this.Site + ".OpciSifrarnici", 11, null, "KORISNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.IZVORDOKUMENTACommand", "FINA - Izvor dokumenta", this.Site + ".OpciSifrarnici", 11, null, "IZVORDOKUMENTA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VRSTAELEMENTCommand", "Vrste elemenata", this.Site + ".OpciSifrarnici", 11, null, "VRSTAELEMENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ELEMENTCommand", "Elementi", this.Site + ".OpciSifrarnici", My.Resources.ResourcesPlacaExe.elementi, null, "ELEMENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSOBNIODBITAKCommand", StringResources.OSOBNIODBITAKDescription, this.Site + ".OpciSifrarnici", 11, null, "OSOBNIODBITAK.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RSVRSTEOBRACUNACommand", "RSm Vrste obračuna", this.Site + ".OpciSifrarnici", 11, null, "RSVRSTEOBRACUNA.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RSVRSTEOBVEZNIKACommand", "RSm Vrste obveznika", this.Site + ".OpciSifrarnici", 11, null, "RSVRSTEOBVEZNIKA.Select"));
            //this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OSNOVAOSIGURANJACommand", "RSm Osnove osiguranja", this.Site + ".OpciSifrarnici", 11, null, "OSNOVAOSIGURANJA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.IPIDENTCommand", "IP - identifikatori", this.Site + ".OpciSifrarnici", 11, null, "IPIDENT.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VRSTADOPRINOSCommand", "Vrste doprinosa", this.Site + ".OpciSifrarnici", 11, null, "VRSTADOPRINOS.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.DOPRINOSCommand", StringResources.DOPRINOSDescription, this.Site + ".OpciSifrarnici", 11, null, "DOPRINOS.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPIZNOSACommand", StringResources.TIPIZNOSADescription, this.Site + ".OpciSifrarnici", 11, null, "TIPIZNOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OPCINACommand", StringResources.OPCINADescription, this.Site + ".OpciSifrarnici", 11, null, "OPCINA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SKUPPOREZAIDOPRINOSACommand", "Skupine poreza i doprinosa", this.Site + ".OpciSifrarnici", 11, null, "SKUPPOREZAIDOPRINOSA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.POREZCommand", StringResources.POREZDescription, this.Site + ".OpciSifrarnici", 11, null, "POREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KRIZNIPOREZCommand", "Posebni porez na n.pl", this.Site + ".OpciSifrarnici", 11, null, "KRIZNIPOREZ.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VRSTAOBUSTAVECommand", "Vrste obustava", this.Site + ".OpciSifrarnici", 11, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.KREDITORCommand", StringResources.KREDITORDescription, this.Site + ".OpciSifrarnici", 11, null, "KREDITOR.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OBUSTAVACommand", StringResources.OBUSTAVADescription, this.Site + ".OpciSifrarnici", 11, null, "OBUSTAVA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GRUPEOLAKSICACommand", "Grupe olakšica", this.Site + ".OpciSifrarnici", 11, null, "GRUPEOLAKSICA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TIPOLAKSICECommand", "Tipovi olakšica", this.Site + ".OpciSifrarnici", 11, null, "TIPOLAKSICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OLAKSICECommand", StringResources.OLAKSICEDescription, this.Site + ".OpciSifrarnici", 11, null, "OLAKSICE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BANKECommand", StringResources.BANKEDescription, this.Site + ".OpciSifrarnici", 11, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.GRUPEKOEFCommand", "Grupe koeficijenata", this.Site + ".OpciSifrarnici", 11, null, "GRUPEKOEF.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BOLOVANJEFONDCommand", "Bolovanje FOND/config", this.Site + ".OpciSifrarnici", 11, null, "BOLOVANJEFOND.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.SPOLCommand", "Spol", this.Site + ".OpciSifrarnici", 11, null, "SPOL.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BRACNOSTANJECommand", "Bračno stanje", this.Site + ".OpciSifrarnici", 11, null, "BRACNOSTANJE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BENEFICIRANICommand", "Beneficirani staž", this.Site + ".OpciSifrarnici", 11, null, "BENEFICIRANI.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RADNOMJESTOCommand", "Radna mjesta", this.Site + ".OpciSifrarnici", 11, null, "RADNOMJESTO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.STRUCNASPREMACommand", "Stručne spreme", this.Site + ".OpciSifrarnici", My.Resources.ResourcesPlacaExe.strucna_sprema, null, "STRUCNASPREMA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.STRUKACommand", "Struka", this.Site + ".OpciSifrarnici", 11, null, "STRUKA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ORGDIOCommand", "Organizacijske cjeline", this.Site + ".OpciSifrarnici", 11, null, "ORGDIO.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.TITULACommand", "Titule", this.Site + ".OpciSifrarnici", 11, null, "TITULA.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ObracunPlace", "Obračun plaće", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RADNIKCommand", StringResources.RADNIKDescription, this.Site + ".ObracunPlace", My.Resources.ResourcesPlacaExe.Zaposlenici, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.BrziUnosKreditaCommand", "Brzi unos kredita", this.Site + ".ObracunPlace", My.Resources.ResourcesPlacaExe.Zaposlenici, null, "RADNIK.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PRPLACECommand", "Priprema plaće", this.Site + ".ObracunPlace", My.Resources.ResourcesPlacaExe.priprema, null, "PRPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PripremaCommand", "Obračun", this.Site + ".ObracunPlace", My.Resources.ResourcesPlacaExe.obracun_place_2, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.RSMObrazacCommand", "R-Sm Obrazac", this.Site + ".ObracunPlace", RuntimeHelpers.GetObjectValue(My.Resources.ResourcesPlacaExe.eRegos2.Clone()), null, "VRSTAOBUSTAVE.Select"));
            
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.VirmaniUserCommand", "Virmani", this.Site + ".ObracunPlace", My.Resources.ResourcesPlacaExe.virmani, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.PrPlaceCustom", "Novi unos pripreme", this.Site + ".ObracunPlace", 11, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OS.UnosTemeljnice", "OS Unos tem", this.Site + ".ObracunPlace", 11, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OS.Amortizacija", "Amortizacija", this.Site + ".ObracunPlace", 11, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OS.TablicniRazmjestaj", "TablicniRazmjestaj", this.Site + ".ObracunPlace", 11, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("OS.InventurnaLista", "InventurnaLista", this.Site + ".ObracunPlace", 11, null, "VRSTAOBUSTAVE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Pregledi", "Izvještaji-pregledi", this.Site + "", 0, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ListaIznosaCommand", "Lista iznosa zaposlenika", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.obrazac, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ZAP1Command", "ZAP-1 Obrazac", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.obrazac, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IDObrazacCommand", "ID Obrazac", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.obrazac, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IPPObrazacCommand", "IPP Obrazac", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.obrazac, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Tablica01Command", "Tablica 01/10", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.obrazac, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Tablica018Command", "Tablica 018", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.obrazac, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IPKarticeCommand", "IP Obrasci", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.obrazac, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("MaticniKartonCommand", "Matični karton", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.maticni_karton, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Godisnji", "Prosjek za GO", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.godisnji_odmor, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.Bolovanje", "Prosjek bolovanje", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.bolovanje, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.FondBolovanje", "Prosjek bolovanje/HZZO", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.doctor, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.ProsjekPlace", "Prosjek neto plaće", this.Site + ".Pregledi", My.Resources.ResourcesPlacaExe.doctor, null, "PRIPREMAPLACE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("ServisneFunkcije", "Servisne funkcije", this.Site + "", 11, false, true, DeklaritMode.All));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Margine", "Margine", this.Site + ".ServisneFunkcije", My.Resources.ResourcesPlacaExe._default, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("BazePodataka", "Rad sa bazama", this.Site + ".ServisneFunkcije", My.Resources.ResourcesPlacaExe._default, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("IMPORTIP", "IP Obrasci DOS", this.Site + ".ServisneFunkcije", My.Resources.ResourcesPlacaExe._default, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("PRIPREMA", "Priprema plaće", this.Site + ".ServisneFunkcije", My.Resources.ResourcesPlacaExe._default, null, "BANKE.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Placa.OBRACUNCommand", "Ručna korekcija iznosa", this.Site + ".ServisneFunkcije", My.Resources.ResourcesPlacaExe._default, null, "OBRACUN.Select"));
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("JavnaNabava", "Javna nabava", this.Site + "", 11, false, true, DeklaritMode.All));
            //hrvoje Materijalno
            this.m_UICommandDefinitionContainer.Add(new UICommandDefinition("Materijalno", "Materijalno", this.Site + "", 11, false, true, DeklaritMode.All));

            // moduleGlobal.g_connection = Helper.UsingOpenExeConfiguration2();
            // Configuration.ConfigurationProvider = new DefaultConfigurationProvider();
        }

        [ServiceDependency(Type=typeof(IUICommandDefinitionMenuAdapterService))]
        public virtual IUICommandDefinitionAdapterService MainMenuEntryAdapter
        {
            get
            {
                return this.m_MenuAdapterService;
            }
            set
            {
                this.m_MenuAdapterService = value;
            }
        }

        [ServiceDependency(Type=typeof(IUICommandDefinitionVerticalToolPanelAdapterService))]
        public virtual IUICommandDefinitionAdapterService MenuEntryAdapter
        {
            get
            {
                return this.m_UICommandDefinitionAdapterService;
            }
            set
            {
                this.m_UICommandDefinitionAdapterService = value;
            }
        }

        public string Site
        {
            get
            {
                return "MainMenu";
            }
        }

        public Deklarit.Practices.CompositeUI.UICommandDefinitionContainer UICommandDefinitionContainer
        {
            get
            {
                return this.m_UICommandDefinitionContainer;
            }
        }
    }
}

