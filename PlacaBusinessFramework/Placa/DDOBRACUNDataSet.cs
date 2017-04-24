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
    public class DDOBRACUNDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DDOBRACUNDataTable tableDDOBRACUN;
        private DDOBRACUNRadniciDataTable tableDDOBRACUNRadnici;
        private DDOBRACUNRadniciDDKrizniPorezDataTable tableDDOBRACUNRadniciDDKrizniPorez;
        private DDOBRACUNRadniciDoprinosiDataTable tableDDOBRACUNRadniciDoprinosi;
        private DDOBRACUNRadniciIzdaciDataTable tableDDOBRACUNRadniciIzdaci;
        private DDOBRACUNRadniciPoreziDataTable tableDDOBRACUNRadniciPorezi;
        private DDOBRACUNRadniciVrstePoslaDataTable tableDDOBRACUNRadniciVrstePosla;

        public DDOBRACUNDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DDOBRACUNDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DDOBRACUNRadniciDDKrizniPorez"] != null)
                    {
                        this.Tables.Add(new DDOBRACUNRadniciDDKrizniPorezDataTable(dataSet.Tables["DDOBRACUNRadniciDDKrizniPorez"]));
                    }
                    if (dataSet.Tables["DDOBRACUNRadniciPorezi"] != null)
                    {
                        this.Tables.Add(new DDOBRACUNRadniciPoreziDataTable(dataSet.Tables["DDOBRACUNRadniciPorezi"]));
                    }
                    if (dataSet.Tables["DDOBRACUNRadniciDoprinosi"] != null)
                    {
                        this.Tables.Add(new DDOBRACUNRadniciDoprinosiDataTable(dataSet.Tables["DDOBRACUNRadniciDoprinosi"]));
                    }
                    if (dataSet.Tables["DDOBRACUNRadniciIzdaci"] != null)
                    {
                        this.Tables.Add(new DDOBRACUNRadniciIzdaciDataTable(dataSet.Tables["DDOBRACUNRadniciIzdaci"]));
                    }
                    if (dataSet.Tables["DDOBRACUNRadniciVrstePosla"] != null)
                    {
                        this.Tables.Add(new DDOBRACUNRadniciVrstePoslaDataTable(dataSet.Tables["DDOBRACUNRadniciVrstePosla"]));
                    }
                    if (dataSet.Tables["DDOBRACUNRadnici"] != null)
                    {
                        this.Tables.Add(new DDOBRACUNRadniciDataTable(dataSet.Tables["DDOBRACUNRadnici"]));
                    }
                    if (dataSet.Tables["DDOBRACUN"] != null)
                    {
                        this.Tables.Add(new DDOBRACUNDataTable(dataSet.Tables["DDOBRACUN"]));
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
            DDOBRACUNDataSet set = (DDOBRACUNDataSet) base.Clone();
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
            DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DDOBRACUNDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2088");
            this.ExtendedProperties.Add("DataSetName", "DDOBRACUNDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDDOBRACUNDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DDOBRACUN");
            this.ExtendedProperties.Add("ObjectDescription", "DDOBRACUN");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "DDOBRACUNDataSet";
            this.Namespace = "http://www.tempuri.org/DDOBRACUN";
            this.tableDDOBRACUNRadniciDDKrizniPorez = new DDOBRACUNRadniciDDKrizniPorezDataTable();
            this.Tables.Add(this.tableDDOBRACUNRadniciDDKrizniPorez);
            this.tableDDOBRACUNRadniciPorezi = new DDOBRACUNRadniciPoreziDataTable();
            this.Tables.Add(this.tableDDOBRACUNRadniciPorezi);
            this.tableDDOBRACUNRadniciDoprinosi = new DDOBRACUNRadniciDoprinosiDataTable();
            this.Tables.Add(this.tableDDOBRACUNRadniciDoprinosi);
            this.tableDDOBRACUNRadniciIzdaci = new DDOBRACUNRadniciIzdaciDataTable();
            this.Tables.Add(this.tableDDOBRACUNRadniciIzdaci);
            this.tableDDOBRACUNRadniciVrstePosla = new DDOBRACUNRadniciVrstePoslaDataTable();
            this.Tables.Add(this.tableDDOBRACUNRadniciVrstePosla);
            this.tableDDOBRACUNRadnici = new DDOBRACUNRadniciDataTable();
            this.Tables.Add(this.tableDDOBRACUNRadnici);
            this.tableDDOBRACUN = new DDOBRACUNDataTable();
            this.Tables.Add(this.tableDDOBRACUN);
            this.Relations.Add("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez", new DataColumn[] { this.Tables["DDOBRACUNRadnici"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadnici"].Columns["DDIDRADNIK"] }, new DataColumn[] { this.Tables["DDOBRACUNRadniciDDKrizniPorez"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadniciDDKrizniPorez"].Columns["DDIDRADNIK"] });
            this.Relations["DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez"].Nested = true;
            this.Relations.Add("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi", new DataColumn[] { this.Tables["DDOBRACUNRadnici"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadnici"].Columns["DDIDRADNIK"] }, new DataColumn[] { this.Tables["DDOBRACUNRadniciPorezi"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadniciPorezi"].Columns["DDIDRADNIK"] });
            this.Relations["DDOBRACUNRadnici_DDOBRACUNRadniciPorezi"].Nested = true;
            this.Relations.Add("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi", new DataColumn[] { this.Tables["DDOBRACUNRadnici"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadnici"].Columns["DDIDRADNIK"] }, new DataColumn[] { this.Tables["DDOBRACUNRadniciDoprinosi"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadniciDoprinosi"].Columns["DDIDRADNIK"] });
            this.Relations["DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi"].Nested = true;
            this.Relations.Add("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci", new DataColumn[] { this.Tables["DDOBRACUNRadnici"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadnici"].Columns["DDIDRADNIK"] }, new DataColumn[] { this.Tables["DDOBRACUNRadniciIzdaci"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadniciIzdaci"].Columns["DDIDRADNIK"] });
            this.Relations["DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci"].Nested = true;
            this.Relations.Add("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla", new DataColumn[] { this.Tables["DDOBRACUNRadnici"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadnici"].Columns["DDIDRADNIK"] }, new DataColumn[] { this.Tables["DDOBRACUNRadniciVrstePosla"].Columns["DDOBRACUNIDOBRACUN"], this.Tables["DDOBRACUNRadniciVrstePosla"].Columns["DDIDRADNIK"] });
            this.Relations["DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla"].Nested = true;
            this.Relations.Add("DDOBRACUN_DDOBRACUNRadnici", new DataColumn[] { this.Tables["DDOBRACUN"].Columns["DDOBRACUNIDOBRACUN"] }, new DataColumn[] { this.Tables["DDOBRACUNRadnici"].Columns["DDOBRACUNIDOBRACUN"] });
            this.Relations["DDOBRACUN_DDOBRACUNRadnici"].Nested = true;
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
            this.tableDDOBRACUNRadniciDDKrizniPorez = (DDOBRACUNRadniciDDKrizniPorezDataTable) this.Tables["DDOBRACUNRadniciDDKrizniPorez"];
            this.tableDDOBRACUNRadniciPorezi = (DDOBRACUNRadniciPoreziDataTable) this.Tables["DDOBRACUNRadniciPorezi"];
            this.tableDDOBRACUNRadniciDoprinosi = (DDOBRACUNRadniciDoprinosiDataTable) this.Tables["DDOBRACUNRadniciDoprinosi"];
            this.tableDDOBRACUNRadniciIzdaci = (DDOBRACUNRadniciIzdaciDataTable) this.Tables["DDOBRACUNRadniciIzdaci"];
            this.tableDDOBRACUNRadniciVrstePosla = (DDOBRACUNRadniciVrstePoslaDataTable) this.Tables["DDOBRACUNRadniciVrstePosla"];
            this.tableDDOBRACUNRadnici = (DDOBRACUNRadniciDataTable) this.Tables["DDOBRACUNRadnici"];
            this.tableDDOBRACUN = (DDOBRACUNDataTable) this.Tables["DDOBRACUN"];
            if (initTable)
            {
                if (this.tableDDOBRACUNRadniciDDKrizniPorez != null)
                {
                    this.tableDDOBRACUNRadniciDDKrizniPorez.InitVars();
                }
                if (this.tableDDOBRACUNRadniciPorezi != null)
                {
                    this.tableDDOBRACUNRadniciPorezi.InitVars();
                }
                if (this.tableDDOBRACUNRadniciDoprinosi != null)
                {
                    this.tableDDOBRACUNRadniciDoprinosi.InitVars();
                }
                if (this.tableDDOBRACUNRadniciIzdaci != null)
                {
                    this.tableDDOBRACUNRadniciIzdaci.InitVars();
                }
                if (this.tableDDOBRACUNRadniciVrstePosla != null)
                {
                    this.tableDDOBRACUNRadniciVrstePosla.InitVars();
                }
                if (this.tableDDOBRACUNRadnici != null)
                {
                    this.tableDDOBRACUNRadnici.InitVars();
                }
                if (this.tableDDOBRACUN != null)
                {
                    this.tableDDOBRACUN.InitVars();
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
                if (dataSet.Tables["DDOBRACUNRadniciDDKrizniPorez"] != null)
                {
                    this.Tables.Add(new DDOBRACUNRadniciDDKrizniPorezDataTable(dataSet.Tables["DDOBRACUNRadniciDDKrizniPorez"]));
                }
                if (dataSet.Tables["DDOBRACUNRadniciPorezi"] != null)
                {
                    this.Tables.Add(new DDOBRACUNRadniciPoreziDataTable(dataSet.Tables["DDOBRACUNRadniciPorezi"]));
                }
                if (dataSet.Tables["DDOBRACUNRadniciDoprinosi"] != null)
                {
                    this.Tables.Add(new DDOBRACUNRadniciDoprinosiDataTable(dataSet.Tables["DDOBRACUNRadniciDoprinosi"]));
                }
                if (dataSet.Tables["DDOBRACUNRadniciIzdaci"] != null)
                {
                    this.Tables.Add(new DDOBRACUNRadniciIzdaciDataTable(dataSet.Tables["DDOBRACUNRadniciIzdaci"]));
                }
                if (dataSet.Tables["DDOBRACUNRadniciVrstePosla"] != null)
                {
                    this.Tables.Add(new DDOBRACUNRadniciVrstePoslaDataTable(dataSet.Tables["DDOBRACUNRadniciVrstePosla"]));
                }
                if (dataSet.Tables["DDOBRACUNRadnici"] != null)
                {
                    this.Tables.Add(new DDOBRACUNRadniciDataTable(dataSet.Tables["DDOBRACUNRadnici"]));
                }
                if (dataSet.Tables["DDOBRACUN"] != null)
                {
                    this.Tables.Add(new DDOBRACUNDataTable(dataSet.Tables["DDOBRACUN"]));
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

        private bool ShouldSerializeDDOBRACUN()
        {
            return false;
        }

        private bool ShouldSerializeDDOBRACUNRadnici()
        {
            return false;
        }

        private bool ShouldSerializeDDOBRACUNRadniciDDKrizniPorez()
        {
            return false;
        }

        private bool ShouldSerializeDDOBRACUNRadniciDoprinosi()
        {
            return false;
        }

        private bool ShouldSerializeDDOBRACUNRadniciIzdaci()
        {
            return false;
        }

        private bool ShouldSerializeDDOBRACUNRadniciPorezi()
        {
            return false;
        }

        private bool ShouldSerializeDDOBRACUNRadniciVrstePosla()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDOBRACUNDataTable DDOBRACUN
        {
            get
            {
                return this.tableDDOBRACUN;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDOBRACUNRadniciDataTable DDOBRACUNRadnici
        {
            get
            {
                return this.tableDDOBRACUNRadnici;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDOBRACUNRadniciDDKrizniPorezDataTable DDOBRACUNRadniciDDKrizniPorez
        {
            get
            {
                return this.tableDDOBRACUNRadniciDDKrizniPorez;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDOBRACUNRadniciDoprinosiDataTable DDOBRACUNRadniciDoprinosi
        {
            get
            {
                return this.tableDDOBRACUNRadniciDoprinosi;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDOBRACUNRadniciIzdaciDataTable DDOBRACUNRadniciIzdaci
        {
            get
            {
                return this.tableDDOBRACUNRadniciIzdaci;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDOBRACUNRadniciPoreziDataTable DDOBRACUNRadniciPorezi
        {
            get
            {
                return this.tableDDOBRACUNRadniciPorezi;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDOBRACUNRadniciVrstePoslaDataTable DDOBRACUNRadniciVrstePosla
        {
            get
            {
                return this.tableDDOBRACUNRadniciVrstePosla;
            }
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
        public class DDOBRACUNDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDDATUMOBRACUNA;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDOPISOBRACUN;
            private DataColumn columnDDRSM;
            private DataColumn columnDDZAKLJUCAN;

            public event DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler DDOBRACUNRowChanged;

            public event DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler DDOBRACUNRowChanging;

            public event DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler DDOBRACUNRowDeleted;

            public event DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler DDOBRACUNRowDeleting;

            public DDOBRACUNDataTable()
            {
                this.TableName = "DDOBRACUN";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDOBRACUNDataTable(DataTable table) : base(table.TableName)
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

            protected DDOBRACUNDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDOBRACUNRow(DDOBRACUNDataSet.DDOBRACUNRow row)
            {
                this.Rows.Add(row);
            }

            public DDOBRACUNDataSet.DDOBRACUNRow AddDDOBRACUNRow(string dDOBRACUNIDOBRACUN, string dDOPISOBRACUN, DateTime dDDATUMOBRACUNA, bool dDZAKLJUCAN, string dDRSM)
            {
                DDOBRACUNDataSet.DDOBRACUNRow row = (DDOBRACUNDataSet.DDOBRACUNRow) this.NewRow();
                row["DDOBRACUNIDOBRACUN"] = dDOBRACUNIDOBRACUN;
                row["DDOPISOBRACUN"] = dDOPISOBRACUN;
                row["DDDATUMOBRACUNA"] = dDDATUMOBRACUNA;
                row["DDZAKLJUCAN"] = dDZAKLJUCAN;
                row["DDRSM"] = dDRSM;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDOBRACUNDataSet.DDOBRACUNDataTable table = (DDOBRACUNDataSet.DDOBRACUNDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRow FindByDDOBRACUNIDOBRACUN(string dDOBRACUNIDOBRACUN)
            {
                return (DDOBRACUNDataSet.DDOBRACUNRow) this.Rows.Find(new object[] { dDOBRACUNIDOBRACUN });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDOBRACUNDataSet.DDOBRACUNRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.AllowDBNull = false;
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.Unique = true;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDOPISOBRACUN = new DataColumn("DDOPISOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOPISOBRACUN.AllowDBNull = false;
                this.columnDDOPISOBRACUN.Caption = "Opis";
                this.columnDDOPISOBRACUN.MaxLength = 50;
                this.columnDDOPISOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Description", "Opis");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Length", "50");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOPISOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOPISOBRACUN");
                this.Columns.Add(this.columnDDOPISOBRACUN);
                this.columnDDDATUMOBRACUNA = new DataColumn("DDDATUMOBRACUNA", typeof(DateTime), "", MappingType.Element);
                this.columnDDDATUMOBRACUNA.AllowDBNull = false;
                this.columnDDDATUMOBRACUNA.Caption = "Datum obračuna";
                this.columnDDDATUMOBRACUNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Description", "Datum obračuna");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Length", "8");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDDATUMOBRACUNA.ExtendedProperties.Add("Deklarit.InternalName", "DDDATUMOBRACUNA");
                this.Columns.Add(this.columnDDDATUMOBRACUNA);
                this.columnDDZAKLJUCAN = new DataColumn("DDZAKLJUCAN", typeof(bool), "", MappingType.Element);
                this.columnDDZAKLJUCAN.AllowDBNull = false;
                this.columnDDZAKLJUCAN.Caption = "DDZAKLJUCAN";
                this.columnDDZAKLJUCAN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Description", "DDZAKLJUCAN");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Length", "1");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDZAKLJUCAN.ExtendedProperties.Add("Deklarit.InternalName", "DDZAKLJUCAN");
                this.Columns.Add(this.columnDDZAKLJUCAN);
                this.columnDDRSM = new DataColumn("DDRSM", typeof(string), "", MappingType.Element);
                this.columnDDRSM.AllowDBNull = true;
                this.columnDDRSM.Caption = "DDRSM";
                this.columnDDRSM.MaxLength = 4;
                this.columnDDRSM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDRSM.ExtendedProperties.Add("IsKey", "false");
                this.columnDDRSM.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDRSM.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDRSM.ExtendedProperties.Add("Description", "DDRSM");
                this.columnDDRSM.ExtendedProperties.Add("Length", "4");
                this.columnDDRSM.ExtendedProperties.Add("Decimals", "0");
                this.columnDDRSM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDRSM.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDRSM.ExtendedProperties.Add("Deklarit.InternalName", "DDRSM");
                this.Columns.Add(this.columnDDRSM);
                this.PrimaryKey = new DataColumn[] { this.columnDDOBRACUNIDOBRACUN };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DDOBRACUN");
                this.ExtendedProperties.Add("Description", "DDOBRACUN");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDOPISOBRACUN = this.Columns["DDOPISOBRACUN"];
                this.columnDDDATUMOBRACUNA = this.Columns["DDDATUMOBRACUNA"];
                this.columnDDZAKLJUCAN = this.Columns["DDZAKLJUCAN"];
                this.columnDDRSM = this.Columns["DDRSM"];
            }

            public DDOBRACUNDataSet.DDOBRACUNRow NewDDOBRACUNRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDOBRACUNDataSet.DDOBRACUNRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDOBRACUNRowChanged != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler dDOBRACUNRowChangedEvent = this.DDOBRACUNRowChanged;
                    if (dDOBRACUNRowChangedEvent != null)
                    {
                        dDOBRACUNRowChangedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDOBRACUNRowChanging != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler dDOBRACUNRowChangingEvent = this.DDOBRACUNRowChanging;
                    if (dDOBRACUNRowChangingEvent != null)
                    {
                        dDOBRACUNRowChangingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DDOBRACUNRowDeleted != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler dDOBRACUNRowDeletedEvent = this.DDOBRACUNRowDeleted;
                    if (dDOBRACUNRowDeletedEvent != null)
                    {
                        dDOBRACUNRowDeletedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDOBRACUNRowDeleting != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRowChangeEventHandler dDOBRACUNRowDeletingEvent = this.DDOBRACUNRowDeleting;
                    if (dDOBRACUNRowDeletingEvent != null)
                    {
                        dDOBRACUNRowDeletingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDOBRACUNRow(DDOBRACUNDataSet.DDOBRACUNRow row)
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

            public DataColumn DDDATUMOBRACUNAColumn
            {
                get
                {
                    return this.columnDDDATUMOBRACUNA;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDOPISOBRACUNColumn
            {
                get
                {
                    return this.columnDDOPISOBRACUN;
                }
            }

            public DataColumn DDRSMColumn
            {
                get
                {
                    return this.columnDDRSM;
                }
            }

            public DataColumn DDZAKLJUCANColumn
            {
                get
                {
                    return this.columnDDZAKLJUCAN;
                }
            }

            public DDOBRACUNDataSet.DDOBRACUNRow this[int index]
            {
                get
                {
                    return (DDOBRACUNDataSet.DDOBRACUNRow) this.Rows[index];
                }
            }
        }

        [Serializable]
        public class DDOBRACUNRadniciDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDDRUGISTUP;
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDIME;
            private DataColumn columnDDOBRACUNATIPDV;
            private DataColumn columnDDOBRACUNATIPRIREZ;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDOIB;
            private DataColumn columnDDPDVOBVEZNIK;
            private DataColumn columnDDPREZIME;
            private DataColumn columnDDSIFRAOPCINESTANOVANJA;
            private DataColumn columnDDZRN;
            private DataColumn columnIDBANKE;
            private DataColumn columnIDKATEGORIJA;
            private DataColumn columnIDKOLONAIDD;
            private DataColumn columnNAZIVBANKE1;
            private DataColumn columnNAZIVBANKE2;
            private DataColumn columnNAZIVBANKE3;
            private DataColumn columnNAZIVKATEGORIJA;
            private DataColumn columnOPCINARADAIDOPCINE;
            private DataColumn columnOPCINARADANAZIVOPCINE;
            private DataColumn columnOPCINASTANOVANJAIDOPCINE;
            private DataColumn columnOPCINASTANOVANJANAZIVOPCINE;
            private DataColumn columnOPCINASTANOVANJAPRIREZ;
            private DataColumn columnOPCINASTANOVANJAVBDIOPCINA;
            private DataColumn columnOPCINASTANOVANJAZRNOPCINA;
            private DataColumn columnVBDIBANKE;
            private DataColumn columnZRNBANKE;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler DDOBRACUNRadniciRowChanged;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler DDOBRACUNRadniciRowChanging;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler DDOBRACUNRadniciRowDeleted;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler DDOBRACUNRadniciRowDeleting;

            public DDOBRACUNRadniciDataTable()
            {
                this.TableName = "DDOBRACUNRadnici";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDOBRACUNRadniciDataTable(DataTable table) : base(table.TableName)
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

            protected DDOBRACUNRadniciDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDOBRACUNRadniciRow(DDOBRACUNDataSet.DDOBRACUNRadniciRow row)
            {
                this.Rows.Add(row);
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow AddDDOBRACUNRadniciRow(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int iDKATEGORIJA, decimal dDOBRACUNATIPRIREZ, decimal dDOBRACUNATIPDV, string dDSIFRAOPCINESTANOVANJA)
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciRow row = (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.NewRow();
                row["DDOBRACUNIDOBRACUN"] = dDOBRACUNIDOBRACUN;
                row["DDIDRADNIK"] = dDIDRADNIK;
                row["IDKATEGORIJA"] = iDKATEGORIJA;
                row["DDOBRACUNATIPRIREZ"] = dDOBRACUNATIPRIREZ;
                row["DDOBRACUNATIPDV"] = dDOBRACUNATIPDV;
                row["DDSIFRAOPCINESTANOVANJA"] = dDSIFRAOPCINESTANOVANJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciDataTable table = (DDOBRACUNDataSet.DDOBRACUNRadniciDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow FindByDDOBRACUNIDOBRACUNDDIDRADNIK(string dDOBRACUNIDOBRACUN, int dDIDRADNIK)
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.Rows.Find(new object[] { dDOBRACUNIDOBRACUN, dDIDRADNIK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDOBRACUNDataSet.DDOBRACUNRadniciRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.AllowDBNull = false;
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.AllowDBNull = false;
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
                this.columnDDPREZIME = new DataColumn("DDPREZIME", typeof(string), "", MappingType.Element);
                this.columnDDPREZIME.AllowDBNull = true;
                this.columnDDPREZIME.Caption = "Prezime";
                this.columnDDPREZIME.MaxLength = 50;
                this.columnDDPREZIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPREZIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPREZIME.ExtendedProperties.Add("Description", "Prezime");
                this.columnDDPREZIME.ExtendedProperties.Add("Length", "50");
                this.columnDDPREZIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPREZIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPREZIME.ExtendedProperties.Add("Deklarit.InternalName", "DDPREZIME");
                this.Columns.Add(this.columnDDPREZIME);
                this.columnDDIME = new DataColumn("DDIME", typeof(string), "", MappingType.Element);
                this.columnDDIME.AllowDBNull = true;
                this.columnDDIME.Caption = "Ime";
                this.columnDDIME.MaxLength = 50;
                this.columnDDIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIME.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDIME.ExtendedProperties.Add("Description", "Ime");
                this.columnDDIME.ExtendedProperties.Add("Length", "50");
                this.columnDDIME.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIME.ExtendedProperties.Add("Deklarit.InternalName", "DDIME");
                this.Columns.Add(this.columnDDIME);
                this.columnIDKATEGORIJA = new DataColumn("IDKATEGORIJA", typeof(int), "", MappingType.Element);
                this.columnIDKATEGORIJA.AllowDBNull = false;
                this.columnIDKATEGORIJA.Caption = "IDKATEGORIJA";
                this.columnIDKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Description", "IDKATEGORIJA");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Length", "5");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "IDKATEGORIJA");
                this.Columns.Add(this.columnIDKATEGORIJA);
                this.columnNAZIVKATEGORIJA = new DataColumn("NAZIVKATEGORIJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVKATEGORIJA.AllowDBNull = true;
                this.columnNAZIVKATEGORIJA.Caption = "Kategorija";
                this.columnNAZIVKATEGORIJA.MaxLength = 50;
                this.columnNAZIVKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Description", "Kategorija");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKATEGORIJA");
                this.Columns.Add(this.columnNAZIVKATEGORIJA);
                this.columnDDOBRACUNATIPRIREZ = new DataColumn("DDOBRACUNATIPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnDDOBRACUNATIPRIREZ.AllowDBNull = false;
                this.columnDDOBRACUNATIPRIREZ.Caption = "DDOBRACUNATIPRIREZ";
                this.columnDDOBRACUNATIPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Description", "DDOBRACUNATIPRIREZ");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNATIPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNATIPRIREZ");
                this.Columns.Add(this.columnDDOBRACUNATIPRIREZ);
                this.columnDDOBRACUNATIPDV = new DataColumn("DDOBRACUNATIPDV", typeof(decimal), "", MappingType.Element);
                this.columnDDOBRACUNATIPDV.AllowDBNull = false;
                this.columnDDOBRACUNATIPDV.Caption = "DDOBRACUNATIPDV";
                this.columnDDOBRACUNATIPDV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Description", "DDOBRACUNATIPDV");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Length", "12");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNATIPDV.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNATIPDV");
                this.Columns.Add(this.columnDDOBRACUNATIPDV);
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
                this.columnOPCINASTANOVANJAIDOPCINE = new DataColumn("OPCINASTANOVANJAIDOPCINE", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAIDOPCINE.AllowDBNull = false;
                this.columnOPCINASTANOVANJAIDOPCINE.Caption = "Šifra općine stanovanja";
                this.columnOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
                this.columnOPCINASTANOVANJAIDOPCINE.DefaultValue = "";
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
                this.columnOPCINASTANOVANJAIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
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
                this.columnOPCINASTANOVANJAVBDIOPCINA = new DataColumn("OPCINASTANOVANJAVBDIOPCINA", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAVBDIOPCINA.AllowDBNull = true;
                this.columnOPCINASTANOVANJAVBDIOPCINA.Caption = "VBDI žiro računa općine stanovanja";
                this.columnOPCINASTANOVANJAVBDIOPCINA.MaxLength = 7;
                this.columnOPCINASTANOVANJAVBDIOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("SuperType", "VBDIOPCINA");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Description", "VBDI žiro računa općine stanovanja");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Length", "7");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAVBDIOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAVBDIOPCINA");
                this.Columns.Add(this.columnOPCINASTANOVANJAVBDIOPCINA);
                this.columnOPCINASTANOVANJAZRNOPCINA = new DataColumn("OPCINASTANOVANJAZRNOPCINA", typeof(string), "", MappingType.Element);
                this.columnOPCINASTANOVANJAZRNOPCINA.AllowDBNull = true;
                this.columnOPCINASTANOVANJAZRNOPCINA.Caption = "Broj žiro računa općine stanovanja";
                this.columnOPCINASTANOVANJAZRNOPCINA.MaxLength = 10;
                this.columnOPCINASTANOVANJAZRNOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("SuperType", "ZRNOPCINA");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("SubtypeGroup", "OPCINASTANOVANJA");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Description", "Broj žiro računa općine stanovanja");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Length", "10");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPCINASTANOVANJAZRNOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "OPCINASTANOVANJAZRNOPCINA");
                this.Columns.Add(this.columnOPCINASTANOVANJAZRNOPCINA);
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
                this.columnDDPDVOBVEZNIK = new DataColumn("DDPDVOBVEZNIK", typeof(bool), "", MappingType.Element);
                this.columnDDPDVOBVEZNIK.AllowDBNull = true;
                this.columnDDPDVOBVEZNIK.Caption = "DDPDVOBVEZNIK";
                this.columnDDPDVOBVEZNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Description", "DDPDVOBVEZNIK");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Length", "1");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPDVOBVEZNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDPDVOBVEZNIK");
                this.Columns.Add(this.columnDDPDVOBVEZNIK);
                this.columnDDDRUGISTUP = new DataColumn("DDDRUGISTUP", typeof(bool), "", MappingType.Element);
                this.columnDDDRUGISTUP.AllowDBNull = true;
                this.columnDDDRUGISTUP.Caption = "DDDRUGISTUP";
                this.columnDDDRUGISTUP.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("IsKey", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Description", "DDDRUGISTUP");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Length", "1");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Decimals", "0");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDDRUGISTUP.ExtendedProperties.Add("Deklarit.InternalName", "DDDRUGISTUP");
                this.Columns.Add(this.columnDDDRUGISTUP);
                this.columnDDSIFRAOPCINESTANOVANJA = new DataColumn("DDSIFRAOPCINESTANOVANJA", typeof(string), "", MappingType.Element);
                this.columnDDSIFRAOPCINESTANOVANJA.AllowDBNull = false;
                this.columnDDSIFRAOPCINESTANOVANJA.Caption = "DDSIFRAOPCINESTANOVANJA";
                this.columnDDSIFRAOPCINESTANOVANJA.MaxLength = 4;
                this.columnDDSIFRAOPCINESTANOVANJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Description", "DDSIFRAOPCINESTANOVANJA");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Length", "4");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDSIFRAOPCINESTANOVANJA.ExtendedProperties.Add("Deklarit.InternalName", "DDSIFRAOPCINESTANOVANJA");
                this.Columns.Add(this.columnDDSIFRAOPCINESTANOVANJA);
                this.columnIDKOLONAIDD = new DataColumn("IDKOLONAIDD", typeof(int), "", MappingType.Element);
                this.columnIDKOLONAIDD.AllowDBNull = false;
                this.columnIDKOLONAIDD.Caption = "Kolona IDD obrasca";
                this.columnIDKOLONAIDD.DefaultValue = 0;
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("IsKey", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Description", "Kolona IDD obrasca");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Length", "5");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.InternalName", "IDKOLONAIDD");
                this.Columns.Add(this.columnIDKOLONAIDD);
                this.columnDDOIB = new DataColumn("DDOIB", typeof(string), "", MappingType.Element);
                this.columnDDOIB.AllowDBNull = true;
                this.columnDDOIB.Caption = "OIB";
                this.columnDDOIB.MaxLength = 11;
                this.columnDDOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnDDOIB.ExtendedProperties.Add("Length", "11");
                this.columnDDOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOIB.ExtendedProperties.Add("Deklarit.InternalName", "DDOIB");
                this.Columns.Add(this.columnDDOIB);
                this.columnDDZRN = new DataColumn("DDZRN", typeof(string), "", MappingType.Element);
                this.columnDDZRN.AllowDBNull = true;
                this.columnDDZRN.Caption = "DDZRN";
                this.columnDDZRN.MaxLength = 10;
                this.columnDDZRN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDZRN.ExtendedProperties.Add("IsKey", "false");
                this.columnDDZRN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDZRN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDZRN.ExtendedProperties.Add("Description", "DDZRN");
                this.columnDDZRN.ExtendedProperties.Add("Length", "10");
                this.columnDDZRN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDZRN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDZRN.ExtendedProperties.Add("Deklarit.InternalName", "DDZRN");
                this.Columns.Add(this.columnDDZRN);
                this.PrimaryKey = new DataColumn[] { this.columnDDOBRACUNIDOBRACUN, this.columnDDIDRADNIK };
                this.ExtendedProperties.Add("ParentLvl", "DDOBRACUN");
                this.ExtendedProperties.Add("LevelName", "Radnici");
                this.ExtendedProperties.Add("Description", "Radnici");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnDDPREZIME = this.Columns["DDPREZIME"];
                this.columnDDIME = this.Columns["DDIME"];
                this.columnIDKATEGORIJA = this.Columns["IDKATEGORIJA"];
                this.columnNAZIVKATEGORIJA = this.Columns["NAZIVKATEGORIJA"];
                this.columnDDOBRACUNATIPRIREZ = this.Columns["DDOBRACUNATIPRIREZ"];
                this.columnDDOBRACUNATIPDV = this.Columns["DDOBRACUNATIPDV"];
                this.columnOPCINARADAIDOPCINE = this.Columns["OPCINARADAIDOPCINE"];
                this.columnOPCINARADANAZIVOPCINE = this.Columns["OPCINARADANAZIVOPCINE"];
                this.columnOPCINASTANOVANJAIDOPCINE = this.Columns["OPCINASTANOVANJAIDOPCINE"];
                this.columnOPCINASTANOVANJANAZIVOPCINE = this.Columns["OPCINASTANOVANJANAZIVOPCINE"];
                this.columnOPCINASTANOVANJAPRIREZ = this.Columns["OPCINASTANOVANJAPRIREZ"];
                this.columnOPCINASTANOVANJAVBDIOPCINA = this.Columns["OPCINASTANOVANJAVBDIOPCINA"];
                this.columnOPCINASTANOVANJAZRNOPCINA = this.Columns["OPCINASTANOVANJAZRNOPCINA"];
                this.columnIDBANKE = this.Columns["IDBANKE"];
                this.columnNAZIVBANKE1 = this.Columns["NAZIVBANKE1"];
                this.columnNAZIVBANKE2 = this.Columns["NAZIVBANKE2"];
                this.columnNAZIVBANKE3 = this.Columns["NAZIVBANKE3"];
                this.columnVBDIBANKE = this.Columns["VBDIBANKE"];
                this.columnZRNBANKE = this.Columns["ZRNBANKE"];
                this.columnDDPDVOBVEZNIK = this.Columns["DDPDVOBVEZNIK"];
                this.columnDDDRUGISTUP = this.Columns["DDDRUGISTUP"];
                this.columnDDSIFRAOPCINESTANOVANJA = this.Columns["DDSIFRAOPCINESTANOVANJA"];
                this.columnIDKOLONAIDD = this.Columns["IDKOLONAIDD"];
                this.columnDDOIB = this.Columns["DDOIB"];
                this.columnDDZRN = this.Columns["DDZRN"];
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow NewDDOBRACUNRadniciRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDOBRACUNDataSet.DDOBRACUNRadniciRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDOBRACUNRadniciRowChanged != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler dDOBRACUNRadniciRowChangedEvent = this.DDOBRACUNRadniciRowChanged;
                    if (dDOBRACUNRadniciRowChangedEvent != null)
                    {
                        dDOBRACUNRadniciRowChangedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDOBRACUNRadniciRowChanging != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler dDOBRACUNRadniciRowChangingEvent = this.DDOBRACUNRadniciRowChanging;
                    if (dDOBRACUNRadniciRowChangingEvent != null)
                    {
                        dDOBRACUNRadniciRowChangingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDOBRACUN_DDOBRACUNRadnici", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDOBRACUNRadniciRowDeleted != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler dDOBRACUNRadniciRowDeletedEvent = this.DDOBRACUNRadniciRowDeleted;
                    if (dDOBRACUNRadniciRowDeletedEvent != null)
                    {
                        dDOBRACUNRadniciRowDeletedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDOBRACUNRadniciRowDeleting != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEventHandler dDOBRACUNRadniciRowDeletingEvent = this.DDOBRACUNRadniciRowDeleting;
                    if (dDOBRACUNRadniciRowDeletingEvent != null)
                    {
                        dDOBRACUNRadniciRowDeletingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDOBRACUNRadniciRow(DDOBRACUNDataSet.DDOBRACUNRadniciRow row)
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

            public DataColumn DDDRUGISTUPColumn
            {
                get
                {
                    return this.columnDDDRUGISTUP;
                }
            }

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDIMEColumn
            {
                get
                {
                    return this.columnDDIME;
                }
            }

            public DataColumn DDOBRACUNATIPDVColumn
            {
                get
                {
                    return this.columnDDOBRACUNATIPDV;
                }
            }

            public DataColumn DDOBRACUNATIPRIREZColumn
            {
                get
                {
                    return this.columnDDOBRACUNATIPRIREZ;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDOIBColumn
            {
                get
                {
                    return this.columnDDOIB;
                }
            }

            public DataColumn DDPDVOBVEZNIKColumn
            {
                get
                {
                    return this.columnDDPDVOBVEZNIK;
                }
            }

            public DataColumn DDPREZIMEColumn
            {
                get
                {
                    return this.columnDDPREZIME;
                }
            }

            public DataColumn DDSIFRAOPCINESTANOVANJAColumn
            {
                get
                {
                    return this.columnDDSIFRAOPCINESTANOVANJA;
                }
            }

            public DataColumn DDZRNColumn
            {
                get
                {
                    return this.columnDDZRN;
                }
            }

            public DataColumn IDBANKEColumn
            {
                get
                {
                    return this.columnIDBANKE;
                }
            }

            public DataColumn IDKATEGORIJAColumn
            {
                get
                {
                    return this.columnIDKATEGORIJA;
                }
            }

            public DataColumn IDKOLONAIDDColumn
            {
                get
                {
                    return this.columnIDKOLONAIDD;
                }
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow this[int index]
            {
                get
                {
                    return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.Rows[index];
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

            public DataColumn NAZIVKATEGORIJAColumn
            {
                get
                {
                    return this.columnNAZIVKATEGORIJA;
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

            public DataColumn OPCINASTANOVANJAVBDIOPCINAColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAVBDIOPCINA;
                }
            }

            public DataColumn OPCINASTANOVANJAZRNOPCINAColumn
            {
                get
                {
                    return this.columnOPCINASTANOVANJAZRNOPCINA;
                }
            }

            public DataColumn VBDIBANKEColumn
            {
                get
                {
                    return this.columnVBDIBANKE;
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

        [Serializable]
        public class DDOBRACUNRadniciDDKrizniPorezDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDOSNOVICAKRIZNI;
            private DataColumn columnDDOSNOVICAPRETHODNA;
            private DataColumn columnDDOSNOVICAUKUPNA;
            private DataColumn columnDDPOREZKRIZNI;
            private DataColumn columnDDPOREZPRETHODNI;
            private DataColumn columnDDPOREZUKUPNO;
            private DataColumn columnIDKRIZNIPOREZ;
            private DataColumn columnKRIZNISTOPA;
            private DataColumn columnMOKRIZNI;
            private DataColumn columnMZKRIZNI;
            private DataColumn columnNAZIVKRIZNIPOREZ;
            private DataColumn columnOPISPLACANJAKRIZNI;
            private DataColumn columnPOKRIZNI;
            private DataColumn columnPRIMATELJKRIZNI1;
            private DataColumn columnPRIMATELJKRIZNI2;
            private DataColumn columnPRIMATELJKRIZNI3;
            private DataColumn columnPZKRIZNI;
            private DataColumn columnSIFRAOPISAPLACANJAKRIZNI;
            private DataColumn columnVBDIKRIZNI;
            private DataColumn columnZRNKRIZNI;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler DDOBRACUNRadniciDDKrizniPorezRowChanged;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler DDOBRACUNRadniciDDKrizniPorezRowChanging;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler DDOBRACUNRadniciDDKrizniPorezRowDeleted;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler DDOBRACUNRadniciDDKrizniPorezRowDeleting;

            public DDOBRACUNRadniciDDKrizniPorezDataTable()
            {
                this.TableName = "DDOBRACUNRadniciDDKrizniPorez";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDOBRACUNRadniciDDKrizniPorezDataTable(DataTable table) : base(table.TableName)
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

            protected DDOBRACUNRadniciDDKrizniPorezDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDOBRACUNRadniciDDKrizniPorezRow(DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow row)
            {
                this.Rows.Add(row);
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow AddDDOBRACUNRadniciDDKrizniPorezRow(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int iDKRIZNIPOREZ, decimal dDOSNOVICAKRIZNI, decimal dDPOREZKRIZNI, decimal dDOSNOVICAPRETHODNA, decimal dDOSNOVICAUKUPNA, decimal dDPOREZPRETHODNI, decimal dDPOREZUKUPNO)
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow row = (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) this.NewRow();
                row["DDOBRACUNIDOBRACUN"] = dDOBRACUNIDOBRACUN;
                row["DDIDRADNIK"] = dDIDRADNIK;
                row["IDKRIZNIPOREZ"] = iDKRIZNIPOREZ;
                row["DDOSNOVICAKRIZNI"] = dDOSNOVICAKRIZNI;
                row["DDPOREZKRIZNI"] = dDPOREZKRIZNI;
                row["DDOSNOVICAPRETHODNA"] = dDOSNOVICAPRETHODNA;
                row["DDOSNOVICAUKUPNA"] = dDOSNOVICAUKUPNA;
                row["DDPOREZPRETHODNI"] = dDPOREZPRETHODNI;
                row["DDPOREZUKUPNO"] = dDPOREZUKUPNO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezDataTable table = (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow FindByDDOBRACUNIDOBRACUNDDIDRADNIKIDKRIZNIPOREZ(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int iDKRIZNIPOREZ)
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) this.Rows.Find(new object[] { dDOBRACUNIDOBRACUN, dDIDRADNIK, iDKRIZNIPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.AllowDBNull = false;
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.AllowDBNull = false;
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
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
                this.columnPRIMATELJKRIZNI3.AllowDBNull = true;
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
                this.columnPRIMATELJKRIZNI3.ExtendedProperties.Add("AllowDBNulls", "true");
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
                this.columnDDOSNOVICAKRIZNI = new DataColumn("DDOSNOVICAKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnDDOSNOVICAKRIZNI.AllowDBNull = false;
                this.columnDDOSNOVICAKRIZNI.Caption = "DDOSNOVICAKRIZNI";
                this.columnDDOSNOVICAKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Description", "DDOSNOVICAKRIZNI");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOSNOVICAKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "DDOSNOVICAKRIZNI");
                this.Columns.Add(this.columnDDOSNOVICAKRIZNI);
                this.columnDDPOREZKRIZNI = new DataColumn("DDPOREZKRIZNI", typeof(decimal), "", MappingType.Element);
                this.columnDDPOREZKRIZNI.AllowDBNull = false;
                this.columnDDPOREZKRIZNI.Caption = "DDPOREZKRIZNI";
                this.columnDDPOREZKRIZNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Description", "DDPOREZKRIZNI");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Length", "12");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Decimals", "2");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOREZKRIZNI.ExtendedProperties.Add("Deklarit.InternalName", "DDPOREZKRIZNI");
                this.Columns.Add(this.columnDDPOREZKRIZNI);
                this.columnDDOSNOVICAPRETHODNA = new DataColumn("DDOSNOVICAPRETHODNA", typeof(decimal), "", MappingType.Element);
                this.columnDDOSNOVICAPRETHODNA.AllowDBNull = false;
                this.columnDDOSNOVICAPRETHODNA.Caption = "DDOSNOVICAPRETHODNA";
                this.columnDDOSNOVICAPRETHODNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Description", "DDOSNOVICAPRETHODNA");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Length", "12");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOSNOVICAPRETHODNA.ExtendedProperties.Add("Deklarit.InternalName", "DDOSNOVICAPRETHODNA");
                this.Columns.Add(this.columnDDOSNOVICAPRETHODNA);
                this.columnDDOSNOVICAUKUPNA = new DataColumn("DDOSNOVICAUKUPNA", typeof(decimal), "", MappingType.Element);
                this.columnDDOSNOVICAUKUPNA.AllowDBNull = false;
                this.columnDDOSNOVICAUKUPNA.Caption = "DDOSNOVICAUKUPNA";
                this.columnDDOSNOVICAUKUPNA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Description", "DDOSNOVICAUKUPNA");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Length", "12");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOSNOVICAUKUPNA.ExtendedProperties.Add("Deklarit.InternalName", "DDOSNOVICAUKUPNA");
                this.Columns.Add(this.columnDDOSNOVICAUKUPNA);
                this.columnDDPOREZPRETHODNI = new DataColumn("DDPOREZPRETHODNI", typeof(decimal), "", MappingType.Element);
                this.columnDDPOREZPRETHODNI.AllowDBNull = false;
                this.columnDDPOREZPRETHODNI.Caption = "DDPOREZPRETHODNI";
                this.columnDDPOREZPRETHODNI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Description", "DDPOREZPRETHODNI");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Length", "12");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Decimals", "2");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOREZPRETHODNI.ExtendedProperties.Add("Deklarit.InternalName", "DDPOREZPRETHODNI");
                this.Columns.Add(this.columnDDPOREZPRETHODNI);
                this.columnDDPOREZUKUPNO = new DataColumn("DDPOREZUKUPNO", typeof(decimal), "", MappingType.Element);
                this.columnDDPOREZUKUPNO.AllowDBNull = false;
                this.columnDDPOREZUKUPNO.Caption = "DDPOREZUKUPNO";
                this.columnDDPOREZUKUPNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Description", "DDPOREZUKUPNO");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Length", "12");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Decimals", "2");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOREZUKUPNO.ExtendedProperties.Add("Deklarit.InternalName", "DDPOREZUKUPNO");
                this.Columns.Add(this.columnDDPOREZUKUPNO);
                this.PrimaryKey = new DataColumn[] { this.columnDDOBRACUNIDOBRACUN, this.columnDDIDRADNIK, this.columnIDKRIZNIPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "DDOBRACUNRadnici");
                this.ExtendedProperties.Add("LevelName", "DDKrizniPorez");
                this.ExtendedProperties.Add("Description", "DDKrizniPorez");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
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
                this.columnDDOSNOVICAKRIZNI = this.Columns["DDOSNOVICAKRIZNI"];
                this.columnDDPOREZKRIZNI = this.Columns["DDPOREZKRIZNI"];
                this.columnDDOSNOVICAPRETHODNA = this.Columns["DDOSNOVICAPRETHODNA"];
                this.columnDDOSNOVICAUKUPNA = this.Columns["DDOSNOVICAUKUPNA"];
                this.columnDDPOREZPRETHODNI = this.Columns["DDPOREZPRETHODNI"];
                this.columnDDPOREZUKUPNO = this.Columns["DDPOREZUKUPNO"];
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow NewDDOBRACUNRadniciDDKrizniPorezRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDOBRACUNRadniciDDKrizniPorezRowChanged != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler dDOBRACUNRadniciDDKrizniPorezRowChangedEvent = this.DDOBRACUNRadniciDDKrizniPorezRowChanged;
                    if (dDOBRACUNRadniciDDKrizniPorezRowChangedEvent != null)
                    {
                        dDOBRACUNRadniciDDKrizniPorezRowChangedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDOBRACUNRadniciDDKrizniPorezRowChanging != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler dDOBRACUNRadniciDDKrizniPorezRowChangingEvent = this.DDOBRACUNRadniciDDKrizniPorezRowChanging;
                    if (dDOBRACUNRadniciDDKrizniPorezRowChangingEvent != null)
                    {
                        dDOBRACUNRadniciDDKrizniPorezRowChangingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDOBRACUNRadniciDDKrizniPorezRowDeleted != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler dDOBRACUNRadniciDDKrizniPorezRowDeletedEvent = this.DDOBRACUNRadniciDDKrizniPorezRowDeleted;
                    if (dDOBRACUNRadniciDDKrizniPorezRowDeletedEvent != null)
                    {
                        dDOBRACUNRadniciDDKrizniPorezRowDeletedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDOBRACUNRadniciDDKrizniPorezRowDeleting != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler dDOBRACUNRadniciDDKrizniPorezRowDeletingEvent = this.DDOBRACUNRadniciDDKrizniPorezRowDeleting;
                    if (dDOBRACUNRadniciDDKrizniPorezRowDeletingEvent != null)
                    {
                        dDOBRACUNRadniciDDKrizniPorezRowDeletingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDOBRACUNRadniciDDKrizniPorezRow(DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow row)
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

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDOSNOVICAKRIZNIColumn
            {
                get
                {
                    return this.columnDDOSNOVICAKRIZNI;
                }
            }

            public DataColumn DDOSNOVICAPRETHODNAColumn
            {
                get
                {
                    return this.columnDDOSNOVICAPRETHODNA;
                }
            }

            public DataColumn DDOSNOVICAUKUPNAColumn
            {
                get
                {
                    return this.columnDDOSNOVICAUKUPNA;
                }
            }

            public DataColumn DDPOREZKRIZNIColumn
            {
                get
                {
                    return this.columnDDPOREZKRIZNI;
                }
            }

            public DataColumn DDPOREZPRETHODNIColumn
            {
                get
                {
                    return this.columnDDPOREZPRETHODNI;
                }
            }

            public DataColumn DDPOREZUKUPNOColumn
            {
                get
                {
                    return this.columnDDPOREZUKUPNO;
                }
            }

            public DataColumn IDKRIZNIPOREZColumn
            {
                get
                {
                    return this.columnIDKRIZNIPOREZ;
                }
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow this[int index]
            {
                get
                {
                    return (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow) this.Rows[index];
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

            public DataColumn POKRIZNIColumn
            {
                get
                {
                    return this.columnPOKRIZNI;
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

        public class DDOBRACUNRadniciDDKrizniPorezRow : DataRow
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezDataTable tableDDOBRACUNRadniciDDKrizniPorez;

            internal DDOBRACUNRadniciDDKrizniPorezRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDOBRACUNRadniciDDKrizniPorez = (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezDataTable) this.Table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow GetDDOBRACUNRadniciRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez");
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDIDRADNIKColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDOSNOVICAKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAKRIZNIColumn);
            }

            public bool IsDDOSNOVICAPRETHODNANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAPRETHODNAColumn);
            }

            public bool IsDDOSNOVICAUKUPNANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAUKUPNAColumn);
            }

            public bool IsDDPOREZKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZKRIZNIColumn);
            }

            public bool IsDDPOREZPRETHODNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZPRETHODNIColumn);
            }

            public bool IsDDPOREZUKUPNONull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZUKUPNOColumn);
            }

            public bool IsIDKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.IDKRIZNIPOREZColumn);
            }

            public bool IsKRIZNISTOPANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.KRIZNISTOPAColumn);
            }

            public bool IsMOKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.MOKRIZNIColumn);
            }

            public bool IsMZKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.MZKRIZNIColumn);
            }

            public bool IsNAZIVKRIZNIPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.NAZIVKRIZNIPOREZColumn);
            }

            public bool IsOPISPLACANJAKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.OPISPLACANJAKRIZNIColumn);
            }

            public bool IsPOKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.POKRIZNIColumn);
            }

            public bool IsPRIMATELJKRIZNI1Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI1Column);
            }

            public bool IsPRIMATELJKRIZNI2Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI2Column);
            }

            public bool IsPRIMATELJKRIZNI3Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI3Column);
            }

            public bool IsPZKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.PZKRIZNIColumn);
            }

            public bool IsSIFRAOPISAPLACANJAKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.SIFRAOPISAPLACANJAKRIZNIColumn);
            }

            public bool IsVBDIKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.VBDIKRIZNIColumn);
            }

            public bool IsZRNKRIZNINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDDKrizniPorez.ZRNKRIZNIColumn);
            }

            public void SetDDOSNOVICAKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOSNOVICAPRETHODNANull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAPRETHODNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOSNOVICAUKUPNANull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAUKUPNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOREZKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOREZPRETHODNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZPRETHODNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOREZUKUPNONull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZUKUPNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKRIZNISTOPANull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.KRIZNISTOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMOKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.MOKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.MZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKRIZNIPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.NAZIVKRIZNIPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.OPISPLACANJAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.POKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI1Null()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI2Null()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJKRIZNI3Null()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.PZKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.SIFRAOPISAPLACANJAKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.VBDIKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNKRIZNINull()
            {
                this[this.tableDDOBRACUNRadniciDDKrizniPorez.ZRNKRIZNIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDIDRADNIKColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDIDRADNIKColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOBRACUNIDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public decimal DDOSNOVICAKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAKRIZNIColumn] = value;
                }
            }

            public decimal DDOSNOVICAPRETHODNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAPRETHODNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAPRETHODNAColumn] = value;
                }
            }

            public decimal DDOSNOVICAUKUPNA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAUKUPNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDOSNOVICAUKUPNAColumn] = value;
                }
            }

            public decimal DDPOREZKRIZNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZKRIZNIColumn] = value;
                }
            }

            public decimal DDPOREZPRETHODNI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZPRETHODNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZPRETHODNIColumn] = value;
                }
            }

            public decimal DDPOREZUKUPNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZUKUPNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.DDPOREZUKUPNOColumn] = value;
                }
            }

            public int IDKRIZNIPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciDDKrizniPorez.IDKRIZNIPOREZColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.IDKRIZNIPOREZColumn] = value;
                }
            }

            public decimal KRIZNISTOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDDKrizniPorez.KRIZNISTOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.KRIZNISTOPAColumn] = value;
                }
            }

            public string MOKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.MOKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.MOKRIZNIColumn] = value;
                }
            }

            public string MZKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.MZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.MZKRIZNIColumn] = value;
                }
            }

            public string NAZIVKRIZNIPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.NAZIVKRIZNIPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.NAZIVKRIZNIPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.OPISPLACANJAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.OPISPLACANJAKRIZNIColumn] = value;
                }
            }

            public string POKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.POKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.POKRIZNIColumn] = value;
                }
            }

            public string PRIMATELJKRIZNI1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI1Column] = value;
                }
            }

            public string PRIMATELJKRIZNI2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI2Column] = value;
                }
            }

            public string PRIMATELJKRIZNI3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.PRIMATELJKRIZNI3Column] = value;
                }
            }

            public string PZKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.PZKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.PZKRIZNIColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.SIFRAOPISAPLACANJAKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.SIFRAOPISAPLACANJAKRIZNIColumn] = value;
                }
            }

            public string VBDIKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.VBDIKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.VBDIKRIZNIColumn] = value;
                }
            }

            public string ZRNKRIZNI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDDKrizniPorez.ZRNKRIZNIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDDKrizniPorez.ZRNKRIZNIColumn] = value;
                }
            }
        }

        public class DDOBRACUNRadniciDDKrizniPorezRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow eventRow;

            public DDOBRACUNRadniciDDKrizniPorezRowChangeEvent(DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow row, DataRowAction action)
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

            public DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDOBRACUNRadniciDDKrizniPorezRowChangeEventHandler(object sender, DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRowChangeEvent e);

        [Serializable]
        public class DDOBRACUNRadniciDoprinosiDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDOBRACUNATIDOPRINOS;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDOSNOVICADOPRINOS;
            private DataColumn columnIDDOPRINOS;
            private DataColumn columnIDVRSTADOPRINOS;
            private DataColumn columnMODOPRINOS;
            private DataColumn columnMZDOPRINOS;
            private DataColumn columnNAZIVDOPRINOS;
            private DataColumn columnNAZIVVRSTADOPRINOS;
            private DataColumn columnOPISPLACANJADOPRINOS;
            private DataColumn columnPODOPRINOS;
            private DataColumn columnPRIMATELJDOPRINOS1;
            private DataColumn columnPRIMATELJDOPRINOS2;
            private DataColumn columnPZDOPRINOS;
            private DataColumn columnSIFRAOPISAPLACANJADOPRINOS;
            private DataColumn columnSTOPA;
            private DataColumn columnVBDIDOPRINOS;
            private DataColumn columnZRNDOPRINOS;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler DDOBRACUNRadniciDoprinosiRowChanged;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler DDOBRACUNRadniciDoprinosiRowChanging;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler DDOBRACUNRadniciDoprinosiRowDeleted;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler DDOBRACUNRadniciDoprinosiRowDeleting;

            public DDOBRACUNRadniciDoprinosiDataTable()
            {
                this.TableName = "DDOBRACUNRadniciDoprinosi";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDOBRACUNRadniciDoprinosiDataTable(DataTable table) : base(table.TableName)
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

            protected DDOBRACUNRadniciDoprinosiDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDOBRACUNRadniciDoprinosiRow(DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow row)
            {
                this.Rows.Add(row);
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow AddDDOBRACUNRadniciDoprinosiRow(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int iDDOPRINOS, decimal dDOBRACUNATIDOPRINOS, decimal dDOSNOVICADOPRINOS)
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow row = (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) this.NewRow();
                row["DDOBRACUNIDOBRACUN"] = dDOBRACUNIDOBRACUN;
                row["DDIDRADNIK"] = dDIDRADNIK;
                row["IDDOPRINOS"] = iDDOPRINOS;
                row["DDOBRACUNATIDOPRINOS"] = dDOBRACUNATIDOPRINOS;
                row["DDOSNOVICADOPRINOS"] = dDOSNOVICADOPRINOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiDataTable table = (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow FindByDDOBRACUNIDOBRACUNDDIDRADNIKIDDOPRINOS(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int iDDOPRINOS)
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) this.Rows.Find(new object[] { dDOBRACUNIDOBRACUN, dDIDRADNIK, iDDOPRINOS });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.AllowDBNull = false;
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.AllowDBNull = false;
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
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
                this.columnPRIMATELJDOPRINOS2.AllowDBNull = false;
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
                this.columnPRIMATELJDOPRINOS2.ExtendedProperties.Add("AllowDBNulls", "false");
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
                this.columnDDOBRACUNATIDOPRINOS = new DataColumn("DDOBRACUNATIDOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnDDOBRACUNATIDOPRINOS.AllowDBNull = false;
                this.columnDDOBRACUNATIDOPRINOS.Caption = "DDOBRACUNATIDOPRINOS";
                this.columnDDOBRACUNATIDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Description", "DDOBRACUNATIDOPRINOS");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNATIDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNATIDOPRINOS");
                this.Columns.Add(this.columnDDOBRACUNATIDOPRINOS);
                this.columnDDOSNOVICADOPRINOS = new DataColumn("DDOSNOVICADOPRINOS", typeof(decimal), "", MappingType.Element);
                this.columnDDOSNOVICADOPRINOS.AllowDBNull = false;
                this.columnDDOSNOVICADOPRINOS.Caption = "DDOSNOVICADOPRINOS";
                this.columnDDOSNOVICADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Description", "DDOSNOVICADOPRINOS");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Length", "12");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOSNOVICADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "DDOSNOVICADOPRINOS");
                this.Columns.Add(this.columnDDOSNOVICADOPRINOS);
                this.PrimaryKey = new DataColumn[] { this.columnDDOBRACUNIDOBRACUN, this.columnDDIDRADNIK, this.columnIDDOPRINOS };
                this.ExtendedProperties.Add("ParentLvl", "DDOBRACUNRadnici");
                this.ExtendedProperties.Add("LevelName", "Doprinosi");
                this.ExtendedProperties.Add("Description", "Doprinosi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnIDDOPRINOS = this.Columns["IDDOPRINOS"];
                this.columnNAZIVDOPRINOS = this.Columns["NAZIVDOPRINOS"];
                this.columnIDVRSTADOPRINOS = this.Columns["IDVRSTADOPRINOS"];
                this.columnNAZIVVRSTADOPRINOS = this.Columns["NAZIVVRSTADOPRINOS"];
                this.columnMODOPRINOS = this.Columns["MODOPRINOS"];
                this.columnPODOPRINOS = this.Columns["PODOPRINOS"];
                this.columnMZDOPRINOS = this.Columns["MZDOPRINOS"];
                this.columnPZDOPRINOS = this.Columns["PZDOPRINOS"];
                this.columnPRIMATELJDOPRINOS1 = this.Columns["PRIMATELJDOPRINOS1"];
                this.columnPRIMATELJDOPRINOS2 = this.Columns["PRIMATELJDOPRINOS2"];
                this.columnSIFRAOPISAPLACANJADOPRINOS = this.Columns["SIFRAOPISAPLACANJADOPRINOS"];
                this.columnOPISPLACANJADOPRINOS = this.Columns["OPISPLACANJADOPRINOS"];
                this.columnVBDIDOPRINOS = this.Columns["VBDIDOPRINOS"];
                this.columnZRNDOPRINOS = this.Columns["ZRNDOPRINOS"];
                this.columnSTOPA = this.Columns["STOPA"];
                this.columnDDOBRACUNATIDOPRINOS = this.Columns["DDOBRACUNATIDOPRINOS"];
                this.columnDDOSNOVICADOPRINOS = this.Columns["DDOSNOVICADOPRINOS"];
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow NewDDOBRACUNRadniciDoprinosiRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDOBRACUNRadniciDoprinosiRowChanged != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler dDOBRACUNRadniciDoprinosiRowChangedEvent = this.DDOBRACUNRadniciDoprinosiRowChanged;
                    if (dDOBRACUNRadniciDoprinosiRowChangedEvent != null)
                    {
                        dDOBRACUNRadniciDoprinosiRowChangedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDOBRACUNRadniciDoprinosiRowChanging != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler dDOBRACUNRadniciDoprinosiRowChangingEvent = this.DDOBRACUNRadniciDoprinosiRowChanging;
                    if (dDOBRACUNRadniciDoprinosiRowChangingEvent != null)
                    {
                        dDOBRACUNRadniciDoprinosiRowChangingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDOBRACUNRadniciDoprinosiRowDeleted != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler dDOBRACUNRadniciDoprinosiRowDeletedEvent = this.DDOBRACUNRadniciDoprinosiRowDeleted;
                    if (dDOBRACUNRadniciDoprinosiRowDeletedEvent != null)
                    {
                        dDOBRACUNRadniciDoprinosiRowDeletedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDOBRACUNRadniciDoprinosiRowDeleting != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEventHandler dDOBRACUNRadniciDoprinosiRowDeletingEvent = this.DDOBRACUNRadniciDoprinosiRowDeleting;
                    if (dDOBRACUNRadniciDoprinosiRowDeletingEvent != null)
                    {
                        dDOBRACUNRadniciDoprinosiRowDeletingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDOBRACUNRadniciDoprinosiRow(DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow row)
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

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDOBRACUNATIDOPRINOSColumn
            {
                get
                {
                    return this.columnDDOBRACUNATIDOPRINOS;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDOSNOVICADOPRINOSColumn
            {
                get
                {
                    return this.columnDDOSNOVICADOPRINOS;
                }
            }

            public DataColumn IDDOPRINOSColumn
            {
                get
                {
                    return this.columnIDDOPRINOS;
                }
            }

            public DataColumn IDVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnIDVRSTADOPRINOS;
                }
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow this[int index]
            {
                get
                {
                    return (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow) this.Rows[index];
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

            public DataColumn OPISPLACANJADOPRINOSColumn
            {
                get
                {
                    return this.columnOPISPLACANJADOPRINOS;
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

        public class DDOBRACUNRadniciDoprinosiRow : DataRow
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiDataTable tableDDOBRACUNRadniciDoprinosi;

            internal DDOBRACUNRadniciDoprinosiRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDOBRACUNRadniciDoprinosi = (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiDataTable) this.Table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow GetDDOBRACUNRadniciRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi");
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.DDIDRADNIKColumn);
            }

            public bool IsDDOBRACUNATIDOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.DDOBRACUNATIDOPRINOSColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDOSNOVICADOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.DDOSNOVICADOPRINOSColumn);
            }

            public bool IsIDDOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.IDDOPRINOSColumn);
            }

            public bool IsIDVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.IDVRSTADOPRINOSColumn);
            }

            public bool IsMODOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.MODOPRINOSColumn);
            }

            public bool IsMZDOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.MZDOPRINOSColumn);
            }

            public bool IsNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.NAZIVDOPRINOSColumn);
            }

            public bool IsNAZIVVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.NAZIVVRSTADOPRINOSColumn);
            }

            public bool IsOPISPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.OPISPLACANJADOPRINOSColumn);
            }

            public bool IsPODOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.PODOPRINOSColumn);
            }

            public bool IsPRIMATELJDOPRINOS1Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS1Column);
            }

            public bool IsPRIMATELJDOPRINOS2Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS2Column);
            }

            public bool IsPZDOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.PZDOPRINOSColumn);
            }

            public bool IsSIFRAOPISAPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn);
            }

            public bool IsSTOPANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.STOPAColumn);
            }

            public bool IsVBDIDOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.VBDIDOPRINOSColumn);
            }

            public bool IsZRNDOPRINOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciDoprinosi.ZRNDOPRINOSColumn);
            }

            public void SetDDOBRACUNATIDOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.DDOBRACUNATIDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOSNOVICADOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.DDOSNOVICADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDVRSTADOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.IDVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.MODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZDOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.MZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.NAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTADOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.NAZIVVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJADOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.OPISPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPODOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.PODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS1Null()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS2Null()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZDOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.PZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJADOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPANull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.STOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIDOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.VBDIDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNDOPRINOSNull()
            {
                this[this.tableDDOBRACUNRadniciDoprinosi.ZRNDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciDoprinosi.DDIDRADNIKColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.DDIDRADNIKColumn] = value;
                }
            }

            public decimal DDOBRACUNATIDOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDoprinosi.DDOBRACUNATIDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.DDOBRACUNATIDOPRINOSColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.DDOBRACUNIDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public decimal DDOSNOVICADOPRINOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDoprinosi.DDOSNOVICADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.DDOSNOVICADOPRINOSColumn] = value;
                }
            }

            public int IDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciDoprinosi.IDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.IDDOPRINOSColumn] = value;
                }
            }

            public int IDVRSTADOPRINOS
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDDOBRACUNRadniciDoprinosi.IDVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.IDVRSTADOPRINOSColumn] = value;
                }
            }

            public string MODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.MODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.MODOPRINOSColumn] = value;
                }
            }

            public string MZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.MZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.MZDOPRINOSColumn] = value;
                }
            }

            public string NAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.NAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.NAZIVDOPRINOSColumn] = value;
                }
            }

            public string NAZIVVRSTADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.NAZIVVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.NAZIVVRSTADOPRINOSColumn] = value;
                }
            }

            public string OPISPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.OPISPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.OPISPLACANJADOPRINOSColumn] = value;
                }
            }

            public string PODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.PODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.PODOPRINOSColumn] = value;
                }
            }

            public string PRIMATELJDOPRINOS1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS1Column] = value;
                }
            }

            public string PRIMATELJDOPRINOS2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.PRIMATELJDOPRINOS2Column] = value;
                }
            }

            public string PZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.PZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.PZDOPRINOSColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.SIFRAOPISAPLACANJADOPRINOSColumn] = value;
                }
            }

            public decimal STOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciDoprinosi.STOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.STOPAColumn] = value;
                }
            }

            public string VBDIDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.VBDIDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.VBDIDOPRINOSColumn] = value;
                }
            }

            public string ZRNDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciDoprinosi.ZRNDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciDoprinosi.ZRNDOPRINOSColumn] = value;
                }
            }
        }

        public class DDOBRACUNRadniciDoprinosiRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow eventRow;

            public DDOBRACUNRadniciDoprinosiRowChangeEvent(DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow row, DataRowAction action)
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

            public DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDOBRACUNRadniciDoprinosiRowChangeEventHandler(object sender, DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRowChangeEvent e);

        [Serializable]
        public class DDOBRACUNRadniciIzdaciDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDIZDATAK;
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDNAZIVIZDATKA;
            private DataColumn columnDDOBRACUNATIIZDATAK;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDPOSTOTAKIZDATKA;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler DDOBRACUNRadniciIzdaciRowChanged;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler DDOBRACUNRadniciIzdaciRowChanging;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler DDOBRACUNRadniciIzdaciRowDeleted;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler DDOBRACUNRadniciIzdaciRowDeleting;

            public DDOBRACUNRadniciIzdaciDataTable()
            {
                this.TableName = "DDOBRACUNRadniciIzdaci";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDOBRACUNRadniciIzdaciDataTable(DataTable table) : base(table.TableName)
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

            protected DDOBRACUNRadniciIzdaciDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDOBRACUNRadniciIzdaciRow(DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow row)
            {
                this.Rows.Add(row);
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow AddDDOBRACUNRadniciIzdaciRow(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int dDIDIZDATAK, decimal dDOBRACUNATIIZDATAK)
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow row = (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) this.NewRow();
                row["DDOBRACUNIDOBRACUN"] = dDOBRACUNIDOBRACUN;
                row["DDIDRADNIK"] = dDIDRADNIK;
                row["DDIDIZDATAK"] = dDIDIZDATAK;
                row["DDOBRACUNATIIZDATAK"] = dDOBRACUNATIIZDATAK;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciDataTable table = (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow FindByDDOBRACUNIDOBRACUNDDIDRADNIKDDIDIZDATAK(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int dDIDIZDATAK)
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) this.Rows.Find(new object[] { dDOBRACUNIDOBRACUN, dDIDRADNIK, dDIDIZDATAK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.AllowDBNull = false;
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.AllowDBNull = false;
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
                this.columnDDIDIZDATAK = new DataColumn("DDIDIZDATAK", typeof(int), "", MappingType.Element);
                this.columnDDIDIZDATAK.AllowDBNull = false;
                this.columnDDIDIZDATAK.Caption = "DDIDIZDATAK";
                this.columnDDIDIZDATAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Description", "DDIDIZDATAK");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDIZDATAK");
                this.Columns.Add(this.columnDDIDIZDATAK);
                this.columnDDNAZIVIZDATKA = new DataColumn("DDNAZIVIZDATKA", typeof(string), "", MappingType.Element);
                this.columnDDNAZIVIZDATKA.AllowDBNull = false;
                this.columnDDNAZIVIZDATKA.Caption = "DDNAZIVIZDATKA";
                this.columnDDNAZIVIZDATKA.MaxLength = 50;
                this.columnDDNAZIVIZDATKA.DefaultValue = "";
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Description", "DDNAZIVIZDATKA");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Length", "50");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.InternalName", "DDNAZIVIZDATKA");
                this.Columns.Add(this.columnDDNAZIVIZDATKA);
                this.columnDDPOSTOTAKIZDATKA = new DataColumn("DDPOSTOTAKIZDATKA", typeof(decimal), "", MappingType.Element);
                this.columnDDPOSTOTAKIZDATKA.AllowDBNull = false;
                this.columnDDPOSTOTAKIZDATKA.Caption = "DDPOSTOTAKIZDATKA";
                this.columnDDPOSTOTAKIZDATKA.DefaultValue = 0;
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Description", "DDPOSTOTAKIZDATKA");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Length", "5");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Decimals", "2");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.InternalName", "DDPOSTOTAKIZDATKA");
                this.Columns.Add(this.columnDDPOSTOTAKIZDATKA);
                this.columnDDOBRACUNATIIZDATAK = new DataColumn("DDOBRACUNATIIZDATAK", typeof(decimal), "", MappingType.Element);
                this.columnDDOBRACUNATIIZDATAK.AllowDBNull = false;
                this.columnDDOBRACUNATIIZDATAK.Caption = "DDOBRACUNATIIZDATAK";
                this.columnDDOBRACUNATIIZDATAK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Description", "DDOBRACUNATIIZDATAK");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Length", "12");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNATIIZDATAK.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNATIIZDATAK");
                this.Columns.Add(this.columnDDOBRACUNATIIZDATAK);
                this.PrimaryKey = new DataColumn[] { this.columnDDOBRACUNIDOBRACUN, this.columnDDIDRADNIK, this.columnDDIDIZDATAK };
                this.ExtendedProperties.Add("ParentLvl", "DDOBRACUNRadnici");
                this.ExtendedProperties.Add("LevelName", "Izdaci");
                this.ExtendedProperties.Add("Description", "Izdaci");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnDDIDIZDATAK = this.Columns["DDIDIZDATAK"];
                this.columnDDNAZIVIZDATKA = this.Columns["DDNAZIVIZDATKA"];
                this.columnDDPOSTOTAKIZDATKA = this.Columns["DDPOSTOTAKIZDATKA"];
                this.columnDDOBRACUNATIIZDATAK = this.Columns["DDOBRACUNATIIZDATAK"];
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow NewDDOBRACUNRadniciIzdaciRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDOBRACUNRadniciIzdaciRowChanged != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler dDOBRACUNRadniciIzdaciRowChangedEvent = this.DDOBRACUNRadniciIzdaciRowChanged;
                    if (dDOBRACUNRadniciIzdaciRowChangedEvent != null)
                    {
                        dDOBRACUNRadniciIzdaciRowChangedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDOBRACUNRadniciIzdaciRowChanging != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler dDOBRACUNRadniciIzdaciRowChangingEvent = this.DDOBRACUNRadniciIzdaciRowChanging;
                    if (dDOBRACUNRadniciIzdaciRowChangingEvent != null)
                    {
                        dDOBRACUNRadniciIzdaciRowChangingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDOBRACUNRadniciIzdaciRowDeleted != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler dDOBRACUNRadniciIzdaciRowDeletedEvent = this.DDOBRACUNRadniciIzdaciRowDeleted;
                    if (dDOBRACUNRadniciIzdaciRowDeletedEvent != null)
                    {
                        dDOBRACUNRadniciIzdaciRowDeletedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDOBRACUNRadniciIzdaciRowDeleting != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEventHandler dDOBRACUNRadniciIzdaciRowDeletingEvent = this.DDOBRACUNRadniciIzdaciRowDeleting;
                    if (dDOBRACUNRadniciIzdaciRowDeletingEvent != null)
                    {
                        dDOBRACUNRadniciIzdaciRowDeletingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDOBRACUNRadniciIzdaciRow(DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow row)
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

            public DataColumn DDIDIZDATAKColumn
            {
                get
                {
                    return this.columnDDIDIZDATAK;
                }
            }

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDNAZIVIZDATKAColumn
            {
                get
                {
                    return this.columnDDNAZIVIZDATKA;
                }
            }

            public DataColumn DDOBRACUNATIIZDATAKColumn
            {
                get
                {
                    return this.columnDDOBRACUNATIIZDATAK;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDPOSTOTAKIZDATKAColumn
            {
                get
                {
                    return this.columnDDPOSTOTAKIZDATKA;
                }
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow this[int index]
            {
                get
                {
                    return (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow) this.Rows[index];
                }
            }
        }

        public class DDOBRACUNRadniciIzdaciRow : DataRow
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciDataTable tableDDOBRACUNRadniciIzdaci;

            internal DDOBRACUNRadniciIzdaciRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDOBRACUNRadniciIzdaci = (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciDataTable) this.Table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow GetDDOBRACUNRadniciRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci");
            }

            public bool IsDDIDIZDATAKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciIzdaci.DDIDIZDATAKColumn);
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciIzdaci.DDIDRADNIKColumn);
            }

            public bool IsDDNAZIVIZDATKANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciIzdaci.DDNAZIVIZDATKAColumn);
            }

            public bool IsDDOBRACUNATIIZDATAKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciIzdaci.DDOBRACUNATIIZDATAKColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciIzdaci.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDPOSTOTAKIZDATKANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciIzdaci.DDPOSTOTAKIZDATKAColumn);
            }

            public void SetDDNAZIVIZDATKANull()
            {
                this[this.tableDDOBRACUNRadniciIzdaci.DDNAZIVIZDATKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOBRACUNATIIZDATAKNull()
            {
                this[this.tableDDOBRACUNRadniciIzdaci.DDOBRACUNATIIZDATAKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOSTOTAKIZDATKANull()
            {
                this[this.tableDDOBRACUNRadniciIzdaci.DDPOSTOTAKIZDATKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDIZDATAK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciIzdaci.DDIDIZDATAKColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciIzdaci.DDIDIZDATAKColumn] = value;
                }
            }

            public int DDIDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciIzdaci.DDIDRADNIKColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciIzdaci.DDIDRADNIKColumn] = value;
                }
            }

            public string DDNAZIVIZDATKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciIzdaci.DDNAZIVIZDATKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciIzdaci.DDNAZIVIZDATKAColumn] = value;
                }
            }

            public decimal DDOBRACUNATIIZDATAK
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciIzdaci.DDOBRACUNATIIZDATAKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciIzdaci.DDOBRACUNATIIZDATAKColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableDDOBRACUNRadniciIzdaci.DDOBRACUNIDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciIzdaci.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public decimal DDPOSTOTAKIZDATKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciIzdaci.DDPOSTOTAKIZDATKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciIzdaci.DDPOSTOTAKIZDATKAColumn] = value;
                }
            }
        }

        public class DDOBRACUNRadniciIzdaciRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow eventRow;

            public DDOBRACUNRadniciIzdaciRowChangeEvent(DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow row, DataRowAction action)
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

            public DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDOBRACUNRadniciIzdaciRowChangeEventHandler(object sender, DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRowChangeEvent e);

        [Serializable]
        public class DDOBRACUNRadniciPoreziDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDMOPOREZ;
            private DataColumn columnDDOBRACUNATIPOREZ;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDOSNOVICAPOREZ;
            private DataColumn columnDDPOPOREZ;
            private DataColumn columnIDPOREZ;
            private DataColumn columnMZPOREZ;
            private DataColumn columnNAZIVPOREZ;
            private DataColumn columnOPISPLACANJAPOREZ;
            private DataColumn columnPOREZMJESECNO;
            private DataColumn columnPRIMATELJPOREZ1;
            private DataColumn columnPRIMATELJPOREZ2;
            private DataColumn columnPZPOREZ;
            private DataColumn columnSIFRAOPISAPLACANJAPOREZ;
            private DataColumn columnSTOPAPOREZA;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler DDOBRACUNRadniciPoreziRowChanged;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler DDOBRACUNRadniciPoreziRowChanging;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler DDOBRACUNRadniciPoreziRowDeleted;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler DDOBRACUNRadniciPoreziRowDeleting;

            public DDOBRACUNRadniciPoreziDataTable()
            {
                this.TableName = "DDOBRACUNRadniciPorezi";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDOBRACUNRadniciPoreziDataTable(DataTable table) : base(table.TableName)
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

            protected DDOBRACUNRadniciPoreziDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDOBRACUNRadniciPoreziRow(DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow row)
            {
                this.Rows.Add(row);
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow AddDDOBRACUNRadniciPoreziRow(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int iDPOREZ, decimal dDOBRACUNATIPOREZ, decimal dDOSNOVICAPOREZ)
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow row = (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) this.NewRow();
                row["DDOBRACUNIDOBRACUN"] = dDOBRACUNIDOBRACUN;
                row["DDIDRADNIK"] = dDIDRADNIK;
                row["IDPOREZ"] = iDPOREZ;
                row["DDOBRACUNATIPOREZ"] = dDOBRACUNATIPOREZ;
                row["DDOSNOVICAPOREZ"] = dDOSNOVICAPOREZ;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciPoreziDataTable table = (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow FindByDDOBRACUNIDOBRACUNDDIDRADNIKIDPOREZ(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int iDPOREZ)
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) this.Rows.Find(new object[] { dDOBRACUNIDOBRACUN, dDIDRADNIK, iDPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.AllowDBNull = false;
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.AllowDBNull = false;
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
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
                this.columnPOREZMJESECNO = new DataColumn("POREZMJESECNO", typeof(decimal), "", MappingType.Element);
                this.columnPOREZMJESECNO.AllowDBNull = true;
                this.columnPOREZMJESECNO.Caption = "Maks. mjesečni iznos osnovice";
                this.columnPOREZMJESECNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPOREZMJESECNO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZMJESECNO.ExtendedProperties.Add("Deklarit.InternalName", "POREZMJESECNO");
                this.Columns.Add(this.columnPOREZMJESECNO);
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
                this.columnDDPOPOREZ = new DataColumn("DDPOPOREZ", typeof(string), "", MappingType.Element);
                this.columnDDPOPOREZ.AllowDBNull = false;
                this.columnDDPOPOREZ.Caption = "DDPOPOREZ";
                this.columnDDPOPOREZ.MaxLength = 0x16;
                this.columnDDPOPOREZ.DefaultValue = "";
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Description", "DDPOPOREZ");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "DDPOPOREZ");
                this.Columns.Add(this.columnDDPOPOREZ);
                this.columnDDMOPOREZ = new DataColumn("DDMOPOREZ", typeof(string), "", MappingType.Element);
                this.columnDDMOPOREZ.AllowDBNull = false;
                this.columnDDMOPOREZ.Caption = "DDMOPOREZ";
                this.columnDDMOPOREZ.MaxLength = 2;
                this.columnDDMOPOREZ.DefaultValue = "";
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDMOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDMOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Description", "DDMOPOREZ");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnDDMOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "DDMOPOREZ");
                this.Columns.Add(this.columnDDMOPOREZ);
                this.columnMZPOREZ = new DataColumn("MZPOREZ", typeof(string), "", MappingType.Element);
                this.columnMZPOREZ.AllowDBNull = true;
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
                this.columnMZPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMZPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "MZPOREZ");
                this.Columns.Add(this.columnMZPOREZ);
                this.columnPZPOREZ = new DataColumn("PZPOREZ", typeof(string), "", MappingType.Element);
                this.columnPZPOREZ.AllowDBNull = true;
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
                this.columnPZPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
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
                this.columnDDOBRACUNATIPOREZ = new DataColumn("DDOBRACUNATIPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnDDOBRACUNATIPOREZ.AllowDBNull = false;
                this.columnDDOBRACUNATIPOREZ.Caption = "DDOBRACUNATIPOREZ";
                this.columnDDOBRACUNATIPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Description", "DDOBRACUNATIPOREZ");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNATIPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNATIPOREZ");
                this.Columns.Add(this.columnDDOBRACUNATIPOREZ);
                this.columnDDOSNOVICAPOREZ = new DataColumn("DDOSNOVICAPOREZ", typeof(decimal), "", MappingType.Element);
                this.columnDDOSNOVICAPOREZ.AllowDBNull = false;
                this.columnDDOSNOVICAPOREZ.Caption = "DDOSNOVICAPOREZ";
                this.columnDDOSNOVICAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Description", "DDOSNOVICAPOREZ");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Length", "12");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOSNOVICAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "DDOSNOVICAPOREZ");
                this.Columns.Add(this.columnDDOSNOVICAPOREZ);
                this.PrimaryKey = new DataColumn[] { this.columnDDOBRACUNIDOBRACUN, this.columnDDIDRADNIK, this.columnIDPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "DDOBRACUNRadnici");
                this.ExtendedProperties.Add("LevelName", "Porezi");
                this.ExtendedProperties.Add("Description", "Porezi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnIDPOREZ = this.Columns["IDPOREZ"];
                this.columnNAZIVPOREZ = this.Columns["NAZIVPOREZ"];
                this.columnPOREZMJESECNO = this.Columns["POREZMJESECNO"];
                this.columnSTOPAPOREZA = this.Columns["STOPAPOREZA"];
                this.columnDDPOPOREZ = this.Columns["DDPOPOREZ"];
                this.columnDDMOPOREZ = this.Columns["DDMOPOREZ"];
                this.columnMZPOREZ = this.Columns["MZPOREZ"];
                this.columnPZPOREZ = this.Columns["PZPOREZ"];
                this.columnPRIMATELJPOREZ1 = this.Columns["PRIMATELJPOREZ1"];
                this.columnPRIMATELJPOREZ2 = this.Columns["PRIMATELJPOREZ2"];
                this.columnSIFRAOPISAPLACANJAPOREZ = this.Columns["SIFRAOPISAPLACANJAPOREZ"];
                this.columnOPISPLACANJAPOREZ = this.Columns["OPISPLACANJAPOREZ"];
                this.columnDDOBRACUNATIPOREZ = this.Columns["DDOBRACUNATIPOREZ"];
                this.columnDDOSNOVICAPOREZ = this.Columns["DDOSNOVICAPOREZ"];
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow NewDDOBRACUNRadniciPoreziRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDOBRACUNRadniciPoreziRowChanged != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler dDOBRACUNRadniciPoreziRowChangedEvent = this.DDOBRACUNRadniciPoreziRowChanged;
                    if (dDOBRACUNRadniciPoreziRowChangedEvent != null)
                    {
                        dDOBRACUNRadniciPoreziRowChangedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDOBRACUNRadniciPoreziRowChanging != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler dDOBRACUNRadniciPoreziRowChangingEvent = this.DDOBRACUNRadniciPoreziRowChanging;
                    if (dDOBRACUNRadniciPoreziRowChangingEvent != null)
                    {
                        dDOBRACUNRadniciPoreziRowChangingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDOBRACUNRadniciPoreziRowDeleted != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler dDOBRACUNRadniciPoreziRowDeletedEvent = this.DDOBRACUNRadniciPoreziRowDeleted;
                    if (dDOBRACUNRadniciPoreziRowDeletedEvent != null)
                    {
                        dDOBRACUNRadniciPoreziRowDeletedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDOBRACUNRadniciPoreziRowDeleting != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEventHandler dDOBRACUNRadniciPoreziRowDeletingEvent = this.DDOBRACUNRadniciPoreziRowDeleting;
                    if (dDOBRACUNRadniciPoreziRowDeletingEvent != null)
                    {
                        dDOBRACUNRadniciPoreziRowDeletingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDOBRACUNRadniciPoreziRow(DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow row)
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

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDMOPOREZColumn
            {
                get
                {
                    return this.columnDDMOPOREZ;
                }
            }

            public DataColumn DDOBRACUNATIPOREZColumn
            {
                get
                {
                    return this.columnDDOBRACUNATIPOREZ;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDOSNOVICAPOREZColumn
            {
                get
                {
                    return this.columnDDOSNOVICAPOREZ;
                }
            }

            public DataColumn DDPOPOREZColumn
            {
                get
                {
                    return this.columnDDPOPOREZ;
                }
            }

            public DataColumn IDPOREZColumn
            {
                get
                {
                    return this.columnIDPOREZ;
                }
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow this[int index]
            {
                get
                {
                    return (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow) this.Rows[index];
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

            public DataColumn OPISPLACANJAPOREZColumn
            {
                get
                {
                    return this.columnOPISPLACANJAPOREZ;
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

        public class DDOBRACUNRadniciPoreziRow : DataRow
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciPoreziDataTable tableDDOBRACUNRadniciPorezi;

            internal DDOBRACUNRadniciPoreziRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDOBRACUNRadniciPorezi = (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziDataTable) this.Table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow GetDDOBRACUNRadniciRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi");
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.DDIDRADNIKColumn);
            }

            public bool IsDDMOPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.DDMOPOREZColumn);
            }

            public bool IsDDOBRACUNATIPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.DDOBRACUNATIPOREZColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDOSNOVICAPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.DDOSNOVICAPOREZColumn);
            }

            public bool IsDDPOPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.DDPOPOREZColumn);
            }

            public bool IsIDPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.IDPOREZColumn);
            }

            public bool IsMZPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.MZPOREZColumn);
            }

            public bool IsNAZIVPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.NAZIVPOREZColumn);
            }

            public bool IsOPISPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.OPISPLACANJAPOREZColumn);
            }

            public bool IsPOREZMJESECNONull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.POREZMJESECNOColumn);
            }

            public bool IsPRIMATELJPOREZ1Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ1Column);
            }

            public bool IsPRIMATELJPOREZ2Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ2Column);
            }

            public bool IsPZPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.PZPOREZColumn);
            }

            public bool IsSIFRAOPISAPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.SIFRAOPISAPLACANJAPOREZColumn);
            }

            public bool IsSTOPAPOREZANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciPorezi.STOPAPOREZAColumn);
            }

            public void SetDDMOPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.DDMOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOBRACUNATIPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.DDOBRACUNATIPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOSNOVICAPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.DDOSNOVICAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.DDPOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.MZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.NAZIVPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.OPISPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZMJESECNONull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.POREZMJESECNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ1Null()
            {
                this[this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ2Null()
            {
                this[this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.PZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAPOREZNull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.SIFRAOPISAPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAPOREZANull()
            {
                this[this.tableDDOBRACUNRadniciPorezi.STOPAPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciPorezi.DDIDRADNIKColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.DDIDRADNIKColumn] = value;
                }
            }

            public string DDMOPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.DDMOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.DDMOPOREZColumn] = value;
                }
            }

            public decimal DDOBRACUNATIPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciPorezi.DDOBRACUNATIPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.DDOBRACUNATIPOREZColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.DDOBRACUNIDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public decimal DDOSNOVICAPOREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciPorezi.DDOSNOVICAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.DDOSNOVICAPOREZColumn] = value;
                }
            }

            public string DDPOPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.DDPOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.DDPOPOREZColumn] = value;
                }
            }

            public int IDPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciPorezi.IDPOREZColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.IDPOREZColumn] = value;
                }
            }

            public string MZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.MZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.MZPOREZColumn] = value;
                }
            }

            public string NAZIVPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.NAZIVPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.NAZIVPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.OPISPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.OPISPLACANJAPOREZColumn] = value;
                }
            }

            public decimal POREZMJESECNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciPorezi.POREZMJESECNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.POREZMJESECNOColumn] = value;
                }
            }

            public string PRIMATELJPOREZ1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ1Column] = value;
                }
            }

            public string PRIMATELJPOREZ2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.PRIMATELJPOREZ2Column] = value;
                }
            }

            public string PZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.PZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.PZPOREZColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciPorezi.SIFRAOPISAPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.SIFRAOPISAPLACANJAPOREZColumn] = value;
                }
            }

            public decimal STOPAPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciPorezi.STOPAPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciPorezi.STOPAPOREZAColumn] = value;
                }
            }
        }

        public class DDOBRACUNRadniciPoreziRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow eventRow;

            public DDOBRACUNRadniciPoreziRowChangeEvent(DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow row, DataRowAction action)
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

            public DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDOBRACUNRadniciPoreziRowChangeEventHandler(object sender, DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRowChangeEvent e);

        public class DDOBRACUNRadniciRow : DataRow
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciDataTable tableDDOBRACUNRadnici;

            internal DDOBRACUNRadniciRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDOBRACUNRadnici = (DDOBRACUNDataSet.DDOBRACUNRadniciDataTable) this.Table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow[] GetDDOBRACUNRadniciDDKrizniPorezRows()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciDDKrizniPorezRow[]) this.GetChildRows("DDOBRACUNRadnici_DDOBRACUNRadniciDDKrizniPorez");
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow[] GetDDOBRACUNRadniciDoprinosiRows()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciDoprinosiRow[]) this.GetChildRows("DDOBRACUNRadnici_DDOBRACUNRadniciDoprinosi");
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow[] GetDDOBRACUNRadniciIzdaciRows()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciIzdaciRow[]) this.GetChildRows("DDOBRACUNRadnici_DDOBRACUNRadniciIzdaci");
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow[] GetDDOBRACUNRadniciPoreziRows()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciPoreziRow[]) this.GetChildRows("DDOBRACUNRadnici_DDOBRACUNRadniciPorezi");
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow[] GetDDOBRACUNRadniciVrstePoslaRows()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow[]) this.GetChildRows("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla");
            }

            public DDOBRACUNDataSet.DDOBRACUNRow GetDDOBRACUNRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRow) this.GetParentRow("DDOBRACUN_DDOBRACUNRadnici");
            }

            public bool IsDDDRUGISTUPNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDDRUGISTUPColumn);
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDIDRADNIKColumn);
            }

            public bool IsDDIMENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDIMEColumn);
            }

            public bool IsDDOBRACUNATIPDVNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDOBRACUNATIPDVColumn);
            }

            public bool IsDDOBRACUNATIPRIREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDOBRACUNATIPRIREZColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDOIBNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDOIBColumn);
            }

            public bool IsDDPDVOBVEZNIKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDPDVOBVEZNIKColumn);
            }

            public bool IsDDPREZIMENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDPREZIMEColumn);
            }

            public bool IsDDSIFRAOPCINESTANOVANJANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDSIFRAOPCINESTANOVANJAColumn);
            }

            public bool IsDDZRNNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.DDZRNColumn);
            }

            public bool IsIDBANKENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.IDBANKEColumn);
            }

            public bool IsIDKATEGORIJANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.IDKATEGORIJAColumn);
            }

            public bool IsIDKOLONAIDDNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.IDKOLONAIDDColumn);
            }

            public bool IsNAZIVBANKE1Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.NAZIVBANKE1Column);
            }

            public bool IsNAZIVBANKE2Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.NAZIVBANKE2Column);
            }

            public bool IsNAZIVBANKE3Null()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.NAZIVBANKE3Column);
            }

            public bool IsNAZIVKATEGORIJANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.NAZIVKATEGORIJAColumn);
            }

            public bool IsOPCINARADAIDOPCINENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.OPCINARADAIDOPCINEColumn);
            }

            public bool IsOPCINARADANAZIVOPCINENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.OPCINARADANAZIVOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJAIDOPCINENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.OPCINASTANOVANJAIDOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJANAZIVOPCINENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.OPCINASTANOVANJANAZIVOPCINEColumn);
            }

            public bool IsOPCINASTANOVANJAPRIREZNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.OPCINASTANOVANJAPRIREZColumn);
            }

            public bool IsOPCINASTANOVANJAVBDIOPCINANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.OPCINASTANOVANJAVBDIOPCINAColumn);
            }

            public bool IsOPCINASTANOVANJAZRNOPCINANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.OPCINASTANOVANJAZRNOPCINAColumn);
            }

            public bool IsVBDIBANKENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.VBDIBANKEColumn);
            }

            public bool IsZRNBANKENull()
            {
                return this.IsNull(this.tableDDOBRACUNRadnici.ZRNBANKEColumn);
            }

            public void SetDDDRUGISTUPNull()
            {
                this[this.tableDDOBRACUNRadnici.DDDRUGISTUPColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDIMENull()
            {
                this[this.tableDDOBRACUNRadnici.DDIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOBRACUNATIPDVNull()
            {
                this[this.tableDDOBRACUNRadnici.DDOBRACUNATIPDVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOBRACUNATIPRIREZNull()
            {
                this[this.tableDDOBRACUNRadnici.DDOBRACUNATIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOIBNull()
            {
                this[this.tableDDOBRACUNRadnici.DDOIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPDVOBVEZNIKNull()
            {
                this[this.tableDDOBRACUNRadnici.DDPDVOBVEZNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPREZIMENull()
            {
                this[this.tableDDOBRACUNRadnici.DDPREZIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDSIFRAOPCINESTANOVANJANull()
            {
                this[this.tableDDOBRACUNRadnici.DDSIFRAOPCINESTANOVANJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDZRNNull()
            {
                this[this.tableDDOBRACUNRadnici.DDZRNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDBANKENull()
            {
                this[this.tableDDOBRACUNRadnici.IDBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDKATEGORIJANull()
            {
                this[this.tableDDOBRACUNRadnici.IDKATEGORIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDKOLONAIDDNull()
            {
                this[this.tableDDOBRACUNRadnici.IDKOLONAIDDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE1Null()
            {
                this[this.tableDDOBRACUNRadnici.NAZIVBANKE1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE2Null()
            {
                this[this.tableDDOBRACUNRadnici.NAZIVBANKE2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBANKE3Null()
            {
                this[this.tableDDOBRACUNRadnici.NAZIVBANKE3Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKATEGORIJANull()
            {
                this[this.tableDDOBRACUNRadnici.NAZIVKATEGORIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADAIDOPCINENull()
            {
                this[this.tableDDOBRACUNRadnici.OPCINARADAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINARADANAZIVOPCINENull()
            {
                this[this.tableDDOBRACUNRadnici.OPCINARADANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAIDOPCINENull()
            {
                this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAIDOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJANAZIVOPCINENull()
            {
                this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJANAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAPRIREZNull()
            {
                this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAVBDIOPCINANull()
            {
                this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAVBDIOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPCINASTANOVANJAZRNOPCINANull()
            {
                this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAZRNOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIBANKENull()
            {
                this[this.tableDDOBRACUNRadnici.VBDIBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNBANKENull()
            {
                this[this.tableDDOBRACUNRadnici.ZRNBANKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool DDDRUGISTUP
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDOBRACUNRadnici.DDDRUGISTUPColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDDRUGISTUPColumn] = value;
                }
            }

            public int DDIDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadnici.DDIDRADNIKColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDIDRADNIKColumn] = value;
                }
            }

            public string DDIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.DDIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDIMEColumn] = value;
                }
            }

            public decimal DDOBRACUNATIPDV
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadnici.DDOBRACUNATIPDVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDOBRACUNATIPDVColumn] = value;
                }
            }

            public decimal DDOBRACUNATIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadnici.DDOBRACUNATIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDOBRACUNATIPRIREZColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableDDOBRACUNRadnici.DDOBRACUNIDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public string DDOIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.DDOIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDOIBColumn] = value;
                }
            }

            public bool DDPDVOBVEZNIK
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDOBRACUNRadnici.DDPDVOBVEZNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDPDVOBVEZNIKColumn] = value;
                }
            }

            public string DDPREZIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.DDPREZIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDPREZIMEColumn] = value;
                }
            }

            public string DDSIFRAOPCINESTANOVANJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.DDSIFRAOPCINESTANOVANJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDSIFRAOPCINESTANOVANJAColumn] = value;
                }
            }

            public string DDZRN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.DDZRNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.DDZRNColumn] = value;
                }
            }

            public int IDBANKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDDOBRACUNRadnici.IDBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                     
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.IDBANKEColumn] = value;
                }
            }

            public int IDKATEGORIJA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDDOBRACUNRadnici.IDKATEGORIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.IDKATEGORIJAColumn] = value;
                }
            }

            public int IDKOLONAIDD
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDDOBRACUNRadnici.IDKOLONAIDDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.IDKOLONAIDDColumn] = value;
                }
            }

            public string NAZIVBANKE1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.NAZIVBANKE1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                       
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.NAZIVBANKE1Column] = value;
                }
            }

            public string NAZIVBANKE2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.NAZIVBANKE2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.NAZIVBANKE2Column] = value;
                }
            }

            public string NAZIVBANKE3
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.NAZIVBANKE3Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.NAZIVBANKE3Column] = value;
                }
            }

            public string NAZIVKATEGORIJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.NAZIVKATEGORIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.NAZIVKATEGORIJAColumn] = value;
                }
            }

            public string OPCINARADAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.OPCINARADAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.OPCINARADAIDOPCINEColumn] = value;
                }
            }

            public string OPCINARADANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.OPCINARADANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.OPCINARADANAZIVOPCINEColumn] = value;
                }
            }

            public string OPCINASTANOVANJAIDOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAIDOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAIDOPCINEColumn] = value;
                }
            }

            public string OPCINASTANOVANJANAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJANAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJANAZIVOPCINEColumn] = value;
                }
            }

            public decimal OPCINASTANOVANJAPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAPRIREZColumn] = value;
                }
            }

            public string OPCINASTANOVANJAVBDIOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAVBDIOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAVBDIOPCINAColumn] = value;
                }
            }

            public string OPCINASTANOVANJAZRNOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAZRNOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.OPCINASTANOVANJAZRNOPCINAColumn] = value;
                }
            }

            public string VBDIBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.VBDIBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.VBDIBANKEColumn] = value;
                }
            }

            public string ZRNBANKE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadnici.ZRNBANKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadnici.ZRNBANKEColumn] = value;
                }
            }
        }

        public class DDOBRACUNRadniciRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDOBRACUNDataSet.DDOBRACUNRadniciRow eventRow;

            public DDOBRACUNRadniciRowChangeEvent(DDOBRACUNDataSet.DDOBRACUNRadniciRow row, DataRowAction action)
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

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDOBRACUNRadniciRowChangeEventHandler(object sender, DDOBRACUNDataSet.DDOBRACUNRadniciRowChangeEvent e);

        [Serializable]
        public class DDOBRACUNRadniciVrstePoslaDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDRADNIK;
            private DataColumn columnDDIDVRSTAPOSLA;
            private DataColumn columnDDIZNOS;
            private DataColumn columnDDNAZIVVRSTAPOSLA;
            private DataColumn columnDDOBRACUNIDOBRACUN;
            private DataColumn columnDDSATI;
            private DataColumn columnDDSATNICA;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler DDOBRACUNRadniciVrstePoslaRowChanged;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler DDOBRACUNRadniciVrstePoslaRowChanging;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler DDOBRACUNRadniciVrstePoslaRowDeleted;

            public event DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler DDOBRACUNRadniciVrstePoslaRowDeleting;

            public DDOBRACUNRadniciVrstePoslaDataTable()
            {
                this.TableName = "DDOBRACUNRadniciVrstePosla";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDOBRACUNRadniciVrstePoslaDataTable(DataTable table) : base(table.TableName)
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

            protected DDOBRACUNRadniciVrstePoslaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDOBRACUNRadniciVrstePoslaRow(DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow row)
            {
                this.Rows.Add(row);
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow AddDDOBRACUNRadniciVrstePoslaRow(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int dDIDVRSTAPOSLA, decimal dDSATI, decimal dDSATNICA, decimal dDIZNOS)
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow row = (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) this.NewRow();
                row["DDOBRACUNIDOBRACUN"] = dDOBRACUNIDOBRACUN;
                row["DDIDRADNIK"] = dDIDRADNIK;
                row["DDIDVRSTAPOSLA"] = dDIDVRSTAPOSLA;
                row["DDSATI"] = dDSATI;
                row["DDSATNICA"] = dDSATNICA;
                row["DDIZNOS"] = dDIZNOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaDataTable table = (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow FindByDDOBRACUNIDOBRACUNDDIDRADNIKDDIDVRSTAPOSLA(string dDOBRACUNIDOBRACUN, int dDIDRADNIK, int dDIDVRSTAPOSLA)
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) this.Rows.Find(new object[] { dDOBRACUNIDOBRACUN, dDIDRADNIK, dDIDVRSTAPOSLA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDOBRACUNDataSet set = new DDOBRACUNDataSet();
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
                this.columnDDOBRACUNIDOBRACUN = new DataColumn("DDOBRACUNIDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnDDOBRACUNIDOBRACUN.AllowDBNull = false;
                this.columnDDOBRACUNIDOBRACUN.Caption = "Šifra obračuna";
                this.columnDDOBRACUNIDOBRACUN.MaxLength = 11;
                this.columnDDOBRACUNIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsKey", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Description", "Šifra obračuna");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDOBRACUNIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "DDOBRACUNIDOBRACUN");
                this.Columns.Add(this.columnDDOBRACUNIDOBRACUN);
                this.columnDDIDRADNIK = new DataColumn("DDIDRADNIK", typeof(int), "", MappingType.Element);
                this.columnDDIDRADNIK.AllowDBNull = false;
                this.columnDDIDRADNIK.Caption = "Šifra";
                this.columnDDIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDRADNIK.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDRADNIK");
                this.Columns.Add(this.columnDDIDRADNIK);
                this.columnDDIDVRSTAPOSLA = new DataColumn("DDIDVRSTAPOSLA", typeof(int), "", MappingType.Element);
                this.columnDDIDVRSTAPOSLA.AllowDBNull = false;
                this.columnDDIDVRSTAPOSLA.Caption = "Šifra";
                this.columnDDIDVRSTAPOSLA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("IsKey", "true");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Length", "5");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDVRSTAPOSLA.ExtendedProperties.Add("Deklarit.InternalName", "DDIDVRSTAPOSLA");
                this.Columns.Add(this.columnDDIDVRSTAPOSLA);
                this.columnDDNAZIVVRSTAPOSLA = new DataColumn("DDNAZIVVRSTAPOSLA", typeof(string), "", MappingType.Element);
                this.columnDDNAZIVVRSTAPOSLA.AllowDBNull = false;
                this.columnDDNAZIVVRSTAPOSLA.Caption = "DDNAZIVVRSTAPOSLA";
                this.columnDDNAZIVVRSTAPOSLA.MaxLength = 50;
                this.columnDDNAZIVVRSTAPOSLA.DefaultValue = "";
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Description", "DDNAZIVVRSTAPOSLA");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Length", "50");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDNAZIVVRSTAPOSLA.ExtendedProperties.Add("Deklarit.InternalName", "DDNAZIVVRSTAPOSLA");
                this.Columns.Add(this.columnDDNAZIVVRSTAPOSLA);
                this.columnDDSATI = new DataColumn("DDSATI", typeof(decimal), "", MappingType.Element);
                this.columnDDSATI.AllowDBNull = false;
                this.columnDDSATI.Caption = "DDSATI";
                this.columnDDSATI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDSATI.ExtendedProperties.Add("IsKey", "false");
                this.columnDDSATI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDSATI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDSATI.ExtendedProperties.Add("Description", "DDSATI");
                this.columnDDSATI.ExtendedProperties.Add("Length", "5");
                this.columnDDSATI.ExtendedProperties.Add("Decimals", "2");
                this.columnDDSATI.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDSATI.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnDDSATI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDSATI.ExtendedProperties.Add("Deklarit.InternalName", "DDSATI");
                this.Columns.Add(this.columnDDSATI);
                this.columnDDSATNICA = new DataColumn("DDSATNICA", typeof(decimal), "", MappingType.Element);
                this.columnDDSATNICA.AllowDBNull = false;
                this.columnDDSATNICA.Caption = "DDSATNICA";
                this.columnDDSATNICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDSATNICA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDSATNICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDSATNICA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDSATNICA.ExtendedProperties.Add("Description", "DDSATNICA");
                this.columnDDSATNICA.ExtendedProperties.Add("Length", "12");
                this.columnDDSATNICA.ExtendedProperties.Add("Decimals", "8");
                this.columnDDSATNICA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDSATNICA.ExtendedProperties.Add("DomainType", "PUNODECIMALA");
                this.columnDDSATNICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDSATNICA.ExtendedProperties.Add("Deklarit.InternalName", "DDSATNICA");
                this.Columns.Add(this.columnDDSATNICA);
                this.columnDDIZNOS = new DataColumn("DDIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnDDIZNOS.AllowDBNull = false;
                this.columnDDIZNOS.Caption = "DDIZNOS";
                this.columnDDIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnDDIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDIZNOS.ExtendedProperties.Add("Description", "DDIZNOS");
                this.columnDDIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnDDIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnDDIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnDDIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "DDIZNOS");
                this.Columns.Add(this.columnDDIZNOS);
                this.PrimaryKey = new DataColumn[] { this.columnDDOBRACUNIDOBRACUN, this.columnDDIDRADNIK, this.columnDDIDVRSTAPOSLA };
                this.ExtendedProperties.Add("ParentLvl", "DDOBRACUNRadnici");
                this.ExtendedProperties.Add("LevelName", "VrstePosla");
                this.ExtendedProperties.Add("Description", "VrstePosla");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnDDOBRACUNIDOBRACUN = this.Columns["DDOBRACUNIDOBRACUN"];
                this.columnDDIDRADNIK = this.Columns["DDIDRADNIK"];
                this.columnDDIDVRSTAPOSLA = this.Columns["DDIDVRSTAPOSLA"];
                this.columnDDNAZIVVRSTAPOSLA = this.Columns["DDNAZIVVRSTAPOSLA"];
                this.columnDDSATI = this.Columns["DDSATI"];
                this.columnDDSATNICA = this.Columns["DDSATNICA"];
                this.columnDDIZNOS = this.Columns["DDIZNOS"];
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow NewDDOBRACUNRadniciVrstePoslaRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDOBRACUNRadniciVrstePoslaRowChanged != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler dDOBRACUNRadniciVrstePoslaRowChangedEvent = this.DDOBRACUNRadniciVrstePoslaRowChanged;
                    if (dDOBRACUNRadniciVrstePoslaRowChangedEvent != null)
                    {
                        dDOBRACUNRadniciVrstePoslaRowChangedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDOBRACUNRadniciVrstePoslaRowChanging != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler dDOBRACUNRadniciVrstePoslaRowChangingEvent = this.DDOBRACUNRadniciVrstePoslaRowChanging;
                    if (dDOBRACUNRadniciVrstePoslaRowChangingEvent != null)
                    {
                        dDOBRACUNRadniciVrstePoslaRowChangingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDOBRACUNRadniciVrstePoslaRowDeleted != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler dDOBRACUNRadniciVrstePoslaRowDeletedEvent = this.DDOBRACUNRadniciVrstePoslaRowDeleted;
                    if (dDOBRACUNRadniciVrstePoslaRowDeletedEvent != null)
                    {
                        dDOBRACUNRadniciVrstePoslaRowDeletedEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDOBRACUNRadniciVrstePoslaRowDeleting != null)
                {
                    DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEventHandler dDOBRACUNRadniciVrstePoslaRowDeletingEvent = this.DDOBRACUNRadniciVrstePoslaRowDeleting;
                    if (dDOBRACUNRadniciVrstePoslaRowDeletingEvent != null)
                    {
                        dDOBRACUNRadniciVrstePoslaRowDeletingEvent(this, new DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEvent((DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDOBRACUNRadniciVrstePoslaRow(DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow row)
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

            public DataColumn DDIDRADNIKColumn
            {
                get
                {
                    return this.columnDDIDRADNIK;
                }
            }

            public DataColumn DDIDVRSTAPOSLAColumn
            {
                get
                {
                    return this.columnDDIDVRSTAPOSLA;
                }
            }

            public DataColumn DDIZNOSColumn
            {
                get
                {
                    return this.columnDDIZNOS;
                }
            }

            public DataColumn DDNAZIVVRSTAPOSLAColumn
            {
                get
                {
                    return this.columnDDNAZIVVRSTAPOSLA;
                }
            }

            public DataColumn DDOBRACUNIDOBRACUNColumn
            {
                get
                {
                    return this.columnDDOBRACUNIDOBRACUN;
                }
            }

            public DataColumn DDSATIColumn
            {
                get
                {
                    return this.columnDDSATI;
                }
            }

            public DataColumn DDSATNICAColumn
            {
                get
                {
                    return this.columnDDSATNICA;
                }
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow this[int index]
            {
                get
                {
                    return (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow) this.Rows[index];
                }
            }
        }

        public class DDOBRACUNRadniciVrstePoslaRow : DataRow
        {
            private DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaDataTable tableDDOBRACUNRadniciVrstePosla;

            internal DDOBRACUNRadniciVrstePoslaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDOBRACUNRadniciVrstePosla = (DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaDataTable) this.Table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow GetDDOBRACUNRadniciRow()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow) this.GetParentRow("DDOBRACUNRadnici_DDOBRACUNRadniciVrstePosla");
            }

            public bool IsDDIDRADNIKNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciVrstePosla.DDIDRADNIKColumn);
            }

            public bool IsDDIDVRSTAPOSLANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciVrstePosla.DDIDVRSTAPOSLAColumn);
            }

            public bool IsDDIZNOSNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciVrstePosla.DDIZNOSColumn);
            }

            public bool IsDDNAZIVVRSTAPOSLANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciVrstePosla.DDNAZIVVRSTAPOSLAColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciVrstePosla.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDSATINull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciVrstePosla.DDSATIColumn);
            }

            public bool IsDDSATNICANull()
            {
                return this.IsNull(this.tableDDOBRACUNRadniciVrstePosla.DDSATNICAColumn);
            }

            public void SetDDIZNOSNull()
            {
                this[this.tableDDOBRACUNRadniciVrstePosla.DDIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDNAZIVVRSTAPOSLANull()
            {
                this[this.tableDDOBRACUNRadniciVrstePosla.DDNAZIVVRSTAPOSLAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDSATINull()
            {
                this[this.tableDDOBRACUNRadniciVrstePosla.DDSATIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDSATNICANull()
            {
                this[this.tableDDOBRACUNRadniciVrstePosla.DDSATNICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDRADNIK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciVrstePosla.DDIDRADNIKColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciVrstePosla.DDIDRADNIKColumn] = value;
                }
            }

            public int DDIDVRSTAPOSLA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDOBRACUNRadniciVrstePosla.DDIDVRSTAPOSLAColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciVrstePosla.DDIDVRSTAPOSLAColumn] = value;
                }
            }

            public decimal DDIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciVrstePosla.DDIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciVrstePosla.DDIZNOSColumn] = value;
                }
            }

            public string DDNAZIVVRSTAPOSLA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUNRadniciVrstePosla.DDNAZIVVRSTAPOSLAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciVrstePosla.DDNAZIVVRSTAPOSLAColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableDDOBRACUNRadniciVrstePosla.DDOBRACUNIDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciVrstePosla.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public decimal DDSATI
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciVrstePosla.DDSATIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciVrstePosla.DDSATIColumn] = value;
                }
            }

            public decimal DDSATNICA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDOBRACUNRadniciVrstePosla.DDSATNICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDOBRACUNRadniciVrstePosla.DDSATNICAColumn] = value;
                }
            }
        }

        public class DDOBRACUNRadniciVrstePoslaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow eventRow;

            public DDOBRACUNRadniciVrstePoslaRowChangeEvent(DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow row, DataRowAction action)
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

            public DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDOBRACUNRadniciVrstePoslaRowChangeEventHandler(object sender, DDOBRACUNDataSet.DDOBRACUNRadniciVrstePoslaRowChangeEvent e);

        public class DDOBRACUNRow : DataRow
        {
            private DDOBRACUNDataSet.DDOBRACUNDataTable tableDDOBRACUN;

            internal DDOBRACUNRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDOBRACUN = (DDOBRACUNDataSet.DDOBRACUNDataTable) this.Table;
            }

            public DDOBRACUNDataSet.DDOBRACUNRadniciRow[] GetDDOBRACUNRadniciRows()
            {
                return (DDOBRACUNDataSet.DDOBRACUNRadniciRow[]) this.GetChildRows("DDOBRACUN_DDOBRACUNRadnici");
            }

            public bool IsDDDATUMOBRACUNANull()
            {
                return this.IsNull(this.tableDDOBRACUN.DDDATUMOBRACUNAColumn);
            }

            public bool IsDDOBRACUNIDOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUN.DDOBRACUNIDOBRACUNColumn);
            }

            public bool IsDDOPISOBRACUNNull()
            {
                return this.IsNull(this.tableDDOBRACUN.DDOPISOBRACUNColumn);
            }

            public bool IsDDRSMNull()
            {
                return this.IsNull(this.tableDDOBRACUN.DDRSMColumn);
            }

            public bool IsDDZAKLJUCANNull()
            {
                return this.IsNull(this.tableDDOBRACUN.DDZAKLJUCANColumn);
            }

            public void SetDDDATUMOBRACUNANull()
            {
                this[this.tableDDOBRACUN.DDDATUMOBRACUNAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDOPISOBRACUNNull()
            {
                this[this.tableDDOBRACUN.DDOPISOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDRSMNull()
            {
                this[this.tableDDOBRACUN.DDRSMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDZAKLJUCANNull()
            {
                this[this.tableDDOBRACUN.DDZAKLJUCANColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DDDATUMOBRACUNA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableDDOBRACUN.DDDATUMOBRACUNAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableDDOBRACUN.DDDATUMOBRACUNAColumn] = value;
                }
            }

            public string DDOBRACUNIDOBRACUN
            {
                get
                {
                    return Conversions.ToString(this[this.tableDDOBRACUN.DDOBRACUNIDOBRACUNColumn]);
                }
                set
                {
                    this[this.tableDDOBRACUN.DDOBRACUNIDOBRACUNColumn] = value;
                }
            }

            public string DDOPISOBRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUN.DDOPISOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUN.DDOPISOBRACUNColumn] = value;
                }
            }

            public string DDRSM
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDOBRACUN.DDRSMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDOBRACUN.DDRSMColumn] = value;
                }
            }

            public bool DDZAKLJUCAN
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDOBRACUN.DDZAKLJUCANColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDOBRACUN.DDZAKLJUCANColumn] = value;
                }
            }
        }

        public class DDOBRACUNRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDOBRACUNDataSet.DDOBRACUNRow eventRow;

            public DDOBRACUNRowChangeEvent(DDOBRACUNDataSet.DDOBRACUNRow row, DataRowAction action)
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

            public DDOBRACUNDataSet.DDOBRACUNRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDOBRACUNRowChangeEventHandler(object sender, DDOBRACUNDataSet.DDOBRACUNRowChangeEvent e);
    }
}

