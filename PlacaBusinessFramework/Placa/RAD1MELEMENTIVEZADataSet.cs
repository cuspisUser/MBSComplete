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
    public class RAD1MELEMENTIVEZADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1MELEMENTIVEZADataTable tableRAD1MELEMENTIVEZA;

        public RAD1MELEMENTIVEZADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1MELEMENTIVEZADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1MELEMENTIVEZA"] != null)
                    {
                        this.Tables.Add(new RAD1MELEMENTIVEZADataTable(dataSet.Tables["RAD1MELEMENTIVEZA"]));
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
            RAD1MELEMENTIVEZADataSet set = (RAD1MELEMENTIVEZADataSet) base.Clone();
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
            RAD1MELEMENTIVEZADataSet set = new RAD1MELEMENTIVEZADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1MELEMENTIVEZADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2178");
            this.ExtendedProperties.Add("DataSetName", "RAD1MELEMENTIVEZADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1MELEMENTIVEZADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1MELEMENTIVEZA");
            this.ExtendedProperties.Add("ObjectDescription", "Veza RAD1M elementi i elementi");
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
            this.DataSetName = "RAD1MELEMENTIVEZADataSet";
            this.Namespace = "http://www.tempuri.org/RAD1MELEMENTIVEZA";
            this.tableRAD1MELEMENTIVEZA = new RAD1MELEMENTIVEZADataTable();
            this.Tables.Add(this.tableRAD1MELEMENTIVEZA);
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
            this.tableRAD1MELEMENTIVEZA = (RAD1MELEMENTIVEZADataTable) this.Tables["RAD1MELEMENTIVEZA"];
            if (initTable && (this.tableRAD1MELEMENTIVEZA != null))
            {
                this.tableRAD1MELEMENTIVEZA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1MELEMENTIVEZA"] != null)
                {
                    this.Tables.Add(new RAD1MELEMENTIVEZADataTable(dataSet.Tables["RAD1MELEMENTIVEZA"]));
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

        private bool ShouldSerializeRAD1MELEMENTIVEZA()
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
        public RAD1MELEMENTIVEZADataTable RAD1MELEMENTIVEZA
        {
            get
            {
                return this.tableRAD1MELEMENTIVEZA;
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
        public class RAD1MELEMENTIVEZADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDELEMENT;
            private DataColumn columnRAD1ELEMENTIID;

            public event RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler RAD1MELEMENTIVEZARowChanged;

            public event RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler RAD1MELEMENTIVEZARowChanging;

            public event RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler RAD1MELEMENTIVEZARowDeleted;

            public event RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler RAD1MELEMENTIVEZARowDeleting;

            public RAD1MELEMENTIVEZADataTable()
            {
                this.TableName = "RAD1MELEMENTIVEZA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1MELEMENTIVEZADataTable(DataTable table) : base(table.TableName)
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

            protected RAD1MELEMENTIVEZADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1MELEMENTIVEZARow(RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow row)
            {
                this.Rows.Add(row);
            }

            public RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow AddRAD1MELEMENTIVEZARow(int rAD1ELEMENTIID, int iDELEMENT)
            {
                RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow row = (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) this.NewRow();
                row["RAD1ELEMENTIID"] = rAD1ELEMENTIID;
                row["IDELEMENT"] = iDELEMENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZADataTable table = (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow FindByRAD1ELEMENTIIDIDELEMENT(int rAD1ELEMENTIID, int iDELEMENT)
            {
                return (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) this.Rows.Find(new object[] { rAD1ELEMENTIID, iDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1MELEMENTIVEZADataSet set = new RAD1MELEMENTIVEZADataSet();
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
                this.columnRAD1ELEMENTIID.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Description", "Element iz RAD-1M obrasca");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Length", "5");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1ELEMENTIID.ExtendedProperties.Add("Deklarit.InternalName", "RAD1ELEMENTIID");
                this.Columns.Add(this.columnRAD1ELEMENTIID);
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.AllowDBNull = false;
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Element iz programa plaća");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1ELEMENTIID, this.columnIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1MELEMENTIVEZA");
                this.ExtendedProperties.Add("Description", "Veza RAD1M elementi i elementi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1ELEMENTIID = this.Columns["RAD1ELEMENTIID"];
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
            }

            public RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow NewRAD1MELEMENTIVEZARow()
            {
                return (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1MELEMENTIVEZARowChanged != null)
                {
                    RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler handler = this.RAD1MELEMENTIVEZARowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEvent((RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1MELEMENTIVEZARowChanging != null)
                {
                    RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler handler = this.RAD1MELEMENTIVEZARowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEvent((RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1MELEMENTIVEZARowDeleted != null)
                {
                    RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler handler = this.RAD1MELEMENTIVEZARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEvent((RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1MELEMENTIVEZARowDeleting != null)
                {
                    RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEventHandler handler = this.RAD1MELEMENTIVEZARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEvent((RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1MELEMENTIVEZARow(RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow row)
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

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
                }
            }

            public RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow this[int index]
            {
                get
                {
                    return (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow) this.Rows[index];
                }
            }

            public DataColumn RAD1ELEMENTIIDColumn
            {
                get
                {
                    return this.columnRAD1ELEMENTIID;
                }
            }
        }

        public class RAD1MELEMENTIVEZARow : DataRow
        {
            private RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZADataTable tableRAD1MELEMENTIVEZA;

            internal RAD1MELEMENTIVEZARow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1MELEMENTIVEZA = (RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZADataTable) this.Table;
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tableRAD1MELEMENTIVEZA.IDELEMENTColumn);
            }

            public bool IsRAD1ELEMENTIIDNull()
            {
                return this.IsNull(this.tableRAD1MELEMENTIVEZA.RAD1ELEMENTIIDColumn);
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1MELEMENTIVEZA.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tableRAD1MELEMENTIVEZA.IDELEMENTColumn] = value;
                }
            }

            public int RAD1ELEMENTIID
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1MELEMENTIVEZA.RAD1ELEMENTIIDColumn]);
                }
                set
                {
                    this[this.tableRAD1MELEMENTIVEZA.RAD1ELEMENTIIDColumn] = value;
                }
            }
        }

        public class RAD1MELEMENTIVEZARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow eventRow;

            public RAD1MELEMENTIVEZARowChangeEvent(RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow row, DataRowAction action)
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

            public RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1MELEMENTIVEZARowChangeEventHandler(object sender, RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARowChangeEvent e);
    }
}

