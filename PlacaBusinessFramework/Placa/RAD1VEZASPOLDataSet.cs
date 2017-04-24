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
    public class RAD1VEZASPOLDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1VEZASPOLDataTable tableRAD1VEZASPOL;

        public RAD1VEZASPOLDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1VEZASPOLDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1VEZASPOL"] != null)
                    {
                        this.Tables.Add(new RAD1VEZASPOLDataTable(dataSet.Tables["RAD1VEZASPOL"]));
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
            RAD1VEZASPOLDataSet set = (RAD1VEZASPOLDataSet) base.Clone();
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
            RAD1VEZASPOLDataSet set = new RAD1VEZASPOLDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1VEZASPOLDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2176");
            this.ExtendedProperties.Add("DataSetName", "RAD1VEZASPOLDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1VEZASPOLDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1VEZASPOL");
            this.ExtendedProperties.Add("ObjectDescription", "Veza RAD1 i spol");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\VezeRAD1");
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
            this.DataSetName = "RAD1VEZASPOLDataSet";
            this.Namespace = "http://www.tempuri.org/RAD1VEZASPOL";
            this.tableRAD1VEZASPOL = new RAD1VEZASPOLDataTable();
            this.Tables.Add(this.tableRAD1VEZASPOL);
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
            this.tableRAD1VEZASPOL = (RAD1VEZASPOLDataTable) this.Tables["RAD1VEZASPOL"];
            if (initTable && (this.tableRAD1VEZASPOL != null))
            {
                this.tableRAD1VEZASPOL.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1VEZASPOL"] != null)
                {
                    this.Tables.Add(new RAD1VEZASPOLDataTable(dataSet.Tables["RAD1VEZASPOL"]));
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

        private bool ShouldSerializeRAD1VEZASPOL()
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
        public RAD1VEZASPOLDataTable RAD1VEZASPOL
        {
            get
            {
                return this.tableRAD1VEZASPOL;
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
        public class RAD1VEZASPOLDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSPOL;
            private DataColumn columnRAD1SPOLID;

            public event RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler RAD1VEZASPOLRowChanged;

            public event RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler RAD1VEZASPOLRowChanging;

            public event RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler RAD1VEZASPOLRowDeleted;

            public event RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler RAD1VEZASPOLRowDeleting;

            public RAD1VEZASPOLDataTable()
            {
                this.TableName = "RAD1VEZASPOL";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1VEZASPOLDataTable(DataTable table) : base(table.TableName)
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

            protected RAD1VEZASPOLDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1VEZASPOLRow(RAD1VEZASPOLDataSet.RAD1VEZASPOLRow row)
            {
                this.Rows.Add(row);
            }

            public RAD1VEZASPOLDataSet.RAD1VEZASPOLRow AddRAD1VEZASPOLRow(int rAD1SPOLID, int iDSPOL)
            {
                RAD1VEZASPOLDataSet.RAD1VEZASPOLRow row = (RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) this.NewRow();
                row["RAD1SPOLID"] = rAD1SPOLID;
                row["IDSPOL"] = iDSPOL;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1VEZASPOLDataSet.RAD1VEZASPOLDataTable table = (RAD1VEZASPOLDataSet.RAD1VEZASPOLDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1VEZASPOLDataSet.RAD1VEZASPOLRow FindByRAD1SPOLIDIDSPOL(int rAD1SPOLID, int iDSPOL)
            {
                return (RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) this.Rows.Find(new object[] { rAD1SPOLID, iDSPOL });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1VEZASPOLDataSet.RAD1VEZASPOLRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1VEZASPOLDataSet set = new RAD1VEZASPOLDataSet();
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
                this.columnRAD1SPOLID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1SPOLID.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Description", "Spol u RAD1 obrascu");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Length", "5");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1SPOLID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1SPOLID.ExtendedProperties.Add("Deklarit.InternalName", "RAD1SPOLID");
                this.Columns.Add(this.columnRAD1SPOLID);
                this.columnIDSPOL = new DataColumn("IDSPOL", typeof(int), "", MappingType.Element);
                this.columnIDSPOL.AllowDBNull = false;
                this.columnIDSPOL.Caption = "IDSPOL";
                this.columnIDSPOL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSPOL.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSPOL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSPOL.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSPOL.ExtendedProperties.Add("Description", "Spol iz kadrovske evidencije");
                this.columnIDSPOL.ExtendedProperties.Add("Length", "5");
                this.columnIDSPOL.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSPOL.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSPOL.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.InternalName", "IDSPOL");
                this.Columns.Add(this.columnIDSPOL);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1SPOLID, this.columnIDSPOL };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1VEZASPOL");
                this.ExtendedProperties.Add("Description", "Veza RAD1 i spol");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1SPOLID = this.Columns["RAD1SPOLID"];
                this.columnIDSPOL = this.Columns["IDSPOL"];
            }

            public RAD1VEZASPOLDataSet.RAD1VEZASPOLRow NewRAD1VEZASPOLRow()
            {
                return (RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1VEZASPOLDataSet.RAD1VEZASPOLRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1VEZASPOLRowChanged != null)
                {
                    RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler handler = this.RAD1VEZASPOLRowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEvent((RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1VEZASPOLRowChanging != null)
                {
                    RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler handler = this.RAD1VEZASPOLRowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEvent((RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1VEZASPOLRowDeleted != null)
                {
                    RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler handler = this.RAD1VEZASPOLRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEvent((RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1VEZASPOLRowDeleting != null)
                {
                    RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEventHandler handler = this.RAD1VEZASPOLRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEvent((RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1VEZASPOLRow(RAD1VEZASPOLDataSet.RAD1VEZASPOLRow row)
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

            public DataColumn IDSPOLColumn
            {
                get
                {
                    return this.columnIDSPOL;
                }
            }

            public RAD1VEZASPOLDataSet.RAD1VEZASPOLRow this[int index]
            {
                get
                {
                    return (RAD1VEZASPOLDataSet.RAD1VEZASPOLRow) this.Rows[index];
                }
            }

            public DataColumn RAD1SPOLIDColumn
            {
                get
                {
                    return this.columnRAD1SPOLID;
                }
            }
        }

        public class RAD1VEZASPOLRow : DataRow
        {
            private RAD1VEZASPOLDataSet.RAD1VEZASPOLDataTable tableRAD1VEZASPOL;

            internal RAD1VEZASPOLRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1VEZASPOL = (RAD1VEZASPOLDataSet.RAD1VEZASPOLDataTable) this.Table;
            }

            public bool IsIDSPOLNull()
            {
                return this.IsNull(this.tableRAD1VEZASPOL.IDSPOLColumn);
            }

            public bool IsRAD1SPOLIDNull()
            {
                return this.IsNull(this.tableRAD1VEZASPOL.RAD1SPOLIDColumn);
            }

            public int IDSPOL
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1VEZASPOL.IDSPOLColumn]);
                }
                set
                {
                    this[this.tableRAD1VEZASPOL.IDSPOLColumn] = value;
                }
            }

            public int RAD1SPOLID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1VEZASPOL.RAD1SPOLIDColumn]);
                }
                set
                {
                    this[this.tableRAD1VEZASPOL.RAD1SPOLIDColumn] = value;
                }
            }
        }

        public class RAD1VEZASPOLRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1VEZASPOLDataSet.RAD1VEZASPOLRow eventRow;

            public RAD1VEZASPOLRowChangeEvent(RAD1VEZASPOLDataSet.RAD1VEZASPOLRow row, DataRowAction action)
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

            public RAD1VEZASPOLDataSet.RAD1VEZASPOLRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1VEZASPOLRowChangeEventHandler(object sender, RAD1VEZASPOLDataSet.RAD1VEZASPOLRowChangeEvent e);
    }
}

