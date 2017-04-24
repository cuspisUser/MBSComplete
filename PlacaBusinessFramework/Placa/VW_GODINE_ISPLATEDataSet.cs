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
    public class VW_GODINE_ISPLATEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private VW_GODINE_ISPLATEDataTable tableVW_GODINE_ISPLATE;

        public VW_GODINE_ISPLATEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected VW_GODINE_ISPLATEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["VW_GODINE_ISPLATE"] != null)
                    {
                        this.Tables.Add(new VW_GODINE_ISPLATEDataTable(dataSet.Tables["VW_GODINE_ISPLATE"]));
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
            VW_GODINE_ISPLATEDataSet set = (VW_GODINE_ISPLATEDataSet) base.Clone();
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
            VW_GODINE_ISPLATEDataSet set = new VW_GODINE_ISPLATEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "VW_GODINE_ISPLATEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2037");
            this.ExtendedProperties.Add("DataSetName", "VW_GODINE_ISPLATEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IVW_GODINE_ISPLATEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "VW_GODINE_ISPLATE");
            this.ExtendedProperties.Add("ObjectDescription", "VW_GODINE_ISPLATE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "false");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "false");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "VW_GODINE_ISPLATEDataSet";
            this.Namespace = "http://www.tempuri.org/VW_GODINE_ISPLATE";
            this.tableVW_GODINE_ISPLATE = new VW_GODINE_ISPLATEDataTable();
            this.Tables.Add(this.tableVW_GODINE_ISPLATE);
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
            this.tableVW_GODINE_ISPLATE = (VW_GODINE_ISPLATEDataTable) this.Tables["VW_GODINE_ISPLATE"];
            if (initTable && (this.tableVW_GODINE_ISPLATE != null))
            {
                this.tableVW_GODINE_ISPLATE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["VW_GODINE_ISPLATE"] != null)
                {
                    this.Tables.Add(new VW_GODINE_ISPLATEDataTable(dataSet.Tables["VW_GODINE_ISPLATE"]));
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

        private bool ShouldSerializeVW_GODINE_ISPLATE()
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
        public VW_GODINE_ISPLATEDataTable VW_GODINE_ISPLATE
        {
            get
            {
                return this.tableVW_GODINE_ISPLATE;
            }
        }

        [Serializable]
        public class VW_GODINE_ISPLATEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAISPLATE;

            public event VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler VW_GODINE_ISPLATERowChanged;

            public event VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler VW_GODINE_ISPLATERowChanging;

            public event VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler VW_GODINE_ISPLATERowDeleted;

            public event VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler VW_GODINE_ISPLATERowDeleting;

            public VW_GODINE_ISPLATEDataTable()
            {
                this.TableName = "VW_GODINE_ISPLATE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal VW_GODINE_ISPLATEDataTable(DataTable table) : base(table.TableName)
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

            protected VW_GODINE_ISPLATEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddVW_GODINE_ISPLATERow(VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow row)
            {
                this.Rows.Add(row);
            }

            public VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow AddVW_GODINE_ISPLATERow(string gODINAISPLATE)
            {
                VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow row = (VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow) this.NewRow();
                row.ItemArray = new object[] { gODINAISPLATE };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATEDataTable table = (VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                VW_GODINE_ISPLATEDataSet set = new VW_GODINE_ISPLATEDataSet();
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
                this.columnGODINAISPLATE = new DataColumn("GODINAISPLATE", typeof(string), "", MappingType.Element);
                this.columnGODINAISPLATE.Caption = "Godina isplate";
                this.columnGODINAISPLATE.MaxLength = 4;
                this.columnGODINAISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Description", "Godina isplate");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Length", "4");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnGODINAISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGODINAISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "GODINAISPLATE");
                this.Columns.Add(this.columnGODINAISPLATE);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "VW_GODINE_ISPLATE");
                this.ExtendedProperties.Add("Description", "VW_PLACA_GODINE_ISPLATE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnGODINAISPLATE = this.Columns["GODINAISPLATE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow(builder);
            }

            public VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow NewVW_GODINE_ISPLATERow()
            {
                return (VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VW_GODINE_ISPLATERowChanged != null)
                {
                    VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler handler = this.VW_GODINE_ISPLATERowChanged;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEvent((VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VW_GODINE_ISPLATERowChanging != null)
                {
                    VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler handler = this.VW_GODINE_ISPLATERowChanging;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEvent((VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VW_GODINE_ISPLATERowDeleted != null)
                {
                    VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler handler = this.VW_GODINE_ISPLATERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEvent((VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VW_GODINE_ISPLATERowDeleting != null)
                {
                    VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEventHandler handler = this.VW_GODINE_ISPLATERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEvent((VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveVW_GODINE_ISPLATERow(VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow row)
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

            public DataColumn GODINAISPLATEColumn
            {
                get
                {
                    return this.columnGODINAISPLATE;
                }
            }

            public VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow this[int index]
            {
                get
                {
                    return (VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow) this.Rows[index];
                }
            }
        }

        public class VW_GODINE_ISPLATERow : DataRow
        {
            private VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATEDataTable tableVW_GODINE_ISPLATE;

            internal VW_GODINE_ISPLATERow(DataRowBuilder rb) : base(rb)
            {
                this.tableVW_GODINE_ISPLATE = (VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATEDataTable) this.Table;
            }

            public bool IsGODINAISPLATENull()
            {
                return this.IsNull(this.tableVW_GODINE_ISPLATE.GODINAISPLATEColumn);
            }

            public void SetGODINAISPLATENull()
            {
                this[this.tableVW_GODINE_ISPLATE.GODINAISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableVW_GODINE_ISPLATE.GODINAISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value GODINAISPLATE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableVW_GODINE_ISPLATE.GODINAISPLATEColumn] = value;
                }
            }
        }

        public class VW_GODINE_ISPLATERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow eventRow;

            public VW_GODINE_ISPLATERowChangeEvent(VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow row, DataRowAction action)
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

            public VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void VW_GODINE_ISPLATERowChangeEventHandler(object sender, VW_GODINE_ISPLATEDataSet.VW_GODINE_ISPLATERowChangeEvent e);
    }
}

