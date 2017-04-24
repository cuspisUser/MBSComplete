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
    public class RAD1SPOLDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1SPOLDataTable tableRAD1SPOL;

        public RAD1SPOLDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1SPOLDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1SPOL"] != null)
                    {
                        this.Tables.Add(new RAD1SPOLDataTable(dataSet.Tables["RAD1SPOL"]));
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
            RAD1SPOLDataSet set = (RAD1SPOLDataSet) base.Clone();
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
            RAD1SPOLDataSet set = new RAD1SPOLDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1SPOLDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2174");
            this.ExtendedProperties.Add("DataSetName", "RAD1SPOLDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1SPOLDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1SPOL");
            this.ExtendedProperties.Add("ObjectDescription", "RAD1SPOL");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "RAD1SPOLNAZIV");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RAD1SPOLDataSet";
            this.Namespace = "http://www.tempuri.org/RAD1SPOL";
            this.tableRAD1SPOL = new RAD1SPOLDataTable();
            this.Tables.Add(this.tableRAD1SPOL);
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
            this.tableRAD1SPOL = (RAD1SPOLDataTable) this.Tables["RAD1SPOL"];
            if (initTable && (this.tableRAD1SPOL != null))
            {
                this.tableRAD1SPOL.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1SPOL"] != null)
                {
                    this.Tables.Add(new RAD1SPOLDataTable(dataSet.Tables["RAD1SPOL"]));
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

        private bool ShouldSerializeRAD1SPOL()
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
        public RAD1SPOLDataTable RAD1SPOL
        {
            get
            {
                return this.tableRAD1SPOL;
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
        public class RAD1SPOLDataTable : DataTable, IEnumerable
        {
            private DataColumn columnRAD1SPOLID;
            private DataColumn columnRAD1SPOLNAZIV;

            public event RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler RAD1SPOLRowChanged;

            public event RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler RAD1SPOLRowChanging;

            public event RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler RAD1SPOLRowDeleted;

            public event RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler RAD1SPOLRowDeleting;

            public RAD1SPOLDataTable()
            {
                this.TableName = "RAD1SPOL";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1SPOLDataTable(DataTable table) : base(table.TableName)
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

            protected RAD1SPOLDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1SPOLRow(RAD1SPOLDataSet.RAD1SPOLRow row)
            {
                this.Rows.Add(row);
            }

            public RAD1SPOLDataSet.RAD1SPOLRow AddRAD1SPOLRow(int rAD1SPOLID, string rAD1SPOLNAZIV)
            {
                RAD1SPOLDataSet.RAD1SPOLRow row = (RAD1SPOLDataSet.RAD1SPOLRow) this.NewRow();
                row["RAD1SPOLID"] = rAD1SPOLID;
                row["RAD1SPOLNAZIV"] = rAD1SPOLNAZIV;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1SPOLDataSet.RAD1SPOLDataTable table = (RAD1SPOLDataSet.RAD1SPOLDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1SPOLDataSet.RAD1SPOLRow FindByRAD1SPOLID(int rAD1SPOLID)
            {
                return (RAD1SPOLDataSet.RAD1SPOLRow) this.Rows.Find(new object[] { rAD1SPOLID });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1SPOLDataSet.RAD1SPOLRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1SPOLDataSet set = new RAD1SPOLDataSet();
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
                this.columnRAD1SPOLID = new DataColumn("RAD1SPOLID", typeof(int), "", MappingType.Element);
                this.columnRAD1SPOLID.AllowDBNull = false;
                this.columnRAD1SPOLID.Caption = "RAD1 SPOLID";
                this.columnRAD1SPOLID.Unique = true;
                this.columnRAD1SPOLID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1SPOLID.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Description", "RAD1 SPOLID");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Length", "5");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1SPOLID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.InternalName", "RAD1SPOLID");
                this.Columns.Add(this.columnRAD1SPOLID);
                this.columnRAD1SPOLNAZIV = new DataColumn("RAD1SPOLNAZIV", typeof(string), "", MappingType.Element);
                this.columnRAD1SPOLNAZIV.AllowDBNull = false;
                this.columnRAD1SPOLNAZIV.Caption = "RAD1 SPOLNAZIV";
                this.columnRAD1SPOLNAZIV.MaxLength = 20;
                this.columnRAD1SPOLNAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Description", "RAD1 SPOLNAZIV");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Length", "20");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1SPOLNAZIV.ExtendedProperties.Add("Deklarit.InternalName", "RAD1SPOLNAZIV");
                this.Columns.Add(this.columnRAD1SPOLNAZIV);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1SPOLID };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1SPOL");
                this.ExtendedProperties.Add("Description", "RAD1SPOL");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1SPOLID = this.Columns["RAD1SPOLID"];
                this.columnRAD1SPOLNAZIV = this.Columns["RAD1SPOLNAZIV"];
            }

            public RAD1SPOLDataSet.RAD1SPOLRow NewRAD1SPOLRow()
            {
                return (RAD1SPOLDataSet.RAD1SPOLRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1SPOLDataSet.RAD1SPOLRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1SPOLRowChanged != null)
                {
                    RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler handler = this.RAD1SPOLRowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPOLDataSet.RAD1SPOLRowChangeEvent((RAD1SPOLDataSet.RAD1SPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1SPOLRowChanging != null)
                {
                    RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler handler = this.RAD1SPOLRowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPOLDataSet.RAD1SPOLRowChangeEvent((RAD1SPOLDataSet.RAD1SPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1SPOLRowDeleted != null)
                {
                    RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler handler = this.RAD1SPOLRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPOLDataSet.RAD1SPOLRowChangeEvent((RAD1SPOLDataSet.RAD1SPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1SPOLRowDeleting != null)
                {
                    RAD1SPOLDataSet.RAD1SPOLRowChangeEventHandler handler = this.RAD1SPOLRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPOLDataSet.RAD1SPOLRowChangeEvent((RAD1SPOLDataSet.RAD1SPOLRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1SPOLRow(RAD1SPOLDataSet.RAD1SPOLRow row)
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

            public RAD1SPOLDataSet.RAD1SPOLRow this[int index]
            {
                get
                {
                    return (RAD1SPOLDataSet.RAD1SPOLRow) this.Rows[index];
                }
            }

            public DataColumn RAD1SPOLIDColumn
            {
                get
                {
                    return this.columnRAD1SPOLID;
                }
            }

            public DataColumn RAD1SPOLNAZIVColumn
            {
                get
                {
                    return this.columnRAD1SPOLNAZIV;
                }
            }
        }

        public class RAD1SPOLRow : DataRow
        {
            private RAD1SPOLDataSet.RAD1SPOLDataTable tableRAD1SPOL;

            internal RAD1SPOLRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1SPOL = (RAD1SPOLDataSet.RAD1SPOLDataTable) this.Table;
            }

            public bool IsRAD1SPOLIDNull()
            {
                return this.IsNull(this.tableRAD1SPOL.RAD1SPOLIDColumn);
            }

            public bool IsRAD1SPOLNAZIVNull()
            {
                return this.IsNull(this.tableRAD1SPOL.RAD1SPOLNAZIVColumn);
            }

            public void SetRAD1SPOLNAZIVNull()
            {
                this[this.tableRAD1SPOL.RAD1SPOLNAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int RAD1SPOLID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1SPOL.RAD1SPOLIDColumn]);
                }
                set
                {
                    this[this.tableRAD1SPOL.RAD1SPOLIDColumn] = value;
                }
            }

            public string RAD1SPOLNAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRAD1SPOL.RAD1SPOLNAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value RAD1SPOLNAZIV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRAD1SPOL.RAD1SPOLNAZIVColumn] = value;
                }
            }
        }

        public class RAD1SPOLRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1SPOLDataSet.RAD1SPOLRow eventRow;

            public RAD1SPOLRowChangeEvent(RAD1SPOLDataSet.RAD1SPOLRow row, DataRowAction action)
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

            public RAD1SPOLDataSet.RAD1SPOLRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1SPOLRowChangeEventHandler(object sender, RAD1SPOLDataSet.RAD1SPOLRowChangeEvent e);
    }
}

