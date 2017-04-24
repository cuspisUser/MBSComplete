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
    public class OSDOKUMENTDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OSDOKUMENTDataTable tableOSDOKUMENT;

        public OSDOKUMENTDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OSDOKUMENTDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OSDOKUMENT"] != null)
                    {
                        this.Tables.Add(new OSDOKUMENTDataTable(dataSet.Tables["OSDOKUMENT"]));
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
            OSDOKUMENTDataSet set = (OSDOKUMENTDataSet) base.Clone();
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
            OSDOKUMENTDataSet set = new OSDOKUMENTDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OSDOKUMENTDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2152");
            this.ExtendedProperties.Add("DataSetName", "OSDOKUMENTDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOSDOKUMENTDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OSDOKUMENT");
            this.ExtendedProperties.Add("ObjectDescription", "OSDOKUMENT");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "OSDK");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "OSDOKUMENTDataSet";
            this.Namespace = "http://www.tempuri.org/OSDOKUMENT";
            this.tableOSDOKUMENT = new OSDOKUMENTDataTable();
            this.Tables.Add(this.tableOSDOKUMENT);
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
            this.tableOSDOKUMENT = (OSDOKUMENTDataTable) this.Tables["OSDOKUMENT"];
            if (initTable && (this.tableOSDOKUMENT != null))
            {
                this.tableOSDOKUMENT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OSDOKUMENT"] != null)
                {
                    this.Tables.Add(new OSDOKUMENTDataTable(dataSet.Tables["OSDOKUMENT"]));
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

        private bool ShouldSerializeOSDOKUMENT()
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
        public OSDOKUMENTDataTable OSDOKUMENT
        {
            get
            {
                return this.tableOSDOKUMENT;
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
        public class OSDOKUMENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOSDOKUMENT;
            private DataColumn columnNAZIVOSDOKUMENT;
            private DataColumn columnOSDK;

            public event OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler OSDOKUMENTRowChanged;

            public event OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler OSDOKUMENTRowChanging;

            public event OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler OSDOKUMENTRowDeleted;

            public event OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler OSDOKUMENTRowDeleting;

            public OSDOKUMENTDataTable()
            {
                this.TableName = "OSDOKUMENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OSDOKUMENTDataTable(DataTable table) : base(table.TableName)
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

            protected OSDOKUMENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOSDOKUMENTRow(OSDOKUMENTDataSet.OSDOKUMENTRow row)
            {
                this.Rows.Add(row);
            }

            public OSDOKUMENTDataSet.OSDOKUMENTRow AddOSDOKUMENTRow(int iDOSDOKUMENT, string nAZIVOSDOKUMENT)
            {
                OSDOKUMENTDataSet.OSDOKUMENTRow row = (OSDOKUMENTDataSet.OSDOKUMENTRow) this.NewRow();
                row["IDOSDOKUMENT"] = iDOSDOKUMENT;
                row["NAZIVOSDOKUMENT"] = nAZIVOSDOKUMENT;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OSDOKUMENTDataSet.OSDOKUMENTDataTable table = (OSDOKUMENTDataSet.OSDOKUMENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OSDOKUMENTDataSet.OSDOKUMENTRow FindByIDOSDOKUMENT(int iDOSDOKUMENT)
            {
                return (OSDOKUMENTDataSet.OSDOKUMENTRow) this.Rows.Find(new object[] { iDOSDOKUMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OSDOKUMENTDataSet.OSDOKUMENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OSDOKUMENTDataSet set = new OSDOKUMENTDataSet();
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
                this.columnIDOSDOKUMENT = new DataColumn("IDOSDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIDOSDOKUMENT.AllowDBNull = false;
                this.columnIDOSDOKUMENT.Caption = "IDOSDOKUMENT";
                this.columnIDOSDOKUMENT.Unique = true;
                this.columnIDOSDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Length", "5");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDOSDOKUMENT");
                this.Columns.Add(this.columnIDOSDOKUMENT);
                this.columnNAZIVOSDOKUMENT = new DataColumn("NAZIVOSDOKUMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVOSDOKUMENT.AllowDBNull = false;
                this.columnNAZIVOSDOKUMENT.Caption = "NAZIVOSDOKUMENT";
                this.columnNAZIVOSDOKUMENT.MaxLength = 30;
                this.columnNAZIVOSDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Description", "Dokument");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Length", "30");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOSDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOSDOKUMENT");
                this.Columns.Add(this.columnNAZIVOSDOKUMENT);
                this.columnOSDK = new DataColumn("OSDK", typeof(string), "", MappingType.Element);
                this.columnOSDK.AllowDBNull = true;
                this.columnOSDK.Caption = "OSDK";
                this.columnOSDK.MaxLength = 40;
                this.columnOSDK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSDK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSDK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSDK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSDK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSDK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSDK.ExtendedProperties.Add("IsKey", "false");
                this.columnOSDK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSDK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOSDK.ExtendedProperties.Add("Description", "OSDK");
                this.columnOSDK.ExtendedProperties.Add("Length", "40");
                this.columnOSDK.ExtendedProperties.Add("Decimals", "0");
                this.columnOSDK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSDK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSDK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSDK.ExtendedProperties.Add("Deklarit.InternalName", "OSDK");
                this.Columns.Add(this.columnOSDK);
                this.PrimaryKey = new DataColumn[] { this.columnIDOSDOKUMENT };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OSDOKUMENT");
                this.ExtendedProperties.Add("Description", "OSDOKUMENT");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOSDOKUMENT = this.Columns["IDOSDOKUMENT"];
                this.columnNAZIVOSDOKUMENT = this.Columns["NAZIVOSDOKUMENT"];
                this.columnOSDK = this.Columns["OSDK"];
            }

            public OSDOKUMENTDataSet.OSDOKUMENTRow NewOSDOKUMENTRow()
            {
                return (OSDOKUMENTDataSet.OSDOKUMENTRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OSDOKUMENTDataSet.OSDOKUMENTRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OSDOKUMENTRowChanged != null)
                {
                    OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler oSDOKUMENTRowChangedEvent = this.OSDOKUMENTRowChanged;
                    if (oSDOKUMENTRowChangedEvent != null)
                    {
                        oSDOKUMENTRowChangedEvent(this, new OSDOKUMENTDataSet.OSDOKUMENTRowChangeEvent((OSDOKUMENTDataSet.OSDOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OSDOKUMENTRowChanging != null)
                {
                    OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler oSDOKUMENTRowChangingEvent = this.OSDOKUMENTRowChanging;
                    if (oSDOKUMENTRowChangingEvent != null)
                    {
                        oSDOKUMENTRowChangingEvent(this, new OSDOKUMENTDataSet.OSDOKUMENTRowChangeEvent((OSDOKUMENTDataSet.OSDOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OSDOKUMENTRowDeleted != null)
                {
                    OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler oSDOKUMENTRowDeletedEvent = this.OSDOKUMENTRowDeleted;
                    if (oSDOKUMENTRowDeletedEvent != null)
                    {
                        oSDOKUMENTRowDeletedEvent(this, new OSDOKUMENTDataSet.OSDOKUMENTRowChangeEvent((OSDOKUMENTDataSet.OSDOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OSDOKUMENTRowDeleting != null)
                {
                    OSDOKUMENTDataSet.OSDOKUMENTRowChangeEventHandler oSDOKUMENTRowDeletingEvent = this.OSDOKUMENTRowDeleting;
                    if (oSDOKUMENTRowDeletingEvent != null)
                    {
                        oSDOKUMENTRowDeletingEvent(this, new OSDOKUMENTDataSet.OSDOKUMENTRowChangeEvent((OSDOKUMENTDataSet.OSDOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOSDOKUMENTRow(OSDOKUMENTDataSet.OSDOKUMENTRow row)
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

            public DataColumn IDOSDOKUMENTColumn
            {
                get
                {
                    return this.columnIDOSDOKUMENT;
                }
            }

            public OSDOKUMENTDataSet.OSDOKUMENTRow this[int index]
            {
                get
                {
                    return (OSDOKUMENTDataSet.OSDOKUMENTRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVOSDOKUMENTColumn
            {
                get
                {
                    return this.columnNAZIVOSDOKUMENT;
                }
            }

            public DataColumn OSDKColumn
            {
                get
                {
                    return this.columnOSDK;
                }
            }
        }

        public class OSDOKUMENTRow : DataRow
        {
            private OSDOKUMENTDataSet.OSDOKUMENTDataTable tableOSDOKUMENT;

            internal OSDOKUMENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableOSDOKUMENT = (OSDOKUMENTDataSet.OSDOKUMENTDataTable) this.Table;
            }

            public bool IsIDOSDOKUMENTNull()
            {
                return this.IsNull(this.tableOSDOKUMENT.IDOSDOKUMENTColumn);
            }

            public bool IsNAZIVOSDOKUMENTNull()
            {
                return this.IsNull(this.tableOSDOKUMENT.NAZIVOSDOKUMENTColumn);
            }

            public bool IsOSDKNull()
            {
                return this.IsNull(this.tableOSDOKUMENT.OSDKColumn);
            }

            public void SetNAZIVOSDOKUMENTNull()
            {
                this[this.tableOSDOKUMENT.NAZIVOSDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSDKNull()
            {
                this[this.tableOSDOKUMENT.OSDKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOSDOKUMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOSDOKUMENT.IDOSDOKUMENTColumn]);
                }
                set
                {
                    this[this.tableOSDOKUMENT.IDOSDOKUMENTColumn] = value;
                }
            }

            public string NAZIVOSDOKUMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSDOKUMENT.NAZIVOSDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVOSDOKUMENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSDOKUMENT.NAZIVOSDOKUMENTColumn] = value;
                }
            }

            public string OSDK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSDOKUMENT.OSDKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSDK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSDOKUMENT.OSDKColumn] = value;
                }
            }
        }

        public class OSDOKUMENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OSDOKUMENTDataSet.OSDOKUMENTRow eventRow;

            public OSDOKUMENTRowChangeEvent(OSDOKUMENTDataSet.OSDOKUMENTRow row, DataRowAction action)
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

            public OSDOKUMENTDataSet.OSDOKUMENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OSDOKUMENTRowChangeEventHandler(object sender, OSDOKUMENTDataSet.OSDOKUMENTRowChangeEvent e);
    }
}

