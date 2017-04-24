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
    public class TIPDOKUMENTADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TIPDOKUMENTADataTable tableTIPDOKUMENTA;

        public TIPDOKUMENTADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected TIPDOKUMENTADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TIPDOKUMENTA"] != null)
                    {
                        this.Tables.Add(new TIPDOKUMENTADataTable(dataSet.Tables["TIPDOKUMENTA"]));
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
            TIPDOKUMENTADataSet set = (TIPDOKUMENTADataSet) base.Clone();
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
            TIPDOKUMENTADataSet set = new TIPDOKUMENTADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "TIPDOKUMENTADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2031");
            this.ExtendedProperties.Add("DataSetName", "TIPDOKUMENTADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ITIPDOKUMENTADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "TIPDOKUMENTA");
            this.ExtendedProperties.Add("ObjectDescription", "TIPDOKUMENTA");
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
            this.DataSetName = "TIPDOKUMENTADataSet";
            this.Namespace = "http://www.tempuri.org/TIPDOKUMENTA";
            this.tableTIPDOKUMENTA = new TIPDOKUMENTADataTable();
            this.Tables.Add(this.tableTIPDOKUMENTA);
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
            this.tableTIPDOKUMENTA = (TIPDOKUMENTADataTable) this.Tables["TIPDOKUMENTA"];
            if (initTable && (this.tableTIPDOKUMENTA != null))
            {
                this.tableTIPDOKUMENTA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TIPDOKUMENTA"] != null)
                {
                    this.Tables.Add(new TIPDOKUMENTADataTable(dataSet.Tables["TIPDOKUMENTA"]));
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

        private bool ShouldSerializeTIPDOKUMENTA()
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
        public TIPDOKUMENTADataTable TIPDOKUMENTA
        {
            get
            {
                return this.tableTIPDOKUMENTA;
            }
        }

        [Serializable]
        public class TIPDOKUMENTADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTIPDOKUMENTA;
            private DataColumn columnNAZIVTIPDOKUMENTA;

            public event TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler TIPDOKUMENTARowChanged;

            public event TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler TIPDOKUMENTARowChanging;

            public event TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler TIPDOKUMENTARowDeleted;

            public event TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler TIPDOKUMENTARowDeleting;

            public TIPDOKUMENTADataTable()
            {
                this.TableName = "TIPDOKUMENTA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal TIPDOKUMENTADataTable(DataTable table) : base(table.TableName)
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

            protected TIPDOKUMENTADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddTIPDOKUMENTARow(TIPDOKUMENTADataSet.TIPDOKUMENTARow row)
            {
                this.Rows.Add(row);
            }

            public TIPDOKUMENTADataSet.TIPDOKUMENTARow AddTIPDOKUMENTARow(int iDTIPDOKUMENTA, string nAZIVTIPDOKUMENTA)
            {
                TIPDOKUMENTADataSet.TIPDOKUMENTARow row = (TIPDOKUMENTADataSet.TIPDOKUMENTARow) this.NewRow();
                row["IDTIPDOKUMENTA"] = iDTIPDOKUMENTA;
                row["NAZIVTIPDOKUMENTA"] = nAZIVTIPDOKUMENTA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                TIPDOKUMENTADataSet.TIPDOKUMENTADataTable table = (TIPDOKUMENTADataSet.TIPDOKUMENTADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public TIPDOKUMENTADataSet.TIPDOKUMENTARow FindByIDTIPDOKUMENTA(int iDTIPDOKUMENTA)
            {
                return (TIPDOKUMENTADataSet.TIPDOKUMENTARow) this.Rows.Find(new object[] { iDTIPDOKUMENTA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(TIPDOKUMENTADataSet.TIPDOKUMENTARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                TIPDOKUMENTADataSet set = new TIPDOKUMENTADataSet();
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
                this.columnIDTIPDOKUMENTA = new DataColumn("IDTIPDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnIDTIPDOKUMENTA.AllowDBNull = false;
                this.columnIDTIPDOKUMENTA.Caption = "IDTIPDOKUMENTA";
                this.columnIDTIPDOKUMENTA.Unique = true;
                this.columnIDTIPDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Description", "Šifr. tipa dok.");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPDOKUMENTA");
                this.Columns.Add(this.columnIDTIPDOKUMENTA);
                this.columnNAZIVTIPDOKUMENTA = new DataColumn("NAZIVTIPDOKUMENTA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPDOKUMENTA.AllowDBNull = false;
                this.columnNAZIVTIPDOKUMENTA.Caption = "NAZIVTIPDOKUMENTA";
                this.columnNAZIVTIPDOKUMENTA.MaxLength = 50;
                this.columnNAZIVTIPDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Description", "Tip dokumenta");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPDOKUMENTA");
                this.Columns.Add(this.columnNAZIVTIPDOKUMENTA);
                this.PrimaryKey = new DataColumn[] { this.columnIDTIPDOKUMENTA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "TIPDOKUMENTA");
                this.ExtendedProperties.Add("Description", "TIPDOKUMENTA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDTIPDOKUMENTA = this.Columns["IDTIPDOKUMENTA"];
                this.columnNAZIVTIPDOKUMENTA = this.Columns["NAZIVTIPDOKUMENTA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TIPDOKUMENTADataSet.TIPDOKUMENTARow(builder);
            }

            public TIPDOKUMENTADataSet.TIPDOKUMENTARow NewTIPDOKUMENTARow()
            {
                return (TIPDOKUMENTADataSet.TIPDOKUMENTARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TIPDOKUMENTARowChanged != null)
                {
                    TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler tIPDOKUMENTARowChangedEvent = this.TIPDOKUMENTARowChanged;
                    if (tIPDOKUMENTARowChangedEvent != null)
                    {
                        tIPDOKUMENTARowChangedEvent(this, new TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEvent((TIPDOKUMENTADataSet.TIPDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TIPDOKUMENTARowChanging != null)
                {
                    TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler tIPDOKUMENTARowChangingEvent = this.TIPDOKUMENTARowChanging;
                    if (tIPDOKUMENTARowChangingEvent != null)
                    {
                        tIPDOKUMENTARowChangingEvent(this, new TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEvent((TIPDOKUMENTADataSet.TIPDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TIPDOKUMENTARowDeleted != null)
                {
                    TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler tIPDOKUMENTARowDeletedEvent = this.TIPDOKUMENTARowDeleted;
                    if (tIPDOKUMENTARowDeletedEvent != null)
                    {
                        tIPDOKUMENTARowDeletedEvent(this, new TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEvent((TIPDOKUMENTADataSet.TIPDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TIPDOKUMENTARowDeleting != null)
                {
                    TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEventHandler tIPDOKUMENTARowDeletingEvent = this.TIPDOKUMENTARowDeleting;
                    if (tIPDOKUMENTARowDeletingEvent != null)
                    {
                        tIPDOKUMENTARowDeletingEvent(this, new TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEvent((TIPDOKUMENTADataSet.TIPDOKUMENTARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveTIPDOKUMENTARow(TIPDOKUMENTADataSet.TIPDOKUMENTARow row)
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

            public DataColumn IDTIPDOKUMENTAColumn
            {
                get
                {
                    return this.columnIDTIPDOKUMENTA;
                }
            }

            public TIPDOKUMENTADataSet.TIPDOKUMENTARow this[int index]
            {
                get
                {
                    return (TIPDOKUMENTADataSet.TIPDOKUMENTARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVTIPDOKUMENTAColumn
            {
                get
                {
                    return this.columnNAZIVTIPDOKUMENTA;
                }
            }
        }

        public class TIPDOKUMENTARow : DataRow
        {
            private TIPDOKUMENTADataSet.TIPDOKUMENTADataTable tableTIPDOKUMENTA;

            internal TIPDOKUMENTARow(DataRowBuilder rb) : base(rb)
            {
                this.tableTIPDOKUMENTA = (TIPDOKUMENTADataSet.TIPDOKUMENTADataTable) this.Table;
            }

            public bool IsIDTIPDOKUMENTANull()
            {
                return this.IsNull(this.tableTIPDOKUMENTA.IDTIPDOKUMENTAColumn);
            }

            public bool IsNAZIVTIPDOKUMENTANull()
            {
                return this.IsNull(this.tableTIPDOKUMENTA.NAZIVTIPDOKUMENTAColumn);
            }

            public void SetNAZIVTIPDOKUMENTANull()
            {
                this[this.tableTIPDOKUMENTA.NAZIVTIPDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTIPDOKUMENTA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTIPDOKUMENTA.IDTIPDOKUMENTAColumn]);
                }
                set
                {
                    this[this.tableTIPDOKUMENTA.IDTIPDOKUMENTAColumn] = value;
                }
            }

            public string NAZIVTIPDOKUMENTA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTIPDOKUMENTA.NAZIVTIPDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVTIPDOKUMENTA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTIPDOKUMENTA.NAZIVTIPDOKUMENTAColumn] = value;
                }
            }
        }

        public class TIPDOKUMENTARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private TIPDOKUMENTADataSet.TIPDOKUMENTARow eventRow;

            public TIPDOKUMENTARowChangeEvent(TIPDOKUMENTADataSet.TIPDOKUMENTARow row, DataRowAction action)
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

            public TIPDOKUMENTADataSet.TIPDOKUMENTARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TIPDOKUMENTARowChangeEventHandler(object sender, TIPDOKUMENTADataSet.TIPDOKUMENTARowChangeEvent e);
    }
}

