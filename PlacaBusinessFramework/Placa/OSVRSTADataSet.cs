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
    public class OSVRSTADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private OSVRSTADataTable tableOSVRSTA;

        public OSVRSTADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected OSVRSTADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["OSVRSTA"] != null)
                    {
                        this.Tables.Add(new OSVRSTADataTable(dataSet.Tables["OSVRSTA"]));
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
            OSVRSTADataSet set = (OSVRSTADataSet) base.Clone();
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
            OSVRSTADataSet set = new OSVRSTADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "OSVRSTADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2142");
            this.ExtendedProperties.Add("DataSetName", "OSVRSTADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IOSVRSTADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "OSVRSTA");
            this.ExtendedProperties.Add("ObjectDescription", "Vrste sredstava (OS ili SI)");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "OSV");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "OSVRSTADataSet";
            this.Namespace = "http://www.tempuri.org/OSVRSTA";
            this.tableOSVRSTA = new OSVRSTADataTable();
            this.Tables.Add(this.tableOSVRSTA);
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
            this.tableOSVRSTA = (OSVRSTADataTable) this.Tables["OSVRSTA"];
            if (initTable && (this.tableOSVRSTA != null))
            {
                this.tableOSVRSTA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["OSVRSTA"] != null)
                {
                    this.Tables.Add(new OSVRSTADataTable(dataSet.Tables["OSVRSTA"]));
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

        private bool ShouldSerializeOSVRSTA()
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
        public OSVRSTADataTable OSVRSTA
        {
            get
            {
                return this.tableOSVRSTA;
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
        public class OSVRSTADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDOSVRSTA;
            private DataColumn columnOPISOSVRSTA;
            private DataColumn columnOSV;

            public event OSVRSTADataSet.OSVRSTARowChangeEventHandler OSVRSTARowChanged;

            public event OSVRSTADataSet.OSVRSTARowChangeEventHandler OSVRSTARowChanging;

            public event OSVRSTADataSet.OSVRSTARowChangeEventHandler OSVRSTARowDeleted;

            public event OSVRSTADataSet.OSVRSTARowChangeEventHandler OSVRSTARowDeleting;

            public OSVRSTADataTable()
            {
                this.TableName = "OSVRSTA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal OSVRSTADataTable(DataTable table) : base(table.TableName)
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

            protected OSVRSTADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddOSVRSTARow(OSVRSTADataSet.OSVRSTARow row)
            {
                this.Rows.Add(row);
            }

            public OSVRSTADataSet.OSVRSTARow AddOSVRSTARow(int iDOSVRSTA, string oPISOSVRSTA)
            {
                OSVRSTADataSet.OSVRSTARow row = (OSVRSTADataSet.OSVRSTARow) this.NewRow();
                row["IDOSVRSTA"] = iDOSVRSTA;
                row["OPISOSVRSTA"] = oPISOSVRSTA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                OSVRSTADataSet.OSVRSTADataTable table = (OSVRSTADataSet.OSVRSTADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public OSVRSTADataSet.OSVRSTARow FindByIDOSVRSTA(int iDOSVRSTA)
            {
                return (OSVRSTADataSet.OSVRSTARow) this.Rows.Find(new object[] { iDOSVRSTA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(OSVRSTADataSet.OSVRSTARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                OSVRSTADataSet set = new OSVRSTADataSet();
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
                this.columnIDOSVRSTA = new DataColumn("IDOSVRSTA", typeof(int), "", MappingType.Element);
                this.columnIDOSVRSTA.AllowDBNull = false;
                this.columnIDOSVRSTA.Caption = "IDOSVRSTA";
                this.columnIDOSVRSTA.Unique = true;
                this.columnIDOSVRSTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOSVRSTA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDOSVRSTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Description", "Šfr.");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Length", "5");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOSVRSTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOSVRSTA.ExtendedProperties.Add("Deklarit.InternalName", "IDOSVRSTA");
                this.Columns.Add(this.columnIDOSVRSTA);
                this.columnOPISOSVRSTA = new DataColumn("OPISOSVRSTA", typeof(string), "", MappingType.Element);
                this.columnOPISOSVRSTA.AllowDBNull = false;
                this.columnOPISOSVRSTA.Caption = "OPISOSVRSTA";
                this.columnOPISOSVRSTA.MaxLength = 30;
                this.columnOPISOSVRSTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Description", "Vrsta sredstva (OS ili SI)");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Length", "30");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISOSVRSTA.ExtendedProperties.Add("Deklarit.InternalName", "OPISOSVRSTA");
                this.Columns.Add(this.columnOPISOSVRSTA);
                this.columnOSV = new DataColumn("OSV", typeof(string), "", MappingType.Element);
                this.columnOSV.AllowDBNull = true;
                this.columnOSV.Caption = "OSV";
                this.columnOSV.MaxLength = 0x23;
                this.columnOSV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOSV.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOSV.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOSV.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOSV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOSV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOSV.ExtendedProperties.Add("IsKey", "false");
                this.columnOSV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOSV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOSV.ExtendedProperties.Add("Description", "OSV");
                this.columnOSV.ExtendedProperties.Add("Length", "35");
                this.columnOSV.ExtendedProperties.Add("Decimals", "0");
                this.columnOSV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOSV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOSV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOSV.ExtendedProperties.Add("Deklarit.InternalName", "OSV");
                this.Columns.Add(this.columnOSV);
                this.PrimaryKey = new DataColumn[] { this.columnIDOSVRSTA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "OSVRSTA");
                this.ExtendedProperties.Add("Description", "Vrste sredstava (OS ili SI)");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDOSVRSTA = this.Columns["IDOSVRSTA"];
                this.columnOPISOSVRSTA = this.Columns["OPISOSVRSTA"];
                this.columnOSV = this.Columns["OSV"];
            }

            public OSVRSTADataSet.OSVRSTARow NewOSVRSTARow()
            {
                return (OSVRSTADataSet.OSVRSTARow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OSVRSTADataSet.OSVRSTARow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.OSVRSTARowChanged != null)
                {
                    OSVRSTADataSet.OSVRSTARowChangeEventHandler oSVRSTARowChangedEvent = this.OSVRSTARowChanged;
                    if (oSVRSTARowChangedEvent != null)
                    {
                        oSVRSTARowChangedEvent(this, new OSVRSTADataSet.OSVRSTARowChangeEvent((OSVRSTADataSet.OSVRSTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.OSVRSTARowChanging != null)
                {
                    OSVRSTADataSet.OSVRSTARowChangeEventHandler oSVRSTARowChangingEvent = this.OSVRSTARowChanging;
                    if (oSVRSTARowChangingEvent != null)
                    {
                        oSVRSTARowChangingEvent(this, new OSVRSTADataSet.OSVRSTARowChangeEvent((OSVRSTADataSet.OSVRSTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.OSVRSTARowDeleted != null)
                {
                    OSVRSTADataSet.OSVRSTARowChangeEventHandler oSVRSTARowDeletedEvent = this.OSVRSTARowDeleted;
                    if (oSVRSTARowDeletedEvent != null)
                    {
                        oSVRSTARowDeletedEvent(this, new OSVRSTADataSet.OSVRSTARowChangeEvent((OSVRSTADataSet.OSVRSTARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.OSVRSTARowDeleting != null)
                {
                    OSVRSTADataSet.OSVRSTARowChangeEventHandler oSVRSTARowDeletingEvent = this.OSVRSTARowDeleting;
                    if (oSVRSTARowDeletingEvent != null)
                    {
                        oSVRSTARowDeletingEvent(this, new OSVRSTADataSet.OSVRSTARowChangeEvent((OSVRSTADataSet.OSVRSTARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveOSVRSTARow(OSVRSTADataSet.OSVRSTARow row)
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

            public DataColumn IDOSVRSTAColumn
            {
                get
                {
                    return this.columnIDOSVRSTA;
                }
            }

            public OSVRSTADataSet.OSVRSTARow this[int index]
            {
                get
                {
                    return (OSVRSTADataSet.OSVRSTARow) this.Rows[index];
                }
            }

            public DataColumn OPISOSVRSTAColumn
            {
                get
                {
                    return this.columnOPISOSVRSTA;
                }
            }

            public DataColumn OSVColumn
            {
                get
                {
                    return this.columnOSV;
                }
            }
        }

        public class OSVRSTARow : DataRow
        {
            private OSVRSTADataSet.OSVRSTADataTable tableOSVRSTA;

            internal OSVRSTARow(DataRowBuilder rb) : base(rb)
            {
                this.tableOSVRSTA = (OSVRSTADataSet.OSVRSTADataTable) this.Table;
            }

            public bool IsIDOSVRSTANull()
            {
                return this.IsNull(this.tableOSVRSTA.IDOSVRSTAColumn);
            }

            public bool IsOPISOSVRSTANull()
            {
                return this.IsNull(this.tableOSVRSTA.OPISOSVRSTAColumn);
            }

            public bool IsOSVNull()
            {
                return this.IsNull(this.tableOSVRSTA.OSVColumn);
            }

            public void SetOPISOSVRSTANull()
            {
                this[this.tableOSVRSTA.OPISOSVRSTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOSVNull()
            {
                this[this.tableOSVRSTA.OSVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDOSVRSTA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableOSVRSTA.IDOSVRSTAColumn]);
                }
                set
                {
                    this[this.tableOSVRSTA.IDOSVRSTAColumn] = value;
                }
            }

            public string OPISOSVRSTA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSVRSTA.OPISOSVRSTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPISOSVRSTA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSVRSTA.OPISOSVRSTAColumn] = value;
                }
            }

            public string OSV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableOSVRSTA.OSVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OSV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableOSVRSTA.OSVColumn] = value;
                }
            }
        }

        public class OSVRSTARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private OSVRSTADataSet.OSVRSTARow eventRow;

            public OSVRSTARowChangeEvent(OSVRSTADataSet.OSVRSTARow row, DataRowAction action)
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

            public OSVRSTADataSet.OSVRSTARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void OSVRSTARowChangeEventHandler(object sender, OSVRSTADataSet.OSVRSTARowChangeEvent e);
    }
}

