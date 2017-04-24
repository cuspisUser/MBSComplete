using System.Xml.Serialization;

namespace DDModule.ID1OBRAZAC
{


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0", IsNullable = false)]
    public partial class Id1
    {

        private int identifikatorField;

        private int isplataUGodiniField;

        private IsplatiteljTip isplatiteljField;

        private ObveznikTip[] obvezniciField;

        private UkupnoTip ukupnoField;

        private bool stornoField;

        public Id1()
        {
            this.stornoField = false;
        }

        /// <remarks/>
        public int Identifikator
        {
            get
            {
                return this.identifikatorField;
            }
            set
            {
                this.identifikatorField = value;
            }
        }

        /// <remarks/>
        public int IsplataUGodini
        {
            get
            {
                return this.isplataUGodiniField;
            }
            set
            {
                this.isplataUGodiniField = value;
            }
        }

        /// <remarks/>
        public IsplatiteljTip Isplatitelj
        {
            get
            {
                return this.isplatiteljField;
            }
            set
            {
                this.isplatiteljField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Obveznik", IsNullable = false)]
        public ObveznikTip[] Obveznici
        {
            get
            {
                return this.obvezniciField;
            }
            set
            {
                this.obvezniciField = value;
            }
        }

        /// <remarks/>
        public UkupnoTip Ukupno
        {
            get
            {
                return this.ukupnoField;
            }
            set
            {
                this.ukupnoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool storno
        {
            get
            {
                return this.stornoField;
            }
            set
            {
                this.stornoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0")]
    public partial class IsplatiteljTip
    {

        private KontaktOsobaTip kontaktOsobaField;

        private string oibField;

        /// <remarks/>
        public KontaktOsobaTip KontaktOsoba
        {
            get
            {
                return this.kontaktOsobaField;
            }
            set
            {
                this.kontaktOsobaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string oib
        {
            get
            {
                return this.oibField;
            }
            set
            {
                this.oibField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0")]
    public partial class KontaktOsobaTip
    {

        private string imeField;

        private string prezimeField;

        private string[] telefoniField;

        private string emailField;

        /// <remarks/>
        public string Ime
        {
            get
            {
                return this.imeField;
            }
            set
            {
                this.imeField = value;
            }
        }

        /// <remarks/>
        public string Prezime
        {
            get
            {
                return this.prezimeField;
            }
            set
            {
                this.prezimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Telefon", IsNullable = false)]
        public string[] Telefoni
        {
            get
            {
                return this.telefoniField;
            }
            set
            {
                this.telefoniField = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0")]
    public partial class UkupnoTip
    {

        private decimal primitakField;

        private decimal izdatakField;

        private decimal izdatakDoprinosaField;

        private PorezPrirezTip porezPrirezField;

        private decimal isplaceniPrimitakField;

        public UkupnoTip()
        {
            this.primitakField = ((decimal)(0.00m));
            this.izdatakField = ((decimal)(0.00m));
            this.izdatakDoprinosaField = ((decimal)(0.00m));
            this.isplaceniPrimitakField = ((decimal)(0.00m));
        }

        /// <remarks/>
        public decimal Primitak
        {
            get
            {
                return this.primitakField;
            }
            set
            {
                this.primitakField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.00")]
        public decimal Izdatak
        {
            get
            {
                return this.izdatakField;
            }
            set
            {
                this.izdatakField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.00")]
        public decimal IzdatakDoprinosa
        {
            get
            {
                return this.izdatakDoprinosaField;
            }
            set
            {
                this.izdatakDoprinosaField = value;
            }
        }

        /// <remarks/>
        public PorezPrirezTip PorezPrirez
        {
            get
            {
                return this.porezPrirezField;
            }
            set
            {
                this.porezPrirezField = value;
            }
        }

        /// <remarks/>
        public decimal IsplaceniPrimitak
        {
            get
            {
                return this.isplaceniPrimitakField;
            }
            set
            {
                this.isplaceniPrimitakField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0")]
    public partial class PorezPrirezTip
    {

        private RacunTip[] racuniField;

        private decimal ukupnoField;

        public PorezPrirezTip()
        {
            this.ukupnoField = ((decimal)(0.00m));
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Racun", IsNullable = false)]
        public RacunTip[] Racuni
        {
            get
            {
                return this.racuniField;
            }
            set
            {
                this.racuniField = value;
            }
        }

        /// <remarks/>
        public decimal Ukupno
        {
            get
            {
                return this.ukupnoField;
            }
            set
            {
                this.ukupnoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0")]
    public partial class RacunTip
    {

        private decimal iznosField;

        private string brojRacunaField;

        /// <remarks/>
        public decimal Iznos
        {
            get
            {
                return this.iznosField;
            }
            set
            {
                this.iznosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string brojRacuna
        {
            get
            {
                return this.brojRacunaField;
            }
            set
            {
                this.brojRacunaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/obrasci/id1/v4-0")]
    public partial class ObveznikTip
    {

        private string imeField;

        private string prezimeField;

        private decimal primitakField;

        private decimal izdatakField;

        private decimal izdatakDoprinosaField;

        private PorezPrirezTip porezPrirezField;

        private decimal isplaceniPrimitakField;

        private string oibField;

        private string oznGrOpField;

        public ObveznikTip()
        {
            this.primitakField = ((decimal)(0.00m));
            this.izdatakField = ((decimal)(0.00m));
            this.izdatakDoprinosaField = ((decimal)(0.00m));
            this.isplaceniPrimitakField = ((decimal)(0.00m));
        }

        /// <remarks/>
        public string Ime
        {
            get
            {
                return this.imeField;
            }
            set
            {
                this.imeField = value;
            }
        }

        /// <remarks/>
        public string Prezime
        {
            get
            {
                return this.prezimeField;
            }
            set
            {
                this.prezimeField = value;
            }
        }

        /// <remarks/>
        public decimal Primitak
        {
            get
            {
                return this.primitakField;
            }
            set
            {
                this.primitakField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.00")]
        public decimal Izdatak
        {
            get
            {
                return this.izdatakField;
            }
            set
            {
                this.izdatakField = value;
            }
        }

        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.00")]
        public decimal IzdatakDoprinosa
        {
            get
            {
                return this.izdatakDoprinosaField;
            }
            set
            {
                this.izdatakDoprinosaField = value;
            }
        }

        /// <remarks/>
        public PorezPrirezTip PorezPrirez
        {
            get
            {
                return this.porezPrirezField;
            }
            set
            {
                this.porezPrirezField = value;
            }
        }

        /// <remarks/>
        public decimal IsplaceniPrimitak
        {
            get
            {
                return this.isplaceniPrimitakField;
            }
            set
            {
                this.isplaceniPrimitakField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string oib
        {
            get
            {
                return this.oibField;
            }
            set
            {
                this.oibField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string oznGrOp
        {
            get
            {
                return this.oznGrOpField;
            }
            set
            {
                this.oznGrOpField = value;
            }
        }
    }
}
