using System;
using System.ComponentModel;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0"), XmlRoot("ObrazacID", Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", IsNullable=false)]
public class sObrazacID
{
    [XmlElement(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0", Order = 1)]
    public sIDmetapodaci Metapodaci;

    [XmlElement(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", Order = 2)]
    public sZaglavlje Zaglavlje;

    [XmlElement(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", Order = 3)]
    public sTijelo Tijelo;

    [DefaultValue("30"), XmlAttribute]
    public string verzijaSheme = "30";

}

