using System.Xml.Serialization;

namespace OPZShema
{

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	[System.Xml.Serialization.XmlRootAttribute("ObrazacOPZ", Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0", IsNullable=false)]
	public partial class sObrazacOPZ {
		
		private sOPZmetapodaci metapodaciField;
		
		private sZaglavlje zaglavljeField;
		
		private sTijelo tijeloField;
		
		private string verzijaShemeField;
		
		public sObrazacOPZ() {
			this.verzijaShemeField = "1.0";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
		public sOPZmetapodaci Metapodaci {
			get {
				return this.metapodaciField;
			}
			set {
				this.metapodaciField = value;
			}
		}
		
		/// <remarks/>
		public sZaglavlje Zaglavlje {
			get {
				return this.zaglavljeField;
			}
			set {
				this.zaglavljeField = value;
			}
		}
		
		/// <remarks/>
		public sTijelo Tijelo {
			get {
				return this.tijeloField;
			}
			set {
				this.tijeloField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string verzijaSheme {
			get {
				return this.verzijaShemeField;
			}
			set {
				this.verzijaShemeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	[System.Xml.Serialization.XmlRootAttribute("Metapodaci", Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0", IsNullable=false)]
	public partial class sOPZmetapodaci {
		
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
		public sNaslovTemeljni Naslov {
			get {
				return this.naslovField;
			}
			set {
				this.naslovField = value;
			}
		}
		
		/// <remarks/>
		public sAutorTemeljni Autor {
			get {
				return this.autorField;
			}
			set {
				this.autorField = value;
			}
		}
		
		/// <remarks/>
		public sDatumTemeljni Datum {
			get {
				return this.datumField;
			}
			set {
				this.datumField = value;
			}
		}
		
		/// <remarks/>
		public sFormatTemeljni Format {
			get {
				return this.formatField;
			}
			set {
				this.formatField = value;
			}
		}
		
		/// <remarks/>
		public sJezikTemeljni Jezik {
			get {
				return this.jezikField;
			}
			set {
				this.jezikField = value;
			}
		}
		
		/// <remarks/>
		public sIdentifikatorTemeljni Identifikator {
			get {
				return this.identifikatorField;
			}
			set {
				this.identifikatorField = value;
			}
		}
		
		/// <remarks/>
		public sUskladjenost Uskladjenost {
			get {
				return this.uskladjenostField;
			}
			set {
				this.uskladjenostField = value;
			}
		}
		
		/// <remarks/>
		public sTipTemeljni Tip {
			get {
				return this.tipField;
			}
			set {
				this.tipField = value;
			}
		}
		
		/// <remarks/>
		public sAdresantTemeljni Adresant {
			get {
				return this.adresantField;
			}
			set {
				this.adresantField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sNaslovTemeljni {
		
		private string dcField;
		
		private string valueField;
		
		public sNaslovTemeljni() {
			this.dcField = "http://purl.org/dc/elements/1.1/title";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sRacun {
		
		private string r1Field;
		
		private string r2Field;
		
		private string r3Field;
		
		private string r4Field;
		
		private string r5Field;
		
		private decimal r6Field;
		
		private decimal r7Field;
		
		private decimal r8Field;
		
		private decimal r9Field;
		
		private decimal r10Field;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
		public string R1 {
			get {
				return this.r1Field;
			}
			set {
				this.r1Field = value;
			}
		}
		
		/// <remarks/>
		public string R2 {
			get {
				return this.r2Field;
			}
			set {
				this.r2Field = value;
			}
		}
		
		/// <remarks/>
		public string R3 {
			get {
				return this.r3Field;
			}
			set {
				this.r3Field = value;
			}
		}
		
		/// <remarks/>
		public string R4 {
			get {
				return this.r4Field;
			}
			set {
				this.r4Field = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
		public string R5 {
			get {
				return this.r5Field;
			}
			set {
				this.r5Field = value;
			}
		}
		
		/// <remarks/>
		public decimal R6 {
			get {
				return this.r6Field;
			}
			set {
				this.r6Field = value;
			}
		}
		
		/// <remarks/>
		public decimal R7 {
			get {
				return this.r7Field;
			}
			set {
				this.r7Field = value;
			}
		}
		
		/// <remarks/>
		public decimal R8 {
			get {
				return this.r8Field;
			}
			set {
				this.r8Field = value;
			}
		}
		
		/// <remarks/>
		public decimal R9 {
			get {
				return this.r9Field;
			}
			set {
				this.r9Field = value;
			}
		}
		
		/// <remarks/>
		public decimal R10 {
			get {
				return this.r10Field;
			}
			set {
				this.r10Field = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sKupac {
		
		private string k1Field;
		
		private string k2Field;
		
		private string k3Field;
		
		private string k4Field;
		
		private decimal k5Field;
		
		private decimal k6Field;
		
		private decimal k7Field;
		
		private decimal k8Field;
		
		private decimal k9Field;
		
		private sRacun[] racuniField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
		public string K1 {
			get {
				return this.k1Field;
			}
			set {
				this.k1Field = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string K2 {
			get {
				return this.k2Field;
			}
			set {
				this.k2Field = value;
			}
		}
		
		/// <remarks/>
		public string K3 {
			get {
				return this.k3Field;
			}
			set {
				this.k3Field = value;
			}
		}
		
		/// <remarks/>
		public string K4 {
			get {
				return this.k4Field;
			}
			set {
				this.k4Field = value;
			}
		}
		
		/// <remarks/>
		public decimal K5 {
			get {
				return this.k5Field;
			}
			set {
				this.k5Field = value;
			}
		}
		
		/// <remarks/>
		public decimal K6 {
			get {
				return this.k6Field;
			}
			set {
				this.k6Field = value;
			}
		}
		
		/// <remarks/>
		public decimal K7 {
			get {
				return this.k7Field;
			}
			set {
				this.k7Field = value;
			}
		}
		
		/// <remarks/>
		public decimal K8 {
			get {
				return this.k8Field;
			}
			set {
				this.k8Field = value;
			}
		}
		
		/// <remarks/>
		public decimal K9 {
			get {
				return this.k9Field;
			}
			set {
				this.k9Field = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("Racun", IsNullable=false)]
		public sRacun[] Racuni {
			get {
				return this.racuniField;
			}
			set {
				this.racuniField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sTijelo {
		
		private sKupac[] kupciField;
		
		private decimal ukupanIznosRacunaObrascaField;
		
		private decimal ukupanIznosPdvObrascaField;
		
		private decimal ukupanIznosRacunaSPdvObrascaField;
		
		private decimal ukupniPlaceniIznosRacunaObrascaField;
		
		private decimal neplaceniIznosRacunaObrascaField;
		
		private decimal oPZUkupanIznosRacunaSPdvField;
		
		private decimal oPZUkupanIznosPdvField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("Kupac", IsNullable=false)]
		public sKupac[] Kupci {
			get {
				return this.kupciField;
			}
			set {
				this.kupciField = value;
			}
		}
		
		/// <remarks/>
		public decimal UkupanIznosRacunaObrasca {
			get {
				return this.ukupanIznosRacunaObrascaField;
			}
			set {
				this.ukupanIznosRacunaObrascaField = value;
			}
		}
		
		/// <remarks/>
		public decimal UkupanIznosPdvObrasca {
			get {
				return this.ukupanIznosPdvObrascaField;
			}
			set {
				this.ukupanIznosPdvObrascaField = value;
			}
		}
		
		/// <remarks/>
		public decimal UkupanIznosRacunaSPdvObrasca {
			get {
				return this.ukupanIznosRacunaSPdvObrascaField;
			}
			set {
				this.ukupanIznosRacunaSPdvObrascaField = value;
			}
		}
		
		/// <remarks/>
		public decimal UkupniPlaceniIznosRacunaObrasca {
			get {
				return this.ukupniPlaceniIznosRacunaObrascaField;
			}
			set {
				this.ukupniPlaceniIznosRacunaObrascaField = value;
			}
		}
		
		/// <remarks/>
		public decimal NeplaceniIznosRacunaObrasca {
			get {
				return this.neplaceniIznosRacunaObrascaField;
			}
			set {
				this.neplaceniIznosRacunaObrascaField = value;
			}
		}
		
		/// <remarks/>
		public decimal OPZUkupanIznosRacunaSPdv {
			get {
				return this.oPZUkupanIznosRacunaSPdvField;
			}
			set {
				this.oPZUkupanIznosRacunaSPdvField = value;
			}
		}
		
		/// <remarks/>
		public decimal OPZUkupanIznosPdv {
			get {
				return this.oPZUkupanIznosPdvField;
			}
			set {
				this.oPZUkupanIznosPdvField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sIzvjesceSastavio {
		
		private string imeField;
		
		private string prezimeField;
		
		private string telefonField;
		
		private string faxField;
		
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
		public string Telefon {
			get {
				return this.telefonField;
			}
			set {
				this.telefonField = value;
			}
		}
		
		/// <remarks/>
		public string Fax {
			get {
				return this.faxField;
			}
			set {
				this.faxField = value;
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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sAdresa {
		
		private string mjestoField;
		
		private string ulicaField;
		
		private string brojField;
		
		/// <remarks/>
		public string Mjesto {
			get {
				return this.mjestoField;
			}
			set {
				this.mjestoField = value;
			}
		}
		
		/// <remarks/>
		public string Ulica {
			get {
				return this.ulicaField;
			}
			set {
				this.ulicaField = value;
			}
		}
		
		/// <remarks/>
		public string Broj {
			get {
				return this.brojField;
			}
			set {
				this.brojField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sPorezniObveznik {
		
		private string oIBField;
		
		private string[] itemsField;
		
		private ItemsChoiceType[] itemsElementNameField;
		
		private sAdresa adresaField;
		
		private string emailField;
		
		/// <remarks/>
		public string OIB {
			get {
				return this.oIBField;
			}
			set {
				this.oIBField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Ime", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Naziv", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Prezime", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public string[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType[] ItemsElementName {
			get {
				return this.itemsElementNameField;
			}
			set {
				this.itemsElementNameField = value;
			}
		}
		
		/// <remarks/>
		public sAdresa Adresa {
			get {
				return this.adresaField;
			}
			set {
				this.adresaField = value;
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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0", IncludeInSchema=false)]
	public enum ItemsChoiceType {
		
		/// <remarks/>
		Ime,
		
		/// <remarks/>
		Naziv,
		
		/// <remarks/>
		Prezime,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sRazdoblje {
		
		private System.DateTime datumOdField;
		
		private System.DateTime datumDoField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime DatumOd {
			get {
				return this.datumOdField;
			}
			set {
				this.datumOdField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime DatumDo {
			get {
				return this.datumDoField;
			}
			set {
				this.datumDoField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacOPZ/v1-0")]
	public partial class sZaglavlje {
		
		private sRazdoblje razdobljeField;
		
		private sPorezniObveznik porezniObveznikField;
		
		private sIzvjesceSastavio izvjesceSastavioField;
		
		private System.DateTime naDanField;
		
		private System.DateTime nisuNaplaceniDoField;
		
		/// <remarks/>
		public sRazdoblje Razdoblje {
			get {
				return this.razdobljeField;
			}
			set {
				this.razdobljeField = value;
			}
		}
		
		/// <remarks/>
		public sPorezniObveznik PorezniObveznik {
			get {
				return this.porezniObveznikField;
			}
			set {
				this.porezniObveznikField = value;
			}
		}
		
		/// <remarks/>
		public sIzvjesceSastavio IzvjesceSastavio {
			get {
				return this.izvjesceSastavioField;
			}
			set {
				this.izvjesceSastavioField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime NaDan {
			get {
				return this.naDanField;
			}
			set {
				this.naDanField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime NisuNaplaceniDo {
			get {
				return this.nisuNaplaceniDoField;
			}
			set {
				this.nisuNaplaceniDoField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sAdresantTemeljni {
		
		private string valueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sTipTemeljni {
		
		private string dcField;
		
		private tTip valueField;
		
		public sTipTemeljni() {
			this.dcField = "http://purl.org/dc/elements/1.1/type";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public tTip Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
	public enum tTip {
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Elektronički obrazac")]
		Elektroničkiobrazac,
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(sUskladjenost))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sUskladjenostTemeljni {
		
		private string dcField;
		
		private string valueField;
		
		public sUskladjenostTemeljni() {
			this.dcField = "http://purl.org/dc/terms/conformsTo";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sUskladjenost : sUskladjenostTemeljni {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sIdentifikatorTemeljni {
		
		private string dcField;
		
		private string valueField;
		
		public sIdentifikatorTemeljni() {
			this.dcField = "http://purl.org/dc/elements/1.1/identifier";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sJezikTemeljni {
		
		private string dcField;
		
		private tJezik valueField;
		
		public sJezikTemeljni() {
			this.dcField = "http://purl.org/dc/elements/1.1/language";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public tJezik Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
	public enum tJezik {
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("hr-HR")]
		hrHR,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sFormatTemeljni {
		
		private string dcField;
		
		private tFormat valueField;
		
		public sFormatTemeljni() {
			this.dcField = "http://purl.org/dc/elements/1.1/format";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public tFormat Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
	public enum tFormat {
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("text/xml")]
		textxml,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sDatumTemeljni {
		
		private string dcField;
		
		private string valueField;
		
		public sDatumTemeljni() {
			this.dcField = "http://purl.org/dc/elements/1.1/date";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
	public partial class sAutorTemeljni {
		
		private string dcField;
		
		private string valueField;
		
		public sAutorTemeljni() {
			this.dcField = "http://purl.org/dc/elements/1.1/creator";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string dc {
			get {
				return this.dcField;
			}
			set {
				this.dcField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0", IsNullable=false)]
	public partial class ObrazacOPZGreske {
		
		private sMetapodaci metapodaciField;
		
		private sZaglavlje1 zaglavljeField;
		
		private sGreska[] greskeField;
		
		/// <remarks/>
		public sMetapodaci Metapodaci {
			get {
				return this.metapodaciField;
			}
			set {
				this.metapodaciField = value;
			}
		}
		
		/// <remarks/>
		public sZaglavlje1 Zaglavlje {
			get {
				return this.zaglavljeField;
			}
			set {
				this.zaglavljeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("Greska", IsNullable=false)]
		public sGreska[] Greske {
			get {
				return this.greskeField;
			}
			set {
				this.greskeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0")]
	public partial class sMetapodaci {
		
		private string naslovField;
		
		private System.DateTime datumField;
		
		private tFormat formatField;
		
		private tJezik jezikField;
		
		private string uskladjenostField;
		
		public sMetapodaci() {
			this.naslovField = "Greške obrasca OPZ";
			this.formatField = tFormat.textxml;
			this.jezikField = tJezik.hrHR;
			this.uskladjenostField = "ObrazacOPZGreske-v1-1";
		}
		
		/// <remarks/>
		public string Naslov {
			get {
				return this.naslovField;
			}
			set {
				this.naslovField = value;
			}
		}
		
		/// <remarks/>
		public System.DateTime Datum {
			get {
				return this.datumField;
			}
			set {
				this.datumField = value;
			}
		}
		
		/// <remarks/>
		public tFormat Format {
			get {
				return this.formatField;
			}
			set {
				this.formatField = value;
			}
		}
		
		/// <remarks/>
		public tJezik Jezik {
			get {
				return this.jezikField;
			}
			set {
				this.jezikField = value;
			}
		}
		
		/// <remarks/>
		public string Uskladjenost {
			get {
				return this.uskladjenostField;
			}
			set {
				this.uskladjenostField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="sZaglavlje", Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0")]
	public partial class sZaglavlje1 {
		
		private string identifikatorObrascaField;
		
		private string oznakaIzvjescaField;
		
		private tVrstaIzvjesca vrstaIzvjescaField;
		
		private string oIBPodnositeljaField;
		
		private tOznakaPodnositelja oznakaPodnositeljaField;
		
		private string oIBObveznikaPlacanjaField;
		
		private System.DateTime datumIzvjescaField;
		
		/// <remarks/>
		public string IdentifikatorObrasca {
			get {
				return this.identifikatorObrascaField;
			}
			set {
				this.identifikatorObrascaField = value;
			}
		}
		
		/// <remarks/>
		public string OznakaIzvjesca {
			get {
				return this.oznakaIzvjescaField;
			}
			set {
				this.oznakaIzvjescaField = value;
			}
		}
		
		/// <remarks/>
		public tVrstaIzvjesca VrstaIzvjesca {
			get {
				return this.vrstaIzvjescaField;
			}
			set {
				this.vrstaIzvjescaField = value;
			}
		}
		
		/// <remarks/>
		public string OIBPodnositelja {
			get {
				return this.oIBPodnositeljaField;
			}
			set {
				this.oIBPodnositeljaField = value;
			}
		}
		
		/// <remarks/>
		public tOznakaPodnositelja OznakaPodnositelja {
			get {
				return this.oznakaPodnositeljaField;
			}
			set {
				this.oznakaPodnositeljaField = value;
			}
		}
		
		/// <remarks/>
		public string OIBObveznikaPlacanja {
			get {
				return this.oIBObveznikaPlacanjaField;
			}
			set {
				this.oIBObveznikaPlacanjaField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime DatumIzvjesca {
			get {
				return this.datumIzvjescaField;
			}
			set {
				this.datumIzvjescaField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0")]
	public enum tVrstaIzvjesca {
		
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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0")]
	public enum tOznakaPodnositelja {
		
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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0")]
	public partial class sGreska {
		
		private long redniBrojRetkaStraneBField;
		
		private string oIBStjecateljaField;
		
		private string sifraField;
		
		private string opisField;
		
		private tTipGreske tipField;
		
		/// <remarks/>
		public long RedniBrojRetkaStraneB {
			get {
				return this.redniBrojRetkaStraneBField;
			}
			set {
				this.redniBrojRetkaStraneBField = value;
			}
		}
		
		/// <remarks/>
		public string OIBStjecatelja {
			get {
				return this.oIBStjecateljaField;
			}
			set {
				this.oIBStjecateljaField = value;
			}
		}
		
		/// <remarks/>
		public string Sifra {
			get {
				return this.sifraField;
			}
			set {
				this.sifraField = value;
			}
		}
		
		/// <remarks/>
		public string Opis {
			get {
				return this.opisField;
			}
			set {
				this.opisField = value;
			}
		}
		
		/// <remarks/>
		public tTipGreske Tip {
			get {
				return this.tipField;
			}
			set {
				this.tipField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://e-porezna.porezna-uprava.hr/sheme/ObrazacOPZ/Greske/v1-0")]
	public enum tTipGreske {
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,
	}
}