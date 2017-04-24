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
    public class trazi_partneraDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PARTNERDataTable tablePARTNER;

        public trazi_partneraDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected trazi_partneraDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
            trazi_partneraDataSet set = (trazi_partneraDataSet) base.Clone();
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
            trazi_partneraDataSet set = new trazi_partneraDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "trazi_partneraDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2012");
            this.ExtendedProperties.Add("DataSetName", "trazi_partneraDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Itrazi_partneraDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "trazi_partnera");
            this.ExtendedProperties.Add("ObjectDescription", "trazi_partnera");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("DefaultBusinessComponent", "PARTNER");
            this.ExtendedProperties.Add("Deklarit.GroupByAttributes", "");
            this.ExtendedProperties.Add("Deklarit.GenerateCRUDForDP", "True");
            this.ExtendedProperties.Add("Deklarit.ExtendedView", "True");
            this.ExtendedProperties.Add("Deklarit.ShowGroupByDP", "True");
            this.ExtendedProperties.Add("Deklarit.UseSuggestInFK", "True");
            this.ExtendedProperties.Add("Deklarit.BCForNewOption", "");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "PT");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "trazi_partneraDataSet";
            this.Namespace = "http://www.tempuri.org/trazi_partnera";
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
            private DataColumn columnPARTNERMJESTO;
            private DataColumn columnPARTNEROIB;
            private DataColumn columnPARTNERULICA;
            private DataColumn columnPT;

            public event trazi_partneraDataSet.PARTNERRowChangeEventHandler PARTNERRowChanged;

            public event trazi_partneraDataSet.PARTNERRowChangeEventHandler PARTNERRowChanging;

            public event trazi_partneraDataSet.PARTNERRowChangeEventHandler PARTNERRowDeleted;

            public event trazi_partneraDataSet.PARTNERRowChangeEventHandler PARTNERRowDeleting;

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

            public void AddPARTNERRow(trazi_partneraDataSet.PARTNERRow row)
            {
                this.Rows.Add(row);
            }

            public trazi_partneraDataSet.PARTNERRow AddPARTNERRow(int iDPARTNER, string nAZIVPARTNER, string pARTNERMJESTO, string pARTNEREMAIL, string pARTNERULICA, string mB, string pARTNEROIB, string pT)
            {
                trazi_partneraDataSet.PARTNERRow row = (trazi_partneraDataSet.PARTNERRow) this.NewRow();
                row.ItemArray = new object[] { iDPARTNER, nAZIVPARTNER, pARTNERMJESTO, pARTNEREMAIL, pARTNERULICA, mB, pARTNEROIB, pT };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                trazi_partneraDataSet.PARTNERDataTable table = (trazi_partneraDataSet.PARTNERDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(trazi_partneraDataSet.PARTNERRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                trazi_partneraDataSet set = new trazi_partneraDataSet();
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
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsKey", "false");
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
                this.columnPT = new DataColumn("PT", typeof(string), "", MappingType.Element);
                this.columnPT.Caption = "PT";
                this.columnPT.MaxLength = 0x7d;
                this.columnPT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPT.ExtendedProperties.Add("IsKey", "false");
                this.columnPT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPT.ExtendedProperties.Add("Description", "PT");
                this.columnPT.ExtendedProperties.Add("Length", "125");
                this.columnPT.ExtendedProperties.Add("Decimals", "0");
                this.columnPT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPT.ExtendedProperties.Add("Deklarit.InternalName", "PT");
                this.Columns.Add(this.columnPT);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "trazi_partnera");
                this.ExtendedProperties.Add("Description", "PARTNER");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnNAZIVPARTNER = this.Columns["NAZIVPARTNER"];
                this.columnPARTNERMJESTO = this.Columns["PARTNERMJESTO"];
                this.columnPARTNEREMAIL = this.Columns["PARTNEREMAIL"];
                this.columnPARTNERULICA = this.Columns["PARTNERULICA"];
                this.columnMB = this.Columns["MB"];
                this.columnPARTNEROIB = this.Columns["PARTNEROIB"];
                this.columnPT = this.Columns["PT"];
            }

            public trazi_partneraDataSet.PARTNERRow NewPARTNERRow()
            {
                return (trazi_partneraDataSet.PARTNERRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new trazi_partneraDataSet.PARTNERRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PARTNERRowChanged != null)
                {
                    trazi_partneraDataSet.PARTNERRowChangeEventHandler pARTNERRowChangedEvent = this.PARTNERRowChanged;
                    if (pARTNERRowChangedEvent != null)
                    {
                        pARTNERRowChangedEvent(this, new trazi_partneraDataSet.PARTNERRowChangeEvent((trazi_partneraDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PARTNERRowChanging != null)
                {
                    trazi_partneraDataSet.PARTNERRowChangeEventHandler pARTNERRowChangingEvent = this.PARTNERRowChanging;
                    if (pARTNERRowChangingEvent != null)
                    {
                        pARTNERRowChangingEvent(this, new trazi_partneraDataSet.PARTNERRowChangeEvent((trazi_partneraDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PARTNERRowDeleted != null)
                {
                    trazi_partneraDataSet.PARTNERRowChangeEventHandler pARTNERRowDeletedEvent = this.PARTNERRowDeleted;
                    if (pARTNERRowDeletedEvent != null)
                    {
                        pARTNERRowDeletedEvent(this, new trazi_partneraDataSet.PARTNERRowChangeEvent((trazi_partneraDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PARTNERRowDeleting != null)
                {
                    trazi_partneraDataSet.PARTNERRowChangeEventHandler pARTNERRowDeletingEvent = this.PARTNERRowDeleting;
                    if (pARTNERRowDeletingEvent != null)
                    {
                        pARTNERRowDeletingEvent(this, new trazi_partneraDataSet.PARTNERRowChangeEvent((trazi_partneraDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePARTNERRow(trazi_partneraDataSet.PARTNERRow row)
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

            public trazi_partneraDataSet.PARTNERRow this[int index]
            {
                get
                {
                    return (trazi_partneraDataSet.PARTNERRow) this.Rows[index];
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

            public DataColumn PARTNERULICAColumn
            {
                get
                {
                    return this.columnPARTNERULICA;
                }
            }

            public DataColumn PTColumn
            {
                get
                {
                    return this.columnPT;
                }
            }
        }

        public class PARTNERRow : DataRow
        {
            private trazi_partneraDataSet.PARTNERDataTable tablePARTNER;

            internal PARTNERRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePARTNER = (trazi_partneraDataSet.PARTNERDataTable) this.Table;
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

            public bool IsPARTNERMJESTONull()
            {
                return this.IsNull(this.tablePARTNER.PARTNERMJESTOColumn);
            }

            public bool IsPARTNEROIBNull()
            {
                return this.IsNull(this.tablePARTNER.PARTNEROIBColumn);
            }

            public bool IsPARTNERULICANull()
            {
                return this.IsNull(this.tablePARTNER.PARTNERULICAColumn);
            }

            public bool IsPTNull()
            {
                return this.IsNull(this.tablePARTNER.PTColumn);
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

            public void SetPARTNERMJESTONull()
            {
                this[this.tablePARTNER.PARTNERMJESTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNEROIBNull()
            {
                this[this.tablePARTNER.PARTNEROIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPARTNERULICANull()
            {
                this[this.tablePARTNER.PARTNERULICAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPTNull()
            {
                this[this.tablePARTNER.PTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
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
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value NAZIVPARTNER because it is DBNull.", innerException);
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
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PARTNEREMAIL because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNEREMAILColumn] = value;
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
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PARTNERMJESTO because it is DBNull.", innerException);
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
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PARTNEROIB because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNEROIBColumn] = value;
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
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PARTNERULICA because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PARTNERULICAColumn] = value;
                }
            }

            public string PT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNER.PTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value PT because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNER.PTColumn] = value;
                }
            }
        }

        public class PARTNERRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private trazi_partneraDataSet.PARTNERRow eventRow;

            public PARTNERRowChangeEvent(trazi_partneraDataSet.PARTNERRow row, DataRowAction action)
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

            public trazi_partneraDataSet.PARTNERRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PARTNERRowChangeEventHandler(object sender, trazi_partneraDataSet.PARTNERRowChangeEvent e);
    }
}

