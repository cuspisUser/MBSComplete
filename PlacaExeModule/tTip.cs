﻿using System;
using System.Xml.Serialization;


namespace PlacaExe
{
    [XmlType(Namespace = "http://e-porezna.porezna-uprava.hr/sheme/TemeljniTipovi/v2-1")]
    public enum tTip
    {
        [XmlEnum("Elektronički obrazac")]
        Elektroničkiobrazac = 0
    }
}

