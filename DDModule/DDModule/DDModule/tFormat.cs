namespace DDModule.DDModule
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
    public enum tFormat
    {
        [XmlEnum("text/xml")]
        textxml = 0
    }
}

