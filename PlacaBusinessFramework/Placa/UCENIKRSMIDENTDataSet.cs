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
    public class UCENIKRSMIDENTDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private UCENIKRSMIDENTDataTable tableUCENIKRSMIDENT;

        public UCENIKRSMIDENTDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected UCENIKRSMIDENTDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["UCENIKRSMIDENT"] != null)
                    {
                        this.Tables.Add(new UCENIKRSMIDENTDataTable(dataSet.Tables["UCENIKRSMIDENT"]));
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
            UCENIKRSMIDENTDataSet set = (UCENIKRSMIDENTDataSet) base.Clone();
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
            UCENIKRSMIDENTDataSet set = new UCENIKRSMIDENTDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "UCENIKRSMIDENTDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2199");
            this.ExtendedProperties.Add("DataSetName", "UCENIKRSMIDENTDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IUCENIKRSMIDENTDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "UCENIKRSMIDENT");
            this.ExtendedProperties.Add("ObjectDescription", "UCENIKRSMIDENT");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\UcenickaPraksa");
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
            this.DataSetName = "UCENIKRSMIDENTDataSet";
            this.Namespace = "http://www.tempuri.org/UCENIKRSMIDENT";
            this.tableUCENIKRSMIDENT = new UCENIKRSMIDENTDataTable();
            this.Tables.Add(this.tableUCENIKRSMIDENT);
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
            this.tableUCENIKRSMIDENT = (UCENIKRSMIDENTDataTable) this.Tables["UCENIKRSMIDENT"];
            if (initTable && (this.tableUCENIKRSMIDENT != null))
            {
                this.tableUCENIKRSMIDENT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["UCENIKRSMIDENT"] != null)
                {
                    this.Tables.Add(new UCENIKRSMIDENTDataTable(dataSet.Tables["UCENIKRSMIDENT"]));
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

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeUCENIKRSMIDENT()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UCENIKRSMIDENTDataTable UCENIKRSMIDENT
        {
            get
            {
                return this.tableUCENIKRSMIDENT;
            }
        }

        [Serializable]
        public class UCENIKRSMIDENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnUCENIKRSMIDENT;

            public event UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler UCENIKRSMIDENTRowChanged;

            public event UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler UCENIKRSMIDENTRowChanging;

            public event UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler UCENIKRSMIDENTRowDeleted;

            public event UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler UCENIKRSMIDENTRowDeleting;

            public UCENIKRSMIDENTDataTable()
            {
                this.TableName = "UCENIKRSMIDENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal UCENIKRSMIDENTDataTable(DataTable table) : base(table.TableName)
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

            protected UCENIKRSMIDENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddUCENIKRSMIDENTRow(UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow row)
            {
                this.Rows.Add(row);
            }

            public UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow AddUCENIKRSMIDENTRow(string uCENIKRSMIDENT)
            {
                UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow row = (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) this.NewRow();
                row["UCENIKRSMIDENT"] = uCENIKRSMIDENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                UCENIKRSMIDENTDataSet.UCENIKRSMIDENTDataTable table = (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow FindByUCENIKRSMIDENT(string uCENIKRSMIDENT)
            {
                return (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) this.Rows.Find(new object[] { uCENIKRSMIDENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                UCENIKRSMIDENTDataSet set = new UCENIKRSMIDENTDataSet();
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
                this.columnUCENIKRSMIDENT = new DataColumn("UCENIKRSMIDENT", typeof(string), "", MappingType.Element);
                this.columnUCENIKRSMIDENT.AllowDBNull = false;
                this.columnUCENIKRSMIDENT.Caption = "UCENIKRSMIDENT";
                this.columnUCENIKRSMIDENT.MaxLength = 4;
                this.columnUCENIKRSMIDENT.Unique = true;
                this.columnUCENIKRSMIDENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("IsKey", "true");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Description", "UCENIKRSMIDENT");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Length", "4");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Decimals", "0");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUCENIKRSMIDENT.ExtendedProperties.Add("Deklarit.InternalName", "UCENIKRSMIDENT");
                this.Columns.Add(this.columnUCENIKRSMIDENT);
                this.PrimaryKey = new DataColumn[] { this.columnUCENIKRSMIDENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "UCENIKRSMIDENT");
                this.ExtendedProperties.Add("Description", "UCENIKRSMIDENT");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnUCENIKRSMIDENT = this.Columns["UCENIKRSMIDENT"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow(builder);
            }

            public UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow NewUCENIKRSMIDENTRow()
            {
                return (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.UCENIKRSMIDENTRowChanged != null)
                {
                    UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler uCENIKRSMIDENTRowChangedEvent = this.UCENIKRSMIDENTRowChanged;
                    if (uCENIKRSMIDENTRowChangedEvent != null)
                    {
                        uCENIKRSMIDENTRowChangedEvent(this, new UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEvent((UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.UCENIKRSMIDENTRowChanging != null)
                {
                    UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler uCENIKRSMIDENTRowChangingEvent = this.UCENIKRSMIDENTRowChanging;
                    if (uCENIKRSMIDENTRowChangingEvent != null)
                    {
                        uCENIKRSMIDENTRowChangingEvent(this, new UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEvent((UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.UCENIKRSMIDENTRowDeleted != null)
                {
                    UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler uCENIKRSMIDENTRowDeletedEvent = this.UCENIKRSMIDENTRowDeleted;
                    if (uCENIKRSMIDENTRowDeletedEvent != null)
                    {
                        uCENIKRSMIDENTRowDeletedEvent(this, new UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEvent((UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.UCENIKRSMIDENTRowDeleting != null)
                {
                    UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEventHandler uCENIKRSMIDENTRowDeletingEvent = this.UCENIKRSMIDENTRowDeleting;
                    if (uCENIKRSMIDENTRowDeletingEvent != null)
                    {
                        uCENIKRSMIDENTRowDeletingEvent(this, new UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEvent((UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveUCENIKRSMIDENTRow(UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow row)
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

            public UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow this[int index]
            {
                get
                {
                    return (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) this.Rows[index];
                }
            }

            public DataColumn UCENIKRSMIDENTColumn
            {
                get
                {
                    return this.columnUCENIKRSMIDENT;
                }
            }
        }

        public class UCENIKRSMIDENTRow : DataRow
        {
            private UCENIKRSMIDENTDataSet.UCENIKRSMIDENTDataTable tableUCENIKRSMIDENT;

            internal UCENIKRSMIDENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableUCENIKRSMIDENT = (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTDataTable) this.Table;
            }

            public bool IsUCENIKRSMIDENTNull()
            {
                return this.IsNull(this.tableUCENIKRSMIDENT.UCENIKRSMIDENTColumn);
            }

            public string UCENIKRSMIDENT
            {
                get
                {
                    return Conversions.ToString(this[this.tableUCENIKRSMIDENT.UCENIKRSMIDENTColumn]);
                }
                set
                {
                    this[this.tableUCENIKRSMIDENT.UCENIKRSMIDENTColumn] = value;
                }
            }
        }

        public class UCENIKRSMIDENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow eventRow;

            public UCENIKRSMIDENTRowChangeEvent(UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow row, DataRowAction action)
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

            public UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void UCENIKRSMIDENTRowChangeEventHandler(object sender, UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRowChangeEvent e);
    }
}

