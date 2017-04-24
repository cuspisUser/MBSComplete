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
    public class DRZAVLJANSTVODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DRZAVLJANSTVODataTable tableDRZAVLJANSTVO;

        public DRZAVLJANSTVODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DRZAVLJANSTVODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DRZAVLJANSTVO"] != null)
                    {
                        this.Tables.Add(new DRZAVLJANSTVODataTable(dataSet.Tables["DRZAVLJANSTVO"]));
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
            DRZAVLJANSTVODataSet set = (DRZAVLJANSTVODataSet) base.Clone();
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
            DRZAVLJANSTVODataSet set = new DRZAVLJANSTVODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DRZAVLJANSTVODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2150");
            this.ExtendedProperties.Add("DataSetName", "DRZAVLJANSTVODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDRZAVLJANSTVODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DRZAVLJANSTVO");
            this.ExtendedProperties.Add("ObjectDescription", "Državljanstvo");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVDRZAVLJANSTVO");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "DRZAVLJANSTVODataSet";
            this.Namespace = "http://www.tempuri.org/DRZAVLJANSTVO";
            this.tableDRZAVLJANSTVO = new DRZAVLJANSTVODataTable();
            this.Tables.Add(this.tableDRZAVLJANSTVO);
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
            this.tableDRZAVLJANSTVO = (DRZAVLJANSTVODataTable) this.Tables["DRZAVLJANSTVO"];
            if (initTable && (this.tableDRZAVLJANSTVO != null))
            {
                this.tableDRZAVLJANSTVO.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DRZAVLJANSTVO"] != null)
                {
                    this.Tables.Add(new DRZAVLJANSTVODataTable(dataSet.Tables["DRZAVLJANSTVO"]));
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

        private bool ShouldSerializeDRZAVLJANSTVO()
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
        public DRZAVLJANSTVODataTable DRZAVLJANSTVO
        {
            get
            {
                return this.tableDRZAVLJANSTVO;
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
        public class DRZAVLJANSTVODataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDRZAVLJANSTVO;
            private DataColumn columnNAZIVDRZAVLJANSTVO;

            public event DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler DRZAVLJANSTVORowChanged;

            public event DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler DRZAVLJANSTVORowChanging;

            public event DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler DRZAVLJANSTVORowDeleted;

            public event DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler DRZAVLJANSTVORowDeleting;

            public DRZAVLJANSTVODataTable()
            {
                this.TableName = "DRZAVLJANSTVO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DRZAVLJANSTVODataTable(DataTable table) : base(table.TableName)
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

            protected DRZAVLJANSTVODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDRZAVLJANSTVORow(DRZAVLJANSTVODataSet.DRZAVLJANSTVORow row)
            {
                this.Rows.Add(row);
            }

            public DRZAVLJANSTVODataSet.DRZAVLJANSTVORow AddDRZAVLJANSTVORow(int iDDRZAVLJANSTVO, string nAZIVDRZAVLJANSTVO)
            {
                DRZAVLJANSTVODataSet.DRZAVLJANSTVORow row = (DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) this.NewRow();
                row["IDDRZAVLJANSTVO"] = iDDRZAVLJANSTVO;
                row["NAZIVDRZAVLJANSTVO"] = nAZIVDRZAVLJANSTVO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DRZAVLJANSTVODataSet.DRZAVLJANSTVODataTable table = (DRZAVLJANSTVODataSet.DRZAVLJANSTVODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DRZAVLJANSTVODataSet.DRZAVLJANSTVORow FindByIDDRZAVLJANSTVO(int iDDRZAVLJANSTVO)
            {
                return (DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) this.Rows.Find(new object[] { iDDRZAVLJANSTVO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DRZAVLJANSTVODataSet.DRZAVLJANSTVORow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DRZAVLJANSTVODataSet set = new DRZAVLJANSTVODataSet();
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
                this.columnIDDRZAVLJANSTVO = new DataColumn("IDDRZAVLJANSTVO", typeof(int), "", MappingType.Element);
                this.columnIDDRZAVLJANSTVO.AllowDBNull = false;
                this.columnIDDRZAVLJANSTVO.Caption = "IDDRZAVLJANSTVO";
                this.columnIDDRZAVLJANSTVO.Unique = true;
                this.columnIDDRZAVLJANSTVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("IsKey", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Length", "5");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.InternalName", "IDDRZAVLJANSTVO");
                this.Columns.Add(this.columnIDDRZAVLJANSTVO);
                this.columnNAZIVDRZAVLJANSTVO = new DataColumn("NAZIVDRZAVLJANSTVO", typeof(string), "", MappingType.Element);
                this.columnNAZIVDRZAVLJANSTVO.AllowDBNull = false;
                this.columnNAZIVDRZAVLJANSTVO.Caption = "NAZIVDRZAVLJANSTVO";
                this.columnNAZIVDRZAVLJANSTVO.MaxLength = 50;
                this.columnNAZIVDRZAVLJANSTVO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Description", "Drzavljanstvo");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDRZAVLJANSTVO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDRZAVLJANSTVO");
                this.Columns.Add(this.columnNAZIVDRZAVLJANSTVO);
                this.PrimaryKey = new DataColumn[] { this.columnIDDRZAVLJANSTVO };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DRZAVLJANSTVO");
                this.ExtendedProperties.Add("Description", "Državljanstvo");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDDRZAVLJANSTVO = this.Columns["IDDRZAVLJANSTVO"];
                this.columnNAZIVDRZAVLJANSTVO = this.Columns["NAZIVDRZAVLJANSTVO"];
            }

            public DRZAVLJANSTVODataSet.DRZAVLJANSTVORow NewDRZAVLJANSTVORow()
            {
                return (DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DRZAVLJANSTVODataSet.DRZAVLJANSTVORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DRZAVLJANSTVORowChanged != null)
                {
                    DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler dRZAVLJANSTVORowChangedEvent = this.DRZAVLJANSTVORowChanged;
                    if (dRZAVLJANSTVORowChangedEvent != null)
                    {
                        dRZAVLJANSTVORowChangedEvent(this, new DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEvent((DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DRZAVLJANSTVORowChanging != null)
                {
                    DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler dRZAVLJANSTVORowChangingEvent = this.DRZAVLJANSTVORowChanging;
                    if (dRZAVLJANSTVORowChangingEvent != null)
                    {
                        dRZAVLJANSTVORowChangingEvent(this, new DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEvent((DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DRZAVLJANSTVORowDeleted != null)
                {
                    DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler dRZAVLJANSTVORowDeletedEvent = this.DRZAVLJANSTVORowDeleted;
                    if (dRZAVLJANSTVORowDeletedEvent != null)
                    {
                        dRZAVLJANSTVORowDeletedEvent(this, new DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEvent((DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DRZAVLJANSTVORowDeleting != null)
                {
                    DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEventHandler dRZAVLJANSTVORowDeletingEvent = this.DRZAVLJANSTVORowDeleting;
                    if (dRZAVLJANSTVORowDeletingEvent != null)
                    {
                        dRZAVLJANSTVORowDeletingEvent(this, new DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEvent((DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDRZAVLJANSTVORow(DRZAVLJANSTVODataSet.DRZAVLJANSTVORow row)
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

            public DataColumn IDDRZAVLJANSTVOColumn
            {
                get
                {
                    return this.columnIDDRZAVLJANSTVO;
                }
            }

            public DRZAVLJANSTVODataSet.DRZAVLJANSTVORow this[int index]
            {
                get
                {
                    return (DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) this.Rows[index];
                }
            }

            public DataColumn NAZIVDRZAVLJANSTVOColumn
            {
                get
                {
                    return this.columnNAZIVDRZAVLJANSTVO;
                }
            }
        }

        public class DRZAVLJANSTVORow : DataRow
        {
            private DRZAVLJANSTVODataSet.DRZAVLJANSTVODataTable tableDRZAVLJANSTVO;

            internal DRZAVLJANSTVORow(DataRowBuilder rb) : base(rb)
            {
                this.tableDRZAVLJANSTVO = (DRZAVLJANSTVODataSet.DRZAVLJANSTVODataTable) this.Table;
            }

            public bool IsIDDRZAVLJANSTVONull()
            {
                return this.IsNull(this.tableDRZAVLJANSTVO.IDDRZAVLJANSTVOColumn);
            }

            public bool IsNAZIVDRZAVLJANSTVONull()
            {
                return this.IsNull(this.tableDRZAVLJANSTVO.NAZIVDRZAVLJANSTVOColumn);
            }

            public void SetNAZIVDRZAVLJANSTVONull()
            {
                this[this.tableDRZAVLJANSTVO.NAZIVDRZAVLJANSTVOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDRZAVLJANSTVO
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDRZAVLJANSTVO.IDDRZAVLJANSTVOColumn]);
                }
                set
                {
                    this[this.tableDRZAVLJANSTVO.IDDRZAVLJANSTVOColumn] = value;
                }
            }

            public string NAZIVDRZAVLJANSTVO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDRZAVLJANSTVO.NAZIVDRZAVLJANSTVOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVDRZAVLJANSTVO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDRZAVLJANSTVO.NAZIVDRZAVLJANSTVOColumn] = value;
                }
            }
        }

        public class DRZAVLJANSTVORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DRZAVLJANSTVODataSet.DRZAVLJANSTVORow eventRow;

            public DRZAVLJANSTVORowChangeEvent(DRZAVLJANSTVODataSet.DRZAVLJANSTVORow row, DataRowAction action)
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

            public DRZAVLJANSTVODataSet.DRZAVLJANSTVORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DRZAVLJANSTVORowChangeEventHandler(object sender, DRZAVLJANSTVODataSet.DRZAVLJANSTVORowChangeEvent e);
    }
}

