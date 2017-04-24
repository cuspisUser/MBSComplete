﻿
using System.Xml.Serialization;

namespace JOPPDNew
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    [System.Xml.Serialization.XmlRootAttribute("Metapodaci", Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0", IsNullable = false)]
    public partial class sJOPPDmetapodaci
    {

        private sNaslovTemeljni naslovField;

        private sAutorTemeljni autorField;

        private sDatumTemeljni datumField;

        private sFormatTemeljni formatField;

        private sJezikTemeljni jezikField;

        private sIdentifikatorTemeljni identifikatorField;

        private sUskladjenost uskladjenostField;

        private sTipTemeljni tipField;

        private sAdresantTemeljni adresantField;

        /// <remarks/>
        public sNaslovTemeljni Naslov
        {
            get
            {
                return this.naslovField;
            }
            set
            {
                this.naslovField = value;
            }
        }

        /// <remarks/>
        public sAutorTemeljni Autor
        {
            get
            {
                return this.autorField;
            }
            set
            {
                this.autorField = value;
            }
        }

        /// <remarks/>
        public sDatumTemeljni Datum
        {
            get
            {
                return this.datumField;
            }
            set
            {
                this.datumField = value;
            }
        }

        /// <remarks/>
        public sFormatTemeljni Format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }

        /// <remarks/>
        public sJezikTemeljni Jezik
        {
            get
            {
                return this.jezikField;
            }
            set
            {
                this.jezikField = value;
            }
        }

        /// <remarks/>
        public sIdentifikatorTemeljni Identifikator
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
        public sUskladjenost Uskladjenost
        {
            get
            {
                return this.uskladjenostField;
            }
            set
            {
                this.uskladjenostField = value;
            }
        }

        /// <remarks/>
        public sTipTemeljni Tip
        {
            get
            {
                return this.tipField;
            }
            set
            {
                this.tipField = value;
            }
        }

        /// <remarks/>
        public sAdresantTemeljni Adresant
        {
            get
            {
                return this.adresantField;
            }
            set
            {
                this.adresantField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sNaslovTemeljni
    {

        private string dcField;

        private string valueField;

        public sNaslovTemeljni()
        {
            this.dcField = "http://purl.org/dc/elements/1.1/title";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sAdresantTemeljni
    {

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sTipTemeljni
    {

        private string dcField;

        private tTip valueField;

        public sTipTemeljni()
        {
            this.dcField = "http://purl.org/dc/elements/1.1/type";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public tTip Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
    public enum tTip
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Elektronički obrazac")]
        Elektroničkiobrazac,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(sUskladjenost))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sUskladjenostTemeljni
    {

        private string dcField;

        private string valueField;

        public sUskladjenostTemeljni()
        {
            this.dcField = "http://purl.org/dc/terms/conformsTo";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sUskladjenost : sUskladjenostTemeljni
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sIdentifikatorTemeljni
    {

        private string dcField;

        private string valueField;

        public sIdentifikatorTemeljni()
        {
            this.dcField = "http://purl.org/dc/elements/1.1/identifier";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sJezikTemeljni
    {

        private string dcField;

        private tJezik valueField;

        public sJezikTemeljni()
        {
            this.dcField = "http://purl.org/dc/elements/1.1/language";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public tJezik Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
    public enum tJezik
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("hr-HR")]
        hrHR,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sFormatTemeljni
    {

        private string dcField;

        private tFormat valueField;

        public sFormatTemeljni()
        {
            this.dcField = "http://purl.org/dc/elements/1.1/format";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public tFormat Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
    public enum tFormat
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("text/xml")]
        textxml,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sDatumTemeljni
    {

        private string dcField;

        private System.DateTime valueField;

        public sDatumTemeljni()
        {
            this.dcField = "http://purl.org/dc/elements/1.1/date";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public partial class sAutorTemeljni
    {

        private string dcField;

        private string valueField;

        public sAutorTemeljni()
        {
            this.dcField = "http://purl.org/dc/elements/1.1/creator";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dc
        {
            get
            {
                return this.dcField;
            }
            set
            {
                this.dcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    [System.Xml.Serialization.XmlRootAttribute("ObrazacJOPPD", Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1", IsNullable = false)]
    public partial class sObrazacJOPPD
    {

        private sJOPPDmetapodaci metapodaciField;

        private sStranaA stranaAField;

        private sPrimateljiP[][] stranaBField;

        private string verzijaShemeField;

        public sObrazacJOPPD()
        {
            this.verzijaShemeField = "1.1";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
        public sJOPPDmetapodaci Metapodaci
        {
            get
            {
                return this.metapodaciField;
            }
            set
            {
                this.metapodaciField = value;
            }
        }

        /// <remarks/>
        public sStranaA StranaA
        {
            get
            {
                return this.stranaAField;
            }
            set
            {
                this.stranaAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Primatelji", IsNullable = false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("P", IsNullable = false, NestingLevel = 1)]
        public sPrimateljiP[][] StranaB
        {
            get
            {
                return this.stranaBField;
            }
            set
            {
                this.stranaBField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string verzijaSheme
        {
            get
            {
                return this.verzijaShemeField;
            }
            set
            {
                this.verzijaShemeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sStranaA
    {

        private System.DateTime datumIzvjescaField;

        private string oznakaIzvjescaField;

        private tVrstaIzvjesca vrstaIzvjescaField;

        private sPodnositeljIzvjesca podnositeljIzvjescaField;

        private sObveznikPlacanja obveznikPlacanjaField;

        private string brojOsobaField;

        private string brojRedakaField;

        private sPredujamPoreza predujamPorezaField;

        private sDoprinosi doprinosiField;

        private decimal isplaceniNeoporeziviPrimiciField;

        private bool isplaceniNeoporeziviPrimiciFieldSpecified;

        private decimal kamataMO2Field;

        private bool kamataMO2FieldSpecified;

        private decimal ukupniNeoporeziviPrimiciField;

        private bool ukupniNeoporeziviPrimiciFieldSpecified;

        private sNaknadaZaposljavanjeInvalida naknadaZaposljavanjeInvalidaField;

        private sIzvjesceSastavio izvjesceSastavioField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime DatumIzvjesca
        {
            get
            {
                return this.datumIzvjescaField;
            }
            set
            {
                this.datumIzvjescaField = value;
            }
        }

        /// <remarks/>
        public string OznakaIzvjesca
        {
            get
            {
                return this.oznakaIzvjescaField;
            }
            set
            {
                this.oznakaIzvjescaField = value;
            }
        }

        /// <remarks/>
        public tVrstaIzvjesca VrstaIzvjesca
        {
            get
            {
                return this.vrstaIzvjescaField;
            }
            set
            {
                this.vrstaIzvjescaField = value;
            }
        }

        /// <remarks/>
        public sPodnositeljIzvjesca PodnositeljIzvjesca
        {
            get
            {
                return this.podnositeljIzvjescaField;
            }
            set
            {
                this.podnositeljIzvjescaField = value;
            }
        }

        /// <remarks/>
        public sObveznikPlacanja ObveznikPlacanja
        {
            get
            {
                return this.obveznikPlacanjaField;
            }
            set
            {
                this.obveznikPlacanjaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string BrojOsoba
        {
            get
            {
                return this.brojOsobaField;
            }
            set
            {
                this.brojOsobaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string BrojRedaka
        {
            get
            {
                return this.brojRedakaField;
            }
            set
            {
                this.brojRedakaField = value;
            }
        }

        /// <remarks/>
        public sPredujamPoreza PredujamPoreza
        {
            get
            {
                return this.predujamPorezaField;
            }
            set
            {
                this.predujamPorezaField = value;
            }
        }

        /// <remarks/>
        public sDoprinosi Doprinosi
        {
            get
            {
                return this.doprinosiField;
            }
            set
            {
                this.doprinosiField = value;
            }
        }

        /// <remarks/>
        public decimal IsplaceniNeoporeziviPrimici
        {
            get
            {
                return this.isplaceniNeoporeziviPrimiciField;
            }
            set
            {
                this.isplaceniNeoporeziviPrimiciField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsplaceniNeoporeziviPrimiciSpecified
        {
            get
            {
                return this.isplaceniNeoporeziviPrimiciFieldSpecified;
            }
            set
            {
                this.isplaceniNeoporeziviPrimiciFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal KamataMO2
        {
            get
            {
                return this.kamataMO2Field;
            }
            set
            {
                this.kamataMO2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KamataMO2Specified
        {
            get
            {
                return this.kamataMO2FieldSpecified;
            }
            set
            {
                this.kamataMO2FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal UkupniNeoporeziviPrimici
        {
            get
            {
                return this.ukupniNeoporeziviPrimiciField;
            }
            set
            {
                this.ukupniNeoporeziviPrimiciField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UkupniNeoporeziviPrimiciSpecified
        {
            get
            {
                return this.ukupniNeoporeziviPrimiciFieldSpecified;
            }
            set
            {
                this.ukupniNeoporeziviPrimiciFieldSpecified = value;
            }
        }

        /// <remarks/>
        public sNaknadaZaposljavanjeInvalida NaknadaZaposljavanjeInvalida
        {
            get
            {
                return this.naknadaZaposljavanjeInvalidaField;
            }
            set
            {
                this.naknadaZaposljavanjeInvalidaField = value;
            }
        }

        /// <remarks/>
        public sIzvjesceSastavio IzvjesceSastavio
        {
            get
            {
                return this.izvjesceSastavioField;
            }
            set
            {
                this.izvjesceSastavioField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tVrstaIzvjesca
    {

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

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Item6,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("7")]
        Item7,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("8")]
        Item8,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("9")]
        Item9,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sPodnositeljIzvjesca
    {

        private string[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private sAdresa adresaField;

        private string emailField;

        private string oIBField;

        private tOznakaPodnositelja oznakaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Ime", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Naziv", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Prezime", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        public sAdresa Adresa
        {
            get
            {
                return this.adresaField;
            }
            set
            {
                this.adresaField = value;
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

        /// <remarks/>
        public string OIB
        {
            get
            {
                return this.oIBField;
            }
            set
            {
                this.oIBField = value;
            }
        }

        /// <remarks/>
        public tOznakaPodnositelja Oznaka
        {
            get
            {
                return this.oznakaField;
            }
            set
            {
                this.oznakaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        Ime,

        /// <remarks/>
        Naziv,

        /// <remarks/>
        Prezime,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sAdresa
    {

        private string mjestoField;

        private string ulicaField;

        private string brojField;

        /// <remarks/>
        public string Mjesto
        {
            get
            {
                return this.mjestoField;
            }
            set
            {
                this.mjestoField = value;
            }
        }

        /// <remarks/>
        public string Ulica
        {
            get
            {
                return this.ulicaField;
            }
            set
            {
                this.ulicaField = value;
            }
        }

        /// <remarks/>
        public string Broj
        {
            get
            {
                return this.brojField;
            }
            set
            {
                this.brojField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaPodnositelja
    {

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

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Item6,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("7")]
        Item7,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("8")]
        Item8,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("9")]
        Item9,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sObveznikPlacanja
    {

        private string[] itemsField;

        private ItemsChoiceType1[] itemsElementNameField;

        private sAdresa adresaField;

        private string emailField;

        private string oIBField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Ime", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Naziv", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Prezime", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType1[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        public sAdresa Adresa
        {
            get
            {
                return this.adresaField;
            }
            set
            {
                this.adresaField = value;
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

        /// <remarks/>
        public string OIB
        {
            get
            {
                return this.oIBField;
            }
            set
            {
                this.oIBField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        Ime,

        /// <remarks/>
        Naziv,

        /// <remarks/>
        Prezime,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sPredujamPoreza
    {

        private decimal p1Field;

        private decimal p11Field;

        private decimal p12Field;

        private decimal p2Field;

        private decimal p3Field;

        private decimal p4Field;

        private decimal p5Field;

        private decimal p6Field;

        private bool p6FieldSpecified;

        /// <remarks/>
        public decimal P1
        {
            get
            {
                return this.p1Field;
            }
            set
            {
                this.p1Field = value;
            }
        }

        /// <remarks/>
        public decimal P11
        {
            get
            {
                return this.p11Field;
            }
            set
            {
                this.p11Field = value;
            }
        }

        /// <remarks/>
        public decimal P12
        {
            get
            {
                return this.p12Field;
            }
            set
            {
                this.p12Field = value;
            }
        }

        /// <remarks/>
        public decimal P2
        {
            get
            {
                return this.p2Field;
            }
            set
            {
                this.p2Field = value;
            }
        }

        /// <remarks/>
        public decimal P3
        {
            get
            {
                return this.p3Field;
            }
            set
            {
                this.p3Field = value;
            }
        }

        /// <remarks/>
        public decimal P4
        {
            get
            {
                return this.p4Field;
            }
            set
            {
                this.p4Field = value;
            }
        }

        /// <remarks/>
        public decimal P5
        {
            get
            {
                return this.p5Field;
            }
            set
            {
                this.p5Field = value;
            }
        }

        /// <remarks/>
        public decimal P6
        {
            get
            {
                return this.p6Field;
            }
            set
            {
                this.p6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P6Specified
        {
            get
            {
                return this.p6FieldSpecified;
            }
            set
            {
                this.p6FieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sDoprinosi
    {

        private sGeneracijskaSolidarnost generacijskaSolidarnostField;

        private sKapitaliziranaStednja kapitaliziranaStednjaField;

        private sZdravstvenoOsiguranje zdravstvenoOsiguranjeField;

        private sZaposljavanje zaposljavanjeField;

        /// <remarks/>
        public sGeneracijskaSolidarnost GeneracijskaSolidarnost
        {
            get
            {
                return this.generacijskaSolidarnostField;
            }
            set
            {
                this.generacijskaSolidarnostField = value;
            }
        }

        /// <remarks/>
        public sKapitaliziranaStednja KapitaliziranaStednja
        {
            get
            {
                return this.kapitaliziranaStednjaField;
            }
            set
            {
                this.kapitaliziranaStednjaField = value;
            }
        }

        /// <remarks/>
        public sZdravstvenoOsiguranje ZdravstvenoOsiguranje
        {
            get
            {
                return this.zdravstvenoOsiguranjeField;
            }
            set
            {
                this.zdravstvenoOsiguranjeField = value;
            }
        }

        /// <remarks/>
        public sZaposljavanje Zaposljavanje
        {
            get
            {
                return this.zaposljavanjeField;
            }
            set
            {
                this.zaposljavanjeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sGeneracijskaSolidarnost
    {

        private decimal p1Field;

        private bool p1FieldSpecified;

        private decimal p2Field;

        private bool p2FieldSpecified;

        private decimal p3Field;

        private bool p3FieldSpecified;

        private decimal p4Field;

        private bool p4FieldSpecified;

        private decimal p5Field;

        private bool p5FieldSpecified;

        private decimal p6Field;

        private bool p6FieldSpecified;

        private decimal p7Field;

        private bool p7FieldSpecified;

        /// <remarks/>
        public decimal P1
        {
            get
            {
                return this.p1Field;
            }
            set
            {
                this.p1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P1Specified
        {
            get
            {
                return this.p1FieldSpecified;
            }
            set
            {
                this.p1FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P2
        {
            get
            {
                return this.p2Field;
            }
            set
            {
                this.p2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P2Specified
        {
            get
            {
                return this.p2FieldSpecified;
            }
            set
            {
                this.p2FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P3
        {
            get
            {
                return this.p3Field;
            }
            set
            {
                this.p3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P3Specified
        {
            get
            {
                return this.p3FieldSpecified;
            }
            set
            {
                this.p3FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P4
        {
            get
            {
                return this.p4Field;
            }
            set
            {
                this.p4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P4Specified
        {
            get
            {
                return this.p4FieldSpecified;
            }
            set
            {
                this.p4FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P5
        {
            get
            {
                return this.p5Field;
            }
            set
            {
                this.p5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P5Specified
        {
            get
            {
                return this.p5FieldSpecified;
            }
            set
            {
                this.p5FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P6
        {
            get
            {
                return this.p6Field;
            }
            set
            {
                this.p6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P6Specified
        {
            get
            {
                return this.p6FieldSpecified;
            }
            set
            {
                this.p6FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P7
        {
            get
            {
                return this.p7Field;
            }
            set
            {
                this.p7Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P7Specified
        {
            get
            {
                return this.p7FieldSpecified;
            }
            set
            {
                this.p7FieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sKapitaliziranaStednja
    {

        private decimal p1Field;

        private bool p1FieldSpecified;

        private decimal p2Field;

        private bool p2FieldSpecified;

        private decimal p3Field;

        private bool p3FieldSpecified;

        private decimal p4Field;

        private bool p4FieldSpecified;

        private decimal p5Field;

        private bool p5FieldSpecified;

        private decimal p6Field;

        private bool p6FieldSpecified;

        /// <remarks/>
        public decimal P1
        {
            get
            {
                return this.p1Field;
            }
            set
            {
                this.p1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P1Specified
        {
            get
            {
                return this.p1FieldSpecified;
            }
            set
            {
                this.p1FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P2
        {
            get
            {
                return this.p2Field;
            }
            set
            {
                this.p2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P2Specified
        {
            get
            {
                return this.p2FieldSpecified;
            }
            set
            {
                this.p2FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P3
        {
            get
            {
                return this.p3Field;
            }
            set
            {
                this.p3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P3Specified
        {
            get
            {
                return this.p3FieldSpecified;
            }
            set
            {
                this.p3FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P4
        {
            get
            {
                return this.p4Field;
            }
            set
            {
                this.p4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P4Specified
        {
            get
            {
                return this.p4FieldSpecified;
            }
            set
            {
                this.p4FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P5
        {
            get
            {
                return this.p5Field;
            }
            set
            {
                this.p5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P5Specified
        {
            get
            {
                return this.p5FieldSpecified;
            }
            set
            {
                this.p5FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P6
        {
            get
            {
                return this.p6Field;
            }
            set
            {
                this.p6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P6Specified
        {
            get
            {
                return this.p6FieldSpecified;
            }
            set
            {
                this.p6FieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sZdravstvenoOsiguranje
    {

        private decimal p1Field;

        private bool p1FieldSpecified;

        private decimal p2Field;

        private bool p2FieldSpecified;

        private decimal p3Field;

        private bool p3FieldSpecified;

        private decimal p4Field;

        private bool p4FieldSpecified;

        private decimal p5Field;

        private bool p5FieldSpecified;

        private decimal p6Field;

        private bool p6FieldSpecified;

        private decimal p7Field;

        private bool p7FieldSpecified;

        private decimal p8Field;

        private bool p8FieldSpecified;

        private decimal p9Field;

        private bool p9FieldSpecified;

        private decimal p10Field;

        private bool p10FieldSpecified;

        private decimal p11Field;

        private bool p11FieldSpecified;

        private decimal p12Field;

        private bool p12FieldSpecified;

        /// <remarks/>
        public decimal P1
        {
            get
            {
                return this.p1Field;
            }
            set
            {
                this.p1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P1Specified
        {
            get
            {
                return this.p1FieldSpecified;
            }
            set
            {
                this.p1FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P2
        {
            get
            {
                return this.p2Field;
            }
            set
            {
                this.p2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P2Specified
        {
            get
            {
                return this.p2FieldSpecified;
            }
            set
            {
                this.p2FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P3
        {
            get
            {
                return this.p3Field;
            }
            set
            {
                this.p3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P3Specified
        {
            get
            {
                return this.p3FieldSpecified;
            }
            set
            {
                this.p3FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P4
        {
            get
            {
                return this.p4Field;
            }
            set
            {
                this.p4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P4Specified
        {
            get
            {
                return this.p4FieldSpecified;
            }
            set
            {
                this.p4FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P5
        {
            get
            {
                return this.p5Field;
            }
            set
            {
                this.p5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P5Specified
        {
            get
            {
                return this.p5FieldSpecified;
            }
            set
            {
                this.p5FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P6
        {
            get
            {
                return this.p6Field;
            }
            set
            {
                this.p6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P6Specified
        {
            get
            {
                return this.p6FieldSpecified;
            }
            set
            {
                this.p6FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P7
        {
            get
            {
                return this.p7Field;
            }
            set
            {
                this.p7Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P7Specified
        {
            get
            {
                return this.p7FieldSpecified;
            }
            set
            {
                this.p7FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P8
        {
            get
            {
                return this.p8Field;
            }
            set
            {
                this.p8Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P8Specified
        {
            get
            {
                return this.p8FieldSpecified;
            }
            set
            {
                this.p8FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P9
        {
            get
            {
                return this.p9Field;
            }
            set
            {
                this.p9Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P9Specified
        {
            get
            {
                return this.p9FieldSpecified;
            }
            set
            {
                this.p9FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P10
        {
            get
            {
                return this.p10Field;
            }
            set
            {
                this.p10Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P10Specified
        {
            get
            {
                return this.p10FieldSpecified;
            }
            set
            {
                this.p10FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P11
        {
            get
            {
                return this.p11Field;
            }
            set
            {
                this.p11Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P11Specified
        {
            get
            {
                return this.p11FieldSpecified;
            }
            set
            {
                this.p11FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P12
        {
            get
            {
                return this.p12Field;
            }
            set
            {
                this.p12Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P12Specified
        {
            get
            {
                return this.p12FieldSpecified;
            }
            set
            {
                this.p12FieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sZaposljavanje
    {

        private decimal p1Field;

        private bool p1FieldSpecified;

        private decimal p2Field;

        private bool p2FieldSpecified;

        private decimal p3Field;

        private bool p3FieldSpecified;

        private decimal p4Field;

        private bool p4FieldSpecified;

        /// <remarks/>
        public decimal P1
        {
            get
            {
                return this.p1Field;
            }
            set
            {
                this.p1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P1Specified
        {
            get
            {
                return this.p1FieldSpecified;
            }
            set
            {
                this.p1FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P2
        {
            get
            {
                return this.p2Field;
            }
            set
            {
                this.p2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P2Specified
        {
            get
            {
                return this.p2FieldSpecified;
            }
            set
            {
                this.p2FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P3
        {
            get
            {
                return this.p3Field;
            }
            set
            {
                this.p3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P3Specified
        {
            get
            {
                return this.p3FieldSpecified;
            }
            set
            {
                this.p3FieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal P4
        {
            get
            {
                return this.p4Field;
            }
            set
            {
                this.p4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P4Specified
        {
            get
            {
                return this.p4FieldSpecified;
            }
            set
            {
                this.p4FieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sNaknadaZaposljavanjeInvalida
    {

        private string p1Field;

        private decimal p2Field;

        private bool p2FieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
        public string P1
        {
            get
            {
                return this.p1Field;
            }
            set
            {
                this.p1Field = value;
            }
        }

        /// <remarks/>
        public decimal P2
        {
            get
            {
                return this.p2Field;
            }
            set
            {
                this.p2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool P2Specified
        {
            get
            {
                return this.p2FieldSpecified;
            }
            set
            {
                this.p2FieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sIzvjesceSastavio
    {

        private string imeField;

        private string prezimeField;

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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public partial class sPrimateljiP
    {

        private long p1Field;

        private string p2Field;

        private string p3Field;

        private string p4Field;

        private string p5Field;

        private tOznakaStjecatelja p61Field;

        private tOznakaPrimici p62Field;

        private tOznakaMO p71Field;

        private tOznakaInvaliditet p72Field;

        private tOznakaMjesec p8Field;

        private tOznakaRadnoVrijeme p9Field;

        private int p10Field;

        private int p100Field;

        private System.DateTime p101Field;

        private System.DateTime p102Field;

        private decimal p11Field;

        private decimal p12Field;

        private decimal p121Field;

        private decimal p122Field;

        private decimal p123Field;

        private decimal p124Field;

        private decimal p125Field;

        private decimal p126Field;

        private decimal p127Field;

        private decimal p128Field;

        private decimal p129Field;

        private decimal p131Field;

        private decimal p132Field;

        private decimal p133Field;

        private decimal p134Field;

        private decimal p135Field;

        private decimal p141Field;

        private decimal p142Field;

        private tOznakaNeoporezivogPrimitka p151Field;

        private decimal p152Field;

        private tOznakaNacinaIsplate p161Field;

        private decimal p162Field;

        private decimal p17Field;

        /// <remarks/>
        public long P1
        {
            get
            {
                return this.p1Field;
            }
            set
            {
                this.p1Field = value;
            }
        }

        /// <remarks/>
        public string P2
        {
            get
            {
                return this.p2Field;
            }
            set
            {
                this.p2Field = value;
            }
        }

        /// <remarks/>
        public string P3
        {
            get
            {
                return this.p3Field;
            }
            set
            {
                this.p3Field = value;
            }
        }

        /// <remarks/>
        public string P4
        {
            get
            {
                return this.p4Field;
            }
            set
            {
                this.p4Field = value;
            }
        }

        /// <remarks/>
        public string P5
        {
            get
            {
                return this.p5Field;
            }
            set
            {
                this.p5Field = value;
            }
        }

        /// <remarks/>
        public tOznakaStjecatelja P61
        {
            get
            {
                return this.p61Field;
            }
            set
            {
                this.p61Field = value;
            }
        }

        /// <remarks/>
        public tOznakaPrimici P62
        {
            get
            {
                return this.p62Field;
            }
            set
            {
                this.p62Field = value;
            }
        }

        /// <remarks/>
        public tOznakaMO P71
        {
            get
            {
                return this.p71Field;
            }
            set
            {
                this.p71Field = value;
            }
        }

        /// <remarks/>
        public tOznakaInvaliditet P72
        {
            get
            {
                return this.p72Field;
            }
            set
            {
                this.p72Field = value;
            }
        }

        /// <remarks/>
        public tOznakaMjesec P8
        {
            get
            {
                return this.p8Field;
            }
            set
            {
                this.p8Field = value;
            }
        }

        /// <remarks/>
        public tOznakaRadnoVrijeme P9
        {
            get
            {
                return this.p9Field;
            }
            set
            {
                this.p9Field = value;
            }
        }

        /// <remarks/>
        public int P10
        {
            get
            {
                return this.p10Field;
            }
            set
            {
                this.p10Field = value;
            }
        }

        /// <remarks/>
        public int P100
        {
            get
            {
                return this.p100Field;
            }
            set
            {
                this.p100Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime P101
        {
            get
            {
                return this.p101Field;
            }
            set
            {
                this.p101Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime P102
        {
            get
            {
                return this.p102Field;
            }
            set
            {
                this.p102Field = value;
            }
        }

        /// <remarks/>
        public decimal P11
        {
            get
            {
                return this.p11Field;
            }
            set
            {
                this.p11Field = value;
            }
        }

        /// <remarks/>
        public decimal P12
        {
            get
            {
                return this.p12Field;
            }
            set
            {
                this.p12Field = value;
            }
        }

        /// <remarks/>
        public decimal P121
        {
            get
            {
                return this.p121Field;
            }
            set
            {
                this.p121Field = value;
            }
        }

        /// <remarks/>
        public decimal P122
        {
            get
            {
                return this.p122Field;
            }
            set
            {
                this.p122Field = value;
            }
        }

        /// <remarks/>
        public decimal P123
        {
            get
            {
                return this.p123Field;
            }
            set
            {
                this.p123Field = value;
            }
        }

        /// <remarks/>
        public decimal P124
        {
            get
            {
                return this.p124Field;
            }
            set
            {
                this.p124Field = value;
            }
        }

        /// <remarks/>
        public decimal P125
        {
            get
            {
                return this.p125Field;
            }
            set
            {
                this.p125Field = value;
            }
        }

        /// <remarks/>
        public decimal P126
        {
            get
            {
                return this.p126Field;
            }
            set
            {
                this.p126Field = value;
            }
        }

        /// <remarks/>
        public decimal P127
        {
            get
            {
                return this.p127Field;
            }
            set
            {
                this.p127Field = value;
            }
        }

        /// <remarks/>
        public decimal P128
        {
            get
            {
                return this.p128Field;
            }
            set
            {
                this.p128Field = value;
            }
        }

        /// <remarks/>
        public decimal P129
        {
            get
            {
                return this.p129Field;
            }
            set
            {
                this.p129Field = value;
            }
        }

        /// <remarks/>
        public decimal P131
        {
            get
            {
                return this.p131Field;
            }
            set
            {
                this.p131Field = value;
            }
        }

        /// <remarks/>
        public decimal P132
        {
            get
            {
                return this.p132Field;
            }
            set
            {
                this.p132Field = value;
            }
        }

        /// <remarks/>
        public decimal P133
        {
            get
            {
                return this.p133Field;
            }
            set
            {
                this.p133Field = value;
            }
        }

        /// <remarks/>
        public decimal P134
        {
            get
            {
                return this.p134Field;
            }
            set
            {
                this.p134Field = value;
            }
        }

        /// <remarks/>
        public decimal P135
        {
            get
            {
                return this.p135Field;
            }
            set
            {
                this.p135Field = value;
            }
        }

        /// <remarks/>
        public decimal P141
        {
            get
            {
                return this.p141Field;
            }
            set
            {
                this.p141Field = value;
            }
        }

        /// <remarks/>
        public decimal P142
        {
            get
            {
                return this.p142Field;
            }
            set
            {
                this.p142Field = value;
            }
        }

        /// <remarks/>
        public tOznakaNeoporezivogPrimitka P151
        {
            get
            {
                return this.p151Field;
            }
            set
            {
                this.p151Field = value;
            }
        }

        /// <remarks/>
        public decimal P152
        {
            get
            {
                return this.p152Field;
            }
            set
            {
                this.p152Field = value;
            }
        }

        /// <remarks/>
        public tOznakaNacinaIsplate P161
        {
            get
            {
                return this.p161Field;
            }
            set
            {
                this.p161Field = value;
            }
        }

        /// <remarks/>
        public decimal P162
        {
            get
            {
                return this.p162Field;
            }
            set
            {
                this.p162Field = value;
            }
        }

        /// <remarks/>
        public decimal P17
        {
            get
            {
                return this.p17Field;
            }
            set
            {
                this.p17Field = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaStjecatelja
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0000")]
        Item0000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0001")]
        Item0001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0002")]
        Item0002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0003")]
        Item0003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0004")]
        Item0004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0005")]
        Item0005,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0006")]
        Item0006,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0007")]
        Item0007,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0008")]
        Item0008,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0009")]
        Item0009,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0010")]
        Item0010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0011")]
        Item0011,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0021")]
        Item0021,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0022")]
        Item0022,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0023")]
        Item0023,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0024")]
        Item0024,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0025")]
        Item0025,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0031")]
        Item0031,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0032")]
        Item0032,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0033")]
        Item0033,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0041")]
        Item0041,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0042")]
        Item0042,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0043")]
        Item0043,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0044")]
        Item0044,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0045")]
        Item0045,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0046")]
        Item0046,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0101")]
        Item0101,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0102")]
        Item0102,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0103")]
        Item0103,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0104")]
        Item0104,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0105")]
        Item0105,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0106")]
        Item0106,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0107")]
        Item0107,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0108")]
        Item0108,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0121")]
        Item0121,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0201")]
        Item0201,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1001")]
        Item1001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1002")]
        Item1002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1003")]
        Item1003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1004")]
        Item1004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1101")]
        Item1101,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1102")]
        Item1102,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1103")]
        Item1103,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1104")]
        Item1104,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2001")]
        Item2001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2002")]
        Item2002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2003")]
        Item2003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2004")]
        Item2004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2005")]
        Item2005,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3001")]
        Item3001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4001")]
        Item4001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4002")]
        Item4002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5001")]
        Item5001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5002")]
        Item5002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5101")]
        Item5101,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5102")]
        Item5102,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5103")]
        Item5103,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5104")]
        Item5104,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5201")]
        Item5201,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5202")]
        Item5202,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5203")]
        Item5203,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5204")]
        Item5204,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5205")]
        Item5205,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5206")]
        Item5206,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5207")]
        Item5207,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5208")]
        Item5208,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5209")]
        Item5209,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5210")]
        Item5210,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5211")]
        Item5211,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5212")]
        Item5212,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5213")]
        Item5213,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5301")]
        Item5301,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5302")]
        Item5302,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5401")]
        Item5401,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5402")]
        Item5402,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5403")]
        Item5403,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5501")]
        Item5501,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5601")]
        Item5601,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5602")]
        Item5602,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5603")]
        Item5603,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5604")]
        Item5604,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5605")]
        Item5605,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5606")]
        Item5606,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5607")]
        Item5607,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5608")]
        Item5608,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5701")]
        Item5701,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5702")]
        Item5702,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaPrimici
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0000")]
        Item0000,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0001")]
        Item0001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0002")]
        Item0002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0003")]
        Item0003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0004")]
        Item0004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0021")]
        Item0021,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0022")]
        Item0022,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0023")]
        Item0023,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0024")]
        Item0024,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0025")]
        Item0025,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0026")]
        Item0026,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0027")]
        Item0027,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0028")]
        Item0028,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0041")]
        Item0041,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0042")]
        Item0042,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0043")]
        Item0043,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0044")]
        Item0044,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0045")]
        Item0045,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0046")]
        Item0046,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0051")]
        Item0051,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0052")]
        Item0052,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0061")]
        Item0061,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0062")]
        Item0062,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0063")]
        Item0063,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0064")]
        Item0064,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0071")]
        Item0071,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0072")]
        Item0072,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0081")]
        Item0081,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0082")]
        Item0082,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0083")]
        Item0083,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0084")]
        Item0084,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0086")]
        Item0086,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0087")]
        Item0087,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0088")]
        Item0088,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0090")]
        Item0090,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0091")]
        Item0091,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0092")]
        Item0092,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0093")]
        Item0093,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0094")]
        Item0094,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0095")]
        Item0095,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0096")]
        Item0096,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0097")]
        Item0097,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0098")]
        Item0098,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0101")]
        Item0101,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0102")]
        Item0102,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0103")]
        Item0103,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0201")]
        Item0201,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0202")]
        Item0202,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0203")]
        Item0203,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0204")]
        Item0204,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0205")]
        Item0205,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0206")]
        Item0206,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0207")]
        Item0207,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0208")]
        Item0208,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0209")]
        Item0209,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0210")]
        Item0210,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0211")]
        Item0211,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0212")]
        Item0212,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0213")]
        Item0213,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0214")]
        Item0214,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0215")]
        Item0215,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0216")]
        Item0216,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0217")]
        Item0217,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0218")]
        Item0218,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0219")]
        Item0219,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0301")]
        Item0301,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0302")]
        Item0302,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0303")]
        Item0303,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0321")]
        Item0321,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0322")]
        Item0322,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0323")]
        Item0323,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0331")]
        Item0331,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0332")]
        Item0332,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0333")]
        Item0333,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0334")]
        Item0334,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0335")]
        Item0335,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0401")]
        Item0401,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0402")]
        Item0402,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0403")]
        Item0403,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0404")]
        Item0404,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0405")]
        Item0405,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0406")]
        Item0406,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0407")]
        Item0407,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0408")]
        Item0408,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0409")]
        Item0409,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0410")]
        Item0410,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0411")]
        Item0411,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0412")]
        Item0412,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0413")]
        Item0413,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0414")]
        Item0414,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0415")]
        Item0415,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0416")]
        Item0416,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0417")]
        Item0417,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0418")]
        Item0418,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0419")]
        Item0419,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1001")]
        Item1001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1002")]
        Item1002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1003")]
        Item1003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1004")]
        Item1004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1005")]
        Item1005,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1006")]
        Item1006,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2001")]
        Item2001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2002")]
        Item2002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3001")]
        Item3001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3002")]
        Item3002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4001")]
        Item4001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4002")]
        Item4002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4003")]
        Item4003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4004")]
        Item4004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4005")]
        Item4005,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4006")]
        Item4006,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4007")]
        Item4007,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4008")]
        Item4008,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4009")]
        Item4009,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4010")]
        Item4010,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4011")]
        Item4011,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4012")]
        Item4012,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4013")]
        Item4013,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4014")]
        Item4014,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4015")]
        Item4015,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4016")]
        Item4016,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4017")]
        Item4017,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4018")]
        Item4018,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4019")]
        Item4019,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4020")]
        Item4020,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4021")]
        Item4021,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4022")]
        Item4022,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4023")]
        Item4023,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4024")]
        Item4024,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4025")]
        Item4025,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4026")]
        Item4026,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4027")]
        Item4027,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4028")]
        Item4028,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4029")]
        Item4029,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4030")]
        Item4030,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4031")]
        Item4031,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4032")]
        Item4032,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4033")]
        Item4033,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4034")]
        Item4034,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4035")]
        Item4035,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4036")]
        Item4036,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4037")]
        Item4037,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4038")]
        Item4038,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4039")]
        Item4039,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4040")]
        Item4040,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4041")]
        Item4041,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4042")]
        Item4042,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4043")]
        Item4043,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4044")]
        Item4044,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5001")]
        Item5001,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5002")]
        Item5002,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5003")]
        Item5003,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5004")]
        Item5004,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5005")]
        Item5005,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5101")]
        Item5101,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5102")]
        Item5102,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5103")]
        Item5103,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5104")]
        Item5104,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5105")]
        Item5105,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5106")]
        Item5106,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5107")]
        Item5107,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5108")]
        Item5108,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5109")]
        Item5109,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5110")]
        Item5110,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5111")]
        Item5111,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5112")]
        Item5112,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5701")]
        Item5701,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5702")]
        Item5702,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5703")]
        Item5703,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5721")]
        Item5721,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5801")]
        Item5801,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5802")]
        Item5802,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5803")]
        Item5803,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5804")]
        Item5804,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5805")]
        Item5805,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5806")]
        Item5806,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5807")]
        Item5807,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaMO
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaInvaliditet
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaMjesec
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

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

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaRadnoVrijeme
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaNeoporezivogPrimitka
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("18")]
        Item18,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("19")]
        Item19,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("20")]
        Item20,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("21")]
        Item21,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("22")]
        Item22,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("23")]
        Item23,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("24")]
        Item24,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("25")]
        Item25,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("26")]
        Item26,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("27")]
        Item27,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("28")]
        Item28,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("29")]
        Item29,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("30")]
        Item30,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("31")]
        Item31,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("32")]
        Item32,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("33")]
        Item33,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("34")]
        Item34,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("35")]
        Item35,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("36")]
        Item36,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("37")]
        Item37,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("38")]
        Item38,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("39")]
        Item39,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("40")]
        Item40,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41")]
        Item41,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("42")]
        Item42,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("43")]
        Item43,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("44")]
        Item44,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("45")]
        Item45,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("46")]
        Item46,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("47")]
        Item47,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("48")]
        Item48,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("49")]
        Item49,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("50")]
        Item50,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("51")]
        Item51,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("52")]
        Item52,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("53")]
        Item53,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("54")]
        Item54,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("55")]
        Item55,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("56")]
        Item56,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacJOPPD/v1-1")]
    public enum tOznakaNacinaIsplate
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

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

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Item6,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("7")]
        Item7,
    }
}