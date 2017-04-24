namespace DDModule.DDModule
{
    using System;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0")]
    public class sAdresa
    {
        [XmlElement(Form = XmlSchemaForm.None, Order = 1)]
        public string Mjesto;

        [XmlElement(Form = XmlSchemaForm.None, Order = 2)]
        public string Ulica;

        [XmlElement(Form = XmlSchemaForm.None, Order = 3)]
        public string Broj;
    }
}

