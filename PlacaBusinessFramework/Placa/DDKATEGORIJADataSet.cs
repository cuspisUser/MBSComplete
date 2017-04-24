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
    public class DDKATEGORIJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DDKATEGORIJADataTable tableDDKATEGORIJA;
        private DDKATEGORIJAIzdaciDataTable tableDDKATEGORIJAIzdaci;
        private DDKATEGORIJALevel1DataTable tableDDKATEGORIJALevel1;
        private DDKATEGORIJALevel3DataTable tableDDKATEGORIJALevel3;

        public DDKATEGORIJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DDKATEGORIJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DDKATEGORIJAIzdaci"] != null)
                    {
                        this.Tables.Add(new DDKATEGORIJAIzdaciDataTable(dataSet.Tables["DDKATEGORIJAIzdaci"]));
                    }
                    if (dataSet.Tables["DDKATEGORIJALevel3"] != null)
                    {
                        this.Tables.Add(new DDKATEGORIJALevel3DataTable(dataSet.Tables["DDKATEGORIJALevel3"]));
                    }
                    if (dataSet.Tables["DDKATEGORIJALevel1"] != null)
                    {
                        this.Tables.Add(new DDKATEGORIJALevel1DataTable(dataSet.Tables["DDKATEGORIJALevel1"]));
                    }
                    if (dataSet.Tables["DDKATEGORIJA"] != null)
                    {
                        this.Tables.Add(new DDKATEGORIJADataTable(dataSet.Tables["DDKATEGORIJA"]));
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
            DDKATEGORIJADataSet set = (DDKATEGORIJADataSet) base.Clone();
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
            DDKATEGORIJADataSet set = new DDKATEGORIJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DDKATEGORIJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2083");
            this.ExtendedProperties.Add("DataSetName", "DDKATEGORIJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDDKATEGORIJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DDKATEGORIJA");
            this.ExtendedProperties.Add("ObjectDescription", "Kategorija drugog dohotka");
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
            this.DataSetName = "DDKATEGORIJADataSet";
            this.Namespace = "http://www.tempuri.org/DDKATEGORIJA";
            this.tableDDKATEGORIJAIzdaci = new DDKATEGORIJAIzdaciDataTable();
            this.Tables.Add(this.tableDDKATEGORIJAIzdaci);
            this.tableDDKATEGORIJALevel3 = new DDKATEGORIJALevel3DataTable();
            this.Tables.Add(this.tableDDKATEGORIJALevel3);
            this.tableDDKATEGORIJALevel1 = new DDKATEGORIJALevel1DataTable();
            this.Tables.Add(this.tableDDKATEGORIJALevel1);
            this.tableDDKATEGORIJA = new DDKATEGORIJADataTable();
            this.Tables.Add(this.tableDDKATEGORIJA);
            this.Relations.Add("DDKATEGORIJA_DDKATEGORIJAIzdaci", new DataColumn[] { this.Tables["DDKATEGORIJA"].Columns["IDKATEGORIJA"] }, new DataColumn[] { this.Tables["DDKATEGORIJAIzdaci"].Columns["IDKATEGORIJA"] });
            this.Relations["DDKATEGORIJA_DDKATEGORIJAIzdaci"].Nested = true;
            this.Relations.Add("DDKATEGORIJA_DDKATEGORIJALevel3", new DataColumn[] { this.Tables["DDKATEGORIJA"].Columns["IDKATEGORIJA"] }, new DataColumn[] { this.Tables["DDKATEGORIJALevel3"].Columns["IDKATEGORIJA"] });
            this.Relations["DDKATEGORIJA_DDKATEGORIJALevel3"].Nested = true;
            this.Relations.Add("DDKATEGORIJA_DDKATEGORIJALevel1", new DataColumn[] { this.Tables["DDKATEGORIJA"].Columns["IDKATEGORIJA"] }, new DataColumn[] { this.Tables["DDKATEGORIJALevel1"].Columns["IDKATEGORIJA"] });
            this.Relations["DDKATEGORIJA_DDKATEGORIJALevel1"].Nested = true;
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
            this.tableDDKATEGORIJAIzdaci = (DDKATEGORIJAIzdaciDataTable) this.Tables["DDKATEGORIJAIzdaci"];
            this.tableDDKATEGORIJALevel3 = (DDKATEGORIJALevel3DataTable) this.Tables["DDKATEGORIJALevel3"];
            this.tableDDKATEGORIJALevel1 = (DDKATEGORIJALevel1DataTable) this.Tables["DDKATEGORIJALevel1"];
            this.tableDDKATEGORIJA = (DDKATEGORIJADataTable) this.Tables["DDKATEGORIJA"];
            if (initTable)
            {
                if (this.tableDDKATEGORIJAIzdaci != null)
                {
                    this.tableDDKATEGORIJAIzdaci.InitVars();
                }
                if (this.tableDDKATEGORIJALevel3 != null)
                {
                    this.tableDDKATEGORIJALevel3.InitVars();
                }
                if (this.tableDDKATEGORIJALevel1 != null)
                {
                    this.tableDDKATEGORIJALevel1.InitVars();
                }
                if (this.tableDDKATEGORIJA != null)
                {
                    this.tableDDKATEGORIJA.InitVars();
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
                if (dataSet.Tables["DDKATEGORIJAIzdaci"] != null)
                {
                    this.Tables.Add(new DDKATEGORIJAIzdaciDataTable(dataSet.Tables["DDKATEGORIJAIzdaci"]));
                }
                if (dataSet.Tables["DDKATEGORIJALevel3"] != null)
                {
                    this.Tables.Add(new DDKATEGORIJALevel3DataTable(dataSet.Tables["DDKATEGORIJALevel3"]));
                }
                if (dataSet.Tables["DDKATEGORIJALevel1"] != null)
                {
                    this.Tables.Add(new DDKATEGORIJALevel1DataTable(dataSet.Tables["DDKATEGORIJALevel1"]));
                }
                if (dataSet.Tables["DDKATEGORIJA"] != null)
                {
                    this.Tables.Add(new DDKATEGORIJADataTable(dataSet.Tables["DDKATEGORIJA"]));
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

        private bool ShouldSerializeDDKATEGORIJA()
        {
            return false;
        }

        private bool ShouldSerializeDDKATEGORIJAIzdaci()
        {
            return false;
        }

        private bool ShouldSerializeDDKATEGORIJALevel1()
        {
            return false;
        }

        private bool ShouldSerializeDDKATEGORIJALevel3()
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
        public DDKATEGORIJADataTable DDKATEGORIJA
        {
            get
            {
                return this.tableDDKATEGORIJA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDKATEGORIJAIzdaciDataTable DDKATEGORIJAIzdaci
        {
            get
            {
                return this.tableDDKATEGORIJAIzdaci;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDKATEGORIJALevel1DataTable DDKATEGORIJALevel1
        {
            get
            {
                return this.tableDDKATEGORIJALevel1;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DDKATEGORIJALevel3DataTable DDKATEGORIJALevel3
        {
            get
            {
                return this.tableDDKATEGORIJALevel3;
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
        public class DDKATEGORIJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDKATEGORIJA;
            private DataColumn columnIDKOLONAIDD;
            private DataColumn columnNAZIVKATEGORIJA;
            private DataColumn columnNAZIVKOLONAIDD;

            public event DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler DDKATEGORIJARowChanged;

            public event DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler DDKATEGORIJARowChanging;

            public event DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler DDKATEGORIJARowDeleted;

            public event DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler DDKATEGORIJARowDeleting;

            public DDKATEGORIJADataTable()
            {
                this.TableName = "DDKATEGORIJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDKATEGORIJADataTable(DataTable table) : base(table.TableName)
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

            protected DDKATEGORIJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDKATEGORIJARow(DDKATEGORIJADataSet.DDKATEGORIJARow row)
            {
                this.Rows.Add(row);
            }

            public DDKATEGORIJADataSet.DDKATEGORIJARow AddDDKATEGORIJARow(int iDKATEGORIJA, string nAZIVKATEGORIJA, int iDKOLONAIDD)
            {
                DDKATEGORIJADataSet.DDKATEGORIJARow row = (DDKATEGORIJADataSet.DDKATEGORIJARow) this.NewRow();
                row["IDKATEGORIJA"] = iDKATEGORIJA;
                row["NAZIVKATEGORIJA"] = nAZIVKATEGORIJA;
                row["IDKOLONAIDD"] = iDKOLONAIDD;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDKATEGORIJADataSet.DDKATEGORIJADataTable table = (DDKATEGORIJADataSet.DDKATEGORIJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJARow FindByIDKATEGORIJA(int iDKATEGORIJA)
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJARow) this.Rows.Find(new object[] { iDKATEGORIJA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDKATEGORIJADataSet.DDKATEGORIJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDKATEGORIJADataSet set = new DDKATEGORIJADataSet();
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
                this.columnIDKATEGORIJA = new DataColumn("IDKATEGORIJA", typeof(int), "", MappingType.Element);
                this.columnIDKATEGORIJA.AllowDBNull = false;
                this.columnIDKATEGORIJA.Caption = "IDKATEGORIJA";
                this.columnIDKATEGORIJA.Unique = true;
                this.columnIDKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Length", "5");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "IDKATEGORIJA");
                this.Columns.Add(this.columnIDKATEGORIJA);
                this.columnNAZIVKATEGORIJA = new DataColumn("NAZIVKATEGORIJA", typeof(string), "", MappingType.Element);
                this.columnNAZIVKATEGORIJA.AllowDBNull = false;
                this.columnNAZIVKATEGORIJA.Caption = "Kategorija";
                this.columnNAZIVKATEGORIJA.MaxLength = 50;
                this.columnNAZIVKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Description", "Kategorija drugog dohotka");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKATEGORIJA");
                this.Columns.Add(this.columnNAZIVKATEGORIJA);
                this.columnIDKOLONAIDD = new DataColumn("IDKOLONAIDD", typeof(int), "", MappingType.Element);
                this.columnIDKOLONAIDD.AllowDBNull = false;
                this.columnIDKOLONAIDD.Caption = "Kolona IDD obrasca";
                this.columnIDKOLONAIDD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("IsKey", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Description", "Kolona IDD obrasca");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Length", "5");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.InternalName", "IDKOLONAIDD");
                this.Columns.Add(this.columnIDKOLONAIDD);
                this.columnNAZIVKOLONAIDD = new DataColumn("NAZIVKOLONAIDD", typeof(string), "", MappingType.Element);
                this.columnNAZIVKOLONAIDD.AllowDBNull = true;
                this.columnNAZIVKOLONAIDD.Caption = "Naziv kolone";
                this.columnNAZIVKOLONAIDD.MaxLength = 50;
                this.columnNAZIVKOLONAIDD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Description", "Naziv kolone");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKOLONAIDD");
                this.Columns.Add(this.columnNAZIVKOLONAIDD);
                this.PrimaryKey = new DataColumn[] { this.columnIDKATEGORIJA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DDKATEGORIJA");
                this.ExtendedProperties.Add("Description", "Kategorija drugog dohotka");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDKATEGORIJA = this.Columns["IDKATEGORIJA"];
                this.columnNAZIVKATEGORIJA = this.Columns["NAZIVKATEGORIJA"];
                this.columnIDKOLONAIDD = this.Columns["IDKOLONAIDD"];
                this.columnNAZIVKOLONAIDD = this.Columns["NAZIVKOLONAIDD"];
            }

            public DDKATEGORIJADataSet.DDKATEGORIJARow NewDDKATEGORIJARow()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDKATEGORIJADataSet.DDKATEGORIJARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDKATEGORIJARowChanged != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler dDKATEGORIJARowChangedEvent = this.DDKATEGORIJARowChanged;
                    if (dDKATEGORIJARowChangedEvent != null)
                    {
                        dDKATEGORIJARowChangedEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJARowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDKATEGORIJARowChanging != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler dDKATEGORIJARowChangingEvent = this.DDKATEGORIJARowChanging;
                    if (dDKATEGORIJARowChangingEvent != null)
                    {
                        dDKATEGORIJARowChangingEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJARowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DDKATEGORIJARowDeleted != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler dDKATEGORIJARowDeletedEvent = this.DDKATEGORIJARowDeleted;
                    if (dDKATEGORIJARowDeletedEvent != null)
                    {
                        dDKATEGORIJARowDeletedEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJARowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDKATEGORIJARowDeleting != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJARowChangeEventHandler dDKATEGORIJARowDeletingEvent = this.DDKATEGORIJARowDeleting;
                    if (dDKATEGORIJARowDeletingEvent != null)
                    {
                        dDKATEGORIJARowDeletingEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJARowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDKATEGORIJARow(DDKATEGORIJADataSet.DDKATEGORIJARow row)
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

            public DDKATEGORIJADataSet.DDKATEGORIJARow this[int index]
            {
                get
                {
                    return (DDKATEGORIJADataSet.DDKATEGORIJARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVKATEGORIJAColumn
            {
                get
                {
                    return this.columnNAZIVKATEGORIJA;
                }
            }

            public DataColumn NAZIVKOLONAIDDColumn
            {
                get
                {
                    return this.columnNAZIVKOLONAIDD;
                }
            }
        }

        [Serializable]
        public class DDKATEGORIJAIzdaciDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDIDIZDATAK;
            private DataColumn columnDDNAZIVIZDATKA;
            private DataColumn columnDDPOSTOTAKIZDATKA;
            private DataColumn columnIDKATEGORIJA;

            public event DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler DDKATEGORIJAIzdaciRowChanged;

            public event DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler DDKATEGORIJAIzdaciRowChanging;

            public event DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler DDKATEGORIJAIzdaciRowDeleted;

            public event DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler DDKATEGORIJAIzdaciRowDeleting;

            public DDKATEGORIJAIzdaciDataTable()
            {
                this.TableName = "DDKATEGORIJAIzdaci";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDKATEGORIJAIzdaciDataTable(DataTable table) : base(table.TableName)
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

            protected DDKATEGORIJAIzdaciDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDKATEGORIJAIzdaciRow(DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow row)
            {
                this.Rows.Add(row);
            }

            public DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow AddDDKATEGORIJAIzdaciRow(int iDKATEGORIJA, int dDIDIZDATAK)
            {
                DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow row = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) this.NewRow();
                row["IDKATEGORIJA"] = iDKATEGORIJA;
                row["DDIDIZDATAK"] = dDIDIZDATAK;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDKATEGORIJADataSet.DDKATEGORIJAIzdaciDataTable table = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow FindByIDKATEGORIJADDIDIZDATAK(int iDKATEGORIJA, int dDIDIZDATAK)
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) this.Rows.Find(new object[] { iDKATEGORIJA, dDIDIZDATAK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDKATEGORIJADataSet set = new DDKATEGORIJADataSet();
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
                this.columnIDKATEGORIJA = new DataColumn("IDKATEGORIJA", typeof(int), "", MappingType.Element);
                this.columnIDKATEGORIJA.AllowDBNull = false;
                this.columnIDKATEGORIJA.Caption = "IDKATEGORIJA";
                this.columnIDKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Length", "5");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "IDKATEGORIJA");
                this.Columns.Add(this.columnIDKATEGORIJA);
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
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Description", "Šifra");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Length", "5");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Decimals", "0");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDIDIZDATAK.ExtendedProperties.Add("Deklarit.InternalName", "DDIDIZDATAK");
                this.Columns.Add(this.columnDDIDIZDATAK);
                this.columnDDNAZIVIZDATKA = new DataColumn("DDNAZIVIZDATKA", typeof(string), "", MappingType.Element);
                this.columnDDNAZIVIZDATKA.AllowDBNull = true;
                this.columnDDNAZIVIZDATKA.Caption = "DDNAZIVIZDATKA";
                this.columnDDNAZIVIZDATKA.MaxLength = 50;
                this.columnDDNAZIVIZDATKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Description", "Naziv izdatka");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Length", "50");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Decimals", "0");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDNAZIVIZDATKA.ExtendedProperties.Add("Deklarit.InternalName", "DDNAZIVIZDATKA");
                this.Columns.Add(this.columnDDNAZIVIZDATKA);
                this.columnDDPOSTOTAKIZDATKA = new DataColumn("DDPOSTOTAKIZDATKA", typeof(decimal), "", MappingType.Element);
                this.columnDDPOSTOTAKIZDATKA.AllowDBNull = true;
                this.columnDDPOSTOTAKIZDATKA.Caption = "DDPOSTOTAKIZDATKA";
                this.columnDDPOSTOTAKIZDATKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Description", "Postotak izdatka");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Length", "5");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Decimals", "2");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOSTOTAKIZDATKA.ExtendedProperties.Add("Deklarit.InternalName", "DDPOSTOTAKIZDATKA");
                this.Columns.Add(this.columnDDPOSTOTAKIZDATKA);
                this.PrimaryKey = new DataColumn[] { this.columnIDKATEGORIJA, this.columnDDIDIZDATAK };
                this.ExtendedProperties.Add("ParentLvl", "DDKATEGORIJA");
                this.ExtendedProperties.Add("LevelName", "Izdaci");
                this.ExtendedProperties.Add("Description", "Izdaci");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDKATEGORIJA = this.Columns["IDKATEGORIJA"];
                this.columnDDIDIZDATAK = this.Columns["DDIDIZDATAK"];
                this.columnDDNAZIVIZDATKA = this.Columns["DDNAZIVIZDATKA"];
                this.columnDDPOSTOTAKIZDATKA = this.Columns["DDPOSTOTAKIZDATKA"];
            }

            public DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow NewDDKATEGORIJAIzdaciRow()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDKATEGORIJAIzdaciRowChanged != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler dDKATEGORIJAIzdaciRowChangedEvent = this.DDKATEGORIJAIzdaciRowChanged;
                    if (dDKATEGORIJAIzdaciRowChangedEvent != null)
                    {
                        dDKATEGORIJAIzdaciRowChangedEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDKATEGORIJAIzdaciRowChanging != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler dDKATEGORIJAIzdaciRowChangingEvent = this.DDKATEGORIJAIzdaciRowChanging;
                    if (dDKATEGORIJAIzdaciRowChangingEvent != null)
                    {
                        dDKATEGORIJAIzdaciRowChangingEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDKATEGORIJA_DDKATEGORIJAIzdaci", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDKATEGORIJAIzdaciRowDeleted != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler dDKATEGORIJAIzdaciRowDeletedEvent = this.DDKATEGORIJAIzdaciRowDeleted;
                    if (dDKATEGORIJAIzdaciRowDeletedEvent != null)
                    {
                        dDKATEGORIJAIzdaciRowDeletedEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDKATEGORIJAIzdaciRowDeleting != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEventHandler dDKATEGORIJAIzdaciRowDeletingEvent = this.DDKATEGORIJAIzdaciRowDeleting;
                    if (dDKATEGORIJAIzdaciRowDeletingEvent != null)
                    {
                        dDKATEGORIJAIzdaciRowDeletingEvent(this, new DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDKATEGORIJAIzdaciRow(DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow row)
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

            public DataColumn DDNAZIVIZDATKAColumn
            {
                get
                {
                    return this.columnDDNAZIVIZDATKA;
                }
            }

            public DataColumn DDPOSTOTAKIZDATKAColumn
            {
                get
                {
                    return this.columnDDPOSTOTAKIZDATKA;
                }
            }

            public DataColumn IDKATEGORIJAColumn
            {
                get
                {
                    return this.columnIDKATEGORIJA;
                }
            }

            public DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow this[int index]
            {
                get
                {
                    return (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) this.Rows[index];
                }
            }
        }

        public class DDKATEGORIJAIzdaciRow : DataRow
        {
            private DDKATEGORIJADataSet.DDKATEGORIJAIzdaciDataTable tableDDKATEGORIJAIzdaci;

            internal DDKATEGORIJAIzdaciRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDKATEGORIJAIzdaci = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciDataTable) this.Table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJARow GetDDKATEGORIJARow()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJARow) this.GetParentRow("DDKATEGORIJA_DDKATEGORIJAIzdaci");
            }

            public bool IsDDIDIZDATAKNull()
            {
                return this.IsNull(this.tableDDKATEGORIJAIzdaci.DDIDIZDATAKColumn);
            }

            public bool IsDDNAZIVIZDATKANull()
            {
                return this.IsNull(this.tableDDKATEGORIJAIzdaci.DDNAZIVIZDATKAColumn);
            }

            public bool IsDDPOSTOTAKIZDATKANull()
            {
                return this.IsNull(this.tableDDKATEGORIJAIzdaci.DDPOSTOTAKIZDATKAColumn);
            }

            public bool IsIDKATEGORIJANull()
            {
                return this.IsNull(this.tableDDKATEGORIJAIzdaci.IDKATEGORIJAColumn);
            }

            public void SetDDNAZIVIZDATKANull()
            {
                this[this.tableDDKATEGORIJAIzdaci.DDNAZIVIZDATKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOSTOTAKIZDATKANull()
            {
                this[this.tableDDKATEGORIJAIzdaci.DDPOSTOTAKIZDATKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int DDIDIZDATAK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKATEGORIJAIzdaci.DDIDIZDATAKColumn]);
                }
                set
                {
                    this[this.tableDDKATEGORIJAIzdaci.DDIDIZDATAKColumn] = value;
                }
            }

            public string DDNAZIVIZDATKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJAIzdaci.DDNAZIVIZDATKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DDNAZIVIZDATKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJAIzdaci.DDNAZIVIZDATKAColumn] = value;
                }
            }

            public decimal DDPOSTOTAKIZDATKA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDKATEGORIJAIzdaci.DDPOSTOTAKIZDATKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDKATEGORIJAIzdaci.DDPOSTOTAKIZDATKAColumn] = value;
                }
            }

            public int IDKATEGORIJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKATEGORIJAIzdaci.IDKATEGORIJAColumn]);
                }
                set
                {
                    this[this.tableDDKATEGORIJAIzdaci.IDKATEGORIJAColumn] = value;
                }
            }
        }

        public class DDKATEGORIJAIzdaciRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow eventRow;

            public DDKATEGORIJAIzdaciRowChangeEvent(DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow row, DataRowAction action)
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

            public DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDKATEGORIJAIzdaciRowChangeEventHandler(object sender, DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRowChangeEvent e);

        [Serializable]
        public class DDKATEGORIJALevel1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnDDMOPOREZ;
            private DataColumn columnDDPOPOREZ;
            private DataColumn columnIDKATEGORIJA;
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

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler DDKATEGORIJALevel1RowChanged;

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler DDKATEGORIJALevel1RowChanging;

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler DDKATEGORIJALevel1RowDeleted;

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler DDKATEGORIJALevel1RowDeleting;

            public DDKATEGORIJALevel1DataTable()
            {
                this.TableName = "DDKATEGORIJALevel1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDKATEGORIJALevel1DataTable(DataTable table) : base(table.TableName)
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

            protected DDKATEGORIJALevel1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDKATEGORIJALevel1Row(DDKATEGORIJADataSet.DDKATEGORIJALevel1Row row)
            {
                this.Rows.Add(row);
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel1Row AddDDKATEGORIJALevel1Row(int iDKATEGORIJA, int iDPOREZ, string dDMOPOREZ, string dDPOPOREZ)
            {
                DDKATEGORIJADataSet.DDKATEGORIJALevel1Row row = (DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) this.NewRow();
                row["IDKATEGORIJA"] = iDKATEGORIJA;
                row["IDPOREZ"] = iDPOREZ;
                row["DDMOPOREZ"] = dDMOPOREZ;
                row["DDPOPOREZ"] = dDPOPOREZ;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDKATEGORIJADataSet.DDKATEGORIJALevel1DataTable table = (DDKATEGORIJADataSet.DDKATEGORIJALevel1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel1Row FindByIDKATEGORIJAIDPOREZ(int iDKATEGORIJA, int iDPOREZ)
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) this.Rows.Find(new object[] { iDKATEGORIJA, iDPOREZ });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDKATEGORIJADataSet.DDKATEGORIJALevel1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDKATEGORIJADataSet set = new DDKATEGORIJADataSet();
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
                this.columnIDKATEGORIJA = new DataColumn("IDKATEGORIJA", typeof(int), "", MappingType.Element);
                this.columnIDKATEGORIJA.AllowDBNull = false;
                this.columnIDKATEGORIJA.Caption = "IDKATEGORIJA";
                this.columnIDKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Length", "5");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "IDKATEGORIJA");
                this.Columns.Add(this.columnIDKATEGORIJA);
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
                this.columnNAZIVPOREZ.AllowDBNull = true;
                this.columnNAZIVPOREZ.Caption = "Naziv poreza";
                this.columnNAZIVPOREZ.MaxLength = 50;
                this.columnNAZIVPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnNAZIVPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
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
                this.columnSTOPAPOREZA.AllowDBNull = true;
                this.columnSTOPAPOREZA.Caption = "Stopa poreza";
                this.columnSTOPAPOREZA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnSTOPAPOREZA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAPOREZA.ExtendedProperties.Add("Deklarit.InternalName", "STOPAPOREZA");
                this.Columns.Add(this.columnSTOPAPOREZA);
                this.columnDDMOPOREZ = new DataColumn("DDMOPOREZ", typeof(string), "", MappingType.Element);
                this.columnDDMOPOREZ.AllowDBNull = false;
                this.columnDDMOPOREZ.Caption = "DDMOPOREZ";
                this.columnDDMOPOREZ.MaxLength = 2;
                this.columnDDMOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDMOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Description", "Model odobrenja");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Length", "2");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnDDMOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDMOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "DDMOPOREZ");
                this.Columns.Add(this.columnDDMOPOREZ);
                this.columnDDPOPOREZ = new DataColumn("DDPOPOREZ", typeof(string), "", MappingType.Element);
                this.columnDDPOPOREZ.AllowDBNull = false;
                this.columnDDPOPOREZ.Caption = "DDPOPOREZ";
                this.columnDDPOPOREZ.MaxLength = 0x16;
                this.columnDDPOPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDDPOPOREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Description", "Poziv na broj odobrenja");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Length", "22");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Decimals", "0");
                this.columnDDPOPOREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDDPOPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "DDPOPOREZ");
                this.Columns.Add(this.columnDDPOPOREZ);
                this.columnMZPOREZ = new DataColumn("MZPOREZ", typeof(string), "", MappingType.Element);
                this.columnMZPOREZ.AllowDBNull = true;
                this.columnMZPOREZ.Caption = "Model zaduženja poreza";
                this.columnMZPOREZ.MaxLength = 2;
                this.columnMZPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPZPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPRIMATELJPOREZ1.AllowDBNull = true;
                this.columnPRIMATELJPOREZ1.Caption = "Primatelj poreza (1)";
                this.columnPRIMATELJPOREZ1.MaxLength = 20;
                this.columnPRIMATELJPOREZ1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ1");
                this.Columns.Add(this.columnPRIMATELJPOREZ1);
                this.columnPRIMATELJPOREZ2 = new DataColumn("PRIMATELJPOREZ2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJPOREZ2.AllowDBNull = true;
                this.columnPRIMATELJPOREZ2.Caption = "Primatelj poreza (2)";
                this.columnPRIMATELJPOREZ2.MaxLength = 20;
                this.columnPRIMATELJPOREZ2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJPOREZ2.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJPOREZ2");
                this.Columns.Add(this.columnPRIMATELJPOREZ2);
                this.columnSIFRAOPISAPLACANJAPOREZ = new DataColumn("SIFRAOPISAPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnSIFRAOPISAPLACANJAPOREZ.AllowDBNull = true;
                this.columnSIFRAOPISAPLACANJAPOREZ.Caption = "Šifra opisa plaćanja poreza";
                this.columnSIFRAOPISAPLACANJAPOREZ.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJAPOREZ");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJAPOREZ);
                this.columnOPISPLACANJAPOREZ = new DataColumn("OPISPLACANJAPOREZ", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJAPOREZ.AllowDBNull = true;
                this.columnOPISPLACANJAPOREZ.Caption = "Opis plaćanja poreza";
                this.columnOPISPLACANJAPOREZ.MaxLength = 0x24;
                this.columnOPISPLACANJAPOREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJAPOREZ.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJAPOREZ");
                this.Columns.Add(this.columnOPISPLACANJAPOREZ);
                this.PrimaryKey = new DataColumn[] { this.columnIDKATEGORIJA, this.columnIDPOREZ };
                this.ExtendedProperties.Add("ParentLvl", "DDKATEGORIJA");
                this.ExtendedProperties.Add("LevelName", "Level1");
                this.ExtendedProperties.Add("Description", "Porezi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDKATEGORIJA = this.Columns["IDKATEGORIJA"];
                this.columnIDPOREZ = this.Columns["IDPOREZ"];
                this.columnNAZIVPOREZ = this.Columns["NAZIVPOREZ"];
                this.columnPOREZMJESECNO = this.Columns["POREZMJESECNO"];
                this.columnSTOPAPOREZA = this.Columns["STOPAPOREZA"];
                this.columnDDMOPOREZ = this.Columns["DDMOPOREZ"];
                this.columnDDPOPOREZ = this.Columns["DDPOPOREZ"];
                this.columnMZPOREZ = this.Columns["MZPOREZ"];
                this.columnPZPOREZ = this.Columns["PZPOREZ"];
                this.columnPRIMATELJPOREZ1 = this.Columns["PRIMATELJPOREZ1"];
                this.columnPRIMATELJPOREZ2 = this.Columns["PRIMATELJPOREZ2"];
                this.columnSIFRAOPISAPLACANJAPOREZ = this.Columns["SIFRAOPISAPLACANJAPOREZ"];
                this.columnOPISPLACANJAPOREZ = this.Columns["OPISPLACANJAPOREZ"];
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel1Row NewDDKATEGORIJALevel1Row()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDKATEGORIJADataSet.DDKATEGORIJALevel1Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDKATEGORIJALevel1RowChanged != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler handler = this.DDKATEGORIJALevel1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDKATEGORIJALevel1RowChanging != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler handler = this.DDKATEGORIJALevel1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDKATEGORIJA_DDKATEGORIJALevel1", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDKATEGORIJALevel1RowDeleted != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler handler = this.DDKATEGORIJALevel1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDKATEGORIJALevel1RowDeleting != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEventHandler handler = this.DDKATEGORIJALevel1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDKATEGORIJALevel1Row(DDKATEGORIJADataSet.DDKATEGORIJALevel1Row row)
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

            public DataColumn DDMOPOREZColumn
            {
                get
                {
                    return this.columnDDMOPOREZ;
                }
            }

            public DataColumn DDPOPOREZColumn
            {
                get
                {
                    return this.columnDDPOPOREZ;
                }
            }

            public DataColumn IDKATEGORIJAColumn
            {
                get
                {
                    return this.columnIDKATEGORIJA;
                }
            }

            public DataColumn IDPOREZColumn
            {
                get
                {
                    return this.columnIDPOREZ;
                }
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel1Row this[int index]
            {
                get
                {
                    return (DDKATEGORIJADataSet.DDKATEGORIJALevel1Row) this.Rows[index];
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

        public class DDKATEGORIJALevel1Row : DataRow
        {
            private DDKATEGORIJADataSet.DDKATEGORIJALevel1DataTable tableDDKATEGORIJALevel1;

            internal DDKATEGORIJALevel1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableDDKATEGORIJALevel1 = (DDKATEGORIJADataSet.DDKATEGORIJALevel1DataTable) this.Table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJARow GetDDKATEGORIJARow()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJARow) this.GetParentRow("DDKATEGORIJA_DDKATEGORIJALevel1");
            }

            public bool IsDDMOPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.DDMOPOREZColumn);
            }

            public bool IsDDPOPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.DDPOPOREZColumn);
            }

            public bool IsIDKATEGORIJANull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.IDKATEGORIJAColumn);
            }

            public bool IsIDPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.IDPOREZColumn);
            }

            public bool IsMZPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.MZPOREZColumn);
            }

            public bool IsNAZIVPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.NAZIVPOREZColumn);
            }

            public bool IsOPISPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.OPISPLACANJAPOREZColumn);
            }

            public bool IsPOREZMJESECNONull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.POREZMJESECNOColumn);
            }

            public bool IsPRIMATELJPOREZ1Null()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ1Column);
            }

            public bool IsPRIMATELJPOREZ2Null()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ2Column);
            }

            public bool IsPZPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.PZPOREZColumn);
            }

            public bool IsSIFRAOPISAPLACANJAPOREZNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.SIFRAOPISAPLACANJAPOREZColumn);
            }

            public bool IsSTOPAPOREZANull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel1.STOPAPOREZAColumn);
            }

            public void SetDDMOPOREZNull()
            {
                this[this.tableDDKATEGORIJALevel1.DDMOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDDPOPOREZNull()
            {
                this[this.tableDDKATEGORIJALevel1.DDPOPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZPOREZNull()
            {
                this[this.tableDDKATEGORIJALevel1.MZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPOREZNull()
            {
                this[this.tableDDKATEGORIJALevel1.NAZIVPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJAPOREZNull()
            {
                this[this.tableDDKATEGORIJALevel1.OPISPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZMJESECNONull()
            {
                this[this.tableDDKATEGORIJALevel1.POREZMJESECNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ1Null()
            {
                this[this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJPOREZ2Null()
            {
                this[this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZPOREZNull()
            {
                this[this.tableDDKATEGORIJALevel1.PZPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJAPOREZNull()
            {
                this[this.tableDDKATEGORIJALevel1.SIFRAOPISAPLACANJAPOREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAPOREZANull()
            {
                this[this.tableDDKATEGORIJALevel1.STOPAPOREZAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string DDMOPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.DDMOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.DDMOPOREZColumn] = value;
                }
            }

            public string DDPOPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.DDPOPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.DDPOPOREZColumn] = value;
                }
            }

            public int IDKATEGORIJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKATEGORIJALevel1.IDKATEGORIJAColumn]);
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.IDKATEGORIJAColumn] = value;
                }
            }

            public int IDPOREZ
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKATEGORIJALevel1.IDPOREZColumn]);
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.IDPOREZColumn] = value;
                }
            }

            public string MZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.MZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.MZPOREZColumn] = value;
                }
            }

            public string NAZIVPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.NAZIVPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.NAZIVPOREZColumn] = value;
                }
            }

            public string OPISPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.OPISPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.OPISPLACANJAPOREZColumn] = value;
                }
            }

            public decimal POREZMJESECNO
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDKATEGORIJALevel1.POREZMJESECNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.POREZMJESECNOColumn] = value;
                }
            }

            public string PRIMATELJPOREZ1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ1Column] = value;
                }
            }

            public string PRIMATELJPOREZ2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.PRIMATELJPOREZ2Column] = value;
                }
            }

            public string PZPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.PZPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.PZPOREZColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJAPOREZ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel1.SIFRAOPISAPLACANJAPOREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.SIFRAOPISAPLACANJAPOREZColumn] = value;
                }
            }

            public decimal STOPAPOREZA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDKATEGORIJALevel1.STOPAPOREZAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel1.STOPAPOREZAColumn] = value;
                }
            }
        }

        public class DDKATEGORIJALevel1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDKATEGORIJADataSet.DDKATEGORIJALevel1Row eventRow;

            public DDKATEGORIJALevel1RowChangeEvent(DDKATEGORIJADataSet.DDKATEGORIJALevel1Row row, DataRowAction action)
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

            public DDKATEGORIJADataSet.DDKATEGORIJALevel1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDKATEGORIJALevel1RowChangeEventHandler(object sender, DDKATEGORIJADataSet.DDKATEGORIJALevel1RowChangeEvent e);

        [Serializable]
        public class DDKATEGORIJALevel3DataTable : DataTable, IEnumerable
        {
            private DataColumn columnDOPRINOSDRUGOGSTUPA;
            private DataColumn columnIDDOPRINOS;
            private DataColumn columnIDKATEGORIJA;
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

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler DDKATEGORIJALevel3RowChanged;

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler DDKATEGORIJALevel3RowChanging;

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler DDKATEGORIJALevel3RowDeleted;

            public event DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler DDKATEGORIJALevel3RowDeleting;

            public DDKATEGORIJALevel3DataTable()
            {
                this.TableName = "DDKATEGORIJALevel3";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDKATEGORIJALevel3DataTable(DataTable table) : base(table.TableName)
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

            protected DDKATEGORIJALevel3DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDKATEGORIJALevel3Row(DDKATEGORIJADataSet.DDKATEGORIJALevel3Row row)
            {
                this.Rows.Add(row);
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel3Row AddDDKATEGORIJALevel3Row(int iDKATEGORIJA, int iDDOPRINOS, bool dOPRINOSDRUGOGSTUPA)
            {
                DDKATEGORIJADataSet.DDKATEGORIJALevel3Row row = (DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) this.NewRow();
                row["IDKATEGORIJA"] = iDKATEGORIJA;
                row["IDDOPRINOS"] = iDDOPRINOS;
                row["DOPRINOSDRUGOGSTUPA"] = dOPRINOSDRUGOGSTUPA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDKATEGORIJADataSet.DDKATEGORIJALevel3DataTable table = (DDKATEGORIJADataSet.DDKATEGORIJALevel3DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel3Row FindByIDKATEGORIJAIDDOPRINOS(int iDKATEGORIJA, int iDDOPRINOS)
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) this.Rows.Find(new object[] { iDKATEGORIJA, iDDOPRINOS });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDKATEGORIJADataSet.DDKATEGORIJALevel3Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDKATEGORIJADataSet set = new DDKATEGORIJADataSet();
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
                this.columnIDKATEGORIJA = new DataColumn("IDKATEGORIJA", typeof(int), "", MappingType.Element);
                this.columnIDKATEGORIJA.AllowDBNull = false;
                this.columnIDKATEGORIJA.Caption = "IDKATEGORIJA";
                this.columnIDKATEGORIJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Length", "5");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKATEGORIJA.ExtendedProperties.Add("Deklarit.InternalName", "IDKATEGORIJA");
                this.Columns.Add(this.columnIDKATEGORIJA);
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
                this.columnNAZIVDOPRINOS.AllowDBNull = true;
                this.columnNAZIVDOPRINOS.Caption = "Naziv doprinosa";
                this.columnNAZIVDOPRINOS.MaxLength = 50;
                this.columnNAZIVDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDOPRINOS");
                this.Columns.Add(this.columnNAZIVDOPRINOS);
                this.columnIDVRSTADOPRINOS = new DataColumn("IDVRSTADOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDVRSTADOPRINOS.AllowDBNull = true;
                this.columnIDVRSTADOPRINOS.Caption = "Šifra vrste doprinosa";
                this.columnIDVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDVRSTADOPRINOS");
                this.Columns.Add(this.columnIDVRSTADOPRINOS);
                this.columnNAZIVVRSTADOPRINOS = new DataColumn("NAZIVVRSTADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTADOPRINOS.AllowDBNull = true;
                this.columnNAZIVVRSTADOPRINOS.Caption = "Naziv vrste doprinosa";
                this.columnNAZIVVRSTADOPRINOS.MaxLength = 50;
                this.columnNAZIVVRSTADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTADOPRINOS");
                this.Columns.Add(this.columnNAZIVVRSTADOPRINOS);
                this.columnMODOPRINOS = new DataColumn("MODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMODOPRINOS.AllowDBNull = true;
                this.columnMODOPRINOS.Caption = "Model odobrenja doprinosa";
                this.columnMODOPRINOS.MaxLength = 2;
                this.columnMODOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnMODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "MODOPRINOS");
                this.Columns.Add(this.columnMODOPRINOS);
                this.columnPODOPRINOS = new DataColumn("PODOPRINOS", typeof(string), "", MappingType.Element);
                this.columnPODOPRINOS.AllowDBNull = true;
                this.columnPODOPRINOS.Caption = "Poziv odobrenja doprinosa";
                this.columnPODOPRINOS.MaxLength = 0x16;
                this.columnPODOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPODOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPODOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "PODOPRINOS");
                this.Columns.Add(this.columnPODOPRINOS);
                this.columnMZDOPRINOS = new DataColumn("MZDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnMZDOPRINOS.AllowDBNull = true;
                this.columnMZDOPRINOS.Caption = "Model zaduženja doprinosa";
                this.columnMZDOPRINOS.MaxLength = 2;
                this.columnMZDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPZDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPRIMATELJDOPRINOS1.AllowDBNull = true;
                this.columnPRIMATELJDOPRINOS1.Caption = "Primatelj doprinosa";
                this.columnPRIMATELJDOPRINOS1.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIMATELJDOPRINOS1.ExtendedProperties.Add("Deklarit.InternalName", "PRIMATELJDOPRINOS1");
                this.Columns.Add(this.columnPRIMATELJDOPRINOS1);
                this.columnPRIMATELJDOPRINOS2 = new DataColumn("PRIMATELJDOPRINOS2", typeof(string), "", MappingType.Element);
                this.columnPRIMATELJDOPRINOS2.AllowDBNull = true;
                this.columnPRIMATELJDOPRINOS2.Caption = "Primatelj doprinosa (2)";
                this.columnPRIMATELJDOPRINOS2.MaxLength = 20;
                this.columnPRIMATELJDOPRINOS2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnSIFRAOPISAPLACANJADOPRINOS.AllowDBNull = true;
                this.columnSIFRAOPISAPLACANJADOPRINOS.Caption = "Šifra opisa plaćanja doprinosa";
                this.columnSIFRAOPISAPLACANJADOPRINOS.MaxLength = 2;
                this.columnSIFRAOPISAPLACANJADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAOPISAPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAOPISAPLACANJADOPRINOS");
                this.Columns.Add(this.columnSIFRAOPISAPLACANJADOPRINOS);
                this.columnOPISPLACANJADOPRINOS = new DataColumn("OPISPLACANJADOPRINOS", typeof(string), "", MappingType.Element);
                this.columnOPISPLACANJADOPRINOS.AllowDBNull = true;
                this.columnOPISPLACANJADOPRINOS.Caption = "Opis plaćanja doprinosa";
                this.columnOPISPLACANJADOPRINOS.MaxLength = 0x24;
                this.columnOPISPLACANJADOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISPLACANJADOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "OPISPLACANJADOPRINOS");
                this.Columns.Add(this.columnOPISPLACANJADOPRINOS);
                this.columnVBDIDOPRINOS = new DataColumn("VBDIDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnVBDIDOPRINOS.AllowDBNull = true;
                this.columnVBDIDOPRINOS.Caption = "VBDI za doprinos";
                this.columnVBDIDOPRINOS.MaxLength = 7;
                this.columnVBDIDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "VBDIDOPRINOS");
                this.Columns.Add(this.columnVBDIDOPRINOS);
                this.columnZRNDOPRINOS = new DataColumn("ZRNDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnZRNDOPRINOS.AllowDBNull = true;
                this.columnZRNDOPRINOS.Caption = "Žiro račun za doprinos";
                this.columnZRNDOPRINOS.MaxLength = 10;
                this.columnZRNDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnZRNDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "ZRNDOPRINOS");
                this.Columns.Add(this.columnZRNDOPRINOS);
                this.columnSTOPA = new DataColumn("STOPA", typeof(decimal), "", MappingType.Element);
                this.columnSTOPA.AllowDBNull = true;
                this.columnSTOPA.Caption = "STOPA";
                this.columnSTOPA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                this.columnSTOPA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPA.ExtendedProperties.Add("Deklarit.InternalName", "STOPA");
                this.Columns.Add(this.columnSTOPA);
                this.columnDOPRINOSDRUGOGSTUPA = new DataColumn("DOPRINOSDRUGOGSTUPA", typeof(bool), "", MappingType.Element);
                this.columnDOPRINOSDRUGOGSTUPA.AllowDBNull = false;
                this.columnDOPRINOSDRUGOGSTUPA.Caption = "DOPRINOSDRUGOGSTUPA";
                this.columnDOPRINOSDRUGOGSTUPA.DefaultValue = false;
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("IsKey", "false");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Description", "VEZA MIO I + MIO II (15+5%)");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Length", "1");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Decimals", "0");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOPRINOSDRUGOGSTUPA.ExtendedProperties.Add("Deklarit.InternalName", "DOPRINOSDRUGOGSTUPA");
                this.Columns.Add(this.columnDOPRINOSDRUGOGSTUPA);
                this.PrimaryKey = new DataColumn[] { this.columnIDKATEGORIJA, this.columnIDDOPRINOS };
                this.ExtendedProperties.Add("ParentLvl", "DDKATEGORIJA");
                this.ExtendedProperties.Add("LevelName", "Level3");
                this.ExtendedProperties.Add("Description", "Doprinosi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDKATEGORIJA = this.Columns["IDKATEGORIJA"];
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
                this.columnDOPRINOSDRUGOGSTUPA = this.Columns["DOPRINOSDRUGOGSTUPA"];
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel3Row NewDDKATEGORIJALevel3Row()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDKATEGORIJADataSet.DDKATEGORIJALevel3Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDKATEGORIJALevel3RowChanged != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler handler = this.DDKATEGORIJALevel3RowChanged;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDKATEGORIJALevel3RowChanging != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler handler = this.DDKATEGORIJALevel3RowChanging;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("DDKATEGORIJA_DDKATEGORIJALevel3", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.DDKATEGORIJALevel3RowDeleted != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler handler = this.DDKATEGORIJALevel3RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDKATEGORIJALevel3RowDeleting != null)
                {
                    DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEventHandler handler = this.DDKATEGORIJALevel3RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEvent((DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDKATEGORIJALevel3Row(DDKATEGORIJADataSet.DDKATEGORIJALevel3Row row)
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

            public DataColumn DOPRINOSDRUGOGSTUPAColumn
            {
                get
                {
                    return this.columnDOPRINOSDRUGOGSTUPA;
                }
            }

            public DataColumn IDDOPRINOSColumn
            {
                get
                {
                    return this.columnIDDOPRINOS;
                }
            }

            public DataColumn IDKATEGORIJAColumn
            {
                get
                {
                    return this.columnIDKATEGORIJA;
                }
            }

            public DataColumn IDVRSTADOPRINOSColumn
            {
                get
                {
                    return this.columnIDVRSTADOPRINOS;
                }
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel3Row this[int index]
            {
                get
                {
                    return (DDKATEGORIJADataSet.DDKATEGORIJALevel3Row) this.Rows[index];
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

        public class DDKATEGORIJALevel3Row : DataRow
        {
            private DDKATEGORIJADataSet.DDKATEGORIJALevel3DataTable tableDDKATEGORIJALevel3;

            internal DDKATEGORIJALevel3Row(DataRowBuilder rb) : base(rb)
            {
                this.tableDDKATEGORIJALevel3 = (DDKATEGORIJADataSet.DDKATEGORIJALevel3DataTable) this.Table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJARow GetDDKATEGORIJARow()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJARow) this.GetParentRow("DDKATEGORIJA_DDKATEGORIJALevel3");
            }

            public bool IsDOPRINOSDRUGOGSTUPANull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.DOPRINOSDRUGOGSTUPAColumn);
            }

            public bool IsIDDOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.IDDOPRINOSColumn);
            }

            public bool IsIDKATEGORIJANull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.IDKATEGORIJAColumn);
            }

            public bool IsIDVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.IDVRSTADOPRINOSColumn);
            }

            public bool IsMODOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.MODOPRINOSColumn);
            }

            public bool IsMZDOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.MZDOPRINOSColumn);
            }

            public bool IsNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.NAZIVDOPRINOSColumn);
            }

            public bool IsNAZIVVRSTADOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.NAZIVVRSTADOPRINOSColumn);
            }

            public bool IsOPISPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.OPISPLACANJADOPRINOSColumn);
            }

            public bool IsPODOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.PODOPRINOSColumn);
            }

            public bool IsPRIMATELJDOPRINOS1Null()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS1Column);
            }

            public bool IsPRIMATELJDOPRINOS2Null()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS2Column);
            }

            public bool IsPZDOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.PZDOPRINOSColumn);
            }

            public bool IsSIFRAOPISAPLACANJADOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.SIFRAOPISAPLACANJADOPRINOSColumn);
            }

            public bool IsSTOPANull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.STOPAColumn);
            }

            public bool IsVBDIDOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.VBDIDOPRINOSColumn);
            }

            public bool IsZRNDOPRINOSNull()
            {
                return this.IsNull(this.tableDDKATEGORIJALevel3.ZRNDOPRINOSColumn);
            }

            public void SetDOPRINOSDRUGOGSTUPANull()
            {
                this[this.tableDDKATEGORIJALevel3.DOPRINOSDRUGOGSTUPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDVRSTADOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.IDVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMODOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.MODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMZDOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.MZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.NAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVVRSTADOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.NAZIVVRSTADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISPLACANJADOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.OPISPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPODOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.PODOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS1Null()
            {
                this[this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIMATELJDOPRINOS2Null()
            {
                this[this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPZDOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.PZDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAOPISAPLACANJADOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.SIFRAOPISAPLACANJADOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPANull()
            {
                this[this.tableDDKATEGORIJALevel3.STOPAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIDOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.VBDIDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNDOPRINOSNull()
            {
                this[this.tableDDKATEGORIJALevel3.ZRNDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool DOPRINOSDRUGOGSTUPA
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDDKATEGORIJALevel3.DOPRINOSDRUGOGSTUPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.DOPRINOSDRUGOGSTUPAColumn] = value;
                }
            }

            public int IDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKATEGORIJALevel3.IDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.IDDOPRINOSColumn] = value;
                }
            }

            public int IDKATEGORIJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKATEGORIJALevel3.IDKATEGORIJAColumn]);
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.IDKATEGORIJAColumn] = value;
                }
            }

            public int IDVRSTADOPRINOS
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDDKATEGORIJALevel3.IDVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.IDVRSTADOPRINOSColumn] = value;
                }
            }

            public string MODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.MODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.MODOPRINOSColumn] = value;
                }
            }

            public string MZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.MZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.MZDOPRINOSColumn] = value;
                }
            }

            public string NAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.NAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.NAZIVDOPRINOSColumn] = value;
                }
            }

            public string NAZIVVRSTADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.NAZIVVRSTADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.NAZIVVRSTADOPRINOSColumn] = value;
                }
            }

            public string OPISPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.OPISPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.OPISPLACANJADOPRINOSColumn] = value;
                }
            }

            public string PODOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.PODOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.PODOPRINOSColumn] = value;
                }
            }

            public string PRIMATELJDOPRINOS1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS1Column] = value;
                }
            }

            public string PRIMATELJDOPRINOS2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.PRIMATELJDOPRINOS2Column] = value;
                }
            }

            public string PZDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.PZDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.PZDOPRINOSColumn] = value;
                }
            }

            public string SIFRAOPISAPLACANJADOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.SIFRAOPISAPLACANJADOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.SIFRAOPISAPLACANJADOPRINOSColumn] = value;
                }
            }

            public decimal STOPA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableDDKATEGORIJALevel3.STOPAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.STOPAColumn] = value;
                }
            }

            public string VBDIDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.VBDIDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.VBDIDOPRINOSColumn] = value;
                }
            }

            public string ZRNDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJALevel3.ZRNDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJALevel3.ZRNDOPRINOSColumn] = value;
                }
            }
        }

        public class DDKATEGORIJALevel3RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDKATEGORIJADataSet.DDKATEGORIJALevel3Row eventRow;

            public DDKATEGORIJALevel3RowChangeEvent(DDKATEGORIJADataSet.DDKATEGORIJALevel3Row row, DataRowAction action)
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

            public DDKATEGORIJADataSet.DDKATEGORIJALevel3Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDKATEGORIJALevel3RowChangeEventHandler(object sender, DDKATEGORIJADataSet.DDKATEGORIJALevel3RowChangeEvent e);

        public class DDKATEGORIJARow : DataRow
        {
            private DDKATEGORIJADataSet.DDKATEGORIJADataTable tableDDKATEGORIJA;

            internal DDKATEGORIJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDKATEGORIJA = (DDKATEGORIJADataSet.DDKATEGORIJADataTable) this.Table;
            }

            public DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow[] GetDDKATEGORIJAIzdaciRows()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow[]) this.GetChildRows("DDKATEGORIJA_DDKATEGORIJAIzdaci");
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel1Row[] GetDDKATEGORIJALevel1Rows()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJALevel1Row[]) this.GetChildRows("DDKATEGORIJA_DDKATEGORIJALevel1");
            }

            public DDKATEGORIJADataSet.DDKATEGORIJALevel3Row[] GetDDKATEGORIJALevel3Rows()
            {
                return (DDKATEGORIJADataSet.DDKATEGORIJALevel3Row[]) this.GetChildRows("DDKATEGORIJA_DDKATEGORIJALevel3");
            }

            public bool IsIDKATEGORIJANull()
            {
                return this.IsNull(this.tableDDKATEGORIJA.IDKATEGORIJAColumn);
            }

            public bool IsIDKOLONAIDDNull()
            {
                return this.IsNull(this.tableDDKATEGORIJA.IDKOLONAIDDColumn);
            }

            public bool IsNAZIVKATEGORIJANull()
            {
                return this.IsNull(this.tableDDKATEGORIJA.NAZIVKATEGORIJAColumn);
            }

            public bool IsNAZIVKOLONAIDDNull()
            {
                return this.IsNull(this.tableDDKATEGORIJA.NAZIVKOLONAIDDColumn);
            }

            public void SetIDKOLONAIDDNull()
            {
                this[this.tableDDKATEGORIJA.IDKOLONAIDDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKATEGORIJANull()
            {
                this[this.tableDDKATEGORIJA.NAZIVKATEGORIJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKOLONAIDDNull()
            {
                this[this.tableDDKATEGORIJA.NAZIVKOLONAIDDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDKATEGORIJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKATEGORIJA.IDKATEGORIJAColumn]);
                }
                set
                {
                    this[this.tableDDKATEGORIJA.IDKATEGORIJAColumn] = value;
                }
            }

            public int IDKOLONAIDD
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDDKATEGORIJA.IDKOLONAIDDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableDDKATEGORIJA.IDKOLONAIDDColumn] = value;
                }
            }

            public string NAZIVKATEGORIJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJA.NAZIVKATEGORIJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJA.NAZIVKATEGORIJAColumn] = value;
                }
            }

            public string NAZIVKOLONAIDD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKATEGORIJA.NAZIVKOLONAIDDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKATEGORIJA.NAZIVKOLONAIDDColumn] = value;
                }
            }
        }

        public class DDKATEGORIJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDKATEGORIJADataSet.DDKATEGORIJARow eventRow;

            public DDKATEGORIJARowChangeEvent(DDKATEGORIJADataSet.DDKATEGORIJARow row, DataRowAction action)
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

            public DDKATEGORIJADataSet.DDKATEGORIJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDKATEGORIJARowChangeEventHandler(object sender, DDKATEGORIJADataSet.DDKATEGORIJARowChangeEvent e);
    }
}

