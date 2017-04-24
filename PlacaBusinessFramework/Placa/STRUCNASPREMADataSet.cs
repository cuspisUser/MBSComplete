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
    public class STRUCNASPREMADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private STRUCNASPREMADataTable tableSTRUCNASPREMA;

        public STRUCNASPREMADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected STRUCNASPREMADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["STRUCNASPREMA"] != null)
                    {
                        this.Tables.Add(new STRUCNASPREMADataTable(dataSet.Tables["STRUCNASPREMA"]));
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
            STRUCNASPREMADataSet set = (STRUCNASPREMADataSet) base.Clone();
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
            STRUCNASPREMADataSet set = new STRUCNASPREMADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "STRUCNASPREMADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1023");
            this.ExtendedProperties.Add("DataSetName", "STRUCNASPREMADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISTRUCNASPREMADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "STRUCNASPREMA");
            this.ExtendedProperties.Add("ObjectDescription", "Struene spreme");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVSTRUCNASPREMA");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "STRUCNASPREMADataSet";
            this.Namespace = "http://www.tempuri.org/STRUCNASPREMA";
            this.tableSTRUCNASPREMA = new STRUCNASPREMADataTable();
            this.Tables.Add(this.tableSTRUCNASPREMA);
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
            this.tableSTRUCNASPREMA = (STRUCNASPREMADataTable) this.Tables["STRUCNASPREMA"];
            if (initTable && (this.tableSTRUCNASPREMA != null))
            {
                this.tableSTRUCNASPREMA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["STRUCNASPREMA"] != null)
                {
                    this.Tables.Add(new STRUCNASPREMADataTable(dataSet.Tables["STRUCNASPREMA"]));
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

        private bool ShouldSerializeSTRUCNASPREMA()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public STRUCNASPREMADataTable STRUCNASPREMA
        {
            get
            {
                return this.tableSTRUCNASPREMA;
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
        public class STRUCNASPREMADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSTRUCNASPREMA;
            private DataColumn columnNAZIVSTRUCNASPREMA;

            public event STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler STRUCNASPREMARowChanged;

            public event STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler STRUCNASPREMARowChanging;

            public event STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler STRUCNASPREMARowDeleted;

            public event STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler STRUCNASPREMARowDeleting;

            public STRUCNASPREMADataTable()
            {
                this.TableName = "STRUCNASPREMA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal STRUCNASPREMADataTable(DataTable table) : base(table.TableName)
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

            protected STRUCNASPREMADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSTRUCNASPREMARow(STRUCNASPREMADataSet.STRUCNASPREMARow row)
            {
                this.Rows.Add(row);
            }

            public STRUCNASPREMADataSet.STRUCNASPREMARow AddSTRUCNASPREMARow(int iDSTRUCNASPREMA, string nAZIVSTRUCNASPREMA)
            {
                STRUCNASPREMADataSet.STRUCNASPREMARow row = (STRUCNASPREMADataSet.STRUCNASPREMARow) this.NewRow();
                row["IDSTRUCNASPREMA"] = iDSTRUCNASPREMA;
                row["NAZIVSTRUCNASPREMA"] = nAZIVSTRUCNASPREMA;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                STRUCNASPREMADataSet.STRUCNASPREMADataTable table = (STRUCNASPREMADataSet.STRUCNASPREMADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public STRUCNASPREMADataSet.STRUCNASPREMARow FindByIDSTRUCNASPREMA(int iDSTRUCNASPREMA)
            {
                return (STRUCNASPREMADataSet.STRUCNASPREMARow) this.Rows.Find(new object[] { iDSTRUCNASPREMA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(STRUCNASPREMADataSet.STRUCNASPREMARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                STRUCNASPREMADataSet set = new STRUCNASPREMADataSet();
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
                this.columnIDSTRUCNASPREMA = new DataColumn("IDSTRUCNASPREMA", typeof(int), "", MappingType.Element);
                this.columnIDSTRUCNASPREMA.AllowDBNull = false;
                this.columnIDSTRUCNASPREMA.Caption = "Šifra stručne spreme";
                this.columnIDSTRUCNASPREMA.Unique = true;
                this.columnIDSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Description", "Šifra stručne spreme");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Length", "5");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "IDSTRUCNASPREMA");
                this.Columns.Add(this.columnIDSTRUCNASPREMA);
                this.columnNAZIVSTRUCNASPREMA = new DataColumn("NAZIVSTRUCNASPREMA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSTRUCNASPREMA.AllowDBNull = false;
                this.columnNAZIVSTRUCNASPREMA.Caption = "Naziv stručne spreme";
                this.columnNAZIVSTRUCNASPREMA.MaxLength = 50;
                this.columnNAZIVSTRUCNASPREMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Description", "Naziv stručne spreme");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSTRUCNASPREMA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSTRUCNASPREMA");
                this.Columns.Add(this.columnNAZIVSTRUCNASPREMA);
                this.PrimaryKey = new DataColumn[] { this.columnIDSTRUCNASPREMA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "STRUCNASPREMA");
                this.ExtendedProperties.Add("Description", "Struene spreme");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSTRUCNASPREMA = this.Columns["IDSTRUCNASPREMA"];
                this.columnNAZIVSTRUCNASPREMA = this.Columns["NAZIVSTRUCNASPREMA"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new STRUCNASPREMADataSet.STRUCNASPREMARow(builder);
            }

            public STRUCNASPREMADataSet.STRUCNASPREMARow NewSTRUCNASPREMARow()
            {
                return (STRUCNASPREMADataSet.STRUCNASPREMARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.STRUCNASPREMARowChanged != null)
                {
                    STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler sTRUCNASPREMARowChangedEvent = this.STRUCNASPREMARowChanged;
                    if (sTRUCNASPREMARowChangedEvent != null)
                    {
                        sTRUCNASPREMARowChangedEvent(this, new STRUCNASPREMADataSet.STRUCNASPREMARowChangeEvent((STRUCNASPREMADataSet.STRUCNASPREMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.STRUCNASPREMARowChanging != null)
                {
                    STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler sTRUCNASPREMARowChangingEvent = this.STRUCNASPREMARowChanging;
                    if (sTRUCNASPREMARowChangingEvent != null)
                    {
                        sTRUCNASPREMARowChangingEvent(this, new STRUCNASPREMADataSet.STRUCNASPREMARowChangeEvent((STRUCNASPREMADataSet.STRUCNASPREMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.STRUCNASPREMARowDeleted != null)
                {
                    STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler sTRUCNASPREMARowDeletedEvent = this.STRUCNASPREMARowDeleted;
                    if (sTRUCNASPREMARowDeletedEvent != null)
                    {
                        sTRUCNASPREMARowDeletedEvent(this, new STRUCNASPREMADataSet.STRUCNASPREMARowChangeEvent((STRUCNASPREMADataSet.STRUCNASPREMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.STRUCNASPREMARowDeleting != null)
                {
                    STRUCNASPREMADataSet.STRUCNASPREMARowChangeEventHandler sTRUCNASPREMARowDeletingEvent = this.STRUCNASPREMARowDeleting;
                    if (sTRUCNASPREMARowDeletingEvent != null)
                    {
                        sTRUCNASPREMARowDeletingEvent(this, new STRUCNASPREMADataSet.STRUCNASPREMARowChangeEvent((STRUCNASPREMADataSet.STRUCNASPREMARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSTRUCNASPREMARow(STRUCNASPREMADataSet.STRUCNASPREMARow row)
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

            public DataColumn IDSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnIDSTRUCNASPREMA;
                }
            }

            public STRUCNASPREMADataSet.STRUCNASPREMARow this[int index]
            {
                get
                {
                    return (STRUCNASPREMADataSet.STRUCNASPREMARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSTRUCNASPREMAColumn
            {
                get
                {
                    return this.columnNAZIVSTRUCNASPREMA;
                }
            }
        }

        public class STRUCNASPREMARow : DataRow
        {
            private STRUCNASPREMADataSet.STRUCNASPREMADataTable tableSTRUCNASPREMA;

            internal STRUCNASPREMARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSTRUCNASPREMA = (STRUCNASPREMADataSet.STRUCNASPREMADataTable) this.Table;
            }

            public bool IsIDSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableSTRUCNASPREMA.IDSTRUCNASPREMAColumn);
            }

            public bool IsNAZIVSTRUCNASPREMANull()
            {
                return this.IsNull(this.tableSTRUCNASPREMA.NAZIVSTRUCNASPREMAColumn);
            }

            public void SetNAZIVSTRUCNASPREMANull()
            {
                this[this.tableSTRUCNASPREMA.NAZIVSTRUCNASPREMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSTRUCNASPREMA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSTRUCNASPREMA.IDSTRUCNASPREMAColumn]);
                }
                set
                {
                    this[this.tableSTRUCNASPREMA.IDSTRUCNASPREMAColumn] = value;
                }
            }

            public string NAZIVSTRUCNASPREMA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSTRUCNASPREMA.NAZIVSTRUCNASPREMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSTRUCNASPREMA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSTRUCNASPREMA.NAZIVSTRUCNASPREMAColumn] = value;
                }
            }
        }

        public class STRUCNASPREMARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private STRUCNASPREMADataSet.STRUCNASPREMARow eventRow;

            public STRUCNASPREMARowChangeEvent(STRUCNASPREMADataSet.STRUCNASPREMARow row, DataRowAction action)
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

            public STRUCNASPREMADataSet.STRUCNASPREMARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void STRUCNASPREMARowChangeEventHandler(object sender, STRUCNASPREMADataSet.STRUCNASPREMARowChangeEvent e);
    }
}

