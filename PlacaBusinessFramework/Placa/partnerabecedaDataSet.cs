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
    public class partnerabecedaDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PARTNERDataTable tablePARTNER;

        public partnerabecedaDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected partnerabecedaDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PARTNER"] != null)
                    {
                        this.Tables.Add(new PARTNERDataTable(dataSet.Tables["PARTNER"]));
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
            partnerabecedaDataSet set = (partnerabecedaDataSet) base.Clone();
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
            partnerabecedaDataSet set = new partnerabecedaDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "partnerabecedaDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2046");
            this.ExtendedProperties.Add("DataSetName", "PARTNERDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IpartnerabecedaDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "partnerabeceda");
            this.ExtendedProperties.Add("ObjectDescription", "partnerabeceda");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("DefaultBusinessComponent", "PARTNER");
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
            this.DataSetName = "partnerabecedaDataSet";
            this.Namespace = "http://www.tempuri.org/partnerabeceda";
            this.tablePARTNER = new PARTNERDataTable();
            this.Tables.Add(this.tablePARTNER);
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
            this.tablePARTNER = (PARTNERDataTable) this.Tables["PARTNER"];
            if (initTable && (this.tablePARTNER != null))
            {
                this.tablePARTNER.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["PARTNER"] != null)
                {
                    this.Tables.Add(new PARTNERDataTable(dataSet.Tables["PARTNER"]));
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

        private bool ShouldSerializePARTNER()
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
        public PARTNERDataTable PARTNER
        {
            get
            {
                return this.tablePARTNER;
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
        public class PARTNERDataTable : DataTable, IEnumerable
        {
            private DataColumn columnIDPARTNER;
            private DataColumn columnMB;
            private DataColumn columnNAZIVPARTNER;
            private DataColumn columnPARTNEREMAIL;
            private DataColumn columnPARTNERFAX;
            private DataColumn columnPARTNERMJESTO;
            private DataColumn columnPARTNEROIB;
            private DataColumn columnPARTNERTELEFON;
            private DataColumn columnPARTNERULICA;
            private DataColumn columnPARTNERZIRO1;
            private DataColumn columnPARTNERZIRO2;

            public event partnerabecedaDataSet.PARTNERRowChangeEventHandler PARTNERRowChanged;

            public event partnerabecedaDataSet.PARTNERRowChangeEventHandler PARTNERRowChanging;

            public event partnerabecedaDataSet.PARTNERRowChangeEventHandler PARTNERRowDeleted;

            public event partnerabecedaDataSet.PARTNERRowChangeEventHandler PARTNERRowDeleting;

            public PARTNERDataTable()
            {
                this.TableName = "PARTNER";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PARTNERDataTable(DataTable table) : base(table.TableName)
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

            protected PARTNERDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPARTNERRow(partnerabecedaDataSet.PARTNERRow row)
            {
                this.Rows.Add(row);
            }

            public partnerabecedaDataSet.PARTNERRow AddPARTNERRow(int iDPARTNER, string nAZIVPARTNER, string mB, string pARTNERMJESTO, string pARTNERULICA, string pARTNEREMAIL, string pARTNEROIB, string pARTNERFAX, string pARTNERTELEFON, string pARTNERZIRO1, string pARTNERZIRO2)
            {
                partnerabecedaDataSet.PARTNERRow row = (partnerabecedaDataSet.PARTNERRow) this.NewRow();
                row.ItemArray = new object[] { iDPARTNER, nAZIVPARTNER, mB, pARTNERMJESTO, pARTNERULICA, pARTNEREMAIL, pARTNEROIB, pARTNERFAX, pARTNERTELEFON, pARTNERZIRO1, pARTNERZIRO2 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                partnerabecedaDataSet.PARTNERDataTable table = (partnerabecedaDataSet.PARTNERDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(partnerabecedaDataSet.PARTNERRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                partnerabecedaDataSet set = new partnerabecedaDataSet();
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
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
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
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsKey", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Description", "Naziv partnera");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPARTNER");
                this.Columns.Add(this.columnNAZIVPARTNER);
                this.columnMB = new DataColumn("MB", typeof(string), "", MappingType.Element);
                this.columnMB.Caption = "MB";
                this.columnMB.MaxLength = 13;
                this.columnMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMB.ExtendedProperties.Add("IsKey", "false");
                this.columnMB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMB.ExtendedProperties.Add("Description", "MB");
                this.columnMB.ExtendedProperties.Add("Length", "13");
                this.columnMB.ExtendedProperties.Add("Decimals", "0");
                this.columnMB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMB.ExtendedProperties.Add("IsInReader", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMB.ExtendedProperties.Add("Deklarit.InternalName", "MB");
                this.Columns.Add(this.columnMB);
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
                this.columnPARTNERMJESTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERMJESTO");
                this.Columns.Add(this.columnPARTNERMJESTO);
                this.columnPARTNERULICA = new DataColumn("PARTNERULICA", typeof(string), "", MappingType.Element);
                this.columnPARTNERULICA.Caption = "PARTNERULICA";
                this.columnPARTNERULICA.MaxLength = 150;
                this.columnPARTNERULICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERULICA.ExtendedProperties.Add("Description", "PARTNERULICA");
                this.columnPARTNERULICA.ExtendedProperties.Add("Length", "150");
                this.columnPARTNERULICA.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERULICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERULICA");
                this.Columns.Add(this.columnPARTNERULICA);
                this.columnPARTNEREMAIL = new DataColumn("PARTNEREMAIL", typeof(string), "", MappingType.Element);
                this.columnPARTNEREMAIL.Caption = "PARTNEREMAIL";
                this.columnPARTNEREMAIL.MaxLength = 100;
                this.columnPARTNEREMAIL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Description", "PARTNEREMAIL");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Length", "100");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEREMAIL");
                this.Columns.Add(this.columnPARTNEREMAIL);
                this.columnPARTNEROIB = new DataColumn("PARTNEROIB", typeof(string), "", MappingType.Element);
                this.columnPARTNEROIB.Caption = "PARTNEROIB";
                this.columnPARTNEROIB.MaxLength = 11;
                this.columnPARTNEROIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNEROIB.ExtendedProperties.Add("Description", "PARTNEROIB");
                this.columnPARTNEROIB.ExtendedProperties.Add("Length", "11");
                this.columnPARTNEROIB.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEROIB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEROIB");
                this.Columns.Add(this.columnPARTNEROIB);
                this.columnPARTNERFAX = new DataColumn("PARTNERFAX", typeof(string), "", MappingType.Element);
                this.columnPARTNERFAX.Caption = "PARTNERFAX";
                this.columnPARTNERFAX.MaxLength = 20;
                this.columnPARTNERFAX.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERFAX.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERFAX.ExtendedProperties.Add("Description", "PARTNERFAX");
                this.columnPARTNERFAX.ExtendedProperties.Add("Length", "20");
                this.columnPARTNERFAX.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERFAX.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERFAX");
                this.Columns.Add(this.columnPARTNERFAX);
                this.columnPARTNERTELEFON = new DataColumn("PARTNERTELEFON", typeof(string), "", MappingType.Element);
                this.columnPARTNERTELEFON.Caption = "PARTNERTELEFON";
                this.columnPARTNERTELEFON.MaxLength = 50;
                this.columnPARTNERTELEFON.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Description", "PARTNERTELEFON");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Length", "50");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERTELEFON");
                this.Columns.Add(this.columnPARTNERTELEFON);
                this.columnPARTNERZIRO1 = new DataColumn("PARTNERZIRO1", typeof(string), "", MappingType.Element);
                this.columnPARTNERZIRO1.Caption = "PARTNERZIR O1";
                this.columnPARTNERZIRO1.MaxLength = 0x12;
                this.columnPARTNERZIRO1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Description", "PARTNERZIR O1");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Length", "18");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERZIRO1");
                this.Columns.Add(this.columnPARTNERZIRO1);
                this.columnPARTNERZIRO2 = new DataColumn("PARTNERZIRO2", typeof(string), "", MappingType.Element);
                this.columnPARTNERZIRO2.Caption = "PARTNERZIR O2";
                this.columnPARTNERZIRO2.MaxLength = 0x12;
                this.columnPARTNERZIRO2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Description", "PARTNERZIR O2");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Length", "18");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERZIRO2");
                this.Columns.Add(this.columnPARTNERZIRO2);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "partnerabeceda");
                this.ExtendedProperties.Add("Description", "PARTNER");
                this.ExtendedProperties.Add("HasOrder", "true");
                this.ExtendedProperties.Add("OrderAttributes", "NAZIVPARTNER");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnMB = this.Columns["MB"];
                this.columnPARTNERMJESTO = this.Columns["PARTNERMJESTO"];
                this.columnPARTNERULICA = this.Columns["PARTNERULICA"];
                this.columnPARTNEREMAIL = this.Columns["PARTNEREMAIL"];
                this.columnPARTNEROIB = this.Columns["PARTNEROIB"];
                this.columnPARTNERFAX = this.Columns["PARTNERFAX"];
                this.columnPARTNERTELEFON = this.Columns["PARTNERTELEFON"];
                this.columnPARTNERZIRO1 = this.Columns["PARTNERZIRO1"];
                this.columnPARTNERZIRO2 = this.Columns["PARTNERZIRO2"];
            }

            public partnerabecedaDataSet.PARTNERRow NewPARTNERRow()
            {
                return (partnerabecedaDataSet.PARTNERRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new partnerabecedaDataSet.PARTNERRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PARTNERRowChanged != null)
                {
                    partnerabecedaDataSet.PARTNERRowChangeEventHandler pARTNERRowChangedEvent = this.PARTNERRowChanged;
                    if (pARTNERRowChangedEvent != null)
                    {
                        pARTNERRowChangedEvent(this, new partnerabecedaDataSet.PARTNERRowChangeEvent((partnerabecedaDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PARTNERRowChanging != null)
                {
                    partnerabecedaDataSet.PARTNERRowChangeEventHandler pARTNERRowChangingEvent = this.PARTNERRowChanging;
                    if (pARTNERRowChangingEvent != null)
                    {
                        pARTNERRowChangingEvent(this, new partnerabecedaDataSet.PARTNERRowChangeEvent((partnerabecedaDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PARTNERRowDeleted != null)
                {
                    partnerabecedaDataSet.PARTNERRowChangeEventHandler pARTNERRowDeletedEvent = this.PARTNERRowDeleted;
                    if (pARTNERRowDeletedEvent != null)
                    {
                        pARTNERRowDeletedEvent(this, new partnerabecedaDataSet.PARTNERRowChangeEvent((partnerabecedaDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PARTNERRowDeleting != null)
                {
                    partnerabecedaDataSet.PARTNERRowChangeEventHandler pARTNERRowDeletingEvent = this.PARTNERRowDeleting;
                    if (pARTNERRowDeletingEvent != null)
                    {
                        pARTNERRowDeletingEvent(this, new partnerabecedaDataSet.PARTNERRowChangeEvent((partnerabecedaDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePARTNERRow(partnerabecedaDataSet.PARTNERRow row)
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

            public partnerabecedaDataSet.PARTNERRow this[int index]
            {
                get
                {
                    return (partnerabecedaDataSet.PARTNERRow) this.Rows[index];
                }
            }

            public DataColumn MBColumn
            {
                get
                {
                    return this.columnMB;
                }
            }

            public DataColumn NAZIVPARTNERColumn
            {
                get
                {
                    return this.columnNAZIVPARTNER;
                }
            }

            public DataColumn PARTNEREMAILColumn
            {
                get
                {
                    return this.columnPARTNEREMAIL;
                }
            }

            public DataColumn PARTNERFAXColumn
            {
                get
                {
                    return this.columnPARTNERFAX;
                }
            }

            public DataColumn PARTNERMJESTOColumn
            {
                get
                {
                    return this.columnPARTNERMJESTO;
                }
            }

            public DataColumn PARTNEROIBColumn
            {
                get
                {
                    return this.columnPARTNEROIB;
                }
            }

            public DataColumn PARTNERTELEFONColumn
            {
                get
                {
                    return this.columnPARTNERTELEFON;
                }
            }

            public DataColumn PARTNERULICAColumn
            {
                get
                {
                    return this.columnPARTNERULICA;
                }
            }

            public DataColumn PARTNERZIRO1Column
            {
                get
                {
                    return this.columnPARTNERZIRO1;
                }
            }

            public DataColumn PARTNERZIRO2Column
            {
                get
                {
                    return this.columnPARTNERZIRO2;
                }
            }
        }

        public class PARTNERRow : DataRow
        {
            private partnerabecedaDataSet.PARTNERDataTable tablePARTNER;

            internal PARTNERRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePARTNER = (partnerabecedaDataSet.PARTNERDataTable) this.Table;
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tablePARTNER.IDPARTNERColumn);
            }

            public bool IsMBNull()
            {
                return this.IsNull(this.tablePARTNER.MBColumn);
            }

            public bool IsNAZIVPARTNERNull()
            {
                return this.IsNull(this.tablePARTNER.NAZIVPARTNERColumn);
            }

            public bool IsPARTNEREMAILNull()
            {
                return this.IsNull(this.tablePARTNER.PARTNEREMAILColumn);
            }

            public bool IsPARTNERFAXNull()
            {
                return this.IsNull(this.tablePARTNER.PARTNERFAXColumn);
            }

            public bool IsPARTNERMJESTONull()
            {
                return this.IsNull(this.tablePARTNER.PARTNERMJESTOColumn);
            }

            public bool IsPARTNEROIBNull()
            {
                return this.IsNull(this.tablePARTNER.PARTNEROIBColumn);
            }

            public bool IsPARTNERTELEFONNull()
            {
                return this.IsNull(this.tablePARTNER.PARTNERTELEFONColumn);
            }

            public bool IsPARTNERULICANull()
            {
                return this.IsNull(this.tablePARTNER.PARTNERULICAColumn);
            }

            public bool IsPARTNERZIRO1Null()
            {
                return this.IsNull(this.tablePARTNER.PARTNERZIRO1Column);
            }

            public bool IsPARTNERZIRO2Null()
            {
                return this.IsNull(this.tablePARTNER.PARTNERZIRO2Column);
            }

            public void SetIDPARTNERNull()
            {
                this[this.tablePARTNER.IDPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBNull()
            {
                this[this.tablePARTNER.MBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPARTNERNull()
            {
                this[this.tablePARTNER.NAZIVPARTNERColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNEREMAILNull()
            {
                this[this.tablePARTNER.PARTNEREMAILColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERFAXNull()
            {
                this[this.tablePARTNER.PARTNERFAXColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERMJESTONull()
            {
                this[this.tablePARTNER.PARTNERMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNEROIBNull()
            {
                this[this.tablePARTNER.PARTNEROIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERTELEFONNull()
            {
                this[this.tablePARTNER.PARTNERTELEFONColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERULICANull()
            {
                this[this.tablePARTNER.PARTNERULICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERZIRO1Null()
            {
                this[this.tablePARTNER.PARTNERZIRO1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERZIRO2Null()
            {
                this[this.tablePARTNER.PARTNERZIRO2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPARTNER
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePARTNER.IDPARTNERColumn]);
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
                    this[this.tablePARTNER.IDPARTNERColumn] = value;
                }
            }

            public string MB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.MBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value MB because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.MBColumn] = value;
                }
            }

            public string NAZIVPARTNER
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.NAZIVPARTNERColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.NAZIVPARTNERColumn] = value;
                }
            }

            public string PARTNEREMAIL
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNEREMAILColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNEREMAILColumn] = value;
                }
            }

            public string PARTNERFAX
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNERFAXColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNERFAXColumn] = value;
                }
            }

            public string PARTNERMJESTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNERMJESTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNERMJESTOColumn] = value;
                }
            }

            public string PARTNEROIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNEROIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNEROIBColumn] = value;
                }
            }

            public string PARTNERTELEFON
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNERTELEFONColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNERTELEFONColumn] = value;
                }
            }

            public string PARTNERULICA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNERULICAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNERULICAColumn] = value;
                }
            }

            public string PARTNERZIRO1
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNERZIRO1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNERZIRO1Column] = value;
                }
            }

            public string PARTNERZIRO2
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PARTNERZIRO2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNERZIRO2Column] = value;
                }
            }
        }

        public class PARTNERRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private partnerabecedaDataSet.PARTNERRow eventRow;

            public PARTNERRowChangeEvent(partnerabecedaDataSet.PARTNERRow row, DataRowAction action)
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

            public partnerabecedaDataSet.PARTNERRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PARTNERRowChangeEventHandler(object sender, partnerabecedaDataSet.PARTNERRowChangeEvent e);
    }
}

