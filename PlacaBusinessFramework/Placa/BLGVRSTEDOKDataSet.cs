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
    public class BLGVRSTEDOKDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private BLGVRSTEDOKDataTable tableBLGVRSTEDOK;

        public BLGVRSTEDOKDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected BLGVRSTEDOKDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["BLGVRSTEDOK"] != null)
                    {
                        this.Tables.Add(new BLGVRSTEDOKDataTable(dataSet.Tables["BLGVRSTEDOK"]));
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
            BLGVRSTEDOKDataSet set = (BLGVRSTEDOKDataSet) base.Clone();
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
            BLGVRSTEDOKDataSet set = new BLGVRSTEDOKDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "BLGVRSTEDOKDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2034");
            this.ExtendedProperties.Add("DataSetName", "BLGVRSTEDOKDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IBLGVRSTEDOKDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "BLGVRSTEDOK");
            this.ExtendedProperties.Add("ObjectDescription", "BLGVRSTEDOK");
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
            this.DataSetName = "BLGVRSTEDOKDataSet";
            this.Namespace = "http://www.tempuri.org/BLGVRSTEDOK";
            this.tableBLGVRSTEDOK = new BLGVRSTEDOKDataTable();
            this.Tables.Add(this.tableBLGVRSTEDOK);
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
            this.tableBLGVRSTEDOK = (BLGVRSTEDOKDataTable) this.Tables["BLGVRSTEDOK"];
            if (initTable && (this.tableBLGVRSTEDOK != null))
            {
                this.tableBLGVRSTEDOK.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["BLGVRSTEDOK"] != null)
                {
                    this.Tables.Add(new BLGVRSTEDOKDataTable(dataSet.Tables["BLGVRSTEDOK"]));
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

        private bool ShouldSerializeBLGVRSTEDOK()
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
        public BLGVRSTEDOKDataTable BLGVRSTEDOK
        {
            get
            {
                return this.tableBLGVRSTEDOK;
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
        public class BLGVRSTEDOKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDBLGVRSTEDOK;
            private DataColumn columnNAZIVVRSTEDOK;

            public event BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler BLGVRSTEDOKRowChanged;

            public event BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler BLGVRSTEDOKRowChanging;

            public event BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler BLGVRSTEDOKRowDeleted;

            public event BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler BLGVRSTEDOKRowDeleting;

            public BLGVRSTEDOKDataTable()
            {
                this.TableName = "BLGVRSTEDOK";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BLGVRSTEDOKDataTable(DataTable table) : base(table.TableName)
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

            protected BLGVRSTEDOKDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBLGVRSTEDOKRow(BLGVRSTEDOKDataSet.BLGVRSTEDOKRow row)
            {
                this.Rows.Add(row);
            }

            public BLGVRSTEDOKDataSet.BLGVRSTEDOKRow AddBLGVRSTEDOKRow(int iDBLGVRSTEDOK, string nAZIVVRSTEDOK)
            {
                BLGVRSTEDOKDataSet.BLGVRSTEDOKRow row = (BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) this.NewRow();
                row["IDBLGVRSTEDOK"] = iDBLGVRSTEDOK;
                row["NAZIVVRSTEDOK"] = nAZIVVRSTEDOK;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BLGVRSTEDOKDataSet.BLGVRSTEDOKDataTable table = (BLGVRSTEDOKDataSet.BLGVRSTEDOKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BLGVRSTEDOKDataSet.BLGVRSTEDOKRow FindByIDBLGVRSTEDOK(int iDBLGVRSTEDOK)
            {
                return (BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) this.Rows.Find(new object[] { iDBLGVRSTEDOK });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BLGVRSTEDOKDataSet.BLGVRSTEDOKRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BLGVRSTEDOKDataSet set = new BLGVRSTEDOKDataSet();
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
                this.columnIDBLGVRSTEDOK = new DataColumn("IDBLGVRSTEDOK", typeof(int), "", MappingType.Element);
                this.columnIDBLGVRSTEDOK.AllowDBNull = false;
                this.columnIDBLGVRSTEDOK.Caption = "IDBLGVRSTEDOK";
                this.columnIDBLGVRSTEDOK.Unique = true;
                this.columnIDBLGVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsKey", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Description", "Šif.dok.blagajne");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Length", "5");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBLGVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "IDBLGVRSTEDOK");
                this.Columns.Add(this.columnIDBLGVRSTEDOK);
                this.columnNAZIVVRSTEDOK = new DataColumn("NAZIVVRSTEDOK", typeof(string), "", MappingType.Element);
                this.columnNAZIVVRSTEDOK.AllowDBNull = false;
                this.columnNAZIVVRSTEDOK.Caption = "NAZIVVRSTEDOK";
                this.columnNAZIVVRSTEDOK.MaxLength = 30;
                this.columnNAZIVVRSTEDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Description", "Naziv dok.");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVVRSTEDOK.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVVRSTEDOK");
                this.Columns.Add(this.columnNAZIVVRSTEDOK);
                this.PrimaryKey = new DataColumn[] { this.columnIDBLGVRSTEDOK };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "BLGVRSTEDOK");
                this.ExtendedProperties.Add("Description", "BLGVRSTEDOK");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDBLGVRSTEDOK = this.Columns["IDBLGVRSTEDOK"];
                this.columnNAZIVVRSTEDOK = this.Columns["NAZIVVRSTEDOK"];
            }

            public BLGVRSTEDOKDataSet.BLGVRSTEDOKRow NewBLGVRSTEDOKRow()
            {
                return (BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BLGVRSTEDOKDataSet.BLGVRSTEDOKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BLGVRSTEDOKRowChanged != null)
                {
                    BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler bLGVRSTEDOKRowChangedEvent = this.BLGVRSTEDOKRowChanged;
                    if (bLGVRSTEDOKRowChangedEvent != null)
                    {
                        bLGVRSTEDOKRowChangedEvent(this, new BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEvent((BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BLGVRSTEDOKRowChanging != null)
                {
                    BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler bLGVRSTEDOKRowChangingEvent = this.BLGVRSTEDOKRowChanging;
                    if (bLGVRSTEDOKRowChangingEvent != null)
                    {
                        bLGVRSTEDOKRowChangingEvent(this, new BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEvent((BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.BLGVRSTEDOKRowDeleted != null)
                {
                    BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler bLGVRSTEDOKRowDeletedEvent = this.BLGVRSTEDOKRowDeleted;
                    if (bLGVRSTEDOKRowDeletedEvent != null)
                    {
                        bLGVRSTEDOKRowDeletedEvent(this, new BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEvent((BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BLGVRSTEDOKRowDeleting != null)
                {
                    BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEventHandler bLGVRSTEDOKRowDeletingEvent = this.BLGVRSTEDOKRowDeleting;
                    if (bLGVRSTEDOKRowDeletingEvent != null)
                    {
                        bLGVRSTEDOKRowDeletingEvent(this, new BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEvent((BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBLGVRSTEDOKRow(BLGVRSTEDOKDataSet.BLGVRSTEDOKRow row)
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

            public DataColumn IDBLGVRSTEDOKColumn
            {
                get
                {
                    return this.columnIDBLGVRSTEDOK;
                }
            }

            public BLGVRSTEDOKDataSet.BLGVRSTEDOKRow this[int index]
            {
                get
                {
                    return (BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVVRSTEDOKColumn
            {
                get
                {
                    return this.columnNAZIVVRSTEDOK;
                }
            }
        }

        public class BLGVRSTEDOKRow : DataRow
        {
            private BLGVRSTEDOKDataSet.BLGVRSTEDOKDataTable tableBLGVRSTEDOK;

            internal BLGVRSTEDOKRow(DataRowBuilder rb) : base(rb)
            {
                this.tableBLGVRSTEDOK = (BLGVRSTEDOKDataSet.BLGVRSTEDOKDataTable) this.Table;
            }

            public bool IsIDBLGVRSTEDOKNull()
            {
                return this.IsNull(this.tableBLGVRSTEDOK.IDBLGVRSTEDOKColumn);
            }

            public bool IsNAZIVVRSTEDOKNull()
            {
                return this.IsNull(this.tableBLGVRSTEDOK.NAZIVVRSTEDOKColumn);
            }

            public void SetNAZIVVRSTEDOKNull()
            {
                this[this.tableBLGVRSTEDOK.NAZIVVRSTEDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDBLGVRSTEDOK
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBLGVRSTEDOK.IDBLGVRSTEDOKColumn]);
                }
                set
                {
                    this[this.tableBLGVRSTEDOK.IDBLGVRSTEDOKColumn] = value;
                }
            }

            public string NAZIVVRSTEDOK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBLGVRSTEDOK.NAZIVVRSTEDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVVRSTEDOK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBLGVRSTEDOK.NAZIVVRSTEDOKColumn] = value;
                }
            }
        }

        public class BLGVRSTEDOKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BLGVRSTEDOKDataSet.BLGVRSTEDOKRow eventRow;

            public BLGVRSTEDOKRowChangeEvent(BLGVRSTEDOKDataSet.BLGVRSTEDOKRow row, DataRowAction action)
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

            public BLGVRSTEDOKDataSet.BLGVRSTEDOKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BLGVRSTEDOKRowChangeEventHandler(object sender, BLGVRSTEDOKDataSet.BLGVRSTEDOKRowChangeEvent e);
    }
}

