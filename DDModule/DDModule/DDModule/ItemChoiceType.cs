namespace DDModule.DDModule
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://e-porezna.porezna-uprava.hr/sheme/zahtjevi/ObrazacIDD/v1-0", IncludeInSchema=false)]
    public enum ItemChoiceType
    {
        Naziv,
        Prezime,
        Ime
    }
}

