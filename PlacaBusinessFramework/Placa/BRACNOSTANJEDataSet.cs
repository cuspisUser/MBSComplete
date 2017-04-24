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
    public class BRACNOSTANJEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private BRACNOSTANJEDataTable tableBRACNOSTANJE;

        public BRACNOSTANJEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected BRACNOSTANJEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["BRACNOSTANJE"] != null)
                    {
                        this.Tables.Add(new BRACNOSTANJEDataTable(dataSet.Tables["BRACNOSTANJE"]));
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
            BRACNOSTANJEDataSet set = (BRACNOSTANJEDataSet) base.Clone();
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
            BRACNOSTANJEDataSet set = new BRACNOSTANJEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "BRACNOSTANJEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1003");
            this.ExtendedProperties.Add("DataSetName", "BRACNOSTANJEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IBRACNOSTANJEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "BRACNOSTANJE");
            this.ExtendedProperties.Add("ObjectDescription", "Braeno stanje");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVBRACNOSTANJE");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "BRACNOSTANJEDataSet";
            this.Namespace = "http://www.tempuri.org/BRACNOSTANJE";
            this.tableBRACNOSTANJE = new BRACNOSTANJEDataTable();
            this.Tables.Add(this.tableBRACNOSTANJE);
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
            this.tableBRACNOSTANJE = (BRACNOSTANJEDataTable) this.Tables["BRACNOSTANJE"];
            if (initTable && (this.tableBRACNOSTANJE != null))
            {
                this.tableBRACNOSTANJE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["BRACNOSTANJE"] != null)
                {
                    this.Tables.Add(new BRACNOSTANJEDataTable(dataSet.Tables["BRACNOSTANJE"]));
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

        private bool ShouldSerializeBRACNOSTANJE()
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
        public BRACNOSTANJEDataTable BRACNOSTANJE
        {
            get
            {
                return this.tableBRACNOSTANJE;
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
        public class BRACNOSTANJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDBRACNOSTANJE;
            private DataColumn columnNAZIVBRACNOSTANJE;

            public event BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler BRACNOSTANJERowChanged;

            public event BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler BRACNOSTANJERowChanging;

            public event BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler BRACNOSTANJERowDeleted;

            public event BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler BRACNOSTANJERowDeleting;

            public BRACNOSTANJEDataTable()
            {
                this.TableName = "BRACNOSTANJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal BRACNOSTANJEDataTable(DataTable table) : base(table.TableName)
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

            protected BRACNOSTANJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddBRACNOSTANJERow(BRACNOSTANJEDataSet.BRACNOSTANJERow row)
            {
                this.Rows.Add(row);
            }

            public BRACNOSTANJEDataSet.BRACNOSTANJERow AddBRACNOSTANJERow(int iDBRACNOSTANJE, string nAZIVBRACNOSTANJE)
            {
                BRACNOSTANJEDataSet.BRACNOSTANJERow row = (BRACNOSTANJEDataSet.BRACNOSTANJERow) this.NewRow();
                row["IDBRACNOSTANJE"] = iDBRACNOSTANJE;
                row["NAZIVBRACNOSTANJE"] = nAZIVBRACNOSTANJE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                BRACNOSTANJEDataSet.BRACNOSTANJEDataTable table = (BRACNOSTANJEDataSet.BRACNOSTANJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public BRACNOSTANJEDataSet.BRACNOSTANJERow FindByIDBRACNOSTANJE(int iDBRACNOSTANJE)
            {
                return (BRACNOSTANJEDataSet.BRACNOSTANJERow) this.Rows.Find(new object[] { iDBRACNOSTANJE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(BRACNOSTANJEDataSet.BRACNOSTANJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                BRACNOSTANJEDataSet set = new BRACNOSTANJEDataSet();
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
                this.columnIDBRACNOSTANJE = new DataColumn("IDBRACNOSTANJE", typeof(int), "", MappingType.Element);
                this.columnIDBRACNOSTANJE.AllowDBNull = false;
                this.columnIDBRACNOSTANJE.Caption = "Šifra bračnog stanja";
                this.columnIDBRACNOSTANJE.Unique = true;
                this.columnIDBRACNOSTANJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Description", "Šifra bračnog stanja");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Length", "5");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDBRACNOSTANJE.ExtendedProperties.Add("Deklarit.InternalName", "IDBRACNOSTANJE");
                this.Columns.Add(this.columnIDBRACNOSTANJE);
                this.columnNAZIVBRACNOSTANJE = new DataColumn("NAZIVBRACNOSTANJE", typeof(string), "", MappingType.Element);
                this.columnNAZIVBRACNOSTANJE.AllowDBNull = false;
                this.columnNAZIVBRACNOSTANJE.Caption = "Naziv bračnog stanja";
                this.columnNAZIVBRACNOSTANJE.MaxLength = 50;
                this.columnNAZIVBRACNOSTANJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Description", "Naziv bračnog stanja");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVBRACNOSTANJE.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVBRACNOSTANJE");
                this.Columns.Add(this.columnNAZIVBRACNOSTANJE);
                this.PrimaryKey = new DataColumn[] { this.columnIDBRACNOSTANJE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "BRACNOSTANJE");
                this.ExtendedProperties.Add("Description", "Braeno stanje");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDBRACNOSTANJE = this.Columns["IDBRACNOSTANJE"];
                this.columnNAZIVBRACNOSTANJE = this.Columns["NAZIVBRACNOSTANJE"];
            }

            public BRACNOSTANJEDataSet.BRACNOSTANJERow NewBRACNOSTANJERow()
            {
                return (BRACNOSTANJEDataSet.BRACNOSTANJERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new BRACNOSTANJEDataSet.BRACNOSTANJERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BRACNOSTANJERowChanged != null)
                {
                    BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler bRACNOSTANJERowChangedEvent = this.BRACNOSTANJERowChanged;
                    if (bRACNOSTANJERowChangedEvent != null)
                    {
                        bRACNOSTANJERowChangedEvent(this, new BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEvent((BRACNOSTANJEDataSet.BRACNOSTANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BRACNOSTANJERowChanging != null)
                {
                    BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler bRACNOSTANJERowChangingEvent = this.BRACNOSTANJERowChanging;
                    if (bRACNOSTANJERowChangingEvent != null)
                    {
                        bRACNOSTANJERowChangingEvent(this, new BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEvent((BRACNOSTANJEDataSet.BRACNOSTANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.BRACNOSTANJERowDeleted != null)
                {
                    BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler bRACNOSTANJERowDeletedEvent = this.BRACNOSTANJERowDeleted;
                    if (bRACNOSTANJERowDeletedEvent != null)
                    {
                        bRACNOSTANJERowDeletedEvent(this, new BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEvent((BRACNOSTANJEDataSet.BRACNOSTANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BRACNOSTANJERowDeleting != null)
                {
                    BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEventHandler bRACNOSTANJERowDeletingEvent = this.BRACNOSTANJERowDeleting;
                    if (bRACNOSTANJERowDeletingEvent != null)
                    {
                        bRACNOSTANJERowDeletingEvent(this, new BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEvent((BRACNOSTANJEDataSet.BRACNOSTANJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveBRACNOSTANJERow(BRACNOSTANJEDataSet.BRACNOSTANJERow row)
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

            public DataColumn IDBRACNOSTANJEColumn
            {
                get
                {
                    return this.columnIDBRACNOSTANJE;
                }
            }

            public BRACNOSTANJEDataSet.BRACNOSTANJERow this[int index]
            {
                get
                {
                    return (BRACNOSTANJEDataSet.BRACNOSTANJERow) this.Rows[index];
                }
            }

            public DataColumn NAZIVBRACNOSTANJEColumn
            {
                get
                {
                    return this.columnNAZIVBRACNOSTANJE;
                }
            }
        }

        public class BRACNOSTANJERow : DataRow
        {
            private BRACNOSTANJEDataSet.BRACNOSTANJEDataTable tableBRACNOSTANJE;

            internal BRACNOSTANJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableBRACNOSTANJE = (BRACNOSTANJEDataSet.BRACNOSTANJEDataTable) this.Table;
            }

            public bool IsIDBRACNOSTANJENull()
            {
                return this.IsNull(this.tableBRACNOSTANJE.IDBRACNOSTANJEColumn);
            }

            public bool IsNAZIVBRACNOSTANJENull()
            {
                return this.IsNull(this.tableBRACNOSTANJE.NAZIVBRACNOSTANJEColumn);
            }

            public void SetNAZIVBRACNOSTANJENull()
            {
                this[this.tableBRACNOSTANJE.NAZIVBRACNOSTANJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDBRACNOSTANJE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableBRACNOSTANJE.IDBRACNOSTANJEColumn]);
                }
                set
                {
                    this[this.tableBRACNOSTANJE.IDBRACNOSTANJEColumn] = value;
                }
            }

            public string NAZIVBRACNOSTANJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableBRACNOSTANJE.NAZIVBRACNOSTANJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVBRACNOSTANJE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableBRACNOSTANJE.NAZIVBRACNOSTANJEColumn] = value;
                }
            }
        }

        public class BRACNOSTANJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private BRACNOSTANJEDataSet.BRACNOSTANJERow eventRow;

            public BRACNOSTANJERowChangeEvent(BRACNOSTANJEDataSet.BRACNOSTANJERow row, DataRowAction action)
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

            public BRACNOSTANJEDataSet.BRACNOSTANJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void BRACNOSTANJERowChangeEventHandler(object sender, BRACNOSTANJEDataSet.BRACNOSTANJERowChangeEvent e);
    }
}

