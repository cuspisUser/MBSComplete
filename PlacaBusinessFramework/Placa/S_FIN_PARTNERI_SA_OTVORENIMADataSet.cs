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
    public class S_FIN_PARTNERI_SA_OTVORENIMADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_PARTNERI_SA_OTVORENIMADataTable tableS_FIN_PARTNERI_SA_OTVORENIMA;

        public S_FIN_PARTNERI_SA_OTVORENIMADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_PARTNERI_SA_OTVORENIMADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_PARTNERI_SA_OTVORENIMA"] != null)
                    {
                        this.Tables.Add(new S_FIN_PARTNERI_SA_OTVORENIMADataTable(dataSet.Tables["S_FIN_PARTNERI_SA_OTVORENIMA"]));
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
            S_FIN_PARTNERI_SA_OTVORENIMADataSet set = (S_FIN_PARTNERI_SA_OTVORENIMADataSet) base.Clone();
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
            S_FIN_PARTNERI_SA_OTVORENIMADataSet set = new S_FIN_PARTNERI_SA_OTVORENIMADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_PARTNERI_SA_OTVORENIMADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2139");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_PARTNERI_SA_OTVORENIMADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_PARTNERI_SA_OTVORENIMADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_PARTNERI_SA_OTVORENIMA");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_PARTNERI_SA_OTVORENIMA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_PARTNERI_SA_OTVORENIMA");
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
            this.DataSetName = "S_FIN_PARTNERI_SA_OTVORENIMADataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_PARTNERI_SA_OTVORENIMA";
            this.tableS_FIN_PARTNERI_SA_OTVORENIMA = new S_FIN_PARTNERI_SA_OTVORENIMADataTable();
            this.Tables.Add(this.tableS_FIN_PARTNERI_SA_OTVORENIMA);
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
            this.tableS_FIN_PARTNERI_SA_OTVORENIMA = (S_FIN_PARTNERI_SA_OTVORENIMADataTable) this.Tables["S_FIN_PARTNERI_SA_OTVORENIMA"];
            if (initTable && (this.tableS_FIN_PARTNERI_SA_OTVORENIMA != null))
            {
                this.tableS_FIN_PARTNERI_SA_OTVORENIMA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_PARTNERI_SA_OTVORENIMA"] != null)
                {
                    this.Tables.Add(new S_FIN_PARTNERI_SA_OTVORENIMADataTable(dataSet.Tables["S_FIN_PARTNERI_SA_OTVORENIMA"]));
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

        private bool ShouldSerializeS_FIN_PARTNERI_SA_OTVORENIMA()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public S_FIN_PARTNERI_SA_OTVORENIMADataTable S_FIN_PARTNERI_SA_OTVORENIMA
        {
            get
            {
                return this.tableS_FIN_PARTNERI_SA_OTVORENIMA;
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
        public class S_FIN_PARTNERI_SA_OTVORENIMADataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPARTNER;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnPARTNERMJESTO;

            public event S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler S_FIN_PARTNERI_SA_OTVORENIMARowChanged;

            public event S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler S_FIN_PARTNERI_SA_OTVORENIMARowChanging;

            public event S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler S_FIN_PARTNERI_SA_OTVORENIMARowDeleted;

            public event S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler S_FIN_PARTNERI_SA_OTVORENIMARowDeleting;

            public S_FIN_PARTNERI_SA_OTVORENIMADataTable()
            {
                this.TableName = "S_FIN_PARTNERI_SA_OTVORENIMA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_PARTNERI_SA_OTVORENIMADataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_PARTNERI_SA_OTVORENIMADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_PARTNERI_SA_OTVORENIMARow(S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow AddS_FIN_PARTNERI_SA_OTVORENIMARow(int iDPARTNER, string nAZIVPARTNER, string pARTNERMJESTO)
            {
                S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow row = (S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow) this.NewRow();
                row.ItemArray = new object[] { iDPARTNER, nAZIVPARTNER, pARTNERMJESTO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMADataTable table = (S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_PARTNERI_SA_OTVORENIMADataSet set = new S_FIN_PARTNERI_SA_OTVORENIMADataSet();
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
                this.columnIDPARTNER = new DataColumn("IDPARTNER", typeof(int), "", MappingType.Element);
                this.columnIDPARTNER.Caption = "Šifra partnera";
                this.columnIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šifra partnera");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IDPARTNER");
                this.Columns.Add(this.columnIDPARTNER);
                this.columnNAZIVPARTNER = new DataColumn("NAZIVPARTNER", typeof(string), "", MappingType.Element);
                this.columnNAZIVPARTNER.Caption = "Naziv partnera";
                this.columnNAZIVPARTNER.MaxLength = 100;
                this.columnNAZIVPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Description", "Naziv partnera");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPARTNER");
                this.Columns.Add(this.columnNAZIVPARTNER);
                this.columnPARTNERMJESTO = new DataColumn("PARTNERMJESTO", typeof(string), "", MappingType.Element);
                this.columnPARTNERMJESTO.Caption = "PARTNERMJESTO";
                this.columnPARTNERMJESTO.MaxLength = 50;
                this.columnPARTNERMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Description", "PARTNERMJESTO");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERMJESTO");
                this.Columns.Add(this.columnPARTNERMJESTO);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_PARTNERI_SA_OTVORENIMA");
                this.ExtendedProperties.Add("Description", "_S_FIN_PARTNERI_SA_OTVORENIMA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnPARTNERMJESTO = this.Columns["PARTNERMJESTO"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow(builder);
            }

            public S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow NewS_FIN_PARTNERI_SA_OTVORENIMARow()
            {
                return (S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_PARTNERI_SA_OTVORENIMARowChanged != null)
                {
                    S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler handler = this.S_FIN_PARTNERI_SA_OTVORENIMARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEvent((S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_PARTNERI_SA_OTVORENIMARowChanging != null)
                {
                    S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler handler = this.S_FIN_PARTNERI_SA_OTVORENIMARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEvent((S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_PARTNERI_SA_OTVORENIMARowDeleted != null)
                {
                    S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler handler = this.S_FIN_PARTNERI_SA_OTVORENIMARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEvent((S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_PARTNERI_SA_OTVORENIMARowDeleting != null)
                {
                    S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler handler = this.S_FIN_PARTNERI_SA_OTVORENIMARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEvent((S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_PARTNERI_SA_OTVORENIMARow(S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow row)
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

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow this[int index]
            {
                get
                {
                    return (S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            public DataColumn PARTNERMJESTOColumn
            {
                get
                {
                    return this.columnPARTNERMJESTO;
                }
            }
        }

        public class S_FIN_PARTNERI_SA_OTVORENIMARow : DataRow
        {
            private S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMADataTable tableS_FIN_PARTNERI_SA_OTVORENIMA;

            internal S_FIN_PARTNERI_SA_OTVORENIMARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_PARTNERI_SA_OTVORENIMA = (S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMADataTable) this.Table;
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tableS_FIN_PARTNERI_SA_OTVORENIMA.IDPARTNERColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tableS_FIN_PARTNERI_SA_OTVORENIMA.NAZIVPARTNERColumn);
            }

            public bool IsPARTNERMJESTONull()
            {
                return this.IsNull(this.tableS_FIN_PARTNERI_SA_OTVORENIMA.PARTNERMJESTOColumn);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERMJESTONull()
            {
                this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.PARTNERMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.IDPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDPARTNER because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.IDPARTNERColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVPARTNER because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.NAZIVPARTNERColumn] = value;
                }
            }

            public string PARTNERMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.PARTNERMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PARTNERMJESTO because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_PARTNERI_SA_OTVORENIMA.PARTNERMJESTOColumn] = value;
                }
            }
        }

        public class S_FIN_PARTNERI_SA_OTVORENIMARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow eventRow;

            public S_FIN_PARTNERI_SA_OTVORENIMARowChangeEvent(S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow row, DataRowAction action)
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

            public S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_PARTNERI_SA_OTVORENIMARowChangeEventHandler(object sender, S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARowChangeEvent e);
    }
}

