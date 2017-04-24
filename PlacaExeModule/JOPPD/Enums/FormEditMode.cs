using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JOPPD.Enums
{
    public enum FormEditMode
    {
        None,
        Insert,
        Update,
        Copy
    }

    public enum Vrstaobracuna
    {
        NagradePraksa,
        NagradeNatjecanja,
        Stipendije,
        PrijevozNezaposleni,
        StudentServisNeoporezivo,
        StudentServisOporezivo,
        SocijalnaNaknada
    }

    public enum VrsteOsoba
    {
        Ucenik = 1,
        Roditelj = 2,
        Ostalo = 4,
        UcenikPraksa = 8,
        RoditeljPraksa = 9
    }
}
