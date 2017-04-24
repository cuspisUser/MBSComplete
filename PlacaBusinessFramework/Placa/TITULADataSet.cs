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
    public class TITULADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private TITULADataTable tableTITULA;

        public TITULADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected TITULADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TITULA"] != null)
                    {
                        this.Tables.Add(new TITULADataTable(dataSet.Tables["TITULA"]));
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
            TITULADataSet set = (TITULADataSet) base.Clone();
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
            TITULADataSet set = new TITULADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "TITULADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1027");
            this.ExtendedProperties.Add("DataSetName", "TITULADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ITITULADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "TITULA");
            this.ExtendedProperties.Add("ObjectDescription", "Titule");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVTITULA");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "TITULADataSet";
            this.Namespace = "http://www.tempuri.org/TITULA";
            this.tableTITULA = new TITULADataTable();
            this.Tables.Add(this.tableTITULA);
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
            this.tableTITULA = (TITULADataTable) this.Tables["TITULA"];
            if (initTable && (this.tableTITULA != null))
            {
                this.tableTITULA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TITULA"] != null)
                {
                    this.Tables.Add(new TITULADataTable(dataSet.Tables["TITULA"]));
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

        private bool ShouldSerializeTITULA()
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
        public TITULADataTable TITULA
        {
            get
            {
                return this.tableTITULA;
            }
        }

        [Serializable]
        public class TITULADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDTITULA;
            private DataColumn columnNAZIVTITULA;

            public event TITULADataSet.TITULARowChangeEventHandler TITULARowChanged;

            public event TITULADataSet.TITULARowChangeEventHandler TITULARowChanging;

            public event TITULADataSet.TITULARowChangeEventHandler TITULARowDeleted;

            public event TITULADataSet.TITULARowChangeEventHandler TITULARowDeleting;

            public TITULADataTable()
            {
                this.TableName = "TITULA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal TITULADataTable(DataTable table) : base(table.TableName)
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

            protected TITULADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddTITULARow(TITULADataSet.TITULARow row)
            {
                this.Rows.Add(row);
            }

            public TITULADataSet.TITULARow AddTITULARow(int iDTITULA, string nAZIVTITULA)
            {
                TITULADataSet.TITULARow row = (TITULADataSet.TITULARow) this.NewRow();
                row["IDTITULA"] = iDTITULA;
                row["NAZIVTITULA"] = nAZIVTITULA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                TITULADataSet.TITULADataTable table = (TITULADataSet.TITULADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public TITULADataSet.TITULARow FindByIDTITULA(int iDTITULA)
            {
                return (TITULADataSet.TITULARow) this.Rows.Find(new object[] { iDTITULA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(TITULADataSet.TITULARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                TITULADataSet set = new TITULADataSet();
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
                this.columnIDTITULA = new DataColumn("IDTITULA", typeof(int), "", MappingType.Element);
                this.columnIDTITULA.AllowDBNull = false;
                this.columnIDTITULA.Caption = "Šifra titule";
                this.columnIDTITULA.Unique = true;
                this.columnIDTITULA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTITULA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTITULA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDTITULA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTITULA.ExtendedProperties.Add("Description", "Šifra titule");
                this.columnIDTITULA.ExtendedProperties.Add("Length", "5");
                this.columnIDTITULA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTITULA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTITULA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTITULA.ExtendedProperties.Add("Deklarit.InternalName", "IDTITULA");
                this.Columns.Add(this.columnIDTITULA);
                this.columnNAZIVTITULA = new DataColumn("NAZIVTITULA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTITULA.AllowDBNull = false;
                this.columnNAZIVTITULA.Caption = "Naziv titule";
                this.columnNAZIVTITULA.MaxLength = 50;
                this.columnNAZIVTITULA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTITULA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Description", "Naziv titule");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTITULA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTITULA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTITULA");
                this.Columns.Add(this.columnNAZIVTITULA);
                this.PrimaryKey = new DataColumn[] { this.columnIDTITULA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "TITULA");
                this.ExtendedProperties.Add("Description", "Titule");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDTITULA = this.Columns["IDTITULA"];
                this.columnNAZIVTITULA = this.Columns["NAZIVTITULA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TITULADataSet.TITULARow(builder);
            }

            public TITULADataSet.TITULARow NewTITULARow()
            {
                return (TITULADataSet.TITULARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TITULARowChanged != null)
                {
                    TITULADataSet.TITULARowChangeEventHandler tITULARowChangedEvent = this.TITULARowChanged;
                    if (tITULARowChangedEvent != null)
                    {
                        tITULARowChangedEvent(this, new TITULADataSet.TITULARowChangeEvent((TITULADataSet.TITULARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TITULARowChanging != null)
                {
                    TITULADataSet.TITULARowChangeEventHandler tITULARowChangingEvent = this.TITULARowChanging;
                    if (tITULARowChangingEvent != null)
                    {
                        tITULARowChangingEvent(this, new TITULADataSet.TITULARowChangeEvent((TITULADataSet.TITULARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TITULARowDeleted != null)
                {
                    TITULADataSet.TITULARowChangeEventHandler tITULARowDeletedEvent = this.TITULARowDeleted;
                    if (tITULARowDeletedEvent != null)
                    {
                        tITULARowDeletedEvent(this, new TITULADataSet.TITULARowChangeEvent((TITULADataSet.TITULARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TITULARowDeleting != null)
                {
                    TITULADataSet.TITULARowChangeEventHandler tITULARowDeletingEvent = this.TITULARowDeleting;
                    if (tITULARowDeletingEvent != null)
                    {
                        tITULARowDeletingEvent(this, new TITULADataSet.TITULARowChangeEvent((TITULADataSet.TITULARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveTITULARow(TITULADataSet.TITULARow row)
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

            public DataColumn IDTITULAColumn
            {
                get
                {
                    return this.columnIDTITULA;
                }
            }

            public TITULADataSet.TITULARow this[int index]
            {
                get
                {
                    return (TITULADataSet.TITULARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVTITULAColumn
            {
                get
                {
                    return this.columnNAZIVTITULA;
                }
            }
        }

        public class TITULARow : DataRow
        {
            private TITULADataSet.TITULADataTable tableTITULA;

            internal TITULARow(DataRowBuilder rb) : base(rb)
            {
                this.tableTITULA = (TITULADataSet.TITULADataTable) this.Table;
            }

            public bool IsIDTITULANull()
            {
                return this.IsNull(this.tableTITULA.IDTITULAColumn);
            }

            public bool IsNAZIVTITULANull()
            {
                return this.IsNull(this.tableTITULA.NAZIVTITULAColumn);
            }

            public void SetNAZIVTITULANull()
            {
                this[this.tableTITULA.NAZIVTITULAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDTITULA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableTITULA.IDTITULAColumn]);
                }
                set
                {
                    this[this.tableTITULA.IDTITULAColumn] = value;
                }
            }

            public string NAZIVTITULA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableTITULA.NAZIVTITULAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVTITULA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableTITULA.NAZIVTITULAColumn] = value;
                }
            }
        }

        public class TITULARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private TITULADataSet.TITULARow eventRow;

            public TITULARowChangeEvent(TITULADataSet.TITULARow row, DataRowAction action)
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

            public TITULADataSet.TITULARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void TITULARowChangeEventHandler(object sender, TITULADataSet.TITULARowChangeEvent e);
    }
}

