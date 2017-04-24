using System;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0")]
public enum sIdentifikator
{
    [XmlEnum("1")]
    Item1 = 0,
    [XmlEnum("10")]
    Item10 = 9,
    [XmlEnum("11")]
    Item11 = 10,
    [XmlEnum("12")]
    Item12 = 11,
    [XmlEnum("13")]
    Item13 = 12,
    [XmlEnum("2")]
    Item2 = 1,
    [XmlEnum("3")]
    Item3 = 2,
    [XmlEnum("4")]
    Item4 = 3,
    [XmlEnum("5")]
    Item5 = 4,
    [XmlEnum("6")]
    Item6 = 5,
    [XmlEnum("7")]
    Item7 = 6,
    [XmlEnum("8")]
    Item8 = 7,
    [XmlEnum("9")]
    Item9 = 8
}

