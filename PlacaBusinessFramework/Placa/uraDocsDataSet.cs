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
    public class uraDocsDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DOKUMENTDataTable tableDOKUMENT;

        public uraDocsDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected uraDocsDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["DOKUMENT"] != null)
                    {
                        this.Tables.Add(new DOKUMENTDataTable(dataSet.Tables["DOKUMENT"]));
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
            uraDocsDataSet set = (uraDocsDataSet) base.Clone();
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
            uraDocsDataSet set = new uraDocsDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "uraDocsDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2112");
            this.ExtendedProperties.Add("DataSetName", "DOKUMENTDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IuraDocsDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "uraDocs");
            this.ExtendedProperties.Add("ObjectDescription", "uraDocs");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("DefaultBusinessComponent", "DOKUMENT");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "false");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "false");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "False");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "False");
        }

        private void InitClassBase()
        {
            this.DataSetName = "uraDocsDataSet";
            this.Namespace = "http://www.tempuri.org/uraDocs";
            this.tableDOKUMENT = new DOKUMENTDataTable();
            this.Tables.Add(this.tableDOKUMENT);
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
            this.tableDOKUMENT = (DOKUMENTDataTable) this.Tables["DOKUMENT"];
            if (initTable && (this.tableDOKUMENT != null))
            {
                this.tableDOKUMENT.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["DOKUMENT"] != null)
                {
                    this.Tables.Add(new DOKUMENTDataTable(dataSet.Tables["DOKUMENT"]));
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

        private bool ShouldSerializeDOKUMENT()
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
        public DOKUMENTDataTable DOKUMENT
        {
            get
            {
                return this.tableDOKUMENT;
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
        public class DOKUMENTDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDDOKUMENT;
            private DataColumn columnIDTIPDOKUMENTA;
            private DataColumn columnNAZIVDOKUMENT;
            private DataColumn columnNAZIVTIPDOKUMENTA;
            private DataColumn columnPS;

            public event uraDocsDataSet.DOKUMENTRowChangeEventHandler DOKUMENTRowChanged;

            public event uraDocsDataSet.DOKUMENTRowChangeEventHandler DOKUMENTRowChanging;

            public event uraDocsDataSet.DOKUMENTRowChangeEventHandler DOKUMENTRowDeleted;

            public event uraDocsDataSet.DOKUMENTRowChangeEventHandler DOKUMENTRowDeleting;

            public DOKUMENTDataTable()
            {
                this.TableName = "DOKUMENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal DOKUMENTDataTable(DataTable table) : base(table.TableName)
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

            protected DOKUMENTDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddDOKUMENTRow(uraDocsDataSet.DOKUMENTRow row)
            {
                this.Rows.Add(row);
            }

            public uraDocsDataSet.DOKUMENTRow AddDOKUMENTRow(int iDDOKUMENT, string nAZIVDOKUMENT, int iDTIPDOKUMENTA, string nAZIVTIPDOKUMENTA, bool pS)
            {
                uraDocsDataSet.DOKUMENTRow row = (uraDocsDataSet.DOKUMENTRow) this.NewRow();
                row.ItemArray = new object[] { iDDOKUMENT, nAZIVDOKUMENT, iDTIPDOKUMENTA, nAZIVTIPDOKUMENTA, pS };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                uraDocsDataSet.DOKUMENTDataTable table = (uraDocsDataSet.DOKUMENTDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(uraDocsDataSet.DOKUMENTRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                uraDocsDataSet set = new uraDocsDataSet();
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
                this.columnIDDOKUMENT = new DataColumn("IDDOKUMENT", typeof(int), "", MappingType.Element);
                this.columnIDDOKUMENT.Caption = "Šifra dokumenta";
                this.columnIDDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Description", "Šifra dokumenta");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Length", "8");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDDOKUMENT");
                this.Columns.Add(this.columnIDDOKUMENT);
                this.columnNAZIVDOKUMENT = new DataColumn("NAZIVDOKUMENT", typeof(string), "", MappingType.Element);
                this.columnNAZIVDOKUMENT.Caption = "Naziv dokumenta";
                this.columnNAZIVDOKUMENT.MaxLength = 50;
                this.columnNAZIVDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Description", "Naziv dokumenta");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVDOKUMENT");
                this.Columns.Add(this.columnNAZIVDOKUMENT);
                this.columnIDTIPDOKUMENTA = new DataColumn("IDTIPDOKUMENTA", typeof(int), "", MappingType.Element);
                this.columnIDTIPDOKUMENTA.Caption = "IDTIPDOKUMENTA";
                this.columnIDTIPDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("IsKey", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Description", "IDTIPDOKUMENTA");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Length", "5");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "IDTIPDOKUMENTA");
                this.Columns.Add(this.columnIDTIPDOKUMENTA);
                this.columnNAZIVTIPDOKUMENTA = new DataColumn("NAZIVTIPDOKUMENTA", typeof(string), "", MappingType.Element);
                this.columnNAZIVTIPDOKUMENTA.Caption = "NAZIVTIPDOKUMENTA";
                this.columnNAZIVTIPDOKUMENTA.MaxLength = 50;
                this.columnNAZIVTIPDOKUMENTA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Description", "NAZIVTIPDOKUMENTA");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Length", "50");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVTIPDOKUMENTA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVTIPDOKUMENTA");
                this.Columns.Add(this.columnNAZIVTIPDOKUMENTA);
                this.columnPS = new DataColumn("PS", typeof(bool), "", MappingType.Element);
                this.columnPS.Caption = "PS";
                this.columnPS.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPS.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPS.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPS.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPS.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPS.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPS.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPS.ExtendedProperties.Add("IsKey", "false");
                this.columnPS.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPS.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnPS.ExtendedProperties.Add("Description", "PS");
                this.columnPS.ExtendedProperties.Add("Length", "1");
                this.columnPS.ExtendedProperties.Add("Decimals", "0");
                this.columnPS.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPS.ExtendedProperties.Add("IsInReader", "true");
                this.columnPS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPS.ExtendedProperties.Add("Deklarit.InternalName", "PS");
                this.Columns.Add(this.columnPS);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "uraDocs");
                this.ExtendedProperties.Add("Description", "DOKUMENT");
                this.ExtendedProperties.Add("HasOrder", "true");
                this.ExtendedProperties.Add("OrderAttributes", "IDTIPDOKUMENTA");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDDOKUMENT = this.Columns["IDDOKUMENT"];
                this.columnNAZIVDOKUMENT = this.Columns["NAZIVDOKUMENT"];
                this.columnIDTIPDOKUMENTA = this.Columns["IDTIPDOKUMENTA"];
                this.columnNAZIVTIPDOKUMENTA = this.Columns["NAZIVTIPDOKUMENTA"];
                this.columnPS = this.Columns["PS"];
            }

            public uraDocsDataSet.DOKUMENTRow NewDOKUMENTRow()
            {
                return (uraDocsDataSet.DOKUMENTRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new uraDocsDataSet.DOKUMENTRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DOKUMENTRowChanged != null)
                {
                    uraDocsDataSet.DOKUMENTRowChangeEventHandler dOKUMENTRowChangedEvent = this.DOKUMENTRowChanged;
                    if (dOKUMENTRowChangedEvent != null)
                    {
                        dOKUMENTRowChangedEvent(this, new uraDocsDataSet.DOKUMENTRowChangeEvent((uraDocsDataSet.DOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DOKUMENTRowChanging != null)
                {
                    uraDocsDataSet.DOKUMENTRowChangeEventHandler dOKUMENTRowChangingEvent = this.DOKUMENTRowChanging;
                    if (dOKUMENTRowChangingEvent != null)
                    {
                        dOKUMENTRowChangingEvent(this, new uraDocsDataSet.DOKUMENTRowChangeEvent((uraDocsDataSet.DOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DOKUMENTRowDeleted != null)
                {
                    uraDocsDataSet.DOKUMENTRowChangeEventHandler dOKUMENTRowDeletedEvent = this.DOKUMENTRowDeleted;
                    if (dOKUMENTRowDeletedEvent != null)
                    {
                        dOKUMENTRowDeletedEvent(this, new uraDocsDataSet.DOKUMENTRowChangeEvent((uraDocsDataSet.DOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DOKUMENTRowDeleting != null)
                {
                    uraDocsDataSet.DOKUMENTRowChangeEventHandler dOKUMENTRowDeletingEvent = this.DOKUMENTRowDeleting;
                    if (dOKUMENTRowDeletingEvent != null)
                    {
                        dOKUMENTRowDeletingEvent(this, new uraDocsDataSet.DOKUMENTRowChangeEvent((uraDocsDataSet.DOKUMENTRow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveDOKUMENTRow(uraDocsDataSet.DOKUMENTRow row)
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

            public DataColumn IDDOKUMENTColumn
            {
                get
                {
                    return this.columnIDDOKUMENT;
                }
            }

            public DataColumn IDTIPDOKUMENTAColumn
            {
                get
                {
                    return this.columnIDTIPDOKUMENTA;
                }
            }

            public uraDocsDataSet.DOKUMENTRow this[int index]
            {
                get
                {
                    return (uraDocsDataSet.DOKUMENTRow) this.Rows[index];
                }
            }

            public DataColumn NAZIVDOKUMENTColumn
            {
                get
                {
                    return this.columnNAZIVDOKUMENT;
                }
            }

            public DataColumn NAZIVTIPDOKUMENTAColumn
            {
                get
                {
                    return this.columnNAZIVTIPDOKUMENTA;
                }
            }

            public DataColumn PSColumn
            {
                get
                {
                    return this.columnPS;
                }
            }
        }

        public class DOKUMENTRow : DataRow
        {
            private uraDocsDataSet.DOKUMENTDataTable tableDOKUMENT;

            internal DOKUMENTRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDOKUMENT = (uraDocsDataSet.DOKUMENTDataTable) this.Table;
            }

            public bool IsIDDOKUMENTNull()
            {
                return this.IsNull(this.tableDOKUMENT.IDDOKUMENTColumn);
            }

            public bool IsIDTIPDOKUMENTANull()
            {
                return this.IsNull(this.tableDOKUMENT.IDTIPDOKUMENTAColumn);
            }

            public bool IsNAZIVDOKUMENTNull()
            {
                return this.IsNull(this.tableDOKUMENT.NAZIVDOKUMENTColumn);
            }

            public bool IsNAZIVTIPDOKUMENTANull()
            {
                return this.IsNull(this.tableDOKUMENT.NAZIVTIPDOKUMENTAColumn);
            }

            public bool IsPSNull()
            {
                return this.IsNull(this.tableDOKUMENT.PSColumn);
            }

            public void SetIDDOKUMENTNull()
            {
                this[this.tableDOKUMENT.IDDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDTIPDOKUMENTANull()
            {
                this[this.tableDOKUMENT.IDTIPDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVDOKUMENTNull()
            {
                this[this.tableDOKUMENT.NAZIVDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVTIPDOKUMENTANull()
            {
                this[this.tableDOKUMENT.NAZIVTIPDOKUMENTAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPSNull()
            {
                this[this.tableDOKUMENT.PSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDOKUMENT.IDDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDDOKUMENT because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOKUMENT.IDDOKUMENTColumn] = value;
                }
            }

            public int IDTIPDOKUMENTA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableDOKUMENT.IDTIPDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDTIPDOKUMENTA because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableDOKUMENT.IDTIPDOKUMENTAColumn] = value;
                }
            }

            public string NAZIVDOKUMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOKUMENT.NAZIVDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVDOKUMENT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOKUMENT.NAZIVDOKUMENTColumn] = value;
                }
            }

            public string NAZIVTIPDOKUMENTA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableDOKUMENT.NAZIVTIPDOKUMENTAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVTIPDOKUMENTA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableDOKUMENT.NAZIVTIPDOKUMENTAColumn] = value;
                }
            }

            public bool PS
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableDOKUMENT.PSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableDOKUMENT.PSColumn] = value;
                }
            }
        }

        public class DOKUMENTRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private uraDocsDataSet.DOKUMENTRow eventRow;

            public DOKUMENTRowChangeEvent(uraDocsDataSet.DOKUMENTRow row, DataRowAction action)
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

            public uraDocsDataSet.DOKUMENTRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DOKUMENTRowChangeEventHandler(object sender, uraDocsDataSet.DOKUMENTRowChangeEvent e);
    }
}

