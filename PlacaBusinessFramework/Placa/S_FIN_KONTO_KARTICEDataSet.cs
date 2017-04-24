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
    public class S_FIN_KONTO_KARTICEDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private S_FIN_KONTO_KARTICEDataTable tableS_FIN_KONTO_KARTICE;

        public S_FIN_KONTO_KARTICEDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected S_FIN_KONTO_KARTICEDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["S_FIN_KONTO_KARTICE"] != null)
                    {
                        this.Tables.Add(new S_FIN_KONTO_KARTICEDataTable(dataSet.Tables["S_FIN_KONTO_KARTICE"]));
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
            S_FIN_KONTO_KARTICEDataSet set = (S_FIN_KONTO_KARTICEDataSet) base.Clone();
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
            S_FIN_KONTO_KARTICEDataSet set = new S_FIN_KONTO_KARTICEDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "S_FIN_KONTO_KARTICEDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2166");
            this.ExtendedProperties.Add("DataSetName", "S_FIN_KONTO_KARTICEDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "IS_FIN_KONTO_KARTICEDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "S_FIN_KONTO_KARTICE");
            this.ExtendedProperties.Add("ObjectDescription", "S_FIN_KONTO_KARTICE");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_FINPOS");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_FIN_KONTO_KARTICE");
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
            this.DataSetName = "S_FIN_KONTO_KARTICEDataSet";
            this.Namespace = "http://www.tempuri.org/S_FIN_KONTO_KARTICE";
            this.tableS_FIN_KONTO_KARTICE = new S_FIN_KONTO_KARTICEDataTable();
            this.Tables.Add(this.tableS_FIN_KONTO_KARTICE);
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
            this.tableS_FIN_KONTO_KARTICE = (S_FIN_KONTO_KARTICEDataTable) this.Tables["S_FIN_KONTO_KARTICE"];
            if (initTable && (this.tableS_FIN_KONTO_KARTICE != null))
            {
                this.tableS_FIN_KONTO_KARTICE.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["S_FIN_KONTO_KARTICE"] != null)
                {
                    this.Tables.Add(new S_FIN_KONTO_KARTICEDataTable(dataSet.Tables["S_FIN_KONTO_KARTICE"]));
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

        private bool ShouldSerializeS_FIN_KONTO_KARTICE()
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
        public S_FIN_KONTO_KARTICEDataTable S_FIN_KONTO_KARTICE
        {
            get
            {
                return this.tableS_FIN_KONTO_KARTICE;
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
        public class S_FIN_KONTO_KARTICEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBROJDOK;
            private DataColumn columnBROJSTAVKE;
            private DataColumn columnDATUMDOK;
            private DataColumn columnDATUMPRIJAVE;
            private DataColumn columnduguje;
            private DataColumn columnIDDOKUMENT;
            private DataColumn columnIDMJESTOTROSKA;
            private DataColumn columnIDORGJED;
            private DataColumn columnkonto;
            private DataColumn columnNAZIVKONTO;
            private DataColumn columnNAZIVMT;
            private DataColumn columnNAZIVOJ;
            private DataColumn columnOPISKNJIZENJA;
            private DataColumn columnORIGINALNIDOKUMENT;
            private DataColumn columnPOTRAZUJE;
            private DataColumn columnPS;
            private DataColumn columnSKRACENI;

            public event S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler S_FIN_KONTO_KARTICERowChanged;

            public event S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler S_FIN_KONTO_KARTICERowChanging;

            public event S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler S_FIN_KONTO_KARTICERowDeleted;

            public event S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler S_FIN_KONTO_KARTICERowDeleting;

            public S_FIN_KONTO_KARTICEDataTable()
            {
                this.TableName = "S_FIN_KONTO_KARTICE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal S_FIN_KONTO_KARTICEDataTable(DataTable table) : base(table.TableName)
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

            protected S_FIN_KONTO_KARTICEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void AddS_FIN_KONTO_KARTICERow(S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow row)
            {
                this.Rows.Add(row);
            }

            public S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow AddS_FIN_KONTO_KARTICERow(decimal duguje, decimal pOTRAZUJE, string konto, DateTime dATUMDOK, string sKRACENI, int bROJDOK, int bROJSTAVKE, string oPISKNJIZENJA, string nAZIVKONTO, int iDDOKUMENT, int iDORGJED, int iDMJESTOTROSKA, string oRIGINALNIDOKUMENT, string nAZIVOJ, string nAZIVMT, bool pS)
            {
                S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow row = (S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow) this.NewRow();
                row.ItemArray = new object[] { duguje, pOTRAZUJE, konto, dATUMDOK, sKRACENI, bROJDOK, bROJSTAVKE, oPISKNJIZENJA, nAZIVKONTO, iDDOKUMENT, iDORGJED, iDMJESTOTROSKA, oRIGINALNIDOKUMENT, nAZIVOJ, nAZIVMT, pS };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICEDataTable table = (S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                S_FIN_KONTO_KARTICEDataSet set = new S_FIN_KONTO_KARTICEDataSet();
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
                this.columnkonto = new DataColumn("konto", typeof(string), "", MappingType.Element);
                this.columnkonto.Caption = "konto";
                this.columnkonto.MaxLength = 15;
                this.columnkonto.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnkonto.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnkonto.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnkonto.ExtendedProperties.Add("IsKey", "false");
                this.columnkonto.ExtendedProperties.Add("ReadOnly", "true");
                this.columnkonto.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnkonto.ExtendedProperties.Add("Description", "konto");
                this.columnkonto.ExtendedProperties.Add("Length", "15");
                this.columnkonto.ExtendedProperties.Add("Decimals", "0");
                this.columnkonto.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnkonto.ExtendedProperties.Add("IsInReader", "true");
                this.columnkonto.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnkonto.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnkonto.ExtendedProperties.Add("Deklarit.InternalName", "konto");
                this.Columns.Add(this.columnkonto);
                this.columnDATUMDOK = new DataColumn("DATUMDOK", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMDOK.Caption = "DATUMDOK";
                this.columnDATUMDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMDOK.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMDOK.ExtendedProperties.Add("Description", "DATUMDOK");
                this.columnDATUMDOK.ExtendedProperties.Add("Length", "8");
                this.columnDATUMDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMDOK.ExtendedProperties.Add("Deklarit.InternalName", "DATUMDOK");
                this.Columns.Add(this.columnDATUMDOK);

                this.columnDATUMPRIJAVE = new DataColumn("DATUMPRIJAVE", typeof(DateTime), "", MappingType.Element);
                this.columnDATUMPRIJAVE.Caption = "DATUMPRIJAVE";
                this.columnDATUMPRIJAVE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("IsKey", "false");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("DeklaritType", "date");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Description", "DATUMPRIJAVE");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Length", "8");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Decimals", "0");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("IsInReader", "true");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDATUMPRIJAVE.ExtendedProperties.Add("Deklarit.InternalName", "DATUMPRIJAVE");
                this.Columns.Add(this.columnDATUMPRIJAVE);

                this.columnSKRACENI = new DataColumn("SKRACENI", typeof(string), "", MappingType.Element);
                this.columnSKRACENI.Caption = "SKRACENI";
                this.columnSKRACENI.MaxLength = 50;
                this.columnSKRACENI.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSKRACENI.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSKRACENI.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSKRACENI.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSKRACENI.ExtendedProperties.Add("IsKey", "false");
                this.columnSKRACENI.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSKRACENI.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSKRACENI.ExtendedProperties.Add("Description", "SKRACENI");
                this.columnSKRACENI.ExtendedProperties.Add("Length", "50");
                this.columnSKRACENI.ExtendedProperties.Add("Decimals", "0");
                this.columnSKRACENI.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSKRACENI.ExtendedProperties.Add("IsInReader", "true");
                this.columnSKRACENI.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSKRACENI.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSKRACENI.ExtendedProperties.Add("Deklarit.InternalName", "SKRACENI");
                this.Columns.Add(this.columnSKRACENI);
                this.columnBROJDOK = new DataColumn("BROJDOK", typeof(int), "", MappingType.Element);
                this.columnBROJDOK.Caption = "BROJDOK";
                this.columnBROJDOK.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJDOK.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJDOK.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJDOK.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJDOK.ExtendedProperties.Add("Description", "BROJDOK");
                this.columnBROJDOK.ExtendedProperties.Add("Length", "8");
                this.columnBROJDOK.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJDOK.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJDOK.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJDOK.ExtendedProperties.Add("Deklarit.InternalName", "BROJDOK");
                this.Columns.Add(this.columnBROJDOK);
                this.columnBROJSTAVKE = new DataColumn("BROJSTAVKE", typeof(int), "", MappingType.Element);
                this.columnBROJSTAVKE.Caption = "BROJSTAVKE";
                this.columnBROJSTAVKE.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("IsKey", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("ReadOnly", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("DeklaritType", "int");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Description", "BROJSTAVKE");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Length", "6");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Decimals", "0");
                this.columnBROJSTAVKE.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("IsInReader", "true");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnBROJSTAVKE.ExtendedProperties.Add("Deklarit.InternalName", "BROJSTAVKE");
                this.Columns.Add(this.columnBROJSTAVKE);
                this.columnOPISKNJIZENJA = new DataColumn("OPISKNJIZENJA", typeof(string), "", MappingType.Element);
                this.columnOPISKNJIZENJA.Caption = "OPISKNJIZENJA";
                this.columnOPISKNJIZENJA.MaxLength = 150;
                this.columnOPISKNJIZENJA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("IsKey", "false");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Description", "OPISKNJIZENJA");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Length", "150");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Decimals", "0");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("IsInReader", "true");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOPISKNJIZENJA.ExtendedProperties.Add("Deklarit.InternalName", "OPISKNJIZENJA");
                this.Columns.Add(this.columnOPISKNJIZENJA);
                this.columnNAZIVKONTO = new DataColumn("NAZIVKONTO", typeof(string), "", MappingType.Element);
                this.columnNAZIVKONTO.Caption = "Naziv konta";
                this.columnNAZIVKONTO.MaxLength = 150;
                this.columnNAZIVKONTO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Description", "Naziv konta");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Length", "150");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVKONTO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("RightTrim", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVKONTO.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVKONTO");
                this.Columns.Add(this.columnNAZIVKONTO);
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
                this.columnIDDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "IDDOKUMENT");
                this.Columns.Add(this.columnIDDOKUMENT);
                this.columnIDORGJED = new DataColumn("IDORGJED", typeof(int), "", MappingType.Element);
                this.columnIDORGJED.Caption = "Šifra OJ";
                this.columnIDORGJED.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDORGJED.ExtendedProperties.Add("IsKey", "false");
                this.columnIDORGJED.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDORGJED.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDORGJED.ExtendedProperties.Add("Description", "Šifra OJ");
                this.columnIDORGJED.ExtendedProperties.Add("Length", "8");
                this.columnIDORGJED.ExtendedProperties.Add("Decimals", "0");
                this.columnIDORGJED.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDORGJED.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDORGJED.ExtendedProperties.Add("Deklarit.InternalName", "IDORGJED");
                this.Columns.Add(this.columnIDORGJED);
                this.columnIDMJESTOTROSKA = new DataColumn("IDMJESTOTROSKA", typeof(int), "", MappingType.Element);
                this.columnIDMJESTOTROSKA.Caption = "Šifra MT";
                this.columnIDMJESTOTROSKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsKey", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Description", "Šifra MT");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Length", "8");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Decimals", "0");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDMJESTOTROSKA.ExtendedProperties.Add("Deklarit.InternalName", "IDMJESTOTROSKA");
                this.Columns.Add(this.columnIDMJESTOTROSKA);
                this.columnORIGINALNIDOKUMENT = new DataColumn("ORIGINALNIDOKUMENT", typeof(string), "", MappingType.Element);
                this.columnORIGINALNIDOKUMENT.Caption = "ORIGINALNIDOKUMENT";
                this.columnORIGINALNIDOKUMENT.MaxLength = 50;
                this.columnORIGINALNIDOKUMENT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("IsKey", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Description", "ORIGINALNIDOKUMENT");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Length", "50");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Decimals", "0");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("IsInReader", "true");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnORIGINALNIDOKUMENT.ExtendedProperties.Add("Deklarit.InternalName", "ORIGINALNIDOKUMENT");
                this.Columns.Add(this.columnORIGINALNIDOKUMENT);
                this.columnNAZIVOJ = new DataColumn("NAZIVOJ", typeof(string), "", MappingType.Element);
                this.columnNAZIVOJ.Caption = "NAZIVOJ";
                this.columnNAZIVOJ.MaxLength = 150;
                this.columnNAZIVOJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVOJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVOJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVOJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVOJ.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVOJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVOJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVOJ.ExtendedProperties.Add("Description", "NAZIVOJ");
                this.columnNAZIVOJ.ExtendedProperties.Add("Length", "150");
                this.columnNAZIVOJ.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVOJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVOJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVOJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVOJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVOJ.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVOJ");
                this.Columns.Add(this.columnNAZIVOJ);
                this.columnNAZIVMT = new DataColumn("NAZIVMT", typeof(string), "", MappingType.Element);
                this.columnNAZIVMT.Caption = "NAZIVMT";
                this.columnNAZIVMT.MaxLength = 150;
                this.columnNAZIVMT.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnNAZIVMT.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnNAZIVMT.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnNAZIVMT.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnNAZIVMT.ExtendedProperties.Add("IsKey", "false");
                this.columnNAZIVMT.ExtendedProperties.Add("ReadOnly", "true");
                this.columnNAZIVMT.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnNAZIVMT.ExtendedProperties.Add("Description", "NAZIVMT");
                this.columnNAZIVMT.ExtendedProperties.Add("Length", "150");
                this.columnNAZIVMT.ExtendedProperties.Add("Decimals", "0");
                this.columnNAZIVMT.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnNAZIVMT.ExtendedProperties.Add("IsInReader", "true");
                this.columnNAZIVMT.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnNAZIVMT.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnNAZIVMT.ExtendedProperties.Add("Deklarit.InternalName", "NAZIVMT");
                this.Columns.Add(this.columnNAZIVMT);
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
                this.columnPS.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPS.ExtendedProperties.Add("IsInReader", "true");
                this.columnPS.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPS.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPS.ExtendedProperties.Add("Deklarit.InternalName", "PS");
                this.Columns.Add(this.columnPS);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "S_FIN_KONTO_KARTICE");
                this.ExtendedProperties.Add("Description", "S_FIN_KONTO_KARTICE");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnduguje = this.Columns["duguje"];
                this.columnPOTRAZUJE = this.Columns["POTRAZUJE"];
                this.columnkonto = this.Columns["konto"];
                this.columnDATUMDOK = this.Columns["DATUMDOK"];
                this.columnDATUMPRIJAVE = this.Columns["DATUMPRIJAVE"];
                this.columnSKRACENI = this.Columns["SKRACENI"];
                this.columnBROJDOK = this.Columns["BROJDOK"];
                this.columnBROJSTAVKE = this.Columns["BROJSTAVKE"];
                this.columnOPISKNJIZENJA = this.Columns["OPISKNJIZENJA"];
                this.columnNAZIVKONTO = this.Columns["NAZIVKONTO"];
                this.columnIDDOKUMENT = this.Columns["IDDOKUMENT"];
                this.columnIDORGJED = this.Columns["IDORGJED"];
                this.columnIDMJESTOTROSKA = this.Columns["IDMJESTOTROSKA"];
                this.columnORIGINALNIDOKUMENT = this.Columns["ORIGINALNIDOKUMENT"];
                this.columnNAZIVOJ = this.Columns["NAZIVOJ"];
                this.columnNAZIVMT = this.Columns["NAZIVMT"];
                this.columnPS = this.Columns["PS"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow(builder);
            }

            public S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow NewS_FIN_KONTO_KARTICERow()
            {
                return (S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S_FIN_KONTO_KARTICERowChanged != null)
                {
                    S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler handler = this.S_FIN_KONTO_KARTICERowChanged;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEvent((S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S_FIN_KONTO_KARTICERowChanging != null)
                {
                    S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler handler = this.S_FIN_KONTO_KARTICERowChanging;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEvent((S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S_FIN_KONTO_KARTICERowDeleted != null)
                {
                    S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler handler = this.S_FIN_KONTO_KARTICERowDeleted;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEvent((S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S_FIN_KONTO_KARTICERowDeleting != null)
                {
                    S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEventHandler handler = this.S_FIN_KONTO_KARTICERowDeleting;
                    if (handler != null)
                    {
                        handler(this, new S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEvent((S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow) e.Row, e.Action));
                    }
                }
            }

            public void RemoveS_FIN_KONTO_KARTICERow(S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BROJDOKColumn
            {
                get
                {
                    return this.columnBROJDOK;
                }
            }

            public DataColumn BROJSTAVKEColumn
            {
                get
                {
                    return this.columnBROJSTAVKE;
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

            public DataColumn DATUMDOKColumn
            {
                get
                {
                    return this.columnDATUMDOK;
                }
            }

            public DataColumn DATUMPRIJAVEColumn
            {
                get
                {
                    return this.columnDATUMPRIJAVE;
                }
            }

            public DataColumn dugujeColumn
            {
                get
                {
                    return this.columnduguje;
                }
            }

            public DataColumn IDDOKUMENTColumn
            {
                get
                {
                    return this.columnIDDOKUMENT;
                }
            }

            public DataColumn IDMJESTOTROSKAColumn
            {
                get
                {
                    return this.columnIDMJESTOTROSKA;
                }
            }

            public DataColumn IDORGJEDColumn
            {
                get
                {
                    return this.columnIDORGJED;
                }
            }

            public S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow this[int index]
            {
                get
                {
                    return (S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow) this.Rows[index];
                }
            }

            public DataColumn kontoColumn
            {
                get
                {
                    return this.columnkonto;
                }
            }

            public DataColumn NAZIVKONTOColumn
            {
                get
                {
                    return this.columnNAZIVKONTO;
                }
            }

            public DataColumn NAZIVMTColumn
            {
                get
                {
                    return this.columnNAZIVMT;
                }
            }

            public DataColumn NAZIVOJColumn
            {
                get
                {
                    return this.columnNAZIVOJ;
                }
            }

            public DataColumn OPISKNJIZENJAColumn
            {
                get
                {
                    return this.columnOPISKNJIZENJA;
                }
            }

            public DataColumn ORIGINALNIDOKUMENTColumn
            {
                get
                {
                    return this.columnORIGINALNIDOKUMENT;
                }
            }

            public DataColumn POTRAZUJEColumn
            {
                get
                {
                    return this.columnPOTRAZUJE;
                }
            }

            public DataColumn PSColumn
            {
                get
                {
                    return this.columnPS;
                }
            }

            public DataColumn SKRACENIColumn
            {
                get
                {
                    return this.columnSKRACENI;
                }
            }
        }

        public class S_FIN_KONTO_KARTICERow : DataRow
        {
            private S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICEDataTable tableS_FIN_KONTO_KARTICE;

            internal S_FIN_KONTO_KARTICERow(DataRowBuilder rb) : base(rb)
            {
                this.tableS_FIN_KONTO_KARTICE = (S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICEDataTable) this.Table;
            }

            public bool IsBROJDOKNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.BROJDOKColumn);
            }

            public bool IsBROJSTAVKENull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.BROJSTAVKEColumn);
            }

            public bool IsDATUMDOKNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.DATUMDOKColumn);
            }


            public bool IsDATUMPRIJAVENull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.DATUMDOKColumn);
            }

            public bool IsdugujeNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.dugujeColumn);
            }

            public bool IsIDDOKUMENTNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.IDDOKUMENTColumn);
            }

            public bool IsIDMJESTOTROSKANull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.IDMJESTOTROSKAColumn);
            }

            public bool IsIDORGJEDNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.IDORGJEDColumn);
            }

            public bool IskontoNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.kontoColumn);
            }

            public bool IsNAZIVKONTONull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.NAZIVKONTOColumn);
            }

            public bool IsNAZIVMTNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.NAZIVMTColumn);
            }

            public bool IsNAZIVOJNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.NAZIVOJColumn);
            }

            public bool IsOPISKNJIZENJANull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.OPISKNJIZENJAColumn);
            }

            public bool IsORIGINALNIDOKUMENTNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.ORIGINALNIDOKUMENTColumn);
            }

            public bool IsPOTRAZUJENull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.POTRAZUJEColumn);
            }

            public bool IsPSNull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.PSColumn);
            }

            public bool IsSKRACENINull()
            {
                return this.IsNull(this.tableS_FIN_KONTO_KARTICE.SKRACENIColumn);
            }

            public void SetBROJDOKNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.BROJDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetBROJSTAVKENull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.BROJSTAVKEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMDOKNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.DATUMDOKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDATUMPRIJAVENull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.DATUMPRIJAVEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetdugujeNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.dugujeColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDDOKUMENTNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.IDDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDMJESTOTROSKANull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.IDMJESTOTROSKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDORGJEDNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.IDORGJEDColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetkontoNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.kontoColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVKONTONull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.NAZIVKONTOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVMTNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.NAZIVMTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetNAZIVOJNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.NAZIVOJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOPISKNJIZENJANull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.OPISKNJIZENJAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetORIGINALNIDOKUMENTNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.ORIGINALNIDOKUMENTColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOTRAZUJENull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.POTRAZUJEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPSNull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.PSColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSKRACENINull()
            {
                this[this.tableS_FIN_KONTO_KARTICE.SKRACENIColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public int BROJDOK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_KONTO_KARTICE.BROJDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJDOK because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.BROJDOKColumn] = value;
                }
            }

            public int BROJSTAVKE
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_KONTO_KARTICE.BROJSTAVKEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value BROJSTAVKE because it is DBNull.", innerException);
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.BROJSTAVKEColumn] = value;
                }
            }

            public DateTime DATUMDOK
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_KONTO_KARTICE.DATUMDOKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMDOK because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.DATUMDOKColumn] = value;
                }
            }

            public DateTime DATUMPRIJAVE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = Conversions.ToDate(this[this.tableS_FIN_KONTO_KARTICE.DATUMPRIJAVEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                        //InvalidCastException innerException = exception1;
                        //throw new StrongTypingException("Cannot get value DATUMDOK because it is DBNull.", innerException);
                    }
                    return time;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.DATUMPRIJAVEColumn] = value;
                }
            }

            public decimal duguje
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_KONTO_KARTICE.dugujeColumn]);
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
                    this[this.tableS_FIN_KONTO_KARTICE.dugujeColumn] = value;
                }
            }

            public int IDDOKUMENT
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_KONTO_KARTICE.IDDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.IDDOKUMENTColumn] = value;
                }
            }

            public int IDMJESTOTROSKA
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_KONTO_KARTICE.IDMJESTOTROSKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.IDMJESTOTROSKAColumn] = value;
                }
            }

            public int IDORGJED
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tableS_FIN_KONTO_KARTICE.IDORGJEDColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.IDORGJEDColumn] = value;
                }
            }

            public string konto
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_KONTO_KARTICE.kontoColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.kontoColumn] = value;
                }
            }

            public string NAZIVKONTO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_KONTO_KARTICE.NAZIVKONTOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.NAZIVKONTOColumn] = value;
                }
            }

            public string NAZIVMT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_KONTO_KARTICE.NAZIVMTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.NAZIVMTColumn] = value;
                }
            }

            public string NAZIVOJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_KONTO_KARTICE.NAZIVOJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.NAZIVOJColumn] = value;
                }
            }

            public string OPISKNJIZENJA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_KONTO_KARTICE.OPISKNJIZENJAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.OPISKNJIZENJAColumn] = value;
                }
            }

            public string ORIGINALNIDOKUMENT
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_KONTO_KARTICE.ORIGINALNIDOKUMENTColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.ORIGINALNIDOKUMENTColumn] = value;
                }
            }

            public decimal POTRAZUJE
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tableS_FIN_KONTO_KARTICE.POTRAZUJEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.POTRAZUJEColumn] = value;
                }
            }

            public bool PS
            {
                get
                {
                    bool flag = false;
                    try
                    {
                        flag = Conversions.ToBoolean(this[this.tableS_FIN_KONTO_KARTICE.PSColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return flag;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.PSColumn] = value;
                }
            }

            public string SKRACENI
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tableS_FIN_KONTO_KARTICE.SKRACENIColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tableS_FIN_KONTO_KARTICE.SKRACENIColumn] = value;
                }
            }
        }

        public class S_FIN_KONTO_KARTICERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow eventRow;

            public S_FIN_KONTO_KARTICERowChangeEvent(S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow row, DataRowAction action)
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

            public S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void S_FIN_KONTO_KARTICERowChangeEventHandler(object sender, S_FIN_KONTO_KARTICEDataSet.S_FIN_KONTO_KARTICERowChangeEvent e);
    }
}

