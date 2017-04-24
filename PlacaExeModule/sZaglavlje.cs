using System;
using System.Xml.Serialization;

[XmlType(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0")]
public class sZaglavlje
{
    [XmlElement(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", Order = 1)]
    public string PodrucniUred;

    [XmlElement(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", Order = 2)]
    public string Ispostava;

    [XmlElement(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", Order = 3)]
    public sRazdoblje Razdoblje;

    [XmlElement(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", Order = 4)]
    public sZaglavljePodnositeljZahtjeva PodnositeljZahtjeva;

    [XmlElement(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", Order = 5)]
    public sIdentifikator Identifikator;
}

