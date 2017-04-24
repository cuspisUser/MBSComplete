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
    public class SHEMAPLACADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SHEMAPLACADataTable tableSHEMAPLACA;
        private SHEMAPLACASHEMAPLACADOPDataTable tableSHEMAPLACASHEMAPLACADOP;
        private SHEMAPLACASHEMAPLACAELEMENTDataTable tableSHEMAPLACASHEMAPLACAELEMENT;
        private SHEMAPLACASHEMAPLACASTANDARDDataTable tableSHEMAPLACASHEMAPLACASTANDARD;

        public SHEMAPLACADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SHEMAPLACADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SHEMAPLACASHEMAPLACASTANDARD"] != null)
                    {
                        this.Tables.Add(new SHEMAPLACASHEMAPLACASTANDARDDataTable(dataSet.Tables["SHEMAPLACASHEMAPLACASTANDARD"]));
                    }
                    if (dataSet.Tables["SHEMAPLACASHEMAPLACAELEMENT"] != null)
                    {
                        this.Tables.Add(new SHEMAPLACASHEMAPLACAELEMENTDataTable(dataSet.Tables["SHEMAPLACASHEMAPLACAELEMENT"]));
                    }
                    if (dataSet.Tables["SHEMAPLACASHEMAPLACADOP"] != null)
                    {
                        this.Tables.Add(new SHEMAPLACASHEMAPLACADOPDataTable(dataSet.Tables["SHEMAPLACASHEMAPLACADOP"]));
                    }
                    if (dataSet.Tables["SHEMAPLACA"] != null)
                    {
                        this.Tables.Add(new SHEMAPLACADataTable(dataSet.Tables["SHEMAPLACA"]));
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
            SHEMAPLACADataSet set = (SHEMAPLACADataSet) base.Clone();
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
            SHEMAPLACADataSet set = new SHEMAPLACADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SHEMAPLACADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2116");
            this.ExtendedProperties.Add("DataSetName", "SHEMAPLACADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISHEMAPLACADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SHEMAPLACA");
            this.ExtendedProperties.Add("ObjectDescription", "Shema place");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
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
            this.DataSetName = "SHEMAPLACADataSet";
            this.Namespace = "http://www.tempuri.org/SHEMAPLACA";
            this.tableSHEMAPLACASHEMAPLACASTANDARD = new SHEMAPLACASHEMAPLACASTANDARDDataTable();
            this.Tables.Add(this.tableSHEMAPLACASHEMAPLACASTANDARD);
            this.tableSHEMAPLACASHEMAPLACAELEMENT = new SHEMAPLACASHEMAPLACAELEMENTDataTable();
            this.Tables.Add(this.tableSHEMAPLACASHEMAPLACAELEMENT);
            this.tableSHEMAPLACASHEMAPLACADOP = new SHEMAPLACASHEMAPLACADOPDataTable();
            this.Tables.Add(this.tableSHEMAPLACASHEMAPLACADOP);
            this.tableSHEMAPLACA = new SHEMAPLACADataTable();
            this.Tables.Add(this.tableSHEMAPLACA);
            this.Relations.Add("SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD", new DataColumn[] { this.Tables["SHEMAPLACA"].Columns["IDSHEMAPLACA"] }, new DataColumn[] { this.Tables["SHEMAPLACASHEMAPLACASTANDARD"].Columns["IDSHEMAPLACA"] });
            this.Relations["SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD"].Nested = true;
            this.Relations.Add("SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT", new DataColumn[] { this.Tables["SHEMAPLACA"].Columns["IDSHEMAPLACA"] }, new DataColumn[] { this.Tables["SHEMAPLACASHEMAPLACAELEMENT"].Columns["IDSHEMAPLACA"] });
            this.Relations["SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT"].Nested = true;
            this.Relations.Add("SHEMAPLACA_SHEMAPLACASHEMAPLACADOP", new DataColumn[] { this.Tables["SHEMAPLACA"].Columns["IDSHEMAPLACA"] }, new DataColumn[] { this.Tables["SHEMAPLACASHEMAPLACADOP"].Columns["IDSHEMAPLACA"] });
            this.Relations["SHEMAPLACA_SHEMAPLACASHEMAPLACADOP"].Nested = true;
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
            this.tableSHEMAPLACASHEMAPLACASTANDARD = (SHEMAPLACASHEMAPLACASTANDARDDataTable) this.Tables["SHEMAPLACASHEMAPLACASTANDARD"];
            this.tableSHEMAPLACASHEMAPLACAELEMENT = (SHEMAPLACASHEMAPLACAELEMENTDataTable) this.Tables["SHEMAPLACASHEMAPLACAELEMENT"];
            this.tableSHEMAPLACASHEMAPLACADOP = (SHEMAPLACASHEMAPLACADOPDataTable) this.Tables["SHEMAPLACASHEMAPLACADOP"];
            this.tableSHEMAPLACA = (SHEMAPLACADataTable) this.Tables["SHEMAPLACA"];
            if (initTable)
            {
                if (this.tableSHEMAPLACASHEMAPLACASTANDARD != null)
                {
                    this.tableSHEMAPLACASHEMAPLACASTANDARD.InitVars();
                }
                if (this.tableSHEMAPLACASHEMAPLACAELEMENT != null)
                {
                    this.tableSHEMAPLACASHEMAPLACAELEMENT.InitVars();
                }
                if (this.tableSHEMAPLACASHEMAPLACADOP != null)
                {
                    this.tableSHEMAPLACASHEMAPLACADOP.InitVars();
                }
                if (this.tableSHEMAPLACA != null)
                {
                    this.tableSHEMAPLACA.InitVars();
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
                if (dataSet.Tables["SHEMAPLACASHEMAPLACASTANDARD"] != null)
                {
                    this.Tables.Add(new SHEMAPLACASHEMAPLACASTANDARDDataTable(dataSet.Tables["SHEMAPLACASHEMAPLACASTANDARD"]));
                }
                if (dataSet.Tables["SHEMAPLACASHEMAPLACAELEMENT"] != null)
                {
                    this.Tables.Add(new SHEMAPLACASHEMAPLACAELEMENTDataTable(dataSet.Tables["SHEMAPLACASHEMAPLACAELEMENT"]));
                }
                if (dataSet.Tables["SHEMAPLACASHEMAPLACADOP"] != null)
                {
                    this.Tables.Add(new SHEMAPLACASHEMAPLACADOPDataTable(dataSet.Tables["SHEMAPLACASHEMAPLACADOP"]));
                }
                if (dataSet.Tables["SHEMAPLACA"] != null)
                {
                    this.Tables.Add(new SHEMAPLACADataTable(dataSet.Tables["SHEMAPLACA"]));
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

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        private bool ShouldSerializeSHEMAPLACA()
        {
            return false;
        }

        private bool ShouldSerializeSHEMAPLACASHEMAPLACADOP()
        {
            return false;
        }

        private bool ShouldSerializeSHEMAPLACASHEMAPLACAELEMENT()
        {
            return false;
        }

        private bool ShouldSerializeSHEMAPLACASHEMAPLACASTANDARD()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMAPLACADataTable SHEMAPLACA
        {
            get
            {
                return this.tableSHEMAPLACA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMAPLACASHEMAPLACADOPDataTable SHEMAPLACASHEMAPLACADOP
        {
            get
            {
                return this.tableSHEMAPLACASHEMAPLACADOP;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMAPLACASHEMAPLACAELEMENTDataTable SHEMAPLACASHEMAPLACAELEMENT
        {
            get
            {
                return this.tableSHEMAPLACASHEMAPLACAELEMENT;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMAPLACASHEMAPLACASTANDARDDataTable SHEMAPLACASHEMAPLACASTANDARD
        {
            get
            {
                return this.tableSHEMAPLACASHEMAPLACASTANDARD;
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
        public class SHEMAPLACADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMAPLACA;
            private DataColumn columnNAZIVSHEMAPLACA;
            private DataColumn columnSHEMAPLOJIDORGJED;

            public event SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler SHEMAPLACARowChanged;

            public event SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler SHEMAPLACARowChanging;

            public event SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler SHEMAPLACARowDeleted;

            public event SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler SHEMAPLACARowDeleting;

            public SHEMAPLACADataTable()
            {
                this.TableName = "SHEMAPLACA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAPLACADataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAPLACADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAPLACARow(SHEMAPLACADataSet.SHEMAPLACARow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAPLACADataSet.SHEMAPLACARow AddSHEMAPLACARow(int iDSHEMAPLACA, string nAZIVSHEMAPLACA, int sHEMAPLOJIDORGJED)
            {
                SHEMAPLACADataSet.SHEMAPLACARow row = (SHEMAPLACADataSet.SHEMAPLACARow) this.NewRow();
                row["IDSHEMAPLACA"] = iDSHEMAPLACA;
                row["NAZIVSHEMAPLACA"] = nAZIVSHEMAPLACA;
                row["SHEMAPLOJIDORGJED"] = sHEMAPLOJIDORGJED;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAPLACADataSet.SHEMAPLACADataTable table = (SHEMAPLACADataSet.SHEMAPLACADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAPLACADataSet.SHEMAPLACARow FindByIDSHEMAPLACA(int iDSHEMAPLACA)
            {
                return (SHEMAPLACADataSet.SHEMAPLACARow) this.Rows.Find(new object[] { iDSHEMAPLACA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAPLACADataSet.SHEMAPLACARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAPLACADataSet set = new SHEMAPLACADataSet();
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
                this.columnIDSHEMAPLACA = new DataColumn("IDSHEMAPLACA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAPLACA.AllowDBNull = false;
                this.columnIDSHEMAPLACA.Caption = "IDSHEMAPLACA";
                this.columnIDSHEMAPLACA.Unique = true;
                this.columnIDSHEMAPLACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAPLACA");
                this.Columns.Add(this.columnIDSHEMAPLACA);
                this.columnNAZIVSHEMAPLACA = new DataColumn("NAZIVSHEMAPLACA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSHEMAPLACA.AllowDBNull = false;
                this.columnNAZIVSHEMAPLACA.Caption = "NAZIVSHEMAPLACA";
                this.columnNAZIVSHEMAPLACA.MaxLength = 50;
                this.columnNAZIVSHEMAPLACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSHEMAPLACA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSHEMAPLACA");
                this.Columns.Add(this.columnNAZIVSHEMAPLACA);
                this.columnSHEMAPLOJIDORGJED = new DataColumn("SHEMAPLOJIDORGJED", typeof(int), "", MappingType.Element);
                this.columnSHEMAPLOJIDORGJED.AllowDBNull = false;
                this.columnSHEMAPLOJIDORGJED.Caption = "Šifra OJ";
                this.columnSHEMAPLOJIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("SubtypeGroup", "SHEMAPLOJ");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Description", "Organiz. jed.");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAPLOJIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAPLOJIDORGJED");
                this.Columns.Add(this.columnSHEMAPLOJIDORGJED);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAPLACA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SHEMAPLACA");
                this.ExtendedProperties.Add("Description", "Shema place");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAPLACA = this.Columns["IDSHEMAPLACA"];
                this.columnNAZIVSHEMAPLACA = this.Columns["NAZIVSHEMAPLACA"];
                this.columnSHEMAPLOJIDORGJED = this.Columns["SHEMAPLOJIDORGJED"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAPLACADataSet.SHEMAPLACARow(builder);
            }

            public SHEMAPLACADataSet.SHEMAPLACARow NewSHEMAPLACARow()
            {
                return (SHEMAPLACADataSet.SHEMAPLACARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAPLACARowChanged != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler sHEMAPLACARowChangedEvent = this.SHEMAPLACARowChanged;
                    if (sHEMAPLACARowChangedEvent != null)
                    {
                        sHEMAPLACARowChangedEvent(this, new SHEMAPLACADataSet.SHEMAPLACARowChangeEvent((SHEMAPLACADataSet.SHEMAPLACARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAPLACARowChanging != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler sHEMAPLACARowChangingEvent = this.SHEMAPLACARowChanging;
                    if (sHEMAPLACARowChangingEvent != null)
                    {
                        sHEMAPLACARowChangingEvent(this, new SHEMAPLACADataSet.SHEMAPLACARowChangeEvent((SHEMAPLACADataSet.SHEMAPLACARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SHEMAPLACARowDeleted != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler sHEMAPLACARowDeletedEvent = this.SHEMAPLACARowDeleted;
                    if (sHEMAPLACARowDeletedEvent != null)
                    {
                        sHEMAPLACARowDeletedEvent(this, new SHEMAPLACADataSet.SHEMAPLACARowChangeEvent((SHEMAPLACADataSet.SHEMAPLACARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAPLACARowDeleting != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACARowChangeEventHandler sHEMAPLACARowDeletingEvent = this.SHEMAPLACARowDeleting;
                    if (sHEMAPLACARowDeletingEvent != null)
                    {
                        sHEMAPLACARowDeletingEvent(this, new SHEMAPLACADataSet.SHEMAPLACARowChangeEvent((SHEMAPLACADataSet.SHEMAPLACARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAPLACARow(SHEMAPLACADataSet.SHEMAPLACARow row)
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

            public DataColumn IDSHEMAPLACAColumn
            {
                get
                {
                    return this.columnIDSHEMAPLACA;
                }
            }

            public SHEMAPLACADataSet.SHEMAPLACARow this[int index]
            {
                get
                {
                    return (SHEMAPLACADataSet.SHEMAPLACARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSHEMAPLACAColumn
            {
                get
                {
                    return this.columnNAZIVSHEMAPLACA;
                }
            }

            public DataColumn SHEMAPLOJIDORGJEDColumn
            {
                get
                {
                    return this.columnSHEMAPLOJIDORGJED;
                }
            }
        }

        public class SHEMAPLACARow : DataRow
        {
            private SHEMAPLACADataSet.SHEMAPLACADataTable tableSHEMAPLACA;

            internal SHEMAPLACARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAPLACA = (SHEMAPLACADataSet.SHEMAPLACADataTable) this.Table;
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow[] GetSHEMAPLACASHEMAPLACADOPRows()
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow[]) this.GetChildRows("SHEMAPLACA_SHEMAPLACASHEMAPLACADOP");
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow[] GetSHEMAPLACASHEMAPLACAELEMENTRows()
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow[]) this.GetChildRows("SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT");
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow[] GetSHEMAPLACASHEMAPLACASTANDARDRows()
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow[]) this.GetChildRows("SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD");
            }

            public bool IsIDSHEMAPLACANull()
            {
                return this.IsNull(this.tableSHEMAPLACA.IDSHEMAPLACAColumn);
            }

            public bool IsNAZIVSHEMAPLACANull()
            {
                return this.IsNull(this.tableSHEMAPLACA.NAZIVSHEMAPLACAColumn);
            }

            public bool IsSHEMAPLOJIDORGJEDNull()
            {
                return this.IsNull(this.tableSHEMAPLACA.SHEMAPLOJIDORGJEDColumn);
            }

            public void SetNAZIVSHEMAPLACANull()
            {
                this[this.tableSHEMAPLACA.NAZIVSHEMAPLACAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAPLOJIDORGJEDNull()
            {
                this[this.tableSHEMAPLACA.SHEMAPLOJIDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMAPLACA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAPLACA.IDSHEMAPLACAColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACA.IDSHEMAPLACAColumn] = value;
                }
            }

            public string NAZIVSHEMAPLACA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMAPLACA.NAZIVSHEMAPLACAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSHEMAPLACA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMAPLACA.NAZIVSHEMAPLACAColumn] = value;
                }
            }

            public int SHEMAPLOJIDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAPLACA.SHEMAPLOJIDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        ////InvalidCastException innerException = exception1;
                        ////throw new StrongTypingException("Cannot get value SHEMAPLOJIDORGJED because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACA.SHEMAPLOJIDORGJEDColumn] = value;
                }
            }
        }

        public class SHEMAPLACARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAPLACADataSet.SHEMAPLACARow eventRow;

            public SHEMAPLACARowChangeEvent(SHEMAPLACADataSet.SHEMAPLACARow row, DataRowAction action)
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

            public SHEMAPLACADataSet.SHEMAPLACARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAPLACARowChangeEventHandler(object sender, SHEMAPLACADataSet.SHEMAPLACARowChangeEvent e);

        [Serializable]
        public class SHEMAPLACASHEMAPLACADOPDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMAPLACA;
            private DataColumn columnKONTODOPIDKONTO;
            private DataColumn columnMTDOPIDMJESTOTROSKA;
            private DataColumn columnSHEMAPLDOPIDDOPRINOS;
            private DataColumn columnSHEMAPLDOPNAZIVDOPRINOS;
            private DataColumn columnSTRANEDOPIDSTRANEKNJIZENJA;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler SHEMAPLACASHEMAPLACADOPRowChanged;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler SHEMAPLACASHEMAPLACADOPRowChanging;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler SHEMAPLACASHEMAPLACADOPRowDeleted;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler SHEMAPLACASHEMAPLACADOPRowDeleting;

            public SHEMAPLACASHEMAPLACADOPDataTable()
            {
                this.TableName = "SHEMAPLACASHEMAPLACADOP";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAPLACASHEMAPLACADOPDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAPLACASHEMAPLACADOPDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAPLACASHEMAPLACADOPRow(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow AddSHEMAPLACASHEMAPLACADOPRow(int iDSHEMAPLACA, int sHEMAPLDOPIDDOPRINOS, string kONTODOPIDKONTO, int mTDOPIDMJESTOTROSKA, int sTRANEDOPIDSTRANEKNJIZENJA)
            {
                SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow row = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) this.NewRow();
                row["IDSHEMAPLACA"] = iDSHEMAPLACA;
                row["SHEMAPLDOPIDDOPRINOS"] = sHEMAPLDOPIDDOPRINOS;
                row["KONTODOPIDKONTO"] = kONTODOPIDKONTO;
                row["MTDOPIDMJESTOTROSKA"] = mTDOPIDMJESTOTROSKA;
                row["STRANEDOPIDSTRANEKNJIZENJA"] = sTRANEDOPIDSTRANEKNJIZENJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPDataTable table = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow FindByIDSHEMAPLACASHEMAPLDOPIDDOPRINOSKONTODOPIDKONTO(int iDSHEMAPLACA, int sHEMAPLDOPIDDOPRINOS, string kONTODOPIDKONTO)
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) this.Rows.Find(new object[] { iDSHEMAPLACA, sHEMAPLDOPIDDOPRINOS, kONTODOPIDKONTO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAPLACADataSet set = new SHEMAPLACADataSet();
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
                this.columnIDSHEMAPLACA = new DataColumn("IDSHEMAPLACA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAPLACA.AllowDBNull = false;
                this.columnIDSHEMAPLACA.Caption = "IDSHEMAPLACA";
                this.columnIDSHEMAPLACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAPLACA");
                this.Columns.Add(this.columnIDSHEMAPLACA);
                this.columnSHEMAPLDOPIDDOPRINOS = new DataColumn("SHEMAPLDOPIDDOPRINOS", typeof(int), "", MappingType.Element);
                this.columnSHEMAPLDOPIDDOPRINOS.AllowDBNull = false;
                this.columnSHEMAPLDOPIDDOPRINOS.Caption = "Šifra doprinosa";
                this.columnSHEMAPLDOPIDDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("SuperType", "IDDOPRINOS");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("SubtypeGroup", "SHEMAPLDOP");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Description", "Šifra doprinosa");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAPLDOPIDDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAPLDOPIDDOPRINOS");
                this.Columns.Add(this.columnSHEMAPLDOPIDDOPRINOS);
                this.columnKONTODOPIDKONTO = new DataColumn("KONTODOPIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKONTODOPIDKONTO.AllowDBNull = false;
                this.columnKONTODOPIDKONTO.Caption = "Konto";
                this.columnKONTODOPIDKONTO.MaxLength = 14;
                this.columnKONTODOPIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KONTODOP");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTODOPIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KONTODOPIDKONTO");
                this.Columns.Add(this.columnKONTODOPIDKONTO);
                this.columnMTDOPIDMJESTOTROSKA = new DataColumn("MTDOPIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnMTDOPIDMJESTOTROSKA.AllowDBNull = false;
                this.columnMTDOPIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnMTDOPIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "MTDOP");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Mjesto troška");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMTDOPIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "MTDOPIDMJESTOTROSKA");
                this.Columns.Add(this.columnMTDOPIDMJESTOTROSKA);
                this.columnSTRANEDOPIDSTRANEKNJIZENJA = new DataColumn("STRANEDOPIDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.Caption = "Šifra strane";
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("SuperType", "IDSTRANEKNJIZENJA");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("SubtypeGroup", "STRANEDOP");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Strana knjiženja");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTRANEDOPIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "STRANEDOPIDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnSTRANEDOPIDSTRANEKNJIZENJA);
                this.columnSHEMAPLDOPNAZIVDOPRINOS = new DataColumn("SHEMAPLDOPNAZIVDOPRINOS", typeof(string), "", MappingType.Element);
                this.columnSHEMAPLDOPNAZIVDOPRINOS.AllowDBNull = true;
                this.columnSHEMAPLDOPNAZIVDOPRINOS.Caption = "Naziv doprinosa";
                this.columnSHEMAPLDOPNAZIVDOPRINOS.MaxLength = 50;
                this.columnSHEMAPLDOPNAZIVDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("SuperType", "NAZIVDOPRINOS");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("SubtypeGroup", "SHEMAPLDOP");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Description", "Naziv doprinosa");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Length", "50");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAPLDOPNAZIVDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAPLDOPNAZIVDOPRINOS");
                this.Columns.Add(this.columnSHEMAPLDOPNAZIVDOPRINOS);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAPLACA, this.columnSHEMAPLDOPIDDOPRINOS, this.columnKONTODOPIDKONTO };
                this.ExtendedProperties.Add("ParentLvl", "SHEMAPLACA");
                this.ExtendedProperties.Add("LevelName", "SHEMAPLACADOP");
                this.ExtendedProperties.Add("Description", "Doprinosi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAPLACA = this.Columns["IDSHEMAPLACA"];
                this.columnSHEMAPLDOPIDDOPRINOS = this.Columns["SHEMAPLDOPIDDOPRINOS"];
                this.columnKONTODOPIDKONTO = this.Columns["KONTODOPIDKONTO"];
                this.columnMTDOPIDMJESTOTROSKA = this.Columns["MTDOPIDMJESTOTROSKA"];
                this.columnSTRANEDOPIDSTRANEKNJIZENJA = this.Columns["STRANEDOPIDSTRANEKNJIZENJA"];
                this.columnSHEMAPLDOPNAZIVDOPRINOS = this.Columns["SHEMAPLDOPNAZIVDOPRINOS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow(builder);
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow NewSHEMAPLACASHEMAPLACADOPRow()
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAPLACASHEMAPLACADOPRowChanged != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler sHEMAPLACASHEMAPLACADOPRowChangedEvent = this.SHEMAPLACASHEMAPLACADOPRowChanged;
                    if (sHEMAPLACASHEMAPLACADOPRowChangedEvent != null)
                    {
                        sHEMAPLACASHEMAPLACADOPRowChangedEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAPLACASHEMAPLACADOPRowChanging != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler sHEMAPLACASHEMAPLACADOPRowChangingEvent = this.SHEMAPLACASHEMAPLACADOPRowChanging;
                    if (sHEMAPLACASHEMAPLACADOPRowChangingEvent != null)
                    {
                        sHEMAPLACASHEMAPLACADOPRowChangingEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SHEMAPLACA_SHEMAPLACASHEMAPLACADOP", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SHEMAPLACASHEMAPLACADOPRowDeleted != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler sHEMAPLACASHEMAPLACADOPRowDeletedEvent = this.SHEMAPLACASHEMAPLACADOPRowDeleted;
                    if (sHEMAPLACASHEMAPLACADOPRowDeletedEvent != null)
                    {
                        sHEMAPLACASHEMAPLACADOPRowDeletedEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAPLACASHEMAPLACADOPRowDeleting != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEventHandler sHEMAPLACASHEMAPLACADOPRowDeletingEvent = this.SHEMAPLACASHEMAPLACADOPRowDeleting;
                    if (sHEMAPLACASHEMAPLACADOPRowDeletingEvent != null)
                    {
                        sHEMAPLACASHEMAPLACADOPRowDeletingEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAPLACASHEMAPLACADOPRow(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow row)
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

            public DataColumn IDSHEMAPLACAColumn
            {
                get
                {
                    return this.columnIDSHEMAPLACA;
                }
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow this[int index]
            {
                get
                {
                    return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) this.Rows[index];
                }
            }

            public DataColumn KONTODOPIDKONTOColumn
            {
                get
                {
                    return this.columnKONTODOPIDKONTO;
                }
            }

            public DataColumn MTDOPIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnMTDOPIDMJESTOTROSKA;
                }
            }

            public DataColumn SHEMAPLDOPIDDOPRINOSColumn
            {
                get
                {
                    return this.columnSHEMAPLDOPIDDOPRINOS;
                }
            }

            public DataColumn SHEMAPLDOPNAZIVDOPRINOSColumn
            {
                get
                {
                    return this.columnSHEMAPLDOPNAZIVDOPRINOS;
                }
            }

            public DataColumn STRANEDOPIDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnSTRANEDOPIDSTRANEKNJIZENJA;
                }
            }
        }

        public class SHEMAPLACASHEMAPLACADOPRow : DataRow
        {
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPDataTable tableSHEMAPLACASHEMAPLACADOP;

            internal SHEMAPLACASHEMAPLACADOPRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAPLACASHEMAPLACADOP = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPDataTable) this.Table;
            }

            public SHEMAPLACADataSet.SHEMAPLACARow GetSHEMAPLACARow()
            {
                return (SHEMAPLACADataSet.SHEMAPLACARow) this.GetParentRow("SHEMAPLACA_SHEMAPLACASHEMAPLACADOP");
            }

            public bool IsIDSHEMAPLACANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACADOP.IDSHEMAPLACAColumn);
            }

            public bool IsKONTODOPIDKONTONull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACADOP.KONTODOPIDKONTOColumn);
            }

            public bool IsMTDOPIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACADOP.MTDOPIDMJESTOTROSKAColumn);
            }

            public bool IsSHEMAPLDOPIDDOPRINOSNull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACADOP.SHEMAPLDOPIDDOPRINOSColumn);
            }

            public bool IsSHEMAPLDOPNAZIVDOPRINOSNull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACADOP.SHEMAPLDOPNAZIVDOPRINOSColumn);
            }

            public bool IsSTRANEDOPIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACADOP.STRANEDOPIDSTRANEKNJIZENJAColumn);
            }

            public void SetMTDOPIDMJESTOTROSKANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACADOP.MTDOPIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAPLDOPNAZIVDOPRINOSNull()
            {
                this[this.tableSHEMAPLACASHEMAPLACADOP.SHEMAPLDOPNAZIVDOPRINOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTRANEDOPIDSTRANEKNJIZENJANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACADOP.STRANEDOPIDSTRANEKNJIZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMAPLACA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACADOP.IDSHEMAPLACAColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACADOP.IDSHEMAPLACAColumn] = value;
                }
            }

            public string KONTODOPIDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableSHEMAPLACASHEMAPLACADOP.KONTODOPIDKONTOColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACADOP.KONTODOPIDKONTOColumn] = value;
                }
            }

            public int MTDOPIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACADOP.MTDOPIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MTDOPIDMJESTOTROSKA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACADOP.MTDOPIDMJESTOTROSKAColumn] = value;
                }
            }

            public int SHEMAPLDOPIDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACADOP.SHEMAPLDOPIDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACADOP.SHEMAPLDOPIDDOPRINOSColumn] = value;
                }
            }

            public string SHEMAPLDOPNAZIVDOPRINOS
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMAPLACASHEMAPLACADOP.SHEMAPLDOPNAZIVDOPRINOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value SHEMAPLDOPNAZIVDOPRINOS because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACADOP.SHEMAPLDOPNAZIVDOPRINOSColumn] = value;
                }
            }

            public int STRANEDOPIDSTRANEKNJIZENJA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACADOP.STRANEDOPIDSTRANEKNJIZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value STRANEDOPIDSTRANEKNJIZENJA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACADOP.STRANEDOPIDSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class SHEMAPLACASHEMAPLACADOPRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow eventRow;

            public SHEMAPLACASHEMAPLACADOPRowChangeEvent(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow row, DataRowAction action)
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

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAPLACASHEMAPLACADOPRowChangeEventHandler(object sender, SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRowChangeEvent e);

        [Serializable]
        public class SHEMAPLACASHEMAPLACAELEMENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMAPLACA;
            private DataColumn columnKONTOELEMENTIDKONTO;
            private DataColumn columnMTELEMENTIDMJESTOTROSKA;
            private DataColumn columnSHEMAPLELEMENTIDELEMENT;
            private DataColumn columnSHEMAPLELEMENTIDVRSTAELEMENTA;
            private DataColumn columnSHEMAPLELEMENTNAZIVELEMENT;
            private DataColumn columnSTRANEELEMENTIDSTRANEKNJIZENJA;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler SHEMAPLACASHEMAPLACAELEMENTRowChanged;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler SHEMAPLACASHEMAPLACAELEMENTRowChanging;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler SHEMAPLACASHEMAPLACAELEMENTRowDeleted;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler SHEMAPLACASHEMAPLACAELEMENTRowDeleting;

            public SHEMAPLACASHEMAPLACAELEMENTDataTable()
            {
                this.TableName = "SHEMAPLACASHEMAPLACAELEMENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAPLACASHEMAPLACAELEMENTDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAPLACASHEMAPLACAELEMENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAPLACASHEMAPLACAELEMENTRow(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow AddSHEMAPLACASHEMAPLACAELEMENTRow(int iDSHEMAPLACA, int sHEMAPLELEMENTIDELEMENT, string kONTOELEMENTIDKONTO, int sTRANEELEMENTIDSTRANEKNJIZENJA, int mTELEMENTIDMJESTOTROSKA)
            {
                SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow row = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) this.NewRow();
                row["IDSHEMAPLACA"] = iDSHEMAPLACA;
                row["SHEMAPLELEMENTIDELEMENT"] = sHEMAPLELEMENTIDELEMENT;
                row["KONTOELEMENTIDKONTO"] = kONTOELEMENTIDKONTO;
                row["STRANEELEMENTIDSTRANEKNJIZENJA"] = sTRANEELEMENTIDSTRANEKNJIZENJA;
                row["MTELEMENTIDMJESTOTROSKA"] = mTELEMENTIDMJESTOTROSKA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTDataTable table = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow FindByIDSHEMAPLACASHEMAPLELEMENTIDELEMENTKONTOELEMENTIDKONTOSTRANEELEMENTIDSTRANEKNJIZENJA(int iDSHEMAPLACA, int sHEMAPLELEMENTIDELEMENT, string kONTOELEMENTIDKONTO, int sTRANEELEMENTIDSTRANEKNJIZENJA)
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) this.Rows.Find(new object[] { iDSHEMAPLACA, sHEMAPLELEMENTIDELEMENT, kONTOELEMENTIDKONTO, sTRANEELEMENTIDSTRANEKNJIZENJA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAPLACADataSet set = new SHEMAPLACADataSet();
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
                this.columnIDSHEMAPLACA = new DataColumn("IDSHEMAPLACA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAPLACA.AllowDBNull = false;
                this.columnIDSHEMAPLACA.Caption = "IDSHEMAPLACA";
                this.columnIDSHEMAPLACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAPLACA");
                this.Columns.Add(this.columnIDSHEMAPLACA);
                this.columnSHEMAPLELEMENTIDELEMENT = new DataColumn("SHEMAPLELEMENTIDELEMENT", typeof(int), "", MappingType.Element);
                this.columnSHEMAPLELEMENTIDELEMENT.AllowDBNull = false;
                this.columnSHEMAPLELEMENTIDELEMENT.Caption = "Šifra elementa";
                this.columnSHEMAPLELEMENTIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("SuperType", "IDELEMENT");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("SubtypeGroup", "SHEMAPLELEMENT");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAPLELEMENTIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAPLELEMENTIDELEMENT");
                this.Columns.Add(this.columnSHEMAPLELEMENTIDELEMENT);
                this.columnKONTOELEMENTIDKONTO = new DataColumn("KONTOELEMENTIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKONTOELEMENTIDKONTO.AllowDBNull = false;
                this.columnKONTOELEMENTIDKONTO.Caption = "Konto";
                this.columnKONTOELEMENTIDKONTO.MaxLength = 14;
                this.columnKONTOELEMENTIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KONTOELEMENT");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTOELEMENTIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KONTOELEMENTIDKONTO");
                this.Columns.Add(this.columnKONTOELEMENTIDKONTO);
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA = new DataColumn("STRANEELEMENTIDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.Caption = "Šifra strane";
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("SuperType", "IDSTRANEKNJIZENJA");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("SubtypeGroup", "STRANEELEMENT");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "true");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Strana knjiženja");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "STRANEELEMENTIDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnSTRANEELEMENTIDSTRANEKNJIZENJA);
                this.columnMTELEMENTIDMJESTOTROSKA = new DataColumn("MTELEMENTIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnMTELEMENTIDMJESTOTROSKA.AllowDBNull = false;
                this.columnMTELEMENTIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnMTELEMENTIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "MTELEMENT");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Mjesto troška");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMTELEMENTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "MTELEMENTIDMJESTOTROSKA");
                this.Columns.Add(this.columnMTELEMENTIDMJESTOTROSKA);
                this.columnSHEMAPLELEMENTNAZIVELEMENT = new DataColumn("SHEMAPLELEMENTNAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnSHEMAPLELEMENTNAZIVELEMENT.AllowDBNull = true;
                this.columnSHEMAPLELEMENTNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnSHEMAPLELEMENTNAZIVELEMENT.MaxLength = 50;
                this.columnSHEMAPLELEMENTNAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("SuperType", "NAZIVELEMENT");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("SubtypeGroup", "SHEMAPLELEMENT");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAPLELEMENTNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAPLELEMENTNAZIVELEMENT");
                this.Columns.Add(this.columnSHEMAPLELEMENTNAZIVELEMENT);
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA = new DataColumn("SHEMAPLELEMENTIDVRSTAELEMENTA", typeof(short), "", MappingType.Element);
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.AllowDBNull = true;
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.Caption = "Šifra Vrste elementa";
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("SuperType", "IDVRSTAELEMENTA");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("SubtypeGroup", "SHEMAPLELEMENT");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Description", "Šifra Vrste elementa");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Length", "4");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAPLELEMENTIDVRSTAELEMENTA");
                this.Columns.Add(this.columnSHEMAPLELEMENTIDVRSTAELEMENTA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAPLACA, this.columnSHEMAPLELEMENTIDELEMENT, this.columnKONTOELEMENTIDKONTO, this.columnSTRANEELEMENTIDSTRANEKNJIZENJA };
                this.ExtendedProperties.Add("ParentLvl", "SHEMAPLACA");
                this.ExtendedProperties.Add("LevelName", "SHEMAPLACAELEMENT");
                this.ExtendedProperties.Add("Description", "SHEMAPLACAELEMENT");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAPLACA = this.Columns["IDSHEMAPLACA"];
                this.columnSHEMAPLELEMENTIDELEMENT = this.Columns["SHEMAPLELEMENTIDELEMENT"];
                this.columnKONTOELEMENTIDKONTO = this.Columns["KONTOELEMENTIDKONTO"];
                this.columnSTRANEELEMENTIDSTRANEKNJIZENJA = this.Columns["STRANEELEMENTIDSTRANEKNJIZENJA"];
                this.columnMTELEMENTIDMJESTOTROSKA = this.Columns["MTELEMENTIDMJESTOTROSKA"];
                this.columnSHEMAPLELEMENTNAZIVELEMENT = this.Columns["SHEMAPLELEMENTNAZIVELEMENT"];
                this.columnSHEMAPLELEMENTIDVRSTAELEMENTA = this.Columns["SHEMAPLELEMENTIDVRSTAELEMENTA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow(builder);
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow NewSHEMAPLACASHEMAPLACAELEMENTRow()
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAPLACASHEMAPLACAELEMENTRowChanged != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler sHEMAPLACASHEMAPLACAELEMENTRowChangedEvent = this.SHEMAPLACASHEMAPLACAELEMENTRowChanged;
                    if (sHEMAPLACASHEMAPLACAELEMENTRowChangedEvent != null)
                    {
                        sHEMAPLACASHEMAPLACAELEMENTRowChangedEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAPLACASHEMAPLACAELEMENTRowChanging != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler sHEMAPLACASHEMAPLACAELEMENTRowChangingEvent = this.SHEMAPLACASHEMAPLACAELEMENTRowChanging;
                    if (sHEMAPLACASHEMAPLACAELEMENTRowChangingEvent != null)
                    {
                        sHEMAPLACASHEMAPLACAELEMENTRowChangingEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SHEMAPLACASHEMAPLACAELEMENTRowDeleted != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler sHEMAPLACASHEMAPLACAELEMENTRowDeletedEvent = this.SHEMAPLACASHEMAPLACAELEMENTRowDeleted;
                    if (sHEMAPLACASHEMAPLACAELEMENTRowDeletedEvent != null)
                    {
                        sHEMAPLACASHEMAPLACAELEMENTRowDeletedEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAPLACASHEMAPLACAELEMENTRowDeleting != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler sHEMAPLACASHEMAPLACAELEMENTRowDeletingEvent = this.SHEMAPLACASHEMAPLACAELEMENTRowDeleting;
                    if (sHEMAPLACASHEMAPLACAELEMENTRowDeletingEvent != null)
                    {
                        sHEMAPLACASHEMAPLACAELEMENTRowDeletingEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAPLACASHEMAPLACAELEMENTRow(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow row)
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

            public DataColumn IDSHEMAPLACAColumn
            {
                get
                {
                    return this.columnIDSHEMAPLACA;
                }
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow this[int index]
            {
                get
                {
                    return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) this.Rows[index];
                }
            }

            public DataColumn KONTOELEMENTIDKONTOColumn
            {
                get
                {
                    return this.columnKONTOELEMENTIDKONTO;
                }
            }

            public DataColumn MTELEMENTIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnMTELEMENTIDMJESTOTROSKA;
                }
            }

            public DataColumn SHEMAPLELEMENTIDELEMENTColumn
            {
                get
                {
                    return this.columnSHEMAPLELEMENTIDELEMENT;
                }
            }

            public DataColumn SHEMAPLELEMENTIDVRSTAELEMENTAColumn
            {
                get
                {
                    return this.columnSHEMAPLELEMENTIDVRSTAELEMENTA;
                }
            }

            public DataColumn SHEMAPLELEMENTNAZIVELEMENTColumn
            {
                get
                {
                    return this.columnSHEMAPLELEMENTNAZIVELEMENT;
                }
            }

            public DataColumn STRANEELEMENTIDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnSTRANEELEMENTIDSTRANEKNJIZENJA;
                }
            }
        }

        public class SHEMAPLACASHEMAPLACAELEMENTRow : DataRow
        {
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTDataTable tableSHEMAPLACASHEMAPLACAELEMENT;

            internal SHEMAPLACASHEMAPLACAELEMENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAPLACASHEMAPLACAELEMENT = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTDataTable) this.Table;
            }

            public SHEMAPLACADataSet.SHEMAPLACARow GetSHEMAPLACARow()
            {
                return (SHEMAPLACADataSet.SHEMAPLACARow) this.GetParentRow("SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT");
            }

            public bool IsIDSHEMAPLACANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACAELEMENT.IDSHEMAPLACAColumn);
            }

            public bool IsKONTOELEMENTIDKONTONull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACAELEMENT.KONTOELEMENTIDKONTOColumn);
            }

            public bool IsMTELEMENTIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACAELEMENT.MTELEMENTIDMJESTOTROSKAColumn);
            }

            public bool IsSHEMAPLELEMENTIDELEMENTNull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTIDELEMENTColumn);
            }

            public bool IsSHEMAPLELEMENTIDVRSTAELEMENTANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTIDVRSTAELEMENTAColumn);
            }

            public bool IsSHEMAPLELEMENTNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTNAZIVELEMENTColumn);
            }

            public bool IsSTRANEELEMENTIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACAELEMENT.STRANEELEMENTIDSTRANEKNJIZENJAColumn);
            }

            public void SetMTELEMENTIDMJESTOTROSKANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACAELEMENT.MTELEMENTIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAPLELEMENTIDVRSTAELEMENTANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTIDVRSTAELEMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAPLELEMENTNAZIVELEMENTNull()
            {
                this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTNAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMAPLACA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACAELEMENT.IDSHEMAPLACAColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACAELEMENT.IDSHEMAPLACAColumn] = value;
                }
            }

            public string KONTOELEMENTIDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableSHEMAPLACASHEMAPLACAELEMENT.KONTOELEMENTIDKONTOColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACAELEMENT.KONTOELEMENTIDKONTOColumn] = value;
                }
            }

            public int MTELEMENTIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACAELEMENT.MTELEMENTIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACAELEMENT.MTELEMENTIDMJESTOTROSKAColumn] = value;
                }
            }

            public int SHEMAPLELEMENTIDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTIDELEMENTColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTIDELEMENTColumn] = value;
                }
            }

            public short SHEMAPLELEMENTIDVRSTAELEMENTA
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTIDVRSTAELEMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTIDVRSTAELEMENTAColumn] = value;
                }
            }

            public string SHEMAPLELEMENTNAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTNAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACAELEMENT.SHEMAPLELEMENTNAZIVELEMENTColumn] = value;
                }
            }

            public int STRANEELEMENTIDSTRANEKNJIZENJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACAELEMENT.STRANEELEMENTIDSTRANEKNJIZENJAColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACAELEMENT.STRANEELEMENTIDSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class SHEMAPLACASHEMAPLACAELEMENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow eventRow;

            public SHEMAPLACASHEMAPLACAELEMENTRowChangeEvent(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow row, DataRowAction action)
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

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAPLACASHEMAPLACAELEMENTRowChangeEventHandler(object sender, SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRowChangeEvent e);

        [Serializable]
        public class SHEMAPLACASHEMAPLACASTANDARDDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPLVRSTEIZNOSA;
            private DataColumn columnIDSHEMAPLACA;
            private DataColumn columnKONTOPLACAVRSTAIZNOSAIDKONTO;
            private DataColumn columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA;
            private DataColumn columnNAZIVPLVRSTEIZNOSA;
            private DataColumn columnSHEMAPLACASTANDARDID;
            private DataColumn columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler SHEMAPLACASHEMAPLACASTANDARDRowChanged;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler SHEMAPLACASHEMAPLACASTANDARDRowChanging;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler SHEMAPLACASHEMAPLACASTANDARDRowDeleted;

            public event SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler SHEMAPLACASHEMAPLACASTANDARDRowDeleting;

            public SHEMAPLACASHEMAPLACASTANDARDDataTable()
            {
                this.TableName = "SHEMAPLACASHEMAPLACASTANDARD";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAPLACASHEMAPLACASTANDARDDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAPLACASHEMAPLACASTANDARDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAPLACASHEMAPLACASTANDARDRow(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow AddSHEMAPLACASHEMAPLACASTANDARDRow(int iDSHEMAPLACA, int iDPLVRSTEIZNOSA, string kONTOPLACAVRSTAIZNOSAIDKONTO, int mTPLACAVRSTAIZNOSAIDMJESTOTROSKA, int sTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA)
            {
                SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow row = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) this.NewRow();
                row["IDSHEMAPLACA"] = iDSHEMAPLACA;
                row["IDPLVRSTEIZNOSA"] = iDPLVRSTEIZNOSA;
                row["KONTOPLACAVRSTAIZNOSAIDKONTO"] = kONTOPLACAVRSTAIZNOSAIDKONTO;
                row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"] = mTPLACAVRSTAIZNOSAIDMJESTOTROSKA;
                row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"] = sTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDDataTable table = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow FindByIDSHEMAPLACASHEMAPLACASTANDARDID(int iDSHEMAPLACA, Guid sHEMAPLACASTANDARDID)
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) this.Rows.Find(new object[] { iDSHEMAPLACA, sHEMAPLACASTANDARDID });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAPLACADataSet set = new SHEMAPLACADataSet();
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
                this.columnIDSHEMAPLACA = new DataColumn("IDSHEMAPLACA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAPLACA.AllowDBNull = false;
                this.columnIDSHEMAPLACA.Caption = "IDSHEMAPLACA";
                this.columnIDSHEMAPLACA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAPLACA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAPLACA");
                this.Columns.Add(this.columnIDSHEMAPLACA);
                this.columnSHEMAPLACASTANDARDID = new DataColumn("SHEMAPLACASTANDARDID", typeof(Guid), "", MappingType.Element);
                this.columnSHEMAPLACASTANDARDID.AllowDBNull = false;
                this.columnSHEMAPLACASTANDARDID.Caption = "SHEMAPLACASTANDARDID";
                this.columnSHEMAPLACASTANDARDID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("AutoGenerated", "true");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("DeklaritType", "guid");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Description", "SHEMAPLACASTANDARDID");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Length", "32");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAPLACASTANDARDID.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAPLACASTANDARDID");
                this.Columns.Add(this.columnSHEMAPLACASTANDARDID);
                this.columnIDPLVRSTEIZNOSA = new DataColumn("IDPLVRSTEIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDPLVRSTEIZNOSA.AllowDBNull = false;
                this.columnIDPLVRSTEIZNOSA.Caption = "IDPLVRSTEIZNOSA";
                this.columnIDPLVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Description", "Šifra iznosa");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDPLVRSTEIZNOSA");
                this.Columns.Add(this.columnIDPLVRSTEIZNOSA);
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO = new DataColumn("KONTOPLACAVRSTAIZNOSAIDKONTO", typeof(string), "", MappingType.Element);
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.AllowDBNull = false;
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.Caption = "Konto";
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.MaxLength = 14;
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("SubtypeGroup", "KONTOPLACAVRSTAIZNOSA");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "KONTOPLACAVRSTAIZNOSAIDKONTO");
                this.Columns.Add(this.columnKONTOPLACAVRSTAIZNOSAIDKONTO);
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA = new DataColumn("MTPLACAVRSTAIZNOSAIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.AllowDBNull = false;
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "MTPLACAVRSTAIZNOSA");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Mjesto troška");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "MTPLACAVRSTAIZNOSAIDMJESTOTROSKA");
                this.Columns.Add(this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA);
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA = new DataColumn("STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Caption = "Šifra strane";
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("SuperType", "IDSTRANEKNJIZENJA");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("SubtypeGroup", "STRANEVRSTEIZNOSA");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Strana kniženja");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA);
                this.columnNAZIVPLVRSTEIZNOSA = new DataColumn("NAZIVPLVRSTEIZNOSA", typeof(string), "", MappingType.Element);
                this.columnNAZIVPLVRSTEIZNOSA.AllowDBNull = true;
                this.columnNAZIVPLVRSTEIZNOSA.Caption = "NAZIVPLVRSTEIZNOSA";
                this.columnNAZIVPLVRSTEIZNOSA.MaxLength = 50;
                this.columnNAZIVPLVRSTEIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPLVRSTEIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPLVRSTEIZNOSA");
                this.Columns.Add(this.columnNAZIVPLVRSTEIZNOSA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAPLACA, this.columnSHEMAPLACASTANDARDID };
                this.ExtendedProperties.Add("ParentLvl", "SHEMAPLACA");
                this.ExtendedProperties.Add("LevelName", "SHEMAPLACASTANDARD");
                this.ExtendedProperties.Add("Description", "SHEMAPLACASTANDARD");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAPLACA = this.Columns["IDSHEMAPLACA"];
                this.columnSHEMAPLACASTANDARDID = this.Columns["SHEMAPLACASTANDARDID"];
                this.columnIDPLVRSTEIZNOSA = this.Columns["IDPLVRSTEIZNOSA"];
                this.columnKONTOPLACAVRSTAIZNOSAIDKONTO = this.Columns["KONTOPLACAVRSTAIZNOSAIDKONTO"];
                this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA = this.Columns["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"];
                this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA = this.Columns["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"];
                this.columnNAZIVPLVRSTEIZNOSA = this.Columns["NAZIVPLVRSTEIZNOSA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow(builder);
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow NewSHEMAPLACASHEMAPLACASTANDARDRow()
            {
                return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAPLACASHEMAPLACASTANDARDRowChanged != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler sHEMAPLACASHEMAPLACASTANDARDRowChangedEvent = this.SHEMAPLACASHEMAPLACASTANDARDRowChanged;
                    if (sHEMAPLACASHEMAPLACASTANDARDRowChangedEvent != null)
                    {
                        sHEMAPLACASHEMAPLACASTANDARDRowChangedEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAPLACASHEMAPLACASTANDARDRowChanging != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler sHEMAPLACASHEMAPLACASTANDARDRowChangingEvent = this.SHEMAPLACASHEMAPLACASTANDARDRowChanging;
                    if (sHEMAPLACASHEMAPLACASTANDARDRowChangingEvent != null)
                    {
                        sHEMAPLACASHEMAPLACASTANDARDRowChangingEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SHEMAPLACASHEMAPLACASTANDARDRowDeleted != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler sHEMAPLACASHEMAPLACASTANDARDRowDeletedEvent = this.SHEMAPLACASHEMAPLACASTANDARDRowDeleted;
                    if (sHEMAPLACASHEMAPLACASTANDARDRowDeletedEvent != null)
                    {
                        sHEMAPLACASHEMAPLACASTANDARDRowDeletedEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAPLACASHEMAPLACASTANDARDRowDeleting != null)
                {
                    SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler sHEMAPLACASHEMAPLACASTANDARDRowDeletingEvent = this.SHEMAPLACASHEMAPLACASTANDARDRowDeleting;
                    if (sHEMAPLACASHEMAPLACASTANDARDRowDeletingEvent != null)
                    {
                        sHEMAPLACASHEMAPLACASTANDARDRowDeletingEvent(this, new SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEvent((SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAPLACASHEMAPLACASTANDARDRow(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow row)
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

            public DataColumn IDPLVRSTEIZNOSAColumn
            {
                get
                {
                    return this.columnIDPLVRSTEIZNOSA;
                }
            }

            public DataColumn IDSHEMAPLACAColumn
            {
                get
                {
                    return this.columnIDSHEMAPLACA;
                }
            }

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow this[int index]
            {
                get
                {
                    return (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) this.Rows[index];
                }
            }

            public DataColumn KONTOPLACAVRSTAIZNOSAIDKONTOColumn
            {
                get
                {
                    return this.columnKONTOPLACAVRSTAIZNOSAIDKONTO;
                }
            }

            public DataColumn MTPLACAVRSTAIZNOSAIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKA;
                }
            }

            public DataColumn NAZIVPLVRSTEIZNOSAColumn
            {
                get
                {
                    return this.columnNAZIVPLVRSTEIZNOSA;
                }
            }

            public DataColumn SHEMAPLACASTANDARDIDColumn
            {
                get
                {
                    return this.columnSHEMAPLACASTANDARDID;
                }
            }

            public DataColumn STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA;
                }
            }
        }

        public class SHEMAPLACASHEMAPLACASTANDARDRow : DataRow
        {
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDDataTable tableSHEMAPLACASHEMAPLACASTANDARD;

            internal SHEMAPLACASHEMAPLACASTANDARDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAPLACASHEMAPLACASTANDARD = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDDataTable) this.Table;
                this.SHEMAPLACASTANDARDID = Guid.NewGuid();
            }

            public SHEMAPLACADataSet.SHEMAPLACARow GetSHEMAPLACARow()
            {
                return (SHEMAPLACADataSet.SHEMAPLACARow) this.GetParentRow("SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD");
            }

            public bool IsIDPLVRSTEIZNOSANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACASTANDARD.IDPLVRSTEIZNOSAColumn);
            }

            public bool IsIDSHEMAPLACANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACASTANDARD.IDSHEMAPLACAColumn);
            }

            public bool IsKONTOPLACAVRSTAIZNOSAIDKONTONull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACASTANDARD.KONTOPLACAVRSTAIZNOSAIDKONTOColumn);
            }

            public bool IsMTPLACAVRSTAIZNOSAIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACASTANDARD.MTPLACAVRSTAIZNOSAIDMJESTOTROSKAColumn);
            }

            public bool IsNAZIVPLVRSTEIZNOSANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACASTANDARD.NAZIVPLVRSTEIZNOSAColumn);
            }

            public bool IsSHEMAPLACASTANDARDIDNull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACASTANDARD.SHEMAPLACASTANDARDIDColumn);
            }

            public bool IsSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSHEMAPLACASHEMAPLACASTANDARD.STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAColumn);
            }

            public void SetIDPLVRSTEIZNOSANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACASTANDARD.IDPLVRSTEIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKONTOPLACAVRSTAIZNOSAIDKONTONull()
            {
                this[this.tableSHEMAPLACASHEMAPLACASTANDARD.KONTOPLACAVRSTAIZNOSAIDKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMTPLACAVRSTAIZNOSAIDMJESTOTROSKANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACASTANDARD.MTPLACAVRSTAIZNOSAIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPLVRSTEIZNOSANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACASTANDARD.NAZIVPLVRSTEIZNOSAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJANull()
            {
                this[this.tableSHEMAPLACASHEMAPLACASTANDARD.STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPLVRSTEIZNOSA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACASTANDARD.IDPLVRSTEIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACASTANDARD.IDPLVRSTEIZNOSAColumn] = value;
                }
            }

            public int IDSHEMAPLACA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACASTANDARD.IDSHEMAPLACAColumn]);
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACASTANDARD.IDSHEMAPLACAColumn] = value;
                }
            }

            public string KONTOPLACAVRSTAIZNOSAIDKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMAPLACASHEMAPLACASTANDARD.KONTOPLACAVRSTAIZNOSAIDKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACASTANDARD.KONTOPLACAVRSTAIZNOSAIDKONTOColumn] = value;
                }
            }

            public int MTPLACAVRSTAIZNOSAIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACASTANDARD.MTPLACAVRSTAIZNOSAIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACASTANDARD.MTPLACAVRSTAIZNOSAIDMJESTOTROSKAColumn] = value;
                }
            }

            public string NAZIVPLVRSTEIZNOSA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMAPLACASHEMAPLACASTANDARD.NAZIVPLVRSTEIZNOSAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACASTANDARD.NAZIVPLVRSTEIZNOSAColumn] = value;
                }
            }

            public Guid SHEMAPLACASTANDARDID
            {
                get
                {
                    object obj1 = this[this.tableSHEMAPLACASHEMAPLACASTANDARD.SHEMAPLACASTANDARDIDColumn];
                    if (obj1 == null)
                    {
                        Guid guid2 = new Guid();
                        return guid2;
                    }
                    return (Guid) obj1;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACASTANDARD.SHEMAPLACASTANDARDIDColumn] = value;
                }
            }

            public int STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAPLACASHEMAPLACASTANDARD.STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAPLACASHEMAPLACASTANDARD.STRANEVRSTEIZNOSAIDSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class SHEMAPLACASHEMAPLACASTANDARDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow eventRow;

            public SHEMAPLACASHEMAPLACASTANDARDRowChangeEvent(SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow row, DataRowAction action)
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

            public SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAPLACASHEMAPLACASTANDARDRowChangeEventHandler(object sender, SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRowChangeEvent e);
    }
}

