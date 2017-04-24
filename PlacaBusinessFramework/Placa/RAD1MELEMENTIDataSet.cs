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
    public class RAD1MELEMENTIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1MELEMENTIDataTable tableRAD1MELEMENTI;

        public RAD1MELEMENTIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1MELEMENTIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1MELEMENTI"] != null)
                    {
                        this.Tables.Add(new RAD1MELEMENTIDataTable(dataSet.Tables["RAD1MELEMENTI"]));
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
            RAD1MELEMENTIDataSet set = (RAD1MELEMENTIDataSet) base.Clone();
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
            RAD1MELEMENTIDataSet set = new RAD1MELEMENTIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1MELEMENTIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2173");
            this.ExtendedProperties.Add("DataSetName", "RAD1MELEMENTIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1MELEMENTIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1MELEMENTI");
            this.ExtendedProperties.Add("ObjectDescription", "RAD1MELEMENTI");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "RAD1ELEMENTINAZIV");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RAD1MELEMENTIDataSet";
            this.Namespace = "http://www.tempuri.org/RAD1MELEMENTI";
            this.tableRAD1MELEMENTI = new RAD1MELEMENTIDataTable();
            this.Tables.Add(this.tableRAD1MELEMENTI);
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
            this.tableRAD1MELEMENTI = (RAD1MELEMENTIDataTable) this.Tables["RAD1MELEMENTI"];
            if (initTable && (this.tableRAD1MELEMENTI != null))
            {
                this.tableRAD1MELEMENTI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1MELEMENTI"] != null)
                {
                    this.Tables.Add(new RAD1MELEMENTIDataTable(dataSet.Tables["RAD1MELEMENTI"]));
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

        private bool ShouldSerializeRAD1MELEMENTI()
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
        public RAD1MELEMENTIDataTable RAD1MELEMENTI
        {
            get
            {
                return this.tableRAD1MELEMENTI;
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
        public class RAD1MELEMENTIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnRAD1ELEMENTIID;
            private DataColumn columnRAD1ELEMENTINAZIV;

            public event RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler RAD1MELEMENTIRowChanged;

            public event RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler RAD1MELEMENTIRowChanging;

            public event RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler RAD1MELEMENTIRowDeleted;

            public event RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler RAD1MELEMENTIRowDeleting;

            public RAD1MELEMENTIDataTable()
            {
                this.TableName = "RAD1MELEMENTI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1MELEMENTIDataTable(DataTable table) : base(table.TableName)
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

            protected RAD1MELEMENTIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1MELEMENTIRow(RAD1MELEMENTIDataSet.RAD1MELEMENTIRow row)
            {
                this.Rows.Add(row);
            }

            public RAD1MELEMENTIDataSet.RAD1MELEMENTIRow AddRAD1MELEMENTIRow(int rAD1ELEMENTIID, string rAD1ELEMENTINAZIV)
            {
                RAD1MELEMENTIDataSet.RAD1MELEMENTIRow row = (RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) this.NewRow();
                row["RAD1ELEMENTIID"] = rAD1ELEMENTIID;
                row["RAD1ELEMENTINAZIV"] = rAD1ELEMENTINAZIV;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1MELEMENTIDataSet.RAD1MELEMENTIDataTable table = (RAD1MELEMENTIDataSet.RAD1MELEMENTIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1MELEMENTIDataSet.RAD1MELEMENTIRow FindByRAD1ELEMENTIID(int rAD1ELEMENTIID)
            {
                return (RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) this.Rows.Find(new object[] { rAD1ELEMENTIID });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1MELEMENTIDataSet.RAD1MELEMENTIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1MELEMENTIDataSet set = new RAD1MELEMENTIDataSet();
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
                this.columnRAD1ELEMENTIID = new DataColumn("RAD1ELEMENTIID", typeof(int), "", MappingType.Element);
                this.columnRAD1ELEMENTIID.AllowDBNull = false;
                this.columnRAD1ELEMENTIID.Caption = "RAD1 ELEMENTIID";
                this.columnRAD1ELEMENTIID.Unique = true;
                this.columnRAD1ELEMENTIID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Description", "RAD1 ELEMENTIID");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Length", "5");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.InternalName", "RAD1ELEMENTIID");
                this.Columns.Add(this.columnRAD1ELEMENTIID);
                this.columnRAD1ELEMENTINAZIV = new DataColumn("RAD1ELEMENTINAZIV", typeof(string), "", MappingType.Element);
                this.columnRAD1ELEMENTINAZIV.AllowDBNull = false;
                this.columnRAD1ELEMENTINAZIV.Caption = "RAD1 ELEMENTINAZIV";
                this.columnRAD1ELEMENTINAZIV.MaxLength = 50;
                this.columnRAD1ELEMENTINAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Description", "RAD1 ELEMENTINAZIV");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Length", "50");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1ELEMENTINAZIV.ExtendedProperties.Add("Deklarit.InternalName", "RAD1ELEMENTINAZIV");
                this.Columns.Add(this.columnRAD1ELEMENTINAZIV);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1ELEMENTIID };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1MELEMENTI");
                this.ExtendedProperties.Add("Description", "RAD1MELEMENTI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1ELEMENTIID = this.Columns["RAD1ELEMENTIID"];
                this.columnRAD1ELEMENTINAZIV = this.Columns["RAD1ELEMENTINAZIV"];
            }

            public RAD1MELEMENTIDataSet.RAD1MELEMENTIRow NewRAD1MELEMENTIRow()
            {
                return (RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1MELEMENTIDataSet.RAD1MELEMENTIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1MELEMENTIRowChanged != null)
                {
                    RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler handler = this.RAD1MELEMENTIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEvent((RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1MELEMENTIRowChanging != null)
                {
                    RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler handler = this.RAD1MELEMENTIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEvent((RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1MELEMENTIRowDeleted != null)
                {
                    RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler handler = this.RAD1MELEMENTIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEvent((RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1MELEMENTIRowDeleting != null)
                {
                    RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEventHandler handler = this.RAD1MELEMENTIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEvent((RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1MELEMENTIRow(RAD1MELEMENTIDataSet.RAD1MELEMENTIRow row)
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

            public RAD1MELEMENTIDataSet.RAD1MELEMENTIRow this[int index]
            {
                get
                {
                    return (RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) this.Rows[index];
                }
            }

            public DataColumn RAD1ELEMENTIIDColumn
            {
                get
                {
                    return this.columnRAD1ELEMENTIID;
                }
            }

            public DataColumn RAD1ELEMENTINAZIVColumn
            {
                get
                {
                    return this.columnRAD1ELEMENTINAZIV;
                }
            }
        }

        public class RAD1MELEMENTIRow : DataRow
        {
            private RAD1MELEMENTIDataSet.RAD1MELEMENTIDataTable tableRAD1MELEMENTI;

            internal RAD1MELEMENTIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1MELEMENTI = (RAD1MELEMENTIDataSet.RAD1MELEMENTIDataTable) this.Table;
            }

            public bool IsRAD1ELEMENTIIDNull()
            {
                return this.IsNull(this.tableRAD1MELEMENTI.RAD1ELEMENTIIDColumn);
            }

            public bool IsRAD1ELEMENTINAZIVNull()
            {
                return this.IsNull(this.tableRAD1MELEMENTI.RAD1ELEMENTINAZIVColumn);
            }

            public void SetRAD1ELEMENTINAZIVNull()
            {
                this[this.tableRAD1MELEMENTI.RAD1ELEMENTINAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int RAD1ELEMENTIID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1MELEMENTI.RAD1ELEMENTIIDColumn]);
                }
                set
                {
                    this[this.tableRAD1MELEMENTI.RAD1ELEMENTIIDColumn] = value;
                }
            }

            public string RAD1ELEMENTINAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRAD1MELEMENTI.RAD1ELEMENTINAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value RAD1ELEMENTINAZIV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRAD1MELEMENTI.RAD1ELEMENTINAZIVColumn] = value;
                }
            }
        }

        public class RAD1MELEMENTIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1MELEMENTIDataSet.RAD1MELEMENTIRow eventRow;

            public RAD1MELEMENTIRowChangeEvent(RAD1MELEMENTIDataSet.RAD1MELEMENTIRow row, DataRowAction action)
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

            public RAD1MELEMENTIDataSet.RAD1MELEMENTIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1MELEMENTIRowChangeEventHandler(object sender, RAD1MELEMENTIDataSet.RAD1MELEMENTIRowChangeEvent e);
    }
}

