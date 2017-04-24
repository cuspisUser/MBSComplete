using System;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0")]
public class sRazdoblje
{
    [XmlElement(Form = XmlSchemaForm.None, DataType = "date", Order = 1)]
    public DateTime DatumOd;

    [XmlElement(Form = XmlSchemaForm.None, DataType = "date", Order = 2)]
    public DateTime DatumDo;
}

