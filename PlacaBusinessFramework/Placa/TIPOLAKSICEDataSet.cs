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
    public class TIPOLAKSICEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TIPOLAKSICEDataTable tableTIPOLAKSICE;

        public TIPOLAKSICEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected TIPOLAKSICEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TIPOLAKSICE"] != null)
                    {
                        this.Tables.Add(new TIPOLAKSICEDataTable(dataSet.Tables["TIPOLAKSICE"]));
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
            TIPOLAKSICEDataSet set = (TIPOLAKSICEDataSet) base.Clone();
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
            TIPOLAKSICEDataSet set = new TIPOLAKSICEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "TIPOLAKSICEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1026");
            this.ExtendedProperties.Add("DataSetName", "TIPOLAKSICEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ITIPOLAKSICEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "TIPOLAKSICE");
            this.ExtendedProperties.Add("ObjectDescription", "Tipovi olakšica");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVTIPOLAKSICE");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "TIPOLAKSICEDataSet";
            this.Namespace = "http://www.tempuri.org/TIPOLAKSICE";
            this.tableTIPOLAKSICE = new TIPOLAKSICEDataTable();
            this.Tables.Add(this.tableTIPOLAKSICE);
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
            this.tableTIPOLAKSICE = (TIPOLAKSICEDataTable) this.Tables["TIPOLAKSICE"];
            if (initTable && (this.tableTIPOLAKSICE != null))
            {
                this.tableTIPOLAKSICE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TIPOLAKSICE"] != null)
                {
                    this.Tables.Add(new TIPOLAKSICEDataTable(dataSet.Tables["TIPOLAKSICE"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeTIPOLAKSICE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TIPOLAKSICEDataTable TIPOLAKSICE
        {
            get
            {
                return this.tableTIPOLAKSICE;
            }
        }

        [Serializable]
        public class TIPOLAKSICEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPOLAKSICE;
            private DataColumn columnNAZIVTIPOLAKSICE;

            public event TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler TIPOLAKSICERowChanged;

            public event TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler TIPOLAKSICERowChanging;

            public event TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler TIPOLAKSICERowDeleted;

            public event TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler TIPOLAKSICERowDeleting;

            public TIPOLAKSICEDataTable()
            {
                this.TableName = "TIPOLAKSICE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal TIPOLAKSICEDataTable(DataTable table) : base(table.TableName)
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

            protected TIPOLAKSICEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddTIPOLAKSICERow(TIPOLAKSICEDataSet.TIPOLAKSICERow row)
            {
                this.Rows.Add(row);
            }

            public TIPOLAKSICEDataSet.TIPOLAKSICERow AddTIPOLAKSICERow(int iDTIPOLAKSICE, string nAZIVTIPOLAKSICE)
            {
                TIPOLAKSICEDataSet.TIPOLAKSICERow row = (TIPOLAKSICEDataSet.TIPOLAKSICERow) this.NewRow();
                row["IDTIPOLAKSICE"] = iDTIPOLAKSICE;
                row["NAZIVTIPOLAKSICE"] = nAZIVTIPOLAKSICE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                TIPOLAKSICEDataSet.TIPOLAKSICEDataTable table = (TIPOLAKSICEDataSet.TIPOLAKSICEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public TIPOLAKSICEDataSet.TIPOLAKSICERow FindByIDTIPOLAKSICE(int iDTIPOLAKSICE)
            {
                return (TIPOLAKSICEDataSet.TIPOLAKSICERow) this.Rows.Find(new object[] { iDTIPOLAKSICE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(TIPOLAKSICEDataSet.TIPOLAKSICERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                TIPOLAKSICEDataSet set = new TIPOLAKSICEDataSet();
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
                this.columnIDTIPOLAKSICE = new DataColumn("IDTIPOLAKSICE", typeof(int), "", MappingType.Element);
                this.columnIDTIPOLAKSICE.AllowDBNull = false;
                this.columnIDTIPOLAKSICE.Caption = "Tip olakšice";
                this.columnIDTIPOLAKSICE.Unique = true;
                this.columnIDTIPOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Description", "Tip olakšice");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPOLAKSICE");
                this.Columns.Add(this.columnIDTIPOLAKSICE);
                this.columnNAZIVTIPOLAKSICE = new DataColumn("NAZIVTIPOLAKSICE", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPOLAKSICE.AllowDBNull = false;
                this.columnNAZIVTIPOLAKSICE.Caption = "Naziv tipa olakšice";
                this.columnNAZIVTIPOLAKSICE.MaxLength = 50;
                this.columnNAZIVTIPOLAKSICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Description", "Naziv tipa olakšice");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPOLAKSICE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPOLAKSICE");
                this.Columns.Add(this.columnNAZIVTIPOLAKSICE);
                this.PrimaryKey = new DataColumn[] { this.columnIDTIPOLAKSICE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "TIPOLAKSICE");
                this.ExtendedProperties.Add("Description", "Tipovi olakšica");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDTIPOLAKSICE = this.Columns["IDTIPOLAKSICE"];
                this.columnNAZIVTIPOLAKSICE = this.Columns["NAZIVTIPOLAKSICE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TIPOLAKSICEDataSet.TIPOLAKSICERow(builder);
            }

            public TIPOLAKSICEDataSet.TIPOLAKSICERow NewTIPOLAKSICERow()
            {
                return (TIPOLAKSICEDataSet.TIPOLAKSICERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TIPOLAKSICERowChanged != null)
                {
                    TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler tIPOLAKSICERowChangedEvent = this.TIPOLAKSICERowChanged;
                    if (tIPOLAKSICERowChangedEvent != null)
                    {
                        tIPOLAKSICERowChangedEvent(this, new TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEvent((TIPOLAKSICEDataSet.TIPOLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TIPOLAKSICERowChanging != null)
                {
                    TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler tIPOLAKSICERowChangingEvent = this.TIPOLAKSICERowChanging;
                    if (tIPOLAKSICERowChangingEvent != null)
                    {
                        tIPOLAKSICERowChangingEvent(this, new TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEvent((TIPOLAKSICEDataSet.TIPOLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TIPOLAKSICERowDeleted != null)
                {
                    TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler tIPOLAKSICERowDeletedEvent = this.TIPOLAKSICERowDeleted;
                    if (tIPOLAKSICERowDeletedEvent != null)
                    {
                        tIPOLAKSICERowDeletedEvent(this, new TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEvent((TIPOLAKSICEDataSet.TIPOLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TIPOLAKSICERowDeleting != null)
                {
                    TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEventHandler tIPOLAKSICERowDeletingEvent = this.TIPOLAKSICERowDeleting;
                    if (tIPOLAKSICERowDeletingEvent != null)
                    {
                        tIPOLAKSICERowDeletingEvent(this, new TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEvent((TIPOLAKSICEDataSet.TIPOLAKSICERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveTIPOLAKSICERow(TIPOLAKSICEDataSet.TIPOLAKSICERow row)
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

            public DataColumn IDTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnIDTIPOLAKSICE;
                }
            }

            public TIPOLAKSICEDataSet.TIPOLAKSICERow this[int index]
            {
                get
                {
                    return (TIPOLAKSICEDataSet.TIPOLAKSICERow) this.Rows[index];
                }
            }

            public DataColumn NAZIVTIPOLAKSICEColumn
            {
                get
                {
                    return this.columnNAZIVTIPOLAKSICE;
                }
            }
        }

        public class TIPOLAKSICERow : DataRow
        {
            private TIPOLAKSICEDataSet.TIPOLAKSICEDataTable tableTIPOLAKSICE;

            internal TIPOLAKSICERow(DataRowBuilder rb) : base(rb)
            {
                this.tableTIPOLAKSICE = (TIPOLAKSICEDataSet.TIPOLAKSICEDataTable) this.Table;
            }

            public bool IsIDTIPOLAKSICENull()
            {
                return this.IsNull(this.tableTIPOLAKSICE.IDTIPOLAKSICEColumn);
            }

            public bool IsNAZIVTIPOLAKSICENull()
            {
                return this.IsNull(this.tableTIPOLAKSICE.NAZIVTIPOLAKSICEColumn);
            }

            public void SetNAZIVTIPOLAKSICENull()
            {
                this[this.tableTIPOLAKSICE.NAZIVTIPOLAKSICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPOLAKSICE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTIPOLAKSICE.IDTIPOLAKSICEColumn]);
                }
                set
                {
                    this[this.tableTIPOLAKSICE.IDTIPOLAKSICEColumn] = value;
                }
            }

            public string NAZIVTIPOLAKSICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPOLAKSICE.NAZIVTIPOLAKSICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVTIPOLAKSICE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPOLAKSICE.NAZIVTIPOLAKSICEColumn] = value;
                }
            }
        }

        public class TIPOLAKSICERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private TIPOLAKSICEDataSet.TIPOLAKSICERow eventRow;

            public TIPOLAKSICERowChangeEvent(TIPOLAKSICEDataSet.TIPOLAKSICERow row, DataRowAction action)
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

            public TIPOLAKSICEDataSet.TIPOLAKSICERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TIPOLAKSICERowChangeEventHandler(object sender, TIPOLAKSICEDataSet.TIPOLAKSICERowChangeEvent e);
    }
}

