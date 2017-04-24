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
    public class testDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private testDataTable tabletest;
        private testLevel1DataTable tabletestLevel1;
        private testLevel2DataTable tabletestLevel2;
        private testLevel3DataTable tabletestLevel3;

        public testDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected testDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["testLevel3"] != null)
                    {
                        this.Tables.Add(new testLevel3DataTable(dataSet.Tables["testLevel3"]));
                    }
                    if (dataSet.Tables["testLevel2"] != null)
                    {
                        this.Tables.Add(new testLevel2DataTable(dataSet.Tables["testLevel2"]));
                    }
                    if (dataSet.Tables["testLevel1"] != null)
                    {
                        this.Tables.Add(new testLevel1DataTable(dataSet.Tables["testLevel1"]));
                    }
                    if (dataSet.Tables["test"] != null)
                    {
                        this.Tables.Add(new testDataTable(dataSet.Tables["test"]));
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
            testDataSet set = (testDataSet) base.Clone();
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
            testDataSet set = new testDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "testDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2085");
            this.ExtendedProperties.Add("DataSetName", "testDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ItestDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "test");
            this.ExtendedProperties.Add("ObjectDescription", "test");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Common");
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
            this.DataSetName = "testDataSet";
            this.Namespace = "http://www.tempuri.org/test";
            this.tabletestLevel3 = new testLevel3DataTable();
            this.Tables.Add(this.tabletestLevel3);
            this.tabletestLevel2 = new testLevel2DataTable();
            this.Tables.Add(this.tabletestLevel2);
            this.tabletestLevel1 = new testLevel1DataTable();
            this.Tables.Add(this.tabletestLevel1);
            this.tabletest = new testDataTable();
            this.Tables.Add(this.tabletest);
            this.Relations.Add("test_testLevel3", new DataColumn[] { this.Tables["test"].Columns["idtest"] }, new DataColumn[] { this.Tables["testLevel3"].Columns["idtest"] });
            this.Relations["test_testLevel3"].Nested = true;
            this.Relations.Add("test_testLevel2", new DataColumn[] { this.Tables["test"].Columns["idtest"] }, new DataColumn[] { this.Tables["testLevel2"].Columns["idtest"] });
            this.Relations["test_testLevel2"].Nested = true;
            this.Relations.Add("test_testLevel1", new DataColumn[] { this.Tables["test"].Columns["idtest"] }, new DataColumn[] { this.Tables["testLevel1"].Columns["idtest"] });
            this.Relations["test_testLevel1"].Nested = true;
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
            this.tabletestLevel3 = (testLevel3DataTable) this.Tables["testLevel3"];
            this.tabletestLevel2 = (testLevel2DataTable) this.Tables["testLevel2"];
            this.tabletestLevel1 = (testLevel1DataTable) this.Tables["testLevel1"];
            this.tabletest = (testDataTable) this.Tables["test"];
            if (initTable)
            {
                if (this.tabletestLevel3 != null)
                {
                    this.tabletestLevel3.InitVars();
                }
                if (this.tabletestLevel2 != null)
                {
                    this.tabletestLevel2.InitVars();
                }
                if (this.tabletestLevel1 != null)
                {
                    this.tabletestLevel1.InitVars();
                }
                if (this.tabletest != null)
                {
                    this.tabletest.InitVars();
                }
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["testLevel3"] != null)
                {
                    this.Tables.Add(new testLevel3DataTable(dataSet.Tables["testLevel3"]));
                }
                if (dataSet.Tables["testLevel2"] != null)
                {
                    this.Tables.Add(new testLevel2DataTable(dataSet.Tables["testLevel2"]));
                }
                if (dataSet.Tables["testLevel1"] != null)
                {
                    this.Tables.Add(new testLevel1DataTable(dataSet.Tables["testLevel1"]));
                }
                if (dataSet.Tables["test"] != null)
                {
                    this.Tables.Add(new testDataTable(dataSet.Tables["test"]));
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

        private bool ShouldSerializetest()
        {
            return false;
        }

        private bool ShouldSerializetestLevel1()
        {
            return false;
        }

        private bool ShouldSerializetestLevel2()
        {
            return false;
        }

        private bool ShouldSerializetestLevel3()
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
        public testDataTable test
        {
            get
            {
                return this.tabletest;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public testLevel1DataTable testLevel1
        {
            get
            {
                return this.tabletestLevel1;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public testLevel2DataTable testLevel2
        {
            get
            {
                return this.tabletestLevel2;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public testLevel3DataTable testLevel3
        {
            get
            {
                return this.tabletestLevel3;
            }
        }

        [Serializable]
        public class testDataTable : DataTable, IEnumerable
        {
            private DataColumn columnidtest;
            private DataColumn columnmt;
            private DataColumn columnnazivtest;
            private DataColumn columnoj;

            public event testDataSet.testRowChangeEventHandler testRowChanged;

            public event testDataSet.testRowChangeEventHandler testRowChanging;

            public event testDataSet.testRowChangeEventHandler testRowDeleted;

            public event testDataSet.testRowChangeEventHandler testRowDeleting;

            public testDataTable()
            {
                this.TableName = "test";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal testDataTable(DataTable table) : base(table.TableName)
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

            protected testDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddtestRow(testDataSet.testRow row)
            {
                this.Rows.Add(row);
            }

            public testDataSet.testRow AddtestRow(int idtest, string nazivtest, int oj, int mt)
            {
                testDataSet.testRow row = (testDataSet.testRow) this.NewRow();
                row["idtest"] = idtest;
                row["nazivtest"] = nazivtest;
                row["oj"] = oj;
                row["mt"] = mt;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                testDataSet.testDataTable table = (testDataSet.testDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public testDataSet.testRow FindByidtest(int idtest)
            {
                return (testDataSet.testRow) this.Rows.Find(new object[] { idtest });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(testDataSet.testRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                testDataSet set = new testDataSet();
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
                this.columnidtest = new DataColumn("idtest", typeof(int), "", MappingType.Element);
                this.columnidtest.AllowDBNull = false;
                this.columnidtest.Caption = "idtest";
                this.columnidtest.Unique = true;
                this.columnidtest.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidtest.ExtendedProperties.Add("IsKey", "true");
                this.columnidtest.ExtendedProperties.Add("ReadOnly", "false");
                this.columnidtest.ExtendedProperties.Add("DeklaritType", "int");
                this.columnidtest.ExtendedProperties.Add("Description", "idtest");
                this.columnidtest.ExtendedProperties.Add("Length", "5");
                this.columnidtest.ExtendedProperties.Add("Decimals", "0");
                this.columnidtest.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnidtest.ExtendedProperties.Add("IsInReader", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.InternalName", "idtest");
                this.Columns.Add(this.columnidtest);
                this.columnnazivtest = new DataColumn("nazivtest", typeof(string), "", MappingType.Element);
                this.columnnazivtest.AllowDBNull = false;
                this.columnnazivtest.Caption = "nazivtest";
                this.columnnazivtest.MaxLength = 50;
                this.columnnazivtest.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnnazivtest.ExtendedProperties.Add("IsKey", "false");
                this.columnnazivtest.ExtendedProperties.Add("ReadOnly", "false");
                this.columnnazivtest.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnnazivtest.ExtendedProperties.Add("Description", "nazivtest");
                this.columnnazivtest.ExtendedProperties.Add("Length", "50");
                this.columnnazivtest.ExtendedProperties.Add("Decimals", "0");
                this.columnnazivtest.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnnazivtest.ExtendedProperties.Add("IsInReader", "true");
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnnazivtest.ExtendedProperties.Add("Deklarit.InternalName", "nazivtest");
                this.Columns.Add(this.columnnazivtest);
                this.columnoj = new DataColumn("oj", typeof(int), "", MappingType.Element);
                this.columnoj.AllowDBNull = false;
                this.columnoj.Caption = "oj";
                this.columnoj.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnoj.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnoj.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnoj.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnoj.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnoj.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnoj.ExtendedProperties.Add("IsKey", "false");
                this.columnoj.ExtendedProperties.Add("ReadOnly", "false");
                this.columnoj.ExtendedProperties.Add("DeklaritType", "int");
                this.columnoj.ExtendedProperties.Add("Description", "oj");
                this.columnoj.ExtendedProperties.Add("Length", "5");
                this.columnoj.ExtendedProperties.Add("Decimals", "0");
                this.columnoj.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnoj.ExtendedProperties.Add("IsInReader", "true");
                this.columnoj.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnoj.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnoj.ExtendedProperties.Add("Deklarit.InternalName", "oj");
                this.Columns.Add(this.columnoj);
                this.columnmt = new DataColumn("mt", typeof(int), "", MappingType.Element);
                this.columnmt.AllowDBNull = false;
                this.columnmt.Caption = "mt";
                this.columnmt.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnmt.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnmt.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnmt.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnmt.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnmt.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnmt.ExtendedProperties.Add("IsKey", "false");
                this.columnmt.ExtendedProperties.Add("ReadOnly", "false");
                this.columnmt.ExtendedProperties.Add("DeklaritType", "int");
                this.columnmt.ExtendedProperties.Add("Description", "mt");
                this.columnmt.ExtendedProperties.Add("Length", "5");
                this.columnmt.ExtendedProperties.Add("Decimals", "0");
                this.columnmt.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnmt.ExtendedProperties.Add("IsInReader", "true");
                this.columnmt.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnmt.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnmt.ExtendedProperties.Add("Deklarit.InternalName", "mt");
                this.Columns.Add(this.columnmt);
                this.PrimaryKey = new DataColumn[] { this.columnidtest };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "test");
                this.ExtendedProperties.Add("Description", "test");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnidtest = this.Columns["idtest"];
                this.columnnazivtest = this.Columns["nazivtest"];
                this.columnoj = this.Columns["oj"];
                this.columnmt = this.Columns["mt"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new testDataSet.testRow(builder);
            }

            public testDataSet.testRow NewtestRow()
            {
                return (testDataSet.testRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.testRowChanged != null)
                {
                    testDataSet.testRowChangeEventHandler testRowChangedEvent = this.testRowChanged;
                    if (testRowChangedEvent != null)
                    {
                        testRowChangedEvent(this, new testDataSet.testRowChangeEvent((testDataSet.testRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.testRowChanging != null)
                {
                    testDataSet.testRowChangeEventHandler testRowChangingEvent = this.testRowChanging;
                    if (testRowChangingEvent != null)
                    {
                        testRowChangingEvent(this, new testDataSet.testRowChangeEvent((testDataSet.testRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.testRowDeleted != null)
                {
                    testDataSet.testRowChangeEventHandler testRowDeletedEvent = this.testRowDeleted;
                    if (testRowDeletedEvent != null)
                    {
                        testRowDeletedEvent(this, new testDataSet.testRowChangeEvent((testDataSet.testRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.testRowDeleting != null)
                {
                    testDataSet.testRowChangeEventHandler testRowDeletingEvent = this.testRowDeleting;
                    if (testRowDeletingEvent != null)
                    {
                        testRowDeletingEvent(this, new testDataSet.testRowChangeEvent((testDataSet.testRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovetestRow(testDataSet.testRow row)
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

            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            public testDataSet.testRow this[int index]
            {
                get
                {
                    return (testDataSet.testRow) this.Rows[index];
                }
            }

            public DataColumn mtColumn
            {
                get
                {
                    return this.columnmt;
                }
            }

            public DataColumn nazivtestColumn
            {
                get
                {
                    return this.columnnazivtest;
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

        [Serializable]
        public class testLevel1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDOPRINOS;
            private DataColumn columnidtest;
            private DataColumn columnkontodop;
            private DataColumn columnstranadop;

            public event testDataSet.testLevel1RowChangeEventHandler testLevel1RowChanged;

            public event testDataSet.testLevel1RowChangeEventHandler testLevel1RowChanging;

            public event testDataSet.testLevel1RowChangeEventHandler testLevel1RowDeleted;

            public event testDataSet.testLevel1RowChangeEventHandler testLevel1RowDeleting;

            public testLevel1DataTable()
            {
                this.TableName = "testLevel1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal testLevel1DataTable(DataTable table) : base(table.TableName)
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

            protected testLevel1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddtestLevel1Row(testDataSet.testLevel1Row row)
            {
                this.Rows.Add(row);
            }

            public testDataSet.testLevel1Row AddtestLevel1Row(int idtest, int iDDOPRINOS, int kontodop, int stranadop)
            {
                testDataSet.testLevel1Row row = (testDataSet.testLevel1Row) this.NewRow();
                row["idtest"] = idtest;
                row["IDDOPRINOS"] = iDDOPRINOS;
                row["kontodop"] = kontodop;
                row["stranadop"] = stranadop;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                testDataSet.testLevel1DataTable table = (testDataSet.testLevel1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public testDataSet.testLevel1Row FindByidtestIDDOPRINOS(int idtest, int iDDOPRINOS)
            {
                return (testDataSet.testLevel1Row) this.Rows.Find(new object[] { idtest, iDDOPRINOS });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(testDataSet.testLevel1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                testDataSet set = new testDataSet();
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
                this.columnidtest = new DataColumn("idtest", typeof(int), "", MappingType.Element);
                this.columnidtest.AllowDBNull = false;
                this.columnidtest.Caption = "idtest";
                this.columnidtest.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidtest.ExtendedProperties.Add("IsKey", "true");
                this.columnidtest.ExtendedProperties.Add("ReadOnly", "true");
                this.columnidtest.ExtendedProperties.Add("DeklaritType", "int");
                this.columnidtest.ExtendedProperties.Add("Description", "idtest");
                this.columnidtest.ExtendedProperties.Add("Length", "5");
                this.columnidtest.ExtendedProperties.Add("Decimals", "0");
                this.columnidtest.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnidtest.ExtendedProperties.Add("IsInReader", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.InternalName", "idtest");
                this.Columns.Add(this.columnidtest);
                this.columnIDDOPRINOS = new DataColumn("IDDOPRINOS", typeof(int), "", MappingType.Element);
                this.columnIDDOPRINOS.AllowDBNull = false;
                this.columnIDDOPRINOS.Caption = "Šifra doprinosa";
                this.columnIDDOPRINOS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOPRINOS.ExtendedProperties.Add("IsKey", "true");
                this.columnIDDOPRINOS.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Description", "Šifra doprinosa");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Length", "8");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOPRINOS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOPRINOS.ExtendedProperties.Add("Deklarit.InternalName", "IDDOPRINOS");
                this.Columns.Add(this.columnIDDOPRINOS);
                this.columnkontodop = new DataColumn("kontodop", typeof(int), "", MappingType.Element);
                this.columnkontodop.AllowDBNull = false;
                this.columnkontodop.Caption = "konto";
                this.columnkontodop.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkontodop.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkontodop.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkontodop.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkontodop.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkontodop.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkontodop.ExtendedProperties.Add("IsKey", "false");
                this.columnkontodop.ExtendedProperties.Add("ReadOnly", "false");
                this.columnkontodop.ExtendedProperties.Add("DeklaritType", "int");
                this.columnkontodop.ExtendedProperties.Add("Description", "konto");
                this.columnkontodop.ExtendedProperties.Add("Length", "5");
                this.columnkontodop.ExtendedProperties.Add("Decimals", "0");
                this.columnkontodop.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnkontodop.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkontodop.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkontodop.ExtendedProperties.Add("Deklarit.InternalName", "kontodop");
                this.Columns.Add(this.columnkontodop);
                this.columnstranadop = new DataColumn("stranadop", typeof(int), "", MappingType.Element);
                this.columnstranadop.AllowDBNull = false;
                this.columnstranadop.Caption = "stranadop";
                this.columnstranadop.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnstranadop.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnstranadop.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnstranadop.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnstranadop.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnstranadop.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnstranadop.ExtendedProperties.Add("IsKey", "false");
                this.columnstranadop.ExtendedProperties.Add("ReadOnly", "false");
                this.columnstranadop.ExtendedProperties.Add("DeklaritType", "int");
                this.columnstranadop.ExtendedProperties.Add("Description", "stranadop");
                this.columnstranadop.ExtendedProperties.Add("Length", "5");
                this.columnstranadop.ExtendedProperties.Add("Decimals", "0");
                this.columnstranadop.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnstranadop.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnstranadop.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnstranadop.ExtendedProperties.Add("Deklarit.InternalName", "stranadop");
                this.Columns.Add(this.columnstranadop);
                this.PrimaryKey = new DataColumn[] { this.columnidtest, this.columnIDDOPRINOS };
                this.ExtendedProperties.Add("ParentLvl", "test");
                this.ExtendedProperties.Add("LevelName", "Level1");
                this.ExtendedProperties.Add("Description", "Level1");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnidtest = this.Columns["idtest"];
                this.columnIDDOPRINOS = this.Columns["IDDOPRINOS"];
                this.columnkontodop = this.Columns["kontodop"];
                this.columnstranadop = this.Columns["stranadop"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new testDataSet.testLevel1Row(builder);
            }

            public testDataSet.testLevel1Row NewtestLevel1Row()
            {
                return (testDataSet.testLevel1Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.testLevel1RowChanged != null)
                {
                    testDataSet.testLevel1RowChangeEventHandler handler = this.testLevel1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel1RowChangeEvent((testDataSet.testLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.testLevel1RowChanging != null)
                {
                    testDataSet.testLevel1RowChangeEventHandler handler = this.testLevel1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel1RowChangeEvent((testDataSet.testLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("test_testLevel1", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.testLevel1RowDeleted != null)
                {
                    testDataSet.testLevel1RowChangeEventHandler handler = this.testLevel1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel1RowChangeEvent((testDataSet.testLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.testLevel1RowDeleting != null)
                {
                    testDataSet.testLevel1RowChangeEventHandler handler = this.testLevel1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel1RowChangeEvent((testDataSet.testLevel1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemovetestLevel1Row(testDataSet.testLevel1Row row)
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

            public DataColumn IDDOPRINOSColumn
            {
                get
                {
                    return this.columnIDDOPRINOS;
                }
            }

            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            public testDataSet.testLevel1Row this[int index]
            {
                get
                {
                    return (testDataSet.testLevel1Row) this.Rows[index];
                }
            }

            public DataColumn kontodopColumn
            {
                get
                {
                    return this.columnkontodop;
                }
            }

            public DataColumn stranadopColumn
            {
                get
                {
                    return this.columnstranadop;
                }
            }
        }

        public class testLevel1Row : DataRow
        {
            private testDataSet.testLevel1DataTable tabletestLevel1;

            internal testLevel1Row(DataRowBuilder rb) : base(rb)
            {
                this.tabletestLevel1 = (testDataSet.testLevel1DataTable) this.Table;
            }

            public testDataSet.testRow GettestRow()
            {
                return (testDataSet.testRow) this.GetParentRow("test_testLevel1");
            }

            public bool IsIDDOPRINOSNull()
            {
                return this.IsNull(this.tabletestLevel1.IDDOPRINOSColumn);
            }

            public bool IsidtestNull()
            {
                return this.IsNull(this.tabletestLevel1.idtestColumn);
            }

            public bool IskontodopNull()
            {
                return this.IsNull(this.tabletestLevel1.kontodopColumn);
            }

            public bool IsstranadopNull()
            {
                return this.IsNull(this.tabletestLevel1.stranadopColumn);
            }

            public void SetkontodopNull()
            {
                this[this.tabletestLevel1.kontodopColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetstranadopNull()
            {
                this[this.tabletestLevel1.stranadopColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDOPRINOS
            {
                get
                {
                    return Conversions.ToInteger(this[this.tabletestLevel1.IDDOPRINOSColumn]);
                }
                set
                {
                    this[this.tabletestLevel1.IDDOPRINOSColumn] = value;
                }
            }

            public int idtest
            {
                get
                {
                    return Conversions.ToInteger(this[this.tabletestLevel1.idtestColumn]);
                }
                set
                {
                    this[this.tabletestLevel1.idtestColumn] = value;
                }
            }

            public int kontodop
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletestLevel1.kontodopColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletestLevel1.kontodopColumn] = value;
                }
            }

            public int stranadop
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletestLevel1.stranadopColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletestLevel1.stranadopColumn] = value;
                }
            }
        }

        public class testLevel1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private testDataSet.testLevel1Row eventRow;

            public testLevel1RowChangeEvent(testDataSet.testLevel1Row row, DataRowAction action)
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

            public testDataSet.testLevel1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void testLevel1RowChangeEventHandler(object sender, testDataSet.testLevel1RowChangeEvent e);

        [Serializable]
        public class testLevel2DataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDELEMENT;
            private DataColumn columnidtest;
            private DataColumn columnkontoelement;
            private DataColumn columnstranaelement;

            public event testDataSet.testLevel2RowChangeEventHandler testLevel2RowChanged;

            public event testDataSet.testLevel2RowChangeEventHandler testLevel2RowChanging;

            public event testDataSet.testLevel2RowChangeEventHandler testLevel2RowDeleted;

            public event testDataSet.testLevel2RowChangeEventHandler testLevel2RowDeleting;

            public testLevel2DataTable()
            {
                this.TableName = "testLevel2";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal testLevel2DataTable(DataTable table) : base(table.TableName)
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

            protected testLevel2DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddtestLevel2Row(testDataSet.testLevel2Row row)
            {
                this.Rows.Add(row);
            }

            public testDataSet.testLevel2Row AddtestLevel2Row(int idtest, int iDELEMENT, int kontoelement, int stranaelement)
            {
                testDataSet.testLevel2Row row = (testDataSet.testLevel2Row) this.NewRow();
                row["idtest"] = idtest;
                row["IDELEMENT"] = iDELEMENT;
                row["kontoelement"] = kontoelement;
                row["stranaelement"] = stranaelement;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                testDataSet.testLevel2DataTable table = (testDataSet.testLevel2DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public testDataSet.testLevel2Row FindByidtestIDELEMENT(int idtest, int iDELEMENT)
            {
                return (testDataSet.testLevel2Row) this.Rows.Find(new object[] { idtest, iDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(testDataSet.testLevel2Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                testDataSet set = new testDataSet();
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
                this.columnidtest = new DataColumn("idtest", typeof(int), "", MappingType.Element);
                this.columnidtest.AllowDBNull = false;
                this.columnidtest.Caption = "idtest";
                this.columnidtest.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidtest.ExtendedProperties.Add("IsKey", "true");
                this.columnidtest.ExtendedProperties.Add("ReadOnly", "true");
                this.columnidtest.ExtendedProperties.Add("DeklaritType", "int");
                this.columnidtest.ExtendedProperties.Add("Description", "idtest");
                this.columnidtest.ExtendedProperties.Add("Length", "5");
                this.columnidtest.ExtendedProperties.Add("Decimals", "0");
                this.columnidtest.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnidtest.ExtendedProperties.Add("IsInReader", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.InternalName", "idtest");
                this.Columns.Add(this.columnidtest);
                this.columnIDELEMENT = new DataColumn("IDELEMENT", typeof(int), "", MappingType.Element);
                this.columnIDELEMENT.AllowDBNull = false;
                this.columnIDELEMENT.Caption = "Šifra elementa";
                this.columnIDELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDELEMENT.ExtendedProperties.Add("IsKey", "true");
                this.columnIDELEMENT.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDELEMENT.ExtendedProperties.Add("Description", "Šifra elementa");
                this.columnIDELEMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDELEMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDELEMENT");
                this.Columns.Add(this.columnIDELEMENT);
                this.columnkontoelement = new DataColumn("kontoelement", typeof(int), "", MappingType.Element);
                this.columnkontoelement.AllowDBNull = false;
                this.columnkontoelement.Caption = "kontoelement";
                this.columnkontoelement.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkontoelement.ExtendedProperties.Add("IsKey", "false");
                this.columnkontoelement.ExtendedProperties.Add("ReadOnly", "false");
                this.columnkontoelement.ExtendedProperties.Add("DeklaritType", "int");
                this.columnkontoelement.ExtendedProperties.Add("Description", "kontoelement");
                this.columnkontoelement.ExtendedProperties.Add("Length", "5");
                this.columnkontoelement.ExtendedProperties.Add("Decimals", "0");
                this.columnkontoelement.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkontoelement.ExtendedProperties.Add("Deklarit.InternalName", "kontoelement");
                this.Columns.Add(this.columnkontoelement);
                this.columnstranaelement = new DataColumn("stranaelement", typeof(int), "", MappingType.Element);
                this.columnstranaelement.AllowDBNull = false;
                this.columnstranaelement.Caption = "stranaelement";
                this.columnstranaelement.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnstranaelement.ExtendedProperties.Add("IsKey", "false");
                this.columnstranaelement.ExtendedProperties.Add("ReadOnly", "false");
                this.columnstranaelement.ExtendedProperties.Add("DeklaritType", "int");
                this.columnstranaelement.ExtendedProperties.Add("Description", "stranaelement");
                this.columnstranaelement.ExtendedProperties.Add("Length", "5");
                this.columnstranaelement.ExtendedProperties.Add("Decimals", "0");
                this.columnstranaelement.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnstranaelement.ExtendedProperties.Add("Deklarit.InternalName", "stranaelement");
                this.Columns.Add(this.columnstranaelement);
                this.PrimaryKey = new DataColumn[] { this.columnidtest, this.columnIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "test");
                this.ExtendedProperties.Add("LevelName", "Level2");
                this.ExtendedProperties.Add("Description", "Level2");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnidtest = this.Columns["idtest"];
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
                this.columnkontoelement = this.Columns["kontoelement"];
                this.columnstranaelement = this.Columns["stranaelement"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new testDataSet.testLevel2Row(builder);
            }

            public testDataSet.testLevel2Row NewtestLevel2Row()
            {
                return (testDataSet.testLevel2Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.testLevel2RowChanged != null)
                {
                    testDataSet.testLevel2RowChangeEventHandler handler = this.testLevel2RowChanged;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel2RowChangeEvent((testDataSet.testLevel2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.testLevel2RowChanging != null)
                {
                    testDataSet.testLevel2RowChangeEventHandler handler = this.testLevel2RowChanging;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel2RowChangeEvent((testDataSet.testLevel2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("test_testLevel2", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.testLevel2RowDeleted != null)
                {
                    testDataSet.testLevel2RowChangeEventHandler handler = this.testLevel2RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel2RowChangeEvent((testDataSet.testLevel2Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.testLevel2RowDeleting != null)
                {
                    testDataSet.testLevel2RowChangeEventHandler handler = this.testLevel2RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel2RowChangeEvent((testDataSet.testLevel2Row) e.Row, e.Action));
                    }
                }
            }

            public void RemovetestLevel2Row(testDataSet.testLevel2Row row)
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

            public DataColumn IDELEMENTColumn
            {
                get
                {
                    return this.columnIDELEMENT;
                }
            }

            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            public testDataSet.testLevel2Row this[int index]
            {
                get
                {
                    return (testDataSet.testLevel2Row) this.Rows[index];
                }
            }

            public DataColumn kontoelementColumn
            {
                get
                {
                    return this.columnkontoelement;
                }
            }

            public DataColumn stranaelementColumn
            {
                get
                {
                    return this.columnstranaelement;
                }
            }
        }

        public class testLevel2Row : DataRow
        {
            private testDataSet.testLevel2DataTable tabletestLevel2;

            internal testLevel2Row(DataRowBuilder rb) : base(rb)
            {
                this.tabletestLevel2 = (testDataSet.testLevel2DataTable) this.Table;
            }

            public testDataSet.testRow GettestRow()
            {
                return (testDataSet.testRow) this.GetParentRow("test_testLevel2");
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tabletestLevel2.IDELEMENTColumn);
            }

            public bool IsidtestNull()
            {
                return this.IsNull(this.tabletestLevel2.idtestColumn);
            }

            public bool IskontoelementNull()
            {
                return this.IsNull(this.tabletestLevel2.kontoelementColumn);
            }

            public bool IsstranaelementNull()
            {
                return this.IsNull(this.tabletestLevel2.stranaelementColumn);
            }

            public void SetkontoelementNull()
            {
                this[this.tabletestLevel2.kontoelementColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetstranaelementNull()
            {
                this[this.tabletestLevel2.stranaelementColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tabletestLevel2.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tabletestLevel2.IDELEMENTColumn] = value;
                }
            }

            public int idtest
            {
                get
                {
                    return Conversions.ToInteger(this[this.tabletestLevel2.idtestColumn]);
                }
                set
                {
                    this[this.tabletestLevel2.idtestColumn] = value;
                }
            }

            public int kontoelement
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletestLevel2.kontoelementColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletestLevel2.kontoelementColumn] = value;
                }
            }

            public int stranaelement
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletestLevel2.stranaelementColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletestLevel2.stranaelementColumn] = value;
                }
            }
        }

        public class testLevel2RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private testDataSet.testLevel2Row eventRow;

            public testLevel2RowChangeEvent(testDataSet.testLevel2Row row, DataRowAction action)
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

            public testDataSet.testLevel2Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void testLevel2RowChangeEventHandler(object sender, testDataSet.testLevel2RowChangeEvent e);

        [Serializable]
        public class testLevel3DataTable : DataTable, IEnumerable
        {
            private DataColumn columnidostalo;
            private DataColumn columnidtest;
            private DataColumn columnkontoostalo;
            private DataColumn columnstranaostalo;

            public event testDataSet.testLevel3RowChangeEventHandler testLevel3RowChanged;

            public event testDataSet.testLevel3RowChangeEventHandler testLevel3RowChanging;

            public event testDataSet.testLevel3RowChangeEventHandler testLevel3RowDeleted;

            public event testDataSet.testLevel3RowChangeEventHandler testLevel3RowDeleting;

            public testLevel3DataTable()
            {
                this.TableName = "testLevel3";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal testLevel3DataTable(DataTable table) : base(table.TableName)
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

            protected testLevel3DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddtestLevel3Row(testDataSet.testLevel3Row row)
            {
                this.Rows.Add(row);
            }

            public testDataSet.testLevel3Row AddtestLevel3Row(int idtest, string idostalo, int kontoostalo, int stranaostalo)
            {
                testDataSet.testLevel3Row row = (testDataSet.testLevel3Row) this.NewRow();
                row["idtest"] = idtest;
                row["idostalo"] = idostalo;
                row["kontoostalo"] = kontoostalo;
                row["stranaostalo"] = stranaostalo;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                testDataSet.testLevel3DataTable table = (testDataSet.testLevel3DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public testDataSet.testLevel3Row FindByidtestidostalo(int idtest, string idostalo)
            {
                return (testDataSet.testLevel3Row) this.Rows.Find(new object[] { idtest, idostalo });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(testDataSet.testLevel3Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                testDataSet set = new testDataSet();
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
                this.columnidtest = new DataColumn("idtest", typeof(int), "", MappingType.Element);
                this.columnidtest.AllowDBNull = false;
                this.columnidtest.Caption = "idtest";
                this.columnidtest.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidtest.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidtest.ExtendedProperties.Add("IsKey", "true");
                this.columnidtest.ExtendedProperties.Add("ReadOnly", "true");
                this.columnidtest.ExtendedProperties.Add("DeklaritType", "int");
                this.columnidtest.ExtendedProperties.Add("Description", "idtest");
                this.columnidtest.ExtendedProperties.Add("Length", "5");
                this.columnidtest.ExtendedProperties.Add("Decimals", "0");
                this.columnidtest.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnidtest.ExtendedProperties.Add("IsInReader", "true");
                this.columnidtest.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidtest.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidtest.ExtendedProperties.Add("Deklarit.InternalName", "idtest");
                this.Columns.Add(this.columnidtest);
                this.columnidostalo = new DataColumn("idostalo", typeof(string), "", MappingType.Element);
                this.columnidostalo.AllowDBNull = false;
                this.columnidostalo.Caption = "idostalo";
                this.columnidostalo.MaxLength = 50;
                this.columnidostalo.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnidostalo.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnidostalo.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnidostalo.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnidostalo.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnidostalo.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnidostalo.ExtendedProperties.Add("IsKey", "true");
                this.columnidostalo.ExtendedProperties.Add("ReadOnly", "false");
                this.columnidostalo.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnidostalo.ExtendedProperties.Add("Description", "idostalo");
                this.columnidostalo.ExtendedProperties.Add("Length", "50");
                this.columnidostalo.ExtendedProperties.Add("Decimals", "0");
                this.columnidostalo.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnidostalo.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnidostalo.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnidostalo.ExtendedProperties.Add("Deklarit.InternalName", "idostalo");
                this.Columns.Add(this.columnidostalo);
                this.columnkontoostalo = new DataColumn("kontoostalo", typeof(int), "", MappingType.Element);
                this.columnkontoostalo.AllowDBNull = false;
                this.columnkontoostalo.Caption = "kontoostalo";
                this.columnkontoostalo.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkontoostalo.ExtendedProperties.Add("IsKey", "false");
                this.columnkontoostalo.ExtendedProperties.Add("ReadOnly", "false");
                this.columnkontoostalo.ExtendedProperties.Add("DeklaritType", "int");
                this.columnkontoostalo.ExtendedProperties.Add("Description", "kontoostalo");
                this.columnkontoostalo.ExtendedProperties.Add("Length", "5");
                this.columnkontoostalo.ExtendedProperties.Add("Decimals", "0");
                this.columnkontoostalo.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkontoostalo.ExtendedProperties.Add("Deklarit.InternalName", "kontoostalo");
                this.Columns.Add(this.columnkontoostalo);
                this.columnstranaostalo = new DataColumn("stranaostalo", typeof(int), "", MappingType.Element);
                this.columnstranaostalo.AllowDBNull = false;
                this.columnstranaostalo.Caption = "stranaostalo";
                this.columnstranaostalo.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnstranaostalo.ExtendedProperties.Add("IsKey", "false");
                this.columnstranaostalo.ExtendedProperties.Add("ReadOnly", "false");
                this.columnstranaostalo.ExtendedProperties.Add("DeklaritType", "int");
                this.columnstranaostalo.ExtendedProperties.Add("Description", "stranaostalo");
                this.columnstranaostalo.ExtendedProperties.Add("Length", "5");
                this.columnstranaostalo.ExtendedProperties.Add("Decimals", "0");
                this.columnstranaostalo.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnstranaostalo.ExtendedProperties.Add("Deklarit.InternalName", "stranaostalo");
                this.Columns.Add(this.columnstranaostalo);
                this.PrimaryKey = new DataColumn[] { this.columnidtest, this.columnidostalo };
                this.ExtendedProperties.Add("ParentLvl", "test");
                this.ExtendedProperties.Add("LevelName", "Level3");
                this.ExtendedProperties.Add("Description", "Level3");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnidtest = this.Columns["idtest"];
                this.columnidostalo = this.Columns["idostalo"];
                this.columnkontoostalo = this.Columns["kontoostalo"];
                this.columnstranaostalo = this.Columns["stranaostalo"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new testDataSet.testLevel3Row(builder);
            }

            public testDataSet.testLevel3Row NewtestLevel3Row()
            {
                return (testDataSet.testLevel3Row) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.testLevel3RowChanged != null)
                {
                    testDataSet.testLevel3RowChangeEventHandler handler = this.testLevel3RowChanged;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel3RowChangeEvent((testDataSet.testLevel3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.testLevel3RowChanging != null)
                {
                    testDataSet.testLevel3RowChangeEventHandler handler = this.testLevel3RowChanging;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel3RowChangeEvent((testDataSet.testLevel3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("test_testLevel3", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.testLevel3RowDeleted != null)
                {
                    testDataSet.testLevel3RowChangeEventHandler handler = this.testLevel3RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel3RowChangeEvent((testDataSet.testLevel3Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.testLevel3RowDeleting != null)
                {
                    testDataSet.testLevel3RowChangeEventHandler handler = this.testLevel3RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new testDataSet.testLevel3RowChangeEvent((testDataSet.testLevel3Row) e.Row, e.Action));
                    }
                }
            }

            public void RemovetestLevel3Row(testDataSet.testLevel3Row row)
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

            public DataColumn idostaloColumn
            {
                get
                {
                    return this.columnidostalo;
                }
            }

            public DataColumn idtestColumn
            {
                get
                {
                    return this.columnidtest;
                }
            }

            public testDataSet.testLevel3Row this[int index]
            {
                get
                {
                    return (testDataSet.testLevel3Row) this.Rows[index];
                }
            }

            public DataColumn kontoostaloColumn
            {
                get
                {
                    return this.columnkontoostalo;
                }
            }

            public DataColumn stranaostaloColumn
            {
                get
                {
                    return this.columnstranaostalo;
                }
            }
        }

        public class testLevel3Row : DataRow
        {
            private testDataSet.testLevel3DataTable tabletestLevel3;

            internal testLevel3Row(DataRowBuilder rb) : base(rb)
            {
                this.tabletestLevel3 = (testDataSet.testLevel3DataTable) this.Table;
            }

            public testDataSet.testRow GettestRow()
            {
                return (testDataSet.testRow) this.GetParentRow("test_testLevel3");
            }

            public bool IsidostaloNull()
            {
                return this.IsNull(this.tabletestLevel3.idostaloColumn);
            }

            public bool IsidtestNull()
            {
                return this.IsNull(this.tabletestLevel3.idtestColumn);
            }

            public bool IskontoostaloNull()
            {
                return this.IsNull(this.tabletestLevel3.kontoostaloColumn);
            }

            public bool IsstranaostaloNull()
            {
                return this.IsNull(this.tabletestLevel3.stranaostaloColumn);
            }

            public void SetkontoostaloNull()
            {
                this[this.tabletestLevel3.kontoostaloColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetstranaostaloNull()
            {
                this[this.tabletestLevel3.stranaostaloColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string idostalo
            {
                get
                {
                    return Conversions.ToString(this[this.tabletestLevel3.idostaloColumn]);
                }
                set
                {
                    this[this.tabletestLevel3.idostaloColumn] = value;
                }
            }

            public int idtest
            {
                get
                {
                    return Conversions.ToInteger(this[this.tabletestLevel3.idtestColumn]);
                }
                set
                {
                    this[this.tabletestLevel3.idtestColumn] = value;
                }
            }

            public int kontoostalo
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletestLevel3.kontoostaloColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletestLevel3.kontoostaloColumn] = value;
                }
            }

            public int stranaostalo
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletestLevel3.stranaostaloColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletestLevel3.stranaostaloColumn] = value;
                }
            }
        }

        public class testLevel3RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private testDataSet.testLevel3Row eventRow;

            public testLevel3RowChangeEvent(testDataSet.testLevel3Row row, DataRowAction action)
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

            public testDataSet.testLevel3Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void testLevel3RowChangeEventHandler(object sender, testDataSet.testLevel3RowChangeEvent e);

        public class testRow : DataRow
        {
            private testDataSet.testDataTable tabletest;

            internal testRow(DataRowBuilder rb) : base(rb)
            {
                this.tabletest = (testDataSet.testDataTable) this.Table;
            }

            public testDataSet.testLevel1Row[] GettestLevel1Rows()
            {
                return (testDataSet.testLevel1Row[]) this.GetChildRows("test_testLevel1");
            }

            public testDataSet.testLevel2Row[] GettestLevel2Rows()
            {
                return (testDataSet.testLevel2Row[]) this.GetChildRows("test_testLevel2");
            }

            public testDataSet.testLevel3Row[] GettestLevel3Rows()
            {
                return (testDataSet.testLevel3Row[]) this.GetChildRows("test_testLevel3");
            }

            public bool IsidtestNull()
            {
                return this.IsNull(this.tabletest.idtestColumn);
            }

            public bool IsmtNull()
            {
                return this.IsNull(this.tabletest.mtColumn);
            }

            public bool IsnazivtestNull()
            {
                return this.IsNull(this.tabletest.nazivtestColumn);
            }

            public bool IsojNull()
            {
                return this.IsNull(this.tabletest.ojColumn);
            }

            public void SetmtNull()
            {
                this[this.tabletest.mtColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetnazivtestNull()
            {
                this[this.tabletest.nazivtestColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetojNull()
            {
                this[this.tabletest.ojColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int idtest
            {
                get
                {
                    return Conversions.ToInteger(this[this.tabletest.idtestColumn]);
                }
                set
                {
                    this[this.tabletest.idtestColumn] = value;
                }
            }

            public int mt
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletest.mtColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletest.mtColumn] = value;
                }
            }

            public string nazivtest
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tabletest.nazivtestColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tabletest.nazivtestColumn] = value;
                }
            }

            public int oj
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tabletest.ojColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tabletest.ojColumn] = value;
                }
            }
        }

        public class testRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private testDataSet.testRow eventRow;

            public testRowChangeEvent(testDataSet.testRow row, DataRowAction action)
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

            public testDataSet.testRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void testRowChangeEventHandler(object sender, testDataSet.testRowChangeEvent e);
    }
}

