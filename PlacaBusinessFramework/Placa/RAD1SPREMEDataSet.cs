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
    public class RAD1SPREMEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1SPREMEDataTable tableRAD1SPREME;

        public RAD1SPREMEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1SPREMEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1SPREME"] != null)
                    {
                        this.Tables.Add(new RAD1SPREMEDataTable(dataSet.Tables["RAD1SPREME"]));
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
            RAD1SPREMEDataSet set = (RAD1SPREMEDataSet) base.Clone();
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
            RAD1SPREMEDataSet set = new RAD1SPREMEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1SPREMEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2171");
            this.ExtendedProperties.Add("DataSetName", "RAD1SPREMEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1SPREMEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1SPREME");
            this.ExtendedProperties.Add("ObjectDescription", "RAD1SPREME");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "RAD1NAZIVSPREME");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RAD1SPREMEDataSet";
            this.Namespace = "http://www.tempuri.org/RAD1SPREME";
            this.tableRAD1SPREME = new RAD1SPREMEDataTable();
            this.Tables.Add(this.tableRAD1SPREME);
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
            this.tableRAD1SPREME = (RAD1SPREMEDataTable) this.Tables["RAD1SPREME"];
            if (initTable && (this.tableRAD1SPREME != null))
            {
                this.tableRAD1SPREME.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1SPREME"] != null)
                {
                    this.Tables.Add(new RAD1SPREMEDataTable(dataSet.Tables["RAD1SPREME"]));
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

        private bool ShouldSerializeRAD1SPREME()
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
        public RAD1SPREMEDataTable RAD1SPREME
        {
            get
            {
                return this.tableRAD1SPREME;
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
        public class RAD1SPREMEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnRAD1IDSPREME;
            private DataColumn columnRAD1NAZIVSPREME;

            public event RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler RAD1SPREMERowChanged;

            public event RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler RAD1SPREMERowChanging;

            public event RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler RAD1SPREMERowDeleted;

            public event RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler RAD1SPREMERowDeleting;

            public RAD1SPREMEDataTable()
            {
                this.TableName = "RAD1SPREME";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1SPREMEDataTable(DataTable table) : base(table.TableName)
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

            protected RAD1SPREMEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1SPREMERow(RAD1SPREMEDataSet.RAD1SPREMERow row)
            {
                this.Rows.Add(row);
            }

            public RAD1SPREMEDataSet.RAD1SPREMERow AddRAD1SPREMERow(int rAD1IDSPREME, string rAD1NAZIVSPREME)
            {
                RAD1SPREMEDataSet.RAD1SPREMERow row = (RAD1SPREMEDataSet.RAD1SPREMERow) this.NewRow();
                row["RAD1IDSPREME"] = rAD1IDSPREME;
                row["RAD1NAZIVSPREME"] = rAD1NAZIVSPREME;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1SPREMEDataSet.RAD1SPREMEDataTable table = (RAD1SPREMEDataSet.RAD1SPREMEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1SPREMEDataSet.RAD1SPREMERow FindByRAD1IDSPREME(int rAD1IDSPREME)
            {
                return (RAD1SPREMEDataSet.RAD1SPREMERow) this.Rows.Find(new object[] { rAD1IDSPREME });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1SPREMEDataSet.RAD1SPREMERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1SPREMEDataSet set = new RAD1SPREMEDataSet();
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
                this.columnRAD1IDSPREME = new DataColumn("RAD1IDSPREME", typeof(int), "", MappingType.Element);
                this.columnRAD1IDSPREME.AllowDBNull = false;
                this.columnRAD1IDSPREME.Caption = "RAD1 IDSPREME";
                this.columnRAD1IDSPREME.Unique = true;
                this.columnRAD1IDSPREME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Description", "RAD1 IDSPREME");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Length", "5");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.InternalName", "RAD1IDSPREME");
                this.Columns.Add(this.columnRAD1IDSPREME);
                this.columnRAD1NAZIVSPREME = new DataColumn("RAD1NAZIVSPREME", typeof(string), "", MappingType.Element);
                this.columnRAD1NAZIVSPREME.AllowDBNull = false;
                this.columnRAD1NAZIVSPREME.Caption = "RAD1 NAZIVSPREME";
                this.columnRAD1NAZIVSPREME.MaxLength = 50;
                this.columnRAD1NAZIVSPREME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("IsKey", "false");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Description", "RAD1 NAZIVSPREME");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Length", "50");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1NAZIVSPREME.ExtendedProperties.Add("Deklarit.InternalName", "RAD1NAZIVSPREME");
                this.Columns.Add(this.columnRAD1NAZIVSPREME);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1IDSPREME };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1SPREME");
                this.ExtendedProperties.Add("Description", "RAD1SPREME");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1IDSPREME = this.Columns["RAD1IDSPREME"];
                this.columnRAD1NAZIVSPREME = this.Columns["RAD1NAZIVSPREME"];
            }

            public RAD1SPREMEDataSet.RAD1SPREMERow NewRAD1SPREMERow()
            {
                return (RAD1SPREMEDataSet.RAD1SPREMERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1SPREMEDataSet.RAD1SPREMERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1SPREMERowChanged != null)
                {
                    RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler handler = this.RAD1SPREMERowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEDataSet.RAD1SPREMERowChangeEvent((RAD1SPREMEDataSet.RAD1SPREMERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1SPREMERowChanging != null)
                {
                    RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler handler = this.RAD1SPREMERowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEDataSet.RAD1SPREMERowChangeEvent((RAD1SPREMEDataSet.RAD1SPREMERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1SPREMERowDeleted != null)
                {
                    RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler handler = this.RAD1SPREMERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEDataSet.RAD1SPREMERowChangeEvent((RAD1SPREMEDataSet.RAD1SPREMERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1SPREMERowDeleting != null)
                {
                    RAD1SPREMEDataSet.RAD1SPREMERowChangeEventHandler handler = this.RAD1SPREMERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEDataSet.RAD1SPREMERowChangeEvent((RAD1SPREMEDataSet.RAD1SPREMERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1SPREMERow(RAD1SPREMEDataSet.RAD1SPREMERow row)
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

            public RAD1SPREMEDataSet.RAD1SPREMERow this[int index]
            {
                get
                {
                    return (RAD1SPREMEDataSet.RAD1SPREMERow) this.Rows[index];
                }
            }

            public DataColumn RAD1IDSPREMEColumn
            {
                get
                {
                    return this.columnRAD1IDSPREME;
                }
            }

            public DataColumn RAD1NAZIVSPREMEColumn
            {
                get
                {
                    return this.columnRAD1NAZIVSPREME;
                }
            }
        }

        public class RAD1SPREMERow : DataRow
        {
            private RAD1SPREMEDataSet.RAD1SPREMEDataTable tableRAD1SPREME;

            internal RAD1SPREMERow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1SPREME = (RAD1SPREMEDataSet.RAD1SPREMEDataTable) this.Table;
            }

            public bool IsRAD1IDSPREMENull()
            {
                return this.IsNull(this.tableRAD1SPREME.RAD1IDSPREMEColumn);
            }

            public bool IsRAD1NAZIVSPREMENull()
            {
                return this.IsNull(this.tableRAD1SPREME.RAD1NAZIVSPREMEColumn);
            }

            public void SetRAD1NAZIVSPREMENull()
            {
                this[this.tableRAD1SPREME.RAD1NAZIVSPREMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int RAD1IDSPREME
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1SPREME.RAD1IDSPREMEColumn]);
                }
                set
                {
                    this[this.tableRAD1SPREME.RAD1IDSPREMEColumn] = value;
                }
            }

            public string RAD1NAZIVSPREME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRAD1SPREME.RAD1NAZIVSPREMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value RAD1NAZIVSPREME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRAD1SPREME.RAD1NAZIVSPREMEColumn] = value;
                }
            }
        }

        public class RAD1SPREMERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1SPREMEDataSet.RAD1SPREMERow eventRow;

            public RAD1SPREMERowChangeEvent(RAD1SPREMEDataSet.RAD1SPREMERow row, DataRowAction action)
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

            public RAD1SPREMEDataSet.RAD1SPREMERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1SPREMERowChangeEventHandler(object sender, RAD1SPREMEDataSet.RAD1SPREMERowChangeEvent e);
    }
}

