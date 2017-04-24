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
    public class IPIDENTDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private IPIDENTDataTable tableIPIDENT;

        public IPIDENTDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected IPIDENTDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["IPIDENT"] != null)
                    {
                        this.Tables.Add(new IPIDENTDataTable(dataSet.Tables["IPIDENT"]));
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
            IPIDENTDataSet set = (IPIDENTDataSet) base.Clone();
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
            IPIDENTDataSet set = new IPIDENTDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "IPIDENTDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2013");
            this.ExtendedProperties.Add("DataSetName", "IPIDENTDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IIPIDENTDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "IPIDENT");
            this.ExtendedProperties.Add("ObjectDescription", "IP Identifikatori");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "IDIPIDENT");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "IPIDENTDataSet";
            this.Namespace = "http://www.tempuri.org/IPIDENT";
            this.tableIPIDENT = new IPIDENTDataTable();
            this.Tables.Add(this.tableIPIDENT);
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
            this.tableIPIDENT = (IPIDENTDataTable) this.Tables["IPIDENT"];
            if (initTable && (this.tableIPIDENT != null))
            {
                this.tableIPIDENT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["IPIDENT"] != null)
                {
                    this.Tables.Add(new IPIDENTDataTable(dataSet.Tables["IPIDENT"]));
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

        private bool ShouldSerializeIPIDENT()
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
        public IPIDENTDataTable IPIDENT
        {
            get
            {
                return this.tableIPIDENT;
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
        public class IPIDENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDIPIDENT;
            private DataColumn columnNAZIVIPIDENT;

            public event IPIDENTDataSet.IPIDENTRowChangeEventHandler IPIDENTRowChanged;

            public event IPIDENTDataSet.IPIDENTRowChangeEventHandler IPIDENTRowChanging;

            public event IPIDENTDataSet.IPIDENTRowChangeEventHandler IPIDENTRowDeleted;

            public event IPIDENTDataSet.IPIDENTRowChangeEventHandler IPIDENTRowDeleting;

            public IPIDENTDataTable()
            {
                this.TableName = "IPIDENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal IPIDENTDataTable(DataTable table) : base(table.TableName)
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

            protected IPIDENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddIPIDENTRow(IPIDENTDataSet.IPIDENTRow row)
            {
                this.Rows.Add(row);
            }

            public IPIDENTDataSet.IPIDENTRow AddIPIDENTRow(int iDIPIDENT, string nAZIVIPIDENT)
            {
                IPIDENTDataSet.IPIDENTRow row = (IPIDENTDataSet.IPIDENTRow) this.NewRow();
                row["IDIPIDENT"] = iDIPIDENT;
                row["NAZIVIPIDENT"] = nAZIVIPIDENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                IPIDENTDataSet.IPIDENTDataTable table = (IPIDENTDataSet.IPIDENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IPIDENTDataSet.IPIDENTRow FindByIDIPIDENT(int iDIPIDENT)
            {
                return (IPIDENTDataSet.IPIDENTRow) this.Rows.Find(new object[] { iDIPIDENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(IPIDENTDataSet.IPIDENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                IPIDENTDataSet set = new IPIDENTDataSet();
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
                this.columnIDIPIDENT = new DataColumn("IDIPIDENT", typeof(int), "", MappingType.Element);
                this.columnIDIPIDENT.AllowDBNull = false;
                this.columnIDIPIDENT.Caption = "IDIPIDENT";
                this.columnIDIPIDENT.Unique = true;
                this.columnIDIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDIPIDENT.ExtendedProperties.Add("Description", "IP Identifikator");
                this.columnIDIPIDENT.ExtendedProperties.Add("Length", "5");
                this.columnIDIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDIPIDENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "IDIPIDENT");
                this.Columns.Add(this.columnIDIPIDENT);
                this.columnNAZIVIPIDENT = new DataColumn("NAZIVIPIDENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVIPIDENT.AllowDBNull = false;
                this.columnNAZIVIPIDENT.Caption = "NAZIVIPIDENT";
                this.columnNAZIVIPIDENT.MaxLength = 20;
                this.columnNAZIVIPIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Description", "Naziv IP identifikator");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Length", "20");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVIPIDENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVIPIDENT");
                this.Columns.Add(this.columnNAZIVIPIDENT);
                this.PrimaryKey = new DataColumn[] { this.columnIDIPIDENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "IPIDENT");
                this.ExtendedProperties.Add("Description", "IP Identifikatori");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDIPIDENT = this.Columns["IDIPIDENT"];
                this.columnNAZIVIPIDENT = this.Columns["NAZIVIPIDENT"];
            }

            public IPIDENTDataSet.IPIDENTRow NewIPIDENTRow()
            {
                return (IPIDENTDataSet.IPIDENTRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new IPIDENTDataSet.IPIDENTRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.IPIDENTRowChanged != null)
                {
                    IPIDENTDataSet.IPIDENTRowChangeEventHandler iPIDENTRowChangedEvent = this.IPIDENTRowChanged;
                    if (iPIDENTRowChangedEvent != null)
                    {
                        iPIDENTRowChangedEvent(this, new IPIDENTDataSet.IPIDENTRowChangeEvent((IPIDENTDataSet.IPIDENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.IPIDENTRowChanging != null)
                {
                    IPIDENTDataSet.IPIDENTRowChangeEventHandler iPIDENTRowChangingEvent = this.IPIDENTRowChanging;
                    if (iPIDENTRowChangingEvent != null)
                    {
                        iPIDENTRowChangingEvent(this, new IPIDENTDataSet.IPIDENTRowChangeEvent((IPIDENTDataSet.IPIDENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.IPIDENTRowDeleted != null)
                {
                    IPIDENTDataSet.IPIDENTRowChangeEventHandler iPIDENTRowDeletedEvent = this.IPIDENTRowDeleted;
                    if (iPIDENTRowDeletedEvent != null)
                    {
                        iPIDENTRowDeletedEvent(this, new IPIDENTDataSet.IPIDENTRowChangeEvent((IPIDENTDataSet.IPIDENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.IPIDENTRowDeleting != null)
                {
                    IPIDENTDataSet.IPIDENTRowChangeEventHandler iPIDENTRowDeletingEvent = this.IPIDENTRowDeleting;
                    if (iPIDENTRowDeletingEvent != null)
                    {
                        iPIDENTRowDeletingEvent(this, new IPIDENTDataSet.IPIDENTRowChangeEvent((IPIDENTDataSet.IPIDENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveIPIDENTRow(IPIDENTDataSet.IPIDENTRow row)
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

            public DataColumn IDIPIDENTColumn
            {
                get
                {
                    return this.columnIDIPIDENT;
                }
            }

            public IPIDENTDataSet.IPIDENTRow this[int index]
            {
                get
                {
                    return (IPIDENTDataSet.IPIDENTRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVIPIDENTColumn
            {
                get
                {
                    return this.columnNAZIVIPIDENT;
                }
            }
        }

        public class IPIDENTRow : DataRow
        {
            private IPIDENTDataSet.IPIDENTDataTable tableIPIDENT;

            internal IPIDENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableIPIDENT = (IPIDENTDataSet.IPIDENTDataTable) this.Table;
            }

            public bool IsIDIPIDENTNull()
            {
                return this.IsNull(this.tableIPIDENT.IDIPIDENTColumn);
            }

            public bool IsNAZIVIPIDENTNull()
            {
                return this.IsNull(this.tableIPIDENT.NAZIVIPIDENTColumn);
            }

            public void SetNAZIVIPIDENTNull()
            {
                this[this.tableIPIDENT.NAZIVIPIDENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDIPIDENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableIPIDENT.IDIPIDENTColumn]);
                }
                set
                {
                    this[this.tableIPIDENT.IDIPIDENTColumn] = value;
                }
            }

            public string NAZIVIPIDENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableIPIDENT.NAZIVIPIDENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVIPIDENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableIPIDENT.NAZIVIPIDENTColumn] = value;
                }
            }
        }

        public class IPIDENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private IPIDENTDataSet.IPIDENTRow eventRow;

            public IPIDENTRowChangeEvent(IPIDENTDataSet.IPIDENTRow row, DataRowAction action)
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

            public IPIDENTDataSet.IPIDENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void IPIDENTRowChangeEventHandler(object sender, IPIDENTDataSet.IPIDENTRowChangeEvent e);
    }
}

