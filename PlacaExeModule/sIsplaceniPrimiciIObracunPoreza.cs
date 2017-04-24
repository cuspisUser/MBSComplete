using System;
using System.Xml.Schema;
using System.Xml.Serialization;

public class sIsplaceniPrimiciIObracunPoreza
{
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak100;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak200;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak210;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak220;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak230;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak300;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak400;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak500;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak600;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak610;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak620;
    [XmlElement(Form=XmlSchemaForm.None)]
    public decimal Podatak700;
    [XmlElement(Form=XmlSchemaForm.None, DataType="nonNegativeInteger")]
    public string Podatak800;
}

