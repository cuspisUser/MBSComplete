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
    public class S_PLACA_KREDITI_KARTICEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_PLACA_KREDITI_KARTICEDataTable tableS_PLACA_KREDITI_KARTICE;

        public S_PLACA_KREDITI_KARTICEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_PLACA_KREDITI_KARTICEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_PLACA_KREDITI_KARTICE"] != null)
                    {
                        this.Tables.Add(new S_PLACA_KREDITI_KARTICEDataTable(dataSet.Tables["S_PLACA_KREDITI_KARTICE"]));
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
            S_PLACA_KREDITI_KARTICEDataSet set = (S_PLACA_KREDITI_KARTICEDataSet) base.Clone();
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
            S_PLACA_KREDITI_KARTICEDataSet set = new S_PLACA_KREDITI_KARTICEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_PLACA_KREDITI_KARTICEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2191");
            this.ExtendedProperties.Add("DataSetName", "S_PLACA_KREDITI_KARTICEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_PLACA_KREDITI_KARTICEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_PLACA_KREDITI_KARTICE");
            this.ExtendedProperties.Add("ObjectDescription", "S_PLACA_KREDITI_KARTICE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_PLACA_KREDITI_KARTICE");
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
            this.DataSetName = "S_PLACA_KREDITI_KARTICEDataSet";
            this.Namespace = "http://www.tempuri.org/S_PLACA_KREDITI_KARTICE";
            this.tableS_PLACA_KREDITI_KARTICE = new S_PLACA_KREDITI_KARTICEDataTable();
            this.Tables.Add(this.tableS_PLACA_KREDITI_KARTICE);
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
            this.tableS_PLACA_KREDITI_KARTICE = (S_PLACA_KREDITI_KARTICEDataTable) this.Tables["S_PLACA_KREDITI_KARTICE"];
            if (initTable && (this.tableS_PLACA_KREDITI_KARTICE != null))
            {
                this.tableS_PLACA_KREDITI_KARTICE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_PLACA_KREDITI_KARTICE"] != null)
                {
                    this.Tables.Add(new S_PLACA_KREDITI_KARTICEDataTable(dataSet.Tables["S_PLACA_KREDITI_KARTICE"]));
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

        private bool ShouldSerializeS_PLACA_KREDITI_KARTICE()
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
        public S_PLACA_KREDITI_KARTICEDataTable S_PLACA_KREDITI_KARTICE
        {
            get
            {
                return this.tableS_PLACA_KREDITI_KARTICE;
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
        public class S_PLACA_KREDITI_KARTICEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDATUM;
            private DataColumn columnDATUMUGOVORA;
            private DataColumn columnIDOBRACUN;
            private DataColumn columnIDRADNIK;
            private DataColumn columnISPLACENOKASA;
            private DataColumn columnIZNOSOBUSTAVE;
            private DataColumn columnNAZIVOBUSTAVA;
            private DataColumn columnPOSTOTAKOBUSTAVE;
            private DataColumn columnSALDOKASA;
            private DataColumn columnSIFRAZAKARTICU;
            private DataColumn columnUKUNAMA;
            private DataColumn columnvrsta;

            public event S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler S_PLACA_KREDITI_KARTICERowChanged;

            public event S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler S_PLACA_KREDITI_KARTICERowChanging;

            public event S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler S_PLACA_KREDITI_KARTICERowDeleted;

            public event S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler S_PLACA_KREDITI_KARTICERowDeleting;

            public S_PLACA_KREDITI_KARTICEDataTable()
            {
                this.TableName = "S_PLACA_KREDITI_KARTICE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_PLACA_KREDITI_KARTICEDataTable(DataTable table) : base(table.TableName)
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

            protected S_PLACA_KREDITI_KARTICEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_PLACA_KREDITI_KARTICERow(S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow row)
            {
                this.Rows.Add(row);
            }

            public S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow AddS_PLACA_KREDITI_KARTICERow(int iDRADNIK, string nAZIVOBUSTAVA, decimal iZNOSOBUSTAVE, decimal pOSTOTAKOBUSTAVE, decimal uKUNAMA, decimal iSPLACENOKASA, decimal sALDOKASA, DateTime dATUM, DateTime dATUMUGOVORA, string vrsta, string iDOBRACUN, int sIFRAZAKARTICU)
            {
                S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow row = (S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow) this.NewRow();
                row.ItemArray = new object[] { iDRADNIK, nAZIVOBUSTAVA, iZNOSOBUSTAVE, pOSTOTAKOBUSTAVE, uKUNAMA, iSPLACENOKASA, sALDOKASA, dATUM, dATUMUGOVORA, vrsta, iDOBRACUN, sIFRAZAKARTICU };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICEDataTable table = (S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_PLACA_KREDITI_KARTICEDataSet set = new S_PLACA_KREDITI_KARTICEDataSet();
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
                this.columnIDRADNIK = new DataColumn("IDRADNIK", typeof(int), "", MappingType.Element);
                this.columnIDRADNIK.Caption = "Šifra radnika";
                this.columnIDRADNIK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("IsKey", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDRADNIK.ExtendedProperties.Add("Description", "Šifra radnika");
                this.columnIDRADNIK.ExtendedProperties.Add("Length", "8");
                this.columnIDRADNIK.ExtendedProperties.Add("Decimals", "0");
                this.columnIDRADNIK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDRADNIK.ExtendedProperties.Add("Deklarit.InternalName", "IDRADNIK");
                this.Columns.Add(this.columnIDRADNIK);
                this.columnNAZIVOBUSTAVA = new DataColumn("NAZIVOBUSTAVA", typeof(string), "", MappingType.Element);
                this.columnNAZIVOBUSTAVA.Caption = "Naziv obustave";
                this.columnNAZIVOBUSTAVA.MaxLength = 100;
                this.columnNAZIVOBUSTAVA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Description", "Naziv obustave");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Length", "100");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOBUSTAVA.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOBUSTAVA");
                this.Columns.Add(this.columnNAZIVOBUSTAVA);
                this.columnIZNOSOBUSTAVE = new DataColumn("IZNOSOBUSTAVE", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOBUSTAVE.Caption = "IZNOSOBUSTAVE";
                this.columnIZNOSOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Description", "IZNOSOBUSTAVE");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOBUSTAVE");
                this.Columns.Add(this.columnIZNOSOBUSTAVE);
                this.columnPOSTOTAKOBUSTAVE = new DataColumn("POSTOTAKOBUSTAVE", typeof(decimal), "", MappingType.Element);
                this.columnPOSTOTAKOBUSTAVE.Caption = "POSTOTAKOBUSTAVE";
                this.columnPOSTOTAKOBUSTAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Description", "POSTOTAKOBUSTAVE");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Length", "5");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Decimals", "2");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOSTOTAKOBUSTAVE.ExtendedProperties.Add("Deklarit.InternalName", "POSTOTAKOBUSTAVE");
                this.Columns.Add(this.columnPOSTOTAKOBUSTAVE);
                this.columnUKUNAMA = new DataColumn("UKUNAMA", typeof(decimal), "", MappingType.Element);
                this.columnUKUNAMA.Caption = "UKUNAMA";
                this.columnUKUNAMA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnUKUNAMA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnUKUNAMA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnUKUNAMA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnUKUNAMA.ExtendedProperties.Add("IsKey", "false");
                this.columnUKUNAMA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnUKUNAMA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnUKUNAMA.ExtendedProperties.Add("Description", "UKUNAMA");
                this.columnUKUNAMA.ExtendedProperties.Add("Length", "12");
                this.columnUKUNAMA.ExtendedProperties.Add("Decimals", "2");
                this.columnUKUNAMA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnUKUNAMA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnUKUNAMA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnUKUNAMA.ExtendedProperties.Add("IsInReader", "true");
                this.columnUKUNAMA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnUKUNAMA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnUKUNAMA.ExtendedProperties.Add("Deklarit.InternalName", "UKUNAMA");
                this.Columns.Add(this.columnUKUNAMA);
                this.columnISPLACENOKASA = new DataColumn("ISPLACENOKASA", typeof(decimal), "", MappingType.Element);
                this.columnISPLACENOKASA.Caption = "ISPLACENOKASA";
                this.columnISPLACENOKASA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("IsKey", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Description", "ISPLACENOKASA");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Length", "12");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Decimals", "2");
                this.columnISPLACENOKASA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnISPLACENOKASA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("IsInReader", "true");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnISPLACENOKASA.ExtendedProperties.Add("Deklarit.InternalName", "ISPLACENOKASA");
                this.Columns.Add(this.columnISPLACENOKASA);
                this.columnSALDOKASA = new DataColumn("SALDOKASA", typeof(decimal), "", MappingType.Element);
                this.columnSALDOKASA.Caption = "SALDOKASA";
                this.columnSALDOKASA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("IsKey", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSALDOKASA.ExtendedProperties.Add("Description", "SALDOKASA");
                this.columnSALDOKASA.ExtendedProperties.Add("Length", "12");
                this.columnSALDOKASA.ExtendedProperties.Add("Decimals", "2");
                this.columnSALDOKASA.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnSALDOKASA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSALDOKASA.ExtendedProperties.Add("Deklarit.InternalName", "SALDOKASA");
                this.Columns.Add(this.columnSALDOKASA);
                this.columnDATUM = new DataColumn("DATUM", typeof(DateTime), "", MappingType.Element);
                this.columnDATUM.Caption = "Datum";
                this.columnDATUM.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUM.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUM.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUM.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUM.ExtendedProperties.Add("Description", "Datum");
                this.columnDATUM.ExtendedProperties.Add("Length", "8");
                this.columnDATUM.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUM.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUM.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUM.ExtendedProperties.Add("Deklarit.InternalName", "DATUM");
                this.Columns.Add(this.columnDATUM);
                this.columnDATUMUGOVORA = new DataColumn("DATUMUGOVORA", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMUGOVORA.Caption = "DATUMUGOVORA";
                this.columnDATUMUGOVORA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Description", "DATUMUGOVORA");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Length", "8");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMUGOVORA.ExtendedProperties.Add("Deklarit.InternalName", "DATUMUGOVORA");
                this.Columns.Add(this.columnDATUMUGOVORA);
                this.columnvrsta = new DataColumn("vrsta", typeof(string), "", MappingType.Element);
                this.columnvrsta.Caption = "vrsta";
                this.columnvrsta.MaxLength = 50;
                this.columnvrsta.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnvrsta.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnvrsta.ExtendedProperties.Add("IsKey", "false");
                this.columnvrsta.ExtendedProperties.Add("ReadOnly", "true");
                this.columnvrsta.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnvrsta.ExtendedProperties.Add("Description", "vrsta");
                this.columnvrsta.ExtendedProperties.Add("Length", "50");
                this.columnvrsta.ExtendedProperties.Add("Decimals", "0");
                this.columnvrsta.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnvrsta.ExtendedProperties.Add("IsInReader", "true");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnvrsta.ExtendedProperties.Add("Deklarit.InternalName", "vrsta");
                this.Columns.Add(this.columnvrsta);
                this.columnIDOBRACUN = new DataColumn("IDOBRACUN", typeof(string), "", MappingType.Element);
                this.columnIDOBRACUN.Caption = "";
                this.columnIDOBRACUN.MaxLength = 11;
                this.columnIDOBRACUN.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsKey", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnIDOBRACUN.ExtendedProperties.Add("Description", "");
                this.columnIDOBRACUN.ExtendedProperties.Add("Length", "11");
                this.columnIDOBRACUN.ExtendedProperties.Add("Decimals", "0");
                this.columnIDOBRACUN.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDOBRACUN.ExtendedProperties.Add("Deklarit.InternalName", "IDOBRACUN");
                this.Columns.Add(this.columnIDOBRACUN);
                this.columnSIFRAZAKARTICU = new DataColumn("SIFRAZAKARTICU", typeof(int), "", MappingType.Element);
                this.columnSIFRAZAKARTICU.Caption = "SIFRAZAKARTICU";
                this.columnSIFRAZAKARTICU.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Description", "SIFRAZAKARTICU");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Length", "8");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAZAKARTICU.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAZAKARTICU");
                this.Columns.Add(this.columnSIFRAZAKARTICU);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_PLACA_KREDITI_KARTICE");
                this.ExtendedProperties.Add("Description", "_S_PLACA_KREDITI_KARTICE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnNAZIVOBUSTAVA = this.Columns["NAZIVOBUSTAVA"];
                this.columnIZNOSOBUSTAVE = this.Columns["IZNOSOBUSTAVE"];
                this.columnPOSTOTAKOBUSTAVE = this.Columns["POSTOTAKOBUSTAVE"];
                this.columnUKUNAMA = this.Columns["UKUNAMA"];
                this.columnISPLACENOKASA = this.Columns["ISPLACENOKASA"];
                this.columnSALDOKASA = this.Columns["SALDOKASA"];
                this.columnDATUM = this.Columns["DATUM"];
                this.columnDATUMUGOVORA = this.Columns["DATUMUGOVORA"];
                this.columnvrsta = this.Columns["vrsta"];
                this.columnIDOBRACUN = this.Columns["IDOBRACUN"];
                this.columnSIFRAZAKARTICU = this.Columns["SIFRAZAKARTICU"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow(builder);
            }

            public S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow NewS_PLACA_KREDITI_KARTICERow()
            {
                return (S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_PLACA_KREDITI_KARTICERowChanged != null)
                {
                    S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler handler = this.S_PLACA_KREDITI_KARTICERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEvent((S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_PLACA_KREDITI_KARTICERowChanging != null)
                {
                    S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler handler = this.S_PLACA_KREDITI_KARTICERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEvent((S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_PLACA_KREDITI_KARTICERowDeleted != null)
                {
                    S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler handler = this.S_PLACA_KREDITI_KARTICERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEvent((S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_PLACA_KREDITI_KARTICERowDeleting != null)
                {
                    S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEventHandler handler = this.S_PLACA_KREDITI_KARTICERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEvent((S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_PLACA_KREDITI_KARTICERow(S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow row)
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

            public DataColumn DATUMColumn
            {
                get
                {
                    return this.columnDATUM;
                }
            }

            public DataColumn DATUMUGOVORAColumn
            {
                get
                {
                    return this.columnDATUMUGOVORA;
                }
            }

            public DataColumn IDOBRACUNColumn
            {
                get
                {
                    return this.columnIDOBRACUN;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public DataColumn ISPLACENOKASAColumn
            {
                get
                {
                    return this.columnISPLACENOKASA;
                }
            }

            public S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow this[int index]
            {
                get
                {
                    return (S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow) this.Rows[index];
                }
            }

            public DataColumn IZNOSOBUSTAVEColumn
            {
                get
                {
                    return this.columnIZNOSOBUSTAVE;
                }
            }

            public DataColumn NAZIVOBUSTAVAColumn
            {
                get
                {
                    return this.columnNAZIVOBUSTAVA;
                }
            }

            public DataColumn POSTOTAKOBUSTAVEColumn
            {
                get
                {
                    return this.columnPOSTOTAKOBUSTAVE;
                }
            }

            public DataColumn SALDOKASAColumn
            {
                get
                {
                    return this.columnSALDOKASA;
                }
            }

            public DataColumn SIFRAZAKARTICUColumn
            {
                get
                {
                    return this.columnSIFRAZAKARTICU;
                }
            }

            public DataColumn UKUNAMAColumn
            {
                get
                {
                    return this.columnUKUNAMA;
                }
            }

            public DataColumn vrstaColumn
            {
                get
                {
                    return this.columnvrsta;
                }
            }
        }

        public class S_PLACA_KREDITI_KARTICERow : DataRow
        {
            private S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICEDataTable tableS_PLACA_KREDITI_KARTICE;

            internal S_PLACA_KREDITI_KARTICERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_PLACA_KREDITI_KARTICE = (S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICEDataTable) this.Table;
            }

            public bool IsDATUMNull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.DATUMColumn);
            }

            public bool IsDATUMUGOVORANull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.DATUMUGOVORAColumn);
            }

            public bool IsIDOBRACUNNull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.IDOBRACUNColumn);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.IDRADNIKColumn);
            }

            public bool IsISPLACENOKASANull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.ISPLACENOKASAColumn);
            }

            public bool IsIZNOSOBUSTAVENull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.IZNOSOBUSTAVEColumn);
            }

            public bool IsNAZIVOBUSTAVANull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.NAZIVOBUSTAVAColumn);
            }

            public bool IsPOSTOTAKOBUSTAVENull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.POSTOTAKOBUSTAVEColumn);
            }

            public bool IsSALDOKASANull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.SALDOKASAColumn);
            }

            public bool IsSIFRAZAKARTICUNull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.SIFRAZAKARTICUColumn);
            }

            public bool IsUKUNAMANull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.UKUNAMAColumn);
            }

            public bool IsvrstaNull()
            {
                return this.IsNull(this.tableS_PLACA_KREDITI_KARTICE.vrstaColumn);
            }

            public void SetDATUMNull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.DATUMColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMUGOVORANull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.DATUMUGOVORAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDOBRACUNNull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.IDOBRACUNColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetISPLACENOKASANull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.ISPLACENOKASAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOBUSTAVENull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.IZNOSOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOBUSTAVANull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.NAZIVOBUSTAVAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOSTOTAKOBUSTAVENull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.POSTOTAKOBUSTAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSALDOKASANull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.SALDOKASAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAZAKARTICUNull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.SIFRAZAKARTICUColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetUKUNAMANull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.UKUNAMAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetvrstaNull()
            {
                this[this.tableS_PLACA_KREDITI_KARTICE.vrstaColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public DateTime DATUM
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_PLACA_KREDITI_KARTICE.DATUMColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.DATUMColumn] = value;
                }
            }

            public DateTime DATUMUGOVORA
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_PLACA_KREDITI_KARTICE.DATUMUGOVORAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMUGOVORA because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.DATUMUGOVORAColumn] = value;
                }
            }

            public string IDOBRACUN
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KREDITI_KARTICE.IDOBRACUNColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value IDOBRACUN because it is DBNull.", innerException);
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.IDOBRACUNColumn] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_KREDITI_KARTICE.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.IDRADNIKColumn] = value;
                }
            }

            public decimal ISPLACENOKASA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KREDITI_KARTICE.ISPLACENOKASAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.ISPLACENOKASAColumn] = value;
                }
            }

            public decimal IZNOSOBUSTAVE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KREDITI_KARTICE.IZNOSOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.IZNOSOBUSTAVEColumn] = value;
                }
            }

            public string NAZIVOBUSTAVA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KREDITI_KARTICE.NAZIVOBUSTAVAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.NAZIVOBUSTAVAColumn] = value;
                }
            }

            public decimal POSTOTAKOBUSTAVE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KREDITI_KARTICE.POSTOTAKOBUSTAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.POSTOTAKOBUSTAVEColumn] = value;
                }
            }

            public decimal SALDOKASA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KREDITI_KARTICE.SALDOKASAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.SALDOKASAColumn] = value;
                }
            }

            public int SIFRAZAKARTICU
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_PLACA_KREDITI_KARTICE.SIFRAZAKARTICUColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.SIFRAZAKARTICUColumn] = value;
                }
            }

            public decimal UKUNAMA
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_PLACA_KREDITI_KARTICE.UKUNAMAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.UKUNAMAColumn] = value;
                }
            }

            public string vrsta
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_PLACA_KREDITI_KARTICE.vrstaColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_PLACA_KREDITI_KARTICE.vrstaColumn] = value;
                }
            }
        }

        public class S_PLACA_KREDITI_KARTICERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow eventRow;

            public S_PLACA_KREDITI_KARTICERowChangeEvent(S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow row, DataRowAction action)
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

            public S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_PLACA_KREDITI_KARTICERowChangeEventHandler(object sender, S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERowChangeEvent e);
    }
}

