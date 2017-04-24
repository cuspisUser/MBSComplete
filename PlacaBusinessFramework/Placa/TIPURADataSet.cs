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
    public class TIPURADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TIPURADataTable tableTIPURA;

        public TIPURADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected TIPURADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TIPURA"] != null)
                    {
                        this.Tables.Add(new TIPURADataTable(dataSet.Tables["TIPURA"]));
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
            TIPURADataSet set = (TIPURADataSet) base.Clone();
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
            TIPURADataSet set = new TIPURADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "TIPURADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2037");
            this.ExtendedProperties.Add("DataSetName", "TIPURADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ITIPURADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "TIPURA");
            this.ExtendedProperties.Add("ObjectDescription", "TIPURA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
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
            this.DataSetName = "TIPURADataSet";
            this.Namespace = "http://www.tempuri.org/TIPURA";
            this.tableTIPURA = new TIPURADataTable();
            this.Tables.Add(this.tableTIPURA);
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
            this.tableTIPURA = (TIPURADataTable) this.Tables["TIPURA"];
            if (initTable && (this.tableTIPURA != null))
            {
                this.tableTIPURA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TIPURA"] != null)
                {
                    this.Tables.Add(new TIPURADataTable(dataSet.Tables["TIPURA"]));
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

        private bool ShouldSerializeTIPURA()
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
        public TIPURADataTable TIPURA
        {
            get
            {
                return this.tableTIPURA;
            }
        }

        [Serializable]
        public class TIPURADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPURA;
            private DataColumn columnNAZIVTIPURA;

            public event TIPURADataSet.TIPURARowChangeEventHandler TIPURARowChanged;

            public event TIPURADataSet.TIPURARowChangeEventHandler TIPURARowChanging;

            public event TIPURADataSet.TIPURARowChangeEventHandler TIPURARowDeleted;

            public event TIPURADataSet.TIPURARowChangeEventHandler TIPURARowDeleting;

            public TIPURADataTable()
            {
                this.TableName = "TIPURA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal TIPURADataTable(DataTable table) : base(table.TableName)
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

            protected TIPURADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddTIPURARow(TIPURADataSet.TIPURARow row)
            {
                this.Rows.Add(row);
            }

            public TIPURADataSet.TIPURARow AddTIPURARow(int iDTIPURA, string nAZIVTIPURA)
            {
                TIPURADataSet.TIPURARow row = (TIPURADataSet.TIPURARow) this.NewRow();
                row["IDTIPURA"] = iDTIPURA;
                row["NAZIVTIPURA"] = nAZIVTIPURA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                TIPURADataSet.TIPURADataTable table = (TIPURADataSet.TIPURADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public TIPURADataSet.TIPURARow FindByIDTIPURA(int iDTIPURA)
            {
                return (TIPURADataSet.TIPURARow) this.Rows.Find(new object[] { iDTIPURA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(TIPURADataSet.TIPURARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                TIPURADataSet set = new TIPURADataSet();
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
                this.columnIDTIPURA = new DataColumn("IDTIPURA", typeof(int), "", MappingType.Element);
                this.columnIDTIPURA.AllowDBNull = false;
                this.columnIDTIPURA.Caption = "IDTIPURA";
                this.columnIDTIPURA.Unique = true;
                this.columnIDTIPURA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPURA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPURA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDTIPURA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPURA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPURA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPURA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPURA");
                this.Columns.Add(this.columnIDTIPURA);
                this.columnNAZIVTIPURA = new DataColumn("NAZIVTIPURA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPURA.AllowDBNull = false;
                this.columnNAZIVTIPURA.Caption = "NAZIVTIPURA";
                this.columnNAZIVTIPURA.MaxLength = 50;
                this.columnNAZIVTIPURA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Description", "Naziv URE");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPURA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPURA");
                this.Columns.Add(this.columnNAZIVTIPURA);
                this.PrimaryKey = new DataColumn[] { this.columnIDTIPURA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "TIPURA");
                this.ExtendedProperties.Add("Description", "TIPURA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDTIPURA = this.Columns["IDTIPURA"];
                this.columnNAZIVTIPURA = this.Columns["NAZIVTIPURA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TIPURADataSet.TIPURARow(builder);
            }

            public TIPURADataSet.TIPURARow NewTIPURARow()
            {
                return (TIPURADataSet.TIPURARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TIPURARowChanged != null)
                {
                    TIPURADataSet.TIPURARowChangeEventHandler tIPURARowChangedEvent = this.TIPURARowChanged;
                    if (tIPURARowChangedEvent != null)
                    {
                        tIPURARowChangedEvent(this, new TIPURADataSet.TIPURARowChangeEvent((TIPURADataSet.TIPURARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TIPURARowChanging != null)
                {
                    TIPURADataSet.TIPURARowChangeEventHandler tIPURARowChangingEvent = this.TIPURARowChanging;
                    if (tIPURARowChangingEvent != null)
                    {
                        tIPURARowChangingEvent(this, new TIPURADataSet.TIPURARowChangeEvent((TIPURADataSet.TIPURARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TIPURARowDeleted != null)
                {
                    TIPURADataSet.TIPURARowChangeEventHandler tIPURARowDeletedEvent = this.TIPURARowDeleted;
                    if (tIPURARowDeletedEvent != null)
                    {
                        tIPURARowDeletedEvent(this, new TIPURADataSet.TIPURARowChangeEvent((TIPURADataSet.TIPURARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TIPURARowDeleting != null)
                {
                    TIPURADataSet.TIPURARowChangeEventHandler tIPURARowDeletingEvent = this.TIPURARowDeleting;
                    if (tIPURARowDeletingEvent != null)
                    {
                        tIPURARowDeletingEvent(this, new TIPURADataSet.TIPURARowChangeEvent((TIPURADataSet.TIPURARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveTIPURARow(TIPURADataSet.TIPURARow row)
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

            public DataColumn IDTIPURAColumn
            {
                get
                {
                    return this.columnIDTIPURA;
                }
            }

            public TIPURADataSet.TIPURARow this[int index]
            {
                get
                {
                    return (TIPURADataSet.TIPURARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVTIPURAColumn
            {
                get
                {
                    return this.columnNAZIVTIPURA;
                }
            }
        }

        public class TIPURARow : DataRow
        {
            private TIPURADataSet.TIPURADataTable tableTIPURA;

            internal TIPURARow(DataRowBuilder rb) : base(rb)
            {
                this.tableTIPURA = (TIPURADataSet.TIPURADataTable) this.Table;
            }

            public bool IsIDTIPURANull()
            {
                return this.IsNull(this.tableTIPURA.IDTIPURAColumn);
            }

            public bool IsNAZIVTIPURANull()
            {
                return this.IsNull(this.tableTIPURA.NAZIVTIPURAColumn);
            }

            public void SetNAZIVTIPURANull()
            {
                this[this.tableTIPURA.NAZIVTIPURAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPURA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTIPURA.IDTIPURAColumn]);
                }
                set
                {
                    this[this.tableTIPURA.IDTIPURAColumn] = value;
                }
            }

            public string NAZIVTIPURA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPURA.NAZIVTIPURAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVTIPURA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPURA.NAZIVTIPURAColumn] = value;
                }
            }
        }

        public class TIPURARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private TIPURADataSet.TIPURARow eventRow;

            public TIPURARowChangeEvent(TIPURADataSet.TIPURARow row, DataRowAction action)
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

            public TIPURADataSet.TIPURARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TIPURARowChangeEventHandler(object sender, TIPURADataSet.TIPURARowChangeEvent e);
    }
}

