namespace DDModule.DDModule
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0"), XmlRoot("Metapodaci", Namespace="http://e-porezna.porezna-uprava.hr/sheme/Metapodaci/v2-0", IsNullable=false)]
    public class sIDDmetapodaci
    {
        [XmlElement(Order = 1)]
        public sNaslovTemeljni Naslov;

        [XmlElement(Order = 2)]
        public sAutorTemeljni Autor;

        [XmlElement(Order = 3)]
        public sDatumTemeljni Datum;

        [XmlElement(Order = 4)]
        public sFormatTemeljni Format;

        [XmlElement(Order = 5)]
        public sJezikTemeljni Jezik;

        [XmlElement(Order = 6)]
        public sIdentifikatorTemeljni Identifikator;

        [XmlElement(Order = 7)]
        public sUskladjenost Uskladjenost;

        [XmlElement(Order = 8)]
        public sTipTemeljni Tip;

        [XmlElement(Order = 9)]
        public sAdresantTemeljni Adresant;
    }
}

