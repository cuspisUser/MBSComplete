namespace DDModule.DDModule
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [XmlRoot("ObrazacIDD", Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0", IsNullable=false), XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0")]
    public class sObrazacIDD
    {
        [XmlElement(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0", Order = 1)]
        public sIDDmetapodaci Metapodaci;

        [XmlElement(Order = 2)]
        public sZaglavlje Zaglavlje;

        [XmlElement(Order = 3)]
        public sTijelo Tijelo;

        [DefaultValue("1.000"), XmlAttribute]
        public string verzijaSheme = "1.000";
    }
}

