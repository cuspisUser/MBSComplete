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
    public class ORGJEDDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ORGJEDDataTable tableORGJED;

        public ORGJEDDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected ORGJEDDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ORGJED"] != null)
                    {
                        this.Tables.Add(new ORGJEDDataTable(dataSet.Tables["ORGJED"]));
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
            ORGJEDDataSet set = (ORGJEDDataSet) base.Clone();
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
            ORGJEDDataSet set = new ORGJEDDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "ORGJEDDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1012");
            this.ExtendedProperties.Add("DataSetName", "ORGJEDDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IORGJEDDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "ORGJED");
            this.ExtendedProperties.Add("ObjectDescription", "Organizacijske jedinice");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "AlmostNever");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "oj");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "ORGJEDDataSet";
            this.Namespace = "http://www.tempuri.org/ORGJED";
            this.tableORGJED = new ORGJEDDataTable();
            this.Tables.Add(this.tableORGJED);
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
            this.tableORGJED = (ORGJEDDataTable) this.Tables["ORGJED"];
            if (initTable && (this.tableORGJED != null))
            {
                this.tableORGJED.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ORGJED"] != null)
                {
                    this.Tables.Add(new ORGJEDDataTable(dataSet.Tables["ORGJED"]));
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

        private bool ShouldSerializeORGJED()
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
        public ORGJEDDataTable ORGJED
        {
            get
            {
                return this.tableORGJED;
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
        public class ORGJEDDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDORGJED;
            private DataColumn columnNAZIVORGJED;
            private DataColumn columnoj;

            public event ORGJEDDataSet.ORGJEDRowChangeEventHandler ORGJEDRowChanged;

            public event ORGJEDDataSet.ORGJEDRowChangeEventHandler ORGJEDRowChanging;

            public event ORGJEDDataSet.ORGJEDRowChangeEventHandler ORGJEDRowDeleted;

            public event ORGJEDDataSet.ORGJEDRowChangeEventHandler ORGJEDRowDeleting;

            public ORGJEDDataTable()
            {
                this.TableName = "ORGJED";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ORGJEDDataTable(DataTable table) : base(table.TableName)
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

            protected ORGJEDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddORGJEDRow(ORGJEDDataSet.ORGJEDRow row)
            {
                this.Rows.Add(row);
            }

            public ORGJEDDataSet.ORGJEDRow AddORGJEDRow(int iDORGJED, string nAZIVORGJED)
            {
                ORGJEDDataSet.ORGJEDRow row = (ORGJEDDataSet.ORGJEDRow) this.NewRow();
                row["IDORGJED"] = iDORGJED;
                row["NAZIVORGJED"] = nAZIVORGJED;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                ORGJEDDataSet.ORGJEDDataTable table = (ORGJEDDataSet.ORGJEDDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public ORGJEDDataSet.ORGJEDRow FindByIDORGJED(int iDORGJED)
            {
                return (ORGJEDDataSet.ORGJEDRow) this.Rows.Find(new object[] { iDORGJED });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(ORGJEDDataSet.ORGJEDRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                ORGJEDDataSet set = new ORGJEDDataSet();
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
                this.columnIDORGJED = new DataColumn("IDORGJED", typeof(int), "", MappingType.Element);
                this.columnIDORGJED.AllowDBNull = false;
                this.columnIDORGJED.Caption = "Šifra OJ";
                this.columnIDORGJED.Unique = true;
                this.columnIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGJED.ExtendedProperties.Add("IsKey", "true");
                this.columnIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "IDORGJED");
                this.Columns.Add(this.columnIDORGJED);
                this.columnNAZIVORGJED = new DataColumn("NAZIVORGJED", typeof(string), "", MappingType.Element);
                this.columnNAZIVORGJED.AllowDBNull = false;
                this.columnNAZIVORGJED.Caption = "Naziv OJ";
                this.columnNAZIVORGJED.MaxLength = 100;
                this.columnNAZIVORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Description", "Naziv OJ");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVORGJED.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVORGJED");
                this.Columns.Add(this.columnNAZIVORGJED);
                this.columnoj = new DataColumn("oj", typeof(string), "", MappingType.Element);
                this.columnoj.AllowDBNull = true;
                this.columnoj.Caption = "OJ";
                this.columnoj.MaxLength = 110;
                this.columnoj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnoj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnoj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnoj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnoj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnoj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnoj.ExtendedProperties.Add("IsKey", "false");
                this.columnoj.ExtendedProperties.Add("ReadOnly", "true");
                this.columnoj.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnoj.ExtendedProperties.Add("Description", "oj");
                this.columnoj.ExtendedProperties.Add("Length", "110");
                this.columnoj.ExtendedProperties.Add("Decimals", "0");
                this.columnoj.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnoj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnoj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnoj.ExtendedProperties.Add("Deklarit.InternalName", "oj");
                this.Columns.Add(this.columnoj);
                this.PrimaryKey = new DataColumn[] { this.columnIDORGJED };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "ORGJED");
                this.ExtendedProperties.Add("Description", "Organizacijske jedinice");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDORGJED = this.Columns["IDORGJED"];
                this.columnNAZIVORGJED = this.Columns["NAZIVORGJED"];
                this.columnoj = this.Columns["oj"];
            }

            public ORGJEDDataSet.ORGJEDRow NewORGJEDRow()
            {
                return (ORGJEDDataSet.ORGJEDRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ORGJEDDataSet.ORGJEDRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ORGJEDRowChanged != null)
                {
                    ORGJEDDataSet.ORGJEDRowChangeEventHandler oRGJEDRowChangedEvent = this.ORGJEDRowChanged;
                    if (oRGJEDRowChangedEvent != null)
                    {
                        oRGJEDRowChangedEvent(this, new ORGJEDDataSet.ORGJEDRowChangeEvent((ORGJEDDataSet.ORGJEDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ORGJEDRowChanging != null)
                {
                    ORGJEDDataSet.ORGJEDRowChangeEventHandler oRGJEDRowChangingEvent = this.ORGJEDRowChanging;
                    if (oRGJEDRowChangingEvent != null)
                    {
                        oRGJEDRowChangingEvent(this, new ORGJEDDataSet.ORGJEDRowChangeEvent((ORGJEDDataSet.ORGJEDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ORGJEDRowDeleted != null)
                {
                    ORGJEDDataSet.ORGJEDRowChangeEventHandler oRGJEDRowDeletedEvent = this.ORGJEDRowDeleted;
                    if (oRGJEDRowDeletedEvent != null)
                    {
                        oRGJEDRowDeletedEvent(this, new ORGJEDDataSet.ORGJEDRowChangeEvent((ORGJEDDataSet.ORGJEDRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ORGJEDRowDeleting != null)
                {
                    ORGJEDDataSet.ORGJEDRowChangeEventHandler oRGJEDRowDeletingEvent = this.ORGJEDRowDeleting;
                    if (oRGJEDRowDeletingEvent != null)
                    {
                        oRGJEDRowDeletingEvent(this, new ORGJEDDataSet.ORGJEDRowChangeEvent((ORGJEDDataSet.ORGJEDRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveORGJEDRow(ORGJEDDataSet.ORGJEDRow row)
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

            public DataColumn IDORGJEDColumn
            {
                get
                {
                    return this.columnIDORGJED;
                }
            }

            public ORGJEDDataSet.ORGJEDRow this[int index]
            {
                get
                {
                    return (ORGJEDDataSet.ORGJEDRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVORGJEDColumn
            {
                get
                {
                    return this.columnNAZIVORGJED;
                }
            }

            public DataColumn ojColumn
            {
                get
                {
                    return this.columnoj;
                }
            }
        }

        public class ORGJEDRow : DataRow
        {
            private ORGJEDDataSet.ORGJEDDataTable tableORGJED;

            internal ORGJEDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableORGJED = (ORGJEDDataSet.ORGJEDDataTable) this.Table;
            }

            public bool IsIDORGJEDNull()
            {
                return this.IsNull(this.tableORGJED.IDORGJEDColumn);
            }

            public bool IsNAZIVORGJEDNull()
            {
                return this.IsNull(this.tableORGJED.NAZIVORGJEDColumn);
            }

            public bool IsojNull()
            {
                return this.IsNull(this.tableORGJED.ojColumn);
            }

            public void SetNAZIVORGJEDNull()
            {
                this[this.tableORGJED.NAZIVORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetojNull()
            {
                this[this.tableORGJED.ojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDORGJED
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableORGJED.IDORGJEDColumn]);
                }
                set
                {
                    this[this.tableORGJED.IDORGJEDColumn] = value;
                }
            }

            public string NAZIVORGJED
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableORGJED.NAZIVORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVORGJED because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableORGJED.NAZIVORGJEDColumn] = value;
                }
            }

            public string oj
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableORGJED.ojColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value oj because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableORGJED.ojColumn] = value;
                }
            }
        }

        public class ORGJEDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private ORGJEDDataSet.ORGJEDRow eventRow;

            public ORGJEDRowChangeEvent(ORGJEDDataSet.ORGJEDRow row, DataRowAction action)
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

            public ORGJEDDataSet.ORGJEDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ORGJEDRowChangeEventHandler(object sender, ORGJEDDataSet.ORGJEDRowChangeEvent e);
    }
}

