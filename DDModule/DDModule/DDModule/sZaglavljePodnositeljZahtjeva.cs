namespace DDModule.DDModule
{
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0")]
    public class sZaglavljePodnositeljZahtjeva
    {
        [XmlElement(Form = XmlSchemaForm.None, Order = 1)]
        public string Naziv;

        [XmlElement(Form = XmlSchemaForm.None, Order = 2)]
        public string OIB;

        [XmlElement(Form = XmlSchemaForm.None, Order = 3)]
        public sAdresa Adresa;
    }
}

