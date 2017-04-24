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
    public class TIPPARTNERADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TIPPARTNERADataTable tableTIPPARTNERA;

        public TIPPARTNERADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected TIPPARTNERADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TIPPARTNERA"] != null)
                    {
                        this.Tables.Add(new TIPPARTNERADataTable(dataSet.Tables["TIPPARTNERA"]));
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
            TIPPARTNERADataSet set = (TIPPARTNERADataSet) base.Clone();
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
            TIPPARTNERADataSet set = new TIPPARTNERADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "TIPPARTNERADataAdapter");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1075");
            this.ExtendedProperties.Add("DataSetName", "TIPPARTNERADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ITIPPARTNERADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "TIPPARTNERA");
            this.ExtendedProperties.Add("ObjectDescription", "TIPPARTNERA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Common");
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
            this.DataSetName = "TIPPARTNERADataSet";
            this.Namespace = "http://www.tempuri.org/TIPPARTNERA";
            this.tableTIPPARTNERA = new TIPPARTNERADataTable();
            this.Tables.Add(this.tableTIPPARTNERA);
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
            this.tableTIPPARTNERA = (TIPPARTNERADataTable) this.Tables["TIPPARTNERA"];
            if (initTable && (this.tableTIPPARTNERA != null))
            {
                this.tableTIPPARTNERA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TIPPARTNERA"] != null)
                {
                    this.Tables.Add(new TIPPARTNERADataTable(dataSet.Tables["TIPPARTNERA"]));
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

        private bool ShouldSerializeTIPPARTNERA()
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
        public TIPPARTNERADataTable TIPPARTNERA
        {
            get
            {
                return this.tableTIPPARTNERA;
            }
        }

        [Serializable]
        public class TIPPARTNERADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPPARTNERA;
            private DataColumn columnNAZIVTIPPARTNERA;

            public event TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler TIPPARTNERARowChanged;

            public event TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler TIPPARTNERARowChanging;

            public event TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler TIPPARTNERARowDeleted;

            public event TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler TIPPARTNERARowDeleting;

            public TIPPARTNERADataTable()
            {
                this.TableName = "TIPPARTNERA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal TIPPARTNERADataTable(DataTable table) : base(table.TableName)
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

            protected TIPPARTNERADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddTIPPARTNERARow(TIPPARTNERADataSet.TIPPARTNERARow row)
            {
                this.Rows.Add(row);
            }

            public TIPPARTNERADataSet.TIPPARTNERARow AddTIPPARTNERARow(int iDTIPPARTNERA, string nAZIVTIPPARTNERA)
            {
                TIPPARTNERADataSet.TIPPARTNERARow row = (TIPPARTNERADataSet.TIPPARTNERARow) this.NewRow();
                row["IDTIPPARTNERA"] = iDTIPPARTNERA;
                row["NAZIVTIPPARTNERA"] = nAZIVTIPPARTNERA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                TIPPARTNERADataSet.TIPPARTNERADataTable table = (TIPPARTNERADataSet.TIPPARTNERADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public TIPPARTNERADataSet.TIPPARTNERARow FindByIDTIPPARTNERA(int iDTIPPARTNERA)
            {
                return (TIPPARTNERADataSet.TIPPARTNERARow) this.Rows.Find(new object[] { iDTIPPARTNERA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(TIPPARTNERADataSet.TIPPARTNERARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                TIPPARTNERADataSet set = new TIPPARTNERADataSet();
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
                this.columnIDTIPPARTNERA = new DataColumn("IDTIPPARTNERA", typeof(int), "", MappingType.Element);
                this.columnIDTIPPARTNERA.AllowDBNull = false;
                this.columnIDTIPPARTNERA.Caption = "Tip partnera";
                this.columnIDTIPPARTNERA.Unique = true;
                this.columnIDTIPPARTNERA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Description", "Tip partnera");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Length", "6");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPPARTNERA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPPARTNERA");
                this.Columns.Add(this.columnIDTIPPARTNERA);
                this.columnNAZIVTIPPARTNERA = new DataColumn("NAZIVTIPPARTNERA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPPARTNERA.AllowDBNull = false;
                this.columnNAZIVTIPPARTNERA.Caption = "Naziv tipa partnera";
                this.columnNAZIVTIPPARTNERA.MaxLength = 100;
                this.columnNAZIVTIPPARTNERA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Description", "Naziv tipa partnera");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPPARTNERA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPPARTNERA");
                this.Columns.Add(this.columnNAZIVTIPPARTNERA);
                this.PrimaryKey = new DataColumn[] { this.columnIDTIPPARTNERA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "TIPPARTNERA");
                this.ExtendedProperties.Add("Description", "TIPPARTNERA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDTIPPARTNERA = this.Columns["IDTIPPARTNERA"];
                this.columnNAZIVTIPPARTNERA = this.Columns["NAZIVTIPPARTNERA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TIPPARTNERADataSet.TIPPARTNERARow(builder);
            }

            public TIPPARTNERADataSet.TIPPARTNERARow NewTIPPARTNERARow()
            {
                return (TIPPARTNERADataSet.TIPPARTNERARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TIPPARTNERARowChanged != null)
                {
                    TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler tIPPARTNERARowChangedEvent = this.TIPPARTNERARowChanged;
                    if (tIPPARTNERARowChangedEvent != null)
                    {
                        tIPPARTNERARowChangedEvent(this, new TIPPARTNERADataSet.TIPPARTNERARowChangeEvent((TIPPARTNERADataSet.TIPPARTNERARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TIPPARTNERARowChanging != null)
                {
                    TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler tIPPARTNERARowChangingEvent = this.TIPPARTNERARowChanging;
                    if (tIPPARTNERARowChangingEvent != null)
                    {
                        tIPPARTNERARowChangingEvent(this, new TIPPARTNERADataSet.TIPPARTNERARowChangeEvent((TIPPARTNERADataSet.TIPPARTNERARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TIPPARTNERARowDeleted != null)
                {
                    TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler tIPPARTNERARowDeletedEvent = this.TIPPARTNERARowDeleted;
                    if (tIPPARTNERARowDeletedEvent != null)
                    {
                        tIPPARTNERARowDeletedEvent(this, new TIPPARTNERADataSet.TIPPARTNERARowChangeEvent((TIPPARTNERADataSet.TIPPARTNERARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TIPPARTNERARowDeleting != null)
                {
                    TIPPARTNERADataSet.TIPPARTNERARowChangeEventHandler tIPPARTNERARowDeletingEvent = this.TIPPARTNERARowDeleting;
                    if (tIPPARTNERARowDeletingEvent != null)
                    {
                        tIPPARTNERARowDeletingEvent(this, new TIPPARTNERADataSet.TIPPARTNERARowChangeEvent((TIPPARTNERADataSet.TIPPARTNERARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveTIPPARTNERARow(TIPPARTNERADataSet.TIPPARTNERARow row)
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

            public DataColumn IDTIPPARTNERAColumn
            {
                get
                {
                    return this.columnIDTIPPARTNERA;
                }
            }

            public TIPPARTNERADataSet.TIPPARTNERARow this[int index]
            {
                get
                {
                    return (TIPPARTNERADataSet.TIPPARTNERARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVTIPPARTNERAColumn
            {
                get
                {
                    return this.columnNAZIVTIPPARTNERA;
                }
            }
        }

        public class TIPPARTNERARow : DataRow
        {
            private TIPPARTNERADataSet.TIPPARTNERADataTable tableTIPPARTNERA;

            internal TIPPARTNERARow(DataRowBuilder rb) : base(rb)
            {
                this.tableTIPPARTNERA = (TIPPARTNERADataSet.TIPPARTNERADataTable) this.Table;
            }

            public bool IsIDTIPPARTNERANull()
            {
                return this.IsNull(this.tableTIPPARTNERA.IDTIPPARTNERAColumn);
            }

            public bool IsNAZIVTIPPARTNERANull()
            {
                return this.IsNull(this.tableTIPPARTNERA.NAZIVTIPPARTNERAColumn);
            }

            public void SetNAZIVTIPPARTNERANull()
            {
                this[this.tableTIPPARTNERA.NAZIVTIPPARTNERAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPPARTNERA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTIPPARTNERA.IDTIPPARTNERAColumn]);
                }
                set
                {
                    this[this.tableTIPPARTNERA.IDTIPPARTNERAColumn] = value;
                }
            }

            public string NAZIVTIPPARTNERA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPPARTNERA.NAZIVTIPPARTNERAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVTIPPARTNERA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPPARTNERA.NAZIVTIPPARTNERAColumn] = value;
                }
            }
        }

        public class TIPPARTNERARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private TIPPARTNERADataSet.TIPPARTNERARow eventRow;

            public TIPPARTNERARowChangeEvent(TIPPARTNERADataSet.TIPPARTNERARow row, DataRowAction action)
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

            public TIPPARTNERADataSet.TIPPARTNERARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TIPPARTNERARowChangeEventHandler(object sender, TIPPARTNERADataSet.TIPPARTNERARowChangeEvent e);
    }
}

