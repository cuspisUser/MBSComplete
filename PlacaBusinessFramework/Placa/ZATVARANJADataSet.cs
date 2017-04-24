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
    public class ZATVARANJADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ZATVARANJADataTable tableZATVARANJA;

        public ZATVARANJADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected ZATVARANJADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ZATVARANJA"] != null)
                    {
                        this.Tables.Add(new ZATVARANJADataTable(dataSet.Tables["ZATVARANJA"]));
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
            ZATVARANJADataSet set = (ZATVARANJADataSet) base.Clone();
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
            ZATVARANJADataSet set = new ZATVARANJADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "ZATVARANJADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "1107");
            this.ExtendedProperties.Add("DataSetName", "ZATVARANJADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IZATVARANJADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "ZATVARANJA");
            this.ExtendedProperties.Add("ObjectDescription", "ZATVARANJA");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
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
            this.DataSetName = "ZATVARANJADataSet";
            this.Namespace = "http://www.tempuri.org/ZATVARANJA";
            this.tableZATVARANJA = new ZATVARANJADataTable();
            this.Tables.Add(this.tableZATVARANJA);
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
            this.tableZATVARANJA = (ZATVARANJADataTable) this.Tables["ZATVARANJA"];
            if (initTable && (this.tableZATVARANJA != null))
            {
                this.tableZATVARANJA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ZATVARANJA"] != null)
                {
                    this.Tables.Add(new ZATVARANJADataTable(dataSet.Tables["ZATVARANJA"]));
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

        private bool ShouldSerializeZATVARANJA()
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
        public ZATVARANJADataTable ZATVARANJA
        {
            get
            {
                return this.tableZATVARANJA;
            }
        }

        [Serializable]
        public class ZATVARANJADataTable : DataTable, IEnumerable
        {
            private DataColumn columnGK1IDGKSTAVKA;
            private DataColumn columnGK2IDGKSTAVKA;
            private DataColumn columnZATVARANJAIZNOS;

            public event ZATVARANJADataSet.ZATVARANJARowChangeEventHandler ZATVARANJARowChanged;

            public event ZATVARANJADataSet.ZATVARANJARowChangeEventHandler ZATVARANJARowChanging;

            public event ZATVARANJADataSet.ZATVARANJARowChangeEventHandler ZATVARANJARowDeleted;

            public event ZATVARANJADataSet.ZATVARANJARowChangeEventHandler ZATVARANJARowDeleting;

            public ZATVARANJADataTable()
            {
                this.TableName = "ZATVARANJA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal ZATVARANJADataTable(DataTable table) : base(table.TableName)
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

            protected ZATVARANJADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddZATVARANJARow(ZATVARANJADataSet.ZATVARANJARow row)
            {
                this.Rows.Add(row);
            }

            public ZATVARANJADataSet.ZATVARANJARow AddZATVARANJARow(int gK1IDGKSTAVKA, int gK2IDGKSTAVKA, decimal zATVARANJAIZNOS)
            {
                ZATVARANJADataSet.ZATVARANJARow row = (ZATVARANJADataSet.ZATVARANJARow) this.NewRow();
                row["GK1IDGKSTAVKA"] = gK1IDGKSTAVKA;
                row["GK2IDGKSTAVKA"] = gK2IDGKSTAVKA;
                row["ZATVARANJAIZNOS"] = zATVARANJAIZNOS;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                ZATVARANJADataSet.ZATVARANJADataTable table = (ZATVARANJADataSet.ZATVARANJADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public ZATVARANJADataSet.ZATVARANJARow FindByGK1IDGKSTAVKAGK2IDGKSTAVKA(int gK1IDGKSTAVKA, int gK2IDGKSTAVKA)
            {
                return (ZATVARANJADataSet.ZATVARANJARow) this.Rows.Find(new object[] { gK1IDGKSTAVKA, gK2IDGKSTAVKA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(ZATVARANJADataSet.ZATVARANJARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                ZATVARANJADataSet set = new ZATVARANJADataSet();
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
                this.columnGK1IDGKSTAVKA = new DataColumn("GK1IDGKSTAVKA", typeof(int), "", MappingType.Element);
                this.columnGK1IDGKSTAVKA.AllowDBNull = false;
                this.columnGK1IDGKSTAVKA.Caption = "IDGKSTAVKA";
                this.columnGK1IDGKSTAVKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("SuperType", "IDGKSTAVKA");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("SubtypeGroup", "GK1");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("IsKey", "true");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Description", "IDGKSTAVKA");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Length", "5");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Decimals", "0");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGK1IDGKSTAVKA.ExtendedProperties.Add("Deklarit.InternalName", "GK1IDGKSTAVKA");
                this.Columns.Add(this.columnGK1IDGKSTAVKA);
                this.columnGK2IDGKSTAVKA = new DataColumn("GK2IDGKSTAVKA", typeof(int), "", MappingType.Element);
                this.columnGK2IDGKSTAVKA.AllowDBNull = false;
                this.columnGK2IDGKSTAVKA.Caption = "IDGKSTAVKA";
                this.columnGK2IDGKSTAVKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("SuperType", "IDGKSTAVKA");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("SubtypeGroup", "GK2");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("IsKey", "true");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Description", "IDGKSTAVKA");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Length", "5");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Decimals", "0");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnGK2IDGKSTAVKA.ExtendedProperties.Add("Deklarit.InternalName", "GK2IDGKSTAVKA");
                this.Columns.Add(this.columnGK2IDGKSTAVKA);
                this.columnZATVARANJAIZNOS = new DataColumn("ZATVARANJAIZNOS", typeof(decimal), "", MappingType.Element);
                this.columnZATVARANJAIZNOS.AllowDBNull = false;
                this.columnZATVARANJAIZNOS.Caption = "ZATVARANJAIZNOS";
                this.columnZATVARANJAIZNOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("IsKey", "false");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Description", "ZATVARANJAIZNOS");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Length", "12");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Decimals", "2");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("IsInReader", "true");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnZATVARANJAIZNOS.ExtendedProperties.Add("Deklarit.InternalName", "ZATVARANJAIZNOS");
                this.Columns.Add(this.columnZATVARANJAIZNOS);
                this.PrimaryKey = new DataColumn[] { this.columnGK1IDGKSTAVKA, this.columnGK2IDGKSTAVKA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "ZATVARANJA");
                this.ExtendedProperties.Add("Description", "ZATVARANJA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnGK1IDGKSTAVKA = this.Columns["GK1IDGKSTAVKA"];
                this.columnGK2IDGKSTAVKA = this.Columns["GK2IDGKSTAVKA"];
                this.columnZATVARANJAIZNOS = this.Columns["ZATVARANJAIZNOS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ZATVARANJADataSet.ZATVARANJARow(builder);
            }

            public ZATVARANJADataSet.ZATVARANJARow NewZATVARANJARow()
            {
                return (ZATVARANJADataSet.ZATVARANJARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ZATVARANJARowChanged != null)
                {
                    ZATVARANJADataSet.ZATVARANJARowChangeEventHandler zATVARANJARowChangedEvent = this.ZATVARANJARowChanged;
                    if (zATVARANJARowChangedEvent != null)
                    {
                        zATVARANJARowChangedEvent(this, new ZATVARANJADataSet.ZATVARANJARowChangeEvent((ZATVARANJADataSet.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ZATVARANJARowChanging != null)
                {
                    ZATVARANJADataSet.ZATVARANJARowChangeEventHandler zATVARANJARowChangingEvent = this.ZATVARANJARowChanging;
                    if (zATVARANJARowChangingEvent != null)
                    {
                        zATVARANJARowChangingEvent(this, new ZATVARANJADataSet.ZATVARANJARowChangeEvent((ZATVARANJADataSet.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ZATVARANJARowDeleted != null)
                {
                    ZATVARANJADataSet.ZATVARANJARowChangeEventHandler zATVARANJARowDeletedEvent = this.ZATVARANJARowDeleted;
                    if (zATVARANJARowDeletedEvent != null)
                    {
                        zATVARANJARowDeletedEvent(this, new ZATVARANJADataSet.ZATVARANJARowChangeEvent((ZATVARANJADataSet.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ZATVARANJARowDeleting != null)
                {
                    ZATVARANJADataSet.ZATVARANJARowChangeEventHandler zATVARANJARowDeletingEvent = this.ZATVARANJARowDeleting;
                    if (zATVARANJARowDeletingEvent != null)
                    {
                        zATVARANJARowDeletingEvent(this, new ZATVARANJADataSet.ZATVARANJARowChangeEvent((ZATVARANJADataSet.ZATVARANJARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveZATVARANJARow(ZATVARANJADataSet.ZATVARANJARow row)
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

            public DataColumn GK1IDGKSTAVKAColumn
            {
                get
                {
                    return this.columnGK1IDGKSTAVKA;
                }
            }

            public DataColumn GK2IDGKSTAVKAColumn
            {
                get
                {
                    return this.columnGK2IDGKSTAVKA;
                }
            }

            public ZATVARANJADataSet.ZATVARANJARow this[int index]
            {
                get
                {
                    return (ZATVARANJADataSet.ZATVARANJARow) this.Rows[index];
                }
            }

            public DataColumn ZATVARANJAIZNOSColumn
            {
                get
                {
                    return this.columnZATVARANJAIZNOS;
                }
            }
        }

        public class ZATVARANJARow : DataRow
        {
            private ZATVARANJADataSet.ZATVARANJADataTable tableZATVARANJA;

            internal ZATVARANJARow(DataRowBuilder rb) : base(rb)
            {
                this.tableZATVARANJA = (ZATVARANJADataSet.ZATVARANJADataTable) this.Table;
            }

            public bool IsGK1IDGKSTAVKANull()
            {
                return this.IsNull(this.tableZATVARANJA.GK1IDGKSTAVKAColumn);
            }

            public bool IsGK2IDGKSTAVKANull()
            {
                return this.IsNull(this.tableZATVARANJA.GK2IDGKSTAVKAColumn);
            }

            public bool IsZATVARANJAIZNOSNull()
            {
                return this.IsNull(this.tableZATVARANJA.ZATVARANJAIZNOSColumn);
            }

            public void SetZATVARANJAIZNOSNull()
            {
                this[this.tableZATVARANJA.ZATVARANJAIZNOSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int GK1IDGKSTAVKA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableZATVARANJA.GK1IDGKSTAVKAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.GK1IDGKSTAVKAColumn] = value;
                }
            }

            public int GK2IDGKSTAVKA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableZATVARANJA.GK2IDGKSTAVKAColumn]);
                }
                set
                {
                    this[this.tableZATVARANJA.GK2IDGKSTAVKAColumn] = value;
                }
            }

            public decimal ZATVARANJAIZNOS
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableZATVARANJA.ZATVARANJAIZNOSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value ZATVARANJAIZNOS because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableZATVARANJA.ZATVARANJAIZNOSColumn] = value;
                }
            }
        }

        public class ZATVARANJARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private ZATVARANJADataSet.ZATVARANJARow eventRow;

            public ZATVARANJARowChangeEvent(ZATVARANJADataSet.ZATVARANJARow row, DataRowAction action)
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

            public ZATVARANJADataSet.ZATVARANJARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ZATVARANJARowChangeEventHandler(object sender, ZATVARANJADataSet.ZATVARANJARowChangeEvent e);
    }
}

