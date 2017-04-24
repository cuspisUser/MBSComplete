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
    public class RADNOVRIJEMEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private RADNOVRIJEMEDataTable tableRADNOVRIJEME;

        public RADNOVRIJEMEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected RADNOVRIJEMEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["RADNOVRIJEME"] != null)
                    {
                        this.Tables.Add(new RADNOVRIJEMEDataTable(dataSet.Tables["RADNOVRIJEME"]));
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
            RADNOVRIJEMEDataSet set = (RADNOVRIJEMEDataSet) base.Clone();
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
            RADNOVRIJEMEDataSet set = new RADNOVRIJEMEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "RADNOVRIJEMEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2175");
            this.ExtendedProperties.Add("DataSetName", "RADNOVRIJEMEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IRADNOVRIJEMEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "RADNOVRIJEME");
            this.ExtendedProperties.Add("ObjectDescription", "RADNOVRIJEME");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
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
            this.DataSetName = "RADNOVRIJEMEDataSet";
            this.Namespace = "http://www.tempuri.org/RADNOVRIJEME";
            this.tableRADNOVRIJEME = new RADNOVRIJEMEDataTable();
            this.Tables.Add(this.tableRADNOVRIJEME);
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
            this.tableRADNOVRIJEME = (RADNOVRIJEMEDataTable) this.Tables["RADNOVRIJEME"];
            if (initTable && (this.tableRADNOVRIJEME != null))
            {
                this.tableRADNOVRIJEME.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RADNOVRIJEME"] != null)
                {
                    this.Tables.Add(new RADNOVRIJEMEDataTable(dataSet.Tables["RADNOVRIJEME"]));
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

        private bool ShouldSerializeRADNOVRIJEME()
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
        public RADNOVRIJEMEDataTable RADNOVRIJEME
        {
            get
            {
                return this.tableRADNOVRIJEME;
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
        public class RADNOVRIJEMEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDRADNOVRIJEME;
            private DataColumn columnNAZIVRADNOVRIJEME;

            public event RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler RADNOVRIJEMERowChanged;

            public event RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler RADNOVRIJEMERowChanging;

            public event RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler RADNOVRIJEMERowDeleted;

            public event RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler RADNOVRIJEMERowDeleting;

            public RADNOVRIJEMEDataTable()
            {
                this.TableName = "RADNOVRIJEME";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal RADNOVRIJEMEDataTable(DataTable table) : base(table.TableName)
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

            protected RADNOVRIJEMEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddRADNOVRIJEMERow(RADNOVRIJEMEDataSet.RADNOVRIJEMERow row)
            {
                this.Rows.Add(row);
            }

            public RADNOVRIJEMEDataSet.RADNOVRIJEMERow AddRADNOVRIJEMERow(int iDRADNOVRIJEME, string nAZIVRADNOVRIJEME)
            {
                RADNOVRIJEMEDataSet.RADNOVRIJEMERow row = (RADNOVRIJEMEDataSet.RADNOVRIJEMERow) this.NewRow();
                row["IDRADNOVRIJEME"] = iDRADNOVRIJEME;
                row["NAZIVRADNOVRIJEME"] = nAZIVRADNOVRIJEME;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                RADNOVRIJEMEDataSet.RADNOVRIJEMEDataTable table = (RADNOVRIJEMEDataSet.RADNOVRIJEMEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public RADNOVRIJEMEDataSet.RADNOVRIJEMERow FindByIDRADNOVRIJEME(int iDRADNOVRIJEME)
            {
                return (RADNOVRIJEMEDataSet.RADNOVRIJEMERow) this.Rows.Find(new object[] { iDRADNOVRIJEME });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(RADNOVRIJEMEDataSet.RADNOVRIJEMERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                RADNOVRIJEMEDataSet set = new RADNOVRIJEMEDataSet();
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
                this.columnIDRADNOVRIJEME = new DataColumn("IDRADNOVRIJEME", typeof(int), "", MappingType.Element);
                this.columnIDRADNOVRIJEME.AllowDBNull = false;
                this.columnIDRADNOVRIJEME.Caption = "IDRADNOVRIJEME";
                this.columnIDRADNOVRIJEME.Unique = true;
                this.columnIDRADNOVRIJEME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("IsKey", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Description", "IDRADNOVRIJEME");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Length", "5");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNOVRIJEME.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNOVRIJEME");
                this.Columns.Add(this.columnIDRADNOVRIJEME);
                this.columnNAZIVRADNOVRIJEME = new DataColumn("NAZIVRADNOVRIJEME", typeof(string), "", MappingType.Element);
                this.columnNAZIVRADNOVRIJEME.AllowDBNull = false;
                this.columnNAZIVRADNOVRIJEME.Caption = "NAZIVRADNOVRIJEME";
                this.columnNAZIVRADNOVRIJEME.MaxLength = 50;
                this.columnNAZIVRADNOVRIJEME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Description", "NAZIVRADNOVRIJEME");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVRADNOVRIJEME.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVRADNOVRIJEME");
                this.Columns.Add(this.columnNAZIVRADNOVRIJEME);
                this.PrimaryKey = new DataColumn[] { this.columnIDRADNOVRIJEME };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "RADNOVRIJEME");
                this.ExtendedProperties.Add("Description", "RADNOVRIJEME");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDRADNOVRIJEME = this.Columns["IDRADNOVRIJEME"];
                this.columnNAZIVRADNOVRIJEME = this.Columns["NAZIVRADNOVRIJEME"];
            }

            public RADNOVRIJEMEDataSet.RADNOVRIJEMERow NewRADNOVRIJEMERow()
            {
                return (RADNOVRIJEMEDataSet.RADNOVRIJEMERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RADNOVRIJEMEDataSet.RADNOVRIJEMERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RADNOVRIJEMERowChanged != null)
                {
                    RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler rADNOVRIJEMERowChangedEvent = this.RADNOVRIJEMERowChanged;
                    if (rADNOVRIJEMERowChangedEvent != null)
                    {
                        rADNOVRIJEMERowChangedEvent(this, new RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEvent((RADNOVRIJEMEDataSet.RADNOVRIJEMERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RADNOVRIJEMERowChanging != null)
                {
                    RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler rADNOVRIJEMERowChangingEvent = this.RADNOVRIJEMERowChanging;
                    if (rADNOVRIJEMERowChangingEvent != null)
                    {
                        rADNOVRIJEMERowChangingEvent(this, new RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEvent((RADNOVRIJEMEDataSet.RADNOVRIJEMERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RADNOVRIJEMERowDeleted != null)
                {
                    RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler rADNOVRIJEMERowDeletedEvent = this.RADNOVRIJEMERowDeleted;
                    if (rADNOVRIJEMERowDeletedEvent != null)
                    {
                        rADNOVRIJEMERowDeletedEvent(this, new RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEvent((RADNOVRIJEMEDataSet.RADNOVRIJEMERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RADNOVRIJEMERowDeleting != null)
                {
                    RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEventHandler rADNOVRIJEMERowDeletingEvent = this.RADNOVRIJEMERowDeleting;
                    if (rADNOVRIJEMERowDeletingEvent != null)
                    {
                        rADNOVRIJEMERowDeletingEvent(this, new RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEvent((RADNOVRIJEMEDataSet.RADNOVRIJEMERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveRADNOVRIJEMERow(RADNOVRIJEMEDataSet.RADNOVRIJEMERow row)
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

            public DataColumn IDRADNOVRIJEMEColumn
            {
                get
                {
                    return this.columnIDRADNOVRIJEME;
                }
            }

            public RADNOVRIJEMEDataSet.RADNOVRIJEMERow this[int index]
            {
                get
                {
                    return (RADNOVRIJEMEDataSet.RADNOVRIJEMERow) this.Rows[index];
                }
            }

            public DataColumn NAZIVRADNOVRIJEMEColumn
            {
                get
                {
                    return this.columnNAZIVRADNOVRIJEME;
                }
            }
        }

        public class RADNOVRIJEMERow : DataRow
        {
            private RADNOVRIJEMEDataSet.RADNOVRIJEMEDataTable tableRADNOVRIJEME;

            internal RADNOVRIJEMERow(DataRowBuilder rb) : base(rb)
            {
                this.tableRADNOVRIJEME = (RADNOVRIJEMEDataSet.RADNOVRIJEMEDataTable) this.Table;
            }

            public bool IsIDRADNOVRIJEMENull()
            {
                return this.IsNull(this.tableRADNOVRIJEME.IDRADNOVRIJEMEColumn);
            }

            public bool IsNAZIVRADNOVRIJEMENull()
            {
                return this.IsNull(this.tableRADNOVRIJEME.NAZIVRADNOVRIJEMEColumn);
            }

            public void SetNAZIVRADNOVRIJEMENull()
            {
                this[this.tableRADNOVRIJEME.NAZIVRADNOVRIJEMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDRADNOVRIJEME
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableRADNOVRIJEME.IDRADNOVRIJEMEColumn]);
                }
                set
                {
                    this[this.tableRADNOVRIJEME.IDRADNOVRIJEMEColumn] = value;
                }
            }

            public string NAZIVRADNOVRIJEME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableRADNOVRIJEME.NAZIVRADNOVRIJEMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVRADNOVRIJEME because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableRADNOVRIJEME.NAZIVRADNOVRIJEMEColumn] = value;
                }
            }
        }

        public class RADNOVRIJEMERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private RADNOVRIJEMEDataSet.RADNOVRIJEMERow eventRow;

            public RADNOVRIJEMERowChangeEvent(RADNOVRIJEMEDataSet.RADNOVRIJEMERow row, DataRowAction action)
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

            public RADNOVRIJEMEDataSet.RADNOVRIJEMERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void RADNOVRIJEMERowChangeEventHandler(object sender, RADNOVRIJEMEDataSet.RADNOVRIJEMERowChangeEvent e);
    }
}

