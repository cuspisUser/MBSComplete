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
    public class MZOSTABLICEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private MZOSTABLICEDataTable tableMZOSTABLICE;

        public MZOSTABLICEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected MZOSTABLICEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["MZOSTABLICE"] != null)
                    {
                        this.Tables.Add(new MZOSTABLICEDataTable(dataSet.Tables["MZOSTABLICE"]));
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
            MZOSTABLICEDataSet set = (MZOSTABLICEDataSet) base.Clone();
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
            MZOSTABLICEDataSet set = new MZOSTABLICEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "MZOSTABLICEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2070");
            this.ExtendedProperties.Add("DataSetName", "MZOSTABLICEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IMZOSTABLICEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "MZOSTABLICE");
            this.ExtendedProperties.Add("ObjectDescription", "MZOŠ Tablica");
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
            this.DataSetName = "MZOSTABLICEDataSet";
            this.Namespace = "http://www.tempuri.org/MZOSTABLICE";
            this.tableMZOSTABLICE = new MZOSTABLICEDataTable();
            this.Tables.Add(this.tableMZOSTABLICE);
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
            this.tableMZOSTABLICE = (MZOSTABLICEDataTable) this.Tables["MZOSTABLICE"];
            if (initTable && (this.tableMZOSTABLICE != null))
            {
                this.tableMZOSTABLICE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["MZOSTABLICE"] != null)
                {
                    this.Tables.Add(new MZOSTABLICEDataTable(dataSet.Tables["MZOSTABLICE"]));
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

        private bool ShouldSerializeMZOSTABLICE()
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
        public MZOSTABLICEDataTable MZOSTABLICE
        {
            get
            {
                return this.tableMZOSTABLICE;
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
        public class MZOSTABLICEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDMZOSTABLICE;
            private DataColumn columnOPISMZOSTABLICE;

            public event MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler MZOSTABLICERowChanged;

            public event MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler MZOSTABLICERowChanging;

            public event MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler MZOSTABLICERowDeleted;

            public event MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler MZOSTABLICERowDeleting;

            public MZOSTABLICEDataTable()
            {
                this.TableName = "MZOSTABLICE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal MZOSTABLICEDataTable(DataTable table) : base(table.TableName)
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

            protected MZOSTABLICEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddMZOSTABLICERow(MZOSTABLICEDataSet.MZOSTABLICERow row)
            {
                this.Rows.Add(row);
            }

            public MZOSTABLICEDataSet.MZOSTABLICERow AddMZOSTABLICERow(int iDMZOSTABLICE, string oPISMZOSTABLICE)
            {
                MZOSTABLICEDataSet.MZOSTABLICERow row = (MZOSTABLICEDataSet.MZOSTABLICERow) this.NewRow();
                row["IDMZOSTABLICE"] = iDMZOSTABLICE;
                row["OPISMZOSTABLICE"] = oPISMZOSTABLICE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                MZOSTABLICEDataSet.MZOSTABLICEDataTable table = (MZOSTABLICEDataSet.MZOSTABLICEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public MZOSTABLICEDataSet.MZOSTABLICERow FindByIDMZOSTABLICE(int iDMZOSTABLICE)
            {
                return (MZOSTABLICEDataSet.MZOSTABLICERow) this.Rows.Find(new object[] { iDMZOSTABLICE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(MZOSTABLICEDataSet.MZOSTABLICERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                MZOSTABLICEDataSet set = new MZOSTABLICEDataSet();
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
                this.columnIDMZOSTABLICE = new DataColumn("IDMZOSTABLICE", typeof(int), "", MappingType.Element);
                this.columnIDMZOSTABLICE.AllowDBNull = false;
                this.columnIDMZOSTABLICE.Caption = "Šifra tablice";
                this.columnIDMZOSTABLICE.Unique = true;
                this.columnIDMZOSTABLICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Description", "Šifra tablice");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Length", "5");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.InternalName", "IDMZOSTABLICE");
                this.Columns.Add(this.columnIDMZOSTABLICE);
                this.columnOPISMZOSTABLICE = new DataColumn("OPISMZOSTABLICE", typeof(string), "", MappingType.Element);
                this.columnOPISMZOSTABLICE.AllowDBNull = false;
                this.columnOPISMZOSTABLICE.Caption = "Naziv tablice";
                this.columnOPISMZOSTABLICE.MaxLength = 20;
                this.columnOPISMZOSTABLICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Description", "Naziv tablice");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Length", "20");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISMZOSTABLICE.ExtendedProperties.Add("Deklarit.InternalName", "OPISMZOSTABLICE");
                this.Columns.Add(this.columnOPISMZOSTABLICE);
                this.PrimaryKey = new DataColumn[] { this.columnIDMZOSTABLICE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "MZOSTABLICE");
                this.ExtendedProperties.Add("Description", "MZOŠ Tablica");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDMZOSTABLICE = this.Columns["IDMZOSTABLICE"];
                this.columnOPISMZOSTABLICE = this.Columns["OPISMZOSTABLICE"];
            }

            public MZOSTABLICEDataSet.MZOSTABLICERow NewMZOSTABLICERow()
            {
                return (MZOSTABLICEDataSet.MZOSTABLICERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new MZOSTABLICEDataSet.MZOSTABLICERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.MZOSTABLICERowChanged != null)
                {
                    MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler mZOSTABLICERowChangedEvent = this.MZOSTABLICERowChanged;
                    if (mZOSTABLICERowChangedEvent != null)
                    {
                        mZOSTABLICERowChangedEvent(this, new MZOSTABLICEDataSet.MZOSTABLICERowChangeEvent((MZOSTABLICEDataSet.MZOSTABLICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.MZOSTABLICERowChanging != null)
                {
                    MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler mZOSTABLICERowChangingEvent = this.MZOSTABLICERowChanging;
                    if (mZOSTABLICERowChangingEvent != null)
                    {
                        mZOSTABLICERowChangingEvent(this, new MZOSTABLICEDataSet.MZOSTABLICERowChangeEvent((MZOSTABLICEDataSet.MZOSTABLICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.MZOSTABLICERowDeleted != null)
                {
                    MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler mZOSTABLICERowDeletedEvent = this.MZOSTABLICERowDeleted;
                    if (mZOSTABLICERowDeletedEvent != null)
                    {
                        mZOSTABLICERowDeletedEvent(this, new MZOSTABLICEDataSet.MZOSTABLICERowChangeEvent((MZOSTABLICEDataSet.MZOSTABLICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.MZOSTABLICERowDeleting != null)
                {
                    MZOSTABLICEDataSet.MZOSTABLICERowChangeEventHandler mZOSTABLICERowDeletingEvent = this.MZOSTABLICERowDeleting;
                    if (mZOSTABLICERowDeletingEvent != null)
                    {
                        mZOSTABLICERowDeletingEvent(this, new MZOSTABLICEDataSet.MZOSTABLICERowChangeEvent((MZOSTABLICEDataSet.MZOSTABLICERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveMZOSTABLICERow(MZOSTABLICEDataSet.MZOSTABLICERow row)
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

            public DataColumn IDMZOSTABLICEColumn
            {
                get
                {
                    return this.columnIDMZOSTABLICE;
                }
            }

            public MZOSTABLICEDataSet.MZOSTABLICERow this[int index]
            {
                get
                {
                    return (MZOSTABLICEDataSet.MZOSTABLICERow) this.Rows[index];
                }
            }

            public DataColumn OPISMZOSTABLICEColumn
            {
                get
                {
                    return this.columnOPISMZOSTABLICE;
                }
            }
        }

        public class MZOSTABLICERow : DataRow
        {
            private MZOSTABLICEDataSet.MZOSTABLICEDataTable tableMZOSTABLICE;

            internal MZOSTABLICERow(DataRowBuilder rb) : base(rb)
            {
                this.tableMZOSTABLICE = (MZOSTABLICEDataSet.MZOSTABLICEDataTable) this.Table;
            }

            public bool IsIDMZOSTABLICENull()
            {
                return this.IsNull(this.tableMZOSTABLICE.IDMZOSTABLICEColumn);
            }

            public bool IsOPISMZOSTABLICENull()
            {
                return this.IsNull(this.tableMZOSTABLICE.OPISMZOSTABLICEColumn);
            }

            public void SetOPISMZOSTABLICENull()
            {
                this[this.tableMZOSTABLICE.OPISMZOSTABLICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDMZOSTABLICE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableMZOSTABLICE.IDMZOSTABLICEColumn]);
                }
                set
                {
                    this[this.tableMZOSTABLICE.IDMZOSTABLICEColumn] = value;
                }
            }

            public string OPISMZOSTABLICE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableMZOSTABLICE.OPISMZOSTABLICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPISMZOSTABLICE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableMZOSTABLICE.OPISMZOSTABLICEColumn] = value;
                }
            }
        }

        public class MZOSTABLICERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private MZOSTABLICEDataSet.MZOSTABLICERow eventRow;

            public MZOSTABLICERowChangeEvent(MZOSTABLICEDataSet.MZOSTABLICERow row, DataRowAction action)
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

            public MZOSTABLICEDataSet.MZOSTABLICERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void MZOSTABLICERowChangeEventHandler(object sender, MZOSTABLICEDataSet.MZOSTABLICERowChangeEvent e);
    }
}

