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
    public class vw_mjeseci_godine_isplateDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private vw_mjeseci_godine_isplateDataTable tablevw_mjeseci_godine_isplate;

        public vw_mjeseci_godine_isplateDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected vw_mjeseci_godine_isplateDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["vw_mjeseci_godine_isplate"] != null)
                    {
                        this.Tables.Add(new vw_mjeseci_godine_isplateDataTable(dataSet.Tables["vw_mjeseci_godine_isplate"]));
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
            vw_mjeseci_godine_isplateDataSet set = (vw_mjeseci_godine_isplateDataSet) base.Clone();
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
            vw_mjeseci_godine_isplateDataSet set = new vw_mjeseci_godine_isplateDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "vw_mjeseci_godine_isplateDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2028");
            this.ExtendedProperties.Add("DataSetName", "vw_mjeseci_godine_isplateDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Ivw_mjeseci_godine_isplateDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "vw_mjeseci_godine_isplate");
            this.ExtendedProperties.Add("ObjectDescription", "vw_mjeseci_godine_isplate");
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
            this.DataSetName = "vw_mjeseci_godine_isplateDataSet";
            this.Namespace = "http://www.tempuri.org/vw_mjeseci_godine_isplate";
            this.tablevw_mjeseci_godine_isplate = new vw_mjeseci_godine_isplateDataTable();
            this.Tables.Add(this.tablevw_mjeseci_godine_isplate);
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
            this.tablevw_mjeseci_godine_isplate = (vw_mjeseci_godine_isplateDataTable) this.Tables["vw_mjeseci_godine_isplate"];
            if (initTable && (this.tablevw_mjeseci_godine_isplate != null))
            {
                this.tablevw_mjeseci_godine_isplate.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["vw_mjeseci_godine_isplate"] != null)
                {
                    this.Tables.Add(new vw_mjeseci_godine_isplateDataTable(dataSet.Tables["vw_mjeseci_godine_isplate"]));
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

        private bool ShouldSerializevw_mjeseci_godine_isplate()
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
        public vw_mjeseci_godine_isplateDataTable vw_mjeseci_godine_isplate
        {
            get
            {
                return this.tablevw_mjeseci_godine_isplate;
            }
        }

        [Serializable]
        public class vw_mjeseci_godine_isplateDataTable : DataTable, IEnumerable
        {
            private DataColumn columnGODINAISPLATE;
            private DataColumn columnMJESECISPLATE;

            public event vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler vw_mjeseci_godine_isplateRowChanged;

            public event vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler vw_mjeseci_godine_isplateRowChanging;

            public event vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler vw_mjeseci_godine_isplateRowDeleted;

            public event vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler vw_mjeseci_godine_isplateRowDeleting;

            public vw_mjeseci_godine_isplateDataTable()
            {
                this.TableName = "vw_mjeseci_godine_isplate";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal vw_mjeseci_godine_isplateDataTable(DataTable table) : base(table.TableName)
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

            protected vw_mjeseci_godine_isplateDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addvw_mjeseci_godine_isplateRow(vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow row)
            {
                this.Rows.Add(row);
            }

            public vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow Addvw_mjeseci_godine_isplateRow(string mJESECISPLATE, string gODINAISPLATE)
            {
                vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow row = (vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow) this.NewRow();
                row.ItemArray = new object[] { mJESECISPLATE, gODINAISPLATE };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateDataTable table = (vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                vw_mjeseci_godine_isplateDataSet set = new vw_mjeseci_godine_isplateDataSet();
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
                this.columnMJESECISPLATE = new DataColumn("MJESECISPLATE", typeof(string), "", MappingType.Element);
                this.columnMJESECISPLATE.Caption = "Mjesec isplate";
                this.columnMJESECISPLATE.MaxLength = 2;
                this.columnMJESECISPLATE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsKey", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Description", "Mjesec isplate");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Length", "2");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Decimals", "0");
                this.columnMJESECISPLATE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("IsInReader", "true");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMJESECISPLATE.ExtendedProperties.Add("Deklarit.InternalName", "MJESECISPLATE");
                this.Columns.Add(this.columnMJESECISPLATE);
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
                this.ExtendedProperties.Add("LevelName", "vw_mjeseci_godine_isplate");
                this.ExtendedProperties.Add("Description", "VW_PLACA_DD_MJESECI_GODINE_ISPLATE");
                this.ExtendedProperties.Add("HasOrder", "true");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnMJESECISPLATE = this.Columns["MJESECISPLATE"];
                this.columnGODINAISPLATE = this.Columns["GODINAISPLATE"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow(builder);
            }

            public vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow Newvw_mjeseci_godine_isplateRow()
            {
                return (vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vw_mjeseci_godine_isplateRowChanged != null)
                {
                    vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler handler = this.vw_mjeseci_godine_isplateRowChanged;
                    if (handler != null)
                    {
                        handler(this, new vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEvent((vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vw_mjeseci_godine_isplateRowChanging != null)
                {
                    vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler handler = this.vw_mjeseci_godine_isplateRowChanging;
                    if (handler != null)
                    {
                        handler(this, new vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEvent((vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vw_mjeseci_godine_isplateRowDeleted != null)
                {
                    vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler handler = this.vw_mjeseci_godine_isplateRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEvent((vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vw_mjeseci_godine_isplateRowDeleting != null)
                {
                    vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEventHandler handler = this.vw_mjeseci_godine_isplateRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEvent((vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow) e.Row, e.Action));
                    }
                }
            }

            public void Removevw_mjeseci_godine_isplateRow(vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow row)
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

            public vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow this[int index]
            {
                get
                {
                    return (vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow) this.Rows[index];
                }
            }

            public DataColumn MJESECISPLATEColumn
            {
                get
                {
                    return this.columnMJESECISPLATE;
                }
            }
        }

        public class vw_mjeseci_godine_isplateRow : DataRow
        {
            private vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateDataTable tablevw_mjeseci_godine_isplate;

            internal vw_mjeseci_godine_isplateRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevw_mjeseci_godine_isplate = (vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateDataTable) this.Table;
            }

            public bool IsGODINAISPLATENull()
            {
                return this.IsNull(this.tablevw_mjeseci_godine_isplate.GODINAISPLATEColumn);
            }

            public bool IsMJESECISPLATENull()
            {
                return this.IsNull(this.tablevw_mjeseci_godine_isplate.MJESECISPLATEColumn);
            }

            public void SetGODINAISPLATENull()
            {
                this[this.tablevw_mjeseci_godine_isplate.GODINAISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMJESECISPLATENull()
            {
                this[this.tablevw_mjeseci_godine_isplate.MJESECISPLATEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string GODINAISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablevw_mjeseci_godine_isplate.GODINAISPLATEColumn]);
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
                    this[this.tablevw_mjeseci_godine_isplate.GODINAISPLATEColumn] = value;
                }
            }

            public string MJESECISPLATE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablevw_mjeseci_godine_isplate.MJESECISPLATEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MJESECISPLATE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablevw_mjeseci_godine_isplate.MJESECISPLATEColumn] = value;
                }
            }
        }

        public class vw_mjeseci_godine_isplateRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow eventRow;

            public vw_mjeseci_godine_isplateRowChangeEvent(vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow row, DataRowAction action)
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

            public vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void vw_mjeseci_godine_isplateRowChangeEventHandler(object sender, vw_mjeseci_godine_isplateDataSet.vw_mjeseci_godine_isplateRowChangeEvent e);
    }
}

