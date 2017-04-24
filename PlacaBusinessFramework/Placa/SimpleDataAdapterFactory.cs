namespace Placa
{
    using Deklarit.Configuration;
    using Deklarit.Data;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
    using System;
    using System.Data;

    public class SimpleDataAdapterFactory : IDataAdapterFactory, IConnectedDataAdapterFactory
    {
        public virtual IAKTIVNOSTDataAdapter GetAKTIVNOSTDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<AKTIVNOSTDataAdapter, IAKTIVNOSTDataAdapter>(new object[0]);
        }

        public virtual IAMSKUPINEDataAdapter GetAMSKUPINEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<AMSKUPINEDataAdapter, IAMSKUPINEDataAdapter>(new object[0]);
        }

        public virtual IBANKEDataAdapter GetBANKEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<BANKEDataAdapter, IBANKEDataAdapter>(new object[0]);
        }

        public virtual IBENEFICIRANIDataAdapter GetBENEFICIRANIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<BENEFICIRANIDataAdapter, IBENEFICIRANIDataAdapter>(new object[0]);
        }

        public virtual IBLAGAJNADataAdapter GetBLAGAJNADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<BLAGAJNADataAdapter, IBLAGAJNADataAdapter>(new object[0]);
        }

        public virtual IBLGVRSTEDOKDataAdapter GetBLGVRSTEDOKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<BLGVRSTEDOKDataAdapter, IBLGVRSTEDOKDataAdapter>(new object[0]);
        }

        public virtual IBOLOVANJEFONDDataAdapter GetBOLOVANJEFONDDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<BOLOVANJEFONDDataAdapter, IBOLOVANJEFONDDataAdapter>(new object[0]);
        }

        public virtual IBRACNOSTANJEDataAdapter GetBRACNOSTANJEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<BRACNOSTANJEDataAdapter, IBRACNOSTANJEDataAdapter>(new object[0]);
        }

        public virtual IDDIZDATAKDataAdapter GetDDIZDATAKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DDIZDATAKDataAdapter, IDDIZDATAKDataAdapter>(new object[0]);
        }

        public virtual IDDKATEGORIJADataAdapter GetDDKATEGORIJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DDKATEGORIJADataAdapter, IDDKATEGORIJADataAdapter>(new object[0]);
        }

        public virtual IDDKOLONAIDDDataAdapter GetDDKOLONAIDDDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DDKOLONAIDDDataAdapter, IDDKOLONAIDDDataAdapter>(new object[0]);
        }

        public virtual IDDOBRACUNDataAdapter GetDDOBRACUNDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DDOBRACUNDataAdapter, IDDOBRACUNDataAdapter>(new object[0]);
        }

        public virtual IDDRADNIKDataAdapter GetDDRADNIKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DDRADNIKDataAdapter, IDDRADNIKDataAdapter>(new object[0]);
        }

        public virtual IDDVRSTEIZNOSADataAdapter GetDDVRSTEIZNOSADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DDVRSTEIZNOSADataAdapter, IDDVRSTEIZNOSADataAdapter>(new object[0]);
        }

        public virtual IDDVRSTEPOSLADataAdapter GetDDVRSTEPOSLADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DDVRSTEPOSLADataAdapter, IDDVRSTEPOSLADataAdapter>(new object[0]);
        }

        public IDeklaritTransaction GetDeklaritTransaction()
        {
            return new DeklaritTransaction();
        }

        public IDeklaritTransaction GetDeklaritTransaction(IsolationLevel level)
        {
            return new DeklaritTransaction(level);
        }

        public virtual IDOKUMENTDataAdapter GetDOKUMENTDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DOKUMENTDataAdapter, IDOKUMENTDataAdapter>(new object[0]);
        }

        public virtual IDOPRINOSDataAdapter GetDOPRINOSDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DOPRINOSDataAdapter, IDOPRINOSDataAdapter>(new object[0]);
        }

        public virtual IDOSIPZAGLAVLJEDataAdapter GetDOSIPZAGLAVLJEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DOSIPZAGLAVLJEDataAdapter, IDOSIPZAGLAVLJEDataAdapter>(new object[0]);
        }

        public virtual IDRZAVLJANSTVODataAdapter GetDRZAVLJANSTVODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<DRZAVLJANSTVODataAdapter, IDRZAVLJANSTVODataAdapter>(new object[0]);
        }

        public virtual IELEMENTDataAdapter GetELEMENTDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<ELEMENTDataAdapter, IELEMENTDataAdapter>(new object[0]);
        }

        public virtual IEVIDENCIJADataAdapter GetEVIDENCIJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<EVIDENCIJADataAdapter, IEVIDENCIJADataAdapter>(new object[0]);
        }

        public virtual IFINPOREZDataAdapter GetFINPOREZDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<FINPOREZDataAdapter, IFINPOREZDataAdapter>(new object[0]);
        }

        public virtual IGKSTAVKADataAdapter GetGKSTAVKADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<GKSTAVKADataAdapter, IGKSTAVKADataAdapter>(new object[0]);
        }

        public virtual IGODINA_I_MJESEC_OBRACUNADataAdapter GetGODINA_I_MJESEC_OBRACUNADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<GODINA_I_MJESEC_OBRACUNADataAdapter, IGODINA_I_MJESEC_OBRACUNADataAdapter>(new object[0]);
        }

        public virtual IGODINEDataAdapter GetGODINEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<GODINEDataAdapter, IGODINEDataAdapter>(new object[0]);
        }

        public virtual IGOOBRACUNDataAdapter GetGOOBRACUNDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<GOOBRACUNDataAdapter, IGOOBRACUNDataAdapter>(new object[0]);
        }

        public virtual IGRUPEKOEFDataAdapter GetGRUPEKOEFDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<GRUPEKOEFDataAdapter, IGRUPEKOEFDataAdapter>(new object[0]);
        }

        public virtual IGRUPEOLAKSICADataAdapter GetGRUPEOLAKSICADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<GRUPEOLAKSICADataAdapter, IGRUPEOLAKSICADataAdapter>(new object[0]);
        }

        public virtual IIPIDENTDataAdapter GetIPIDENTDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<IPIDENTDataAdapter, IIPIDENTDataAdapter>(new object[0]);
        }

        public virtual IIRADataAdapter GetIRADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<IRADataAdapter, IIRADataAdapter>(new object[0]);
        }

        public virtual IIRAVRSTAIZNOSADataAdapter GetIRAVRSTAIZNOSADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<IRAVRSTAIZNOSADataAdapter, IIRAVRSTAIZNOSADataAdapter>(new object[0]);
        }

        public virtual IIZVORDOKUMENTADataAdapter GetIZVORDOKUMENTADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<IZVORDOKUMENTADataAdapter, IIZVORDOKUMENTADataAdapter>(new object[0]);
        }

        public virtual IJEDINICAMJEREDataAdapter GetJEDINICAMJEREDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<JEDINICAMJEREDataAdapter, IJEDINICAMJEREDataAdapter>(new object[0]);
        }

        public virtual IKONTODataAdapter GetKONTODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<KONTODataAdapter, IKONTODataAdapter>(new object[0]);
        }

        public virtual IKORISNIKDataAdapter GetKORISNIKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<KORISNIKDataAdapter, IKORISNIKDataAdapter>(new object[0]);
        }

        public virtual IKREDITORDataAdapter GetKREDITORDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<KREDITORDataAdapter, IKREDITORDataAdapter>(new object[0]);
        }

        public virtual IKRIZNIPOREZDataAdapter GetKRIZNIPOREZDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<KRIZNIPOREZDataAdapter, IKRIZNIPOREZDataAdapter>(new object[0]);
        }

        public virtual ILOKACIJEDataAdapter GetLOKACIJEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<LOKACIJEDataAdapter, ILOKACIJEDataAdapter>(new object[0]);
        }

        public virtual IMJESTOTROSKADataAdapter GetMJESTOTROSKADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<MJESTOTROSKADataAdapter, IMJESTOTROSKADataAdapter>(new object[0]);
        }

        public virtual IMZOSTABLICEDataAdapter GetMZOSTABLICEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<MZOSTABLICEDataAdapter, IMZOSTABLICEDataAdapter>(new object[0]);
        }

        public virtual IOBRACUNDataAdapter GetOBRACUNDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OBRACUNDataAdapter, IOBRACUNDataAdapter>(new object[0]);
        }

        public virtual IOBUSTAVADataAdapter GetOBUSTAVADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OBUSTAVADataAdapter, IOBUSTAVADataAdapter>(new object[0]);
        }

        public virtual IOLAKSICEDataAdapter GetOLAKSICEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OLAKSICEDataAdapter, IOLAKSICEDataAdapter>(new object[0]);
        }

        public virtual IOPCINADataAdapter GetOPCINADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OPCINADataAdapter, IOPCINADataAdapter>(new object[0]);
        }

        public virtual IORGDIODataAdapter GetORGDIODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<ORGDIODataAdapter, IORGDIODataAdapter>(new object[0]);
        }

        public virtual IORGJEDDataAdapter GetORGJEDDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<ORGJEDDataAdapter, IORGJEDDataAdapter>(new object[0]);
        }

        public virtual IOSDataAdapter GetOSDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OSDataAdapter, IOSDataAdapter>(new object[0]);
        }

        public virtual IOSDOKUMENTDataAdapter GetOSDOKUMENTDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OSDOKUMENTDataAdapter, IOSDOKUMENTDataAdapter>(new object[0]);
        }

        public virtual IOSNOVAOSIGURANJADataAdapter GetOSNOVAOSIGURANJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OSNOVAOSIGURANJADataAdapter, IOSNOVAOSIGURANJADataAdapter>(new object[0]);
        }

        public virtual IOSOBNIODBITAKDataAdapter GetOSOBNIODBITAKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OSOBNIODBITAKDataAdapter, IOSOBNIODBITAKDataAdapter>(new object[0]);
        }

        public virtual IOSRAZMJESTAJDataAdapter GetOSRAZMJESTAJDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OSRAZMJESTAJDataAdapter, IOSRAZMJESTAJDataAdapter>(new object[0]);
        }

        public virtual IOSVRSTADataAdapter GetOSVRSTADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OSVRSTADataAdapter, IOSVRSTADataAdapter>(new object[0]);
        }

        public virtual IOTISLIDataAdapter GetOTISLIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<OTISLIDataAdapter, IOTISLIDataAdapter>(new object[0]);
        }

        public virtual IpartnerabecedaDataAdapter GetpartnerabecedaDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<partnerabecedaDataAdapter, IpartnerabecedaDataAdapter>(new object[0]);
        }

        public virtual IPARTNERDataAdapter GetPARTNERDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PARTNERDataAdapter, IPARTNERDataAdapter>(new object[0]);
        }

        public virtual IPLANDataAdapter GetPLANDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PLANDataAdapter, IPLANDataAdapter>(new object[0]);
        }

        public virtual IPLVRSTEIZNOSADataAdapter GetPLVRSTEIZNOSADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PLVRSTEIZNOSADataAdapter, IPLVRSTEIZNOSADataAdapter>(new object[0]);
        }

        public virtual IPOREZDataAdapter GetPOREZDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<POREZDataAdapter, IPOREZDataAdapter>(new object[0]);
        }

        public virtual IPOSTANSKIBROJEVIDataAdapter GetPOSTANSKIBROJEVIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<POSTANSKIBROJEVIDataAdapter, IPOSTANSKIBROJEVIDataAdapter>(new object[0]);
        }

        public virtual IPregledObracunaDataAdapter GetPregledObracunaDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PregledObracunaDataAdapter, IPregledObracunaDataAdapter>(new object[0]);
        }

        public virtual IPregledRadnikaDataAdapter GetPregledRadnikaDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PregledRadnikaDataAdapter, IPregledRadnikaDataAdapter>(new object[0]);
        }

        public virtual IPregledRadnikaSvihDataAdapter GetPregledRadnikaSvihDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PregledRadnikaSvihDataAdapter, IPregledRadnikaSvihDataAdapter>(new object[0]);
        }

        public virtual IPREGLEDZADUZENJADataAdapter GetPREGLEDZADUZENJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PREGLEDZADUZENJADataAdapter, IPREGLEDZADUZENJADataAdapter>(new object[0]);
        }

        public virtual IPROIZVODDataAdapter GetPROIZVODDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PROIZVODDataAdapter, IPROIZVODDataAdapter>(new object[0]);
        }

        public virtual IPROVIDER_BRUTODataAdapter GetPROVIDER_BRUTODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PROVIDER_BRUTODataAdapter, IPROVIDER_BRUTODataAdapter>(new object[0]);
        }

        public virtual IPROVIDER_NETODataAdapter GetPROVIDER_NETODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PROVIDER_NETODataAdapter, IPROVIDER_NETODataAdapter>(new object[0]);
        }

        public virtual IPRPLACEDataAdapter GetPRPLACEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<PRPLACEDataAdapter, IPRPLACEDataAdapter>(new object[0]);
        }

        public virtual IRACUNDataAdapter GetRACUNDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RACUNDataAdapter, IRACUNDataAdapter>(new object[0]);
        }

        public virtual IRAD1GELEMENTIDataAdapter GetRAD1GELEMENTIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1GELEMENTIDataAdapter, IRAD1GELEMENTIDataAdapter>(new object[0]);
        }

        public virtual IRAD1GELEMENTIVEZADataAdapter GetRAD1GELEMENTIVEZADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1GELEMENTIVEZADataAdapter, IRAD1GELEMENTIVEZADataAdapter>(new object[0]);
        }

        public virtual IRAD1MELEMENTIDataAdapter GetRAD1MELEMENTIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1MELEMENTIDataAdapter, IRAD1MELEMENTIDataAdapter>(new object[0]);
        }

        public virtual IRAD1MELEMENTIVEZADataAdapter GetRAD1MELEMENTIVEZADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1MELEMENTIVEZADataAdapter, IRAD1MELEMENTIVEZADataAdapter>(new object[0]);
        }

        public virtual IRAD1SPOLDataAdapter GetRAD1SPOLDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1SPOLDataAdapter, IRAD1SPOLDataAdapter>(new object[0]);
        }

        public virtual IRAD1SPREMEDataAdapter GetRAD1SPREMEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1SPREMEDataAdapter, IRAD1SPREMEDataAdapter>(new object[0]);
        }

        public virtual IRAD1SPREMEVEZADataAdapter GetRAD1SPREMEVEZADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1SPREMEVEZADataAdapter, IRAD1SPREMEVEZADataAdapter>(new object[0]);
        }

        public virtual IRAD1VEZASPOLDataAdapter GetRAD1VEZASPOLDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RAD1VEZASPOLDataAdapter, IRAD1VEZASPOLDataAdapter>(new object[0]);
        }

        public virtual IRADNIKDataAdapter GetRADNIKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RADNIKDataAdapter, IRADNIKDataAdapter>(new object[0]);
        }

        public virtual IRadnikPripremaDataAdapter GetRadnikPripremaDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RadnikPripremaDataAdapter, IRadnikPripremaDataAdapter>(new object[0]);
        }

        public virtual IRadnikZaObracunDataAdapter GetRadnikZaObracunDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RadnikZaObracunDataAdapter, IRadnikZaObracunDataAdapter>(new object[0]);
        }

        public virtual IRADNOMJESTODataAdapter GetRADNOMJESTODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RADNOMJESTODataAdapter, IRADNOMJESTODataAdapter>(new object[0]);
        }

        public virtual IRADNOVRIJEMEDataAdapter GetRADNOVRIJEMEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RADNOVRIJEMEDataAdapter, IRADNOVRIJEMEDataAdapter>(new object[0]);
        }

        public virtual IRSMADataAdapter GetRSMADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RSMADataAdapter, IRSMADataAdapter>(new object[0]);
        }

        public virtual IRSVRSTEOBRACUNADataAdapter GetRSVRSTEOBRACUNADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RSVRSTEOBRACUNADataAdapter, IRSVRSTEOBRACUNADataAdapter>(new object[0]);
        }

        public virtual IRSVRSTEOBVEZNIKADataAdapter GetRSVRSTEOBVEZNIKADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<RSVRSTEOBVEZNIKADataAdapter, IRSVRSTEOBVEZNIKADataAdapter>(new object[0]);
        }

        public virtual IS_DD_IP1DataAdapter GetS_DD_IP1DataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_DD_IP1DataAdapter, IS_DD_IP1DataAdapter>(new object[0]);
        }

        public virtual IS_DD_IPPDataAdapter GetS_DD_IPPDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_DD_IPPDataAdapter, IS_DD_IPPDataAdapter>(new object[0]);
        }

        public virtual IS_DD_KRIZNI_POREZDataAdapter GetS_DD_KRIZNI_POREZDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_DD_KRIZNI_POREZDataAdapter, IS_DD_KRIZNI_POREZDataAdapter>(new object[0]);
        }

        public virtual IS_DD_LISTA_IZNOSA_RADNIKADataAdapter GetS_DD_LISTA_IZNOSA_RADNIKADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_DD_LISTA_IZNOSA_RADNIKADataAdapter, IS_DD_LISTA_IZNOSA_RADNIKADataAdapter>(new object[0]);
        }

        public virtual IS_DD_POTVRDADataAdapter GetS_DD_POTVRDADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_DD_POTVRDADataAdapter, IS_DD_POTVRDADataAdapter>(new object[0]);
        }

        public virtual IS_DD_REKAP_DOPRINOSDataAdapter GetS_DD_REKAP_DOPRINOSDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_DD_REKAP_DOPRINOSDataAdapter, IS_DD_REKAP_DOPRINOSDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_BILANCADataAdapter GetS_FIN_BILANCADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_BILANCADataAdapter, IS_FIN_BILANCADataAdapter>(new object[0]);
        }

        public virtual IS_FIN_BLAGAJNA_U_GKDataAdapter GetS_FIN_BLAGAJNA_U_GKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_BLAGAJNA_U_GKDataAdapter, IS_FIN_BLAGAJNA_U_GKDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_DNEVNIKBLAGAJNEDataAdapter GetS_FIN_DNEVNIKBLAGAJNEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_DNEVNIKBLAGAJNEDataAdapter, IS_FIN_DNEVNIKBLAGAJNEDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_DNEVNIKBLAGAJNEODDODataAdapter GetS_FIN_DNEVNIKBLAGAJNEODDODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_DNEVNIKBLAGAJNEODDODataAdapter, IS_FIN_DNEVNIKBLAGAJNEODDODataAdapter>(new object[0]);
        }

        public virtual IS_FIN_DNEVNIKDataAdapter GetS_FIN_DNEVNIKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_DNEVNIKDataAdapter, IS_FIN_DNEVNIKDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter GetS_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter, IS_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_IRA_PLACANJEDataAdapter GetS_FIN_IRA_PLACANJEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_IRA_PLACANJEDataAdapter, IS_FIN_IRA_PLACANJEDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_IZVRSENJE_PLANADataAdapter GetS_FIN_IZVRSENJE_PLANADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_IZVRSENJE_PLANADataAdapter, IS_FIN_IZVRSENJE_PLANADataAdapter>(new object[0]);
        }

        public virtual IS_FIN_KARTICEPARTNERADataAdapter GetS_FIN_KARTICEPARTNERADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_KARTICEPARTNERADataAdapter, IS_FIN_KARTICEPARTNERADataAdapter>(new object[0]);
        }

        public virtual IS_FIN_KONTO_KARTICEDataAdapter GetS_FIN_KONTO_KARTICEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_KONTO_KARTICEDataAdapter, IS_FIN_KONTO_KARTICEDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_OTVORENE_STAVKEDataAdapter GetS_FIN_OTVORENE_STAVKEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_OTVORENE_STAVKEDataAdapter, IS_FIN_OTVORENE_STAVKEDataAdapter>(new object[0]);
        }

        public virtual IS_FIN_PARTNERI_SA_OTVORENIMADataAdapter GetS_FIN_PARTNERI_SA_OTVORENIMADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_PARTNERI_SA_OTVORENIMADataAdapter, IS_FIN_PARTNERI_SA_OTVORENIMADataAdapter>(new object[0]);
        }

        public virtual IS_FIN_PROMET_PO_KONTIMADataAdapter GetS_FIN_PROMET_PO_KONTIMADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_PROMET_PO_KONTIMADataAdapter, IS_FIN_PROMET_PO_KONTIMADataAdapter>(new object[0]);
        }

        public virtual IS_FIN_PROMET_PO_PARTNERIMADataAdapter GetS_FIN_PROMET_PO_PARTNERIMADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_FIN_PROMET_PO_PARTNERIMADataAdapter, IS_FIN_PROMET_PO_PARTNERIMADataAdapter>(new object[0]);
        }

        public virtual IS_OD_BOLOVANJE_FONDDataAdapter GetS_OD_BOLOVANJE_FONDDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_BOLOVANJE_FONDDataAdapter, IS_OD_BOLOVANJE_FONDDataAdapter>(new object[0]);
        }

        public virtual IS_OD_BOLOVANJE_POSLODAVACDataAdapter GetS_OD_BOLOVANJE_POSLODAVACDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_BOLOVANJE_POSLODAVACDataAdapter, IS_OD_BOLOVANJE_POSLODAVACDataAdapter>(new object[0]);
        }

        public virtual IS_OD_IP_ZBIRNIDataAdapter GetS_OD_IP_ZBIRNIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_IP_ZBIRNIDataAdapter, IS_OD_IP_ZBIRNIDataAdapter>(new object[0]);
        }

        public virtual IS_OD_IPPDataAdapter GetS_OD_IPPDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_IPPDataAdapter, IS_OD_IPPDataAdapter>(new object[0]);
        }

        public virtual IS_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter GetS_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter, IS_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter>(new object[0]);
        }

        public virtual IS_OD_KONACNIDataAdapter GetS_OD_KONACNIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_KONACNIDataAdapter, IS_OD_KONACNIDataAdapter>(new object[0]);
        }

        public virtual IS_OD_KREDIT_OBRACUNATDataAdapter GetS_OD_KREDIT_OBRACUNATDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_KREDIT_OBRACUNATDataAdapter, IS_OD_KREDIT_OBRACUNATDataAdapter>(new object[0]);
        }

        public virtual IS_OD_KRIZNI_POREZDataAdapter GetS_OD_KRIZNI_POREZDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_KRIZNI_POREZDataAdapter, IS_OD_KRIZNI_POREZDataAdapter>(new object[0]);
        }

        public virtual IS_OD_OBUSTAVA_OBRACUNATADataAdapter GetS_OD_OBUSTAVA_OBRACUNATADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_OBUSTAVA_OBRACUNATADataAdapter, IS_OD_OBUSTAVA_OBRACUNATADataAdapter>(new object[0]);
        }

        public virtual IS_OD_OO_MJESECNODataAdapter GetS_OD_OO_MJESECNODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_OO_MJESECNODataAdapter, IS_OD_OO_MJESECNODataAdapter>(new object[0]);
        }

        public virtual IS_OD_POREZ_MJESECNODataAdapter GetS_OD_POREZ_MJESECNODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_POREZ_MJESECNODataAdapter, IS_OD_POREZ_MJESECNODataAdapter>(new object[0]);
        }

        public virtual Is_od_pripremaDataAdapter Gets_od_pripremaDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<s_od_pripremaDataAdapter, Is_od_pripremaDataAdapter>(new object[0]);
        }

        public virtual IS_OD_PROSJEK_PLACEDataAdapter GetS_OD_PROSJEK_PLACEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_PROSJEK_PLACEDataAdapter, IS_OD_PROSJEK_PLACEDataAdapter>(new object[0]);
        }

        public virtual Is_od_rekap_brutoDataAdapter Gets_od_rekap_brutoDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<s_od_rekap_brutoDataAdapter, Is_od_rekap_brutoDataAdapter>(new object[0]);
        }

        public virtual Is_od_rekap_doprinosDataAdapter Gets_od_rekap_doprinosDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<s_od_rekap_doprinosDataAdapter, Is_od_rekap_doprinosDataAdapter>(new object[0]);
        }

        public virtual IS_OD_REKAP_FIKSNEDataAdapter GetS_OD_REKAP_FIKSNEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_REKAP_FIKSNEDataAdapter, IS_OD_REKAP_FIKSNEDataAdapter>(new object[0]);
        }

        public virtual IS_OD_REKAP_ISPLATADataAdapter GetS_OD_REKAP_ISPLATADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_REKAP_ISPLATADataAdapter, IS_OD_REKAP_ISPLATADataAdapter>(new object[0]);
        }

        public virtual IS_OD_REKAP_KREDITNEDataAdapter GetS_OD_REKAP_KREDITNEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_REKAP_KREDITNEDataAdapter, IS_OD_REKAP_KREDITNEDataAdapter>(new object[0]);
        }

        public virtual IS_OD_REKAP_NETODataAdapter GetS_OD_REKAP_NETODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_REKAP_NETODataAdapter, IS_OD_REKAP_NETODataAdapter>(new object[0]);
        }

        public virtual IS_OD_REKAP_OLAKSICEDataAdapter GetS_OD_REKAP_OLAKSICEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_REKAP_OLAKSICEDataAdapter, IS_OD_REKAP_OLAKSICEDataAdapter>(new object[0]);
        }

        public virtual IS_OD_REKAP_POREZDataAdapter GetS_OD_REKAP_POREZDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_REKAP_POREZDataAdapter, IS_OD_REKAP_POREZDataAdapter>(new object[0]);
        }

        public virtual IS_OD_REKAP_POSTOTNEDataAdapter GetS_OD_REKAP_POSTOTNEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_REKAP_POSTOTNEDataAdapter, IS_OD_REKAP_POSTOTNEDataAdapter>(new object[0]);
        }

        public virtual IS_OD_STANJE_KREDITADataAdapter GetS_OD_STANJE_KREDITADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_STANJE_KREDITADataAdapter, IS_OD_STANJE_KREDITADataAdapter>(new object[0]);
        }

        public virtual IS_OD_STANJE_OBUSTAVADataAdapter GetS_OD_STANJE_OBUSTAVADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_STANJE_OBUSTAVADataAdapter, IS_OD_STANJE_OBUSTAVADataAdapter>(new object[0]);
        }

        public virtual IS_OD_STAT_KREDITDataAdapter GetS_OD_STAT_KREDITDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_STAT_KREDITDataAdapter, IS_OD_STAT_KREDITDataAdapter>(new object[0]);
        }

        public virtual IS_OD_TABLICA01DataAdapter GetS_OD_TABLICA01DataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OD_TABLICA01DataAdapter, IS_OD_TABLICA01DataAdapter>(new object[0]);
        }

        public virtual IS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataAdapter GetS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataAdapter, IS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataAdapter>(new object[0]);
        }

        public virtual IS_OS_BILANCA_STANJA_NA_DANDataAdapter GetS_OS_BILANCA_STANJA_NA_DANDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_BILANCA_STANJA_NA_DANDataAdapter, IS_OS_BILANCA_STANJA_NA_DANDataAdapter>(new object[0]);
        }

        public virtual IS_OS_BROJ_I_DATUMDataAdapter GetS_OS_BROJ_I_DATUMDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_BROJ_I_DATUMDataAdapter, IS_OS_BROJ_I_DATUMDataAdapter>(new object[0]);
        }

        public virtual IS_OS_POSTOJECI_DOKUMENTIDataAdapter GetS_OS_POSTOJECI_DOKUMENTIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_POSTOJECI_DOKUMENTIDataAdapter, IS_OS_POSTOJECI_DOKUMENTIDataAdapter>(new object[0]);
        }

        public virtual IS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter GetS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter, IS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter>(new object[0]);
        }

        public virtual IS_OS_PREGLED_AMORTIZACIJEDataAdapter GetS_OS_PREGLED_AMORTIZACIJEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_PREGLED_AMORTIZACIJEDataAdapter, IS_OS_PREGLED_AMORTIZACIJEDataAdapter>(new object[0]);
        }

        public virtual IS_OS_REKAP_TEMELJNICEDataAdapter GetS_OS_REKAP_TEMELJNICEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_REKAP_TEMELJNICEDataAdapter, IS_OS_REKAP_TEMELJNICEDataAdapter>(new object[0]);
        }

        public virtual IS_OS_STANJE_FINANCIJSKODataAdapter GetS_OS_STANJE_FINANCIJSKODataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_STANJE_FINANCIJSKODataAdapter, IS_OS_STANJE_FINANCIJSKODataAdapter>(new object[0]);
        }

        public virtual IS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter GetS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter, IS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter>(new object[0]);
        }

        public virtual IS_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter GetS_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter, IS_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter>(new object[0]);
        }

        public virtual IS_OS_STANJE_LOKACIJADataAdapter GetS_OS_STANJE_LOKACIJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_OS_STANJE_LOKACIJADataAdapter, IS_OS_STANJE_LOKACIJADataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter GetS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter, IS_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_KONACNI_REKAPOPCINEDataAdapter GetS_PLACA_KONACNI_REKAPOPCINEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_KONACNI_REKAPOPCINEDataAdapter, IS_PLACA_KONACNI_REKAPOPCINEDataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_KREDITI_KARTICEDataAdapter GetS_PLACA_KREDITI_KARTICEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_KREDITI_KARTICEDataAdapter, IS_PLACA_KREDITI_KARTICEDataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_ODBICI_GODINADataAdapter GetS_PLACA_ODBICI_GODINADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_ODBICI_GODINADataAdapter, IS_PLACA_ODBICI_GODINADataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_RAD1G_IIIDataAdapter GetS_PLACA_RAD1G_IIIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_RAD1G_IIIDataAdapter, IS_PLACA_RAD1G_IIIDataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_RAD1G_IVDataAdapter GetS_PLACA_RAD1G_IVDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_RAD1G_IVDataAdapter, IS_PLACA_RAD1G_IVDataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_RAD1G_SATIDataAdapter GetS_PLACA_RAD1G_SATIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_RAD1G_SATIDataAdapter, IS_PLACA_RAD1G_SATIDataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_RAD1GDataAdapter GetS_PLACA_RAD1GDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_RAD1GDataAdapter, IS_PLACA_RAD1GDataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_RAD1M_DIO1DataAdapter GetS_PLACA_RAD1M_DIO1DataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_RAD1M_DIO1DataAdapter, IS_PLACA_RAD1M_DIO1DataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_RAD1M_DIO2DataAdapter GetS_PLACA_RAD1M_DIO2DataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_RAD1M_DIO2DataAdapter, IS_PLACA_RAD1M_DIO2DataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_RAD1M_DIO3DataAdapter GetS_PLACA_RAD1M_DIO3DataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_RAD1M_DIO3DataAdapter, IS_PLACA_RAD1M_DIO3DataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_SIFREOBRACUNADataAdapter GetS_PLACA_SIFREOBRACUNADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_SIFREOBRACUNADataAdapter, IS_PLACA_SIFREOBRACUNADataAdapter>(new object[0]);
        }

        public virtual IS_PLACA_TABLICA018DataAdapter GetS_PLACA_TABLICA018DataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<S_PLACA_TABLICA018DataAdapter, IS_PLACA_TABLICA018DataAdapter>(new object[0]);
        }

        public virtual ISHEMADDDataAdapter GetSHEMADDDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SHEMADDDataAdapter, ISHEMADDDataAdapter>(new object[0]);
        }

        public virtual ISHEMAIRADataAdapter GetSHEMAIRADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SHEMAIRADataAdapter, ISHEMAIRADataAdapter>(new object[0]);
        }

        public virtual ISHEMAPLACADataAdapter GetSHEMAPLACADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SHEMAPLACADataAdapter, ISHEMAPLACADataAdapter>(new object[0]);
        }

        public virtual ISHEMAURADataAdapter GetSHEMAURADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SHEMAURADataAdapter, ISHEMAURADataAdapter>(new object[0]);
        }

        public virtual ISKUPPOREZAIDOPRINOSADataAdapter GetSKUPPOREZAIDOPRINOSADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SKUPPOREZAIDOPRINOSADataAdapter, ISKUPPOREZAIDOPRINOSADataAdapter>(new object[0]);
        }

        public virtual ISMJENEDataAdapter GetSMJENEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SMJENEDataAdapter, ISMJENEDataAdapter>(new object[0]);
        }

        public virtual Isp_diskete_za_bankuDataAdapter Getsp_diskete_za_bankuDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_diskete_za_bankuDataAdapter, Isp_diskete_za_bankuDataAdapter>(new object[0]);
        }

        public virtual ISP_FIN_URAPLACANJEDataAdapter GetSP_FIN_URAPLACANJEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SP_FIN_URAPLACANJEDataAdapter, ISP_FIN_URAPLACANJEDataAdapter>(new object[0]);
        }

        public virtual Isp_id_detaljiDataAdapter Getsp_id_detaljiDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_id_detaljiDataAdapter, Isp_id_detaljiDataAdapter>(new object[0]);
        }

        public virtual Isp_id_zaglavljeDataAdapter Getsp_id_zaglavljeDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_id_zaglavljeDataAdapter, Isp_id_zaglavljeDataAdapter>(new object[0]);
        }

        public virtual Isp_ip_detaljiDataAdapter Getsp_ip_detaljiDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_ip_detaljiDataAdapter, Isp_ip_detaljiDataAdapter>(new object[0]);
        }

        public virtual Isp_ip_zaglavljeDataAdapter Getsp_ip_zaglavljeDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_ip_zaglavljeDataAdapter, Isp_ip_zaglavljeDataAdapter>(new object[0]);
        }

        public virtual ISP_LISTA_IZNOSA_RADNIKADataAdapter GetSP_LISTA_IZNOSA_RADNIKADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SP_LISTA_IZNOSA_RADNIKADataAdapter, ISP_LISTA_IZNOSA_RADNIKADataAdapter>(new object[0]);
        }

        public virtual Isp_maticni_kartonDataAdapter Getsp_maticni_kartonDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_maticni_kartonDataAdapter, Isp_maticni_kartonDataAdapter>(new object[0]);
        }

        public virtual Isp_RSOBRAZACDataAdapter Getsp_RSOBRAZACDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_RSOBRAZACDataAdapter, Isp_RSOBRAZACDataAdapter>(new object[0]);
        }

        public virtual Isp_VIRMANIDataAdapter Getsp_VIRMANIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_VIRMANIDataAdapter, Isp_VIRMANIDataAdapter>(new object[0]);
        }

        public virtual Isp_zap1DataAdapter Getsp_zap1DataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<sp_zap1DataAdapter, Isp_zap1DataAdapter>(new object[0]);
        }

        public virtual ISPOLDataAdapter GetSPOLDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<SPOLDataAdapter, ISPOLDataAdapter>(new object[0]);
        }

        public virtual ISTRANEKNJIZENJADataAdapter GetSTRANEKNJIZENJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<STRANEKNJIZENJADataAdapter, ISTRANEKNJIZENJADataAdapter>(new object[0]);
        }

        public virtual ISTRUCNASPREMADataAdapter GetSTRUCNASPREMADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<STRUCNASPREMADataAdapter, ISTRUCNASPREMADataAdapter>(new object[0]);
        }

        public virtual ISTRUKADataAdapter GetSTRUKADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<STRUKADataAdapter, ISTRUKADataAdapter>(new object[0]);
        }

        public virtual ITIPDOKUMENTADataAdapter GetTIPDOKUMENTADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<TIPDOKUMENTADataAdapter, ITIPDOKUMENTADataAdapter>(new object[0]);
        }

        public virtual ITIPIRADataAdapter GetTIPIRADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<TIPIRADataAdapter, ITIPIRADataAdapter>(new object[0]);
        }

        public virtual ITIPIZNOSADataAdapter GetTIPIZNOSADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<TIPIZNOSADataAdapter, ITIPIZNOSADataAdapter>(new object[0]);
        }

        public virtual ITIPOLAKSICEDataAdapter GetTIPOLAKSICEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<TIPOLAKSICEDataAdapter, ITIPOLAKSICEDataAdapter>(new object[0]);
        }

        public virtual ITIPURADataAdapter GetTIPURADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<TIPURADataAdapter, ITIPURADataAdapter>(new object[0]);
        }

        public virtual ITITULADataAdapter GetTITULADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<TITULADataAdapter, ITITULADataAdapter>(new object[0]);
        }

        public virtual Itrazi_partneraDataAdapter Gettrazi_partneraDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<trazi_partneraDataAdapter, Itrazi_partneraDataAdapter>(new object[0]);
        }

        public virtual Itrazi_proizvodDataAdapter Gettrazi_proizvodDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<trazi_proizvodDataAdapter, Itrazi_proizvodDataAdapter>(new object[0]);
        }

        public virtual IUCENIKDataAdapter GetUCENIKDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<UCENIKDataAdapter, IUCENIKDataAdapter>(new object[0]);
        }

        public virtual IUCENIKOBRACUNDataAdapter GetUCENIKOBRACUNDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<UCENIKOBRACUNDataAdapter, IUCENIKOBRACUNDataAdapter>(new object[0]);
        }

        public virtual IUCENIKRSMIDENTDataAdapter GetUCENIKRSMIDENTDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<UCENIKRSMIDENTDataAdapter, IUCENIKRSMIDENTDataAdapter>(new object[0]);
        }

        public virtual IUGOVORORADUDataAdapter GetUGOVORORADUDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<UGOVORORADUDataAdapter, IUGOVORORADUDataAdapter>(new object[0]);
        }

        public virtual IURADataAdapter GetURADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<URADataAdapter, IURADataAdapter>(new object[0]);
        }

        public virtual IuraDocsDataAdapter GeturaDocsDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<uraDocsDataAdapter, IuraDocsDataAdapter>(new object[0]);
        }

        public virtual IURAVRSTAIZNOSADataAdapter GetURAVRSTAIZNOSADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<URAVRSTAIZNOSADataAdapter, IURAVRSTAIZNOSADataAdapter>(new object[0]);
        }

        public virtual IV_DD_GODINE_ISPLATEDataAdapter GetV_DD_GODINE_ISPLATEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<V_DD_GODINE_ISPLATEDataAdapter, IV_DD_GODINE_ISPLATEDataAdapter>(new object[0]);
        }

        public virtual IV_DD_PREGLED_OBRACUNADataAdapter GetV_DD_PREGLED_OBRACUNADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<V_DD_PREGLED_OBRACUNADataAdapter, IV_DD_PREGLED_OBRACUNADataAdapter>(new object[0]);
        }

        public virtual IVALUTEDataAdapter GetVALUTEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VALUTEDataAdapter, IVALUTEDataAdapter>(new object[0]);
        }

        public virtual IVERZIJADataAdapter GetVERZIJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VERZIJADataAdapter, IVERZIJADataAdapter>(new object[0]);
        }

        public virtual IVIRMANIDataAdapter GetVIRMANIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VIRMANIDataAdapter, IVIRMANIDataAdapter>(new object[0]);
        }

        public virtual IVRSTADOPRINOSDataAdapter GetVRSTADOPRINOSDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VRSTADOPRINOSDataAdapter, IVRSTADOPRINOSDataAdapter>(new object[0]);
        }

        public virtual IVRSTAELEMENTDataAdapter GetVRSTAELEMENTDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VRSTAELEMENTDataAdapter, IVRSTAELEMENTDataAdapter>(new object[0]);
        }

        public virtual IVRSTAOBUSTAVEDataAdapter GetVRSTAOBUSTAVEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VRSTAOBUSTAVEDataAdapter, IVRSTAOBUSTAVEDataAdapter>(new object[0]);
        }

        public virtual Ivw_DD_MJESECI_GODINE_ISPLATEDataAdapter Getvw_DD_MJESECI_GODINE_ISPLATEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<vw_DD_MJESECI_GODINE_ISPLATEDataAdapter, Ivw_DD_MJESECI_GODINE_ISPLATEDataAdapter>(new object[0]);
        }

        public virtual IVW_GODINE_ISPLATEDataAdapter GetVW_GODINE_ISPLATEDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VW_GODINE_ISPLATEDataAdapter, IVW_GODINE_ISPLATEDataAdapter>(new object[0]);
        }

        public virtual IVW_GODINE_OBRACUNADataAdapter GetVW_GODINE_OBRACUNADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VW_GODINE_OBRACUNADataAdapter, IVW_GODINE_OBRACUNADataAdapter>(new object[0]);
        }

        public virtual Ivw_mjeseci_godine_isplateDataAdapter Getvw_mjeseci_godine_isplateDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<vw_mjeseci_godine_isplateDataAdapter, Ivw_mjeseci_godine_isplateDataAdapter>(new object[0]);
        }

        public virtual IVW_MJESECI_GODINE_OBRACUNADataAdapter GetVW_MJESECI_GODINE_OBRACUNADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VW_MJESECI_GODINE_OBRACUNADataAdapter, IVW_MJESECI_GODINE_OBRACUNADataAdapter>(new object[0]);
        }

        public virtual IVW_ZADUZENI_PARTNERIDataAdapter GetVW_ZADUZENI_PARTNERIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<VW_ZADUZENI_PARTNERIDataAdapter, IVW_ZADUZENI_PARTNERIDataAdapter>(new object[0]);
        }

        public virtual IZAPOSLENIDataAdapter GetZAPOSLENIDataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<ZAPOSLENIDataAdapter, IZAPOSLENIDataAdapter>(new object[0]);
        }

        public virtual IZATVARANJADataAdapter GetZATVARANJADataAdapter()
        {
            return Microsoft.Practices.EnterpriseLibrary.PolicyInjection.PolicyInjection.Create<ZATVARANJADataAdapter, IZATVARANJADataAdapter>(new object[0]);
        }

        object Deklarit.Configuration.IConnectedDataAdapterFactory.EnterpriseLibraryConfigurationContext
        {
            get
            {
                return EnterpriseLibrary.Instance.ConfigurationContext;
            }
            set
            {
                EnterpriseLibrary.Instance.ConfigurationContext = (IConfigurationSource) value;
            }
        }

        Deklarit.Configuration.IDeklaritConfiguration Deklarit.Configuration.IConnectedDataAdapterFactory.IDeklaritConfiguration
        {
            get
            {
                return Configuration.Instance;
            }
            set
            {
                Configuration.Instance = value;
            }
        }

        public object EnterpriseLibraryConfigurationContext
        {
            get
            {
                return EnterpriseLibrary.Instance.ConfigurationContext;
            }
            set
            {
                EnterpriseLibrary.Instance.ConfigurationContext = (IConfigurationSource) value;
            }
        }

        public Deklarit.Configuration.IDeklaritConfiguration IDeklaritConfiguration
        {
            get
            {
                return Configuration.Instance;
            }
            set
            {
                Configuration.Instance = value;
            }
        }
    }
}

