using System;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlType(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0")]
public class sTijelo
{
    [XmlElement(Form = XmlSchemaForm.None, Order = 1)]
    public sIsplaceniPrimiciIObracunPoreza IsplaceniPrimiciIObracunPoreza;

    [XmlElement(Form = XmlSchemaForm.None, Order = 2)]
    public sDoprinosiUkupno DoprinosiUkupno;

    [XmlArrayItem("ObracunatiPorez", Form = XmlSchemaForm.None, IsNullable = false), XmlArray(Form = XmlSchemaForm.None, Order = 3)]
    public sPorezIprirezPremaOpciniGraduObracunatiPorez[] ObracunatiPorezi;

    [XmlElement(Form = XmlSchemaForm.None, Order = 4)]
    public sUkupno Ukupno;
}

