﻿namespace DDModule.DDModule
{
    using System;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0")]
    public class sTijeloPodatak010
    {
        [XmlElement(Form=XmlSchemaForm.None)]
        public int Iznos3;
        [XmlElement(Form=XmlSchemaForm.None)]
        public int Iznos4;
        [XmlElement(Form=XmlSchemaForm.None)]
        public int Iznos5;
        [XmlElement(Form=XmlSchemaForm.None)]
        public int Iznos6;
        [XmlElement(Form=XmlSchemaForm.None)]
        public int Iznos7;
        [XmlElement(Form=XmlSchemaForm.None)]
        public int Iznos8;
        [XmlElement(Form=XmlSchemaForm.None)]
        public int Iznos9;
    }
}

