namespace DDModule.DDModule
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
    public class sJezikTemeljni
    {
        [XmlAttribute, DefaultValue("http://purl.org/dc/elements/1.1/languagee")]
        public string dc = "http://purl.org/dc/elements/1.1/languagee";
        [XmlText]
        public tJezik Value;
    }
}

