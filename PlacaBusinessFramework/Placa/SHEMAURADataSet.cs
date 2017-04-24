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
    public class SHEMAURADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private SHEMAURADataTable tableSHEMAURA;
        private SHEMAURASHEMAURAKONTIRANJEDataTable tableSHEMAURASHEMAURAKONTIRANJE;

        public SHEMAURADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected SHEMAURADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["SHEMAURASHEMAURAKONTIRANJE"] != null)
                    {
                        this.Tables.Add(new SHEMAURASHEMAURAKONTIRANJEDataTable(dataSet.Tables["SHEMAURASHEMAURAKONTIRANJE"]));
                    }
                    if (dataSet.Tables["SHEMAURA"] != null)
                    {
                        this.Tables.Add(new SHEMAURADataTable(dataSet.Tables["SHEMAURA"]));
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
            SHEMAURADataSet set = (SHEMAURADataSet) base.Clone();
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
            SHEMAURADataSet set = new SHEMAURADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "SHEMAURADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2109");
            this.ExtendedProperties.Add("DataSetName", "SHEMAURADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "ISHEMAURADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "SHEMAURA");
            this.ExtendedProperties.Add("ObjectDescription", "Shema kontiranja URA");
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
            this.DataSetName = "SHEMAURADataSet";
            this.Namespace = "http://www.tempuri.org/SHEMAURA";
            this.tableSHEMAURASHEMAURAKONTIRANJE = new SHEMAURASHEMAURAKONTIRANJEDataTable();
            this.Tables.Add(this.tableSHEMAURASHEMAURAKONTIRANJE);
            this.tableSHEMAURA = new SHEMAURADataTable();
            this.Tables.Add(this.tableSHEMAURA);
            this.Relations.Add("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE", new DataColumn[] { this.Tables["SHEMAURA"].Columns["IDSHEMAURA"] }, new DataColumn[] { this.Tables["SHEMAURASHEMAURAKONTIRANJE"].Columns["IDSHEMAURA"] });
            this.Relations["SHEMAURA_SHEMAURASHEMAURAKONTIRANJE"].Nested = true;
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
            this.tableSHEMAURASHEMAURAKONTIRANJE = (SHEMAURASHEMAURAKONTIRANJEDataTable) this.Tables["SHEMAURASHEMAURAKONTIRANJE"];
            this.tableSHEMAURA = (SHEMAURADataTable) this.Tables["SHEMAURA"];
            if (initTable)
            {
                if (this.tableSHEMAURASHEMAURAKONTIRANJE != null)
                {
                    this.tableSHEMAURASHEMAURAKONTIRANJE.InitVars();
                }
                if (this.tableSHEMAURA != null)
                {
                    this.tableSHEMAURA.InitVars();
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
                if (dataSet.Tables["SHEMAURASHEMAURAKONTIRANJE"] != null)
                {
                    this.Tables.Add(new SHEMAURASHEMAURAKONTIRANJEDataTable(dataSet.Tables["SHEMAURASHEMAURAKONTIRANJE"]));
                }
                if (dataSet.Tables["SHEMAURA"] != null)
                {
                    this.Tables.Add(new SHEMAURADataTable(dataSet.Tables["SHEMAURA"]));
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

        private bool ShouldSerializeSHEMAURA()
        {
            return false;
        }

        private bool ShouldSerializeSHEMAURASHEMAURAKONTIRANJE()
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
        public SHEMAURADataTable SHEMAURA
        {
            get
            {
                return this.tableSHEMAURA;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SHEMAURASHEMAURAKONTIRANJEDataTable SHEMAURASHEMAURAKONTIRANJE
        {
            get
            {
                return this.tableSHEMAURASHEMAURAKONTIRANJE;
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
        public class SHEMAURADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMAURA;
            private DataColumn columnNAZIVSHEMAURA;
            private DataColumn columnPARTNERSHEMAURAIDPARTNER;

            public event SHEMAURADataSet.SHEMAURARowChangeEventHandler SHEMAURARowChanged;

            public event SHEMAURADataSet.SHEMAURARowChangeEventHandler SHEMAURARowChanging;

            public event SHEMAURADataSet.SHEMAURARowChangeEventHandler SHEMAURARowDeleted;

            public event SHEMAURADataSet.SHEMAURARowChangeEventHandler SHEMAURARowDeleting;

            public SHEMAURADataTable()
            {
                this.TableName = "SHEMAURA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAURADataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAURADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAURARow(SHEMAURADataSet.SHEMAURARow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAURADataSet.SHEMAURARow AddSHEMAURARow(int iDSHEMAURA, string nAZIVSHEMAURA, int pARTNERSHEMAURAIDPARTNER)
            {
                SHEMAURADataSet.SHEMAURARow row = (SHEMAURADataSet.SHEMAURARow) this.NewRow();
                row["IDSHEMAURA"] = iDSHEMAURA;
                row["NAZIVSHEMAURA"] = nAZIVSHEMAURA;
                row["PARTNERSHEMAURAIDPARTNER"] = pARTNERSHEMAURAIDPARTNER;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAURADataSet.SHEMAURADataTable table = (SHEMAURADataSet.SHEMAURADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAURADataSet.SHEMAURARow FindByIDSHEMAURA(int iDSHEMAURA)
            {
                return (SHEMAURADataSet.SHEMAURARow) this.Rows.Find(new object[] { iDSHEMAURA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAURADataSet.SHEMAURARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAURADataSet set = new SHEMAURADataSet();
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
                this.columnIDSHEMAURA = new DataColumn("IDSHEMAURA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAURA.AllowDBNull = false;
                this.columnIDSHEMAURA.Caption = "IDSHEMAURA";
                this.columnIDSHEMAURA.Unique = true;
                this.columnIDSHEMAURA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAURA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDSHEMAURA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAURA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAURA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAURA");
                this.Columns.Add(this.columnIDSHEMAURA);
                this.columnNAZIVSHEMAURA = new DataColumn("NAZIVSHEMAURA", typeof(string), "", MappingType.Element);
                this.columnNAZIVSHEMAURA.AllowDBNull = false;
                this.columnNAZIVSHEMAURA.Caption = "NAZIVSHEMAURA";
                this.columnNAZIVSHEMAURA.MaxLength = 50;
                this.columnNAZIVSHEMAURA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Description", "Naziv");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVSHEMAURA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVSHEMAURA");
                this.Columns.Add(this.columnNAZIVSHEMAURA);
                this.columnPARTNERSHEMAURAIDPARTNER = new DataColumn("PARTNERSHEMAURAIDPARTNER", typeof(int), "", MappingType.Element);
                this.columnPARTNERSHEMAURAIDPARTNER.AllowDBNull = false;
                this.columnPARTNERSHEMAURAIDPARTNER.Caption = "Šifra partnera";
                this.columnPARTNERSHEMAURAIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("SuperType", "IDPARTNER");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("SubtypeGroup", "PARTNERSHEMAURA");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Description", "Partner");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERSHEMAURAIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERSHEMAURAIDPARTNER");
                this.Columns.Add(this.columnPARTNERSHEMAURAIDPARTNER);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAURA };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "SHEMAURA");
                this.ExtendedProperties.Add("Description", "Shema kontiranja URA");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAURA = this.Columns["IDSHEMAURA"];
                this.columnNAZIVSHEMAURA = this.Columns["NAZIVSHEMAURA"];
                this.columnPARTNERSHEMAURAIDPARTNER = this.Columns["PARTNERSHEMAURAIDPARTNER"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAURADataSet.SHEMAURARow(builder);
            }

            public SHEMAURADataSet.SHEMAURARow NewSHEMAURARow()
            {
                return (SHEMAURADataSet.SHEMAURARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAURARowChanged != null)
                {
                    SHEMAURADataSet.SHEMAURARowChangeEventHandler sHEMAURARowChangedEvent = this.SHEMAURARowChanged;
                    if (sHEMAURARowChangedEvent != null)
                    {
                        sHEMAURARowChangedEvent(this, new SHEMAURADataSet.SHEMAURARowChangeEvent((SHEMAURADataSet.SHEMAURARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAURARowChanged != null)
                {
                    SHEMAURADataSet.SHEMAURARowChangeEventHandler sHEMAURARowChangingEvent = this.SHEMAURARowChanging;
                    if (sHEMAURARowChangingEvent != null)
                    {
                        sHEMAURARowChangingEvent(this, new SHEMAURADataSet.SHEMAURARowChangeEvent((SHEMAURADataSet.SHEMAURARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SHEMAURARowDeleted != null)
                {
                    SHEMAURADataSet.SHEMAURARowChangeEventHandler sHEMAURARowDeletedEvent = this.SHEMAURARowDeleted;
                    if (sHEMAURARowDeletedEvent != null)
                    {
                        sHEMAURARowDeletedEvent(this, new SHEMAURADataSet.SHEMAURARowChangeEvent((SHEMAURADataSet.SHEMAURARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAURARowDeleting != null)
                {
                    SHEMAURADataSet.SHEMAURARowChangeEventHandler sHEMAURARowDeletingEvent = this.SHEMAURARowDeleting;
                    if (sHEMAURARowDeletingEvent != null)
                    {
                        sHEMAURARowDeletingEvent(this, new SHEMAURADataSet.SHEMAURARowChangeEvent((SHEMAURADataSet.SHEMAURARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAURARow(SHEMAURADataSet.SHEMAURARow row)
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

            public DataColumn IDSHEMAURAColumn
            {
                get
                {
                    return this.columnIDSHEMAURA;
                }
            }

            public SHEMAURADataSet.SHEMAURARow this[int index]
            {
                get
                {
                    return (SHEMAURADataSet.SHEMAURARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVSHEMAURAColumn
            {
                get
                {
                    return this.columnNAZIVSHEMAURA;
                }
            }

            public DataColumn PARTNERSHEMAURAIDPARTNERColumn
            {
                get
                {
                    return this.columnPARTNERSHEMAURAIDPARTNER;
                }
            }
        }

        public class SHEMAURARow : DataRow
        {
            private SHEMAURADataSet.SHEMAURADataTable tableSHEMAURA;

            internal SHEMAURARow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAURA = (SHEMAURADataSet.SHEMAURADataTable) this.Table;
            }

            public SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow[] GetSHEMAURASHEMAURAKONTIRANJERows()
            {
                return (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow[]) this.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE");
            }

            public bool IsIDSHEMAURANull()
            {
                return this.IsNull(this.tableSHEMAURA.IDSHEMAURAColumn);
            }

            public bool IsNAZIVSHEMAURANull()
            {
                return this.IsNull(this.tableSHEMAURA.NAZIVSHEMAURAColumn);
            }

            public bool IsPARTNERSHEMAURAIDPARTNERNull()
            {
                return this.IsNull(this.tableSHEMAURA.PARTNERSHEMAURAIDPARTNERColumn);
            }

            public void SetNAZIVSHEMAURANull()
            {
                this[this.tableSHEMAURA.NAZIVSHEMAURAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERSHEMAURAIDPARTNERNull()
            {
                this[this.tableSHEMAURA.PARTNERSHEMAURAIDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMAURA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAURA.IDSHEMAURAColumn]);
                }
                set
                {
                    this[this.tableSHEMAURA.IDSHEMAURAColumn] = value;
                }
            }

            public string NAZIVSHEMAURA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableSHEMAURA.NAZIVSHEMAURAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVSHEMAURA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableSHEMAURA.NAZIVSHEMAURAColumn] = value;
                }
            }

            public int PARTNERSHEMAURAIDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAURA.PARTNERSHEMAURAIDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PARTNERSHEMAURAIDPARTNER because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAURA.PARTNERSHEMAURAIDPARTNERColumn] = value;
                }
            }
        }

        public class SHEMAURARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAURADataSet.SHEMAURARow eventRow;

            public SHEMAURARowChangeEvent(SHEMAURADataSet.SHEMAURARow row, DataRowAction action)
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

            public SHEMAURADataSet.SHEMAURARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAURARowChangeEventHandler(object sender, SHEMAURADataSet.SHEMAURARowChangeEvent e);

        [Serializable]
        public class SHEMAURASHEMAURAKONTIRANJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDSHEMAURA;
            private DataColumn columnIDURAVRSTAIZNOSA;
            private DataColumn columnSHEMAURAKONTOIDKONTO;
            private DataColumn columnSHEMAURAMTIDMJESTOTROSKA;
            private DataColumn columnSHEMAURAOJIDORGJED;
            private DataColumn columnSHEMAURASTRANEIDSTRANEKNJIZENJA;

            public event SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler SHEMAURASHEMAURAKONTIRANJERowChanged;

            public event SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler SHEMAURASHEMAURAKONTIRANJERowChanging;

            public event SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler SHEMAURASHEMAURAKONTIRANJERowDeleted;

            public event SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler SHEMAURASHEMAURAKONTIRANJERowDeleting;

            public SHEMAURASHEMAURAKONTIRANJEDataTable()
            {
                this.TableName = "SHEMAURASHEMAURAKONTIRANJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal SHEMAURASHEMAURAKONTIRANJEDataTable(DataTable table) : base(table.TableName)
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

            protected SHEMAURASHEMAURAKONTIRANJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddSHEMAURASHEMAURAKONTIRANJERow(SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow row)
            {
                this.Rows.Add(row);
            }

            public SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow AddSHEMAURASHEMAURAKONTIRANJERow(int iDSHEMAURA, string sHEMAURAKONTOIDKONTO, int sHEMAURASTRANEIDSTRANEKNJIZENJA, int iDURAVRSTAIZNOSA, int sHEMAURAMTIDMJESTOTROSKA, int sHEMAURAOJIDORGJED)
            {
                SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow row = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) this.NewRow();
                row["IDSHEMAURA"] = iDSHEMAURA;
                row["SHEMAURAKONTOIDKONTO"] = sHEMAURAKONTOIDKONTO;
                row["SHEMAURASTRANEIDSTRANEKNJIZENJA"] = sHEMAURASTRANEIDSTRANEKNJIZENJA;
                row["IDURAVRSTAIZNOSA"] = iDURAVRSTAIZNOSA;
                row["SHEMAURAMTIDMJESTOTROSKA"] = sHEMAURAMTIDMJESTOTROSKA;
                row["SHEMAURAOJIDORGJED"] = sHEMAURAOJIDORGJED;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJEDataTable table = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow FindByIDSHEMAURASHEMAURAKONTOIDKONTOSHEMAURASTRANEIDSTRANEKNJIZENJAIDURAVRSTAIZNOSA(int iDSHEMAURA, string sHEMAURAKONTOIDKONTO, int sHEMAURASTRANEIDSTRANEKNJIZENJA, int iDURAVRSTAIZNOSA)
            {
                return (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) this.Rows.Find(new object[] { iDSHEMAURA, sHEMAURAKONTOIDKONTO, sHEMAURASTRANEIDSTRANEKNJIZENJA, iDURAVRSTAIZNOSA });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                SHEMAURADataSet set = new SHEMAURADataSet();
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
                this.columnIDSHEMAURA = new DataColumn("IDSHEMAURA", typeof(int), "", MappingType.Element);
                this.columnIDSHEMAURA.AllowDBNull = false;
                this.columnIDSHEMAURA.Caption = "IDSHEMAURA";
                this.columnIDSHEMAURA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDSHEMAURA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Length", "5");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDSHEMAURA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDSHEMAURA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDSHEMAURA.ExtendedProperties.Add("Deklarit.InternalName", "IDSHEMAURA");
                this.Columns.Add(this.columnIDSHEMAURA);
                this.columnSHEMAURAKONTOIDKONTO = new DataColumn("SHEMAURAKONTOIDKONTO", typeof(string), "", MappingType.Element);
                this.columnSHEMAURAKONTOIDKONTO.AllowDBNull = false;
                this.columnSHEMAURAKONTOIDKONTO.Caption = "Konto";
                this.columnSHEMAURAKONTOIDKONTO.MaxLength = 14;
                this.columnSHEMAURAKONTOIDKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("SuperType", "IDKONTO");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("SubtypeGroup", "SHEMAURAKONTO");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Description", "Konto");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Length", "14");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAURAKONTOIDKONTO.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAURAKONTOIDKONTO");
                this.Columns.Add(this.columnSHEMAURAKONTOIDKONTO);
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA = new DataColumn("SHEMAURASTRANEIDSTRANEKNJIZENJA", typeof(int), "", MappingType.Element);
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.AllowDBNull = false;
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.Caption = "IDSTRANEKNJIZENJA";
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("SuperType", "IDSTRANEKNJIZENJA");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("SubtypeGroup", "SHEMAURASTRANE");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("IsKey", "true");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Description", "Strana knjiženja");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Length", "5");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAURASTRANEIDSTRANEKNJIZENJA");
                this.Columns.Add(this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA);
                this.columnIDURAVRSTAIZNOSA = new DataColumn("IDURAVRSTAIZNOSA", typeof(int), "", MappingType.Element);
                this.columnIDURAVRSTAIZNOSA.AllowDBNull = false;
                this.columnIDURAVRSTAIZNOSA.Caption = "IDURAVRSTAIZNOSA";
                this.columnIDURAVRSTAIZNOSA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Description", "Vrsta iznosa");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Length", "5");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDURAVRSTAIZNOSA.ExtendedProperties.Add("Deklarit.InternalName", "IDURAVRSTAIZNOSA");
                this.Columns.Add(this.columnIDURAVRSTAIZNOSA);
                this.columnSHEMAURAMTIDMJESTOTROSKA = new DataColumn("SHEMAURAMTIDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnSHEMAURAMTIDMJESTOTROSKA.AllowDBNull = false;
                this.columnSHEMAURAMTIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnSHEMAURAMTIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("SuperType", "IDMJESTOTROSKA");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("SubtypeGroup", "SHEMAURAMT");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAURAMTIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAURAMTIDMJESTOTROSKA");
                this.Columns.Add(this.columnSHEMAURAMTIDMJESTOTROSKA);
                this.columnSHEMAURAOJIDORGJED = new DataColumn("SHEMAURAOJIDORGJED", typeof(int), "", MappingType.Element);
                this.columnSHEMAURAOJIDORGJED.AllowDBNull = false;
                this.columnSHEMAURAOJIDORGJED.Caption = "Šifra OJ";
                this.columnSHEMAURAOJIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("SuperType", "IDORGJED");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("SubtypeGroup", "SHEMAURAOJ");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("ReadOnly", "false");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSHEMAURAOJIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "SHEMAURAOJIDORGJED");
                this.Columns.Add(this.columnSHEMAURAOJIDORGJED);
                this.PrimaryKey = new DataColumn[] { this.columnIDSHEMAURA, this.columnSHEMAURAKONTOIDKONTO, this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA, this.columnIDURAVRSTAIZNOSA };
                this.ExtendedProperties.Add("ParentLvl", "SHEMAURA");
                this.ExtendedProperties.Add("LevelName", "SHEMAURAKONTIRANJE");
                this.ExtendedProperties.Add("Description", "SHEMAURAKONTIRANJE");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDSHEMAURA = this.Columns["IDSHEMAURA"];
                this.columnSHEMAURAKONTOIDKONTO = this.Columns["SHEMAURAKONTOIDKONTO"];
                this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA = this.Columns["SHEMAURASTRANEIDSTRANEKNJIZENJA"];
                this.columnIDURAVRSTAIZNOSA = this.Columns["IDURAVRSTAIZNOSA"];
                this.columnSHEMAURAMTIDMJESTOTROSKA = this.Columns["SHEMAURAMTIDMJESTOTROSKA"];
                this.columnSHEMAURAOJIDORGJED = this.Columns["SHEMAURAOJIDORGJED"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow(builder);
            }

            public SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow NewSHEMAURASHEMAURAKONTIRANJERow()
            {
                return (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SHEMAURASHEMAURAKONTIRANJERowChanged != null)
                {
                    SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler sHEMAURASHEMAURAKONTIRANJERowChangedEvent = this.SHEMAURASHEMAURAKONTIRANJERowChanged;
                    if (sHEMAURASHEMAURAKONTIRANJERowChangedEvent != null)
                    {
                        sHEMAURASHEMAURAKONTIRANJERowChangedEvent(this, new SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEvent((SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SHEMAURASHEMAURAKONTIRANJERowChanging != null)
                {
                    SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler sHEMAURASHEMAURAKONTIRANJERowChangingEvent = this.SHEMAURASHEMAURAKONTIRANJERowChanging;
                    if (sHEMAURASHEMAURAKONTIRANJERowChangingEvent != null)
                    {
                        sHEMAURASHEMAURAKONTIRANJERowChangingEvent(this, new SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEvent((SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.SHEMAURASHEMAURAKONTIRANJERowDeleted != null)
                {
                    SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler sHEMAURASHEMAURAKONTIRANJERowDeletedEvent = this.SHEMAURASHEMAURAKONTIRANJERowDeleted;
                    if (sHEMAURASHEMAURAKONTIRANJERowDeletedEvent != null)
                    {
                        sHEMAURASHEMAURAKONTIRANJERowDeletedEvent(this, new SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEvent((SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SHEMAURASHEMAURAKONTIRANJERowDeleting != null)
                {
                    SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler sHEMAURASHEMAURAKONTIRANJERowDeletingEvent = this.SHEMAURASHEMAURAKONTIRANJERowDeleting;
                    if (sHEMAURASHEMAURAKONTIRANJERowDeletingEvent != null)
                    {
                        sHEMAURASHEMAURAKONTIRANJERowDeletingEvent(this, new SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEvent((SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveSHEMAURASHEMAURAKONTIRANJERow(SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow row)
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

            public DataColumn IDSHEMAURAColumn
            {
                get
                {
                    return this.columnIDSHEMAURA;
                }
            }

            public DataColumn IDURAVRSTAIZNOSAColumn
            {
                get
                {
                    return this.columnIDURAVRSTAIZNOSA;
                }
            }

            public SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow this[int index]
            {
                get
                {
                    return (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) this.Rows[index];
                }
            }

            public DataColumn SHEMAURAKONTOIDKONTOColumn
            {
                get
                {
                    return this.columnSHEMAURAKONTOIDKONTO;
                }
            }

            public DataColumn SHEMAURAMTIDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnSHEMAURAMTIDMJESTOTROSKA;
                }
            }

            public DataColumn SHEMAURAOJIDORGJEDColumn
            {
                get
                {
                    return this.columnSHEMAURAOJIDORGJED;
                }
            }

            public DataColumn SHEMAURASTRANEIDSTRANEKNJIZENJAColumn
            {
                get
                {
                    return this.columnSHEMAURASTRANEIDSTRANEKNJIZENJA;
                }
            }
        }

        public class SHEMAURASHEMAURAKONTIRANJERow : DataRow
        {
            private SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJEDataTable tableSHEMAURASHEMAURAKONTIRANJE;

            internal SHEMAURASHEMAURAKONTIRANJERow(DataRowBuilder rb) : base(rb)
            {
                this.tableSHEMAURASHEMAURAKONTIRANJE = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJEDataTable) this.Table;
            }

            public SHEMAURADataSet.SHEMAURARow GetSHEMAURARow()
            {
                return (SHEMAURADataSet.SHEMAURARow) this.GetParentRow("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE");
            }

            public bool IsIDSHEMAURANull()
            {
                return this.IsNull(this.tableSHEMAURASHEMAURAKONTIRANJE.IDSHEMAURAColumn);
            }

            public bool IsIDURAVRSTAIZNOSANull()
            {
                return this.IsNull(this.tableSHEMAURASHEMAURAKONTIRANJE.IDURAVRSTAIZNOSAColumn);
            }

            public bool IsSHEMAURAKONTOIDKONTONull()
            {
                return this.IsNull(this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAKONTOIDKONTOColumn);
            }

            public bool IsSHEMAURAMTIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAMTIDMJESTOTROSKAColumn);
            }

            public bool IsSHEMAURAOJIDORGJEDNull()
            {
                return this.IsNull(this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAOJIDORGJEDColumn);
            }

            public bool IsSHEMAURASTRANEIDSTRANEKNJIZENJANull()
            {
                return this.IsNull(this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURASTRANEIDSTRANEKNJIZENJAColumn);
            }

            public void SetSHEMAURAMTIDMJESTOTROSKANull()
            {
                this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAMTIDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSHEMAURAOJIDORGJEDNull()
            {
                this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAOJIDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDSHEMAURA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAURASHEMAURAKONTIRANJE.IDSHEMAURAColumn]);
                }
                set
                {
                    this[this.tableSHEMAURASHEMAURAKONTIRANJE.IDSHEMAURAColumn] = value;
                }
            }

            public int IDURAVRSTAIZNOSA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAURASHEMAURAKONTIRANJE.IDURAVRSTAIZNOSAColumn]);
                }
                set
                {
                    this[this.tableSHEMAURASHEMAURAKONTIRANJE.IDURAVRSTAIZNOSAColumn] = value;
                }
            }

            public string SHEMAURAKONTOIDKONTO
            {
                get
                {
                    return Conversions.ToString(this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAKONTOIDKONTOColumn]);
                }
                set
                {
                    this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAKONTOIDKONTOColumn] = value;
                }
            }

            public int SHEMAURAMTIDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAMTIDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAMTIDMJESTOTROSKAColumn] = value;
                }
            }

            public int SHEMAURAOJIDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAOJIDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURAOJIDORGJEDColumn] = value;
                }
            }

            public int SHEMAURASTRANEIDSTRANEKNJIZENJA
            {
                get
                {
                    return Conversions.ToInteger(this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURASTRANEIDSTRANEKNJIZENJAColumn]);
                }
                set
                {
                    this[this.tableSHEMAURASHEMAURAKONTIRANJE.SHEMAURASTRANEIDSTRANEKNJIZENJAColumn] = value;
                }
            }
        }

        public class SHEMAURASHEMAURAKONTIRANJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow eventRow;

            public SHEMAURASHEMAURAKONTIRANJERowChangeEvent(SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow row, DataRowAction action)
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

            public SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void SHEMAURASHEMAURAKONTIRANJERowChangeEventHandler(object sender, SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERowChangeEvent e);
    }
}

