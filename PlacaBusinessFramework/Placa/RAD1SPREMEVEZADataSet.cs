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
    public class RAD1SPREMEVEZADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RAD1SPREMEVEZADataTable tableRAD1SPREMEVEZA;

        public RAD1SPREMEVEZADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RAD1SPREMEVEZADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RAD1SPREMEVEZA"] != null)
                    {
                        this.Tables.Add(new RAD1SPREMEVEZADataTable(dataSet.Tables["RAD1SPREMEVEZA"]));
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
            RAD1SPREMEVEZADataSet set = (RAD1SPREMEVEZADataSet) base.Clone();
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
            RAD1SPREMEVEZADataSet set = new RAD1SPREMEVEZADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RAD1SPREMEVEZADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2179");
            this.ExtendedProperties.Add("DataSetName", "RAD1SPREMEVEZADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRAD1SPREMEVEZADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RAD1SPREMEVEZA");
            this.ExtendedProperties.Add("ObjectDescription", "Veza RAD1 i strucne spreme");
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
            this.DataSetName = "RAD1SPREMEVEZADataSet";
            this.Namespace = "http://www.tempuri.org/RAD1SPREMEVEZA";
            this.tableRAD1SPREMEVEZA = new RAD1SPREMEVEZADataTable();
            this.Tables.Add(this.tableRAD1SPREMEVEZA);
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
            this.tableRAD1SPREMEVEZA = (RAD1SPREMEVEZADataTable) this.Tables["RAD1SPREMEVEZA"];
            if (initTable && (this.tableRAD1SPREMEVEZA != null))
            {
                this.tableRAD1SPREMEVEZA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RAD1SPREMEVEZA"] != null)
                {
                    this.Tables.Add(new RAD1SPREMEVEZADataTable(dataSet.Tables["RAD1SPREMEVEZA"]));
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

        private bool ShouldSerializeRAD1SPREMEVEZA()
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
        public RAD1SPREMEVEZADataTable RAD1SPREMEVEZA
        {
            get
            {
                return this.tableRAD1SPREMEVEZA;
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
        public class RAD1SPREMEVEZADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSTRUCNASPREMA;
            private DataColumn columnRAD1IDSPREME;

            public event RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler RAD1SPREMEVEZARowChanged;

            public event RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler RAD1SPREMEVEZARowChanging;

            public event RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler RAD1SPREMEVEZARowDeleted;

            public event RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler RAD1SPREMEVEZARowDeleting;

            public RAD1SPREMEVEZADataTable()
            {
                this.TableName = "RAD1SPREMEVEZA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RAD1SPREMEVEZADataTable(DataTable table) : base(table.TableName)
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

            protected RAD1SPREMEVEZADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRAD1SPREMEVEZARow(RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow row)
            {
                this.Rows.Add(row);
            }

            public RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow AddRAD1SPREMEVEZARow(int rAD1IDSPREME, int iDSTRUCNASPREMA)
            {
                RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow row = (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) this.NewRow();
                row["RAD1IDSPREME"] = rAD1IDSPREME;
                row["IDSTRUCNASPREMA"] = iDSTRUCNASPREMA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RAD1SPREMEVEZADataSet.RAD1SPREMEVEZADataTable table = (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow FindByRAD1IDSPREMEIDSTRUCNASPREMA(int rAD1IDSPREME, int iDSTRUCNASPREMA)
            {
                return (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) this.Rows.Find(new object[] { rAD1IDSPREME, iDSTRUCNASPREMA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RAD1SPREMEVEZADataSet set = new RAD1SPREMEVEZADataSet();
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
                this.columnRAD1IDSPREME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("IsKey", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Description", "RAD1-Obrazac spreme");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Length", "5");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Decimals", "0");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("IsInReader", "true");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRAD1IDSPREME.ExtendedProperties.Add("Deklarit.InternalName", "RAD1IDSPREME");
                this.Columns.Add(this.columnRAD1IDSPREME);
                this.columnIDSTRUCNASPREMA = new DataColumn("IDSTRUCNASPREMA", typeof(int), "", MappingType.Element);
                this.columnIDSTRUCNASPREMA.AllowDBNull = false;
                this.columnIDSTRUCNASPREMA.Caption = "Šifra stručne spreme";
                this.columnIDSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Description", "Šifra stručne spreme iz kadrovske");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Length", "5");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "IDSTRUCNASPREMA");
                this.Columns.Add(this.columnIDSTRUCNASPREMA);
                this.PrimaryKey = new DataColumn[] { this.columnRAD1IDSPREME, this.columnIDSTRUCNASPREMA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RAD1SPREMEVEZA");
                this.ExtendedProperties.Add("Description", "Veza RAD1 i strucne spreme");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnRAD1IDSPREME = this.Columns["RAD1IDSPREME"];
                this.columnIDSTRUCNASPREMA = this.Columns["IDSTRUCNASPREMA"];
            }

            public RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow NewRAD1SPREMEVEZARow()
            {
                return (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RAD1SPREMEVEZARowChanged != null)
                {
                    RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler handler = this.RAD1SPREMEVEZARowChanged;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEvent((RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RAD1SPREMEVEZARowChanging != null)
                {
                    RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler handler = this.RAD1SPREMEVEZARowChanging;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEvent((RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RAD1SPREMEVEZARowDeleted != null)
                {
                    RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler handler = this.RAD1SPREMEVEZARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEvent((RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RAD1SPREMEVEZARowDeleting != null)
                {
                    RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEventHandler handler = this.RAD1SPREMEVEZARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEvent((RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRAD1SPREMEVEZARow(RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow row)
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

            public DataColumn IDSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnIDSTRUCNASPREMA;
                }
            }

            public RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow this[int index]
            {
                get
                {
                    return (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) this.Rows[index];
                }
            }

            public DataColumn RAD1IDSPREMEColumn
            {
                get
                {
                    return this.columnRAD1IDSPREME;
                }
            }
        }

        public class RAD1SPREMEVEZARow : DataRow
        {
            private RAD1SPREMEVEZADataSet.RAD1SPREMEVEZADataTable tableRAD1SPREMEVEZA;

            internal RAD1SPREMEVEZARow(DataRowBuilder rb) : base(rb)
            {
                this.tableRAD1SPREMEVEZA = (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZADataTable) this.Table;
            }

            public bool IsIDSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableRAD1SPREMEVEZA.IDSTRUCNASPREMAColumn);
            }

            public bool IsRAD1IDSPREMENull()
            {
                return this.IsNull(this.tableRAD1SPREMEVEZA.RAD1IDSPREMEColumn);
            }

            public int IDSTRUCNASPREMA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1SPREMEVEZA.IDSTRUCNASPREMAColumn]);
                }
                set
                {
                    this[this.tableRAD1SPREMEVEZA.IDSTRUCNASPREMAColumn] = value;
                }
            }

            public int RAD1IDSPREME
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRAD1SPREMEVEZA.RAD1IDSPREMEColumn]);
                }
                set
                {
                    this[this.tableRAD1SPREMEVEZA.RAD1IDSPREMEColumn] = value;
                }
            }
        }

        public class RAD1SPREMEVEZARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow eventRow;

            public RAD1SPREMEVEZARowChangeEvent(RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow row, DataRowAction action)
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

            public RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RAD1SPREMEVEZARowChangeEventHandler(object sender, RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARowChangeEvent e);
    }
}

