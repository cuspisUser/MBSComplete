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
    public class AKTIVNOSTDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private AKTIVNOSTDataTable tableAKTIVNOST;

        public AKTIVNOSTDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected AKTIVNOSTDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["AKTIVNOST"] != null)
                    {
                        this.Tables.Add(new AKTIVNOSTDataTable(dataSet.Tables["AKTIVNOST"]));
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
            AKTIVNOSTDataSet set = (AKTIVNOSTDataSet) base.Clone();
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
            AKTIVNOSTDataSet set = new AKTIVNOSTDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "AKTIVNOSTDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1031");
            this.ExtendedProperties.Add("DataSetName", "AKTIVNOSTDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IAKTIVNOSTDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "AKTIVNOST");
            this.ExtendedProperties.Add("ObjectDescription", "Aktivnosti konta");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "False");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "NAZIVAKTIVNOST");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "AKTIVNOSTDataSet";
            this.Namespace = "http://www.tempuri.org/AKTIVNOST";
            this.tableAKTIVNOST = new AKTIVNOSTDataTable();
            this.Tables.Add(this.tableAKTIVNOST);
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
            this.tableAKTIVNOST = (AKTIVNOSTDataTable) this.Tables["AKTIVNOST"];
            if (initTable && (this.tableAKTIVNOST != null))
            {
                this.tableAKTIVNOST.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["AKTIVNOST"] != null)
                {
                    this.Tables.Add(new AKTIVNOSTDataTable(dataSet.Tables["AKTIVNOST"]));
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

        private bool ShouldSerializeAKTIVNOST()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AKTIVNOSTDataTable AKTIVNOST
        {
            get
            {
                return this.tableAKTIVNOST;
            }
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

        [Serializable]
        public class AKTIVNOSTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDAKTIVNOST;
            private DataColumn columnNAZIVAKTIVNOST;

            public event AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler AKTIVNOSTRowChanged;

            public event AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler AKTIVNOSTRowChanging;

            public event AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler AKTIVNOSTRowDeleted;

            public event AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler AKTIVNOSTRowDeleting;

            public AKTIVNOSTDataTable()
            {
                this.TableName = "AKTIVNOST";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal AKTIVNOSTDataTable(DataTable table) : base(table.TableName)
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

            protected AKTIVNOSTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddAKTIVNOSTRow(AKTIVNOSTDataSet.AKTIVNOSTRow row)
            {
                this.Rows.Add(row);
            }

            public AKTIVNOSTDataSet.AKTIVNOSTRow AddAKTIVNOSTRow(int iDAKTIVNOST, string nAZIVAKTIVNOST)
            {
                AKTIVNOSTDataSet.AKTIVNOSTRow row = (AKTIVNOSTDataSet.AKTIVNOSTRow) this.NewRow();
                row["IDAKTIVNOST"] = iDAKTIVNOST;
                row["NAZIVAKTIVNOST"] = nAZIVAKTIVNOST;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                AKTIVNOSTDataSet.AKTIVNOSTDataTable table = (AKTIVNOSTDataSet.AKTIVNOSTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public AKTIVNOSTDataSet.AKTIVNOSTRow FindByIDAKTIVNOST(int iDAKTIVNOST)
            {
                return (AKTIVNOSTDataSet.AKTIVNOSTRow) this.Rows.Find(new object[] { iDAKTIVNOST });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(AKTIVNOSTDataSet.AKTIVNOSTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                AKTIVNOSTDataSet set = new AKTIVNOSTDataSet();
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
                this.columnIDAKTIVNOST = new DataColumn("IDAKTIVNOST", typeof(int), "", MappingType.Element);
                this.columnIDAKTIVNOST.AllowDBNull = false;
                this.columnIDAKTIVNOST.Caption = "Šifra aktivnosti";
                this.columnIDAKTIVNOST.Unique = true;
                this.columnIDAKTIVNOST.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("IsKey", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Description", "Šifra aktivnosti");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Length", "6");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDAKTIVNOST.ExtendedProperties.Add("Deklarit.InternalName", "IDAKTIVNOST");
                this.Columns.Add(this.columnIDAKTIVNOST);
                this.columnNAZIVAKTIVNOST = new DataColumn("NAZIVAKTIVNOST", typeof(string), "", MappingType.Element);
                this.columnNAZIVAKTIVNOST.AllowDBNull = false;
                this.columnNAZIVAKTIVNOST.Caption = "Naziv aktivnosti";
                this.columnNAZIVAKTIVNOST.MaxLength = 50;
                this.columnNAZIVAKTIVNOST.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Description", "Naziv aktivnosti");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVAKTIVNOST.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVAKTIVNOST");
                this.Columns.Add(this.columnNAZIVAKTIVNOST);
                this.PrimaryKey = new DataColumn[] { this.columnIDAKTIVNOST };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "AKTIVNOST");
                this.ExtendedProperties.Add("Description", "Aktivnosti konta");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDAKTIVNOST = this.Columns["IDAKTIVNOST"];
                this.columnNAZIVAKTIVNOST = this.Columns["NAZIVAKTIVNOST"];
            }

            public AKTIVNOSTDataSet.AKTIVNOSTRow NewAKTIVNOSTRow()
            {
                return (AKTIVNOSTDataSet.AKTIVNOSTRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new AKTIVNOSTDataSet.AKTIVNOSTRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.AKTIVNOSTRowChanged != null)
                {
                    AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler aKTIVNOSTRowChangedEvent = this.AKTIVNOSTRowChanged;
                    if (aKTIVNOSTRowChangedEvent != null)
                    {
                        aKTIVNOSTRowChangedEvent(this, new AKTIVNOSTDataSet.AKTIVNOSTRowChangeEvent((AKTIVNOSTDataSet.AKTIVNOSTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.AKTIVNOSTRowChanging != null)
                {
                    AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler aKTIVNOSTRowChangingEvent = this.AKTIVNOSTRowChanging;
                    if (aKTIVNOSTRowChangingEvent != null)
                    {
                        aKTIVNOSTRowChangingEvent(this, new AKTIVNOSTDataSet.AKTIVNOSTRowChangeEvent((AKTIVNOSTDataSet.AKTIVNOSTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.AKTIVNOSTRowDeleted != null)
                {
                    AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler aKTIVNOSTRowDeletedEvent = this.AKTIVNOSTRowDeleted;
                    if (aKTIVNOSTRowDeletedEvent != null)
                    {
                        aKTIVNOSTRowDeletedEvent(this, new AKTIVNOSTDataSet.AKTIVNOSTRowChangeEvent((AKTIVNOSTDataSet.AKTIVNOSTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.AKTIVNOSTRowDeleting != null)
                {
                    AKTIVNOSTDataSet.AKTIVNOSTRowChangeEventHandler aKTIVNOSTRowDeletingEvent = this.AKTIVNOSTRowDeleting;
                    if (aKTIVNOSTRowDeletingEvent != null)
                    {
                        aKTIVNOSTRowDeletingEvent(this, new AKTIVNOSTDataSet.AKTIVNOSTRowChangeEvent((AKTIVNOSTDataSet.AKTIVNOSTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveAKTIVNOSTRow(AKTIVNOSTDataSet.AKTIVNOSTRow row)
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

            public DataColumn IDAKTIVNOSTColumn
            {
                get
                {
                    return this.columnIDAKTIVNOST;
                }
            }

            public AKTIVNOSTDataSet.AKTIVNOSTRow this[int index]
            {
                get
                {
                    return (AKTIVNOSTDataSet.AKTIVNOSTRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVAKTIVNOSTColumn
            {
                get
                {
                    return this.columnNAZIVAKTIVNOST;
                }
            }
        }

        public class AKTIVNOSTRow : DataRow
        {
            private AKTIVNOSTDataSet.AKTIVNOSTDataTable tableAKTIVNOST;

            internal AKTIVNOSTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableAKTIVNOST = (AKTIVNOSTDataSet.AKTIVNOSTDataTable) this.Table;
            }

            public bool IsIDAKTIVNOSTNull()
            {
                return this.IsNull(this.tableAKTIVNOST.IDAKTIVNOSTColumn);
            }

            public bool IsNAZIVAKTIVNOSTNull()
            {
                return this.IsNull(this.tableAKTIVNOST.NAZIVAKTIVNOSTColumn);
            }

            public void SetNAZIVAKTIVNOSTNull()
            {
                this[this.tableAKTIVNOST.NAZIVAKTIVNOSTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDAKTIVNOST
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableAKTIVNOST.IDAKTIVNOSTColumn]);
                }
                set
                {
                    this[this.tableAKTIVNOST.IDAKTIVNOSTColumn] = value;
                }
            }

            public string NAZIVAKTIVNOST
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableAKTIVNOST.NAZIVAKTIVNOSTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVAKTIVNOST because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableAKTIVNOST.NAZIVAKTIVNOSTColumn] = value;
                }
            }
        }

        public class AKTIVNOSTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private AKTIVNOSTDataSet.AKTIVNOSTRow eventRow;

            public AKTIVNOSTRowChangeEvent(AKTIVNOSTDataSet.AKTIVNOSTRow row, DataRowAction action)
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

            public AKTIVNOSTDataSet.AKTIVNOSTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void AKTIVNOSTRowChangeEventHandler(object sender, AKTIVNOSTDataSet.AKTIVNOSTRowChangeEvent e);
    }
}

