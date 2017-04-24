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
    public class SPOLDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SPOLDataTable tableSPOL;

        public SPOLDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SPOLDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SPOL"] != null)
                    {
                        this.Tables.Add(new SPOLDataTable(dataSet.Tables["SPOL"]));
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
            SPOLDataSet set = (SPOLDataSet) base.Clone();
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
            SPOLDataSet set = new SPOLDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SPOLDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2012");
            this.ExtendedProperties.Add("DataSetName", "SPOLDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISPOLDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SPOL");
            this.ExtendedProperties.Add("ObjectDescription", "Spol");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVSPOL");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "SPOLDataSet";
            this.Namespace = "http://www.tempuri.org/SPOL";
            this.tableSPOL = new SPOLDataTable();
            this.Tables.Add(this.tableSPOL);
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
            this.tableSPOL = (SPOLDataTable) this.Tables["SPOL"];
            if (initTable && (this.tableSPOL != null))
            {
                this.tableSPOL.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["SPOL"] != null)
                {
                    this.Tables.Add(new SPOLDataTable(dataSet.Tables["SPOL"]));
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

        private bool ShouldSerializeSPOL()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SPOLDataTable SPOL
        {
            get
            {
                return this.tableSPOL;
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
        public class SPOLDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSPOL;
            private DataColumn columnNAZIVSPOL;

            public event SPOLDataSet.SPOLRowChangeEventHandler SPOLRowChanged;

            public event SPOLDataSet.SPOLRowChangeEventHandler SPOLRowChanging;

            public event SPOLDataSet.SPOLRowChangeEventHandler SPOLRowDeleted;

            public event SPOLDataSet.SPOLRowChangeEventHandler SPOLRowDeleting;

            public SPOLDataTable()
            {
                this.TableName = "SPOL";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SPOLDataTable(DataTable table) : base(table.TableName)
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

            protected SPOLDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSPOLRow(SPOLDataSet.SPOLRow row)
            {
                this.Rows.Add(row);
            }

            public SPOLDataSet.SPOLRow AddSPOLRow(int iDSPOL, string nAZIVSPOL)
            {
                SPOLDataSet.SPOLRow row = (SPOLDataSet.SPOLRow) this.NewRow();
                row["IDSPOL"] = iDSPOL;
                row["NAZIVSPOL"] = nAZIVSPOL;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SPOLDataSet.SPOLDataTable table = (SPOLDataSet.SPOLDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SPOLDataSet.SPOLRow FindByIDSPOL(int iDSPOL)
            {
                return (SPOLDataSet.SPOLRow) this.Rows.Find(new object[] { iDSPOL });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SPOLDataSet.SPOLRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SPOLDataSet set = new SPOLDataSet();
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
                this.columnIDSPOL = new DataColumn("IDSPOL", typeof(int), "", MappingType.Element);
                this.columnIDSPOL.AllowDBNull = false;
                this.columnIDSPOL.Caption = "IDSPOL";
                this.columnIDSPOL.Unique = true;
                this.columnIDSPOL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSPOL.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSPOL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSPOL.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSPOL.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSPOL.ExtendedProperties.Add("Length", "5");
                this.columnIDSPOL.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSPOL.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSPOL.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSPOL.ExtendedProperties.Add("Deklarit.InternalName", "IDSPOL");
                this.Columns.Add(this.columnIDSPOL);
                this.columnNAZIVSPOL = new DataColumn("NAZIVSPOL", typeof(string), "", MappingType.Element);
                this.columnNAZIVSPOL.AllowDBNull = false;
                this.columnNAZIVSPOL.Caption = "NAZIVSPOL";
                this.columnNAZIVSPOL.MaxLength = 20;
                this.columnNAZIVSPOL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSPOL.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Description", "Spol");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSPOL.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSPOL.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSPOL");
                this.Columns.Add(this.columnNAZIVSPOL);
                this.PrimaryKey = new DataColumn[] { this.columnIDSPOL };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SPOL");
                this.ExtendedProperties.Add("Description", "Spol");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSPOL = this.Columns["IDSPOL"];
                this.columnNAZIVSPOL = this.Columns["NAZIVSPOL"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SPOLDataSet.SPOLRow(builder);
            }

            public SPOLDataSet.SPOLRow NewSPOLRow()
            {
                return (SPOLDataSet.SPOLRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SPOLRowChanged != null)
                {
                    SPOLDataSet.SPOLRowChangeEventHandler sPOLRowChangedEvent = this.SPOLRowChanged;
                    if (sPOLRowChangedEvent != null)
                    {
                        sPOLRowChangedEvent(this, new SPOLDataSet.SPOLRowChangeEvent((SPOLDataSet.SPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SPOLRowChanging != null)
                {
                    SPOLDataSet.SPOLRowChangeEventHandler sPOLRowChangingEvent = this.SPOLRowChanging;
                    if (sPOLRowChangingEvent != null)
                    {
                        sPOLRowChangingEvent(this, new SPOLDataSet.SPOLRowChangeEvent((SPOLDataSet.SPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SPOLRowDeleted != null)
                {
                    SPOLDataSet.SPOLRowChangeEventHandler sPOLRowDeletedEvent = this.SPOLRowDeleted;
                    if (sPOLRowDeletedEvent != null)
                    {
                        sPOLRowDeletedEvent(this, new SPOLDataSet.SPOLRowChangeEvent((SPOLDataSet.SPOLRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SPOLRowDeleting != null)
                {
                    SPOLDataSet.SPOLRowChangeEventHandler sPOLRowDeletingEvent = this.SPOLRowDeleting;
                    if (sPOLRowDeletingEvent != null)
                    {
                        sPOLRowDeletingEvent(this, new SPOLDataSet.SPOLRowChangeEvent((SPOLDataSet.SPOLRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSPOLRow(SPOLDataSet.SPOLRow row)
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

            public SPOLDataSet.SPOLRow this[int index]
            {
                get
                {
                    return (SPOLDataSet.SPOLRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSPOLColumn
            {
                get
                {
                    return this.columnNAZIVSPOL;
                }
            }
        }

        public class SPOLRow : DataRow
        {
            private SPOLDataSet.SPOLDataTable tableSPOL;

            internal SPOLRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSPOL = (SPOLDataSet.SPOLDataTable) this.Table;
            }

            public bool IsIDSPOLNull()
            {
                return this.IsNull(this.tableSPOL.IDSPOLColumn);
            }

            public bool IsNAZIVSPOLNull()
            {
                return this.IsNull(this.tableSPOL.NAZIVSPOLColumn);
            }

            public void SetNAZIVSPOLNull()
            {
                this[this.tableSPOL.NAZIVSPOLColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSPOL
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSPOL.IDSPOLColumn]);
                }
                set
                {
                    this[this.tableSPOL.IDSPOLColumn] = value;
                }
            }

            public string NAZIVSPOL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSPOL.NAZIVSPOLColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSPOL because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSPOL.NAZIVSPOLColumn] = value;
                }
            }
        }

        public class SPOLRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SPOLDataSet.SPOLRow eventRow;

            public SPOLRowChangeEvent(SPOLDataSet.SPOLRow row, DataRowAction action)
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

            public SPOLDataSet.SPOLRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SPOLRowChangeEventHandler(object sender, SPOLDataSet.SPOLRowChangeEvent e);
    }
}

