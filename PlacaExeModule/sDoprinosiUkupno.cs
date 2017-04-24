using System;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacID/v3-0")]
public class sDoprinosiUkupno
{
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak110;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak120;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak210;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak220;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak310;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak320;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak330;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak410;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak420;
    [XmlElement(Form=XmlSchemaForm.None, DataType="nonNegativeInteger")]
    public string Podatak500;
}

