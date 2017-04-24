namespace DDModule.DDModule
{
    using System;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0")]
    public class sTijeloPodatak051
    {
        [XmlElement(Form=XmlSchemaForm.None)]
        public decimal Iznos3;
        [XmlElement(Form=XmlSchemaForm.None)]
        public decimal Iznos7;
        [XmlElement(Form=XmlSchemaForm.None)]
        public decimal Iznos9;
    }
}

