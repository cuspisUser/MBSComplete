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
    public class MJESTOTROSKADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private MJESTOTROSKADataTable tableMJESTOTROSKA;

        public MJESTOTROSKADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected MJESTOTROSKADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["MJESTOTROSKA"] != null)
                    {
                        this.Tables.Add(new MJESTOTROSKADataTable(dataSet.Tables["MJESTOTROSKA"]));
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
            MJESTOTROSKADataSet set = (MJESTOTROSKADataSet) base.Clone();
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
            MJESTOTROSKADataSet set = new MJESTOTROSKADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "MJESTOTROSKADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2038");
            this.ExtendedProperties.Add("DataSetName", "MJESTOTROSKADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IMJESTOTROSKADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "MJESTOTROSKA");
            this.ExtendedProperties.Add("ObjectDescription", "MJESTOTROSKA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "mt");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "MJESTOTROSKADataSet";
            this.Namespace = "http://www.tempuri.org/MJESTOTROSKA";
            this.tableMJESTOTROSKA = new MJESTOTROSKADataTable();
            this.Tables.Add(this.tableMJESTOTROSKA);
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
            this.tableMJESTOTROSKA = (MJESTOTROSKADataTable) this.Tables["MJESTOTROSKA"];
            if (initTable && (this.tableMJESTOTROSKA != null))
            {
                this.tableMJESTOTROSKA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["MJESTOTROSKA"] != null)
                {
                    this.Tables.Add(new MJESTOTROSKADataTable(dataSet.Tables["MJESTOTROSKA"]));
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

        private bool ShouldSerializeMJESTOTROSKA()
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
        public MJESTOTROSKADataTable MJESTOTROSKA
        {
            get
            {
                return this.tableMJESTOTROSKA;
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
        public class MJESTOTROSKADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDMJESTOTROSKA;
            private DataColumn columnmt;
            private DataColumn columnNAZIVMJESTOTROSKA;

            public event MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler MJESTOTROSKARowChanged;

            public event MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler MJESTOTROSKARowChanging;

            public event MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler MJESTOTROSKARowDeleted;

            public event MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler MJESTOTROSKARowDeleting;

            public MJESTOTROSKADataTable()
            {
                this.TableName = "MJESTOTROSKA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal MJESTOTROSKADataTable(DataTable table) : base(table.TableName)
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

            protected MJESTOTROSKADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddMJESTOTROSKARow(MJESTOTROSKADataSet.MJESTOTROSKARow row)
            {
                this.Rows.Add(row);
            }

            public MJESTOTROSKADataSet.MJESTOTROSKARow AddMJESTOTROSKARow(int iDMJESTOTROSKA, string nAZIVMJESTOTROSKA)
            {
                MJESTOTROSKADataSet.MJESTOTROSKARow row = (MJESTOTROSKADataSet.MJESTOTROSKARow) this.NewRow();
                row["IDMJESTOTROSKA"] = iDMJESTOTROSKA;
                row["NAZIVMJESTOTROSKA"] = nAZIVMJESTOTROSKA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                MJESTOTROSKADataSet.MJESTOTROSKADataTable table = (MJESTOTROSKADataSet.MJESTOTROSKADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public MJESTOTROSKADataSet.MJESTOTROSKARow FindByIDMJESTOTROSKA(int iDMJESTOTROSKA)
            {
                return (MJESTOTROSKADataSet.MJESTOTROSKARow) this.Rows.Find(new object[] { iDMJESTOTROSKA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(MJESTOTROSKADataSet.MJESTOTROSKARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                MJESTOTROSKADataSet set = new MJESTOTROSKADataSet();
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
                this.columnIDMJESTOTROSKA = new DataColumn("IDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnIDMJESTOTROSKA.AllowDBNull = false;
                this.columnIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnIDMJESTOTROSKA.Unique = true;
                this.columnIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "IDMJESTOTROSKA");
                this.Columns.Add(this.columnIDMJESTOTROSKA);
                this.columnNAZIVMJESTOTROSKA = new DataColumn("NAZIVMJESTOTROSKA", typeof(string), "", MappingType.Element);
                this.columnNAZIVMJESTOTROSKA.AllowDBNull = false;
                this.columnNAZIVMJESTOTROSKA.Caption = "Naziv MT";
                this.columnNAZIVMJESTOTROSKA.MaxLength = 120;
                this.columnNAZIVMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Description", "Naziv MT");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Length", "120");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVMJESTOTROSKA");
                this.Columns.Add(this.columnNAZIVMJESTOTROSKA);
                this.columnmt = new DataColumn("mt", typeof(string), "", MappingType.Element);
                this.columnmt.AllowDBNull = true;
                this.columnmt.Caption = "mt";
                this.columnmt.MaxLength = 130;
                this.columnmt.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmt.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnmt.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnmt.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnmt.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmt.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmt.ExtendedProperties.Add("IsKey", "false");
                this.columnmt.ExtendedProperties.Add("ReadOnly", "true");
                this.columnmt.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnmt.ExtendedProperties.Add("Description", "mt");
                this.columnmt.ExtendedProperties.Add("Length", "130");
                this.columnmt.ExtendedProperties.Add("Decimals", "0");
                this.columnmt.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnmt.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmt.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmt.ExtendedProperties.Add("Deklarit.InternalName", "mt");
                this.Columns.Add(this.columnmt);
                this.PrimaryKey = new DataColumn[] { this.columnIDMJESTOTROSKA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "MJESTOTROSKA");
                this.ExtendedProperties.Add("Description", "MJESTOTROSKA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDMJESTOTROSKA = this.Columns["IDMJESTOTROSKA"];
                this.columnNAZIVMJESTOTROSKA = this.Columns["NAZIVMJESTOTROSKA"];
                this.columnmt = this.Columns["mt"];
            }

            public MJESTOTROSKADataSet.MJESTOTROSKARow NewMJESTOTROSKARow()
            {
                return (MJESTOTROSKADataSet.MJESTOTROSKARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new MJESTOTROSKADataSet.MJESTOTROSKARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.MJESTOTROSKARowChanged != null)
                {
                    MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler mJESTOTROSKARowChangedEvent = this.MJESTOTROSKARowChanged;
                    if (mJESTOTROSKARowChangedEvent != null)
                    {
                        mJESTOTROSKARowChangedEvent(this, new MJESTOTROSKADataSet.MJESTOTROSKARowChangeEvent((MJESTOTROSKADataSet.MJESTOTROSKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.MJESTOTROSKARowChanging != null)
                {
                    MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler mJESTOTROSKARowChangingEvent = this.MJESTOTROSKARowChanging;
                    if (mJESTOTROSKARowChangingEvent != null)
                    {
                        mJESTOTROSKARowChangingEvent(this, new MJESTOTROSKADataSet.MJESTOTROSKARowChangeEvent((MJESTOTROSKADataSet.MJESTOTROSKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.MJESTOTROSKARowDeleted != null)
                {
                    MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler mJESTOTROSKARowDeletedEvent = this.MJESTOTROSKARowDeleted;
                    if (mJESTOTROSKARowDeletedEvent != null)
                    {
                        mJESTOTROSKARowDeletedEvent(this, new MJESTOTROSKADataSet.MJESTOTROSKARowChangeEvent((MJESTOTROSKADataSet.MJESTOTROSKARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.MJESTOTROSKARowDeleting != null)
                {
                    MJESTOTROSKADataSet.MJESTOTROSKARowChangeEventHandler mJESTOTROSKARowDeletingEvent = this.MJESTOTROSKARowDeleting;
                    if (mJESTOTROSKARowDeletingEvent != null)
                    {
                        mJESTOTROSKARowDeletingEvent(this, new MJESTOTROSKADataSet.MJESTOTROSKARowChangeEvent((MJESTOTROSKADataSet.MJESTOTROSKARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveMJESTOTROSKARow(MJESTOTROSKADataSet.MJESTOTROSKARow row)
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

            public DataColumn IDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnIDMJESTOTROSKA;
                }
            }

            public MJESTOTROSKADataSet.MJESTOTROSKARow this[int index]
            {
                get
                {
                    return (MJESTOTROSKADataSet.MJESTOTROSKARow) this.Rows[index];
                }
            }

            public DataColumn mtColumn
            {
                get
                {
                    return this.columnmt;
                }
            }

            public DataColumn NAZIVMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnNAZIVMJESTOTROSKA;
                }
            }
        }

        public class MJESTOTROSKARow : DataRow
        {
            private MJESTOTROSKADataSet.MJESTOTROSKADataTable tableMJESTOTROSKA;

            internal MJESTOTROSKARow(DataRowBuilder rb) : base(rb)
            {
                this.tableMJESTOTROSKA = (MJESTOTROSKADataSet.MJESTOTROSKADataTable) this.Table;
            }

            public bool IsIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableMJESTOTROSKA.IDMJESTOTROSKAColumn);
            }

            public bool IsmtNull()
            {
                return this.IsNull(this.tableMJESTOTROSKA.mtColumn);
            }

            public bool IsNAZIVMJESTOTROSKANull()
            {
                return this.IsNull(this.tableMJESTOTROSKA.NAZIVMJESTOTROSKAColumn);
            }

            public void SetmtNull()
            {
                this[this.tableMJESTOTROSKA.mtColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVMJESTOTROSKANull()
            {
                this[this.tableMJESTOTROSKA.NAZIVMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDMJESTOTROSKA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableMJESTOTROSKA.IDMJESTOTROSKAColumn]);
                }
                set
                {
                    this[this.tableMJESTOTROSKA.IDMJESTOTROSKAColumn] = value;
                }
            }

            public string mt
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableMJESTOTROSKA.mtColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value mt because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableMJESTOTROSKA.mtColumn] = value;
                }
            }

            public string NAZIVMJESTOTROSKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableMJESTOTROSKA.NAZIVMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVMJESTOTROSKA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableMJESTOTROSKA.NAZIVMJESTOTROSKAColumn] = value;
                }
            }
        }

        public class MJESTOTROSKARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private MJESTOTROSKADataSet.MJESTOTROSKARow eventRow;

            public MJESTOTROSKARowChangeEvent(MJESTOTROSKADataSet.MJESTOTROSKARow row, DataRowAction action)
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

            public MJESTOTROSKADataSet.MJESTOTROSKARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void MJESTOTROSKARowChangeEventHandler(object sender, MJESTOTROSKADataSet.MJESTOTROSKARowChangeEvent e);
    }
}

