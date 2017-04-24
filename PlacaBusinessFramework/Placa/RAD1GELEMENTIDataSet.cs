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
    public class RAD1GELEMENTIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1GELEMENTIDataTable tableRAD1GELEMENTI;

        public RAD1GELEMENTIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1GELEMENTIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1GELEMENTI"] != null)
                    {
                        this.Tables.Add(new RAD1GELEMENTIDataTable(dataSet.Tables["RAD1GELEMENTI"]));
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
            RAD1GELEMENTIDataSet set = (RAD1GELEMENTIDataSet) base.Clone();
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
            RAD1GELEMENTIDataSet set = new RAD1GELEMENTIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1GELEMENTIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2172");
            this.ExtendedProperties.Add("DataSetName", "RAD1GELEMENTIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1GELEMENTIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1GELEMENTI");
            this.ExtendedProperties.Add("ObjectDescription", "RAD1GELEMENTI");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "RAD1GELEMENTINAZIV");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RAD1GELEMENTIDataSet";
            this.Namespace = "http://www.tempuri.org/RAD1GELEMENTI";
            this.tableRAD1GELEMENTI = new RAD1GELEMENTIDataTable();
            this.Tables.Add(this.tableRAD1GELEMENTI);
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
            this.tableRAD1GELEMENTI = (RAD1GELEMENTIDataTable) this.Tables["RAD1GELEMENTI"];
            if (initTable && (this.tableRAD1GELEMENTI != null))
            {
                this.tableRAD1GELEMENTI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1GELEMENTI"] != null)
                {
                    this.Tables.Add(new RAD1GELEMENTIDataTable(dataSet.Tables["RAD1GELEMENTI"]));
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

        private bool ShouldSerializeRAD1GELEMENTI()
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
        public RAD1GELEMENTIDataTable RAD1GELEMENTI
        {
            get
            {
                return this.tableRAD1GELEMENTI;
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
        public class RAD1GELEMENTIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnRAD1GELEMENTIID;
            private DataColumn columnRAD1GELEMENTINAZIV;

            public event RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler RAD1GELEMENTIRowChanged;

            public event RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler RAD1GELEMENTIRowChanging;

            public event RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler RAD1GELEMENTIRowDeleted;

            public event RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler RAD1GELEMENTIRowDeleting;

            public RAD1GELEMENTIDataTable()
            {
                this.TableName = "RAD1GELEMENTI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1GELEMENTIDataTable(DataTable table) : base(table.TableName)
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

            protected RAD1GELEMENTIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1GELEMENTIRow(RAD1GELEMENTIDataSet.RAD1GELEMENTIRow row)
            {
                this.Rows.Add(row);
            }

            public RAD1GELEMENTIDataSet.RAD1GELEMENTIRow AddRAD1GELEMENTIRow(int rAD1GELEMENTIID, string rAD1GELEMENTINAZIV)
            {
                RAD1GELEMENTIDataSet.RAD1GELEMENTIRow row = (RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) this.NewRow();
                row["RAD1GELEMENTIID"] = rAD1GELEMENTIID;
                row["RAD1GELEMENTINAZIV"] = rAD1GELEMENTINAZIV;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1GELEMENTIDataSet.RAD1GELEMENTIDataTable table = (RAD1GELEMENTIDataSet.RAD1GELEMENTIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1GELEMENTIDataSet.RAD1GELEMENTIRow FindByRAD1GELEMENTIID(int rAD1GELEMENTIID)
            {
                return (RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) this.Rows.Find(new object[] { rAD1GELEMENTIID });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1GELEMENTIDataSet.RAD1GELEMENTIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1GELEMENTIDataSet set = new RAD1GELEMENTIDataSet();
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
                this.columnRAD1GELEMENTIID = new DataColumn("RAD1GELEMENTIID", typeof(int), "", MappingType.Element);
                this.columnRAD1GELEMENTIID.AllowDBNull = false;
                this.columnRAD1GELEMENTIID.Caption = "RAD1 GELEMENTIID";
                this.columnRAD1GELEMENTIID.Unique = true;
                this.columnRAD1GELEMENTIID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Description", "RAD1 GELEMENTIID");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Length", "5");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1GELEMENTIID.ExtendedProperties.Add("Deklarit.InternalName", "RAD1GELEMENTIID");
                this.Columns.Add(this.columnRAD1GELEMENTIID);
                this.columnRAD1GELEMENTINAZIV = new DataColumn("RAD1GELEMENTINAZIV", typeof(string), "", MappingType.Element);
                this.columnRAD1GELEMENTINAZIV.AllowDBNull = false;
                this.columnRAD1GELEMENTINAZIV.Caption = "RAD1 GELEMENTINAZIV";
                this.columnRAD1GELEMENTINAZIV.MaxLength = 30;
                this.columnRAD1GELEMENTINAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Description", "RAD1 GELEMENTINAZIV");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Length", "30");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1GELEMENTINAZIV.ExtendedProperties.Add("Deklarit.InternalName", "RAD1GELEMENTINAZIV");
                this.Columns.Add(this.columnRAD1GELEMENTINAZIV);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1GELEMENTIID };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1GELEMENTI");
                this.ExtendedProperties.Add("Description", "RAD1GELEMENTI");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1GELEMENTIID = this.Columns["RAD1GELEMENTIID"];
                this.columnRAD1GELEMENTINAZIV = this.Columns["RAD1GELEMENTINAZIV"];
            }

            public RAD1GELEMENTIDataSet.RAD1GELEMENTIRow NewRAD1GELEMENTIRow()
            {
                return (RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1GELEMENTIDataSet.RAD1GELEMENTIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1GELEMENTIRowChanged != null)
                {
                    RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler handler = this.RAD1GELEMENTIRowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEvent((RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1GELEMENTIRowChanging != null)
                {
                    RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler handler = this.RAD1GELEMENTIRowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEvent((RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1GELEMENTIRowDeleted != null)
                {
                    RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler handler = this.RAD1GELEMENTIRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEvent((RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1GELEMENTIRowDeleting != null)
                {
                    RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEventHandler handler = this.RAD1GELEMENTIRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEvent((RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1GELEMENTIRow(RAD1GELEMENTIDataSet.RAD1GELEMENTIRow row)
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

            public RAD1GELEMENTIDataSet.RAD1GELEMENTIRow this[int index]
            {
                get
                {
                    return (RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) this.Rows[index];
                }
            }

            public DataColumn RAD1GELEMENTIIDColumn
            {
                get
                {
                    return this.columnRAD1GELEMENTIID;
                }
            }

            public DataColumn RAD1GELEMENTINAZIVColumn
            {
                get
                {
                    return this.columnRAD1GELEMENTINAZIV;
                }
            }
        }

        public class RAD1GELEMENTIRow : DataRow
        {
            private RAD1GELEMENTIDataSet.RAD1GELEMENTIDataTable tableRAD1GELEMENTI;

            internal RAD1GELEMENTIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1GELEMENTI = (RAD1GELEMENTIDataSet.RAD1GELEMENTIDataTable) this.Table;
            }

            public bool IsRAD1GELEMENTIIDNull()
            {
                return this.IsNull(this.tableRAD1GELEMENTI.RAD1GELEMENTIIDColumn);
            }

            public bool IsRAD1GELEMENTINAZIVNull()
            {
                return this.IsNull(this.tableRAD1GELEMENTI.RAD1GELEMENTINAZIVColumn);
            }

            public void SetRAD1GELEMENTINAZIVNull()
            {
                this[this.tableRAD1GELEMENTI.RAD1GELEMENTINAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int RAD1GELEMENTIID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1GELEMENTI.RAD1GELEMENTIIDColumn]);
                }
                set
                {
                    this[this.tableRAD1GELEMENTI.RAD1GELEMENTIIDColumn] = value;
                }
            }

            public string RAD1GELEMENTINAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRAD1GELEMENTI.RAD1GELEMENTINAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value RAD1GELEMENTINAZIV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRAD1GELEMENTI.RAD1GELEMENTINAZIVColumn] = value;
                }
            }
        }

        public class RAD1GELEMENTIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1GELEMENTIDataSet.RAD1GELEMENTIRow eventRow;

            public RAD1GELEMENTIRowChangeEvent(RAD1GELEMENTIDataSet.RAD1GELEMENTIRow row, DataRowAction action)
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

            public RAD1GELEMENTIDataSet.RAD1GELEMENTIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1GELEMENTIRowChangeEventHandler(object sender, RAD1GELEMENTIDataSet.RAD1GELEMENTIRowChangeEvent e);
    }
}

