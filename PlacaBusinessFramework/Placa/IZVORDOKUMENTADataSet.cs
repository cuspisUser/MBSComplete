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
    public class IZVORDOKUMENTADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private IZVORDOKUMENTADataTable tableIZVORDOKUMENTA;

        public IZVORDOKUMENTADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected IZVORDOKUMENTADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["IZVORDOKUMENTA"] != null)
                    {
                        this.Tables.Add(new IZVORDOKUMENTADataTable(dataSet.Tables["IZVORDOKUMENTA"]));
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
            IZVORDOKUMENTADataSet set = (IZVORDOKUMENTADataSet) base.Clone();
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
            IZVORDOKUMENTADataSet set = new IZVORDOKUMENTADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "IZVORDOKUMENTADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2022");
            this.ExtendedProperties.Add("DataSetName", "IZVORDOKUMENTADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IIZVORDOKUMENTADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "IZVORDOKUMENTA");
            this.ExtendedProperties.Add("ObjectDescription", "IZVORDOKUMENTA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "IZVORDOKUMENTADataSet";
            this.Namespace = "http://www.tempuri.org/IZVORDOKUMENTA";
            this.tableIZVORDOKUMENTA = new IZVORDOKUMENTADataTable();
            this.Tables.Add(this.tableIZVORDOKUMENTA);
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
            this.tableIZVORDOKUMENTA = (IZVORDOKUMENTADataTable) this.Tables["IZVORDOKUMENTA"];
            if (initTable && (this.tableIZVORDOKUMENTA != null))
            {
                this.tableIZVORDOKUMENTA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["IZVORDOKUMENTA"] != null)
                {
                    this.Tables.Add(new IZVORDOKUMENTADataTable(dataSet.Tables["IZVORDOKUMENTA"]));
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

        private bool ShouldSerializeIZVORDOKUMENTA()
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
        public IZVORDOKUMENTADataTable IZVORDOKUMENTA
        {
            get
            {
                return this.tableIZVORDOKUMENTA;
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
        public class IZVORDOKUMENTADataTable : DataTable, IEnumerable
        {
            private DataColumn columnNAZIVIZVORA;
            private DataColumn columnSIFRAIZVORA;

            public event IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler IZVORDOKUMENTARowChanged;

            public event IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler IZVORDOKUMENTARowChanging;

            public event IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler IZVORDOKUMENTARowDeleted;

            public event IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler IZVORDOKUMENTARowDeleting;

            public IZVORDOKUMENTADataTable()
            {
                this.TableName = "IZVORDOKUMENTA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal IZVORDOKUMENTADataTable(DataTable table) : base(table.TableName)
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

            protected IZVORDOKUMENTADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddIZVORDOKUMENTARow(IZVORDOKUMENTADataSet.IZVORDOKUMENTARow row)
            {
                this.Rows.Add(row);
            }

            public IZVORDOKUMENTADataSet.IZVORDOKUMENTARow AddIZVORDOKUMENTARow(string sIFRAIZVORA, string nAZIVIZVORA)
            {
                IZVORDOKUMENTADataSet.IZVORDOKUMENTARow row = (IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) this.NewRow();
                row["SIFRAIZVORA"] = sIFRAIZVORA;
                row["NAZIVIZVORA"] = nAZIVIZVORA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                IZVORDOKUMENTADataSet.IZVORDOKUMENTADataTable table = (IZVORDOKUMENTADataSet.IZVORDOKUMENTADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IZVORDOKUMENTADataSet.IZVORDOKUMENTARow FindBySIFRAIZVORA(string sIFRAIZVORA)
            {
                return (IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) this.Rows.Find(new object[] { sIFRAIZVORA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(IZVORDOKUMENTADataSet.IZVORDOKUMENTARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IZVORDOKUMENTADataSet set = new IZVORDOKUMENTADataSet();
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
                this.columnSIFRAIZVORA = new DataColumn("SIFRAIZVORA", typeof(string), "", MappingType.Element);
                this.columnSIFRAIZVORA.AllowDBNull = false;
                this.columnSIFRAIZVORA.Caption = "SIFRAIZVORA";
                this.columnSIFRAIZVORA.MaxLength = 3;
                this.columnSIFRAIZVORA.Unique = true;
                this.columnSIFRAIZVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("IsKey", "true");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Description", "SIFRAIZVORA");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Length", "3");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAIZVORA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAIZVORA");
                this.Columns.Add(this.columnSIFRAIZVORA);
                this.columnNAZIVIZVORA = new DataColumn("NAZIVIZVORA", typeof(string), "", MappingType.Element);
                this.columnNAZIVIZVORA.AllowDBNull = false;
                this.columnNAZIVIZVORA.Caption = "NAZIVIZVORA";
                this.columnNAZIVIZVORA.MaxLength = 20;
                this.columnNAZIVIZVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Description", "NAZIVIZVORA");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVIZVORA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVIZVORA");
                this.Columns.Add(this.columnNAZIVIZVORA);
                this.PrimaryKey = new DataColumn[] { this.columnSIFRAIZVORA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "IZVORDOKUMENTA");
                this.ExtendedProperties.Add("Description", "IZVORDOKUMENTA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnSIFRAIZVORA = this.Columns["SIFRAIZVORA"];
                this.columnNAZIVIZVORA = this.Columns["NAZIVIZVORA"];
            }

            public IZVORDOKUMENTADataSet.IZVORDOKUMENTARow NewIZVORDOKUMENTARow()
            {
                return (IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IZVORDOKUMENTADataSet.IZVORDOKUMENTARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.IZVORDOKUMENTARowChanged != null)
                {
                    IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler iZVORDOKUMENTARowChangedEvent = this.IZVORDOKUMENTARowChanged;
                    if (iZVORDOKUMENTARowChangedEvent != null)
                    {
                        iZVORDOKUMENTARowChangedEvent(this, new IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEvent((IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.IZVORDOKUMENTARowChanging != null)
                {
                    IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler iZVORDOKUMENTARowChangingEvent = this.IZVORDOKUMENTARowChanging;
                    if (iZVORDOKUMENTARowChangingEvent != null)
                    {
                        iZVORDOKUMENTARowChangingEvent(this, new IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEvent((IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.IZVORDOKUMENTARowDeleted != null)
                {
                    IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler iZVORDOKUMENTARowDeletedEvent = this.IZVORDOKUMENTARowDeleted;
                    if (iZVORDOKUMENTARowDeletedEvent != null)
                    {
                        iZVORDOKUMENTARowDeletedEvent(this, new IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEvent((IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.IZVORDOKUMENTARowDeleting != null)
                {
                    IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEventHandler iZVORDOKUMENTARowDeletingEvent = this.IZVORDOKUMENTARowDeleting;
                    if (iZVORDOKUMENTARowDeletingEvent != null)
                    {
                        iZVORDOKUMENTARowDeletingEvent(this, new IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEvent((IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveIZVORDOKUMENTARow(IZVORDOKUMENTADataSet.IZVORDOKUMENTARow row)
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

            public IZVORDOKUMENTADataSet.IZVORDOKUMENTARow this[int index]
            {
                get
                {
                    return (IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVIZVORAColumn
            {
                get
                {
                    return this.columnNAZIVIZVORA;
                }
            }

            public DataColumn SIFRAIZVORAColumn
            {
                get
                {
                    return this.columnSIFRAIZVORA;
                }
            }
        }

        public class IZVORDOKUMENTARow : DataRow
        {
            private IZVORDOKUMENTADataSet.IZVORDOKUMENTADataTable tableIZVORDOKUMENTA;

            internal IZVORDOKUMENTARow(DataRowBuilder rb) : base(rb)
            {
                this.tableIZVORDOKUMENTA = (IZVORDOKUMENTADataSet.IZVORDOKUMENTADataTable) this.Table;
            }

            public bool IsNAZIVIZVORANull()
            {
                return this.IsNull(this.tableIZVORDOKUMENTA.NAZIVIZVORAColumn);
            }

            public bool IsSIFRAIZVORANull()
            {
                return this.IsNull(this.tableIZVORDOKUMENTA.SIFRAIZVORAColumn);
            }

            public void SetNAZIVIZVORANull()
            {
                this[this.tableIZVORDOKUMENTA.NAZIVIZVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string NAZIVIZVORA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableIZVORDOKUMENTA.NAZIVIZVORAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVIZVORA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableIZVORDOKUMENTA.NAZIVIZVORAColumn] = value;
                }
            }

            public string SIFRAIZVORA
            {
                get
                {
                    return Conversions.ToString(this[this.tableIZVORDOKUMENTA.SIFRAIZVORAColumn]);
                }
                set
                {
                    this[this.tableIZVORDOKUMENTA.SIFRAIZVORAColumn] = value;
                }
            }
        }

        public class IZVORDOKUMENTARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IZVORDOKUMENTADataSet.IZVORDOKUMENTARow eventRow;

            public IZVORDOKUMENTARowChangeEvent(IZVORDOKUMENTADataSet.IZVORDOKUMENTARow row, DataRowAction action)
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

            public IZVORDOKUMENTADataSet.IZVORDOKUMENTARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void IZVORDOKUMENTARowChangeEventHandler(object sender, IZVORDOKUMENTADataSet.IZVORDOKUMENTARowChangeEvent e);
    }
}

