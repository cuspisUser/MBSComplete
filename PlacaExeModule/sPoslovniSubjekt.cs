using System;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlType(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0"), XmlInclude(typeof(sZaglavljePodnositeljZahtjeva))]
public class sPoslovniSubjekt
{
    [XmlElement(Form = XmlSchemaForm.None, Order = 1)]
    public string Naziv;

    [XmlElement(Form = XmlSchemaForm.None, Order = 2)]
    public string OIB;
}

