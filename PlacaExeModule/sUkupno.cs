using System;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0")]
public class sUkupno
{
    [XmlElement(Form = XmlSchemaForm.None, Order = 1)]
    public decimal Poreza;

    [XmlElement(Form = XmlSchemaForm.None, Order = 2)]
    public decimal Prireza;

    [XmlElement(Form = XmlSchemaForm.None, Order = 3)]
    public decimal Ukupno;
}

