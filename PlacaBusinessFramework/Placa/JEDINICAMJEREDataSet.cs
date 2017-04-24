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
    public class JEDINICAMJEREDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private JEDINICAMJEREDataTable tableJEDINICAMJERE;

        public JEDINICAMJEREDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected JEDINICAMJEREDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["JEDINICAMJERE"] != null)
                    {
                        this.Tables.Add(new JEDINICAMJEREDataTable(dataSet.Tables["JEDINICAMJERE"]));
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
            JEDINICAMJEREDataSet set = (JEDINICAMJEREDataSet) base.Clone();
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
            JEDINICAMJEREDataSet set = new JEDINICAMJEREDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "JEDINICAMJEREDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2007");
            this.ExtendedProperties.Add("DataSetName", "JEDINICAMJEREDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IJEDINICAMJEREDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "JEDINICAMJERE");
            this.ExtendedProperties.Add("ObjectDescription", "JEDINICAMJERE");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVJEDINICAMJERE");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "JEDINICAMJEREDataSet";
            this.Namespace = "http://www.tempuri.org/JEDINICAMJERE";
            this.tableJEDINICAMJERE = new JEDINICAMJEREDataTable();
            this.Tables.Add(this.tableJEDINICAMJERE);
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
            this.tableJEDINICAMJERE = (JEDINICAMJEREDataTable) this.Tables["JEDINICAMJERE"];
            if (initTable && (this.tableJEDINICAMJERE != null))
            {
                this.tableJEDINICAMJERE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["JEDINICAMJERE"] != null)
                {
                    this.Tables.Add(new JEDINICAMJEREDataTable(dataSet.Tables["JEDINICAMJERE"]));
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

        private bool ShouldSerializeJEDINICAMJERE()
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
        public JEDINICAMJEREDataTable JEDINICAMJERE
        {
            get
            {
                return this.tableJEDINICAMJERE;
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
        public class JEDINICAMJEREDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDJEDINICAMJERE;
            private DataColumn columnNAZIVJEDINICAMJERE;

            public event JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler JEDINICAMJERERowChanged;

            public event JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler JEDINICAMJERERowChanging;

            public event JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler JEDINICAMJERERowDeleted;

            public event JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler JEDINICAMJERERowDeleting;

            public JEDINICAMJEREDataTable()
            {
                this.TableName = "JEDINICAMJERE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal JEDINICAMJEREDataTable(DataTable table) : base(table.TableName)
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

            protected JEDINICAMJEREDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddJEDINICAMJERERow(JEDINICAMJEREDataSet.JEDINICAMJERERow row)
            {
                this.Rows.Add(row);
            }

            public JEDINICAMJEREDataSet.JEDINICAMJERERow AddJEDINICAMJERERow(int iDJEDINICAMJERE, string nAZIVJEDINICAMJERE)
            {
                JEDINICAMJEREDataSet.JEDINICAMJERERow row = (JEDINICAMJEREDataSet.JEDINICAMJERERow) this.NewRow();
                row["IDJEDINICAMJERE"] = iDJEDINICAMJERE;
                row["NAZIVJEDINICAMJERE"] = nAZIVJEDINICAMJERE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                JEDINICAMJEREDataSet.JEDINICAMJEREDataTable table = (JEDINICAMJEREDataSet.JEDINICAMJEREDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public JEDINICAMJEREDataSet.JEDINICAMJERERow FindByIDJEDINICAMJERE(int iDJEDINICAMJERE)
            {
                return (JEDINICAMJEREDataSet.JEDINICAMJERERow) this.Rows.Find(new object[] { iDJEDINICAMJERE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(JEDINICAMJEREDataSet.JEDINICAMJERERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                JEDINICAMJEREDataSet set = new JEDINICAMJEREDataSet();
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
                this.columnIDJEDINICAMJERE = new DataColumn("IDJEDINICAMJERE", typeof(int), "", MappingType.Element);
                this.columnIDJEDINICAMJERE.AllowDBNull = false;
                this.columnIDJEDINICAMJERE.Caption = "IDJEDINICAMJERE";
                this.columnIDJEDINICAMJERE.Unique = true;
                this.columnIDJEDINICAMJERE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Description", "Šifra JM");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Length", "5");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDJEDINICAMJERE.ExtendedProperties.Add("Deklarit.InternalName", "IDJEDINICAMJERE");
                this.Columns.Add(this.columnIDJEDINICAMJERE);
                this.columnNAZIVJEDINICAMJERE = new DataColumn("NAZIVJEDINICAMJERE", typeof(string), "", MappingType.Element);
                this.columnNAZIVJEDINICAMJERE.AllowDBNull = false;
                this.columnNAZIVJEDINICAMJERE.Caption = "NAZIVJEDINICAMJERE";
                this.columnNAZIVJEDINICAMJERE.MaxLength = 50;
                this.columnNAZIVJEDINICAMJERE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Description", "Jed mjere");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVJEDINICAMJERE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVJEDINICAMJERE");
                this.Columns.Add(this.columnNAZIVJEDINICAMJERE);
                this.PrimaryKey = new DataColumn[] { this.columnIDJEDINICAMJERE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "JEDINICAMJERE");
                this.ExtendedProperties.Add("Description", "JEDINICAMJERE");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDJEDINICAMJERE = this.Columns["IDJEDINICAMJERE"];
                this.columnNAZIVJEDINICAMJERE = this.Columns["NAZIVJEDINICAMJERE"];
            }

            public JEDINICAMJEREDataSet.JEDINICAMJERERow NewJEDINICAMJERERow()
            {
                return (JEDINICAMJEREDataSet.JEDINICAMJERERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new JEDINICAMJEREDataSet.JEDINICAMJERERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.JEDINICAMJERERowChanged != null)
                {
                    JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler jEDINICAMJERERowChangedEvent = this.JEDINICAMJERERowChanged;
                    if (jEDINICAMJERERowChangedEvent != null)
                    {
                        jEDINICAMJERERowChangedEvent(this, new JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEvent((JEDINICAMJEREDataSet.JEDINICAMJERERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.JEDINICAMJERERowChanging != null)
                {
                    JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler jEDINICAMJERERowChangingEvent = this.JEDINICAMJERERowChanging;
                    if (jEDINICAMJERERowChangingEvent != null)
                    {
                        jEDINICAMJERERowChangingEvent(this, new JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEvent((JEDINICAMJEREDataSet.JEDINICAMJERERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.JEDINICAMJERERowDeleted != null)
                {
                    JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler jEDINICAMJERERowDeletedEvent = this.JEDINICAMJERERowDeleted;
                    if (jEDINICAMJERERowDeletedEvent != null)
                    {
                        jEDINICAMJERERowDeletedEvent(this, new JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEvent((JEDINICAMJEREDataSet.JEDINICAMJERERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.JEDINICAMJERERowDeleting != null)
                {
                    JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEventHandler jEDINICAMJERERowDeletingEvent = this.JEDINICAMJERERowDeleting;
                    if (jEDINICAMJERERowDeletingEvent != null)
                    {
                        jEDINICAMJERERowDeletingEvent(this, new JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEvent((JEDINICAMJEREDataSet.JEDINICAMJERERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveJEDINICAMJERERow(JEDINICAMJEREDataSet.JEDINICAMJERERow row)
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

            public DataColumn IDJEDINICAMJEREColumn
            {
                get
                {
                    return this.columnIDJEDINICAMJERE;
                }
            }

            public JEDINICAMJEREDataSet.JEDINICAMJERERow this[int index]
            {
                get
                {
                    return (JEDINICAMJEREDataSet.JEDINICAMJERERow) this.Rows[index];
                }
            }

            public DataColumn NAZIVJEDINICAMJEREColumn
            {
                get
                {
                    return this.columnNAZIVJEDINICAMJERE;
                }
            }
        }

        public class JEDINICAMJERERow : DataRow
        {
            private JEDINICAMJEREDataSet.JEDINICAMJEREDataTable tableJEDINICAMJERE;

            internal JEDINICAMJERERow(DataRowBuilder rb) : base(rb)
            {
                this.tableJEDINICAMJERE = (JEDINICAMJEREDataSet.JEDINICAMJEREDataTable) this.Table;
            }

            public bool IsIDJEDINICAMJERENull()
            {
                return this.IsNull(this.tableJEDINICAMJERE.IDJEDINICAMJEREColumn);
            }

            public bool IsNAZIVJEDINICAMJERENull()
            {
                return this.IsNull(this.tableJEDINICAMJERE.NAZIVJEDINICAMJEREColumn);
            }

            public void SetNAZIVJEDINICAMJERENull()
            {
                this[this.tableJEDINICAMJERE.NAZIVJEDINICAMJEREColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDJEDINICAMJERE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableJEDINICAMJERE.IDJEDINICAMJEREColumn]);
                }
                set
                {
                    this[this.tableJEDINICAMJERE.IDJEDINICAMJEREColumn] = value;
                }
            }

            public string NAZIVJEDINICAMJERE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableJEDINICAMJERE.NAZIVJEDINICAMJEREColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVJEDINICAMJERE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableJEDINICAMJERE.NAZIVJEDINICAMJEREColumn] = value;
                }
            }
        }

        public class JEDINICAMJERERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private JEDINICAMJEREDataSet.JEDINICAMJERERow eventRow;

            public JEDINICAMJERERowChangeEvent(JEDINICAMJEREDataSet.JEDINICAMJERERow row, DataRowAction action)
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

            public JEDINICAMJEREDataSet.JEDINICAMJERERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void JEDINICAMJERERowChangeEventHandler(object sender, JEDINICAMJEREDataSet.JEDINICAMJERERowChangeEvent e);
    }
}

