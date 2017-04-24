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
    public class ORGDIODataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ORGDIODataTable tableORGDIO;

        public ORGDIODataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected ORGDIODataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ORGDIO"] != null)
                    {
                        this.Tables.Add(new ORGDIODataTable(dataSet.Tables["ORGDIO"]));
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
            ORGDIODataSet set = (ORGDIODataSet) base.Clone();
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
            ORGDIODataSet set = new ORGDIODataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "ORGDIODataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1013");
            this.ExtendedProperties.Add("DataSetName", "ORGDIODataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IORGDIODataAdapter");
            this.ExtendedProperties.Add("ObjectName", "ORGDIO");
            this.ExtendedProperties.Add("ObjectDescription", "Organizacijske jedinice");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "ORGANIZACIJSKIDIO");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "ORGDIODataSet";
            this.Namespace = "http://www.tempuri.org/ORGDIO";
            this.tableORGDIO = new ORGDIODataTable();
            this.Tables.Add(this.tableORGDIO);
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
            this.tableORGDIO = (ORGDIODataTable) this.Tables["ORGDIO"];
            if (initTable && (this.tableORGDIO != null))
            {
                this.tableORGDIO.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ORGDIO"] != null)
                {
                    this.Tables.Add(new ORGDIODataTable(dataSet.Tables["ORGDIO"]));
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

        private bool ShouldSerializeORGDIO()
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
        public ORGDIODataTable ORGDIO
        {
            get
            {
                return this.tableORGDIO;
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
        public class ORGDIODataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDORGDIO;
            private DataColumn columnORGANIZACIJSKIDIO;

            public event ORGDIODataSet.ORGDIORowChangeEventHandler ORGDIORowChanged;

            public event ORGDIODataSet.ORGDIORowChangeEventHandler ORGDIORowChanging;

            public event ORGDIODataSet.ORGDIORowChangeEventHandler ORGDIORowDeleted;

            public event ORGDIODataSet.ORGDIORowChangeEventHandler ORGDIORowDeleting;

            public ORGDIODataTable()
            {
                this.TableName = "ORGDIO";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ORGDIODataTable(DataTable table) : base(table.TableName)
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

            protected ORGDIODataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddORGDIORow(ORGDIODataSet.ORGDIORow row)
            {
                this.Rows.Add(row);
            }

            public ORGDIODataSet.ORGDIORow AddORGDIORow(int iDORGDIO, string oRGANIZACIJSKIDIO)
            {
                ORGDIODataSet.ORGDIORow row = (ORGDIODataSet.ORGDIORow) this.NewRow();
                row["IDORGDIO"] = iDORGDIO;
                row["ORGANIZACIJSKIDIO"] = oRGANIZACIJSKIDIO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                ORGDIODataSet.ORGDIODataTable table = (ORGDIODataSet.ORGDIODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public ORGDIODataSet.ORGDIORow FindByIDORGDIO(int iDORGDIO)
            {
                return (ORGDIODataSet.ORGDIORow) this.Rows.Find(new object[] { iDORGDIO });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(ORGDIODataSet.ORGDIORow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                ORGDIODataSet set = new ORGDIODataSet();
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
                this.columnIDORGDIO = new DataColumn("IDORGDIO", typeof(int), "", MappingType.Element);
                this.columnIDORGDIO.AllowDBNull = false;
                this.columnIDORGDIO.Caption = "Šifra organizacijske jedinice";
                this.columnIDORGDIO.Unique = true;
                this.columnIDORGDIO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGDIO.ExtendedProperties.Add("IsKey", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGDIO.ExtendedProperties.Add("Description", "Šifra organizacijske jedinice");
                this.columnIDORGDIO.ExtendedProperties.Add("Length", "5");
                this.columnIDORGDIO.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGDIO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGDIO.ExtendedProperties.Add("Deklarit.InternalName", "IDORGDIO");
                this.Columns.Add(this.columnIDORGDIO);
                this.columnORGANIZACIJSKIDIO = new DataColumn("ORGANIZACIJSKIDIO", typeof(string), "", MappingType.Element);
                this.columnORGANIZACIJSKIDIO.AllowDBNull = false;
                this.columnORGANIZACIJSKIDIO.Caption = "Naziv organizacijske jedinice";
                this.columnORGANIZACIJSKIDIO.MaxLength = 50;
                this.columnORGANIZACIJSKIDIO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("IsKey", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Description", "Naziv organizacijske jedinice");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Length", "50");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Decimals", "0");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("IsInReader", "true");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnORGANIZACIJSKIDIO.ExtendedProperties.Add("Deklarit.InternalName", "ORGANIZACIJSKIDIO");
                this.Columns.Add(this.columnORGANIZACIJSKIDIO);
                this.PrimaryKey = new DataColumn[] { this.columnIDORGDIO };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "ORGDIO");
                this.ExtendedProperties.Add("Description", "Organizacijske jedinice");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDORGDIO = this.Columns["IDORGDIO"];
                this.columnORGANIZACIJSKIDIO = this.Columns["ORGANIZACIJSKIDIO"];
            }

            public ORGDIODataSet.ORGDIORow NewORGDIORow()
            {
                return (ORGDIODataSet.ORGDIORow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ORGDIODataSet.ORGDIORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ORGDIORowChanged != null)
                {
                    ORGDIODataSet.ORGDIORowChangeEventHandler oRGDIORowChangedEvent = this.ORGDIORowChanged;
                    if (oRGDIORowChangedEvent != null)
                    {
                        oRGDIORowChangedEvent(this, new ORGDIODataSet.ORGDIORowChangeEvent((ORGDIODataSet.ORGDIORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ORGDIORowChanging != null)
                {
                    ORGDIODataSet.ORGDIORowChangeEventHandler oRGDIORowChangingEvent = this.ORGDIORowChanging;
                    if (oRGDIORowChangingEvent != null)
                    {
                        oRGDIORowChangingEvent(this, new ORGDIODataSet.ORGDIORowChangeEvent((ORGDIODataSet.ORGDIORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ORGDIORowDeleted != null)
                {
                    ORGDIODataSet.ORGDIORowChangeEventHandler oRGDIORowDeletedEvent = this.ORGDIORowDeleted;
                    if (oRGDIORowDeletedEvent != null)
                    {
                        oRGDIORowDeletedEvent(this, new ORGDIODataSet.ORGDIORowChangeEvent((ORGDIODataSet.ORGDIORow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ORGDIORowDeleting != null)
                {
                    ORGDIODataSet.ORGDIORowChangeEventHandler oRGDIORowDeletingEvent = this.ORGDIORowDeleting;
                    if (oRGDIORowDeletingEvent != null)
                    {
                        oRGDIORowDeletingEvent(this, new ORGDIODataSet.ORGDIORowChangeEvent((ORGDIODataSet.ORGDIORow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveORGDIORow(ORGDIODataSet.ORGDIORow row)
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

            public DataColumn IDORGDIOColumn
            {
                get
                {
                    return this.columnIDORGDIO;
                }
            }

            public ORGDIODataSet.ORGDIORow this[int index]
            {
                get
                {
                    return (ORGDIODataSet.ORGDIORow) this.Rows[index];
                }
            }

            public DataColumn ORGANIZACIJSKIDIOColumn
            {
                get
                {
                    return this.columnORGANIZACIJSKIDIO;
                }
            }
        }

        public class ORGDIORow : DataRow
        {
            private ORGDIODataSet.ORGDIODataTable tableORGDIO;

            internal ORGDIORow(DataRowBuilder rb) : base(rb)
            {
                this.tableORGDIO = (ORGDIODataSet.ORGDIODataTable) this.Table;
            }

            public bool IsIDORGDIONull()
            {
                return this.IsNull(this.tableORGDIO.IDORGDIOColumn);
            }

            public bool IsORGANIZACIJSKIDIONull()
            {
                return this.IsNull(this.tableORGDIO.ORGANIZACIJSKIDIOColumn);
            }

            public void SetORGANIZACIJSKIDIONull()
            {
                this[this.tableORGDIO.ORGANIZACIJSKIDIOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDORGDIO
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableORGDIO.IDORGDIOColumn]);
                }
                set
                {
                    this[this.tableORGDIO.IDORGDIOColumn] = value;
                }
            }

            public string ORGANIZACIJSKIDIO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableORGDIO.ORGANIZACIJSKIDIOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ORGANIZACIJSKIDIO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableORGDIO.ORGANIZACIJSKIDIOColumn] = value;
                }
            }
        }

        public class ORGDIORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private ORGDIODataSet.ORGDIORow eventRow;

            public ORGDIORowChangeEvent(ORGDIODataSet.ORGDIORow row, DataRowAction action)
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

            public ORGDIODataSet.ORGDIORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ORGDIORowChangeEventHandler(object sender, ORGDIODataSet.ORGDIORowChangeEvent e);
    }
}

