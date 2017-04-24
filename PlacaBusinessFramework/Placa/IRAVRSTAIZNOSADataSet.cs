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
    public class IRAVRSTAIZNOSADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private IRAVRSTAIZNOSADataTable tableIRAVRSTAIZNOSA;

        public IRAVRSTAIZNOSADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected IRAVRSTAIZNOSADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["IRAVRSTAIZNOSA"] != null)
                    {
                        this.Tables.Add(new IRAVRSTAIZNOSADataTable(dataSet.Tables["IRAVRSTAIZNOSA"]));
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
            IRAVRSTAIZNOSADataSet set = (IRAVRSTAIZNOSADataSet) base.Clone();
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
            IRAVRSTAIZNOSADataSet set = new IRAVRSTAIZNOSADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "IRAVRSTAIZNOSADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2113");
            this.ExtendedProperties.Add("DataSetName", "IRAVRSTAIZNOSADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IIRAVRSTAIZNOSADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "IRAVRSTAIZNOSA");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste iznosa IRA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "IRAVRSTAIZNOSANAZIV");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "IRAVRSTAIZNOSADataSet";
            this.Namespace = "http://www.tempuri.org/IRAVRSTAIZNOSA";
            this.tableIRAVRSTAIZNOSA = new IRAVRSTAIZNOSADataTable();
            this.Tables.Add(this.tableIRAVRSTAIZNOSA);
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
            this.tableIRAVRSTAIZNOSA = (IRAVRSTAIZNOSADataTable) this.Tables["IRAVRSTAIZNOSA"];
            if (initTable && (this.tableIRAVRSTAIZNOSA != null))
            {
                this.tableIRAVRSTAIZNOSA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["IRAVRSTAIZNOSA"] != null)
                {
                    this.Tables.Add(new IRAVRSTAIZNOSADataTable(dataSet.Tables["IRAVRSTAIZNOSA"]));
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

        private bool ShouldSerializeIRAVRSTAIZNOSA()
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
        public IRAVRSTAIZNOSADataTable IRAVRSTAIZNOSA
        {
            get
            {
                return this.tableIRAVRSTAIZNOSA;
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
        public class IRAVRSTAIZNOSADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDIRAVRSTAIZNOSA;
            private DataColumn columnIRAVRSTAIZNOSANAZIV;

            public event IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler IRAVRSTAIZNOSARowChanged;

            public event IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler IRAVRSTAIZNOSARowChanging;

            public event IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler IRAVRSTAIZNOSARowDeleted;

            public event IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler IRAVRSTAIZNOSARowDeleting;

            public IRAVRSTAIZNOSADataTable()
            {
                this.TableName = "IRAVRSTAIZNOSA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal IRAVRSTAIZNOSADataTable(DataTable table) : base(table.TableName)
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

            protected IRAVRSTAIZNOSADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddIRAVRSTAIZNOSARow(IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow row)
            {
                this.Rows.Add(row);
            }

            public IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow AddIRAVRSTAIZNOSARow(int iDIRAVRSTAIZNOSA, string iRAVRSTAIZNOSANAZIV)
            {
                IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow row = (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) this.NewRow();
                row["IDIRAVRSTAIZNOSA"] = iDIRAVRSTAIZNOSA;
                row["IRAVRSTAIZNOSANAZIV"] = iRAVRSTAIZNOSANAZIV;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSADataTable table = (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow FindByIDIRAVRSTAIZNOSA(int iDIRAVRSTAIZNOSA)
            {
                return (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) this.Rows.Find(new object[] { iDIRAVRSTAIZNOSA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IRAVRSTAIZNOSADataSet set = new IRAVRSTAIZNOSADataSet();
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
                this.columnIDIRAVRSTAIZNOSA = new DataColumn("IDIRAVRSTAIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDIRAVRSTAIZNOSA.AllowDBNull = false;
                this.columnIDIRAVRSTAIZNOSA.Caption = "IDIRAVRSTAIZNOSA";
                this.columnIDIRAVRSTAIZNOSA.Unique = true;
                this.columnIDIRAVRSTAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Description", "IDIRAVRSTAIZNOSA");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDIRAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDIRAVRSTAIZNOSA");
                this.Columns.Add(this.columnIDIRAVRSTAIZNOSA);
                this.columnIRAVRSTAIZNOSANAZIV = new DataColumn("IRAVRSTAIZNOSANAZIV", typeof(string), "", MappingType.Element);
                this.columnIRAVRSTAIZNOSANAZIV.AllowDBNull = false;
                this.columnIRAVRSTAIZNOSANAZIV.Caption = "IRAVRSTAIZNOSANAZIV";
                this.columnIRAVRSTAIZNOSANAZIV.MaxLength = 30;
                this.columnIRAVRSTAIZNOSANAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Description", "IRAVRSTAIZNOSANAZIV");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Length", "30");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIRAVRSTAIZNOSANAZIV.ExtendedProperties.Add("Deklarit.InternalName", "IRAVRSTAIZNOSANAZIV");
                this.Columns.Add(this.columnIRAVRSTAIZNOSANAZIV);
                this.PrimaryKey = new DataColumn[] { this.columnIDIRAVRSTAIZNOSA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "IRAVRSTAIZNOSA");
                this.ExtendedProperties.Add("Description", "Vrste iznosa IRA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDIRAVRSTAIZNOSA = this.Columns["IDIRAVRSTAIZNOSA"];
                this.columnIRAVRSTAIZNOSANAZIV = this.Columns["IRAVRSTAIZNOSANAZIV"];
            }

            public IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow NewIRAVRSTAIZNOSARow()
            {
                return (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.IRAVRSTAIZNOSARowChanged != null)
                {
                    IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler iRAVRSTAIZNOSARowChangedEvent = this.IRAVRSTAIZNOSARowChanged;
                    if (iRAVRSTAIZNOSARowChangedEvent != null)
                    {
                        iRAVRSTAIZNOSARowChangedEvent(this, new IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEvent((IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.IRAVRSTAIZNOSARowChanging != null)
                {
                    IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler iRAVRSTAIZNOSARowChangingEvent = this.IRAVRSTAIZNOSARowChanging;
                    if (iRAVRSTAIZNOSARowChangingEvent != null)
                    {
                        iRAVRSTAIZNOSARowChangingEvent(this, new IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEvent((IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.IRAVRSTAIZNOSARowDeleted != null)
                {
                    IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler iRAVRSTAIZNOSARowDeletedEvent = this.IRAVRSTAIZNOSARowDeleted;
                    if (iRAVRSTAIZNOSARowDeletedEvent != null)
                    {
                        iRAVRSTAIZNOSARowDeletedEvent(this, new IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEvent((IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.IRAVRSTAIZNOSARowDeleting != null)
                {
                    IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEventHandler iRAVRSTAIZNOSARowDeletingEvent = this.IRAVRSTAIZNOSARowDeleting;
                    if (iRAVRSTAIZNOSARowDeletingEvent != null)
                    {
                        iRAVRSTAIZNOSARowDeletingEvent(this, new IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEvent((IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveIRAVRSTAIZNOSARow(IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow row)
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

            public DataColumn IDIRAVRSTAIZNOSAColumn
            {
                get
                {
                    return this.columnIDIRAVRSTAIZNOSA;
                }
            }

            public DataColumn IRAVRSTAIZNOSANAZIVColumn
            {
                get
                {
                    return this.columnIRAVRSTAIZNOSANAZIV;
                }
            }

            public IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow this[int index]
            {
                get
                {
                    return (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) this.Rows[index];
                }
            }
        }

        public class IRAVRSTAIZNOSARow : DataRow
        {
            private IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSADataTable tableIRAVRSTAIZNOSA;

            internal IRAVRSTAIZNOSARow(DataRowBuilder rb) : base(rb)
            {
                this.tableIRAVRSTAIZNOSA = (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSADataTable) this.Table;
            }

            public bool IsIDIRAVRSTAIZNOSANull()
            {
                return this.IsNull(this.tableIRAVRSTAIZNOSA.IDIRAVRSTAIZNOSAColumn);
            }

            public bool IsIRAVRSTAIZNOSANAZIVNull()
            {
                return this.IsNull(this.tableIRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIVColumn);
            }

            public void SetIRAVRSTAIZNOSANAZIVNull()
            {
                this[this.tableIRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDIRAVRSTAIZNOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableIRAVRSTAIZNOSA.IDIRAVRSTAIZNOSAColumn]);
                }
                set
                {
                    this[this.tableIRAVRSTAIZNOSA.IDIRAVRSTAIZNOSAColumn] = value;
                }
            }

            public string IRAVRSTAIZNOSANAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableIRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IRAVRSTAIZNOSANAZIV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableIRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIVColumn] = value;
                }
            }
        }

        public class IRAVRSTAIZNOSARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow eventRow;

            public IRAVRSTAIZNOSARowChangeEvent(IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow row, DataRowAction action)
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

            public IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void IRAVRSTAIZNOSARowChangeEventHandler(object sender, IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARowChangeEvent e);
    }
}

