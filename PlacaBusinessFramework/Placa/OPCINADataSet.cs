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
    public class OPCINADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OPCINADataTable tableOPCINA;

        public OPCINADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OPCINADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OPCINA"] != null)
                    {
                        this.Tables.Add(new OPCINADataTable(dataSet.Tables["OPCINA"]));
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
            OPCINADataSet set = (OPCINADataSet) base.Clone();
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
            OPCINADataSet set = new OPCINADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OPCINADataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1011");
            this.ExtendedProperties.Add("DataSetName", "OPCINADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOPCINADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OPCINA");
            this.ExtendedProperties.Add("ObjectDescription", "Opaine");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
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
            this.DataSetName = "OPCINADataSet";
            this.Namespace = "http://www.tempuri.org/OPCINA";
            this.tableOPCINA = new OPCINADataTable();
            this.Tables.Add(this.tableOPCINA);
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
            this.tableOPCINA = (OPCINADataTable) this.Tables["OPCINA"];
            if (initTable && (this.tableOPCINA != null))
            {
                this.tableOPCINA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OPCINA"] != null)
                {
                    this.Tables.Add(new OPCINADataTable(dataSet.Tables["OPCINA"]));
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

        private bool ShouldSerializeOPCINA()
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
        public OPCINADataTable OPCINA
        {
            get
            {
                return this.tableOPCINA;
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
        public class OPCINADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOPCINE;
            private DataColumn columnNAZIVOPCINE;
            private DataColumn columnPRIREZ;
            private DataColumn columnVBDIOPCINA;
            private DataColumn columnZRNOPCINA;

            public event OPCINADataSet.OPCINARowChangeEventHandler OPCINARowChanged;

            public event OPCINADataSet.OPCINARowChangeEventHandler OPCINARowChanging;

            public event OPCINADataSet.OPCINARowChangeEventHandler OPCINARowDeleted;

            public event OPCINADataSet.OPCINARowChangeEventHandler OPCINARowDeleting;

            public OPCINADataTable()
            {
                this.TableName = "OPCINA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OPCINADataTable(DataTable table) : base(table.TableName)
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

            protected OPCINADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOPCINARow(OPCINADataSet.OPCINARow row)
            {
                this.Rows.Add(row);
            }

            public OPCINADataSet.OPCINARow AddOPCINARow(string iDOPCINE, string nAZIVOPCINE, decimal pRIREZ, string vBDIOPCINA, string zRNOPCINA)
            {
                OPCINADataSet.OPCINARow row = (OPCINADataSet.OPCINARow) this.NewRow();
                row["IDOPCINE"] = iDOPCINE;
                row["NAZIVOPCINE"] = nAZIVOPCINE;
                row["PRIREZ"] = pRIREZ;
                row["VBDIOPCINA"] = vBDIOPCINA;
                row["ZRNOPCINA"] = zRNOPCINA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OPCINADataSet.OPCINADataTable table = (OPCINADataSet.OPCINADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OPCINADataSet.OPCINARow FindByIDOPCINE(string iDOPCINE)
            {
                return (OPCINADataSet.OPCINARow) this.Rows.Find(new object[] { iDOPCINE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OPCINADataSet.OPCINARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OPCINADataSet set = new OPCINADataSet();
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
                this.columnIDOPCINE = new DataColumn("IDOPCINE", typeof(string), "", MappingType.Element);
                this.columnIDOPCINE.AllowDBNull = false;
                this.columnIDOPCINE.Caption = "Šifra općine";
                this.columnIDOPCINE.MaxLength = 4;
                this.columnIDOPCINE.Unique = true;
                this.columnIDOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOPCINE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOPCINE.ExtendedProperties.Add("Description", "Šifra općine");
                this.columnIDOPCINE.ExtendedProperties.Add("Length", "4");
                this.columnIDOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "IDOPCINE");
                this.Columns.Add(this.columnIDOPCINE);
                this.columnNAZIVOPCINE = new DataColumn("NAZIVOPCINE", typeof(string), "", MappingType.Element);
                this.columnNAZIVOPCINE.AllowDBNull = false;
                this.columnNAZIVOPCINE.Caption = "Naziv općine";
                this.columnNAZIVOPCINE.MaxLength = 50;
                this.columnNAZIVOPCINE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Description", "Naziv općine");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOPCINE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOPCINE");
                this.Columns.Add(this.columnNAZIVOPCINE);
                this.columnPRIREZ = new DataColumn("PRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnPRIREZ.AllowDBNull = false;
                this.columnPRIREZ.Caption = "Prirez općine";
                this.columnPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPRIREZ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPRIREZ.ExtendedProperties.Add("Description", "Prirez općine");
                this.columnPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPRIREZ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "PRIREZ");
                this.Columns.Add(this.columnPRIREZ);
                this.columnVBDIOPCINA = new DataColumn("VBDIOPCINA", typeof(string), "", MappingType.Element);
                this.columnVBDIOPCINA.AllowDBNull = false;
                this.columnVBDIOPCINA.Caption = "VBDI žiro računa općine";
                this.columnVBDIOPCINA.MaxLength = 7;
                this.columnVBDIOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnVBDIOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnVBDIOPCINA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnVBDIOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Description", "VBDI žiro računa općine");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Length", "7");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnVBDIOPCINA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnVBDIOPCINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnVBDIOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "VBDIOPCINA");
                this.Columns.Add(this.columnVBDIOPCINA);
                this.columnZRNOPCINA = new DataColumn("ZRNOPCINA", typeof(string), "", MappingType.Element);
                this.columnZRNOPCINA.AllowDBNull = false;
                this.columnZRNOPCINA.Caption = "Broj žiro računa općine";
                this.columnZRNOPCINA.MaxLength = 10;
                this.columnZRNOPCINA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZRNOPCINA.ExtendedProperties.Add("IsKey", "false");
                this.columnZRNOPCINA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZRNOPCINA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnZRNOPCINA.ExtendedProperties.Add("Description", "Broj žiro računa općine");
                this.columnZRNOPCINA.ExtendedProperties.Add("Length", "10");
                this.columnZRNOPCINA.ExtendedProperties.Add("Decimals", "0");
                this.columnZRNOPCINA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZRNOPCINA.ExtendedProperties.Add("IsInReader", "true");
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZRNOPCINA.ExtendedProperties.Add("Deklarit.InternalName", "ZRNOPCINA");
                this.Columns.Add(this.columnZRNOPCINA);
                this.PrimaryKey = new DataColumn[] { this.columnIDOPCINE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OPCINA");
                this.ExtendedProperties.Add("Description", "Opaine");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOPCINE = this.Columns["IDOPCINE"];
                this.columnNAZIVOPCINE = this.Columns["NAZIVOPCINE"];
                this.columnPRIREZ = this.Columns["PRIREZ"];
                this.columnVBDIOPCINA = this.Columns["VBDIOPCINA"];
                this.columnZRNOPCINA = this.Columns["ZRNOPCINA"];
            }

            public OPCINADataSet.OPCINARow NewOPCINARow()
            {
                return (OPCINADataSet.OPCINARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OPCINADataSet.OPCINARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OPCINARowChanged != null)
                {
                    OPCINADataSet.OPCINARowChangeEventHandler oPCINARowChangedEvent = this.OPCINARowChanged;
                    if (oPCINARowChangedEvent != null)
                    {
                        oPCINARowChangedEvent(this, new OPCINADataSet.OPCINARowChangeEvent((OPCINADataSet.OPCINARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OPCINARowChanging != null)
                {
                    OPCINADataSet.OPCINARowChangeEventHandler oPCINARowChangingEvent = this.OPCINARowChanging;
                    if (oPCINARowChangingEvent != null)
                    {
                        oPCINARowChangingEvent(this, new OPCINADataSet.OPCINARowChangeEvent((OPCINADataSet.OPCINARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OPCINARowDeleted != null)
                {
                    OPCINADataSet.OPCINARowChangeEventHandler oPCINARowDeletedEvent = this.OPCINARowDeleted;
                    if (oPCINARowDeletedEvent != null)
                    {
                        oPCINARowDeletedEvent(this, new OPCINADataSet.OPCINARowChangeEvent((OPCINADataSet.OPCINARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OPCINARowDeleting != null)
                {
                    OPCINADataSet.OPCINARowChangeEventHandler oPCINARowDeletingEvent = this.OPCINARowDeleting;
                    if (oPCINARowDeletingEvent != null)
                    {
                        oPCINARowDeletingEvent(this, new OPCINADataSet.OPCINARowChangeEvent((OPCINADataSet.OPCINARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOPCINARow(OPCINADataSet.OPCINARow row)
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

            public DataColumn IDOPCINEColumn
            {
                get
                {
                    return this.columnIDOPCINE;
                }
            }

            public OPCINADataSet.OPCINARow this[int index]
            {
                get
                {
                    return (OPCINADataSet.OPCINARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOPCINEColumn
            {
                get
                {
                    return this.columnNAZIVOPCINE;
                }
            }

            public DataColumn PRIREZColumn
            {
                get
                {
                    return this.columnPRIREZ;
                }
            }

            public DataColumn VBDIOPCINAColumn
            {
                get
                {
                    return this.columnVBDIOPCINA;
                }
            }

            public DataColumn ZRNOPCINAColumn
            {
                get
                {
                    return this.columnZRNOPCINA;
                }
            }
        }

        public class OPCINARow : DataRow
        {
            private OPCINADataSet.OPCINADataTable tableOPCINA;

            internal OPCINARow(DataRowBuilder rb) : base(rb)
            {
                this.tableOPCINA = (OPCINADataSet.OPCINADataTable) this.Table;
            }

            public bool IsIDOPCINENull()
            {
                return this.IsNull(this.tableOPCINA.IDOPCINEColumn);
            }

            public bool IsNAZIVOPCINENull()
            {
                return this.IsNull(this.tableOPCINA.NAZIVOPCINEColumn);
            }

            public bool IsPRIREZNull()
            {
                return this.IsNull(this.tableOPCINA.PRIREZColumn);
            }

            public bool IsVBDIOPCINANull()
            {
                return this.IsNull(this.tableOPCINA.VBDIOPCINAColumn);
            }

            public bool IsZRNOPCINANull()
            {
                return this.IsNull(this.tableOPCINA.ZRNOPCINAColumn);
            }

            public void SetNAZIVOPCINENull()
            {
                this[this.tableOPCINA.NAZIVOPCINEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPRIREZNull()
            {
                this[this.tableOPCINA.PRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetVBDIOPCINANull()
            {
                this[this.tableOPCINA.VBDIOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetZRNOPCINANull()
            {
                this[this.tableOPCINA.ZRNOPCINAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string IDOPCINE
            {
                get
                {
                    return Conversions.ToString(this[this.tableOPCINA.IDOPCINEColumn]);
                }
                set
                {
                    this[this.tableOPCINA.IDOPCINEColumn] = value;
                }
            }

            public string NAZIVOPCINE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOPCINA.NAZIVOPCINEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOPCINE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOPCINA.NAZIVOPCINEColumn] = value;
                }
            }

            public decimal PRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableOPCINA.PRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PRIREZ because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableOPCINA.PRIREZColumn] = value;
                }
            }

            public string VBDIOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOPCINA.VBDIOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value VBDIOPCINA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOPCINA.VBDIOPCINAColumn] = value;
                }
            }

            public string ZRNOPCINA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOPCINA.ZRNOPCINAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ZRNOPCINA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOPCINA.ZRNOPCINAColumn] = value;
                }
            }
        }

        public class OPCINARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OPCINADataSet.OPCINARow eventRow;

            public OPCINARowChangeEvent(OPCINADataSet.OPCINARow row, DataRowAction action)
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

            public OPCINADataSet.OPCINARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OPCINARowChangeEventHandler(object sender, OPCINADataSet.OPCINARowChangeEvent e);
    }
}

