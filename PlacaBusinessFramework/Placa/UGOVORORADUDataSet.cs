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
    public class UGOVORORADUDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private UGOVORORADUDataTable tableUGOVORORADU;

        public UGOVORORADUDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected UGOVORORADUDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["UGOVORORADU"] != null)
                    {
                        this.Tables.Add(new UGOVORORADUDataTable(dataSet.Tables["UGOVORORADU"]));
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
            UGOVORORADUDataSet set = (UGOVORORADUDataSet) base.Clone();
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
            UGOVORORADUDataSet set = new UGOVORORADUDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "UGOVORORADUDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2151");
            this.ExtendedProperties.Add("DataSetName", "UGOVORORADUDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IUGOVORORADUDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "UGOVORORADU");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste ugovora o radu");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVUGOVORORADU");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "UGOVORORADUDataSet";
            this.Namespace = "http://www.tempuri.org/UGOVORORADU";
            this.tableUGOVORORADU = new UGOVORORADUDataTable();
            this.Tables.Add(this.tableUGOVORORADU);
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
            this.tableUGOVORORADU = (UGOVORORADUDataTable) this.Tables["UGOVORORADU"];
            if (initTable && (this.tableUGOVORORADU != null))
            {
                this.tableUGOVORORADU.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["UGOVORORADU"] != null)
                {
                    this.Tables.Add(new UGOVORORADUDataTable(dataSet.Tables["UGOVORORADU"]));
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

        private bool ShouldSerializeUGOVORORADU()
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
        public UGOVORORADUDataTable UGOVORORADU
        {
            get
            {
                return this.tableUGOVORORADU;
            }
        }

        [Serializable]
        public class UGOVORORADUDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDUGOVORORADU;
            private DataColumn columnNAZIVUGOVORORADU;

            public event UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler UGOVORORADURowChanged;

            public event UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler UGOVORORADURowChanging;

            public event UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler UGOVORORADURowDeleted;

            public event UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler UGOVORORADURowDeleting;

            public UGOVORORADUDataTable()
            {
                this.TableName = "UGOVORORADU";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal UGOVORORADUDataTable(DataTable table) : base(table.TableName)
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

            protected UGOVORORADUDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddUGOVORORADURow(UGOVORORADUDataSet.UGOVORORADURow row)
            {
                this.Rows.Add(row);
            }

            public UGOVORORADUDataSet.UGOVORORADURow AddUGOVORORADURow(int iDUGOVORORADU, string nAZIVUGOVORORADU)
            {
                UGOVORORADUDataSet.UGOVORORADURow row = (UGOVORORADUDataSet.UGOVORORADURow) this.NewRow();
                row["IDUGOVORORADU"] = iDUGOVORORADU;
                row["NAZIVUGOVORORADU"] = nAZIVUGOVORORADU;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                UGOVORORADUDataSet.UGOVORORADUDataTable table = (UGOVORORADUDataSet.UGOVORORADUDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public UGOVORORADUDataSet.UGOVORORADURow FindByIDUGOVORORADU(int iDUGOVORORADU)
            {
                return (UGOVORORADUDataSet.UGOVORORADURow) this.Rows.Find(new object[] { iDUGOVORORADU });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(UGOVORORADUDataSet.UGOVORORADURow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                UGOVORORADUDataSet set = new UGOVORORADUDataSet();
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
                this.columnIDUGOVORORADU = new DataColumn("IDUGOVORORADU", typeof(int), "", MappingType.Element);
                this.columnIDUGOVORORADU.AllowDBNull = false;
                this.columnIDUGOVORORADU.Caption = "IDUGOVORORADU";
                this.columnIDUGOVORORADU.Unique = true;
                this.columnIDUGOVORORADU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("IsKey", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Length", "5");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Decimals", "0");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDUGOVORORADU.ExtendedProperties.Add("Deklarit.InternalName", "IDUGOVORORADU");
                this.Columns.Add(this.columnIDUGOVORORADU);
                this.columnNAZIVUGOVORORADU = new DataColumn("NAZIVUGOVORORADU", typeof(string), "", MappingType.Element);
                this.columnNAZIVUGOVORORADU.AllowDBNull = false;
                this.columnNAZIVUGOVORORADU.Caption = "NAZIVUGOVORORADU";
                this.columnNAZIVUGOVORORADU.MaxLength = 20;
                this.columnNAZIVUGOVORORADU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Description", "Vrsta ugovora");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVUGOVORORADU.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVUGOVORORADU");
                this.Columns.Add(this.columnNAZIVUGOVORORADU);
                this.PrimaryKey = new DataColumn[] { this.columnIDUGOVORORADU };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "UGOVORORADU");
                this.ExtendedProperties.Add("Description", "Vrste ugovora o radu");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDUGOVORORADU = this.Columns["IDUGOVORORADU"];
                this.columnNAZIVUGOVORORADU = this.Columns["NAZIVUGOVORORADU"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UGOVORORADUDataSet.UGOVORORADURow(builder);
            }

            public UGOVORORADUDataSet.UGOVORORADURow NewUGOVORORADURow()
            {
                return (UGOVORORADUDataSet.UGOVORORADURow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.UGOVORORADURowChanged != null)
                {
                    UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler uGOVORORADURowChangedEvent = this.UGOVORORADURowChanged;
                    if (uGOVORORADURowChangedEvent != null)
                    {
                        uGOVORORADURowChangedEvent(this, new UGOVORORADUDataSet.UGOVORORADURowChangeEvent((UGOVORORADUDataSet.UGOVORORADURow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.UGOVORORADURowChanging != null)
                {
                    UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler uGOVORORADURowChangingEvent = this.UGOVORORADURowChanging;
                    if (uGOVORORADURowChangingEvent != null)
                    {
                        uGOVORORADURowChangingEvent(this, new UGOVORORADUDataSet.UGOVORORADURowChangeEvent((UGOVORORADUDataSet.UGOVORORADURow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.UGOVORORADURowDeleted != null)
                {
                    UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler uGOVORORADURowDeletedEvent = this.UGOVORORADURowDeleted;
                    if (uGOVORORADURowDeletedEvent != null)
                    {
                        uGOVORORADURowDeletedEvent(this, new UGOVORORADUDataSet.UGOVORORADURowChangeEvent((UGOVORORADUDataSet.UGOVORORADURow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.UGOVORORADURowDeleting != null)
                {
                    UGOVORORADUDataSet.UGOVORORADURowChangeEventHandler uGOVORORADURowDeletingEvent = this.UGOVORORADURowDeleting;
                    if (uGOVORORADURowDeletingEvent != null)
                    {
                        uGOVORORADURowDeletingEvent(this, new UGOVORORADUDataSet.UGOVORORADURowChangeEvent((UGOVORORADUDataSet.UGOVORORADURow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveUGOVORORADURow(UGOVORORADUDataSet.UGOVORORADURow row)
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

            public DataColumn IDUGOVORORADUColumn
            {
                get
                {
                    return this.columnIDUGOVORORADU;
                }
            }

            public UGOVORORADUDataSet.UGOVORORADURow this[int index]
            {
                get
                {
                    return (UGOVORORADUDataSet.UGOVORORADURow) this.Rows[index];
                }
            }

            public DataColumn NAZIVUGOVORORADUColumn
            {
                get
                {
                    return this.columnNAZIVUGOVORORADU;
                }
            }
        }

        public class UGOVORORADURow : DataRow
        {
            private UGOVORORADUDataSet.UGOVORORADUDataTable tableUGOVORORADU;

            internal UGOVORORADURow(DataRowBuilder rb) : base(rb)
            {
                this.tableUGOVORORADU = (UGOVORORADUDataSet.UGOVORORADUDataTable) this.Table;
            }

            public bool IsIDUGOVORORADUNull()
            {
                return this.IsNull(this.tableUGOVORORADU.IDUGOVORORADUColumn);
            }

            public bool IsNAZIVUGOVORORADUNull()
            {
                return this.IsNull(this.tableUGOVORORADU.NAZIVUGOVORORADUColumn);
            }

            public void SetNAZIVUGOVORORADUNull()
            {
                this[this.tableUGOVORORADU.NAZIVUGOVORORADUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDUGOVORORADU
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableUGOVORORADU.IDUGOVORORADUColumn]);
                }
                set
                {
                    this[this.tableUGOVORORADU.IDUGOVORORADUColumn] = value;
                }
            }

            public string NAZIVUGOVORORADU
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableUGOVORORADU.NAZIVUGOVORORADUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVUGOVORORADU because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableUGOVORORADU.NAZIVUGOVORORADUColumn] = value;
                }
            }
        }

        public class UGOVORORADURowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private UGOVORORADUDataSet.UGOVORORADURow eventRow;

            public UGOVORORADURowChangeEvent(UGOVORORADUDataSet.UGOVORORADURow row, DataRowAction action)
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

            public UGOVORORADUDataSet.UGOVORORADURow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void UGOVORORADURowChangeEventHandler(object sender, UGOVORORADUDataSet.UGOVORORADURowChangeEvent e);
    }
}

