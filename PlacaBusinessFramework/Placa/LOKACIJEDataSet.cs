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
    public class LOKACIJEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private LOKACIJEDataTable tableLOKACIJE;

        public LOKACIJEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected LOKACIJEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["LOKACIJE"] != null)
                    {
                        this.Tables.Add(new LOKACIJEDataTable(dataSet.Tables["LOKACIJE"]));
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
            LOKACIJEDataSet set = (LOKACIJEDataSet) base.Clone();
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
            LOKACIJEDataSet set = new LOKACIJEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "LOKACIJEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2140");
            this.ExtendedProperties.Add("DataSetName", "LOKACIJEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ILOKACIJEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "LOKACIJE");
            this.ExtendedProperties.Add("ObjectDescription", "Lokacije OS-a i SI-a");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\OSNOVNA");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "LOK");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "LOKACIJEDataSet";
            this.Namespace = "http://www.tempuri.org/LOKACIJE";
            this.tableLOKACIJE = new LOKACIJEDataTable();
            this.Tables.Add(this.tableLOKACIJE);
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
            this.tableLOKACIJE = (LOKACIJEDataTable) this.Tables["LOKACIJE"];
            if (initTable && (this.tableLOKACIJE != null))
            {
                this.tableLOKACIJE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["LOKACIJE"] != null)
                {
                    this.Tables.Add(new LOKACIJEDataTable(dataSet.Tables["LOKACIJE"]));
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

        private bool ShouldSerializeLOKACIJE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LOKACIJEDataTable LOKACIJE
        {
            get
            {
                return this.tableLOKACIJE;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]


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
        public new  DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable]
        public class LOKACIJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDLOKACIJE;
            private DataColumn columnLOK;
            private DataColumn columnOPISLOKACIJE;

            public event LOKACIJEDataSet.LOKACIJERowChangeEventHandler LOKACIJERowChanged;

            public event LOKACIJEDataSet.LOKACIJERowChangeEventHandler LOKACIJERowChanging;

            public event LOKACIJEDataSet.LOKACIJERowChangeEventHandler LOKACIJERowDeleted;

            public event LOKACIJEDataSet.LOKACIJERowChangeEventHandler LOKACIJERowDeleting;

            public LOKACIJEDataTable()
            {
                this.TableName = "LOKACIJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal LOKACIJEDataTable(DataTable table) : base(table.TableName)
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

            protected LOKACIJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddLOKACIJERow(LOKACIJEDataSet.LOKACIJERow row)
            {
                this.Rows.Add(row);
            }

            public LOKACIJEDataSet.LOKACIJERow AddLOKACIJERow(int iDLOKACIJE, string oPISLOKACIJE)
            {
                LOKACIJEDataSet.LOKACIJERow row = (LOKACIJEDataSet.LOKACIJERow) this.NewRow();
                row["IDLOKACIJE"] = iDLOKACIJE;
                row["OPISLOKACIJE"] = oPISLOKACIJE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                LOKACIJEDataSet.LOKACIJEDataTable table = (LOKACIJEDataSet.LOKACIJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public LOKACIJEDataSet.LOKACIJERow FindByIDLOKACIJE(int iDLOKACIJE)
            {
                return (LOKACIJEDataSet.LOKACIJERow) this.Rows.Find(new object[] { iDLOKACIJE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(LOKACIJEDataSet.LOKACIJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                LOKACIJEDataSet set = new LOKACIJEDataSet();
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
                this.columnIDLOKACIJE = new DataColumn("IDLOKACIJE", typeof(int), "", MappingType.Element);
                this.columnIDLOKACIJE.AllowDBNull = false;
                this.columnIDLOKACIJE.Caption = "Šif.lok.";
                this.columnIDLOKACIJE.Unique = true;
                this.columnIDLOKACIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDLOKACIJE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Description", "Šfr.");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Length", "5");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDLOKACIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDLOKACIJE.ExtendedProperties.Add("Deklarit.InternalName", "IDLOKACIJE");
                this.Columns.Add(this.columnIDLOKACIJE);
                this.columnOPISLOKACIJE = new DataColumn("OPISLOKACIJE", typeof(string), "", MappingType.Element);
                this.columnOPISLOKACIJE.AllowDBNull = false;
                this.columnOPISLOKACIJE.Caption = "Naz. lok.";
                this.columnOPISLOKACIJE.MaxLength = 50;
                this.columnOPISLOKACIJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Description", "Opis");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Length", "50");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISLOKACIJE.ExtendedProperties.Add("Deklarit.InternalName", "OPISLOKACIJE");
                this.Columns.Add(this.columnOPISLOKACIJE);
                this.columnLOK = new DataColumn("LOK", typeof(string), "", MappingType.Element);
                this.columnLOK.AllowDBNull = true;
                this.columnLOK.Caption = "LOK";
                this.columnLOK.MaxLength = 60;
                this.columnLOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnLOK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnLOK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnLOK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnLOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnLOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnLOK.ExtendedProperties.Add("IsKey", "false");
                this.columnLOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnLOK.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnLOK.ExtendedProperties.Add("Description", "LOK");
                this.columnLOK.ExtendedProperties.Add("Length", "60");
                this.columnLOK.ExtendedProperties.Add("Decimals", "0");
                this.columnLOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnLOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnLOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnLOK.ExtendedProperties.Add("Deklarit.InternalName", "LOK");
                this.Columns.Add(this.columnLOK);
                this.PrimaryKey = new DataColumn[] { this.columnIDLOKACIJE };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "LOKACIJE");
                this.ExtendedProperties.Add("Description", "Lokacije OS-a i SI-a");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDLOKACIJE = this.Columns["IDLOKACIJE"];
                this.columnOPISLOKACIJE = this.Columns["OPISLOKACIJE"];
                this.columnLOK = this.Columns["LOK"];
            }

            public LOKACIJEDataSet.LOKACIJERow NewLOKACIJERow()
            {
                return (LOKACIJEDataSet.LOKACIJERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new LOKACIJEDataSet.LOKACIJERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.LOKACIJERowChanged != null)
                {
                    LOKACIJEDataSet.LOKACIJERowChangeEventHandler lOKACIJERowChangedEvent = this.LOKACIJERowChanged;
                    if (lOKACIJERowChangedEvent != null)
                    {
                        lOKACIJERowChangedEvent(this, new LOKACIJEDataSet.LOKACIJERowChangeEvent((LOKACIJEDataSet.LOKACIJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.LOKACIJERowChanging != null)
                {
                    LOKACIJEDataSet.LOKACIJERowChangeEventHandler lOKACIJERowChangingEvent = this.LOKACIJERowChanging;
                    if (lOKACIJERowChangingEvent != null)
                    {
                        lOKACIJERowChangingEvent(this, new LOKACIJEDataSet.LOKACIJERowChangeEvent((LOKACIJEDataSet.LOKACIJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.LOKACIJERowDeleted != null)
                {
                    LOKACIJEDataSet.LOKACIJERowChangeEventHandler lOKACIJERowDeletedEvent = this.LOKACIJERowDeleted;
                    if (lOKACIJERowDeletedEvent != null)
                    {
                        lOKACIJERowDeletedEvent(this, new LOKACIJEDataSet.LOKACIJERowChangeEvent((LOKACIJEDataSet.LOKACIJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.LOKACIJERowDeleting != null)
                {
                    LOKACIJEDataSet.LOKACIJERowChangeEventHandler lOKACIJERowDeletingEvent = this.LOKACIJERowDeleting;
                    if (lOKACIJERowDeletingEvent != null)
                    {
                        lOKACIJERowDeletingEvent(this, new LOKACIJEDataSet.LOKACIJERowChangeEvent((LOKACIJEDataSet.LOKACIJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveLOKACIJERow(LOKACIJEDataSet.LOKACIJERow row)
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

            public DataColumn IDLOKACIJEColumn
            {
                get
                {
                    return this.columnIDLOKACIJE;
                }
            }

            public LOKACIJEDataSet.LOKACIJERow this[int index]
            {
                get
                {
                    return (LOKACIJEDataSet.LOKACIJERow) this.Rows[index];
                }
            }

            public DataColumn LOKColumn
            {
                get
                {
                    return this.columnLOK;
                }
            }

            public DataColumn OPISLOKACIJEColumn
            {
                get
                {
                    return this.columnOPISLOKACIJE;
                }
            }
        }

        public class LOKACIJERow : DataRow
        {
            private LOKACIJEDataSet.LOKACIJEDataTable tableLOKACIJE;

            internal LOKACIJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableLOKACIJE = (LOKACIJEDataSet.LOKACIJEDataTable) this.Table;
            }

            public bool IsIDLOKACIJENull()
            {
                return this.IsNull(this.tableLOKACIJE.IDLOKACIJEColumn);
            }

            public bool IsLOKNull()
            {
                return this.IsNull(this.tableLOKACIJE.LOKColumn);
            }

            public bool IsOPISLOKACIJENull()
            {
                return this.IsNull(this.tableLOKACIJE.OPISLOKACIJEColumn);
            }

            public void SetLOKNull()
            {
                this[this.tableLOKACIJE.LOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISLOKACIJENull()
            {
                this[this.tableLOKACIJE.OPISLOKACIJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDLOKACIJE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableLOKACIJE.IDLOKACIJEColumn]);
                }
                set
                {
                    this[this.tableLOKACIJE.IDLOKACIJEColumn] = value;
                }
            }

            public string LOK
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableLOKACIJE.LOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value LOK because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableLOKACIJE.LOKColumn] = value;
                }
            }

            public string OPISLOKACIJE
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableLOKACIJE.OPISLOKACIJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value OPISLOKACIJE because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableLOKACIJE.OPISLOKACIJEColumn] = value;
                }
            }
        }

        public class LOKACIJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private LOKACIJEDataSet.LOKACIJERow eventRow;

            public LOKACIJERowChangeEvent(LOKACIJEDataSet.LOKACIJERow row, DataRowAction action)
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

            public LOKACIJEDataSet.LOKACIJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void LOKACIJERowChangeEventHandler(object sender, LOKACIJEDataSet.LOKACIJERowChangeEvent e);
    }
}

