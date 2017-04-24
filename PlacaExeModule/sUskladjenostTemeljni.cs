using System;
using System.ComponentModel;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0"), XmlInclude(typeof(sUskladjenost))]
public class sUskladjenostTemeljni
{
    [XmlAttribute, DefaultValue("http://purl.org/dc/terms/conformsToe")]
    public string dc = "http://purl.org/dc/terms/conformsToe";
    [XmlText]
    public string Value;
}

