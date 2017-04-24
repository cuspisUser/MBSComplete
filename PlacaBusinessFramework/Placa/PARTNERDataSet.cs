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
    public class PARTNERDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private PARTNERDataTable tablePARTNER;
        private PARTNERZADUZENJEDataTable tablePARTNERZADUZENJE;

        public PARTNERDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected PARTNERDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["PARTNERZADUZENJE"] != null)
                    {
                        this.Tables.Add(new PARTNERZADUZENJEDataTable(dataSet.Tables["PARTNERZADUZENJE"]));
                    }
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
            PARTNERDataSet set = (PARTNERDataSet) base.Clone();
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
            PARTNERDataSet set = new PARTNERDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "PARTNERDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2004");
            this.ExtendedProperties.Add("DataSetName", "PARTNERDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IPARTNERDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "PARTNER");
            this.ExtendedProperties.Add("ObjectDescription", "PARTNER");
            this.ExtendedProperties.Add("ObjectType", "BusinessComponent");
            this.ExtendedProperties.Add("ObjectPath", @"\BusinessComponents\Finpos");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.ShowGroupBy", "False");
            this.ExtendedProperties.Add("Deklarit.AddNewOptionToLowCardinality", "True");
            this.ExtendedProperties.Add("Deklarit.DescriptionAttribute", "PT");
            this.ExtendedProperties.Add("Deklarit.LowCardinality", "True");
        }

        private void InitClassBase()
        {
            this.DataSetName = "PARTNERDataSet";
            this.Namespace = "http://www.tempuri.org/PARTNER";
            this.tablePARTNERZADUZENJE = new PARTNERZADUZENJEDataTable();
            this.Tables.Add(this.tablePARTNERZADUZENJE);
            this.tablePARTNER = new PARTNERDataTable();
            this.Tables.Add(this.tablePARTNER);
            this.Relations.Add("PARTNER_PARTNERZADUZENJE", new DataColumn[] { this.Tables["PARTNER"].Columns["IDPARTNER"] }, new DataColumn[] { this.Tables["PARTNERZADUZENJE"].Columns["IDPARTNER"] });
            this.Relations["PARTNER_PARTNERZADUZENJE"].Nested = true;
            this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn.Expression = "CIJENAZADUZENJA*KOLICINAZADUZENJA";
            this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn.Expression = "IZNOSZADUZENJA-IZNOSRABATAZADUZENJE";
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
            this.tablePARTNERZADUZENJE = (PARTNERZADUZENJEDataTable) this.Tables["PARTNERZADUZENJE"];
            this.tablePARTNER = (PARTNERDataTable) this.Tables["PARTNER"];
            if (initTable)
            {
                if (this.tablePARTNERZADUZENJE != null)
                {
                    this.tablePARTNERZADUZENJE.InitVars();
                }
                if (this.tablePARTNER != null)
                {
                    this.tablePARTNER.InitVars();
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
                if (dataSet.Tables["PARTNERZADUZENJE"] != null)
                {
                    this.Tables.Add(new PARTNERZADUZENJEDataTable(dataSet.Tables["PARTNERZADUZENJE"]));
                }
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

        private bool ShouldSerializePARTNERZADUZENJE()
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PARTNERZADUZENJEDataTable PARTNERZADUZENJE
        {
            get
            {
                return this.tablePARTNERZADUZENJE;
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
            private DataColumn columnPT;

            public event PARTNERDataSet.PARTNERRowChangeEventHandler PARTNERRowChanged;

            public event PARTNERDataSet.PARTNERRowChangeEventHandler PARTNERRowChanging;

            public event PARTNERDataSet.PARTNERRowChangeEventHandler PARTNERRowDeleted;

            public event PARTNERDataSet.PARTNERRowChangeEventHandler PARTNERRowDeleting;

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

            public void AddPARTNERRow(PARTNERDataSet.PARTNERRow row)
            {
                this.Rows.Add(row);
            }

            public PARTNERDataSet.PARTNERRow AddPARTNERRow(int iDPARTNER, string nAZIVPARTNER, string mB, string pARTNERMJESTO, string pARTNERULICA, string pARTNEREMAIL, string pARTNEROIB, string pARTNERFAX, string pARTNERTELEFON, string pARTNERZIRO1, string pARTNERZIRO2)
            {
                PARTNERDataSet.PARTNERRow row = (PARTNERDataSet.PARTNERRow) this.NewRow();
                row["IDPARTNER"] = iDPARTNER;
                row["NAZIVPARTNER"] = nAZIVPARTNER;
                row["MB"] = mB;
                row["PARTNERMJESTO"] = pARTNERMJESTO;
                row["PARTNERULICA"] = pARTNERULICA;
                row["PARTNEREMAIL"] = pARTNEREMAIL;
                row["PARTNEROIB"] = pARTNEROIB;
                row["PARTNERFAX"] = pARTNERFAX;
                row["PARTNERTELEFON"] = pARTNERTELEFON;
                row["PARTNERZIRO1"] = pARTNERZIRO1;
                row["PARTNERZIRO2"] = pARTNERZIRO2;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PARTNERDataSet.PARTNERDataTable table = (PARTNERDataSet.PARTNERDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PARTNERDataSet.PARTNERRow FindByIDPARTNER(int iDPARTNER)
            {
                return (PARTNERDataSet.PARTNERRow) this.Rows.Find(new object[] { iDPARTNER });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PARTNERDataSet.PARTNERRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PARTNERDataSet set = new PARTNERDataSet();
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
                this.columnIDPARTNER.AllowDBNull = false;
                this.columnIDPARTNER.Caption = "Šifra partnera";
                this.columnIDPARTNER.Unique = true;
                this.columnIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPARTNER.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IDPARTNER");
                this.Columns.Add(this.columnIDPARTNER);
                this.columnNAZIVPARTNER = new DataColumn("NAZIVPARTNER", typeof(string), "", MappingType.Element);
                this.columnNAZIVPARTNER.AllowDBNull = false;
                this.columnNAZIVPARTNER.Caption = "Naziv partnera";
                this.columnNAZIVPARTNER.MaxLength = 100;
                this.columnNAZIVPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("ReadOnly", "false");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPARTNER.ExtendedProperties.Add("Description", "Partner");
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
                this.columnMB.AllowDBNull = true;
                this.columnMB.Caption = "MB";
                this.columnMB.MaxLength = 13;
                this.columnMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMB.ExtendedProperties.Add("IsKey", "false");
                this.columnMB.ExtendedProperties.Add("ReadOnly", "false");
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
                this.columnPARTNERMJESTO.AllowDBNull = false;
                this.columnPARTNERMJESTO.Caption = "PARTNERMJESTO";
                this.columnPARTNERMJESTO.MaxLength = 50;
                this.columnPARTNERMJESTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Description", "Mjesto");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Length", "50");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERMJESTO.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERMJESTO");
                this.Columns.Add(this.columnPARTNERMJESTO);
                this.columnPARTNERULICA = new DataColumn("PARTNERULICA", typeof(string), "", MappingType.Element);
                this.columnPARTNERULICA.AllowDBNull = false;
                this.columnPARTNERULICA.Caption = "PARTNERULICA";
                this.columnPARTNERULICA.MaxLength = 150;
                this.columnPARTNERULICA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERULICA.ExtendedProperties.Add("Description", "Ulica i broj");
                this.columnPARTNERULICA.ExtendedProperties.Add("Length", "150");
                this.columnPARTNERULICA.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERULICA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERULICA.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERULICA");
                this.Columns.Add(this.columnPARTNERULICA);
                this.columnPARTNEREMAIL = new DataColumn("PARTNEREMAIL", typeof(string), "", MappingType.Element);
                this.columnPARTNEREMAIL.AllowDBNull = true;
                this.columnPARTNEREMAIL.Caption = "PARTNEREMAIL";
                this.columnPARTNEREMAIL.MaxLength = 100;
                this.columnPARTNEREMAIL.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Description", "Primarni mail");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Length", "100");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEREMAIL.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEREMAIL");
                this.Columns.Add(this.columnPARTNEREMAIL);
                this.columnPARTNEROIB = new DataColumn("PARTNEROIB", typeof(string), "", MappingType.Element);
                this.columnPARTNEROIB.AllowDBNull = false;
                this.columnPARTNEROIB.Caption = "PARTNEROIB";
                this.columnPARTNEROIB.MaxLength = 25;
                this.columnPARTNEROIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNEROIB.ExtendedProperties.Add("Description", "OIB");
                this.columnPARTNEROIB.ExtendedProperties.Add("Length", "25");
                this.columnPARTNEROIB.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNEROIB.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNEROIB.ExtendedProperties.Add("Deklarit.InternalName", "PARTNEROIB");
                this.Columns.Add(this.columnPARTNEROIB);
                this.columnPARTNERFAX = new DataColumn("PARTNERFAX", typeof(string), "", MappingType.Element);
                this.columnPARTNERFAX.AllowDBNull = false;
                this.columnPARTNERFAX.Caption = "PARTNERFAX";
                this.columnPARTNERFAX.MaxLength = 20;
                this.columnPARTNERFAX.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERFAX.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERFAX.ExtendedProperties.Add("Description", "Fax");
                this.columnPARTNERFAX.ExtendedProperties.Add("Length", "20");
                this.columnPARTNERFAX.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERFAX.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERFAX.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERFAX");
                this.Columns.Add(this.columnPARTNERFAX);
                this.columnPARTNERTELEFON = new DataColumn("PARTNERTELEFON", typeof(string), "", MappingType.Element);
                this.columnPARTNERTELEFON.AllowDBNull = false;
                this.columnPARTNERTELEFON.Caption = "PARTNERTELEFON";
                this.columnPARTNERTELEFON.MaxLength = 50;
                this.columnPARTNERTELEFON.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Description", "Telefon");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Length", "50");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERTELEFON.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERTELEFON");
                this.Columns.Add(this.columnPARTNERTELEFON);
                this.columnPARTNERZIRO1 = new DataColumn("PARTNERZIRO1", typeof(string), "", MappingType.Element);
                this.columnPARTNERZIRO1.AllowDBNull = false;
                this.columnPARTNERZIRO1.Caption = "PARTNERZIR O1";
                this.columnPARTNERZIRO1.MaxLength = 0x12;
                this.columnPARTNERZIRO1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Description", "Žiro račun 1");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Length", "18");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERZIRO1.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERZIRO1");
                this.Columns.Add(this.columnPARTNERZIRO1);
                this.columnPARTNERZIRO2 = new DataColumn("PARTNERZIRO2", typeof(string), "", MappingType.Element);
                this.columnPARTNERZIRO2.AllowDBNull = true;
                this.columnPARTNERZIRO2.Caption = "PARTNERZIR O2";
                this.columnPARTNERZIRO2.MaxLength = 0x12;
                this.columnPARTNERZIRO2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("IsKey", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("ReadOnly", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Description", "Žiro račun 2");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Length", "18");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Decimals", "0");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("IsInReader", "true");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPARTNERZIRO2.ExtendedProperties.Add("Deklarit.InternalName", "PARTNERZIRO2");
                this.Columns.Add(this.columnPARTNERZIRO2);
                this.columnPT = new DataColumn("PT", typeof(string), "", MappingType.Element);
                this.columnPT.AllowDBNull = true;
                this.columnPT.Caption = "PT";
                this.columnPT.MaxLength = 0x7d;
                this.columnPT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
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
                this.PrimaryKey = new DataColumn[] { this.columnIDPARTNER };
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "PARTNER");
                this.ExtendedProperties.Add("Description", "PARTNER");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "True");
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
                this.columnPT = this.Columns["PT"];
            }

            public PARTNERDataSet.PARTNERRow NewPARTNERRow()
            {
                return (PARTNERDataSet.PARTNERRow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PARTNERDataSet.PARTNERRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PARTNERRowChanged != null)
                {
                    PARTNERDataSet.PARTNERRowChangeEventHandler pARTNERRowChangedEvent = this.PARTNERRowChanged;
                    if (pARTNERRowChangedEvent != null)
                    {
                        pARTNERRowChangedEvent(this, new PARTNERDataSet.PARTNERRowChangeEvent((PARTNERDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PARTNERRowChanging != null)
                {
                    PARTNERDataSet.PARTNERRowChangeEventHandler pARTNERRowChangingEvent = this.PARTNERRowChanging;
                    if (pARTNERRowChangingEvent != null)
                    {
                        pARTNERRowChangingEvent(this, new PARTNERDataSet.PARTNERRowChangeEvent((PARTNERDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PARTNERRowDeleted != null)
                {
                    PARTNERDataSet.PARTNERRowChangeEventHandler pARTNERRowDeletedEvent = this.PARTNERRowDeleted;
                    if (pARTNERRowDeletedEvent != null)
                    {
                        pARTNERRowDeletedEvent(this, new PARTNERDataSet.PARTNERRowChangeEvent((PARTNERDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PARTNERRowDeleting != null)
                {
                    PARTNERDataSet.PARTNERRowChangeEventHandler pARTNERRowDeletingEvent = this.PARTNERRowDeleting;
                    if (pARTNERRowDeletingEvent != null)
                    {
                        pARTNERRowDeletingEvent(this, new PARTNERDataSet.PARTNERRowChangeEvent((PARTNERDataSet.PARTNERRow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePARTNERRow(PARTNERDataSet.PARTNERRow row)
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

            public PARTNERDataSet.PARTNERRow this[int index]
            {
                get
                {
                    return (PARTNERDataSet.PARTNERRow) this.Rows[index];
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
            private PARTNERDataSet.PARTNERDataTable tablePARTNER;

            internal PARTNERRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePARTNER = (PARTNERDataSet.PARTNERDataTable) this.Table;
            }

            public PARTNERDataSet.PARTNERZADUZENJERow[] GetPARTNERZADUZENJERows()
            {
                return (PARTNERDataSet.PARTNERZADUZENJERow[]) this.GetChildRows("PARTNER_PARTNERZADUZENJE");
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

            public bool IsPTNull()
            {
                return this.IsNull(this.tablePARTNER.PTColumn);
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

            public void SetPTNull()
            {
                this[this.tablePARTNER.PTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int IDPARTNER
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePARTNER.IDPARTNERColumn]);
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
            private PARTNERDataSet.PARTNERRow eventRow;

            public PARTNERRowChangeEvent(PARTNERDataSet.PARTNERRow row, DataRowAction action)
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

            public PARTNERDataSet.PARTNERRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PARTNERRowChangeEventHandler(object sender, PARTNERDataSet.PARTNERRowChangeEvent e);

        [Serializable]
        public class PARTNERZADUZENJEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAKTIVNO;
            private DataColumn columnCIJENA;
            private DataColumn columnCIJENAZADUZENJA;
            private DataColumn columnCIJENAZAFAKTURU;
            private DataColumn columnDATUMUGOVORA;
            private DataColumn columnIDPARTNER;
            private DataColumn columnIDPROIZVOD;
            private DataColumn columnIDZADUZENJE;
            private DataColumn columnIZNOSRABATAZADUZENJE;
            private DataColumn columnIZNOSZADUZENJA;
            private DataColumn columnKOLICINAZADUZENJA;
            private DataColumn columnNAZIVPROIZVOD;
            private DataColumn columnRABATZADUZENJA;
            private DataColumn columnUGOVORBROJ;

            public event PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowChanged;

            public event PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowChanging;

            public event PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowDeleted;

            public event PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler PARTNERZADUZENJERowDeleting;

            public PARTNERZADUZENJEDataTable()
            {
                this.TableName = "PARTNERZADUZENJE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal PARTNERZADUZENJEDataTable(DataTable table) : base(table.TableName)
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

            protected PARTNERZADUZENJEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddPARTNERZADUZENJERow(PARTNERDataSet.PARTNERZADUZENJERow row)
            {
                this.Rows.Add(row);
            }

            public PARTNERDataSet.PARTNERZADUZENJERow AddPARTNERZADUZENJERow(int iDPARTNER, int iDZADUZENJE, int iDPROIZVOD, decimal kOLICINAZADUZENJA, decimal cIJENAZADUZENJA, decimal rABATZADUZENJA, string uGOVORBROJ, DateTime dATUMUGOVORA, bool aKTIVNO)
            {
                PARTNERDataSet.PARTNERZADUZENJERow row = (PARTNERDataSet.PARTNERZADUZENJERow) this.NewRow();
                row["IDPARTNER"] = iDPARTNER;
                row["IDZADUZENJE"] = iDZADUZENJE;
                row["IDPROIZVOD"] = iDPROIZVOD;
                row["KOLICINAZADUZENJA"] = kOLICINAZADUZENJA;
                row["CIJENAZADUZENJA"] = cIJENAZADUZENJA;
                row["RABATZADUZENJA"] = rABATZADUZENJA;
                row["UGOVORBROJ"] = uGOVORBROJ;
                row["DATUMUGOVORA"] = dATUMUGOVORA;
                row["AKTIVNO"] = aKTIVNO;
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                PARTNERDataSet.PARTNERZADUZENJEDataTable table = (PARTNERDataSet.PARTNERZADUZENJEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public PARTNERDataSet.PARTNERZADUZENJERow FindByIDPARTNERIDZADUZENJE(int iDPARTNER, int iDZADUZENJE)
            {
                return (PARTNERDataSet.PARTNERZADUZENJERow) this.Rows.Find(new object[] { iDPARTNER, iDZADUZENJE });
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(PARTNERDataSet.PARTNERZADUZENJERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                PARTNERDataSet set = new PARTNERDataSet();
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
                this.columnIDPARTNER.AllowDBNull = false;
                this.columnIDPARTNER.Caption = "Šifra partnera";
                this.columnIDPARTNER.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPARTNER.ExtendedProperties.Add("IsKey", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPARTNER.ExtendedProperties.Add("Description", "Šifra");
                this.columnIDPARTNER.ExtendedProperties.Add("Length", "9");
                this.columnIDPARTNER.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPARTNER.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPARTNER.ExtendedProperties.Add("Deklarit.InternalName", "IDPARTNER");
                this.Columns.Add(this.columnIDPARTNER);
                this.columnIDZADUZENJE = new DataColumn("IDZADUZENJE", typeof(int), "", MappingType.Element);
                this.columnIDZADUZENJE.AllowDBNull = false;
                this.columnIDZADUZENJE.Caption = "Zaduženje";
                this.columnIDZADUZENJE.AutoIncrement = true;
                this.columnIDZADUZENJE.AutoIncrementSeed = -1L;
                this.columnIDZADUZENJE.AutoIncrementStep = -1L;
                this.columnIDZADUZENJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDZADUZENJE.ExtendedProperties.Add("AutoNumber", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("IsKey", "true");
                this.columnIDZADUZENJE.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Description", "Zaduženje");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Length", "5");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Decimals", "0");
                this.columnIDZADUZENJE.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDZADUZENJE.ExtendedProperties.Add("Deklarit.InternalName", "IDZADUZENJE");
                this.Columns.Add(this.columnIDZADUZENJE);
                this.columnIDPROIZVOD = new DataColumn("IDPROIZVOD", typeof(int), "", MappingType.Element);
                this.columnIDPROIZVOD.AllowDBNull = false;
                this.columnIDPROIZVOD.Caption = "IDPROIZVOD";
                this.columnIDPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("ReadOnly", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Description", "IDPROIZVOD");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Length", "5");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnIDPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "IDPROIZVOD");
                this.Columns.Add(this.columnIDPROIZVOD);
                this.columnNAZIVPROIZVOD = new DataColumn("NAZIVPROIZVOD", typeof(string), "", MappingType.Element);
                this.columnNAZIVPROIZVOD.AllowDBNull = true;
                this.columnNAZIVPROIZVOD.Caption = "NAZIVPROIZVOD";
                this.columnNAZIVPROIZVOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Description", "NAZIVPROIZVOD");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Length", "500");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVPROIZVOD.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVPROIZVOD");
                this.Columns.Add(this.columnNAZIVPROIZVOD);
                this.columnCIJENA = new DataColumn("CIJENA", typeof(decimal), "", MappingType.Element);
                this.columnCIJENA.AllowDBNull = true;
                this.columnCIJENA.Caption = "CIJENA";
                this.columnCIJENA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENA.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnCIJENA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENA.ExtendedProperties.Add("Description", "CIJENA");
                this.columnCIJENA.ExtendedProperties.Add("Length", "9");
                this.columnCIJENA.ExtendedProperties.Add("Decimals", "4");
                this.columnCIJENA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENA.ExtendedProperties.Add("Deklarit.InternalName", "CIJENA");
                this.Columns.Add(this.columnCIJENA);
                this.columnKOLICINAZADUZENJA = new DataColumn("KOLICINAZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnKOLICINAZADUZENJA.AllowDBNull = false;
                this.columnKOLICINAZADUZENJA.Caption = "KOLICINAZADUZENJA";
                this.columnKOLICINAZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Description", "Količina");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Length", "5");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnKOLICINAZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "KOLICINAZADUZENJA");
                this.Columns.Add(this.columnKOLICINAZADUZENJA);
                this.columnCIJENAZADUZENJA = new DataColumn("CIJENAZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnCIJENAZADUZENJA.AllowDBNull = false;
                this.columnCIJENAZADUZENJA.Caption = "CIJENAZADUZENJA";
                this.columnCIJENAZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Description", "Cijena");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Length", "12");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENAZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "CIJENAZADUZENJA");
                this.Columns.Add(this.columnCIJENAZADUZENJA);
                this.columnIZNOSZADUZENJA = new DataColumn("IZNOSZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSZADUZENJA.AllowDBNull = true;
                this.columnIZNOSZADUZENJA.Caption = "IZNOSZADUZENJA";
                this.columnIZNOSZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Description", "Iznos");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSZADUZENJA");
                this.columnIZNOSZADUZENJA.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnIZNOSZADUZENJA);
                this.columnRABATZADUZENJA = new DataColumn("RABATZADUZENJA", typeof(decimal), "", MappingType.Element);
                this.columnRABATZADUZENJA.AllowDBNull = false;
                this.columnRABATZADUZENJA.Caption = "RABATZADUZENJA";
                this.columnRABATZADUZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Description", "Rabat %");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Length", "5");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Decimals", "2");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnRABATZADUZENJA.ExtendedProperties.Add("Deklarit.InternalName", "RABATZADUZENJA");
                this.Columns.Add(this.columnRABATZADUZENJA);
                this.columnIZNOSRABATAZADUZENJE = new DataColumn("IZNOSRABATAZADUZENJE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSRABATAZADUZENJE.AllowDBNull = true;
                this.columnIZNOSRABATAZADUZENJE.Caption = "IZNOSRABATAZADUZENJE";
                this.columnIZNOSRABATAZADUZENJE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Description", "Iznos rabata");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSRABATAZADUZENJE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSRABATAZADUZENJE");
                this.Columns.Add(this.columnIZNOSRABATAZADUZENJE);
                this.columnCIJENAZAFAKTURU = new DataColumn("CIJENAZAFAKTURU", typeof(decimal), "", MappingType.Element);
                this.columnCIJENAZAFAKTURU.AllowDBNull = true;
                this.columnCIJENAZAFAKTURU.Caption = "CIJENAZAFAKTURU";
                this.columnCIJENAZAFAKTURU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("IsKey", "false");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Description", "Iznos umanjen za rabat");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Length", "12");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Decimals", "2");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.InternalName", "CIJENAZAFAKTURU");
                this.columnCIJENAZAFAKTURU.ExtendedProperties.Add("Deklarit.IsFormula", "true");
                this.Columns.Add(this.columnCIJENAZAFAKTURU);
                this.columnUGOVORBROJ = new DataColumn("UGOVORBROJ", typeof(string), "", MappingType.Element);
                this.columnUGOVORBROJ.AllowDBNull = false;
                this.columnUGOVORBROJ.Caption = "UGOVORBROJ";
                this.columnUGOVORBROJ.MaxLength = 200;
                this.columnUGOVORBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUGOVORBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("ReadOnly", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Description", "Ugovor");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Length", "200");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnUGOVORBROJ.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUGOVORBROJ.ExtendedProperties.Add("Deklarit.InternalName", "UGOVORBROJ");
                this.Columns.Add(this.columnUGOVORBROJ);
                this.columnDATUMUGOVORA = new DataColumn("DATUMUGOVORA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMUGOVORA.AllowDBNull = false;
                this.columnDATUMUGOVORA.Caption = "DATUMUGOVORA";
                this.columnDATUMUGOVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("ReadOnly", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Description", "Datum");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMUGOVORA");
                this.Columns.Add(this.columnDATUMUGOVORA);
                this.columnAKTIVNO = new DataColumn("AKTIVNO", typeof(bool), "", MappingType.Element);
                this.columnAKTIVNO.AllowDBNull = false;
                this.columnAKTIVNO.Caption = "AKTIVNO";
                this.columnAKTIVNO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnAKTIVNO.ExtendedProperties.Add("IsKey", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("ReadOnly", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("DeklaritType", "boolean");
                this.columnAKTIVNO.ExtendedProperties.Add("Description", "AKTIVNO");
                this.columnAKTIVNO.ExtendedProperties.Add("Length", "1");
                this.columnAKTIVNO.ExtendedProperties.Add("Decimals", "0");
                this.columnAKTIVNO.ExtendedProperties.Add("AllowDBNulls", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnAKTIVNO.ExtendedProperties.Add("Deklarit.InternalName", "AKTIVNO");
                this.Columns.Add(this.columnAKTIVNO);
                this.PrimaryKey = new DataColumn[] { this.columnIDPARTNER, this.columnIDZADUZENJE };
                this.ExtendedProperties.Add("ParentLvl", "PARTNER");
                this.ExtendedProperties.Add("LevelName", "ZADUZENJE");
                this.ExtendedProperties.Add("Description", "Zaduzenja partnera");
                this.ExtendedProperties.Add("msprop:AllowInsert", "true");
                this.ExtendedProperties.Add("msprop:AllowUpdate", "true");
                this.ExtendedProperties.Add("msprop:AllowDelete", "true");
                this.ExtendedProperties.Add("Deklarit.EditInDataGrid", "False");
                this.ExtendedProperties.Add("Deklarit.DefaultSortString", "");
            }

            internal void InitVars()
            {
                this.columnIDPARTNER = this.Columns["IDPARTNER"];
                this.columnIDZADUZENJE = this.Columns["IDZADUZENJE"];
                this.columnIDPROIZVOD = this.Columns["IDPROIZVOD"];
                this.columnNAZIVPROIZVOD = this.Columns["NAZIVPROIZVOD"];
                this.columnCIJENA = this.Columns["CIJENA"];
                this.columnKOLICINAZADUZENJA = this.Columns["KOLICINAZADUZENJA"];
                this.columnCIJENAZADUZENJA = this.Columns["CIJENAZADUZENJA"];
                this.columnIZNOSZADUZENJA = this.Columns["IZNOSZADUZENJA"];
                this.columnRABATZADUZENJA = this.Columns["RABATZADUZENJA"];
                this.columnIZNOSRABATAZADUZENJE = this.Columns["IZNOSRABATAZADUZENJE"];
                this.columnCIJENAZAFAKTURU = this.Columns["CIJENAZAFAKTURU"];
                this.columnUGOVORBROJ = this.Columns["UGOVORBROJ"];
                this.columnDATUMUGOVORA = this.Columns["DATUMUGOVORA"];
                this.columnAKTIVNO = this.Columns["AKTIVNO"];
            }

            public PARTNERDataSet.PARTNERZADUZENJERow NewPARTNERZADUZENJERow()
            {
                return (PARTNERDataSet.PARTNERZADUZENJERow) this.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PARTNERDataSet.PARTNERZADUZENJERow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PARTNERZADUZENJERowChanged != null)
                {
                    PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowChangedEvent = this.PARTNERZADUZENJERowChanged;
                    if (pARTNERZADUZENJERowChangedEvent != null)
                    {
                        pARTNERZADUZENJERowChangedEvent(this, new PARTNERDataSet.PARTNERZADUZENJERowChangeEvent((PARTNERDataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PARTNERZADUZENJERowChanging != null)
                {
                    PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowChangingEvent = this.PARTNERZADUZENJERowChanging;
                    if (pARTNERZADUZENJERowChangingEvent != null)
                    {
                        pARTNERZADUZENJERowChangingEvent(this, new PARTNERDataSet.PARTNERZADUZENJERowChangeEvent((PARTNERDataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                DataRow parentRow = e.Row.GetParentRow("PARTNER_PARTNERZADUZENJE", DataRowVersion.Original);
                if ((parentRow != null) && (parentRow.RowState == DataRowState.Unchanged))
                {
                    parentRow[0] = RuntimeHelpers.GetObjectValue(parentRow[0]);
                }
                if (this.PARTNERZADUZENJERowDeleted != null)
                {
                    PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowDeletedEvent = this.PARTNERZADUZENJERowDeleted;
                    if (pARTNERZADUZENJERowDeletedEvent != null)
                    {
                        pARTNERZADUZENJERowDeletedEvent(this, new PARTNERDataSet.PARTNERZADUZENJERowChangeEvent((PARTNERDataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PARTNERZADUZENJERowDeleting != null)
                {
                    PARTNERDataSet.PARTNERZADUZENJERowChangeEventHandler pARTNERZADUZENJERowDeletingEvent = this.PARTNERZADUZENJERowDeleting;
                    if (pARTNERZADUZENJERowDeletingEvent != null)
                    {
                        pARTNERZADUZENJERowDeletingEvent(this, new PARTNERDataSet.PARTNERZADUZENJERowChangeEvent((PARTNERDataSet.PARTNERZADUZENJERow) e.Row, e.Action));
                    }
                }
            }

            public void RemovePARTNERZADUZENJERow(PARTNERDataSet.PARTNERZADUZENJERow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn AKTIVNOColumn
            {
                get
                {
                    return this.columnAKTIVNO;
                }
            }

            public DataColumn CIJENAColumn
            {
                get
                {
                    return this.columnCIJENA;
                }
            }

            public DataColumn CIJENAZADUZENJAColumn
            {
                get
                {
                    return this.columnCIJENAZADUZENJA;
                }
            }

            public DataColumn CIJENAZAFAKTURUColumn
            {
                get
                {
                    return this.columnCIJENAZAFAKTURU;
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

            public DataColumn DATUMUGOVORAColumn
            {
                get
                {
                    return this.columnDATUMUGOVORA;
                }
            }

            public DataColumn IDPARTNERColumn
            {
                get
                {
                    return this.columnIDPARTNER;
                }
            }

            public DataColumn IDPROIZVODColumn
            {
                get
                {
                    return this.columnIDPROIZVOD;
                }
            }

            public DataColumn IDZADUZENJEColumn
            {
                get
                {
                    return this.columnIDZADUZENJE;
                }
            }

            public PARTNERDataSet.PARTNERZADUZENJERow this[int index]
            {
                get
                {
                    return (PARTNERDataSet.PARTNERZADUZENJERow) this.Rows[index];
                }
            }

            public DataColumn IZNOSRABATAZADUZENJEColumn
            {
                get
                {
                    return this.columnIZNOSRABATAZADUZENJE;
                }
            }

            public DataColumn IZNOSZADUZENJAColumn
            {
                get
                {
                    return this.columnIZNOSZADUZENJA;
                }
            }

            public DataColumn KOLICINAZADUZENJAColumn
            {
                get
                {
                    return this.columnKOLICINAZADUZENJA;
                }
            }

            public DataColumn NAZIVPROIZVODColumn
            {
                get
                {
                    return this.columnNAZIVPROIZVOD;
                }
            }

            public DataColumn RABATZADUZENJAColumn
            {
                get
                {
                    return this.columnRABATZADUZENJA;
                }
            }

            public DataColumn UGOVORBROJColumn
            {
                get
                {
                    return this.columnUGOVORBROJ;
                }
            }
        }

        public class PARTNERZADUZENJERow : DataRow
        {
            private PARTNERDataSet.PARTNERZADUZENJEDataTable tablePARTNERZADUZENJE;

            internal PARTNERZADUZENJERow(DataRowBuilder rb) : base(rb)
            {
                this.tablePARTNERZADUZENJE = (PARTNERDataSet.PARTNERZADUZENJEDataTable) this.Table;
            }

            public PARTNERDataSet.PARTNERRow GetPARTNERRow()
            {
                return (PARTNERDataSet.PARTNERRow) this.GetParentRow("PARTNER_PARTNERZADUZENJE");
            }

            public bool IsAKTIVNONull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.AKTIVNOColumn);
            }

            public bool IsCIJENANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.CIJENAColumn);
            }

            public bool IsCIJENAZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn);
            }

            public bool IsCIJENAZAFAKTURUNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn);
            }

            public bool IsDATUMUGOVORANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn);
            }

            public bool IsIDPARTNERNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IDPARTNERColumn);
            }

            public bool IsIDPROIZVODNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IDPROIZVODColumn);
            }

            public bool IsIDZADUZENJENull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IDZADUZENJEColumn);
            }

            public bool IsIZNOSRABATAZADUZENJENull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn);
            }

            public bool IsIZNOSZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn);
            }

            public bool IsKOLICINAZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn);
            }

            public bool IsNAZIVPROIZVODNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn);
            }

            public bool IsRABATZADUZENJANull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn);
            }

            public bool IsUGOVORBROJNull()
            {
                return this.IsNull(this.tablePARTNERZADUZENJE.UGOVORBROJColumn);
            }

            public void SetAKTIVNONull()
            {
                this[this.tablePARTNERZADUZENJE.AKTIVNOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCIJENANull()
            {
                this[this.tablePARTNERZADUZENJE.CIJENAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCIJENAZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetCIJENAZAFAKTURUNull()
            {
                this[this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMUGOVORANull()
            {
                this[this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDPROIZVODNull()
            {
                this[this.tablePARTNERZADUZENJE.IDPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSRABATAZADUZENJENull()
            {
                this[this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetKOLICINAZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVPROIZVODNull()
            {
                this[this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetRABATZADUZENJANull()
            {
                this[this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUGOVORBROJNull()
            {
                this[this.tablePARTNERZADUZENJE.UGOVORBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public bool AKTIVNO
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tablePARTNERZADUZENJE.AKTIVNOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.AKTIVNOColumn] = value;
                }
            }

            public decimal CIJENA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.CIJENAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.CIJENAColumn] = value;
                }
            }

            public decimal CIJENAZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.CIJENAZADUZENJAColumn] = value;
                }
            }

            public decimal CIJENAZAFAKTURU
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.CIJENAZAFAKTURUColumn] = value;
                }
            }

            public DateTime DATUMUGOVORA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.DATUMUGOVORAColumn] = value;
                }
            }

            public int IDPARTNER
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePARTNERZADUZENJE.IDPARTNERColumn]);
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IDPARTNERColumn] = value;
                }
            }

            public int IDPROIZVOD
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablePARTNERZADUZENJE.IDPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IDPROIZVODColumn] = value;
                }
            }

            public int IDZADUZENJE
            {
                get
                {
                    return Conversions.ToInteger(this[this.tablePARTNERZADUZENJE.IDZADUZENJEColumn]);
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IDZADUZENJEColumn] = value;
                }
            }

            public decimal IZNOSRABATAZADUZENJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IZNOSRABATAZADUZENJEColumn] = value;
                }
            }

            public decimal IZNOSZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.IZNOSZADUZENJAColumn] = value;
                }
            }

            public decimal KOLICINAZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.KOLICINAZADUZENJAColumn] = value;
                }
            }

            public string NAZIVPROIZVOD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.NAZIVPROIZVODColumn] = value;
                }
            }

            public decimal RABATZADUZENJA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.RABATZADUZENJAColumn] = value;
                }
            }

            public string UGOVORBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablePARTNERZADUZENJE.UGOVORBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablePARTNERZADUZENJE.UGOVORBROJColumn] = value;
                }
            }
        }

        public class PARTNERZADUZENJERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private PARTNERDataSet.PARTNERZADUZENJERow eventRow;

            public PARTNERZADUZENJERowChangeEvent(PARTNERDataSet.PARTNERZADUZENJERow row, DataRowAction action)
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

            public PARTNERDataSet.PARTNERZADUZENJERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PARTNERZADUZENJERowChangeEventHandler(object sender, PARTNERDataSet.PARTNERZADUZENJERowChangeEvent e);
    }
}

