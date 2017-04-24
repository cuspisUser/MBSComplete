namespace DDModule.ID1OBRAZAC
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [Serializable, GeneratedCode("xsd", "2.0.50727.3038"), XmlType(Namespace="http://e-porezna.porezna-uprava.hr/obrasci/id1/v2-0"), DesignerCategory("code"), DebuggerStepThrough]
    public class RacunTip
    {
        private string brojRacunaField;
        private decimal iznosField;

        [XmlAttribute]
        public string brojRacuna
        {
            get
            {
                return this.brojRacunaField;
            }
            set
            {
                this.brojRacunaField = value;
            }
        }

        public decimal Iznos
        {
            get
            {
                return this.iznosField;
            }
            set
            {
                this.iznosField = value;
            }
        }
    }
}

