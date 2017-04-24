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
    public class DDKOLONAIDDDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DDKOLONAIDDDataTable tableDDKOLONAIDD;

        public DDKOLONAIDDDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected DDKOLONAIDDDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DDKOLONAIDD"] != null)
                    {
                        this.Tables.Add(new DDKOLONAIDDDataTable(dataSet.Tables["DDKOLONAIDD"]));
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
            DDKOLONAIDDDataSet set = (DDKOLONAIDDDataSet) base.Clone();
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
            DDKOLONAIDDDataSet set = new DDKOLONAIDDDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "DDKOLONAIDDDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2087");
            this.ExtendedProperties.Add("DataSetName", "DDKOLONAIDDDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IDDKOLONAIDDDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "DDKOLONAIDD");
            this.ExtendedProperties.Add("ObjectDescription", "Kolona IDD obrasca");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\DD");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVKOLONAIDD");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "DDKOLONAIDDDataSet";
            this.Namespace = "http://www.tempuri.org/DDKOLONAIDD";
            this.tableDDKOLONAIDD = new DDKOLONAIDDDataTable();
            this.Tables.Add(this.tableDDKOLONAIDD);
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
            this.tableDDKOLONAIDD = (DDKOLONAIDDDataTable) this.Tables["DDKOLONAIDD"];
            if (initTable && (this.tableDDKOLONAIDD != null))
            {
                this.tableDDKOLONAIDD.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DDKOLONAIDD"] != null)
                {
                    this.Tables.Add(new DDKOLONAIDDDataTable(dataSet.Tables["DDKOLONAIDD"]));
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

        private bool ShouldSerializeDDKOLONAIDD()
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
        public DDKOLONAIDDDataTable DDKOLONAIDD
        {
            get
            {
                return this.tableDDKOLONAIDD;
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
        public class DDKOLONAIDDDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDKOLONAIDD;
            private DataColumn columnNAZIVKOLONAIDD;

            public event DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler DDKOLONAIDDRowChanged;

            public event DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler DDKOLONAIDDRowChanging;

            public event DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler DDKOLONAIDDRowDeleted;

            public event DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler DDKOLONAIDDRowDeleting;

            public DDKOLONAIDDDataTable()
            {
                this.TableName = "DDKOLONAIDD";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DDKOLONAIDDDataTable(DataTable table) : base(table.TableName)
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

            protected DDKOLONAIDDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDDKOLONAIDDRow(DDKOLONAIDDDataSet.DDKOLONAIDDRow row)
            {
                this.Rows.Add(row);
            }

            public DDKOLONAIDDDataSet.DDKOLONAIDDRow AddDDKOLONAIDDRow(int iDKOLONAIDD, string nAZIVKOLONAIDD)
            {
                DDKOLONAIDDDataSet.DDKOLONAIDDRow row = (DDKOLONAIDDDataSet.DDKOLONAIDDRow) this.NewRow();
                row["IDKOLONAIDD"] = iDKOLONAIDD;
                row["NAZIVKOLONAIDD"] = nAZIVKOLONAIDD;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                DDKOLONAIDDDataSet.DDKOLONAIDDDataTable table = (DDKOLONAIDDDataSet.DDKOLONAIDDDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public DDKOLONAIDDDataSet.DDKOLONAIDDRow FindByIDKOLONAIDD(int iDKOLONAIDD)
            {
                return (DDKOLONAIDDDataSet.DDKOLONAIDDRow) this.Rows.Find(new object[] { iDKOLONAIDD });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(DDKOLONAIDDDataSet.DDKOLONAIDDRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DDKOLONAIDDDataSet set = new DDKOLONAIDDDataSet();
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
                this.columnIDKOLONAIDD = new DataColumn("IDKOLONAIDD", typeof(int), "", MappingType.Element);
                this.columnIDKOLONAIDD.AllowDBNull = false;
                this.columnIDKOLONAIDD.Caption = "Kolona IDD obrasca";
                this.columnIDKOLONAIDD.Unique = true;
                this.columnIDKOLONAIDD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("IsKey", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Description", "Kolona");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Length", "5");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDKOLONAIDD.ExtendedProperties.Add("Deklarit.InternalName", "IDKOLONAIDD");
                this.Columns.Add(this.columnIDKOLONAIDD);
                this.columnNAZIVKOLONAIDD = new DataColumn("NAZIVKOLONAIDD", typeof(string), "", MappingType.Element);
                this.columnNAZIVKOLONAIDD.AllowDBNull = false;
                this.columnNAZIVKOLONAIDD.Caption = "Naziv kolone";
                this.columnNAZIVKOLONAIDD.MaxLength = 50;
                this.columnNAZIVKOLONAIDD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Description", "Naziv kolone");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKOLONAIDD.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKOLONAIDD");
                this.Columns.Add(this.columnNAZIVKOLONAIDD);
                this.PrimaryKey = new DataColumn[] { this.columnIDKOLONAIDD };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "DDKOLONAIDD");
                this.ExtendedProperties.Add("Description", "Kolona IDD obrasca");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDKOLONAIDD = this.Columns["IDKOLONAIDD"];
                this.columnNAZIVKOLONAIDD = this.Columns["NAZIVKOLONAIDD"];
            }

            public DDKOLONAIDDDataSet.DDKOLONAIDDRow NewDDKOLONAIDDRow()
            {
                return (DDKOLONAIDDDataSet.DDKOLONAIDDRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DDKOLONAIDDDataSet.DDKOLONAIDDRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DDKOLONAIDDRowChanged != null)
                {
                    DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler dDKOLONAIDDRowChangedEvent = this.DDKOLONAIDDRowChanged;
                    if (dDKOLONAIDDRowChangedEvent != null)
                    {
                        dDKOLONAIDDRowChangedEvent(this, new DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEvent((DDKOLONAIDDDataSet.DDKOLONAIDDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DDKOLONAIDDRowChanging != null)
                {
                    DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler dDKOLONAIDDRowChangingEvent = this.DDKOLONAIDDRowChanging;
                    if (dDKOLONAIDDRowChangingEvent != null)
                    {
                        dDKOLONAIDDRowChangingEvent(this, new DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEvent((DDKOLONAIDDDataSet.DDKOLONAIDDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DDKOLONAIDDRowDeleted != null)
                {
                    DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler dDKOLONAIDDRowDeletedEvent = this.DDKOLONAIDDRowDeleted;
                    if (dDKOLONAIDDRowDeletedEvent != null)
                    {
                        dDKOLONAIDDRowDeletedEvent(this, new DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEvent((DDKOLONAIDDDataSet.DDKOLONAIDDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DDKOLONAIDDRowDeleting != null)
                {
                    DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEventHandler dDKOLONAIDDRowDeletingEvent = this.DDKOLONAIDDRowDeleting;
                    if (dDKOLONAIDDRowDeletingEvent != null)
                    {
                        dDKOLONAIDDRowDeletingEvent(this, new DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEvent((DDKOLONAIDDDataSet.DDKOLONAIDDRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDDKOLONAIDDRow(DDKOLONAIDDDataSet.DDKOLONAIDDRow row)
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

            public DataColumn IDKOLONAIDDColumn
            {
                get
                {
                    return this.columnIDKOLONAIDD;
                }
            }

            public DDKOLONAIDDDataSet.DDKOLONAIDDRow this[int index]
            {
                get
                {
                    return (DDKOLONAIDDDataSet.DDKOLONAIDDRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVKOLONAIDDColumn
            {
                get
                {
                    return this.columnNAZIVKOLONAIDD;
                }
            }
        }

        public class DDKOLONAIDDRow : DataRow
        {
            private DDKOLONAIDDDataSet.DDKOLONAIDDDataTable tableDDKOLONAIDD;

            internal DDKOLONAIDDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDDKOLONAIDD = (DDKOLONAIDDDataSet.DDKOLONAIDDDataTable) this.Table;
            }

            public bool IsIDKOLONAIDDNull()
            {
                return this.IsNull(this.tableDDKOLONAIDD.IDKOLONAIDDColumn);
            }

            public bool IsNAZIVKOLONAIDDNull()
            {
                return this.IsNull(this.tableDDKOLONAIDD.NAZIVKOLONAIDDColumn);
            }

            public void SetNAZIVKOLONAIDDNull()
            {
                this[this.tableDDKOLONAIDD.NAZIVKOLONAIDDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDKOLONAIDD
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableDDKOLONAIDD.IDKOLONAIDDColumn]);
                }
                set
                {
                    this[this.tableDDKOLONAIDD.IDKOLONAIDDColumn] = value;
                }
            }

            public string NAZIVKOLONAIDD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDDKOLONAIDD.NAZIVKOLONAIDDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVKOLONAIDD because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDDKOLONAIDD.NAZIVKOLONAIDDColumn] = value;
                }
            }
        }

        public class DDKOLONAIDDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DDKOLONAIDDDataSet.DDKOLONAIDDRow eventRow;

            public DDKOLONAIDDRowChangeEvent(DDKOLONAIDDDataSet.DDKOLONAIDDRow row, DataRowAction action)
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

            public DDKOLONAIDDDataSet.DDKOLONAIDDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DDKOLONAIDDRowChangeEventHandler(object sender, DDKOLONAIDDDataSet.DDKOLONAIDDRowChangeEvent e);
    }
}

