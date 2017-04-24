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
    public class BENEFICIRANIDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private BENEFICIRANIDataTable tableBENEFICIRANI;

        public BENEFICIRANIDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected BENEFICIRANIDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["BENEFICIRANI"] != null)
                    {
                        this.Tables.Add(new BENEFICIRANIDataTable(dataSet.Tables["BENEFICIRANI"]));
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
            BENEFICIRANIDataSet set = (BENEFICIRANIDataSet) base.Clone();
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
            BENEFICIRANIDataSet set = new BENEFICIRANIDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "BENEFICIRANIDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1003");
            this.ExtendedProperties.Add("DataSetName", "BENEFICIRANIDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IBENEFICIRANIDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "BENEFICIRANI");
            this.ExtendedProperties.Add("ObjectDescription", "Beneficirani radni staž");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVBENEFICIRANI");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "BENEFICIRANIDataSet";
            this.Namespace = "http://www.tempuri.org/BENEFICIRANI";
            this.tableBENEFICIRANI = new BENEFICIRANIDataTable();
            this.Tables.Add(this.tableBENEFICIRANI);
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
            this.tableBENEFICIRANI = (BENEFICIRANIDataTable) this.Tables["BENEFICIRANI"];
            if (initTable && (this.tableBENEFICIRANI != null))
            {
                this.tableBENEFICIRANI.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["BENEFICIRANI"] != null)
                {
                    this.Tables.Add(new BENEFICIRANIDataTable(dataSet.Tables["BENEFICIRANI"]));
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

        private bool ShouldSerializeBENEFICIRANI()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BENEFICIRANIDataTable BENEFICIRANI
        {
            get
            {
                return this.tableBENEFICIRANI;
            }
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable]
        public class BENEFICIRANIDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJPRIZNATIHMJESECI;
            private DataColumn columnIDBENEFICIRANI;
            private DataColumn columnNAZIVBENEFICIRANI;

            public event BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler BENEFICIRANIRowChanged;

            public event BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler BENEFICIRANIRowChanging;

            public event BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler BENEFICIRANIRowDeleted;

            public event BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler BENEFICIRANIRowDeleting;

            public BENEFICIRANIDataTable()
            {
                this.TableName = "BENEFICIRANI";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BENEFICIRANIDataTable(DataTable table) : base(table.TableName)
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

            protected BENEFICIRANIDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBENEFICIRANIRow(BENEFICIRANIDataSet.BENEFICIRANIRow row)
            {
                this.Rows.Add(row);
            }

            public BENEFICIRANIDataSet.BENEFICIRANIRow AddBENEFICIRANIRow(string iDBENEFICIRANI, string nAZIVBENEFICIRANI, short bROJPRIZNATIHMJESECI)
            {
                BENEFICIRANIDataSet.BENEFICIRANIRow row = (BENEFICIRANIDataSet.BENEFICIRANIRow) this.NewRow();
                row["IDBENEFICIRANI"] = iDBENEFICIRANI;
                row["NAZIVBENEFICIRANI"] = nAZIVBENEFICIRANI;
                row["BROJPRIZNATIHMJESECI"] = bROJPRIZNATIHMJESECI;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BENEFICIRANIDataSet.BENEFICIRANIDataTable table = (BENEFICIRANIDataSet.BENEFICIRANIDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BENEFICIRANIDataSet.BENEFICIRANIRow FindByIDBENEFICIRANI(string iDBENEFICIRANI)
            {
                return (BENEFICIRANIDataSet.BENEFICIRANIRow) this.Rows.Find(new object[] { iDBENEFICIRANI });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BENEFICIRANIDataSet.BENEFICIRANIRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BENEFICIRANIDataSet set = new BENEFICIRANIDataSet();
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
                this.columnIDBENEFICIRANI = new DataColumn("IDBENEFICIRANI", typeof(string), "", MappingType.Element);
                this.columnIDBENEFICIRANI.AllowDBNull = false;
                this.columnIDBENEFICIRANI.Caption = "Šifra beneficiranog radnog staža";
                this.columnIDBENEFICIRANI.MaxLength = 1;
                this.columnIDBENEFICIRANI.Unique = true;
                this.columnIDBENEFICIRANI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("IsKey", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Description", "Šifra beneficiranog radnog staža");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Length", "1");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBENEFICIRANI.ExtendedProperties.Add("Deklarit.InternalName", "IDBENEFICIRANI");
                this.Columns.Add(this.columnIDBENEFICIRANI);
                this.columnNAZIVBENEFICIRANI = new DataColumn("NAZIVBENEFICIRANI", typeof(string), "", MappingType.Element);
                this.columnNAZIVBENEFICIRANI.AllowDBNull = false;
                this.columnNAZIVBENEFICIRANI.Caption = "Naziv beneficiranog radnog staža";
                this.columnNAZIVBENEFICIRANI.MaxLength = 50;
                this.columnNAZIVBENEFICIRANI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Description", "Naziv beneficiranog radnog staža");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBENEFICIRANI.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBENEFICIRANI");
                this.Columns.Add(this.columnNAZIVBENEFICIRANI);
                this.columnBROJPRIZNATIHMJESECI = new DataColumn("BROJPRIZNATIHMJESECI", typeof(short), "", MappingType.Element);
                this.columnBROJPRIZNATIHMJESECI.AllowDBNull = false;
                this.columnBROJPRIZNATIHMJESECI.Caption = "Broj priznatih mjeseci za 12 mjeseci rada";
                this.columnBROJPRIZNATIHMJESECI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("ReadOnly", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Description", "Broj priznatih mjeseci za 12 mjeseci rada");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Length", "2");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJPRIZNATIHMJESECI.ExtendedProperties.Add("Deklarit.InternalName", "BROJPRIZNATIHMJESECI");
                this.Columns.Add(this.columnBROJPRIZNATIHMJESECI);
                this.PrimaryKey = new DataColumn[] { this.columnIDBENEFICIRANI };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "BENEFICIRANI");
                this.ExtendedProperties.Add("Description", "Beneficirani radni staž");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDBENEFICIRANI = this.Columns["IDBENEFICIRANI"];
                this.columnNAZIVBENEFICIRANI = this.Columns["NAZIVBENEFICIRANI"];
                this.columnBROJPRIZNATIHMJESECI = this.Columns["BROJPRIZNATIHMJESECI"];
            }

            public BENEFICIRANIDataSet.BENEFICIRANIRow NewBENEFICIRANIRow()
            {
                return (BENEFICIRANIDataSet.BENEFICIRANIRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BENEFICIRANIDataSet.BENEFICIRANIRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BENEFICIRANIRowChanged != null)
                {
                    BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler bENEFICIRANIRowChangedEvent = this.BENEFICIRANIRowChanged;
                    if (bENEFICIRANIRowChangedEvent != null)
                    {
                        bENEFICIRANIRowChangedEvent(this, new BENEFICIRANIDataSet.BENEFICIRANIRowChangeEvent((BENEFICIRANIDataSet.BENEFICIRANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BENEFICIRANIRowChanging != null)
                {
                    BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler bENEFICIRANIRowChangingEvent = this.BENEFICIRANIRowChanging;
                    if (bENEFICIRANIRowChangingEvent != null)
                    {
                        bENEFICIRANIRowChangingEvent(this, new BENEFICIRANIDataSet.BENEFICIRANIRowChangeEvent((BENEFICIRANIDataSet.BENEFICIRANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.BENEFICIRANIRowDeleted != null)
                {
                    BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler bENEFICIRANIRowDeletedEvent = this.BENEFICIRANIRowDeleted;
                    if (bENEFICIRANIRowDeletedEvent != null)
                    {
                        bENEFICIRANIRowDeletedEvent(this, new BENEFICIRANIDataSet.BENEFICIRANIRowChangeEvent((BENEFICIRANIDataSet.BENEFICIRANIRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BENEFICIRANIRowDeleting != null)
                {
                    BENEFICIRANIDataSet.BENEFICIRANIRowChangeEventHandler bENEFICIRANIRowDeletingEvent = this.BENEFICIRANIRowDeleting;
                    if (bENEFICIRANIRowDeletingEvent != null)
                    {
                        bENEFICIRANIRowDeletingEvent(this, new BENEFICIRANIDataSet.BENEFICIRANIRowChangeEvent((BENEFICIRANIDataSet.BENEFICIRANIRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBENEFICIRANIRow(BENEFICIRANIDataSet.BENEFICIRANIRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJPRIZNATIHMJESECIColumn
            {
                get
                {
                    return this.columnBROJPRIZNATIHMJESECI;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn IDBENEFICIRANIColumn
            {
                get
                {
                    return this.columnIDBENEFICIRANI;
                }
            }

            public BENEFICIRANIDataSet.BENEFICIRANIRow this[int index]
            {
                get
                {
                    return (BENEFICIRANIDataSet.BENEFICIRANIRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVBENEFICIRANIColumn
            {
                get
                {
                    return this.columnNAZIVBENEFICIRANI;
                }
            }
        }

        public class BENEFICIRANIRow : DataRow
        {
            private BENEFICIRANIDataSet.BENEFICIRANIDataTable tableBENEFICIRANI;

            internal BENEFICIRANIRow(DataRowBuilder rb) : base(rb)
            {
                this.tableBENEFICIRANI = (BENEFICIRANIDataSet.BENEFICIRANIDataTable) this.Table;
            }

            public bool IsBROJPRIZNATIHMJESECINull()
            {
                return this.IsNull(this.tableBENEFICIRANI.BROJPRIZNATIHMJESECIColumn);
            }

            public bool IsIDBENEFICIRANINull()
            {
                return this.IsNull(this.tableBENEFICIRANI.IDBENEFICIRANIColumn);
            }

            public bool IsNAZIVBENEFICIRANINull()
            {
                return this.IsNull(this.tableBENEFICIRANI.NAZIVBENEFICIRANIColumn);
            }

            public void SetBROJPRIZNATIHMJESECINull()
            {
                this[this.tableBENEFICIRANI.BROJPRIZNATIHMJESECIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVBENEFICIRANINull()
            {
                this[this.tableBENEFICIRANI.NAZIVBENEFICIRANIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public short BROJPRIZNATIHMJESECI
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableBENEFICIRANI.BROJPRIZNATIHMJESECIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJPRIZNATIHMJESECI because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableBENEFICIRANI.BROJPRIZNATIHMJESECIColumn] = value;
                }
            }

            public string IDBENEFICIRANI
            {
                get
                {
                    return Conversions.ToString(this[this.tableBENEFICIRANI.IDBENEFICIRANIColumn]);
                }
                set
                {
                    this[this.tableBENEFICIRANI.IDBENEFICIRANIColumn] = value;
                }
            }

            public string NAZIVBENEFICIRANI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBENEFICIRANI.NAZIVBENEFICIRANIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVBENEFICIRANI because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBENEFICIRANI.NAZIVBENEFICIRANIColumn] = value;
                }
            }
        }

        public class BENEFICIRANIRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BENEFICIRANIDataSet.BENEFICIRANIRow eventRow;

            public BENEFICIRANIRowChangeEvent(BENEFICIRANIDataSet.BENEFICIRANIRow row, DataRowAction action)
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

            public BENEFICIRANIDataSet.BENEFICIRANIRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BENEFICIRANIRowChangeEventHandler(object sender, BENEFICIRANIDataSet.BENEFICIRANIRowChangeEvent e);
    }
}

