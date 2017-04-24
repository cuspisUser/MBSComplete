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
    public class S_FIN_PROMET_PO_PARTNERIMADataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_PROMET_PO_PARTNERIMADataTable tableS_FIN_PROMET_PO_PARTNERIMA;

        public S_FIN_PROMET_PO_PARTNERIMADataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_PROMET_PO_PARTNERIMADataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_PROMET_PO_PARTNERIMA"] != null)
                    {
                        this.Tables.Add(new S_FIN_PROMET_PO_PARTNERIMADataTable(dataSet.Tables["S_FIN_PROMET_PO_PARTNERIMA"]));
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
            S_FIN_PROMET_PO_PARTNERIMADataSet set = (S_FIN_PROMET_PO_PARTNERIMADataSet) base.Clone();
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
            S_FIN_PROMET_PO_PARTNERIMADataSet set = new S_FIN_PROMET_PO_PARTNERIMADataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_PROMET_PO_PARTNERIMADataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2168");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_PROMET_PO_PARTNERIMADataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_PROMET_PO_PARTNERIMADataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_PROMET_PO_PARTNERIMA");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_PROMET_PO_PARTNERIMA");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_PROMET_PO_PARTNERIMA");
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
            this.DataSetName = "S_FIN_PROMET_PO_PARTNERIMADataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_PROMET_PO_PARTNERIMA";
            this.tableS_FIN_PROMET_PO_PARTNERIMA = new S_FIN_PROMET_PO_PARTNERIMADataTable();
            this.Tables.Add(this.tableS_FIN_PROMET_PO_PARTNERIMA);
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
            this.tableS_FIN_PROMET_PO_PARTNERIMA = (S_FIN_PROMET_PO_PARTNERIMADataTable) this.Tables["S_FIN_PROMET_PO_PARTNERIMA"];
            if (initTable && (this.tableS_FIN_PROMET_PO_PARTNERIMA != null))
            {
                this.tableS_FIN_PROMET_PO_PARTNERIMA.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_PROMET_PO_PARTNERIMA"] != null)
                {
                    this.Tables.Add(new S_FIN_PROMET_PO_PARTNERIMADataTable(dataSet.Tables["S_FIN_PROMET_PO_PARTNERIMA"]));
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

        private bool ShouldSerializeS_FIN_PROMET_PO_PARTNERIMA()
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
        public S_FIN_PROMET_PO_PARTNERIMADataTable S_FIN_PROMET_PO_PARTNERIMA
        {
            get
            {
                return this.tableS_FIN_PROMET_PO_PARTNERIMA;
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
        public class S_FIN_PROMET_PO_PARTNERIMADataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVNOST;
            private DataColumn columnduguje;
            private DataColumn columnIDPARTNER;
            private DataColumn columnNAZIV;
            private DataColumn columnPARTNERMJESTO;
            private DataColumn columnPOTRAZUJE;

            public event S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler S_FIN_PROMET_PO_PARTNERIMARowChanged;

            public event S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler S_FIN_PROMET_PO_PARTNERIMARowChanging;

            public event S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler S_FIN_PROMET_PO_PARTNERIMARowDeleted;

            public event S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler S_FIN_PROMET_PO_PARTNERIMARowDeleting;

            public S_FIN_PROMET_PO_PARTNERIMADataTable()
            {
                this.TableName = "S_FIN_PROMET_PO_PARTNERIMA";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_PROMET_PO_PARTNERIMADataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_PROMET_PO_PARTNERIMADataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_PROMET_PO_PARTNERIMARow(S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow AddS_FIN_PROMET_PO_PARTNERIMARow(int iDPARTNER, decimal duguje, decimal pOTRAZUJE, string nAZIV, short aKTIVNOST, string pARTNERMJESTO)
            {
                S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow row = (S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow) this.NewRow();
                row.ItemArray = new object[] { iDPARTNER, duguje, pOTRAZUJE, nAZIV, aKTIVNOST, pARTNERMJESTO };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMADataTable table = (S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMADataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_PROMET_PO_PARTNERIMADataSet set = new S_FIN_PROMET_PO_PARTNERIMADataSet();
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
                this.columnduguje = new DataColumn("duguje", typeof(decimal), "", MappingType.Element);
                this.columnduguje.Caption = "duguje";
                this.columnduguje.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.InputMask", "0,##");
                this.columnduguje.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnduguje.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnduguje.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnduguje.ExtendedProperties.Add("IsKey", "false");
                this.columnduguje.ExtendedProperties.Add("ReadOnly", "true");
                this.columnduguje.ExtendedProperties.Add("DeklaritType", "int");
                this.columnduguje.ExtendedProperties.Add("Description", "duguje");
                this.columnduguje.ExtendedProperties.Add("Length", "12");
                this.columnduguje.ExtendedProperties.Add("Decimals", "2");
                this.columnduguje.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnduguje.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnduguje.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnduguje.ExtendedProperties.Add("IsInReader", "true");
                this.columnduguje.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnduguje.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnduguje.ExtendedProperties.Add("Deklarit.InternalName", "duguje");
                this.Columns.Add(this.columnduguje);
                this.columnPOTRAZUJE = new DataColumn("POTRAZUJE", typeof(decimal), "", MappingType.Element);
                this.columnPOTRAZUJE.Caption = "POTRAZUJE";
                this.columnPOTRAZUJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Description", "POTRAZUJE");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Length", "12");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Decimals", "2");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOTRAZUJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOTRAZUJE.ExtendedProperties.Add("Deklarit.InternalName", "POTRAZUJE");
                this.Columns.Add(this.columnPOTRAZUJE);
                this.columnNAZIV = new DataColumn("NAZIV", typeof(string), "", MappingType.Element);
                this.columnNAZIV.Caption = "NAZIV";
                this.columnNAZIV.MaxLength = 150;
                this.columnNAZIV.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIV.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIV.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIV.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIV.ExtendedProperties.Add("Description", "NAZIV");
                this.columnNAZIV.ExtendedProperties.Add("Length", "150");
                this.columnNAZIV.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIV.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIV.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIV.ExtendedProperties.Add("Deklarit.InternalName", "NAZIV");
                this.Columns.Add(this.columnNAZIV);
                this.columnAKTIVNOST = new DataColumn("AKTIVNOST", typeof(short), "", MappingType.Element);
                this.columnAKTIVNOST.Caption = "AKTIVNOST";
                this.columnAKTIVNOST.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAKTIVNOST.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVNOST.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVNOST.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnAKTIVNOST.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVNOST.ExtendedProperties.Add("ReadOnly", "true");
                this.columnAKTIVNOST.ExtendedProperties.Add("DeklaritType", "int");
                this.columnAKTIVNOST.ExtendedProperties.Add("Description", "AKTIVNOST");
                this.columnAKTIVNOST.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVNOST.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVNOST.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnAKTIVNOST.ExtendedProperties.Add("IsInReader", "true");
                this.columnAKTIVNOST.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVNOST.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVNOST.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVNOST");
                this.Columns.Add(this.columnAKTIVNOST);
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
                this.ExtendedProperties.Add("LevelName", "S_FIN_PROMET_PO_PARTNERIMA");
                this.ExtendedProperties.Add("Description", "S_FIN_PROMET_PO_PARTNERIMA");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnduguje = this.Columns["duguje"];
                this.columnPOTRAZUJE = this.Columns["POTRAZUJE"];
                this.columnNAZIV = this.Columns["NAZIV"];
                this.columnAKTIVNOST = this.Columns["AKTIVNOST"];
                this.columnPARTNERMJESTO = this.Columns["PARTNERMJESTO"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow(builder);
            }

            public S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow NewS_FIN_PROMET_PO_PARTNERIMARow()
            {
                return (S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_PROMET_PO_PARTNERIMARowChanged != null)
                {
                    S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_PARTNERIMARowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEvent((S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_PROMET_PO_PARTNERIMARowChanging != null)
                {
                    S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_PARTNERIMARowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEvent((S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_PROMET_PO_PARTNERIMARowDeleted != null)
                {
                    S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_PARTNERIMARowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEvent((S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_PROMET_PO_PARTNERIMARowDeleting != null)
                {
                    S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler handler = this.S_FIN_PROMET_PO_PARTNERIMARowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEvent((S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_PROMET_PO_PARTNERIMARow(S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVNOSTColumn
            {
                get
                {
                    return this.columnAKTIVNOST;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public DataColumn dugujeColumn
            {
                get
                {
                    return this.columnduguje;
                }
            }

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow this[int index]
            {
                get
                {
                    return (S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow) this.Rows[index];
                }
            }

            public DataColumn NAZIVColumn
            {
                get
                {
                    return this.columnNAZIV;
                }
            }

            public DataColumn PARTNERMJESTOColumn
            {
                get
                {
                    return this.columnPARTNERMJESTO;
                }
            }

            public DataColumn POTRAZUJEColumn
            {
                get
                {
                    return this.columnPOTRAZUJE;
                }
            }
        }

        public class S_FIN_PROMET_PO_PARTNERIMARow : DataRow
        {
            private S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMADataTable tableS_FIN_PROMET_PO_PARTNERIMA;

            internal S_FIN_PROMET_PO_PARTNERIMARow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_PROMET_PO_PARTNERIMA = (S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMADataTable) this.Table;
            }

            public bool IsAKTIVNOSTNull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_PARTNERIMA.AKTIVNOSTColumn);
            }

            public bool IsdugujeNull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_PARTNERIMA.dugujeColumn);
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_PARTNERIMA.IDPARTNERColumn);
            }

            public bool IsNAZIVNull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_PARTNERIMA.NAZIVColumn);
            }

            public bool IsPARTNERMJESTONull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_PARTNERIMA.PARTNERMJESTOColumn);
            }

            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableS_FIN_PROMET_PO_PARTNERIMA.POTRAZUJEColumn);
            }

            public void SetAKTIVNOSTNull()
            {
                this[this.tableS_FIN_PROMET_PO_PARTNERIMA.AKTIVNOSTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdugujeNull()
            {
                this[this.tableS_FIN_PROMET_PO_PARTNERIMA.dugujeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tableS_FIN_PROMET_PO_PARTNERIMA.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVNull()
            {
                this[this.tableS_FIN_PROMET_PO_PARTNERIMA.NAZIVColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERMJESTONull()
            {
                this[this.tableS_FIN_PROMET_PO_PARTNERIMA.PARTNERMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTRAZUJENull()
            {
                this[this.tableS_FIN_PROMET_PO_PARTNERIMA.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public short AKTIVNOST
            {
                get
                {
                    short num = 0;
                    try
                    {
                        num = Conversions.ToShort(this[this.tableS_FIN_PROMET_PO_PARTNERIMA.AKTIVNOSTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value AKTIVNOST because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_PROMET_PO_PARTNERIMA.AKTIVNOSTColumn] = value;
                }
            }

            public decimal duguje
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_PROMET_PO_PARTNERIMA.dugujeColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value duguje because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_PROMET_PO_PARTNERIMA.dugujeColumn] = value;
                }
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_PROMET_PO_PARTNERIMA.IDPARTNERColumn]);
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
                    this[this.tableS_FIN_PROMET_PO_PARTNERIMA.IDPARTNERColumn] = value;
                }
            }

            public string NAZIV
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_PROMET_PO_PARTNERIMA.NAZIVColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIV because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_PROMET_PO_PARTNERIMA.NAZIVColumn] = value;
                }
            }

            public string PARTNERMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_PROMET_PO_PARTNERIMA.PARTNERMJESTOColumn]);
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
                    this[this.tableS_FIN_PROMET_PO_PARTNERIMA.PARTNERMJESTOColumn] = value;
                }
            }

            public decimal POTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_PROMET_PO_PARTNERIMA.POTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value POTRAZUJE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_PROMET_PO_PARTNERIMA.POTRAZUJEColumn] = value;
                }
            }
        }

        public class S_FIN_PROMET_PO_PARTNERIMARowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow eventRow;

            public S_FIN_PROMET_PO_PARTNERIMARowChangeEvent(S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow row, DataRowAction action)
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

            public S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_PROMET_PO_PARTNERIMARowChangeEventHandler(object sender, S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARowChangeEvent e);
    }
}

