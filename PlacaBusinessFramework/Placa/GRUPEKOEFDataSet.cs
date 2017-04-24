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
    public class GRUPEKOEFDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private GRUPEKOEFDataTable tableGRUPEKOEF;
        private GRUPEKOEFLevel1DataTable tableGRUPEKOEFLevel1;

        public GRUPEKOEFDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected GRUPEKOEFDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["GRUPEKOEFLevel1"] != null)
                    {
                        this.Tables.Add(new GRUPEKOEFLevel1DataTable(dataSet.Tables["GRUPEKOEFLevel1"]));
                    }
                    if (dataSet.Tables["GRUPEKOEF"] != null)
                    {
                        this.Tables.Add(new GRUPEKOEFDataTable(dataSet.Tables["GRUPEKOEF"]));
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
            GRUPEKOEFDataSet set = (GRUPEKOEFDataSet) base.Clone();
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
            GRUPEKOEFDataSet set = new GRUPEKOEFDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "GRUPEKOEFDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2065");
            this.ExtendedProperties.Add("DataSetName", "GRUPEKOEFDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IGRUPEKOEFDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "GRUPEKOEF");
            this.ExtendedProperties.Add("ObjectDescription", "Grupe koeficijenata");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "GRUPEKOEFDataSet";
            this.Namespace = "http://www.tempuri.org/GRUPEKOEF";
            this.tableGRUPEKOEFLevel1 = new GRUPEKOEFLevel1DataTable();
            this.Tables.Add(this.tableGRUPEKOEFLevel1);
            this.tableGRUPEKOEF = new GRUPEKOEFDataTable();
            this.Tables.Add(this.tableGRUPEKOEF);
            this.Relations.Add("GRUPEKOEF_GRUPEKOEFLevel1", new DataColumn[] { this.Tables["GRUPEKOEF"].Columns["IDGRUPEKOEF"] }, new DataColumn[] { this.Tables["GRUPEKOEFLevel1"].Columns["IDGRUPEKOEF"] });
            this.Relations["GRUPEKOEF_GRUPEKOEFLevel1"].Nested = true;
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
            this.tableGRUPEKOEFLevel1 = (GRUPEKOEFLevel1DataTable) this.Tables["GRUPEKOEFLevel1"];
            this.tableGRUPEKOEF = (GRUPEKOEFDataTable) this.Tables["GRUPEKOEF"];
            if (initTable)
            {
                if (this.tableGRUPEKOEFLevel1 != null)
                {
                    this.tableGRUPEKOEFLevel1.InitVars();
                }
                if (this.tableGRUPEKOEF != null)
                {
                    this.tableGRUPEKOEF.InitVars();
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
                if (dataSet.Tables["GRUPEKOEFLevel1"] != null)
                {
                    this.Tables.Add(new GRUPEKOEFLevel1DataTable(dataSet.Tables["GRUPEKOEFLevel1"]));
                }
                if (dataSet.Tables["GRUPEKOEF"] != null)
                {
                    this.Tables.Add(new GRUPEKOEFDataTable(dataSet.Tables["GRUPEKOEF"]));
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

        private bool ShouldSerializeGRUPEKOEF()
        {
            return false;
        }

        private bool ShouldSerializeGRUPEKOEFLevel1()
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
        public GRUPEKOEFDataTable GRUPEKOEF
        {
            get
            {
                return this.tableGRUPEKOEF;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GRUPEKOEFLevel1DataTable GRUPEKOEFLevel1
        {
            get
            {
                return this.tableGRUPEKOEFLevel1;
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
        public class GRUPEKOEFDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDGRUPEKOEF;
            private DataColumn columnNAZIVGRUPEKOEF;

            public event GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler GRUPEKOEFRowChanged;

            public event GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler GRUPEKOEFRowChanging;

            public event GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler GRUPEKOEFRowDeleted;

            public event GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler GRUPEKOEFRowDeleting;

            public GRUPEKOEFDataTable()
            {
                this.TableName = "GRUPEKOEF";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal GRUPEKOEFDataTable(DataTable table) : base(table.TableName)
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

            protected GRUPEKOEFDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddGRUPEKOEFRow(GRUPEKOEFDataSet.GRUPEKOEFRow row)
            {
                this.Rows.Add(row);
            }

            public GRUPEKOEFDataSet.GRUPEKOEFRow AddGRUPEKOEFRow(int iDGRUPEKOEF, string nAZIVGRUPEKOEF)
            {
                GRUPEKOEFDataSet.GRUPEKOEFRow row = (GRUPEKOEFDataSet.GRUPEKOEFRow) this.NewRow();
                row["IDGRUPEKOEF"] = iDGRUPEKOEF;
                row["NAZIVGRUPEKOEF"] = nAZIVGRUPEKOEF;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                GRUPEKOEFDataSet.GRUPEKOEFDataTable table = (GRUPEKOEFDataSet.GRUPEKOEFDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public GRUPEKOEFDataSet.GRUPEKOEFRow FindByIDGRUPEKOEF(int iDGRUPEKOEF)
            {
                return (GRUPEKOEFDataSet.GRUPEKOEFRow) this.Rows.Find(new object[] { iDGRUPEKOEF });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(GRUPEKOEFDataSet.GRUPEKOEFRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                GRUPEKOEFDataSet set = new GRUPEKOEFDataSet();
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
                this.columnIDGRUPEKOEF = new DataColumn("IDGRUPEKOEF", typeof(int), "", MappingType.Element);
                this.columnIDGRUPEKOEF.AllowDBNull = false;
                this.columnIDGRUPEKOEF.Caption = "IDGRUPEKOEF";
                this.columnIDGRUPEKOEF.Unique = true;
                this.columnIDGRUPEKOEF.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Length", "5");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.InternalName", "IDGRUPEKOEF");
                this.Columns.Add(this.columnIDGRUPEKOEF);
                this.columnNAZIVGRUPEKOEF = new DataColumn("NAZIVGRUPEKOEF", typeof(string), "", MappingType.Element);
                this.columnNAZIVGRUPEKOEF.AllowDBNull = false;
                this.columnNAZIVGRUPEKOEF.Caption = "NAZIVGRUPEKOEF";
                this.columnNAZIVGRUPEKOEF.MaxLength = 50;
                this.columnNAZIVGRUPEKOEF.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVGRUPEKOEF.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVGRUPEKOEF");
                this.Columns.Add(this.columnNAZIVGRUPEKOEF);
                this.PrimaryKey = new DataColumn[] { this.columnIDGRUPEKOEF };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "GRUPEKOEF");
                this.ExtendedProperties.Add("Description", "Grupe koeficijenata");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDGRUPEKOEF = this.Columns["IDGRUPEKOEF"];
                this.columnNAZIVGRUPEKOEF = this.Columns["NAZIVGRUPEKOEF"];
            }

            public GRUPEKOEFDataSet.GRUPEKOEFRow NewGRUPEKOEFRow()
            {
                return (GRUPEKOEFDataSet.GRUPEKOEFRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new GRUPEKOEFDataSet.GRUPEKOEFRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GRUPEKOEFRowChanged != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler gRUPEKOEFRowChangedEvent = this.GRUPEKOEFRowChanged;
                    if (gRUPEKOEFRowChangedEvent != null)
                    {
                        gRUPEKOEFRowChangedEvent(this, new GRUPEKOEFDataSet.GRUPEKOEFRowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GRUPEKOEFRowChanging != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler gRUPEKOEFRowChangingEvent = this.GRUPEKOEFRowChanging;
                    if (gRUPEKOEFRowChangingEvent != null)
                    {
                        gRUPEKOEFRowChangingEvent(this, new GRUPEKOEFDataSet.GRUPEKOEFRowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GRUPEKOEFRowDeleted != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler gRUPEKOEFRowDeletedEvent = this.GRUPEKOEFRowDeleted;
                    if (gRUPEKOEFRowDeletedEvent != null)
                    {
                        gRUPEKOEFRowDeletedEvent(this, new GRUPEKOEFDataSet.GRUPEKOEFRowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GRUPEKOEFRowDeleting != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFRowChangeEventHandler gRUPEKOEFRowDeletingEvent = this.GRUPEKOEFRowDeleting;
                    if (gRUPEKOEFRowDeletingEvent != null)
                    {
                        gRUPEKOEFRowDeletingEvent(this, new GRUPEKOEFDataSet.GRUPEKOEFRowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveGRUPEKOEFRow(GRUPEKOEFDataSet.GRUPEKOEFRow row)
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

            public DataColumn IDGRUPEKOEFColumn
            {
                get
                {
                    return this.columnIDGRUPEKOEF;
                }
            }

            public GRUPEKOEFDataSet.GRUPEKOEFRow this[int index]
            {
                get
                {
                    return (GRUPEKOEFDataSet.GRUPEKOEFRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVGRUPEKOEFColumn
            {
                get
                {
                    return this.columnNAZIVGRUPEKOEF;
                }
            }
        }

        [Serializable]
        public class GRUPEKOEFLevel1DataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDELEMENT;
            private DataColumn columnIDGRUPEKOEF;
            private DataColumn columnIDMZOSTABLICE;
            private DataColumn columnNAZIVELEMENT;

            public event GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler GRUPEKOEFLevel1RowChanged;

            public event GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler GRUPEKOEFLevel1RowChanging;

            public event GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler GRUPEKOEFLevel1RowDeleted;

            public event GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler GRUPEKOEFLevel1RowDeleting;

            public GRUPEKOEFLevel1DataTable()
            {
                this.TableName = "GRUPEKOEFLevel1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal GRUPEKOEFLevel1DataTable(DataTable table) : base(table.TableName)
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

            protected GRUPEKOEFLevel1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddGRUPEKOEFLevel1Row(GRUPEKOEFDataSet.GRUPEKOEFLevel1Row row)
            {
                this.Rows.Add(row);
            }

            public GRUPEKOEFDataSet.GRUPEKOEFLevel1Row AddGRUPEKOEFLevel1Row(int iDGRUPEKOEF, int iDELEMENT, int iDMZOSTABLICE)
            {
                GRUPEKOEFDataSet.GRUPEKOEFLevel1Row row = (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) this.NewRow();
                row["IDGRUPEKOEF"] = iDGRUPEKOEF;
                row["IDELEMENT"] = iDELEMENT;
                row["IDMZOSTABLICE"] = iDMZOSTABLICE;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                GRUPEKOEFDataSet.GRUPEKOEFLevel1DataTable table = (GRUPEKOEFDataSet.GRUPEKOEFLevel1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public GRUPEKOEFDataSet.GRUPEKOEFLevel1Row FindByIDGRUPEKOEFIDELEMENT(int iDGRUPEKOEF, int iDELEMENT)
            {
                return (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) this.Rows.Find(new object[] { iDGRUPEKOEF, iDELEMENT });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(GRUPEKOEFDataSet.GRUPEKOEFLevel1Row);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                GRUPEKOEFDataSet set = new GRUPEKOEFDataSet();
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
                this.columnIDGRUPEKOEF = new DataColumn("IDGRUPEKOEF", typeof(int), "", MappingType.Element);
                this.columnIDGRUPEKOEF.AllowDBNull = false;
                this.columnIDGRUPEKOEF.Caption = "IDGRUPEKOEF";
                this.columnIDGRUPEKOEF.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("IsKey", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Length", "5");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Decimals", "0");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDGRUPEKOEF.ExtendedProperties.Add("Deklarit.InternalName", "IDGRUPEKOEF");
                this.Columns.Add(this.columnIDGRUPEKOEF);
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
                this.columnNAZIVELEMENT = new DataColumn("NAZIVELEMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVELEMENT.AllowDBNull = true;
                this.columnNAZIVELEMENT.Caption = "Naziv elementa";
                this.columnNAZIVELEMENT.MaxLength = 50;
                this.columnNAZIVELEMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Description", "Naziv elementa");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVELEMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVELEMENT");
                this.Columns.Add(this.columnNAZIVELEMENT);
                this.columnIDMZOSTABLICE = new DataColumn("IDMZOSTABLICE", typeof(int), "", MappingType.Element);
                this.columnIDMZOSTABLICE.AllowDBNull = false;
                this.columnIDMZOSTABLICE.Caption = "Šifra tablice";
                this.columnIDMZOSTABLICE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("IsKey", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Description", "MZOŠ Tablica");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Length", "5");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDMZOSTABLICE.ExtendedProperties.Add("Deklarit.InternalName", "IDMZOSTABLICE");
                this.Columns.Add(this.columnIDMZOSTABLICE);
                this.PrimaryKey = new DataColumn[] { this.columnIDGRUPEKOEF, this.columnIDELEMENT };
                this.ExtendedProperties.Add("ParentLvl", "GRUPEKOEF");
                this.ExtendedProperties.Add("LevelName", "GrupeElementi");
                this.ExtendedProperties.Add("Description", "Elementi u grupi");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDGRUPEKOEF = this.Columns["IDGRUPEKOEF"];
                this.columnIDELEMENT = this.Columns["IDELEMENT"];
                this.columnNAZIVELEMENT = this.Columns["NAZIVELEMENT"];
                this.columnIDMZOSTABLICE = this.Columns["IDMZOSTABLICE"];
            }

            public GRUPEKOEFDataSet.GRUPEKOEFLevel1Row NewGRUPEKOEFLevel1Row()
            {
                return (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new GRUPEKOEFDataSet.GRUPEKOEFLevel1Row(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GRUPEKOEFLevel1RowChanged != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler handler = this.GRUPEKOEFLevel1RowChanged;
                    if (handler != null)
                    {
                        handler(this, new GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GRUPEKOEFLevel1RowChanging != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler handler = this.GRUPEKOEFLevel1RowChanging;
                    if (handler != null)
                    {
                        handler(this, new GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("GRUPEKOEF_GRUPEKOEFLevel1", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.GRUPEKOEFLevel1RowDeleted != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler handler = this.GRUPEKOEFLevel1RowDeleted;
                    if (handler != null)
                    {
                        handler(this, new GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GRUPEKOEFLevel1RowDeleting != null)
                {
                    GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEventHandler handler = this.GRUPEKOEFLevel1RowDeleting;
                    if (handler != null)
                    {
                        handler(this, new GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEvent((GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) e.Row, e.Action));
                    }
                }
            }

            public void RemoveGRUPEKOEFLevel1Row(GRUPEKOEFDataSet.GRUPEKOEFLevel1Row row)
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

            public DataColumn IDGRUPEKOEFColumn
            {
                get
                {
                    return this.columnIDGRUPEKOEF;
                }
            }

            public DataColumn IDMZOSTABLICEColumn
            {
                get
                {
                    return this.columnIDMZOSTABLICE;
                }
            }

            public GRUPEKOEFDataSet.GRUPEKOEFLevel1Row this[int index]
            {
                get
                {
                    return (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) this.Rows[index];
                }
            }

            public DataColumn NAZIVELEMENTColumn
            {
                get
                {
                    return this.columnNAZIVELEMENT;
                }
            }
        }

        public class GRUPEKOEFLevel1Row : DataRow
        {
            private GRUPEKOEFDataSet.GRUPEKOEFLevel1DataTable tableGRUPEKOEFLevel1;

            internal GRUPEKOEFLevel1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableGRUPEKOEFLevel1 = (GRUPEKOEFDataSet.GRUPEKOEFLevel1DataTable) this.Table;
            }

            public GRUPEKOEFDataSet.GRUPEKOEFRow GetGRUPEKOEFRow()
            {
                return (GRUPEKOEFDataSet.GRUPEKOEFRow) this.GetParentRow("GRUPEKOEF_GRUPEKOEFLevel1");
            }

            public bool IsIDELEMENTNull()
            {
                return this.IsNull(this.tableGRUPEKOEFLevel1.IDELEMENTColumn);
            }

            public bool IsIDGRUPEKOEFNull()
            {
                return this.IsNull(this.tableGRUPEKOEFLevel1.IDGRUPEKOEFColumn);
            }

            public bool IsIDMZOSTABLICENull()
            {
                return this.IsNull(this.tableGRUPEKOEFLevel1.IDMZOSTABLICEColumn);
            }

            public bool IsNAZIVELEMENTNull()
            {
                return this.IsNull(this.tableGRUPEKOEFLevel1.NAZIVELEMENTColumn);
            }

            public void SetIDMZOSTABLICENull()
            {
                this[this.tableGRUPEKOEFLevel1.IDMZOSTABLICEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVELEMENTNull()
            {
                this[this.tableGRUPEKOEFLevel1.NAZIVELEMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDELEMENT
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableGRUPEKOEFLevel1.IDELEMENTColumn]);
                }
                set
                {
                    this[this.tableGRUPEKOEFLevel1.IDELEMENTColumn] = value;
                }
            }

            public int IDGRUPEKOEF
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableGRUPEKOEFLevel1.IDGRUPEKOEFColumn]);
                }
                set
                {
                    this[this.tableGRUPEKOEFLevel1.IDGRUPEKOEFColumn] = value;
                }
            }

            public int IDMZOSTABLICE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableGRUPEKOEFLevel1.IDMZOSTABLICEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDMZOSTABLICE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableGRUPEKOEFLevel1.IDMZOSTABLICEColumn] = value;
                }
            }

            public string NAZIVELEMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGRUPEKOEFLevel1.NAZIVELEMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVELEMENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableGRUPEKOEFLevel1.NAZIVELEMENTColumn] = value;
                }
            }
        }

        public class GRUPEKOEFLevel1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private GRUPEKOEFDataSet.GRUPEKOEFLevel1Row eventRow;

            public GRUPEKOEFLevel1RowChangeEvent(GRUPEKOEFDataSet.GRUPEKOEFLevel1Row row, DataRowAction action)
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

            public GRUPEKOEFDataSet.GRUPEKOEFLevel1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GRUPEKOEFLevel1RowChangeEventHandler(object sender, GRUPEKOEFDataSet.GRUPEKOEFLevel1RowChangeEvent e);

        public class GRUPEKOEFRow : DataRow
        {
            private GRUPEKOEFDataSet.GRUPEKOEFDataTable tableGRUPEKOEF;

            internal GRUPEKOEFRow(DataRowBuilder rb) : base(rb)
            {
                this.tableGRUPEKOEF = (GRUPEKOEFDataSet.GRUPEKOEFDataTable) this.Table;
            }

            public GRUPEKOEFDataSet.GRUPEKOEFLevel1Row[] GetGRUPEKOEFLevel1Rows()
            {
                return (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row[]) this.GetChildRows("GRUPEKOEF_GRUPEKOEFLevel1");
            }

            public bool IsIDGRUPEKOEFNull()
            {
                return this.IsNull(this.tableGRUPEKOEF.IDGRUPEKOEFColumn);
            }

            public bool IsNAZIVGRUPEKOEFNull()
            {
                return this.IsNull(this.tableGRUPEKOEF.NAZIVGRUPEKOEFColumn);
            }

            public void SetNAZIVGRUPEKOEFNull()
            {
                this[this.tableGRUPEKOEF.NAZIVGRUPEKOEFColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDGRUPEKOEF
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableGRUPEKOEF.IDGRUPEKOEFColumn]);
                }
                set
                {
                    this[this.tableGRUPEKOEF.IDGRUPEKOEFColumn] = value;
                }
            }

            public string NAZIVGRUPEKOEF
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableGRUPEKOEF.NAZIVGRUPEKOEFColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableGRUPEKOEF.NAZIVGRUPEKOEFColumn] = value;
                }
            }
        }

        public class GRUPEKOEFRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private GRUPEKOEFDataSet.GRUPEKOEFRow eventRow;

            public GRUPEKOEFRowChangeEvent(GRUPEKOEFDataSet.GRUPEKOEFRow row, DataRowAction action)
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

            public GRUPEKOEFDataSet.GRUPEKOEFRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void GRUPEKOEFRowChangeEventHandler(object sender, GRUPEKOEFDataSet.GRUPEKOEFRowChangeEvent e);
    }
}

