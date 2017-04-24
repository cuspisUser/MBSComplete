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
    public class TIPIRADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TIPIRADataTable tableTIPIRA;

        public TIPIRADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected TIPIRADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TIPIRA"] != null)
                    {
                        this.Tables.Add(new TIPIRADataTable(dataSet.Tables["TIPIRA"]));
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
            TIPIRADataSet set = (TIPIRADataSet) base.Clone();
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
            TIPIRADataSet set = new TIPIRADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "TIPIRADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2043");
            this.ExtendedProperties.Add("DataSetName", "TIPIRADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ITIPIRADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "TIPIRA");
            this.ExtendedProperties.Add("ObjectDescription", "TIPIRA");
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
            this.DataSetName = "TIPIRADataSet";
            this.Namespace = "http://www.tempuri.org/TIPIRA";
            this.tableTIPIRA = new TIPIRADataTable();
            this.Tables.Add(this.tableTIPIRA);
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
            this.tableTIPIRA = (TIPIRADataTable) this.Tables["TIPIRA"];
            if (initTable && (this.tableTIPIRA != null))
            {
                this.tableTIPIRA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TIPIRA"] != null)
                {
                    this.Tables.Add(new TIPIRADataTable(dataSet.Tables["TIPIRA"]));
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

        private bool ShouldSerializeTIPIRA()
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
        public TIPIRADataTable TIPIRA
        {
            get
            {
                return this.tableTIPIRA;
            }
        }

        [Serializable]
        public class TIPIRADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPIRA;
            private DataColumn columnNAZIVTIPIRA;

            public event TIPIRADataSet.TIPIRARowChangeEventHandler TIPIRARowChanged;

            public event TIPIRADataSet.TIPIRARowChangeEventHandler TIPIRARowChanging;

            public event TIPIRADataSet.TIPIRARowChangeEventHandler TIPIRARowDeleted;

            public event TIPIRADataSet.TIPIRARowChangeEventHandler TIPIRARowDeleting;

            public TIPIRADataTable()
            {
                this.TableName = "TIPIRA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal TIPIRADataTable(DataTable table) : base(table.TableName)
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

            protected TIPIRADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddTIPIRARow(TIPIRADataSet.TIPIRARow row)
            {
                this.Rows.Add(row);
            }

            public TIPIRADataSet.TIPIRARow AddTIPIRARow(int iDTIPIRA, string nAZIVTIPIRA)
            {
                TIPIRADataSet.TIPIRARow row = (TIPIRADataSet.TIPIRARow) this.NewRow();
                row["IDTIPIRA"] = iDTIPIRA;
                row["NAZIVTIPIRA"] = nAZIVTIPIRA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                TIPIRADataSet.TIPIRADataTable table = (TIPIRADataSet.TIPIRADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public TIPIRADataSet.TIPIRARow FindByIDTIPIRA(int iDTIPIRA)
            {
                return (TIPIRADataSet.TIPIRARow) this.Rows.Find(new object[] { iDTIPIRA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(TIPIRADataSet.TIPIRARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                TIPIRADataSet set = new TIPIRADataSet();
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
                this.columnIDTIPIRA = new DataColumn("IDTIPIRA", typeof(int), "", MappingType.Element);
                this.columnIDTIPIRA.AllowDBNull = false;
                this.columnIDTIPIRA.Caption = "IDTIPIRA";
                this.columnIDTIPIRA.Unique = true;
                this.columnIDTIPIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPIRA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPIRA.ExtendedProperties.Add("Description", "IDTIPIRA");
                this.columnIDTIPIRA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPIRA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPIRA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPIRA");
                this.Columns.Add(this.columnIDTIPIRA);
                this.columnNAZIVTIPIRA = new DataColumn("NAZIVTIPIRA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPIRA.AllowDBNull = false;
                this.columnNAZIVTIPIRA.Caption = "NAZIVTIPIRA";
                this.columnNAZIVTIPIRA.MaxLength = 50;
                this.columnNAZIVTIPIRA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Description", "NAZIVTIPIRA");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPIRA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPIRA");
                this.Columns.Add(this.columnNAZIVTIPIRA);
                this.PrimaryKey = new DataColumn[] { this.columnIDTIPIRA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "TIPIRA");
                this.ExtendedProperties.Add("Description", "TIPIRA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDTIPIRA = this.Columns["IDTIPIRA"];
                this.columnNAZIVTIPIRA = this.Columns["NAZIVTIPIRA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TIPIRADataSet.TIPIRARow(builder);
            }

            public TIPIRADataSet.TIPIRARow NewTIPIRARow()
            {
                return (TIPIRADataSet.TIPIRARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TIPIRARowChanged != null)
                {
                    TIPIRADataSet.TIPIRARowChangeEventHandler tIPIRARowChangedEvent = this.TIPIRARowChanged;
                    if (tIPIRARowChangedEvent != null)
                    {
                        tIPIRARowChangedEvent(this, new TIPIRADataSet.TIPIRARowChangeEvent((TIPIRADataSet.TIPIRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TIPIRARowChanging != null)
                {
                    TIPIRADataSet.TIPIRARowChangeEventHandler tIPIRARowChangingEvent = this.TIPIRARowChanging;
                    if (tIPIRARowChangingEvent != null)
                    {
                        tIPIRARowChangingEvent(this, new TIPIRADataSet.TIPIRARowChangeEvent((TIPIRADataSet.TIPIRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TIPIRARowDeleted != null)
                {
                    TIPIRADataSet.TIPIRARowChangeEventHandler tIPIRARowDeletedEvent = this.TIPIRARowDeleted;
                    if (tIPIRARowDeletedEvent != null)
                    {
                        tIPIRARowDeletedEvent(this, new TIPIRADataSet.TIPIRARowChangeEvent((TIPIRADataSet.TIPIRARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TIPIRARowDeleting != null)
                {
                    TIPIRADataSet.TIPIRARowChangeEventHandler tIPIRARowDeletingEvent = this.TIPIRARowDeleting;
                    if (tIPIRARowDeletingEvent != null)
                    {
                        tIPIRARowDeletingEvent(this, new TIPIRADataSet.TIPIRARowChangeEvent((TIPIRADataSet.TIPIRARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveTIPIRARow(TIPIRADataSet.TIPIRARow row)
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

            public DataColumn IDTIPIRAColumn
            {
                get
                {
                    return this.columnIDTIPIRA;
                }
            }

            public TIPIRADataSet.TIPIRARow this[int index]
            {
                get
                {
                    return (TIPIRADataSet.TIPIRARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVTIPIRAColumn
            {
                get
                {
                    return this.columnNAZIVTIPIRA;
                }
            }
        }

        public class TIPIRARow : DataRow
        {
            private TIPIRADataSet.TIPIRADataTable tableTIPIRA;

            internal TIPIRARow(DataRowBuilder rb) : base(rb)
            {
                this.tableTIPIRA = (TIPIRADataSet.TIPIRADataTable) this.Table;
            }

            public bool IsIDTIPIRANull()
            {
                return this.IsNull(this.tableTIPIRA.IDTIPIRAColumn);
            }

            public bool IsNAZIVTIPIRANull()
            {
                return this.IsNull(this.tableTIPIRA.NAZIVTIPIRAColumn);
            }

            public void SetNAZIVTIPIRANull()
            {
                this[this.tableTIPIRA.NAZIVTIPIRAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPIRA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTIPIRA.IDTIPIRAColumn]);
                }
                set
                {
                    this[this.tableTIPIRA.IDTIPIRAColumn] = value;
                }
            }

            public string NAZIVTIPIRA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPIRA.NAZIVTIPIRAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVTIPIRA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPIRA.NAZIVTIPIRAColumn] = value;
                }
            }
        }

        public class TIPIRARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private TIPIRADataSet.TIPIRARow eventRow;

            public TIPIRARowChangeEvent(TIPIRADataSet.TIPIRARow row, DataRowAction action)
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

            public TIPIRADataSet.TIPIRARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TIPIRARowChangeEventHandler(object sender, TIPIRADataSet.TIPIRARowChangeEvent e);
    }
}

