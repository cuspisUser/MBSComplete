namespace DDModule
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct isplate
    {
        public string oib;
        public string mbg;
        public string opcina;
        public string ime;
        public string prezime;
        public decimal primitak;
        public decimal izdatak;
        public decimal izdatakdoprinosa;
    }
}

