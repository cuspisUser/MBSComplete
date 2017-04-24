using System;
using System.ComponentModel;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
public class sNaslovTemeljni
{
    [DefaultValue("http://purl.org/dc/elements/1.1/titlee"), XmlAttribute]
    public string dc = "http://purl.org/dc/elements/1.1/titlee";
    [XmlText]
    public string Value;
}

