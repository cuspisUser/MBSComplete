using System;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlType(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0")]
public class sPorezIprirezPremaOpciniGraduObracunatiPorez
{
    [XmlElement(Form = XmlSchemaForm.None, Order = 1)]
    public string Sifra;

    [XmlElement(Form = XmlSchemaForm.None, Order = 2)]
    public decimal Poreza;

    [XmlElement(Form = XmlSchemaForm.None, Order = 3)]
    public decimal Prireza;

    [XmlElement(Form = XmlSchemaForm.None, Order = 4)]
    public decimal Ukupno;
}

