namespace Placa
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;

    [Serializable]
    public class OBRACUNDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OBRACUNDataTable tableOBRACUN;
        private ObracunDoprinosiDataTable tableObracunDoprinosi;
        private ObracunElementiDataTable tableObracunElementi;
        private OBRACUNKreditiDataTable tableOBRACUNKrediti;
        private OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable tableOBRACUNOBRACUNLevel1ObracunIzuzece;
        private OBRACUNOBRACUNLevel1ObracunKrizniDataTable tableOBRACUNOBRACUNLevel1ObracunKrizni;
        private OBRACUNObustaveDataTable tableOBRACUNObustave;
        private ObracunOlaksiceDataTable tableObracunOlaksice;
        private ObracunPoreziDataTable tableObracunPorezi;
        private ObracunRadniciDataTable tableObracunRadnici;

        public OBRACUNDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OBRACUNDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (this.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler2;
                this.Relations.CollectionChanged += handler2;
            }
            else
            {
                string s = Conversions.ToString(info.GetValue("XmlSchema", typeof(string)));
                if (this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"] != null)
                    {
                        this.Tables.Add(new OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable(dataSet.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"]));
                    }
                    if (dataSet.Tables["OBRACUNOBRACUNLevel1ObracunKrizni"] != null)
                    {
                        this.Tables.Add(new OBRACUNOBRACUNLevel1ObracunKrizniDataTable(dataSet.Tables["OBRACUNOBRACUNLevel1ObracunKrizni"]));
                    }
                    if (dataSet.Tables["ObracunElementi"] != null)
                    {
                        this.Tables.Add(new ObracunElementiDataTable(dataSet.Tables["ObracunElementi"]));
                    }
                    if (dataSet.Tables["OBRACUNObustave"] != null)
                    {
                        this.Tables.Add(new OBRACUNObustaveDataTable(dataSet.Tables["OBRACUNObustave"]));
                    }
                    if (dataSet.Tables["OBRACUNKrediti"] != null)
                    {
                        this.Tables.Add(new OBRACUNKreditiDataTable(dataSet.Tables["OBRACUNKrediti"]));
                    }
                    if (dataSet.Tables["ObracunOlaksice"] != null)
                    {
                        this.Tables.Add(new ObracunOlaksiceDataTable(dataSet.Tables["ObracunOlaksice"]));
                    }
                    if (dataSet.Tables["ObracunPorezi"] != null)
                    {
                        this.Tables.Add(new ObracunPoreziDataTable(dataSet.Tables["ObracunPorezi"]));
                    }
                    if (dataSet.Tables["ObracunDoprinosi"] != null)
                    {
                        this.Tables.Add(new ObracunDoprinosiDataTable(dataSet.Tables["ObracunDoprinosi"]));
                    }
                    if (dataSet.Tables["ObracunRadnici"] != null)
                    {
                        this.Tables.Add(new ObracunRadniciDataTable(dataSet.Tables["ObracunRadnici"]));
                    }
                    if (dataSet.Tables["OBRACUN"] != null)
                    {
                        this.Tables.Add(new OBRACUNDataTable(dataSet.Tables["OBRACUN"]));
                    }
                    this.DataSetName = dataSet.DataSetName;
                    this.Prefix = dataSet.Prefix;
                    this.Namespace = dataSet.Namespace;
                    this.Locale = dataSet.Locale;
                    this.CaseSensitive = dataSet.CaseSensitive;
                    this.EnforceConstraints = dataSet.EnforceConstraints;
                    this.Merge(dataSet, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    this.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                this.GetSerializationData(info, context);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
        }

        public override DataSet Clone()
        {
            OBRACUNDataSet set = (OBRACUNDataSet) base.Clone();
            set.InitVars();
            return set;
        }

        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            OBRACUNDataSet set = new OBRACUNDataSet();
            XmlSchemaComplexType type2 = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            xs.Add(set.GetSchemaSerializable());
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = set.Namespace
            };
            sequence.Items.Add(item);
            type2.Particle = sequence;
            return type2;
        }

        private void InitClass()
        {
            this.InitClassBase();
            this.ExtendedProperties.Add("DataAdapterName", "OBRACUNDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1008");
            this.ExtendedProperties.Add("DataSetName", "OBRACUNDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOBRACUNDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OBRACUN");
            this.ExtendedProperties.Add("ObjectDescription", "Obraeun");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "High");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "OBRACUNDataSet";
            this.Namespace = "http://www.tempuri.org/OBRACUN";
            this.tableOBRACUNOBRACUNLevel1ObracunIzuzece = new OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable();
            this.Tables.Add(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece);
            this.tableOBRACUNOBRACUNLevel1ObracunKrizni = new OBRACUNOBRACUNLevel1ObracunKrizniDataTable();
            this.Tables.Add(this.tableOBRACUNOBRACUNLevel1ObracunKrizni);
            this.tableObracunElementi = new ObracunElementiDataTable();
            this.Tables.Add(this.tableObracunElementi);
            this.tableOBRACUNObustave = new OBRACUNObustaveDataTable();
            this.Tables.Add(this.tableOBRACUNObustave);
            this.tableOBRACUNKrediti = new OBRACUNKreditiDataTable();
            this.Tables.Add(this.tableOBRACUNKrediti);
            this.tableObracunOlaksice = new ObracunOlaksiceDataTable();
            this.Tables.Add(this.tableObracunOlaksice);
            this.tableObracunPorezi = new ObracunPoreziDataTable();
            this.Tables.Add(this.tableObracunPorezi);
            this.tableObracunDoprinosi = new ObracunDoprinosiDataTable();
            this.Tables.Add(this.tableObracunDoprinosi);
            this.tableObracunRadnici = new ObracunRadniciDataTable();
            this.Tables.Add(this.tableObracunRadnici);
            this.tableOBRACUN = new OBRACUNDataTable();
            this.Tables.Add(this.tableOBRACUN);
            this.Relations.Add("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"].Columns["IDOBRACUN"], this.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece"].Nested = true;
            this.Relations.Add("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["OBRACUNOBRACUNLevel1ObracunKrizni"].Columns["IDOBRACUN"], this.Tables["OBRACUNOBRACUNLevel1ObracunKrizni"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni"].Nested = true;
            this.Relations.Add("ObracunRadnici_ObracunElementi", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["ObracunElementi"].Columns["IDOBRACUN"], this.Tables["ObracunElementi"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_ObracunElementi"].Nested = true;
            this.Relations.Add("ObracunRadnici_OBRACUNObustave", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["OBRACUNObustave"].Columns["IDOBRACUN"], this.Tables["OBRACUNObustave"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_OBRACUNObustave"].Nested = true;
            this.Relations.Add("ObracunRadnici_OBRACUNKrediti", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["OBRACUNKrediti"].Columns["IDOBRACUN"], this.Tables["OBRACUNKrediti"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_OBRACUNKrediti"].Nested = true;
            this.Relations.Add("ObracunRadnici_ObracunOlaksice", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["ObracunOlaksice"].Columns["IDOBRACUN"], this.Tables["ObracunOlaksice"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_ObracunOlaksice"].Nested = true;
            this.Relations.Add("ObracunRadnici_ObracunPorezi", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["ObracunPorezi"].Columns["IDOBRACUN"], this.Tables["ObracunPorezi"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_ObracunPorezi"].Nested = true;
            this.Relations.Add("ObracunRadnici_ObracunDoprinosi", new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"], this.Tables["ObracunRadnici"].Columns["IDRADNIK"] }, new DataColumn[] { this.Tables["ObracunDoprinosi"].Columns["IDOBRACUN"], this.Tables["ObracunDoprinosi"].Columns["IDRADNIK"] });
            this.Relations["ObracunRadnici_ObracunDoprinosi"].Nested = true;
            this.Relations.Add("OBRACUN_ObracunRadnici", new DataColumn[] { this.Tables["OBRACUN"].Columns["IDOBRACUN"] }, new DataColumn[] { this.Tables["ObracunRadnici"].Columns["IDOBRACUN"] });
            this.Relations["OBRACUN_ObracunRadnici"].Nested = true;
        }

        protected override void InitializeDerivedDataSet()
        {
            this.BeginInit();
            this.InitClassBase();
            this.EndInit();
        }

        internal void InitVars()
        {
            this.InitVars(true);
        }

        internal void InitVars(bool initTable)
        {
            this.tableOBRACUNOBRACUNLevel1ObracunIzuzece = (OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable) this.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"];
            this.tableOBRACUNOBRACUNLevel1ObracunKrizni = (OBRACUNOBRACUNLevel1ObracunKrizniDataTable) this.Tables["OBRACUNOBRACUNLevel1ObracunKrizni"];
            this.tableObracunElementi = (ObracunElementiDataTable) this.Tables["ObracunElementi"];
            this.tableOBRACUNObustave = (OBRACUNObustaveDataTable) this.Tables["OBRACUNObustave"];
            this.tableOBRACUNKrediti = (OBRACUNKreditiDataTable) this.Tables["OBRACUNKrediti"];
            this.tableObracunOlaksice = (ObracunOlaksiceDataTable) this.Tables["ObracunOlaksice"];
            this.tableObracunPorezi = (ObracunPoreziDataTable) this.Tables["ObracunPorezi"];
            this.tableObracunDoprinosi = (ObracunDoprinosiDataTable) this.Tables["ObracunDoprinosi"];
            this.tableObracunRadnici = (ObracunRadniciDataTable) this.Tables["ObracunRadnici"];
            this.tableOBRACUN = (OBRACUNDataTable) this.Tables["OBRACUN"];
            if (initTable)
            {
                if (this.tableOBRACUNOBRACUNLevel1ObracunIzuzece != null)
                {
                    this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.InitVars();
                }
                if (this.tableOBRACUNOBRACUNLevel1ObracunKrizni != null)
                {
                    this.tableOBRACUNOBRACUNLevel1ObracunKrizni.InitVars();
                }
                if (this.tableObracunElementi != null)
                {
                    this.tableObracunElementi.InitVars();
                }
                if (this.tableOBRACUNObustave != null)
                {
                    this.tableOBRACUNObustave.InitVars();
                }
                if (this.tableOBRACUNKrediti != null)
                {
                    this.tableOBRACUNKrediti.InitVars();
                }
                if (this.tableObracunOlaksice != null)
                {
                    this.tableObracunOlaksice.InitVars();
                }
                if (this.tableObracunPorezi != null)
                {
                    this.tableObracunPorezi.InitVars();
                }
                if (this.tableObracunDoprinosi != null)
                {
                    this.tableObracunDoprinosi.InitVars();
                }
                if (this.tableObracunRadnici != null)
                {
                    this.tableObracunRadnici.InitVars();
                }
                if (this.tableOBRACUN != null)
                {
                    this.tableOBRACUN.InitVars();
                }
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"] != null)
                {
                    this.Tables.Add(new OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable(dataSet.Tables["OBRACUNOBRACUNLevel1ObracunIzuzece"]));
                }
                if (dataSet.Tables["OBRACUNOBRACUNLevel1ObracunKrizni"] != null)
                {
                    this.Tables.Add(new OBRACUNOBRACUNLevel1ObracunKrizniDataTable(dataSet.Tables["OBRACUNOBRACUNLevel1ObracunKrizni"]));
                }
                if (dataSet.Tables["ObracunElementi"] != null)
                {
                    this.Tables.Add(new ObracunElementiDataTable(dataSet.Tables["ObracunElementi"]));
                }
                if (dataSet.Tables["OBRACUNObustave"] != null)
                {
                    this.Tables.Add(new OBRACUNObustaveDataTable(dataSet.Tables["OBRACUNObustave"]));
                }
                if (dataSet.Tables["OBRACUNKrediti"] != null)
                {
                    this.Tables.Add(new OBRACUNKreditiDataTable(dataSet.Tables["OBRACUNKrediti"]));
                }
                if (dataSet.Tables["ObracunOlaksice"] != null)
                {
                    this.Tables.Add(new ObracunOlaksiceDataTable(dataSet.Tables["ObracunOlaksice"]));
                }
                if (dataSet.Tables["ObracunPorezi"] != null)
                {
                    this.Tables.Add(new ObracunPoreziDataTable(dataSet.Tables["ObracunPorezi"]));
                }
                if (dataSet.Tables["ObracunDoprinosi"] != null)
                {
                    this.Tables.Add(new ObracunDoprinosiDataTable(dataSet.Tables["ObracunDoprinosi"]));
                }
                if (dataSet.Tables["ObracunRadnici"] != null)
                {
                    this.Tables.Add(new ObracunRadniciDataTable(dataSet.Tables["ObracunRadnici"]));
                }
                if (dataSet.Tables["OBRACUN"] != null)
                {
                    this.Tables.Add(new OBRACUNDataTable(dataSet.Tables["OBRACUN"]));
                }
                this.DataSetName = dataSet.DataSetName;
                this.Prefix = dataSet.Prefix;
                this.Namespace = dataSet.Namespace;
                this.Locale = dataSet.Locale;
                this.CaseSensitive = dataSet.CaseSensitive;
                this.EnforceConstraints = dataSet.EnforceConstraints;
                this.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ExtendedProperties.Clear();
                this.ReadXml(reader);
                this.InitVars();
            }
        }

        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        private bool ShouldSerializeOBRACUN()
        {
            return false;
        }

        private bool ShouldSerializeObracunDoprinosi()
        {
            return false;
        }

        private bool ShouldSerializeObracunElementi()
        {
            return false;
        }

        private bool ShouldSerializeOBRACUNKrediti()
        {
            return false;
        }

        private bool ShouldSerializeOBRACUNOBRACUNLevel1ObracunIzuzece()
        {
            return false;
        }

        private bool ShouldSerializeOBRACUNOBRACUNLevel1ObracunKrizni()
        {
            return false;
        }

        private bool ShouldSerializeOBRACUNObustave()
        {
            return false;
        }

        private bool ShouldSerializeObracunOlaksice()
        {
            return false;
        }

        private bool ShouldSerializeObracunPorezi()
        {
            return false;
        }

        private bool ShouldSerializeObracunRadnici()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DefaultValue(true)]
        public new bool EnforceConstraints
        {
            get
            {
                return base.EnforceConstraints;
            }
            set
            {
                base.EnforceConstraints = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OBRACUNDataTable OBRACUN
        {
            get
            {
                return this.tableOBRACUN;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObracunDoprinosiDataTable ObracunDoprinosi
        {
            get
            {
                return this.tableObracunDoprinosi;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObracunElementiDataTable ObracunElementi
        {
            get
            {
                return this.tableObracunElementi;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OBRACUNKreditiDataTable OBRACUNKrediti
        {
            get
            {
                return this.tableOBRACUNKrediti;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable OBRACUNOBRACUNLevel1ObracunIzuzece
        {
            get
            {
                return this.tableOBRACUNOBRACUNLevel1ObracunIzuzece;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OBRACUNOBRACUNLevel1ObracunKrizniDataTable OBRACUNOBRACUNLevel1ObracunKrizni
        {
            get
            {
                return this.tableOBRACUNOBRACUNLevel1ObracunKrizni;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OBRACUNObustaveDataTable OBRACUNObustave
        {
            get
            {
                return this.tableOBRACUNObustave;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObracunOlaksiceDataTable ObracunOlaksice
        {
            get
            {
                return this.tableObracunOlaksice;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObracunPoreziDataTable ObracunPorezi
        {
            get
            {
                return this.tableObracunPorezi;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObracunRadniciDataTable ObracunRadnici
        {
            get
            {
                return this.tableObracunRadnici;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable]
        public class OBRACUNDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUMISPLATE;
            private DataColumn columnDATUMOBRACUNASTAZA;
            private DataColumn columnGODINAISPLATE;
            private DataColumn columnGODINAOBRACUNA;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnMJESECISPLATE;
            private DataColumn columnMJESECNIFONDSATIOBRACUN;
            private DataColumn columnMJESECOBRACUNA;
            private DataColumn columnOBRACUNSKAOSNOVICA;
            private DataColumn columnOBRFIKSNIH;
            private DataColumn columnOBRKREDITNIH;
            private DataColumn columnOBRPOSTOTNIH;
            private DataColumn columnOSNOVNIOO;
            private DataColumn columnSVRHAOBRACUNA;
            private DataColumn columntjednifondsatiobracun;
            private DataColumn columnVRSTAOBRACUNA;
            private DataColumn columnZAKLJ;

            public event OBRACUNDataSet.OBRACUNRowChangeEventHandler OBRACUNRowChanged;

            public event OBRACUNDataSet.OBRACUNRowChangeEventHandler OBRACUNRowChanging;

            public event OBRACUNDataSet.OBRACUNRowChangeEventHandler OBRACUNRowDeleted;

            public event OBRACUNDataSet.OBRACUNRowChangeEventHandler OBRACUNRowDeleting;

            public OBRACUNDataTable()
            {
                this.TableName = "OBRACUN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OBRACUNDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected OBRACUNDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOBRACUNRow(OBRACUNDataSet.OBRACUNRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.OBRACUNRow AddOBRACUNRow(string iDOBRACUN, string vRSTAOBRACUNA, string mJESECOBRACUNA, string gODINAOBRACUNA, string mJESECISPLATE, string gODINAISPLATE, DateTime dATUMISPLATE, short tjednifondsatiobracun, short mJESECNIFONDSATIOBRACUN, decimal oSNOVNIOO, decimal oBRACUNSKAOSNOVICA, DateTime dATUMOBRACUNASTAZA, bool oBRPOSTOTNIH, bool oBRFIKSNIH, bool oBRKREDITNIH, bool zAKLJ, string sVRHAOBRACUNA)
            {
                OBRACUNDataSet.OBRACUNRow row = (OBRACUNDataSet.OBRACUNRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["VRSTAOBRACUNA"] = vRSTAOBRACUNA;
                row["MJESECOBRACUNA"] = mJESECOBRACUNA;
                row["GODINAOBRACUNA"] = gODINAOBRACUNA;
                row["MJESECISPLATE"] = mJESECISPLATE;
                row["GODINAISPLATE"] = gODINAISPLATE;
                row["DATUMISPLATE"] = dATUMISPLATE;
                row["tjednifondsatiobracun"] = tjednifondsatiobracun;
                row["MJESECNIFONDSATIOBRACUN"] = mJESECNIFONDSATIOBRACUN;
                row["OSNOVNIOO"] = oSNOVNIOO;
                row["OBRACUNSKAOSNOVICA"] = oBRACUNSKAOSNOVICA;
                row["DATUMOBRACUNASTAZA"] = dATUMOBRACUNASTAZA;
                row["OBRPOSTOTNIH"] = oBRPOSTOTNIH;
                row["OBRFIKSNIH"] = oBRFIKSNIH;
                row["OBRKREDITNIH"] = oBRKREDITNIH;
                row["ZAKLJ"] = zAKLJ;
                row["SVRHAOBRACUNA"] = sVRHAOBRACUNA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.OBRACUNDataTable table = (OBRACUNDataSet.OBRACUNDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.OBRACUNRow FindByIDOBRACUN(string iDOBRACUN)
            {
                return (OBRACUNDataSet.OBRACUNRow) this.Rows.Find(new object[] { iDOBRACUN });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.OBRACUNRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.Unique = true;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnVRSTAOBRACUNA = new DataColumn("VRSTAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnVRSTAOBRACUNA.AllowDBNull = false;
                this.columnVRSTAOBRACUNA.Caption = "VRSTAOBRACUNA";
                this.columnVRSTAOBRACUNA.MaxLength = 2;
                this.columnVRSTAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Description", "VRSTAOBRACUNA");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Length", "2");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRSTAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "VRSTAOBRACUNA");
                this.Columns.Add(this.columnVRSTAOBRACUNA);
                this.columnMJESECOBRACUNA = new DataColumn("MJESECOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnMJESECOBRACUNA.AllowDBNull = false;
                this.columnMJESECOBRACUNA.Caption = "Mjesec obraeuna";
                this.columnMJESECOBRACUNA.MaxLength = 2;
                this.columnMJESECOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Description", "Mjesec obraeuna");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Length", "2");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "MJESECOBRACUNA");
                this.Columns.Add(this.columnMJESECOBRACUNA);
                this.columnGODINAOBRACUNA = new DataColumn("GODINAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnGODINAOBRACUNA.AllowDBNull = false;
                this.columnGODINAOBRACUNA.Caption = "Godina obraeuna";
                this.columnGODINAOBRACUNA.MaxLength = 4;
                this.columnGODINAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Description", "Godina obraeuna");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Length", "4");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "GODINAOBRACUNA");
                this.Columns.Add(this.columnGODINAOBRACUNA);
                this.columnMJESECISPLATE = new DataColumn("MJESECISPLATE", typeof(string), "", MappingType.Element);
                this.columnMJESECISPLATE.AllowDBNull = false;
                this.columnMJESECISPLATE.Caption = "Mjesec isplate";
                this.columnMJESECISPLATE.MaxLength = 2;
                this.columnMJESECISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Description", "Mjesec isplate");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Length", "2");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECISPLATE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "MJESECISPLATE");
                this.Columns.Add(this.columnMJESECISPLATE);
                this.columnGODINAISPLATE = new DataColumn("GODINAISPLATE", typeof(string), "", MappingType.Element);
                this.columnGODINAISPLATE.AllowDBNull = false;
                this.columnGODINAISPLATE.Caption = "Godina isplate";
                this.columnGODINAISPLATE.MaxLength = 4;
                this.columnGODINAISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Description", "Godina isplate");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Length", "4");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAISPLATE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "GODINAISPLATE");
                this.Columns.Add(this.columnGODINAISPLATE);
                this.columnDATUMISPLATE = new DataColumn("DATUMISPLATE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMISPLATE.AllowDBNull = true;
                this.columnDATUMISPLATE.Caption = "Datum isplate";
                this.columnDATUMISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Description", "Datum isplate");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMISPLATE");
                this.Columns.Add(this.columnDATUMISPLATE);
                this.columntjednifondsatiobracun = new DataColumn("tjednifondsatiobracun", typeof(short), "", MappingType.Element);
                this.columntjednifondsatiobracun.AllowDBNull = false;
                this.columntjednifondsatiobracun.Caption = "Tjedni fond sati";
                this.columntjednifondsatiobracun.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("IsKey", "false");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("ReadOnly", "false");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("DeklaritType", "int");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Description", "Tjedni fond sati");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Length", "3");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Decimals", "0");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("IsInReader", "true");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columntjednifondsatiobracun.ExtendedProperties.Add("Deklarit.InternalName", "tjednifondsatiobracun");
                this.Columns.Add(this.columntjednifondsatiobracun);
                this.columnMJESECNIFONDSATIOBRACUN = new DataColumn("MJESECNIFONDSATIOBRACUN", typeof(short), "", MappingType.Element);
                this.columnMJESECNIFONDSATIOBRACUN.AllowDBNull = false;
                this.columnMJESECNIFONDSATIOBRACUN.Caption = "Mjeseeni fond sati";
                this.columnMJESECNIFONDSATIOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Description", "Mjeseeni fond sati");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Length", "3");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECNIFONDSATIOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "MJESECNIFONDSATIOBRACUN");
                this.Columns.Add(this.columnMJESECNIFONDSATIOBRACUN);
                this.columnOSNOVNIOO = new DataColumn("OSNOVNIOO", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVNIOO.AllowDBNull = false;
                this.columnOSNOVNIOO.Caption = "Osnovni osobni odbitak";
                this.columnOSNOVNIOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVNIOO.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVNIOO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVNIOO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Description", "Osnovni osobni odbitak");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVNIOO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVNIOO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVNIOO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVNIOO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVNIOO.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVNIOO");
                this.Columns.Add(this.columnOSNOVNIOO);
                this.columnOBRACUNSKAOSNOVICA = new DataColumn("OBRACUNSKAOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNSKAOSNOVICA.AllowDBNull = false;
                this.columnOBRACUNSKAOSNOVICA.Caption = "Obraeunska osnovica";
                this.columnOBRACUNSKAOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Description", "Obraeunska osnovica");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNSKAOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNSKAOSNOVICA");
                this.Columns.Add(this.columnOBRACUNSKAOSNOVICA);
                this.columnDATUMOBRACUNASTAZA = new DataColumn("DATUMOBRACUNASTAZA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMOBRACUNASTAZA.AllowDBNull = false;
                this.columnDATUMOBRACUNASTAZA.Caption = "DATUMOBRACUNASTAZA";
                this.columnDATUMOBRACUNASTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Description", "Datum obračuna staža");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMOBRACUNASTAZA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMOBRACUNASTAZA");
                this.Columns.Add(this.columnDATUMOBRACUNASTAZA);
                this.columnOBRPOSTOTNIH = new DataColumn("OBRPOSTOTNIH", typeof(bool), "", MappingType.Element);
                this.columnOBRPOSTOTNIH.AllowDBNull = false;
                this.columnOBRPOSTOTNIH.Caption = "OBRPOSTOTNIH";
                this.columnOBRPOSTOTNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Description", "Obračun postotnih");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Length", "1");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRPOSTOTNIH.ExtendedProperties.Add("Deklarit.InternalName", "OBRPOSTOTNIH");
                this.Columns.Add(this.columnOBRPOSTOTNIH);
                this.columnOBRFIKSNIH = new DataColumn("OBRFIKSNIH", typeof(bool), "", MappingType.Element);
                this.columnOBRFIKSNIH.AllowDBNull = false;
                this.columnOBRFIKSNIH.Caption = "OBRFIKSNIH";
                this.columnOBRFIKSNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Description", "Obračun fiksnih");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Length", "1");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRFIKSNIH.ExtendedProperties.Add("Deklarit.InternalName", "OBRFIKSNIH");
                this.Columns.Add(this.columnOBRFIKSNIH);
                this.columnOBRKREDITNIH = new DataColumn("OBRKREDITNIH", typeof(bool), "", MappingType.Element);
                this.columnOBRKREDITNIH.AllowDBNull = false;
                this.columnOBRKREDITNIH.Caption = "OBRKREDITNIH";
                this.columnOBRKREDITNIH.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Description", "Obračun kreditnih");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Length", "1");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("IsInReader", "true");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRKREDITNIH.ExtendedProperties.Add("Deklarit.InternalName", "OBRKREDITNIH");
                this.Columns.Add(this.columnOBRKREDITNIH);
                this.columnZAKLJ = new DataColumn("ZAKLJ", typeof(bool), "", MappingType.Element);
                this.columnZAKLJ.AllowDBNull = false;
                this.columnZAKLJ.Caption = "ZAKLJ";
                this.columnZAKLJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZAKLJ.ExtendedProperties.Add("IsKey", "false");
                this.columnZAKLJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZAKLJ.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZAKLJ.ExtendedProperties.Add("Description", "Zaključano");
                this.columnZAKLJ.ExtendedProperties.Add("Length", "1");
                this.columnZAKLJ.ExtendedProperties.Add("Decimals", "0");
                this.columnZAKLJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZAKLJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZAKLJ.ExtendedProperties.Add("Deklarit.InternalName", "ZAKLJ");
                this.Columns.Add(this.columnZAKLJ);
                this.columnSVRHAOBRACUNA = new DataColumn("SVRHAOBRACUNA", typeof(string), "", MappingType.Element);
                this.columnSVRHAOBRACUNA.AllowDBNull = true;
                this.columnSVRHAOBRACUNA.Caption = "SVRHAOBRACUNA";
                this.columnSVRHAOBRACUNA.MaxLength = 100;
                this.columnSVRHAOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Description", "Svrha obračuna");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Length", "100");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSVRHAOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "SVRHAOBRACUNA");
                this.Columns.Add(this.columnSVRHAOBRACUNA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OBRACUN");
                this.ExtendedProperties.Add("Description", "Obraeun");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnVRSTAOBRACUNA = this.Columns["VRSTAOBRACUNA"];
                this.columnMJESECOBRACUNA = this.Columns["MJESECOBRACUNA"];
                this.columnGODINAOBRACUNA = this.Columns["GODINAOBRACUNA"];
                this.columnMJESECISPLATE = this.Columns["MJESECISPLATE"];
                this.columnGODINAISPLATE = this.Columns["GODINAISPLATE"];
                this.columnDATUMISPLATE = this.Columns["DATUMISPLATE"];
                this.columntjednifondsatiobracun = this.Columns["tjednifondsatiobracun"];
                this.columnMJESECNIFONDSATIOBRACUN = this.Columns["MJESECNIFONDSATIOBRACUN"];
                this.columnOSNOVNIOO = this.Columns["OSNOVNIOO"];
                this.columnOBRACUNSKAOSNOVICA = this.Columns["OBRACUNSKAOSNOVICA"];
                this.columnDATUMOBRACUNASTAZA = this.Columns["DATUMOBRACUNASTAZA"];
                this.columnOBRPOSTOTNIH = this.Columns["OBRPOSTOTNIH"];
                this.columnOBRFIKSNIH = this.Columns["OBRFIKSNIH"];
                this.columnOBRKREDITNIH = this.Columns["OBRKREDITNIH"];
                this.columnZAKLJ = this.Columns["ZAKLJ"];
                this.columnSVRHAOBRACUNA = this.Columns["SVRHAOBRACUNA"];
            }

            public OBRACUNDataSet.OBRACUNRow NewOBRACUNRow()
            {
                return (OBRACUNDataSet.OBRACUNRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.OBRACUNRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OBRACUNRowChanged != null)
                {
                    OBRACUNDataSet.OBRACUNRowChangeEventHandler oBRACUNRowChangedEvent = this.OBRACUNRowChanged;
                    if (oBRACUNRowChangedEvent != null)
                    {
                        oBRACUNRowChangedEvent(this, new OBRACUNDataSet.OBRACUNRowChangeEvent((OBRACUNDataSet.OBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OBRACUNRowChanging != null)
                {
                    OBRACUNDataSet.OBRACUNRowChangeEventHandler oBRACUNRowChangingEvent = this.OBRACUNRowChanging;
                    if (oBRACUNRowChangingEvent != null)
                    {
                        oBRACUNRowChangingEvent(this, new OBRACUNDataSet.OBRACUNRowChangeEvent((OBRACUNDataSet.OBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OBRACUNRowDeleted != null)
                {
                    OBRACUNDataSet.OBRACUNRowChangeEventHandler oBRACUNRowDeletedEvent = this.OBRACUNRowDeleted;
                    if (oBRACUNRowDeletedEvent != null)
                    {
                        oBRACUNRowDeletedEvent(this, new OBRACUNDataSet.OBRACUNRowChangeEvent((OBRACUNDataSet.OBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OBRACUNRowDeleting != null)
                {
                    OBRACUNDataSet.OBRACUNRowChangeEventHandler oBRACUNRowDeletingEvent = this.OBRACUNRowDeleting;
                    if (oBRACUNRowDeletingEvent != null)
                    {
                        oBRACUNRowDeletingEvent(this, new OBRACUNDataSet.OBRACUNRowChangeEvent((OBRACUNDataSet.OBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOBRACUNRow(OBRACUNDataSet.OBRACUNRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn DATUMISPLATEColumn
            {
                get
                {
                    return this.columnDATUMISPLATE;
                }
            }

            public DataColumn DATUMOBRACUNASTAZAColumn
            {
                get
                {
                    return this.columnDATUMOBRACUNASTAZA;
                }
            }

            public DataColumn GODINAISPLATEColumn
            {
                get
                {
                    return this.columnGODINAISPLATE;
                }
            }

            public DataColumn GODINAOBRACUNAColumn
            {
                get
                {
                    return this.columnGODINAOBRACUNA;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public OBRACUNDataSet.OBRACUNRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.OBRACUNRow) this.Rows[index];
                }
            }

            public DataColumn MJESECISPLATEColumn
            {
                get
                {
                    return this.columnMJESECISPLATE;
                }
            }

            public DataColumn MJESECNIFONDSATIOBRACUNColumn
            {
                get
                {
                    return this.columnMJESECNIFONDSATIOBRACUN;
                }
            }

            public DataColumn MJESECOBRACUNAColumn
            {
                get
                {
                    return this.columnMJESECOBRACUNA;
                }
            }

            public DataColumn OBRACUNSKAOSNOVICAColumn
            {
                get
                {
                    return this.columnOBRACUNSKAOSNOVICA;
                }
            }

            public DataColumn OBRFIKSNIHColumn
            {
                get
                {
                    return this.columnOBRFIKSNIH;
                }
            }

            public DataColumn OBRKREDITNIHColumn
            {
                get
                {
                    return this.columnOBRKREDITNIH;
                }
            }

            public DataColumn OBRPOSTOTNIHColumn
            {
                get
                {
                    return this.columnOBRPOSTOTNIH;
                }
            }

            public DataColumn OSNOVNIOOColumn
            {
                get
                {
                    return this.columnOSNOVNIOO;
                }
            }

            public DataColumn SVRHAOBRACUNAColumn
            {
                get
                {
                    return this.columnSVRHAOBRACUNA;
                }
            }

            public DataColumn tjednifondsatiobracunColumn
            {
                get
                {
                    return this.columntjednifondsatiobracun;
                }
            }

            public DataColumn VRSTAOBRACUNAColumn
            {
                get
                {
                    return this.columnVRSTAOBRACUNA;
                }
            }

            public DataColumn ZAKLJColumn
            {
                get
                {
                    return this.columnZAKLJ;
                }
            }
        }

        [Serializable]
        public class ObracunDoprinosiDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDOPRINOS;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIDVRSTADOPRINOS;
            private DataColumn columnMAXDOPRINOS;
            private DataColumn columnMINDOPRINOS;
            private DataColumn columnMODOPRINOS;
            private DataColumn columnMZDOPRINOS;
            private DataColumn columnNAZIVDOPRINOS;
            private DataColumn columnNAZIVVRSTADOPRINOS;
            private DataColumn columnOBRACUNATIDOPRINOS;
            private DataColumn columnOPISPLACANJADOPRINOS;
            private DataColumn columnOSNOVICADOPRINOS;
            private DataColumn columnPODOPRINOS;
            private DataColumn columnPRIMATELJDOPRINOS1;
            private DataColumn columnPRIMATELJDOPRINOS2;
            private DataColumn columnPZDOPRINOS;
            private DataColumn columnSIFRAOPISAPLACANJADOPRINOS;
            private DataColumn columnSTOPA;
            private DataColumn columnVBDIDOPRINOS;
            private DataColumn columnZRNDOPRINOS;

            public event OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler ObracunDoprinosiRowChanged;

            public event OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler ObracunDoprinosiRowChanging;

            public event OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler ObracunDoprinosiRowDeleted;

            public event OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler ObracunDoprinosiRowDeleting;

            public ObracunDoprinosiDataTable()
            {
                this.TableName = "ObracunDoprinosi";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ObracunDoprinosiDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected ObracunDoprinosiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddObracunDoprinosiRow(OBRACUNDataSet.ObracunDoprinosiRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.ObracunDoprinosiRow AddObracunDoprinosiRow(string iDOBRACUN, int iDRADNIK, int iDDOPRINOS, decimal oBRACUNATIDOPRINOS, decimal oSNOVICADOPRINOS)
            {
                OBRACUNDataSet.ObracunDoprinosiRow row = (OBRACUNDataSet.ObracunDoprinosiRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["IDDOPRINOS"] = iDDOPRINOS;
                row["OBRACUNATIDOPRINOS"] = oBRACUNATIDOPRINOS;
                row["OSNOVICADOPRINOS"] = oSNOVICADOPRINOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.ObracunDoprinosiDataTable table = (OBRACUNDataSet.ObracunDoprinosiDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.ObracunDoprinosiRow FindByIDOBRACUNIDRADNIKIDDOPRINOS(string iDOBRACUN, int iDRADNIK, int iDDOPRINOS)
            {
                return (OBRACUNDataSet.ObracunDoprinosiRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDDOPRINOS });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.ObracunDoprinosiRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDDOPRINOS = new DataColumn("IDDOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDDOPRINOS.AllowDBNull = false;
                this.columnIDDOPRINOS.Caption = "Šifra doprinosa";
                this.columnIDDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("IsKey", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Description", "Šifra doprinosa");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Length", "8");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDDOPRINOS");
                this.Columns.Add(this.columnIDDOPRINOS);
                this.columnVBDIDOPRINOS = new DataColumn("VBDIDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnVBDIDOPRINOS.AllowDBNull = false;
                this.columnVBDIDOPRINOS.Caption = "VBDI za doprinos";
                this.columnVBDIDOPRINOS.MaxLength = 7;
                this.columnVBDIDOPRINOS.DefaultValue = "";
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Description", "VBDI za doprinos");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Length", "7");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "VBDIDOPRINOS");
                this.Columns.Add(this.columnVBDIDOPRINOS);
                this.columnZRNDOPRINOS = new DataColumn("ZRNDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnZRNDOPRINOS.AllowDBNull = false;
                this.columnZRNDOPRINOS.Caption = "Žiro račun za doprinos";
                this.columnZRNDOPRINOS.MaxLength = 10;
                this.columnZRNDOPRINOS.DefaultValue = "";
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Description", "Žiro račun za doprinos");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Length", "10");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "ZRNDOPRINOS");
                this.Columns.Add(this.columnZRNDOPRINOS);
                this.columnNAZIVDOPRINOS = new DataColumn("NAZIVDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVDOPRINOS.AllowDBNull = false;
                this.columnNAZIVDOPRINOS.Caption = "Naziv doprinosa";
                this.columnNAZIVDOPRINOS.MaxLength = 50;
                this.columnNAZIVDOPRINOS.DefaultValue = "";
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Description", "Naziv doprinosa");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDOPRINOS");
                this.Columns.Add(this.columnNAZIVDOPRINOS);
                this.columnIDVRSTADOPRINOS = new DataColumn("IDVRSTADOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDVRSTADOPRINOS.AllowDBNull = false;
                this.columnIDVRSTADOPRINOS.Caption = "Šifra vrste doprinosa";
                this.columnIDVRSTADOPRINOS.DefaultValue = 0;
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Description", "Šifra vrste doprinosa");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Length", "5");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTADOPRINOS");
                this.Columns.Add(this.columnIDVRSTADOPRINOS);
                this.columnNAZIVVRSTADOPRINOS = new DataColumn("NAZIVVRSTADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTADOPRINOS.AllowDBNull = false;
                this.columnNAZIVVRSTADOPRINOS.Caption = "Naziv vrste doprinosa";
                this.columnNAZIVVRSTADOPRINOS.MaxLength = 50;
                this.columnNAZIVVRSTADOPRINOS.DefaultValue = "";
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Description", "Naziv vrste doprinosa");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTADOPRINOS");
                this.Columns.Add(this.columnNAZIVVRSTADOPRINOS);
                this.columnSTOPA = new DataColumn("STOPA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPA.AllowDBNull = false;
                this.columnSTOPA.Caption = "STOPA";
                this.columnSTOPA.DefaultValue = 0;
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPA.ExtendedProperties.Add("Description", "STOPA");
                this.columnSTOPA.ExtendedProperties.Add("Length", "5");
                this.columnSTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTOPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "STOPA");
                this.Columns.Add(this.columnSTOPA);
                this.columnMODOPRINOS = new DataColumn("MODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMODOPRINOS.AllowDBNull = false;
                this.columnMODOPRINOS.Caption = "Model odobrenja doprinosa";
                this.columnMODOPRINOS.MaxLength = 2;
                this.columnMODOPRINOS.DefaultValue = "";
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMODOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMODOPRINOS.ExtendedProperties.Add("Description", "Model odobrenja doprinosa");
                this.columnMODOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnMODOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnMODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MODOPRINOS");
                this.Columns.Add(this.columnMODOPRINOS);
                this.columnPODOPRINOS = new DataColumn("PODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnPODOPRINOS.AllowDBNull = false;
                this.columnPODOPRINOS.Caption = "Poziv odobrenja doprinosa";
                this.columnPODOPRINOS.MaxLength = 0x16;
                this.columnPODOPRINOS.DefaultValue = "";
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPODOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPODOPRINOS.ExtendedProperties.Add("Description", "Poziv odobrenja doprinosa");
                this.columnPODOPRINOS.ExtendedProperties.Add("Length", "22");
                this.columnPODOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnPODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "PODOPRINOS");
                this.Columns.Add(this.columnPODOPRINOS);
                this.columnMZDOPRINOS = new DataColumn("MZDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMZDOPRINOS.AllowDBNull = true;
                this.columnMZDOPRINOS.Caption = "Model zaduženja doprinosa";
                this.columnMZDOPRINOS.MaxLength = 2;
                this.columnMZDOPRINOS.DefaultValue = "";
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Description", "Model zaduženja doprinosa");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnMZDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MZDOPRINOS");
                this.Columns.Add(this.columnMZDOPRINOS);
                this.columnPZDOPRINOS = new DataColumn("PZDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnPZDOPRINOS.AllowDBNull = true;
                this.columnPZDOPRINOS.Caption = "Poziv zaduženja doprinosa";
                this.columnPZDOPRINOS.MaxLength = 0x16;
                this.columnPZDOPRINOS.DefaultValue = "";
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Description", "Poziv zaduženja doprinosa");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Length", "22");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnPZDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "PZDOPRINOS");
                this.Columns.Add(this.columnPZDOPRINOS);
                this.columnPRIMATELJDOPRINOS1 = new DataColumn("PRIMATELJDOPRINOS1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJDOPRINOS1.AllowDBNull = false;
                this.columnPRIMATELJDOPRINOS1.Caption = "Primatelj doprinosa";
                this.columnPRIMATELJDOPRINOS1.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS1.DefaultValue = "";
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Description", "Primatelj doprinosa");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJDOPRINOS1");
                this.Columns.Add(this.columnPRIMATELJDOPRINOS1);
                this.columnPRIMATELJDOPRINOS2 = new DataColumn("PRIMATELJDOPRINOS2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJDOPRINOS2.AllowDBNull = true;
                this.columnPRIMATELJDOPRINOS2.Caption = "Primatelj doprinosa (2)";
                this.columnPRIMATELJDOPRINOS2.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS2.DefaultValue = "";
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Description", "Primatelj doprinosa (2)");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJDOPRINOS2");
                this.Columns.Add(this.columnPRIMATELJDOPRINOS2);
                this.columnSIFRAOPISAPLACANJADOPRINOS = new DataColumn("SIFRAOPISAPLACANJADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJADOPRINOS.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJADOPRINOS.Caption = "Šifra opisa plaćanja doprinosa";
                this.columnSIFRAOPISAPLACANJADOPRINOS.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJADOPRINOS.DefaultValue = "";
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Description", "Šifra opisa plaćanja doprinosa");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJADOPRINOS");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJADOPRINOS);
                this.columnOPISPLACANJADOPRINOS = new DataColumn("OPISPLACANJADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJADOPRINOS.AllowDBNull = false;
                this.columnOPISPLACANJADOPRINOS.Caption = "Opis plaćanja doprinosa";
                this.columnOPISPLACANJADOPRINOS.MaxLength = 0x24;
                this.columnOPISPLACANJADOPRINOS.DefaultValue = "";
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Description", "Opis plaćanja doprinosa");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJADOPRINOS");
                this.Columns.Add(this.columnOPISPLACANJADOPRINOS);
                this.columnOBRACUNATIDOPRINOS = new DataColumn("OBRACUNATIDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATIDOPRINOS.AllowDBNull = false;
                this.columnOBRACUNATIDOPRINOS.Caption = "OBRACUNATIDOPRINOS";
                this.columnOBRACUNATIDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Description", "OBRACUNATIDOPRINOS");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATIDOPRINOS");
                this.Columns.Add(this.columnOBRACUNATIDOPRINOS);
                this.columnOSNOVICADOPRINOS = new DataColumn("OSNOVICADOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICADOPRINOS.AllowDBNull = false;
                this.columnOSNOVICADOPRINOS.Caption = "OSNOVICADOPRINOS";
                this.columnOSNOVICADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Description", "OSNOVICADOPRINOS");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICADOPRINOS");
                this.Columns.Add(this.columnOSNOVICADOPRINOS);
                this.columnMINDOPRINOS = new DataColumn("MINDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnMINDOPRINOS.AllowDBNull = true;
                this.columnMINDOPRINOS.Caption = "Minimalna osnovica za obračun doprinosa";
                this.columnMINDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMINDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Description", "Minimalna osnovica za obračun doprinosa");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnMINDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMINDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMINDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MINDOPRINOS");
                this.Columns.Add(this.columnMINDOPRINOS);
                this.columnMAXDOPRINOS = new DataColumn("MAXDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnMAXDOPRINOS.AllowDBNull = true;
                this.columnMAXDOPRINOS.Caption = "Maksimalna osnovica za obračun doprinosa";
                this.columnMAXDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Description", "Maksimalna osnovica za obračun doprinosa");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMAXDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MAXDOPRINOS");
                this.Columns.Add(this.columnMAXDOPRINOS);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDDOPRINOS };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "OBRACUNLevel3");
                this.ExtendedProperties.Add("Description", "OBRACUNLevel3");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDDOPRINOS = this.Columns["IDDOPRINOS"];
                this.columnVBDIDOPRINOS = this.Columns["VBDIDOPRINOS"];
                this.columnZRNDOPRINOS = this.Columns["ZRNDOPRINOS"];
                this.columnNAZIVDOPRINOS = this.Columns["NAZIVDOPRINOS"];
                this.columnIDVRSTADOPRINOS = this.Columns["IDVRSTADOPRINOS"];
                this.columnNAZIVVRSTADOPRINOS = this.Columns["NAZIVVRSTADOPRINOS"];
                this.columnSTOPA = this.Columns["STOPA"];
                this.columnMODOPRINOS = this.Columns["MODOPRINOS"];
                this.columnPODOPRINOS = this.Columns["PODOPRINOS"];
                this.columnMZDOPRINOS = this.Columns["MZDOPRINOS"];
                this.columnPZDOPRINOS = this.Columns["PZDOPRINOS"];
                this.columnPRIMATELJDOPRINOS1 = this.Columns["PRIMATELJDOPRINOS1"];
                this.columnPRIMATELJDOPRINOS2 = this.Columns["PRIMATELJDOPRINOS2"];
                this.columnSIFRAOPISAPLACANJADOPRINOS = this.Columns["SIFRAOPISAPLACANJADOPRINOS"];
                this.columnOPISPLACANJADOPRINOS = this.Columns["OPISPLACANJADOPRINOS"];
                this.columnOBRACUNATIDOPRINOS = this.Columns["OBRACUNATIDOPRINOS"];
                this.columnOSNOVICADOPRINOS = this.Columns["OSNOVICADOPRINOS"];
                this.columnMINDOPRINOS = this.Columns["MINDOPRINOS"];
                this.columnMAXDOPRINOS = this.Columns["MAXDOPRINOS"];
            }

            public OBRACUNDataSet.ObracunDoprinosiRow NewObracunDoprinosiRow()
            {
                return (OBRACUNDataSet.ObracunDoprinosiRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.ObracunDoprinosiRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ObracunDoprinosiRowChanged != null)
                {
                    OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler obracunDoprinosiRowChangedEvent = this.ObracunDoprinosiRowChanged;
                    if (obracunDoprinosiRowChangedEvent != null)
                    {
                        obracunDoprinosiRowChangedEvent(this, new OBRACUNDataSet.ObracunDoprinosiRowChangeEvent((OBRACUNDataSet.ObracunDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ObracunDoprinosiRowChanging != null)
                {
                    OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler obracunDoprinosiRowChangingEvent = this.ObracunDoprinosiRowChanging;
                    if (obracunDoprinosiRowChangingEvent != null)
                    {
                        obracunDoprinosiRowChangingEvent(this, new OBRACUNDataSet.ObracunDoprinosiRowChangeEvent((OBRACUNDataSet.ObracunDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_ObracunDoprinosi", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.ObracunDoprinosiRowDeleted != null)
                {
                    OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler obracunDoprinosiRowDeletedEvent = this.ObracunDoprinosiRowDeleted;
                    if (obracunDoprinosiRowDeletedEvent != null)
                    {
                        obracunDoprinosiRowDeletedEvent(this, new OBRACUNDataSet.ObracunDoprinosiRowChangeEvent((OBRACUNDataSet.ObracunDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ObracunDoprinosiRowDeleting != null)
                {
                    OBRACUNDataSet.ObracunDoprinosiRowChangeEventHandler obracunDoprinosiRowDeletingEvent = this.ObracunDoprinosiRowDeleting;
                    if (obracunDoprinosiRowDeletingEvent != null)
                    {
                        obracunDoprinosiRowDeletingEvent(this, new OBRACUNDataSet.ObracunDoprinosiRowChangeEvent((OBRACUNDataSet.ObracunDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveObracunDoprinosiRow(OBRACUNDataSet.ObracunDoprinosiRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDDOPRINOSColumn
            {
                get
                {
                    return this.columnIDDOPRINOS;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IDVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnIDVRSTADOPRINOS;
                }
            }

            public OBRACUNDataSet.ObracunDoprinosiRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.ObracunDoprinosiRow) this.Rows[index];
                }
            }

            public DataColumn MAXDOPRINOSColumn
            {
                get
                {
                    return this.columnMAXDOPRINOS;
                }
            }

            public DataColumn MINDOPRINOSColumn
            {
                get
                {
                    return this.columnMINDOPRINOS;
                }
            }

            public DataColumn MODOPRINOSColumn
            {
                get
                {
                    return this.columnMODOPRINOS;
                }
            }

            public DataColumn MZDOPRINOSColumn
            {
                get
                {
                    return this.columnMZDOPRINOS;
                }
            }

            public DataColumn NAZIVDOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVDOPRINOS;
                }
            }

            public DataColumn NAZIVVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnNAZIVVRSTADOPRINOS;
                }
            }

            public DataColumn OBRACUNATIDOPRINOSColumn
            {
                get
                {
                    return this.columnOBRACUNATIDOPRINOS;
                }
            }

            public DataColumn OPISPLACANJADOPRINOSColumn
            {
                get
                {
                    return this.columnOPISPLACANJADOPRINOS;
                }
            }

            public DataColumn OSNOVICADOPRINOSColumn
            {
                get
                {
                    return this.columnOSNOVICADOPRINOS;
                }
            }

            public DataColumn PODOPRINOSColumn
            {
                get
                {
                    return this.columnPODOPRINOS;
                }
            }

            public DataColumn PRIMATELJDOPRINOS1Column
            {
                get
                {
                    return this.columnPRIMATELJDOPRINOS1;
                }
            }

            public DataColumn PRIMATELJDOPRINOS2Column
            {
                get
                {
                    return this.columnPRIMATELJDOPRINOS2;
                }
            }

            public DataColumn PZDOPRINOSColumn
            {
                get
                {
                    return this.columnPZDOPRINOS;
                }
            }

            public DataColumn SIFRAOPISAPLACANJADOPRINOSColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJADOPRINOS;
                }
            }

            public DataColumn STOPAColumn
            {
                get
                {
                    return this.columnSTOPA;
                }
            }

            public DataColumn VBDIDOPRINOSColumn
            {
                get
                {
                    return this.columnVBDIDOPRINOS;
                }
            }

            public DataColumn ZRNDOPRINOSColumn
            {
                get
                {
                    return this.columnZRNDOPRINOS;
                }
            }
        }

        public class ObracunDoprinosiRow : DataRow
        {
            private OBRACUNDataSet.ObracunDoprinosiDataTable tableObracunDoprinosi;

            internal ObracunDoprinosiRow(DataRowBuilder rb) : base(rb)
            {
                this.tableObracunDoprinosi = (OBRACUNDataSet.ObracunDoprinosiDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_ObracunDoprinosi");
            }

            public bool IsIDDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.IDDOPRINOSColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.IDOBRACUNColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.IDRADNIKColumn);
            }

            public bool IsIDVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.IDVRSTADOPRINOSColumn);
            }

            public bool IsMAXDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.MAXDOPRINOSColumn);
            }

            public bool IsMINDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.MINDOPRINOSColumn);
            }

            public bool IsMODOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.MODOPRINOSColumn);
            }

            public bool IsMZDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.MZDOPRINOSColumn);
            }

            public bool IsNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.NAZIVDOPRINOSColumn);
            }

            public bool IsNAZIVVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.NAZIVVRSTADOPRINOSColumn);
            }

            public bool IsOBRACUNATIDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.OBRACUNATIDOPRINOSColumn);
            }

            public bool IsOPISPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.OPISPLACANJADOPRINOSColumn);
            }

            public bool IsOSNOVICADOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.OSNOVICADOPRINOSColumn);
            }

            public bool IsPODOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.PODOPRINOSColumn);
            }

            public bool IsPRIMATELJDOPRINOS1Null()
            {
                return this.IsNull(this.tableObracunDoprinosi.PRIMATELJDOPRINOS1Column);
            }

            public bool IsPRIMATELJDOPRINOS2Null()
            {
                return this.IsNull(this.tableObracunDoprinosi.PRIMATELJDOPRINOS2Column);
            }

            public bool IsPZDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.PZDOPRINOSColumn);
            }

            public bool IsSIFRAOPISAPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn);
            }

            public bool IsSTOPANull()
            {
                return this.IsNull(this.tableObracunDoprinosi.STOPAColumn);
            }

            public bool IsVBDIDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.VBDIDOPRINOSColumn);
            }

            public bool IsZRNDOPRINOSNull()
            {
                return this.IsNull(this.tableObracunDoprinosi.ZRNDOPRINOSColumn);
            }

            public void SetIDVRSTADOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.IDVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMAXDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.MAXDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMINDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.MINDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.MODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.MZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.NAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTADOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.NAZIVVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATIDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.OBRACUNATIDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJADOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.OPISPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICADOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.OSNOVICADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPODOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.PODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS1Null()
            {
                this[this.tableObracunDoprinosi.PRIMATELJDOPRINOS1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS2Null()
            {
                this[this.tableObracunDoprinosi.PRIMATELJDOPRINOS2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.PZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJADOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPANull()
            {
                this[this.tableObracunDoprinosi.STOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.VBDIDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNDOPRINOSNull()
            {
                this[this.tableObracunDoprinosi.ZRNDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunDoprinosi.IDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tableObracunDoprinosi.IDDOPRINOSColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableObracunDoprinosi.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableObracunDoprinosi.IDOBRACUNColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunDoprinosi.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableObracunDoprinosi.IDRADNIKColumn] = value;
                }
            }

            public int IDVRSTADOPRINOS
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunDoprinosi.IDVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunDoprinosi.IDVRSTADOPRINOSColumn] = value;
                }
            }

            public decimal MAXDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunDoprinosi.MAXDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunDoprinosi.MAXDOPRINOSColumn] = value;
                }
            }

            public decimal MINDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunDoprinosi.MINDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunDoprinosi.MINDOPRINOSColumn] = value;
                }
            }

            public string MODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.MODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.MODOPRINOSColumn] = value;
                }
            }

            public string MZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.MZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.MZDOPRINOSColumn] = value;
                }
            }

            public string NAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.NAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.NAZIVDOPRINOSColumn] = value;
                }
            }

            public string NAZIVVRSTADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.NAZIVVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.NAZIVVRSTADOPRINOSColumn] = value;
                }
            }

            public decimal OBRACUNATIDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunDoprinosi.OBRACUNATIDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunDoprinosi.OBRACUNATIDOPRINOSColumn] = value;
                }
            }

            public string OPISPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.OPISPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.OPISPLACANJADOPRINOSColumn] = value;
                }
            }

            public decimal OSNOVICADOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunDoprinosi.OSNOVICADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunDoprinosi.OSNOVICADOPRINOSColumn] = value;
                }
            }

            public string PODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.PODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.PODOPRINOSColumn] = value;
                }
            }

            public string PRIMATELJDOPRINOS1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.PRIMATELJDOPRINOS1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.PRIMATELJDOPRINOS1Column] = value;
                }
            }

            public string PRIMATELJDOPRINOS2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.PRIMATELJDOPRINOS2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.PRIMATELJDOPRINOS2Column] = value;
                }
            }

            public string PZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.PZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.PZDOPRINOSColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn] = value;
                }
            }

            public decimal STOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunDoprinosi.STOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunDoprinosi.STOPAColumn] = value;
                }
            }

            public string VBDIDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.VBDIDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.VBDIDOPRINOSColumn] = value;
                }
            }

            public string ZRNDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunDoprinosi.ZRNDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunDoprinosi.ZRNDOPRINOSColumn] = value;
                }
            }
        }

        public class ObracunDoprinosiRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.ObracunDoprinosiRow eventRow;

            public ObracunDoprinosiRowChangeEvent(OBRACUNDataSet.ObracunDoprinosiRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.ObracunDoprinosiRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ObracunDoprinosiRowChangeEventHandler(object sender, OBRACUNDataSet.ObracunDoprinosiRowChangeEvent e);

        [Serializable]
        public class ObracunElementiDataTable : DataTable, IEnumerable
        {
            private DataColumn columnELEMENTRAZDOBLJEDO;
            private DataColumn columnELEMENTRAZDOBLJEOD;
            private DataColumn columnIDELEMENT;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDOSNOVAOSIGURANJA;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIDVRSTAELEMENTA;
            private DataColumn columnNAZIVELEMENT;
            private DataColumn columnNAZIVOSNOVAOSIGURANJA;
            private DataColumn columnNAZIVVRSTAELEMENT;
            private DataColumn columnOBRIZNOS;
            private DataColumn columnOBRPOSTOTAK;
            private DataColumn columnOBRSATI;
            private DataColumn columnOBRSATNICA;
            private DataColumn columnRAZDOBLJESESMIJEPREKLAPATI;
            private DataColumn columnZBRAJASATEUFONDSATI;

            public event OBRACUNDataSet.ObracunElementiRowChangeEventHandler ObracunElementiRowChanged;

            public event OBRACUNDataSet.ObracunElementiRowChangeEventHandler ObracunElementiRowChanging;

            public event OBRACUNDataSet.ObracunElementiRowChangeEventHandler ObracunElementiRowDeleted;

            public event OBRACUNDataSet.ObracunElementiRowChangeEventHandler ObracunElementiRowDeleting;

            public ObracunElementiDataTable()
            {
                this.TableName = "ObracunElementi";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ObracunElementiDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected ObracunElementiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddObracunElementiRow(OBRACUNDataSet.ObracunElementiRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.ObracunElementiRow AddObracunElementiRow(string iDOBRACUN, int iDRADNIK, int iDELEMENT, DateTime eLEMENTRAZDOBLJEOD, DateTime eLEMENTRAZDOBLJEDO, decimal oBRSATI, decimal oBRSATNICA, decimal oBRIZNOS, decimal oBRPOSTOTAK)
            {
                OBRACUNDataSet.ObracunElementiRow row = (OBRACUNDataSet.ObracunElementiRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["IDELEMENT"] = iDELEMENT;
                row["ELEMENTRAZDOBLJEOD"] = eLEMENTRAZDOBLJEOD;
                row["ELEMENTRAZDOBLJEDO"] = eLEMENTRAZDOBLJEDO;
                row["OBRSATI"] = oBRSATI;
                row["OBRSATNICA"] = oBRSATNICA;
                row["OBRIZNOS"] = oBRIZNOS;
                row["OBRPOSTOTAK"] = oBRPOSTOTAK;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.ObracunElementiDataTable table = (OBRACUNDataSet.ObracunElementiDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.ObracunElementiRow FindByIDOBRACUNIDRADNIKIDELEMENTELEMENTRAZDOBLJEODELEMENTRAZDOBLJEDO(string iDOBRACUN, int iDRADNIK, int iDELEMENT, DateTime eLEMENTRAZDOBLJEOD, DateTime eLEMENTRAZDOBLJEDO)
            {
                return (OBRACUNDataSet.ObracunElementiRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDELEMENT, eLEMENTRAZDOBLJEOD, eLEMENTRAZDOBLJEDO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.ObracunElementiRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.AllowDBNull = false;
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.columnELEMENTRAZDOBLJEOD = new DataColumn("ELEMENTRAZDOBLJEOD", typeof(DateTime), "", MappingType.Element);
                this.columnELEMENTRAZDOBLJEOD.AllowDBNull = false;
                this.columnELEMENTRAZDOBLJEOD.Caption = "";
                this.columnELEMENTRAZDOBLJEOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("IsKey", "true");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("DeklaritType", "date");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Description", "");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Length", "8");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Decimals", "0");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnELEMENTRAZDOBLJEOD.ExtendedProperties.Add("Deklarit.InternalName", "ELEMENTRAZDOBLJEOD");
                this.Columns.Add(this.columnELEMENTRAZDOBLJEOD);
                this.columnELEMENTRAZDOBLJEDO = new DataColumn("ELEMENTRAZDOBLJEDO", typeof(DateTime), "", MappingType.Element);
                this.columnELEMENTRAZDOBLJEDO.AllowDBNull = false;
                this.columnELEMENTRAZDOBLJEDO.Caption = "";
                this.columnELEMENTRAZDOBLJEDO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("IsKey", "true");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("DeklaritType", "date");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Description", "");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Length", "8");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Decimals", "0");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnELEMENTRAZDOBLJEDO.ExtendedProperties.Add("Deklarit.InternalName", "ELEMENTRAZDOBLJEDO");
                this.Columns.Add(this.columnELEMENTRAZDOBLJEDO);
                this.columnIDOSNOVAOSIGURANJA = new DataColumn("IDOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnIDOSNOVAOSIGURANJA.AllowDBNull = true;
                this.columnIDOSNOVAOSIGURANJA.Caption = "Šifra osnove osiguranja";
                this.columnIDOSNOVAOSIGURANJA.MaxLength = 2;
                this.columnIDOSNOVAOSIGURANJA.DefaultValue = "";
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Šifra osnove osiguranja");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "2");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("TreatEmptyAsNull", "true");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "IDOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnIDOSNOVAOSIGURANJA);
                this.columnNAZIVOSNOVAOSIGURANJA = new DataColumn("NAZIVOSNOVAOSIGURANJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOSNOVAOSIGURANJA.AllowDBNull = true;
                this.columnNAZIVOSNOVAOSIGURANJA.Caption = "Naziv osnove osiguranja";
                this.columnNAZIVOSNOVAOSIGURANJA.MaxLength = 100;
                this.columnNAZIVOSNOVAOSIGURANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Description", "Naziv osnove osiguranja");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOSNOVAOSIGURANJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOSNOVAOSIGURANJA");
                this.Columns.Add(this.columnNAZIVOSNOVAOSIGURANJA);
                this.columnRAZDOBLJESESMIJEPREKLAPATI = new DataColumn("RAZDOBLJESESMIJEPREKLAPATI", typeof(bool), "", MappingType.Element);
                this.columnRAZDOBLJESESMIJEPREKLAPATI.AllowDBNull = true;
                this.columnRAZDOBLJESESMIJEPREKLAPATI.Caption = "Razdoblje se smije preklapati";
                this.columnRAZDOBLJESESMIJEPREKLAPATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("IsKey", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Description", "Razdoblje se smije preklapati");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Length", "1");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Decimals", "0");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAZDOBLJESESMIJEPREKLAPATI.ExtendedProperties.Add("Deklarit.InternalName", "RAZDOBLJESESMIJEPREKLAPATI");
                this.Columns.Add(this.columnRAZDOBLJESESMIJEPREKLAPATI);
                this.columnOBRSATI = new DataColumn("OBRSATI", typeof(decimal), "", MappingType.Element);
                this.columnOBRSATI.AllowDBNull = false;
                this.columnOBRSATI.Caption = "";
                this.columnOBRSATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRSATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRSATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRSATI.ExtendedProperties.Add("Description", "");
                this.columnOBRSATI.ExtendedProperties.Add("Length", "5");
                this.columnOBRSATI.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRSATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRSATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnOBRSATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRSATI.ExtendedProperties.Add("Deklarit.InternalName", "OBRSATI");
                this.Columns.Add(this.columnOBRSATI);
                this.columnOBRSATNICA = new DataColumn("OBRSATNICA", typeof(decimal), "", MappingType.Element);
                this.columnOBRSATNICA.AllowDBNull = false;
                this.columnOBRSATNICA.Caption = "";
                this.columnOBRSATNICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRSATNICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRSATNICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRSATNICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRSATNICA.ExtendedProperties.Add("Description", "");
                this.columnOBRSATNICA.ExtendedProperties.Add("Length", "12");
                this.columnOBRSATNICA.ExtendedProperties.Add("Decimals", "8");
                this.columnOBRSATNICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRSATNICA.ExtendedProperties.Add("DomainType", "PUNODECIMALA");
                this.columnOBRSATNICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRSATNICA.ExtendedProperties.Add("Deklarit.InternalName", "OBRSATNICA");
                this.Columns.Add(this.columnOBRSATNICA);
                this.columnOBRIZNOS = new DataColumn("OBRIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnOBRIZNOS.AllowDBNull = false;
                this.columnOBRIZNOS.Caption = "OBRIZNOS";
                this.columnOBRIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRIZNOS.ExtendedProperties.Add("Description", "OBRIZNOS");
                this.columnOBRIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnOBRIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "OBRIZNOS");
                this.Columns.Add(this.columnOBRIZNOS);
                this.columnNAZIVELEMENT = new DataColumn("NAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVELEMENT.AllowDBNull = false;
                this.columnNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnNAZIVELEMENT.MaxLength = 50;
                this.columnNAZIVELEMENT.DefaultValue = "";
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVELEMENT");
                this.Columns.Add(this.columnNAZIVELEMENT);
                this.columnIDVRSTAELEMENTA = new DataColumn("IDVRSTAELEMENTA", typeof(short), "", MappingType.Element);
                this.columnIDVRSTAELEMENTA.AllowDBNull = false;
                this.columnIDVRSTAELEMENTA.Caption = "Šifra Vrste elementa";
                this.columnIDVRSTAELEMENTA.DefaultValue = 0;
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Description", "Šifra Vrste elementa");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Length", "4");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTAELEMENTA");
                this.Columns.Add(this.columnIDVRSTAELEMENTA);
                this.columnNAZIVVRSTAELEMENT = new DataColumn("NAZIVVRSTAELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTAELEMENT.AllowDBNull = false;
                this.columnNAZIVVRSTAELEMENT.Caption = "Naziv vrste elementa";
                this.columnNAZIVVRSTAELEMENT.MaxLength = 0x19;
                this.columnNAZIVVRSTAELEMENT.DefaultValue = "";
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Description", "Naziv vrste elementa");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Length", "25");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTAELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTAELEMENT");
                this.Columns.Add(this.columnNAZIVVRSTAELEMENT);
                this.columnOBRPOSTOTAK = new DataColumn("OBRPOSTOTAK", typeof(decimal), "", MappingType.Element);
                this.columnOBRPOSTOTAK.AllowDBNull = false;
                this.columnOBRPOSTOTAK.Caption = "";
                this.columnOBRPOSTOTAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Description", "");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Length", "5");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRPOSTOTAK.ExtendedProperties.Add("Deklarit.InternalName", "OBRPOSTOTAK");
                this.Columns.Add(this.columnOBRPOSTOTAK);
                this.columnZBRAJASATEUFONDSATI = new DataColumn("ZBRAJASATEUFONDSATI", typeof(bool), "", MappingType.Element);
                this.columnZBRAJASATEUFONDSATI.AllowDBNull = true;
                this.columnZBRAJASATEUFONDSATI.Caption = "Sati ulaze u fond sati";
                this.columnZBRAJASATEUFONDSATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Description", "Sati ulaze u fond sati");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Length", "1");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Decimals", "0");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZBRAJASATEUFONDSATI.ExtendedProperties.Add("Deklarit.InternalName", "ZBRAJASATEUFONDSATI");
                this.Columns.Add(this.columnZBRAJASATEUFONDSATI);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDELEMENT, this.columnELEMENTRAZDOBLJEOD, this.columnELEMENTRAZDOBLJEDO };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "ObracunElementi");
                this.ExtendedProperties.Add("Description", "ObracunElementi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
                this.columnELEMENTRAZDOBLJEOD = this.Columns["ELEMENTRAZDOBLJEOD"];
                this.columnELEMENTRAZDOBLJEDO = this.Columns["ELEMENTRAZDOBLJEDO"];
                this.columnIDOSNOVAOSIGURANJA = this.Columns["IDOSNOVAOSIGURANJA"];
                this.columnNAZIVOSNOVAOSIGURANJA = this.Columns["NAZIVOSNOVAOSIGURANJA"];
                this.columnRAZDOBLJESESMIJEPREKLAPATI = this.Columns["RAZDOBLJESESMIJEPREKLAPATI"];
                this.columnOBRSATI = this.Columns["OBRSATI"];
                this.columnOBRSATNICA = this.Columns["OBRSATNICA"];
                this.columnOBRIZNOS = this.Columns["OBRIZNOS"];
                this.columnNAZIVELEMENT = this.Columns["NAZIVELEMENT"];
                this.columnIDVRSTAELEMENTA = this.Columns["IDVRSTAELEMENTA"];
                this.columnNAZIVVRSTAELEMENT = this.Columns["NAZIVVRSTAELEMENT"];
                this.columnOBRPOSTOTAK = this.Columns["OBRPOSTOTAK"];
                this.columnZBRAJASATEUFONDSATI = this.Columns["ZBRAJASATEUFONDSATI"];
            }

            public OBRACUNDataSet.ObracunElementiRow NewObracunElementiRow()
            {
                return (OBRACUNDataSet.ObracunElementiRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.ObracunElementiRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ObracunElementiRowChanged != null)
                {
                    OBRACUNDataSet.ObracunElementiRowChangeEventHandler obracunElementiRowChangedEvent = this.ObracunElementiRowChanged;
                    if (obracunElementiRowChangedEvent != null)
                    {
                        obracunElementiRowChangedEvent(this, new OBRACUNDataSet.ObracunElementiRowChangeEvent((OBRACUNDataSet.ObracunElementiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ObracunElementiRowChanging != null)
                {
                    OBRACUNDataSet.ObracunElementiRowChangeEventHandler obracunElementiRowChangingEvent = this.ObracunElementiRowChanging;
                    if (obracunElementiRowChangingEvent != null)
                    {
                        obracunElementiRowChangingEvent(this, new OBRACUNDataSet.ObracunElementiRowChangeEvent((OBRACUNDataSet.ObracunElementiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_ObracunElementi", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.ObracunElementiRowDeleted != null)
                {
                    OBRACUNDataSet.ObracunElementiRowChangeEventHandler obracunElementiRowDeletedEvent = this.ObracunElementiRowDeleted;
                    if (obracunElementiRowDeletedEvent != null)
                    {
                        obracunElementiRowDeletedEvent(this, new OBRACUNDataSet.ObracunElementiRowChangeEvent((OBRACUNDataSet.ObracunElementiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ObracunElementiRowDeleting != null)
                {
                    OBRACUNDataSet.ObracunElementiRowChangeEventHandler obracunElementiRowDeletingEvent = this.ObracunElementiRowDeleting;
                    if (obracunElementiRowDeletingEvent != null)
                    {
                        obracunElementiRowDeletingEvent(this, new OBRACUNDataSet.ObracunElementiRowChangeEvent((OBRACUNDataSet.ObracunElementiRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveObracunElementiRow(OBRACUNDataSet.ObracunElementiRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn ELEMENTRAZDOBLJEDOColumn
            {
                get
                {
                    return this.columnELEMENTRAZDOBLJEDO;
                }
            }

            public DataColumn ELEMENTRAZDOBLJEODColumn
            {
                get
                {
                    return this.columnELEMENTRAZDOBLJEOD;
                }
            }

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnIDOSNOVAOSIGURANJA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IDVRSTAELEMENTAColumn
            {
                get
                {
                    return this.columnIDVRSTAELEMENTA;
                }
            }

            public OBRACUNDataSet.ObracunElementiRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.ObracunElementiRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVELEMENT;
                }
            }

            public DataColumn NAZIVOSNOVAOSIGURANJAColumn
            {
                get
                {
                    return this.columnNAZIVOSNOVAOSIGURANJA;
                }
            }

            public DataColumn NAZIVVRSTAELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVVRSTAELEMENT;
                }
            }

            public DataColumn OBRIZNOSColumn
            {
                get
                {
                    return this.columnOBRIZNOS;
                }
            }

            public DataColumn OBRPOSTOTAKColumn
            {
                get
                {
                    return this.columnOBRPOSTOTAK;
                }
            }

            public DataColumn OBRSATIColumn
            {
                get
                {
                    return this.columnOBRSATI;
                }
            }

            public DataColumn OBRSATNICAColumn
            {
                get
                {
                    return this.columnOBRSATNICA;
                }
            }

            public DataColumn RAZDOBLJESESMIJEPREKLAPATIColumn
            {
                get
                {
                    return this.columnRAZDOBLJESESMIJEPREKLAPATI;
                }
            }

            public DataColumn ZBRAJASATEUFONDSATIColumn
            {
                get
                {
                    return this.columnZBRAJASATEUFONDSATI;
                }
            }
        }

        public class ObracunElementiRow : DataRow
        {
            private OBRACUNDataSet.ObracunElementiDataTable tableObracunElementi;

            internal ObracunElementiRow(DataRowBuilder rb) : base(rb)
            {
                this.tableObracunElementi = (OBRACUNDataSet.ObracunElementiDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_ObracunElementi");
            }

            public bool IsELEMENTRAZDOBLJEDONull()
            {
                return this.IsNull(this.tableObracunElementi.ELEMENTRAZDOBLJEDOColumn);
            }

            public bool IsELEMENTRAZDOBLJEODNull()
            {
                return this.IsNull(this.tableObracunElementi.ELEMENTRAZDOBLJEODColumn);
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tableObracunElementi.IDELEMENTColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableObracunElementi.IDOBRACUNColumn);
            }

            public bool IsIDOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableObracunElementi.IDOSNOVAOSIGURANJAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableObracunElementi.IDRADNIKColumn);
            }

            public bool IsIDVRSTAELEMENTANull()
            {
                return this.IsNull(this.tableObracunElementi.IDVRSTAELEMENTAColumn);
            }

            public bool IsNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableObracunElementi.NAZIVELEMENTColumn);
            }

            public bool IsNAZIVOSNOVAOSIGURANJANull()
            {
                return this.IsNull(this.tableObracunElementi.NAZIVOSNOVAOSIGURANJAColumn);
            }

            public bool IsNAZIVVRSTAELEMENTNull()
            {
                return this.IsNull(this.tableObracunElementi.NAZIVVRSTAELEMENTColumn);
            }

            public bool IsOBRIZNOSNull()
            {
                return this.IsNull(this.tableObracunElementi.OBRIZNOSColumn);
            }

            public bool IsOBRPOSTOTAKNull()
            {
                return this.IsNull(this.tableObracunElementi.OBRPOSTOTAKColumn);
            }

            public bool IsOBRSATINull()
            {
                return this.IsNull(this.tableObracunElementi.OBRSATIColumn);
            }

            public bool IsOBRSATNICANull()
            {
                return this.IsNull(this.tableObracunElementi.OBRSATNICAColumn);
            }

            public bool IsRAZDOBLJESESMIJEPREKLAPATINull()
            {
                return this.IsNull(this.tableObracunElementi.RAZDOBLJESESMIJEPREKLAPATIColumn);
            }

            public bool IsZBRAJASATEUFONDSATINull()
            {
                return this.IsNull(this.tableObracunElementi.ZBRAJASATEUFONDSATIColumn);
            }

            public void SetIDOSNOVAOSIGURANJANull()
            {
                this[this.tableObracunElementi.IDOSNOVAOSIGURANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDVRSTAELEMENTANull()
            {
                this[this.tableObracunElementi.IDVRSTAELEMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVELEMENTNull()
            {
                this[this.tableObracunElementi.NAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOSNOVAOSIGURANJANull()
            {
                this[this.tableObracunElementi.NAZIVOSNOVAOSIGURANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTAELEMENTNull()
            {
                this[this.tableObracunElementi.NAZIVVRSTAELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRIZNOSNull()
            {
                this[this.tableObracunElementi.OBRIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRPOSTOTAKNull()
            {
                this[this.tableObracunElementi.OBRPOSTOTAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRSATINull()
            {
                this[this.tableObracunElementi.OBRSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRSATNICANull()
            {
                this[this.tableObracunElementi.OBRSATNICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRAZDOBLJESESMIJEPREKLAPATINull()
            {
                this[this.tableObracunElementi.RAZDOBLJESESMIJEPREKLAPATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZBRAJASATEUFONDSATINull()
            {
                this[this.tableObracunElementi.ZBRAJASATEUFONDSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime ELEMENTRAZDOBLJEDO
            {
                get
                {
                    return Conversions.ToDate(this[this.tableObracunElementi.ELEMENTRAZDOBLJEDOColumn]);
                }
                set
                {
                    this[this.tableObracunElementi.ELEMENTRAZDOBLJEDOColumn] = value;
                }
            }

            public DateTime ELEMENTRAZDOBLJEOD
            {
                get
                {
                    return Conversions.ToDate(this[this.tableObracunElementi.ELEMENTRAZDOBLJEODColumn]);
                }
                set
                {
                    this[this.tableObracunElementi.ELEMENTRAZDOBLJEODColumn] = value;
                }
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunElementi.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tableObracunElementi.IDELEMENTColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableObracunElementi.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableObracunElementi.IDOBRACUNColumn] = value;
                }
            }

            public string IDOSNOVAOSIGURANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunElementi.IDOSNOVAOSIGURANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunElementi.IDOSNOVAOSIGURANJAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunElementi.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableObracunElementi.IDRADNIKColumn] = value;
                }
            }

            public short IDVRSTAELEMENTA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableObracunElementi.IDVRSTAELEMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunElementi.IDVRSTAELEMENTAColumn] = value;
                }
            }

            public string NAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunElementi.NAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunElementi.NAZIVELEMENTColumn] = value;
                }
            }

            public string NAZIVOSNOVAOSIGURANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunElementi.NAZIVOSNOVAOSIGURANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunElementi.NAZIVOSNOVAOSIGURANJAColumn] = value;
                }
            }

            public string NAZIVVRSTAELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunElementi.NAZIVVRSTAELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunElementi.NAZIVVRSTAELEMENTColumn] = value;
                }
            }

            public decimal OBRIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunElementi.OBRIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunElementi.OBRIZNOSColumn] = value;
                }
            }

            public decimal OBRPOSTOTAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunElementi.OBRPOSTOTAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunElementi.OBRPOSTOTAKColumn] = value;
                }
            }

            public decimal OBRSATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunElementi.OBRSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunElementi.OBRSATIColumn] = value;
                }
            }

            public decimal OBRSATNICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunElementi.OBRSATNICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunElementi.OBRSATNICAColumn] = value;
                }
            }

            public bool RAZDOBLJESESMIJEPREKLAPATI
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableObracunElementi.RAZDOBLJESESMIJEPREKLAPATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableObracunElementi.RAZDOBLJESESMIJEPREKLAPATIColumn] = value;
                }
            }

            public bool ZBRAJASATEUFONDSATI
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableObracunElementi.ZBRAJASATEUFONDSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableObracunElementi.ZBRAJASATEUFONDSATIColumn] = value;
                }
            }
        }

        public class ObracunElementiRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.ObracunElementiRow eventRow;

            public ObracunElementiRowChangeEvent(OBRACUNDataSet.ObracunElementiRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.ObracunElementiRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ObracunElementiRowChangeEventHandler(object sender, OBRACUNDataSet.ObracunElementiRowChangeEvent e);

        [Serializable]
        public class OBRACUNKreditiDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBRRATADOSADA;
            private DataColumn columnDATUMUGOVORA;
            private DataColumn columnDOSADAOBUSTAVLJENO;
            private DataColumn columnIDKREDITOR;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDRADNIK;
            private DataColumn columnNAZIVKREDITOR;
            private DataColumn columnOBRACUNATIKUNSKIIZNOS;
            private DataColumn columnOBRIZNOSRATEKREDITOR;
            private DataColumn columnOBRMOKREDITOR;
            private DataColumn columnOBRMZKREDITOR;
            private DataColumn columnOBROPISPLACANJAKREDITOR;
            private DataColumn columnOBRPOKREDITOR;
            private DataColumn columnOBRPZKREDITOR;
            private DataColumn columnOBRSIFRAOPISAPLACANJAKREDITOR;
            private DataColumn columnPRIMATELJKREDITOR1;
            private DataColumn columnPRIMATELJKREDITOR2;
            private DataColumn columnPRIMATELJKREDITOR3;
            private DataColumn columnUKUPNIZNOSKREDITA;
            private DataColumn columnVBDIKREDITOR;
            private DataColumn columnVECOTPLACENOBROJRATA;
            private DataColumn columnVECOTPLACENOUKUPNIIZNOS;
            private DataColumn columnZRNKREDITOR;

            public event OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler OBRACUNKreditiRowChanged;

            public event OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler OBRACUNKreditiRowChanging;

            public event OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler OBRACUNKreditiRowDeleted;

            public event OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler OBRACUNKreditiRowDeleting;

            public OBRACUNKreditiDataTable()
            {
                this.TableName = "OBRACUNKrediti";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OBRACUNKreditiDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected OBRACUNKreditiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOBRACUNKreditiRow(OBRACUNDataSet.OBRACUNKreditiRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.OBRACUNKreditiRow AddOBRACUNKreditiRow(string iDOBRACUN, int iDRADNIK, int iDKREDITOR, DateTime dATUMUGOVORA, string oBRSIFRAOPISAPLACANJAKREDITOR, string oBROPISPLACANJAKREDITOR, string oBRMOKREDITOR, string oBRPOKREDITOR, string oBRMZKREDITOR, string oBRPZKREDITOR, decimal oBRIZNOSRATEKREDITOR, decimal oBRACUNATIKUNSKIIZNOS, decimal vECOTPLACENOBROJRATA, decimal vECOTPLACENOUKUPNIIZNOS, decimal uKUPNIZNOSKREDITA)
            {
                OBRACUNDataSet.OBRACUNKreditiRow row = (OBRACUNDataSet.OBRACUNKreditiRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["IDKREDITOR"] = iDKREDITOR;
                row["DATUMUGOVORA"] = dATUMUGOVORA;
                row["OBRSIFRAOPISAPLACANJAKREDITOR"] = oBRSIFRAOPISAPLACANJAKREDITOR;
                row["OBROPISPLACANJAKREDITOR"] = oBROPISPLACANJAKREDITOR;
                row["OBRMOKREDITOR"] = oBRMOKREDITOR;
                row["OBRPOKREDITOR"] = oBRPOKREDITOR;
                row["OBRMZKREDITOR"] = oBRMZKREDITOR;
                row["OBRPZKREDITOR"] = oBRPZKREDITOR;
                row["OBRIZNOSRATEKREDITOR"] = oBRIZNOSRATEKREDITOR;
                row["OBRACUNATIKUNSKIIZNOS"] = oBRACUNATIKUNSKIIZNOS;
                row["VECOTPLACENOBROJRATA"] = vECOTPLACENOBROJRATA;
                row["VECOTPLACENOUKUPNIIZNOS"] = vECOTPLACENOUKUPNIIZNOS;
                row["UKUPNIZNOSKREDITA"] = uKUPNIZNOSKREDITA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.OBRACUNKreditiDataTable table = (OBRACUNDataSet.OBRACUNKreditiDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.OBRACUNKreditiRow FindByIDOBRACUNIDRADNIKIDKREDITORDATUMUGOVORA(string iDOBRACUN, int iDRADNIK, int iDKREDITOR, DateTime dATUMUGOVORA)
            {
                return (OBRACUNDataSet.OBRACUNKreditiRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDKREDITOR, dATUMUGOVORA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.OBRACUNKreditiRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDKREDITOR = new DataColumn("IDKREDITOR", typeof(int), "", MappingType.Element);
                this.columnIDKREDITOR.AllowDBNull = false;
                this.columnIDKREDITOR.Caption = "IDKREDITOR";
                this.columnIDKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "99999999");
                this.columnIDKREDITOR.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKREDITOR.ExtendedProperties.Add("Description", "IDKREDITOR");
                this.columnIDKREDITOR.ExtendedProperties.Add("Length", "8");
                this.columnIDKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "IDKREDITOR");
                this.Columns.Add(this.columnIDKREDITOR);
                this.columnDATUMUGOVORA = new DataColumn("DATUMUGOVORA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMUGOVORA.AllowDBNull = false;
                this.columnDATUMUGOVORA.Caption = "DATUMUGOVORA";
                this.columnDATUMUGOVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsKey", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Description", "DATUMUGOVORA");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMUGOVORA");
                this.Columns.Add(this.columnDATUMUGOVORA);
                this.columnNAZIVKREDITOR = new DataColumn("NAZIVKREDITOR", typeof(string), "", MappingType.Element);
                this.columnNAZIVKREDITOR.AllowDBNull = false;
                this.columnNAZIVKREDITOR.Caption = "NAZIVKREDITOR";
                this.columnNAZIVKREDITOR.MaxLength = 20;
                this.columnNAZIVKREDITOR.DefaultValue = "";
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Description", "NAZIVKREDITOR");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKREDITOR");
                this.Columns.Add(this.columnNAZIVKREDITOR);
                this.columnVBDIKREDITOR = new DataColumn("VBDIKREDITOR", typeof(string), "", MappingType.Element);
                this.columnVBDIKREDITOR.AllowDBNull = false;
                this.columnVBDIKREDITOR.Caption = "VBDIKREDITOR";
                this.columnVBDIKREDITOR.MaxLength = 7;
                this.columnVBDIKREDITOR.DefaultValue = "";
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Description", "VBDIKREDITOR");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Length", "7");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "VBDIKREDITOR");
                this.Columns.Add(this.columnVBDIKREDITOR);
                this.columnZRNKREDITOR = new DataColumn("ZRNKREDITOR", typeof(string), "", MappingType.Element);
                this.columnZRNKREDITOR.AllowDBNull = false;
                this.columnZRNKREDITOR.Caption = "ZRNKREDITOR";
                this.columnZRNKREDITOR.MaxLength = 10;
                this.columnZRNKREDITOR.DefaultValue = "";
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Description", "ZRNKREDITOR");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Length", "10");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "ZRNKREDITOR");
                this.Columns.Add(this.columnZRNKREDITOR);
                this.columnPRIMATELJKREDITOR1 = new DataColumn("PRIMATELJKREDITOR1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR1.AllowDBNull = false;
                this.columnPRIMATELJKREDITOR1.Caption = "PRIMATELJKREDITO R1";
                this.columnPRIMATELJKREDITOR1.MaxLength = 20;
                this.columnPRIMATELJKREDITOR1.DefaultValue = "";
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Description", "PRIMATELJKREDITO R1");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR1");
                this.Columns.Add(this.columnPRIMATELJKREDITOR1);
                this.columnPRIMATELJKREDITOR2 = new DataColumn("PRIMATELJKREDITOR2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR2.AllowDBNull = true;
                this.columnPRIMATELJKREDITOR2.Caption = "PRIMATELJKREDITO R2";
                this.columnPRIMATELJKREDITOR2.MaxLength = 20;
                this.columnPRIMATELJKREDITOR2.DefaultValue = "";
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Description", "PRIMATELJKREDITO R2");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR2");
                this.Columns.Add(this.columnPRIMATELJKREDITOR2);
                this.columnPRIMATELJKREDITOR3 = new DataColumn("PRIMATELJKREDITOR3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKREDITOR3.AllowDBNull = true;
                this.columnPRIMATELJKREDITOR3.Caption = "PRIMATELJKREDITO R3";
                this.columnPRIMATELJKREDITOR3.MaxLength = 20;
                this.columnPRIMATELJKREDITOR3.DefaultValue = "";
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Description", "PRIMATELJKREDITO R3");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKREDITOR3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKREDITOR3");
                this.Columns.Add(this.columnPRIMATELJKREDITOR3);
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR = new DataColumn("OBRSIFRAOPISAPLACANJAKREDITOR", typeof(string), "", MappingType.Element);
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.AllowDBNull = false;
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.Caption = "SIFRAOPISAPLACANJAKREDITOR";
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.MaxLength = 2;
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Description", "SIFRAOPISAPLACANJAKREDITOR");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Length", "2");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OBRSIFRAOPISAPLACANJAKREDITOR");
                this.Columns.Add(this.columnOBRSIFRAOPISAPLACANJAKREDITOR);
                this.columnOBROPISPLACANJAKREDITOR = new DataColumn("OBROPISPLACANJAKREDITOR", typeof(string), "", MappingType.Element);
                this.columnOBROPISPLACANJAKREDITOR.AllowDBNull = false;
                this.columnOBROPISPLACANJAKREDITOR.Caption = "OBROPISPLACANJAKREDITOR";
                this.columnOBROPISPLACANJAKREDITOR.MaxLength = 0x24;
                this.columnOBROPISPLACANJAKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Description", "OBROPISPLACANJAKREDITOR");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Length", "36");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBROPISPLACANJAKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OBROPISPLACANJAKREDITOR");
                this.Columns.Add(this.columnOBROPISPLACANJAKREDITOR);
                this.columnOBRMOKREDITOR = new DataColumn("OBRMOKREDITOR", typeof(string), "", MappingType.Element);
                this.columnOBRMOKREDITOR.AllowDBNull = true;
                this.columnOBRMOKREDITOR.Caption = "OBRMOKREDITOR";
                this.columnOBRMOKREDITOR.MaxLength = 2;
                this.columnOBRMOKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Description", "OBRMOKREDITOR");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Length", "2");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRMOKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OBRMOKREDITOR");
                this.Columns.Add(this.columnOBRMOKREDITOR);
                this.columnOBRPOKREDITOR = new DataColumn("OBRPOKREDITOR", typeof(string), "", MappingType.Element);
                this.columnOBRPOKREDITOR.AllowDBNull = true;
                this.columnOBRPOKREDITOR.Caption = "OBRPOKREDITOR";
                this.columnOBRPOKREDITOR.MaxLength = 0x16;
                this.columnOBRPOKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Description", "OBRPOKREDITOR");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Length", "22");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRPOKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OBRPOKREDITOR");
                this.Columns.Add(this.columnOBRPOKREDITOR);
                this.columnOBRMZKREDITOR = new DataColumn("OBRMZKREDITOR", typeof(string), "", MappingType.Element);
                this.columnOBRMZKREDITOR.AllowDBNull = true;
                this.columnOBRMZKREDITOR.Caption = "OBRMZKREDITOR";
                this.columnOBRMZKREDITOR.MaxLength = 2;
                this.columnOBRMZKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Description", "OBRMZKREDITOR");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Length", "2");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRMZKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OBRMZKREDITOR");
                this.Columns.Add(this.columnOBRMZKREDITOR);
                this.columnOBRPZKREDITOR = new DataColumn("OBRPZKREDITOR", typeof(string), "", MappingType.Element);
                this.columnOBRPZKREDITOR.AllowDBNull = true;
                this.columnOBRPZKREDITOR.Caption = "OBRPZKREDITOR";
                this.columnOBRPZKREDITOR.MaxLength = 0x16;
                this.columnOBRPZKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Description", "OBRPZKREDITOR");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Length", "22");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRPZKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OBRPZKREDITOR");
                this.Columns.Add(this.columnOBRPZKREDITOR);
                this.columnOBRIZNOSRATEKREDITOR = new DataColumn("OBRIZNOSRATEKREDITOR", typeof(decimal), "", MappingType.Element);
                this.columnOBRIZNOSRATEKREDITOR.AllowDBNull = false;
                this.columnOBRIZNOSRATEKREDITOR.Caption = "OBRIZNOSRATEKREDITOR";
                this.columnOBRIZNOSRATEKREDITOR.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Description", "OBRIZNOSRATEKREDITOR");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Length", "12");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRIZNOSRATEKREDITOR.ExtendedProperties.Add("Deklarit.InternalName", "OBRIZNOSRATEKREDITOR");
                this.Columns.Add(this.columnOBRIZNOSRATEKREDITOR);
                this.columnOBRACUNATIKUNSKIIZNOS = new DataColumn("OBRACUNATIKUNSKIIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATIKUNSKIIZNOS.AllowDBNull = false;
                this.columnOBRACUNATIKUNSKIIZNOS.Caption = "OBRACUNATIKUNSKIIZNOS";
                this.columnOBRACUNATIKUNSKIIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Description", "OBRACUNATIKUNSKIIZNOS");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATIKUNSKIIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATIKUNSKIIZNOS");
                this.Columns.Add(this.columnOBRACUNATIKUNSKIIZNOS);
                this.columnVECOTPLACENOBROJRATA = new DataColumn("VECOTPLACENOBROJRATA", typeof(decimal), "", MappingType.Element);
                this.columnVECOTPLACENOBROJRATA.AllowDBNull = false;
                this.columnVECOTPLACENOBROJRATA.Caption = "";
                this.columnVECOTPLACENOBROJRATA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("IsKey", "false");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Description", "");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Length", "12");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Decimals", "2");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVECOTPLACENOBROJRATA.ExtendedProperties.Add("Deklarit.InternalName", "VECOTPLACENOBROJRATA");
                this.Columns.Add(this.columnVECOTPLACENOBROJRATA);
                this.columnVECOTPLACENOUKUPNIIZNOS = new DataColumn("VECOTPLACENOUKUPNIIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnVECOTPLACENOUKUPNIIZNOS.AllowDBNull = false;
                this.columnVECOTPLACENOUKUPNIIZNOS.Caption = "";
                this.columnVECOTPLACENOUKUPNIIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Description", "");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVECOTPLACENOUKUPNIIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "VECOTPLACENOUKUPNIIZNOS");
                this.Columns.Add(this.columnVECOTPLACENOUKUPNIIZNOS);
                this.columnUKUPNIZNOSKREDITA = new DataColumn("UKUPNIZNOSKREDITA", typeof(decimal), "", MappingType.Element);
                this.columnUKUPNIZNOSKREDITA.AllowDBNull = false;
                this.columnUKUPNIZNOSKREDITA.Caption = "";
                this.columnUKUPNIZNOSKREDITA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Description", "");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Length", "12");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUPNIZNOSKREDITA.ExtendedProperties.Add("Deklarit.InternalName", "UKUPNIZNOSKREDITA");
                this.Columns.Add(this.columnUKUPNIZNOSKREDITA);
                this.columnDOSADAOBUSTAVLJENO = new DataColumn("DOSADAOBUSTAVLJENO", typeof(decimal), "", MappingType.Element);
                this.columnDOSADAOBUSTAVLJENO.AllowDBNull = true;
                this.columnDOSADAOBUSTAVLJENO.Caption = "";
                this.columnDOSADAOBUSTAVLJENO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("IsKey", "false");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Description", "");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Length", "12");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Decimals", "2");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOSADAOBUSTAVLJENO.ExtendedProperties.Add("Deklarit.InternalName", "DOSADAOBUSTAVLJENO");
                this.Columns.Add(this.columnDOSADAOBUSTAVLJENO);
                this.columnBRRATADOSADA = new DataColumn("BRRATADOSADA", typeof(decimal), "", MappingType.Element);
                this.columnBRRATADOSADA.AllowDBNull = true;
                this.columnBRRATADOSADA.Caption = "";
                this.columnBRRATADOSADA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBRRATADOSADA.ExtendedProperties.Add("IsKey", "false");
                this.columnBRRATADOSADA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBRRATADOSADA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Description", "");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Length", "12");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Decimals", "2");
                this.columnBRRATADOSADA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnBRRATADOSADA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnBRRATADOSADA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBRRATADOSADA.ExtendedProperties.Add("Deklarit.InternalName", "BRRATADOSADA");
                this.Columns.Add(this.columnBRRATADOSADA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDKREDITOR, this.columnDATUMUGOVORA };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "ObracunKrediti");
                this.ExtendedProperties.Add("Description", "ObracunKrediti");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDKREDITOR = this.Columns["IDKREDITOR"];
                this.columnDATUMUGOVORA = this.Columns["DATUMUGOVORA"];
                this.columnNAZIVKREDITOR = this.Columns["NAZIVKREDITOR"];
                this.columnVBDIKREDITOR = this.Columns["VBDIKREDITOR"];
                this.columnZRNKREDITOR = this.Columns["ZRNKREDITOR"];
                this.columnPRIMATELJKREDITOR1 = this.Columns["PRIMATELJKREDITOR1"];
                this.columnPRIMATELJKREDITOR2 = this.Columns["PRIMATELJKREDITOR2"];
                this.columnPRIMATELJKREDITOR3 = this.Columns["PRIMATELJKREDITOR3"];
                this.columnOBRSIFRAOPISAPLACANJAKREDITOR = this.Columns["OBRSIFRAOPISAPLACANJAKREDITOR"];
                this.columnOBROPISPLACANJAKREDITOR = this.Columns["OBROPISPLACANJAKREDITOR"];
                this.columnOBRMOKREDITOR = this.Columns["OBRMOKREDITOR"];
                this.columnOBRPOKREDITOR = this.Columns["OBRPOKREDITOR"];
                this.columnOBRMZKREDITOR = this.Columns["OBRMZKREDITOR"];
                this.columnOBRPZKREDITOR = this.Columns["OBRPZKREDITOR"];
                this.columnOBRIZNOSRATEKREDITOR = this.Columns["OBRIZNOSRATEKREDITOR"];
                this.columnOBRACUNATIKUNSKIIZNOS = this.Columns["OBRACUNATIKUNSKIIZNOS"];
                this.columnVECOTPLACENOBROJRATA = this.Columns["VECOTPLACENOBROJRATA"];
                this.columnVECOTPLACENOUKUPNIIZNOS = this.Columns["VECOTPLACENOUKUPNIIZNOS"];
                this.columnUKUPNIZNOSKREDITA = this.Columns["UKUPNIZNOSKREDITA"];
                this.columnDOSADAOBUSTAVLJENO = this.Columns["DOSADAOBUSTAVLJENO"];
                this.columnBRRATADOSADA = this.Columns["BRRATADOSADA"];
            }

            public OBRACUNDataSet.OBRACUNKreditiRow NewOBRACUNKreditiRow()
            {
                return (OBRACUNDataSet.OBRACUNKreditiRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.OBRACUNKreditiRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OBRACUNKreditiRowChanged != null)
                {
                    OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler oBRACUNKreditiRowChangedEvent = this.OBRACUNKreditiRowChanged;
                    if (oBRACUNKreditiRowChangedEvent != null)
                    {
                        oBRACUNKreditiRowChangedEvent(this, new OBRACUNDataSet.OBRACUNKreditiRowChangeEvent((OBRACUNDataSet.OBRACUNKreditiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OBRACUNKreditiRowChanging != null)
                {
                    OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler oBRACUNKreditiRowChangingEvent = this.OBRACUNKreditiRowChanging;
                    if (oBRACUNKreditiRowChangingEvent != null)
                    {
                        oBRACUNKreditiRowChangingEvent(this, new OBRACUNDataSet.OBRACUNKreditiRowChangeEvent((OBRACUNDataSet.OBRACUNKreditiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_OBRACUNKrediti", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.OBRACUNKreditiRowDeleted != null)
                {
                    OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler oBRACUNKreditiRowDeletedEvent = this.OBRACUNKreditiRowDeleted;
                    if (oBRACUNKreditiRowDeletedEvent != null)
                    {
                        oBRACUNKreditiRowDeletedEvent(this, new OBRACUNDataSet.OBRACUNKreditiRowChangeEvent((OBRACUNDataSet.OBRACUNKreditiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OBRACUNKreditiRowDeleting != null)
                {
                    OBRACUNDataSet.OBRACUNKreditiRowChangeEventHandler oBRACUNKreditiRowDeletingEvent = this.OBRACUNKreditiRowDeleting;
                    if (oBRACUNKreditiRowDeletingEvent != null)
                    {
                        oBRACUNKreditiRowDeletingEvent(this, new OBRACUNDataSet.OBRACUNKreditiRowChangeEvent((OBRACUNDataSet.OBRACUNKreditiRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOBRACUNKreditiRow(OBRACUNDataSet.OBRACUNKreditiRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BRRATADOSADAColumn
            {
                get
                {
                    return this.columnBRRATADOSADA;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn DATUMUGOVORAColumn
            {
                get
                {
                    return this.columnDATUMUGOVORA;
                }
            }

            public DataColumn DOSADAOBUSTAVLJENOColumn
            {
                get
                {
                    return this.columnDOSADAOBUSTAVLJENO;
                }
            }

            public DataColumn IDKREDITORColumn
            {
                get
                {
                    return this.columnIDKREDITOR;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public OBRACUNDataSet.OBRACUNKreditiRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.OBRACUNKreditiRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVKREDITORColumn
            {
                get
                {
                    return this.columnNAZIVKREDITOR;
                }
            }

            public DataColumn OBRACUNATIKUNSKIIZNOSColumn
            {
                get
                {
                    return this.columnOBRACUNATIKUNSKIIZNOS;
                }
            }

            public DataColumn OBRIZNOSRATEKREDITORColumn
            {
                get
                {
                    return this.columnOBRIZNOSRATEKREDITOR;
                }
            }

            public DataColumn OBRMOKREDITORColumn
            {
                get
                {
                    return this.columnOBRMOKREDITOR;
                }
            }

            public DataColumn OBRMZKREDITORColumn
            {
                get
                {
                    return this.columnOBRMZKREDITOR;
                }
            }

            public DataColumn OBROPISPLACANJAKREDITORColumn
            {
                get
                {
                    return this.columnOBROPISPLACANJAKREDITOR;
                }
            }

            public DataColumn OBRPOKREDITORColumn
            {
                get
                {
                    return this.columnOBRPOKREDITOR;
                }
            }

            public DataColumn OBRPZKREDITORColumn
            {
                get
                {
                    return this.columnOBRPZKREDITOR;
                }
            }

            public DataColumn OBRSIFRAOPISAPLACANJAKREDITORColumn
            {
                get
                {
                    return this.columnOBRSIFRAOPISAPLACANJAKREDITOR;
                }
            }

            public DataColumn PRIMATELJKREDITOR1Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR1;
                }
            }

            public DataColumn PRIMATELJKREDITOR2Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR2;
                }
            }

            public DataColumn PRIMATELJKREDITOR3Column
            {
                get
                {
                    return this.columnPRIMATELJKREDITOR3;
                }
            }

            public DataColumn UKUPNIZNOSKREDITAColumn
            {
                get
                {
                    return this.columnUKUPNIZNOSKREDITA;
                }
            }

            public DataColumn VBDIKREDITORColumn
            {
                get
                {
                    return this.columnVBDIKREDITOR;
                }
            }

            public DataColumn VECOTPLACENOBROJRATAColumn
            {
                get
                {
                    return this.columnVECOTPLACENOBROJRATA;
                }
            }

            public DataColumn VECOTPLACENOUKUPNIIZNOSColumn
            {
                get
                {
                    return this.columnVECOTPLACENOUKUPNIIZNOS;
                }
            }

            public DataColumn ZRNKREDITORColumn
            {
                get
                {
                    return this.columnZRNKREDITOR;
                }
            }
        }

        public class OBRACUNKreditiRow : DataRow
        {
            private OBRACUNDataSet.OBRACUNKreditiDataTable tableOBRACUNKrediti;

            internal OBRACUNKreditiRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOBRACUNKrediti = (OBRACUNDataSet.OBRACUNKreditiDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_OBRACUNKrediti");
            }

            public bool IsBRRATADOSADANull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.BRRATADOSADAColumn);
            }

            public bool IsDATUMUGOVORANull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.DATUMUGOVORAColumn);
            }

            public bool IsDOSADAOBUSTAVLJENONull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.DOSADAOBUSTAVLJENOColumn);
            }

            public bool IsIDKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.IDKREDITORColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.IDOBRACUNColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.IDRADNIKColumn);
            }

            public bool IsNAZIVKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.NAZIVKREDITORColumn);
            }

            public bool IsOBRACUNATIKUNSKIIZNOSNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBRACUNATIKUNSKIIZNOSColumn);
            }

            public bool IsOBRIZNOSRATEKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBRIZNOSRATEKREDITORColumn);
            }

            public bool IsOBRMOKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBRMOKREDITORColumn);
            }

            public bool IsOBRMZKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBRMZKREDITORColumn);
            }

            public bool IsOBROPISPLACANJAKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBROPISPLACANJAKREDITORColumn);
            }

            public bool IsOBRPOKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBRPOKREDITORColumn);
            }

            public bool IsOBRPZKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBRPZKREDITORColumn);
            }

            public bool IsOBRSIFRAOPISAPLACANJAKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.OBRSIFRAOPISAPLACANJAKREDITORColumn);
            }

            public bool IsPRIMATELJKREDITOR1Null()
            {
                return this.IsNull(this.tableOBRACUNKrediti.PRIMATELJKREDITOR1Column);
            }

            public bool IsPRIMATELJKREDITOR2Null()
            {
                return this.IsNull(this.tableOBRACUNKrediti.PRIMATELJKREDITOR2Column);
            }

            public bool IsPRIMATELJKREDITOR3Null()
            {
                return this.IsNull(this.tableOBRACUNKrediti.PRIMATELJKREDITOR3Column);
            }

            public bool IsUKUPNIZNOSKREDITANull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.UKUPNIZNOSKREDITAColumn);
            }

            public bool IsVBDIKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.VBDIKREDITORColumn);
            }

            public bool IsVECOTPLACENOBROJRATANull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.VECOTPLACENOBROJRATAColumn);
            }

            public bool IsVECOTPLACENOUKUPNIIZNOSNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.VECOTPLACENOUKUPNIIZNOSColumn);
            }

            public bool IsZRNKREDITORNull()
            {
                return this.IsNull(this.tableOBRACUNKrediti.ZRNKREDITORColumn);
            }

            public void SetBRRATADOSADANull()
            {
                this[this.tableOBRACUNKrediti.BRRATADOSADAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOSADAOBUSTAVLJENONull()
            {
                this[this.tableOBRACUNKrediti.DOSADAOBUSTAVLJENOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.NAZIVKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATIKUNSKIIZNOSNull()
            {
                this[this.tableOBRACUNKrediti.OBRACUNATIKUNSKIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRIZNOSRATEKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.OBRIZNOSRATEKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRMOKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.OBRMOKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRMZKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.OBRMZKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBROPISPLACANJAKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.OBROPISPLACANJAKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRPOKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.OBRPOKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRPZKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.OBRPZKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRSIFRAOPISAPLACANJAKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.OBRSIFRAOPISAPLACANJAKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR1Null()
            {
                this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR2Null()
            {
                this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKREDITOR3Null()
            {
                this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUPNIZNOSKREDITANull()
            {
                this[this.tableOBRACUNKrediti.UKUPNIZNOSKREDITAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.VBDIKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVECOTPLACENOBROJRATANull()
            {
                this[this.tableOBRACUNKrediti.VECOTPLACENOBROJRATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVECOTPLACENOUKUPNIIZNOSNull()
            {
                this[this.tableOBRACUNKrediti.VECOTPLACENOUKUPNIIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNKREDITORNull()
            {
                this[this.tableOBRACUNKrediti.ZRNKREDITORColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public decimal BRRATADOSADA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNKrediti.BRRATADOSADAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.BRRATADOSADAColumn] = value;
                }
            }

            public DateTime DATUMUGOVORA
            {
                get
                {
                    return Conversions.ToDate(this[this.tableOBRACUNKrediti.DATUMUGOVORAColumn]);
                }
                set
                {
                    this[this.tableOBRACUNKrediti.DATUMUGOVORAColumn] = value;
                }
            }

            public decimal DOSADAOBUSTAVLJENO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNKrediti.DOSADAOBUSTAVLJENOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.DOSADAOBUSTAVLJENOColumn] = value;
                }
            }

            public int IDKREDITOR
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBRACUNKrediti.IDKREDITORColumn]);
                }
                set
                {
                    this[this.tableOBRACUNKrediti.IDKREDITORColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableOBRACUNKrediti.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableOBRACUNKrediti.IDOBRACUNColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBRACUNKrediti.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableOBRACUNKrediti.IDRADNIKColumn] = value;
                }
            }

            public string NAZIVKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.NAZIVKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.NAZIVKREDITORColumn] = value;
                }
            }

            public decimal OBRACUNATIKUNSKIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNKrediti.OBRACUNATIKUNSKIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBRACUNATIKUNSKIIZNOSColumn] = value;
                }
            }

            public decimal OBRIZNOSRATEKREDITOR
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNKrediti.OBRIZNOSRATEKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBRIZNOSRATEKREDITORColumn] = value;
                }
            }

            public string OBRMOKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.OBRMOKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBRMOKREDITORColumn] = value;
                }
            }

            public string OBRMZKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.OBRMZKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBRMZKREDITORColumn] = value;
                }
            }

            public string OBROPISPLACANJAKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.OBROPISPLACANJAKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBROPISPLACANJAKREDITORColumn] = value;
                }
            }

            public string OBRPOKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.OBRPOKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBRPOKREDITORColumn] = value;
                }
            }

            public string OBRPZKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.OBRPZKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBRPZKREDITORColumn] = value;
                }
            }

            public string OBRSIFRAOPISAPLACANJAKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.OBRSIFRAOPISAPLACANJAKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                      
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.OBRSIFRAOPISAPLACANJAKREDITORColumn] = value;
                }
            }

            public string PRIMATELJKREDITOR1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR1Column] = value;
                }
            }

            public string PRIMATELJKREDITOR2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR2Column] = value;
                }
            }

            public string PRIMATELJKREDITOR3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.PRIMATELJKREDITOR3Column] = value;
                }
            }

            public decimal UKUPNIZNOSKREDITA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNKrediti.UKUPNIZNOSKREDITAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.UKUPNIZNOSKREDITAColumn] = value;
                }
            }

            public string VBDIKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.VBDIKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.VBDIKREDITORColumn] = value;
                }
            }

            public decimal VECOTPLACENOBROJRATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNKrediti.VECOTPLACENOBROJRATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.VECOTPLACENOBROJRATAColumn] = value;
                }
            }

            public decimal VECOTPLACENOUKUPNIIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNKrediti.VECOTPLACENOUKUPNIIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.VECOTPLACENOUKUPNIIZNOSColumn] = value;
                }
            }

            public string ZRNKREDITOR
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNKrediti.ZRNKREDITORColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNKrediti.ZRNKREDITORColumn] = value;
                }
            }
        }

        public class OBRACUNKreditiRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.OBRACUNKreditiRow eventRow;

            public OBRACUNKreditiRowChangeEvent(OBRACUNDataSet.OBRACUNKreditiRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.OBRACUNKreditiRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OBRACUNKreditiRowChangeEventHandler(object sender, OBRACUNDataSet.OBRACUNKreditiRowChangeEvent e);

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDOBRACUNIZUZECE;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIZNOSIZUZECA;
            private DataColumn columnMOIZUZECE;
            private DataColumn columnMZIZUZECE;
            private DataColumn columnOPISPLACANJAIZUZECE;
            private DataColumn columnPOIZUZECE;
            private DataColumn columnPRIMATELJIZUZECE1;
            private DataColumn columnPRIMATELJIZUZECE2;
            private DataColumn columnPRIMATELJIZUZECE3;
            private DataColumn columnPZIZUZECE;
            private DataColumn columnSIFRAOPISAPLACANJAIZUZECE;
            private DataColumn columnTEKUCIIZUZECE;
            private DataColumn columnVBDIIZUZECE;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunIzuzeceRowChanged;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunIzuzeceRowChanging;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunIzuzeceRowDeleted;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunIzuzeceRowDeleting;

            public OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable()
            {
                this.TableName = "OBRACUNOBRACUNLevel1ObracunIzuzece";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOBRACUNOBRACUNLevel1ObracunIzuzeceRow(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow AddOBRACUNOBRACUNLevel1ObracunIzuzeceRow(string iDOBRACUN, int iDRADNIK, string pRIMATELJIZUZECE1, string pRIMATELJIZUZECE2, string pRIMATELJIZUZECE3, string sIFRAOPISAPLACANJAIZUZECE, string oPISPLACANJAIZUZECE, string vBDIIZUZECE, string tEKUCIIZUZECE, string mOIZUZECE, string pOIZUZECE, string mZIZUZECE, string pZIZUZECE, decimal iZNOSIZUZECA)
            {
                OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow row = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["PRIMATELJIZUZECE1"] = pRIMATELJIZUZECE1;
                row["PRIMATELJIZUZECE2"] = pRIMATELJIZUZECE2;
                row["PRIMATELJIZUZECE3"] = pRIMATELJIZUZECE3;
                row["SIFRAOPISAPLACANJAIZUZECE"] = sIFRAOPISAPLACANJAIZUZECE;
                row["OPISPLACANJAIZUZECE"] = oPISPLACANJAIZUZECE;
                row["VBDIIZUZECE"] = vBDIIZUZECE;
                row["TEKUCIIZUZECE"] = tEKUCIIZUZECE;
                row["MOIZUZECE"] = mOIZUZECE;
                row["POIZUZECE"] = pOIZUZECE;
                row["MZIZUZECE"] = mZIZUZECE;
                row["PZIZUZECE"] = pZIZUZECE;
                row["IZNOSIZUZECA"] = iZNOSIZUZECA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable table = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow FindByIDOBRACUNIDRADNIKIDOBRACUNIZUZECE(string iDOBRACUN, int iDRADNIK, Guid iDOBRACUNIZUZECE)
            {
                return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDOBRACUNIZUZECE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDOBRACUNIZUZECE = new DataColumn("IDOBRACUNIZUZECE", typeof(Guid), "", MappingType.Element);
                this.columnIDOBRACUNIZUZECE.AllowDBNull = false;
                this.columnIDOBRACUNIZUZECE.Caption = "IDOBRACUNIZUZECE";
                this.columnIDOBRACUNIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("AutoGenerated", "true");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("DeklaritType", "guid");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Description", "IDOBRACUNIZUZECE");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Length", "32");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUNIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUNIZUZECE");
                this.Columns.Add(this.columnIDOBRACUNIZUZECE);
                this.columnPRIMATELJIZUZECE1 = new DataColumn("PRIMATELJIZUZECE1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJIZUZECE1.AllowDBNull = false;
                this.columnPRIMATELJIZUZECE1.Caption = "PRIMATELJIZUZEC E1";
                this.columnPRIMATELJIZUZECE1.MaxLength = 20;
                this.columnPRIMATELJIZUZECE1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Description", "PRIMATELJIZUZEC E1");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJIZUZECE1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJIZUZECE1");
                this.Columns.Add(this.columnPRIMATELJIZUZECE1);
                this.columnPRIMATELJIZUZECE2 = new DataColumn("PRIMATELJIZUZECE2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJIZUZECE2.AllowDBNull = false;
                this.columnPRIMATELJIZUZECE2.Caption = "PRIMATELJIZUZEC E2";
                this.columnPRIMATELJIZUZECE2.MaxLength = 20;
                this.columnPRIMATELJIZUZECE2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Description", "PRIMATELJIZUZEC E2");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJIZUZECE2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJIZUZECE2");
                this.Columns.Add(this.columnPRIMATELJIZUZECE2);
                this.columnPRIMATELJIZUZECE3 = new DataColumn("PRIMATELJIZUZECE3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJIZUZECE3.AllowDBNull = true;
                this.columnPRIMATELJIZUZECE3.Caption = "PRIMATELJIZUZEC E3";
                this.columnPRIMATELJIZUZECE3.MaxLength = 20;
                this.columnPRIMATELJIZUZECE3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Description", "PRIMATELJIZUZEC E3");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJIZUZECE3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJIZUZECE3");
                this.Columns.Add(this.columnPRIMATELJIZUZECE3);
                this.columnSIFRAOPISAPLACANJAIZUZECE = new DataColumn("SIFRAOPISAPLACANJAIZUZECE", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAIZUZECE.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAIZUZECE.Caption = "SIFRAOPISAPLACANJAIZUZECE";
                this.columnSIFRAOPISAPLACANJAIZUZECE.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Description", "SIFRAOPISAPLACANJAIZUZECE");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAIZUZECE");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAIZUZECE);
                this.columnOPISPLACANJAIZUZECE = new DataColumn("OPISPLACANJAIZUZECE", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAIZUZECE.AllowDBNull = false;
                this.columnOPISPLACANJAIZUZECE.Caption = "OPISPLACANJAIZUZECE";
                this.columnOPISPLACANJAIZUZECE.MaxLength = 0x24;
                this.columnOPISPLACANJAIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Description", "OPISPLACANJAIZUZECE");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAIZUZECE");
                this.Columns.Add(this.columnOPISPLACANJAIZUZECE);
                this.columnVBDIIZUZECE = new DataColumn("VBDIIZUZECE", typeof(string), "", MappingType.Element);
                this.columnVBDIIZUZECE.AllowDBNull = false;
                this.columnVBDIIZUZECE.Caption = "VBDIIZUZECE";
                this.columnVBDIIZUZECE.MaxLength = 7;
                this.columnVBDIIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Description", "VBDIIZUZECE");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Length", "7");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "VBDIIZUZECE");
                this.Columns.Add(this.columnVBDIIZUZECE);

                this.columnTEKUCIIZUZECE = new DataColumn("TEKUCIIZUZECE", typeof(string), "", MappingType.Element);
                this.columnTEKUCIIZUZECE.AllowDBNull = false;
                this.columnTEKUCIIZUZECE.Caption = "IBANIZUZECE";
                this.columnTEKUCIIZUZECE.MaxLength = 25;
                this.columnTEKUCIIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Description", "IBANIZUZECE");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Length", "25");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTEKUCIIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "TEKUCIIZUZECE");
                this.Columns.Add(this.columnTEKUCIIZUZECE);

                this.columnMOIZUZECE = new DataColumn("MOIZUZECE", typeof(string), "", MappingType.Element);
                this.columnMOIZUZECE.AllowDBNull = false;
                this.columnMOIZUZECE.Caption = "MOIZUZECE";
                this.columnMOIZUZECE.MaxLength = 2;
                this.columnMOIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnMOIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOIZUZECE.ExtendedProperties.Add("Description", "MOIZUZECE");
                this.columnMOIZUZECE.ExtendedProperties.Add("Length", "2");
                this.columnMOIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnMOIZUZECE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "MOIZUZECE");
                this.Columns.Add(this.columnMOIZUZECE);
                this.columnPOIZUZECE = new DataColumn("POIZUZECE", typeof(string), "", MappingType.Element);
                this.columnPOIZUZECE.AllowDBNull = true;
                this.columnPOIZUZECE.Caption = "POIZUZECE";
                this.columnPOIZUZECE.MaxLength = 0x16;
                this.columnPOIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOIZUZECE.ExtendedProperties.Add("Description", "POIZUZECE");
                this.columnPOIZUZECE.ExtendedProperties.Add("Length", "22");
                this.columnPOIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnPOIZUZECE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "POIZUZECE");
                this.Columns.Add(this.columnPOIZUZECE);
                this.columnMZIZUZECE = new DataColumn("MZIZUZECE", typeof(string), "", MappingType.Element);
                this.columnMZIZUZECE.AllowDBNull = true;
                this.columnMZIZUZECE.Caption = "MZIZUZECE";
                this.columnMZIZUZECE.MaxLength = 2;
                this.columnMZIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnMZIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZIZUZECE.ExtendedProperties.Add("Description", "MZIZUZECE");
                this.columnMZIZUZECE.ExtendedProperties.Add("Length", "2");
                this.columnMZIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnMZIZUZECE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "MZIZUZECE");
                this.Columns.Add(this.columnMZIZUZECE);
                this.columnPZIZUZECE = new DataColumn("PZIZUZECE", typeof(string), "", MappingType.Element);
                this.columnPZIZUZECE.AllowDBNull = true;
                this.columnPZIZUZECE.Caption = "PZIZUZECE";
                this.columnPZIZUZECE.MaxLength = 0x16;
                this.columnPZIZUZECE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZIZUZECE.ExtendedProperties.Add("IsKey", "false");
                this.columnPZIZUZECE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZIZUZECE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZIZUZECE.ExtendedProperties.Add("Description", "PZIZUZECE");
                this.columnPZIZUZECE.ExtendedProperties.Add("Length", "22");
                this.columnPZIZUZECE.ExtendedProperties.Add("Decimals", "0");
                this.columnPZIZUZECE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZIZUZECE.ExtendedProperties.Add("Deklarit.InternalName", "PZIZUZECE");
                this.Columns.Add(this.columnPZIZUZECE);
                this.columnIZNOSIZUZECA = new DataColumn("IZNOSIZUZECA", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSIZUZECA.AllowDBNull = false;
                this.columnIZNOSIZUZECA.Caption = "IZNOSIZUZECA";
                this.columnIZNOSIZUZECA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Description", "IZNOSIZUZECA");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSIZUZECA.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSIZUZECA");
                this.Columns.Add(this.columnIZNOSIZUZECA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDOBRACUNIZUZECE };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "ObracunIzuzece");
                this.ExtendedProperties.Add("Description", "ObracunIzuzece");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDOBRACUNIZUZECE = this.Columns["IDOBRACUNIZUZECE"];
                this.columnPRIMATELJIZUZECE1 = this.Columns["PRIMATELJIZUZECE1"];
                this.columnPRIMATELJIZUZECE2 = this.Columns["PRIMATELJIZUZECE2"];
                this.columnPRIMATELJIZUZECE3 = this.Columns["PRIMATELJIZUZECE3"];
                this.columnSIFRAOPISAPLACANJAIZUZECE = this.Columns["SIFRAOPISAPLACANJAIZUZECE"];
                this.columnOPISPLACANJAIZUZECE = this.Columns["OPISPLACANJAIZUZECE"];
                this.columnVBDIIZUZECE = this.Columns["VBDIIZUZECE"];
                this.columnTEKUCIIZUZECE = this.Columns["TEKUCIIZUZECE"];
                this.columnMOIZUZECE = this.Columns["MOIZUZECE"];
                this.columnPOIZUZECE = this.Columns["POIZUZECE"];
                this.columnMZIZUZECE = this.Columns["MZIZUZECE"];
                this.columnPZIZUZECE = this.Columns["PZIZUZECE"];
                this.columnIZNOSIZUZECA = this.Columns["IZNOSIZUZECA"];
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow NewOBRACUNOBRACUNLevel1ObracunIzuzeceRow()
            {
                return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChanged != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChanged;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChanging != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChanging;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowDeleted != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowDeleting != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunIzuzeceRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOBRACUNOBRACUNLevel1ObracunIzuzeceRow(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDOBRACUNIZUZECEColumn
            {
                get
                {
                    return this.columnIDOBRACUNIZUZECE;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSIZUZECAColumn
            {
                get
                {
                    return this.columnIZNOSIZUZECA;
                }
            }

            public DataColumn MOIZUZECEColumn
            {
                get
                {
                    return this.columnMOIZUZECE;
                }
            }

            public DataColumn MZIZUZECEColumn
            {
                get
                {
                    return this.columnMZIZUZECE;
                }
            }

            public DataColumn OPISPLACANJAIZUZECEColumn
            {
                get
                {
                    return this.columnOPISPLACANJAIZUZECE;
                }
            }

            public DataColumn POIZUZECEColumn
            {
                get
                {
                    return this.columnPOIZUZECE;
                }
            }

            public DataColumn PRIMATELJIZUZECE1Column
            {
                get
                {
                    return this.columnPRIMATELJIZUZECE1;
                }
            }

            public DataColumn PRIMATELJIZUZECE2Column
            {
                get
                {
                    return this.columnPRIMATELJIZUZECE2;
                }
            }

            public DataColumn PRIMATELJIZUZECE3Column
            {
                get
                {
                    return this.columnPRIMATELJIZUZECE3;
                }
            }

            public DataColumn PZIZUZECEColumn
            {
                get
                {
                    return this.columnPZIZUZECE;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAIZUZECEColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAIZUZECE;
                }
            }

            public DataColumn TEKUCIIZUZECEColumn
            {
                get
                {
                    return this.columnTEKUCIIZUZECE;
                }
            }

            public DataColumn VBDIIZUZECEColumn
            {
                get
                {
                    return this.columnVBDIIZUZECE;
                }
            }
        }

        public class OBRACUNOBRACUNLevel1ObracunIzuzeceRow : DataRow
        {
            private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable tableOBRACUNOBRACUNLevel1ObracunIzuzece;

            internal OBRACUNOBRACUNLevel1ObracunIzuzeceRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOBRACUNOBRACUNLevel1ObracunIzuzece = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceDataTable) this.Table;
                this.IDOBRACUNIZUZECE = Guid.NewGuid();
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece");
            }

            public bool IsIDOBRACUNIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDOBRACUNIZUZECEColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDOBRACUNColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDRADNIKColumn);
            }

            public bool IsIZNOSIZUZECANull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IZNOSIZUZECAColumn);
            }

            public bool IsMOIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MOIZUZECEColumn);
            }

            public bool IsMZIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MZIZUZECEColumn);
            }

            public bool IsOPISPLACANJAIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.OPISPLACANJAIZUZECEColumn);
            }

            public bool IsPOIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.POIZUZECEColumn);
            }

            public bool IsPRIMATELJIZUZECE1Null()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE1Column);
            }

            public bool IsPRIMATELJIZUZECE2Null()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE2Column);
            }

            public bool IsPRIMATELJIZUZECE3Null()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE3Column);
            }

            public bool IsPZIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PZIZUZECEColumn);
            }

            public bool IsSIFRAOPISAPLACANJAIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.SIFRAOPISAPLACANJAIZUZECEColumn);
            }

            public bool IsTEKUCIIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.TEKUCIIZUZECEColumn);
            }

            public bool IsVBDIIZUZECENull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.VBDIIZUZECEColumn);
            }

            public void SetIZNOSIZUZECANull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IZNOSIZUZECAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MOIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MZIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.OPISPLACANJAIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.POIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJIZUZECE1Null()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJIZUZECE2Null()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJIZUZECE3Null()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PZIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.SIFRAOPISAPLACANJAIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTEKUCIIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.TEKUCIIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIIZUZECENull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.VBDIIZUZECEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDOBRACUNColumn] = value;
                }
            }

            public Guid IDOBRACUNIZUZECE
            {
                get
                {
                    object obj1 = this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDOBRACUNIZUZECEColumn];
                    if (obj1 == null)
                    {
                        Guid guid2 = new Guid();
                        return guid2;
                    }
                    return (Guid) obj1;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDOBRACUNIZUZECEColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IDRADNIKColumn] = value;
                }
            }

            public decimal IZNOSIZUZECA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IZNOSIZUZECAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.IZNOSIZUZECAColumn] = value;
                }
            }

            public string MOIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MOIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MOIZUZECEColumn] = value;
                }
            }

            public string MZIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MZIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.MZIZUZECEColumn] = value;
                }
            }

            public string OPISPLACANJAIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.OPISPLACANJAIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.OPISPLACANJAIZUZECEColumn] = value;
                }
            }

            public string POIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.POIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.POIZUZECEColumn] = value;
                }
            }

            public string PRIMATELJIZUZECE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE1Column] = value;
                }
            }

            public string PRIMATELJIZUZECE2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE2Column] = value;
                }
            }

            public string PRIMATELJIZUZECE3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PRIMATELJIZUZECE3Column] = value;
                }
            }

            public string PZIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PZIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.PZIZUZECEColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.SIFRAOPISAPLACANJAIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.SIFRAOPISAPLACANJAIZUZECEColumn] = value;
                }
            }

            public string TEKUCIIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.TEKUCIIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.TEKUCIIZUZECEColumn] = value;
                }
            }

            public string VBDIIZUZECE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.VBDIIZUZECEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunIzuzece.VBDIIZUZECEColumn] = value;
                }
            }
        }

        public class OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow eventRow;

            public OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEvent(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEventHandler(object sender, OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRowChangeEvent e);

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunKrizniDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDKRIZNIPOREZ;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDRADNIK;
            private DataColumn columnKRIZNISTOPA;
            private DataColumn columnMOKRIZNI;
            private DataColumn columnMZKRIZNI;
            private DataColumn columnNAZIVKRIZNIPOREZ;
            private DataColumn columnOPISPLACANJAKRIZNI;
            private DataColumn columnOSNOVICAKRIZNI;
            private DataColumn columnOSNOVICAPRETHODNA;
            private DataColumn columnOSNOVICAUKUPNA;
            private DataColumn columnPOKRIZNI;
            private DataColumn columnPOREZKRIZNI;
            private DataColumn columnPOREZPRETHODNI;
            private DataColumn columnPOREZUKUPNO;
            private DataColumn columnPRIMATELJKRIZNI1;
            private DataColumn columnPRIMATELJKRIZNI2;
            private DataColumn columnPRIMATELJKRIZNI3;
            private DataColumn columnPZKRIZNI;
            private DataColumn columnSIFRAOPISAPLACANJAKRIZNI;
            private DataColumn columnVBDIKRIZNI;
            private DataColumn columnZRNKRIZNI;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunKrizniRowChanged;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunKrizniRowChanging;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunKrizniRowDeleted;

            public event OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler OBRACUNOBRACUNLevel1ObracunKrizniRowDeleting;

            public OBRACUNOBRACUNLevel1ObracunKrizniDataTable()
            {
                this.TableName = "OBRACUNOBRACUNLevel1ObracunKrizni";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OBRACUNOBRACUNLevel1ObracunKrizniDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected OBRACUNOBRACUNLevel1ObracunKrizniDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOBRACUNOBRACUNLevel1ObracunKrizniRow(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow AddOBRACUNOBRACUNLevel1ObracunKrizniRow(string iDOBRACUN, int iDRADNIK, int iDKRIZNIPOREZ, decimal oSNOVICAKRIZNI, decimal pOREZKRIZNI, decimal oSNOVICAPRETHODNA, decimal oSNOVICAUKUPNA, decimal pOREZPRETHODNI, decimal pOREZUKUPNO)
            {
                OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow row = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["IDKRIZNIPOREZ"] = iDKRIZNIPOREZ;
                row["OSNOVICAKRIZNI"] = oSNOVICAKRIZNI;
                row["POREZKRIZNI"] = pOREZKRIZNI;
                row["OSNOVICAPRETHODNA"] = oSNOVICAPRETHODNA;
                row["OSNOVICAUKUPNA"] = oSNOVICAUKUPNA;
                row["POREZPRETHODNI"] = pOREZPRETHODNI;
                row["POREZUKUPNO"] = pOREZUKUPNO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniDataTable table = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow FindByIDOBRACUNIDRADNIKIDKRIZNIPOREZ(string iDOBRACUN, int iDRADNIK, int iDKRIZNIPOREZ)
            {
                return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDKRIZNIPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDKRIZNIPOREZ = new DataColumn("IDKRIZNIPOREZ", typeof(int), "", MappingType.Element);
                this.columnIDKRIZNIPOREZ.AllowDBNull = false;
                this.columnIDKRIZNIPOREZ.Caption = "IDKRIZNIPOREZ";
                this.columnIDKRIZNIPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Description", "IDKRIZNIPOREZ");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Length", "5");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "IDKRIZNIPOREZ");
                this.Columns.Add(this.columnIDKRIZNIPOREZ);
                this.columnNAZIVKRIZNIPOREZ = new DataColumn("NAZIVKRIZNIPOREZ", typeof(string), "", MappingType.Element);
                this.columnNAZIVKRIZNIPOREZ.AllowDBNull = false;
                this.columnNAZIVKRIZNIPOREZ.Caption = "NAZIVKRIZNIPOREZ";
                this.columnNAZIVKRIZNIPOREZ.MaxLength = 50;
                this.columnNAZIVKRIZNIPOREZ.DefaultValue = "";
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Description", "NAZIVKRIZNIPOREZ");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKRIZNIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKRIZNIPOREZ");
                this.Columns.Add(this.columnNAZIVKRIZNIPOREZ);
                this.columnKRIZNISTOPA = new DataColumn("KRIZNISTOPA", typeof(decimal), "", MappingType.Element);
                this.columnKRIZNISTOPA.AllowDBNull = false;
                this.columnKRIZNISTOPA.Caption = "KRIZNISTOPA";
                this.columnKRIZNISTOPA.DefaultValue = 0;
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("IsKey", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Description", "KRIZNISTOPA");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Length", "5");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Decimals", "2");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKRIZNISTOPA.ExtendedProperties.Add("Deklarit.InternalName", "KRIZNISTOPA");
                this.Columns.Add(this.columnKRIZNISTOPA);
                this.columnMOKRIZNI = new DataColumn("MOKRIZNI", typeof(string), "", MappingType.Element);
                this.columnMOKRIZNI.AllowDBNull = false;
                this.columnMOKRIZNI.Caption = "MOKRIZNI";
                this.columnMOKRIZNI.MaxLength = 2;
                this.columnMOKRIZNI.DefaultValue = "";
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMOKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOKRIZNI.ExtendedProperties.Add("Description", "MOKRIZNI");
                this.columnMOKRIZNI.ExtendedProperties.Add("Length", "2");
                this.columnMOKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnMOKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "MOKRIZNI");
                this.Columns.Add(this.columnMOKRIZNI);
                this.columnPOKRIZNI = new DataColumn("POKRIZNI", typeof(string), "", MappingType.Element);
                this.columnPOKRIZNI.AllowDBNull = false;
                this.columnPOKRIZNI.Caption = "POKRIZNI";
                this.columnPOKRIZNI.MaxLength = 0x16;
                this.columnPOKRIZNI.DefaultValue = "";
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOKRIZNI.ExtendedProperties.Add("Description", "POKRIZNI");
                this.columnPOKRIZNI.ExtendedProperties.Add("Length", "22");
                this.columnPOKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnPOKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POKRIZNI");
                this.Columns.Add(this.columnPOKRIZNI);
                this.columnMZKRIZNI = new DataColumn("MZKRIZNI", typeof(string), "", MappingType.Element);
                this.columnMZKRIZNI.AllowDBNull = true;
                this.columnMZKRIZNI.Caption = "MZKRIZNI";
                this.columnMZKRIZNI.MaxLength = 2;
                this.columnMZKRIZNI.DefaultValue = "";
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnMZKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZKRIZNI.ExtendedProperties.Add("Description", "MZKRIZNI");
                this.columnMZKRIZNI.ExtendedProperties.Add("Length", "2");
                this.columnMZKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnMZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "MZKRIZNI");
                this.Columns.Add(this.columnMZKRIZNI);
                this.columnPZKRIZNI = new DataColumn("PZKRIZNI", typeof(string), "", MappingType.Element);
                this.columnPZKRIZNI.AllowDBNull = true;
                this.columnPZKRIZNI.Caption = "PZKRIZNI";
                this.columnPZKRIZNI.MaxLength = 0x16;
                this.columnPZKRIZNI.DefaultValue = "";
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPZKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZKRIZNI.ExtendedProperties.Add("Description", "PZKRIZNI");
                this.columnPZKRIZNI.ExtendedProperties.Add("Length", "22");
                this.columnPZKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnPZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "PZKRIZNI");
                this.Columns.Add(this.columnPZKRIZNI);
                this.columnPRIMATELJKRIZNI1 = new DataColumn("PRIMATELJKRIZNI1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKRIZNI1.AllowDBNull = false;
                this.columnPRIMATELJKRIZNI1.Caption = "PRIMATELJKRIZNI";
                this.columnPRIMATELJKRIZNI1.MaxLength = 20;
                this.columnPRIMATELJKRIZNI1.DefaultValue = "";
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Description", "PRIMATELJKRIZNI");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKRIZNI1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKRIZNI1");
                this.Columns.Add(this.columnPRIMATELJKRIZNI1);
                this.columnPRIMATELJKRIZNI2 = new DataColumn("PRIMATELJKRIZNI2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKRIZNI2.AllowDBNull = false;
                this.columnPRIMATELJKRIZNI2.Caption = "PRIMATELJKRIZN I2";
                this.columnPRIMATELJKRIZNI2.MaxLength = 20;
                this.columnPRIMATELJKRIZNI2.DefaultValue = "";
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Description", "PRIMATELJKRIZN I2");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKRIZNI2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKRIZNI2");
                this.Columns.Add(this.columnPRIMATELJKRIZNI2);
                this.columnPRIMATELJKRIZNI3 = new DataColumn("PRIMATELJKRIZNI3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJKRIZNI3.AllowDBNull = false;
                this.columnPRIMATELJKRIZNI3.Caption = "PRIMATELJKRIZN I3";
                this.columnPRIMATELJKRIZNI3.MaxLength = 20;
                this.columnPRIMATELJKRIZNI3.DefaultValue = "";
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Description", "PRIMATELJKRIZN I3");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJKRIZNI3");
                this.Columns.Add(this.columnPRIMATELJKRIZNI3);
                this.columnSIFRAOPISAPLACANJAKRIZNI = new DataColumn("SIFRAOPISAPLACANJAKRIZNI", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAKRIZNI.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAKRIZNI.Caption = "SIFRAOPISAPLACANJAKRIZNI";
                this.columnSIFRAOPISAPLACANJAKRIZNI.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAKRIZNI.DefaultValue = "";
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Description", "SIFRAOPISAPLACANJAKRIZNI");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAKRIZNI");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAKRIZNI);
                this.columnOPISPLACANJAKRIZNI = new DataColumn("OPISPLACANJAKRIZNI", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAKRIZNI.AllowDBNull = false;
                this.columnOPISPLACANJAKRIZNI.Caption = "OPISPLACANJAKRIZNI";
                this.columnOPISPLACANJAKRIZNI.MaxLength = 0x24;
                this.columnOPISPLACANJAKRIZNI.DefaultValue = "";
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Description", "OPISPLACANJAKRIZNI");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAKRIZNI");
                this.Columns.Add(this.columnOPISPLACANJAKRIZNI);
                this.columnVBDIKRIZNI = new DataColumn("VBDIKRIZNI", typeof(string), "", MappingType.Element);
                this.columnVBDIKRIZNI.AllowDBNull = false;
                this.columnVBDIKRIZNI.Caption = "VBDIKRIZNI";
                this.columnVBDIKRIZNI.MaxLength = 7;
                this.columnVBDIKRIZNI.DefaultValue = "";
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Description", "VBDIKRIZNI");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Length", "7");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "VBDIKRIZNI");
                this.Columns.Add(this.columnVBDIKRIZNI);
                this.columnZRNKRIZNI = new DataColumn("ZRNKRIZNI", typeof(string), "", MappingType.Element);
                this.columnZRNKRIZNI.AllowDBNull = false;
                this.columnZRNKRIZNI.Caption = "ZRNKRIZNI";
                this.columnZRNKRIZNI.MaxLength = 10;
                this.columnZRNKRIZNI.DefaultValue = "";
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNKRIZNI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Description", "ZRNKRIZNI");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Length", "10");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "ZRNKRIZNI");
                this.Columns.Add(this.columnZRNKRIZNI);
                this.columnOSNOVICAKRIZNI = new DataColumn("OSNOVICAKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAKRIZNI.AllowDBNull = false;
                this.columnOSNOVICAKRIZNI.Caption = "OSNOVICAKRIZNI";
                this.columnOSNOVICAKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Description", "OSNOVICAKRIZNI");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAKRIZNI");
                this.Columns.Add(this.columnOSNOVICAKRIZNI);
                this.columnPOREZKRIZNI = new DataColumn("POREZKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnPOREZKRIZNI.AllowDBNull = false;
                this.columnPOREZKRIZNI.Caption = "POREZKRIZNI";
                this.columnPOREZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Description", "POREZKRIZNI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "POREZKRIZNI");
                this.Columns.Add(this.columnPOREZKRIZNI);
                this.columnOSNOVICAPRETHODNA = new DataColumn("OSNOVICAPRETHODNA", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAPRETHODNA.AllowDBNull = false;
                this.columnOSNOVICAPRETHODNA.Caption = "OSNOVICAPRETHODNA";
                this.columnOSNOVICAPRETHODNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Description", "OSNOVICAPRETHODNA");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAPRETHODNA");
                this.Columns.Add(this.columnOSNOVICAPRETHODNA);
                this.columnOSNOVICAUKUPNA = new DataColumn("OSNOVICAUKUPNA", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAUKUPNA.AllowDBNull = false;
                this.columnOSNOVICAUKUPNA.Caption = "OSNOVICAUKUPNA";
                this.columnOSNOVICAUKUPNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Description", "OSNOVICAUKUPNA");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAUKUPNA");
                this.Columns.Add(this.columnOSNOVICAUKUPNA);
                this.columnPOREZPRETHODNI = new DataColumn("POREZPRETHODNI", typeof(decimal), "", MappingType.Element);
                this.columnPOREZPRETHODNI.AllowDBNull = false;
                this.columnPOREZPRETHODNI.Caption = "POREZPRETHODNI";
                this.columnPOREZPRETHODNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Description", "POREZPRETHODNI");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Length", "12");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.InternalName", "POREZPRETHODNI");
                this.Columns.Add(this.columnPOREZPRETHODNI);
                this.columnPOREZUKUPNO = new DataColumn("POREZUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnPOREZUKUPNO.AllowDBNull = false;
                this.columnPOREZUKUPNO.Caption = "POREZUKUPNO";
                this.columnPOREZUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Description", "POREZUKUPNO");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "POREZUKUPNO");
                this.Columns.Add(this.columnPOREZUKUPNO);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDKRIZNIPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "ObracunKrizni");
                this.ExtendedProperties.Add("Description", "ObracunKrizni");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDKRIZNIPOREZ = this.Columns["IDKRIZNIPOREZ"];
                this.columnNAZIVKRIZNIPOREZ = this.Columns["NAZIVKRIZNIPOREZ"];
                this.columnKRIZNISTOPA = this.Columns["KRIZNISTOPA"];
                this.columnMOKRIZNI = this.Columns["MOKRIZNI"];
                this.columnPOKRIZNI = this.Columns["POKRIZNI"];
                this.columnMZKRIZNI = this.Columns["MZKRIZNI"];
                this.columnPZKRIZNI = this.Columns["PZKRIZNI"];
                this.columnPRIMATELJKRIZNI1 = this.Columns["PRIMATELJKRIZNI1"];
                this.columnPRIMATELJKRIZNI2 = this.Columns["PRIMATELJKRIZNI2"];
                this.columnPRIMATELJKRIZNI3 = this.Columns["PRIMATELJKRIZNI3"];
                this.columnSIFRAOPISAPLACANJAKRIZNI = this.Columns["SIFRAOPISAPLACANJAKRIZNI"];
                this.columnOPISPLACANJAKRIZNI = this.Columns["OPISPLACANJAKRIZNI"];
                this.columnVBDIKRIZNI = this.Columns["VBDIKRIZNI"];
                this.columnZRNKRIZNI = this.Columns["ZRNKRIZNI"];
                this.columnOSNOVICAKRIZNI = this.Columns["OSNOVICAKRIZNI"];
                this.columnPOREZKRIZNI = this.Columns["POREZKRIZNI"];
                this.columnOSNOVICAPRETHODNA = this.Columns["OSNOVICAPRETHODNA"];
                this.columnOSNOVICAUKUPNA = this.Columns["OSNOVICAUKUPNA"];
                this.columnPOREZPRETHODNI = this.Columns["POREZPRETHODNI"];
                this.columnPOREZUKUPNO = this.Columns["POREZUKUPNO"];
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow NewOBRACUNOBRACUNLevel1ObracunKrizniRow()
            {
                return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OBRACUNOBRACUNLevel1ObracunKrizniRowChanged != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunKrizniRowChanged;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OBRACUNOBRACUNLevel1ObracunKrizniRowChanging != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunKrizniRowChanging;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.OBRACUNOBRACUNLevel1ObracunKrizniRowDeleted != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunKrizniRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OBRACUNOBRACUNLevel1ObracunKrizniRowDeleting != null)
                {
                    OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler handler = this.OBRACUNOBRACUNLevel1ObracunKrizniRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEvent((OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOBRACUNOBRACUNLevel1ObracunKrizniRow(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDKRIZNIPOREZColumn
            {
                get
                {
                    return this.columnIDKRIZNIPOREZ;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow) this.Rows[index];
                }
            }

            public DataColumn KRIZNISTOPAColumn
            {
                get
                {
                    return this.columnKRIZNISTOPA;
                }
            }

            public DataColumn MOKRIZNIColumn
            {
                get
                {
                    return this.columnMOKRIZNI;
                }
            }

            public DataColumn MZKRIZNIColumn
            {
                get
                {
                    return this.columnMZKRIZNI;
                }
            }

            public DataColumn NAZIVKRIZNIPOREZColumn
            {
                get
                {
                    return this.columnNAZIVKRIZNIPOREZ;
                }
            }

            public DataColumn OPISPLACANJAKRIZNIColumn
            {
                get
                {
                    return this.columnOPISPLACANJAKRIZNI;
                }
            }

            public DataColumn OSNOVICAKRIZNIColumn
            {
                get
                {
                    return this.columnOSNOVICAKRIZNI;
                }
            }

            public DataColumn OSNOVICAPRETHODNAColumn
            {
                get
                {
                    return this.columnOSNOVICAPRETHODNA;
                }
            }

            public DataColumn OSNOVICAUKUPNAColumn
            {
                get
                {
                    return this.columnOSNOVICAUKUPNA;
                }
            }

            public DataColumn POKRIZNIColumn
            {
                get
                {
                    return this.columnPOKRIZNI;
                }
            }

            public DataColumn POREZKRIZNIColumn
            {
                get
                {
                    return this.columnPOREZKRIZNI;
                }
            }

            public DataColumn POREZPRETHODNIColumn
            {
                get
                {
                    return this.columnPOREZPRETHODNI;
                }
            }

            public DataColumn POREZUKUPNOColumn
            {
                get
                {
                    return this.columnPOREZUKUPNO;
                }
            }

            public DataColumn PRIMATELJKRIZNI1Column
            {
                get
                {
                    return this.columnPRIMATELJKRIZNI1;
                }
            }

            public DataColumn PRIMATELJKRIZNI2Column
            {
                get
                {
                    return this.columnPRIMATELJKRIZNI2;
                }
            }

            public DataColumn PRIMATELJKRIZNI3Column
            {
                get
                {
                    return this.columnPRIMATELJKRIZNI3;
                }
            }

            public DataColumn PZKRIZNIColumn
            {
                get
                {
                    return this.columnPZKRIZNI;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAKRIZNIColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAKRIZNI;
                }
            }

            public DataColumn VBDIKRIZNIColumn
            {
                get
                {
                    return this.columnVBDIKRIZNI;
                }
            }

            public DataColumn ZRNKRIZNIColumn
            {
                get
                {
                    return this.columnZRNKRIZNI;
                }
            }
        }

        public class OBRACUNOBRACUNLevel1ObracunKrizniRow : DataRow
        {
            private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniDataTable tableOBRACUNOBRACUNLevel1ObracunKrizni;

            internal OBRACUNOBRACUNLevel1ObracunKrizniRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOBRACUNOBRACUNLevel1ObracunKrizni = (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni");
            }

            public bool IsIDKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDKRIZNIPOREZColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDOBRACUNColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDRADNIKColumn);
            }

            public bool IsKRIZNISTOPANull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.KRIZNISTOPAColumn);
            }

            public bool IsMOKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MOKRIZNIColumn);
            }

            public bool IsMZKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MZKRIZNIColumn);
            }

            public bool IsNAZIVKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.NAZIVKRIZNIPOREZColumn);
            }

            public bool IsOPISPLACANJAKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OPISPLACANJAKRIZNIColumn);
            }

            public bool IsOSNOVICAKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAKRIZNIColumn);
            }

            public bool IsOSNOVICAPRETHODNANull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAPRETHODNAColumn);
            }

            public bool IsOSNOVICAUKUPNANull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAUKUPNAColumn);
            }

            public bool IsPOKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POKRIZNIColumn);
            }

            public bool IsPOREZKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZKRIZNIColumn);
            }

            public bool IsPOREZPRETHODNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZPRETHODNIColumn);
            }

            public bool IsPOREZUKUPNONull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZUKUPNOColumn);
            }

            public bool IsPRIMATELJKRIZNI1Null()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI1Column);
            }

            public bool IsPRIMATELJKRIZNI2Null()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI2Column);
            }

            public bool IsPRIMATELJKRIZNI3Null()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI3Column);
            }

            public bool IsPZKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PZKRIZNIColumn);
            }

            public bool IsSIFRAOPISAPLACANJAKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.SIFRAOPISAPLACANJAKRIZNIColumn);
            }

            public bool IsVBDIKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.VBDIKRIZNIColumn);
            }

            public bool IsZRNKRIZNINull()
            {
                return this.IsNull(this.tableOBRACUNOBRACUNLevel1ObracunKrizni.ZRNKRIZNIColumn);
            }

            public void SetKRIZNISTOPANull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.KRIZNISTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MOKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKRIZNIPOREZNull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.NAZIVKRIZNIPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OPISPLACANJAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAPRETHODNANull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAPRETHODNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAUKUPNANull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAUKUPNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZPRETHODNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZPRETHODNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZUKUPNONull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI1Null()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI2Null()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI3Null()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.SIFRAOPISAPLACANJAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.VBDIKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNKRIZNINull()
            {
                this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.ZRNKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDKRIZNIPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDKRIZNIPOREZColumn]);
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDKRIZNIPOREZColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDOBRACUNColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.IDRADNIKColumn] = value;
                }
            }

            public decimal KRIZNISTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.KRIZNISTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.KRIZNISTOPAColumn] = value;
                }
            }

            public string MOKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MOKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MOKRIZNIColumn] = value;
                }
            }

            public string MZKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.MZKRIZNIColumn] = value;
                }
            }

            public string NAZIVKRIZNIPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.NAZIVKRIZNIPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.NAZIVKRIZNIPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OPISPLACANJAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OPISPLACANJAKRIZNIColumn] = value;
                }
            }

            public decimal OSNOVICAKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAKRIZNIColumn] = value;
                }
            }

            public decimal OSNOVICAPRETHODNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAPRETHODNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAPRETHODNAColumn] = value;
                }
            }

            public decimal OSNOVICAUKUPNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAUKUPNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.OSNOVICAUKUPNAColumn] = value;
                }
            }

            public string POKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POKRIZNIColumn] = value;
                }
            }

            public decimal POREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZKRIZNIColumn] = value;
                }
            }

            public decimal POREZPRETHODNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZPRETHODNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZPRETHODNIColumn] = value;
                }
            }

            public decimal POREZUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.POREZUKUPNOColumn] = value;
                }
            }

            public string PRIMATELJKRIZNI1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI1Column] = value;
                }
            }

            public string PRIMATELJKRIZNI2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI2Column] = value;
                }
            }

            public string PRIMATELJKRIZNI3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PRIMATELJKRIZNI3Column] = value;
                }
            }

            public string PZKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.PZKRIZNIColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.SIFRAOPISAPLACANJAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.SIFRAOPISAPLACANJAKRIZNIColumn] = value;
                }
            }

            public string VBDIKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.VBDIKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.VBDIKRIZNIColumn] = value;
                }
            }

            public string ZRNKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.ZRNKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNOBRACUNLevel1ObracunKrizni.ZRNKRIZNIColumn] = value;
                }
            }
        }

        public class OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow eventRow;

            public OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEvent(OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEventHandler(object sender, OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRowChangeEvent e);

        [Serializable]
        public class OBRACUNObustaveDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDOBUSTAVA;
            private DataColumn columnIDRADNIK;
            private DataColumn columnISPLACENOKASA;
            private DataColumn columnIZNOSOBUSTAVE;
            private DataColumn columnMOOBUSTAVA;
            private DataColumn columnMZOBUSTAVA;
            private DataColumn columnNAZIVOBUSTAVA;
            private DataColumn columnNAZIVVRSTAOBUSTAVE;
            private DataColumn columnOBRACUNATAOBUSTAVAUKUNAMA;
            private DataColumn columnOBUSTAVLJENODOSADA;
            private DataColumn columnOBUSTAVLJENODOSADABROJRATA;
            private DataColumn columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE;
            private DataColumn columnOPISPLACANJAOBUSTAVA;
            private DataColumn columnPOOBUSTAVA;
            private DataColumn columnPOSTOTAKOBUSTAVE;
            private DataColumn columnPRIMATELJOBUSTAVA1;
            private DataColumn columnPRIMATELJOBUSTAVA2;
            private DataColumn columnPRIMATELJOBUSTAVA3;
            private DataColumn columnPZOBUSTAVA;
            private DataColumn columnSALDOKASA;
            private DataColumn columnSIFRAOPISAPLACANJAOBUSTAVA;
            private DataColumn columnVBDIOBUSTAVA;
            private DataColumn columnVRSTAOBUSTAVE;
            private DataColumn columnZRNOBUSTAVA;

            public event OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler OBRACUNObustaveRowChanged;

            public event OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler OBRACUNObustaveRowChanging;

            public event OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler OBRACUNObustaveRowDeleted;

            public event OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler OBRACUNObustaveRowDeleting;

            public OBRACUNObustaveDataTable()
            {
                this.TableName = "OBRACUNObustave";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OBRACUNObustaveDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected OBRACUNObustaveDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOBRACUNObustaveRow(OBRACUNDataSet.OBRACUNObustaveRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.OBRACUNObustaveRow AddOBRACUNObustaveRow(string iDOBRACUN, int iDRADNIK, int iDOBUSTAVA, decimal iZNOSOBUSTAVE, decimal pOSTOTAKOBUSTAVE, decimal oBRACUNATAOBUSTAVAUKUNAMA, decimal iSPLACENOKASA, decimal sALDOKASA)
            {
                OBRACUNDataSet.OBRACUNObustaveRow row = (OBRACUNDataSet.OBRACUNObustaveRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["IDOBUSTAVA"] = iDOBUSTAVA;
                row["IZNOSOBUSTAVE"] = iZNOSOBUSTAVE;
                row["POSTOTAKOBUSTAVE"] = pOSTOTAKOBUSTAVE;
                row["OBRACUNATAOBUSTAVAUKUNAMA"] = oBRACUNATAOBUSTAVAUKUNAMA;
                row["ISPLACENOKASA"] = iSPLACENOKASA;
                row["SALDOKASA"] = sALDOKASA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.OBRACUNObustaveDataTable table = (OBRACUNDataSet.OBRACUNObustaveDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.OBRACUNObustaveRow FindByIDOBRACUNIDRADNIKIDOBUSTAVA(string iDOBRACUN, int iDRADNIK, int iDOBUSTAVA)
            {
                return (OBRACUNDataSet.OBRACUNObustaveRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDOBUSTAVA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.OBRACUNObustaveRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDOBUSTAVA = new DataColumn("IDOBUSTAVA", typeof(int), "", MappingType.Element);
                this.columnIDOBUSTAVA.AllowDBNull = false;
                this.columnIDOBUSTAVA.Caption = "Šifra obustave";
                this.columnIDOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Description", "Šifra obustave");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Length", "8");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "IDOBUSTAVA");
                this.Columns.Add(this.columnIDOBUSTAVA);
                this.columnNAZIVOBUSTAVA = new DataColumn("NAZIVOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOBUSTAVA.AllowDBNull = false;
                this.columnNAZIVOBUSTAVA.Caption = "Naziv obustave";
                this.columnNAZIVOBUSTAVA.MaxLength = 100;
                this.columnNAZIVOBUSTAVA.DefaultValue = "";
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Description", "Naziv obustave");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOBUSTAVA");
                this.Columns.Add(this.columnNAZIVOBUSTAVA);
                this.columnMOOBUSTAVA = new DataColumn("MOOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnMOOBUSTAVA.AllowDBNull = true;
                this.columnMOOBUSTAVA.Caption = "Model odobrenja";
                this.columnMOOBUSTAVA.MaxLength = 2;
                this.columnMOOBUSTAVA.DefaultValue = "";
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Length", "2");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "MOOBUSTAVA");
                this.Columns.Add(this.columnMOOBUSTAVA);
                this.columnPOOBUSTAVA = new DataColumn("POOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnPOOBUSTAVA.AllowDBNull = true;
                this.columnPOOBUSTAVA.Caption = "Poziv na broj odobrenja obustave";
                this.columnPOOBUSTAVA.MaxLength = 0x16;
                this.columnPOOBUSTAVA.DefaultValue = "";
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Description", "Poziv na broj odobrenja obustave");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Length", "22");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "POOBUSTAVA");
                this.Columns.Add(this.columnPOOBUSTAVA);
                this.columnMZOBUSTAVA = new DataColumn("MZOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnMZOBUSTAVA.AllowDBNull = true;
                this.columnMZOBUSTAVA.Caption = "Model zaduženja obustave";
                this.columnMZOBUSTAVA.MaxLength = 2;
                this.columnMZOBUSTAVA.DefaultValue = "";
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Description", "Model zaduženja obustave");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Length", "2");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "MZOBUSTAVA");
                this.Columns.Add(this.columnMZOBUSTAVA);
                this.columnPZOBUSTAVA = new DataColumn("PZOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnPZOBUSTAVA.AllowDBNull = true;
                this.columnPZOBUSTAVA.Caption = "Poziv na broj zaduženja obustave";
                this.columnPZOBUSTAVA.MaxLength = 0x16;
                this.columnPZOBUSTAVA.DefaultValue = "";
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Description", "Poziv na broj zaduženja obustave");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Length", "22");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "PZOBUSTAVA");
                this.Columns.Add(this.columnPZOBUSTAVA);
                this.columnVBDIOBUSTAVA = new DataColumn("VBDIOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnVBDIOBUSTAVA.AllowDBNull = false;
                this.columnVBDIOBUSTAVA.Caption = "VBDI žiro računa obustave";
                this.columnVBDIOBUSTAVA.MaxLength = 7;
                this.columnVBDIOBUSTAVA.DefaultValue = "";
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Description", "VBDI žiro računa obustave");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Length", "7");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "VBDIOBUSTAVA");
                this.Columns.Add(this.columnVBDIOBUSTAVA);
                this.columnZRNOBUSTAVA = new DataColumn("ZRNOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnZRNOBUSTAVA.AllowDBNull = false;
                this.columnZRNOBUSTAVA.Caption = "Broj žiro računa obustave";
                this.columnZRNOBUSTAVA.MaxLength = 10;
                this.columnZRNOBUSTAVA.DefaultValue = "";
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Description", "Broj žiro računa obustave");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Length", "10");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "ZRNOBUSTAVA");
                this.Columns.Add(this.columnZRNOBUSTAVA);
                this.columnPRIMATELJOBUSTAVA1 = new DataColumn("PRIMATELJOBUSTAVA1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA1.AllowDBNull = false;
                this.columnPRIMATELJOBUSTAVA1.Caption = "Primatelj (1)";
                this.columnPRIMATELJOBUSTAVA1.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA1.DefaultValue = "";
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Description", "Primatelj (1)");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOBUSTAVA1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOBUSTAVA1");
                this.Columns.Add(this.columnPRIMATELJOBUSTAVA1);
                this.columnPRIMATELJOBUSTAVA2 = new DataColumn("PRIMATELJOBUSTAVA2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA2.AllowDBNull = true;
                this.columnPRIMATELJOBUSTAVA2.Caption = "Primatelj (2)";
                this.columnPRIMATELJOBUSTAVA2.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA2.DefaultValue = "";
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Description", "Primatelj (2)");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOBUSTAVA2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOBUSTAVA2");
                this.Columns.Add(this.columnPRIMATELJOBUSTAVA2);
                this.columnPRIMATELJOBUSTAVA3 = new DataColumn("PRIMATELJOBUSTAVA3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOBUSTAVA3.AllowDBNull = true;
                this.columnPRIMATELJOBUSTAVA3.Caption = "Primatelj (3)";
                this.columnPRIMATELJOBUSTAVA3.MaxLength = 20;
                this.columnPRIMATELJOBUSTAVA3.DefaultValue = "";
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Description", "Primatelj (3)");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOBUSTAVA3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOBUSTAVA3");
                this.Columns.Add(this.columnPRIMATELJOBUSTAVA3);
                this.columnSIFRAOPISAPLACANJAOBUSTAVA = new DataColumn("SIFRAOPISAPLACANJAOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.Caption = "Šifra opisa plaćanja";
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.DefaultValue = "";
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Description", "Šifra opisa plaćanja");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAOBUSTAVA");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAOBUSTAVA);
                this.columnOPISPLACANJAOBUSTAVA = new DataColumn("OPISPLACANJAOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAOBUSTAVA.AllowDBNull = false;
                this.columnOPISPLACANJAOBUSTAVA.Caption = "Opis plaćanja";
                this.columnOPISPLACANJAOBUSTAVA.MaxLength = 0x24;
                this.columnOPISPLACANJAOBUSTAVA.DefaultValue = "";
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Description", "Opis plaćanja");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAOBUSTAVA");
                this.Columns.Add(this.columnOPISPLACANJAOBUSTAVA);
                this.columnVRSTAOBUSTAVE = new DataColumn("VRSTAOBUSTAVE", typeof(short), "", MappingType.Element);
                this.columnVRSTAOBUSTAVE.AllowDBNull = false;
                this.columnVRSTAOBUSTAVE.Caption = "Vrsta obustave";
                this.columnVRSTAOBUSTAVE.DefaultValue = 0;
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Vrsta obustave");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "2");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "VRSTAOBUSTAVE");
                this.Columns.Add(this.columnVRSTAOBUSTAVE);
                this.columnNAZIVVRSTAOBUSTAVE = new DataColumn("NAZIVVRSTAOBUSTAVE", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTAOBUSTAVE.AllowDBNull = false;
                this.columnNAZIVVRSTAOBUSTAVE.Caption = "Opis vrste obustave";
                this.columnNAZIVVRSTAOBUSTAVE.MaxLength = 50;
                this.columnNAZIVVRSTAOBUSTAVE.DefaultValue = "";
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Description", "Opis vrste obustave");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTAOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTAOBUSTAVE");
                this.Columns.Add(this.columnNAZIVVRSTAOBUSTAVE);
                this.columnIZNOSOBUSTAVE = new DataColumn("IZNOSOBUSTAVE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOBUSTAVE.AllowDBNull = false;
                this.columnIZNOSOBUSTAVE.Caption = "IZNOSOBUSTAVE";
                this.columnIZNOSOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Description", "IZNOSOBUSTAVE");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOBUSTAVE");
                this.Columns.Add(this.columnIZNOSOBUSTAVE);
                this.columnPOSTOTAKOBUSTAVE = new DataColumn("POSTOTAKOBUSTAVE", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAKOBUSTAVE.AllowDBNull = false;
                this.columnPOSTOTAKOBUSTAVE.Caption = "POSTOTAKOBUSTAVE";
                this.columnPOSTOTAKOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Description", "POSTOTAKOBUSTAVE");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAKOBUSTAVE");
                this.Columns.Add(this.columnPOSTOTAKOBUSTAVE);
                this.columnOBRACUNATAOBUSTAVAUKUNAMA = new DataColumn("OBRACUNATAOBUSTAVAUKUNAMA", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.AllowDBNull = false;
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.Caption = "OBRACUNATAOBUSTAVAUKUNAMA";
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Description", "OBRACUNATAOBUSTAVAUKUNAMA");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATAOBUSTAVAUKUNAMA.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATAOBUSTAVAUKUNAMA");
                this.Columns.Add(this.columnOBRACUNATAOBUSTAVAUKUNAMA);
                this.columnISPLACENOKASA = new DataColumn("ISPLACENOKASA", typeof(decimal), "", MappingType.Element);
                this.columnISPLACENOKASA.AllowDBNull = false;
                this.columnISPLACENOKASA.Caption = "ISPLACENOKASA";
                this.columnISPLACENOKASA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnISPLACENOKASA.ExtendedProperties.Add("IsKey", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Description", "ISPLACENOKASA");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Length", "12");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Decimals", "2");
                this.columnISPLACENOKASA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnISPLACENOKASA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.InternalName", "ISPLACENOKASA");
                this.Columns.Add(this.columnISPLACENOKASA);
                this.columnSALDOKASA = new DataColumn("SALDOKASA", typeof(decimal), "", MappingType.Element);
                this.columnSALDOKASA.AllowDBNull = false;
                this.columnSALDOKASA.Caption = "SALDOKASA";
                this.columnSALDOKASA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSALDOKASA.ExtendedProperties.Add("IsKey", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSALDOKASA.ExtendedProperties.Add("Description", "SALDOKASA");
                this.columnSALDOKASA.ExtendedProperties.Add("Length", "12");
                this.columnSALDOKASA.ExtendedProperties.Add("Decimals", "2");
                this.columnSALDOKASA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSALDOKASA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.InternalName", "SALDOKASA");
                this.Columns.Add(this.columnSALDOKASA);
                this.columnOBUSTAVLJENODOSADA = new DataColumn("OBUSTAVLJENODOSADA", typeof(decimal), "", MappingType.Element);
                this.columnOBUSTAVLJENODOSADA.AllowDBNull = true;
                this.columnOBUSTAVLJENODOSADA.Caption = "OBUSTAVLJENODOSADA";
                this.columnOBUSTAVLJENODOSADA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Description", "OBUSTAVLJENODOSADA");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Length", "12");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBUSTAVLJENODOSADA.ExtendedProperties.Add("Deklarit.InternalName", "OBUSTAVLJENODOSADA");
                this.Columns.Add(this.columnOBUSTAVLJENODOSADA);
                this.columnOBUSTAVLJENODOSADABROJRATA = new DataColumn("OBUSTAVLJENODOSADABROJRATA", typeof(decimal), "", MappingType.Element);
                this.columnOBUSTAVLJENODOSADABROJRATA.AllowDBNull = true;
                this.columnOBUSTAVLJENODOSADABROJRATA.Caption = "OBUSTAVLJENODOSADABROJRATA";
                this.columnOBUSTAVLJENODOSADABROJRATA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Description", "OBUSTAVLJENODOSADABROJRATA");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Length", "12");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBUSTAVLJENODOSADABROJRATA.ExtendedProperties.Add("Deklarit.InternalName", "OBUSTAVLJENODOSADABROJRATA");
                this.Columns.Add(this.columnOBUSTAVLJENODOSADABROJRATA);
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE = new DataColumn("OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE", typeof(decimal), "", MappingType.Element);
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.AllowDBNull = true;
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Caption = "OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE";
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("IsKey", "false");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Description", "OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Length", "12");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Decimals", "2");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.ExtendedProperties.Add("Deklarit.InternalName", "OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE");
                this.Columns.Add(this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDOBUSTAVA };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "ObracunObustave");
                this.ExtendedProperties.Add("Description", "ObracunObustave");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDOBUSTAVA = this.Columns["IDOBUSTAVA"];
                this.columnNAZIVOBUSTAVA = this.Columns["NAZIVOBUSTAVA"];
                this.columnMOOBUSTAVA = this.Columns["MOOBUSTAVA"];
                this.columnPOOBUSTAVA = this.Columns["POOBUSTAVA"];
                this.columnMZOBUSTAVA = this.Columns["MZOBUSTAVA"];
                this.columnPZOBUSTAVA = this.Columns["PZOBUSTAVA"];
                this.columnVBDIOBUSTAVA = this.Columns["VBDIOBUSTAVA"];
                this.columnZRNOBUSTAVA = this.Columns["ZRNOBUSTAVA"];
                this.columnPRIMATELJOBUSTAVA1 = this.Columns["PRIMATELJOBUSTAVA1"];
                this.columnPRIMATELJOBUSTAVA2 = this.Columns["PRIMATELJOBUSTAVA2"];
                this.columnPRIMATELJOBUSTAVA3 = this.Columns["PRIMATELJOBUSTAVA3"];
                this.columnSIFRAOPISAPLACANJAOBUSTAVA = this.Columns["SIFRAOPISAPLACANJAOBUSTAVA"];
                this.columnOPISPLACANJAOBUSTAVA = this.Columns["OPISPLACANJAOBUSTAVA"];
                this.columnVRSTAOBUSTAVE = this.Columns["VRSTAOBUSTAVE"];
                this.columnNAZIVVRSTAOBUSTAVE = this.Columns["NAZIVVRSTAOBUSTAVE"];
                this.columnIZNOSOBUSTAVE = this.Columns["IZNOSOBUSTAVE"];
                this.columnPOSTOTAKOBUSTAVE = this.Columns["POSTOTAKOBUSTAVE"];
                this.columnOBRACUNATAOBUSTAVAUKUNAMA = this.Columns["OBRACUNATAOBUSTAVAUKUNAMA"];
                this.columnISPLACENOKASA = this.Columns["ISPLACENOKASA"];
                this.columnSALDOKASA = this.Columns["SALDOKASA"];
                this.columnOBUSTAVLJENODOSADA = this.Columns["OBUSTAVLJENODOSADA"];
                this.columnOBUSTAVLJENODOSADABROJRATA = this.Columns["OBUSTAVLJENODOSADABROJRATA"];
                this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE = this.Columns["OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE"];
            }

            public OBRACUNDataSet.OBRACUNObustaveRow NewOBRACUNObustaveRow()
            {
                return (OBRACUNDataSet.OBRACUNObustaveRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.OBRACUNObustaveRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OBRACUNObustaveRowChanged != null)
                {
                    OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler oBRACUNObustaveRowChangedEvent = this.OBRACUNObustaveRowChanged;
                    if (oBRACUNObustaveRowChangedEvent != null)
                    {
                        oBRACUNObustaveRowChangedEvent(this, new OBRACUNDataSet.OBRACUNObustaveRowChangeEvent((OBRACUNDataSet.OBRACUNObustaveRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OBRACUNObustaveRowChanging != null)
                {
                    OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler oBRACUNObustaveRowChangingEvent = this.OBRACUNObustaveRowChanging;
                    if (oBRACUNObustaveRowChangingEvent != null)
                    {
                        oBRACUNObustaveRowChangingEvent(this, new OBRACUNDataSet.OBRACUNObustaveRowChangeEvent((OBRACUNDataSet.OBRACUNObustaveRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_OBRACUNObustave", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.OBRACUNObustaveRowDeleted != null)
                {
                    OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler oBRACUNObustaveRowDeletedEvent = this.OBRACUNObustaveRowDeleted;
                    if (oBRACUNObustaveRowDeletedEvent != null)
                    {
                        oBRACUNObustaveRowDeletedEvent(this, new OBRACUNDataSet.OBRACUNObustaveRowChangeEvent((OBRACUNDataSet.OBRACUNObustaveRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OBRACUNObustaveRowDeleting != null)
                {
                    OBRACUNDataSet.OBRACUNObustaveRowChangeEventHandler oBRACUNObustaveRowDeletingEvent = this.OBRACUNObustaveRowDeleting;
                    if (oBRACUNObustaveRowDeletingEvent != null)
                    {
                        oBRACUNObustaveRowDeletingEvent(this, new OBRACUNDataSet.OBRACUNObustaveRowChangeEvent((OBRACUNDataSet.OBRACUNObustaveRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOBRACUNObustaveRow(OBRACUNDataSet.OBRACUNObustaveRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDOBUSTAVAColumn
            {
                get
                {
                    return this.columnIDOBUSTAVA;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn ISPLACENOKASAColumn
            {
                get
                {
                    return this.columnISPLACENOKASA;
                }
            }

            public OBRACUNDataSet.OBRACUNObustaveRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.OBRACUNObustaveRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSOBUSTAVEColumn
            {
                get
                {
                    return this.columnIZNOSOBUSTAVE;
                }
            }

            public DataColumn MOOBUSTAVAColumn
            {
                get
                {
                    return this.columnMOOBUSTAVA;
                }
            }

            public DataColumn MZOBUSTAVAColumn
            {
                get
                {
                    return this.columnMZOBUSTAVA;
                }
            }

            public DataColumn NAZIVOBUSTAVAColumn
            {
                get
                {
                    return this.columnNAZIVOBUSTAVA;
                }
            }

            public DataColumn NAZIVVRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnNAZIVVRSTAOBUSTAVE;
                }
            }

            public DataColumn OBRACUNATAOBUSTAVAUKUNAMAColumn
            {
                get
                {
                    return this.columnOBRACUNATAOBUSTAVAUKUNAMA;
                }
            }

            public DataColumn OBUSTAVLJENODOSADABROJRATAColumn
            {
                get
                {
                    return this.columnOBUSTAVLJENODOSADABROJRATA;
                }
            }

            public DataColumn OBUSTAVLJENODOSADAColumn
            {
                get
                {
                    return this.columnOBUSTAVLJENODOSADA;
                }
            }

            public DataColumn OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEColumn
            {
                get
                {
                    return this.columnOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE;
                }
            }

            public DataColumn OPISPLACANJAOBUSTAVAColumn
            {
                get
                {
                    return this.columnOPISPLACANJAOBUSTAVA;
                }
            }

            public DataColumn POOBUSTAVAColumn
            {
                get
                {
                    return this.columnPOOBUSTAVA;
                }
            }

            public DataColumn POSTOTAKOBUSTAVEColumn
            {
                get
                {
                    return this.columnPOSTOTAKOBUSTAVE;
                }
            }

            public DataColumn PRIMATELJOBUSTAVA1Column
            {
                get
                {
                    return this.columnPRIMATELJOBUSTAVA1;
                }
            }

            public DataColumn PRIMATELJOBUSTAVA2Column
            {
                get
                {
                    return this.columnPRIMATELJOBUSTAVA2;
                }
            }

            public DataColumn PRIMATELJOBUSTAVA3Column
            {
                get
                {
                    return this.columnPRIMATELJOBUSTAVA3;
                }
            }

            public DataColumn PZOBUSTAVAColumn
            {
                get
                {
                    return this.columnPZOBUSTAVA;
                }
            }

            public DataColumn SALDOKASAColumn
            {
                get
                {
                    return this.columnSALDOKASA;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAOBUSTAVAColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAOBUSTAVA;
                }
            }

            public DataColumn VBDIOBUSTAVAColumn
            {
                get
                {
                    return this.columnVBDIOBUSTAVA;
                }
            }

            public DataColumn VRSTAOBUSTAVEColumn
            {
                get
                {
                    return this.columnVRSTAOBUSTAVE;
                }
            }

            public DataColumn ZRNOBUSTAVAColumn
            {
                get
                {
                    return this.columnZRNOBUSTAVA;
                }
            }
        }

        public class OBRACUNObustaveRow : DataRow
        {
            private OBRACUNDataSet.OBRACUNObustaveDataTable tableOBRACUNObustave;

            internal OBRACUNObustaveRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOBRACUNObustave = (OBRACUNDataSet.OBRACUNObustaveDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_OBRACUNObustave");
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableOBRACUNObustave.IDOBRACUNColumn);
            }

            public bool IsIDOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.IDOBUSTAVAColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableOBRACUNObustave.IDRADNIKColumn);
            }

            public bool IsISPLACENOKASANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.ISPLACENOKASAColumn);
            }

            public bool IsIZNOSOBUSTAVENull()
            {
                return this.IsNull(this.tableOBRACUNObustave.IZNOSOBUSTAVEColumn);
            }

            public bool IsMOOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.MOOBUSTAVAColumn);
            }

            public bool IsMZOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.MZOBUSTAVAColumn);
            }

            public bool IsNAZIVOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.NAZIVOBUSTAVAColumn);
            }

            public bool IsNAZIVVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableOBRACUNObustave.NAZIVVRSTAOBUSTAVEColumn);
            }

            public bool IsOBRACUNATAOBUSTAVAUKUNAMANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.OBRACUNATAOBUSTAVAUKUNAMAColumn);
            }

            public bool IsOBUSTAVLJENODOSADABROJRATANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.OBUSTAVLJENODOSADABROJRATAColumn);
            }

            public bool IsOBUSTAVLJENODOSADANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.OBUSTAVLJENODOSADAColumn);
            }

            public bool IsOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASENull()
            {
                return this.IsNull(this.tableOBRACUNObustave.OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEColumn);
            }

            public bool IsOPISPLACANJAOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.OPISPLACANJAOBUSTAVAColumn);
            }

            public bool IsPOOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.POOBUSTAVAColumn);
            }

            public bool IsPOSTOTAKOBUSTAVENull()
            {
                return this.IsNull(this.tableOBRACUNObustave.POSTOTAKOBUSTAVEColumn);
            }

            public bool IsPRIMATELJOBUSTAVA1Null()
            {
                return this.IsNull(this.tableOBRACUNObustave.PRIMATELJOBUSTAVA1Column);
            }

            public bool IsPRIMATELJOBUSTAVA2Null()
            {
                return this.IsNull(this.tableOBRACUNObustave.PRIMATELJOBUSTAVA2Column);
            }

            public bool IsPRIMATELJOBUSTAVA3Null()
            {
                return this.IsNull(this.tableOBRACUNObustave.PRIMATELJOBUSTAVA3Column);
            }

            public bool IsPZOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.PZOBUSTAVAColumn);
            }

            public bool IsSALDOKASANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.SALDOKASAColumn);
            }

            public bool IsSIFRAOPISAPLACANJAOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.SIFRAOPISAPLACANJAOBUSTAVAColumn);
            }

            public bool IsVBDIOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.VBDIOBUSTAVAColumn);
            }

            public bool IsVRSTAOBUSTAVENull()
            {
                return this.IsNull(this.tableOBRACUNObustave.VRSTAOBUSTAVEColumn);
            }

            public bool IsZRNOBUSTAVANull()
            {
                return this.IsNull(this.tableOBRACUNObustave.ZRNOBUSTAVAColumn);
            }

            public void SetISPLACENOKASANull()
            {
                this[this.tableOBRACUNObustave.ISPLACENOKASAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOBUSTAVENull()
            {
                this[this.tableOBRACUNObustave.IZNOSOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.MOOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.MZOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.NAZIVOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTAOBUSTAVENull()
            {
                this[this.tableOBRACUNObustave.NAZIVVRSTAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATAOBUSTAVAUKUNAMANull()
            {
                this[this.tableOBRACUNObustave.OBRACUNATAOBUSTAVAUKUNAMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBUSTAVLJENODOSADABROJRATANull()
            {
                this[this.tableOBRACUNObustave.OBUSTAVLJENODOSADABROJRATAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBUSTAVLJENODOSADANull()
            {
                this[this.tableOBRACUNObustave.OBUSTAVLJENODOSADAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASENull()
            {
                this[this.tableOBRACUNObustave.OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.OPISPLACANJAOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.POOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKOBUSTAVENull()
            {
                this[this.tableOBRACUNObustave.POSTOTAKOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA1Null()
            {
                this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA2Null()
            {
                this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOBUSTAVA3Null()
            {
                this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.PZOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSALDOKASANull()
            {
                this[this.tableOBRACUNObustave.SALDOKASAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.SIFRAOPISAPLACANJAOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.VBDIOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRSTAOBUSTAVENull()
            {
                this[this.tableOBRACUNObustave.VRSTAOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNOBUSTAVANull()
            {
                this[this.tableOBRACUNObustave.ZRNOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableOBRACUNObustave.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableOBRACUNObustave.IDOBRACUNColumn] = value;
                }
            }

            public int IDOBUSTAVA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBRACUNObustave.IDOBUSTAVAColumn]);
                }
                set
                {
                    this[this.tableOBRACUNObustave.IDOBUSTAVAColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOBRACUNObustave.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableOBRACUNObustave.IDRADNIKColumn] = value;
                }
            }

            public decimal ISPLACENOKASA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.ISPLACENOKASAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.ISPLACENOKASAColumn] = value;
                }
            }

            public decimal IZNOSOBUSTAVE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.IZNOSOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.IZNOSOBUSTAVEColumn] = value;
                }
            }

            public string MOOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.MOOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.MOOBUSTAVAColumn] = value;
                }
            }

            public string MZOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.MZOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.MZOBUSTAVAColumn] = value;
                }
            }

            public string NAZIVOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.NAZIVOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.NAZIVOBUSTAVAColumn] = value;
                }
            }

            public string NAZIVVRSTAOBUSTAVE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.NAZIVVRSTAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.NAZIVVRSTAOBUSTAVEColumn] = value;
                }
            }

            public decimal OBRACUNATAOBUSTAVAUKUNAMA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.OBRACUNATAOBUSTAVAUKUNAMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.OBRACUNATAOBUSTAVAUKUNAMAColumn] = value;
                }
            }

            public decimal OBUSTAVLJENODOSADA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.OBUSTAVLJENODOSADAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.OBUSTAVLJENODOSADAColumn] = value;
                }
            }

            public decimal OBUSTAVLJENODOSADABROJRATA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.OBUSTAVLJENODOSADABROJRATAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.OBUSTAVLJENODOSADABROJRATAColumn] = value;
                }
            }

            public decimal OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEColumn] = value;
                }
            }

            public string OPISPLACANJAOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.OPISPLACANJAOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.OPISPLACANJAOBUSTAVAColumn] = value;
                }
            }

            public string POOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.POOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.POOBUSTAVAColumn] = value;
                }
            }

            public decimal POSTOTAKOBUSTAVE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.POSTOTAKOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.POSTOTAKOBUSTAVEColumn] = value;
                }
            }

            public string PRIMATELJOBUSTAVA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA1Column] = value;
                }
            }

            public string PRIMATELJOBUSTAVA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA2Column] = value;
                }
            }

            public string PRIMATELJOBUSTAVA3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.PRIMATELJOBUSTAVA3Column] = value;
                }
            }

            public string PZOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.PZOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.PZOBUSTAVAColumn] = value;
                }
            }

            public decimal SALDOKASA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUNObustave.SALDOKASAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.SALDOKASAColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.SIFRAOPISAPLACANJAOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                       
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.SIFRAOPISAPLACANJAOBUSTAVAColumn] = value;
                }
            }

            public string VBDIOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.VBDIOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.VBDIOBUSTAVAColumn] = value;
                }
            }

            public short VRSTAOBUSTAVE
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableOBRACUNObustave.VRSTAOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUNObustave.VRSTAOBUSTAVEColumn] = value;
                }
            }

            public string ZRNOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUNObustave.ZRNOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUNObustave.ZRNOBUSTAVAColumn] = value;
                }
            }
        }

        public class OBRACUNObustaveRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.OBRACUNObustaveRow eventRow;

            public OBRACUNObustaveRowChangeEvent(OBRACUNDataSet.OBRACUNObustaveRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.OBRACUNObustaveRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OBRACUNObustaveRowChangeEventHandler(object sender, OBRACUNDataSet.OBRACUNObustaveRowChangeEvent e);

        [Serializable]
        public class ObracunOlaksiceDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDGRUPEOLAKSICA;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDOLAKSICE;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIDTIPOLAKSICE;
            private DataColumn columnIZNOSOLAKSICE;
            private DataColumn columnMAXIMALNIIZNOSGRUPE;
            private DataColumn columnMOOLAKSICA;
            private DataColumn columnMZOLAKSICA;
            private DataColumn columnNAZIVGRUPEOLAKSICA;
            private DataColumn columnNAZIVOLAKSICE;
            private DataColumn columnNAZIVTIPOLAKSICE;
            private DataColumn columnOBRACUNATAOLAKSICA;
            private DataColumn columnOPISPLACANJAOLAKSICA;
            private DataColumn columnPOOLAKSICA;
            private DataColumn columnPRIMATELJOLAKSICA1;
            private DataColumn columnPRIMATELJOLAKSICA2;
            private DataColumn columnPRIMATELJOLAKSICA3;
            private DataColumn columnPZOLAKSICA;
            private DataColumn columnSIFRAOPISAPLACANJAOLAKSICA;
            private DataColumn columnVBDIOLAKSICA;
            private DataColumn columnZRNOLAKSICA;

            public event OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler ObracunOlaksiceRowChanged;

            public event OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler ObracunOlaksiceRowChanging;

            public event OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler ObracunOlaksiceRowDeleted;

            public event OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler ObracunOlaksiceRowDeleting;

            public ObracunOlaksiceDataTable()
            {
                this.TableName = "ObracunOlaksice";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ObracunOlaksiceDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected ObracunOlaksiceDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddObracunOlaksiceRow(OBRACUNDataSet.ObracunOlaksiceRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.ObracunOlaksiceRow AddObracunOlaksiceRow(string iDOBRACUN, int iDRADNIK, int iDOLAKSICE, string mZOLAKSICA, string pZOLAKSICA, string mOOLAKSICA, string pOOLAKSICA, string sIFRAOPISAPLACANJAOLAKSICA, string oPISPLACANJAOLAKSICA, decimal iZNOSOLAKSICE, decimal oBRACUNATAOLAKSICA)
            {
                OBRACUNDataSet.ObracunOlaksiceRow row = (OBRACUNDataSet.ObracunOlaksiceRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["IDOLAKSICE"] = iDOLAKSICE;
                row["MZOLAKSICA"] = mZOLAKSICA;
                row["PZOLAKSICA"] = pZOLAKSICA;
                row["MOOLAKSICA"] = mOOLAKSICA;
                row["POOLAKSICA"] = pOOLAKSICA;
                row["SIFRAOPISAPLACANJAOLAKSICA"] = sIFRAOPISAPLACANJAOLAKSICA;
                row["OPISPLACANJAOLAKSICA"] = oPISPLACANJAOLAKSICA;
                row["IZNOSOLAKSICE"] = iZNOSOLAKSICE;
                row["OBRACUNATAOLAKSICA"] = oBRACUNATAOLAKSICA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.ObracunOlaksiceDataTable table = (OBRACUNDataSet.ObracunOlaksiceDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.ObracunOlaksiceRow FindByIDOBRACUNIDRADNIKIDOLAKSICE(string iDOBRACUN, int iDRADNIK, int iDOLAKSICE)
            {
                return (OBRACUNDataSet.ObracunOlaksiceRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDOLAKSICE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.ObracunOlaksiceRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDOLAKSICE = new DataColumn("IDOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnIDOLAKSICE.AllowDBNull = false;
                this.columnIDOLAKSICE.Caption = "Šifra olakšice";
                this.columnIDOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOLAKSICE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Description", "Šifra olakšice");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Length", "8");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IDOLAKSICE");
                this.Columns.Add(this.columnIDOLAKSICE);
                this.columnNAZIVOLAKSICE = new DataColumn("NAZIVOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnNAZIVOLAKSICE.AllowDBNull = false;
                this.columnNAZIVOLAKSICE.Caption = "Naziv olakšice";
                this.columnNAZIVOLAKSICE.MaxLength = 100;
                this.columnNAZIVOLAKSICE.DefaultValue = "";
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Description", "Naziv olakšice");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOLAKSICE");
                this.Columns.Add(this.columnNAZIVOLAKSICE);
                this.columnIDGRUPEOLAKSICA = new DataColumn("IDGRUPEOLAKSICA", typeof(int), "", MappingType.Element);
                this.columnIDGRUPEOLAKSICA.AllowDBNull = false;
                this.columnIDGRUPEOLAKSICA.Caption = "Šifra grupe olakšica";
                this.columnIDGRUPEOLAKSICA.DefaultValue = 0;
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Šifra grupe olakšica");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Length", "5");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "IDGRUPEOLAKSICA");
                this.Columns.Add(this.columnIDGRUPEOLAKSICA);
                this.columnNAZIVGRUPEOLAKSICA = new DataColumn("NAZIVGRUPEOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnNAZIVGRUPEOLAKSICA.AllowDBNull = false;
                this.columnNAZIVGRUPEOLAKSICA.Caption = "Naziv grupe olakšice";
                this.columnNAZIVGRUPEOLAKSICA.MaxLength = 100;
                this.columnNAZIVGRUPEOLAKSICA.DefaultValue = "";
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Description", "Naziv grupe olakšice");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVGRUPEOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVGRUPEOLAKSICA");
                this.Columns.Add(this.columnNAZIVGRUPEOLAKSICA);
                this.columnMAXIMALNIIZNOSGRUPE = new DataColumn("MAXIMALNIIZNOSGRUPE", typeof(decimal), "", MappingType.Element);
                this.columnMAXIMALNIIZNOSGRUPE.AllowDBNull = false;
                this.columnMAXIMALNIIZNOSGRUPE.Caption = "Maks. iznos olakšica u grupi";
                this.columnMAXIMALNIIZNOSGRUPE.DefaultValue = 0;
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsKey", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Description", "Maks. iznos olakšica u grupi");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Length", "12");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Decimals", "2");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMAXIMALNIIZNOSGRUPE.ExtendedProperties.Add("Deklarit.InternalName", "MAXIMALNIIZNOSGRUPE");
                this.Columns.Add(this.columnMAXIMALNIIZNOSGRUPE);
                this.columnIDTIPOLAKSICE = new DataColumn("IDTIPOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnIDTIPOLAKSICE.AllowDBNull = false;
                this.columnIDTIPOLAKSICE.Caption = "Tip olakšice";
                this.columnIDTIPOLAKSICE.DefaultValue = 0;
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Description", "Tip olakšice");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPOLAKSICE");
                this.Columns.Add(this.columnIDTIPOLAKSICE);
                this.columnNAZIVTIPOLAKSICE = new DataColumn("NAZIVTIPOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPOLAKSICE.AllowDBNull = false;
                this.columnNAZIVTIPOLAKSICE.Caption = "Naziv tipa olakšice";
                this.columnNAZIVTIPOLAKSICE.MaxLength = 50;
                this.columnNAZIVTIPOLAKSICE.DefaultValue = "";
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Description", "Naziv tipa olakšice");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPOLAKSICE");
                this.Columns.Add(this.columnNAZIVTIPOLAKSICE);
                this.columnVBDIOLAKSICA = new DataColumn("VBDIOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnVBDIOLAKSICA.AllowDBNull = false;
                this.columnVBDIOLAKSICA.Caption = "VBDI žiro računa olakšice";
                this.columnVBDIOLAKSICA.MaxLength = 7;
                this.columnVBDIOLAKSICA.DefaultValue = "";
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Description", "VBDI žiro računa olakšice");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Length", "7");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "VBDIOLAKSICA");
                this.Columns.Add(this.columnVBDIOLAKSICA);
                this.columnZRNOLAKSICA = new DataColumn("ZRNOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnZRNOLAKSICA.AllowDBNull = false;
                this.columnZRNOLAKSICA.Caption = "Broj žiro računa olakšice";
                this.columnZRNOLAKSICA.MaxLength = 10;
                this.columnZRNOLAKSICA.DefaultValue = "";
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Description", "Broj žiro računa olakšice");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Length", "10");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "ZRNOLAKSICA");
                this.Columns.Add(this.columnZRNOLAKSICA);
                this.columnPRIMATELJOLAKSICA1 = new DataColumn("PRIMATELJOLAKSICA1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA1.AllowDBNull = false;
                this.columnPRIMATELJOLAKSICA1.Caption = "Primatelj olakšice (1)";
                this.columnPRIMATELJOLAKSICA1.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA1.DefaultValue = "";
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Description", "Primatelj olakšice (1)");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOLAKSICA1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOLAKSICA1");
                this.Columns.Add(this.columnPRIMATELJOLAKSICA1);
                this.columnPRIMATELJOLAKSICA2 = new DataColumn("PRIMATELJOLAKSICA2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA2.AllowDBNull = true;
                this.columnPRIMATELJOLAKSICA2.Caption = "Primatelj olakšice (2)";
                this.columnPRIMATELJOLAKSICA2.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA2.DefaultValue = "";
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Description", "Primatelj olakšice (2)");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOLAKSICA2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOLAKSICA2");
                this.Columns.Add(this.columnPRIMATELJOLAKSICA2);
                this.columnPRIMATELJOLAKSICA3 = new DataColumn("PRIMATELJOLAKSICA3", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJOLAKSICA3.AllowDBNull = true;
                this.columnPRIMATELJOLAKSICA3.Caption = "Primatelj olakšice (3)";
                this.columnPRIMATELJOLAKSICA3.MaxLength = 20;
                this.columnPRIMATELJOLAKSICA3.DefaultValue = "";
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Description", "Primatelj olakšice (3)");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJOLAKSICA3.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJOLAKSICA3");
                this.Columns.Add(this.columnPRIMATELJOLAKSICA3);
                this.columnMZOLAKSICA = new DataColumn("MZOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnMZOLAKSICA.AllowDBNull = true;
                this.columnMZOLAKSICA.Caption = "Model zaduženja";
                this.columnMZOLAKSICA.MaxLength = 2;
                this.columnMZOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnMZOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMZOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Description", "Model zaduženja");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Length", "2");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnMZOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "MZOLAKSICA");
                this.Columns.Add(this.columnMZOLAKSICA);
                this.columnPZOLAKSICA = new DataColumn("PZOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnPZOLAKSICA.AllowDBNull = true;
                this.columnPZOLAKSICA.Caption = "Poziv na broj zaduženja";
                this.columnPZOLAKSICA.MaxLength = 0x16;
                this.columnPZOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPZOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPZOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Description", "Poziv na broj zaduženja");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Length", "22");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnPZOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "PZOLAKSICA");
                this.Columns.Add(this.columnPZOLAKSICA);
                this.columnMOOLAKSICA = new DataColumn("MOOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnMOOLAKSICA.AllowDBNull = true;
                this.columnMOOLAKSICA.Caption = "Model odobrenja olakšice";
                this.columnMOOLAKSICA.MaxLength = 2;
                this.columnMOOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Description", "Model odobrenja olakšice");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Length", "2");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnMOOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "MOOLAKSICA");
                this.Columns.Add(this.columnMOOLAKSICA);
                this.columnPOOLAKSICA = new DataColumn("POOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnPOOLAKSICA.AllowDBNull = true;
                this.columnPOOLAKSICA.Caption = "Poziv na broj odobrenja olakšice";
                this.columnPOOLAKSICA.MaxLength = 0x16;
                this.columnPOOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Description", "Poziv na broj odobrenja olakšice");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Length", "22");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "POOLAKSICA");
                this.Columns.Add(this.columnPOOLAKSICA);
                this.columnSIFRAOPISAPLACANJAOLAKSICA = new DataColumn("SIFRAOPISAPLACANJAOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAOLAKSICA.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAOLAKSICA.Caption = "Šifra opisa plaćanja olakšice";
                this.columnSIFRAOPISAPLACANJAOLAKSICA.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Description", "Šifra opisa plaćanja olakšice");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAOLAKSICA");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAOLAKSICA);
                this.columnOPISPLACANJAOLAKSICA = new DataColumn("OPISPLACANJAOLAKSICA", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAOLAKSICA.AllowDBNull = false;
                this.columnOPISPLACANJAOLAKSICA.Caption = "Opis plaćanja olakšice";
                this.columnOPISPLACANJAOLAKSICA.MaxLength = 0x24;
                this.columnOPISPLACANJAOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Description", "Opis plaćanja olakšice");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAOLAKSICA");
                this.Columns.Add(this.columnOPISPLACANJAOLAKSICA);
                this.columnIZNOSOLAKSICE = new DataColumn("IZNOSOLAKSICE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOLAKSICE.AllowDBNull = false;
                this.columnIZNOSOLAKSICE.Caption = "Iznos olakšice";
                this.columnIZNOSOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Description", "Iznos olakšice");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOLAKSICE");
                this.Columns.Add(this.columnIZNOSOLAKSICE);
                this.columnOBRACUNATAOLAKSICA = new DataColumn("OBRACUNATAOLAKSICA", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATAOLAKSICA.AllowDBNull = false;
                this.columnOBRACUNATAOLAKSICA.Caption = "OBRACUNATAOLAKSICA";
                this.columnOBRACUNATAOLAKSICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Description", "OBRACUNATAOLAKSICA");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATAOLAKSICA.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATAOLAKSICA");
                this.Columns.Add(this.columnOBRACUNATAOLAKSICA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDOLAKSICE };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "ObracunOlaksice");
                this.ExtendedProperties.Add("Description", "ObracunOlaksice");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDOLAKSICE = this.Columns["IDOLAKSICE"];
                this.columnNAZIVOLAKSICE = this.Columns["NAZIVOLAKSICE"];
                this.columnIDGRUPEOLAKSICA = this.Columns["IDGRUPEOLAKSICA"];
                this.columnNAZIVGRUPEOLAKSICA = this.Columns["NAZIVGRUPEOLAKSICA"];
                this.columnMAXIMALNIIZNOSGRUPE = this.Columns["MAXIMALNIIZNOSGRUPE"];
                this.columnIDTIPOLAKSICE = this.Columns["IDTIPOLAKSICE"];
                this.columnNAZIVTIPOLAKSICE = this.Columns["NAZIVTIPOLAKSICE"];
                this.columnVBDIOLAKSICA = this.Columns["VBDIOLAKSICA"];
                this.columnZRNOLAKSICA = this.Columns["ZRNOLAKSICA"];
                this.columnPRIMATELJOLAKSICA1 = this.Columns["PRIMATELJOLAKSICA1"];
                this.columnPRIMATELJOLAKSICA2 = this.Columns["PRIMATELJOLAKSICA2"];
                this.columnPRIMATELJOLAKSICA3 = this.Columns["PRIMATELJOLAKSICA3"];
                this.columnMZOLAKSICA = this.Columns["MZOLAKSICA"];
                this.columnPZOLAKSICA = this.Columns["PZOLAKSICA"];
                this.columnMOOLAKSICA = this.Columns["MOOLAKSICA"];
                this.columnPOOLAKSICA = this.Columns["POOLAKSICA"];
                this.columnSIFRAOPISAPLACANJAOLAKSICA = this.Columns["SIFRAOPISAPLACANJAOLAKSICA"];
                this.columnOPISPLACANJAOLAKSICA = this.Columns["OPISPLACANJAOLAKSICA"];
                this.columnIZNOSOLAKSICE = this.Columns["IZNOSOLAKSICE"];
                this.columnOBRACUNATAOLAKSICA = this.Columns["OBRACUNATAOLAKSICA"];
            }

            public OBRACUNDataSet.ObracunOlaksiceRow NewObracunOlaksiceRow()
            {
                return (OBRACUNDataSet.ObracunOlaksiceRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.ObracunOlaksiceRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ObracunOlaksiceRowChanged != null)
                {
                    OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler obracunOlaksiceRowChangedEvent = this.ObracunOlaksiceRowChanged;
                    if (obracunOlaksiceRowChangedEvent != null)
                    {
                        obracunOlaksiceRowChangedEvent(this, new OBRACUNDataSet.ObracunOlaksiceRowChangeEvent((OBRACUNDataSet.ObracunOlaksiceRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ObracunOlaksiceRowChanging != null)
                {
                    OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler obracunOlaksiceRowChangingEvent = this.ObracunOlaksiceRowChanging;
                    if (obracunOlaksiceRowChangingEvent != null)
                    {
                        obracunOlaksiceRowChangingEvent(this, new OBRACUNDataSet.ObracunOlaksiceRowChangeEvent((OBRACUNDataSet.ObracunOlaksiceRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_ObracunOlaksice", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.ObracunOlaksiceRowDeleted != null)
                {
                    OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler obracunOlaksiceRowDeletedEvent = this.ObracunOlaksiceRowDeleted;
                    if (obracunOlaksiceRowDeletedEvent != null)
                    {
                        obracunOlaksiceRowDeletedEvent(this, new OBRACUNDataSet.ObracunOlaksiceRowChangeEvent((OBRACUNDataSet.ObracunOlaksiceRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ObracunOlaksiceRowDeleting != null)
                {
                    OBRACUNDataSet.ObracunOlaksiceRowChangeEventHandler obracunOlaksiceRowDeletingEvent = this.ObracunOlaksiceRowDeleting;
                    if (obracunOlaksiceRowDeletingEvent != null)
                    {
                        obracunOlaksiceRowDeletingEvent(this, new OBRACUNDataSet.ObracunOlaksiceRowChangeEvent((OBRACUNDataSet.ObracunOlaksiceRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveObracunOlaksiceRow(OBRACUNDataSet.ObracunOlaksiceRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnIDGRUPEOLAKSICA;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDOLAKSICEColumn
            {
                get
                {
                    return this.columnIDOLAKSICE;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IDTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnIDTIPOLAKSICE;
                }
            }

            public OBRACUNDataSet.ObracunOlaksiceRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.ObracunOlaksiceRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSOLAKSICEColumn
            {
                get
                {
                    return this.columnIZNOSOLAKSICE;
                }
            }

            public DataColumn MAXIMALNIIZNOSGRUPEColumn
            {
                get
                {
                    return this.columnMAXIMALNIIZNOSGRUPE;
                }
            }

            public DataColumn MOOLAKSICAColumn
            {
                get
                {
                    return this.columnMOOLAKSICA;
                }
            }

            public DataColumn MZOLAKSICAColumn
            {
                get
                {
                    return this.columnMZOLAKSICA;
                }
            }

            public DataColumn NAZIVGRUPEOLAKSICAColumn
            {
                get
                {
                    return this.columnNAZIVGRUPEOLAKSICA;
                }
            }

            public DataColumn NAZIVOLAKSICEColumn
            {
                get
                {
                    return this.columnNAZIVOLAKSICE;
                }
            }

            public DataColumn NAZIVTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnNAZIVTIPOLAKSICE;
                }
            }

            public DataColumn OBRACUNATAOLAKSICAColumn
            {
                get
                {
                    return this.columnOBRACUNATAOLAKSICA;
                }
            }

            public DataColumn OPISPLACANJAOLAKSICAColumn
            {
                get
                {
                    return this.columnOPISPLACANJAOLAKSICA;
                }
            }

            public DataColumn POOLAKSICAColumn
            {
                get
                {
                    return this.columnPOOLAKSICA;
                }
            }

            public DataColumn PRIMATELJOLAKSICA1Column
            {
                get
                {
                    return this.columnPRIMATELJOLAKSICA1;
                }
            }

            public DataColumn PRIMATELJOLAKSICA2Column
            {
                get
                {
                    return this.columnPRIMATELJOLAKSICA2;
                }
            }

            public DataColumn PRIMATELJOLAKSICA3Column
            {
                get
                {
                    return this.columnPRIMATELJOLAKSICA3;
                }
            }

            public DataColumn PZOLAKSICAColumn
            {
                get
                {
                    return this.columnPZOLAKSICA;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAOLAKSICAColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAOLAKSICA;
                }
            }

            public DataColumn VBDIOLAKSICAColumn
            {
                get
                {
                    return this.columnVBDIOLAKSICA;
                }
            }

            public DataColumn ZRNOLAKSICAColumn
            {
                get
                {
                    return this.columnZRNOLAKSICA;
                }
            }
        }

        public class ObracunOlaksiceRow : DataRow
        {
            private OBRACUNDataSet.ObracunOlaksiceDataTable tableObracunOlaksice;

            internal ObracunOlaksiceRow(DataRowBuilder rb) : base(rb)
            {
                this.tableObracunOlaksice = (OBRACUNDataSet.ObracunOlaksiceDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_ObracunOlaksice");
            }

            public bool IsIDGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.IDGRUPEOLAKSICAColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableObracunOlaksice.IDOBRACUNColumn);
            }

            public bool IsIDOLAKSICENull()
            {
                return this.IsNull(this.tableObracunOlaksice.IDOLAKSICEColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableObracunOlaksice.IDRADNIKColumn);
            }

            public bool IsIDTIPOLAKSICENull()
            {
                return this.IsNull(this.tableObracunOlaksice.IDTIPOLAKSICEColumn);
            }

            public bool IsIZNOSOLAKSICENull()
            {
                return this.IsNull(this.tableObracunOlaksice.IZNOSOLAKSICEColumn);
            }

            public bool IsMAXIMALNIIZNOSGRUPENull()
            {
                return this.IsNull(this.tableObracunOlaksice.MAXIMALNIIZNOSGRUPEColumn);
            }

            public bool IsMOOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.MOOLAKSICAColumn);
            }

            public bool IsMZOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.MZOLAKSICAColumn);
            }

            public bool IsNAZIVGRUPEOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.NAZIVGRUPEOLAKSICAColumn);
            }

            public bool IsNAZIVOLAKSICENull()
            {
                return this.IsNull(this.tableObracunOlaksice.NAZIVOLAKSICEColumn);
            }

            public bool IsNAZIVTIPOLAKSICENull()
            {
                return this.IsNull(this.tableObracunOlaksice.NAZIVTIPOLAKSICEColumn);
            }

            public bool IsOBRACUNATAOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.OBRACUNATAOLAKSICAColumn);
            }

            public bool IsOPISPLACANJAOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.OPISPLACANJAOLAKSICAColumn);
            }

            public bool IsPOOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.POOLAKSICAColumn);
            }

            public bool IsPRIMATELJOLAKSICA1Null()
            {
                return this.IsNull(this.tableObracunOlaksice.PRIMATELJOLAKSICA1Column);
            }

            public bool IsPRIMATELJOLAKSICA2Null()
            {
                return this.IsNull(this.tableObracunOlaksice.PRIMATELJOLAKSICA2Column);
            }

            public bool IsPRIMATELJOLAKSICA3Null()
            {
                return this.IsNull(this.tableObracunOlaksice.PRIMATELJOLAKSICA3Column);
            }

            public bool IsPZOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.PZOLAKSICAColumn);
            }

            public bool IsSIFRAOPISAPLACANJAOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.SIFRAOPISAPLACANJAOLAKSICAColumn);
            }

            public bool IsVBDIOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.VBDIOLAKSICAColumn);
            }

            public bool IsZRNOLAKSICANull()
            {
                return this.IsNull(this.tableObracunOlaksice.ZRNOLAKSICAColumn);
            }

            public void SetIDGRUPEOLAKSICANull()
            {
                this[this.tableObracunOlaksice.IDGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDTIPOLAKSICENull()
            {
                this[this.tableObracunOlaksice.IDTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOLAKSICENull()
            {
                this[this.tableObracunOlaksice.IZNOSOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMAXIMALNIIZNOSGRUPENull()
            {
                this[this.tableObracunOlaksice.MAXIMALNIIZNOSGRUPEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOOLAKSICANull()
            {
                this[this.tableObracunOlaksice.MOOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZOLAKSICANull()
            {
                this[this.tableObracunOlaksice.MZOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVGRUPEOLAKSICANull()
            {
                this[this.tableObracunOlaksice.NAZIVGRUPEOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOLAKSICENull()
            {
                this[this.tableObracunOlaksice.NAZIVOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVTIPOLAKSICENull()
            {
                this[this.tableObracunOlaksice.NAZIVTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATAOLAKSICANull()
            {
                this[this.tableObracunOlaksice.OBRACUNATAOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAOLAKSICANull()
            {
                this[this.tableObracunOlaksice.OPISPLACANJAOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOOLAKSICANull()
            {
                this[this.tableObracunOlaksice.POOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA1Null()
            {
                this[this.tableObracunOlaksice.PRIMATELJOLAKSICA1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA2Null()
            {
                this[this.tableObracunOlaksice.PRIMATELJOLAKSICA2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJOLAKSICA3Null()
            {
                this[this.tableObracunOlaksice.PRIMATELJOLAKSICA3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZOLAKSICANull()
            {
                this[this.tableObracunOlaksice.PZOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAOLAKSICANull()
            {
                this[this.tableObracunOlaksice.SIFRAOPISAPLACANJAOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIOLAKSICANull()
            {
                this[this.tableObracunOlaksice.VBDIOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNOLAKSICANull()
            {
                this[this.tableObracunOlaksice.ZRNOLAKSICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDGRUPEOLAKSICA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunOlaksice.IDGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunOlaksice.IDGRUPEOLAKSICAColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableObracunOlaksice.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableObracunOlaksice.IDOBRACUNColumn] = value;
                }
            }

            public int IDOLAKSICE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunOlaksice.IDOLAKSICEColumn]);
                }
                set
                {
                    this[this.tableObracunOlaksice.IDOLAKSICEColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunOlaksice.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableObracunOlaksice.IDRADNIKColumn] = value;
                }
            }

            public int IDTIPOLAKSICE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunOlaksice.IDTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunOlaksice.IDTIPOLAKSICEColumn] = value;
                }
            }

            public decimal IZNOSOLAKSICE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunOlaksice.IZNOSOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunOlaksice.IZNOSOLAKSICEColumn] = value;
                }
            }

            public decimal MAXIMALNIIZNOSGRUPE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunOlaksice.MAXIMALNIIZNOSGRUPEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunOlaksice.MAXIMALNIIZNOSGRUPEColumn] = value;
                }
            }

            public string MOOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.MOOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.MOOLAKSICAColumn] = value;
                }
            }

            public string MZOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.MZOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.MZOLAKSICAColumn] = value;
                }
            }

            public string NAZIVGRUPEOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.NAZIVGRUPEOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.NAZIVGRUPEOLAKSICAColumn] = value;
                }
            }

            public string NAZIVOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.NAZIVOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.NAZIVOLAKSICEColumn] = value;
                }
            }

            public string NAZIVTIPOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.NAZIVTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.NAZIVTIPOLAKSICEColumn] = value;
                }
            }

            public decimal OBRACUNATAOLAKSICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunOlaksice.OBRACUNATAOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunOlaksice.OBRACUNATAOLAKSICAColumn] = value;
                }
            }

            public string OPISPLACANJAOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.OPISPLACANJAOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.OPISPLACANJAOLAKSICAColumn] = value;
                }
            }

            public string POOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.POOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.POOLAKSICAColumn] = value;
                }
            }

            public string PRIMATELJOLAKSICA1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.PRIMATELJOLAKSICA1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.PRIMATELJOLAKSICA1Column] = value;
                }
            }

            public string PRIMATELJOLAKSICA2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.PRIMATELJOLAKSICA2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.PRIMATELJOLAKSICA2Column] = value;
                }
            }

            public string PRIMATELJOLAKSICA3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.PRIMATELJOLAKSICA3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.PRIMATELJOLAKSICA3Column] = value;
                }
            }

            public string PZOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.PZOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.PZOLAKSICAColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.SIFRAOPISAPLACANJAOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.SIFRAOPISAPLACANJAOLAKSICAColumn] = value;
                }
            }

            public string VBDIOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.VBDIOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.VBDIOLAKSICAColumn] = value;
                }
            }

            public string ZRNOLAKSICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunOlaksice.ZRNOLAKSICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunOlaksice.ZRNOLAKSICAColumn] = value;
                }
            }
        }

        public class ObracunOlaksiceRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.ObracunOlaksiceRow eventRow;

            public ObracunOlaksiceRowChangeEvent(OBRACUNDataSet.ObracunOlaksiceRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.ObracunOlaksiceRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ObracunOlaksiceRowChangeEventHandler(object sender, OBRACUNDataSet.ObracunOlaksiceRowChangeEvent e);

        [Serializable]
        public class ObracunPoreziDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDPOREZ;
            private DataColumn columnIDRADNIK;
            private DataColumn columnMOPOREZ;
            private DataColumn columnMZPOREZ;
            private DataColumn columnNAZIVPOREZ;
            private DataColumn columnOBRACUNATIPOREZ;
            private DataColumn columnOPISPLACANJAPOREZ;
            private DataColumn columnOSNOVICAPOREZ;
            private DataColumn columnPOPOREZ;
            private DataColumn columnPOREZMJESECNO;
            private DataColumn columnPRIMATELJPOREZ1;
            private DataColumn columnPRIMATELJPOREZ2;
            private DataColumn columnPZPOREZ;
            private DataColumn columnSIFRAOPISAPLACANJAPOREZ;
            private DataColumn columnSTOPAPOREZA;

            public event OBRACUNDataSet.ObracunPoreziRowChangeEventHandler ObracunPoreziRowChanged;

            public event OBRACUNDataSet.ObracunPoreziRowChangeEventHandler ObracunPoreziRowChanging;

            public event OBRACUNDataSet.ObracunPoreziRowChangeEventHandler ObracunPoreziRowDeleted;

            public event OBRACUNDataSet.ObracunPoreziRowChangeEventHandler ObracunPoreziRowDeleting;

            public ObracunPoreziDataTable()
            {
                this.TableName = "ObracunPorezi";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ObracunPoreziDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected ObracunPoreziDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddObracunPoreziRow(OBRACUNDataSet.ObracunPoreziRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.ObracunPoreziRow AddObracunPoreziRow(string iDOBRACUN, int iDRADNIK, int iDPOREZ, decimal oBRACUNATIPOREZ, decimal oSNOVICAPOREZ)
            {
                OBRACUNDataSet.ObracunPoreziRow row = (OBRACUNDataSet.ObracunPoreziRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["IDPOREZ"] = iDPOREZ;
                row["OBRACUNATIPOREZ"] = oBRACUNATIPOREZ;
                row["OSNOVICAPOREZ"] = oSNOVICAPOREZ;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.ObracunPoreziDataTable table = (OBRACUNDataSet.ObracunPoreziDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.ObracunPoreziRow FindByIDOBRACUNIDRADNIKIDPOREZ(string iDOBRACUN, int iDRADNIK, int iDPOREZ)
            {
                return (OBRACUNDataSet.ObracunPoreziRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK, iDPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.ObracunPoreziRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnIDPOREZ = new DataColumn("IDPOREZ", typeof(int), "", MappingType.Element);
                this.columnIDPOREZ.AllowDBNull = false;
                this.columnIDPOREZ.Caption = "Šifra poreza";
                this.columnIDPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPOREZ.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPOREZ.ExtendedProperties.Add("Description", "Šifra poreza");
                this.columnIDPOREZ.ExtendedProperties.Add("Length", "5");
                this.columnIDPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "IDPOREZ");
                this.Columns.Add(this.columnIDPOREZ);
                this.columnNAZIVPOREZ = new DataColumn("NAZIVPOREZ", typeof(string), "", MappingType.Element);
                this.columnNAZIVPOREZ.AllowDBNull = false;
                this.columnNAZIVPOREZ.Caption = "Naziv poreza";
                this.columnNAZIVPOREZ.MaxLength = 50;
                this.columnNAZIVPOREZ.DefaultValue = "";
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Description", "Naziv poreza");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPOREZ");
                this.Columns.Add(this.columnNAZIVPOREZ);
                this.columnSTOPAPOREZA = new DataColumn("STOPAPOREZA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAPOREZA.AllowDBNull = false;
                this.columnSTOPAPOREZA.Caption = "Stopa poreza";
                this.columnSTOPAPOREZA.DefaultValue = 0;
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Description", "Stopa poreza");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Length", "4");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "STOPAPOREZA");
                this.Columns.Add(this.columnSTOPAPOREZA);
                this.columnPOREZMJESECNO = new DataColumn("POREZMJESECNO", typeof(decimal), "", MappingType.Element);
                this.columnPOREZMJESECNO.AllowDBNull = false;
                this.columnPOREZMJESECNO.Caption = "Maks. mjesečni iznos osnovice";
                this.columnPOREZMJESECNO.DefaultValue = 0;
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Description", "Maks. mjesečni iznos osnovice");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Length", "12");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.InternalName", "POREZMJESECNO");
                this.Columns.Add(this.columnPOREZMJESECNO);
                this.columnMOPOREZ = new DataColumn("MOPOREZ", typeof(string), "", MappingType.Element);
                this.columnMOPOREZ.AllowDBNull = false;
                this.columnMOPOREZ.Caption = "Model odobrenja poreza";
                this.columnMOPOREZ.MaxLength = 2;
                this.columnMOPOREZ.DefaultValue = "";
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMOPOREZ.ExtendedProperties.Add("Description", "Model odobrenja poreza");
                this.columnMOPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnMOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnMOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "MOPOREZ");
                this.Columns.Add(this.columnMOPOREZ);
                this.columnPOPOREZ = new DataColumn("POPOREZ", typeof(string), "", MappingType.Element);
                this.columnPOPOREZ.AllowDBNull = false;
                this.columnPOPOREZ.Caption = "Poziv na broj odobrenja poreza";
                this.columnPOPOREZ.MaxLength = 0x16;
                this.columnPOPOREZ.DefaultValue = "";
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOPOREZ.ExtendedProperties.Add("Description", "Poziv na broj odobrenja poreza");
                this.columnPOPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnPOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnPOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "POPOREZ");
                this.Columns.Add(this.columnPOPOREZ);
                this.columnMZPOREZ = new DataColumn("MZPOREZ", typeof(string), "", MappingType.Element);
                this.columnMZPOREZ.AllowDBNull = false;
                this.columnMZPOREZ.Caption = "Model zaduženja poreza";
                this.columnMZPOREZ.MaxLength = 2;
                this.columnMZPOREZ.DefaultValue = "";
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMZPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMZPOREZ.ExtendedProperties.Add("Description", "Model zaduženja poreza");
                this.columnMZPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnMZPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnMZPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "MZPOREZ");
                this.Columns.Add(this.columnMZPOREZ);
                this.columnPZPOREZ = new DataColumn("PZPOREZ", typeof(string), "", MappingType.Element);
                this.columnPZPOREZ.AllowDBNull = false;
                this.columnPZPOREZ.Caption = "Poziv na broj zaduženja poreza";
                this.columnPZPOREZ.MaxLength = 0x16;
                this.columnPZPOREZ.DefaultValue = "";
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPZPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPZPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPZPOREZ.ExtendedProperties.Add("Description", "Poziv na broj zaduženja poreza");
                this.columnPZPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnPZPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnPZPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPZPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "PZPOREZ");
                this.Columns.Add(this.columnPZPOREZ);
                this.columnPRIMATELJPOREZ1 = new DataColumn("PRIMATELJPOREZ1", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJPOREZ1.AllowDBNull = false;
                this.columnPRIMATELJPOREZ1.Caption = "Primatelj poreza (1)";
                this.columnPRIMATELJPOREZ1.MaxLength = 20;
                this.columnPRIMATELJPOREZ1.DefaultValue = "";
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Description", "Primatelj poreza (1)");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ1");
                this.Columns.Add(this.columnPRIMATELJPOREZ1);
                this.columnPRIMATELJPOREZ2 = new DataColumn("PRIMATELJPOREZ2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJPOREZ2.AllowDBNull = false;
                this.columnPRIMATELJPOREZ2.Caption = "Primatelj poreza (2)";
                this.columnPRIMATELJPOREZ2.MaxLength = 20;
                this.columnPRIMATELJPOREZ2.DefaultValue = "";
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Description", "Primatelj poreza (2)");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Length", "20");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Decimals", "0");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ2");
                this.Columns.Add(this.columnPRIMATELJPOREZ2);
                this.columnSIFRAOPISAPLACANJAPOREZ = new DataColumn("SIFRAOPISAPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAPOREZ.AllowDBNull = false;
                this.columnSIFRAOPISAPLACANJAPOREZ.Caption = "Šifra opisa plaćanja poreza";
                this.columnSIFRAOPISAPLACANJAPOREZ.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAPOREZ.DefaultValue = "";
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Description", "Šifra opisa plaćanja poreza");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAPOREZ");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAPOREZ);
                this.columnOPISPLACANJAPOREZ = new DataColumn("OPISPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAPOREZ.AllowDBNull = false;
                this.columnOPISPLACANJAPOREZ.Caption = "Opis plaćanja poreza";
                this.columnOPISPLACANJAPOREZ.MaxLength = 0x24;
                this.columnOPISPLACANJAPOREZ.DefaultValue = "";
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Description", "Opis plaćanja poreza");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAPOREZ");
                this.Columns.Add(this.columnOPISPLACANJAPOREZ);
                this.columnOBRACUNATIPOREZ = new DataColumn("OBRACUNATIPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATIPOREZ.AllowDBNull = false;
                this.columnOBRACUNATIPOREZ.Caption = "OBRACUNATIPOREZ";
                this.columnOBRACUNATIPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Description", "OBRACUNATIPOREZ");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATIPOREZ");
                this.Columns.Add(this.columnOBRACUNATIPOREZ);
                this.columnOSNOVICAPOREZ = new DataColumn("OSNOVICAPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnOSNOVICAPOREZ.AllowDBNull = false;
                this.columnOSNOVICAPOREZ.Caption = "OSNOVICAPOREZ";
                this.columnOSNOVICAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Description", "OSNOVICAPOREZ");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OSNOVICAPOREZ");
                this.Columns.Add(this.columnOSNOVICAPOREZ);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK, this.columnIDPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "ObracunRadnici");
                this.ExtendedProperties.Add("LevelName", "OBRACUNLevel4");
                this.ExtendedProperties.Add("Description", "OBRACUNLevel4");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnIDPOREZ = this.Columns["IDPOREZ"];
                this.columnNAZIVPOREZ = this.Columns["NAZIVPOREZ"];
                this.columnSTOPAPOREZA = this.Columns["STOPAPOREZA"];
                this.columnPOREZMJESECNO = this.Columns["POREZMJESECNO"];
                this.columnMOPOREZ = this.Columns["MOPOREZ"];
                this.columnPOPOREZ = this.Columns["POPOREZ"];
                this.columnMZPOREZ = this.Columns["MZPOREZ"];
                this.columnPZPOREZ = this.Columns["PZPOREZ"];
                this.columnPRIMATELJPOREZ1 = this.Columns["PRIMATELJPOREZ1"];
                this.columnPRIMATELJPOREZ2 = this.Columns["PRIMATELJPOREZ2"];
                this.columnSIFRAOPISAPLACANJAPOREZ = this.Columns["SIFRAOPISAPLACANJAPOREZ"];
                this.columnOPISPLACANJAPOREZ = this.Columns["OPISPLACANJAPOREZ"];
                this.columnOBRACUNATIPOREZ = this.Columns["OBRACUNATIPOREZ"];
                this.columnOSNOVICAPOREZ = this.Columns["OSNOVICAPOREZ"];
            }

            public OBRACUNDataSet.ObracunPoreziRow NewObracunPoreziRow()
            {
                return (OBRACUNDataSet.ObracunPoreziRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.ObracunPoreziRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ObracunPoreziRowChanged != null)
                {
                    OBRACUNDataSet.ObracunPoreziRowChangeEventHandler obracunPoreziRowChangedEvent = this.ObracunPoreziRowChanged;
                    if (obracunPoreziRowChangedEvent != null)
                    {
                        obracunPoreziRowChangedEvent(this, new OBRACUNDataSet.ObracunPoreziRowChangeEvent((OBRACUNDataSet.ObracunPoreziRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ObracunPoreziRowChanging != null)
                {
                    OBRACUNDataSet.ObracunPoreziRowChangeEventHandler obracunPoreziRowChangingEvent = this.ObracunPoreziRowChanging;
                    if (obracunPoreziRowChangingEvent != null)
                    {
                        obracunPoreziRowChangingEvent(this, new OBRACUNDataSet.ObracunPoreziRowChangeEvent((OBRACUNDataSet.ObracunPoreziRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("ObracunRadnici_ObracunPorezi", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.ObracunPoreziRowDeleted != null)
                {
                    OBRACUNDataSet.ObracunPoreziRowChangeEventHandler obracunPoreziRowDeletedEvent = this.ObracunPoreziRowDeleted;
                    if (obracunPoreziRowDeletedEvent != null)
                    {
                        obracunPoreziRowDeletedEvent(this, new OBRACUNDataSet.ObracunPoreziRowChangeEvent((OBRACUNDataSet.ObracunPoreziRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ObracunPoreziRowDeleting != null)
                {
                    OBRACUNDataSet.ObracunPoreziRowChangeEventHandler obracunPoreziRowDeletingEvent = this.ObracunPoreziRowDeleting;
                    if (obracunPoreziRowDeletingEvent != null)
                    {
                        obracunPoreziRowDeletingEvent(this, new OBRACUNDataSet.ObracunPoreziRowChangeEvent((OBRACUNDataSet.ObracunPoreziRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveObracunPoreziRow(OBRACUNDataSet.ObracunPoreziRow row)
            {
                this.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDPOREZColumn
            {
                get
                {
                    return this.columnIDPOREZ;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public OBRACUNDataSet.ObracunPoreziRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.ObracunPoreziRow) this.Rows[index];
                }
            }

            public DataColumn MOPOREZColumn
            {
                get
                {
                    return this.columnMOPOREZ;
                }
            }

            public DataColumn MZPOREZColumn
            {
                get
                {
                    return this.columnMZPOREZ;
                }
            }

            public DataColumn NAZIVPOREZColumn
            {
                get
                {
                    return this.columnNAZIVPOREZ;
                }
            }

            public DataColumn OBRACUNATIPOREZColumn
            {
                get
                {
                    return this.columnOBRACUNATIPOREZ;
                }
            }

            public DataColumn OPISPLACANJAPOREZColumn
            {
                get
                {
                    return this.columnOPISPLACANJAPOREZ;
                }
            }

            public DataColumn OSNOVICAPOREZColumn
            {
                get
                {
                    return this.columnOSNOVICAPOREZ;
                }
            }

            public DataColumn POPOREZColumn
            {
                get
                {
                    return this.columnPOPOREZ;
                }
            }

            public DataColumn POREZMJESECNOColumn
            {
                get
                {
                    return this.columnPOREZMJESECNO;
                }
            }

            public DataColumn PRIMATELJPOREZ1Column
            {
                get
                {
                    return this.columnPRIMATELJPOREZ1;
                }
            }

            public DataColumn PRIMATELJPOREZ2Column
            {
                get
                {
                    return this.columnPRIMATELJPOREZ2;
                }
            }

            public DataColumn PZPOREZColumn
            {
                get
                {
                    return this.columnPZPOREZ;
                }
            }

            public DataColumn SIFRAOPISAPLACANJAPOREZColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJAPOREZ;
                }
            }

            public DataColumn STOPAPOREZAColumn
            {
                get
                {
                    return this.columnSTOPAPOREZA;
                }
            }
        }

        public class ObracunPoreziRow : DataRow
        {
            private OBRACUNDataSet.ObracunPoreziDataTable tableObracunPorezi;

            internal ObracunPoreziRow(DataRowBuilder rb) : base(rb)
            {
                this.tableObracunPorezi = (OBRACUNDataSet.ObracunPoreziDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow GetObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.GetParentRow("ObracunRadnici_ObracunPorezi");
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableObracunPorezi.IDOBRACUNColumn);
            }

            public bool IsIDPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.IDPOREZColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableObracunPorezi.IDRADNIKColumn);
            }

            public bool IsMOPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.MOPOREZColumn);
            }

            public bool IsMZPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.MZPOREZColumn);
            }

            public bool IsNAZIVPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.NAZIVPOREZColumn);
            }

            public bool IsOBRACUNATIPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.OBRACUNATIPOREZColumn);
            }

            public bool IsOPISPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.OPISPLACANJAPOREZColumn);
            }

            public bool IsOSNOVICAPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.OSNOVICAPOREZColumn);
            }

            public bool IsPOPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.POPOREZColumn);
            }

            public bool IsPOREZMJESECNONull()
            {
                return this.IsNull(this.tableObracunPorezi.POREZMJESECNOColumn);
            }

            public bool IsPRIMATELJPOREZ1Null()
            {
                return this.IsNull(this.tableObracunPorezi.PRIMATELJPOREZ1Column);
            }

            public bool IsPRIMATELJPOREZ2Null()
            {
                return this.IsNull(this.tableObracunPorezi.PRIMATELJPOREZ2Column);
            }

            public bool IsPZPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.PZPOREZColumn);
            }

            public bool IsSIFRAOPISAPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableObracunPorezi.SIFRAOPISAPLACANJAPOREZColumn);
            }

            public bool IsSTOPAPOREZANull()
            {
                return this.IsNull(this.tableObracunPorezi.STOPAPOREZAColumn);
            }

            public void SetMOPOREZNull()
            {
                this[this.tableObracunPorezi.MOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZPOREZNull()
            {
                this[this.tableObracunPorezi.MZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOREZNull()
            {
                this[this.tableObracunPorezi.NAZIVPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATIPOREZNull()
            {
                this[this.tableObracunPorezi.OBRACUNATIPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAPOREZNull()
            {
                this[this.tableObracunPorezi.OPISPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVICAPOREZNull()
            {
                this[this.tableObracunPorezi.OSNOVICAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOPOREZNull()
            {
                this[this.tableObracunPorezi.POPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZMJESECNONull()
            {
                this[this.tableObracunPorezi.POREZMJESECNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ1Null()
            {
                this[this.tableObracunPorezi.PRIMATELJPOREZ1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ2Null()
            {
                this[this.tableObracunPorezi.PRIMATELJPOREZ2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZPOREZNull()
            {
                this[this.tableObracunPorezi.PZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAPOREZNull()
            {
                this[this.tableObracunPorezi.SIFRAOPISAPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAPOREZANull()
            {
                this[this.tableObracunPorezi.STOPAPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableObracunPorezi.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableObracunPorezi.IDOBRACUNColumn] = value;
                }
            }

            public int IDPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunPorezi.IDPOREZColumn]);
                }
                set
                {
                    this[this.tableObracunPorezi.IDPOREZColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunPorezi.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableObracunPorezi.IDRADNIKColumn] = value;
                }
            }

            public string MOPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.MOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.MOPOREZColumn] = value;
                }
            }

            public string MZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.MZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.MZPOREZColumn] = value;
                }
            }

            public string NAZIVPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.NAZIVPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.NAZIVPOREZColumn] = value;
                }
            }

            public decimal OBRACUNATIPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunPorezi.OBRACUNATIPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunPorezi.OBRACUNATIPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.OPISPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.OPISPLACANJAPOREZColumn] = value;
                }
            }

            public decimal OSNOVICAPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunPorezi.OSNOVICAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunPorezi.OSNOVICAPOREZColumn] = value;
                }
            }

            public string POPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.POPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.POPOREZColumn] = value;
                }
            }

            public decimal POREZMJESECNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunPorezi.POREZMJESECNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunPorezi.POREZMJESECNOColumn] = value;
                }
            }

            public string PRIMATELJPOREZ1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.PRIMATELJPOREZ1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.PRIMATELJPOREZ1Column] = value;
                }
            }

            public string PRIMATELJPOREZ2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.PRIMATELJPOREZ2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.PRIMATELJPOREZ2Column] = value;
                }
            }

            public string PZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.PZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.PZPOREZColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunPorezi.SIFRAOPISAPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunPorezi.SIFRAOPISAPLACANJAPOREZColumn] = value;
                }
            }

            public decimal STOPAPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunPorezi.STOPAPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunPorezi.STOPAPOREZAColumn] = value;
                }
            }
        }

        public class ObracunPoreziRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.ObracunPoreziRow eventRow;

            public ObracunPoreziRowChangeEvent(OBRACUNDataSet.ObracunPoreziRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.ObracunPoreziRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ObracunPoreziRowChangeEventHandler(object sender, OBRACUNDataSet.ObracunPoreziRowChangeEvent e);

        [Serializable]
        public class ObracunRadniciDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVAN;
            private DataColumn columnBROJMIROVINSKOG;
            private DataColumn columnBROJPRIZNATIHMJESECI;
            private DataColumn columnBROJZDRAVSTVENOG;
            private DataColumn columnDANISTAZA;
            private DataColumn columnDATUMPRESTANKARADNOGODNOSA;
            private DataColumn columnDATUMRODJENJA;
            private DataColumn columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
            private DataColumn columnfaktoo;
            private DataColumn columnGODINESTAZA;
            private DataColumn columnIDBANKE;
            private DataColumn columnIDBENEFICIRANI;
            private DataColumn columnIDIPIDENT;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDORGDIO;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIDRADNOMJESTO;
            private DataColumn columnIDSTRUKA;
            private DataColumn columnIDTITULA;
            private DataColumn columnIME;
            private DataColumn columnISKORISTENOOO;
            private DataColumn columnJMBG;
            private DataColumn columnKOEFICIJENT;
            private DataColumn columnKOREKCIJAPRIREZA;
            private DataColumn columnkucnibroj;
            private DataColumn columnMBO;
            private DataColumn columnMJESECISTAZA;
            private DataColumn columnmjesto;
            private DataColumn columnNAZIVBANKE1;
            private DataColumn columnNAZIVBANKE2;
            private DataColumn columnNAZIVBANKE3;
            private DataColumn columnNAZIVBENEFICIRANI;
            private DataColumn columnNAZIVRADNOMJESTO;
            private DataColumn columnNAZIVSTRUKA;
            private DataColumn columnNAZIVTITULA;
            private DataColumn columnOBRACUNATIPRIREZ;
            private DataColumn columnOBRACUNAVAJOBUSTAVE;
            private DataColumn columnOBRACUNSKIKOEFICIJENT;
            private DataColumn columnODBITAKPRIJEKOREKCIJE;
            private DataColumn columnOIB;
            private DataColumn columnOPCINARADAIDOPCINE;
            private DataColumn columnOPCINARADANAZIVOPCINE;
            private DataColumn columnOPCINARADAPRIREZ;
            private DataColumn columnOPCINASTANOVANJAIDOPCINE;
            private DataColumn columnOPCINASTANOVANJANAZIVOPCINE;
            private DataColumn columnOPCINASTANOVANJAPRIREZ;
            private DataColumn columnOPISPLACANJANETO;
            private DataColumn columnORGANIZACIJSKIDIO;
            private DataColumn columnPOSTOTAKNASTAZ;
            private DataColumn columnPOSTOTAKOSLOBODJENJAODPOREZA;
            private DataColumn columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            private DataColumn columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA;
            private DataColumn columnPREZIME;
            private DataColumn columnRADNIKOBRACUNOSNOVICA;
            private DataColumn columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            private DataColumn columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA;
            private DataColumn columnSIFRAOPCINESTANOVANJA;
            private DataColumn columnSIFRAOPISAPLACANJANETO;
            private DataColumn columnTEKUCI;
            private DataColumn columnTJEDNIFONDSATI;
            private DataColumn columnTJEDNIFONDSATISTAZ;
            private DataColumn columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            private DataColumn columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA;
            private DataColumn columnulica;
            private DataColumn columnUZIMAUOBZIROSNOVICEDOPRINOSA;
            private DataColumn columnVBDIBANKE;
            private DataColumn columnZBIRNINETO;
            private DataColumn columnZRNBANKE;

            public event OBRACUNDataSet.ObracunRadniciRowChangeEventHandler ObracunRadniciRowChanged;

            public event OBRACUNDataSet.ObracunRadniciRowChangeEventHandler ObracunRadniciRowChanging;

            public event OBRACUNDataSet.ObracunRadniciRowChangeEventHandler ObracunRadniciRowDeleted;

            public event OBRACUNDataSet.ObracunRadniciRowChangeEventHandler ObracunRadniciRowDeleting;

            public ObracunRadniciDataTable()
            {
                this.TableName = "ObracunRadnici";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ObracunRadniciDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    this.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }

            protected ObracunRadniciDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddObracunRadniciRow(OBRACUNDataSet.ObracunRadniciRow row)
            {
                this.Rows.Add(row);
            }

            public OBRACUNDataSet.ObracunRadniciRow AddObracunRadniciRow(string iDOBRACUN, int iDRADNIK, string sIFRAOPCINESTANOVANJA, decimal oBRACUNSKIKOEFICIJENT, decimal iSKORISTENOOO, decimal oBRACUNATIPRIREZ, decimal faktoo, decimal rADNIKOBRACUNOSNOVICA, decimal kOREKCIJAPRIREZA, decimal oDBITAKPRIJEKOREKCIJE, bool oBRACUNAVAJOBUSTAVE)
            {
                OBRACUNDataSet.ObracunRadniciRow row = (OBRACUNDataSet.ObracunRadniciRow) this.NewRow();
                row["IDOBRACUN"] = iDOBRACUN;
                row["IDRADNIK"] = iDRADNIK;
                row["SIFRAOPCINESTANOVANJA"] = sIFRAOPCINESTANOVANJA;
                row["OBRACUNSKIKOEFICIJENT"] = oBRACUNSKIKOEFICIJENT;
                row["ISKORISTENOOO"] = iSKORISTENOOO;
                row["OBRACUNATIPRIREZ"] = oBRACUNATIPRIREZ;
                row["faktoo"] = faktoo;
                row["RADNIKOBRACUNOSNOVICA"] = rADNIKOBRACUNOSNOVICA;
                row["KOREKCIJAPRIREZA"] = kOREKCIJAPRIREZA;
                row["ODBITAKPRIJEKOREKCIJE"] = oDBITAKPRIJEKOREKCIJE;
                row["OBRACUNAVAJOBUSTAVE"] = oBRACUNAVAJOBUSTAVE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OBRACUNDataSet.ObracunRadniciDataTable table = (OBRACUNDataSet.ObracunRadniciDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OBRACUNDataSet.ObracunRadniciRow FindByIDOBRACUNIDRADNIK(string iDOBRACUN, int iDRADNIK)
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.Rows.Find(new object[] { iDOBRACUN, iDRADNIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OBRACUNDataSet.ObracunRadniciRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OBRACUNDataSet set = new OBRACUNDataSet();
                xs.Add(set.GetSchemaSerializable());
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema"
                };
                decimal num = new decimal(0);
                item.MinOccurs = num;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                };
                num = new decimal(1);
                any2.MinOccurs = num;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type2.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "InvoiceDataTable"
                };
                type2.Attributes.Add(attribute2);
                type2.Particle = sequence;
                return type2;
            }

            public void InitClass()
            {
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.AllowDBNull = false;
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.AllowDBNull = false;
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnPREZIME = new DataColumn("PREZIME", typeof(string), "", MappingType.Element);
                this.columnPREZIME.AllowDBNull = true;
                this.columnPREZIME.Caption = "Prezime";
                this.columnPREZIME.MaxLength = 50;
                this.columnPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIME");
                this.Columns.Add(this.columnPREZIME);
                this.columnIME = new DataColumn("IME", typeof(string), "", MappingType.Element);
                this.columnIME.AllowDBNull = true;
                this.columnIME.Caption = "Ime";
                this.columnIME.MaxLength = 50;
                this.columnIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIME.ExtendedProperties.Add("IsKey", "false");
                this.columnIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIME.ExtendedProperties.Add("Description", "Ime");
                this.columnIME.ExtendedProperties.Add("Length", "50");
                this.columnIME.ExtendedProperties.Add("Decimals", "0");
                this.columnIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIME.ExtendedProperties.Add("Deklarit.InternalName", "IME");
                this.Columns.Add(this.columnIME);
                this.columnulica = new DataColumn("ulica", typeof(string), "", MappingType.Element);
                this.columnulica.AllowDBNull = true;
                this.columnulica.Caption = "Ulica";
                this.columnulica.MaxLength = 50;
                this.columnulica.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnulica.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnulica.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnulica.ExtendedProperties.Add("IsKey", "false");
                this.columnulica.ExtendedProperties.Add("ReadOnly", "true");
                this.columnulica.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnulica.ExtendedProperties.Add("Description", "Ulica");
                this.columnulica.ExtendedProperties.Add("Length", "50");
                this.columnulica.ExtendedProperties.Add("Decimals", "0");
                this.columnulica.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnulica.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnulica.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnulica.ExtendedProperties.Add("Deklarit.InternalName", "ulica");
                this.Columns.Add(this.columnulica);
                this.columnmjesto = new DataColumn("mjesto", typeof(string), "", MappingType.Element);
                this.columnmjesto.AllowDBNull = true;
                this.columnmjesto.Caption = "Mjesto";
                this.columnmjesto.MaxLength = 50;
                this.columnmjesto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmjesto.ExtendedProperties.Add("IsKey", "false");
                this.columnmjesto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmjesto.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmjesto.ExtendedProperties.Add("Description", "Mjesto");
                this.columnmjesto.ExtendedProperties.Add("Length", "50");
                this.columnmjesto.ExtendedProperties.Add("Decimals", "0");
                this.columnmjesto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmjesto.ExtendedProperties.Add("Deklarit.InternalName", "mjesto");
                this.Columns.Add(this.columnmjesto);
                this.columnkucnibroj = new DataColumn("kucnibroj", typeof(string), "", MappingType.Element);
                this.columnkucnibroj.AllowDBNull = true;
                this.columnkucnibroj.Caption = "Kućni broj";
                this.columnkucnibroj.MaxLength = 10;
                this.columnkucnibroj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkucnibroj.ExtendedProperties.Add("IsKey", "false");
                this.columnkucnibroj.ExtendedProperties.Add("ReadOnly", "true");
                this.columnkucnibroj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnkucnibroj.ExtendedProperties.Add("Description", "Kućni broj");
                this.columnkucnibroj.ExtendedProperties.Add("Length", "10");
                this.columnkucnibroj.ExtendedProperties.Add("Decimals", "0");
                this.columnkucnibroj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkucnibroj.ExtendedProperties.Add("Deklarit.InternalName", "kucnibroj");
                this.Columns.Add(this.columnkucnibroj);
                this.columnJMBG = new DataColumn("JMBG", typeof(string), "", MappingType.Element);
                this.columnJMBG.AllowDBNull = true;
                this.columnJMBG.Caption = "JMBG";
                this.columnJMBG.MaxLength = 13;
                this.columnJMBG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnJMBG.ExtendedProperties.Add("IsKey", "false");
                this.columnJMBG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnJMBG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnJMBG.ExtendedProperties.Add("Description", "JMBG");
                this.columnJMBG.ExtendedProperties.Add("Length", "13");
                this.columnJMBG.ExtendedProperties.Add("Decimals", "0");
                this.columnJMBG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnJMBG.ExtendedProperties.Add("Deklarit.InternalName", "JMBG");
                this.Columns.Add(this.columnJMBG);
                this.columnDATUMRODJENJA = new DataColumn("DATUMRODJENJA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMRODJENJA.AllowDBNull = true;
                this.columnDATUMRODJENJA.Caption = "Datum rođenja";
                this.columnDATUMRODJENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Description", "Datum rođenja");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMRODJENJA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMRODJENJA");
                this.Columns.Add(this.columnDATUMRODJENJA);
                this.columnOPCINARADAIDOPCINE = new DataColumn("OPCINARADAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINARADAIDOPCINE.AllowDBNull = true;
                this.columnOPCINARADAIDOPCINE.Caption = "Šifra općine rada";
                this.columnOPCINARADAIDOPCINE.MaxLength = 4;
                this.columnOPCINARADAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINARADA");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine rada");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINARADAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINARADAIDOPCINE");
                this.Columns.Add(this.columnOPCINARADAIDOPCINE);
                this.columnOPCINARADANAZIVOPCINE = new DataColumn("OPCINARADANAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINARADANAZIVOPCINE.AllowDBNull = true;
                this.columnOPCINARADANAZIVOPCINE.Caption = "Naziv općine rada";
                this.columnOPCINARADANAZIVOPCINE.MaxLength = 50;
                this.columnOPCINARADANAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("SuperType", "NAZIVOPCINE");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINARADA");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine rada");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINARADANAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINARADANAZIVOPCINE");
                this.Columns.Add(this.columnOPCINARADANAZIVOPCINE);
                this.columnOPCINARADAPRIREZ = new DataColumn("OPCINARADAPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnOPCINARADAPRIREZ.AllowDBNull = true;
                this.columnOPCINARADAPRIREZ.Caption = "PRIREZ";
                this.columnOPCINARADAPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("SuperType", "PRIREZ");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("SubtypeGroup", "OPCINARADA");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Description", "PRIREZ");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINARADAPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPCINARADAPRIREZ");
                this.Columns.Add(this.columnOPCINARADAPRIREZ);
                this.columnOPCINASTANOVANJAIDOPCINE = new DataColumn("OPCINASTANOVANJAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAIDOPCINE.AllowDBNull = true;
                this.columnOPCINASTANOVANJAIDOPCINE.Caption = "Šifra općine stanovanja";
                this.columnOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
                this.columnOPCINASTANOVANJAIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SuperType", "IDOPCINE");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine stanovanja");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAIDOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJAIDOPCINE);
                this.columnOPCINASTANOVANJANAZIVOPCINE = new DataColumn("OPCINASTANOVANJANAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJANAZIVOPCINE.AllowDBNull = true;
                this.columnOPCINASTANOVANJANAZIVOPCINE.Caption = "Naziv općine stanovanja";
                this.columnOPCINASTANOVANJANAZIVOPCINE.MaxLength = 50;
                this.columnOPCINASTANOVANJANAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("SuperType", "NAZIVOPCINE");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine stanovanja");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJANAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJANAZIVOPCINE");
                this.Columns.Add(this.columnOPCINASTANOVANJANAZIVOPCINE);
                this.columnOPCINASTANOVANJAPRIREZ = new DataColumn("OPCINASTANOVANJAPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnOPCINASTANOVANJAPRIREZ.AllowDBNull = true;
                this.columnOPCINASTANOVANJAPRIREZ.Caption = "Prirez općine stanovanja";
                this.columnOPCINASTANOVANJAPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("SuperType", "PRIREZ");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Description", "Prirez općine stanovanja");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAPRIREZ");
                this.Columns.Add(this.columnOPCINASTANOVANJAPRIREZ);
                this.columnSIFRAOPCINESTANOVANJA = new DataColumn("SIFRAOPCINESTANOVANJA", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPCINESTANOVANJA.AllowDBNull = false;
                this.columnSIFRAOPCINESTANOVANJA.Caption = "Šifra općine";
                this.columnSIFRAOPCINESTANOVANJA.MaxLength = 4;
                this.columnSIFRAOPCINESTANOVANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Description", "Šifra općine");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Length", "4");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPCINESTANOVANJA");
                this.Columns.Add(this.columnSIFRAOPCINESTANOVANJA);
                this.columnIDBENEFICIRANI = new DataColumn("IDBENEFICIRANI", typeof(string), "", MappingType.Element);
                this.columnIDBENEFICIRANI.AllowDBNull = true;
                this.columnIDBENEFICIRANI.Caption = "Šifra beneficiranog radnog staža";
                this.columnIDBENEFICIRANI.MaxLength = 1;
                this.columnIDBENEFICIRANI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Description", "Šifra beneficiranog radnog staža");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Length", "1");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.InternalName", "IDBENEFICIRANI");
                this.Columns.Add(this.columnIDBENEFICIRANI);
                this.columnNAZIVBENEFICIRANI = new DataColumn("NAZIVBENEFICIRANI", typeof(string), "", MappingType.Element);
                this.columnNAZIVBENEFICIRANI.AllowDBNull = true;
                this.columnNAZIVBENEFICIRANI.Caption = "Naziv beneficiranog radnog staža";
                this.columnNAZIVBENEFICIRANI.MaxLength = 50;
                this.columnNAZIVBENEFICIRANI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Description", "Naziv beneficiranog radnog staža");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBENEFICIRANI");
                this.Columns.Add(this.columnNAZIVBENEFICIRANI);
                this.columnBROJPRIZNATIHMJESECI = new DataColumn("BROJPRIZNATIHMJESECI", typeof(short), "", MappingType.Element);
                this.columnBROJPRIZNATIHMJESECI.AllowDBNull = true;
                this.columnBROJPRIZNATIHMJESECI.Caption = "Broj priznatih mjeseci za 12 mjeseci rada";
                this.columnBROJPRIZNATIHMJESECI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Description", "Broj priznatih mjeseci za 12 mjeseci rada");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Length", "2");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.InternalName", "BROJPRIZNATIHMJESECI");
                this.Columns.Add(this.columnBROJPRIZNATIHMJESECI);
                this.columnIDBANKE = new DataColumn("IDBANKE", typeof(int), "", MappingType.Element);
                this.columnIDBANKE.AllowDBNull = true;
                this.columnIDBANKE.Caption = "Šifra banke";
                this.columnIDBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDBANKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBANKE.ExtendedProperties.Add("Description", "Šifra banke");
                this.columnIDBANKE.ExtendedProperties.Add("Length", "5");
                this.columnIDBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBANKE.ExtendedProperties.Add("Deklarit.InternalName", "IDBANKE");
                this.Columns.Add(this.columnIDBANKE);
                this.columnNAZIVBANKE1 = new DataColumn("NAZIVBANKE1", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE1.AllowDBNull = true;
                this.columnNAZIVBANKE1.Caption = "Naziv banke";
                this.columnNAZIVBANKE1.MaxLength = 20;
                this.columnNAZIVBANKE1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Description", "Naziv banke");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE1.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE1");
                this.Columns.Add(this.columnNAZIVBANKE1);
                this.columnNAZIVBANKE2 = new DataColumn("NAZIVBANKE2", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE2.AllowDBNull = true;
                this.columnNAZIVBANKE2.Caption = "Naziv banke (2)";
                this.columnNAZIVBANKE2.MaxLength = 20;
                this.columnNAZIVBANKE2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Description", "Naziv banke (2)");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE2.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE2");
                this.Columns.Add(this.columnNAZIVBANKE2);
                this.columnNAZIVBANKE3 = new DataColumn("NAZIVBANKE3", typeof(string), "", MappingType.Element);
                this.columnNAZIVBANKE3.AllowDBNull = true;
                this.columnNAZIVBANKE3.Caption = "Naziv banke (3)";
                this.columnNAZIVBANKE3.MaxLength = 20;
                this.columnNAZIVBANKE3.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Description", "Naziv banke (3)");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBANKE3.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBANKE3");
                this.Columns.Add(this.columnNAZIVBANKE3);
                this.columnVBDIBANKE = new DataColumn("VBDIBANKE", typeof(string), "", MappingType.Element);
                this.columnVBDIBANKE.AllowDBNull = true;
                this.columnVBDIBANKE.Caption = "VBDI žiro računa banke";
                this.columnVBDIBANKE.MaxLength = 7;
                this.columnVBDIBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIBANKE.ExtendedProperties.Add("Description", "VBDI žiro računa banke");
                this.columnVBDIBANKE.ExtendedProperties.Add("Length", "7");
                this.columnVBDIBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIBANKE.ExtendedProperties.Add("Deklarit.InternalName", "VBDIBANKE");
                this.Columns.Add(this.columnVBDIBANKE);
                this.columnZRNBANKE = new DataColumn("ZRNBANKE", typeof(string), "", MappingType.Element);
                this.columnZRNBANKE.AllowDBNull = true;
                this.columnZRNBANKE.Caption = "Broj žiro računa banke";
                this.columnZRNBANKE.MaxLength = 10;
                this.columnZRNBANKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNBANKE.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNBANKE.ExtendedProperties.Add("Description", "Broj žiro računa banke");
                this.columnZRNBANKE.ExtendedProperties.Add("Length", "10");
                this.columnZRNBANKE.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNBANKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNBANKE.ExtendedProperties.Add("Deklarit.InternalName", "ZRNBANKE");
                this.Columns.Add(this.columnZRNBANKE);

                this.columnTEKUCI = new DataColumn("TEKUCI", typeof(string), "", MappingType.Element);
                this.columnTEKUCI.AllowDBNull = true;
                this.columnTEKUCI.Caption = "IBAN";
                this.columnTEKUCI.MaxLength = 25;
                this.columnTEKUCI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTEKUCI.ExtendedProperties.Add("IsKey", "false");
                this.columnTEKUCI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTEKUCI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnTEKUCI.ExtendedProperties.Add("Description", "IBAN");
                this.columnTEKUCI.ExtendedProperties.Add("Length", "25");
                this.columnTEKUCI.ExtendedProperties.Add("Decimals", "0");
                this.columnTEKUCI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTEKUCI.ExtendedProperties.Add("Deklarit.InternalName", "TEKUCI");
                this.Columns.Add(this.columnTEKUCI);

                this.columnSIFRAOPISAPLACANJANETO = new DataColumn("SIFRAOPISAPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJANETO.AllowDBNull = true;
                this.columnSIFRAOPISAPLACANJANETO.Caption = "Šifra opisa plaćanja (iznos za isplatu)";
                this.columnSIFRAOPISAPLACANJANETO.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Description", "Šifra opisa plaćanja (iznos za isplatu)");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Length", "2");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJANETO");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJANETO);
                this.columnOPISPLACANJANETO = new DataColumn("OPISPLACANJANETO", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJANETO.AllowDBNull = true;
                this.columnOPISPLACANJANETO.Caption = "Opis plaćanja (iznos za isplatu)";
                this.columnOPISPLACANJANETO.MaxLength = 0x24;
                this.columnOPISPLACANJANETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Description", "Opis plaćanja (iznos za isplatu)");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Length", "36");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJANETO.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJANETO");
                this.Columns.Add(this.columnOPISPLACANJANETO);
                this.columnBROJMIROVINSKOG = new DataColumn("BROJMIROVINSKOG", typeof(string), "", MappingType.Element);
                this.columnBROJMIROVINSKOG.AllowDBNull = true;
                this.columnBROJMIROVINSKOG.Caption = "Broj mirovinskog osiguranja";
                this.columnBROJMIROVINSKOG.MaxLength = 50;
                this.columnBROJMIROVINSKOG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Description", "Broj mirovinskog osiguranja");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Length", "50");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJMIROVINSKOG.ExtendedProperties.Add("Deklarit.InternalName", "BROJMIROVINSKOG");
                this.Columns.Add(this.columnBROJMIROVINSKOG);
                this.columnBROJZDRAVSTVENOG = new DataColumn("BROJZDRAVSTVENOG", typeof(string), "", MappingType.Element);
                this.columnBROJZDRAVSTVENOG.AllowDBNull = true;
                this.columnBROJZDRAVSTVENOG.Caption = "Broj zdravstvenog osiguranja";
                this.columnBROJZDRAVSTVENOG.MaxLength = 50;
                this.columnBROJZDRAVSTVENOG.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Description", "Broj zdravstvenog osiguranja");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Length", "50");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJZDRAVSTVENOG.ExtendedProperties.Add("Deklarit.InternalName", "BROJZDRAVSTVENOG");
                this.Columns.Add(this.columnBROJZDRAVSTVENOG);
                this.columnMBO = new DataColumn("MBO", typeof(string), "", MappingType.Element);
                this.columnMBO.AllowDBNull = true;
                this.columnMBO.Caption = "Matični broj osiguranika";
                this.columnMBO.MaxLength = 50;
                this.columnMBO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMBO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBO.ExtendedProperties.Add("IsKey", "false");
                this.columnMBO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMBO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBO.ExtendedProperties.Add("Description", "Matični broj osiguranika");
                this.columnMBO.ExtendedProperties.Add("Length", "50");
                this.columnMBO.ExtendedProperties.Add("Decimals", "0");
                this.columnMBO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMBO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBO.ExtendedProperties.Add("Deklarit.InternalName", "MBO");
                this.Columns.Add(this.columnMBO);
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA = new DataColumn("POSTOTAKOSLOBODJENJAODPOREZA", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.AllowDBNull = true;
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.Caption = "Postotak oslobođenja od poreza (HRVI, ...)";
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Description", "Postotak oslobođenja od poreza (HRVI, ...)");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAKOSLOBODJENJAODPOREZA");
                this.Columns.Add(this.columnPOSTOTAKOSLOBODJENJAODPOREZA);
                this.columnKOEFICIJENT = new DataColumn("KOEFICIJENT", typeof(decimal), "", MappingType.Element);
                this.columnKOEFICIJENT.AllowDBNull = false;
                this.columnKOEFICIJENT.Caption = "Koeficijent";
                this.columnKOEFICIJENT.DefaultValue = 0;
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOEFICIJENT.ExtendedProperties.Add("IsKey", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnKOEFICIJENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Description", "Koeficijent");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Length", "17");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Decimals", "10");
                this.columnKOEFICIJENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOEFICIJENT.ExtendedProperties.Add("Deklarit.InternalName", "KOEFICIJENT");
                this.Columns.Add(this.columnKOEFICIJENT);
                this.columnOBRACUNSKIKOEFICIJENT = new DataColumn("OBRACUNSKIKOEFICIJENT", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNSKIKOEFICIJENT.AllowDBNull = false;
                this.columnOBRACUNSKIKOEFICIJENT.Caption = "OBRACUNSKIKOEFICIJENT";
                this.columnOBRACUNSKIKOEFICIJENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Description", "Obračunski koeficijent");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Length", "17");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Decimals", "10");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNSKIKOEFICIJENT.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNSKIKOEFICIJENT");
                this.Columns.Add(this.columnOBRACUNSKIKOEFICIJENT);
                this.columnIDRADNOMJESTO = new DataColumn("IDRADNOMJESTO", typeof(int), "", MappingType.Element);
                this.columnIDRADNOMJESTO.AllowDBNull = true;
                this.columnIDRADNOMJESTO.Caption = "Šifra radnog mjesta";
                this.columnIDRADNOMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Description", "Šifra radnog mjesta");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Length", "5");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNOMJESTO");
                this.Columns.Add(this.columnIDRADNOMJESTO);
                this.columnNAZIVRADNOMJESTO = new DataColumn("NAZIVRADNOMJESTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVRADNOMJESTO.AllowDBNull = true;
                this.columnNAZIVRADNOMJESTO.Caption = "Naziv radnog mjesta";
                this.columnNAZIVRADNOMJESTO.MaxLength = 50;
                this.columnNAZIVRADNOMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Description", "Naziv radnog mjesta");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRADNOMJESTO");
                this.Columns.Add(this.columnNAZIVRADNOMJESTO);
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = new DataColumn("TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", typeof(int), "", MappingType.Element);
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.AllowDBNull = true;
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.Caption = "Šifra stručne spreme";
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "IDSTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "TRENUTNASTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Description", "Šifra stručne spreme");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Length", "5");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
                this.Columns.Add(this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA = new DataColumn("TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA", typeof(string), "", MappingType.Element);
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.AllowDBNull = true;
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.Caption = "Naziv stručne spreme";
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.MaxLength = 50;
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "NAZIVSTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "TRENUTNASTRUCNASPREMA");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Description", "Naziv stručne spreme");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Length", "50");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA");
                this.Columns.Add(this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA);
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = new DataColumn("POTREBNASTRUCNASPREMAIDSTRUCNASPREMA", typeof(int), "", MappingType.Element);
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.AllowDBNull = true;
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.Caption = "Šifra potrebne stručne spreme";
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "IDSTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "POTREBNASTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Description", "Šifra potrebne stručne spreme");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Length", "5");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "POTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
                this.Columns.Add(this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA = new DataColumn("POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA", typeof(string), "", MappingType.Element);
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.AllowDBNull = true;
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.Caption = "Naziv potrebne stručne spreme";
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.MaxLength = 50;
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SuperType", "NAZIVSTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("SubtypeGroup", "POTREBNASTRUCNASPREMA");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Description", "Naziv potrebne stručne spreme");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Length", "50");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA");
                this.Columns.Add(this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA);
                this.columnIDSTRUKA = new DataColumn("IDSTRUKA", typeof(int), "", MappingType.Element);
                this.columnIDSTRUKA.AllowDBNull = true;
                this.columnIDSTRUKA.Caption = "Šifra struke";
                this.columnIDSTRUKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSTRUKA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSTRUKA.ExtendedProperties.Add("Description", "Šifra struke");
                this.columnIDSTRUKA.ExtendedProperties.Add("Length", "5");
                this.columnIDSTRUKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSTRUKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSTRUKA.ExtendedProperties.Add("Deklarit.InternalName", "IDSTRUKA");
                this.Columns.Add(this.columnIDSTRUKA);
                this.columnNAZIVSTRUKA = new DataColumn("NAZIVSTRUKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSTRUKA.AllowDBNull = true;
                this.columnNAZIVSTRUKA.Caption = "Naziv struke";
                this.columnNAZIVSTRUKA.MaxLength = 50;
                this.columnNAZIVSTRUKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Description", "Naziv struke");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSTRUKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSTRUKA");
                this.Columns.Add(this.columnNAZIVSTRUKA);
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = new DataColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", typeof(int), "", MappingType.Element);
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.AllowDBNull = true;
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.Caption = "Šifra skupine poreza i doprinosa";
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SuperType", "IDSKUPPOREZAIDOPRINOSA");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SubtypeGroup", "RADNIKPOREZIDOPRINOS");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Šifra skupine poreza i doprinosa");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "5");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA = new DataColumn("RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA", typeof(string), "", MappingType.Element);
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.AllowDBNull = true;
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.Caption = "Naziv skupine poreza i doprinosa";
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.MaxLength = 50;
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SuperType", "NAZIVSKUPPOREZAIDOPRINOSA");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("SubtypeGroup", "RADNIKPOREZIDOPRINOS");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Description", "Naziv skupine poreza i doprinosa");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Length", "50");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA");
                this.Columns.Add(this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA);
                this.columnAKTIVAN = new DataColumn("AKTIVAN", typeof(bool), "", MappingType.Element);
                this.columnAKTIVAN.AllowDBNull = true;
                this.columnAKTIVAN.Caption = "Aktivan";
                this.columnAKTIVAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVAN.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVAN.ExtendedProperties.Add("Description", "Aktivan");
                this.columnAKTIVAN.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVAN.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVAN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVAN.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVAN");
                this.Columns.Add(this.columnAKTIVAN);
                this.columnISKORISTENOOO = new DataColumn("ISKORISTENOOO", typeof(decimal), "", MappingType.Element);
                this.columnISKORISTENOOO.AllowDBNull = true;
                this.columnISKORISTENOOO.Caption = "OSOBNIODBITAK";
                this.columnISKORISTENOOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnISKORISTENOOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnISKORISTENOOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnISKORISTENOOO.ExtendedProperties.Add("IsKey", "false");
                this.columnISKORISTENOOO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnISKORISTENOOO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnISKORISTENOOO.ExtendedProperties.Add("Description", "OSOBNIODBITAK");
                this.columnISKORISTENOOO.ExtendedProperties.Add("Length", "12");
                this.columnISKORISTENOOO.ExtendedProperties.Add("Decimals", "2");
                this.columnISKORISTENOOO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnISKORISTENOOO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnISKORISTENOOO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnISKORISTENOOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnISKORISTENOOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnISKORISTENOOO.ExtendedProperties.Add("Deklarit.InternalName", "ISKORISTENOOO");
                this.Columns.Add(this.columnISKORISTENOOO);
                this.columnOBRACUNATIPRIREZ = new DataColumn("OBRACUNATIPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnOBRACUNATIPRIREZ.AllowDBNull = false;
                this.columnOBRACUNATIPRIREZ.Caption = "OBRACUNATIPRIREZ";
                this.columnOBRACUNATIPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Description", "OBRACUNATIPRIREZ");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNATIPRIREZ");
                this.Columns.Add(this.columnOBRACUNATIPRIREZ);
                this.columnfaktoo = new DataColumn("faktoo", typeof(decimal), "", MappingType.Element);
                this.columnfaktoo.AllowDBNull = false;
                this.columnfaktoo.Caption = "faktoo";
                this.columnfaktoo.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnfaktoo.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnfaktoo.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnfaktoo.ExtendedProperties.Add("IsKey", "false");
                this.columnfaktoo.ExtendedProperties.Add("ReadOnly", "false");
                this.columnfaktoo.ExtendedProperties.Add("DeklaritType", "int");
                this.columnfaktoo.ExtendedProperties.Add("Description", "faktoo");
                this.columnfaktoo.ExtendedProperties.Add("Length", "5");
                this.columnfaktoo.ExtendedProperties.Add("Decimals", "2");
                this.columnfaktoo.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnfaktoo.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnfaktoo.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnfaktoo.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnfaktoo.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnfaktoo.ExtendedProperties.Add("Deklarit.InternalName", "faktoo");
                this.Columns.Add(this.columnfaktoo);
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = new DataColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.AllowDBNull = true;
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.Caption = "Datum zadnjeg zaposlenja ili promjene fonda sati";
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Description", "Datum zadnjeg zaposlenja ili promjene fonda sati");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Length", "8");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI.ExtendedProperties.Add("Deklarit.InternalName", "DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI");
                this.Columns.Add(this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI);
                this.columnTJEDNIFONDSATI = new DataColumn("TJEDNIFONDSATI", typeof(decimal), "", MappingType.Element);
                this.columnTJEDNIFONDSATI.AllowDBNull = true;
                this.columnTJEDNIFONDSATI.Caption = "Tjedni fond sati (za obračun)";
                this.columnTJEDNIFONDSATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Description", "Tjedni fond sati (za obračun)");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Length", "5");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Decimals", "2");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTJEDNIFONDSATI.ExtendedProperties.Add("Deklarit.InternalName", "TJEDNIFONDSATI");
                this.Columns.Add(this.columnTJEDNIFONDSATI);
                this.columnTJEDNIFONDSATISTAZ = new DataColumn("TJEDNIFONDSATISTAZ", typeof(decimal), "", MappingType.Element);
                this.columnTJEDNIFONDSATISTAZ.AllowDBNull = true;
                this.columnTJEDNIFONDSATISTAZ.Caption = "Tjedni fond sati (za izračun staža)";
                this.columnTJEDNIFONDSATISTAZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("IsKey", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Description", "Tjedni fond sati (za izračun staža)");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Length", "5");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Decimals", "2");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnTJEDNIFONDSATISTAZ.ExtendedProperties.Add("Deklarit.InternalName", "TJEDNIFONDSATISTAZ");
                this.Columns.Add(this.columnTJEDNIFONDSATISTAZ);
                this.columnGODINESTAZA = new DataColumn("GODINESTAZA", typeof(short), "", MappingType.Element);
                this.columnGODINESTAZA.AllowDBNull = true;
                this.columnGODINESTAZA.Caption = "Godine staža (do datuma)";
                this.columnGODINESTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINESTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINESTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGODINESTAZA.ExtendedProperties.Add("Description", "Godine staža (do datuma)");
                this.columnGODINESTAZA.ExtendedProperties.Add("Length", "2");
                this.columnGODINESTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINESTAZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINESTAZA.ExtendedProperties.Add("Deklarit.InternalName", "GODINESTAZA");
                this.Columns.Add(this.columnGODINESTAZA);
                this.columnMJESECISTAZA = new DataColumn("MJESECISTAZA", typeof(short), "", MappingType.Element);
                this.columnMJESECISTAZA.AllowDBNull = true;
                this.columnMJESECISTAZA.Caption = "Mjeseci staža (do datuma)";
                this.columnMJESECISTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECISTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESECISTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Description", "Mjeseci staža (do datuma)");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Length", "2");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECISTAZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECISTAZA.ExtendedProperties.Add("Deklarit.InternalName", "MJESECISTAZA");
                this.Columns.Add(this.columnMJESECISTAZA);
                this.columnDANISTAZA = new DataColumn("DANISTAZA", typeof(short), "", MappingType.Element);
                this.columnDANISTAZA.AllowDBNull = true;
                this.columnDANISTAZA.Caption = "Dani staža (do datuma)";
                this.columnDANISTAZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDANISTAZA.ExtendedProperties.Add("IsKey", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDANISTAZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDANISTAZA.ExtendedProperties.Add("Description", "Dani staža (do datuma)");
                this.columnDANISTAZA.ExtendedProperties.Add("Length", "3");
                this.columnDANISTAZA.ExtendedProperties.Add("Decimals", "0");
                this.columnDANISTAZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDANISTAZA.ExtendedProperties.Add("Deklarit.InternalName", "DANISTAZA");
                this.Columns.Add(this.columnDANISTAZA);
                this.columnDATUMPRESTANKARADNOGODNOSA = new DataColumn("DATUMPRESTANKARADNOGODNOSA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMPRESTANKARADNOGODNOSA.AllowDBNull = true;
                this.columnDATUMPRESTANKARADNOGODNOSA.Caption = "Datum prestanka radnog odnosa";
                this.columnDATUMPRESTANKARADNOGODNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Description", "Datum prestanka radnog odnosa");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMPRESTANKARADNOGODNOSA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMPRESTANKARADNOGODNOSA");
                this.Columns.Add(this.columnDATUMPRESTANKARADNOGODNOSA);
                this.columnIDTITULA = new DataColumn("IDTITULA", typeof(int), "", MappingType.Element);
                this.columnIDTITULA.AllowDBNull = true;
                this.columnIDTITULA.Caption = "Šifra titule";
                this.columnIDTITULA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTITULA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDTITULA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDTITULA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTITULA.ExtendedProperties.Add("Description", "Šifra titule");
                this.columnIDTITULA.ExtendedProperties.Add("Length", "5");
                this.columnIDTITULA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTITULA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.InternalName", "IDTITULA");
                this.Columns.Add(this.columnIDTITULA);
                this.columnNAZIVTITULA = new DataColumn("NAZIVTITULA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTITULA.AllowDBNull = true;
                this.columnNAZIVTITULA.Caption = "Naziv titule";
                this.columnNAZIVTITULA.MaxLength = 50;
                this.columnNAZIVTITULA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTITULA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Description", "Naziv titule");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTITULA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTITULA");
                this.Columns.Add(this.columnNAZIVTITULA);
                this.columnZBIRNINETO = new DataColumn("ZBIRNINETO", typeof(bool), "", MappingType.Element);
                this.columnZBIRNINETO.AllowDBNull = true;
                this.columnZBIRNINETO.Caption = "Uključen u zbirni neto";
                this.columnZBIRNINETO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZBIRNINETO.ExtendedProperties.Add("IsKey", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnZBIRNINETO.ExtendedProperties.Add("Description", "Uključen u zbirni neto");
                this.columnZBIRNINETO.ExtendedProperties.Add("Length", "1");
                this.columnZBIRNINETO.ExtendedProperties.Add("Decimals", "0");
                this.columnZBIRNINETO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZBIRNINETO.ExtendedProperties.Add("Deklarit.InternalName", "ZBIRNINETO");
                this.Columns.Add(this.columnZBIRNINETO);
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA = new DataColumn("UZIMAUOBZIROSNOVICEDOPRINOSA", typeof(bool), "", MappingType.Element);
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.AllowDBNull = true;
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.Caption = "Korištenje min. i maks. osnovice za obraeun doprinosa";
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Description", "Korištenje min. i maks. osnovice za obraeun doprinosa");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Length", "1");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA.ExtendedProperties.Add("Deklarit.InternalName", "UZIMAUOBZIROSNOVICEDOPRINOSA");
                this.Columns.Add(this.columnUZIMAUOBZIROSNOVICEDOPRINOSA);
                this.columnIDORGDIO = new DataColumn("IDORGDIO", typeof(int), "", MappingType.Element);
                this.columnIDORGDIO.AllowDBNull = true;
                this.columnIDORGDIO.Caption = "Šifra organizacijske jedinice";
                this.columnIDORGDIO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGDIO.ExtendedProperties.Add("IsKey", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGDIO.ExtendedProperties.Add("Description", "Šifra organizacijske jedinice");
                this.columnIDORGDIO.ExtendedProperties.Add("Length", "5");
                this.columnIDORGDIO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGDIO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.InternalName", "IDORGDIO");
                this.Columns.Add(this.columnIDORGDIO);
                this.columnORGANIZACIJSKIDIO = new DataColumn("ORGANIZACIJSKIDIO", typeof(string), "", MappingType.Element);
                this.columnORGANIZACIJSKIDIO.AllowDBNull = true;
                this.columnORGANIZACIJSKIDIO.Caption = "Naziv organizacijske jedinice";
                this.columnORGANIZACIJSKIDIO.MaxLength = 50;
                this.columnORGANIZACIJSKIDIO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("IsKey", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Description", "Naziv organizacijske jedinice");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Length", "50");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Decimals", "0");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.InternalName", "ORGANIZACIJSKIDIO");
                this.Columns.Add(this.columnORGANIZACIJSKIDIO);
                this.columnIDIPIDENT = new DataColumn("IDIPIDENT", typeof(int), "", MappingType.Element);
                this.columnIDIPIDENT.AllowDBNull = false;
                this.columnIDIPIDENT.Caption = "IDIPIDENT";
                this.columnIDIPIDENT.DefaultValue = 0;
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDIPIDENT.ExtendedProperties.Add("Description", "IDIPIDENT");
                this.columnIDIPIDENT.ExtendedProperties.Add("Length", "5");
                this.columnIDIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDIPIDENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "IDIPIDENT");
                this.Columns.Add(this.columnIDIPIDENT);
                this.columnOIB = new DataColumn("OIB", typeof(string), "", MappingType.Element);
                this.columnOIB.AllowDBNull = true;
                this.columnOIB.Caption = "OIB";
                this.columnOIB.MaxLength = 11;
                this.columnOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnOIB.ExtendedProperties.Add("Length", "11");
                this.columnOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.InternalName", "OIB");
                this.Columns.Add(this.columnOIB);
                this.columnPOSTOTAKNASTAZ = new DataColumn("POSTOTAKNASTAZ", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAKNASTAZ.AllowDBNull = true;
                this.columnPOSTOTAKNASTAZ.Caption = "POSTOTAKNASTAZ";
                this.columnPOSTOTAKNASTAZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Description", "POSTOTAKNASTAZ");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAKNASTAZ.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAKNASTAZ");
                this.Columns.Add(this.columnPOSTOTAKNASTAZ);
                this.columnRADNIKOBRACUNOSNOVICA = new DataColumn("RADNIKOBRACUNOSNOVICA", typeof(decimal), "", MappingType.Element);
                this.columnRADNIKOBRACUNOSNOVICA.AllowDBNull = false;
                this.columnRADNIKOBRACUNOSNOVICA.Caption = "RADNIKOBRACUNOSNOVICA";
                this.columnRADNIKOBRACUNOSNOVICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("IsKey", "false");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Description", "RADNIKOBRACUNOSNOVICA");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Length", "12");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Decimals", "2");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRADNIKOBRACUNOSNOVICA.ExtendedProperties.Add("Deklarit.InternalName", "RADNIKOBRACUNOSNOVICA");
                this.Columns.Add(this.columnRADNIKOBRACUNOSNOVICA);
                this.columnKOREKCIJAPRIREZA = new DataColumn("KOREKCIJAPRIREZA", typeof(decimal), "", MappingType.Element);
                this.columnKOREKCIJAPRIREZA.AllowDBNull = false;
                this.columnKOREKCIJAPRIREZA.Caption = "KOREKCIJAPRIREZA";
                this.columnKOREKCIJAPRIREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Description", "KOREKCIJAPRIREZA");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Length", "5");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOREKCIJAPRIREZA.ExtendedProperties.Add("Deklarit.InternalName", "KOREKCIJAPRIREZA");
                this.Columns.Add(this.columnKOREKCIJAPRIREZA);
                this.columnODBITAKPRIJEKOREKCIJE = new DataColumn("ODBITAKPRIJEKOREKCIJE", typeof(decimal), "", MappingType.Element);
                this.columnODBITAKPRIJEKOREKCIJE.AllowDBNull = false;
                this.columnODBITAKPRIJEKOREKCIJE.Caption = "ODBITAKPRIJEKOREKCIJE";
                this.columnODBITAKPRIJEKOREKCIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("IsKey", "false");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Description", "ODBITAKPRIJEKOREKCIJE");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Length", "12");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Decimals", "2");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnODBITAKPRIJEKOREKCIJE.ExtendedProperties.Add("Deklarit.InternalName", "ODBITAKPRIJEKOREKCIJE");
                this.Columns.Add(this.columnODBITAKPRIJEKOREKCIJE);
                this.columnOBRACUNAVAJOBUSTAVE = new DataColumn("OBRACUNAVAJOBUSTAVE", typeof(bool), "", MappingType.Element);
                this.columnOBRACUNAVAJOBUSTAVE.AllowDBNull = false;
                this.columnOBRACUNAVAJOBUSTAVE.Caption = "OBRACUNAVAJOBUSTAVE";
                this.columnOBRACUNAVAJOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Description", "Obračunavaj obustave");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Length", "1");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOBRACUNAVAJOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "OBRACUNAVAJOBUSTAVE");
                this.Columns.Add(this.columnOBRACUNAVAJOBUSTAVE);
                this.PrimaryKey = new DataColumn[] { this.columnIDOBRACUN, this.columnIDRADNIK };
                this.ExtendedProperties.Add("ParentLvl", "OBRACUN");
                this.ExtendedProperties.Add("LevelName", "OBRACUNLevel1");
                this.ExtendedProperties.Add("Description", "OBRACUNLevel1");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIME = this.Columns["PREZIME"];
                this.columnIME = this.Columns["IME"];
                this.columnulica = this.Columns["ulica"];
                this.columnmjesto = this.Columns["mjesto"];
                this.columnkucnibroj = this.Columns["kucnibroj"];
                this.columnJMBG = this.Columns["JMBG"];
                this.columnDATUMRODJENJA = this.Columns["DATUMRODJENJA"];
                this.columnOPCINARADAIDOPCINE = this.Columns["OPCINARADAIDOPCINE"];
                this.columnOPCINARADANAZIVOPCINE = this.Columns["OPCINARADANAZIVOPCINE"];
                this.columnOPCINARADAPRIREZ = this.Columns["OPCINARADAPRIREZ"];
                this.columnOPCINASTANOVANJAIDOPCINE = this.Columns["OPCINASTANOVANJAIDOPCINE"];
                this.columnOPCINASTANOVANJANAZIVOPCINE = this.Columns["OPCINASTANOVANJANAZIVOPCINE"];
                this.columnOPCINASTANOVANJAPRIREZ = this.Columns["OPCINASTANOVANJAPRIREZ"];
                this.columnSIFRAOPCINESTANOVANJA = this.Columns["SIFRAOPCINESTANOVANJA"];
                this.columnIDBENEFICIRANI = this.Columns["IDBENEFICIRANI"];
                this.columnNAZIVBENEFICIRANI = this.Columns["NAZIVBENEFICIRANI"];
                this.columnBROJPRIZNATIHMJESECI = this.Columns["BROJPRIZNATIHMJESECI"];
                this.columnIDBANKE = this.Columns["IDBANKE"];
                this.columnNAZIVBANKE1 = this.Columns["NAZIVBANKE1"];
                this.columnNAZIVBANKE2 = this.Columns["NAZIVBANKE2"];
                this.columnNAZIVBANKE3 = this.Columns["NAZIVBANKE3"];
                this.columnVBDIBANKE = this.Columns["VBDIBANKE"];
                this.columnZRNBANKE = this.Columns["ZRNBANKE"];
                this.columnTEKUCI = this.Columns["TEKUCI"];
                this.columnSIFRAOPISAPLACANJANETO = this.Columns["SIFRAOPISAPLACANJANETO"];
                this.columnOPISPLACANJANETO = this.Columns["OPISPLACANJANETO"];
                this.columnBROJMIROVINSKOG = this.Columns["BROJMIROVINSKOG"];
                this.columnBROJZDRAVSTVENOG = this.Columns["BROJZDRAVSTVENOG"];
                this.columnMBO = this.Columns["MBO"];
                this.columnPOSTOTAKOSLOBODJENJAODPOREZA = this.Columns["POSTOTAKOSLOBODJENJAODPOREZA"];
                this.columnKOEFICIJENT = this.Columns["KOEFICIJENT"];
                this.columnOBRACUNSKIKOEFICIJENT = this.Columns["OBRACUNSKIKOEFICIJENT"];
                this.columnIDRADNOMJESTO = this.Columns["IDRADNOMJESTO"];
                this.columnNAZIVRADNOMJESTO = this.Columns["NAZIVRADNOMJESTO"];
                this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = this.Columns["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"];
                this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.Columns["TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA"];
                this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = this.Columns["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"];
                this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA = this.Columns["POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA"];
                this.columnIDSTRUKA = this.Columns["IDSTRUKA"];
                this.columnNAZIVSTRUKA = this.Columns["NAZIVSTRUKA"];
                this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = this.Columns["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"];
                this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA = this.Columns["RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA"];
                this.columnAKTIVAN = this.Columns["AKTIVAN"];
                this.columnISKORISTENOOO = this.Columns["ISKORISTENOOO"];
                this.columnOBRACUNATIPRIREZ = this.Columns["OBRACUNATIPRIREZ"];
                this.columnfaktoo = this.Columns["faktoo"];
                this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = this.Columns["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"];
                this.columnTJEDNIFONDSATI = this.Columns["TJEDNIFONDSATI"];
                this.columnTJEDNIFONDSATISTAZ = this.Columns["TJEDNIFONDSATISTAZ"];
                this.columnGODINESTAZA = this.Columns["GODINESTAZA"];
                this.columnMJESECISTAZA = this.Columns["MJESECISTAZA"];
                this.columnDANISTAZA = this.Columns["DANISTAZA"];
                this.columnDATUMPRESTANKARADNOGODNOSA = this.Columns["DATUMPRESTANKARADNOGODNOSA"];
                this.columnIDTITULA = this.Columns["IDTITULA"];
                this.columnNAZIVTITULA = this.Columns["NAZIVTITULA"];
                this.columnZBIRNINETO = this.Columns["ZBIRNINETO"];
                this.columnUZIMAUOBZIROSNOVICEDOPRINOSA = this.Columns["UZIMAUOBZIROSNOVICEDOPRINOSA"];
                this.columnIDORGDIO = this.Columns["IDORGDIO"];
                this.columnORGANIZACIJSKIDIO = this.Columns["ORGANIZACIJSKIDIO"];
                this.columnIDIPIDENT = this.Columns["IDIPIDENT"];
                this.columnOIB = this.Columns["OIB"];
                this.columnPOSTOTAKNASTAZ = this.Columns["POSTOTAKNASTAZ"];
                this.columnRADNIKOBRACUNOSNOVICA = this.Columns["RADNIKOBRACUNOSNOVICA"];
                this.columnKOREKCIJAPRIREZA = this.Columns["KOREKCIJAPRIREZA"];
                this.columnODBITAKPRIJEKOREKCIJE = this.Columns["ODBITAKPRIJEKOREKCIJE"];
                this.columnOBRACUNAVAJOBUSTAVE = this.Columns["OBRACUNAVAJOBUSTAVE"];
            }

            public OBRACUNDataSet.ObracunRadniciRow NewObracunRadniciRow()
            {
                return (OBRACUNDataSet.ObracunRadniciRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OBRACUNDataSet.ObracunRadniciRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ObracunRadniciRowChanged != null)
                {
                    OBRACUNDataSet.ObracunRadniciRowChangeEventHandler obracunRadniciRowChangedEvent = this.ObracunRadniciRowChanged;
                    if (obracunRadniciRowChangedEvent != null)
                    {
                        obracunRadniciRowChangedEvent(this, new OBRACUNDataSet.ObracunRadniciRowChangeEvent((OBRACUNDataSet.ObracunRadniciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ObracunRadniciRowChanging != null)
                {
                    OBRACUNDataSet.ObracunRadniciRowChangeEventHandler obracunRadniciRowChangingEvent = this.ObracunRadniciRowChanging;
                    if (obracunRadniciRowChangingEvent != null)
                    {
                        obracunRadniciRowChangingEvent(this, new OBRACUNDataSet.ObracunRadniciRowChangeEvent((OBRACUNDataSet.ObracunRadniciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("OBRACUN_ObracunRadnici", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.ObracunRadniciRowDeleted != null)
                {
                    OBRACUNDataSet.ObracunRadniciRowChangeEventHandler obracunRadniciRowDeletedEvent = this.ObracunRadniciRowDeleted;
                    if (obracunRadniciRowDeletedEvent != null)
                    {
                        obracunRadniciRowDeletedEvent(this, new OBRACUNDataSet.ObracunRadniciRowChangeEvent((OBRACUNDataSet.ObracunRadniciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ObracunRadniciRowDeleting != null)
                {
                    OBRACUNDataSet.ObracunRadniciRowChangeEventHandler obracunRadniciRowDeletingEvent = this.ObracunRadniciRowDeleting;
                    if (obracunRadniciRowDeletingEvent != null)
                    {
                        obracunRadniciRowDeletingEvent(this, new OBRACUNDataSet.ObracunRadniciRowChangeEvent((OBRACUNDataSet.ObracunRadniciRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveObracunRadniciRow(OBRACUNDataSet.ObracunRadniciRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVANColumn
            {
                get
                {
                    return this.columnAKTIVAN;
                }
            }

            public DataColumn BROJMIROVINSKOGColumn
            {
                get
                {
                    return this.columnBROJMIROVINSKOG;
                }
            }

            public DataColumn BROJPRIZNATIHMJESECIColumn
            {
                get
                {
                    return this.columnBROJPRIZNATIHMJESECI;
                }
            }

            public DataColumn BROJZDRAVSTVENOGColumn
            {
                get
                {
                    return this.columnBROJZDRAVSTVENOG;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn DANISTAZAColumn
            {
                get
                {
                    return this.columnDANISTAZA;
                }
            }

            public DataColumn DATUMPRESTANKARADNOGODNOSAColumn
            {
                get
                {
                    return this.columnDATUMPRESTANKARADNOGODNOSA;
                }
            }

            public DataColumn DATUMRODJENJAColumn
            {
                get
                {
                    return this.columnDATUMRODJENJA;
                }
            }

            public DataColumn DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn
            {
                get
                {
                    return this.columnDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI;
                }
            }

            public DataColumn faktooColumn
            {
                get
                {
                    return this.columnfaktoo;
                }
            }

            public DataColumn GODINESTAZAColumn
            {
                get
                {
                    return this.columnGODINESTAZA;
                }
            }

            public DataColumn IDBANKEColumn
            {
                get
                {
                    return this.columnIDBANKE;
                }
            }

            public DataColumn IDBENEFICIRANIColumn
            {
                get
                {
                    return this.columnIDBENEFICIRANI;
                }
            }

            public DataColumn IDIPIDENTColumn
            {
                get
                {
                    return this.columnIDIPIDENT;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDORGDIOColumn
            {
                get
                {
                    return this.columnIDORGDIO;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn IDRADNOMJESTOColumn
            {
                get
                {
                    return this.columnIDRADNOMJESTO;
                }
            }

            public DataColumn IDSTRUKAColumn
            {
                get
                {
                    return this.columnIDSTRUKA;
                }
            }

            public DataColumn IDTITULAColumn
            {
                get
                {
                    return this.columnIDTITULA;
                }
            }

            public DataColumn IMEColumn
            {
                get
                {
                    return this.columnIME;
                }
            }

            public DataColumn ISKORISTENOOOColumn
            {
                get
                {
                    return this.columnISKORISTENOOO;
                }
            }

            public OBRACUNDataSet.ObracunRadniciRow this[int index]
            {
                get
                {
                    return (OBRACUNDataSet.ObracunRadniciRow) this.Rows[index];
                }
            }

            public DataColumn JMBGColumn
            {
                get
                {
                    return this.columnJMBG;
                }
            }

            public DataColumn KOEFICIJENTColumn
            {
                get
                {
                    return this.columnKOEFICIJENT;
                }
            }

            public DataColumn KOREKCIJAPRIREZAColumn
            {
                get
                {
                    return this.columnKOREKCIJAPRIREZA;
                }
            }

            public DataColumn kucnibrojColumn
            {
                get
                {
                    return this.columnkucnibroj;
                }
            }

            public DataColumn MBOColumn
            {
                get
                {
                    return this.columnMBO;
                }
            }

            public DataColumn MJESECISTAZAColumn
            {
                get
                {
                    return this.columnMJESECISTAZA;
                }
            }

            public DataColumn mjestoColumn
            {
                get
                {
                    return this.columnmjesto;
                }
            }

            public DataColumn NAZIVBANKE1Column
            {
                get
                {
                    return this.columnNAZIVBANKE1;
                }
            }

            public DataColumn NAZIVBANKE2Column
            {
                get
                {
                    return this.columnNAZIVBANKE2;
                }
            }

            public DataColumn NAZIVBANKE3Column
            {
                get
                {
                    return this.columnNAZIVBANKE3;
                }
            }

            public DataColumn NAZIVBENEFICIRANIColumn
            {
                get
                {
                    return this.columnNAZIVBENEFICIRANI;
                }
            }

            public DataColumn NAZIVRADNOMJESTOColumn
            {
                get
                {
                    return this.columnNAZIVRADNOMJESTO;
                }
            }

            public DataColumn NAZIVSTRUKAColumn
            {
                get
                {
                    return this.columnNAZIVSTRUKA;
                }
            }

            public DataColumn NAZIVTITULAColumn
            {
                get
                {
                    return this.columnNAZIVTITULA;
                }
            }

            public DataColumn OBRACUNATIPRIREZColumn
            {
                get
                {
                    return this.columnOBRACUNATIPRIREZ;
                }
            }

            public DataColumn OBRACUNAVAJOBUSTAVEColumn
            {
                get
                {
                    return this.columnOBRACUNAVAJOBUSTAVE;
                }
            }

            public DataColumn OBRACUNSKIKOEFICIJENTColumn
            {
                get
                {
                    return this.columnOBRACUNSKIKOEFICIJENT;
                }
            }

            public DataColumn ODBITAKPRIJEKOREKCIJEColumn
            {
                get
                {
                    return this.columnODBITAKPRIJEKOREKCIJE;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn OPCINARADAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINARADAIDOPCINE;
                }
            }

            public DataColumn OPCINARADANAZIVOPCINEColumn
            {
                get
                {
                    return this.columnOPCINARADANAZIVOPCINE;
                }
            }

            public DataColumn OPCINARADAPRIREZColumn
            {
                get
                {
                    return this.columnOPCINARADAPRIREZ;
                }
            }

            public DataColumn OPCINASTANOVANJAIDOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAIDOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJANAZIVOPCINEColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJANAZIVOPCINE;
                }
            }

            public DataColumn OPCINASTANOVANJAPRIREZColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAPRIREZ;
                }
            }

            public DataColumn OPISPLACANJANETOColumn
            {
                get
                {
                    return this.columnOPISPLACANJANETO;
                }
            }

            public DataColumn ORGANIZACIJSKIDIOColumn
            {
                get
                {
                    return this.columnORGANIZACIJSKIDIO;
                }
            }

            public DataColumn POSTOTAKNASTAZColumn
            {
                get
                {
                    return this.columnPOSTOTAKNASTAZ;
                }
            }

            public DataColumn POSTOTAKOSLOBODJENJAODPOREZAColumn
            {
                get
                {
                    return this.columnPOSTOTAKOSLOBODJENJAODPOREZA;
                }
            }

            public DataColumn POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
                }
            }

            public DataColumn POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA;
                }
            }

            public DataColumn PREZIMEColumn
            {
                get
                {
                    return this.columnPREZIME;
                }
            }

            public DataColumn RADNIKOBRACUNOSNOVICAColumn
            {
                get
                {
                    return this.columnRADNIKOBRACUNOSNOVICA;
                }
            }

            public DataColumn RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
                }
            }

            public DataColumn RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn
            {
                get
                {
                    return this.columnRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA;
                }
            }

            public DataColumn SIFRAOPCINESTANOVANJAColumn
            {
                get
                {
                    return this.columnSIFRAOPCINESTANOVANJA;
                }
            }

            public DataColumn SIFRAOPISAPLACANJANETOColumn
            {
                get
                {
                    return this.columnSIFRAOPISAPLACANJANETO;
                }
            }

            public DataColumn TEKUCIColumn
            {
                get
                {
                    return this.columnTEKUCI;
                }
            }

            public DataColumn TJEDNIFONDSATIColumn
            {
                get
                {
                    return this.columnTJEDNIFONDSATI;
                }
            }

            public DataColumn TJEDNIFONDSATISTAZColumn
            {
                get
                {
                    return this.columnTJEDNIFONDSATISTAZ;
                }
            }

            public DataColumn TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
                }
            }

            public DataColumn TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA;
                }
            }

            public DataColumn ulicaColumn
            {
                get
                {
                    return this.columnulica;
                }
            }

            public DataColumn UZIMAUOBZIROSNOVICEDOPRINOSAColumn
            {
                get
                {
                    return this.columnUZIMAUOBZIROSNOVICEDOPRINOSA;
                }
            }

            public DataColumn VBDIBANKEColumn
            {
                get
                {
                    return this.columnVBDIBANKE;
                }
            }

            public DataColumn ZBIRNINETOColumn
            {
                get
                {
                    return this.columnZBIRNINETO;
                }
            }

            public DataColumn ZRNBANKEColumn
            {
                get
                {
                    return this.columnZRNBANKE;
                }
            }
        }

        public class ObracunRadniciRow : DataRow
        {
            private OBRACUNDataSet.ObracunRadniciDataTable tableObracunRadnici;

            internal ObracunRadniciRow(DataRowBuilder rb) : base(rb)
            {
                this.tableObracunRadnici = (OBRACUNDataSet.ObracunRadniciDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunDoprinosiRow[] GetObracunDoprinosiRows()
            {
                return (OBRACUNDataSet.ObracunDoprinosiRow[]) this.GetChildRows("ObracunRadnici_ObracunDoprinosi");
            }

            public OBRACUNDataSet.ObracunElementiRow[] GetObracunElementiRows()
            {
                return (OBRACUNDataSet.ObracunElementiRow[]) this.GetChildRows("ObracunRadnici_ObracunElementi");
            }

            public OBRACUNDataSet.OBRACUNKreditiRow[] GetOBRACUNKreditiRows()
            {
                return (OBRACUNDataSet.OBRACUNKreditiRow[]) this.GetChildRows("ObracunRadnici_OBRACUNKrediti");
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow[] GetOBRACUNOBRACUNLevel1ObracunIzuzeceRows()
            {
                return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunIzuzeceRow[]) this.GetChildRows("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunIzuzece");
            }

            public OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow[] GetOBRACUNOBRACUNLevel1ObracunKrizniRows()
            {
                return (OBRACUNDataSet.OBRACUNOBRACUNLevel1ObracunKrizniRow[]) this.GetChildRows("ObracunRadnici_OBRACUNOBRACUNLevel1ObracunKrizni");
            }

            public OBRACUNDataSet.OBRACUNObustaveRow[] GetOBRACUNObustaveRows()
            {
                return (OBRACUNDataSet.OBRACUNObustaveRow[]) this.GetChildRows("ObracunRadnici_OBRACUNObustave");
            }

            public OBRACUNDataSet.ObracunOlaksiceRow[] GetObracunOlaksiceRows()
            {
                return (OBRACUNDataSet.ObracunOlaksiceRow[]) this.GetChildRows("ObracunRadnici_ObracunOlaksice");
            }

            public OBRACUNDataSet.ObracunPoreziRow[] GetObracunPoreziRows()
            {
                return (OBRACUNDataSet.ObracunPoreziRow[]) this.GetChildRows("ObracunRadnici_ObracunPorezi");
            }

            public OBRACUNDataSet.OBRACUNRow GetOBRACUNRow()
            {
                return (OBRACUNDataSet.OBRACUNRow) this.GetParentRow("OBRACUN_ObracunRadnici");
            }

            public bool IsAKTIVANNull()
            {
                return this.IsNull(this.tableObracunRadnici.AKTIVANColumn);
            }

            public bool IsBROJMIROVINSKOGNull()
            {
                return this.IsNull(this.tableObracunRadnici.BROJMIROVINSKOGColumn);
            }

            public bool IsBROJPRIZNATIHMJESECINull()
            {
                return this.IsNull(this.tableObracunRadnici.BROJPRIZNATIHMJESECIColumn);
            }

            public bool IsBROJZDRAVSTVENOGNull()
            {
                return this.IsNull(this.tableObracunRadnici.BROJZDRAVSTVENOGColumn);
            }

            public bool IsDANISTAZANull()
            {
                return this.IsNull(this.tableObracunRadnici.DANISTAZAColumn);
            }

            public bool IsDATUMPRESTANKARADNOGODNOSANull()
            {
                return this.IsNull(this.tableObracunRadnici.DATUMPRESTANKARADNOGODNOSAColumn);
            }

            public bool IsDATUMRODJENJANull()
            {
                return this.IsNull(this.tableObracunRadnici.DATUMRODJENJAColumn);
            }

            public bool IsDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATINull()
            {
                return this.IsNull(this.tableObracunRadnici.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn);
            }

            public bool IsfaktooNull()
            {
                return this.IsNull(this.tableObracunRadnici.faktooColumn);
            }

            public bool IsGODINESTAZANull()
            {
                return this.IsNull(this.tableObracunRadnici.GODINESTAZAColumn);
            }

            public bool IsIDBANKENull()
            {
                return this.IsNull(this.tableObracunRadnici.IDBANKEColumn);
            }

            public bool IsIDBENEFICIRANINull()
            {
                return this.IsNull(this.tableObracunRadnici.IDBENEFICIRANIColumn);
            }

            public bool IsIDIPIDENTNull()
            {
                return this.IsNull(this.tableObracunRadnici.IDIPIDENTColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableObracunRadnici.IDOBRACUNColumn);
            }

            public bool IsIDORGDIONull()
            {
                return this.IsNull(this.tableObracunRadnici.IDORGDIOColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableObracunRadnici.IDRADNIKColumn);
            }

            public bool IsIDRADNOMJESTONull()
            {
                return this.IsNull(this.tableObracunRadnici.IDRADNOMJESTOColumn);
            }

            public bool IsIDSTRUKANull()
            {
                return this.IsNull(this.tableObracunRadnici.IDSTRUKAColumn);
            }

            public bool IsIDTITULANull()
            {
                return this.IsNull(this.tableObracunRadnici.IDTITULAColumn);
            }

            public bool IsIMENull()
            {
                return this.IsNull(this.tableObracunRadnici.IMEColumn);
            }

            public bool IsISKORISTENOOONull()
            {
                return this.IsNull(this.tableObracunRadnici.ISKORISTENOOOColumn);
            }

            public bool IsJMBGNull()
            {
                return this.IsNull(this.tableObracunRadnici.JMBGColumn);
            }

            public bool IsKOEFICIJENTNull()
            {
                return this.IsNull(this.tableObracunRadnici.KOEFICIJENTColumn);
            }

            public bool IsKOREKCIJAPRIREZANull()
            {
                return this.IsNull(this.tableObracunRadnici.KOREKCIJAPRIREZAColumn);
            }

            public bool IskucnibrojNull()
            {
                return this.IsNull(this.tableObracunRadnici.kucnibrojColumn);
            }

            public bool IsMBONull()
            {
                return this.IsNull(this.tableObracunRadnici.MBOColumn);
            }

            public bool IsMJESECISTAZANull()
            {
                return this.IsNull(this.tableObracunRadnici.MJESECISTAZAColumn);
            }

            public bool IsmjestoNull()
            {
                return this.IsNull(this.tableObracunRadnici.mjestoColumn);
            }

            public bool IsNAZIVBANKE1Null()
            {
                return this.IsNull(this.tableObracunRadnici.NAZIVBANKE1Column);
            }

            public bool IsNAZIVBANKE2Null()
            {
                return this.IsNull(this.tableObracunRadnici.NAZIVBANKE2Column);
            }

            public bool IsNAZIVBANKE3Null()
            {
                return this.IsNull(this.tableObracunRadnici.NAZIVBANKE3Column);
            }

            public bool IsNAZIVBENEFICIRANINull()
            {
                return this.IsNull(this.tableObracunRadnici.NAZIVBENEFICIRANIColumn);
            }

            public bool IsNAZIVRADNOMJESTONull()
            {
                return this.IsNull(this.tableObracunRadnici.NAZIVRADNOMJESTOColumn);
            }

            public bool IsNAZIVSTRUKANull()
            {
                return this.IsNull(this.tableObracunRadnici.NAZIVSTRUKAColumn);
            }

            public bool IsNAZIVTITULANull()
            {
                return this.IsNull(this.tableObracunRadnici.NAZIVTITULAColumn);
            }

            public bool IsOBRACUNATIPRIREZNull()
            {
                return this.IsNull(this.tableObracunRadnici.OBRACUNATIPRIREZColumn);
            }

            public bool IsOBRACUNAVAJOBUSTAVENull()
            {
                return this.IsNull(this.tableObracunRadnici.OBRACUNAVAJOBUSTAVEColumn);
            }

            public bool IsOBRACUNSKIKOEFICIJENTNull()
            {
                return this.IsNull(this.tableObracunRadnici.OBRACUNSKIKOEFICIJENTColumn);
            }

            public bool IsODBITAKPRIJEKOREKCIJENull()
            {
                return this.IsNull(this.tableObracunRadnici.ODBITAKPRIJEKOREKCIJEColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tableObracunRadnici.OIBColumn);
            }

            public bool IsOPCINARADAIDOPCINENull()
            {
                return this.IsNull(this.tableObracunRadnici.OPCINARADAIDOPCINEColumn);
            }

            public bool IsOPCINARADANAZIVOPCINENull()
            {
                return this.IsNull(this.tableObracunRadnici.OPCINARADANAZIVOPCINEColumn);
            }

            public bool IsOPCINARADAPRIREZNull()
            {
                return this.IsNull(this.tableObracunRadnici.OPCINARADAPRIREZColumn);
            }

            public bool IsOPCINASTANOVANJAIDOPCINENull()
            {
                return this.IsNull(this.tableObracunRadnici.OPCINASTANOVANJAIDOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJANAZIVOPCINENull()
            {
                return this.IsNull(this.tableObracunRadnici.OPCINASTANOVANJANAZIVOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJAPRIREZNull()
            {
                return this.IsNull(this.tableObracunRadnici.OPCINASTANOVANJAPRIREZColumn);
            }

            public bool IsOPISPLACANJANETONull()
            {
                return this.IsNull(this.tableObracunRadnici.OPISPLACANJANETOColumn);
            }

            public bool IsORGANIZACIJSKIDIONull()
            {
                return this.IsNull(this.tableObracunRadnici.ORGANIZACIJSKIDIOColumn);
            }

            public bool IsPOSTOTAKNASTAZNull()
            {
                return this.IsNull(this.tableObracunRadnici.POSTOTAKNASTAZColumn);
            }

            public bool IsPOSTOTAKOSLOBODJENJAODPOREZANull()
            {
                return this.IsNull(this.tableObracunRadnici.POSTOTAKOSLOBODJENJAODPOREZAColumn);
            }

            public bool IsPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableObracunRadnici.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn);
            }

            public bool IsPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableObracunRadnici.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn);
            }

            public bool IsPREZIMENull()
            {
                return this.IsNull(this.tableObracunRadnici.PREZIMEColumn);
            }

            public bool IsRADNIKOBRACUNOSNOVICANull()
            {
                return this.IsNull(this.tableObracunRadnici.RADNIKOBRACUNOSNOVICAColumn);
            }

            public bool IsRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableObracunRadnici.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn);
            }

            public bool IsRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSANull()
            {
                return this.IsNull(this.tableObracunRadnici.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn);
            }

            public bool IsSIFRAOPCINESTANOVANJANull()
            {
                return this.IsNull(this.tableObracunRadnici.SIFRAOPCINESTANOVANJAColumn);
            }

            public bool IsSIFRAOPISAPLACANJANETONull()
            {
                return this.IsNull(this.tableObracunRadnici.SIFRAOPISAPLACANJANETOColumn);
            }

            public bool IsTEKUCINull()
            {
                return this.IsNull(this.tableObracunRadnici.TEKUCIColumn);
            }

            public bool IsTJEDNIFONDSATINull()
            {
                return this.IsNull(this.tableObracunRadnici.TJEDNIFONDSATIColumn);
            }

            public bool IsTJEDNIFONDSATISTAZNull()
            {
                return this.IsNull(this.tableObracunRadnici.TJEDNIFONDSATISTAZColumn);
            }

            public bool IsTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableObracunRadnici.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn);
            }

            public bool IsTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableObracunRadnici.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn);
            }

            public bool IsulicaNull()
            {
                return this.IsNull(this.tableObracunRadnici.ulicaColumn);
            }

            public bool IsUZIMAUOBZIROSNOVICEDOPRINOSANull()
            {
                return this.IsNull(this.tableObracunRadnici.UZIMAUOBZIROSNOVICEDOPRINOSAColumn);
            }

            public bool IsVBDIBANKENull()
            {
                return this.IsNull(this.tableObracunRadnici.VBDIBANKEColumn);
            }

            public bool IsZBIRNINETONull()
            {
                return this.IsNull(this.tableObracunRadnici.ZBIRNINETOColumn);
            }

            public bool IsZRNBANKENull()
            {
                return this.IsNull(this.tableObracunRadnici.ZRNBANKEColumn);
            }

            public void SetAKTIVANNull()
            {
                this[this.tableObracunRadnici.AKTIVANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJMIROVINSKOGNull()
            {
                this[this.tableObracunRadnici.BROJMIROVINSKOGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJPRIZNATIHMJESECINull()
            {
                this[this.tableObracunRadnici.BROJPRIZNATIHMJESECIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJZDRAVSTVENOGNull()
            {
                this[this.tableObracunRadnici.BROJZDRAVSTVENOGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDANISTAZANull()
            {
                this[this.tableObracunRadnici.DANISTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMPRESTANKARADNOGODNOSANull()
            {
                this[this.tableObracunRadnici.DATUMPRESTANKARADNOGODNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMRODJENJANull()
            {
                this[this.tableObracunRadnici.DATUMRODJENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATINull()
            {
                this[this.tableObracunRadnici.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetfaktooNull()
            {
                this[this.tableObracunRadnici.faktooColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINESTAZANull()
            {
                this[this.tableObracunRadnici.GODINESTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBANKENull()
            {
                this[this.tableObracunRadnici.IDBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBENEFICIRANINull()
            {
                this[this.tableObracunRadnici.IDBENEFICIRANIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDIPIDENTNull()
            {
                this[this.tableObracunRadnici.IDIPIDENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDORGDIONull()
            {
                this[this.tableObracunRadnici.IDORGDIOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNOMJESTONull()
            {
                this[this.tableObracunRadnici.IDRADNOMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDSTRUKANull()
            {
                this[this.tableObracunRadnici.IDSTRUKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDTITULANull()
            {
                this[this.tableObracunRadnici.IDTITULAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIMENull()
            {
                this[this.tableObracunRadnici.IMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetISKORISTENOOONull()
            {
                this[this.tableObracunRadnici.ISKORISTENOOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetJMBGNull()
            {
                this[this.tableObracunRadnici.JMBGColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOEFICIJENTNull()
            {
                this[this.tableObracunRadnici.KOEFICIJENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOREKCIJAPRIREZANull()
            {
                this[this.tableObracunRadnici.KOREKCIJAPRIREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkucnibrojNull()
            {
                this[this.tableObracunRadnici.kucnibrojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBONull()
            {
                this[this.tableObracunRadnici.MBOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECISTAZANull()
            {
                this[this.tableObracunRadnici.MJESECISTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetmjestoNull()
            {
                this[this.tableObracunRadnici.mjestoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE1Null()
            {
                this[this.tableObracunRadnici.NAZIVBANKE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE2Null()
            {
                this[this.tableObracunRadnici.NAZIVBANKE2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE3Null()
            {
                this[this.tableObracunRadnici.NAZIVBANKE3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBENEFICIRANINull()
            {
                this[this.tableObracunRadnici.NAZIVBENEFICIRANIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVRADNOMJESTONull()
            {
                this[this.tableObracunRadnici.NAZIVRADNOMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVSTRUKANull()
            {
                this[this.tableObracunRadnici.NAZIVSTRUKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVTITULANull()
            {
                this[this.tableObracunRadnici.NAZIVTITULAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNATIPRIREZNull()
            {
                this[this.tableObracunRadnici.OBRACUNATIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNAVAJOBUSTAVENull()
            {
                this[this.tableObracunRadnici.OBRACUNAVAJOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNSKIKOEFICIJENTNull()
            {
                this[this.tableObracunRadnici.OBRACUNSKIKOEFICIJENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODBITAKPRIJEKOREKCIJENull()
            {
                this[this.tableObracunRadnici.ODBITAKPRIJEKOREKCIJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tableObracunRadnici.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADAIDOPCINENull()
            {
                this[this.tableObracunRadnici.OPCINARADAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADANAZIVOPCINENull()
            {
                this[this.tableObracunRadnici.OPCINARADANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADAPRIREZNull()
            {
                this[this.tableObracunRadnici.OPCINARADAPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAIDOPCINENull()
            {
                this[this.tableObracunRadnici.OPCINASTANOVANJAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJANAZIVOPCINENull()
            {
                this[this.tableObracunRadnici.OPCINASTANOVANJANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAPRIREZNull()
            {
                this[this.tableObracunRadnici.OPCINASTANOVANJAPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJANETONull()
            {
                this[this.tableObracunRadnici.OPISPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetORGANIZACIJSKIDIONull()
            {
                this[this.tableObracunRadnici.ORGANIZACIJSKIDIOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKNASTAZNull()
            {
                this[this.tableObracunRadnici.POSTOTAKNASTAZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKOSLOBODJENJAODPOREZANull()
            {
                this[this.tableObracunRadnici.POSTOTAKOSLOBODJENJAODPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTREBNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                this[this.tableObracunRadnici.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                this[this.tableObracunRadnici.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMENull()
            {
                this[this.tableObracunRadnici.PREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNIKOBRACUNOSNOVICANull()
            {
                this[this.tableObracunRadnici.RADNIKOBRACUNOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSANull()
            {
                this[this.tableObracunRadnici.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSANull()
            {
                this[this.tableObracunRadnici.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPCINESTANOVANJANull()
            {
                this[this.tableObracunRadnici.SIFRAOPCINESTANOVANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJANETONull()
            {
                this[this.tableObracunRadnici.SIFRAOPISAPLACANJANETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTEKUCINull()
            {
                this[this.tableObracunRadnici.TEKUCIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTJEDNIFONDSATINull()
            {
                this[this.tableObracunRadnici.TJEDNIFONDSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTJEDNIFONDSATISTAZNull()
            {
                this[this.tableObracunRadnici.TJEDNIFONDSATISTAZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTRENUTNASTRUCNASPREMAIDSTRUCNASPREMANull()
            {
                this[this.tableObracunRadnici.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMANull()
            {
                this[this.tableObracunRadnici.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetulicaNull()
            {
                this[this.tableObracunRadnici.ulicaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUZIMAUOBZIROSNOVICEDOPRINOSANull()
            {
                this[this.tableObracunRadnici.UZIMAUOBZIROSNOVICEDOPRINOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIBANKENull()
            {
                this[this.tableObracunRadnici.VBDIBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZBIRNINETONull()
            {
                this[this.tableObracunRadnici.ZBIRNINETOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNBANKENull()
            {
                this[this.tableObracunRadnici.ZRNBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableObracunRadnici.AKTIVANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableObracunRadnici.AKTIVANColumn] = value;
                }
            }

            public string BROJMIROVINSKOG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.BROJMIROVINSKOGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.BROJMIROVINSKOGColumn] = value;
                }
            }

            public short BROJPRIZNATIHMJESECI
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableObracunRadnici.BROJPRIZNATIHMJESECIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.BROJPRIZNATIHMJESECIColumn] = value;
                }
            }

            public string BROJZDRAVSTVENOG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.BROJZDRAVSTVENOGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.BROJZDRAVSTVENOGColumn] = value;
                }
            }

            public short DANISTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableObracunRadnici.DANISTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.DANISTAZAColumn] = value;
                }
            }

            public DateTime DATUMPRESTANKARADNOGODNOSA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableObracunRadnici.DATUMPRESTANKARADNOGODNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableObracunRadnici.DATUMPRESTANKARADNOGODNOSAColumn] = value;
                }
            }

            public DateTime DATUMRODJENJA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableObracunRadnici.DATUMRODJENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableObracunRadnici.DATUMRODJENJAColumn] = value;
                }
            }

            public DateTime DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableObracunRadnici.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableObracunRadnici.DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIColumn] = value;
                }
            }

            public decimal faktoo
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.faktooColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.faktooColumn] = value;
                }
            }

            public short GODINESTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableObracunRadnici.GODINESTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.GODINESTAZAColumn] = value;
                }
            }

            public int IDBANKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.IDBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.IDBANKEColumn] = value;
                }
            }

            public string IDBENEFICIRANI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.IDBENEFICIRANIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.IDBENEFICIRANIColumn] = value;
                }
            }

            public int IDIPIDENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.IDIPIDENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.IDIPIDENTColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableObracunRadnici.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableObracunRadnici.IDOBRACUNColumn] = value;
                }
            }

            public int IDORGDIO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.IDORGDIOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.IDORGDIOColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableObracunRadnici.IDRADNIKColumn]);
                }
                set
                {
                    this[this.tableObracunRadnici.IDRADNIKColumn] = value;
                }
            }

            public int IDRADNOMJESTO
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.IDRADNOMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.IDRADNOMJESTOColumn] = value;
                }
            }

            public int IDSTRUKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.IDSTRUKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.IDSTRUKAColumn] = value;
                }
            }

            public int IDTITULA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.IDTITULAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.IDTITULAColumn] = value;
                }
            }

            public string IME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.IMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.IMEColumn] = value;
                }
            }

            public decimal ISKORISTENOOO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.ISKORISTENOOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.ISKORISTENOOOColumn] = value;
                }
            }

            public string JMBG
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.JMBGColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.JMBGColumn] = value;
                }
            }

            public decimal KOEFICIJENT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.KOEFICIJENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.KOEFICIJENTColumn] = value;
                }
            }

            public decimal KOREKCIJAPRIREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.KOREKCIJAPRIREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.KOREKCIJAPRIREZAColumn] = value;
                }
            }

            public string kucnibroj
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.kucnibrojColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.kucnibrojColumn] = value;
                }
            }

            public string MBO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.MBOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.MBOColumn] = value;
                }
            }

            public short MJESECISTAZA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableObracunRadnici.MJESECISTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.MJESECISTAZAColumn] = value;
                }
            }

            public string mjesto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.mjestoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.mjestoColumn] = value;
                }
            }

            public string NAZIVBANKE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.NAZIVBANKE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.NAZIVBANKE1Column] = value;
                }
            }

            public string NAZIVBANKE2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.NAZIVBANKE2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.NAZIVBANKE2Column] = value;
                }
            }

            public string NAZIVBANKE3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.NAZIVBANKE3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.NAZIVBANKE3Column] = value;
                }
            }

            public string NAZIVBENEFICIRANI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.NAZIVBENEFICIRANIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.NAZIVBENEFICIRANIColumn] = value;
                }
            }

            public string NAZIVRADNOMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.NAZIVRADNOMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.NAZIVRADNOMJESTOColumn] = value;
                }
            }

            public string NAZIVSTRUKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.NAZIVSTRUKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.NAZIVSTRUKAColumn] = value;
                }
            }

            public string NAZIVTITULA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.NAZIVTITULAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.NAZIVTITULAColumn] = value;
                }
            }

            public decimal OBRACUNATIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.OBRACUNATIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.OBRACUNATIPRIREZColumn] = value;
                }
            }

            public bool OBRACUNAVAJOBUSTAVE
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableObracunRadnici.OBRACUNAVAJOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableObracunRadnici.OBRACUNAVAJOBUSTAVEColumn] = value;
                }
            }

            public decimal OBRACUNSKIKOEFICIJENT
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.OBRACUNSKIKOEFICIJENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.OBRACUNSKIKOEFICIJENTColumn] = value;
                }
            }

            public decimal ODBITAKPRIJEKOREKCIJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.ODBITAKPRIJEKOREKCIJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.ODBITAKPRIJEKOREKCIJEColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.OIBColumn] = value;
                }
            }

            public string OPCINARADAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.OPCINARADAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.OPCINARADAIDOPCINEColumn] = value;
                }
            }

            public string OPCINARADANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.OPCINARADANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.OPCINARADANAZIVOPCINEColumn] = value;
                }
            }

            public decimal OPCINARADAPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.OPCINARADAPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.OPCINARADAPRIREZColumn] = value;
                }
            }

            public string OPCINASTANOVANJAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.OPCINASTANOVANJAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.OPCINASTANOVANJAIDOPCINEColumn] = value;
                }
            }

            public string OPCINASTANOVANJANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.OPCINASTANOVANJANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.OPCINASTANOVANJANAZIVOPCINEColumn] = value;
                }
            }

            public decimal OPCINASTANOVANJAPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.OPCINASTANOVANJAPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.OPCINASTANOVANJAPRIREZColumn] = value;
                }
            }

            public string OPISPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.OPISPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.OPISPLACANJANETOColumn] = value;
                }
            }

            public string ORGANIZACIJSKIDIO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.ORGANIZACIJSKIDIOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.ORGANIZACIJSKIDIOColumn] = value;
                }
            }

            public decimal POSTOTAKNASTAZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.POSTOTAKNASTAZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.POSTOTAKNASTAZColumn] = value;
                }
            }

            public decimal POSTOTAKOSLOBODJENJAODPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.POSTOTAKOSLOBODJENJAODPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.POSTOTAKOSLOBODJENJAODPOREZAColumn] = value;
                }
            }

            public int POTREBNASTRUCNASPREMAIDSTRUCNASPREMA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.POTREBNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = value;
                }
            }

            public string POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = value;
                }
            }

            public string PREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.PREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.PREZIMEColumn] = value;
                }
            }

            public decimal RADNIKOBRACUNOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.RADNIKOBRACUNOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.RADNIKOBRACUNOSNOVICAColumn] = value;
                }
            }

            public int RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }

            public string RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSAColumn] = value;
                }
            }

            public string SIFRAOPCINESTANOVANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.SIFRAOPCINESTANOVANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.SIFRAOPCINESTANOVANJAColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJANETO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.SIFRAOPISAPLACANJANETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.SIFRAOPISAPLACANJANETOColumn] = value;
                }
            }

            public string TEKUCI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.TEKUCIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.TEKUCIColumn] = value;
                }
            }

            public decimal TJEDNIFONDSATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.TJEDNIFONDSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.TJEDNIFONDSATIColumn] = value;
                }
            }

            public decimal TJEDNIFONDSATISTAZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableObracunRadnici.TJEDNIFONDSATISTAZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.TJEDNIFONDSATISTAZColumn] = value;
                }
            }

            public int TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableObracunRadnici.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableObracunRadnici.TRENUTNASTRUCNASPREMAIDSTRUCNASPREMAColumn] = value;
                }
            }

            public string TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMAColumn] = value;
                }
            }

            public string ulica
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.ulicaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.ulicaColumn] = value;
                }
            }

            public bool UZIMAUOBZIROSNOVICEDOPRINOSA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableObracunRadnici.UZIMAUOBZIROSNOVICEDOPRINOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableObracunRadnici.UZIMAUOBZIROSNOVICEDOPRINOSAColumn] = value;
                }
            }

            public string VBDIBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.VBDIBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.VBDIBANKEColumn] = value;
                }
            }

            public bool ZBIRNINETO
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableObracunRadnici.ZBIRNINETOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableObracunRadnici.ZBIRNINETOColumn] = value;
                }
            }

            public string ZRNBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableObracunRadnici.ZRNBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableObracunRadnici.ZRNBANKEColumn] = value;
                }
            }
        }

        public class ObracunRadniciRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.ObracunRadniciRow eventRow;

            public ObracunRadniciRowChangeEvent(OBRACUNDataSet.ObracunRadniciRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.ObracunRadniciRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ObracunRadniciRowChangeEventHandler(object sender, OBRACUNDataSet.ObracunRadniciRowChangeEvent e);

        public class OBRACUNRow : DataRow
        {
            private OBRACUNDataSet.OBRACUNDataTable tableOBRACUN;

            internal OBRACUNRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOBRACUN = (OBRACUNDataSet.OBRACUNDataTable) this.Table;
            }

            public OBRACUNDataSet.ObracunRadniciRow[] GetObracunRadniciRows()
            {
                return (OBRACUNDataSet.ObracunRadniciRow[]) this.GetChildRows("OBRACUN_ObracunRadnici");
            }

            public bool IsDATUMISPLATENull()
            {
                return this.IsNull(this.tableOBRACUN.DATUMISPLATEColumn);
            }

            public bool IsDATUMOBRACUNASTAZANull()
            {
                return this.IsNull(this.tableOBRACUN.DATUMOBRACUNASTAZAColumn);
            }

            public bool IsGODINAISPLATENull()
            {
                return this.IsNull(this.tableOBRACUN.GODINAISPLATEColumn);
            }

            public bool IsGODINAOBRACUNANull()
            {
                return this.IsNull(this.tableOBRACUN.GODINAOBRACUNAColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableOBRACUN.IDOBRACUNColumn);
            }

            public bool IsMJESECISPLATENull()
            {
                return this.IsNull(this.tableOBRACUN.MJESECISPLATEColumn);
            }

            public bool IsMJESECNIFONDSATIOBRACUNNull()
            {
                return this.IsNull(this.tableOBRACUN.MJESECNIFONDSATIOBRACUNColumn);
            }

            public bool IsMJESECOBRACUNANull()
            {
                return this.IsNull(this.tableOBRACUN.MJESECOBRACUNAColumn);
            }

            public bool IsOBRACUNSKAOSNOVICANull()
            {
                return this.IsNull(this.tableOBRACUN.OBRACUNSKAOSNOVICAColumn);
            }

            public bool IsOBRFIKSNIHNull()
            {
                return this.IsNull(this.tableOBRACUN.OBRFIKSNIHColumn);
            }

            public bool IsOBRKREDITNIHNull()
            {
                return this.IsNull(this.tableOBRACUN.OBRKREDITNIHColumn);
            }

            public bool IsOBRPOSTOTNIHNull()
            {
                return this.IsNull(this.tableOBRACUN.OBRPOSTOTNIHColumn);
            }

            public bool IsOSNOVNIOONull()
            {
                return this.IsNull(this.tableOBRACUN.OSNOVNIOOColumn);
            }

            public bool IsSVRHAOBRACUNANull()
            {
                return this.IsNull(this.tableOBRACUN.SVRHAOBRACUNAColumn);
            }

            public bool IstjednifondsatiobracunNull()
            {
                return this.IsNull(this.tableOBRACUN.tjednifondsatiobracunColumn);
            }

            public bool IsVRSTAOBRACUNANull()
            {
                return this.IsNull(this.tableOBRACUN.VRSTAOBRACUNAColumn);
            }

            public bool IsZAKLJNull()
            {
                return this.IsNull(this.tableOBRACUN.ZAKLJColumn);
            }

            public void SetDATUMISPLATENull()
            {
                this[this.tableOBRACUN.DATUMISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMOBRACUNASTAZANull()
            {
                this[this.tableOBRACUN.DATUMOBRACUNASTAZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINAISPLATENull()
            {
                this[this.tableOBRACUN.GODINAISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetGODINAOBRACUNANull()
            {
                this[this.tableOBRACUN.GODINAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECISPLATENull()
            {
                this[this.tableOBRACUN.MJESECISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECNIFONDSATIOBRACUNNull()
            {
                this[this.tableOBRACUN.MJESECNIFONDSATIOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECOBRACUNANull()
            {
                this[this.tableOBRACUN.MJESECOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRACUNSKAOSNOVICANull()
            {
                this[this.tableOBRACUN.OBRACUNSKAOSNOVICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRFIKSNIHNull()
            {
                this[this.tableOBRACUN.OBRFIKSNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRKREDITNIHNull()
            {
                this[this.tableOBRACUN.OBRKREDITNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOBRPOSTOTNIHNull()
            {
                this[this.tableOBRACUN.OBRPOSTOTNIHColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSNOVNIOONull()
            {
                this[this.tableOBRACUN.OSNOVNIOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSVRHAOBRACUNANull()
            {
                this[this.tableOBRACUN.SVRHAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SettjednifondsatiobracunNull()
            {
                this[this.tableOBRACUN.tjednifondsatiobracunColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVRSTAOBRACUNANull()
            {
                this[this.tableOBRACUN.VRSTAOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZAKLJNull()
            {
                this[this.tableOBRACUN.ZAKLJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DATUMISPLATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableOBRACUN.DATUMISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableOBRACUN.DATUMISPLATEColumn] = value;
                }
            }

            public DateTime DATUMOBRACUNASTAZA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableOBRACUN.DATUMOBRACUNASTAZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableOBRACUN.DATUMOBRACUNASTAZAColumn] = value;
                }
            }

            public string GODINAISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUN.GODINAISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUN.GODINAISPLATEColumn] = value;
                }
            }

            public string GODINAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUN.GODINAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUN.GODINAOBRACUNAColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableOBRACUN.IDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableOBRACUN.IDOBRACUNColumn] = value;
                }
            }

            public string MJESECISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUN.MJESECISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUN.MJESECISPLATEColumn] = value;
                }
            }

            public short MJESECNIFONDSATIOBRACUN
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableOBRACUN.MJESECNIFONDSATIOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUN.MJESECNIFONDSATIOBRACUNColumn] = value;
                }
            }

            public string MJESECOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUN.MJESECOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUN.MJESECOBRACUNAColumn] = value;
                }
            }

            public decimal OBRACUNSKAOSNOVICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUN.OBRACUNSKAOSNOVICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUN.OBRACUNSKAOSNOVICAColumn] = value;
                }
            }

            public bool OBRFIKSNIH
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableOBRACUN.OBRFIKSNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableOBRACUN.OBRFIKSNIHColumn] = value;
                }
            }

            public bool OBRKREDITNIH
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableOBRACUN.OBRKREDITNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableOBRACUN.OBRKREDITNIHColumn] = value;
                }
            }

            public bool OBRPOSTOTNIH
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableOBRACUN.OBRPOSTOTNIHColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableOBRACUN.OBRPOSTOTNIHColumn] = value;
                }
            }

            public decimal OSNOVNIOO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOBRACUN.OSNOVNIOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUN.OSNOVNIOOColumn] = value;
                }
            }

            public string SVRHAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUN.SVRHAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUN.SVRHAOBRACUNAColumn] = value;
                }
            }

            public short tjednifondsatiobracun
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableOBRACUN.tjednifondsatiobracunColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableOBRACUN.tjednifondsatiobracunColumn] = value;
                }
            }

            public string VRSTAOBRACUNA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOBRACUN.VRSTAOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableOBRACUN.VRSTAOBRACUNAColumn] = value;
                }
            }

            public bool ZAKLJ
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableOBRACUN.ZAKLJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableOBRACUN.ZAKLJColumn] = value;
                }
            }
        }

        public class OBRACUNRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OBRACUNDataSet.OBRACUNRow eventRow;

            public OBRACUNRowChangeEvent(OBRACUNDataSet.OBRACUNRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public OBRACUNDataSet.OBRACUNRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OBRACUNRowChangeEventHandler(object sender, OBRACUNDataSet.OBRACUNRowChangeEvent e);
    }
}

