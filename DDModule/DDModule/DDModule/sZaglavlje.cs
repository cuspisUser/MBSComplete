namespace DDModule.DDModule
{
    using System;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0")]
    public class sZaglavlje
    {
        [XmlElement(Form=XmlSchemaForm.None, Order = 1)]
        public sZaglavljePodnositeljZahtjeva PodnositeljZahtjeva;

        [XmlElement(Form=XmlSchemaForm.None, Order = 2)]
        public sRazdoblje Razdoblje;
    }
}

