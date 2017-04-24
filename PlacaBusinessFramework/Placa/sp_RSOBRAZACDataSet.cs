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
    public class sp_RSOBRAZACDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private sp_RSOBRAZACDataTable tablesp_RSOBRAZAC;

        public sp_RSOBRAZACDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            this.EndInit();
        }

        protected sp_RSOBRAZACDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["sp_RSOBRAZAC"] != null)
                    {
                        this.Tables.Add(new sp_RSOBRAZACDataTable(dataSet.Tables["sp_RSOBRAZAC"]));
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
            sp_RSOBRAZACDataSet set = (sp_RSOBRAZACDataSet) base.Clone();
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
            sp_RSOBRAZACDataSet set = new sp_RSOBRAZACDataSet();
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
            this.ExtendedProperties.Add("DataAdapterName", "sp_RSOBRAZACDataAdapter");
            this.ExtendedProperties.Add("BigImage", " ");
            this.ExtendedProperties.Add("SmallImage", " ");
            this.ExtendedProperties.Add("Image", " ");
            this.ExtendedProperties.Add("Deklarit.PermissionBaseId", "2020");
            this.ExtendedProperties.Add("DataSetName", "sp_RSOBRAZACDataSet");
            this.ExtendedProperties.Add("DataAdapterInterfaceName", "Isp_RSOBRAZACDataAdapter");
            this.ExtendedProperties.Add("ObjectName", "sp_RSOBRAZAC");
            this.ExtendedProperties.Add("ObjectDescription", "sp_RSOBRAZAC");
            this.ExtendedProperties.Add("ObjectType", "DataProvider");
            this.ExtendedProperties.Add("ObjectPath", @"\DataProviders\DP_Placa");
            this.ExtendedProperties.Add("NameSpace", "Placa");
            this.ExtendedProperties.Add("DataChangeFrequency", "PrettyOften");
            this.ExtendedProperties.Add("CachePriority", "Medium");
            this.ExtendedProperties.Add("Deklarit.StoredProcedure", "S_RSM_OBRAZAC");
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
            this.DataSetName = "sp_RSOBRAZACDataSet";
            this.Namespace = "http://www.tempuri.org/sp_RSOBRAZAC";
            this.tablesp_RSOBRAZAC = new sp_RSOBRAZACDataTable();
            this.Tables.Add(this.tablesp_RSOBRAZAC);
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
            this.tablesp_RSOBRAZAC = (sp_RSOBRAZACDataTable) this.Tables["sp_RSOBRAZAC"];
            if (initTable && (this.tablesp_RSOBRAZAC != null))
            {
                this.tablesp_RSOBRAZAC.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["sp_RSOBRAZAC"] != null)
                {
                    this.Tables.Add(new sp_RSOBRAZACDataTable(dataSet.Tables["sp_RSOBRAZAC"]));
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

        private bool ShouldSerializesp_RSOBRAZAC()
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
        public sp_RSOBRAZACDataTable sp_RSOBRAZAC
        {
            get
            {
                return this.tablesp_RSOBRAZAC;
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
        public class sp_RSOBRAZACDataTable : DataTable, IEnumerable
        {
            private DataColumn columnB;
            private DataColumn columnDOO;
            private DataColumn columnIDDOPRINOSMIO1;
            private DataColumn columnIDDOPRINOSMIO2;
            private DataColumn columnIDRADNIK;
            private DataColumn columnIZNOSISPLACENEPLACERSMB;
            private DataColumn columnIZNOSOBRACUNANEPLACERSMB;
            private DataColumn columnIZNOSOSNOVICEZADOPRINOSERSMB;
            private DataColumn columnMBGOSIGURANIKA;
            private DataColumn columnMIO1RSMB;
            private DataColumn columnMIO2RSMB;
            private DataColumn columnOD;
            private DataColumn columnOIB;
            private DataColumn columnOO;
            private DataColumn columnPOREZIPRIREZ;
            private DataColumn columnPREZIMEIIME;
            private DataColumn columnREDNIBROJ;
            private DataColumn columnSIFRAGRADARADA;
            private DataColumn columnSTOPAMIO1;
            private DataColumn columnSTOPAMIO2;

            public event sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler sp_RSOBRAZACRowChanged;

            public event sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler sp_RSOBRAZACRowChanging;

            public event sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler sp_RSOBRAZACRowDeleted;

            public event sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler sp_RSOBRAZACRowDeleting;

            public sp_RSOBRAZACDataTable()
            {
                this.TableName = "sp_RSOBRAZAC";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal sp_RSOBRAZACDataTable(DataTable table) : base(table.TableName)
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

            protected sp_RSOBRAZACDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            public void Addsp_RSOBRAZACRow(sp_RSOBRAZACDataSet.sp_RSOBRAZACRow row)
            {
                this.Rows.Add(row);
            }

            public sp_RSOBRAZACDataSet.sp_RSOBRAZACRow Addsp_RSOBRAZACRow(string rEDNIBROJ, int iDRADNIK, string pREZIMEIIME, string mBGOSIGURANIKA, string sIFRAGRADARADA, string oO, string b, string oD, string dOO, decimal iZNOSOBRACUNANEPLACERSMB, decimal iZNOSOSNOVICEZADOPRINOSERSMB, int iDDOPRINOSMIO1, decimal sTOPAMIO1, decimal mIO1RSMB, int iDDOPRINOSMIO2, decimal sTOPAMIO2, decimal mIO2RSMB, decimal pOREZIPRIREZ, decimal iZNOSISPLACENEPLACERSMB, string oIB)
            {
                sp_RSOBRAZACDataSet.sp_RSOBRAZACRow row = (sp_RSOBRAZACDataSet.sp_RSOBRAZACRow) this.NewRow();
                row.ItemArray = new object[] { 
                    rEDNIBROJ, iDRADNIK, pREZIMEIIME, mBGOSIGURANIKA, sIFRAGRADARADA, oO, b, oD, dOO, iZNOSOBRACUNANEPLACERSMB, iZNOSOSNOVICEZADOPRINOSERSMB, iDDOPRINOSMIO1, sTOPAMIO1, mIO1RSMB, iDDOPRINOSMIO2, sTOPAMIO2, 
                    mIO2RSMB, pOREZIPRIREZ, iZNOSISPLACENEPLACERSMB, oIB
                 };
                this.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                sp_RSOBRAZACDataSet.sp_RSOBRAZACDataTable table = (sp_RSOBRAZACDataSet.sp_RSOBRAZACDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            public IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(sp_RSOBRAZACDataSet.sp_RSOBRAZACRow);
            }

            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type2 = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                sp_RSOBRAZACDataSet set = new sp_RSOBRAZACDataSet();
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
                this.columnREDNIBROJ = new DataColumn("REDNIBROJ", typeof(string), "", MappingType.Element);
                this.columnREDNIBROJ.Caption = "REDNIBROJ";
                this.columnREDNIBROJ.MaxLength = 5;
                this.columnREDNIBROJ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("IsKey", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnREDNIBROJ.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnREDNIBROJ.ExtendedProperties.Add("Description", "REDNIBROJ");
                this.columnREDNIBROJ.ExtendedProperties.Add("Length", "5");
                this.columnREDNIBROJ.ExtendedProperties.Add("Decimals", "0");
                this.columnREDNIBROJ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnREDNIBROJ.ExtendedProperties.Add("IsInReader", "true");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnREDNIBROJ.ExtendedProperties.Add("Deklarit.InternalName", "REDNIBROJ");
                this.Columns.Add(this.columnREDNIBROJ);
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
                this.columnPREZIMEIIME = new DataColumn("PREZIMEIIME", typeof(string), "", MappingType.Element);
                this.columnPREZIMEIIME.Caption = "PREZIMEIIME";
                this.columnPREZIMEIIME.MaxLength = 100;
                this.columnPREZIMEIIME.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("IsKey", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPREZIMEIIME.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Description", "PREZIMEIIME");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Length", "100");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Decimals", "0");
                this.columnPREZIMEIIME.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPREZIMEIIME.ExtendedProperties.Add("IsInReader", "true");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPREZIMEIIME.ExtendedProperties.Add("Deklarit.InternalName", "PREZIMEIIME");
                this.Columns.Add(this.columnPREZIMEIIME);
                this.columnMBGOSIGURANIKA = new DataColumn("MBGOSIGURANIKA", typeof(string), "", MappingType.Element);
                this.columnMBGOSIGURANIKA.Caption = "MBGOSIGURANIKA";
                this.columnMBGOSIGURANIKA.MaxLength = 13;
                this.columnMBGOSIGURANIKA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("IsKey", "false");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Description", "MBGOSIGURANIKA");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Length", "13");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Decimals", "0");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("IsInReader", "true");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMBGOSIGURANIKA.ExtendedProperties.Add("Deklarit.InternalName", "MBGOSIGURANIKA");
                this.Columns.Add(this.columnMBGOSIGURANIKA);
                this.columnSIFRAGRADARADA = new DataColumn("SIFRAGRADARADA", typeof(string), "", MappingType.Element);
                this.columnSIFRAGRADARADA.Caption = "SIFRAGRADARADA";
                this.columnSIFRAGRADARADA.MaxLength = 4;
                this.columnSIFRAGRADARADA.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("IsKey", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Description", "SIFRAGRADARADA");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Length", "4");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Decimals", "0");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("IsInReader", "true");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSIFRAGRADARADA.ExtendedProperties.Add("Deklarit.InternalName", "SIFRAGRADARADA");
                this.Columns.Add(this.columnSIFRAGRADARADA);
                this.columnOO = new DataColumn("OO", typeof(string), "", MappingType.Element);
                this.columnOO.Caption = "OO";
                this.columnOO.MaxLength = 2;
                this.columnOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOO.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOO.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOO.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOO.ExtendedProperties.Add("IsKey", "false");
                this.columnOO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOO.ExtendedProperties.Add("Description", "OO");
                this.columnOO.ExtendedProperties.Add("Length", "2");
                this.columnOO.ExtendedProperties.Add("Decimals", "0");
                this.columnOO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOO.ExtendedProperties.Add("IsInReader", "true");
                this.columnOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOO.ExtendedProperties.Add("Deklarit.InternalName", "OO");
                this.Columns.Add(this.columnOO);
                this.columnB = new DataColumn("B", typeof(string), "", MappingType.Element);
                this.columnB.Caption = "B";
                this.columnB.MaxLength = 1;
                this.columnB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnB.ExtendedProperties.Add("IsKey", "false");
                this.columnB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnB.ExtendedProperties.Add("Description", "B");
                this.columnB.ExtendedProperties.Add("Length", "1");
                this.columnB.ExtendedProperties.Add("Decimals", "0");
                this.columnB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnB.ExtendedProperties.Add("IsInReader", "true");
                this.columnB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnB.ExtendedProperties.Add("Deklarit.InternalName", "B");
                this.Columns.Add(this.columnB);
                this.columnOD = new DataColumn("OD", typeof(string), "", MappingType.Element);
                this.columnOD.Caption = "OD";
                this.columnOD.MaxLength = 2;
                this.columnOD.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOD.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOD.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOD.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOD.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOD.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOD.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOD.ExtendedProperties.Add("IsKey", "false");
                this.columnOD.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOD.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOD.ExtendedProperties.Add("Description", "OD");
                this.columnOD.ExtendedProperties.Add("Length", "2");
                this.columnOD.ExtendedProperties.Add("Decimals", "0");
                this.columnOD.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOD.ExtendedProperties.Add("IsInReader", "true");
                this.columnOD.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOD.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOD.ExtendedProperties.Add("Deklarit.InternalName", "OD");
                this.Columns.Add(this.columnOD);
                this.columnDOO = new DataColumn("DOO", typeof(string), "", MappingType.Element);
                this.columnDOO.Caption = "DOO";
                this.columnDOO.MaxLength = 2;
                this.columnDOO.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnDOO.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnDOO.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnDOO.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnDOO.ExtendedProperties.Add("IsKey", "false");
                this.columnDOO.ExtendedProperties.Add("ReadOnly", "true");
                this.columnDOO.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnDOO.ExtendedProperties.Add("Description", "DOO");
                this.columnDOO.ExtendedProperties.Add("Length", "2");
                this.columnDOO.ExtendedProperties.Add("Decimals", "0");
                this.columnDOO.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnDOO.ExtendedProperties.Add("IsInReader", "true");
                this.columnDOO.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnDOO.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnDOO.ExtendedProperties.Add("Deklarit.InternalName", "DOO");
                this.Columns.Add(this.columnDOO);
                this.columnIZNOSOBRACUNANEPLACERSMB = new DataColumn("IZNOSOBRACUNANEPLACERSMB", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOBRACUNANEPLACERSMB.Caption = "IZNOSOBRACUNANEPLACERSMB";
                this.columnIZNOSOBRACUNANEPLACERSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Description", "IZNOSOBRACUNANEPLACERSMB");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOBRACUNANEPLACERSMB.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOBRACUNANEPLACERSMB");
                this.Columns.Add(this.columnIZNOSOBRACUNANEPLACERSMB);
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB = new DataColumn("IZNOSOSNOVICEZADOPRINOSERSMB", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.Caption = "IZNOSOSNOVICEZADOPRINOSERSMB";
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Description", "IZNOSOSNOVICEZADOPRINOSERSMB");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSOSNOVICEZADOPRINOSERSMB");
                this.Columns.Add(this.columnIZNOSOSNOVICEZADOPRINOSERSMB);
                this.columnIDDOPRINOSMIO1 = new DataColumn("IDDOPRINOSMIO1", typeof(int), "", MappingType.Element);
                this.columnIDDOPRINOSMIO1.Caption = "IDDOPRINOSMI O1";
                this.columnIDDOPRINOSMIO1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("IsKey", "false");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Description", "IDDOPRINOSMI O1");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Length", "5");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOPRINOSMIO1.ExtendedProperties.Add("Deklarit.InternalName", "IDDOPRINOSMIO1");
                this.Columns.Add(this.columnIDDOPRINOSMIO1);
                this.columnSTOPAMIO1 = new DataColumn("STOPAMIO1", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAMIO1.Caption = "STOPAMI O1";
                this.columnSTOPAMIO1.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAMIO1.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAMIO1.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAMIO1.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAMIO1.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Description", "STOPAMI O1");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Length", "5");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAMIO1.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAMIO1.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTOPAMIO1.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAMIO1.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAMIO1.ExtendedProperties.Add("Deklarit.InternalName", "STOPAMIO1");
                this.Columns.Add(this.columnSTOPAMIO1);
                this.columnMIO1RSMB = new DataColumn("MIO1RSMB", typeof(decimal), "", MappingType.Element);
                this.columnMIO1RSMB.Caption = "MIO1 RSMB";
                this.columnMIO1RSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMIO1RSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnMIO1RSMB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMIO1RSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMIO1RSMB.ExtendedProperties.Add("Description", "MIO1 RSMB");
                this.columnMIO1RSMB.ExtendedProperties.Add("Length", "12");
                this.columnMIO1RSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnMIO1RSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMIO1RSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMIO1RSMB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMIO1RSMB.ExtendedProperties.Add("IsInReader", "true");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMIO1RSMB.ExtendedProperties.Add("Deklarit.InternalName", "MIO1RSMB");
                this.Columns.Add(this.columnMIO1RSMB);
                this.columnIDDOPRINOSMIO2 = new DataColumn("IDDOPRINOSMIO2", typeof(int), "", MappingType.Element);
                this.columnIDDOPRINOSMIO2.Caption = "IDDOPRINOSMI O2";
                this.columnIDDOPRINOSMIO2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("IsKey", "false");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Description", "IDDOPRINOSMI O2");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Length", "5");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Decimals", "0");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("IsInReader", "true");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIDDOPRINOSMIO2.ExtendedProperties.Add("Deklarit.InternalName", "IDDOPRINOSMIO2");
                this.Columns.Add(this.columnIDDOPRINOSMIO2);
                this.columnSTOPAMIO2 = new DataColumn("STOPAMIO2", typeof(decimal), "", MappingType.Element);
                this.columnSTOPAMIO2.Caption = "STOPAMI O2";
                this.columnSTOPAMIO2.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnSTOPAMIO2.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnSTOPAMIO2.ExtendedProperties.Add("IsKey", "false");
                this.columnSTOPAMIO2.ExtendedProperties.Add("ReadOnly", "true");
                this.columnSTOPAMIO2.ExtendedProperties.Add("DeklaritType", "int");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Description", "STOPAMI O2");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Length", "5");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Decimals", "2");
                this.columnSTOPAMIO2.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnSTOPAMIO2.ExtendedProperties.Add("DomainType", "MALIIZNOSI");
                this.columnSTOPAMIO2.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnSTOPAMIO2.ExtendedProperties.Add("IsInReader", "true");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnSTOPAMIO2.ExtendedProperties.Add("Deklarit.InternalName", "STOPAMIO2");
                this.Columns.Add(this.columnSTOPAMIO2);
                this.columnMIO2RSMB = new DataColumn("MIO2RSMB", typeof(decimal), "", MappingType.Element);
                this.columnMIO2RSMB.Caption = "MIO2 RSMB";
                this.columnMIO2RSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnMIO2RSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnMIO2RSMB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnMIO2RSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnMIO2RSMB.ExtendedProperties.Add("Description", "MIO2 RSMB");
                this.columnMIO2RSMB.ExtendedProperties.Add("Length", "12");
                this.columnMIO2RSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnMIO2RSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnMIO2RSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnMIO2RSMB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnMIO2RSMB.ExtendedProperties.Add("IsInReader", "true");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnMIO2RSMB.ExtendedProperties.Add("Deklarit.InternalName", "MIO2RSMB");
                this.Columns.Add(this.columnMIO2RSMB);
                this.columnPOREZIPRIREZ = new DataColumn("POREZIPRIREZ", typeof(decimal), "", MappingType.Element);
                this.columnPOREZIPRIREZ.Caption = "Porez i prirez";
                this.columnPOREZIPRIREZ.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsKey", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("ReadOnly", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("DeklaritType", "int");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Description", "Porez i prirez");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Length", "12");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Decimals", "2");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("IsInReader", "true");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnPOREZIPRIREZ.ExtendedProperties.Add("Deklarit.InternalName", "POREZIPRIREZ");
                this.Columns.Add(this.columnPOREZIPRIREZ);
                this.columnIZNOSISPLACENEPLACERSMB = new DataColumn("IZNOSISPLACENEPLACERSMB", typeof(decimal), "", MappingType.Element);
                this.columnIZNOSISPLACENEPLACERSMB.Caption = "IZNOSISPLACENEPLACERSMB";
                this.columnIZNOSISPLACENEPLACERSMB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("IsKey", "false");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("DeklaritType", "int");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Description", "IZNOSISPLACENEPLACERSMB");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Length", "12");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Decimals", "2");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("IsDomainAttribute", "true");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("DomainType", "VELIKIIZNOSI");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("IsInReader", "true");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnIZNOSISPLACENEPLACERSMB.ExtendedProperties.Add("Deklarit.InternalName", "IZNOSISPLACENEPLACERSMB");
                this.Columns.Add(this.columnIZNOSISPLACENEPLACERSMB);
                this.columnOIB = new DataColumn("OIB", typeof(string), "", MappingType.Element);
                this.columnOIB.Caption = "OIB";
                this.columnOIB.MaxLength = 11;
                this.columnOIB.DefaultValue = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsDescription", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnForm", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsVisibleOnWorkWith", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinGridFormat", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.WinInputMask", "");
                this.columnOIB.ExtendedProperties.Add("Deklarit.RelevantData", "false");
                this.columnOIB.ExtendedProperties.Add("IsKey", "false");
                this.columnOIB.ExtendedProperties.Add("ReadOnly", "true");
                this.columnOIB.ExtendedProperties.Add("DeklaritType", "svchar");
                this.columnOIB.ExtendedProperties.Add("Description", "OIB");
                this.columnOIB.ExtendedProperties.Add("Length", "11");
                this.columnOIB.ExtendedProperties.Add("Decimals", "0");
                this.columnOIB.ExtendedProperties.Add("AllowDBNulls", "true");
                this.columnOIB.ExtendedProperties.Add("IsInReader", "true");
                this.columnOIB.ExtendedProperties.Add("Deklarit.Casing", "default");
                this.columnOIB.ExtendedProperties.Add("Deklarit.IsPassword", "false");
                this.columnOIB.ExtendedProperties.Add("Deklarit.InternalName", "OIB");
                this.Columns.Add(this.columnOIB);
                this.ExtendedProperties.Add("ParentLvl", "");
                this.ExtendedProperties.Add("LevelName", "sp_RSOBRAZAC");
                this.ExtendedProperties.Add("Description", "SP_RSOBRAZAC");
                this.ExtendedProperties.Add("HasOrder", "false");
                this.ExtendedProperties.Add("OrderAttributes", "");
                this.ExtendedProperties.Add("Deklarit.NumberOfRows", "0");
            }

            internal void InitVars()
            {
                this.columnREDNIBROJ = this.Columns["REDNIBROJ"];
                this.columnIDRADNIK = this.Columns["IDRADNIK"];
                this.columnPREZIMEIIME = this.Columns["PREZIMEIIME"];
                this.columnMBGOSIGURANIKA = this.Columns["MBGOSIGURANIKA"];
                this.columnSIFRAGRADARADA = this.Columns["SIFRAGRADARADA"];
                this.columnOO = this.Columns["OO"];
                this.columnB = this.Columns["B"];
                this.columnOD = this.Columns["OD"];
                this.columnDOO = this.Columns["DOO"];
                this.columnIZNOSOBRACUNANEPLACERSMB = this.Columns["IZNOSOBRACUNANEPLACERSMB"];
                this.columnIZNOSOSNOVICEZADOPRINOSERSMB = this.Columns["IZNOSOSNOVICEZADOPRINOSERSMB"];
                this.columnIDDOPRINOSMIO1 = this.Columns["IDDOPRINOSMIO1"];
                this.columnSTOPAMIO1 = this.Columns["STOPAMIO1"];
                this.columnMIO1RSMB = this.Columns["MIO1RSMB"];
                this.columnIDDOPRINOSMIO2 = this.Columns["IDDOPRINOSMIO2"];
                this.columnSTOPAMIO2 = this.Columns["STOPAMIO2"];
                this.columnMIO2RSMB = this.Columns["MIO2RSMB"];
                this.columnPOREZIPRIREZ = this.Columns["POREZIPRIREZ"];
                this.columnIZNOSISPLACENEPLACERSMB = this.Columns["IZNOSISPLACENEPLACERSMB"];
                this.columnOIB = this.Columns["OIB"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new sp_RSOBRAZACDataSet.sp_RSOBRAZACRow(builder);
            }

            public sp_RSOBRAZACDataSet.sp_RSOBRAZACRow Newsp_RSOBRAZACRow()
            {
                return (sp_RSOBRAZACDataSet.sp_RSOBRAZACRow) this.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.sp_RSOBRAZACRowChanged != null)
                {
                    sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler handler = this.sp_RSOBRAZACRowChanged;
                    if (handler != null)
                    {
                        handler(this, new sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEvent((sp_RSOBRAZACDataSet.sp_RSOBRAZACRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.sp_RSOBRAZACRowChanging != null)
                {
                    sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler handler = this.sp_RSOBRAZACRowChanging;
                    if (handler != null)
                    {
                        handler(this, new sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEvent((sp_RSOBRAZACDataSet.sp_RSOBRAZACRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.sp_RSOBRAZACRowDeleted != null)
                {
                    sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler handler = this.sp_RSOBRAZACRowDeleted;
                    if (handler != null)
                    {
                        handler(this, new sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEvent((sp_RSOBRAZACDataSet.sp_RSOBRAZACRow) e.Row, e.Action));
                    }
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.sp_RSOBRAZACRowDeleting != null)
                {
                    sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEventHandler handler = this.sp_RSOBRAZACRowDeleting;
                    if (handler != null)
                    {
                        handler(this, new sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEvent((sp_RSOBRAZACDataSet.sp_RSOBRAZACRow) e.Row, e.Action));
                    }
                }
            }

            public void Removesp_RSOBRAZACRow(sp_RSOBRAZACDataSet.sp_RSOBRAZACRow row)
            {
                this.Rows.Remove(row);
            }

            public DataColumn BColumn
            {
                get
                {
                    return this.columnB;
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

            public DataColumn DOOColumn
            {
                get
                {
                    return this.columnDOO;
                }
            }

            public DataColumn IDDOPRINOSMIO1Column
            {
                get
                {
                    return this.columnIDDOPRINOSMIO1;
                }
            }

            public DataColumn IDDOPRINOSMIO2Column
            {
                get
                {
                    return this.columnIDDOPRINOSMIO2;
                }
            }

            public DataColumn IDRADNIKColumn
            {
                get
                {
                    return this.columnIDRADNIK;
                }
            }

            public sp_RSOBRAZACDataSet.sp_RSOBRAZACRow this[int index]
            {
                get
                {
                    return (sp_RSOBRAZACDataSet.sp_RSOBRAZACRow) this.Rows[index];
                }
            }

            public DataColumn IZNOSISPLACENEPLACERSMBColumn
            {
                get
                {
                    return this.columnIZNOSISPLACENEPLACERSMB;
                }
            }

            public DataColumn IZNOSOBRACUNANEPLACERSMBColumn
            {
                get
                {
                    return this.columnIZNOSOBRACUNANEPLACERSMB;
                }
            }

            public DataColumn IZNOSOSNOVICEZADOPRINOSERSMBColumn
            {
                get
                {
                    return this.columnIZNOSOSNOVICEZADOPRINOSERSMB;
                }
            }

            public DataColumn MBGOSIGURANIKAColumn
            {
                get
                {
                    return this.columnMBGOSIGURANIKA;
                }
            }

            public DataColumn MIO1RSMBColumn
            {
                get
                {
                    return this.columnMIO1RSMB;
                }
            }

            public DataColumn MIO2RSMBColumn
            {
                get
                {
                    return this.columnMIO2RSMB;
                }
            }

            public DataColumn ODColumn
            {
                get
                {
                    return this.columnOD;
                }
            }

            public DataColumn OIBColumn
            {
                get
                {
                    return this.columnOIB;
                }
            }

            public DataColumn OOColumn
            {
                get
                {
                    return this.columnOO;
                }
            }

            public DataColumn POREZIPRIREZColumn
            {
                get
                {
                    return this.columnPOREZIPRIREZ;
                }
            }

            public DataColumn PREZIMEIIMEColumn
            {
                get
                {
                    return this.columnPREZIMEIIME;
                }
            }

            public DataColumn REDNIBROJColumn
            {
                get
                {
                    return this.columnREDNIBROJ;
                }
            }

            public DataColumn SIFRAGRADARADAColumn
            {
                get
                {
                    return this.columnSIFRAGRADARADA;
                }
            }

            public DataColumn STOPAMIO1Column
            {
                get
                {
                    return this.columnSTOPAMIO1;
                }
            }

            public DataColumn STOPAMIO2Column
            {
                get
                {
                    return this.columnSTOPAMIO2;
                }
            }
        }

        public class sp_RSOBRAZACRow : DataRow
        {
            private sp_RSOBRAZACDataSet.sp_RSOBRAZACDataTable tablesp_RSOBRAZAC;

            internal sp_RSOBRAZACRow(DataRowBuilder rb) : base(rb)
            {
                this.tablesp_RSOBRAZAC = (sp_RSOBRAZACDataSet.sp_RSOBRAZACDataTable) this.Table;
            }

            public bool IsBNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.BColumn);
            }

            public bool IsDOONull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.DOOColumn);
            }

            public bool IsIDDOPRINOSMIO1Null()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.IDDOPRINOSMIO1Column);
            }

            public bool IsIDDOPRINOSMIO2Null()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.IDDOPRINOSMIO2Column);
            }

            public bool IsIDRADNIKNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.IDRADNIKColumn);
            }

            public bool IsIZNOSISPLACENEPLACERSMBNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.IZNOSISPLACENEPLACERSMBColumn);
            }

            public bool IsIZNOSOBRACUNANEPLACERSMBNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.IZNOSOBRACUNANEPLACERSMBColumn);
            }

            public bool IsIZNOSOSNOVICEZADOPRINOSERSMBNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.IZNOSOSNOVICEZADOPRINOSERSMBColumn);
            }

            public bool IsMBGOSIGURANIKANull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.MBGOSIGURANIKAColumn);
            }

            public bool IsMIO1RSMBNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.MIO1RSMBColumn);
            }

            public bool IsMIO2RSMBNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.MIO2RSMBColumn);
            }

            public bool IsODNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.ODColumn);
            }

            public bool IsOIBNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.OIBColumn);
            }

            public bool IsOONull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.OOColumn);
            }

            public bool IsPOREZIPRIREZNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.POREZIPRIREZColumn);
            }

            public bool IsPREZIMEIIMENull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.PREZIMEIIMEColumn);
            }

            public bool IsREDNIBROJNull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.REDNIBROJColumn);
            }

            public bool IsSIFRAGRADARADANull()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.SIFRAGRADARADAColumn);
            }

            public bool IsSTOPAMIO1Null()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.STOPAMIO1Column);
            }

            public bool IsSTOPAMIO2Null()
            {
                return this.IsNull(this.tablesp_RSOBRAZAC.STOPAMIO2Column);
            }

            public void SetBNull()
            {
                this[this.tablesp_RSOBRAZAC.BColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetDOONull()
            {
                this[this.tablesp_RSOBRAZAC.DOOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDDOPRINOSMIO1Null()
            {
                this[this.tablesp_RSOBRAZAC.IDDOPRINOSMIO1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDDOPRINOSMIO2Null()
            {
                this[this.tablesp_RSOBRAZAC.IDDOPRINOSMIO2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIDRADNIKNull()
            {
                this[this.tablesp_RSOBRAZAC.IDRADNIKColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSISPLACENEPLACERSMBNull()
            {
                this[this.tablesp_RSOBRAZAC.IZNOSISPLACENEPLACERSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOBRACUNANEPLACERSMBNull()
            {
                this[this.tablesp_RSOBRAZAC.IZNOSOBRACUNANEPLACERSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetIZNOSOSNOVICEZADOPRINOSERSMBNull()
            {
                this[this.tablesp_RSOBRAZAC.IZNOSOSNOVICEZADOPRINOSERSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMBGOSIGURANIKANull()
            {
                this[this.tablesp_RSOBRAZAC.MBGOSIGURANIKAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMIO1RSMBNull()
            {
                this[this.tablesp_RSOBRAZAC.MIO1RSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetMIO2RSMBNull()
            {
                this[this.tablesp_RSOBRAZAC.MIO2RSMBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetODNull()
            {
                this[this.tablesp_RSOBRAZAC.ODColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOIBNull()
            {
                this[this.tablesp_RSOBRAZAC.OIBColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetOONull()
            {
                this[this.tablesp_RSOBRAZAC.OOColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPOREZIPRIREZNull()
            {
                this[this.tablesp_RSOBRAZAC.POREZIPRIREZColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetPREZIMEIIMENull()
            {
                this[this.tablesp_RSOBRAZAC.PREZIMEIIMEColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetREDNIBROJNull()
            {
                this[this.tablesp_RSOBRAZAC.REDNIBROJColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSIFRAGRADARADANull()
            {
                this[this.tablesp_RSOBRAZAC.SIFRAGRADARADAColumn] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAMIO1Null()
            {
                this[this.tablesp_RSOBRAZAC.STOPAMIO1Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public void SetSTOPAMIO2Null()
            {
                this[this.tablesp_RSOBRAZAC.STOPAMIO2Column] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }

            public string B
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.BColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.BColumn] = value;
                }
            }

            public string DOO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.DOOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.DOOColumn] = value;
                }
            }

            public int IDDOPRINOSMIO1
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_RSOBRAZAC.IDDOPRINOSMIO1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.IDDOPRINOSMIO1Column] = value;
                }
            }

            public int IDDOPRINOSMIO2
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_RSOBRAZAC.IDDOPRINOSMIO2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.IDDOPRINOSMIO2Column] = value;
                }
            }

            public int IDRADNIK
            {
                get
                {
                    int num = 0;
                    try
                    {
                        num = Conversions.ToInteger(this[this.tablesp_RSOBRAZAC.IDRADNIKColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.IDRADNIKColumn] = value;
                }
            }

            public decimal IZNOSISPLACENEPLACERSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.IZNOSISPLACENEPLACERSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.IZNOSISPLACENEPLACERSMBColumn] = value;
                }
            }

            public decimal IZNOSOBRACUNANEPLACERSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.IZNOSOBRACUNANEPLACERSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.IZNOSOBRACUNANEPLACERSMBColumn] = value;
                }
            }

            public decimal IZNOSOSNOVICEZADOPRINOSERSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.IZNOSOSNOVICEZADOPRINOSERSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.IZNOSOSNOVICEZADOPRINOSERSMBColumn] = value;
                }
            }

            public string MBGOSIGURANIKA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.MBGOSIGURANIKAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.MBGOSIGURANIKAColumn] = value;
                }
            }

            public decimal MIO1RSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.MIO1RSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.MIO1RSMBColumn] = value;
                }
            }

            public decimal MIO2RSMB
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.MIO2RSMBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.MIO2RSMBColumn] = value;
                }
            }

            public string OD
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.ODColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.ODColumn] = value;
                }
            }

            public string OIB
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.OIBColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.OIBColumn] = value;
                }
            }

            public string OO
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.OOColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.OOColumn] = value;
                }
            }

            public decimal POREZIPRIREZ
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.POREZIPRIREZColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.POREZIPRIREZColumn] = value;
                }
            }

            public string PREZIMEIIME
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.PREZIMEIIMEColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.PREZIMEIIMEColumn] = value;
                }
            }

            public string REDNIBROJ
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.REDNIBROJColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.REDNIBROJColumn] = value;
                }
            }

            public string SIFRAGRADARADA
            {
                get
                {
                    string str = string.Empty;
                    try
                    {
                        str = Conversions.ToString(this[this.tablesp_RSOBRAZAC.SIFRAGRADARADAColumn]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return str;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.SIFRAGRADARADAColumn] = value;
                }
            }

            public decimal STOPAMIO1
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.STOPAMIO1Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.STOPAMIO1Column] = value;
                }
            }

            public decimal STOPAMIO2
            {
                get
                {
                    decimal num = 0;
                    try
                    {
                        num = Conversions.ToDecimal(this[this.tablesp_RSOBRAZAC.STOPAMIO2Column]);
                    }
                    catch (InvalidCastException exception1)
                    {
                        throw exception1;
                    }
                    return num;
                }
                set
                {
                    this[this.tablesp_RSOBRAZAC.STOPAMIO2Column] = value;
                }
            }
        }

        public class sp_RSOBRAZACRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private sp_RSOBRAZACDataSet.sp_RSOBRAZACRow eventRow;

            public sp_RSOBRAZACRowChangeEvent(sp_RSOBRAZACDataSet.sp_RSOBRAZACRow row, DataRowAction action)
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

            public sp_RSOBRAZACDataSet.sp_RSOBRAZACRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void sp_RSOBRAZACRowChangeEventHandler(object sender, sp_RSOBRAZACDataSet.sp_RSOBRAZACRowChangeEvent e);
    }
}

