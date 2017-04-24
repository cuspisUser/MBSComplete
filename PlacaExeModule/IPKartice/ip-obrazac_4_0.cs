using System.Xml.Serialization;

namespace IPKarticeNamespace
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0", IsNullable=false)]
    public partial class Ip {
    
        private int isplataUGodiniField;
    
        private PoslodavacTip poslodavacField;
    
        private IpObrazacTip[] ipObrasciField;
    
        private bool stornoField;
    
        public Ip() {
            this.stornoField = false;
        }
    
        /// <remarks/>
        public int IsplataUGodini {
            get {
                return this.isplataUGodiniField;
            }
            set {
                this.isplataUGodiniField = value;
            }
        }
    
        /// <remarks/>
        public PoslodavacTip Poslodavac {
            get {
                return this.poslodavacField;
            }
            set {
                this.poslodavacField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("IpObrazac", IsNullable=false)]
        public IpObrazacTip[] IpObrasci {
            get {
                return this.ipObrasciField;
            }
            set {
                this.ipObrasciField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool storno {
            get {
                return this.stornoField;
            }
            set {
                this.stornoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class PoslodavacTip {
    
        private KontaktOsobaTip kontaktOsobaField;
    
        private string oibField;
    
        /// <remarks/>
        public KontaktOsobaTip KontaktOsoba {
            get {
                return this.kontaktOsobaField;
            }
            set {
                this.kontaktOsobaField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string oib {
            get {
                return this.oibField;
            }
            set {
                this.oibField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class KontaktOsobaTip {
    
        private string imeField;
    
        private string prezimeField;
    
        private string[] telefoniField;
    
        private string emailField;
    
        /// <remarks/>
        public string Ime {
            get {
                return this.imeField;
            }
            set {
                this.imeField = value;
            }
        }
    
        /// <remarks/>
        public string Prezime {
            get {
                return this.prezimeField;
            }
            set {
                this.prezimeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Telefon", IsNullable=false)]
        public string[] Telefoni {
            get {
                return this.telefoniField;
            }
            set {
                this.telefoniField = value;
            }
        }
    
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MjesecniIznosiTip))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class IznosiTip {
    
        private decimal isplPlMirField;
    
        private decimal uplDoprField;
    
        private decimal uplPremOsigField;
    
        private decimal dohodakField;
    
        private decimal osobOdbField;
    
        private decimal porOsnField;
    
        private decimal uplPorPrirField;
    
        private decimal posPorezField;
    
        private decimal netoIsplField;
    
        public IznosiTip() {
            this.isplPlMirField = ((decimal)(0.00m));
            this.uplDoprField = ((decimal)(0.00m));
            this.uplPremOsigField = ((decimal)(0.00m));
            this.dohodakField = ((decimal)(0.00m));
            this.osobOdbField = ((decimal)(0.00m));
            this.porOsnField = ((decimal)(0.00m));
            this.uplPorPrirField = ((decimal)(0.00m));
            this.posPorezField = ((decimal)(0.00m));
            this.netoIsplField = ((decimal)(0.00m));
        }
    
        /// <remarks/>
        public decimal IsplPlMir {
            get {
                return this.isplPlMirField;
            }
            set {
                this.isplPlMirField = value;
            }
        }
    
        /// <remarks/>
        public decimal UplDopr {
            get {
                return this.uplDoprField;
            }
            set {
                this.uplDoprField = value;
            }
        }
    
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.00")]
        public decimal UplPremOsig {
            get {
                return this.uplPremOsigField;
            }
            set {
                this.uplPremOsigField = value;
            }
        }
    
        /// <remarks/>
        public decimal Dohodak {
            get {
                return this.dohodakField;
            }
            set {
                this.dohodakField = value;
            }
        }
    
        /// <remarks/>
        public decimal OsobOdb {
            get {
                return this.osobOdbField;
            }
            set {
                this.osobOdbField = value;
            }
        }
    
        /// <remarks/>
        public decimal PorOsn {
            get {
                return this.porOsnField;
            }
            set {
                this.porOsnField = value;
            }
        }
    
        /// <remarks/>
        public decimal UplPorPrir {
            get {
                return this.uplPorPrirField;
            }
            set {
                this.uplPorPrirField = value;
            }
        }
    
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.00")]
        public decimal PosPorez {
            get {
                return this.posPorezField;
            }
            set {
                this.posPorezField = value;
            }
        }
    
        /// <remarks/>
        public decimal NetoIspl {
            get {
                return this.netoIsplField;
            }
            set {
                this.netoIsplField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class MjesecniIznosiTip : IznosiTip {
    
        private int mjIsplField;
    
        private string sifGrOpField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int mjIspl {
            get {
                return this.mjIsplField;
            }
            set {
                this.mjIsplField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sifGrOp {
            get {
                return this.sifGrOpField;
            }
            set {
                this.sifGrOpField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class UmirovljenikTip {
    
        private VrPrimanjaUmirovljenikTip vrPrimanjaField;
    
        private string[] osobniBrojeviField;
    
        private string oibField;
    
        /// <remarks/>
        public VrPrimanjaUmirovljenikTip VrPrimanja {
            get {
                return this.vrPrimanjaField;
            }
            set {
                this.vrPrimanjaField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("OsobniBroj", IsNullable=false)]
        public string[] OsobniBrojevi {
            get {
                return this.osobniBrojeviField;
            }
            set {
                this.osobniBrojeviField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string oib {
            get {
                return this.oibField;
            }
            set {
                this.oibField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public enum VrPrimanjaUmirovljenikTip {
    
        /// <remarks/>
        MI,
    
        /// <remarks/>
        OM,
    
        /// <remarks/>
        OD,
    
        /// <remarks/>
        OC,
    
        /// <remarks/>
        NM,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class RadnikTip {
    
        private VrPrimanjaRadnikTip vrPrimanjaField;
    
        private string oibField;
    
        /// <remarks/>
        public VrPrimanjaRadnikTip VrPrimanja {
            get {
                return this.vrPrimanjaField;
            }
            set {
                this.vrPrimanjaField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string oib {
            get {
                return this.oibField;
            }
            set {
                this.oibField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public enum VrPrimanjaRadnikTip {
    
        /// <remarks/>
        PL,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class ObveznikTip {
    
        private object itemField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Radnik", typeof(RadnikTip))]
        [System.Xml.Serialization.XmlElementAttribute("Umirovljenik", typeof(UmirovljenikTip))]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public partial class IpObrazacTip {
    
        private ObveznikTip obveznikField;
    
        private MjesecniIznosiTip[] mjeseciField;
    
        private IznosiTip ukupnoField;
    
        private IdentifikatorIpObrascaTip identifikatorField;
    
        private int isplataZaGodinuField;
    
        /// <remarks/>
        public ObveznikTip Obveznik {
            get {
                return this.obveznikField;
            }
            set {
                this.obveznikField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Mjesec", IsNullable=false)]
        public MjesecniIznosiTip[] Mjeseci {
            get {
                return this.mjeseciField;
            }
            set {
                this.mjeseciField = value;
            }
        }
    
        /// <remarks/>
        public IznosiTip Ukupno {
            get {
                return this.ukupnoField;
            }
            set {
                this.ukupnoField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public IdentifikatorIpObrascaTip identifikator {
            get {
                return this.identifikatorField;
            }
            set {
                this.identifikatorField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int isplataZaGodinu {
            get {
                return this.isplataZaGodinuField;
            }
            set {
                this.isplataZaGodinuField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/ip/v4-0")]
    public enum IdentifikatorIpObrascaTip {
    
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
    
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
    
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,
    }
}