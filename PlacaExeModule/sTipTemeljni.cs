using System;
using System.ComponentModel;
using System.Xml.Serialization;
using PlacaExe;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0")]
public class sTipTemeljni
{
    [DefaultValue("http://purl.org/dc/elements/1.1/typee"), XmlAttribute]
    public string dc = "http://purl.org/dc/elements/1.1/typee";

    [XmlText]
    public tTip Value;
}

