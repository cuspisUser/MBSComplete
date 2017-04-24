using System;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0", IncludeInSchema=false)]
public enum ItemChoiceType
{
    Ime,
    Prezime,
    Naziv
}

