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
    public class RADNOMJESTODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RADNOMJESTODataTable tableRADNOMJESTO;

        public RADNOMJESTODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RADNOMJESTODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RADNOMJESTO"] != null)
                    {
                        this.Tables.Add(new RADNOMJESTODataTable(dataSet.Tables["RADNOMJESTO"]));
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
            RADNOMJESTODataSet set = (RADNOMJESTODataSet) base.Clone();
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
            RADNOMJESTODataSet set = new RADNOMJESTODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RADNOMJESTODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1018");
            this.ExtendedProperties.Add("DataSetName", "RADNOMJESTODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRADNOMJESTODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RADNOMJESTO");
            this.ExtendedProperties.Add("ObjectDescription", "Radna mjesta");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVRADNOMJESTO");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "RADNOMJESTODataSet";
            this.Namespace = "http://www.tempuri.org/RADNOMJESTO";
            this.tableRADNOMJESTO = new RADNOMJESTODataTable();
            this.Tables.Add(this.tableRADNOMJESTO);
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
            this.tableRADNOMJESTO = (RADNOMJESTODataTable) this.Tables["RADNOMJESTO"];
            if (initTable && (this.tableRADNOMJESTO != null))
            {
                this.tableRADNOMJESTO.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RADNOMJESTO"] != null)
                {
                    this.Tables.Add(new RADNOMJESTODataTable(dataSet.Tables["RADNOMJESTO"]));
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

        private bool ShouldSerializeRADNOMJESTO()
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
        public RADNOMJESTODataTable RADNOMJESTO
        {
            get
            {
                return this.tableRADNOMJESTO;
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
        public class RADNOMJESTODataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNOMJESTO;
            private DataColumn columnNAZIVRADNOMJESTO;

            public event RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler RADNOMJESTORowChanged;

            public event RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler RADNOMJESTORowChanging;

            public event RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler RADNOMJESTORowDeleted;

            public event RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler RADNOMJESTORowDeleting;

            public RADNOMJESTODataTable()
            {
                this.TableName = "RADNOMJESTO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNOMJESTODataTable(DataTable table) : base(table.TableName)
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

            protected RADNOMJESTODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNOMJESTORow(RADNOMJESTODataSet.RADNOMJESTORow row)
            {
                this.Rows.Add(row);
            }

            public RADNOMJESTODataSet.RADNOMJESTORow AddRADNOMJESTORow(int iDRADNOMJESTO, string nAZIVRADNOMJESTO)
            {
                RADNOMJESTODataSet.RADNOMJESTORow row = (RADNOMJESTODataSet.RADNOMJESTORow) this.NewRow();
                row["IDRADNOMJESTO"] = iDRADNOMJESTO;
                row["NAZIVRADNOMJESTO"] = nAZIVRADNOMJESTO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNOMJESTODataSet.RADNOMJESTODataTable table = (RADNOMJESTODataSet.RADNOMJESTODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNOMJESTODataSet.RADNOMJESTORow FindByIDRADNOMJESTO(int iDRADNOMJESTO)
            {
                return (RADNOMJESTODataSet.RADNOMJESTORow) this.Rows.Find(new object[] { iDRADNOMJESTO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNOMJESTODataSet.RADNOMJESTORow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNOMJESTODataSet set = new RADNOMJESTODataSet();
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
                this.columnIDRADNOMJESTO = new DataColumn("IDRADNOMJESTO", typeof(int), "", MappingType.Element);
                this.columnIDRADNOMJESTO.AllowDBNull = false;
                this.columnIDRADNOMJESTO.Caption = "Šifra radnog mjesta";
                this.columnIDRADNOMJESTO.Unique = true;
                this.columnIDRADNOMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Description", "Šifra radnog mjesta");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Length", "5");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNOMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNOMJESTO");
                this.Columns.Add(this.columnIDRADNOMJESTO);
                this.columnNAZIVRADNOMJESTO = new DataColumn("NAZIVRADNOMJESTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVRADNOMJESTO.AllowDBNull = false;
                this.columnNAZIVRADNOMJESTO.Caption = "Naziv radnog mjesta";
                this.columnNAZIVRADNOMJESTO.MaxLength = 50;
                this.columnNAZIVRADNOMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Description", "Naziv radnog mjesta");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRADNOMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRADNOMJESTO");
                this.Columns.Add(this.columnNAZIVRADNOMJESTO);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNOMJESTO };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RADNOMJESTO");
                this.ExtendedProperties.Add("Description", "Radna mjesta");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRADNOMJESTO = this.Columns["IDRADNOMJESTO"];
                this.columnNAZIVRADNOMJESTO = this.Columns["NAZIVRADNOMJESTO"];
            }

            public RADNOMJESTODataSet.RADNOMJESTORow NewRADNOMJESTORow()
            {
                return (RADNOMJESTODataSet.RADNOMJESTORow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNOMJESTODataSet.RADNOMJESTORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNOMJESTORowChanged != null)
                {
                    RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler rADNOMJESTORowChangedEvent = this.RADNOMJESTORowChanged;
                    if (rADNOMJESTORowChangedEvent != null)
                    {
                        rADNOMJESTORowChangedEvent(this, new RADNOMJESTODataSet.RADNOMJESTORowChangeEvent((RADNOMJESTODataSet.RADNOMJESTORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNOMJESTORowChanging != null)
                {
                    RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler rADNOMJESTORowChangingEvent = this.RADNOMJESTORowChanging;
                    if (rADNOMJESTORowChangingEvent != null)
                    {
                        rADNOMJESTORowChangingEvent(this, new RADNOMJESTODataSet.RADNOMJESTORowChangeEvent((RADNOMJESTODataSet.RADNOMJESTORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RADNOMJESTORowDeleted != null)
                {
                    RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler rADNOMJESTORowDeletedEvent = this.RADNOMJESTORowDeleted;
                    if (rADNOMJESTORowDeletedEvent != null)
                    {
                        rADNOMJESTORowDeletedEvent(this, new RADNOMJESTODataSet.RADNOMJESTORowChangeEvent((RADNOMJESTODataSet.RADNOMJESTORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNOMJESTORowDeleting != null)
                {
                    RADNOMJESTODataSet.RADNOMJESTORowChangeEventHandler rADNOMJESTORowDeletingEvent = this.RADNOMJESTORowDeleting;
                    if (rADNOMJESTORowDeletingEvent != null)
                    {
                        rADNOMJESTORowDeletingEvent(this, new RADNOMJESTODataSet.RADNOMJESTORowChangeEvent((RADNOMJESTODataSet.RADNOMJESTORow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNOMJESTORow(RADNOMJESTODataSet.RADNOMJESTORow row)
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

            public DataColumn IDRADNOMJESTOColumn
            {
                get
                {
                    return this.columnIDRADNOMJESTO;
                }
            }

            public RADNOMJESTODataSet.RADNOMJESTORow this[int index]
            {
                get
                {
                    return (RADNOMJESTODataSet.RADNOMJESTORow) this.Rows[index];
                }
            }

            public DataColumn NAZIVRADNOMJESTOColumn
            {
                get
                {
                    return this.columnNAZIVRADNOMJESTO;
                }
            }
        }

        public class RADNOMJESTORow : DataRow
        {
            private RADNOMJESTODataSet.RADNOMJESTODataTable tableRADNOMJESTO;

            internal RADNOMJESTORow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNOMJESTO = (RADNOMJESTODataSet.RADNOMJESTODataTable) this.Table;
            }

            public bool IsIDRADNOMJESTONull()
            {
                return this.IsNull(this.tableRADNOMJESTO.IDRADNOMJESTOColumn);
            }

            public bool IsNAZIVRADNOMJESTONull()
            {
                return this.IsNull(this.tableRADNOMJESTO.NAZIVRADNOMJESTOColumn);
            }

            public void SetNAZIVRADNOMJESTONull()
            {
                this[this.tableRADNOMJESTO.NAZIVRADNOMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNOMJESTO
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNOMJESTO.IDRADNOMJESTOColumn]);
                }
                set
                {
                    this[this.tableRADNOMJESTO.IDRADNOMJESTOColumn] = value;
                }
            }

            public string NAZIVRADNOMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNOMJESTO.NAZIVRADNOMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVRADNOMJESTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNOMJESTO.NAZIVRADNOMJESTOColumn] = value;
                }
            }
        }

        public class RADNOMJESTORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNOMJESTODataSet.RADNOMJESTORow eventRow;

            public RADNOMJESTORowChangeEvent(RADNOMJESTODataSet.RADNOMJESTORow row, DataRowAction action)
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

            public RADNOMJESTODataSet.RADNOMJESTORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNOMJESTORowChangeEventHandler(object sender, RADNOMJESTODataSet.RADNOMJESTORowChangeEvent e);
    }
}

