using System;
using System.ComponentModel;
using System.Xml.Serialization;

[XmlType(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
public class sDatumTemeljni
{
    [DefaultValue("http://purl.org/dc/elements/1.1/datee"), XmlAttribute]
    public string dc = "http://purl.org/dc/elements/1.1/datee";

    [XmlText]
    public string Value;
}

